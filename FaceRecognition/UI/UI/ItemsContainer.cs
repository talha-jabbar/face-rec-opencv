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
    public partial class ItemsContainer : UserControl
    {
        public delegate void ItemSelectedHandler(object sender, EventArgs e);

        public event ItemSelectedHandler ItemSelected;

        public delegate void ItemEnteredHandler(object sender, EventArgs e);

        public event ItemEnteredHandler ItemEntered;

        public delegate void AddClickedHandler(object sender, EventArgs e);

        public event AddClickedHandler AddClicked;

        public delegate void RemoveClickedHandler(object sender, EventArgs e);

        public event RemoveClickedHandler RemoveClicked;

        public ControlCollection items;

        public string selectedItem;

        public int selectedItemindex;

        public string preSelectedItem;

        public ItemsContainer()
        {
            InitializeComponent();
            items = this.pnl_items.Controls;
        }

        public void AddItem()
        {
            Item i = new Item();
            AddItemToControls(i);
        }

        public void AddItem(int id, string name, Image pic)
        {
            Item i = new Item(id,name, pic);
            AddItemToControls(i);
        }

        public void AddItemToControls(Item i)
        {
            i.Click += new EventHandler(i_Click);
            i.DoubleClick += new EventHandler(i_DoubleClick);
            i.Pcb.Click += new EventHandler(i_Click);
            i.Pcb.DoubleClick += new EventHandler(i_DoubleClick);
            i.LblName.Click += new EventHandler(i_Click);
            i.LblName.DoubleClick += new EventHandler(i_DoubleClick);
            i.MainPanel.Click += new EventHandler(i_Click);
            i.MainPanel.DoubleClick += new EventHandler(i_DoubleClick);

            i.Width = this.pnl_items.Width;
            if (items.Count < 1)
            {
                i.Location = new Point(0,0);
            }
            else
            {
                i.Location = new Point(items[items.Count - 1].Location.X, items[items.Count - 1].Location.Y + items[items.Count - 1].Height);
            }
            items.Add(i);
        }

        public void i_Click(object sender, EventArgs e)
        {
            Item i;
            i = (Item)items[items.IndexOfKey(((Control)sender).AccessibleName)];
            bool select;
            select = i.Selected;

            foreach (Item item in items)
            {
                item.Selected = false;
                item.LowLight();
            }

            if (select)
            {
                i.HighLight();
                i.Selected = true;
                selectedItem = i.NameText;
                selectedItemindex = i.ID;
                preSelectedItem = i.NameText;
                ItemSelected(sender, e);
            }
            else
            {
                preSelectedItem = selectedItem;
                selectedItem = string.Empty;
                //selectedItemindex = -1;
            }
        }

        public void i_DoubleClick(object sender, EventArgs e)
        {
            Item i;
            i = (Item)items[items.IndexOfKey(preSelectedItem)];
            i.HighLight();
            i.Selected = true;
            selectedItem = i.NameText;
            ItemSelected(sender, e);

            ItemEntered(sender, e);

        }

        public void DeleteItem(string name)
        {
            foreach (var item in items)
            {
                if (((Item)item).NameText == name)
                {
                    items.Remove((Control)item);
                    break;
                }
            }
            RefreshItems();
        }

        private void RefreshItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == 0)
                {
                    items[i].Location = new Point(0, 0);
                }
                else
                {
                    items[i].Location = new Point(items[i - 1].Location.X, items[i - 1].Location.Y + items[i- 1].Height);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddClicked(sender, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            RemoveClicked(sender, e);
        }
    }
}