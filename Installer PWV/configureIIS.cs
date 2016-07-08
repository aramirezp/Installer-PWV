using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                lstSites.Items.Add("Site " + s.Name + s.Bindings[0].Attributes["bindingInformation"].Value);// + "\n Path:"+ s.Applications["/"].VirtualDirectories["/"].PhysicalPath);

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
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                /* ServerManager mgr = new ServerManager();
                 Site s = mgr.Sites[siteSelected];
                 s.Applications.Add("/test/pwv1", lblWindows.Text);
                 s.Applications.ena
                 mgr.CommitChanges();
                 */

                const int NUMBEROFSITES = 1;
                const int SITEBASENUMBER = 1000;
                //const string POOLPREFIX = "POOL_";
                const string SITENAMEPREFIX = "SITE";
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

                

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Application exist in IIS, Replace application?" + ex.Message.ToString(), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            }

        }
    }
}
