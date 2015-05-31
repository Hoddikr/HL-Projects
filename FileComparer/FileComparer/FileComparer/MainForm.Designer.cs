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
            this.pbFilesProcessed = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnSelectFolder1 = new System.Windows.Forms.Button();
            this.tbFolderPath1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFileTypes = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fdbBrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFileTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFileComparerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareResultsControl = new HL.FileComparer.Controls.CompareResultsControl();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResultCount = new System.Windows.Forms.TextBox();
            this.btnSelectFolder2 = new System.Windows.Forms.Button();
            this.tbFolderPath2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFilesProcessed
            // 
            this.pbFilesProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFilesProcessed.Location = new System.Drawing.Point(12, 541);
            this.pbFilesProcessed.Name = "pbFilesProcessed";
            this.pbFilesProcessed.Size = new System.Drawing.Size(982, 27);
            this.pbFilesProcessed.TabIndex = 10;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(730, 574);
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
            this.lblProgress.TabIndex = 9;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectFolder1
            // 
            this.btnSelectFolder1.Location = new System.Drawing.Point(437, 56);
            this.btnSelectFolder1.Name = "btnSelectFolder1";
            this.btnSelectFolder1.Size = new System.Drawing.Size(27, 23);
            this.btnSelectFolder1.TabIndex = 5;
            this.btnSelectFolder1.Text = "...";
            this.btnSelectFolder1.UseVisualStyleBackColor = true;
            this.btnSelectFolder1.Click += new System.EventHandler(this.btnSelectFolder1_Click);
            // 
            // tbFolderPath1
            // 
            this.tbFolderPath1.Location = new System.Drawing.Point(92, 58);
            this.tbFolderPath1.Name = "tbFolderPath1";
            this.tbFolderPath1.Size = new System.Drawing.Size(339, 20);
            this.tbFolderPath1.TabIndex = 4;
            this.tbFolderPath1.TextChanged += new System.EventHandler(this.CheckEnabled);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder 1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-44, 29);
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
            this.cmbFileTypes.Location = new System.Drawing.Point(92, 31);
            this.cmbFileTypes.Name = "cmbFileTypes";
            this.cmbFileTypes.Size = new System.Drawing.Size(235, 21);
            this.cmbFileTypes.TabIndex = 2;
            this.cmbFileTypes.SelectedIndexChanged += new System.EventHandler(this.cmbFileTypes_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(865, 574);
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
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageFileTypesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageFileTypesToolStripMenuItem
            // 
            this.manageFileTypesToolStripMenuItem.Name = "manageFileTypesToolStripMenuItem";
            this.manageFileTypesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.manageFileTypesToolStripMenuItem.Text = "Manage File Types";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
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
            // compareResultsControl
            // 
            this.compareResultsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compareResultsControl.Location = new System.Drawing.Point(15, 111);
            this.compareResultsControl.Name = "compareResultsControl";
            this.compareResultsControl.Size = new System.Drawing.Size(979, 401);
            this.compareResultsControl.TabIndex = 8;
            this.compareResultsControl.MatchClicked += new HL.FileComparer.Controls.CompareResultsControl.MatchClickedHandler(this.compareResultsControl_MatchClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(470, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbResultCount
            // 
            this.tbResultCount.Location = new System.Drawing.Point(576, 58);
            this.tbResultCount.Name = "tbResultCount";
            this.tbResultCount.Size = new System.Drawing.Size(100, 20);
            this.tbResultCount.TabIndex = 7;
            // 
            // btnSelectFolder2
            // 
            this.btnSelectFolder2.Location = new System.Drawing.Point(437, 82);
            this.btnSelectFolder2.Name = "btnSelectFolder2";
            this.btnSelectFolder2.Size = new System.Drawing.Size(27, 23);
            this.btnSelectFolder2.TabIndex = 15;
            this.btnSelectFolder2.Text = "...";
            this.btnSelectFolder2.UseVisualStyleBackColor = true;
            // 
            // tbFolderPath2
            // 
            this.tbFolderPath2.Location = new System.Drawing.Point(92, 84);
            this.tbFolderPath2.Name = "tbFolderPath2";
            this.tbFolderPath2.Size = new System.Drawing.Size(339, 20);
            this.tbFolderPath2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Folder 2:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 609);
            this.Controls.Add(this.btnSelectFolder2);
            this.Controls.Add(this.tbFolderPath2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbResultCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.compareResultsControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectFolder1);
            this.Controls.Add(this.tbFolderPath1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFileTypes);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbFilesProcessed);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File comparer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbFilesProcessed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnSelectFolder1;
        private System.Windows.Forms.TextBox tbFolderPath1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFileTypes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog fdbBrowseFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFileTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFileComparerToolStripMenuItem;
        private Controls.CompareResultsControl compareResultsControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbResultCount;
        private System.Windows.Forms.Button btnSelectFolder2;
        private System.Windows.Forms.TextBox tbFolderPath2;
        private System.Windows.Forms.Label label4;
    }
}

