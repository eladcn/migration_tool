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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreConfigFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixSceneryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateFromLabel = new System.Windows.Forms.Label();
            this.migrateSourceCombo = new System.Windows.Forms.ComboBox();
            this.migrateTargetCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startMigrationButton = new System.Windows.Forms.Button();
            this.migrationNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.migrationMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // migrationMenuStrip
            // 
            this.migrationMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.migrationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.migrationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.migrationMenuStrip.Name = "migrationMenuStrip";
            this.migrationMenuStrip.Size = new System.Drawing.Size(419, 28);
            this.migrationMenuStrip.TabIndex = 0;
            this.migrationMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.restoreConfigFilesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // restoreConfigFilesToolStripMenuItem
            // 
            this.restoreConfigFilesToolStripMenuItem.Name = "restoreConfigFilesToolStripMenuItem";
            this.restoreConfigFilesToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.restoreConfigFilesToolStripMenuItem.Text = "Restore Config Files";
            this.restoreConfigFilesToolStripMenuItem.Click += new System.EventHandler(this.restoreConfigFilesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixSceneryToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // fixSceneryToolStripMenuItem
            // 
            this.fixSceneryToolStripMenuItem.Name = "fixSceneryToolStripMenuItem";
            this.fixSceneryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.fixSceneryToolStripMenuItem.Text = "Fix Scenery";
            this.fixSceneryToolStripMenuItem.Click += new System.EventHandler(this.fixSceneryToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.howToUseToolStripMenuItem,
            this.disclaimerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.howToUseToolStripMenuItem.Text = "How to use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // disclaimerToolStripMenuItem
            // 
            this.disclaimerToolStripMenuItem.Name = "disclaimerToolStripMenuItem";
            this.disclaimerToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.disclaimerToolStripMenuItem.Text = "Disclaimer";
            this.disclaimerToolStripMenuItem.Click += new System.EventHandler(this.disclaimerToolStripMenuItem_Click);
            // 
            // migrateFromLabel
            // 
            this.migrateFromLabel.AutoSize = true;
            this.migrateFromLabel.Location = new System.Drawing.Point(12, 41);
            this.migrateFromLabel.Name = "migrateFromLabel";
            this.migrateFromLabel.Size = new System.Drawing.Size(202, 17);
            this.migrateFromLabel.TabIndex = 1;
            this.migrateFromLabel.Text = "The add-ons are applicable to:";
            // 
            // migrateSourceCombo
            // 
            this.migrateSourceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.migrateSourceCombo.FormattingEnabled = true;
            this.migrateSourceCombo.Location = new System.Drawing.Point(15, 61);
            this.migrateSourceCombo.Name = "migrateSourceCombo";
            this.migrateSourceCombo.Size = new System.Drawing.Size(199, 24);
            this.migrateSourceCombo.TabIndex = 2;
            this.migrateSourceCombo.SelectedIndexChanged += new System.EventHandler(this.migrateSourceCombo_SelectedIndexChanged);
            // 
            // migrateTargetCombo
            // 
            this.migrateTargetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.migrateTargetCombo.FormattingEnabled = true;
            this.migrateTargetCombo.Location = new System.Drawing.Point(15, 108);
            this.migrateTargetCombo.Name = "migrateTargetCombo";
            this.migrateTargetCombo.Size = new System.Drawing.Size(199, 24);
            this.migrateTargetCombo.TabIndex = 4;
            this.migrateTargetCombo.SelectedIndexChanged += new System.EventHandler(this.migrateTargetCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "I would like to install them to:";
            // 
            // startMigrationButton
            // 
            this.startMigrationButton.Location = new System.Drawing.Point(220, 61);
            this.startMigrationButton.Name = "startMigrationButton";
            this.startMigrationButton.Size = new System.Drawing.Size(187, 71);
            this.startMigrationButton.TabIndex = 5;
            this.startMigrationButton.Text = "Start Migration";
            this.startMigrationButton.UseVisualStyleBackColor = true;
            this.startMigrationButton.Click += new System.EventHandler(this.startMigrationButton_Click);
            // 
            // migrationNotifyIcon
            // 
            this.migrationNotifyIcon.Text = "Elad\'s Migration Tool";
            this.migrationNotifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 147);
            this.Controls.Add(this.startMigrationButton);
            this.Controls.Add(this.migrateTargetCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.migrateSourceCombo);
            this.Controls.Add(this.migrateFromLabel);
            this.Controls.Add(this.migrationMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.migrationMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Elad\'s Migration Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.migrationMenuStrip.ResumeLayout(false);
            this.migrationMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip migrationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label migrateFromLabel;
        private System.Windows.Forms.ComboBox migrateSourceCombo;
        private System.Windows.Forms.ComboBox migrateTargetCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button startMigrationButton;
        private System.Windows.Forms.NotifyIcon migrationNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreConfigFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disclaimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixSceneryToolStripMenuItem;
    }
}

