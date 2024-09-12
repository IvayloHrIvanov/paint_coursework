using System.Drawing;

namespace Paint_course_work.service
{
    public enum Shape
    {
        Rectangle,
        Square,
        Rhombus,
        RightAngleTriangle,
        EquilateralTriangle,
        ObtuseTriangle,
        Ellipse,
        Line
    }

    internal interface IShapesService
    {
        public Shape type { get; set; }

        public event Delegate events;

        protected SolidBrush brush { get; set; }
        protected Pen pen { get; set; }

        public float x_coord { get; set; }
        public float y_coord { get; set; }

        public float x_width { get; set; }
        public float y_height { get; set; }

        public float thickness { get; set; }

        public int priority { get; set; }

        public Color color { get; set; }

        public bool isFilled { get; set; }

        public bool isResized { get; set; }

        public bool isDeleted { get; set; }

        public bool Contains(int x, int y);

        public void Draw(Graphics graphics);

        public void Fill(Graphics graphics);

        public abstract double Area(float DpiX, float DpiY);

        public abstract double Parameter(float DpiX, float DpiY);

        public void CallEventForAreaAndParameter();

        public IShapesService Copy();
    }
}