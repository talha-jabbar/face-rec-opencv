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
    public partial class AddFromCamera : Form
    {
        string name;
        List<string> images;
        Button done;

        public AddFromCamera(string name, List<string> images, Button done)
        {
            InitializeComponent();
            Form1.frec.pictureBoxFrameGrabber = this.pictureBox1;
            Form1.frec.StartStreaming();
            this.name = name;
            this.images = images;
            this.done = done;
            images = new List<string>();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1.frec.StopStreaming();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Form1.frec.CatchFace(textBox1.Text, this.pictureBox2))
            {
                this.pictureBox2.Visible = true;
                timer1.Start();
                name = textBox1.Text;
                if (images == null)
                    images = new List<string>();
                images.Add(BasicOperations.SaveImage(pictureBox2.Image));
                this.done.Visible = true;
                this.textBox1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox2.Visible = false;
            timer1.Stop();
        }
    }
}
