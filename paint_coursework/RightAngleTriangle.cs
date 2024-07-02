using System;
using System.Drawing;

namespace Paint_course_work
{
    internal class RightAngleTriangle : IShapes
    {
        public Shape type { get; set; } = Shape.RightAngleTriangle;

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

        public RightAngleTriangle(float x, float y, float width, float height, System.Drawing.Color color, int priority)
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

        public RightAngleTriangle(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public RightAngleTriangle()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            Point p = new Point((int)x_coord, (int)y_coord);

            graphics.DrawPolygon(pen, new Point[] { p, new Point(p.X, p.Y + (int)y_height), new Point(p.X + (int)x_width, p.Y + (int)y_height) });
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);

            Point p = new Point((int)x_coord, (int)y_coord);

            graphics.FillPolygon(brush, new Point[] { p, new Point(p.X, p.Y + (int)y_height), new Point(p.X + (int)x_width, p.Y + (int)y_height) });
        }

        public double Area(float DpiX, float DpiY)
        {
            return (x_width / DpiX * y_height / DpiY) / 2.0;
        }

        public double Parameter(float DpiX, float DpiY)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(x_width / DpiX, 2) + Math.Pow(y_height / DpiY, 2));

            return x_width / DpiX + y_height / DpiY + hypotenuse;
        }

        public bool Contains(int mouseX, int mouseY)
        {
            Point p1 = new Point((int)x_coord, (int)y_coord);
            Point p2 = new Point((int)x_coord, (int)(y_coord + y_height));
            Point p3 = new Point((int)(x_coord + x_width), (int)(y_coord + y_height));

            int sign1 = (mouseX - p2.X) * (p1.Y - p2.Y) - (p1.X - p2.X) * (mouseY - p2.Y);
            int sign2 = (mouseX - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (mouseY - p3.Y);
            int sign3 = (mouseX - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (mouseY - p1.Y);

            bool hasNeg = (sign1 < 0) || (sign2 < 0) || (sign3 < 0);
            bool hasPos = (sign1 > 0) || (sign2 > 0) || (sign3 > 0);

            return !(hasNeg && hasPos);
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
            RightAngleTriangle rightAngleTriangle = new RightAngleTriangle(x_coord, y_coord, x_width, y_height, color, priority);

            rightAngleTriangle.thickness = this.thickness;
            rightAngleTriangle.color = this.color;
            rightAngleTriangle.isFilled = this.isFilled;

            return rightAngleTriangle;
        }
    }
}