namespace Blood_Bank_system
{
    partial class LoginForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Login1Recipient = new System.Windows.Forms.Button();
            this.Login1Donor = new System.Windows.Forms.Button();
            this.Login1admin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::Blood_Bank_system.Properties.Resources.joshua_rawson_harris_1089866_unsplash;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.Close);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::Blood_Bank_system.Properties.Resources.black_grey_gradient_background_for_web;
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.Login1Recipient);
            this.splitContainer1.Panel2.Controls.Add(this.Login1Donor);
            this.splitContainer1.Panel2.Controls.Add(this.Login1admin);
            this.splitContainer1.Size = new System.Drawing.Size(582, 553);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.BackgroundImage = global::Blood_Bank_system.Properties.Resources.fileclose;
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Close.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Close.Location = new System.Drawing.Point(548, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(34, 36);
            this.Close.TabIndex = 0;
            this.Close.Text = ".";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 43);
            this.label2.TabIndex = 24;
            this.label2.Text = "Blood Bank Management System";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Blood_Bank_system.Properties.Resources.G4WRua;
            this.pictureBox1.Location = new System.Drawing.Point(458, 316);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Login1Recipient
            // 
            this.Login1Recipient.BackColor = System.Drawing.Color.DarkGray;
            this.Login1Recipient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login1Recipient.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login1Recipient.Location = new System.Drawing.Point(116, 262);
            this.Login1Recipient.Name = "Login1Recipient";
            this.Login1Recipient.Size = new System.Drawing.Size(338, 64);
            this.Login1Recipient.TabIndex = 27;
            this.Login1Recipient.Text = "Login As Recipient";
            this.Login1Recipient.UseVisualStyleBackColor = false;
            this.Login1Recipient.Click += new System.EventHandler(this.Login1Recipient_Click);
            // 
            // Login1Donor
            // 
            this.Login1Donor.BackColor = System.Drawing.Color.DarkGray;
            this.Login1Donor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login1Donor.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login1Donor.Location = new System.Drawing.Point(116, 160);
            this.Login1Donor.Name = "Login1Donor";
            this.Login1Donor.Size = new System.Drawing.Size(338, 64);
            this.Login1Donor.TabIndex = 26;
            this.Login1Donor.Text = "Login As Donor";
            this.Login1Donor.UseVisualStyleBackColor = false;
            this.Login1Donor.Click += new System.EventHandler(this.Login1Donor_Click);
            // 
            // Login1admin
            // 
            this.Login1admin.BackColor = System.Drawing.Color.DarkGray;
            this.Login1admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login1admin.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login1admin.Location = new System.Drawing.Point(116, 65);
            this.Login1admin.Name = "Login1admin";
            this.Login1admin.Size = new System.Drawing.Size(338, 64);
            this.Login1admin.TabIndex = 25;
            this.Login1admin.Text = "Login As Admin";
            this.Login1admin.UseVisualStyleBackColor = false;
            this.Login1admin.Click += new System.EventHandler(this.Login1admin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Login1Recipient;
        private System.Windows.Forms.Button Login1Donor;
        private System.Windows.Forms.Button Login1admin;
        private System.Windows.Forms.Button Close;
    }
}

