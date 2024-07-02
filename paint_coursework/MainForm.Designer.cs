using System.Drawing;
using System.Windows.Forms;

namespace Paint_course_work
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            draw = new Button();
            copy = new Button();
            move = new Button();
            delete = new Button();
            fill = new Button();
            clear = new Button();
            savePicture = new Button();
            colorDialog1 = new ColorDialog();
            pickColor = new Button();
            resize = new Button();
            chooseRectangle = new Button();
            chooseSquare = new Button();
            chooseRhombus = new Button();
            chooseRightAngleTriangle = new Button();
            chooseEquilateralTriangle = new Button();
            chooseObtuseTriangle = new Button();
            chooseElipse = new Button();
            chooseLine = new Button();
            area = new Label();
            parameter = new Label();
            thicknessBox = new ComboBox();
            undo = new Button();
            redo = new Button();
            selectedFunction = new Label();
            selectedShape = new Label();
            shapeColorChanger = new CheckBox();
            label1 = new Label();
            freeDraw = new Button();
            saveFile = new Button();
            loadFromFIle = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.FromArgb(224, 224, 224);
            pictureBox1.Location = new Point(1, 113);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1460, 346);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // draw
            // 
            draw.Anchor = AnchorStyles.Top;
            draw.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            draw.ImageAlign = ContentAlignment.BottomCenter;
            draw.Location = new Point(323, 3);
            draw.Name = "draw";
            draw.Size = new Size(132, 40);
            draw.TabIndex = 4;
            draw.Text = "Draw";
            draw.UseVisualStyleBackColor = true;
            draw.Click += createRectangle_Click;
            // 
            // copy
            // 
            copy.Anchor = AnchorStyles.Top;
            copy.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            copy.Location = new Point(599, 3);
            copy.Name = "copy";
            copy.Size = new Size(130, 40);
            copy.TabIndex = 5;
            copy.Text = "Copy";
            copy.UseVisualStyleBackColor = true;
            copy.Click += copyRectangle_Click;
            // 
            // move
            // 
            move.Anchor = AnchorStyles.Top;
            move.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            move.ImageAlign = ContentAlignment.BottomCenter;
            move.Location = new Point(735, 3);
            move.Name = "move";
            move.Size = new Size(130, 40);
            move.TabIndex = 6;
            move.Text = "Move";
            move.UseVisualStyleBackColor = true;
            move.Click += moveRectangle_Click;
            // 
            // delete
            // 
            delete.Anchor = AnchorStyles.Top;
            delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            delete.ImageAlign = ContentAlignment.BottomCenter;
            delete.Location = new Point(871, 3);
            delete.Name = "delete";
            delete.Size = new Size(130, 40);
            delete.TabIndex = 7;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // fill
            // 
            fill.Anchor = AnchorStyles.Top;
            fill.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fill.ImageAlign = ContentAlignment.BottomCenter;
            fill.Location = new Point(461, 3);
            fill.Name = "fill";
            fill.Size = new Size(132, 40);
            fill.TabIndex = 8;
            fill.Text = "Fill";
            fill.UseVisualStyleBackColor = true;
            fill.Click += fill_Click;
            // 
            // clear
            // 
            clear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clear.ImageAlign = ContentAlignment.BottomCenter;
            clear.Location = new Point(1318, 64);
            clear.Name = "clear";
            clear.Size = new Size(132, 40);
            clear.TabIndex = 9;
            clear.Text = "Clear";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // savePicture
            // 
            savePicture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            savePicture.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            savePicture.ImageAlign = ContentAlignment.BottomCenter;
            savePicture.Location = new Point(1318, 12);
            savePicture.Name = "savePicture";
            savePicture.Size = new Size(65, 50);
            savePicture.TabIndex = 10;
            savePicture.Text = "Save picture";
            savePicture.UseVisualStyleBackColor = true;
            savePicture.Click += savePicture_Click;
            // 
            // pickColor
            // 
            pickColor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pickColor.BackColor = Color.Black;
            pickColor.ImageAlign = ContentAlignment.BottomCenter;
            pickColor.Location = new Point(149, 14);
            pickColor.Name = "pickColor";
            pickColor.Size = new Size(120, 39);
            pickColor.TabIndex = 11;
            pickColor.UseVisualStyleBackColor = false;
            pickColor.Click += pickColor_Click;
            // 
            // resize
            // 
            resize.Anchor = AnchorStyles.Top;
            resize.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resize.ImageAlign = ContentAlignment.BottomCenter;
            resize.Location = new Point(1007, 3);
            resize.Name = "resize";
            resize.Size = new Size(130, 40);
            resize.TabIndex = 12;
            resize.Text = "Resize";
            resize.UseVisualStyleBackColor = true;
            resize.Click += resize_Click;
            // 
            // chooseRectangle
            // 
            chooseRectangle.Anchor = AnchorStyles.Top;
            chooseRectangle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseRectangle.ImageAlign = ContentAlignment.BottomCenter;
            chooseRectangle.Location = new Point(185, 49);
            chooseRectangle.Name = "chooseRectangle";
            chooseRectangle.Size = new Size(132, 49);
            chooseRectangle.TabIndex = 13;
            chooseRectangle.Text = "Rectangle";
            chooseRectangle.UseVisualStyleBackColor = true;
            chooseRectangle.Click += chooseRectangle_Click;
            // 
            // chooseSquare
            // 
            chooseSquare.Anchor = AnchorStyles.Top;
            chooseSquare.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseSquare.ImageAlign = ContentAlignment.BottomCenter;
            chooseSquare.Location = new Point(323, 49);
            chooseSquare.Name = "chooseSquare";
            chooseSquare.Size = new Size(132, 49);
            chooseSquare.TabIndex = 14;
            chooseSquare.Text = "Square";
            chooseSquare.UseVisualStyleBackColor = true;
            chooseSquare.Click += chooseSquare_Click;
            // 
            // chooseRhombus
            // 
            chooseRhombus.Anchor = AnchorStyles.Top;
            chooseRhombus.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseRhombus.ImageAlign = ContentAlignment.BottomCenter;
            chooseRhombus.Location = new Point(461, 49);
            chooseRhombus.Name = "chooseRhombus";
            chooseRhombus.Size = new Size(130, 49);
            chooseRhombus.TabIndex = 15;
            chooseRhombus.Text = "Rhombus";
            chooseRhombus.UseVisualStyleBackColor = true;
            chooseRhombus.Click += chooseRhombus_Click;
            // 
            // chooseRightAngleTriangle
            // 
            chooseRightAngleTriangle.Anchor = AnchorStyles.Top;
            chooseRightAngleTriangle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseRightAngleTriangle.ImageAlign = ContentAlignment.BottomCenter;
            chooseRightAngleTriangle.Location = new Point(599, 49);
            chooseRightAngleTriangle.Name = "chooseRightAngleTriangle";
            chooseRightAngleTriangle.Size = new Size(130, 49);
            chooseRightAngleTriangle.TabIndex = 16;
            chooseRightAngleTriangle.Text = "Right Angle Triangle";
            chooseRightAngleTriangle.UseVisualStyleBackColor = true;
            chooseRightAngleTriangle.Click += chooseRightAngleTriangle_Click;
            // 
            // chooseEquilateralTriangle
            // 
            chooseEquilateralTriangle.Anchor = AnchorStyles.Top;
            chooseEquilateralTriangle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseEquilateralTriangle.ImageAlign = ContentAlignment.BottomCenter;
            chooseEquilateralTriangle.Location = new Point(735, 49);
            chooseEquilateralTriangle.Name = "chooseEquilateralTriangle";
            chooseEquilateralTriangle.Size = new Size(130, 49);
            chooseEquilateralTriangle.TabIndex = 17;
            chooseEquilateralTriangle.Text = "Equilateral Triangle";
            chooseEquilateralTriangle.UseVisualStyleBackColor = true;
            chooseEquilateralTriangle.Click += chooseIsoscelesTriangle_Click;
            // 
            // chooseObtuseTriangle
            // 
            chooseObtuseTriangle.Anchor = AnchorStyles.Top;
            chooseObtuseTriangle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseObtuseTriangle.ImageAlign = ContentAlignment.BottomCenter;
            chooseObtuseTriangle.Location = new Point(873, 49);
            chooseObtuseTriangle.Name = "chooseObtuseTriangle";
            chooseObtuseTriangle.Size = new Size(128, 49);
            chooseObtuseTriangle.TabIndex = 18;
            chooseObtuseTriangle.Text = "Obtuse Triangle";
            chooseObtuseTriangle.UseVisualStyleBackColor = true;
            chooseObtuseTriangle.Click += chooseObtuseTriangle_Click;
            // 
            // chooseElipse
            // 
            chooseElipse.Anchor = AnchorStyles.Top;
            chooseElipse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseElipse.ImageAlign = ContentAlignment.BottomCenter;
            chooseElipse.Location = new Point(1007, 49);
            chooseElipse.Name = "chooseElipse";
            chooseElipse.Size = new Size(130, 49);
            chooseElipse.TabIndex = 19;
            chooseElipse.Text = "Elipse/Circle";
            chooseElipse.UseVisualStyleBackColor = true;
            chooseElipse.Click += chooseEllipse_Click;
            // 
            // chooseLine
            // 
            chooseLine.Anchor = AnchorStyles.Top;
            chooseLine.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseLine.ImageAlign = ContentAlignment.BottomCenter;
            chooseLine.Location = new Point(1143, 49);
            chooseLine.Name = "chooseLine";
            chooseLine.Size = new Size(132, 49);
            chooseLine.TabIndex = 20;
            chooseLine.Text = "Line";
            chooseLine.UseVisualStyleBackColor = true;
            chooseLine.Click += chooseLine_Click;
            // 
            // area
            // 
            area.Location = new Point(1, 68);
            area.Name = "area";
            area.Size = new Size(71, 40);
            area.TabIndex = 21;
            // 
            // parameter
            // 
            parameter.Location = new Point(78, 68);
            parameter.Name = "parameter";
            parameter.Size = new Size(101, 40);
            parameter.TabIndex = 22;
            // 
            // thicknessBox
            // 
            thicknessBox.DropDownStyle = ComboBoxStyle.DropDownList;
            thicknessBox.FormattingEnabled = true;
            thicknessBox.Location = new Point(12, 24);
            thicknessBox.Name = "thicknessBox";
            thicknessBox.Size = new Size(131, 28);
            thicknessBox.TabIndex = 23;
            thicknessBox.Tag = "";
            thicknessBox.SelectedIndexChanged += thicknessBox_SelectedIndexChanged;
            // 
            // undo
            // 
            undo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            undo.Location = new Point(1202, 13);
            undo.Name = "undo";
            undo.Size = new Size(110, 40);
            undo.TabIndex = 24;
            undo.Text = "Undo";
            undo.UseVisualStyleBackColor = true;
            undo.Click += undo_Click;
            // 
            // redo
            // 
            redo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            redo.Location = new Point(1202, 64);
            redo.Name = "redo";
            redo.Size = new Size(110, 40);
            redo.TabIndex = 25;
            redo.Text = "Redo";
            redo.UseVisualStyleBackColor = true;
            redo.Click += redo_Click;
            // 
            // selectedFunction
            // 
            selectedFunction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectedFunction.Location = new Point(1058, 12);
            selectedFunction.Name = "selectedFunction";
            selectedFunction.Size = new Size(138, 40);
            selectedFunction.TabIndex = 26;
            // 
            // selectedShape
            // 
            selectedShape.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectedShape.Location = new Point(1058, 64);
            selectedShape.Name = "selectedShape";
            selectedShape.Size = new Size(138, 40);
            selectedShape.TabIndex = 27;
            // 
            // shapeColorChanger
            // 
            shapeColorChanger.Location = new Point(275, 8);
            shapeColorChanger.Name = "shapeColorChanger";
            shapeColorChanger.Size = new Size(122, 50);
            shapeColorChanger.TabIndex = 28;
            shapeColorChanger.Text = "Toggle color change";
            shapeColorChanger.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(25, 3);
            label1.Name = "label1";
            label1.Size = new Size(101, 19);
            label1.TabIndex = 29;
            label1.Text = "Thickness:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // freeDraw
            // 
            freeDraw.BackColor = SystemColors.Info;
            freeDraw.Location = new Point(414, 12);
            freeDraw.Name = "freeDraw";
            freeDraw.Size = new Size(94, 29);
            freeDraw.TabIndex = 30;
            freeDraw.Text = "Free Draw";
            freeDraw.UseVisualStyleBackColor = false;
            freeDraw.Click += freeDraw_Click;
            // 
            // saveFile
            // 
            saveFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveFile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveFile.ImageAlign = ContentAlignment.BottomCenter;
            saveFile.Location = new Point(1387, 12);
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(65, 50);
            saveFile.TabIndex = 31;
            saveFile.Text = "Save file";
            saveFile.UseVisualStyleBackColor = true;
            saveFile.Click += saveFile_Click;
            // 
            // loadFromFIle
            // 
            loadFromFIle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loadFromFIle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loadFromFIle.ImageAlign = ContentAlignment.BottomCenter;
            loadFromFIle.Location = new Point(915, 6);
            loadFromFIle.Name = "loadFromFIle";
            loadFromFIle.Size = new Size(130, 40);
            loadFromFIle.TabIndex = 32;
            loadFromFIle.Text = "Load from file";
            loadFromFIle.UseVisualStyleBackColor = true;
            loadFromFIle.Click += loadFromFIle_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1462, 460);
            Controls.Add(loadFromFIle);
            Controls.Add(saveFile);
            Controls.Add(freeDraw);
            Controls.Add(label1);
            Controls.Add(shapeColorChanger);
            Controls.Add(selectedShape);
            Controls.Add(selectedFunction);
            Controls.Add(redo);
            Controls.Add(undo);
            Controls.Add(thicknessBox);
            Controls.Add(parameter);
            Controls.Add(area);
            Controls.Add(chooseLine);
            Controls.Add(chooseElipse);
            Controls.Add(chooseObtuseTriangle);
            Controls.Add(chooseEquilateralTriangle);
            Controls.Add(chooseRightAngleTriangle);
            Controls.Add(chooseRhombus);
            Controls.Add(chooseSquare);
            Controls.Add(chooseRectangle);
            Controls.Add(resize);
            Controls.Add(pickColor);
            Controls.Add(savePicture);
            Controls.Add(clear);
            Controls.Add(fill);
            Controls.Add(delete);
            Controls.Add(move);
            Controls.Add(copy);
            Controls.Add(draw);
            Controls.Add(pictureBox1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button draw;
        private Button fill;
        private Button copy;
        private Button move;
        private Button delete;
        private Button clear;
        private Button savePicture;
        public PictureBox pictureBox1;
        private ColorDialog colorDialog1;
        private Button pickColor;
        private Button resize;
        private Button chooseRectangle;
        private Button chooseSquare;
        private Button chooseRhombus;
        private Button chooseRightAngleTriangle;
        private Button chooseEquilateralTriangle;
        private Button chooseObtuseTriangle;
        private Button chooseElipse;
        private Button chooseLine;
        private Label area;
        private Label parameter;
        private ComboBox thicknessBox;
        private Button undo;
        private Button redo;
        private Label selectedFunction;
        private Label selectedShape;
        private CheckBox shapeColorChanger;
        private Label label1;
        private Button freeDraw;
        private Button saveFile;
        private Button loadFromFIle;
    }
}