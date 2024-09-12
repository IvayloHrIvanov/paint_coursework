using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint_course_work
{
    public partial class Form2 : Form
    {
        private Graphics graphics;

        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            graphics = pictureBox1.CreateGraphics();

            pencilThicknessBox.Items.AddRange(new[] { "1", "2", "3", "4", "5" });
            eraserThicknessBox.Items.AddRange(new[] { "1", "2", "3", "4", "5", "8", "12", "15", "20", "25", "30", "35", "40", "50", "100" });
        }

        private ColorDialog colorPicker = new ColorDialog();

        private Point StartDownLocation = new Point();
        private Point MouseDownCurrLocation = new Point();

        private Pen Pencil;
        private Pen Erase = new Pen(Color.LightGray, 20);

        private bool IsMouseDown = false;

        private string FunctionCase = "Pencil";

        private int pencilThickness = 1;
        private int eraserThickness = 20;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            StartDownLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                MouseDownCurrLocation = e.Location;
                Pencil = new Pen(colorPicker.Color, pencilThickness);

                if (FunctionCase == "Pencil")
                {
                    graphics.DrawLine(Pencil, StartDownLocation, MouseDownCurrLocation);
                }
                else
                {
                    graphics.DrawLine(Erase, StartDownLocation, MouseDownCurrLocation);
                }

                StartDownLocation = MouseDownCurrLocation;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void pencil_Click(object sender, EventArgs e)
        {
            FunctionCase = "Pencil";
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            FunctionCase = "Erase";
        }

        private void pencilThicknessBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pencilThickness = int.Parse(pencilThicknessBox.Text);

            Pencil = new Pen(colorPicker.Color, pencilThickness);
        }

        private void eraserThicknessBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            eraserThickness = int.Parse(eraserThicknessBox.Text);

            Erase = new Pen(Color.LightGray, eraserThickness);
        }

        private void pickColor_Click(object sender, EventArgs e)
        {
            colorPicker.ShowDialog();

            pickColor.BackColor = colorPicker.Color;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}