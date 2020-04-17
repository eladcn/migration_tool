using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class FileRestorationFormHandler
    {
        /**
         * Adds a date to the dates list according to the folder name.
         */
        protected static bool AddDateToList(List<string> dates, string folderName)
        {
            if (!folderName.Contains("_"))
            {
                return false;
            }

            folderName += "\\";
            folderName = Path.GetFileName(Path.GetDirectoryName(folderName));

            string[] dirExploded = folderName.Split('_');

            if (dirExploded.Length != 6)
            {
                return false;
            }

            string date = dirExploded[1] + "/" + dirExploded[2] + "/" + dirExploded[0] + " " + dirExploded[3] + ":" + dirExploded[4] + ":" + dirExploded[5];

            if (!dates.Contains(date))
            {
                dates.Add(date);

                return true;
            }

            return false;
        }

        /**
         * Restores the files according to the date.
         */
        public static bool RestoreFiles(string date)
        {
            SimulatorOption targetSimulator = MainFormHandler.GetSelectedTargetSimulator();

            string appDataPath = targetSimulator.GetAppDataPath(true);
            string programDataPath = targetSimulator.GetProgramDataPath(true);

            string appDataBackupPath = targetSimulator.GetAppDataPath(true) + "\\migrationBackup";
            string programDataBackupPath = targetSimulator.GetProgramDataPath(true) + "\\migrationBackup";

            string[] fullDateSplitted = date.Split(' ');
            string[] timeSplitted = fullDateSplitted[1].Split(':');
            string[] dateSplitted = fullDateSplitted[0].Split('/');

            string folderName = dateSplitted[2] + "_" + dateSplitted[0] + "_" + dateSplitted[1] + "_" + timeSplitted[0] + "_" + timeSplitted[1] + "_" + timeSplitted[2];

            appDataBackupPath += "\\" + folderName;
            programDataBackupPath += "\\" + programDataPath;

            bool appDataExists = Directory.Exists(appDataBackupPath);
            bool programDataExists = Directory.Exists(programDataBackupPath);
            int filesRestored = 0;

            if (appDataExists)
            {
                string[] appDataFiles = Directory.GetFiles(appDataBackupPath);

                foreach (string file in appDataFiles)
                {
                    string appDataFileName = Path.GetFileName(file);

                    try
                    {
                        File.Copy(file, appDataPath + "\\" + appDataFileName, true);
                        filesRestored++;
                    }
                    catch (Exception e)
                    {
                        ErrorLogger.LogError("Could not copy file from migrationBackup, function restoreFiles() - " + e.ToString());
                    }
                }
            }

            if (programDataExists)
            {
                string[] programDataBackupFiles = Directory.GetFiles(programDataBackupPath);

                foreach (string file in programDataBackupFiles)
                {
                    string programDataFileName = Path.GetFileName(file);

                    try
                    {
                        File.Copy(file, programDataPath + "\\" + programDataFileName, true);
                        filesRestored++;
                    }
                    catch (Exception e)
                    {
                        ErrorLogger.LogError("Could not copy file from migrationBackup, function restoreFiles() - " + e.ToString());
                    }
                }
            }

            return (appDataExists || programDataExists) && filesRestored > 0;
        }

        /**
         * Initializes the backup dates.
         */
        public static void OnLoadHandler()
        {
            SimulatorOption targetSimulator = MainFormHandler.GetSelectedTargetSimulator();

            string appDataPath = targetSimulator.GetAppDataPath(true) + "\\migrationBackup";
            string programDataPath = targetSimulator.GetProgramDataPath(true) + "\\migrationBackup";

            List<string> dates = new List<string>();
            bool appDataExists = Directory.Exists(appDataPath);
            bool programDataExists = Directory.Exists(programDataPath);

            if (appDataExists || programDataExists)
            {
                if (appDataExists)
                {
                    string[] appDataDirectories = Directory.GetDirectories(appDataPath);

                    foreach (string dir in appDataDirectories)
                    {
                        AddDateToList(dates, dir);
                    }
                }

                if (programDataExists)
                {
                    string[] programDataDirectories = Directory.GetDirectories(programDataPath);

                    foreach (string dir in programDataDirectories)
                    {
                        AddDateToList(dates, dir);
                    }
                }
            }

            if (dates.Count > 0)
            {
                ComboBox restoreDatesCombo = FileRestorationForm.GetRestoreDatesCombo();
                Button restoreButton = FileRestorationForm.GetRestoreButton();

                dates.Reverse();

                foreach (string date in dates)
                {
                    restoreDatesCombo.Items.Add(date);
                }

                restoreButton.Enabled = true;
            }
        }
    }
}