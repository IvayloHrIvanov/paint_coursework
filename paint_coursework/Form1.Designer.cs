namespace Paint_course_work
{
    partial class Form1
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
            okButton = new System.Windows.Forms.Button();
            headline = new System.Windows.Forms.Label();
            heightLabel = new System.Windows.Forms.Label();
            widthLabel = new System.Windows.Forms.Label();
            widthTextBox = new System.Windows.Forms.TextBox();
            heightTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            okButton.Location = new System.Drawing.Point(326, 409);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(94, 29);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += button1_Click;
            // 
            // headline
            // 
            headline.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headline.AutoSize = true;
            headline.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            headline.Location = new System.Drawing.Point(91, 70);
            headline.Name = "headline";
            headline.Size = new System.Drawing.Size(619, 35);
            headline.TabIndex = 1;
            headline.Text = "Write the new width and height for the shape in pixels!";
            // 
            // heightLabel
            // 
            heightLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            heightLabel.AutoSize = true;
            heightLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            heightLabel.Location = new System.Drawing.Point(515, 204);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new System.Drawing.Size(75, 28);
            heightLabel.TabIndex = 2;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            widthLabel.AutoSize = true;
            widthLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            widthLabel.Location = new System.Drawing.Point(189, 204);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new System.Drawing.Size(70, 28);
            widthLabel.TabIndex = 3;
            widthLabel.Text = "Width:";
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new System.Drawing.Point(161, 235);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new System.Drawing.Size(125, 27);
            widthTextBox.TabIndex = 4;
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new System.Drawing.Point(488, 235);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new System.Drawing.Size(125, 27);
            heightTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(heightTextBox);
            Controls.Add(widthTextBox);
            Controls.Add(widthLabel);
            Controls.Add(heightLabel);
            Controls.Add(headline);
            Controls.Add(okButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label headline;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        public System.Windows.Forms.TextBox widthTextBox;
        public System.Windows.Forms.TextBox heightTextBox;
    }
}