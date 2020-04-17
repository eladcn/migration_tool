using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elad_s_Migration_Tool.General;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class MigrationComboFunctions
    {
        protected static List<SimulatorOption> allSimulatorOptions = SimulatorOptions.getAllSimulatorOptions();
        protected static List<SimulatorOption> simOptionsInPC = SimulatorOptions.getSimOptionsInPC();

        protected static int[] defaultIgnoreFromMigrationItems = { 6 };
        protected static int[] defaultIgnoreToMigrationItems = { 1, 2 };
        protected static int defaultMigrateTo = 6;

        protected static bool defaultTargetChosen = false;

        /**
         * Fills a specific combo box with the migration options.
         */
        protected static void fillMigrationComboOptions(ComboBox combo, int[] ignoreID, bool onlyInPC)
        {
            combo.Items.Clear();

            for (int i = 0; i < allSimulatorOptions.Count; i++)
            {
                SimulatorOption optionObject = allSimulatorOptions[i];

                if (optionObject == null)
                {
                    continue;
                }

                if (ignoreID.Contains(optionObject.getValue()))
                {
                    continue;
                }

                if (onlyInPC && !simOptionsInPC.Contains(optionObject))
                {
                    continue;
                }

                combo.Items.Add(optionObject);
            }

            //Making sure the migration change event does not fire, or else an endless recursion will occur
            MainFormHandler.setIgnoreSourceMigrationChange(true);
            MainFormHandler.setIgnoreTargetMigrationChange(true);

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }

            MainFormHandler.setIgnoreSourceMigrationChange(false);
            MainFormHandler.setIgnoreTargetMigrationChange(false);
        }

        /**
         * Returns the selected SimulatorOption.
         */
        public static SimulatorOption getSelectedItem(ComboBox combo)
        {
            int selectedIndex = combo.SelectedIndex;
            int counter = 0;

            if (selectedIndex == -1)
            {
                return null;
            }

            foreach (SimulatorOption simulatorOption in combo.Items)
            {
                if (counter == selectedIndex)
                {
                    return simulatorOption;
                }

                counter++;
            }

            return null;
        }

        /**
         * Returns the migrateFromCombo's selected item.
         */
        public static SimulatorOption getMigrateSourceSelectedOption()
        {
            return getSelectedItem(MainForm.getMigrateSourceCombo());
        }

        /**
         * Returns the migrateToCombo's selected item.
         */
        public static SimulatorOption getMigrateTargetSelectedOption()
        {
            return getSelectedItem(MainForm.getMigrateTargetCombo());
        }

        /**
         * Returns the value of the selected item in a combo box.
         */
        protected static int getSelectedItemValue(ComboBox combo)
        {
            int counter = 0;
            int selectedIndex = combo.SelectedIndex;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (counter == selectedIndex)
                {
                    return simOption.getValue();
                }

                counter++;
            }

            return -1;
        }

        /**
         * Selects a specific item in the combo box if exists according to its value.
         */
        protected static void selectItemByVal(ComboBox combo, int val)
        {
            MainFormHandler.setIgnoreSourceMigrationChange(true);
            MainFormHandler.setIgnoreTargetMigrationChange(true);
            
            int counter = 0;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (simOption.getValue() == val)
                {
                    combo.SelectedIndex = counter;

                    break;
                }

                counter++;
            }

            MainFormHandler.setIgnoreSourceMigrationChange(false);
            MainFormHandler.setIgnoreTargetMigrationChange(false);
        }

        /**
         * Fills the fromMigrationCombo ComboBox data.
         */
        public static void fillSourceMigrationComboOptions()
        {
            ComboBox migrateSourceCombo = MainForm.getMigrateSourceCombo();
            ComboBox migrateTargetCombo = MainForm.getMigrateTargetCombo();

            if (migrateSourceCombo.Items.Count <= 0)
            {
                fillMigrationComboOptions(migrateSourceCombo, defaultIgnoreFromMigrationItems, false);
                return;
            }

            int ignoreID = 0;
            int currentMigrateToSelectedValue = getSelectedItemValue(migrateTargetCombo);

            if (migrateSourceCombo.SelectedIndex >= 0)
            {
                SimulatorOption selectedItem = getSelectedItem(migrateSourceCombo);

                foreach (SimulatorOption migrateToComboItem in migrateTargetCombo.Items)
                {
                    if (selectedItem.Equals(migrateToComboItem))
                    {
                        ignoreID = selectedItem.getValue();
                        break;
                    }
                }
            }

            if(ignoreID > 0){
                int defaultLength = defaultIgnoreToMigrationItems.Length;

                int[] ignoreIDs = new int[defaultLength + 1];
                defaultIgnoreToMigrationItems.CopyTo(ignoreIDs, 0);
                ignoreIDs[defaultLength] = ignoreID;

                fillMigrationComboOptions(migrateTargetCombo, ignoreIDs, true);
            }
            else
            {
                fillMigrationComboOptions(migrateTargetCombo, defaultIgnoreToMigrationItems, true);
            }

            selectItemByVal(migrateTargetCombo, currentMigrateToSelectedValue);
        }

        /**
         * Fills the toMigrationCombo ComboBox data.
         */
        public static void fillTargetMigrationComboOptions()
        {
            ComboBox migrateSourceCombo = MainForm.getMigrateSourceCombo();
            ComboBox migrateTargetCombo = MainForm.getMigrateTargetCombo();

            if (migrateTargetCombo.Items.Count <= 0)
            {
                fillMigrationComboOptions(migrateTargetCombo, defaultIgnoreToMigrationItems, true);

                //Making sure we have at least 1 simulator to migrate to, else we exit the program
                if (migrateTargetCombo.Items.Count == 0)
                {
                    MessageBox.Show("The program could not identify any simulators to migrate to on this computer.\nThe application will now exit.");
                    Application.Exit();
                }

                //We don't need to return because we want to check if we need to remove un-needed options from the "from" combo box.
            }

            int ignoreID = 0;
            int currentMigrateFromSelectedValue = getSelectedItemValue(migrateSourceCombo);

            if (migrateTargetCombo.SelectedIndex >= 0)
            {
                SimulatorOption selectedItem = getSelectedItem(migrateTargetCombo);

                foreach (SimulatorOption migrateFromComboItem in migrateSourceCombo.Items)
                {
                    if (selectedItem.Equals(migrateFromComboItem))
                    {
                        ignoreID = selectedItem.getValue();
                    }
                }
            }

            if (ignoreID > 0)
            {
                int defaultLength = defaultIgnoreFromMigrationItems.Length;

                int[] ignoreIDs = new int[defaultLength + 1];
                defaultIgnoreFromMigrationItems.CopyTo(ignoreIDs, 0);
                ignoreIDs[defaultLength] = ignoreID;

                fillMigrationComboOptions(migrateSourceCombo, ignoreIDs, false);
            }
            else
            {
                fillMigrationComboOptions(migrateSourceCombo, defaultIgnoreFromMigrationItems, false);
            }

            if (SettingsHandler.getSetting("migrationTarget").Equals("") && migrateTargetCombo.SelectedIndex >= 0 && !defaultTargetChosen)
            {
                selectItemByVal(migrateTargetCombo, defaultMigrateTo);
                defaultTargetChosen = true;
            }

            selectItemByVal(migrateSourceCombo, currentMigrateFromSelectedValue);
        }
    }
}