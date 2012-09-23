using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

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

        

        private void btn_done_Click(object sender, EventArgs e)
        {
            name = txt_name.Text;
            bool added;
            //Add the name and the images to the file return bool and display a message box

            int count = images.Count;

            for (int i = 0; i < count; i++)
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FRImages");
                Image image = new Bitmap(images[i]);
                images[i] = System.IO.Directory.GetCurrentDirectory() + @"\" + @"Images\" + txt_name.Text + System.IO.Path.GetFileName(images[i]);
                image.Save(images[i]);
            }

            added = Form1.db.AddToDictionary(name, images);
            if (added && images.Count > 0)
            {
                MessageBox.Show("Added succesfly");
            }

            else
            {   
                MessageBox.Show("Sorry you have to Enter a new name and at least 1 image");
            }
            Form1.itc.AddItem(name, new Bitmap(images[0]));
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
                

                btn_done.Show();
            }
        }

        private void AddPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Enabled = true;
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
