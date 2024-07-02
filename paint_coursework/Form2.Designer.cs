namespace Paint_course_work
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pencil = new System.Windows.Forms.Button();
            eraser = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            pencilThicknessBox = new System.Windows.Forms.ComboBox();
            clear = new System.Windows.Forms.Button();
            pickColor = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            eraserThicknessBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pencil
            // 
            pencil.Location = new System.Drawing.Point(527, 21);
            pencil.Name = "pencil";
            pencil.Size = new System.Drawing.Size(94, 51);
            pencil.TabIndex = 0;
            pencil.Text = "Pencil";
            pencil.UseVisualStyleBackColor = true;
            pencil.Click += pencil_Click;
            // 
            // eraser
            // 
            eraser.Location = new System.Drawing.Point(627, 21);
            eraser.Name = "eraser";
            eraser.Size = new System.Drawing.Size(94, 51);
            eraser.TabIndex = 1;
            eraser.Text = "Eraser";
            eraser.UseVisualStyleBackColor = true;
            eraser.Click += eraser_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.BackColor = System.Drawing.Color.LightGray;
            pictureBox1.Location = new System.Drawing.Point(1, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(1168, 610);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(10, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(153, 35);
            label1.TabIndex = 31;
            label1.Text = "Pencil Thickness:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pencilThicknessBox
            // 
            pencilThicknessBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            pencilThicknessBox.FormattingEnabled = true;
            pencilThicknessBox.Location = new System.Drawing.Point(21, 47);
            pencilThicknessBox.Name = "pencilThicknessBox";
            pencilThicknessBox.Size = new System.Drawing.Size(131, 28);
            pencilThicknessBox.TabIndex = 30;
            pencilThicknessBox.Tag = "";
            pencilThicknessBox.SelectedIndexChanged += pencilThicknessBox_SelectedIndexChanged;
            // 
            // clear
            // 
            clear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clear.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            clear.Location = new System.Drawing.Point(1026, 17);
            clear.Name = "clear";
            clear.Size = new System.Drawing.Size(132, 58);
            clear.TabIndex = 32;
            clear.Text = "Clear";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // pickColor
            // 
            pickColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pickColor.BackColor = System.Drawing.Color.Black;
            pickColor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            pickColor.Location = new System.Drawing.Point(332, 17);
            pickColor.Name = "pickColor";
            pickColor.Size = new System.Drawing.Size(120, 58);
            pickColor.TabIndex = 33;
            pickColor.UseVisualStyleBackColor = false;
            pickColor.Click += pickColor_Click;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(169, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(157, 35);
            label2.TabIndex = 35;
            label2.Text = "Eraser Thickness:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eraserThicknessBox
            // 
            eraserThicknessBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            eraserThicknessBox.FormattingEnabled = true;
            eraserThicknessBox.Location = new System.Drawing.Point(186, 47);
            eraserThicknessBox.Name = "eraserThicknessBox";
            eraserThicknessBox.Size = new System.Drawing.Size(131, 28);
            eraserThicknessBox.TabIndex = 34;
            eraserThicknessBox.Tag = "";
            eraserThicknessBox.SelectedIndexChanged += eraserThicknessBox_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1170, 704);
            Controls.Add(label2);
            Controls.Add(eraserThicknessBox);
            Controls.Add(pickColor);
            Controls.Add(clear);
            Controls.Add(label1);
            Controls.Add(pencilThicknessBox);
            Controls.Add(pictureBox1);
            Controls.Add(eraser);
            Controls.Add(pencil);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button pencil;
        private System.Windows.Forms.Button eraser;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pencilThicknessBox;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button pickColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox eraserThicknessBox;
    }
}