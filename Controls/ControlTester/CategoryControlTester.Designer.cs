namespace ControlTester
{
    partial class CategoryControlTester
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
            this.button1 = new System.Windows.Forms.Button();
            this.categoryControl1 = new HL.Controls.HLControls.CategoryControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // categoryControl1
            // 
            this.categoryControl1.Location = new System.Drawing.Point(12, 12);
            this.categoryControl1.Name = "categoryControl1";
            this.categoryControl1.Size = new System.Drawing.Size(500, 532);
            this.categoryControl1.TabIndex = 0;
            // 
            // CategoryControlTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 556);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.categoryControl1);
            this.Name = "CategoryControlTester";
            this.Text = "CategoryControlTester";
            this.ResumeLayout(false);

        }

        #endregion

        private HL.Controls.HLControls.CategoryControl categoryControl1;
        private System.Windows.Forms.Button button1;

    }
}