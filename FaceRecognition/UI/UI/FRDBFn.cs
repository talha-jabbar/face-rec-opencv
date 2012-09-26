// -----------------------------------------------------------------------
// <copyright file="FRDBFn.cs" company="">
// </copyright>
// -----------------------------------------------------------------------

namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlServerCe;
    using System.Drawing;
    using System.Data.SqlClient;
    using System.Data;
    using System.IO;

    /// <summary>
    /// </summary>
    public class FRDBFn
    {
        #region Members

        /// <summary>
        /// the sql connection
        /// </summary>
        private SqlCeConnection con;


        /// <summary>
        /// Persons list
        /// </summary>
        private List<Person> persons;

        private static FRDBFn database;

        #endregion

//====================================================================================================================

        #region Properties

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        #endregion

//====================================================================================================================

        /// <summary>
        /// Initializes a new instance of the <see cref="data"/> class.
        /// </summary>
        private FRDBFn()
        {
            con = new SqlCeConnection("Data Source=FRDatabase.sdf");
        }

//====================================================================================================================

        public static FRDBFn Instance
        {
            get
            {
                if (database == null)
                {
                    database = new FRDBFn();
                }
                return database;
            }
        }

//====================================================================================================================
        /// <summary>
        /// Selects all users.
        /// </summary>
        /// <returns></returns>
        public List<Person> SelectAllUsers()
        {
            try
            {
                con.Open();
                string selectUser = @"Select * From Users";
                string selectImage = @"Select * From Images";
                SqlCeCommand cmd = new SqlCeCommand(selectUser, con);
                SqlCeDataReader rdr = cmd.ExecuteReader();
                List<Users> users = new List<Users>();
                List<Images> images = new List<Images>();
                Persons = new List<Person>();

                while (rdr.Read())
                {
                    users.Add(new Users((int)rdr["UserID"], (string)rdr["UserName"], (string)rdr["UserPhone"], (string)rdr["UserAddress"]));
                }

                cmd = new SqlCeCommand(selectImage, con);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    images.Add(new Images((int)rdr["ImageID"], (string)rdr["ImagePath"], (int)rdr["UserID"]));
                }

                int index = 0;

                foreach (Users u in users)
                {
                    List<Images> userImages = new List<Images>();

                    foreach (Images image in images)
                    {
                        if (u.UserID == image.UserID)
                        {
                            userImages.Add(image);
                        }

                    }
                    Form1.itc.AddItem(index/*your id here*/, u.Name, new Bitmap(userImages[0].ImagePath));

                    persons.Add(new Person(u, userImages));
                    index++;
                }

                return persons;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Connect to the database", ex);
            }
            finally
            {
                con.Close();
            }

        }

//====================================================================================================================

        /// <summary>
        /// Inserts the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        public void Insert(Person person)
        {
            try
            {
                con.Open();
                string insertUser = @"Insert Into Users(UserName, UserPhone, UserAddress) Values(@name, @phone, @address)";
                SqlCeCommand cmd = new SqlCeCommand(insertUser, con);
                cmd.Parameters.Add(new SqlCeParameter("@name", person.User.Name));
                cmd.Parameters.Add(new SqlCeParameter("@phone", person.User.PhoneNo));
                cmd.Parameters.Add(new SqlCeParameter("@address", person.User.Address));

                cmd.ExecuteNonQuery();
                int id = -1;

                cmd = new SqlCeCommand("select UserID  From Users where UserID = @@IDENTITY", con);
                SqlCeDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr[0] != DBNull.Value)
                {
                    id = (int)rdr[0];


                    person.User.UserID = id;
                    Persons.Add(person);
                    int count = person.Images.Count;
                    for (int i = 0; i < count; i++)
                    {
                        person.Images[i].UserID = id;
                        InsertImage(id, person.Images[i].ImagePath, false);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Connect to the database", ex);
            }
            finally
            {
                con.Close();
            }
        }


//====================================================================================================================

        /// <summary>
        /// Inserts the image.
        /// </summary>
        /// <param name="UserID">The user ID.</param>
        /// <param name="ImagePath">The image path.</param>
        /// <param name="OpenConnection">if set to <c>true</c> [open connection].</param>
        public void InsertImage(int UserID, string ImagePath, bool OpenConnection)
        {
            try
            {
                if (!OpenConnection)
                {
                    con.Close();
                }
                con.Open();

                string insertStatment = @"Insert Into Images(ImagePath, UserID) Values(@imageName, @UserID)";
                SqlCeCommand cmd = new SqlCeCommand(insertStatment, con);
                cmd.Parameters.Add(new SqlCeParameter("@imageName", ImagePath));
                cmd.Parameters.Add(new SqlCeParameter("@UserID", UserID));
                cmd.ExecuteNonQuery();

                cmd = new SqlCeCommand("Select ImageID From Images Where ImageID = @@IDENTITY ", con);
                SqlCeDataReader rdr = cmd.ExecuteReader();
                rdr.Read();

                int imageId = (int)rdr[0];

                foreach (Person per in Persons)
                {
                    if (per.User.UserID == UserID)
                    {
                        per.Images.Add(new Images(imageId, ImagePath, UserID));
                        break;
                    }
                }
            }

            catch
            {
            }

            finally
            {
                con.Close();
                if (!OpenConnection)
                    con.Open();
            }
        }

//====================================================================================================================

        /// <summary>
        /// Updates the user info.
        /// </summary>
        /// <param name="oldPID">The old PID.</param>
        /// <param name="newPerson">The new person.</param>
        public void UpdateUserInfo(int oldPID, Users newPerson)
        {
            Person oldP;
            int id = -1;

            foreach (Person per in Persons)
            {
                id++;

                if (per.User.UserID == oldPID)
                {
                    break;
                }
            }

            oldP = new Person(Persons[id].User, Persons[id].Images);

            persons[id].User = newPerson;

            try
            {
                con.Open();
                string Update = @"update Users Set UserName = @name, UserPhone = @phone, UserAddress = @address  WHERE UserID = @ID";
                SqlCeCommand cmd = new SqlCeCommand(Update, con);
                cmd.Parameters.Add(new SqlCeParameter("@ID", oldPID));
                cmd.Parameters.Add(new SqlCeParameter("@name", newPerson.Name));
                cmd.Parameters.Add(new SqlCeParameter("@phone", newPerson.PhoneNo));
                cmd.Parameters.Add(new SqlCeParameter("@address", newPerson.Address));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
        }

//====================================================================================================================

        /// <summary>
        /// deletes one image
        /// </summary>
        /// <param name="p">the specified person you will delete his image</param>
        /// <param name="ImageID">the image ID you want to delete</param>
        /// <param name="flag">True if u remove an image</param>
        public void DeleteImage(Person p, int ImageID, bool flag)
        {
            int index = 0;
            Images imag = new Images(-1, "", -1);
            try
            {
                if (flag)
                    con.Open();
                
                string deleteImage = @"DELETE FROM Images WHERE ImageID = @ID";
                SqlCeCommand cmd = new SqlCeCommand(deleteImage, con);
                cmd.Parameters.Add(new SqlCeParameter("@ID", ImageID));
                cmd.ExecuteNonQuery();

                if (flag)
                {
                    index = persons.IndexOf(p);
                    foreach (Images image in persons[index].Images)
                    {
                        if (image.ImageID == ImageID)
                        {
                            imag = image;
                            persons[index].Images.Remove(image);
                            break;
                        }
                    }
                }

                if (!flag)
                {
                    index = 0;
                    foreach (Images image in p.Images)
                    {
                        if (image.ImageID == ImageID)
                        {
                            break;
                        }
                        index++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                if (flag)
                {
                    con.Close();
                    //File.Delete(imag.ImagePath);
                }
                else
                {
                    //File.Delete(p.Images[index].ImagePath);
                }
            }
        }

//====================================================================================================================

        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="ID">The ID.</param>
        public void DeletePerson(int ID)
        {
            Person p;
            int id = -1;

            foreach (Person per in Persons)
            {
                id++;

                if (per.User.UserID == ID)
                {
                    break;
                }
            }

            p = new Person(Persons[id].User, Persons[id].Images);
            Persons.Remove(p);

            try
            {
                con.Open();
                string deleteImage = @"DELETE FROM Users WHERE UserID = @ID";
                SqlCeCommand cmd = new SqlCeCommand(deleteImage, con);
                cmd.Parameters.Add(new SqlCeParameter("@ID", p.User.UserID));
                cmd.ExecuteNonQuery();

                foreach (Images i in p.Images)
                {
                    DeleteImage(p, i.ImageID, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                con.Close();
            }
        }

//====================================================================================================================

        public void ClearDataBase()
        {
            try
            {
                con.Open();
                string clearUsers = @"DELETE FROM Users";
                SqlCeCommand cmd = new SqlCeCommand(clearUsers, con);
                cmd.ExecuteNonQuery();

                string clearImages = @"DELETE FROM Images";
                cmd = new SqlCeCommand(clearImages, con);
                cmd.ExecuteNonQuery();

                persons = new List<Person>();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
