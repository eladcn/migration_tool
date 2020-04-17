using System;
using System.Windows.Forms;
using Elad_s_Migration_Tool.MigrationFormsFunctions;

namespace Elad_s_Migration_Tool
{
    public partial class MainForm : Form
    {
        protected static ComboBox staticSourceMigrationCombo;
        protected static ComboBox staticTargetMigrationCombo;
        protected static Button staticStartMigrationButton;

        protected static SettingsForm settingsForm;
        protected static FileRestorationForm fileRestorationForm;

        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * Handles the form load functions.
         */
        private void MainForm_Load(object sender, EventArgs e)
        {
            staticSourceMigrationCombo = MigrateSourceCombo;
            staticTargetMigrationCombo = MigrateTargetCombo;
            staticStartMigrationButton = StartMigrationButton;

            MainFormHandler.OnLoadHandler();
        }

        /**
         * Handles pressing on the exit button in the menu strip.
         */
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainFormHandler.ExitHandler();
        }

        /**
         * Handles closing the form (via the X button).
         */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainFormHandler.ExitHandler();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        /**
         * Returns the migrate source combo object.
         */
        public static ComboBox GetMigrateSourceCombo()
        {
            return staticSourceMigrationCombo;
        }

        /**
         * Returns the migrate target combo object.
         */
        public static ComboBox GetMigrateTargetCombo()
        {
            return staticTargetMigrationCombo;
        }

        /**
         * Returns the start migrate button object.
         */
        public static Button GetStartMigrateButton()
        {
            return staticStartMigrationButton;
        }

        /**
         * Handles change of the migrateSourceCombo.
         */
        protected void MigrateSourceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainFormHandler.SourceMigrationChangeHandler();
        }

        /**
         * Handles change of the migrateTargetCombo.
         */
        protected void MigrateTargetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainFormHandler.TargetMigrationChangeHandler();
        }

        /**
         * Handles click of the startMigrationButton.
         */
        private void StartMigrationButton_Click(object sender, EventArgs e)
        {
            MainFormHandler.StartMigrationHandler();
        }

        /**
         * Handles click of the About button in the menu strip.
         */
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was created by Elad Cohen.\nI hope you enjoy the program and if you have any problems or questions, please send me an email to:\neladcn92@gmail.com");
        }

        /**
         * Handles click of the how to use button in the menu strip.
         */
        private void HowToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please follow the following steps:\n" +
                            "1. Select the simulator that the add-ons are applicable to - you don't need to have this simulator installed!\n" +
                            "2. Select the simulator you would like to install the add-ons to.\n" +
                            "3. Press on \"Start Migration\".\n" +
                            "4. Install your add-ons and if required in the installation process - choose the simulator which the add-ons are applicable to (for example FSX if you want to migrate from FSX to Prepar3D).\n" +
                            "5. When done installing your add-ons, press on \"Stop Migration\".");
        }

        /**
         * Destroys the settings form instance.
         */
        public static void DestroySettingsFormInstance()
        {
            settingsForm = null;
        }

        /**
         * Destroys the file restoration form instance.
         */
        public static void DestroyFileRestorationInstance()
        {
            fileRestorationForm = null;
        }

        /**
         * Handles click of the settings button in the menu strip.
         */
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm();
                settingsForm.Show();
            }
        }

        /**
         * Handles click of the restore configuration files button in the menu strip.
         */
        private void RestoreConfigFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileRestorationForm == null)
            {
                fileRestorationForm = new FileRestorationForm();
                fileRestorationForm.Show();
            }
        }

        /**
         * Handles click of the disclaimer button in the menu strip.
         */
        private void DisclaimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's highly recommended that you create a System Restore point before using this program." +
                            "\nI will not be responsible for any damage this program may do to your simulator or to your operating system." +
                            "\nPlease refer to the ReadMe.txt file for more information.");
        }
    }
}
