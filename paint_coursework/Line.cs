using System;
using System.Drawing;

namespace Paint_course_work
{
    internal class Line : IShapes
    {
        public Shape type { get; set; } = Shape.Line;

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

        public Line(float x, float y, float width, float height, System.Drawing.Color color, int priority)
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

        public Line(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public Line()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            graphics.DrawLine(pen, x_coord, y_coord, x_width, y_height);
        }

        public bool Contains(int mouseX, int mouseY)
        {
            float slope = (y_height - y_coord) / (x_width - x_coord);

            float tolerance = 10.0f;

            if (mouseX >= Math.Min(x_coord, x_width) - tolerance &&
                mouseX <= Math.Max(x_coord, x_width) + tolerance &&
                mouseY >= Math.Min(y_coord, y_height) - tolerance &&
                mouseY <= Math.Max(y_coord, y_height) + tolerance)
            {
                float expectedY = slope * (mouseX - x_coord) + y_coord;

                if (mouseY >= expectedY - tolerance && mouseY <= expectedY + tolerance)
                {
                    return true;
                }
            }

            return false;
        }

        public void CallEventForAreaAndParameter()
        {
            if (events.Equals(2))
            {
                events();
            }
        }

        public void Fill(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public double Parameter(float DpiX, float DpiY)
        {
            throw new NotImplementedException();
        }

        public double Area(float DpiX, float DpiY)
        {
            throw new NotImplementedException();
        }

        public IShapes Copy()
        {
            Line line = new Line(x_coord, y_coord, x_width, y_height, color, priority);

            line.thickness = this.thickness;
            line.color = this.color;
            line.isFilled = this.isFilled;

            return line;
        }
    }
}