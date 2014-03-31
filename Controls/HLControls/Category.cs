using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HL.Controls.HLControls
{
    internal class Category
    {
        private const int collapsedHeight = 28;
        private const int categoryItemHeight = 24;
        private bool collapsed;
        private bool isHovering;
        private bool containsClickedCategoryItem;
        private RectangleF boundsF;

        public Category()
        {
            CategoryItems = new List<CategoryItem>();
            Text = "";
            collapsed = true;
        }

        public Category(string text, string key)
            : this()
        {
            Text = text;
            Key = key;
        }

        /// <summary>
        /// Indicates wether this category needs to be redrawn
        /// </summary>
        public bool NeedsRedraw { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the category
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the key associated with this category
        /// </summary>
        public string Key { get; set; }

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

        /// <summary>
        /// Gets the current bounds of this category
        /// </summary>
        public RectangleF BoundsF
        {
            get
            {
                return boundsF;
            }
        }

        /// <summary>
        /// Gets the current bounds of this category
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)boundsF.X, (int)boundsF.Y, (int)boundsF.Width + 1, (int)boundsF.Height + 1);
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
        /// Gets wether this category has a currently selected category item
        /// </summary>
        public bool HasSelectedCategoryItem { get; private set; }

        /// <summary>
        /// Gets the description of the currently selected category item. If no category item is currently selected an empty string is returned
        /// </summary>
        public string SelectedCategoryItemDescription { get; private set; }

        /// <summary>
        /// Gets or sets the list of category items belonging to this category
        /// </summary>
        public List<CategoryItem> CategoryItems { get; set; }

        /// <summary>
        /// Checks if the point given is inside the categories header
        /// </summary>
        /// <param name="point">The point to check for</param>
        /// <returns></returns>
        public void HeaderHitTest(Point point)
        {
            NeedsRedraw = false;

            bool headerResult = point.X > boundsF.X && point.X < (boundsF.X + boundsF.Width) &&
                                point.Y > boundsF.Y && point.Y < (boundsF.Y + collapsedHeight);

            if (headerResult)
            {
                Collapsed = !Collapsed;
                NeedsRedraw = true;
                return;
            }

            if (!boundsF.Contains(point))
            {
                return;
            }


            HasSelectedCategoryItem = false;
            SelectedCategoryItemDescription = "";

            foreach (CategoryItem item in CategoryItems)
            {
                if (item.HitTest(point))
                {
                    headerResult = true;
                    HasSelectedCategoryItem = true;
                    SelectedCategoryItemDescription = item.Text;
                }
            }

            NeedsRedraw = headerResult;
        }

        public void Draw(Graphics g, Font font, RectangleF parentBounds, PointF startingLocation)
        {
            if (collapsed)
            {
                boundsF = new RectangleF(startingLocation.X, startingLocation.Y, parentBounds.Width - 1, collapsedHeight - 1);
            }
            else
            {                
                int totalCategoryItemHeight = CategoryItems.Count * categoryItemHeight + 10;

                boundsF = new RectangleF(startingLocation.X, startingLocation.Y, parentBounds.Width - 1, (collapsedHeight + totalCategoryItemHeight) - 1);
                
            }

            GraphicsPath headerPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(boundsF, 10);            
            
            // Draw the header            
            if (collapsed)
            {
                Brush brush = new LinearGradientBrush(boundsF, Color.WhiteSmoke, Color.LightGray, 90f);
                g.FillPath(brush, headerPath);
                brush.Dispose();
            }
            else
            {
                // Header
                RectangleF headerRect = new RectangleF(boundsF.X, boundsF.Y, boundsF.Width, collapsedHeight);
                GraphicsPath expandedHeaderPath = Utilities.UI.GraphicsPaths.CreateTopRoundedRectangle(headerRect, 10);
                Brush headerBrush = new LinearGradientBrush(new Point((int)boundsF.X, (int)boundsF.Y),
                                                            new Point((int)boundsF.X, (int)boundsF.Y + collapsedHeight), 
                                                            Color.WhiteSmoke, 
                                                            Color.LightGray);

                // Category items
                RectangleF categoryItemsRect = new RectangleF(boundsF.X, boundsF.Y + collapsedHeight, boundsF.Width, boundsF.Height - collapsedHeight - 1);
                GraphicsPath categoryItemsPath = Utilities.UI.GraphicsPaths.CreateBottomRoundedRectangle(categoryItemsRect, 10);
                //Brush categoryItemsBrush = new SolidBrush(Color.WhiteSmoke);
                Brush categoryItemsBrush = new SolidBrush(Color.White);

                g.FillPath(headerBrush, expandedHeaderPath);
                g.FillPath(categoryItemsBrush, categoryItemsPath);
                headerBrush.Dispose();
                categoryItemsBrush.Dispose();
                expandedHeaderPath.Dispose();
                categoryItemsPath.Dispose();

                float categoryItemYPosition = boundsF.Y + collapsedHeight + 5;
                // Draw each category item
                foreach (CategoryItem categoryItem in CategoryItems)
                {
                    //Rectangle categoryItemBounds = new Rectangle((int)BoundsF.X + 5, (int)categoryItemYPosition, (int)BoundsF.Width - 10, categoryItemHeight);
                    Rectangle categoryItemBounds = new Rectangle((int)boundsF.X + 3, (int)categoryItemYPosition, (int)boundsF.Width - 6, categoryItemHeight);
                    categoryItem.Draw(g, categoryItemBounds);
                    categoryItemYPosition += categoryItemHeight;
                }
            }

            // Draw border around the control
            GraphicsPath borderPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(boundsF, 10);
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

        internal void MouseHover(Point point)
        {
            NeedsRedraw = false;

            bool itemHover = false;
            bool prevHovering = isHovering;
            isHovering = boundsF.Contains(point);

            foreach(CategoryItem item in CategoryItems)
            {
                item.MouseHover(point);                
            }

            foreach (CategoryItem item in CategoryItems)
            {
                if (item.NeedsRedraw)
                {
                    itemHover = true;
                    break;
                }
            }

            NeedsRedraw = itemHover || isHovering || (prevHovering != isHovering);
        }
    }
}
