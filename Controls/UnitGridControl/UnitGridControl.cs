using HL.Controls.UnitGridControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLControls.UnitGridControl
{
    public class UnitGridControl : UserControl
    {
        private const bool drawBorder = true;
        private bool mouseHovering;
        private bool mouseDown;        
        private PointF mouseDownPosition; // The point where the left mouse button was pressed down
        private PointF currentMousePosition; // The current position of the mouse
        private SizeF gridCellSize; 
        private int mouseDragColumns;
        private int mouseDrawRows;
        private GridCell[][] grid;
        private List<GridRectangle> existingRectangles;

        public UnitGridControl()
        {
            DoubleBuffered = true;
            BackColor = Color.Transparent;            
            mouseHovering = false;
            mouseDownPosition = Point.Empty;
            currentMousePosition = Point.Empty;

            Rows = 20;
            Columns = 20;
            grid = new GridCell[Rows][];
            existingRectangles = new List<GridRectangle>();

            int cellWidth = Width / Columns;
            int cellHeight = Height / Rows;
            gridCellSize = new Size(cellWidth, cellHeight);

            mouseDragColumns = 0;
            mouseDrawRows = 0;

            InitializeGrid();
        }

        protected override void OnResize(EventArgs e)
        {
            gridCellSize.Width = (float)Width / (float)Columns;
            gridCellSize.Height = (float)Height / (float)Rows;
            
            UpdateGridSizes();
            base.OnResize(e);
        }

        private bool MouseHovering
        {
            get 
            { 
                return mouseHovering; 
            }
            set 
            { 
                mouseHovering = value;                
            }
        }

        private bool MouseIsDown
        {
            get 
            { 
                return mouseDown; 
            }
            set 
            { 
                mouseDown = value;

                if (!mouseDown)
                {
                    ClearGridVisibility();
                }
            }
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            if (MouseHovering && MouseIsDown)
            {
                //Brush mouseBrush = new SolidBrush(Color.Red);

                //g.FillRectangle(mouseBrush, HL.Utilities.UI.Rectangles.GetRectangle(mouseDownPosition, currentMousePosition));

                //mouseBrush.Dispose();
            }
            
            DrawGridCells(g);

            if (drawBorder)
            {
                Pen borderPen = new Pen(Color.Black);
                borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                borderPen.Width = 2.0f;

                g.DrawRectangle(borderPen, new Rectangle(new Point(ClientRectangle.Location.X + 1, ClientRectangle.Location.Y + 1), new Size(ClientRectangle.Width - 2, ClientRectangle.Height - 2)));
                borderPen.Dispose();
            }
            
            DrawGridLines(g);
            DrawDebugText(g);
        }

        private void DrawGridLines(Graphics g)
        {
            // Calculate space between each column
            float columnSpacing = (float)Width / (float)Columns;

            // Calculate space between each row
            float rowSpacing = (float)Height / (float)Rows;

            float columnXPosition = columnSpacing;
            for (int i = 1; i < Columns; i++)
            {
                HL.Utilities.UI.Lines.DrawDashLine(g, new PointF(columnXPosition, 0), new PointF(columnXPosition, Height), Color.Black);
                columnXPosition += columnSpacing;
            }

            float rowYPosition = rowSpacing;
            for (int i = 1; i < Rows; i++)
            {
                HL.Utilities.UI.Lines.DrawDashLine(g, new PointF(0, rowYPosition), new PointF(Width, rowYPosition), Color.Black);
                rowYPosition += rowSpacing;
            }
        }
        
        private void DrawDebugText(Graphics g)
        {
            //TextRenderer.DrawText(g, mouseDragColumns + " X " + mouseDrawRows, Font, new Point(0, 0), Color.Black);
            TextRenderer.DrawText(g,"Cell width: " + gridCellSize.Width + "\r\n" + "Cell height: " + gridCellSize.Height, Font, new Point(0, 0), Color.Black);
        }

        private void DrawGridCells(Graphics g)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i][j].Draw(g);
                }
            }
        }

        private void InitializeGrid()
        {
            PointF currentPosition = new Point(0,0);            

            for (int i = 0; i < Rows; i++)
            {
                grid[i] = new GridCell[Columns];

                currentPosition.Y = i * gridCellSize.Height;

                for (int j = 0; j < Columns; j++)
                {
                    currentPosition.X = j * gridCellSize.Width;

                    grid[i][j] = new GridCell(new PointF(currentPosition.X, currentPosition.Y), gridCellSize);                    
                }

                currentPosition.X = 0;
            }            
        }

        /// <summary>
        ///  Sets the "IsVisible" on each grid cell and sets it to true for the corresponding mouse position
        /// </summary>
        private void SetGridVisibility()
        {
            RectangleF currentMouseRect = HL.Utilities.UI.Rectangles.GetRectangle(mouseDownPosition, currentMousePosition);

            // Calculate which columns and rows should be visible
            // -1 means that the column/row has not been found
            int startColumn = -1;
            int endColumn = -1;
            int startRow = -1;
            int endRow = -1;

            if (currentMouseRect.Right > Width)
            {
                endColumn = Columns - 1;
            }

            if (currentMouseRect.Bottom > Height)
            {
                endRow = Rows - 1;
            }

            for (int i = 1; i <= Columns; i++)
            {
                if (startColumn == -1 && currentMouseRect.Left <= i * gridCellSize.Width)
                {
                    startColumn = i - 1;
                }

                if (endColumn == -1 && currentMouseRect.Right <= i * gridCellSize.Width)
                {
                    endColumn = i - 1;
                }               
            }

            for (int i = 0; i <= Rows; i++)
            {
                if (startRow == -1 && currentMouseRect.Top <= i * gridCellSize.Height)
                {
                    startRow = i - 1;
                }

                if (endRow == -1 && currentMouseRect.Bottom <= i * gridCellSize.Height)
                {
                    endRow = i - 1;
                }
            }

            if (startRow == -1 || endRow == -1 || startColumn == -1 || endColumn == -1)
            {
                return;
            }

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                {
                    grid[i][j].IsVisible = true;
                }
            }            

            Invalidate();
        }

        /// <summary>
        /// Sets all grid cells visibility to false
        /// </summary>
        private void ClearGridVisibility()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i][j].IsVisible = false;
                }
            }

            Invalidate();
        }

        private void UpdateGridSizes()
        {
            PointF currentPosition = new Point(0, 0);            

            for (int i = 0; i < Rows; i++)
            {                
                currentPosition.Y = i * gridCellSize.Height;

                for (int j = 0; j < Columns; j++)
                {
                    currentPosition.X = j * gridCellSize.Width;

                    grid[i][j].Bounds = new RectangleF(currentPosition, gridCellSize);
                }

                currentPosition.X = 0;
            }

            Invalidate();
        }

        private void CalculateCurrentRowsColumns()
        {
            //int deltaMouseWidth = Math.Abs(mouseDownPosition.X - currentMousePosition.X);
            //int deltaMouseHeight = Math.Abs(mouseDownPosition.Y - currentMousePosition.Y);

            if (!MouseHovering || !MouseIsDown)
            {
                mouseDragColumns = 0;
                mouseDrawRows = 0;
                return;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseIsDown = true;
            mouseDownPosition = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                ClearGridVisibility();
                SetGridVisibility();
            }
            currentMousePosition = e.Location;
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseIsDown = false;            
            base.OnMouseUp(e);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            MouseHovering = false;
            base.OnMouseLeave(e);            
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            MouseHovering = true;
            base.OnMouseEnter(e);            
        }        
    }
}
