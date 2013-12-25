using HL.Controls.HLControls.EventArguments;
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
    public partial class CategoryControlTester : Form
    {
        private int categoryCount = 0;

        public CategoryControlTester()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            categoryCount++;
            string categoryKey = "Category " + categoryCount;
            categoryControl1.AddCategory(categoryKey, "Category: " + categoryCount);
            categoryControl1.AddCategoryItem(categoryKey, "Test & item 1", CategoryItemClicked);
            categoryControl1.AddCategoryItem(categoryKey, "Test item 2", CategoryItemClicked);
            categoryControl1.AddCategoryItem(categoryKey, "Test item 3", CategoryItemClicked);

        }

        private void CategoryItemClicked(object sender, EventArgs args)
        {
            //MessageBox.Show("Item clicked");
        }

        private void categoryControl1_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            //MessageBox.Show(args.CategoryKey + " " + args.CategoryDescription + " " + args.CategoryItemDescriptoin);
        }
    }
}
