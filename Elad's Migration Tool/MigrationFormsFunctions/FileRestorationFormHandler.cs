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
        protected static bool addDateToList(List<string> dates, string folderName)
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
        public static bool restoreFiles(string date)
        {
            SimulatorOption targetSimulator = MainFormHandler.getSelectedTargetSimulator();

            string appDataPath = targetSimulator.getAppDataPath(true);
            string programDataPath = targetSimulator.getProgramDataPath(true);

            string appDataBackupPath = targetSimulator.getAppDataPath(true) + "\\migrationBackup";
            string programDataBackupPath = targetSimulator.getProgramDataPath(true) + "\\migrationBackup";

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
                        ErrorLogger.logError("Could not copy file from migrationBackup, function restoreFiles() - " + e.ToString());
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
                        ErrorLogger.logError("Could not copy file from migrationBackup, function restoreFiles() - " + e.ToString());
                    }
                }
            }

            return (appDataExists || programDataExists) && filesRestored > 0;
        }

        /**
         * Initializes the backup dates.
         */
        public static void onLoadHandler()
        {
            SimulatorOption targetSimulator = MainFormHandler.getSelectedTargetSimulator();

            string appDataPath = targetSimulator.getAppDataPath(true) + "\\migrationBackup";
            string programDataPath = targetSimulator.getProgramDataPath(true) + "\\migrationBackup";

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
                        addDateToList(dates, dir);
                    }
                }

                if (programDataExists)
                {
                    string[] programDataDirectories = Directory.GetDirectories(programDataPath);

                    foreach (string dir in programDataDirectories)
                    {
                        addDateToList(dates, dir);
                    }
                }
            }

            if (dates.Count > 0)
            {
                ComboBox restoreDatesCombo = FileRestorationForm.getRestoreDatesCombo();
                Button restoreButton = FileRestorationForm.getRestoreButton();

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