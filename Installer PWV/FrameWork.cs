﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installer_PWV
{
    public class FrameWork
    {
        public const string noFoundFW45 = "Version 4.5 or later is not detected.";
        public const string foundFWMoreThan45 = "No 4.5 or later version detected";
        public static string CheckFor45DotVersion(int releaseKey)
        {
            if (releaseKey >= 393295)
            {
                return "4.6";
            }
            if ((releaseKey >= 379893))
            {
                return "4.5.2";
            }
            if ((releaseKey >= 378675))
            {
                return "4.5.1";
            }
            if ((releaseKey >= 378389))
            {
                return "4.5";
            }
            // This line should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "1.0";
        }

        public static string Get45or451FromRegistry()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    string numVersion = CheckFor45DotVersion((int)ndpKey.GetValue("Release"));
                    Console.WriteLine("Version: " + numVersion);
                    return numVersion;
                }
                else
                {
                    Console.WriteLine("Version 4.5 or later is not detected.");
                    return "0";
                }
            }
        }
    }
}
