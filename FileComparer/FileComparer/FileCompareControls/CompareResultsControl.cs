using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Controls
{
    public partial class CompareResultsControl : UserControl
    {
        private List<PossibleMatch> matches;
        private const int matchesSpacing = 5;       
        private Font fileFont;
        private bool vScrollBarEnabled;
        private int firstMatchIndex = 0;

        public CompareResultsControl()
        {
            InitializeComponent();
            
            matches = new List<PossibleMatch>();
            fileFont = new Font(Font.FontFamily, 8f, FontStyle.Regular);

            DoubleBuffered = true;
        }

        /// <summary>
        /// Adds a set of possible file matches to the control
        /// </summary>
        /// <param name="listOfMatches"></param>
        public void AddMatches(List<FileHashPair> listOfMatches)
        {
            matches.Add(new PossibleMatch(listOfMatches));
            Invalidate();
        }

        /// <summary>
        /// Clears all matches from the control
        /// </summary>
        public void ClearMatches()
        {
            matches.Clear();
            Invalidate();
        }

        private RectangleF BoundsF
        {
            get { return new RectangleF(0, 0, Width, Height); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;            

            int currentPos = 0;

            // Detect if we need to show the last match. This is done because the last result can clip below the 
            // client area when we have reached the end.
            if (vScrollBarEnabled && vScrollBar.Value > 0)
            {
                int testPos = 0;
                int lastMatchHeight = 0;
                bool drawLastMatch = true;

                for (int i = firstMatchIndex; i < matches.Count; i++)
                {
                    lastMatchHeight = (int) matches[i].MeasureHeight(e.Graphics, fileFont);

                    if (testPos > Height)
                    {
                        drawLastMatch = false;
                        break;
                    }

                    testPos += lastMatchHeight + matchesSpacing;
                }

                if (drawLastMatch)
                {
                    //Starting posistion of the last match is actually above the "testPos"
                    int lastMatchStartPos = testPos - lastMatchHeight - matchesSpacing;
                    int lastMatchDelta = Height - lastMatchStartPos;
                    int vIndent = lastMatchHeight - lastMatchDelta;

                    currentPos -= vIndent + matchesSpacing;
                }
            }

            for(int i = firstMatchIndex; i < matches.Count; i++)
            {
                PossibleMatch match = matches[i];

                match.Draw(e.Graphics, fileFont, currentPos, Width - vScrollBar.Width);
                currentPos += match.Height + matchesSpacing;

                if (currentPos > Height)
                {
                    vScrollBarEnabled = true;
                    break;
                }
            }


            // Only change the state of the control when needed to reduce unnecessary redrawing
            if (vScrollBar.Enabled != vScrollBarEnabled)
            {
                vScrollBar.Enabled = true;
            }

            if (vScrollBarEnabled)
            {
                vScrollBar.Maximum = matches.Count;
            }
            Rectangle borderRect = new Rectangle(0, 0, Width, Height);
            ControlPaint.DrawBorder3D(e.Graphics, borderRect);

        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            firstMatchIndex = vScrollBar.Value;

            Invalidate();
        }
    }
}
