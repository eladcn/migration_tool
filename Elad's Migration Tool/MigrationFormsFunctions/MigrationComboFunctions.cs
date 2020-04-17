using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elad_s_Migration_Tool.General;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class MigrationComboFunctions
    {
        protected static List<SimulatorOption> allSimulatorOptions = SimulatorOptions.GetAllSimulatorOptions();
        protected static List<SimulatorOption> simOptionsInPC = SimulatorOptions.GetSimOptionsInPC();

        protected static int[] defaultIgnoreFromMigrationItems = { 6 };
        protected static int[] defaultIgnoreToMigrationItems = { 1, 2 };
        protected static int defaultMigrateTo = 6;

        protected static bool defaultTargetChosen = false;

        /**
         * Fills a specific combo box with the migration options.
         */
        protected static void FillMigrationComboOptions(ComboBox combo, int[] ignoreID, bool onlyInPC)
        {
            combo.Items.Clear();

            for (int i = 0; i < allSimulatorOptions.Count; i++)
            {
                SimulatorOption optionObject = allSimulatorOptions[i];

                if (optionObject == null)
                {
                    continue;
                }

                if (ignoreID.Contains(optionObject.GetValue()))
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
            MainFormHandler.SetIgnoreSourceMigrationChange(true);
            MainFormHandler.SetIgnoreTargetMigrationChange(true);

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }

            MainFormHandler.SetIgnoreSourceMigrationChange(false);
            MainFormHandler.SetIgnoreTargetMigrationChange(false);
        }

        /**
         * Returns the selected SimulatorOption.
         */
        public static SimulatorOption GetSelectedItem(ComboBox combo)
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
         * Returns the value of the selected item in a combo box.
         */
        protected static int GetSelectedItemValue(ComboBox combo)
        {
            int counter = 0;
            int selectedIndex = combo.SelectedIndex;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (counter == selectedIndex)
                {
                    return simOption.GetValue();
                }

                counter++;
            }

            return -1;
        }

        /**
         * Selects a specific item in the combo box if exists according to its value.
         */
        protected static void SelectItemByVal(ComboBox combo, int val)
        {
            MainFormHandler.SetIgnoreSourceMigrationChange(true);
            MainFormHandler.SetIgnoreTargetMigrationChange(true);
            
            int counter = 0;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (simOption.GetValue() == val)
                {
                    combo.SelectedIndex = counter;

                    break;
                }

                counter++;
            }

            MainFormHandler.SetIgnoreSourceMigrationChange(false);
            MainFormHandler.SetIgnoreTargetMigrationChange(false);
        }

        /**
         * Fills the fromMigrationCombo ComboBox data.
         */
        public static void FillSourceMigrationComboOptions()
        {
            ComboBox migrateSourceCombo = MainForm.GetMigrateSourceCombo();
            ComboBox migrateTargetCombo = MainForm.GetMigrateTargetCombo();

            if (migrateSourceCombo.Items.Count <= 0)
            {
                FillMigrationComboOptions(migrateSourceCombo, defaultIgnoreFromMigrationItems, false);
                return;
            }

            int ignoreID = 0;
            int currentMigrateToSelectedValue = GetSelectedItemValue(migrateTargetCombo);

            if (migrateSourceCombo.SelectedIndex >= 0)
            {
                SimulatorOption selectedItem = GetSelectedItem(migrateSourceCombo);

                foreach (SimulatorOption migrateToComboItem in migrateTargetCombo.Items)
                {
                    if (selectedItem.Equals(migrateToComboItem))
                    {
                        ignoreID = selectedItem.GetValue();
                        break;
                    }
                }
            }

            if(ignoreID > 0){
                int defaultLength = defaultIgnoreToMigrationItems.Length;

                int[] ignoreIDs = new int[defaultLength + 1];
                defaultIgnoreToMigrationItems.CopyTo(ignoreIDs, 0);
                ignoreIDs[defaultLength] = ignoreID;

                FillMigrationComboOptions(migrateTargetCombo, ignoreIDs, true);
            }
            else
            {
                FillMigrationComboOptions(migrateTargetCombo, defaultIgnoreToMigrationItems, true);
            }

            SelectItemByVal(migrateTargetCombo, currentMigrateToSelectedValue);
        }

        /**
         * Fills the toMigrationCombo ComboBox data.
         */
        public static void FillTargetMigrationComboOptions()
        {
            ComboBox migrateSourceCombo = MainForm.GetMigrateSourceCombo();
            ComboBox migrateTargetCombo = MainForm.GetMigrateTargetCombo();

            if (migrateTargetCombo.Items.Count <= 0)
            {
                FillMigrationComboOptions(migrateTargetCombo, defaultIgnoreToMigrationItems, true);

                //Making sure we have at least 1 simulator to migrate to, else we exit the program.
                if (migrateTargetCombo.Items.Count == 0)
                {
                    MessageBox.Show("The program could not identify any simulators to migrate to on this computer.\nThe application will now exit.");
                    Application.Exit();
                }

                //We don't need to return because we want to check if we need to remove un-needed options from the "from" combo box.
            }

            int ignoreID = 0;
            int currentMigrateFromSelectedValue = GetSelectedItemValue(migrateSourceCombo);

            if (migrateTargetCombo.SelectedIndex >= 0)
            {
                SimulatorOption selectedItem = GetSelectedItem(migrateTargetCombo);

                foreach (SimulatorOption migrateFromComboItem in migrateSourceCombo.Items)
                {
                    if (selectedItem.Equals(migrateFromComboItem))
                    {
                        ignoreID = selectedItem.GetValue();
                    }
                }
            }

            if (ignoreID > 0)
            {
                int defaultLength = defaultIgnoreFromMigrationItems.Length;

                int[] ignoreIDs = new int[defaultLength + 1];
                defaultIgnoreFromMigrationItems.CopyTo(ignoreIDs, 0);
                ignoreIDs[defaultLength] = ignoreID;

                FillMigrationComboOptions(migrateSourceCombo, ignoreIDs, false);
            }
            else
            {
                FillMigrationComboOptions(migrateSourceCombo, defaultIgnoreFromMigrationItems, false);
            }

            if (SettingsHandler.GetSetting("migrationTarget").Equals("") && migrateTargetCombo.SelectedIndex >= 0 && !defaultTargetChosen)
            {
                SelectItemByVal(migrateTargetCombo, defaultMigrateTo);
                defaultTargetChosen = true;
            }

            SelectItemByVal(migrateSourceCombo, currentMigrateFromSelectedValue);
        }
    }
}
