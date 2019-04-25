namespace ControlTester
{
    partial class UnitGridControlTester
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
            this.unitGridControl1 = new HLControls.UnitGridControl.UnitGridControl();
            this.SuspendLayout();
            // 
            // unitGridControl1
            // 
            this.unitGridControl1.BackColor = System.Drawing.Color.Transparent;
            this.unitGridControl1.Columns = 20;
            this.unitGridControl1.Location = new System.Drawing.Point(36, 12);
            this.unitGridControl1.Name = "unitGridControl1";
            this.unitGridControl1.Rows = 20;
            this.unitGridControl1.Size = new System.Drawing.Size(663, 478);
            this.unitGridControl1.TabIndex = 0;
            // 
            // UnitGridControlTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 502);
            this.Controls.Add(this.unitGridControl1);
            this.Name = "UnitGridControlTester";
            this.Text = "UnitGridControlTester";
            this.ResumeLayout(false);

        }

        #endregion

        private HLControls.UnitGridControl.UnitGridControl unitGridControl1;
    }
}