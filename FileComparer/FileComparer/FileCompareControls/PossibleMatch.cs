﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Controls
{
    /// <summary>
    /// Represents a single collection of possible matches that is displayed on the <see cref="CompareResultsControl"/>
    /// </summary>
    public class PossibleMatch
    {
        private List<FileHashPair> files;
        private const int borderPadding = 5;
        private const int matchesSpacing = 5;
        private RectangleF currentBounds;
        private bool mouseMoving = false;
        private Point mousePosition;

        public PossibleMatch(List<FileHashPair> files)
        {
            this.files = files;
            mousePosition = Point.Empty;
        }

        /// <summary>
        /// Gets the height of this match component
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Indicates wether this component is currently visible to the user
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets wether this component is currently pressed
        /// </summary>
        public bool IsPressed { get; set; }

        /// <summary>
        /// Gets the list of files beloning to this match component
        /// </summary>
        public List<FileHashPair> Files => files;        

        /// <summary>
        /// Returns the projected height of this component when it will be drawn
        /// </summary>
        /// <param name="g">The context to draw on</param>
        /// <param name="font">The font to use when drawing text</param>
        /// <returns></returns>
        public float MeasureHeight(Graphics g, Font font)
        {
            // Calculate the height
            float height = 0f;

            foreach (FileHashPair file in files)
            {
                height += g.MeasureString(file.FileName, font).Height;
            }

            height += borderPadding * 2 + ((files.Count - 1) * matchesSpacing);

            return height;
        }

        /// <summary>
        /// Returns the maximum short file name width that this component contains
        /// </summary>
        /// <param name="g">The context to draw on</param>
        /// <param name="font">The font to use when drawing text</param>
        /// <returns></returns>
        public float MeasureFileShortWidth(Graphics g, Font font)
        {
            float maxWidth = 0f;

            foreach (FileHashPair file in files)
            {
                float currentWidth = g.MeasureString(file.FileShortName, font).Width;

                if (currentWidth > maxWidth)
                {
                    maxWidth = currentWidth;
                }
            }

            return maxWidth;
        }

        /// <summary>
        /// Gets or sets the maximum width of the file short section
        /// </summary>
        public float MaxFileShortWidth { get; set; }

        /// <summary>
        /// Indicates wether a point is contained within the current bounds of the component
        /// </summary>
        /// <param name="p">The point to test for</param>
        /// <returns></returns>
        public bool HitTest(Point p)
        {
            IsPressed = currentBounds.Contains(p);            
            return IsPressed;
        }
        
        /// <summary>
        /// Indicates wether the current mouse position triggers a change in the components visual state. This will require an re-draw,
        /// </summary>
        /// <param name="p">The current position of the mouse cursor</param>
        /// <returns>True if the parent control should invalidate it's client area</returns>
        public bool MouseMoveHitTest(Point p)
        {
            mouseMoving = currentBounds.Contains(p);
            mousePosition = p;
            return mouseMoving;
        }


        /// <summary>
        /// Draws this component onto the given graphics context
        /// </summary>
        /// <param name="g">The context to draw on</param>
        /// <param name="font">The font to use when drawing text</param>
        /// <param name="xIndent">The amount in pixels that this component is indented by on the x-axis</param>
        /// <param name="yPos">The y position where this match will be drawn</param>
        /// <param name="width">The width that this component is allowed to have</param>
        public void Draw(Graphics g, Font font, int xIndent, int yPos, int width)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;            

            Visible = true;

            // Calculate the height
            float height = MeasureHeight(g, font);

            RectangleF boundsF = new RectangleF(xIndent, yPos, width, height);

            Brush brush = new SolidBrush(IsPressed ? ColorTranslator.FromHtml("#cfd8dc") : Color.White);
            Brush fileTextBrush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, boundsF.X, boundsF.Y, boundsF.Width, boundsF.Height);

            Pen separatorPen = new Pen(Color.DarkGray);

            PointF currentFileShortPosition = new PointF(borderPadding, yPos + borderPadding);
            PointF currentFilePosistion = new PointF(MaxFileShortWidth + 15, currentFileShortPosition.Y);
            
            foreach (FileHashPair file in files)
            {
                SizeF currentFileSize = g.MeasureString(file.FileSizeString + " MB", font);

                if (mouseMoving)
                {
                    RectangleF currentFileBounds = new RectangleF(boundsF.X, currentFileShortPosition.Y, boundsF.Width, currentFileSize.Height);

                    if (currentFileBounds.Contains(mousePosition))
                    {
                        Pen dottedPen = new Pen(Color.Black, 1.5f);
                        dottedPen.DashStyle = DashStyle.Dot;                        
                        g.DrawRectangle(dottedPen, currentFileBounds.X, currentFileBounds.Y - 1, currentFileBounds.Width, currentFileBounds.Height + 1);
                        dottedPen.Dispose();
                    }
                }

                g.DrawString(file.FileShortName, font, fileTextBrush, currentFileShortPosition);
                g.DrawString(file.FileName, font, fileTextBrush, currentFilePosistion);                

                // Align size strings to the right
                float sizeWidth = currentFileSize.Width;                
                g.DrawString(file.FileSizeString + " MB", font, fileTextBrush, new PointF(boundsF.X + boundsF.Width - sizeWidth - 5, currentFilePosistion.Y));

                float lastFileHeight = matchesSpacing + currentFileSize.Height;                

                currentFileShortPosition.Y += lastFileHeight;
                currentFilePosistion.Y += lastFileHeight;
            }

            g.DrawLine(separatorPen, MaxFileShortWidth + 10, yPos + 3, MaxFileShortWidth + 10, yPos + height - 4);

            Pen borderPen = new Pen(Color.DarkGray);
            g.DrawRectangle(borderPen, boundsF.X, boundsF.Y, boundsF.Width, boundsF.Height);

            Height = (int)height;
            currentBounds = boundsF;

            separatorPen.Dispose();
            borderPen.Dispose();
            fileTextBrush.Dispose();
            brush.Dispose();
        }
    }
}
