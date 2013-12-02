namespace FileCompareTester
{
    partial class TestForm
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbPattern = new System.Windows.Forms.TextBox();
            this.lblPattern = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnFindDuplicates = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder1 = new System.Windows.Forms.Button();
            this.btnFindTwoFolderDuplicates = new System.Windows.Forms.Button();
            this.tbFolder1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectFolder2 = new System.Windows.Forms.Button();
            this.tbFolder2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPattern
            // 
            this.tbPattern.Location = new System.Drawing.Point(118, 23);
            this.tbPattern.Name = "tbPattern";
            this.tbPattern.Size = new System.Drawing.Size(191, 20);
            this.tbPattern.TabIndex = 0;
            // 
            // lblPattern
            // 
            this.lblPattern.Location = new System.Drawing.Point(12, 21);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(100, 23);
            this.lblPattern.TabIndex = 1;
            this.lblPattern.Text = "Pattern:";
            this.lblPattern.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(563, 17);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(30, 23);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(103, 19);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.ReadOnly = true;
            this.tbFolder.Size = new System.Drawing.Size(454, 20);
            this.tbFolder.TabIndex = 4;
            // 
            // btnFindDuplicates
            // 
            this.btnFindDuplicates.Location = new System.Drawing.Point(103, 45);
            this.btnFindDuplicates.Name = "btnFindDuplicates";
            this.btnFindDuplicates.Size = new System.Drawing.Size(139, 23);
            this.btnFindDuplicates.TabIndex = 5;
            this.btnFindDuplicates.Text = "Find duplicates";
            this.btnFindDuplicates.UseVisualStyleBackColor = true;
            this.btnFindDuplicates.Click += new System.EventHandler(this.btnFindDuplicates_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelectFolder);
            this.groupBox1.Controls.Add(this.btnFindDuplicates);
            this.groupBox1.Controls.Add(this.tbFolder);
            this.groupBox1.Location = new System.Drawing.Point(15, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 141);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnSelectFolder2);
            this.groupBox2.Controls.Add(this.tbFolder2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnSelectFolder1);
            this.groupBox2.Controls.Add(this.btnFindTwoFolderDuplicates);
            this.groupBox2.Controls.Add(this.tbFolder1);
            this.groupBox2.Location = new System.Drawing.Point(15, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 151);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Two folders";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Folder 1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectFolder1
            // 
            this.btnSelectFolder1.Location = new System.Drawing.Point(563, 17);
            this.btnSelectFolder1.Name = "btnSelectFolder1";
            this.btnSelectFolder1.Size = new System.Drawing.Size(30, 23);
            this.btnSelectFolder1.TabIndex = 6;
            this.btnSelectFolder1.Text = "...";
            this.btnSelectFolder1.UseVisualStyleBackColor = true;
            this.btnSelectFolder1.Click += new System.EventHandler(this.btnSelectFolder1_Click);
            // 
            // btnFindTwoFolderDuplicates
            // 
            this.btnFindTwoFolderDuplicates.Location = new System.Drawing.Point(103, 71);
            this.btnFindTwoFolderDuplicates.Name = "btnFindTwoFolderDuplicates";
            this.btnFindTwoFolderDuplicates.Size = new System.Drawing.Size(139, 23);
            this.btnFindTwoFolderDuplicates.TabIndex = 9;
            this.btnFindTwoFolderDuplicates.Text = "Find duplicates";
            this.btnFindTwoFolderDuplicates.UseVisualStyleBackColor = true;
            this.btnFindTwoFolderDuplicates.Click += new System.EventHandler(this.btnFindTwoFolderDuplicates_Click);
            // 
            // tbFolder1
            // 
            this.tbFolder1.Location = new System.Drawing.Point(103, 19);
            this.tbFolder1.Name = "tbFolder1";
            this.tbFolder1.ReadOnly = true;
            this.tbFolder1.Size = new System.Drawing.Size(454, 20);
            this.tbFolder1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Folder 2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectFolder2
            // 
            this.btnSelectFolder2.Location = new System.Drawing.Point(563, 43);
            this.btnSelectFolder2.Name = "btnSelectFolder2";
            this.btnSelectFolder2.Size = new System.Drawing.Size(30, 23);
            this.btnSelectFolder2.TabIndex = 10;
            this.btnSelectFolder2.Text = "...";
            this.btnSelectFolder2.UseVisualStyleBackColor = true;
            this.btnSelectFolder2.Click += new System.EventHandler(this.btnSelectFolder2_Click);
            // 
            // tbFolder2
            // 
            this.tbFolder2.Location = new System.Drawing.Point(103, 45);
            this.tbFolder2.Name = "tbFolder2";
            this.tbFolder2.ReadOnly = true;
            this.tbFolder2.Size = new System.Drawing.Size(454, 20);
            this.tbFolder2.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 389);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(783, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 545);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.tbPattern);
            this.Name = "TestForm";
            this.Text = "Test form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox tbPattern;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnFindDuplicates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFolder2;
        private System.Windows.Forms.TextBox tbFolder2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectFolder1;
        private System.Windows.Forms.Button btnFindTwoFolderDuplicates;
        private System.Windows.Forms.TextBox tbFolder1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

