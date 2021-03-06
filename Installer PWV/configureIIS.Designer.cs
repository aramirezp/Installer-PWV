﻿namespace Installer_PWV
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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblNomFile = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
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
            this.button2.Text = "Install";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.label2.Location = new System.Drawing.Point(90, 382);
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
            this.lblWindows.Location = new System.Drawing.Point(91, 412);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(289, 21);
            this.lblWindows.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(386, 412);
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
            this.imgPath.Location = new System.Drawing.Point(56, 412);
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
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(94, 325);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(90, 20);
            this.txtPort.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(90, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Port site selected";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 501);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 15);
            this.progressBar1.TabIndex = 37;
            this.progressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblNomFile
            // 
            this.lblNomFile.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNomFile.ForeColor = System.Drawing.Color.White;
            this.lblNomFile.Location = new System.Drawing.Point(12, 519);
            this.lblNomFile.Name = "lblNomFile";
            this.lblNomFile.Size = new System.Drawing.Size(433, 21);
            this.lblNomFile.TabIndex = 38;
            this.lblNomFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(94, 546);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(254, 52);
            this.button4.TabIndex = 39;
            this.button4.Text = "Finish";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // configureIIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(457, 663);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblNomFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "configureIIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup PWV";
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
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblNomFile;
        private System.Windows.Forms.Button button4;
    }
}