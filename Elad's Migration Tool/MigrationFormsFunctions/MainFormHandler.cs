using Elad_s_Migration_Tool.AddonModules;
using Elad_s_Migration_Tool.FilesFunctions;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.Logs;
using Elad_s_Migration_Tool.RegistryFunctions;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class MainFormHandler
    {
        protected const string START_MIGRATION_TEXT = "Start Migration";
        protected const string STOP_MIGRATION_TEXT = "Stop Migration";

        protected static Button startMigrateButton = MainForm.GetStartMigrateButton();
        protected static bool ignoreSourceMigrationChange = true;
        protected static bool ignoreTargetMigrationChange = true;

        //Selected simulators reference
        protected static SimulatorOption selectedSourceSimulator;
        protected static SimulatorOption selectedTargetSimulator;

        //Addons objects
        protected static UltimateTraffic2 ultimateTraffic2;

        /**
         * Handles the main form's load functionality.
         */
        public static void OnLoadHandler()
        {
            CloseIfAlreadyRunning();

            MigrationComboFunctions.FillSourceMigrationComboOptions();
            MigrationComboFunctions.FillTargetMigrationComboOptions();

            //If the settings exist, we initialize the selected options from the settings
            string migrationSourceVal = SettingsHandler.GetSetting("migrationSource");
            string migrationTargetVal = SettingsHandler.GetSetting("migrationTarget");

            if (!migrationSourceVal.Equals(""))
            {
                SimulatorOptions.SetSelectedOptionByVal(MainForm.GetMigrateSourceCombo(), Int32.Parse(migrationSourceVal));
            }

            if (!migrationTargetVal.Equals(""))
            {
                SimulatorOptions.SetSelectedOptionByVal(MainForm.GetMigrateTargetCombo(), Int32.Parse(migrationTargetVal));
            }

            string isStarted = SettingsHandler.GetSetting("started");
            string autoStart = SettingsHandler.GetSetting("autoStart");

            //Initializes the listeners if the auto start option is available and the migration is in started mode.
            if (isStarted.Equals("1") && autoStart.Equals("1"))
            {
                startMigrateButton.Text = STOP_MIGRATION_TEXT;

                DisableMigrationCombos();
                FileListeners.InitStaticListeners();
            }
            else
            {
                SettingsHandler.SetSetting("started", "0");
                FilesHandler.RestoreSourceConfigFiles(GetSelectedSourceSimulator()); //Restores the source config files if exist
            }

            InitializeDefaultSettings();
        }

        /**
         * Handles the start migration button's functionality.
         */
        public static void StartMigrationHandler()
        {
            string isStarted = SettingsHandler.GetSetting("started");

            if (isStarted.Equals("1"))
            {                
                if (HistoryHandler.RevertChanges())
                {
                    SettingsHandler.SetSetting("started", "0");
                    startMigrateButton.Text = START_MIGRATION_TEXT;
                    EnableMigrationCombos();
                    StopSpecialAddonListeners();
                }
                else
                {
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                }
            }
            else
            {
                DisableMigrationCombos();

                if (!FileListeners.InitStaticListeners())
                {
                    HistoryHandler.RevertChanges();
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                    EnableMigrationCombos();

                    return;
                }

                if (!RegistryHandler.SetSourceAsTarget())
                {
                    FileListeners.RemoveListeners();
                    HistoryHandler.RevertChanges();
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                    EnableMigrationCombos();

                    return;
                }

                StartSpecialAddonListeners();

                FilesHandler.CreateFakeFsxExecutable(GetSelectedTargetSimulator().GetSimPath());

                startMigrateButton.Text = STOP_MIGRATION_TEXT;
                SettingsHandler.SetSetting("started", "1");
            }
        }

        /**
         * Sets whether should the app ignore the source migration combo change event.
         */
        public static void SetIgnoreSourceMigrationChange(bool setIgnore)
        {
            ignoreSourceMigrationChange = setIgnore;
        }

        /**
         * Sets whether should the app ignore the target migration combo change event.
         */
        public static void SetIgnoreTargetMigrationChange(bool setIgnore)
        {
            ignoreTargetMigrationChange = setIgnore;
        }

        /**
         * Returns the selected source SimulatorOption.
         */
        public static SimulatorOption GetSelectedSourceSimulator()
        {
            return selectedSourceSimulator;
        }

        /**
         * Returns the selected target SimulatorOption.
         */
        public static SimulatorOption GetSelectedTargetSimulator()
        {
            return selectedTargetSimulator;
        }

        /**
         * Handles the source migration change event.
         */
        public static void SourceMigrationChangeHandler()
        {
            SimulatorOption simOption;

            if (!ignoreSourceMigrationChange)
            {
                MigrationComboFunctions.FillSourceMigrationComboOptions();

                simOption = SimulatorOptions.GetOptionBySelectedItem(MainForm.GetMigrateSourceCombo());
                SettingsHandler.SetSetting("migrationSource", simOption.GetValue().ToString());
            }

            simOption = SimulatorOptions.GetOptionBySelectedItem(MainForm.GetMigrateSourceCombo());
            selectedSourceSimulator = simOption;
        }

        /**
         * Handles the target migration change event.
         */
        public static void TargetMigrationChangeHandler()
        {
            SimulatorOption simOption;

            if (!ignoreTargetMigrationChange)
            {
                MigrationComboFunctions.FillTargetMigrationComboOptions();

                simOption = SimulatorOptions.GetOptionBySelectedItem(MainForm.GetMigrateTargetCombo());
                SettingsHandler.SetSetting("migrationTarget", simOption.GetValue().ToString());
            }

            simOption = SimulatorOptions.GetOptionBySelectedItem(MainForm.GetMigrateTargetCombo());
            selectedTargetSimulator = simOption;
        }

        /**
         * Initializes the default program settings.
         */
        protected static void InitializeDefaultSettings()
        {
            string windowsStartup = SettingsHandler.GetSetting("windowsStartup");
            string autoStart = SettingsHandler.GetSetting("autoStart");
            string ultimateTraffic2 = SettingsHandler.GetSetting("ultimateTraffic2");

            if (windowsStartup.Equals(""))
            {
                //SettingsHandler.setSetting("windowsStartup", "0");
            }

            if (autoStart.Equals(""))
            {
                SettingsHandler.SetSetting("autoStart", "0");
            }

            if (ultimateTraffic2.Equals(""))
            {
                SettingsHandler.SetSetting("ultimateTraffic2", "1");
            }
        }

        /**
         * Closes the program if it's already running to avoid problems.
         */
        protected static void CloseIfAlreadyRunning()
        {
            string processName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            processName = processName.Replace(".exe", "");

            Process[] pname = Process.GetProcessesByName(processName);

            if (pname.Length > 1)
            {
                Application.Exit();
            }
        }

        /**
         * Handles the exit buttons operations.
         */
        public static void ExitHandler()
        {
            string autoStart = SettingsHandler.GetSetting("autoStart");

            if (!autoStart.Equals("1"))
            {
                HistoryHandler.RevertChanges();
                StopSpecialAddonListeners();
                SettingsHandler.SetSetting("started", "0");
            }

            Application.Exit();
        }

        /**
         * Disables the migration combos in the MainForm.
         */
        public static void DisableMigrationCombos()
        {
            MainForm.GetMigrateSourceCombo().Enabled = false;
            MainForm.GetMigrateTargetCombo().Enabled = false;
        }

        /**
         * Enables the migration combos in the MainForm.
         */
        public static void EnableMigrationCombos()
        {
            MainForm.GetMigrateSourceCombo().Enabled = true;
            MainForm.GetMigrateTargetCombo().Enabled = true;
        }

        /**
         * Starts the special addons listeners.
         */
        protected static void StartSpecialAddonListeners()
        {
            ultimateTraffic2 = new UltimateTraffic2();
            ultimateTraffic2.Start();
        }

        /**
         * Stops the special addons listeners.
         */
        protected static void StopSpecialAddonListeners()
        {
            if (ultimateTraffic2 != null)
            {
                ultimateTraffic2.Stop();
                ultimateTraffic2 = null;
            }
        }
    }
}
