using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.General
{
    class VersionHandler
    {
        protected static int programVersion = 30;
        protected static string versionUrl = "http://www.migration-tool.co.nf/getVersion.php";
        protected static string upgradeWebsite = "http://www.migration-tool.co.nf/?u=" + (programVersion + 1);

        /**
         * Returns the latest version found on the website.
         */
        public static int getRecentVersion()
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(versionUrl);
                myRequest.Method = "GET";
                myRequest.Timeout = 5000;
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();

                int res = 0;
                bool success = Int32.TryParse(result, out res);

                if (success)
                {
                    return res;
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return 0;
        }

        /**
         * Returns whether the program is outdated.
         */
        public static bool shouldUpgrade()
        {
            int recentVersion = getRecentVersion();

            if (recentVersion > 0 && recentVersion > programVersion)
            {
                return true;
            }

            return false;
        }

        /**
         * Opens the upgrade website.
         */
        public static void openUpgradeWebsite()
        {
            System.Diagnostics.Process.Start(upgradeWebsite);
        }

        /**
         * Shows the upgrade message if the version of the program is outdated.
         */
        public static void showUpgradeMessage()
        {
            if (shouldUpgrade())
            {
                DialogResult res = MessageBox.Show("A new version of Elad's Migration Tool is available! Would you like to go to the download page?", "New Version Available", MessageBoxButtons.YesNo);

                if (res.Equals(DialogResult.Yes))
                {
                    openUpgradeWebsite();
                }
            }
        }
    }
}