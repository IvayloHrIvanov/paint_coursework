using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Paint_course_work.service;

namespace Paint_course_work
{
    internal class FigureCreator
    {
        public void AddOrUpdateShape(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, IShapesService shape, string FunctionCase)
        {
            if (FunctionCase == "Move")
            {
                AllShapes.Remove(shapeWithHighestPriority);
            }

            AllShapes.Add(shape);
        }

        public Rectangle? DrawOrFillRectangle(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            Rectangle? rectangle = new Rectangle(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                colorPicker.Color, AllShapes.Count);

            rectangle.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                rectangle.isFilled = true;
            }

            return rectangle;
        }

        public Rectangle? CopyOrMoveRectangle(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Rectangle? rectangle = new Rectangle(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                rectangle.thickness = thickness;
                rectangle.isFilled = shapeWithHighestPriority.isFilled;

                return rectangle;
            }

            return null;
        }

        private float BiggerAxis(Point StartDownLocation, Point MouseDownCurrLocation)
        {
            if (Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X) > Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y))
            {
                return Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X);
            }
            else
            {
                return Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y);
            }
        }

        public Square? DrawOrFillSquare(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            Square? square = new Square(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                BiggerAxis(StartDownLocation, MouseDownCurrLocation), colorPicker.Color, AllShapes.Count);


            square.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                square.isFilled = true;
            }

            return square;
        }

        public Square? CopyOrMoveSquare(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Square? square = new Square(Point1.X, Point1.Y, Point2.X, colorPicker.Color, AllShapes.Count);

                square.thickness = thickness;
                square.isFilled = shapeWithHighestPriority.isFilled;

                return square;
            }

            return null;
        }

        public Rhombus? DrawOrFillRhombus(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            Rhombus? rhombus = new Rhombus(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                BiggerAxis(StartDownLocation, MouseDownCurrLocation), colorPicker.Color, AllShapes.Count);

            rhombus.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                rhombus.isFilled = true;
            }

            return rhombus;
        }

        public Rhombus? CopyOrMoveRhombus(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Rhombus? rhombus = new Rhombus(Point1.X, Point1.Y, Point2.X, colorPicker.Color, AllShapes.Count);

                rhombus.thickness = thickness;
                rhombus.isFilled = shapeWithHighestPriority.isFilled;

                return rhombus;
            }

            return null;
        }

        public RightAngleTriangle? DrawOrFillRightAngleTriangle(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            RightAngleTriangle rightAngleTriangle = new RightAngleTriangle(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                colorPicker.Color, AllShapes.Count);

            rightAngleTriangle.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                rightAngleTriangle.isFilled = true;
            }

            return rightAngleTriangle;
        }

        public RightAngleTriangle? CopyOrMoveRightAngleTriangle(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                RightAngleTriangle rightAngleTriangle = new RightAngleTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                rightAngleTriangle.thickness = thickness;
                rightAngleTriangle.isFilled = shapeWithHighestPriority.isFilled;

                return rightAngleTriangle;
            }

            return null;
        }

        public ObtuseTriangle? DrawOrFillObtuseTriangle(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            ObtuseTriangle obtuseTriangle = new ObtuseTriangle(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                colorPicker.Color, AllShapes.Count);

            obtuseTriangle.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                obtuseTriangle.isFilled = true;
            }

            return obtuseTriangle;
        }

        public ObtuseTriangle? CopyOrMoveObtuseTriangle(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                ObtuseTriangle obtuseTriangle = new ObtuseTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                obtuseTriangle.thickness = thickness;
                obtuseTriangle.isFilled = shapeWithHighestPriority.isFilled;

                return obtuseTriangle;
            }

            return null;
        }

        public EquilateralTriangle? DrawOrFillEquilateralTriangle(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            EquilateralTriangle equilateralTriangle = new EquilateralTriangle(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                colorPicker.Color, AllShapes.Count);

            equilateralTriangle.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                equilateralTriangle.isFilled = true;
            }

            return equilateralTriangle;
        }

        public EquilateralTriangle? CopyOrMoveEquilateralTriangle(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                EquilateralTriangle equilateralTriangle = new EquilateralTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                equilateralTriangle.thickness = thickness;
                equilateralTriangle.isFilled = shapeWithHighestPriority.isFilled;

                return equilateralTriangle;
            }

            return null;
        }

        public Ellipse? DrawOrFillEllipse(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            Ellipse ellipse = new Ellipse(
                Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                colorPicker.Color, AllShapes.Count);

            ellipse.thickness = thickness;

            if (FunctionCase == "Fill")
            {
                ellipse.isFilled = true;
            }

            return ellipse;
        }

        public Ellipse? CopyOrMoveEllipse(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Ellipse ellipse = new Ellipse(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                ellipse.thickness = thickness;
                ellipse.isFilled = shapeWithHighestPriority.isFilled;

                return ellipse;
            }

            return null;
        }

        public Line? DrawLine(List<IShapesService> AllShapes, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, ColorDialog colorPicker, float thickness)
        {
            Line line = new Line(
                StartDownLocation.X,
                StartDownLocation.Y,
                MouseDownCurrLocation.X,
                MouseDownCurrLocation.Y,
                colorPicker.Color, AllShapes.Count);

            line.thickness = thickness;

            return line;
        }

        public Line? CopyOrMoveLine(List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, ColorDialog colorPicker, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Line line = new Line(Point1.X, Point1.Y, Point2.X, Point2.Y, colorPicker.Color, AllShapes.Count);

                line.thickness = thickness;

                return line;
            }

            return null;
        }

        public void DrawOrFillRectangleForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            Rectangle rectangle = new Rectangle(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                    Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                    Color.Blue);

            rectangle.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                rectangle.Draw(e.Graphics);
            }
            else
            {
                rectangle.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveRectangleForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Rectangle rectangle = new Rectangle(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                rectangle.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    rectangle.Draw(e.Graphics);
                }
                else
                {
                    rectangle.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillSquareForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            Square square = new Square(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    BiggerAxis(StartDownLocation, MouseDownCurrLocation),
                    Color.Blue);

            square.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                square.Draw(e.Graphics);
            }
            else
            {
                square.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveSqaureForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Square square = new Square(Point1.X, Point1.Y, Point2.X, Color.Orange);

                square.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    square.Draw(e.Graphics);
                }
                else
                {
                    square.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillRhombusForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            Rhombus rhombus = new Rhombus(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    BiggerAxis(StartDownLocation, MouseDownCurrLocation),
                    Color.Blue);

            rhombus.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                rhombus.Draw(e.Graphics);
            }
            else
            {
                rhombus.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveRhombusForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Rhombus rhombus = new Rhombus(Point1.X, Point1.Y, Point2.X, Color.Orange);

                rhombus.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    rhombus.Draw(e.Graphics);
                }
                else
                {
                    rhombus.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillRightAngleTriangleForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            RightAngleTriangle rightAngleTriangle = new RightAngleTriangle(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                    Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                    Color.Blue);

            rightAngleTriangle.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                rightAngleTriangle.Draw(e.Graphics);
            }
            else
            {
                rightAngleTriangle.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveRightAngleTriangleForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                RightAngleTriangle rightAngleTriangle = new RightAngleTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                rightAngleTriangle.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    rightAngleTriangle.Draw(e.Graphics);
                }
                else
                {
                    rightAngleTriangle.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillObtuseTriangleForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            ObtuseTriangle obtuseTriangle = new ObtuseTriangle(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                    Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                    Color.Blue);

            obtuseTriangle.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                obtuseTriangle.Draw(e.Graphics);
            }
            else
            {
                obtuseTriangle.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveObtuseTriangleForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                ObtuseTriangle obtuseTriangle = new ObtuseTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                obtuseTriangle.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    obtuseTriangle.Draw(e.Graphics);
                }
                else
                {
                    obtuseTriangle.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillEquilateralTriangleForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            EquilateralTriangle equilateralTriangle = new EquilateralTriangle(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                    Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                    Color.Blue);

            equilateralTriangle.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                equilateralTriangle.Draw(e.Graphics);
            }
            else
            {
                equilateralTriangle.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveEquilateralTriangleForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                EquilateralTriangle equilateralTriangle = new EquilateralTriangle(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                equilateralTriangle.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    equilateralTriangle.Draw(e.Graphics);
                }
                else
                {
                    equilateralTriangle.Fill(e.Graphics);
                }
            }
        }

        public void DrawOrFillEllipseForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, string FunctionCase, float thickness)
        {
            Ellipse Ellipse = new Ellipse(
                    Math.Min(StartDownLocation.X, MouseDownCurrLocation.X),
                    Math.Min(StartDownLocation.Y, MouseDownCurrLocation.Y),
                    Math.Abs(StartDownLocation.X - MouseDownCurrLocation.X),
                    Math.Abs(StartDownLocation.Y - MouseDownCurrLocation.Y),
                    Color.Blue);

            Ellipse.thickness = thickness;

            if (FunctionCase == "Draw")
            {
                Ellipse.Draw(e.Graphics);
            }
            else
            {
                Ellipse.Fill(e.Graphics);
            }

            return;
        }

        public void CopyOrMoveEllipseForPreview(PaintEventArgs e, List<IShapesService> AllShapes, IShapesService shapeWithHighestPriority, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Ellipse Ellipse = new Ellipse(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                Ellipse.thickness = thickness;

                if (!shapeWithHighestPriority.isFilled)
                {
                    Ellipse.Draw(e.Graphics);
                }
                else
                {
                    Ellipse.Fill(e.Graphics);
                }
            }
        }

        public void DrawLineForPreview(PaintEventArgs e, Point StartDownLocation, Point MouseDownCurrLocation, float thickness)
        {
            Line line = new Line(
                    StartDownLocation.X,
                    StartDownLocation.Y,
                    MouseDownCurrLocation.X,
                    MouseDownCurrLocation.Y,
                    Color.Blue);

            line.thickness = thickness;

            line.Draw(e.Graphics);
        }

        public void CopyOrMoveLineForPreview(PaintEventArgs e, List<IShapesService> AllShapes, Point Point1, Point Point2, float thickness)
        {
            if (AllShapes.Count > 0)
            {
                Line line = new Line(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Orange);

                line.thickness = thickness;

                line.Draw(e.Graphics);
            }
        }

    }
}