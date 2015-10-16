using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Dialogs
{
    public partial class FileTypeDialog : Form
    {
        private SearchPattern pattern;

        public FileTypeDialog()
        {
            InitializeComponent();
        }

        public FileTypeDialog(SearchPattern pattern)
            :this()
        {
            this.pattern = pattern;

            tbDescription.Text = pattern.Description;
            tbPattern.Text = pattern.Pattern;
        }

        private void CheckEnabled(object sender, EventArgs args)
        {
            if (pattern == null)
            {
                btnOK.Enabled = tbDescription.Text.Trim().Length > 0 && tbPattern.Text.Trim().Length > 0;
            }
            else
            {
                btnOK.Enabled = pattern.Description != tbDescription.Text || pattern.Pattern != tbPattern.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool creatingNewPattern = false;

            if (pattern == null)
            {
                creatingNewPattern = true;
                pattern = new SearchPattern();
            }

            pattern.Description = tbDescription.Text;
            pattern.Pattern = tbPattern.Text;

            if (creatingNewPattern)
            {
                Settings.SearchPatterns.Add(pattern);
            }
        }
    }
}
