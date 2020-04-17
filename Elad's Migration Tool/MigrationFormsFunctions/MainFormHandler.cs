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

        protected static Button startMigrateButton = MainForm.getStartMigrateButton();
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
        public static void onLoadHandler()
        {
            closeIfAlreadyRunning();

            MigrationComboFunctions.fillSourceMigrationComboOptions();
            MigrationComboFunctions.fillTargetMigrationComboOptions();

            //If the settings exist, we initialize the selected options from the settings
            string migrationSourceVal = SettingsHandler.getSetting("migrationSource");
            string migrationTargetVal = SettingsHandler.getSetting("migrationTarget");

            if (!migrationSourceVal.Equals(""))
            {
                SimulatorOptions.setSelectedOptionByVal(MainForm.getMigrateSourceCombo(), Int32.Parse(migrationSourceVal));
            }

            if (!migrationTargetVal.Equals(""))
            {
                SimulatorOptions.setSelectedOptionByVal(MainForm.getMigrateTargetCombo(), Int32.Parse(migrationTargetVal));
            }

            string isStarted = SettingsHandler.getSetting("started");
            string autoStart = SettingsHandler.getSetting("autoStart");

            //Initializes the listeners if the auto start option is available and the migration is in started mode.
            if (isStarted.Equals("1") && autoStart.Equals("1"))
            {
                startMigrateButton.Text = STOP_MIGRATION_TEXT;

                disableMigrationCombos();
                FileListeners.initStaticListeners();
            }
            else
            {
                SettingsHandler.setSetting("started", "0");
                FilesHandler.restoreSourceConfigFiles(getSelectedSourceSimulator()); //Restores the source config files if exist
            }

            initializeDefaultSettings();
        }

        /**
         * Handles the start migration button's functionality.
         */
        public static void startMigrationHandler()
        {
            string isStarted = SettingsHandler.getSetting("started");

            if (isStarted.Equals("1"))
            {                
                if (HistoryHandler.revertChanges())
                {
                    SettingsHandler.setSetting("started", "0");
                    startMigrateButton.Text = START_MIGRATION_TEXT;
                    enableMigrationCombos();
                    stopSpecialAddonListeners();
                }
                else
                {
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                }
            }
            else
            {
                disableMigrationCombos();

                if (!FileListeners.initStaticListeners())
                {
                    HistoryHandler.revertChanges();
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                    enableMigrationCombos();

                    return;
                }

                if (!RegistryHandler.setSourceAsTarget())
                {
                    FileListeners.removeListeners();
                    HistoryHandler.revertChanges();
                    MessageBox.Show("An error has occured, please try again or contact the developer for support.");
                    enableMigrationCombos();

                    return;
                }

                startSpecialAddonListeners();

                FilesHandler.createFakeFsxExecutable(getSelectedTargetSimulator().getSimPath());

                startMigrateButton.Text = STOP_MIGRATION_TEXT;
                SettingsHandler.setSetting("started", "1");
            }
        }

        /**
         * Sets whether should the app ignore the source migration combo change event.
         */
        public static void setIgnoreSourceMigrationChange(bool setIgnore)
        {
            ignoreSourceMigrationChange = setIgnore;
        }

        /**
         * Sets whether should the app ignore the target migration combo change event.
         */
        public static void setIgnoreTargetMigrationChange(bool setIgnore)
        {
            ignoreTargetMigrationChange = setIgnore;
        }

        /**
         * Returns the selected source SimulatorOption.
         */
        public static SimulatorOption getSelectedSourceSimulator()
        {
            return selectedSourceSimulator;
        }

        /**
         * Returns the selected target SimulatorOption.
         */
        public static SimulatorOption getSelectedTargetSimulator()
        {
            return selectedTargetSimulator;
        }

        /**
         * Handles the source migration change event.
         */
        public static void sourceMigrationChangeHandler()
        {
            SimulatorOption simOption;

            if (!ignoreSourceMigrationChange)
            {
                MigrationComboFunctions.fillSourceMigrationComboOptions();

                simOption = SimulatorOptions.getOptionBySelectedItem(MainForm.getMigrateSourceCombo());
                SettingsHandler.setSetting("migrationSource", simOption.getValue().ToString());
            }

            simOption = SimulatorOptions.getOptionBySelectedItem(MainForm.getMigrateSourceCombo());
            selectedSourceSimulator = simOption;
        }

        /**
         * Handles the target migration change event.
         */
        public static void targetMigrationChangeHandler()
        {
            SimulatorOption simOption;

            if (!ignoreTargetMigrationChange)
            {
                MigrationComboFunctions.fillTargetMigrationComboOptions();

                simOption = SimulatorOptions.getOptionBySelectedItem(MainForm.getMigrateTargetCombo());
                SettingsHandler.setSetting("migrationTarget", simOption.getValue().ToString());
            }

            simOption = SimulatorOptions.getOptionBySelectedItem(MainForm.getMigrateTargetCombo());
            selectedTargetSimulator = simOption;
        }

        /**
         * Initializes the default program settings.
         */
        protected static void initializeDefaultSettings()
        {
            string windowsStartup = SettingsHandler.getSetting("windowsStartup");
            string autoStart = SettingsHandler.getSetting("autoStart");
            string ultimateTraffic2 = SettingsHandler.getSetting("ultimateTraffic2");

            if (windowsStartup.Equals(""))
            {
                //SettingsHandler.setSetting("windowsStartup", "0");
            }

            if (autoStart.Equals(""))
            {
                SettingsHandler.setSetting("autoStart", "0");
            }

            if (ultimateTraffic2.Equals(""))
            {
                SettingsHandler.setSetting("ultimateTraffic2", "1");
            }
        }

        /**
         * Closes the program if it's already running to avoid problems.
         */
        protected static void closeIfAlreadyRunning()
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
        public static void exitHandler()
        {
            string autoStart = SettingsHandler.getSetting("autoStart");

            if (!autoStart.Equals("1"))
            {
                HistoryHandler.revertChanges();
                stopSpecialAddonListeners();
                SettingsHandler.setSetting("started", "0");
            }

            Application.Exit();
        }

        /**
         * Disables the migration combos in the MainForm.
         */
        public static void disableMigrationCombos()
        {
            MainForm.getMigrateSourceCombo().Enabled = false;
            MainForm.getMigrateTargetCombo().Enabled = false;
        }

        /**
         * Enables the migration combos in the MainForm.
         */
        public static void enableMigrationCombos()
        {
            MainForm.getMigrateSourceCombo().Enabled = true;
            MainForm.getMigrateTargetCombo().Enabled = true;
        }

        /**
         * Starts the special addons listeners.
         */
        protected static void startSpecialAddonListeners()
        {
            ultimateTraffic2 = new UltimateTraffic2();
            ultimateTraffic2.start();
        }

        /**
         * Stops the special addons listeners.
         */
        protected static void stopSpecialAddonListeners()
        {
            if (ultimateTraffic2 != null)
            {
                ultimateTraffic2.stop();
                ultimateTraffic2 = null;
            }
        }
    }
}
