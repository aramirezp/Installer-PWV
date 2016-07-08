namespace Installer_PWV
{
    partial class configureIIS
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstSites = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWindows = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.imgPath = new System.Windows.Forms.PictureBox();
            this.imgSite = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSite)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select site to install Innovmetric PWV";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Installer_PWV.Properties.Resources.logo;
            this.pictureBox6.Location = new System.Drawing.Point(128, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(188, 50);
            this.pictureBox6.TabIndex = 22;
            this.pictureBox6.TabStop = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(94, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 52);
            this.button2.TabIndex = 23;
            this.button2.Text = "Next Step";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lstSites
            // 
            this.lstSites.FormattingEnabled = true;
            this.lstSites.Location = new System.Drawing.Point(94, 167);
            this.lstSites.Name = "lstSites";
            this.lstSites.ScrollAlwaysVisible = true;
            this.lstSites.Size = new System.Drawing.Size(263, 121);
            this.lstSites.TabIndex = 24;
            this.lstSites.SelectedIndexChanged += new System.EventHandler(this.lstSites_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Select path to install Innovmetric PWV";
            // 
            // lblWindows
            // 
            this.lblWindows.BackColor = System.Drawing.Color.White;
            this.lblWindows.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindows.ForeColor = System.Drawing.Color.Black;
            this.lblWindows.Location = new System.Drawing.Point(91, 357);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(289, 21);
            this.lblWindows.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(386, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 28;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgPath
            // 
            this.imgPath.Image = global::Installer_PWV.Properties.Resources.pwv_grey;
            this.imgPath.Location = new System.Drawing.Point(56, 357);
            this.imgPath.Name = "imgPath";
            this.imgPath.Size = new System.Drawing.Size(29, 21);
            this.imgPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPath.TabIndex = 30;
            this.imgPath.TabStop = false;
            // 
            // imgSite
            // 
            this.imgSite.Image = global::Installer_PWV.Properties.Resources.pwv_grey;
            this.imgSite.Location = new System.Drawing.Point(56, 167);
            this.imgSite.Name = "imgSite";
            this.imgSite.Size = new System.Drawing.Size(29, 21);
            this.imgSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgSite.TabIndex = 31;
            this.imgSite.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 32;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // configureIIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(457, 663);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.imgSite);
            this.Controls.Add(this.imgPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWindows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSites);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "configureIIS";
            this.Text = "configureIIS";
            this.Load += new System.EventHandler(this.configureIIS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstSites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWindows;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox imgPath;
        private System.Windows.Forms.PictureBox imgSite;
        private System.Windows.Forms.Button button3;
    }
}