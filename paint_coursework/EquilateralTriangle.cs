using System;
using System.Drawing;

namespace Paint_course_work
{
    internal class EquilateralTriangle : IShapes
    {
        public Shape type { get; set; } = Shape.EquilateralTriangle;

        public event Delegate events;

        public SolidBrush brush { get; set; }
        public Pen pen { get; set; }

        public float x_coord { get; set; }
        public float y_coord { get; set; }

        public float x_width { get; set; }
        public float y_height { get; set; }

        public float thickness { get; set; }

        public Color color { get; set; } = Color.Black;

        public bool isFilled { get; set; } = false;

        public bool isResized { get; set; } = false;

        public bool isDeleted { get; set; } = false;

        public int priority { get; set; }

        public EquilateralTriangle(float x, float y, float width, float height, System.Drawing.Color color, int priority)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.priority = priority;

            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public EquilateralTriangle(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;

            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public EquilateralTriangle()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            Point p0 = new Point((int)x_coord, (int)y_coord);
            Point p1 = new Point((int)(x_coord - x_width), (int)(y_coord + y_height));
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));

            Point[] points = { p0, p1, p2 };

            graphics.DrawPolygon(pen, points);
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);

            Point p0 = new Point((int)x_coord, (int)y_coord);
            Point p1 = new Point((int)(x_coord - x_width), (int)(y_coord + y_height));
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));

            Point[] points = { p0, p1, p2 };

            graphics.FillPolygon(brush, points);
        }

        public double Area(float DpiX, float DpiY)
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(x_width / DpiX, 2);
        }

        public double Parameter(float DpiX, float DpiY)
        {
            return 3 * x_width / DpiX;
        }

        public bool Contains(int mouseX, int mouseY)
        {
            Point p0 = new Point((int)x_coord, (int)y_coord);
            Point p1 = new Point((int)(x_coord - x_width), (int)(y_coord + x_width));
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + x_width));

            float denominator = (float)((p1.Y - p2.Y) * (p0.X - p2.X) + (p2.X - p1.X) * (p0.Y - p2.Y));
            float a = ((p1.Y - p2.Y) * (mouseX - p2.X) + (p2.X - p1.X) * (mouseY - p2.Y)) / denominator;
            float b = ((p2.Y - p0.Y) * (mouseX - p2.X) + (p0.X - p2.X) * (mouseY - p2.Y)) / denominator;
            float c = 1 - a - b;

            return a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1;
        }

        public void CallEventForAreaAndParameter()
        {
            if (events.Equals(2))
            {
                events();
            }
        }

        public IShapes Copy()
        {
            EquilateralTriangle equilateralTriangle = new EquilateralTriangle(x_coord, y_coord, x_width, y_height, color, priority);

            equilateralTriangle.thickness = this.thickness;
            equilateralTriangle.color = this.color;
            equilateralTriangle.isFilled = this.isFilled;

            return equilateralTriangle;
        }
    }
}