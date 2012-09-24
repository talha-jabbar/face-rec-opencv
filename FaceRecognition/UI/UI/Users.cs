// -----------------------------------------------------------------------
// <copyright file="User.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Users
    {
        private int userID;

        private string name;

        private string phoneNo;

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public Users(int UserID, string Name, string Phone, string Address)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.PhoneNo = Phone;
            this.Address = Address;
        }
    }
}
