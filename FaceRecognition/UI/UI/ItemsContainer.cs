using System;
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

        public void AddItem(string name, Image pic)
        {
            Item i = new Item(name, pic);
            AddItemToControls(i);
        }

        public void AddItemToControls(Item i)
        {
            i.Click += new EventHandler(i_Click);
            i.DoubleClick += new EventHandler(i_DoubleClick);
            i.Width = this.pnl_items.Width;
            if (items.Count < 1)
            {
                i.Location = this.pnl_items.Location;
            }
            else
            {
                i.Location = new Point(items[items.Count - 1].Location.X, items[items.Count - 1].Location.Y + items[items.Count - 1].Height);
            }
            items.Add(i);
        }       

        public void i_Click(object sender, EventArgs e)
        {
            ItemSelected(sender, e);
            foreach (Item item in items)
            {
                item.LowLight();
            }

            ((Item)sender).HighLight();
            selectedItem = ((Item)sender).NameText;
        }

        public void i_DoubleClick(object sender, EventArgs e)
        {
            ItemEntered(sender, e);
        }

        public void DeleteItem(string name)
        {
            foreach (var item in items)
            {
                if (((Item)item).Text == name)
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
                    items[i].Location = this.pnl_items.Location;
                }
                else
                {
                    items[i].Location = new Point(items[items.Count - 1].Location.X, items[items.Count - 1].Location.Y + items[items.Count - 1].Height);
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