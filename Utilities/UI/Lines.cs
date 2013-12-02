using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HL.Utilities.UI
{
    public class Lines
    {
        /// <summary>
        /// Draws a dash line from point to point
        /// </summary>
        /// <param name="g">The graphics object to draw on</param>
        /// <param name="startingPoint">The point where the line starts</param>
        /// <param name="endingPoint">The point where the line ends</param>
        /// <param name="lineColor">The color of the line</param>
        public static void DrawDashLine(Graphics g, Point startingPoint, Point endingPoint, Color lineColor)
        {
            Pen pen = new Pen(lineColor);
            pen.Width = 2.0f;
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawLine(pen, startingPoint, endingPoint);

            pen.Dispose();
        }

        /// <summary>
        /// Draws a dash line from point to point
        /// </summary>
        /// <param name="g">The graphics object to draw on</param>
        /// <param name="startingPoint">The point where the line starts</param>
        /// <param name="endingPoint">The point where the line ends</param>
        /// <param name="lineColor">The color of the line</param>
        public static void DrawDashLine(Graphics g, PointF startingPoint, PointF endingPoint, Color lineColor)
        {
            Pen pen = new Pen(lineColor);
            pen.Width = 2.0f;
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawLine(pen, startingPoint, endingPoint);

            pen.Dispose();
        }
    }
}
