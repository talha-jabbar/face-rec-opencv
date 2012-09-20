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

        private ControlCollection items;

        public string selectedItem;

        public ItemsContainer()
        {
            InitializeComponent();
            items = this.Controls;
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

        private void AddItemToControls(Item i)
        {
            i.Click += new EventHandler(Item_Click);
            i.Height = 56;
            i.Width = this.Width;
            if (items.Count < 1)
            {
                i.Location = this.Location;
            }
            else
            {
                i.Location = new Point(items[items.Count - 1].Location.X, items[items.Count - 1].Location.Y + items[items.Count - 1].Height);
            }
            items.Add(i);
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
                    items[i].Location = this.Location;
                }
                else
                {
                    items[i].Location = new Point(items[items.Count - 1].Location.X, items[items.Count - 1].Location.Y + items[items.Count - 1].Height);
                }
            }
        }

        public void Item_Click(object sender, EventArgs e)
        {
            ItemSelected(sender, e);
        }
    }
}