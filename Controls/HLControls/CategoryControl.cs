using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HL.Controls.HLControls
{
    public class CategoryControl : UserControl
    {
        Font categoryFont;
        Font categoryItemFont;
        private const int categorySpacing = 5;
        private Dictionary<string, Category> categories;
        private bool mouseIsDown = false;

        public CategoryControl()
        {
            DoubleBuffered = true;

            categoryFont = new Font(Font.FontFamily, 11f, FontStyle.Regular);            
            categories = new Dictionary<string, Category>();            
            
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
                categories.Add(key, new Category(description));
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
                bool needsRedraw = false;
                // hit test for each category header
                foreach (Category category in categories.Values)
                {
                    if (category.HeaderHitTest(e.Location))
                    {                        
                        needsRedraw = true;
                    }
                }

                if(needsRedraw)
                {
                    Invalidate();
                }
            }

            mouseIsDown = false;
            
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool itemHover = false;;

            foreach (Category category in categories.Values)
            {
                if(category.MouseHover(e.Location))
                {
                    itemHover = true;
                }
            }

            if(itemHover)
            {
                Invalidate();
            }

            base.OnMouseMove(e);
        }
    }
}
