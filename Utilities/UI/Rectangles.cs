using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HL.Utilities.UI
{
    public class Rectangles
    {
        /// <summary>
        /// Creates a rectangle between two given points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Rectangle GetRectangle(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);

            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);

            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Creates a rectangle between two given points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static RectangleF GetRectangle(PointF p1, PointF p2)
        {
            float x = Math.Min(p1.X, p2.X);
            float y = Math.Min(p1.Y, p2.Y);

            float width = Math.Abs(p1.X - p2.X);
            float height = Math.Abs(p1.Y - p2.Y);

            return new RectangleF(x, y, width, height);
        }
    }
}
