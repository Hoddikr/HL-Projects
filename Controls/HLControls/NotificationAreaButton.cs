using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HL.Controls.HLControls
{    
    public class NotificationAreaButton : UserControl
    {
        private bool mouseHovering;
        private const int hoverColorOpacity = 200;

        public NotificationAreaButton()
        {
            DoubleBuffered = true;                        
        }


        [Browsable(true), Category("Appearance"), DefaultValue("")]
        public string Subject { get; set; }

        [Browsable(true), Category("Appearance"), DefaultValue("")]
        public string DateTimeString { get; set; }

        [Browsable(true), Category("Appearance"), 
        DefaultValue(""),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {            
            Graphics g = e.Graphics;                   

            Color textColor = Color.RoyalBlue;

            if (mouseHovering)
            {
                Rectangle hoverBounds = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);

                GraphicsPath hoverPath = Utilities.UI.GraphicsPaths.CreateRoundedRectangle(hoverBounds, 3);
                Brush hoverBrush = new LinearGradientBrush(hoverBounds, Color.FromArgb(hoverColorOpacity, Color.White), Color.FromArgb(hoverColorOpacity, Color.AliceBlue), LinearGradientMode.Vertical);
                Pen hoverBorderPen = new Pen(Color.LightBlue);

                g.FillPath(hoverBrush, hoverPath);
                g.DrawPath(hoverBorderPen, hoverPath);

                hoverPath.Dispose();
                hoverBrush.Dispose();
                hoverBorderPen.Dispose();
            }

            int textLeftPadding = 5;

            // Draw subject
            Font subjectFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
            Point subjectLocation = new Point(textLeftPadding, 5);
            TextRenderer.DrawText(g, Subject, subjectFont, new Point(textLeftPadding, 5), textColor);

            // Draw date and time
            Point dateTimeLocation = new Point(Width - TextRenderer.MeasureText(g, DateTimeString, Font).Width - textLeftPadding, 5);
            TextRenderer.DrawText(g, DateTimeString, Font, dateTimeLocation, textColor);
            
            // Draw content
            Point contentLocation = new Point(textLeftPadding, 5 + TextRenderer.MeasureText(g, Subject, subjectFont).Height + 5);
            TextRenderer.DrawText(g, Text, Font, contentLocation, textColor);
                        
            subjectFont.Dispose();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            bool prevMouseHovering = mouseHovering;

            mouseHovering = true;

            if (prevMouseHovering != mouseHovering)
            {
                Invalidate();
            }

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            bool prevMouseHovering = mouseHovering;

            mouseHovering = false;

            if (prevMouseHovering != mouseHovering)
            {
                Invalidate();
            }

            base.OnMouseLeave(e);
        }
    }
}
