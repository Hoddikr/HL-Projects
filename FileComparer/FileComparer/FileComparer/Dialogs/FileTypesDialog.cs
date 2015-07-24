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
            //SearchPatterns.Add(new SearchPattern() { Description = "Images", Pattern = "*.jpg;*.bmp;*.png" });
            //SearchPatterns.Add(new SearchPattern() { Description = "Videos", Pattern = "*.avi;*.mp4;*.mkv" });
            //SearchPatterns.Add(new SearchPattern() { Description = "Music", Pattern = "*.mp3" });
            lvFileTypes.Items.Clear();

            ListViewItem item;
            foreach (SearchPattern pattern in Settings.SearchPatterns)
            {
                item = new ListViewItem(pattern.Description);
                item.SubItems.Add(pattern.Pattern);

                lvFileTypes.Items.Add(item);
            }

            lvFileTypes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
