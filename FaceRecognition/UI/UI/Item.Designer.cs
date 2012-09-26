namespace UI
{
    partial class Item
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_MainPnl = new System.Windows.Forms.Panel();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.pcb_PersonalPic = new System.Windows.Forms.PictureBox();
            this.pnl_MainPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PersonalPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_MainPnl
            // 
            this.pnl_MainPnl.BackColor = System.Drawing.Color.Transparent;
            this.pnl_MainPnl.Controls.Add(this.lbl_Name);
            this.pnl_MainPnl.Controls.Add(this.pcb_PersonalPic);
            this.pnl_MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MainPnl.Location = new System.Drawing.Point(0, 0);
            this.pnl_MainPnl.Name = "pnl_MainPnl";
            this.pnl_MainPnl.Size = new System.Drawing.Size(204, 58);
            this.pnl_MainPnl.TabIndex = 0;
            this.pnl_MainPnl.Click += new System.EventHandler(this.Item_Click);
            this.pnl_MainPnl.MouseEnter += new System.EventHandler(this.Item_MouseEnter);
            this.pnl_MainPnl.MouseLeave += new System.EventHandler(this.Item_MouseLeave);
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_Name.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_Name.Location = new System.Drawing.Point(69, 14);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(125, 29);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "Name";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Name.Click += new System.EventHandler(this.Item_Click);
            this.lbl_Name.MouseEnter += new System.EventHandler(this.Item_MouseEnter);
            this.lbl_Name.MouseLeave += new System.EventHandler(this.Item_MouseLeave);
            // 
            // pcb_PersonalPic
            // 
            this.pcb_PersonalPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PersonalPic.Location = new System.Drawing.Point(5, 4);
            this.pcb_PersonalPic.Name = "pcb_PersonalPic";
            this.pcb_PersonalPic.Size = new System.Drawing.Size(58, 51);
            this.pcb_PersonalPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_PersonalPic.TabIndex = 0;
            this.pcb_PersonalPic.TabStop = false;
            this.pcb_PersonalPic.Click += new System.EventHandler(this.Item_Click);
            this.pcb_PersonalPic.MouseEnter += new System.EventHandler(this.Item_MouseEnter);
            this.pcb_PersonalPic.MouseLeave += new System.EventHandler(this.Item_MouseLeave);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_MainPnl);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(204, 58);
            this.pnl_MainPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PersonalPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MainPnl;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.PictureBox pcb_PersonalPic;
    }
}
