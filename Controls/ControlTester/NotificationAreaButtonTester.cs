using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlTester
{
    public partial class NotificationAreaButtonTester : Form
    {
        public NotificationAreaButtonTester()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            //label1.MaximumSize = new Size(Width - 10, Height);
            //label1.Text = "Lorem ipsum dolor sit amet, \n consectetur adipiscing elit. Nunc orci urna, dignissim non erat venenatis, rhoncus hendrerit dolor. Proin mattis massa vel nulla semper, id rhoncus lacus vehicula. Maecenas fringilla rutrum convallis. Morbi eget erat nisl. Cras at pellentesque erat. Vivamus adipiscing, erat nec gravida viverra, dui sapien tempus eros, at mollis neque ipsum ut enim. Suspendisse pretium varius lobortis. Nunc consequat quis eros quis ullamcorper. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam sit amet tellus tincidunt, placerat neque at, congue mi.";

            base.OnLoad(e);
        }

        private void notificationAreaButton1_Load(object sender, EventArgs e)
        {

        }

        private void notificationAreaButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CLICK");
        }
    }
}
