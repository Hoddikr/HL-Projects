using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using HL.Utilities.UI;

namespace HL.Controls.WeightLiftingControls
{
    /// <summary>
    /// Handles drawing of a weight
    /// </summary>
    public class BarBellWeight
    {

        private const int WeightCornerRadius = 40;
        private const int borderWidth = 4;

        public BarBellWeight()
            : this(Color.White, 0, 0, false)
        {
            
        }

        public BarBellWeight(Color color, int width, int height, bool isSmall)
        {
            IsSmall = isSmall;
            WeightColor = color;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the color of the weight
        /// </summary>
        public Color WeightColor { get; set; }

        /// <summary>
        /// Gets or sets the width of the weight
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the Height of the weight
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Indicates wether this is a small weight
        /// </summary>
        public bool IsSmall { get; set; }

        /// <summary>
        /// Draws this weight object onto the given surface using the Width and Height properties of this weight
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="x">The uppert left coordinate of the rectangle that this weight will be drawn onto</param>
        /// <param name="y">The top coordinate of the rectangle that this weight will be drawn onto</param>
        public void Draw(Graphics g, int x, int y)
        {            
            Pen weightBorderPen = new Pen(Color.Black, borderWidth);

            RectangleF redWeightBounds = new RectangleF(x, y, Width - 1, Height - 1);
            RectangleF redWeightPenBounds = new RectangleF(weightBorderPen.Width / 2 - 1,
                                                           weightBorderPen.Width / 2 - 1,
                                                           Width - weightBorderPen.Width / 2 - 2,
                                                           Height - weightBorderPen.Width / 2 - 2);

            GraphicsPath redWeightPath = GraphicsPaths.CreateRoundedRectangle(redWeightBounds, WeightCornerRadius);
            GraphicsPath redWeightPenPath = GraphicsPaths.CreateRoundedRectangle(redWeightPenBounds, WeightCornerRadius);

            Brush redWeightBrush = new SolidBrush(WeightColor);
            //Brush redWeightBrush = new LinearGradientBrush(redWeightBounds, Color.Red, Color.DarkRed, LinearGradientMode.Horizontal);
            g.FillPath(redWeightBrush, redWeightPath);
            g.DrawPath(weightBorderPen, redWeightPenPath);

            redWeightBrush.Dispose();
            redWeightPath.Dispose();
            weightBorderPen.Dispose();
        }

        /// <summary>
        /// Draws this weight object onto the given surface using the recangle given as the bounds for the weight instead of 
        /// using the Width and Height properties
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds to draw this weight object into</param>
        public void Draw(Graphics g, RectangleF bounds)
        {
            Pen weightBorderPen = new Pen(Color.Black, borderWidth);

            RectangleF redWeightBounds = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            //RectangleF redWeightPenBounds = new RectangleF(bounds.X + weightBorderPen.Width / 2 - 1,
            //                                               bounds.Y + weightBorderPen.Width / 2 - 1,
            //                                               bounds.Width - weightBorderPen.Width / 2 - 2,
            //                                               bounds.Height - weightBorderPen.Width / 2 - 2);
            RectangleF redWeightPenBounds = new RectangleF(bounds.X + weightBorderPen.Width / 2 - 1,
                                                           bounds.Y + weightBorderPen.Width / 2 - 1,
                                                           bounds.Width - weightBorderPen.Width / 2,
                                                           bounds.Height - weightBorderPen.Width / 2);

            GraphicsPath redWeightPath = GraphicsPaths.CreateRoundedRectangle(redWeightBounds, WeightCornerRadius);
            GraphicsPath redWeightPenPath = GraphicsPaths.CreateRoundedRectangle(redWeightPenBounds, WeightCornerRadius);

            Brush redWeightBrush = new SolidBrush(WeightColor);
            //Brush redWeightBrush = new LinearGradientBrush(redWeightBounds, Color.Red, Color.DarkRed, LinearGradientMode.Horizontal);
            g.FillPath(redWeightBrush, redWeightPath);
            g.DrawPath(weightBorderPen, redWeightPenPath);

            redWeightBrush.Dispose();
            redWeightPath.Dispose();
            weightBorderPen.Dispose();
        }
    }
}
