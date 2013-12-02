using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HL.Controls.HLControls
{
    internal class CategoryItem
    {
        private EventHandler click;
        private Font font;
        private Font boldFont;
        private Rectangle bounds;
        private bool isPressed = false;
        private bool isHovering = false;
        private const int textIndent = 10;

        public CategoryItem(string text, EventHandler click)
        {
            this.Text = text;
            this.click = click;
            font = new Font("Microsoft Sans Serif", 8f);
            boldFont = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
        }

        /// <summary>
        /// Gets or sets the text on the category item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets the bounding rectangle of this CategoryItem
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
        }

        /// <summary>
        /// Gets wether this CategoryItem is currently pressed
        /// </summary>
        public bool IsPressed
        {
            get
            {
                return isPressed;
            }
        }
         
        public void Draw(Graphics g, Rectangle bounds)
        {
            if (isPressed)
            {
                GraphicsPath hoverPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(bounds, 3);
                Brush hoverBrush = new LinearGradientBrush(bounds, Color.White, Color.LightBlue, LinearGradientMode.Vertical);
                Pen hoverBorderPen = new Pen(Color.CornflowerBlue);

                g.FillPath(hoverBrush, hoverPath);
                g.DrawPath(hoverBorderPen, hoverPath);

                hoverPath.Dispose();
                hoverBrush.Dispose();
                hoverBorderPen.Dispose();
            }
            else if (isHovering)
            {
                //VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
                //renderer.DrawBackground(g, bounds);
                //Rectangle newBounds = new Rectangle(bounds.X + 1, bounds.Y, bounds.Width - 2, bounds.Height - 1);                
                
            }
            
            Rectangle textPosition = new Rectangle(bounds.X + textIndent, bounds.Y, bounds.Width - textIndent, bounds.Height);
            //TextRenderer.DrawText(g, Text, isPressed ? boldFont : font, textPosition, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            TextRenderer.DrawText(g, Text, font, textPosition, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPrefix);
            Size textSize = TextRenderer.MeasureText(Text, font, bounds.Size, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            this.bounds = new Rectangle(bounds.X, bounds.Y, textSize.Width + textIndent, bounds.Height);
            
            //Pen pen = new Pen(Color.Red);
            //g.DrawRectangle(pen, this.bounds);
            //pen.Dispose();
        }

        public bool HitTest(Point point)
        {                        
            isPressed = false;

            if (bounds.Contains(point) && click != null)
            {
                click(this, EventArgs.Empty);
                isPressed = true;
                return true;
            }

            return false;
        }

        internal bool MouseHover(Point point)
        {            
            isHovering = bounds.Contains(point);            
            return isHovering;
        }
    }
}
