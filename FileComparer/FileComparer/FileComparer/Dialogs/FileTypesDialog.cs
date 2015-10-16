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
using Newtonsoft.Json;

namespace HL.FileComparer.Dialogs
{
    public partial class FileTypesDialog : Form
    {
        public FileTypesDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadFileTypes();
        }

        private void LoadFileTypes()
        {
            int selectedIndex = lvFileTypes.SelectedIndices.Count > 0 ? lvFileTypes.SelectedIndices[0] : -1;
            lvFileTypes.Items.Clear();

            ListViewItem item;
            foreach (SearchPattern pattern in Settings.SearchPatterns)
            {
                item = new ListViewItem(pattern.Description);
                item.SubItems.Add(pattern.Pattern);

                item.Tag = pattern;
                lvFileTypes.Items.Add(item);

                if (lvFileTypes.Items.Count - 1 == selectedIndex)
                {
                    item.Selected = true;
                }
            }

            lvFileTypes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            BestFitFirstColumn();
        }

        /// <summary>
        /// Only resizes the first column to best fit either content or header text.
        /// </summary>
        private void BestFitFirstColumn()
        {
            int maxWidth = 0;

            foreach (ListViewItem item in lvFileTypes.Items)
            {
                int curWidth = TextRenderer.MeasureText(item.Text, item.Font).Width;

                if (curWidth > maxWidth)
                {
                    maxWidth = curWidth;
                }
            }

            if (lvFileTypes.Columns[0].Width < maxWidth)
            {
                lvFileTypes.Columns[0].Width = maxWidth + 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileTypeDialog dlg = new FileTypeDialog();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Settings.SaveSettings();
                LoadFileTypes();
            }
        }

        private void lvFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = btnEdit.Enabled = lvFileTypes.SelectedItems.Count > 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SearchPattern selectedPattern = (SearchPattern)lvFileTypes.SelectedItems[0].Tag;

            FileTypeDialog dlg = new FileTypeDialog(selectedPattern);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Settings.SaveSettings();
                LoadFileTypes();
            }
        }
    }
}
