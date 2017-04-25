namespace HL.FileComparer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbFilesProcessed = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFileTypes = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFileTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFileComparerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteDuplicates = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSpaceWasted = new System.Windows.Forms.Label();
            this.folderBrowser = new HL.FileComparer.Controls.FolderBrowser();
            this.compareResultsControl = new HL.FileComparer.Controls.CompareResultsControl();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.grpStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFilesProcessed
            // 
            this.pbFilesProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFilesProcessed.Location = new System.Drawing.Point(12, 541);
            this.pbFilesProcessed.Name = "pbFilesProcessed";
            this.pbFilesProcessed.Size = new System.Drawing.Size(1008, 27);
            this.pbFilesProcessed.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(756, 574);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 29);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start search";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProgress.Location = new System.Drawing.Point(12, 515);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(167, 23);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-66, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "File type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFileTypes
            // 
            this.cmbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileTypes.FormattingEnabled = true;
            this.cmbFileTypes.Location = new System.Drawing.Point(70, 37);
            this.cmbFileTypes.Name = "cmbFileTypes";
            this.cmbFileTypes.Size = new System.Drawing.Size(235, 21);
            this.cmbFileTypes.TabIndex = 2;
            this.cmbFileTypes.SelectedIndexChanged += new System.EventHandler(this.cmbFileTypes_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(891, 574);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageFileTypesToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageFileTypesToolStripMenuItem
            // 
            this.manageFileTypesToolStripMenuItem.Name = "manageFileTypesToolStripMenuItem";
            this.manageFileTypesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.manageFileTypesToolStripMenuItem.Text = "Manage File Types";
            this.manageFileTypesToolStripMenuItem.Click += new System.EventHandler(this.manageFileTypesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutFileComparerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutFileComparerToolStripMenuItem
            // 
            this.aboutFileComparerToolStripMenuItem.Name = "aboutFileComparerToolStripMenuItem";
            this.aboutFileComparerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aboutFileComparerToolStripMenuItem.Text = "About File comparer";
            this.aboutFileComparerToolStripMenuItem.Click += new System.EventHandler(this.aboutFileComparerToolStripMenuItem_Click);
            // 
            // btnDeleteDuplicates
            // 
            this.btnDeleteDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDuplicates.Enabled = false;
            this.btnDeleteDuplicates.Location = new System.Drawing.Point(621, 574);
            this.btnDeleteDuplicates.Name = "btnDeleteDuplicates";
            this.btnDeleteDuplicates.Size = new System.Drawing.Size(129, 29);
            this.btnDeleteDuplicates.TabIndex = 10;
            this.btnDeleteDuplicates.Text = "Delete duplicates";
            this.btnDeleteDuplicates.UseVisualStyleBackColor = true;
            this.btnDeleteDuplicates.Click += new System.EventHandler(this.btnDeleteDuplicates_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Space wasted:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpaceWasted
            // 
            this.lblSpaceWasted.Location = new System.Drawing.Point(112, 16);
            this.lblSpaceWasted.Name = "lblSpaceWasted";
            this.lblSpaceWasted.Size = new System.Drawing.Size(78, 23);
            this.lblSpaceWasted.TabIndex = 5;
            this.lblSpaceWasted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // folderBrowser
            // 
            this.folderBrowser.BackColor = System.Drawing.Color.Transparent;
            this.folderBrowser.Location = new System.Drawing.Point(12, 64);
            this.folderBrowser.MaximumFolderItems = 4;
            this.folderBrowser.Name = "folderBrowser";
            this.folderBrowser.Size = new System.Drawing.Size(711, 35);
            this.folderBrowser.TabIndex = 3;
            this.folderBrowser.FolderSelectionChanged += new System.EventHandler(this.CheckEnabled);
            this.folderBrowser.SizeChanged += new System.EventHandler(this.folderBrowser_SizeChanged);
            // 
            // compareResultsControl
            // 
            this.compareResultsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compareResultsControl.Location = new System.Drawing.Point(15, 105);
            this.compareResultsControl.Name = "compareResultsControl";
            this.compareResultsControl.Size = new System.Drawing.Size(1005, 407);
            this.compareResultsControl.TabIndex = 6;
            this.compareResultsControl.MatchClicked += new HL.FileComparer.Controls.CompareResultsControl.MatchClickedHandler(this.compareResultsControl_MatchClicked);
            // 
            // lblResultCount
            // 
            this.lblResultCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultCount.Location = new System.Drawing.Point(891, 515);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(129, 23);
            this.lblResultCount.TabIndex = 8;
            this.lblResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpStatistics
            // 
            this.grpStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatistics.Controls.Add(this.lblTime);
            this.grpStatistics.Controls.Add(this.label4);
            this.grpStatistics.Controls.Add(this.lblTimeElapsed);
            this.grpStatistics.Controls.Add(this.lblSpaceWasted);
            this.grpStatistics.Location = new System.Drawing.Point(726, 27);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.Size = new System.Drawing.Size(294, 72);
            this.grpStatistics.TabIndex = 13;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "Statistics";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(6, 39);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(100, 23);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time elapsed:";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.Location = new System.Drawing.Point(112, 39);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(78, 23);
            this.lblTimeElapsed.TabIndex = 7;
            this.lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 609);
            this.Controls.Add(this.grpStatistics);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.folderBrowser);
            this.Controls.Add(this.btnDeleteDuplicates);
            this.Controls.Add(this.compareResultsControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFileTypes);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbFilesProcessed);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1048, 648);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File comparer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpStatistics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbFilesProcessed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFileTypes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFileTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFileComparerToolStripMenuItem;
        private Controls.CompareResultsControl compareResultsControl;
        private System.Windows.Forms.Button btnDeleteDuplicates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSpaceWasted;
        private Controls.FolderBrowser folderBrowser;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

