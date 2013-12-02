using HLControls.UnitGridControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HL.Controls.UnitGridControl
{
    /// <summary>
    /// Represents an existing rectangle on a UnitGridControl. A GridRectangle exists within the UnitGridControl coordinate system.
    /// </summary>
    internal class GridRectangle
    {        
        private int width;
        private int height;
        private int x;
        private int y;                

        /// <summary>
        /// Creates a new GridRectangle in the UnitGridControl coordinate system.
        /// </summary>
        /// <param name="x">The upper left cell x position</param>
        /// <param name="y">The top y position</param>
        /// <param name="width">The width in number of columns</param>
        /// <param name="height">The height in number of rows</param>
        public GridRectangle(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            Color = Color.Red;
        }

        /// <summary>
        /// Creates a new GridRectangle in the UnitGridControl coordinate system with a given color
        /// </summary>
        /// <param name="x">The upper left cell x position</param>
        /// <param name="y">The top y position</param>
        /// <param name="width">The width in number of columns</param>
        /// <param name="height">The height in number of columns</param>
        /// <param name="color">The color of the rectangle</param>
        public GridRectangle(int x, int y, int width, int height, Color color)
            : this(x, y, width, height)
        {
            Color = color;
        }

        public Color Color { get; set; }
    }
}