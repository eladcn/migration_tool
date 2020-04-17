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

        private static string[] configFiles = FilesHandler.getConfigFiles();
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
        private bool shouldCopyFile(string filePath)
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
        private void fileListener(string configFile, System.Timers.Timer currentTimer)
        {
            SimulatorOption sourceOption = MainFormHandler.getSelectedSourceSimulator();
            SimulatorOption targetOption = MainFormHandler.getSelectedTargetSimulator();

            //Should never happen but just in case...
            if (sourceOption == null || targetOption == null)
            {
                currentTimer.Stop();
                timers.Remove(currentTimer);

                return;
            }

            string targetConfigFile = configFile;

            //Handling Prepare3D.CFG and FSX.CFG.
            if (configFile.Equals(sourceOption.getSimConfigFile()))
            {
                targetConfigFile = targetOption.getSimConfigFile();
            }

            string sourceAppDataPath = sourceOption.getAppDataPath(true) + "\\" + configFile;
            string sourceProgramDataPath = sourceOption.getProgramDataPath(true) + "\\" + configFile;
            string targetAppDataPath = targetOption.getAppDataPath(true) + "\\" + targetConfigFile;
            string targetProgramDataPath = targetOption.getProgramDataPath(true) + "\\" + targetConfigFile;

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
                    if (shouldCopyFile(targetAppDataPath))
                    {
                        File.Copy(targetAppDataPath, sourceAppDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.logError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (targetProgramDataExists)
            {
                try
                {
                    if (shouldCopyFile(targetProgramDataPath))
                    {
                        File.Copy(targetProgramDataPath, sourceProgramDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.logError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (sourceAppDataExists)
            {
                try
                {
                    if (shouldCopyFile(sourceAppDataPath))
                    {
                        File.Copy(sourceAppDataPath, targetAppDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.logError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }

            if (sourceProgramDataExists)
            {
                try
                {
                    if (shouldCopyFile(sourceProgramDataPath))
                    {
                        File.Copy(sourceProgramDataPath, targetProgramDataPath, true);
                    }
                }
                catch (Exception e)
                {
                    ErrorLogger.logError("Could not copy file, function fileListener() - " + e.ToString());
                }
            }
        }

        /**
         * Creates a listener for a specific file.
         */
        public void createFileListener(string configFile)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { fileListener(configFile, timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Initializes the listeners in a static way.
         */
        public static bool initStaticListeners()
        {
            //Singleton
            if (instance == null)
            {
                new FileListeners();
            }

            return instance.initListeners();
        }

        /**
         * Adds listeners to the config files.
         */
        public bool initListeners()
        {
            if (!FilesHandler.copyTargetSimFilesToSource())
            {
                ErrorLogger.logError("Could not initialize the listeners - function copyTargetSimFilesToSource() failed.");
                return false;
            }

            foreach (string configFile in configFiles)
            {
                createFileListener(configFile);
            }

            if (timers.Count <= 0)
            {
                ErrorLogger.logError("Could not initialize the listeners - the files were not found and therefore the timers count is 0.");
                return false;
            }

            return true;
        }

        /**
         * Removes all config files listeners.
         */
        public static void removeListeners()
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