using System;
using System.Collections.Generic;
using System.Linq;
using Elad_s_Migration_Tool.RegistryFunctions;
using System.IO;
using Elad_s_Migration_Tool.Logs;

namespace Elad_s_Migration_Tool.General
{
    class Helper
    {
        /**
         * Returns the complete operating system version.
         */
        public static string getFriendlyOSVersion()
        {
            string ProductName = RegistryInterface.getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName");
            string CSDVersion = RegistryInterface.getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\CSDVersion");

            if (!ProductName.Equals(""))
            {
                return ProductName + (!CSDVersion.Equals("") ? " " + CSDVersion : "");
            }

            return "";
        }

        /**
         * Returns the numeric operating system - 7, 8 or 10.
         */
        public static int getOSVersion()
        {
            string stringVersion = getFriendlyOSVersion();

            if (stringVersion.IndexOf("7") != -1)
            {
                return 7;
            }

            if (stringVersion.IndexOf("8") != -1)
            {
                return 8;
            }

            if (stringVersion.IndexOf("10") != -1)
            {
                return 10;
            }

            return 0;
        }

        /**
         * Reads each line of a text file into a List<string>.
         */
        public static List<string> getTextFileContent(string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file)./*Where(line => line != "").*/ToList();
        }

        /**
         * Writes a specific line into a text file.
         */
        public static bool writeLineToText(string file, string line)
        {
            try
            {
                StreamWriter fileStream = new StreamWriter(file, true);
                fileStream.WriteLine(line);
                fileStream.Close();
            }
            catch (Exception e)
            {
                ErrorLogger.logError("Could not write to file " + file + " at function writeLineToText() - " + e.ToString());

                return false;
            }

            return true;
        }

        /**
         * Sets the content of a text file using a List of the content - each string in content is a line.
         */
        public static bool setTextFileContent(string file, List<string> content)
        {
            try
            {
                File.WriteAllText(file, String.Empty); //Empties the file

                StreamWriter fileStream = new StreamWriter(file, true);

                foreach (string line in content)
                {
                    fileStream.WriteLine(line);
                }

                fileStream.Close();
            }
            catch (Exception e)
            {
                ErrorLogger.logError("Could not write to file " + file + " at function setTextFileContent() - " + e.ToString());
                return false;
            }

            return true;
        }

        /**
         * Returns a path of a previous folder according to the previousFolderAmount.
         * For example, the path C:\users\home with the previousFolderAmount 1 will return C:\users.
         */
        public static string getPreviousFolderPath(string path, int previousFolderAmount)
        {
            string retPath = "";
            string[] pathsSplitted = path.Split('\\');
            int foldersAmount = pathsSplitted.Length;

            for (int i = 0; i < foldersAmount - previousFolderAmount; i++)
            {
                retPath += pathsSplitted[i] + "\\";
            }

            return retPath;
        }

        /**
         * Executes a command prompt command.
         */
        public static void executeCommand(string workingDirectory, string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}