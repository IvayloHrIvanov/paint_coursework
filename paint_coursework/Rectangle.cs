using System.Drawing;

namespace Paint_course_work
{
    internal class Rectangle : IShapes
    {
        public Shape type { get; set; } = Shape.Rectangle;

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

        public Rectangle(float x, float y, float width, float height, System.Drawing.Color color, int priority)
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

        public Rectangle(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.x_width = width;
            this.y_height = height;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public Rectangle()
        {
            this.brush = new(color);
            this.pen = new Pen(color, thickness);
        }

        public void Draw(Graphics graphics)
        {
            pen = new Pen(color, thickness);

            graphics.DrawRectangle(pen, x_coord, y_coord, x_width, y_height);
        }

        public void Fill(Graphics graphics)
        {
            brush = new(color);

            graphics.FillRectangle(brush, x_coord, y_coord, x_width, y_height);
        }

        public double Area(float DpiX, float DpiY)
        {
            return x_width / DpiX * y_height / DpiY;
        }

        public double Parameter(float DpiX, float DpiY)
        {
            return (x_width / DpiX + y_height / DpiY) * 2;
        }

        public bool Contains(int x, int y)
        {
            return x_coord <= x && x < x_coord + x_width && y_coord <= y && y < y_coord + y_height;
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
            Rectangle rectangle = new Rectangle(x_coord, y_coord, x_width, y_height, color, priority);

            rectangle.thickness = this.thickness;
            rectangle.color = this.color;
            rectangle.isFilled = this.isFilled;

            return rectangle;
        }
    }
}