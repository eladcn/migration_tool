namespace Elad_s_Migration_Tool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.migrationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreConfigFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HowToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateFromLabel = new System.Windows.Forms.Label();
            this.MigrateSourceCombo = new System.Windows.Forms.ComboBox();
            this.MigrateTargetCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartMigrationButton = new System.Windows.Forms.Button();
            this.migrationNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.migrationMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // migrationMenuStrip
            // 
            this.migrationMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.migrationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.migrationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.migrationMenuStrip.Name = "migrationMenuStrip";
            this.migrationMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.migrationMenuStrip.Size = new System.Drawing.Size(314, 24);
            this.migrationMenuStrip.TabIndex = 0;
            this.migrationMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.RestoreConfigFilesToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // RestoreConfigFilesToolStripMenuItem
            // 
            this.RestoreConfigFilesToolStripMenuItem.Name = "RestoreConfigFilesToolStripMenuItem";
            this.RestoreConfigFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RestoreConfigFilesToolStripMenuItem.Text = "Restore Config Files";
            this.RestoreConfigFilesToolStripMenuItem.Click += new System.EventHandler(this.RestoreConfigFilesToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.HowToUseToolStripMenuItem,
            this.DisclaimerToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // HowToUseToolStripMenuItem
            // 
            this.HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem";
            this.HowToUseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HowToUseToolStripMenuItem.Text = "How to use";
            this.HowToUseToolStripMenuItem.Click += new System.EventHandler(this.HowToUseToolStripMenuItem_Click);
            // 
            // DisclaimerToolStripMenuItem
            // 
            this.DisclaimerToolStripMenuItem.Name = "DisclaimerToolStripMenuItem";
            this.DisclaimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DisclaimerToolStripMenuItem.Text = "Disclaimer";
            this.DisclaimerToolStripMenuItem.Click += new System.EventHandler(this.DisclaimerToolStripMenuItem_Click);
            // 
            // migrateFromLabel
            // 
            this.migrateFromLabel.AutoSize = true;
            this.migrateFromLabel.Location = new System.Drawing.Point(9, 33);
            this.migrateFromLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.migrateFromLabel.Name = "migrateFromLabel";
            this.migrateFromLabel.Size = new System.Drawing.Size(151, 13);
            this.migrateFromLabel.TabIndex = 1;
            this.migrateFromLabel.Text = "The add-ons are applicable to:";
            // 
            // MigrateSourceCombo
            // 
            this.MigrateSourceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MigrateSourceCombo.FormattingEnabled = true;
            this.MigrateSourceCombo.Location = new System.Drawing.Point(11, 50);
            this.MigrateSourceCombo.Margin = new System.Windows.Forms.Padding(2);
            this.MigrateSourceCombo.Name = "MigrateSourceCombo";
            this.MigrateSourceCombo.Size = new System.Drawing.Size(150, 21);
            this.MigrateSourceCombo.TabIndex = 2;
            this.MigrateSourceCombo.SelectedIndexChanged += new System.EventHandler(this.MigrateSourceCombo_SelectedIndexChanged);
            // 
            // MigrateTargetCombo
            // 
            this.MigrateTargetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MigrateTargetCombo.FormattingEnabled = true;
            this.MigrateTargetCombo.Location = new System.Drawing.Point(11, 88);
            this.MigrateTargetCombo.Margin = new System.Windows.Forms.Padding(2);
            this.MigrateTargetCombo.Name = "MigrateTargetCombo";
            this.MigrateTargetCombo.Size = new System.Drawing.Size(150, 21);
            this.MigrateTargetCombo.TabIndex = 4;
            this.MigrateTargetCombo.SelectedIndexChanged += new System.EventHandler(this.MigrateTargetCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "I would like to install them to:";
            // 
            // StartMigrationButton
            // 
            this.StartMigrationButton.Location = new System.Drawing.Point(165, 50);
            this.StartMigrationButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartMigrationButton.Name = "StartMigrationButton";
            this.StartMigrationButton.Size = new System.Drawing.Size(140, 58);
            this.StartMigrationButton.TabIndex = 5;
            this.StartMigrationButton.Text = "Start Migration";
            this.StartMigrationButton.UseVisualStyleBackColor = true;
            this.StartMigrationButton.Click += new System.EventHandler(this.StartMigrationButton_Click);
            // 
            // migrationNotifyIcon
            // 
            this.migrationNotifyIcon.Text = "Elad\'s Migration Tool";
            this.migrationNotifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 119);
            this.Controls.Add(this.StartMigrationButton);
            this.Controls.Add(this.MigrateTargetCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MigrateSourceCombo);
            this.Controls.Add(this.migrateFromLabel);
            this.Controls.Add(this.migrationMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.migrationMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Elad\'s Migration Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.migrationMenuStrip.ResumeLayout(false);
            this.migrationMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip migrationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Label migrateFromLabel;
        private System.Windows.Forms.ComboBox MigrateSourceCombo;
        private System.Windows.Forms.ComboBox MigrateTargetCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Button StartMigrationButton;
        private System.Windows.Forms.NotifyIcon migrationNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HowToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreConfigFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisclaimerToolStripMenuItem;
    }
}

