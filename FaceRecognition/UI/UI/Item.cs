﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Item : UserControl
    {
        public bool Started = false;
        public bool Selected = false;
        public Color SelectedColor = Color.White;
        public Color HoverColor = Color.Gray;

        public Item()
        {
            InitializeComponent();
        }

        public Item(string name, Image img)
        {
            InitializeComponent();
            NameText = name;
            Pic = img;
        }

        public string NameText
        {
            get { return lbl_Name.Text; }
            set { lbl_Name.Text = value; }
        }

        public Image Pic
        {
            get { return pcb_PersonalPic.Image; }
            set { pcb_PersonalPic.Image = value; }
        }

        public void Item_Click(object sender, EventArgs e)
        {
            if (this.Selected)
            {
                this.Selected = false;              
            }
            else
            {
                this.Selected = true;
            }
            this.Item_MouseEnter(sender, e);
        }

        public void Item_MouseEnter(object sender, EventArgs e)
        {
            
            if (this.Selected)
            {
                this.HighLight();
            }
            else
            {
                this.BackColor = HoverColor;
            }
        }

        public void Item_MouseLeave(object sender, EventArgs e)
        {
            if (this.Selected)
            {
                this.HighLight();
            }
            else
            {
                this.LowLight();
            }
        }
       
        public void HighLight()
        {
            this.BackColor = SelectedColor;
            Selected = true;
        }

        public void LowLight()
        {
            this.BackColor = Color.Empty;
            Selected = false;
        }
    }
}
