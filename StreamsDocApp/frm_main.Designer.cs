namespace StreamsDocApp
{
    partial class frm_main
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
            this.themecontainer = new MonoFlat.MonoFlat_ThemeContainer();
            this.monoFlat_Panel3 = new MonoFlat.MonoFlat_Panel();
            this.monoFlat_NotificationBox1 = new MonoFlat.MonoFlat_NotificationBox();
            this.boxImg = new System.Windows.Forms.PictureBox();
            this.pnl_allPages = new MonoFlat.MonoFlat_Panel();
            this.monoFlat_Panel1 = new MonoFlat.MonoFlat_Panel();
            this.new_note = new MonoFlat.MonoFlat_NotificationBox();
            this.link_path = new MonoFlat.MonoFlat_LinkLabel();
            this.btn_SaveData = new MonoFlat.MonoFlat_Button();
            this.txt_field3 = new MonoFlat.MonoFlat_Label();
            this.txt_field2 = new MonoFlat.MonoFlat_Label();
            this.txt_field1 = new MonoFlat.MonoFlat_Label();
            this.optF3 = new MonoFlat.MonoFlat_RadioButton();
            this.optF2 = new MonoFlat.MonoFlat_RadioButton();
            this.optF1 = new MonoFlat.MonoFlat_RadioButton();
            this.btn_openDoc = new MonoFlat.MonoFlat_Button();
            this.monoFlat_ControlBox1 = new MonoFlat.MonoFlat_ControlBox();
            this.txt_welocme = new MonoFlat.MonoFlat_HeaderLabel();
            this.monoFlat_Panel2 = new MonoFlat.MonoFlat_Panel();
            this.btn_logout = new MonoFlat.MonoFlat_Button();
            this.monoFlat_SocialButton1 = new MonoFlat.MonoFlat_SocialButton();
            this.themecontainer.SuspendLayout();
            this.monoFlat_Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).BeginInit();
            this.monoFlat_Panel1.SuspendLayout();
            this.monoFlat_Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // themecontainer
            // 
            this.themecontainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.themecontainer.Controls.Add(this.monoFlat_Panel2);
            this.themecontainer.Controls.Add(this.monoFlat_Panel3);
            this.themecontainer.Controls.Add(this.pnl_allPages);
            this.themecontainer.Controls.Add(this.monoFlat_Panel1);
            this.themecontainer.Controls.Add(this.monoFlat_ControlBox1);
            this.themecontainer.Controls.Add(this.txt_welocme);
            this.themecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themecontainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.themecontainer.Location = new System.Drawing.Point(0, 0);
            this.themecontainer.Name = "themecontainer";
            this.themecontainer.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.themecontainer.RoundCorners = true;
            this.themecontainer.Sizable = true;
            this.themecontainer.Size = new System.Drawing.Size(1200, 700);
            this.themecontainer.SmartBounds = true;
            this.themecontainer.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.themecontainer.TabIndex = 0;
            // 
            // monoFlat_Panel3
            // 
            this.monoFlat_Panel3.AutoScroll = true;
            this.monoFlat_Panel3.AutoScrollMinSize = new System.Drawing.Size(947, 513);
            this.monoFlat_Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.monoFlat_Panel3.Controls.Add(this.monoFlat_NotificationBox1);
            this.monoFlat_Panel3.Controls.Add(this.boxImg);
            this.monoFlat_Panel3.Location = new System.Drawing.Point(250, 175);
            this.monoFlat_Panel3.Name = "monoFlat_Panel3";
            this.monoFlat_Panel3.Padding = new System.Windows.Forms.Padding(5);
            this.monoFlat_Panel3.Size = new System.Drawing.Size(937, 513);
            this.monoFlat_Panel3.TabIndex = 8;
            this.monoFlat_Panel3.Text = "monoFlat_Panel3";
            // 
            // monoFlat_NotificationBox1
            // 
            this.monoFlat_NotificationBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monoFlat_NotificationBox1.BorderCurve = 20;
            this.monoFlat_NotificationBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.monoFlat_NotificationBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.monoFlat_NotificationBox1.Image = null;
            this.monoFlat_NotificationBox1.Location = new System.Drawing.Point(5, 5);
            this.monoFlat_NotificationBox1.MinimumSize = new System.Drawing.Size(100, 40);
            this.monoFlat_NotificationBox1.Name = "monoFlat_NotificationBox1";
            this.monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Notice;
            this.monoFlat_NotificationBox1.RoundCorners = false;
            this.monoFlat_NotificationBox1.ShowCloseButton = false;
            this.monoFlat_NotificationBox1.Size = new System.Drawing.Size(947, 40);
            this.monoFlat_NotificationBox1.TabIndex = 2;
            this.monoFlat_NotificationBox1.Text = "Use left mouse to draw field coordinates and right mouse to pan image";
            // 
            // boxImg
            // 
            this.boxImg.Location = new System.Drawing.Point(6, 6);
            this.boxImg.Name = "boxImg";
            this.boxImg.Size = new System.Drawing.Size(200, 200);
            this.boxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.boxImg.TabIndex = 1;
            this.boxImg.TabStop = false;
            this.boxImg.Paint += new System.Windows.Forms.PaintEventHandler(this.boxImg_Paint);
            this.boxImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boxImg_MouseDown);
            this.boxImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.boxImg_MouseMove);
            this.boxImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxImg_MouseUp);
            // 
            // pnl_allPages
            // 
            this.pnl_allPages.AutoScroll = true;
            this.pnl_allPages.AutoScrollMinSize = new System.Drawing.Size(0, 454);
            this.pnl_allPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.pnl_allPages.Location = new System.Drawing.Point(10, 234);
            this.pnl_allPages.Name = "pnl_allPages";
            this.pnl_allPages.Padding = new System.Windows.Forms.Padding(5);
            this.pnl_allPages.Size = new System.Drawing.Size(231, 454);
            this.pnl_allPages.TabIndex = 7;
            this.pnl_allPages.Text = "monoFlat_Panel2";
            // 
            // monoFlat_Panel1
            // 
            this.monoFlat_Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.monoFlat_Panel1.Controls.Add(this.new_note);
            this.monoFlat_Panel1.Controls.Add(this.link_path);
            this.monoFlat_Panel1.Controls.Add(this.btn_SaveData);
            this.monoFlat_Panel1.Controls.Add(this.txt_field3);
            this.monoFlat_Panel1.Controls.Add(this.txt_field2);
            this.monoFlat_Panel1.Controls.Add(this.txt_field1);
            this.monoFlat_Panel1.Controls.Add(this.optF3);
            this.monoFlat_Panel1.Controls.Add(this.optF2);
            this.monoFlat_Panel1.Controls.Add(this.optF1);
            this.monoFlat_Panel1.Controls.Add(this.btn_openDoc);
            this.monoFlat_Panel1.Location = new System.Drawing.Point(250, 73);
            this.monoFlat_Panel1.Name = "monoFlat_Panel1";
            this.monoFlat_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.monoFlat_Panel1.Size = new System.Drawing.Size(937, 96);
            this.monoFlat_Panel1.TabIndex = 6;
            this.monoFlat_Panel1.Text = "monoFlat_Panel1";
            // 
            // new_note
            // 
            this.new_note.BorderCurve = 20;
            this.new_note.Font = new System.Drawing.Font("Tahoma", 9F);
            this.new_note.Image = null;
            this.new_note.Location = new System.Drawing.Point(553, 55);
            this.new_note.MinimumSize = new System.Drawing.Size(100, 40);
            this.new_note.Name = "new_note";
            this.new_note.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
            this.new_note.RoundCorners = false;
            this.new_note.ShowCloseButton = true;
            this.new_note.Size = new System.Drawing.Size(373, 40);
            this.new_note.TabIndex = 9;
            this.new_note.Text = "monoFlat_NotificationBox1";
            this.new_note.Visible = false;
            // 
            // link_path
            // 
            this.link_path.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.link_path.AutoSize = true;
            this.link_path.BackColor = System.Drawing.Color.Transparent;
            this.link_path.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.link_path.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_path.LinkColor = System.Drawing.Color.White;
            this.link_path.Location = new System.Drawing.Point(20, 77);
            this.link_path.Name = "link_path";
            this.link_path.Size = new System.Drawing.Size(108, 15);
            this.link_path.TabIndex = 8;
            this.link_path.TabStop = true;
            this.link_path.Text = "document file path";
            this.link_path.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.BackColor = System.Drawing.Color.Transparent;
            this.btn_SaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveData.Enabled = false;
            this.btn_SaveData.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_SaveData.Image = null;
            this.btn_SaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveData.Location = new System.Drawing.Point(780, 8);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(146, 44);
            this.btn_SaveData.TabIndex = 7;
            this.btn_SaveData.Text = "Save";
            this.btn_SaveData.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // txt_field3
            // 
            this.txt_field3.AutoSize = true;
            this.txt_field3.BackColor = System.Drawing.Color.Transparent;
            this.txt_field3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_field3.ForeColor = System.Drawing.Color.Crimson;
            this.txt_field3.Location = new System.Drawing.Point(458, 53);
            this.txt_field3.Name = "txt_field3";
            this.txt_field3.Size = new System.Drawing.Size(42, 19);
            this.txt_field3.TabIndex = 6;
            this.txt_field3.Text = "None";
            // 
            // txt_field2
            // 
            this.txt_field2.AutoSize = true;
            this.txt_field2.BackColor = System.Drawing.Color.Transparent;
            this.txt_field2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_field2.ForeColor = System.Drawing.Color.Crimson;
            this.txt_field2.Location = new System.Drawing.Point(458, 31);
            this.txt_field2.Name = "txt_field2";
            this.txt_field2.Size = new System.Drawing.Size(42, 19);
            this.txt_field2.TabIndex = 6;
            this.txt_field2.Text = "None";
            // 
            // txt_field1
            // 
            this.txt_field1.AutoSize = true;
            this.txt_field1.BackColor = System.Drawing.Color.Transparent;
            this.txt_field1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_field1.ForeColor = System.Drawing.Color.Crimson;
            this.txt_field1.Location = new System.Drawing.Point(458, 9);
            this.txt_field1.Name = "txt_field1";
            this.txt_field1.Size = new System.Drawing.Size(42, 19);
            this.txt_field1.TabIndex = 6;
            this.txt_field1.Text = "None";
            // 
            // optF3
            // 
            this.optF3.Checked = false;
            this.optF3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.optF3.Location = new System.Drawing.Point(314, 53);
            this.optF3.Name = "optF3";
            this.optF3.Size = new System.Drawing.Size(141, 17);
            this.optF3.TabIndex = 5;
            this.optF3.Text = "Field 3 coordinate";
            this.optF3.Click += new System.EventHandler(this.optF1_Click);
            // 
            // optF2
            // 
            this.optF2.Checked = false;
            this.optF2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.optF2.Location = new System.Drawing.Point(314, 31);
            this.optF2.Name = "optF2";
            this.optF2.Size = new System.Drawing.Size(141, 17);
            this.optF2.TabIndex = 5;
            this.optF2.Text = "Field 2 coordinate";
            this.optF2.Click += new System.EventHandler(this.optF1_Click);
            // 
            // optF1
            // 
            this.optF1.Checked = true;
            this.optF1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.optF1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.optF1.Location = new System.Drawing.Point(314, 9);
            this.optF1.Name = "optF1";
            this.optF1.Size = new System.Drawing.Size(141, 17);
            this.optF1.TabIndex = 5;
            this.optF1.Text = "Field 1 coordinate";
            this.optF1.Click += new System.EventHandler(this.optF1_Click);
            // 
            // btn_openDoc
            // 
            this.btn_openDoc.BackColor = System.Drawing.Color.Transparent;
            this.btn_openDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openDoc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_openDoc.Image = null;
            this.btn_openDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_openDoc.Location = new System.Drawing.Point(6, 5);
            this.btn_openDoc.Name = "btn_openDoc";
            this.btn_openDoc.Size = new System.Drawing.Size(268, 41);
            this.btn_openDoc.TabIndex = 4;
            this.btn_openDoc.Text = "Select Docment (Tiff File Format)";
            this.btn_openDoc.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_openDoc.Click += new System.EventHandler(this.btn_openDoc_Click);
            // 
            // monoFlat_ControlBox1
            // 
            this.monoFlat_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monoFlat_ControlBox1.EnableHoverHighlight = false;
            this.monoFlat_ControlBox1.EnableMaximizeButton = false;
            this.monoFlat_ControlBox1.EnableMinimizeButton = true;
            this.monoFlat_ControlBox1.Location = new System.Drawing.Point(1088, 15);
            this.monoFlat_ControlBox1.Name = "monoFlat_ControlBox1";
            this.monoFlat_ControlBox1.Size = new System.Drawing.Size(100, 25);
            this.monoFlat_ControlBox1.TabIndex = 5;
            this.monoFlat_ControlBox1.Text = "monoFlat_ControlBox1";
            // 
            // txt_welocme
            // 
            this.txt_welocme.BackColor = System.Drawing.Color.Transparent;
            this.txt_welocme.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txt_welocme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_welocme.Location = new System.Drawing.Point(434, 9);
            this.txt_welocme.Name = "txt_welocme";
            this.txt_welocme.Size = new System.Drawing.Size(306, 49);
            this.txt_welocme.TabIndex = 0;
            this.txt_welocme.Text = "Administration Panel";
            // 
            // monoFlat_Panel2
            // 
            this.monoFlat_Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.monoFlat_Panel2.Controls.Add(this.monoFlat_SocialButton1);
            this.monoFlat_Panel2.Controls.Add(this.btn_logout);
            this.monoFlat_Panel2.Location = new System.Drawing.Point(13, 73);
            this.monoFlat_Panel2.Name = "monoFlat_Panel2";
            this.monoFlat_Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.monoFlat_Panel2.Size = new System.Drawing.Size(231, 155);
            this.monoFlat_Panel2.TabIndex = 9;
            this.monoFlat_Panel2.Text = "monoFlat_Panel2";
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_logout.Image = null;
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(6, 108);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(202, 41);
            this.btn_logout.TabIndex = 0;
            this.btn_logout.Text = "Logout";
            this.btn_logout.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // monoFlat_SocialButton1
            // 
            this.monoFlat_SocialButton1.BackgroundImage = global::StreamsDocApp.Properties.Resources.user_image_png;
            this.monoFlat_SocialButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.monoFlat_SocialButton1.Image = null;
            this.monoFlat_SocialButton1.Location = new System.Drawing.Point(8, 5);
            this.monoFlat_SocialButton1.Name = "monoFlat_SocialButton1";
            this.monoFlat_SocialButton1.Size = new System.Drawing.Size(54, 54);
            this.monoFlat_SocialButton1.TabIndex = 1;
            this.monoFlat_SocialButton1.Text = "monoFlat_SocialButton1";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.themecontainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_main";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.themecontainer.ResumeLayout(false);
            this.monoFlat_Panel3.ResumeLayout(false);
            this.monoFlat_Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).EndInit();
            this.monoFlat_Panel1.ResumeLayout(false);
            this.monoFlat_Panel1.PerformLayout();
            this.monoFlat_Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public MonoFlat.MonoFlat_HeaderLabel txt_welocme;
        private System.Windows.Forms.PictureBox boxImg;
        private MonoFlat.MonoFlat_Panel monoFlat_Panel1;
        private MonoFlat.MonoFlat_Label txt_field3;
        private MonoFlat.MonoFlat_Label txt_field2;
        private MonoFlat.MonoFlat_Label txt_field1;
        private MonoFlat.MonoFlat_RadioButton optF3;
        private MonoFlat.MonoFlat_RadioButton optF2;
        private MonoFlat.MonoFlat_RadioButton optF1;
        private MonoFlat.MonoFlat_Button btn_openDoc;
        private MonoFlat.MonoFlat_ControlBox monoFlat_ControlBox1;
        private MonoFlat.MonoFlat_Panel monoFlat_Panel3;
        private MonoFlat.MonoFlat_Panel pnl_allPages;
        private MonoFlat.MonoFlat_LinkLabel link_path;
        private MonoFlat.MonoFlat_Button btn_SaveData;
        private MonoFlat.MonoFlat_NotificationBox new_note;
        private MonoFlat.MonoFlat_NotificationBox monoFlat_NotificationBox1;
        public MonoFlat.MonoFlat_ThemeContainer themecontainer;
        private MonoFlat.MonoFlat_Panel monoFlat_Panel2;
        private MonoFlat.MonoFlat_SocialButton monoFlat_SocialButton1;
        private MonoFlat.MonoFlat_Button btn_logout;
    }
}