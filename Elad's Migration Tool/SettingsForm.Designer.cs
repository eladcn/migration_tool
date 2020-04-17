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
            this.WindowsStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.AutoStartCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.UltimateTraffic2Checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // WindowsStartupCheckbox
            // 
            this.WindowsStartupCheckbox.AutoSize = true;
            this.WindowsStartupCheckbox.Enabled = false;
            this.WindowsStartupCheckbox.Location = new System.Drawing.Point(9, 10);
            this.WindowsStartupCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WindowsStartupCheckbox.Name = "WindowsStartupCheckbox";
            this.WindowsStartupCheckbox.Size = new System.Drawing.Size(262, 17);
            this.WindowsStartupCheckbox.TabIndex = 0;
            this.WindowsStartupCheckbox.Text = "Load on Windows startup - currently not available.";
            this.WindowsStartupCheckbox.UseVisualStyleBackColor = true;
            this.WindowsStartupCheckbox.CheckedChanged += new System.EventHandler(this.WindowsStartupCheckbox_CheckedChanged);
            // 
            // AutoStartCheckbox
            // 
            this.AutoStartCheckbox.AutoSize = true;
            this.AutoStartCheckbox.Location = new System.Drawing.Point(9, 32);
            this.AutoStartCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoStartCheckbox.Name = "AutoStartCheckbox";
            this.AutoStartCheckbox.Size = new System.Drawing.Size(250, 17);
            this.AutoStartCheckbox.TabIndex = 1;
            this.AutoStartCheckbox.Text = "Automatically start migrating on program startup.";
            this.AutoStartCheckbox.UseVisualStyleBackColor = true;
            this.AutoStartCheckbox.CheckedChanged += new System.EventHandler(this.AutoStartCheckbox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(93, 76);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 32);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // UltimateTraffic2Checkbox
            // 
            this.UltimateTraffic2Checkbox.AutoSize = true;
            this.UltimateTraffic2Checkbox.Location = new System.Drawing.Point(9, 54);
            this.UltimateTraffic2Checkbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UltimateTraffic2Checkbox.Name = "UltimateTraffic2Checkbox";
            this.UltimateTraffic2Checkbox.Size = new System.Drawing.Size(183, 17);
            this.UltimateTraffic2Checkbox.TabIndex = 3;
            this.UltimateTraffic2Checkbox.Text = "Allow Ultimate Traffic 2 Migration.";
            this.UltimateTraffic2Checkbox.UseVisualStyleBackColor = true;
            this.UltimateTraffic2Checkbox.CheckedChanged += new System.EventHandler(this.UltimateTraffic2Checkbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 116);
            this.Controls.Add(this.UltimateTraffic2Checkbox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AutoStartCheckbox);
            this.Controls.Add(this.WindowsStartupCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox WindowsStartupCheckbox;
        private System.Windows.Forms.CheckBox AutoStartCheckbox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox UltimateTraffic2Checkbox;
    }
}