namespace Elad_s_Migration_Tool
{
    partial class FileRestorationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel2 = new System.Windows.Forms.Label();
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.restoreDatesCombo = new System.Windows.Forms.ComboBox();
            this.restoreButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.AutoSize = true;
            this.descriptionLabel1.Location = new System.Drawing.Point(12, 9);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(441, 17);
            this.descriptionLabel1.TabIndex = 0;
            this.descriptionLabel1.Text = "If anything wrong happened in the process and the simulator\'s config";
            // 
            // descriptionLabel2
            // 
            this.descriptionLabel2.AutoSize = true;
            this.descriptionLabel2.Location = new System.Drawing.Point(12, 26);
            this.descriptionLabel2.Name = "descriptionLabel2";
            this.descriptionLabel2.Size = new System.Drawing.Size(470, 17);
            this.descriptionLabel2.TabIndex = 1;
            this.descriptionLabel2.Text = "files were damaged, it is possible to restore the config files using this tool.";
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.AutoSize = true;
            this.descriptionLabel3.Location = new System.Drawing.Point(12, 43);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(452, 17);
            this.descriptionLabel3.TabIndex = 2;
            this.descriptionLabel3.Text = "Please select the date you would like to restore from and hit \"Restore\".";
            // 
            // restoreDatesCombo
            // 
            this.restoreDatesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.restoreDatesCombo.FormattingEnabled = true;
            this.restoreDatesCombo.Location = new System.Drawing.Point(15, 78);
            this.restoreDatesCombo.Name = "restoreDatesCombo";
            this.restoreDatesCombo.Size = new System.Drawing.Size(264, 24);
            this.restoreDatesCombo.TabIndex = 3;
            // 
            // restoreButton
            // 
            this.restoreButton.Enabled = false;
            this.restoreButton.Location = new System.Drawing.Point(15, 108);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(264, 24);
            this.restoreButton.TabIndex = 4;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(349, 89);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(122, 43);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FileRestorationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 139);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(this.restoreDatesCombo);
            this.Controls.Add(this.descriptionLabel3);
            this.Controls.Add(this.descriptionLabel2);
            this.Controls.Add(this.descriptionLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FileRestorationForm";
            this.Text = "Restore Config Files";
            this.Load += new System.EventHandler(this.FileRestoration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label descriptionLabel2;
        private System.Windows.Forms.Label descriptionLabel3;
        private System.Windows.Forms.ComboBox restoreDatesCombo;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button closeButton;
    }
}