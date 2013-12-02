using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL.Utilities.UI;

namespace Controls
{
    public class RoundedRectangle : UserControl
    {
        // http://tech.pro/tutorial/656/csharp-creating-rounded-rectangles-using-a-graphics-path

        public enum RectangleCorners
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        private bool showOriginalCollar;

        public RoundedRectangle()
        {
            InitializeComponent();
            showOriginalCollar = true;
        }

        public bool ShowOriginalCollar
        {
            get
            {
                return showOriginalCollar;
            }
            set
            {
                showOriginalCollar = value;
                Invalidate();
            }
        
        }

        public static GraphicsPath Create(int x, int y, int width, int height, int radius, RectangleCorners corners)
        {
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();


            // Top left corner
            if ((corners & RectangleCorners.TopLeft) == RectangleCorners.TopLeft)
            {
                p.AddArc(x, y, 2*radius, 2*radius, 180, 90);
            }
            else
            {
                p.AddLine(x, y + radius, x, y);
                p.AddLine(x, y, x + radius, y);                                
            }

            // Top edge
            //p.AddLine(x + radius, y, x + width - radius, y);

            // Top right corner
            if ((corners & RectangleCorners.TopRight) == RectangleCorners.TopRight)
            {
                p.AddArc(x + width - 2*radius, y, 2*radius, 2*radius, 270, 90);
            }
            else
            {
                p.AddLine(x + width - radius, y, x + width, y);
                p.AddLine(x + width, y, x + width, y + radius);
            }

            // Right edge
            //p.AddLine(x + width, y + radius, x + width, y + height - radius);

            // Bottom right corner
            if ((corners & RectangleCorners.BottomRight) == RectangleCorners.BottomRight)
            {
                p.AddArc(x + width - 2*radius, y + height - 2*radius, 2*radius, 2*radius, 0, 90);
            }
            else
            {
                p.AddLine(x + width, y + height - radius, x + width, y + height);
                p.AddLine(x + width, y + height, x + width - radius, y + height);
            }

            // Bottom edge
            //p.AddLine(x + width - radius, y + height, x + radius, y + height);

            // Bottom left corner
            if ((corners & RectangleCorners.BottomLeft) == RectangleCorners.BottomLeft)
            {
                p.AddArc(x, y + height - 2*radius, radius*2, radius*2, 90, 90);
            }
            else
            {
                p.AddLine(x + radius, y + height, x, y + height);
                p.AddLine(x, y + height, x, y + height - radius);
            }

            // Left edge
            //p.AddLine(x, y + height - radius, x, y + radius);

            p.CloseFigure();
            return p;
        }

        protected override void OnPaint(PaintEventArgs e)
        {            

            Brush brush = new LinearGradientBrush(ClientRectangle, Color.LightGray, Color.DimGray, 90);
            //Pen pen = new Pen(brush);
            Pen pen = new Pen(Color.DimGray);

            RectangleF bounds = new RectangleF(0, 0, Width - 1, Height - 1);
            //GraphicsPath roundedPath = HL.Utilities.UI.GraphicsPaths.CreateRoundedRectangle(bounds, 20);         
            GraphicsPath roundedPath = ShowOriginalCollar ? GraphicsPaths.CreateCollarPath(bounds) : GraphicsPaths.CreateRoundedCollarPath(bounds);   
            //GraphicsPath roundedPath = HL.Utilities.UI.GraphicsPaths.CreateRoundedCollarPath(bounds);        

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(brush, roundedPath);
            e.Graphics.DrawPath(pen, roundedPath);


            if (!showOriginalCollar)
            {
                RectangleF extraCollarDetails = new RectangleF(0 + Width/4, Height/2 - Height/8, Width/2, Height/4);
                GraphicsPath extraCollarDetailPath = GraphicsPaths.CreateRoundedRectangle(extraCollarDetails, Width/4);

                Brush detailBrush =
                    new LinearGradientBrush(
                        new RectangleF(extraCollarDetails.X, extraCollarDetails.Y, extraCollarDetails.Width + 1,
                                       extraCollarDetails.Height + 1), Color.LightGray, Color.DimGray, 90);
                //Pen detailPen = new Pen(detailBrush);
                Pen detailPen = new Pen(Color.DimGray);
                e.Graphics.FillPath(detailBrush, extraCollarDetailPath);
                e.Graphics.DrawPath(detailPen, extraCollarDetailPath);

                detailBrush.Dispose();
                detailPen.Dispose();
            }
            brush.Dispose();
            pen.Dispose();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundedRectangle
            // 
            this.AutoSize = true;
            this.Name = "RoundedRectangle";
            this.ResumeLayout(false);

        }
    }
}
