using System;
using System.Collections.Generic;
using System.IO;

namespace Elad_s_Migration_Tool.General
{
    class SettingsHandler
    {
        protected static string settingsFileName = "settings.ini";

        /**
         * Sets a specific setting in the settings file. If the setting already exists - it replaces it.
         */
        public static void setSetting(string key, string value)
        {
            if (!getSetting(key).Equals(""))
            {
                removeSetting(key);
            }

            Helper.writeLineToText(settingsFileName, key + "=" + value);
        }

        /**
         * Returns the value of a specific key.
         */
        public static string getSetting(string key)
        {
            if (!File.Exists(settingsFileName))
            {
                return "";
            }

            string line;
            StreamReader fileStream = new StreamReader(settingsFileName);

            while ((line = fileStream.ReadLine()) != null)
            {
                if (line.IndexOf('=') < 0)
                {
                    continue;
                }

                string[] keyValue = line.Split('=');

                if (key == keyValue[0])
                {
                    fileStream.Close();
                    return keyValue[1];
                }
            }

            fileStream.Close();

            return "";
        }

        /**
         * Removes a specific key from the settings file.
         */
        public static void removeSetting(string key)
        {
            if(getSetting(key).Equals("")){
                return;
            }

            List<string> newSettings = new List<string>();

            string line;
            StreamReader fileStream = new StreamReader(settingsFileName);

            while ((line = fileStream.ReadLine()) != null)
            {
                if (line.IndexOf('=') < 0)
                {
                    continue;
                }

                string[] keyValue = line.Split('=');

                if (key != keyValue[0])
                {
                    newSettings.Add(line);
                }
            }

            fileStream.Close();

            setSettingsFile(newSettings);
        }

        /**
         * Sets the content of the settings file.
         */
        public static void setSettingsFile(List<string> settings)
        {
            if (!deleteSettingsFile())
            {
                return;
            }

            Helper.setTextFileContent(settingsFileName, settings);
        }

        /**
         * Deletes the settings file.
         */
        public static bool deleteSettingsFile()
        {
            if (File.Exists(settingsFileName))
            {
                try
                {
                    File.Delete(settingsFileName);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
    }
}