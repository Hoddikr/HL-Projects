using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HL.FileComparer.Controls
{
    public partial class FolderBrowser : UserControl
    {
        private List<FolderBrowserItem> folderBrowserItems;        
        private const int itemHeight = 30; // each button is 24, add margin of 3 on both sides

        public event EventHandler FolderSelectionChanged;

        public FolderBrowser()
        {
            folderBrowserItems = new List<FolderBrowserItem>();

            InitializeComponent();

            MaximumFolderItems = 4;

            DoubleBuffered = true;            

            AddFolderBrowserItem();
        }

        [Browsable(false)]
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

        internal void AddFolderBrowserItem()
        {
            FolderBrowserItem item = new FolderBrowserItem(this);
            folderBrowserItems.Add(item);

            if (folderBrowserItems.Count == MaximumFolderItems)
            {                
                folderBrowserItems.ForEach(p => p.SetAddEnabled(false));
            }

            SetDeleteEnabled();

            AdjustSize();
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

        private void RefreshItems()
        {
            for (int i = 0; i < folderBrowserItems.Count; i++)
            {
                folderBrowserItems[i].SetSizeAndPosition(this, 5 + i * itemHeight);
            }

            // Since this function is only called after a resize we can safely assume that the controls were removed there
            folderBrowserItems.ForEach(p => p.AddControls(this));

            Invalidate();
        }

        private void AdjustSize()
        {
            folderBrowserItems.ForEach(p => p.RemoveControls(this));

            Size = new Size(Width, 5 + folderBrowserItems.Count * itemHeight);

            RefreshItems();
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

            if (folderBrowserItems.Count < MaximumFolderItems)
            {
                folderBrowserItems.ForEach(p => p.SetAddEnabled(true));
            }

            SetDeleteEnabled();

            AdjustSize();

            FolderSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void ItemTextChangedHandler(object sender, EventArgs args)
        {
            FolderSelectionChanged?.Invoke(this, EventArgs.Empty);            
        }


        /// <summary>
        /// Validates that the paths entered are valid/exist and displays an error for each item that is invalid
        /// </summary>
        /// <returns></returns>
        public bool ValidateSelectedFolders()
        {
            bool result = true;

            folderBrowserItems.ForEach(p => result = result && p.ValidatePath());

            return result;
        }
    }
}
