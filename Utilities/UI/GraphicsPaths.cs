using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace HL.Utilities.UI
{
    public class GraphicsPaths
    {
        /// <summary>
        /// Returns a rounded rectangle path with the specified corner radius
        /// </summary>
        /// <param name="rectangle">The rectangle to draw the rounded rectangle on</param>
        /// <param name="cornerRadius">The radius of the corners. A higher value yields larger rounded corners</param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundedRectangle(RectangleF rectangle, int cornerRadius)
        {
            int x = (int)rectangle.X;
            int y = (int)rectangle.Y;
            int width = (int)rectangle.Width;
            int height = (int)rectangle.Height;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            // Top left corner
            p.AddArc(x, y, cornerRadius, cornerRadius, 180, 90);

            // Top right corner
            p.AddArc(x + width - cornerRadius, y, cornerRadius, cornerRadius, 270, 90);

            // Bottom right corner
            p.AddArc(x + width - cornerRadius, y + height - cornerRadius, cornerRadius, cornerRadius, 0, 90);

            // Bottom left corner
            p.AddArc(x, y + height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            p.CloseFigure();
            return p;
        }

        /// <summary>
        /// Returns a rectangle path where the top left and top right corners are rounded with the specified corner radius
        /// </summary>
        /// <param name="rectangle">The rectangle to draw the rounded rectangle on</param>
        /// <param name="cornerRadius">The radius of the corners. A higher value yields larger rounded corners</param>
        /// <returns></returns>
        public static GraphicsPath CreateTopRoundedRectangle(RectangleF rectangle, int cornerRadius)
        {
            int x = (int)rectangle.X;
            int y = (int)rectangle.Y;
            int width = (int)rectangle.Width;
            int height = (int)rectangle.Height;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            // Top left corner
            p.AddArc(x, y, cornerRadius, cornerRadius, 180, 90);

            // Top right corner
            p.AddArc(x + width - cornerRadius, y, cornerRadius, cornerRadius, 270, 90);

            // Bottom 
            p.AddLine(x + width, y + height, x, y + height);

            p.CloseFigure();
            return p;
        }

        /// <summary>
        /// Returns a rectangle path where the bottom left and bottom right corners are rounded with the specified corner radius
        /// </summary>
        /// <param name="rectangle">The rectangle to draw the rounded rectangle on</param>
        /// <param name="cornerRadius">The radius of the corners. A higher value yields larger rounded corners</param>
        /// <returns></returns>
        public static GraphicsPath CreateBottomRoundedRectangle(RectangleF rectangle, int cornerRadius)
        {
            int x = (int)rectangle.X;
            int y = (int)rectangle.Y;
            int width = (int)rectangle.Width;
            int height = (int)rectangle.Height;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            // Top 
            p.AddLine(x, y, x + width, y);

            // Bottom right corner
            p.AddArc(x + width - cornerRadius, y + height - cornerRadius, cornerRadius, cornerRadius, 0, 90);

            // Bottom left corner
            p.AddArc(x, y + height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            p.CloseFigure();
            return p;
        }

        /// <summary>
        /// Returns a path that draws a collar used on weight lifting bars
        /// </summary>
        /// <param name="rectangle">The bounds of the collar</param>
        /// <returns></returns>
        public static GraphicsPath CreateCollarPath(RectangleF rectangle)
        {
            int x = (int)rectangle.X;
            int y = (int)rectangle.Y;
            int width = (int)rectangle.Width;
            int height = (int)rectangle.Height;
            int screwWidth = width / 2;
            int screwHeight = height / 4;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            p.AddLine(x, y + screwHeight, x + screwWidth / 2, y + screwHeight);
            p.AddLine(width - screwWidth/2, y, width, y + screwHeight/2);
            p.AddLine(width - screwWidth/2, y + screwHeight, width, y + screwHeight);

            p.AddLine(width, height - screwHeight, width - screwWidth/2, height - screwHeight);
            p.AddLine(width, height - screwHeight/2, width - screwWidth/2, height);
            p.AddLine(x + screwWidth / 2, height - screwHeight, x, height - screwHeight);            

            p.CloseFigure();
            return p;
        }

        /// <summary>
        /// Returns a path that draws a collar used on weight lifting bars
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundedCollarPath(RectangleF rectangle)
        {
            int x = (int)rectangle.X;
            int y = (int)rectangle.Y;
            int width = (int)rectangle.Width;
            int height = (int)rectangle.Height;
            int screwWidth = width / 2;
            int screwHeight = height / 4;
            int cornerRadius = 8;
            int topBottomCornerRadius = 10;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            // Top part            
            p.AddArc(x, y + screwHeight, cornerRadius, cornerRadius, 180, 90);
            p.AddLine(x + cornerRadius, y + screwHeight, x + screwWidth / 2, y + screwHeight);
            
            p.AddArc(x + screwWidth / 2, y, topBottomCornerRadius, topBottomCornerRadius, 180, 90);
            p.AddArc(x + width - width/4 - topBottomCornerRadius, y, topBottomCornerRadius, topBottomCornerRadius, 270, 90);
            
            p.AddLine(x + width - screwWidth / 2, y + screwHeight, x + width - cornerRadius, y + screwHeight);
            p.AddArc(x + width - cornerRadius, y + screwHeight, cornerRadius, cornerRadius, 270, 90);
            
            // Bottom part            
            p.AddArc(x + width - cornerRadius, y + height - screwHeight - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            p.AddLine(x + width - cornerRadius, y + height - screwHeight, x + width - screwWidth / 2, y + height - screwHeight);
            
            p.AddArc(x + width - width / 4 - topBottomCornerRadius, y + height - topBottomCornerRadius, topBottomCornerRadius, topBottomCornerRadius, 0, 90);
            p.AddArc(x + screwWidth/2, y + height - topBottomCornerRadius, topBottomCornerRadius, topBottomCornerRadius, 90, 90);            

            p.AddLine(x + screwWidth / 2, y + height - screwHeight, x + cornerRadius, y + height - screwHeight);
            p.AddArc(x, y + height - screwHeight - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            p.CloseFigure();
            return p;
        }      
    }
}
