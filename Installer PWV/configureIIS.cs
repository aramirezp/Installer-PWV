using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Installer_PWV
{
    public partial class configureIIS : Form
    {
        public string siteSelected = string.Empty;
        public configureIIS()
        {
            InitializeComponent();
        }

        private void configureIIS_Load(object sender, EventArgs e)
        {
            //Detect Site IIS to install Frontend
            ServerManager mgr = new ServerManager();
            foreach (Site s in mgr.Sites)
            {
                lstSites.Items.Add("Site " + s.Name);// + s.Bindings[0].Attributes["bindingInformation"].Value);// + "\n Path:"+ s.Applications["/"].VirtualDirectories["/"].PhysicalPath);

                /*foreach (Microsoft.Web.Administration.Application app in s.Applications)
                {
                    lblPathIIS.Text += "Application: " + app.Path + "\n";

                    foreach (VirtualDirectory virtDir in app.VirtualDirectories)
                    {
                        lblPathIIS.Text += "Virtual Dir: " + virtDir.PhysicalPath + "\n";
                    }
                }*/
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                if (!System.IO.Directory.Exists(folderBrowserDialog1.SelectedPath + "\\innovmetric\\pwv"))
                {
                    lblWindows.Text = folderBrowserDialog1.SelectedPath + "\\innovmetric\\pwv";
                    imgPath.Image = Installer_PWV.Properties.Resources.pwv_red;
                }
                else MessageBox.Show("Directory innovmetric pwv exist, please select another directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                /*if (!fileOpened)
                {
                    // No file is opened, bring up openFileDialog in selected path.
                    openFileDialog1.InitialDirectory = folderName;
                    openFileDialog1.FileName = null;
                    openMenuItem.PerformClick();
                }*/
            }
        }

        private void lstSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgSite.Image = Installer_PWV.Properties.Resources.pwv_red;
            siteSelected = ((ListBox)sender).SelectedItem.ToString();
            siteSelected = siteSelected.Split('*')[0].Substring(4).Trim();

            ServerManager mgr = new ServerManager();
            Site s = mgr.Sites[siteSelected];
            txtPort.Text = s.Bindings[0].EndPoint.Port.ToString();
            lblWindows.Text = Environment.ExpandEnvironmentVariables(s.Applications["/"].VirtualDirectories["/"].PhysicalPath.ToString());
        }

        private void MyMethod() //called on the UI thread
        {
            //iCount = checkedlistbox.selecteditems.count;
            progressBar1.Value = 1;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = System.IO.Directory.GetFiles(@"d:\Develop\pwv\", "*", System.IO.SearchOption.AllDirectories).Length; ;
            progressBar1.Step = 1;

            var bgw = new BackgroundWorker();
            bgw.ProgressChanged += backgroundWorker1_ProgressChanged;
            bgw.DoWork += backgroundWorker1_DoWork;
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                 /*ServerManager mgr = new ServerManager();
                 Site s = mgr.Sites[siteSelected];*/
                
                helper_iis.CreateApplication(siteSelected, lblWindows.Text);
                System.Diagnostics.Process.Start("http://localhost:" + txtPort.Text + "/innovmetric/pwv/");
                System.Diagnostics.Process.Start("http://localhost:" + txtPort.Text + "/innovmetric/rest/");
                MyMethod();
                //s.Applications.Add("/test/pwv1", lblWindows.Text);

                /*mgr.CommitChanges();*/


                /*const int NUMBEROFSITES = 1;
                const int SITEBASENUMBER = 1000;
                const string POOLPREFIX = "POOL_";
                const string SITENAMEPREFIX = "INNOVMETRIC";
                const string ROOTDIR = "d:\\content";
                ServerManager mgr = new ServerManager();
                SiteCollection sites = mgr.Sites;
                for (int i = SITEBASENUMBER; i < NUMBEROFSITES + SITEBASENUMBER; i++)
                {
                    if (!helper_iis.CreateSitesInIIS(sites, SITENAMEPREFIX, i, ROOTDIR, 96))
                    {
                        Console.WriteLine("Creating site { 0}failed", i);
                    }
                }
                mgr.CommitChanges();
                */


            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Application exist in IIS, Replace application?" + ex.Message.ToString(), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            const string sourceDir = @"d:\Develop\pwv";
            const string targetDir = @"c:\Develop\pwv";
            int i = 0;
            foreach (var file in System.IO.Directory.GetFiles(sourceDir))
            {
                System.IO.File.Copy(file, System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file)), true);
                ((BackgroundWorker)sender).ReportProgress(i);
            }

            //for (int i = 1; i< 100; ++i)
            //{
            //    //do some work...
            //    System.Threading.Thread.Sleep(1000);
            //    ((BackgroundWorker)sender).ReportProgress(0);
            //}
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
