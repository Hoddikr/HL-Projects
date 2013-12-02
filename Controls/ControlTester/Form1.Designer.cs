namespace ControlTester
{
    partial class Form1
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
            this.btnAddLargeWeight = new System.Windows.Forms.Button();
            this.btnAddSmallWeight = new System.Windows.Forms.Button();
            this.btnSetCollar = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.roundedRectangle1 = new Controls.RoundedRectangle();
            this.barBell1 = new Controls.BarBell();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(799, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddLargeWeight
            // 
            this.btnAddLargeWeight.Location = new System.Drawing.Point(557, 409);
            this.btnAddLargeWeight.Name = "btnAddLargeWeight";
            this.btnAddLargeWeight.Size = new System.Drawing.Size(114, 23);
            this.btnAddLargeWeight.TabIndex = 3;
            this.btnAddLargeWeight.Text = "Add large weight";
            this.btnAddLargeWeight.UseVisualStyleBackColor = true;
            this.btnAddLargeWeight.Click += new System.EventHandler(this.btnAddLargeWeight_Click);
            // 
            // btnAddSmallWeight
            // 
            this.btnAddSmallWeight.Location = new System.Drawing.Point(557, 438);
            this.btnAddSmallWeight.Name = "btnAddSmallWeight";
            this.btnAddSmallWeight.Size = new System.Drawing.Size(114, 23);
            this.btnAddSmallWeight.TabIndex = 4;
            this.btnAddSmallWeight.Text = "Add small weight";
            this.btnAddSmallWeight.UseVisualStyleBackColor = true;
            this.btnAddSmallWeight.Click += new System.EventHandler(this.btnAddSmallWeight_Click);
            // 
            // btnSetCollar
            // 
            this.btnSetCollar.Location = new System.Drawing.Point(557, 467);
            this.btnSetCollar.Name = "btnSetCollar";
            this.btnSetCollar.Size = new System.Drawing.Size(114, 23);
            this.btnSetCollar.TabIndex = 5;
            this.btnSetCollar.Text = "Set collar";
            this.btnSetCollar.UseVisualStyleBackColor = true;
            this.btnSetCollar.Click += new System.EventHandler(this.btnSetCollar_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(557, 496);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // roundedRectangle1
            // 
            this.roundedRectangle1.AutoSize = true;
            this.roundedRectangle1.Location = new System.Drawing.Point(695, 409);
            this.roundedRectangle1.Name = "roundedRectangle1";
            this.roundedRectangle1.ShowOriginalCollar = false;
            this.roundedRectangle1.Size = new System.Drawing.Size(88, 172);
            this.roundedRectangle1.TabIndex = 1;
            // 
            // barBell1
            // 
            this.barBell1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barBell1.AutoSize = true;
            this.barBell1.Location = new System.Drawing.Point(12, 0);
            this.barBell1.Name = "barBell1";
            this.barBell1.Size = new System.Drawing.Size(1040, 403);
            this.barBell1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 593);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSetCollar);
            this.Controls.Add(this.btnAddSmallWeight);
            this.Controls.Add(this.btnAddLargeWeight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roundedRectangle1);
            this.Controls.Add(this.barBell1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.BarBell barBell1;
        private Controls.RoundedRectangle roundedRectangle1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddLargeWeight;
        private System.Windows.Forms.Button btnAddSmallWeight;
        private System.Windows.Forms.Button btnSetCollar;
        private System.Windows.Forms.Button btnClear;
    }
}

