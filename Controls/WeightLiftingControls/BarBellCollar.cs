using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using HL.Utilities.UI;

namespace HL.Controls.WeightLiftingControls
{
    /// <summary>
    /// Handles drawing of the collar
    /// </summary>
    public class BarBellCollar
    {
        public BarBellCollar()
        {
            
        }

        public void Draw(Graphics g, RectangleF bounds)
        {
            LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.LightGray, Color.DimGray, 90);
            //LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.White, Color.Black, 90);
            //brush.SetSigmaBellShape(0.5f);

            Pen pen = new Pen(Color.DimGray);
            
            GraphicsPath roundedPath = GraphicsPaths.CreateRoundedCollarPath(bounds);

            g.FillPath(brush, roundedPath);
            g.DrawPath(pen, roundedPath);

            RectangleF extraCollarDetails = new RectangleF(bounds.X + bounds.Width / 4, 
                                                           bounds.Y +  bounds.Height / 2 - bounds.Height / 8, 
                                                           bounds.Width / 2, 
                                                           bounds.Height / 4);

            GraphicsPath extraCollarDetailPath = GraphicsPaths.CreateRoundedRectangle(extraCollarDetails, (int)(bounds.Width / 4));

            Brush detailBrush = new LinearGradientBrush(new RectangleF(extraCollarDetails.X, 
                                                                       extraCollarDetails.Y, 
                                                                       extraCollarDetails.Width + 1,
                                                                       extraCollarDetails.Height + 1), 
                                                        Color.LightGray, 
                                                        Color.DimGray, 
                                                        90);

            //((LinearGradientBrush)detailBrush).SetSigmaBellShape(0.5f);
            //Pen detailPen = new Pen(detailBrush);
            Pen detailPen = new Pen(Color.DimGray);
            g.FillPath(detailBrush, extraCollarDetailPath);
            g.DrawPath(detailPen, extraCollarDetailPath);

            detailBrush.Dispose();
            detailPen.Dispose();            
            brush.Dispose();
            pen.Dispose();
        }
    }
}
