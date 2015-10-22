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
        private FileType pattern;

        public FileTypeDialog()
        {
            InitializeComponent();
        }

        public FileTypeDialog(FileType pattern)
            :this()
        {
            this.pattern = pattern;

            tbDescription.Text = pattern.Description;
            tbPattern.Text = pattern.Pattern;
            ntbMaxMB.Value = pattern.MaxNoOfMBToSearch;
        }

        private void CheckEnabled(object sender, EventArgs args)
        {
            if (pattern == null)
            {
                btnOK.Enabled = tbDescription.Text.Trim().Length > 0 && tbPattern.Text.Trim().Length > 0;
            }
            else
            {
                btnOK.Enabled = pattern.Description != tbDescription.Text || pattern.Pattern != tbPattern.Text || Math.Abs(pattern.MaxNoOfMBToSearch - ntbMaxMB.Value) >= 1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool creatingNewPattern = false;

            if (pattern == null)
            {
                creatingNewPattern = true;
                pattern = new FileType();
            }

            pattern.Description = tbDescription.Text;
            pattern.Pattern = tbPattern.Text;
            pattern.MaxNoOfMBToSearch = (int)ntbMaxMB.Value;

            if (creatingNewPattern)
            {
                Settings.FileTypes.Add(pattern);
            }
        }
    }
}
