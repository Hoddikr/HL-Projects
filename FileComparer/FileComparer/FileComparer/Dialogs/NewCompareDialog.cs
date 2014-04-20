using HoddiLara.FileCompareUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileComparer.Dialogs
{
    public partial class NewCompareDialog : Form
    {
        public NewCompareDialog()
        {
            InitializeComponent();

            foreach (var pattern in Settings.SearchPatterns)
            {
                cmbFileTypes.Items.Add(pattern.Description + " " + pattern.Pattern);
            }

            cmbFileTypes.SelectedIndex = 0;
        }

        public SearchPattern SelectedPattern
        {
            get
            {
                return Settings.SearchPatterns[cmbFileTypes.SelectedIndex];
            }
        }

        /// <summary>
        /// The path to the "left" folder
        /// </summary>
        public string FolderPath1
        {
            get
            {
                return tbFolderPath1.Text.Trim();
            }
        }

        /// <summary>
        /// The path to the "right" folder
        /// </summary>
        public string FolderPath2
        {
            get
            {
                return tbFolderPath2.Text.Trim();
            }
        }

        private void btnSelectFolder1_Click(object sender, EventArgs e)
        {
            if (fdbBrowseFolder.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath1.Text = fdbBrowseFolder.SelectedPath;
            }
        }

        private void btnSelectFolder2_Click(object sender, EventArgs e)
        {
            if (fdbBrowseFolder.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath2.Text = fdbBrowseFolder.SelectedPath;
            }
        }

        private void CheckEnabled(object sender, EventArgs e)
        {
            btnOK.Enabled = FolderPath1 != "" ||
                            (FolderPath1 != "" && FolderPath2 != "");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
