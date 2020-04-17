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
            this.RestoreDatesCombo = new System.Windows.Forms.ComboBox();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.AutoSize = true;
            this.descriptionLabel1.Location = new System.Drawing.Point(9, 7);
            this.descriptionLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(330, 13);
            this.descriptionLabel1.TabIndex = 0;
            this.descriptionLabel1.Text = "If anything wrong happened in the process and the simulator\'s config";
            // 
            // descriptionLabel2
            // 
            this.descriptionLabel2.AutoSize = true;
            this.descriptionLabel2.Location = new System.Drawing.Point(9, 21);
            this.descriptionLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionLabel2.Name = "descriptionLabel2";
            this.descriptionLabel2.Size = new System.Drawing.Size(348, 13);
            this.descriptionLabel2.TabIndex = 1;
            this.descriptionLabel2.Text = "files were damaged, it is possible to restore the config files using this tool.";
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.AutoSize = true;
            this.descriptionLabel3.Location = new System.Drawing.Point(9, 35);
            this.descriptionLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(340, 13);
            this.descriptionLabel3.TabIndex = 2;
            this.descriptionLabel3.Text = "Please select the date you would like to restore from and hit \"Restore\".";
            // 
            // RestoreDatesCombo
            // 
            this.RestoreDatesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RestoreDatesCombo.FormattingEnabled = true;
            this.RestoreDatesCombo.Location = new System.Drawing.Point(11, 63);
            this.RestoreDatesCombo.Margin = new System.Windows.Forms.Padding(2);
            this.RestoreDatesCombo.Name = "RestoreDatesCombo";
            this.RestoreDatesCombo.Size = new System.Drawing.Size(199, 21);
            this.RestoreDatesCombo.TabIndex = 3;
            // 
            // RestoreButton
            // 
            this.RestoreButton.Enabled = false;
            this.RestoreButton.Location = new System.Drawing.Point(11, 88);
            this.RestoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(199, 20);
            this.RestoreButton.TabIndex = 4;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(262, 72);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(92, 35);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FileRestorationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 113);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.RestoreDatesCombo);
            this.Controls.Add(this.descriptionLabel3);
            this.Controls.Add(this.descriptionLabel2);
            this.Controls.Add(this.descriptionLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ComboBox RestoreDatesCombo;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button CloseButton;
    }
}