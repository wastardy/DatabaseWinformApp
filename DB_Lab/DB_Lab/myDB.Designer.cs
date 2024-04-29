namespace DB_Lab
{
    partial class myDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myDB));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dBTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableExpert = new System.Windows.Forms.ToolStripMenuItem();
            this.TableExploration = new System.Windows.Forms.ToolStripMenuItem();
            this.TableGemstone = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLaboratory = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUsersPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUsersAccessTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBTablesToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.calculatorToolStripMenuItem,
            this.aboutProgramToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dBTablesToolStripMenuItem
            // 
            this.dBTablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TableExpert,
            this.TableExploration,
            this.TableGemstone,
            this.TableLaboratory});
            this.dBTablesToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dBTablesToolStripMenuItem.Name = "dBTablesToolStripMenuItem";
            this.dBTablesToolStripMenuItem.Size = new System.Drawing.Size(118, 27);
            this.dBTablesToolStripMenuItem.Text = "DB Tables";
            // 
            // TableExpert
            // 
            this.TableExpert.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableExpert.Image = global::DB_Lab.Properties.Resources.scientist;
            this.TableExpert.Name = "TableExpert";
            this.TableExpert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.TableExpert.Size = new System.Drawing.Size(268, 28);
            this.TableExpert.Text = "Expert";
            this.TableExpert.Click += new System.EventHandler(this.TableExpert_Click);
            // 
            // TableExploration
            // 
            this.TableExploration.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableExploration.Image = global::DB_Lab.Properties.Resources.explore;
            this.TableExploration.Name = "TableExploration";
            this.TableExploration.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.TableExploration.Size = new System.Drawing.Size(268, 28);
            this.TableExploration.Text = "Exploration";
            this.TableExploration.Click += new System.EventHandler(this.TableExploration_Click);
            // 
            // TableGemstone
            // 
            this.TableGemstone.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableGemstone.Image = global::DB_Lab.Properties.Resources.gem;
            this.TableGemstone.Name = "TableGemstone";
            this.TableGemstone.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.TableGemstone.Size = new System.Drawing.Size(268, 28);
            this.TableGemstone.Text = "Gemstone";
            this.TableGemstone.Click += new System.EventHandler(this.TableGemstone_Click);
            // 
            // TableLaboratory
            // 
            this.TableLaboratory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableLaboratory.Image = global::DB_Lab.Properties.Resources.lab_microscope;
            this.TableLaboratory.Name = "TableLaboratory";
            this.TableLaboratory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.TableLaboratory.Size = new System.Drawing.Size(268, 28);
            this.TableLaboratory.Text = "Laboratory";
            this.TableLaboratory.Click += new System.EventHandler(this.TableLaboratory_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.removeUserToolStripMenuItem,
            this.changeUsersPasswordToolStripMenuItem,
            this.changeUsersAccessTypeToolStripMenuItem,
            this.toolStripSeparator1,
            this.databaseBackupToolStripMenuItem,
            this.backupDatabaseRecoveryToolStripMenuItem});
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(160, 27);
            this.adminToolStripMenuItem.Text = "Administration";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addUserToolStripMenuItem.Image")));
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.addUserToolStripMenuItem.Text = "Add user";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeUserToolStripMenuItem.Image")));
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.removeUserToolStripMenuItem.Text = "Delete user";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // changeUsersPasswordToolStripMenuItem
            // 
            this.changeUsersPasswordToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeUsersPasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeUsersPasswordToolStripMenuItem.Image")));
            this.changeUsersPasswordToolStripMenuItem.Name = "changeUsersPasswordToolStripMenuItem";
            this.changeUsersPasswordToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.changeUsersPasswordToolStripMenuItem.Text = "Change user\'s password";
            this.changeUsersPasswordToolStripMenuItem.Click += new System.EventHandler(this.changeUsersPasswordToolStripMenuItem_Click);
            // 
            // changeUsersAccessTypeToolStripMenuItem
            // 
            this.changeUsersAccessTypeToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeUsersAccessTypeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeUsersAccessTypeToolStripMenuItem.Image")));
            this.changeUsersAccessTypeToolStripMenuItem.Name = "changeUsersAccessTypeToolStripMenuItem";
            this.changeUsersAccessTypeToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.changeUsersAccessTypeToolStripMenuItem.Text = "Change user\'s access type";
            this.changeUsersAccessTypeToolStripMenuItem.Click += new System.EventHandler(this.changeUsersAccessTypeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.databaseBackupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("databaseBackupToolStripMenuItem.Image")));
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.databaseBackupToolStripMenuItem.Text = "Database backup";
            this.databaseBackupToolStripMenuItem.Click += new System.EventHandler(this.databaseBackupToolStripMenuItem_Click);
            // 
            // backupDatabaseRecoveryToolStripMenuItem
            // 
            this.backupDatabaseRecoveryToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backupDatabaseRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backupDatabaseRecoveryToolStripMenuItem.Image")));
            this.backupDatabaseRecoveryToolStripMenuItem.Name = "backupDatabaseRecoveryToolStripMenuItem";
            this.backupDatabaseRecoveryToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.backupDatabaseRecoveryToolStripMenuItem.Text = "Database recovery";
            this.backupDatabaseRecoveryToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseRecoveryToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(129, 27);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(176, 27);
            this.aboutProgramToolStripMenuItem.Text = "About program";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Brown;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 27);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // myDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "myDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.Load += new System.EventHandler(this.myDB_Load);
            this.Click += new System.EventHandler(this.myDB_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dBTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TableExpert;
        private System.Windows.Forms.ToolStripMenuItem TableExploration;
        private System.Windows.Forms.ToolStripMenuItem TableGemstone;
        private System.Windows.Forms.ToolStripMenuItem TableLaboratory;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUsersPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUsersAccessTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseRecoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

