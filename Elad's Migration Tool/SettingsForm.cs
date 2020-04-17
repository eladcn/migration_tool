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
            staticWindowsStartupCheckbox = WindowsStartupCheckbox;
            staticAutoStartCheckbox = AutoStartCheckbox;
            staticUltimateTraffic2Checkbox = UltimateTraffic2Checkbox;

            SettingsFormHandler.OnLoadHandler();
        }

        /**
         * Returns the windows startup checkbox object.
         */
        public static CheckBox GetWindowsStartupCheckbox()
        {
            return staticWindowsStartupCheckbox;
        }

        /**
         * Returns the auto start checkbox.
         */
        public static CheckBox GetAutoStartCheckbox()
        {
            return staticAutoStartCheckbox;
        }

        /**
         * Returns the Ultimate Traffic 2 checkbox.
         */
        public static CheckBox GetUltimateTraffic2Checkbox()
        {
            return staticUltimateTraffic2Checkbox;
        }

        private void WindowsStartupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.OnWindowsStartupCheckboxChange();
        }

        private void AutoStartCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.OnAutoStartCheckboxChange();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            MainForm.DestroySettingsFormInstance();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainForm.DestroySettingsFormInstance();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void UltimateTraffic2Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsFormHandler.OnUltimateTraffic2CheckboxChange();
        }
    }
}
