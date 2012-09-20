using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UI
{
    public partial class Form1 : Form
    {
        Bitmap orignalBmp;

        List<string> names;

        public static Database db = new Database();
        
        ItemsContainer itc;

        public Form1()
        {
            InitializeComponent();

        }

        void itc_RemoveClicked(object sender, EventArgs e)
        {
                throw new NotImplementedException();
        }

        void itc_AddClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancel;
        }

        private void panel_mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancelOff;
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
            itc.AddItem("Ahmed", (Image)new Bitmap(@"C:\Users\EhabMagdy.EhabMagdy-PC\Downloads\frontalimages_manuallyaligned_part1\1a.jpg"));
            itc.AddItem("pola", (Image)new Bitmap(@"C:\Users\EhabMagdy.EhabMagdy-PC\Downloads\frontalimages_manuallyaligned_part1\2a.jpg"));
            itc.AddItem("ehab", (Image)new Bitmap(@"C:\Users\EhabMagdy.EhabMagdy-PC\Downloads\frontalimages_manuallyaligned_part1\3a.jpg"));
            this.Controls[0].Controls.Add(itc);
            itc.AddClicked += new ItemsContainer.AddClickedHandler(itc_AddClicked);
            itc.RemoveClicked += new ItemsContainer.RemoveClickedHandler(itc_RemoveClicked);
            itc.ItemSelected += new ItemsContainer.ItemSelectedHandler(itc_ItemSelected);
            itc.ItemEntered += new ItemsContainer.ItemEnteredHandler(itc_ItemEntered);
            itc.BringToFront();
            db.ReadFileToDictionary("DataBase.txt");
        }

        void itc_ItemEntered(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void itc_ItemSelected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
