namespace ControlTester
{
    partial class NotificationAreaButtonTester
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
            this.notificationAreaButton4 = new HL.Controls.HLControls.NotificationAreaButton();
            this.notificationAreaButton3 = new HL.Controls.HLControls.NotificationAreaButton();
            this.notificationAreaButton2 = new HL.Controls.HLControls.NotificationAreaButton();
            this.notificationAreaButton1 = new HL.Controls.HLControls.NotificationAreaButton();
            this.SuspendLayout();
            // 
            // notificationAreaButton4
            // 
            this.notificationAreaButton4.BackColor = System.Drawing.Color.Transparent;
            this.notificationAreaButton4.DateTimeString = null;
            this.notificationAreaButton4.Location = new System.Drawing.Point(12, 147);
            this.notificationAreaButton4.Name = "notificationAreaButton4";
            this.notificationAreaButton4.Size = new System.Drawing.Size(260, 39);
            this.notificationAreaButton4.Subject = "Subject";
            this.notificationAreaButton4.TabIndex = 3;
            this.notificationAreaButton4.Text = "Content text";
            // 
            // notificationAreaButton3
            // 
            this.notificationAreaButton3.BackColor = System.Drawing.Color.Transparent;
            this.notificationAreaButton3.DateTimeString = null;
            this.notificationAreaButton3.Location = new System.Drawing.Point(12, 102);
            this.notificationAreaButton3.Name = "notificationAreaButton3";
            this.notificationAreaButton3.Size = new System.Drawing.Size(260, 39);
            this.notificationAreaButton3.Subject = "Subject";
            this.notificationAreaButton3.TabIndex = 2;
            this.notificationAreaButton3.Text = "Content text";
            // 
            // notificationAreaButton2
            // 
            this.notificationAreaButton2.BackColor = System.Drawing.Color.Transparent;
            this.notificationAreaButton2.DateTimeString = null;
            this.notificationAreaButton2.Location = new System.Drawing.Point(12, 57);
            this.notificationAreaButton2.Name = "notificationAreaButton2";
            this.notificationAreaButton2.Size = new System.Drawing.Size(260, 39);
            this.notificationAreaButton2.Subject = "Subject";
            this.notificationAreaButton2.TabIndex = 1;
            this.notificationAreaButton2.Text = "Content text";
            // 
            // notificationAreaButton1
            // 
            this.notificationAreaButton1.BackColor = System.Drawing.Color.Transparent;
            this.notificationAreaButton1.DateTimeString = "asdfasdf";
            this.notificationAreaButton1.Location = new System.Drawing.Point(12, 12);
            this.notificationAreaButton1.Name = "notificationAreaButton1";
            this.notificationAreaButton1.Size = new System.Drawing.Size(260, 39);
            this.notificationAreaButton1.Subject = "Subject";
            this.notificationAreaButton1.TabIndex = 0;
            this.notificationAreaButton1.Text = "Content text";
            this.notificationAreaButton1.Load += new System.EventHandler(this.notificationAreaButton1_Load);
            this.notificationAreaButton1.Click += new System.EventHandler(this.notificationAreaButton1_Click);
            // 
            // NotificationAreaButtonTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ControlTester.Properties.Resources.cavestoryouterwallpaperrt3;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.notificationAreaButton4);
            this.Controls.Add(this.notificationAreaButton3);
            this.Controls.Add(this.notificationAreaButton2);
            this.Controls.Add(this.notificationAreaButton1);
            this.Name = "NotificationAreaButtonTester";
            this.Text = "NotificationAreaButtonTester";
            this.ResumeLayout(false);

        }

        #endregion

        private HL.Controls.HLControls.NotificationAreaButton notificationAreaButton1;
        private HL.Controls.HLControls.NotificationAreaButton notificationAreaButton2;
        private HL.Controls.HLControls.NotificationAreaButton notificationAreaButton3;
        private HL.Controls.HLControls.NotificationAreaButton notificationAreaButton4;

    }
}