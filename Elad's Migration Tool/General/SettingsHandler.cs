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
        public static void SetSetting(string key, string value)
        {
            if (!GetSetting(key).Equals(""))
            {
                RemoveSetting(key);
            }

            Helper.WriteLineToText(settingsFileName, key + "=" + value);
        }

        /**
         * Returns the value of a specific key.
         */
        public static string GetSetting(string key)
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
        public static void RemoveSetting(string key)
        {
            if(GetSetting(key).Equals("")){
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

            SetSettingsFile(newSettings);
        }

        /**
         * Sets the content of the settings file.
         */
        public static void SetSettingsFile(List<string> settings)
        {
            if (!DeleteSettingsFile())
            {
                return;
            }

            Helper.SetTextFileContent(settingsFileName, settings);
        }

        /**
         * Deletes the settings file.
         */
        public static bool DeleteSettingsFile()
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