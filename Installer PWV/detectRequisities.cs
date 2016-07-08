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
            // Verify if version es Server
            lblWindows.Text = OS.FriendlyName();
            if (OS.IsWindowsServer())
                picWindows.Image = Installer_PWV.Properties.Resources.pwv_red;

            // Detect wich version is installed
            string version = FrameWork.Get45or451FromRegistry();
            switch (version)
            {
                case "1.0": lblFramework.Text = FrameWork.foundFWMoreThan45; break;
                case "0": lblFramework.Text = FrameWork.noFoundFW45; break;
                default: { lblFramework.Text = "Version " + version; picFramework.Image = Installer_PWV.Properties.Resources.pwv_red; break; }

            }

            // Detect IIS is installed and show version
            Version verIIS = GetIisVersion();
            lblIIS.Text = verIIS.ToString();
            if (verIIS.Major >= 0)
                picIIS.Image = Installer_PWV.Properties.Resources.pwv_red;

           
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

    }
}
