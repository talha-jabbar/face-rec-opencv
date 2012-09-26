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
            this.lbl_profilePic = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_done = new System.Windows.Forms.Button();
            this.btn_AddImage = new System.Windows.Forms.Button();
            this.lbl_edit = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.picBox_close = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_maiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Large)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_maiPanel
            // 
            this.panel_maiPanel.AutoScroll = true;
            this.panel_maiPanel.BackColor = System.Drawing.Color.Transparent;
            this.panel_maiPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_maiPanel.Controls.Add(this.picBox_Large);
            this.panel_maiPanel.Controls.Add(this.lbl_profilePic);
            this.panel_maiPanel.Location = new System.Drawing.Point(4, 277);
            this.panel_maiPanel.Name = "panel_maiPanel";
            this.panel_maiPanel.Size = new System.Drawing.Size(544, 201);
            this.panel_maiPanel.TabIndex = 0;
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
            this.picBox_Large.MouseLeave += new System.EventHandler(this.picBox_Large_MouseLeave);
            // 
            // lbl_profilePic
            // 
            this.lbl_profilePic.AutoSize = true;
            this.lbl_profilePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_profilePic.ForeColor = System.Drawing.Color.Red;
            this.lbl_profilePic.Location = new System.Drawing.Point(82, 171);
            this.lbl_profilePic.Name = "lbl_profilePic";
            this.lbl_profilePic.Size = new System.Drawing.Size(120, 15);
            this.lbl_profilePic.TabIndex = 18;
            this.lbl_profilePic.Text = "Set as Profile Picture";
            this.lbl_profilePic.Visible = false;
            this.lbl_profilePic.Click += new System.EventHandler(this.lbl_profilePic_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_address);
            this.panel1.Controls.Add(this.txt_phone);
            this.panel1.Controls.Add(this.lbl_address);
            this.panel1.Controls.Add(this.lbl_phone);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.btn_done);
            this.panel1.Controls.Add(this.btn_AddImage);
            this.panel1.Controls.Add(this.lbl_edit);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.picBox_close);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 266);
            this.panel1.TabIndex = 11;
            // 
            // txt_address
            // 
            this.txt_address.BackColor = System.Drawing.Color.LightGray;
            this.txt_address.ForeColor = System.Drawing.Color.Black;
            this.txt_address.Location = new System.Drawing.Point(278, 101);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(244, 20);
            this.txt_address.TabIndex = 20;
            this.txt_address.Visible = false;
            // 
            // txt_phone
            // 
            this.txt_phone.BackColor = System.Drawing.Color.LightGray;
            this.txt_phone.ForeColor = System.Drawing.Color.Black;
            this.txt_phone.Location = new System.Drawing.Point(278, 79);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(244, 20);
            this.txt_phone.TabIndex = 19;
            this.txt_phone.Visible = false;
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_address.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_address.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_address.Location = new System.Drawing.Point(277, 101);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(229, 17);
            this.lbl_address.TabIndex = 18;
            this.lbl_address.Text = "User Name From DataBase";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_phone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_phone.Location = new System.Drawing.Point(277, 79);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(229, 17);
            this.lbl_phone.TabIndex = 17;
            this.lbl_phone.Text = "User Name From DataBase";
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.LightGray;
            this.txt_name.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Location = new System.Drawing.Point(278, 57);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(244, 20);
            this.txt_name.TabIndex = 16;
            this.txt_name.Visible = false;
            // 
            // btn_done
            // 
            this.btn_done.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_done.Location = new System.Drawing.Point(393, 236);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(119, 27);
            this.btn_done.TabIndex = 15;
            this.btn_done.Text = "Done";
            this.btn_done.UseVisualStyleBackColor = true;
            this.btn_done.Visible = false;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddImage.Location = new System.Drawing.Point(286, 148);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.Size = new System.Drawing.Size(226, 26);
            this.btn_AddImage.TabIndex = 14;
            this.btn_AddImage.Text = "add image";
            this.btn_AddImage.UseVisualStyleBackColor = true;
            this.btn_AddImage.Visible = false;
            this.btn_AddImage.Click += new System.EventHandler(this.btn_AddImage_Click);
            // 
            // lbl_edit
            // 
            this.lbl_edit.AutoSize = true;
            this.lbl_edit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_edit.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_edit.ForeColor = System.Drawing.Color.Brown;
            this.lbl_edit.Location = new System.Drawing.Point(379, 126);
            this.lbl_edit.Name = "lbl_edit";
            this.lbl_edit.Size = new System.Drawing.Size(45, 23);
            this.lbl_edit.TabIndex = 12;
            this.lbl_edit.Text = "Edit";
            this.lbl_edit.Click += new System.EventHandler(this.lbl_edit_Click);
            this.lbl_edit.MouseEnter += new System.EventHandler(this.lbl_edit_MouseEnter);
            this.lbl_edit.MouseLeave += new System.EventHandler(this.lbl_edit_MouseLeave);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_name.Location = new System.Drawing.Point(277, 57);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(229, 17);
            this.lbl_name.TabIndex = 11;
            this.lbl_name.Text = "User Name From DataBase";
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
            this.picBox_close.MouseEnter += new System.EventHandler(this.picBox_close_MouseEnter);
            this.picBox_close.MouseLeave += new System.EventHandler(this.picBox_close_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(220, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(220, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(219, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.button2.Location = new System.Drawing.Point(393, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 56);
            this.button2.TabIndex = 25;
            this.button2.Text = "From Camera";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.button1.Location = new System.Drawing.Point(249, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 56);
            this.button1.TabIndex = 24;
            this.button1.Text = "From Computer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(550, 491);
            this.Controls.Add(this.panel_maiPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataBaseControl";
            this.Text = "DataBaseControl";
            this.panel_maiPanel.ResumeLayout(false);
            this.panel_maiPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Large)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_maiPanel;
        private System.Windows.Forms.PictureBox picBox_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_edit;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.Button btn_AddImage;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.PictureBox picBox_Large;
        private System.Windows.Forms.Label lbl_profilePic;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}