using System.Drawing;

namespace Paint_course_work
{
    internal class Square : IShapes
    {
        public Shape type { get; set; } = Shape.Square;

        public event Delegate events;

        public SolidBrush brush { get; set; }
        public Pen pen { get; set; }

        public float x_coord { get; set; }
        public float y_coord { get; set; }

        public float side { get; set; }

        public float thickness { get; set; }

        public Color color { get; set; } = Color.Black;

        public bool isFilled { get; set; } = false;

        public bool isResized { get; set; } = false;

        public bool isDeleted { get; set; } = false;

        public int priority { get; set; }

        public float y_height { get; set; }
        public float x_width { get; set; }

        public Square(float x, float y, float side, System.Drawing.Color color, int priority)
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

        public Square(float x, float y, float width, float height, System.Drawing.Color color)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.side = side;
            this.color = color;

            this.brush = new(color);
            this.pen = new Pen(color, thickness);

            this.x_width = width;
            this.y_height = height;
        }

        public Square(float x, float y, float side, System.Drawing.Color color)
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

        public Square()
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
            return side / DpiX * side / DpiY;
        }

        public double Parameter(float DpiX, float DpiY)
        {
            return 4 * side / DpiX;
        }

        public bool Contains(int x, int y)
        {
            return x_coord <= x && x < x_coord + side && y_coord <= y && y < y_coord + side;
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
            Square square = new Square(x_coord, y_coord, x_width, color, priority);

            square.thickness = this.thickness;
            square.color = this.color;
            square.isFilled = this.isFilled;

            return square;
        }

        public void assaignSide(int side)
        {
            this.side = side;
        }
    }
}