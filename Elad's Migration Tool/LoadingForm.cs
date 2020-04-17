using System;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool
{
    public partial class LoadingForm : Form
    {
        protected bool closeEnabled = false;

        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!closeEnabled)
            {
                return;
            }
            
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        public void closeForm()
        {
            closeEnabled = true;
            this.Close();
        }
    }
}
