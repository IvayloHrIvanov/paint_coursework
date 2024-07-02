using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_course_work
{
    internal class Rhombus : IShapes
    {
        public Shape type { get; set; } = Shape.Rhombus;

        public event Delegate events;

        public SolidBrush brush { get; set; }
        public Pen pen { get; set; }

        public float x_coord { get; set; }
        public float y_coord { get; set; }

        public float y_height { get; set; }
        public float x_width { get; set; }

        public float thickness { get; set; }

        public Color color { get; set; }

        public bool isFilled { get; set; } = false;

        public bool isResized { get; set; } = false;

        public bool isDeleted { get; set; } = false;

        public int priority { get; set; }

        public float side { get; set; }

        public Rhombus(float x, float y, float side, System.Drawing.Color color, int priority)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.side = side;
            this.color = color;
            this.priority = priority;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);

            this.x_width = side;
            this.y_height = side;
        }

        public Rhombus(float x, float y, float side, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.side = side;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);

            this.x_width = side;
            this.y_height = side;
        }

        public Rhombus()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics) //test
        {
            pen = new Pen(color, thickness);
            side = x_width;

            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLines(new[]
                {
                    new Point((int)x_coord, (int)(y_coord + (side / 2))),
                    new Point((int)(x_coord + (side / 2)), (int)y_coord),
                    new Point((int)(x_coord + side), (int)(y_coord + (side / 2))),
                    new Point((int)(x_coord + (side / 2)), (int)(y_coord + side)),
                    new Point((int)x_coord, (int)(y_coord + (side / 2)))
                });
                
                graphics.DrawPath(pen, myPath);
            }
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);
            side = x_width;

            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLines(new[]
                {
                    new Point((int)x_coord, (int)(y_coord + (side / 2))),
                    new Point((int)(x_coord + (side / 2)), (int)y_coord),
                    new Point((int)(x_coord + side), (int)(y_coord + (side / 2))),
                    new Point((int)(x_coord + (side / 2)), (int)(y_coord + side)),
                    new Point((int)x_coord, (int)(y_coord + (side / 2)))
                });
                
                graphics.FillPath(brush, myPath);
            }
        }

        public double Area(float DpiX, float DpiY)
        {
            return x_coord / DpiX * y_coord / DpiY * side / DpiX;
        }

        public double Parameter(float DpiX, float DpiY)
        {
            return 4 * side / DpiX;
        }

        public bool Contains(int x, int y)
        {
            float centerX = x_coord + side / 2;
            float centerY = y_coord + side / 2;

            return Math.Abs(x - centerX) / (side / 2) + Math.Abs(y - centerY) / (side / 2) <= 1;
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
            Rhombus rhombus = new Rhombus(x_coord, y_coord, x_width, color, priority);

            rhombus.thickness = this.thickness;
            rhombus.color = this.color;
            rhombus.isFilled = this.isFilled;

            return rhombus;
        }
    }
}