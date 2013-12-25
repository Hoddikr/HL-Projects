using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL.Controls.HLControls.EventArguments;

namespace HL.Controls.HLControls
{
    public class CategoryControl : UserControl
    {
        Font categoryFont;
        Font categoryItemFont;
        private const int categorySpacing = 5;
        private Dictionary<string, Category> categories;
        private bool mouseIsDown = false;
        private string lastSelectedCategoryItemDescription;

        public delegate void SelectionChangedDelegate(object sender, SelectionChangedEventArgs args);

        /// <summary>
        /// Occurs when the currently selected category item is changed
        /// </summary>
        public event SelectionChangedDelegate SelectionChanged;
        
        public CategoryControl()
        {
            DoubleBuffered = true;

            categoryFont = new Font(Font.FontFamily, 11f, FontStyle.Regular);            
            categories = new Dictionary<string, Category>();
            lastSelectedCategoryItemDescription = "";

        }

        private RectangleF BoundsF
        {
            get
            {
                return new RectangleF(0, 0, Width, Height);
            }
        }

        /// <summary>
        /// Adds a category with the given key and description
        /// </summary>
        /// <param name="key">A value used to uniquely identify the category</param>
        /// <param name="description">The description text that is displayed to the user on the control</param>
        public void AddCategory(string key, string description)
        {
            if (!categories.ContainsKey(key))
            {
                categories.Add(key, new Category(description, key));
            }

            Invalidate();
        }

        /// <summary>
        /// Adds a category item to a category
        /// </summary>
        /// <param name="categoryKey">The key that identifies the category</param>
        /// <param name="itemDescription">The description text for the category item</param>
        /// <param name="categoryItemClicked">Occurs when the category item is clicked</param>
        public void AddCategoryItem(string categoryKey, string itemDescription, EventHandler categoryItemClicked)
        {
            if (categories.ContainsKey(categoryKey))
            {
                categories[categoryKey].CategoryItems.Add(new CategoryItem(itemDescription, categoryItemClicked));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;


            PointF currentCategoryLocation = new PointF(0, 0);
            
            foreach (Category category in categories.Values)
            {
                category.Draw(e.Graphics, categoryFont, BoundsF, currentCategoryLocation);
                currentCategoryLocation.Y += category.Height + categorySpacing;
            }            
        }

        protected virtual void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            SelectionChangedDelegate handler = SelectionChanged;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseIsDown = true;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Mouse was clicked
            if (mouseIsDown)
            {                
                string prevSelectedCategoryItemDescription = lastSelectedCategoryItemDescription;
                string selectedCategoryDescription = "";
                string selectedCategoryKey = "";

                // hit test for each category header
                foreach (Category category in categories.Values)
                {
                    category.HeaderHitTest(e.Location);

                    if (category.HasSelectedCategoryItem)
                    {
                        lastSelectedCategoryItemDescription = category.SelectedCategoryItemDescription;
                        selectedCategoryDescription = category.Text;
                        selectedCategoryKey = category.Key;
                    }
                }

                CheckForRedraw();

                if (prevSelectedCategoryItemDescription != lastSelectedCategoryItemDescription)
                {
                    SelectionChangedEventArgs args = new SelectionChangedEventArgs();
                    args.CategoryDescription = selectedCategoryDescription;
                    args.CategoryKey = selectedCategoryKey;

                    OnSelectionChanged(args);
                }
            }

            mouseIsDown = false;
            
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {            
            foreach (Category category in categories.Values)
            {
                category.MouseHover(e.Location);                
            }
            
            CheckForRedraw();

            base.OnMouseMove(e);
        }

        private void CheckForRedraw()
        {
            bool redraw = false;

            foreach (Category category in categories.Values)
            {
                if (category.NeedsRedraw)
                {
                    redraw = true;
                    break;
                }
            }

            if (redraw)
            {
                Invalidate();
            }
        }
    }
}
