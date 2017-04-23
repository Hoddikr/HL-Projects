using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.FileComparer.Controls.EventArguments;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Controls
{
    public partial class CompareResultsControl : UserControl
    {
        private List<PossibleMatch> matches;
        private const int matchesSpacing = 5;       
        private Font fileFont;        
        private bool mouseIsDown;
        private int firstMatchIndex = 0;
        private Bitmap graphicsImage; // Used to retrieve a graphics object for measuring nested components

        public delegate void MatchClickedHandler(object sender, MatchClickEventArgs args);

        /// <summary>
        /// Occurs when a match within the component is clicked
        /// </summary>        
        public event MatchClickedHandler MatchClicked;

        public CompareResultsControl()
        {
            InitializeComponent();
            
            matches = new List<PossibleMatch>();            
            //fileFont = new Font(new FontFamily("Segoe UI"), 8f, FontStyle.Regular);

            DoubleBuffered = true;
            graphicsImage = new Bitmap(4, 4);
        }

        /// <summary>
        /// Returns number of matches
        /// </summary>
        [Browsable(false)]
        public int MatchCount
        {
            get { return matches.Count; }
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

        /// <summary>
        /// Autosizes the matches so that the separator respects the widest match
        /// </summary>
        public void AutosizeMatches()
        {
            float maxWidth = 0f;
            using (Graphics g = Graphics.FromImage(graphicsImage))
            {
                foreach (PossibleMatch match in matches)
                {
                    float currentWidth = match.MeasureFileShortWidth(g, fileFont);

                    if (currentWidth > maxWidth)
                    {
                        maxWidth = currentWidth;
                    }
                }
            }

            matches.ForEach(p => p.MaxFileShortWidth = maxWidth);
            Invalidate();
        }

        private RectangleF BoundsF
        {
            get { return new RectangleF(0, 0, Width, Height); }
        }

        protected override void OnLoad(EventArgs e)
        {
            fileFont = new Font(this.Font.FontFamily, 8f, FontStyle.Regular);

            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;            

            int currentPos = 2;
            int visibleMatches = 0;
            bool vScrollBarEnabled = firstMatchIndex > 0;
            bool lastMatchFullyVisible = false;

            // Reset visibility for all matches. This is done so that after drawing each match
            // we can easily perform actions such as mouse clicks only on currently visible matches
            matches.ForEach(p => p.Visible = false);

            for(int i = firstMatchIndex; i < matches.Count; i++)
            {
                PossibleMatch match = matches[i];

                match.Draw(e.Graphics, fileFont, 2, currentPos, Width - vScrollBar.Width - 5);
                currentPos += match.Height + matchesSpacing;

                if (currentPos > Size.Height)
                {
                    vScrollBarEnabled = true;                    
                    break;
                }

                // Used to stop the "LargeChange" value from decreasing too much
                lastMatchFullyVisible = i == matches.Count - 1;

                visibleMatches++;
            }

            // Only change the state of the control when needed to reduce unnecessary redrawing
            if (vScrollBar.Enabled != vScrollBarEnabled)
            {
                vScrollBar.Enabled = vScrollBarEnabled;
            }

            if (vScrollBarEnabled)
            {
                vScrollBar.Maximum = matches.Count;
                vScrollBar.LargeChange = lastMatchFullyVisible ? visibleMatches + 1 : visibleMatches;
            }

            Rectangle borderRect = new Rectangle(0, 0, Width, Height);
            ControlPaint.DrawBorder3D(e.Graphics, borderRect);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();

            base.OnResize(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                matches.ForEach(p => p.IsPressed = false);

                for (int i = firstMatchIndex; i < matches.Count; i++)
                {
                    if (!matches[i].Visible)
                    {
                        break;
                    }
                    
                    if (matches[i].HitTest(e.Location))
                    {
                        Invalidate();

                        MatchClickEventArgs args = new MatchClickEventArgs(matches[i].Files);
                        MatchClicked?.Invoke(matches[i], args);                        
                        break;
                    }
                }
            }

            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseIsDown = true;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Detect mouse click
            if (mouseIsDown)
            {
                // Mark the match as "clicked" so it is rendered to the user. 
                matches.ForEach(p => p.IsPressed = false);

                for (int i = firstMatchIndex; i < matches.Count; i++)
                {
                    if (!matches[i].Visible)
                    {
                        break;
                    }
                    
                    if (matches[i].HitTest(e.Location))
                    {
                        Invalidate();                           

                        break;
                    }
                }
            }

            mouseIsDown = false;

            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (vScrollBar.Enabled)
            {

                int newValue = vScrollBar.Value - e.Delta/120;
                vScrollBar.Value = newValue > 0 ? Math.Min(newValue, vScrollBar.Maximum - vScrollBar.LargeChange + 1) : 0;
            }

            base.OnMouseWheel(e);
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            firstMatchIndex = vScrollBar.Value;

            Invalidate();
        }
                
    }
}
