using Elad_s_Migration_Tool.General;
using System;
using System.Collections.Generic;
using System.IO;
using Elad_s_Migration_Tool.MigrationFormsFunctions;
using Elad_s_Migration_Tool.Logs;

namespace Elad_s_Migration_Tool.FilesFunctions
{
    class FileListeners
    {
        private static FileListeners instance;

        private static string[] configFiles = FilesHandler.GetConfigFiles();
        private static List<System.Timers.Timer> timers = new List<System.Timers.Timer>();
        private const double TIMER_OFFSET = 9; //defines how often should changes in the files be checked in seconds
        private const double TIMER_INTERVAL = 5; //defines how often the timer will run in seconds

        /**
         * Constructor - initializes the singleton.
         */
        public FileListeners()
        {
            instance = this;
        }

        /**
         * Returns whether a file should be copied or not.
         */
        private bool ShouldCopyFile(string filePath)
        {
            DateTime currentTime = DateTime.Now;

            DateTime lastWriteTime = File.GetLastWriteTime(filePath);
            TimeSpan timeDifference = currentTime.Subtract(lastWriteTime);
            FileInfo fileInfo = new FileInfo(filePath);

            return timeDifference.TotalSeconds <= TIMER_OFFSET && fileInfo.Length > 0;
        }

        /**
         * The actual listener's functionality.
         */
        private void FileListener(string configFile, System.Timers.Timer currentTimer)
        {
            SimulatorOption sourceOption = MainFormHandler.GetSelectedSourceSimulator();
            SimulatorOption targetOption = MainFormHandler.GetSelectedTargetSimulator();

            //Should never happen but just in case...
            if (sourceOption == null || targetOption == null)
            {
                currentTimer.Stop();
                timers.Remove(currentTimer);

                return;
            }

            string targetConfigFile = configFile;

            //Handling Prepare3D.CFG and FSX.CFG.
            if (configFile.Equals(sourceOption.GetSimConfigFile()))
            {
                targetConfigFile = targetOption.GetSimConfigFile();
            }

            string sourceAppDataPath = sourceOption.GetAppDataPath(true) + "\\" + configFile;
            string sourceProgramDataPath = sourceOption.GetProgramDataPath(true) + "\\" + configFile;
            string targetAppDataPath = targetOption.GetAppDataPath(true) + "\\" + targetConfigFile;
            string targetProgramDataPath = targetOption.GetProgramDataPath(true) + "\\" + targetConfigFile;

            bool sourceAppDataExists = File.Exists(sourceAppDataPath);
            bool sourceProgramDataExists = File.Exists(sourceProgramDataPath);
            bool targetAppDataExists = File.Exists(targetAppDataPath);
            bool targetProgramDataExists = File.Exists(targetProgramDataPath);

            //If the config file does not exist at all we skip it
            if (!sourceAppDataExists && !sourceProgramDataExists && !targetAppDataExists && !targetProgramDataExists)
            {
                currentTimer.Stop();
                timers.Remove(currentTimer);

                return;
            }

            if (!targetAppDataExists && !targetProgramDataExists)
            {
                currentTimer.Stop();
                timers.Remove(currentTimer);

                return;
            }

            if (targetAppDataExists)
            {
                try
                {
                    if (ShouldCopyFile(targetAppDataPath))
                    {
                        File.Copy(targetAppDataPath, sourceAppDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (targetProgramDataExists)
            {
                try
                {
                    if (ShouldCopyFile(targetProgramDataPath))
                    {
                        File.Copy(targetProgramDataPath, sourceProgramDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (sourceAppDataExists)
            {
                try
                {
                    if (ShouldCopyFile(sourceAppDataPath))
                    {
                        File.Copy(sourceAppDataPath, targetAppDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (sourceProgramDataExists)
            {
                try
                {
                    if (ShouldCopyFile(sourceProgramDataPath))
                    {
                        File.Copy(sourceProgramDataPath, targetProgramDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.LogError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }
        }

        /**
         * Creates a listener for a specific file.
         */
        public void CreateFileListener(string configFile)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { FileListener(configFile, timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Initializes the listeners in a static way.
         */
        public static bool InitStaticListeners()
        {
            //Singleton
            if (instance == null)
            {
                new FileListeners();
            }

            return instance.InitListeners();
        }

        /**
         * Adds listeners to the config files.
         */
        public bool InitListeners()
        {
            if (!FilesHandler.CopyTargetSimFilesToSource())
            {
                ErrorLogger.LogError("Could not initialize the listeners - function copyTargetSimFilesToSource() failed.");
                return false;
            }

            foreach (string configFile in configFiles)
            {
                CreateFileListener(configFile);
            }

            if (timers.Count <= 0)
            {
                ErrorLogger.LogError("Could not initialize the listeners - the files were not found and therefore the timers count is 0.");
                return false;
            }

            return true;
        }

        /**
         * Removes all config files listeners.
         */
        public static void RemoveListeners()
        {
            if (timers.Count <= 0)
            {
                return;
            }

            foreach (System.Timers.Timer timer in timers)
            {
                timer.Stop();
            }

            timers.Clear();
        }
    }
}
