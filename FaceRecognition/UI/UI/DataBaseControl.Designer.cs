namespace UI
{
    partial class DataBaseControl
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseControl));
            this.panel_maiPanel = new System.Windows.Forms.Panel();
            this.picBox_Large = new System.Windows.Forms.PictureBox();
            this.picBox_close = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_done = new System.Windows.Forms.Button();
            this.btn_AddImage = new System.Windows.Forms.Button();
            this.lbl_delete = new System.Windows.Forms.Label();
            this.lbl_edit = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.panel_maiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Large)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_close)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_maiPanel
            // 
            this.panel_maiPanel.AutoScroll = true;
            this.panel_maiPanel.BackColor = System.Drawing.Color.Transparent;
            this.panel_maiPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_maiPanel.Controls.Add(this.picBox_Large);
            this.panel_maiPanel.Location = new System.Drawing.Point(4, 209);
            this.panel_maiPanel.Name = "panel_maiPanel";
            this.panel_maiPanel.Size = new System.Drawing.Size(544, 201);
            this.panel_maiPanel.TabIndex = 0;
            this.panel_maiPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_maiPanel_MouseMove);
            // 
            // picBox_Large
            // 
            this.picBox_Large.Location = new System.Drawing.Point(36, 15);
            this.picBox_Large.Name = "picBox_Large";
            this.picBox_Large.Size = new System.Drawing.Size(168, 158);
            this.picBox_Large.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Large.TabIndex = 17;
            this.picBox_Large.TabStop = false;
            this.picBox_Large.Visible = false;
            // 
            // picBox_close
            // 
            this.picBox_close.BackColor = System.Drawing.Color.Transparent;
            this.picBox_close.Image = global::UI.Properties.Resources.button_cancelOff;
            this.picBox_close.Location = new System.Drawing.Point(492, 7);
            this.picBox_close.Name = "picBox_close";
            this.picBox_close.Size = new System.Drawing.Size(29, 21);
            this.picBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_close.TabIndex = 8;
            this.picBox_close.TabStop = false;
            this.picBox_close.Click += new System.EventHandler(this.picBox_close_Click);
            this.picBox_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_close_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.btn_done);
            this.panel1.Controls.Add(this.btn_AddImage);
            this.panel1.Controls.Add(this.lbl_delete);
            this.panel1.Controls.Add(this.lbl_edit);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.picBox_close);
            this.panel1.Location = new System.Drawing.Point(13, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 198);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_maiPanel_MouseMove);
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.LightGray;
            this.txt_name.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Location = new System.Drawing.Point(217, 74);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(226, 20);
            this.txt_name.TabIndex = 16;
            this.txt_name.Visible = false;
            // 
            // btn_done
            // 
            this.btn_done.Location = new System.Drawing.Point(406, 148);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(112, 23);
            this.btn_done.TabIndex = 15;
            this.btn_done.Text = "Done";
            this.btn_done.UseVisualStyleBackColor = true;
            this.btn_done.Visible = false;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.Location = new System.Drawing.Point(288, 148);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.Size = new System.Drawing.Size(112, 23);
            this.btn_AddImage.TabIndex = 14;
            this.btn_AddImage.Text = "add image";
            this.btn_AddImage.UseVisualStyleBackColor = true;
            this.btn_AddImage.Visible = false;
            this.btn_AddImage.Click += new System.EventHandler(this.btn_AddImage_Click);
            // 
            // lbl_delete
            // 
            this.lbl_delete.AutoSize = true;
            this.lbl_delete.BackColor = System.Drawing.Color.Transparent;
            this.lbl_delete.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_delete.ForeColor = System.Drawing.Color.Brown;
            this.lbl_delete.Location = new System.Drawing.Point(451, 109);
            this.lbl_delete.Name = "lbl_delete";
            this.lbl_delete.Size = new System.Drawing.Size(67, 23);
            this.lbl_delete.TabIndex = 13;
            this.lbl_delete.Text = "Delete";
            this.lbl_delete.Click += new System.EventHandler(this.lbl_delete_Click);
            this.lbl_delete.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_delete_MouseMove);
            // 
            // lbl_edit
            // 
            this.lbl_edit.AutoSize = true;
            this.lbl_edit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_edit.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_edit.ForeColor = System.Drawing.Color.Brown;
            this.lbl_edit.Location = new System.Drawing.Point(402, 109);
            this.lbl_edit.Name = "lbl_edit";
            this.lbl_edit.Size = new System.Drawing.Size(45, 23);
            this.lbl_edit.TabIndex = 12;
            this.lbl_edit.Text = "Edit";
            this.lbl_edit.Click += new System.EventHandler(this.lbl_edit_Click);
            this.lbl_edit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_edit_MouseMove);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_name.Location = new System.Drawing.Point(214, 74);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(229, 17);
            this.lbl_name.TabIndex = 11;
            this.lbl_name.Text = "User Name From DataBase";
            // 
            // DataBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::UI.Properties.Resources.simple_grungy_dark_blue_ipad_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(553, 415);
            this.Controls.Add(this.panel_maiPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataBaseControl";
            this.Text = "DataBaseControl";
            this.panel_maiPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Large)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_close)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_maiPanel;
        private System.Windows.Forms.PictureBox picBox_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_delete;
        private System.Windows.Forms.Label lbl_edit;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.Button btn_AddImage;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.PictureBox picBox_Large;
    }
}