using HLControls.UnitGridControl;
namespace ControlTester
{
    partial class NumeralTextBoxTester
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
            this.numeralTextbox1 = new HL.Controls.HLControls.NumeralTextbox();
            this.unitGridControl1 = new HLControls.UnitGridControl.UnitGridControl();
            this.SuspendLayout();
            // 
            // numeralTextbox1
            // 
            this.numeralTextbox1.Location = new System.Drawing.Point(29, 30);
            this.numeralTextbox1.Name = "numeralTextbox1";
            this.numeralTextbox1.Size = new System.Drawing.Size(167, 20);
            this.numeralTextbox1.TabIndex = 0;
            // 
            // unitGridControl1
            // 
            this.unitGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitGridControl1.BackColor = System.Drawing.Color.Transparent;
            this.unitGridControl1.Columns = 20;
            this.unitGridControl1.Location = new System.Drawing.Point(202, 30);
            this.unitGridControl1.Name = "unitGridControl1";
            this.unitGridControl1.Rows = 20;
            this.unitGridControl1.Size = new System.Drawing.Size(747, 482);
            this.unitGridControl1.TabIndex = 1;
            // 
            // NumeralTextBoxTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 524);
            this.Controls.Add(this.unitGridControl1);
            this.Controls.Add(this.numeralTextbox1);
            this.Name = "NumeralTextBoxTester";
            this.Text = "NumeralTextBoxTester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HL.Controls.HLControls.NumeralTextbox numeralTextbox1;
        private UnitGridControl unitGridControl1;
    }
}