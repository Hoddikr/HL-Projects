using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HLControls.UnitGridControl
{
    /// <summary>
    /// A class that holds information about a single cell in the grid
    /// </summary>
    internal class GridCell
    {
        private PointF position;
        private RectangleF boundingBox;       

        public GridCell()
        {
            position = new PointF(0, 0);
            Size = new SizeF(0, 0);            
        }

        public GridCell(PointF position, SizeF size)
        {
            this.position = position;
            Size = size;
            boundingBox = new RectangleF(position, Size);
        }

        public PointF Position 
        { 
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public SizeF Size { get; set; }

        /// <summary>
        /// Returns the rectangle that represents the size and location of this grid cell relative to the <see cref="UnitGridControl"/> that owns it
        /// </summary>
        public RectangleF Bounds
        {
            get
            {
                return boundingBox;
            }
            set
            {
                boundingBox = value;
            }
        }

        /// <summary>
        /// Determines if the specified point is contained within this GridCell
        /// </summary>
        /// <param name="point">The point containing the x and y coordinates to check for</param>
        /// <returns></returns>
        public bool Contains(Point point)
        {
            return boundingBox.Contains(point);
        }

        public bool IsVisible { get; set; }        

        public void Draw(Graphics g)
        {
            if (IsVisible)
            {
                Brush brush = new SolidBrush(Color.LightBlue);
                g.FillRectangle(brush, boundingBox);
                brush.Dispose();
            }
        }

        public void Draw(Graphics g, Color color)
        {
            if (IsVisible)
            {
                Brush brush = new SolidBrush(color);
                g.FillRectangle(brush, boundingBox);
                brush.Dispose();
            }
        }
    }
}
