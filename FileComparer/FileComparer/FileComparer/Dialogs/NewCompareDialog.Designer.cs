namespace FileComparer.Dialogs
{
    partial class NewCompareDialog
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
            this.cmbFileTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFolderPath1 = new System.Windows.Forms.TextBox();
            this.tbFolderPath2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectFolder1 = new System.Windows.Forms.Button();
            this.btnSelectFolder2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fdbBrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmbFileTypes
            // 
            this.cmbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileTypes.FormattingEnabled = true;
            this.cmbFileTypes.Location = new System.Drawing.Point(139, 21);
            this.cmbFileTypes.Name = "cmbFileTypes";
            this.cmbFileTypes.Size = new System.Drawing.Size(235, 21);
            this.cmbFileTypes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "File type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder 1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFolderPath1
            // 
            this.tbFolderPath1.Location = new System.Drawing.Point(139, 48);
            this.tbFolderPath1.Name = "tbFolderPath1";
            this.tbFolderPath1.Size = new System.Drawing.Size(313, 20);
            this.tbFolderPath1.TabIndex = 3;
            this.tbFolderPath1.TextChanged += new System.EventHandler(this.CheckEnabled);
            // 
            // tbFolderPath2
            // 
            this.tbFolderPath2.Location = new System.Drawing.Point(139, 74);
            this.tbFolderPath2.Name = "tbFolderPath2";
            this.tbFolderPath2.Size = new System.Drawing.Size(313, 20);
            this.tbFolderPath2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Folder 2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectFolder1
            // 
            this.btnSelectFolder1.Location = new System.Drawing.Point(458, 46);
            this.btnSelectFolder1.Name = "btnSelectFolder1";
            this.btnSelectFolder1.Size = new System.Drawing.Size(27, 23);
            this.btnSelectFolder1.TabIndex = 4;
            this.btnSelectFolder1.Text = "...";
            this.btnSelectFolder1.UseVisualStyleBackColor = true;
            this.btnSelectFolder1.Click += new System.EventHandler(this.btnSelectFolder1_Click);
            // 
            // btnSelectFolder2
            // 
            this.btnSelectFolder2.Location = new System.Drawing.Point(458, 72);
            this.btnSelectFolder2.Name = "btnSelectFolder2";
            this.btnSelectFolder2.Size = new System.Drawing.Size(27, 23);
            this.btnSelectFolder2.TabIndex = 7;
            this.btnSelectFolder2.Text = "...";
            this.btnSelectFolder2.UseVisualStyleBackColor = true;
            this.btnSelectFolder2.Click += new System.EventHandler(this.btnSelectFolder2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(329, 113);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(410, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // fdbBrowseFolder
            // 
            this.fdbBrowseFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // NewCompareDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(511, 148);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelectFolder2);
            this.Controls.Add(this.btnSelectFolder1);
            this.Controls.Add(this.tbFolderPath2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFolderPath1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFileTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewCompareDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start new compare search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFileTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFolderPath1;
        private System.Windows.Forms.TextBox tbFolderPath2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFolder1;
        private System.Windows.Forms.Button btnSelectFolder2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog fdbBrowseFolder;
    }
}