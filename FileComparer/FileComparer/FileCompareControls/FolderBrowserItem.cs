﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Controls.Properties;

namespace HL.FileComparer.Controls
{
    
    internal class FolderBrowserItem
    {

        private Size buttonSize;
        private TextBox tbFolder;
        private Button btnRemove;
        private Button btnBrowseFolder;
        private Button btnAdd;

        public FolderBrowserItem(FolderBrowser parent)
        {
            buttonSize = new Size(24, 24);

            tbFolder = new TextBox();
            tbFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            btnRemove = new Button();
            btnRemove.Size = new Size(buttonSize.Width, buttonSize.Height);
            btnRemove.Image = Resources.minus;
            btnRemove.Anchor = AnchorStyles.Right;

            btnAdd = new Button();
            btnAdd.Size = new Size(buttonSize.Width, buttonSize.Height);
            btnAdd.Image = Resources.plus;
            btnAdd.Anchor = AnchorStyles.Right;

            btnBrowseFolder = new Button();
            btnBrowseFolder.Size = new Size(buttonSize.Width, buttonSize.Height);
            //btnBrowseFolder.Text = "...";
            btnBrowseFolder.Image = Resources.folder_horizontal_open;
            btnBrowseFolder.Anchor = AnchorStyles.Right;            

            btnBrowseFolder.Click += BtnBrowseFolderOnClick;
            btnRemove.Click += BtnRemoveOnClick;
            btnAdd.Click += BtnAddOnClick;



            tbFolder.TextChanged += parent.ItemTextChangedHandler;
        }

        private void BtnAddOnClick(object sender, EventArgs eventArgs)
        {
            ((FolderBrowser)btnAdd.Parent).AddFolderBrowserItem();
        }

        /// <summary>
        /// Returns the folder path from this item
        /// </summary>        
        public string SelectedPath { get { return tbFolder.Text.Trim(); } }

        private void BtnRemoveOnClick(object sender, EventArgs eventArgs)
        {
            ((FolderBrowser) btnRemove.Parent).RemoveItem(this);
        }

        private void BtnBrowseFolderOnClick(object sender, EventArgs eventArgs)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {

                if (tbFolder.Text != "")
                {
                    dlg.SelectedPath = tbFolder.Text;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tbFolder.Text = dlg.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Registers the embedded controls of this component to the parent control
        /// </summary>
        /// <param name="parent">The FolderBrowser control that this item belongs to</param>
        public void RegisterComponents(FolderBrowser parent)
        {
            parent.Controls.Add(tbFolder);
            parent.Controls.Add(btnBrowseFolder);
            parent.Controls.Add(btnRemove);
            parent.Controls.Add(btnAdd);
        }

        /// <summary>
        /// Unregisters the embedded controls of this component from the parent control
        /// </summary>
        /// <param name="parent"></param>
        public void UnRegisterComponents(FolderBrowser parent)
        {
            parent.Controls.Remove(tbFolder);
            parent.Controls.Remove(btnBrowseFolder);
            parent.Controls.Remove(btnRemove);
            parent.Controls.Remove(btnAdd);
        }

        /// <summary>
        /// Cleans up resources used by this component from the parent control
        /// </summary>
        /// <param name="parent">The FolderBrowser control that this item belongs to</param>
        public void Delete(FolderBrowser parent)
        {
            UnRegisterComponents(parent);

            btnRemove.Click -= BtnRemoveOnClick;
            btnRemove.Dispose();
            btnRemove = null;

            btnAdd.Click -= BtnAddOnClick;
            btnAdd.Dispose();
            btnAdd = null;

            btnBrowseFolder.Click -= BtnBrowseFolderOnClick;
            btnBrowseFolder.Dispose();
            btnBrowseFolder = null;

            tbFolder.TextChanged -= parent.ItemTextChangedHandler;
            tbFolder.Dispose();
            tbFolder = null;
        }

        /// <summary>
        /// Sets the visible status of this items embedded controls
        /// </summary>
        /// <param name="visible"></param>
        public void SetComponentsVisible(bool visible)
        {
            tbFolder.Visible = btnBrowseFolder.Visible = btnRemove.Visible = btnAdd.Visible = visible;
        }

        /// <summary>
        /// Sets wether the delete button on this item is enabled
        /// </summary>
        /// <param name="enabled"></param>
        public void SetDeleteEnabled(bool enabled)
        {
            btnRemove.Enabled = enabled;
        }

        /// <summary>
        /// Sets wether the add button on this item is enabled
        /// </summary>
        /// <param name="enabled"></param>
        public void SetAddEnabled(bool enabled)
        {
            btnAdd.Enabled = enabled;
        }

        /// <summary>
        /// Refreshes the locations and sizes(if needed) for the components of this item based on the parent control
        /// </summary>
        /// <param name="parent">The FolderBrowser control that this item belongs to</param>
        /// <param name="yPosition">The y position where this item should start</param>
        public void SetSizeAndPosition(FolderBrowser parent, int yPosition)
        {
            int xOffset = 6;

            tbFolder.Location = new Point(xOffset, yPosition + 2);
            tbFolder.Width = parent.Width - 12 - 15 - 3 * buttonSize.Width;
            xOffset = tbFolder.Width + 6 + 6;

            btnBrowseFolder.Location = new Point(xOffset, yPosition);
            xOffset += btnBrowseFolder.Width + 6;

            btnRemove.Location = new Point(xOffset, yPosition);
            xOffset += btnRemove.Width + 6;

            btnAdd.Location = new Point(xOffset, yPosition);
        }

        public void Draw(Graphics g)
        {
            
        }
    }
}
