﻿namespace FileCompareTester
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowser1 = new HL.FileComparer.Controls.FolderBrowser();
            this.compareResultsControls1 = new HL.FileComparer.Controls.CompareResultsControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // folderBrowser1
            // 
            this.folderBrowser1.BackColor = System.Drawing.Color.Transparent;
            this.folderBrowser1.Location = new System.Drawing.Point(12, 12);
            this.folderBrowser1.MaximumFolderItems = 0;
            this.folderBrowser1.Name = "folderBrowser1";
            this.folderBrowser1.Size = new System.Drawing.Size(486, 65);
            this.folderBrowser1.TabIndex = 1;
            // 
            // compareResultsControls1
            // 
            this.compareResultsControls1.Location = new System.Drawing.Point(12, 334);
            this.compareResultsControls1.Name = "compareResultsControls1";
            this.compareResultsControls1.Size = new System.Drawing.Size(292, 150);
            this.compareResultsControls1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.folderBrowser1);
            this.Controls.Add(this.compareResultsControls1);
            this.DoubleBuffered = true;
            this.Name = "TestForm";
            this.Text = "Test form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private HL.FileComparer.Controls.CompareResultsControl compareResultsControls1;
        private HL.FileComparer.Controls.FolderBrowser folderBrowser1;
        private System.Windows.Forms.Button button1;
    }
}

