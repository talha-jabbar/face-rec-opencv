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
        public Form1()
        {
            InitializeComponent();
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
        List<string> names;
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
            AddPerson ap = new AddPerson();
            ap.Show();
        }
    }
}
