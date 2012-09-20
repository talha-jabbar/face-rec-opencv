using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class AddPerson : Form
    {
        public static List<string> images;
        public static string name;
        Form1 form;

        public AddPerson(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void picBox_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBox_close_MouseMove(object sender, MouseEventArgs e)
        {
            picBox_close.Image = UI.Properties.Resources.button_cancel;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            name = txt_name.Text;
            bool added;
            //Add the name and the images to the file return bool and display a message box
            Database db = new Database();
            added = db.AddToDictionary(name, images);
            if (added)
            {
                MessageBox.Show("Added succesfly");
            }

            else
            {   
                MessageBox.Show("sorry the name you have entered already founded");
            }

            txt_name.Text = string.Empty;
            images = new List<string>();
        }

        private void btn_addImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                images = openFileDialog1.FileNames.ToList();
            }
        }

        private void AddPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Enabled = true;
        }
    }
}
