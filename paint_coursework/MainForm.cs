using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Paint_course_work
{
    public delegate void Delegate();

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            thicknessBox.Items.AddRange(new[] { "1", "3", "5", "8", "12", "15" });
        }

        private Bitmap bm;
        private Graphics graphics;

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bm);
            graphics.Clear(Color.White);
            pictureBox1.Image = bm;
        }

        private Form1 form1 = new Form1();
        private Form2 form2 = new Form2();

        private ColorDialog colorPicker = new ColorDialog();
        private Helper helper = new Helper();
        private FigureCreator figureCreator = new FigureCreator();

        private Rectangle? Rectangle;
        private Square? Square;
        private Rhombus? Rhombus;
        private RightAngleTriangle? RightAngleTriangle;
        private ObtuseTriangle? ObtuseTriangle;
        private EquilateralTriangle? EquilateralTriangle;
        private Ellipse? ellipse;
        private Line? Line;

        private List<IShapes> AllShapes = new List<IShapes>();
        private HashSet<IShapes> CurrShapesSet = new HashSet<IShapes>();

        private List<IShapes> ShapesUndo = new List<IShapes>(20);
        private List<IShapes> ShapesRedo = new List<IShapes>(20);
        private List<int> ShapesIndexUndoResized = new List<int>();
        private List<int> ShapesIndexRedoResized = new List<int>();

        private IShapes? shapeWithHighestPriority;

        private Point Point1 = new Point();
        private Point Point2 = new Point();
        private Point StartDownLocation = new Point();
        private Point MouseDownCurrLocation = new Point();

        private string ShapeCase = "Rectangle";
        private string FunctionCase = "Draw";

        private float DpiX;
        private float DpiY;
        private float thickness;

        private bool IsMouseDown = false;
        private bool IsShapeChecked = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (FunctionCase == "Delete" && CurrShapesSet.Count > 0)
            {
                helper.HandleDelete(AllShapes, CurrShapesSet, ShapesUndo);

                pictureBox1.Refresh();
            }
            else if (FunctionCase == "Resize")
            {
                helper.HandleResize(e, form1, AllShapes, CurrShapesSet, ShapesUndo, ShapesIndexUndoResized);

                pictureBox1.Refresh();
            }
            else
            {
                IsMouseDown = true;

                StartDownLocation = helper.CheckPictureBoxBounderiesWithMouseCoord(e, pictureBox1);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown && AllShapes.Count > 0)
            {
                CurrShapesSet.Clear();
                parameter.Text = "";
                area.Text = "";

                shapeWithHighestPriority = helper.GetShapeWithHighestPriority(e, AllShapes, CurrShapesSet);

                if (shapeWithHighestPriority != null)
                {
                    if (!shapeWithHighestPriority.GetType().Equals(typeof(Ellipse)) && !shapeWithHighestPriority.GetType().Equals(typeof(Line)))
                    {
                        parameter.Text = "Parameter: " + shapeWithHighestPriority.Parameter(DpiX, DpiY).ToString("0.## DPI");
                        area.Text = "Area: " + shapeWithHighestPriority.Area(DpiX, DpiY).ToString("0.## DPI");
                    }
                    else if (shapeWithHighestPriority.GetType().Equals(typeof(Ellipse)))
                    {
                        area.Text = "Area: " + shapeWithHighestPriority.Area(DpiX, DpiY).ToString("0.## DPI");
                    }
                }

                return;
            }

            MouseDownCurrLocation = helper.CheckPictureBoxBounderiesWithMouseCoord(e, pictureBox1);

            if (FunctionCase == "Copy" || FunctionCase == "Move")
            {
                if (!IsShapeChecked)
                {
                    shapeWithHighestPriority = helper.GetShapeWithHighestPriority(e, AllShapes, CurrShapesSet);

                    if (shapeWithHighestPriority == null)
                    {
                        IsMouseDown = false;
                        return;
                    }

                    IsShapeChecked = true;
                }

                if (AllShapes.Count >= 0)
                {
                    MouseDownCurrLocation = helper.CheckPictureBoxBounderiesWithWidthAndHeight(e, pictureBox1, (int)shapeWithHighestPriority.x_width, (int)shapeWithHighestPriority.y_height);

                    if (ShapeCase != "Line")
                    {
                        Point1.X = MouseDownCurrLocation.X;
                        Point1.Y = MouseDownCurrLocation.Y;
                        Point2.X = (int)shapeWithHighestPriority.x_width;
                        Point2.Y = (int)shapeWithHighestPriority.y_height;
                    }
                    else
                    {
                        Point1.X = e.X + (int)shapeWithHighestPriority.x_coord - StartDownLocation.X;
                        Point1.Y = e.Y + (int)shapeWithHighestPriority.y_coord - StartDownLocation.Y;
                        Point2.X = e.X + (int)shapeWithHighestPriority.x_width - StartDownLocation.X;
                        Point2.Y = e.Y + (int)shapeWithHighestPriority.y_height - StartDownLocation.Y;
                    }

                    ShapeCase = shapeWithHighestPriority.GetType().ToString().IndexOf('.') >= 0 ? (shapeWithHighestPriority.GetType().ToString().Substring(shapeWithHighestPriority.GetType().ToString().IndexOf('.') + 1)) : (shapeWithHighestPriority.GetType().ToString());
                }
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDownCurrLocation = helper.CheckPictureBoxBounderiesWithMouseCoord(e, pictureBox1);

            if (IsMouseDown == false)
            {
                return;
            }

            if (shapeColorChanger.Checked && shapeWithHighestPriority != null)
            {
                shapeWithHighestPriority.color = colorPicker.Color;

                IsMouseDown = false;

                pictureBox1.Invalidate();
                return;
            }

            IsMouseDown = false;
            IsShapeChecked = false;

            if (e.Button == MouseButtons.Left)
            {
                if (FunctionCase != "Delete" && FunctionCase != "Save" && FunctionCase != "Resize")
                {
                    switch (ShapeCase)
                    {
                        case "Rectangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    Rectangle = figureCreator.DrawOrFillRectangle(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    Rectangle = figureCreator.CopyOrMoveRectangle(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (Rectangle != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, Rectangle, FunctionCase);
                                }

                                break;
                            }

                        case "Square":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    Square = figureCreator.DrawOrFillSquare(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    Square = figureCreator.CopyOrMoveSquare(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (Square != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, Square, FunctionCase);
                                }

                                break;
                            }

                        case "Rhombus":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    Rhombus = figureCreator.DrawOrFillRhombus(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    Rhombus = figureCreator.CopyOrMoveRhombus(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (Rhombus != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, Rhombus, FunctionCase);
                                }

                                break;
                            }

                        case "RightAngleTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    RightAngleTriangle = figureCreator.DrawOrFillRightAngleTriangle(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    RightAngleTriangle = figureCreator.CopyOrMoveRightAngleTriangle(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (RightAngleTriangle != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, RightAngleTriangle, FunctionCase);
                                }

                                break;
                            }

                        case "ObtuseTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    ObtuseTriangle = figureCreator.DrawOrFillObtuseTriangle(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    ObtuseTriangle = figureCreator.CopyOrMoveObtuseTriangle(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (ObtuseTriangle != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, ObtuseTriangle, FunctionCase);
                                }

                                break;
                            }

                        case "EquilateralTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    EquilateralTriangle = figureCreator.DrawOrFillEquilateralTriangle(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    EquilateralTriangle = figureCreator.CopyOrMoveEquilateralTriangle(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (EquilateralTriangle != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, EquilateralTriangle, FunctionCase);
                                }

                                break;
                            }

                        case "Ellipse":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    ellipse = figureCreator.DrawOrFillEllipse(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    ellipse = figureCreator.CopyOrMoveEllipse(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (ellipse != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, ellipse, FunctionCase);
                                }

                                break;
                            }

                        case "Line":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    Line = figureCreator.DrawLine(AllShapes, StartDownLocation, MouseDownCurrLocation, FunctionCase, colorPicker, thickness);
                                }
                                else
                                {
                                    Line = figureCreator.CopyOrMoveLine(AllShapes, shapeWithHighestPriority, Point1, Point2, colorPicker, thickness);
                                }

                                if (Line != null)
                                {
                                    figureCreator.AddOrUpdateShape(AllShapes, shapeWithHighestPriority, Line, FunctionCase);
                                }

                                break;
                            }

                        default:
                            break;
                    }
                }

                pictureBox1.Invalidate();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DpiX = e.Graphics.DpiX;
            DpiY = e.Graphics.DpiY;

            selectedFunction.Text = "Selected function: " + FunctionCase;
            selectedShape.Text = "Selected shape: " + ShapeCase;

            foreach (var shape in AllShapes)
            {
                if (!shape.isFilled)
                {
                    shape.Draw(e.Graphics);
                }
                else
                {
                    shape.Fill(e.Graphics);
                }
            }

            if (IsMouseDown == true)
            {
                if (FunctionCase != "Delete" && FunctionCase != "Save")
                {
                    switch (ShapeCase)
                    {
                        case "Rectangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillRectangleForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveRectangleForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "Square":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillSquareForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveSqaureForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "Rhombus":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillRhombusForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveRhombusForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "RightAngleTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillRightAngleTriangleForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveRightAngleTriangleForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "ObtuseTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillObtuseTriangleForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveObtuseTriangleForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "EquilateralTriangle":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillEquilateralTriangleForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveEquilateralTriangleForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "Ellipse":
                            {
                                if (FunctionCase == "Draw" || FunctionCase == "Fill")
                                {
                                    figureCreator.DrawOrFillEllipseForPreview(e, StartDownLocation, MouseDownCurrLocation, FunctionCase, thickness);
                                }
                                else
                                {
                                    figureCreator.CopyOrMoveEllipseForPreview(e, AllShapes, shapeWithHighestPriority, Point1, Point2, thickness);
                                }

                                break;
                            }

                        case "Line":
                            {
                                if (FunctionCase == "Draw")
                                {
                                    figureCreator.DrawLineForPreview(e, StartDownLocation, MouseDownCurrLocation, thickness);
                                }
                                else if (FunctionCase == "Copy" || FunctionCase == "Move")
                                {
                                    figureCreator.CopyOrMoveLineForPreview(e, AllShapes, Point1, Point2, thickness);
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("You can't fill a line!");
                                    FunctionCase = "Draw";
                                    IsMouseDown = false;
                                }

                                break;
                            }

                        default:
                            break;
                    }
                }
            }

            parameter.Text = "";
            area.Text = "";
        }

        private void createRectangle_Click(object sender, EventArgs e)
        {
            FunctionCase = "Draw";
            pictureBox1.Refresh();
        }

        private void fill_Click(object sender, EventArgs e)
        {
            FunctionCase = "Fill";
            pictureBox1.Refresh();
        }

        private void copyRectangle_Click(object sender, EventArgs e)
        {
            FunctionCase = "Copy";
            pictureBox1.Refresh();
        }

        private void moveRectangle_Click(object sender, EventArgs e)
        {
            FunctionCase = "Move";
            pictureBox1.Refresh();
        }

        private void resize_Click(object sender, EventArgs e)
        {
            FunctionCase = "Resize";
            pictureBox1.Refresh();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            FunctionCase = "Delete";
            pictureBox1.Refresh();
        }

        private void chooseRectangle_Click(object sender, EventArgs e)
        {
            ShapeCase = "Rectangle";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseSquare_Click(object sender, EventArgs e)
        {
            ShapeCase = "Square";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseRhombus_Click(object sender, EventArgs e)
        {
            ShapeCase = "Rhombus";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseRightAngleTriangle_Click(object sender, EventArgs e)
        {
            ShapeCase = "RightAngleTriangle";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseIsoscelesTriangle_Click(object sender, EventArgs e)
        {
            ShapeCase = "EquilateralTriangle";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseObtuseTriangle_Click(object sender, EventArgs e)
        {
            ShapeCase = "ObtuseTriangle";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseEllipse_Click(object sender, EventArgs e)
        {
            ShapeCase = "Ellipse";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void chooseLine_Click(object sender, EventArgs e)
        {
            ShapeCase = "Line";

            FunctionCase = helper.returnFunctionCase(FunctionCase);

            pictureBox1.Refresh();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            AllShapes.Clear();
            ShapesUndo.Clear();
            ShapesRedo.Clear();
            CurrShapesSet.Clear();

            pictureBox1.Refresh();
        }

        private void pickColor_Click(object sender, EventArgs e)
        {
            colorPicker.ShowDialog();

            pickColor.BackColor = colorPicker.Color;
        }

        private void thicknessBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            thickness = float.Parse(thicknessBox.Text);
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (ShapesUndo.Count <= 20)
            {
                if (AllShapes.Count > 0 && AllShapes.Last().isResized)
                {
                    ShapesRedo.Add(AllShapes.Last());
                    ShapesIndexRedoResized.Add(ShapesIndexUndoResized.Last());
                    AllShapes.RemoveAt(AllShapes.Count - 1);
                    AllShapes.Insert(ShapesIndexUndoResized.Last(), ShapesUndo.Last());
                    ShapesIndexUndoResized.RemoveAt(ShapesIndexUndoResized.Count - 1);
                    ShapesUndo.RemoveAt(ShapesUndo.Count - 1);
                }
                else if (ShapesUndo.Count > 0 && ShapesUndo.Last().isDeleted)
                {
                    AllShapes.Add(ShapesUndo.Last());
                    ShapesRedo.Add(ShapesUndo.Last());
                    ShapesUndo.RemoveAt(ShapesUndo.Count - 1);
                }
                else
                {
                    if (AllShapes.Count > 0)
                    {
                        ShapesRedo.Add(AllShapes.Last());
                        AllShapes.RemoveAt(AllShapes.Count - 1);
                    }
                }
            }

            pictureBox1.Refresh();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            ShapesRedo = ShapesRedo.Distinct().ToList();

            if (ShapesRedo.Count > 0)
            {
                if (ShapesRedo.Last().isResized)
                {
                    ShapesUndo.Add(AllShapes[ShapesIndexRedoResized.Last()]);
                    ShapesIndexUndoResized.Add(ShapesIndexRedoResized.Last());
                    AllShapes.RemoveAt(ShapesIndexRedoResized.Last());
                    AllShapes.Add(ShapesRedo.Last());
                    ShapesIndexRedoResized.RemoveAt(ShapesIndexRedoResized.Count - 1);
                    ShapesRedo.RemoveAt(ShapesRedo.Count - 1);
                }
                else if (ShapesRedo.Count > 0 && ShapesRedo.Last().isDeleted)
                {
                    AllShapes.Remove(ShapesRedo.Last());
                    ShapesUndo.Add(ShapesRedo.Last());
                    ShapesRedo.RemoveAt(ShapesRedo.Count - 1);
                }
                else
                {
                    AllShapes.Add(ShapesRedo.Last());
                    ShapesRedo.RemoveAt(ShapesRedo.Count - 1);
                }
            }

            pictureBox1.Refresh();
        }

        private void savePicture_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image(*.png)|*.png|JPEG Image(*.jpeg)|*.jpeg";

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap btm = bm.Clone(new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), bm.PixelFormat))
                {
                    using (Graphics g = Graphics.FromImage(btm))
                    {
                        foreach (var shape in AllShapes)
                        {
                            if (!shape.isFilled)
                            {
                                shape.Draw(g);
                            }
                            else
                            {
                                shape.Fill(g);
                            }
                        }
                    }

                    string extension = Path.GetExtension(sfd.FileName);

                    if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        ImageFormat imageFormat;

                        if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            imageFormat = ImageFormat.Png;
                        }
                        else
                        {
                            imageFormat = ImageFormat.Jpeg;
                        }

                        btm.Save(sfd.FileName, imageFormat);
                        MessageBox.Show("Image Saved Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid file format. Please select a valid JPEG or PNG file.");
                    }
                }
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            string jsonFileName = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Json files (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                jsonFileName = saveFileDialog.FileName;

                if (AllShapes.Count > 0)
                {
                    File.AppendAllText(jsonFileName, JsonSerializer.Serialize(AllShapes, new JsonSerializerOptions { WriteIndented = true }));

                    MessageBox.Show("Save Complete!");
                }
                else
                {
                    MessageBox.Show("Error saving! There were no shapes");
                }
            }
        }

        private void loadFromFIle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string jsonContent = File.ReadAllText(openFileDialog1.FileName);

                AllShapes = JsonSerializer.Deserialize<List<IShapes>>(jsonContent, new JsonSerializerOptions
                {
                    Converters = { new ObjectConverter() }
                });

                ShapesUndo.Clear();
                CurrShapesSet.Clear();
                pictureBox1.Refresh();
            }
        }

        private void freeDraw_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
    }

    class ObjectConverter : System.Text.Json.Serialization.JsonConverter<IShapes>
    {
        public override IShapes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                var type = root.GetProperty("type");

                IShapes shape;

                switch (type.GetInt32())
                {
                    case 0:
                        shape = JsonSerializer.Deserialize<Rectangle>(root.GetRawText());
                        break;

                    case 1:
                        shape = JsonSerializer.Deserialize<Square>(root.GetRawText());
                        break;

                    case 2:
                        shape = JsonSerializer.Deserialize<Rhombus>(root.GetRawText());
                        break;

                    case 3:
                        shape = JsonSerializer.Deserialize<RightAngleTriangle>(root.GetRawText());
                        break;

                    case 4:
                        shape = JsonSerializer.Deserialize<EquilateralTriangle>(root.GetRawText());
                        break;

                    case 5:
                        shape = JsonSerializer.Deserialize<ObtuseTriangle>(root.GetRawText());
                        break;

                    case 6:
                        shape = JsonSerializer.Deserialize<Ellipse>(root.GetRawText());
                        break;

                    case 7:
                        shape = JsonSerializer.Deserialize<Line>(root.GetRawText());
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown object type: {type}");
                }

                var R = root.GetProperty("color").GetProperty("R").GetInt32();
                var G = root.GetProperty("color").GetProperty("G").GetInt32();
                var B = root.GetProperty("color").GetProperty("B").GetInt32();

                shape.color = Color.FromArgb(R, G, B);

                return shape;
            }
        }

        public override void Write(Utf8JsonWriter writer, IShapes value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}