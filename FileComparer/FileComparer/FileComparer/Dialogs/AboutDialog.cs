using System;
using System.Windows.Forms;

namespace HL.FileComparer.Dialogs
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            label1.Text = Properties.Resources.AboutText;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
