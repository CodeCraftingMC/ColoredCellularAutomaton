namespace ColoredCellularAutomaton
{
    partial class CellCreatorForm
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
            CellPreviewPB = new PictureBoxWithInterpolationMode();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            S0CB = new CheckBox();
            S1CB = new CheckBox();
            S2CB = new CheckBox();
            S3CB = new CheckBox();
            S4CB = new CheckBox();
            S5CB = new CheckBox();
            S6CB = new CheckBox();
            S7CB = new CheckBox();
            S8CB = new CheckBox();
            B0CB = new CheckBox();
            B1CB = new CheckBox();
            B2CB = new CheckBox();
            B3CB = new CheckBox();
            B4CB = new CheckBox();
            B5CB = new CheckBox();
            B6CB = new CheckBox();
            B7CB = new CheckBox();
            B8CB = new CheckBox();
            OkBtn = new Button();
            CancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)CellPreviewPB).BeginInit();
            SuspendLayout();
            // 
            // CellPreviewPB
            // 
            CellPreviewPB.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            CellPreviewPB.Location = new Point(12, 12);
            CellPreviewPB.Name = "CellPreviewPB";
            CellPreviewPB.Size = new Size(200, 200);
            CellPreviewPB.SizeMode = PictureBoxSizeMode.StretchImage;
            CellPreviewPB.TabIndex = 0;
            CellPreviewPB.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 12);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 1;
            label1.Text = "Neighbours:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 12);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 1;
            label2.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 12);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 1;
            label3.Text = "2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(353, 12);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 1;
            label4.Text = "3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(372, 12);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 1;
            label5.Text = "4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(391, 12);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 1;
            label6.Text = "5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(410, 12);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 1;
            label7.Text = "6";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(429, 12);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 1;
            label8.Text = "7";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(448, 12);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 1;
            label9.Text = "8";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(296, 12);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 1;
            label10.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(242, 30);
            label11.Name = "label11";
            label11.Size = new Size(48, 15);
            label11.TabIndex = 1;
            label11.Text = "Survive:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(255, 50);
            label12.Name = "label12";
            label12.Size = new Size(35, 15);
            label12.TabIndex = 1;
            label12.Text = "Birth:";
            // 
            // S0CB
            // 
            S0CB.AutoSize = true;
            S0CB.Location = new Point(296, 30);
            S0CB.Name = "S0CB";
            S0CB.Size = new Size(15, 14);
            S0CB.TabIndex = 0;
            S0CB.UseVisualStyleBackColor = true;
            S0CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S1CB
            // 
            S1CB.AutoSize = true;
            S1CB.Location = new Point(315, 30);
            S1CB.Name = "S1CB";
            S1CB.Size = new Size(15, 14);
            S1CB.TabIndex = 1;
            S1CB.UseVisualStyleBackColor = true;
            S1CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S2CB
            // 
            S2CB.AutoSize = true;
            S2CB.Location = new Point(334, 30);
            S2CB.Name = "S2CB";
            S2CB.Size = new Size(15, 14);
            S2CB.TabIndex = 2;
            S2CB.UseVisualStyleBackColor = true;
            S2CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S3CB
            // 
            S3CB.AutoSize = true;
            S3CB.Location = new Point(353, 30);
            S3CB.Name = "S3CB";
            S3CB.Size = new Size(15, 14);
            S3CB.TabIndex = 3;
            S3CB.UseVisualStyleBackColor = true;
            S3CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S4CB
            // 
            S4CB.AutoSize = true;
            S4CB.Location = new Point(372, 30);
            S4CB.Name = "S4CB";
            S4CB.Size = new Size(15, 14);
            S4CB.TabIndex = 4;
            S4CB.UseVisualStyleBackColor = true;
            S4CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S5CB
            // 
            S5CB.AutoSize = true;
            S5CB.Location = new Point(391, 30);
            S5CB.Name = "S5CB";
            S5CB.Size = new Size(15, 14);
            S5CB.TabIndex = 5;
            S5CB.UseVisualStyleBackColor = true;
            S5CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S6CB
            // 
            S6CB.AutoSize = true;
            S6CB.Location = new Point(410, 30);
            S6CB.Name = "S6CB";
            S6CB.Size = new Size(15, 14);
            S6CB.TabIndex = 6;
            S6CB.UseVisualStyleBackColor = true;
            S6CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S7CB
            // 
            S7CB.AutoSize = true;
            S7CB.Location = new Point(429, 30);
            S7CB.Name = "S7CB";
            S7CB.Size = new Size(15, 14);
            S7CB.TabIndex = 7;
            S7CB.UseVisualStyleBackColor = true;
            S7CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // S8CB
            // 
            S8CB.AutoSize = true;
            S8CB.Location = new Point(448, 30);
            S8CB.Name = "S8CB";
            S8CB.Size = new Size(15, 14);
            S8CB.TabIndex = 8;
            S8CB.UseVisualStyleBackColor = true;
            S8CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B0CB
            // 
            B0CB.AutoSize = true;
            B0CB.Location = new Point(296, 50);
            B0CB.Name = "B0CB";
            B0CB.Size = new Size(15, 14);
            B0CB.TabIndex = 9;
            B0CB.UseVisualStyleBackColor = true;
            B0CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B1CB
            // 
            B1CB.AutoSize = true;
            B1CB.Location = new Point(315, 50);
            B1CB.Name = "B1CB";
            B1CB.Size = new Size(15, 14);
            B1CB.TabIndex = 10;
            B1CB.UseVisualStyleBackColor = true;
            B1CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B2CB
            // 
            B2CB.AutoSize = true;
            B2CB.Location = new Point(334, 50);
            B2CB.Name = "B2CB";
            B2CB.Size = new Size(15, 14);
            B2CB.TabIndex = 11;
            B2CB.UseVisualStyleBackColor = true;
            B2CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B3CB
            // 
            B3CB.AutoSize = true;
            B3CB.Location = new Point(353, 50);
            B3CB.Name = "B3CB";
            B3CB.Size = new Size(15, 14);
            B3CB.TabIndex = 12;
            B3CB.UseVisualStyleBackColor = true;
            B3CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B4CB
            // 
            B4CB.AutoSize = true;
            B4CB.Location = new Point(372, 50);
            B4CB.Name = "B4CB";
            B4CB.Size = new Size(15, 14);
            B4CB.TabIndex = 13;
            B4CB.UseVisualStyleBackColor = true;
            B4CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B5CB
            // 
            B5CB.AutoSize = true;
            B5CB.Location = new Point(391, 50);
            B5CB.Name = "B5CB";
            B5CB.Size = new Size(15, 14);
            B5CB.TabIndex = 14;
            B5CB.UseVisualStyleBackColor = true;
            B5CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B6CB
            // 
            B6CB.AutoSize = true;
            B6CB.Location = new Point(410, 50);
            B6CB.Name = "B6CB";
            B6CB.Size = new Size(15, 14);
            B6CB.TabIndex = 15;
            B6CB.UseVisualStyleBackColor = true;
            B6CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B7CB
            // 
            B7CB.AutoSize = true;
            B7CB.Location = new Point(429, 50);
            B7CB.Name = "B7CB";
            B7CB.Size = new Size(15, 14);
            B7CB.TabIndex = 16;
            B7CB.UseVisualStyleBackColor = true;
            B7CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // B8CB
            // 
            B8CB.AutoSize = true;
            B8CB.Location = new Point(448, 50);
            B8CB.Name = "B8CB";
            B8CB.Size = new Size(15, 14);
            B8CB.TabIndex = 17;
            B8CB.UseVisualStyleBackColor = true;
            B8CB.CheckedChanged += SBCondition_ValueChanged;
            // 
            // OkBtn
            // 
            OkBtn.Location = new Point(515, 189);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(75, 23);
            OkBtn.TabIndex = 18;
            OkBtn.Text = "OK";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(218, 189);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 19;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // CellCreatorForm
            // 
            AcceptButton = OkBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(602, 224);
            Controls.Add(CancelBtn);
            Controls.Add(OkBtn);
            Controls.Add(B8CB);
            Controls.Add(S8CB);
            Controls.Add(B7CB);
            Controls.Add(S7CB);
            Controls.Add(B6CB);
            Controls.Add(S6CB);
            Controls.Add(B5CB);
            Controls.Add(S5CB);
            Controls.Add(B4CB);
            Controls.Add(S4CB);
            Controls.Add(B3CB);
            Controls.Add(S3CB);
            Controls.Add(B2CB);
            Controls.Add(S2CB);
            Controls.Add(B1CB);
            Controls.Add(S1CB);
            Controls.Add(B0CB);
            Controls.Add(S0CB);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label1);
            Controls.Add(CellPreviewPB);
            Name = "CellCreatorForm";
            Text = "Cell Creator";
            Load += SBCondition_ValueChanged;
            ((System.ComponentModel.ISupportInitialize)CellPreviewPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBoxWithInterpolationMode CellPreviewPB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private CheckBox S0CB;
        private CheckBox S1CB;
        private CheckBox S2CB;
        private CheckBox S3CB;
        private CheckBox S4CB;
        private CheckBox S5CB;
        private CheckBox S6CB;
        private CheckBox S7CB;
        private CheckBox S8CB;
        private CheckBox B0CB;
        private CheckBox B1CB;
        private CheckBox B2CB;
        private CheckBox B3CB;
        private CheckBox B4CB;
        private CheckBox B5CB;
        private CheckBox B6CB;
        private CheckBox B7CB;
        private CheckBox B8CB;
        private Button OkBtn;
        private Button CancelBtn;
    }
}