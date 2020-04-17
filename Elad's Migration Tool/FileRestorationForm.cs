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

        protected void closeButton_Click(object sender, EventArgs e)
        {
            MainForm.destroyFileRestorationInstance();
            this.Close();
        }

        private void FileRestoration_Load(object sender, EventArgs e)
        {
            staticRestoreDatesCombo = restoreDatesCombo;
            staticRestoreButton = restoreButton;

            FileRestorationFormHandler.onLoadHandler();
        }

        public static ComboBox getRestoreDatesCombo()
        {
            return staticRestoreDatesCombo;
        }

        public static Button getRestoreButton()
        {
            return staticRestoreButton;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainForm.destroyFileRestorationInstance();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (restoreDatesCombo.Items.Count > 0)
            {
                if (FileRestorationFormHandler.restoreFiles(restoreDatesCombo.Text))
                {
                    MessageBox.Show("The config files have been successfully restored.");
                    MainForm.destroyFileRestorationInstance();
                    this.Close();
                }
            }
        }
    }
}