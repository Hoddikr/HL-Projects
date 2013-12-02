using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL.Controls.WeightLiftingControls;
using HL.Utilities.UI;

namespace Controls
{
    public partial class BarBell : UserControl
    {
        /*
         * The default maximum weight used in previous version of the time and loadout loading display was:
         * 8x large weights
         * 1x small weight
         * 1x collar
         * 
         * The weights are drawn from left to right
         */

        private const float BarHeightPercentage = 15f;
        private const int WeightCornerRadius = 40;
        
        // Note: the combined values of 
        private const float LargeWeightWidthRatio = 0.1f; // at max, 8 large weights
        private const float SmallWeightWidthRatio = 0.08f; // at max, 1 small weigt
        private const float CollarWidthRatio = 0.12f; // at max, 1 collar

        private const float SmallWeightHeightRatio = 0.8f;
        private const float CollarHeightRatio = 0.62f;

        private int largeWeightWidth = 0;
        private int smallWeightWidth = 0;
        private int collarWidth = 0;

        private int largeWeightHeight = 0;
        private int smallWeightHeight = 0;
        private int collarHeight = 0;

        private int collarIndex;

        private List<BarBellWeight> weights; 

        public BarBell()
        {
            InitializeComponent();

            collarIndex = -1;
            SetStyle(ControlStyles.DoubleBuffer, true);
            CalculateSizes();
            weights = new List<BarBellWeight>();            
        }

        /// <summary>
        /// Adds a weight to the control
        /// </summary>
        /// <param name="barBellWeight">The weight object to add</param>
        public void AddWeight(BarBellWeight barBellWeight)
        {
            weights.Add(barBellWeight);
            Invalidate();
        }

        /// <summary>
        /// Adds a large weight with the given color to the control
        /// </summary>
        /// <param name="color">The color of the large weight</param>
        public void AddLargeWeight(Color color)
        {
            BarBellWeight weight = new BarBellWeight(color, 0, 0, false);
            weights.Add(weight);
            Invalidate();
        }

        /// <summary>
        /// Adds a large weight with the given color to the control
        /// </summary>
        /// <param name="color">The color of the large weight</param>
        public void AddSmallWeight(Color color)
        {
            BarBellWeight weight = new BarBellWeight(color, 0, 0, true);
            weights.Add(weight);
            Invalidate();
        }

        /// <summary>
        /// Sets the position of the collar. When called this sets the position to be after that last added weight.
        /// </summary>
        public void SetCollar()
        {
            collarIndex = weights.Count - 1;
            Invalidate();
        }

        /// <summary>
        /// Clears all weights and the collar from the control
        /// </summary>
        public void Clear()
        {
            collarIndex = -1;
            weights.Clear();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            int xOffSet = 0;
            int smallWeightYOffset = (Height - smallWeightHeight) / 2;
            int collarWeightYOffset = (Height - collarHeight) / 2;

            for (int i = 0; i < weights.Count; i++)
            {
                RectangleF largeWeightBounds = new RectangleF(xOffSet, 0, largeWeightWidth - 1, largeWeightHeight - 1);
                RectangleF smallWeightBounds = new RectangleF(xOffSet, smallWeightYOffset, smallWeightWidth - 1, smallWeightHeight - 1);                

                weights[i].Draw(e.Graphics, weights[i].IsSmall ? smallWeightBounds : largeWeightBounds );

                xOffSet += weights[i].IsSmall ? smallWeightWidth : largeWeightWidth;

                if (collarIndex == i)
                {
                    RectangleF collarBounds = new RectangleF(xOffSet, collarWeightYOffset, collarWidth - 1, collarHeight - 1);
                    BarBellCollar collar = new BarBellCollar();
                    collar.Draw(e.Graphics, collarBounds);

                    xOffSet += collarWidth;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            CalculateSizes();
            Invalidate();
        }

        private void CalculateSizes()
        {
            largeWeightWidth = (int)(Width * LargeWeightWidthRatio);
            smallWeightWidth = (int)(Width * SmallWeightWidthRatio);
            collarWidth = (int)(Width * CollarWidthRatio);

            largeWeightHeight = Height;
            smallWeightHeight = (int)(SmallWeightHeightRatio * Height);
            collarHeight = (int)(CollarHeightRatio * Height);
        }
    }
}
