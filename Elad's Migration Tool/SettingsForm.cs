using Elad_s_Migration_Tool.MigrationFormsFunctions;
using System;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool
{
    public partial class SettingsForm : Form
    {
        protected static CheckBox staticWindowsStartupCheckbox;
        protected static CheckBox staticAutoStartCheckbox;
        protected static CheckBox staticUltimateTraffic2Checkbox;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            staticWindowsStartupCheckbox = windowsStartupCheckbox;
            staticAutoStartCheckbox = autoStartCheckbox;
            staticUltimateTraffic2Checkbox = ultimateTraffic2Checkbox;

            SettingsFormHandler.onLoadHandler();
        }

        /**
         * Returns the windows startup checkbox object.
         */
        public static CheckBox getWindowsStartupCheckbox()
        {
            return staticWindowsStartupCheckbox;
        }

        /**
         * Returns the auto start checkbox.
         */
        public static CheckBox getAutoStartCheckbox()
        {
            return staticAutoStartCheckbox;
        }

        /**
         * Returns the Ultimate Traffic 2 checkbox.
         */
        public static CheckBox getUltimateTraffic2Checkbox()
        {
            return staticUltimateTraffic2Checkbox;
        }

        private void windowsStartupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.onWindowsStartupCheckboxChange();
        }

        private void autoStartCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.onAutoStartCheckboxChange();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            MainForm.destroySettingsFormInstance();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainForm.destroySettingsFormInstance();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void ultimateTraffic2Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.onUltimateTraffic2CheckboxChange();
        }
    }
}
