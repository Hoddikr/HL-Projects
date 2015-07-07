using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HL.FileComparer.Controls
{
    public partial class FolderBrowser : UserControl
    {
        private List<FolderBrowserItem> folderBrowserItems;

        private const int itemHeight = 30; // each button is 24, add margin of 3 on both sides

        public FolderBrowser()
        {
            folderBrowserItems = new List<FolderBrowserItem>();

            InitializeComponent();

            MaximumFolderItems = 4;

            DoubleBuffered = true;            

            AddFolderBrowserItem();
        }

        [Browsable(true), DefaultValue(4)]
        public int MaximumFolderItems { get; set; }

        /// <summary>
        /// Gets a semi-comma (;) delimited string containing all of the paths entered
        /// </summary>
        [Browsable(false)]
        public string SelectedFolders
        {
            get
            {
                string paths = "";

                for (int i = 0; i < folderBrowserItems.Count; i++)
                {
                    if (!string.IsNullOrEmpty(folderBrowserItems[i].SelectedPath))
                    {
                        paths = paths + (i > 0 && paths != "" ? ";" : "") + folderBrowserItems[i].SelectedPath;
                    }
                }

                return paths;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFolderBrowserItem();
        }

        private void AddFolderBrowserItem()
        {
            FolderBrowserItem item = new FolderBrowserItem();
            //item.RegisterComponents(this);
            folderBrowserItems.Add(item);

            if (folderBrowserItems.Count == MaximumFolderItems)
            {
                btnAdd.Enabled = false;
            }

            SetDeleteEnabled();

            AdjustSize();

            //RefreshItems();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            foreach (FolderBrowserItem item in folderBrowserItems)
            {
                item.Draw(g);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            RefreshItems();
        }

        private void RefreshItems()
        {            
            folderBrowserItems.ForEach(p => p.SetComponentsVisible(false));
            folderBrowserItems.ForEach(p => p.UnRegisterComponents(this));

            for (int i = 0; i < folderBrowserItems.Count; i++)
            {
                folderBrowserItems[i].SetSizeAndPosition(this, 5 + i * itemHeight);

            }

            folderBrowserItems.ForEach(p => p.RegisterComponents(this));
            folderBrowserItems.ForEach(p => p.SetComponentsVisible(true));
        }

        private void AdjustSize()
        {
            Size = new Size(Width, 5 + folderBrowserItems.Count * itemHeight + itemHeight);
        }

        private void SetDeleteEnabled()
        {
            if (folderBrowserItems.Count == 1)
            {
                folderBrowserItems[0].SetDeleteEnabled(false);
            }
            else if(folderBrowserItems.Count > 1)
            {
                folderBrowserItems[0].SetDeleteEnabled(true);
            }
        }

        internal void RemoveItem(FolderBrowserItem item)
        {
            item.Delete(this);
            folderBrowserItems.Remove(item);
            btnAdd.Enabled = true;            

            SetDeleteEnabled();

            AdjustSize();
        }
    }
}
