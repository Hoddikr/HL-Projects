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
            foreach (FileType pattern in Settings.FileTypes)
            {
                item = new ListViewItem(pattern.Description);
                item.SubItems.Add(pattern.Pattern);
                item.SubItems.Add(pattern.MaxNoOfMBToSearch.ToString("N0"));

                item.Tag = pattern;
                lvFileTypes.Items.Add(item);

                if (lvFileTypes.Items.Count - 1 == selectedIndex)
                {
                    item.Selected = true;
                }
            }

            lvFileTypes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            //BestFitFirstColumn();
            BestFitAllColumns();
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

        private void BestFitAllColumns()
        {
            int maxWidth = 0;
            int[] columnWidths = new int[lvFileTypes.Columns.Count];

            for (int i = 0; i < lvFileTypes.Columns.Count; i++)
            {
                columnWidths[i] = TextRenderer.MeasureText(lvFileTypes.Columns[i].Text, lvFileTypes.Font).Width;
            }

            foreach (ListViewItem item in lvFileTypes.Items)
            {
                for (int i = 0; i < lvFileTypes.Columns.Count; i++)
                {
                    int curWidth = TextRenderer.MeasureText(item.SubItems[i].Text, item.Font).Width;

                    if (curWidth > columnWidths[i])
                    {
                        columnWidths[i] = curWidth;
                    }
                }
            }


            int columnWidthSum = 0;
            for (int i = 0; i < lvFileTypes.Columns.Count - 1; i++)
            {
                if (lvFileTypes.Columns[i].Width < columnWidths[i])
                {
                    lvFileTypes.Columns[i].Width = columnWidths[i] + 5;                    
                }

                columnWidthSum += lvFileTypes.Columns[i].Width;
            }

            lvFileTypes.Columns[lvFileTypes.Columns.Count - 1].Width = lvFileTypes.Width - columnWidthSum - 5;
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
            FileType selectedPattern = (FileType)lvFileTypes.SelectedItems[0].Tag;

            FileTypeDialog dlg = new FileTypeDialog(selectedPattern);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Settings.SaveSettings();
                LoadFileTypes();
            }
        }

        private void lvFileTypes_DoubleClick(object sender, EventArgs e)
        {
            if (lvFileTypes.SelectedItems.Count > 0)
            {
                btnEdit_Click(this, EventArgs.Empty);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete the selected file type?", "Delete file type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FileType pattern = (FileType)lvFileTypes.SelectedItems[0].Tag;
                Settings.FileTypes.Remove(pattern);
                Settings.SaveSettings();
                LoadFileTypes();
            }
        }

        private void FileTypesDialog_SizeChanged(object sender, EventArgs e)
        {
            BestFitAllColumns();
        }
    }
}
