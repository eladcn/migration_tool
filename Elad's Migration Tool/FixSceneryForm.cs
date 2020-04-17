using Elad_s_Migration_Tool.MigrationFormsFunctions;
using System;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool
{
    public partial class FixSceneryForm : Form
    {
        public FixSceneryForm()
        {
            InitializeComponent();
        }

        private void FixSceneryForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            MainForm.destroyFixSceneryFormInstance();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            MainForm.destroyFixSceneryFormInstance();
            this.Close();
        }

        private void fixSceneryButton_Click(object sender, EventArgs e)
        {
            FixSceneryHandler.runFixScenery();
        }
    }
}
