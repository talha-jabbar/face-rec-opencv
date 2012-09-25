// -----------------------------------------------------------------------
// <copyright file="animation.cs" company="">
// </copyright>
// -----------------------------------------------------------------------

namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class animation
    {
        static System.Windows.Forms.Timer t;
        static int counter;
        static PictureBox pictureBox1;
        static int Height, Width;

        /// <summary>
        /// Changes the pic.
        /// </summary>
        /// <param name="pb">The pb.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        public static void Move(PictureBox pb, int height, int width)
        {
            Height = height;
            Width = width;
            pictureBox1 = pb;
            counter = 0;
            t = new System.Windows.Forms.Timer();
            t.Interval = 1;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        /// <summary>
        /// Handles the Tick event of the t control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void t_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                pictureBox1.Location = new Point((pictureBox1.Location.X - 1), (pictureBox1.Location.Y + 2));
                pictureBox1.Height -= 1;
                pictureBox1.Width -= 1;
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }

            if (counter == 200)
                t.Stop();
            counter++;

        }

        static void change()
        {
            for (int i = 0; i < 200; i++ )
            {
                pictureBox1.Location = new Point((pictureBox1.Location.X - 1), (pictureBox1.Location.Y + 2));
                pictureBox1.Height -= 1;
                pictureBox1.Width -= 1;
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }

        }
    }

}
