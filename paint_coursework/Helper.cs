using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Paint_course_work
{
    internal class Helper
    {
        public Point CheckPictureBoxBounderiesWithMouseCoord(MouseEventArgs e, PictureBox pictureBox1)
        {
            Point startDownLocation = new Point(e.Location.X, e.Location.Y);

            startDownLocation.X = Math.Max(pictureBox1.ClientRectangle.Left + 5, Math.Min(pictureBox1.ClientRectangle.Right - 5, startDownLocation.X));

            startDownLocation.Y = Math.Max(pictureBox1.ClientRectangle.Top + 5, Math.Min(pictureBox1.ClientRectangle.Bottom - 5, startDownLocation.Y));


            return startDownLocation;
        }

        public Point CheckPictureBoxBounderiesWithWidthAndHeight(MouseEventArgs e, PictureBox pictureBox1, int width, int height)
        {
            Point startDownLocation = new Point(e.Location.X, e.Location.Y);

            int leftAndRightBounderies = Math.Max(pictureBox1.ClientRectangle.Left + 5, Math.Min(pictureBox1.ClientRectangle.Right - 5, startDownLocation.X - width - 5));

            int topAndBottomBounderies = Math.Max(pictureBox1.ClientRectangle.Top + 5, Math.Min(pictureBox1.ClientRectangle.Bottom - 5, startDownLocation.Y - height - 5));

            if (startDownLocation.X <= leftAndRightBounderies || startDownLocation.Y >= topAndBottomBounderies)
            {
                startDownLocation.X = leftAndRightBounderies;
                startDownLocation.Y = topAndBottomBounderies;
            }

            return startDownLocation;
        }

        public string returnFunctionCase(string FunctionCase)
        {
            if (FunctionCase != "Draw" && FunctionCase != "Fill" || FunctionCase == "Draw")
            {
                return "Draw";
            }
            else
            {
                return "Fill";
            }
        }

        public IShapes? GetShapeWithHighestPriority(MouseEventArgs e, List<IShapes> AllShapes, HashSet<IShapes> CurrShapesSet)
        {
            IShapes? shapeWithHighestPriority = null;

            foreach (var shape in AllShapes)
            {
                if (shape.Contains(e.X, e.Y) && !CurrShapesSet.Contains(shape))
                {
                    CurrShapesSet.Add(shape);
                }
            }

            shapeWithHighestPriority = CurrShapesSet
                    .OrderByDescending(shape => shape.priority)
                    .FirstOrDefault();

            return shapeWithHighestPriority;
        }

        public void HandleResize(MouseEventArgs e, Form1 form1, List<IShapes> AllShapes, HashSet<IShapes> CurrShapesSet, List<IShapes> ShapesUndo, List<int> ShapesIndexUndoResized)
        {
            string? resizeWidth = null;
            string? resizeHeight = null;

            foreach (var shape in AllShapes)
            {
                if (shape.Contains(e.X, e.Y) && !CurrShapesSet.Contains(shape))
                {
                    CurrShapesSet.Add(shape);
                }
            }

            if (CurrShapesSet.Count > 0)
            {
                bool isWidthNumber = false;
                bool isHeightNumber = false;

                while (!isWidthNumber || !isHeightNumber)
                {
                    form1.ShowDialog();

                    resizeWidth = form1.widthTextBox.Text;
                    resizeHeight = form1.heightTextBox.Text;

                    isWidthNumber = int.TryParse(resizeWidth, out _);
                    isHeightNumber = int.TryParse(resizeHeight, out _);

                    if (!isWidthNumber || !isHeightNumber)
                    {
                        if (resizeWidth != "" && resizeHeight != "")
                        {
                            System.Windows.Forms.MessageBox.Show("Please enter valid numeric values for width and height!");
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (CurrShapesSet.Last().GetType().Equals(typeof(Square)) || CurrShapesSet.Last().GetType().Equals(typeof(Rhombus)))
                    {
                        if (int.Parse(resizeWidth) != int.Parse(resizeHeight))
                        {
                            System.Windows.Forms.MessageBox.Show("Please enter the same numeric values for width and height for square and rhombus!");

                            isWidthNumber = false;
                            isHeightNumber = false;

                            continue;
                        }
                    }
                }

                int newWidth = int.Parse(resizeWidth);
                int newHeight = int.Parse(resizeHeight);

                foreach (var shape in AllShapes)
                {
                    if (shape == CurrShapesSet.Last())
                    {
                        ShapesUndo.Add(shape.Copy());
                        shape.isResized = true;

                        ShapesIndexUndoResized.Add(AllShapes.IndexOf(shape));

                        if (!shape.GetType().Equals(typeof(Line)) && !shape.GetType().Equals(typeof(Square)) && !shape.GetType().Equals(typeof(Rhombus)))
                        {
                            shape.x_width = newWidth;
                            shape.y_height = newHeight;
                        }
                        else if (shape is Square square)
                        {
                            square.x_width = newWidth;
                            square.y_height = newHeight;
                            square.side = newWidth;
                        }
                        else if (shape is Rhombus rhombus)
                        {
                            rhombus.x_width = newWidth;
                            rhombus.y_height = newHeight;
                            rhombus.side = newWidth;
                        }
                        else
                        {
                            shape.x_width = shape.x_coord + newWidth;
                            shape.y_height = shape.y_coord + newHeight;
                        }

                        break;
                    }
                }

                AllShapes.Add(AllShapes[ShapesIndexUndoResized.Last()]);
                AllShapes.RemoveAt(ShapesIndexUndoResized.Last());
            }
        }

        public void HandleDelete(List<IShapes> AllShapes, HashSet<IShapes> CurrShapesSet, List<IShapes> ShapesUndo)
        {
            IShapes? shapeWithHighestPriority = null;

            if (CurrShapesSet.Count > 1)
            {
                shapeWithHighestPriority = CurrShapesSet
                    .OrderBy(shape => shape.priority)
                    .Last();

                if (ShapesUndo.Count <= 20)
                {
                    ShapesUndo.Add(shapeWithHighestPriority);
                    ShapesUndo.Last().isDeleted = true;
                }

                AllShapes.Remove(shapeWithHighestPriority);
                return;
            }
            else
            {
                if (ShapesUndo.Count <= 20)
                {
                    ShapesUndo.Add(CurrShapesSet.First());
                    ShapesUndo.Last().isDeleted = true;
                }

                AllShapes.Remove(CurrShapesSet.First());
            }

            CurrShapesSet.Clear();
        }

    }
}