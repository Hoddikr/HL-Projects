using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL.Controls.WeightLiftingControls;

namespace ControlTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            roundedRectangle1.ShowOriginalCollar = !roundedRectangle1.ShowOriginalCollar;
        }

        private void btnAddLargeWeight_Click(object sender, EventArgs e)
        {
            barBell1.AddLargeWeight(Color.Red);
        }

        private void btnAddSmallWeight_Click(object sender, EventArgs e)
        {
            barBell1.AddSmallWeight(Color.Purple);
        }

        private void btnSetCollar_Click(object sender, EventArgs e)
        {
            barBell1.SetCollar();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            barBell1.Clear();
        }
    }
}
