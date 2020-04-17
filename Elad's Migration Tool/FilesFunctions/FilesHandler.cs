using System;
using System.IO;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.Logs;
using Elad_s_Migration_Tool.MigrationFormsFunctions;

namespace Elad_s_Migration_Tool.FilesFunctions
{
    class FilesHandler
    {
        protected static string[] configFiles = { "scenery.cfg", "dll.xml", "exe.xml", "fsx.cfg", "prepar3d.cfg", "cameras.cfg", "airlines.cfg", "autogen.cfg", "display.cfg", "effects.cfg", "fonts.cfg", "gauges.cfg", "sound.cfg", "simobjects.cfg", "texture.cfg", "terrain.cfg", "weather.cfg" };

        /**
         * Returns a copy of the config files array (so it cannot be dynamically changed).
         */
        public static string[] GetConfigFiles()
        {
            string[] copyConfigFiles = new string[configFiles.Length];
            configFiles.CopyTo(copyConfigFiles, 0);

            return copyConfigFiles;
        }

        /**
         * Returns whether the Prepar3D folder that we found in the registry exists.
         */
        public static bool SimulatorPathExists(string simPath)
        {
            return Directory.Exists(simPath);
        }

        /**
         * Duplicates the Prepar3D.exe file and renames it to FSX.exe - some add ons are looking for the FSX.exe file inside the main folder.
         */
        public static bool CreateFakeFsxExecutable(string newSimPath)
        {
            if (newSimPath.Equals("") || !SimulatorPathExists(newSimPath))
            {
                return false;
            }

            try
            {
                if (File.Exists(newSimPath + "\\Prepar3D.exe"))
                {
                    File.Copy(newSimPath + "\\Prepar3D.exe", newSimPath + "\\fsx.exe", true);
                    HistoryHandler.AppendHistory("2," + newSimPath);

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                ErrorLogger.LogError("Could not create fake fsx file, function createFakeFsxExecutable() - " + e.ToString());
                return false;
            }
        }

        /**
         * Delete the fake FSX executable we created.
         */
        public static bool DeleteFakeFsxExecutable(string newSimPath)
        {
            if (newSimPath.Equals("") || !SimulatorPathExists(newSimPath))
            {
                return false;
            }

            try
            {
                File.Delete(newSimPath + "\\fsx.exe");

                return true;
            }
            catch (Exception e)
            {
                ErrorLogger.LogError("Could not delete fake fsx file, function deleteFakeFsxExecutable() - " + e.ToString());
                return false;
            }
        }

        /**
         * Returns the OS ProgramData folder's path.
         */
        public static string GetProgramDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();
        }

        /**
         * Return the OS ApplicationData folder's path.
         */
        public static string GetApplicationDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
        }

        /**
         * Creates a backup of the config files.
         */
        protected static bool CreateConfigFilesBackup(string programDataFolder, string appDataFolder, bool isTargetSim)
        {
            DateTime currentTime = DateTime.Now;
            string backupTime = "\\" + currentTime.ToString("yyyy_MM_dd_HH_mm_ss");

            if(!isTargetSim){
                backupTime = "";
            }

            string programDataPath = GetProgramDataPath() + "\\" + programDataFolder;
            string applicationDataPath = GetApplicationDataPath() + "\\" + appDataFolder;
            string programDataBackupFolderPath = programDataPath + "\\migrationBackup" + backupTime;
            string applicationDataBackupFolderPath = applicationDataPath + "\\migrationBackup" + backupTime;

            if (!Directory.Exists(programDataBackupFolderPath))
            {
                Directory.CreateDirectory(programDataBackupFolderPath);
            }

            if (!Directory.Exists(applicationDataBackupFolderPath))
            {
                Directory.CreateDirectory(applicationDataBackupFolderPath);
            }

            bool filesBackedUp = false;

            for (int i = 0; i < configFiles.Length; i++)
            {
                string fileName = configFiles[i];

                string fileProgramDataPath = programDataPath + "\\" + fileName;
                string fileApplicationDataPath = applicationDataPath + "\\" + fileName;
                string backupProgramDataFilePath = programDataBackupFolderPath + "\\" + fileName;
                string backupApplicationDataFilePath = applicationDataBackupFolderPath + "\\" + fileName;

                try
                {
                    if (File.Exists(fileProgramDataPath))
                    {
                        File.Copy(fileProgramDataPath, backupProgramDataFilePath, true);
                        filesBackedUp = true;
                    }
                    
                    if (File.Exists(fileApplicationDataPath))
                    {
                        File.Copy(fileApplicationDataPath, backupApplicationDataFilePath, true);
                        filesBackedUp = true;
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function createConfigFilesBackup() - " + e.ToString());
                    continue;
                }
            }

            return filesBackedUp;
        }

        /**
         * Creates a backup of the source simulator's config files.
         */
        public static bool CreateSourceSimulatorBackup()
        {
            SimulatorOption simOption = MainFormHandler.GetSelectedSourceSimulator();

            if (simOption == null)
            {
                return false;
            }

            return CreateConfigFilesBackup(simOption.GetProgramDataPath(), simOption.GetAppDataPath(), false);
        }

        /**
         * Creates a backup of the target simulator's config files.
         */
        public static bool CreateTargetSimulatorBackup()
        {
            SimulatorOption simOption = MainFormHandler.GetSelectedTargetSimulator();

            if (simOption == null)
            {
                return false;
            }

            return CreateConfigFilesBackup(simOption.GetProgramDataPath(), simOption.GetAppDataPath(), true);
        }

        /**
         * Copies the config files from the target sim to the source sim.
         */
        public static bool CopyTargetSimFilesToSource()
        {
            SimulatorOption sourceOption = MainFormHandler.GetSelectedSourceSimulator();
            SimulatorOption targetOption = MainFormHandler.GetSelectedTargetSimulator();

            if (sourceOption == null || targetOption == null)
            {
                return false;
            }

            CreateTargetSimulatorBackup();
            CreateSourceSimulatorBackup();

            string sourceAppDataFolder = sourceOption.GetAppDataPath(true);
            string sourceProgramDataFolder = sourceOption.GetProgramDataPath(true);
            string targetAppDataFolder = targetOption.GetAppDataPath(true);
            string targetProgramDataFolder = targetOption.GetProgramDataPath(true);

            foreach (string configFile in configFiles)
            {
                string sourceConfigFile = configFile;

                //Handling Prepar3d.CFG and FSX.CFG files.
                if (configFile.Equals(targetOption.GetSimConfigFile()))
                {
                    sourceConfigFile = sourceOption.GetSimConfigFile();
                }

                try
                {
                    if (File.Exists(targetAppDataFolder + "\\" + configFile))
                    {
                        File.Copy(targetAppDataFolder + "\\" + configFile, sourceAppDataFolder + "\\" + sourceConfigFile, true);
                    }

                    if (File.Exists(targetProgramDataFolder + "\\" + configFile))
                    {
                        File.Copy(targetProgramDataFolder + "\\" + configFile, sourceProgramDataFolder + "\\" + sourceConfigFile, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function copyTargetSimFilesToSource() - " + e.ToString());
                    continue;
                }
            }

            HistoryHandler.AppendHistory("3," + sourceOption.GetValue());

            return true;
        }

        /**
         * Restores the source config files. Should be called on program startup.
         */
        public static bool RestoreSourceConfigFiles(SimulatorOption simOption)
        {
            if (simOption == null)
            {
                return false;
            }

            string sourceAppDataFolder = simOption.GetAppDataPath(true);
            string sourceProgramDataFolder = simOption.GetProgramDataPath(true);

            foreach(string configFile in configFiles){
                string completeAppDataBackupFilePath = sourceAppDataFolder + @"\migrationBackup\" + configFile;
                string completeProgramDataBackupFilePath = sourceProgramDataFolder + @"\migrationBackup\" + configFile;

                try{
                    if (File.Exists(completeAppDataBackupFilePath))
                    {
                        File.Copy(completeAppDataBackupFilePath, sourceAppDataFolder + "\\" + configFile, true);
                        File.Delete(completeAppDataBackupFilePath);
                    }
                }
                catch(Exception e){
                    ErrorLogger.LogError("Could not copy or delete file at function restoreSourceConfigFiles() - " + e);
                }

                try
                {
                    if (File.Exists(completeProgramDataBackupFilePath))
                    {
                        File.Copy(completeProgramDataBackupFilePath, sourceProgramDataFolder + "\\" + configFile, true);
                        File.Delete(completeProgramDataBackupFilePath);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy or delete file at function restoreSourceConfigFiles() - " + e);
                }
            }

            return true;
        }

        /**
         * Copies a directory.
         */
        public static bool CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirectory);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                return false;
            }

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(targetDirectory, file.Name);

                file.CopyTo(temppath, false);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(targetDirectory, subdir.Name);

                CopyDirectory(subdir.FullName, temppath);
            }

            return true;
        }
    }
}
