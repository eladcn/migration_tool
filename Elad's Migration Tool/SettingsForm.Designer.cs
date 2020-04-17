namespace Elad_s_Migration_Tool
{
    partial class SettingsForm
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
            this.windowsStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.autoStartCheckbox = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.ultimateTraffic2Checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // windowsStartupCheckbox
            // 
            this.windowsStartupCheckbox.AutoSize = true;
            this.windowsStartupCheckbox.Enabled = false;
            this.windowsStartupCheckbox.Location = new System.Drawing.Point(12, 12);
            this.windowsStartupCheckbox.Name = "windowsStartupCheckbox";
            this.windowsStartupCheckbox.Size = new System.Drawing.Size(346, 21);
            this.windowsStartupCheckbox.TabIndex = 0;
            this.windowsStartupCheckbox.Text = "Load on Windows startup - currently not available.";
            this.windowsStartupCheckbox.UseVisualStyleBackColor = true;
            this.windowsStartupCheckbox.CheckedChanged += new System.EventHandler(this.windowsStartupCheckbox_CheckedChanged);
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.Location = new System.Drawing.Point(12, 39);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(336, 21);
            this.autoStartCheckbox.TabIndex = 1;
            this.autoStartCheckbox.Text = "Automatically start migrating on program startup.";
            this.autoStartCheckbox.UseVisualStyleBackColor = true;
            this.autoStartCheckbox.CheckedChanged += new System.EventHandler(this.autoStartCheckbox_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(124, 93);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(106, 39);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ultimateTraffic2Checkbox
            // 
            this.ultimateTraffic2Checkbox.AutoSize = true;
            this.ultimateTraffic2Checkbox.Location = new System.Drawing.Point(12, 66);
            this.ultimateTraffic2Checkbox.Name = "ultimateTraffic2Checkbox";
            this.ultimateTraffic2Checkbox.Size = new System.Drawing.Size(239, 21);
            this.ultimateTraffic2Checkbox.TabIndex = 3;
            this.ultimateTraffic2Checkbox.Text = "Allow Ultimate Traffic 2 Migration.";
            this.ultimateTraffic2Checkbox.UseVisualStyleBackColor = true;
            this.ultimateTraffic2Checkbox.CheckedChanged += new System.EventHandler(this.ultimateTraffic2Checkbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 143);
            this.Controls.Add(this.ultimateTraffic2Checkbox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.autoStartCheckbox);
            this.Controls.Add(this.windowsStartupCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox windowsStartupCheckbox;
        private System.Windows.Forms.CheckBox autoStartCheckbox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox ultimateTraffic2Checkbox;
    }
}