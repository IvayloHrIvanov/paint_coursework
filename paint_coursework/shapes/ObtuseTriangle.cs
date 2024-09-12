using System;
using System.Drawing;
using Paint_course_work.service;

namespace Paint_course_work
{
    internal class ObtuseTriangle : IShapesService
    {
        public Shape type { get; set; } = Shape.ObtuseTriangle;

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

        public ObtuseTriangle(float x, float y, float width, float height, System.Drawing.Color color, int priority)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.color = color;
            this.priority = priority;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public ObtuseTriangle(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public ObtuseTriangle()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            Point p1 = new Point((int)x_coord, (int)y_coord);
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));
            Point p3 = new Point((int)(x_coord + x_width / 2), (int)(y_coord + y_height));

            graphics.DrawPolygon(pen, new Point[] { p1, p2, p3 });
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);

            Point p1 = new Point((int)x_coord, (int)y_coord);
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));
            Point p3 = new Point((int)(x_coord + x_width / 2), (int)(y_coord + y_height));

            graphics.FillPolygon(brush, new Point[] { p1, p2, p3 });
        }

        public double Area(float DpiX, float DpiY)
        {
            double a = Math.Sqrt(Math.Pow(x_width / DpiX, 2) + Math.Pow(y_height / DpiY, 2));
            double s = (x_width / DpiX + y_height / DpiY + a) / 2;

            return Math.Sqrt(s * (s - x_width / DpiX) * (s - y_height / DpiY) * (s - a));
        }

        public double Parameter(float DpiX, float DpiY)
        {
            return x_width / DpiX + y_height / DpiY + Math.Sqrt(Math.Pow(x_width / DpiX, 2) + Math.Pow(y_height / DpiY, 2));
        }

        public bool Contains(int x, int y)
        {
            Point p1 = new Point((int)x_coord, (int)y_coord);
            Point p2 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));
            Point p3 = new Point((int)(x_coord + x_width / 2), (int)(y_coord + y_height));

            double denominator = (p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y);
            double a = ((p2.Y - p3.Y) * (x - p3.X) + (p3.X - p2.X) * (y - p3.Y)) / denominator;
            double b = ((p3.Y - p1.Y) * (x - p3.X) + (p1.X - p3.X) * (y - p3.Y)) / denominator;
            double c = 1 - a - b;

            return a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1;
        }

        public void CallEventForAreaAndParameter()
        {
            if (events.Equals(2))
            {
                events();
            }
        }

        public IShapesService Copy()
        {
            ObtuseTriangle obtuseTriangle = new ObtuseTriangle(x_coord, y_coord, x_width, y_height, color, priority);

            obtuseTriangle.thickness = this.thickness;
            obtuseTriangle.color = this.color;
            obtuseTriangle.isFilled = this.isFilled;

            return obtuseTriangle;
        }
    }
}