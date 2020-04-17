using Elad_s_Migration_Tool.MigrationFormsFunctions;
using System;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool
{
    public partial class FileRestorationForm : Form
    {
        protected static ComboBox staticRestoreDatesCombo;
        protected static Button staticRestoreButton;

        public FileRestorationForm()
        {
            InitializeComponent();
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            MainForm.DestroyFileRestorationInstance();
            this.Close();
        }

        private void FileRestoration_Load(object sender, EventArgs e)
        {
            staticRestoreDatesCombo = RestoreDatesCombo;
            staticRestoreButton = RestoreButton;

            FileRestorationFormHandler.OnLoadHandler();
        }

        public static ComboBox GetRestoreDatesCombo()
        {
            return staticRestoreDatesCombo;
        }

        public static Button GetRestoreButton()
        {
            return staticRestoreButton;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainForm.DestroyFileRestorationInstance();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (RestoreDatesCombo.Items.Count > 0)
            {
                if (FileRestorationFormHandler.RestoreFiles(RestoreDatesCombo.Text))
                {
                    MessageBox.Show("The config files have been successfully restored.");
                    MainForm.DestroyFileRestorationInstance();
                    this.Close();
                }
            }
        }
    }
}