using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using Microsoft.Web.Administration;

namespace Installer_PWV
{
    public partial class detectRequisities : Form
    {


        public detectRequisities()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Boolean f1 = false;
            Boolean f2 = false;
            Boolean f3 = false;
            // Verify if version es Server
            lblWindows.Text = OS.FriendlyName();
            if (OS.IsWindowsServer())
            {
                picWindows.Image = Installer_PWV.Properties.Resources.pwv_red;
                f1 = true;
            }

            // Detect wich version is installed
            string version = FrameWork.Get45or451FromRegistry();
            switch (version)
            {
                case "1.0": lblFramework.Text = FrameWork.foundFWMoreThan45; break;
                case "0": lblFramework.Text = FrameWork.noFoundFW45; break;
                default: { lblFramework.Text = "Version " + version; picFramework.Image = Installer_PWV.Properties.Resources.pwv_red; f2 = true; break; }

            }

            // Detect IIS is installed and show version
            Version verIIS = GetIisVersion();
            lblIIS.Text = verIIS.ToString();
            if (verIIS.Major >= 0)
            {
                picIIS.Image = Installer_PWV.Properties.Resources.pwv_red;
                f3 = true;
            }

            if (f1 && f2 && f3)
                    {
                        button2.Enabled = true;
                        button1.Enabled = false;
                    }
        }


        public Version GetIisVersion()
        {
            using (RegistryKey componentsKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp", false))
            {
                if (componentsKey != null)
                {
                    int majorVersion = (int)componentsKey.GetValue("MajorVersion", -1);
                    int minorVersion = (int)componentsKey.GetValue("MinorVersion", -1);

                    if (majorVersion != -1 && minorVersion != -1)
                    {
                        return new Version(majorVersion, minorVersion);
                    }
                }

                return new Version(0, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            configureIIS frmInstaller = new configureIIS();
            frmInstaller.Show();
        }

        private void detectRequisities_Load(object sender, EventArgs e)
        {
            ServerManager manager = new ServerManager();
            foreach (Site defaultSite in manager.Sites)
            {
                //Site defaultSite = manager.Sites[itemSite];
                
                //List<Microsoft.Web.Administration.Application> foundApp = new List<Microsoft.Web.Administration.Application>();
                foreach (Microsoft.Web.Administration.Application appSearch in defaultSite.Applications)
                {
                    if (appSearch.Path.Contains("/innovmetric")) {
                        //defaultSite.Applications.Remove(appSearch);
                        button3.Visible = true;
                        button2.Visible = false;
                        button1.Enabled = false;
                    }
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServerManager manager = new ServerManager();
            foreach (Site defaultSite in manager.Sites)
            {
                //Site defaultSite = manager.Sites[itemSite];

                List<Microsoft.Web.Administration.Application> foundApp = new List<Microsoft.Web.Administration.Application>();
                foreach (Microsoft.Web.Administration.Application appSearch in defaultSite.Applications)
                {
                    if (appSearch.Path.Contains("/innovmetric"))
                    {
                        foundApp.Add(appSearch);
                        
                        
                        
                    }
                }
                foreach (Microsoft.Web.Administration.Application app in foundApp) {
                    string PhysicalPath = app.VirtualDirectories[0].PhysicalPath;
                    defaultSite.Applications.Remove(app);
                    
                    try
                    {
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(PhysicalPath);

                        foreach (System.IO.FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        //System.IO.Directory.Delete(PhysicalPath + @"\innovmetric\", true);
                    }
                    catch (Exception ex)
                    {


                    }
                }

            }
            manager.CommitChanges();
            MessageBox.Show("Uninstall Site PWV Success!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            button1.Enabled = true;
            button2.Visible = true;
            button3.Visible = false;
        }
    }
}
