using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace UI
{
    public partial class Form1 : Form
    {
        Bitmap orignalBmp;

        List<string> names;

        string imagePath;

        public static Database db = new Database();
        
        public static ItemsContainer itc;

        private FRDBFn database;

        public Form1()
        {
            InitializeComponent();
           // button2_Click(null, null);
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\Images");
            if (!dir.Exists)
            {
                dir.Create();
            }

            database = FRDBFn.Instance;
        }

        void itc_RemoveClicked(object sender, EventArgs e)
        {
            if (itc.selectedItem != string.Empty && itc.selectedItem != null)
            {
                db.deleltedImages.AddRange(db.DatabaseDictionary[itc.selectedItem]);
                itc.DeleteItem(itc.selectedItem);
                db.DeleteFromDictionary(itc.selectedItem);
            }
        }

        void itc_AddClicked(object sender, EventArgs e)
        {
            btn_Add_Click(sender, e);
        }

        private void MovePic()
        {
            animation.Move(picBox_Original, this.Height, this.Width);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp|SVG Files (*.svg)|*.svg";
            openFileDialog1.Title = "Please select an image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                orignalBmp = new Bitmap(openFileDialog1.FileName);
                picBox_Original.Image = orignalBmp;
                imagePath = openFileDialog1.FileName;
            }
        }

        private void picBox_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                names = openFileDialog1.FileNames.ToList();
            }
        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseControl dbc = new DataBaseControl("ay habal w 5alaaaaas", names);
            dbc.Show();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddPerson ap = new AddPerson(this);
            this.AddOwnedForm(ap);
            this.Enabled = false;
            ap.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            itc = new ItemsContainer();
            itc.Location = new Point(this.Width - itc.Width, this.Location.Y );
            itc.Height = this.Height-110;
            this.Controls[0].Controls.Add(itc);
            itc.AddClicked += new ItemsContainer.AddClickedHandler(itc_AddClicked);
            itc.RemoveClicked += new ItemsContainer.RemoveClickedHandler(itc_RemoveClicked);
            itc.ItemSelected += new ItemsContainer.ItemSelectedHandler(itc_ItemSelected);
            itc.ItemEntered += new ItemsContainer.ItemEnteredHandler(itc_ItemEntered);
            itc.BringToFront();
            //db.ReadFileToDictionary(System.Windows.Forms.Application.StartupPath+"\\DataBase.txt");
        }

        void itc_ItemEntered(object sender, EventArgs e)
        {
            DataBaseControl dbc = new DataBaseControl(itc.selectedItem, db.DatabaseDictionary[itc.selectedItem]);
            dbc.Show();
        }

        void itc_ItemSelected(object sender, EventArgs e)
        {
           // Item Selected
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.WriteDictionaryToFile(System.Windows.Forms.Application.StartupPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            unsafe
            {
                int* rectangles= null;
                int* recLables = null;
                int [] ids = {1,1,1,2,2,2};
                string[] images = new string[6];
                images[0] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\1-04.jpg";
                images[1] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\1-05.jpg";
                images[2] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\1-06.jpg";
                images[3] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\2-04.jpg";
                images[4] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\2-05.jpg";
                images[5] = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\2-06.jpg";
                bool train = true;
                int count = 6;
                //string image2Rec = imagePath;
                string image2Rec = "C:\\Users\\EhabMagdy.EhabMagdy-PC\\Downloads\\originalimages_part1\\1-013.jpg";
                string modelPath = System.Windows.Forms.Application.StartupPath;
                File.Copy(@"C:\Users\EhabMagdy.EhabMagdy-PC\Desktop\Shared Folder\FaceRecOpenCV\Debug\FaceRecOpenCV.dll", @"C:\Users\EhabMagdy.EhabMagdy-PC\Desktop\UI\UI\bin\Debug\FaceRecOpenCV.dll", true);
                FROpencv.StartFaceRecognition(image2Rec, modelPath, images, ids, ref rectangles, ref recLables, ref count, train);
            }
            //  FROpencv.StartFaceRecognition(System.Windows.Forms.Application.StartupPath + "\\BinaryDatabase.txt", System.Windows.Forms.Application.StartupPath + "\\model", imagePath, rec, lables, ref count, 1);
        }

        private void picBox_close_MouseEnter(object sender, EventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancel;
        }

        private void picBox_close_MouseLeave(object sender, EventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancelOff;

        } 
    }
}
