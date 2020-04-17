using Elad_s_Migration_Tool.FilesFunctions;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.MigrationFormsFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Elad_s_Migration_Tool.AddonModules
{
    class UltimateTraffic2
    {
        protected SimulatorOption migrateTarget = MainFormHandler.GetSelectedTargetSimulator();

        protected static List<System.Timers.Timer> timers = new List<System.Timers.Timer>();
        protected const double TIMER_INTERVAL = 20; //defines how often should the timers run

        /**
         * Creates a listener for the SimObjects.cfg file.
         */
        protected void CreateSimObjectsListener()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { ModifySimObjects(timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Creates a listener for the UT2Settings.cfg file.
         */
        protected void CreateUT2SettingsListener()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { ModifyUT2Settings(timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Initializes the UT2 file listeners.
         */
        protected void InitListeners()
        {
            if (timers.Count > 0) //It's already running
            {
                return;
            }

            CreateSimObjectsListener();
            CreateUT2SettingsListener();
        }

        /**
         * Stops the listeners.
         */
        protected void StopListeners()
        {
            if (timers.Count <= 0) //There's nothing to stop
            {
                return;
            }

            foreach (System.Timers.Timer timer in timers)
            {
                timer.Stop();
            }

            timers = new List<System.Timers.Timer>();
        }

        /**
         * Starts the process of migrating the UT2 addon.
         */
        public void Start()
        {
            string ultimateTraffic2Setting = SettingsHandler.GetSetting("ultimateTraffic2");

            if (ultimateTraffic2Setting.Equals("1"))
            {
                InitListeners();
            }
        }

        /**
         * Stops the UT2 migration process.
         */
        public void Stop()
        {
            StopListeners();
        }

        /**
         * Modifies the simobjects.cfg file.
         */
        protected bool ModifySimObjects(System.Timers.Timer timer)
        {
            string file = migrateTarget.GetProgramDataPath(true) + "\\simobjects.cfg";

            if (!File.Exists(file))
            {
                return false;
            }

            List<string> fileContent = Helper.GetTextFileContent(file);

            int lastEntry = 0;

            foreach (string line in fileContent)
            {
                if (line.Contains(@"SimObjects\UT2 Aircraft")) //Validating that it is not installed yet in this file
                {
                    timer.Stop();
                    timers.Remove(timer);

                    return true;
                }

                if (!line.Contains("[Entry."))
                {
                    continue;
                }

                string newLine = line.Replace("[Entry.", "");
                newLine = newLine.Replace("]", "");

                int number = 0;
                Int32.TryParse(newLine, out number);

                if (number > lastEntry)
                {
                    lastEntry = number;
                }
            }

            if (lastEntry <= 0)
            {
                return false;
            }

            lastEntry++;

            string completeFileText = File.ReadAllText(file);
            bool lastLineEmpty = completeFileText.EndsWith(Environment.NewLine);

            if (!lastLineEmpty)
            {
                if (!Helper.WriteLineToText(file, ""))
                {
                    return false;
                }
            }

            if (!Helper.WriteLineToText(file, "[Entry." + lastEntry + "]"))
            {
                return false;
            }

            Helper.WriteLineToText(file, "Title=Ultimate Traffic 2");
            Helper.WriteLineToText(file, @"Path=SimObjects\UT2 Aircraft");
            Helper.WriteLineToText(file, "Required=True");
            Helper.WriteLineToText(file, "Active=True");

            return true;
        }

        /**
         * Modifies the UT2settings.cfg file.
         */
        protected bool ModifyUT2Settings(System.Timers.Timer timer)
        {
            string file = FilesHandler.GetApplicationDataPath() + @"\Flight One Software\Ultimate Traffic 2\UT2settings.cfg";

            if (!File.Exists(file))
            {
                return false;
            }

            List<string> fileContent = Helper.GetTextFileContent(file);
            List<string> newFileContent = new List<string>();

            string newLine = "FSX Location=" + migrateTarget.GetSimPath();

            foreach (string line in fileContent)
            {
                if (!line.Contains("FSX Location"))
                {
                    newFileContent.Add(line);
                    continue;
                }

                if (line.Equals(newLine))
                {
                    timer.Stop();

                    try
                    {
                        timers.Remove(timer);
                    }
                    catch (Exception)
                    {

                    }

                    return true;
                }
            }

            newFileContent.Add(newLine);

            Helper.SetTextFileContent(file, newFileContent);

            return true;
        }
    }
}
