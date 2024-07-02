using System;
using System.Drawing;

namespace Paint_course_work
{
    internal class Ellipse : IShapes
    {
        public Shape type { get; set; } = Shape.Ellipse;

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

        public Ellipse(float x, float y, float width, float height, Color color, int priority)
        {
            x_coord = x;
            y_coord = y;
            x_width = width;
            y_height = height;
            this.color = color;
            this.priority = priority;

            brush = new(color);
            pen = new Pen(color, thickness);
        }

        public Ellipse(float x, float y, float width, float height, Color color)
        {
            x_coord = x;
            y_coord = y;
            x_width = width;
            y_height = height;
            this.color = color;

            brush = new(color);
            pen = new Pen(color, thickness);
        }

        public Ellipse()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            graphics.DrawEllipse(pen, x_coord, y_coord, x_width, y_height);
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);

            graphics.FillEllipse(brush, x_coord, y_coord, x_width, y_height);
        }

        public double Area(float DpiX, float DpiY)
        {
            return x_width / DpiX / 2 * y_height / DpiY / 2 * Math.PI;
        }

        public bool Contains(int x, int y)
        {
            float a = x_width / 2;
            float b = y_height / 2;
            float x_c = x_coord + a;
            float y_c = y_coord + b;

            double result = Math.Pow((x - x_c) / a, 2) + Math.Pow((y - y_c) / b, 2);

            return result <= 1;
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
            Ellipse elipse = new Ellipse(x_coord, y_coord, x_width, y_height, color, priority);

            elipse.thickness = thickness;
            elipse.color = color;
            elipse.isFilled = isFilled;

            return elipse;
        }

        public double Parameter(float DpiX, float DpiY)
        {
            throw new NotImplementedException();
        }
    }
}