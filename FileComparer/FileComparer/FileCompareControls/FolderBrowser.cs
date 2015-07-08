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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFolderBrowserItem();
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            RefreshItems();
        }

        private void RefreshItems()
        {
            //folderBrowserItems.ForEach(p => p.UnRegisterComponents(this));

            for (int i = 0; i < folderBrowserItems.Count; i++)
            {
                folderBrowserItems[i].SetSizeAndPosition(this, 5 + i * itemHeight);
            }

            folderBrowserItems.ForEach(p => p.RegisterComponents(this));

            Invalidate();
        }

        private void AdjustSize()
        {
            folderBrowserItems.ForEach(p => p.UnRegisterComponents(this));

            Size = new Size(Width, 5 + folderBrowserItems.Count * itemHeight);

            //folderBrowserItems.ForEach(p => p.RegisterComponents(this));
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
        }

        internal void ItemTextChangedHandler(object sender, EventArgs args)
        {
            if (FolderSelectionChanged != null)
            {
                FolderSelectionChanged(this, EventArgs.Empty);
            }
        }
    }
}
