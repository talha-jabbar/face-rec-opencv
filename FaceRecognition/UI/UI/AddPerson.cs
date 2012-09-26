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
        List<Image> cameraImages;
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
            //TODO: i want to add here .. if camImages == null then form1.frec.savereadyimageslist(camimages,name); else form1.frec.savelist(images, name);
            if (!(cameraImages == null))
            {
                Form1.frec.SaveReadyImageList(cameraImages, txt_name.Text);
            }
            else
                Form1.frec.SaveList(images, txt_name.Text);

            name = txt_name.Text;
            Users u = new Users(-1, name, txt_phone.Text, txt_address.Text);
            
            //Add the name and the images to the file return bool and display a message box

            int count = images.Count;
            List<Images> imagesList = new List<Images>();
            for (int i = 0; i < count; i++)
            {
                imagesList.Add(new Images(-1, images[i], -1));
            }
            Form1.database.Insert(new Person(u, imagesList));
            //added = Form1.db.AddToDictionary(name, images);
            if (images.Count > 0)
            {
                MessageBox.Show("Added succesfly");
            }

            else
            {   
                MessageBox.Show("Sorry you have to Enter a new name and at least 1 image");
            }
            Form1.itc.AddItem(Form1.database.Persons.Count - 1 /*your id here*/, name, new Bitmap(images[0]));
            txt_name.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_phone.Text = string.Empty;
            images = new List<string>();
        }

        private void btn_addImage_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                images = openFileDialog1.FileNames.ToList();
                btn_done.Show();
                btn_done.Visible = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFromCamera addfromcam = new AddFromCamera(this.txt_name.Text,cameraImages,btn_done);
            addfromcam.Show();
        }
    }
}
