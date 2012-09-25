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
        public AddFromCamera()
        {
            InitializeComponent();
            Form1.frec.pictureBoxFrameGrabber = this.pictureBox1;
            Form1.frec.StartStreaming();
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
                Form1.itc.AddItem(0, textBox1.Text, this.pictureBox2.Image);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox2.Visible = false;
            timer1.Stop();
        }
    }
}
