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
        protected SimulatorOption migrateTarget = MainFormHandler.getSelectedTargetSimulator();

        protected static List<System.Timers.Timer> timers = new List<System.Timers.Timer>();
        protected const double TIMER_INTERVAL = 20; //defines how often should the timers run

        /**
         * Constructor
         */
        public UltimateTraffic2()
        {
            
        }

        /**
         * Creates a listener for the SimObjects.cfg file.
         */
        protected void createSimObjectsListener()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { modifySimObjects(timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Creates a listener for the UT2Settings.cfg file.
         */
        protected void createUT2SettingsListener()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * TIMER_INTERVAL);
            timer.Elapsed += delegate { modifyUT2Settings(timer); };
            timer.Enabled = true;
            timer.Start();
            timers.Add(timer);
        }

        /**
         * Initializes the UT2 file listeners.
         */
        protected void initListeners()
        {
            if (timers.Count > 0) //It's already running
            {
                return;
            }

            createSimObjectsListener();
            createUT2SettingsListener();
        }

        /**
         * Stops the listeners.
         */
        protected void stopListeners()
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
        public void start()
        {
            string ultimateTraffic2Setting = SettingsHandler.getSetting("ultimateTraffic2");

            if (ultimateTraffic2Setting.Equals("1"))
            {
                initListeners();
            }
        }

        /**
         * Stops the UT2 migration process.
         */
        public void stop()
        {
            stopListeners();
        }

        /**
         * Modifies the simobjects.cfg file.
         */
        protected bool modifySimObjects(System.Timers.Timer timer)
        {
            string file = migrateTarget.getProgramDataPath(true) + "\\simobjects.cfg";

            if (!File.Exists(file))
            {
                return false;
            }

            List<string> fileContent = Helper.getTextFileContent(file);

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
                if (!Helper.writeLineToText(file, ""))
                {
                    return false;
                }
            }

            if (!Helper.writeLineToText(file, "[Entry." + lastEntry + "]"))
            {
                return false;
            }

            Helper.writeLineToText(file, "Title=Ultimate Traffic 2");
            Helper.writeLineToText(file, @"Path=SimObjects\UT2 Aircraft");
            Helper.writeLineToText(file, "Required=True");
            Helper.writeLineToText(file, "Active=True");

            return true;
        }

        /**
         * Modifies the UT2settings.cfg file.
         */
        protected bool modifyUT2Settings(System.Timers.Timer timer)
        {
            string file = FilesHandler.getApplicationDataPath() + @"\Flight One Software\Ultimate Traffic 2\UT2settings.cfg";

            if (!File.Exists(file))
            {
                return false;
            }

            List<string> fileContent = Helper.getTextFileContent(file);
            List<string> newFileContent = new List<string>();

            string newLine = "FSX Location=" + migrateTarget.getSimPath();

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

            Helper.setTextFileContent(file, newFileContent);

            return true;
        }
    }
}