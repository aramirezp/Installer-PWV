using Microsoft.Web.Administration;
using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installer_PWV
{
    public class helper_iis
    {
        const string POOLPREFIX = "POOL_";
        const string SITENAMEPREFIX = "SITE";
        const string ROOTDIR = "e:\\content";
        public static void CreateApplicationPool(string applicationPoolName)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                if (serverManager.ApplicationPools[applicationPoolName] != null)
                    return;
                ApplicationPool newPool = serverManager.ApplicationPools.Add(applicationPoolName);
                newPool.ManagedRuntimeVersion = "v4.0";
                serverManager.CommitChanges();
            }
        }
        public static void CreateSite(string siteName, string path)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                var sites = serverManager.Sites;
                if (sites[siteName] == null)
                {
                    sites.Add(siteName, "http", "*:80:", path);
                    serverManager.CommitChanges();
                }
            }
        }
        public static bool CreateInboundFirewall(int port)
        {
            INetFwMgr icfMgr = null;
            try
            {
                Type TicfMgr = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                icfMgr = (INetFwMgr)Activator.CreateInstance(TicfMgr);
            }
            catch (Exception ex)
            {
                return false;
            }

            try
            {
                INetFwProfile profile;
                INetFwOpenPort portClass;
                Type TportClass = Type.GetTypeFromProgID("HNetCfg.FWOpenPort");
                portClass = (INetFwOpenPort)Activator.CreateInstance(TportClass);

                // Get the current profile
                profile = icfMgr.LocalPolicy.CurrentProfile;

                // Set the port properties
                portClass.Scope = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                portClass.Enabled = true;
                portClass.Protocol = NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                portClass.Name = "Port to application Innovmetric";
                portClass.Port = port;

                // Add the port to the ICF Permissions List
                profile.GloballyOpenPorts.Add(portClass);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool CreateDirectoryPwv(string dirRoot)
        {
            try
            {

                System.IO.Directory.CreateDirectory(dirRoot);
                //TODO: Crear funcion que copie todo el direcctorio en la ruta seleccionada
                System.IO.File.Create(dirRoot + @"\index.html").Close();
                System.IO.TextWriter tw = new System.IO.StreamWriter(dirRoot + @"\index.html");
                if (dirRoot.Contains("rest"))
                    tw.WriteLine("<html><body><h1> Success Backend " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ok!!!</h1></body></html>");
                else
                    tw.WriteLine("<html><body><h1> Success FrontEnd " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ok!!!</h1></body></html>");
                tw.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public static bool CreateSitesInIIS(SiteCollection sites, string sitePrefix, int siteId, string dirRoot, int port)
        {
            string siteName = sitePrefix + siteId;
            // site gets set to Poolname using the following format. Example: 'Site_POOL10'
            string poolName = sitePrefix + siteId;
            try
            {
                Site site = sites.CreateElement();
                site.Id = siteId;
                site.SetAttributeValue("name", siteName);
                sites.Add(site);

                Application app = site.Applications.CreateElement();
                app.SetAttributeValue("path", "/");
                app.SetAttributeValue("applicationPool", ".NET v4.5");
                site.Applications.Add(app);
                VirtualDirectory vdir = app.VirtualDirectories.CreateElement();
                vdir.SetAttributeValue("path", "/");
                vdir.SetAttributeValue("physicalPath", dirRoot + @"\" + siteName);


                app.VirtualDirectories.Add(vdir);

                Binding b = site.Bindings.CreateElement();
                b.SetAttributeValue("protocol", "http");
                b.SetAttributeValue("bindingInformation", ":" + port + ":");// + siteName);

                CreateInboundFirewall(port);

                site.Bindings.Add(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create site { 0} failed.Reason: { 1}", siteName, ex.Message);
                return false;
            }
            return true;
        }
        public static Boolean CreateApplication(string site, string PhysicalPath)
        {
            try
            {

                ServerManager manager = new ServerManager();
                Site defaultSite = manager.Sites[site];
                Boolean siteExist = false;
                List<Application> foundApp = new List<Application>();
                foreach (Application appSearch in defaultSite.Applications)
                {
                    if (appSearch.Path.Contains("/innovmetric"))
                    {
                        siteExist = true;
                        foundApp.Add(appSearch);

                    }
                }
                if (siteExist)
                {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Application exist in IIS, Replace application?", "Information", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (Application appdel in foundApp)
                        {
                            defaultSite.Applications.Remove(appdel);
                            //manager.CommitChanges();
                        }
                        try
                        {
                            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(PhysicalPath + @"\innovmetric\");

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

                        CreateDirectoryPwv(PhysicalPath + @"\innovmetric\pwv\");

                        //CreateDirectoryPwv(PhysicalPath + @"\innovmetric\rest\");
                        Application app = defaultSite.Applications.Add("/innovmetric/rest", PhysicalPath + @"\innovmetric\rest");
                        Application app2 = defaultSite.Applications.Add("/innovmetric", PhysicalPath + @"\innovmetric");
                        //app.VirtualDirectories.Add("/innovmetric"  , @"d:\rootTest\innovmetric");
                        manager.CommitChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    //CreateDirectoryPwv(PhysicalPath + @"\innovmetric\pwv\");

                    //CreateDirectoryPwv(PhysicalPath + @"\innovmetric\rest\");
                    Application app = defaultSite.Applications.Add("/innovmetric/rest", PhysicalPath + @"\innovmetric\rest");
                    Application app2 = defaultSite.Applications.Add("/innovmetric", PhysicalPath + @"\innovmetric");
                    //app.VirtualDirectories.Add("/innovmetric"  , @"d:\rootTest\innovmetric");
                    manager.CommitChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public static Site GetSite(ServerManager serverManager, string siteName)
        {
            using (serverManager)
            {
                return serverManager.Sites[siteName];
            }
        }
        public static void CreateApplication(string siteName, string applicationName, string path, int port)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                var site = GetSite(serverManager, siteName);
                var applications = site.Applications;
                site.Applications.Add("/app1", @"c:\inetpub\wwwroot\app1");
                if (applications["/" + applicationName] == null)
                {
                    applications.Add("/" + applicationName, path);
                    serverManager.CommitChanges();
                    CreateDirectoryPwv(path);
                    CreateInboundFirewall(port);
                }
            }
        }
        public static void CreateVirtualDirectory(string siteName, string applicationName, string virtualDirectoryName, string path)
        {
            //using (ServerManager serverManager = new ServerManager())
            //{
            //    var application = GetApplication(serverManager, siteName, applicationName);
            //    application.VirtualDirectories.Add("/" + virtualDirectoryName, path);
            //    serverManager.CommitChanges();
            //}
        }
        public static void SetApplicationApplicationPool(string siteName, string applicationPoolName)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                var site = GetSite(serverManager, siteName);
                if (site != null)
                {
                    foreach (Application app in site.Applications)
                    {
                        app.ApplicationPoolName = applicationPoolName;
                    }
                }
                serverManager.CommitChanges();
            }
        }
    }
}
