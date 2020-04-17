using Elad_s_Migration_Tool.General;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class SettingsFormHandler
    {
        protected static bool ignoreWindowsStartupChange;
        protected static bool ignoreAutoStartChange;
        protected static bool ignoreUltimateTraffic2Change;
        protected static CheckBox windowsStartupCheckbox;
        protected static CheckBox autoStartCheckbox;
        protected static CheckBox ultimateTraffic2Checkbox;

        /**
         * Handles the onLoad of the settings form.
         */
        public static void OnLoadHandler()
        {
            windowsStartupCheckbox = SettingsForm.GetWindowsStartupCheckbox();
            autoStartCheckbox = SettingsForm.GetAutoStartCheckbox();
            ultimateTraffic2Checkbox = SettingsForm.GetUltimateTraffic2Checkbox();

            SetIgnoreWindowsStartupChange(true);
            SetIgnoreAutoStartChange(true);
            SetIgnoreUltimateTraffic2Change(true);

            string windowsStartup = SettingsHandler.GetSetting("windowsStartup");
            string autoStart = SettingsHandler.GetSetting("autoStart");
            string ultimateTraffic2 = SettingsHandler.GetSetting("ultimateTraffic2");

            if (windowsStartup.Equals("1"))
            {
                windowsStartupCheckbox.Checked = true;
            }

            if (autoStart.Equals("1"))
            {
                autoStartCheckbox.Checked = true;
            }

            if (ultimateTraffic2.Equals("1"))
            {
                ultimateTraffic2Checkbox.Checked = true;
            }

            SetIgnoreWindowsStartupChange(false);
            SetIgnoreAutoStartChange(false);
            SetIgnoreUltimateTraffic2Change(false);
        }

        /**
         * Handles the windows startup checkbox change event.
         */
        public static void OnWindowsStartupCheckboxChange()
        {
            //@todo CHECK IF WE SHOULD ADD THIS OPTION OR NOT
            if (!ignoreWindowsStartupChange)
            {
                if (windowsStartupCheckbox.Checked)
                {
                    //SettingsHandler.setSetting("windowsStartup", "1");
                }
                else
                {
                    //SettingsHandler.setSetting("windowsStartup", "0");
                }
            }
        }

        /**
         * Handles the auto start checkbox change event.
         */
        public static void OnAutoStartCheckboxChange()
        {
            if (!ignoreAutoStartChange)
            {
                if (autoStartCheckbox.Checked)
                {
                    SettingsHandler.SetSetting("autoStart", "1");
                }
                else
                {
                    SettingsHandler.SetSetting("autoStart", "0");
                }
            }
        }

        /**
         * Handles the Ultimate Traffic 2 checkbox change event
         */
        public static void OnUltimateTraffic2CheckboxChange()
        {
            if (!ignoreUltimateTraffic2Change)
            {
                if (ultimateTraffic2Checkbox.Checked)
                {
                    SettingsHandler.SetSetting("ultimateTraffic2", "1");
                }
                else
                {
                    SettingsHandler.SetSetting("ultimateTraffic2", "0");
                }
            }
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void SetIgnoreWindowsStartupChange(bool ignore)
        {
            ignoreWindowsStartupChange = ignore;
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void SetIgnoreAutoStartChange(bool ignore)
        {
            ignoreAutoStartChange = ignore;
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void SetIgnoreUltimateTraffic2Change(bool ignore)
        {
            ignoreUltimateTraffic2Change = ignore;
        }
    }
}
