using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HL.Controls.HLControls
{
    internal class Category
    {
        private const int collapsedHeight = 28;
        private const int categoryItemHeight = 24;
        private bool collapsed;
        private bool isHovering = false;
        private RectangleF bounds;

        public Category()
        {
            CategoryItems = new List<CategoryItem>();
            Text = "";
            collapsed = true;
        }

        public Category(string text)
            : this()
        {
            Text = text;
        }

        /// <summary>
        /// Gets or sets the text displayed on the category
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets the height of the category
        /// </summary>
        public float Height
        {
            get
            {                
                return collapsed ? collapsedHeight : collapsedHeight + CategoryItems.Count * categoryItemHeight + 10;
            }
        }

        public RectangleF Bounds
        {
            get
            {
                return bounds;
            }
        }

        /// <summary>
        /// Gets or sets if this category is collapsed or expanded
        /// </summary>
        public bool Collapsed
        {
            get
            {
                return collapsed;
            }
            set
            {
                collapsed = value;
            }
        }
        

        /// <summary>
        /// Gets or sets the list of category items belonging to this category
        /// </summary>
        public List<CategoryItem> CategoryItems { get; set; }

        /// <summary>
        /// Checks if the point given is inside the categories header
        /// </summary>
        /// <param name="point">The point to check for</param>
        /// <returns></returns>
        public bool HeaderHitTest(Point point)
        {    
            bool headerResult = false;            

            headerResult = point.X > bounds.X && point.X < (bounds.X + bounds.Width) &&
                           point.Y > bounds.Y && point.Y < (bounds.Y + collapsedHeight);

            if (headerResult)
            {
                Collapsed = !Collapsed;
                return true;
            }

            foreach (CategoryItem item in CategoryItems)
            {
                if (item.HitTest(point))
                {
                    headerResult = true;
                }
            }

            return headerResult;
        }

        private GraphicsPath CreateExpandedCategoryPath()
        {
            return null;
        }

        private GraphicsPath CreateCategoryItemsAreaPath()
        {
            return null;
        }

        public void Draw(Graphics g, Font font, RectangleF parentBounds, PointF startingLocation)
        {
            if (collapsed)
            {
                bounds = new RectangleF(startingLocation.X, startingLocation.Y, parentBounds.Width - 1, collapsedHeight - 1);
            }
            else
            {                
                int totalCategoryItemHeight = CategoryItems.Count * categoryItemHeight + 10;

                bounds = new RectangleF(startingLocation.X, startingLocation.Y, parentBounds.Width - 1, (collapsedHeight + totalCategoryItemHeight) - 1);
                
            }

            GraphicsPath headerPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(bounds, 10);            
            
            // Draw the header            
            if (collapsed)
            {
                Brush brush = new LinearGradientBrush(bounds, Color.WhiteSmoke, Color.LightGray, 90f);
                g.FillPath(brush, headerPath);
                brush.Dispose();
            }
            else
            {
                // Header
                RectangleF headerRect = new RectangleF(bounds.X, bounds.Y, bounds.Width, collapsedHeight);
                GraphicsPath expandedHeaderPath = Utilities.UI.GraphicsPaths.CreateTopRoundedRectangle(headerRect, 10);
                Brush headerBrush = new LinearGradientBrush(new Point((int)bounds.X, (int)bounds.Y),
                                                            new Point((int)bounds.X, (int)bounds.Y + collapsedHeight), 
                                                            Color.WhiteSmoke, 
                                                            Color.LightGray);

                // Category items
                RectangleF categoryItemsRect = new RectangleF(bounds.X, bounds.Y + collapsedHeight, bounds.Width, bounds.Height - collapsedHeight - 1);
                GraphicsPath categoryItemsPath = Utilities.UI.GraphicsPaths.CreateBottomRoundedRectangle(categoryItemsRect, 10);
                //Brush categoryItemsBrush = new SolidBrush(Color.WhiteSmoke);
                Brush categoryItemsBrush = new SolidBrush(Color.White);

                g.FillPath(headerBrush, expandedHeaderPath);
                g.FillPath(categoryItemsBrush, categoryItemsPath);
                headerBrush.Dispose();
                categoryItemsBrush.Dispose();
                expandedHeaderPath.Dispose();
                categoryItemsPath.Dispose();

                float categoryItemYPosition = bounds.Y + collapsedHeight + 5;
                // Draw each category item
                foreach (CategoryItem categoryItem in CategoryItems)
                {
                    //Rectangle categoryItemBounds = new Rectangle((int)bounds.X + 5, (int)categoryItemYPosition, (int)bounds.Width - 10, categoryItemHeight);
                    Rectangle categoryItemBounds = new Rectangle((int)bounds.X + 3, (int)categoryItemYPosition, (int)bounds.Width - 6, categoryItemHeight);
                    categoryItem.Draw(g, categoryItemBounds);
                    categoryItemYPosition += categoryItemHeight;
                }
            }

            // Draw border around the control
            GraphicsPath borderPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(bounds, 10);
            Pen pen = new Pen(isHovering ? Color.DimGray : Color.DarkGray);
            g.DrawPath(pen, borderPath);
            borderPath.Dispose();

            Point textLocation = new Point(5, (int)startingLocation.Y + (collapsedHeight - 1) / 2 - (TextRenderer.MeasureText("T", font).Height / 2));
            TextRenderer.DrawText(g, Text, font, textLocation, Color.Black);

            // Draw the category items
            if (!collapsed)
            {
                g.DrawLine(pen, 
                           new Point((int)startingLocation.X, (int)startingLocation.Y + collapsedHeight), 
                           new Point((int)(startingLocation.X + parentBounds.Width), (int)startingLocation.Y + collapsedHeight));                
            }
            
            pen.Dispose();
            headerPath.Dispose();
        }

        internal bool MouseHover(Point point)
        {
            bool itemHover = false;
            isHovering = bounds.Contains(point);

            foreach(CategoryItem item in CategoryItems)
            {
                if (item.MouseHover(point))
                {
                    itemHover = true;
                }
            }

            return itemHover || isHovering;
        }
    }
}
