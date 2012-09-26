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
        int x, y;

        bool canMove;

        Bitmap orignalBmp;

        List<string> names;

        public static FaceRecognizer frec;

        string imagePath;
  
        public static ItemsContainer itc;

        public static FRDBFn database;

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
                database.DeletePerson(database.Persons[itc.selectedItemindex].User.UserID);
                //db.deleltedImages.AddRange(db.DatabaseDictionary[itc.selectedItem]);
                itc.DeleteItem(itc.selectedItem);
                //db.DeleteFromDictionary(itc.selectedItem);
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
                frec.FrameGrabberImage(imagePath, this.picBox_Original);
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddPerson ap = new AddPerson(this);
            this.AddOwnedForm(ap);
            this.Enabled = false;
            ap.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateNewItc();
            database.SelectAllUsers();
            frec = new FaceRecognizer();

        }

        public void CreateNewItc()
        {
            itc = this.itemsContainer1;
            itc.AddClicked += new ItemsContainer.AddClickedHandler(itc_AddClicked);
            itc.RemoveClicked += new ItemsContainer.RemoveClickedHandler(itc_RemoveClicked);
            itc.ItemSelected += new ItemsContainer.ItemSelectedHandler(itc_ItemSelected);
            itc.ItemEntered += new ItemsContainer.ItemEnteredHandler(itc_ItemEntered);
            //database.ClearDataBase();
           // db.ReadFileToDictionary(System.Windows.Forms.Application.StartupPath+"\\DataBase.txt");
           // db.ReadFileToDictionary(System.Windows.Forms.Application.StartupPath+"\\DataBase.txt");

        }

        void itc_ItemEntered(object sender, EventArgs e)
        {
            //DataBaseControl dbc = new DataBaseControl(itc.selectedItem, db.DatabaseDictionary[itc.selectedItem]);
            DataBaseControl dbc = new DataBaseControl(database.Persons[itc.selectedItemindex]);
            dbc.Show();
        }

        void itc_ItemSelected(object sender, EventArgs e)
        {
           // Item Selected
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //db.WriteDictionaryToFile(System.Windows.Forms.Application.StartupPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void picBox_close_MouseEnter(object sender, EventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancel;
        }

        private void picBox_close_MouseLeave(object sender, EventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancelOff;

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void streamingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frec.pictureBoxFrameGrabber = this.picBox_Original;
            frec.StartStreaming();
            this.panel_mainPanel.Enabled = false;
            LinkLabel llablStopStreaming = new LinkLabel();
            llablStopStreaming.Text = "Stop Streaming";
            llablStopStreaming.Location = new Point(137, 480);
            this.Controls.Add(llablStopStreaming);
            llablStopStreaming.BringToFront();
            llablStopStreaming.BackColor = Color.Black;
            llablStopStreaming.Font = linkLabel1.Font;
            llablStopStreaming.Click += new EventHandler(llablStopStreaming_Click);
            llablStopStreaming.AutoSize = true;

        }

        void llablStopStreaming_Click(object sender, EventArgs e)
        {
            frec.StopStreaming();
            this.panel_mainPanel.Enabled = true;
            this.Controls.Remove(((LinkLabel)sender));
        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frec.pictureBoxFrameGrabber = this.picBox_Original;
            frec.CaptureFrame();

        }

        private void clearUrDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.ClearDataBase();
            for (int i = 0; i < itc.items.Count; i++)
            {
                itc.items.RemoveAt(i);
                i--;
            }
                CreateNewItc();
                frec = new FaceRecognizer();
        }

        private void panel_mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            canMove = true;
            x = e.X;
            y = e.Y;
        }

        private void panel_mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
        }

        private void panel_mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
    }
}
