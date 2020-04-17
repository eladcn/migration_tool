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
        public static void onLoadHandler()
        {
            windowsStartupCheckbox = SettingsForm.getWindowsStartupCheckbox();
            autoStartCheckbox = SettingsForm.getAutoStartCheckbox();
            ultimateTraffic2Checkbox = SettingsForm.getUltimateTraffic2Checkbox();

            setIgnoreWindowsStartupChange(true);
            setIgnoreAutoStartChange(true);
            setIgnoreUltimateTraffic2Change(true);

            string windowsStartup = SettingsHandler.getSetting("windowsStartup");
            string autoStart = SettingsHandler.getSetting("autoStart");
            string ultimateTraffic2 = SettingsHandler.getSetting("ultimateTraffic2");

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

            setIgnoreWindowsStartupChange(false);
            setIgnoreAutoStartChange(false);
            setIgnoreUltimateTraffic2Change(false);
        }

        /**
         * Handles the windows startup checkbox change event.
         */
        public static void onWindowsStartupCheckboxChange()
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
        public static void onAutoStartCheckboxChange()
        {
            if (!ignoreAutoStartChange)
            {
                if (autoStartCheckbox.Checked)
                {
                    SettingsHandler.setSetting("autoStart", "1");
                }
                else
                {
                    SettingsHandler.setSetting("autoStart", "0");
                }
            }
        }

        /**
         * Handles the Ultimate Traffic 2 checkbox change event
         */
        public static void onUltimateTraffic2CheckboxChange()
        {
            if (!ignoreUltimateTraffic2Change)
            {
                if (ultimateTraffic2Checkbox.Checked)
                {
                    SettingsHandler.setSetting("ultimateTraffic2", "1");
                }
                else
                {
                    SettingsHandler.setSetting("ultimateTraffic2", "0");
                }
            }
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void setIgnoreWindowsStartupChange(bool ignore)
        {
            ignoreWindowsStartupChange = ignore;
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void setIgnoreAutoStartChange(bool ignore)
        {
            ignoreAutoStartChange = ignore;
        }

        /**
         * Sets whether should we ignore the on change event of the checkbox.
         */
        public static void setIgnoreUltimateTraffic2Change(bool ignore)
        {
            ignoreUltimateTraffic2Change = ignore;
        }
    }
}