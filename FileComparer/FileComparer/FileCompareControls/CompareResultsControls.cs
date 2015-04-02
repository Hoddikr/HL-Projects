using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Controls
{
    /// <summary>
    /// Represents the results of searching for identical files to the user and allows the user to take action on each file
    /// </summary>
    public class CompareResultsControls : UserControl
    {
        private List<PossibleMatches> possibleMatches;
        private const float matchesSpacing = 5; // the space between each group of possible file matches
        private Font fileFont;

        public CompareResultsControls()
        {
            possibleMatches = new List<PossibleMatches>();

            DoubleBuffered = true;

            fileFont = new Font(Font.FontFamily, 8f, FontStyle.Regular);
        }

        /// <summary>
        /// Gets or sets the list of possible file matches that the control should be displayed
        /// </summary>
        public List<PossibleMatches> PossibleMatches
        {
            get
            {
                return possibleMatches;
            }
            set
            {
                possibleMatches = value;
            }
        }

        private RectangleF BoundsF
        {
            get { return new RectangleF(0, 0, Width, Height); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Pen borderPen = new Pen(Color.DarkGray);
            Brush fileTextBrush = new SolidBrush(Color.Black);

            int fileHeight = 20;
            int filesDrawn = 0;

            for(int i = 0; i < possibleMatches.Count; i++)
            {
                foreach (var file in possibleMatches[i].Files)
                {
                    PointF fileLocation = new PointF(0, (filesDrawn * fileHeight) + (i * matchesSpacing));
                    SizeF fileSize = new SizeF(Width, fileHeight);
                    RectangleF fileBounds = new RectangleF(fileLocation, fileSize);
                    StringFormat textFormat = new StringFormat();
                    textFormat.Alignment = StringAlignment.Center | StringAlignment.Near;

                    e.Graphics.DrawString(file.FileName, fileFont, fileTextBrush, fileBounds, textFormat);

                    filesDrawn++;
                }                                                   
            }

            borderPen.Dispose();
            fileTextBrush.Dispose();            
        }
    }
}
