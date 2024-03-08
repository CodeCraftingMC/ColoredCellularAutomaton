namespace ColoredCellularAutomaton
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
            components = new System.ComponentModel.Container();
            GridPBWIM = new PictureBoxWithInterpolationMode();
            SimTimer = new System.Windows.Forms.Timer(components);
            PauseResumeBtn = new Button();
            StepBtn = new Button();
            StepsPerFrameNUD = new NumericUpDown();
            SpeedNUD = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            RandomizeBtn = new Button();
            NewCellBtn = new Button();
            CellsFLP = new FlowLayoutPanel();
            UnlimitedSpeedCB = new CheckBox();
            menuStrip1 = new MenuStrip();
            FileTSMI = new ToolStripMenuItem();
            NewTSMI = new ToolStripMenuItem();
            SaveAllTSMI = new ToolStripMenuItem();
            LoadTSMI = new ToolStripMenuItem();
            EditTSMI = new ToolStripMenuItem();
            ClearGridTSMI = new ToolStripMenuItem();
            SettingsTSMI = new ToolStripMenuItem();
            BrushSizeNUD = new NumericUpDown();
            label3 = new Label();
            GenerationLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)GridPBWIM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StepsPerFrameNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpeedNUD).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BrushSizeNUD).BeginInit();
            SuspendLayout();
            // 
            // GridPBWIM
            // 
            GridPBWIM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridPBWIM.BackColor = Color.White;
            GridPBWIM.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            GridPBWIM.Location = new Point(12, 47);
            GridPBWIM.Name = "GridPBWIM";
            GridPBWIM.Size = new Size(431, 391);
            GridPBWIM.SizeMode = PictureBoxSizeMode.Zoom;
            GridPBWIM.TabIndex = 0;
            GridPBWIM.TabStop = false;
            GridPBWIM.MouseDown += PaintCells;
            GridPBWIM.MouseMove += PaintCells;
            // 
            // SimTimer
            // 
            SimTimer.Interval = 1;
            SimTimer.Tick += SimTimer_Tick;
            // 
            // PauseResumeBtn
            // 
            PauseResumeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PauseResumeBtn.Location = new Point(613, 415);
            PauseResumeBtn.Name = "PauseResumeBtn";
            PauseResumeBtn.Size = new Size(75, 23);
            PauseResumeBtn.TabIndex = 1;
            PauseResumeBtn.Text = "Resume";
            PauseResumeBtn.UseVisualStyleBackColor = true;
            PauseResumeBtn.Click += PauseResumeBtn_Click;
            // 
            // StepBtn
            // 
            StepBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StepBtn.Location = new Point(532, 415);
            StepBtn.Name = "StepBtn";
            StepBtn.Size = new Size(75, 23);
            StepBtn.TabIndex = 1;
            StepBtn.Text = "Step";
            StepBtn.UseVisualStyleBackColor = true;
            StepBtn.Click += StepBtn_Click;
            // 
            // StepsPerFrameNUD
            // 
            StepsPerFrameNUD.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StepsPerFrameNUD.Location = new Point(568, 27);
            StepsPerFrameNUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StepsPerFrameNUD.Name = "StepsPerFrameNUD";
            StepsPerFrameNUD.Size = new Size(120, 23);
            StepsPerFrameNUD.TabIndex = 2;
            StepsPerFrameNUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SpeedNUD
            // 
            SpeedNUD.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SpeedNUD.Location = new Point(568, 56);
            SpeedNUD.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            SpeedNUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            SpeedNUD.Name = "SpeedNUD";
            SpeedNUD.Size = new Size(120, 23);
            SpeedNUD.TabIndex = 3;
            SpeedNUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            SpeedNUD.ValueChanged += SpeedNUD_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(468, 29);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 4;
            label1.Text = "Steps Per Frame:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(493, 58);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Speed (ms):";
            // 
            // RandomizeBtn
            // 
            RandomizeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RandomizeBtn.Location = new Point(451, 415);
            RandomizeBtn.Name = "RandomizeBtn";
            RandomizeBtn.Size = new Size(75, 23);
            RandomizeBtn.TabIndex = 1;
            RandomizeBtn.Text = "Randomize";
            RandomizeBtn.UseVisualStyleBackColor = true;
            RandomizeBtn.Click += RandomizeBtn_Click;
            // 
            // NewCellBtn
            // 
            NewCellBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NewCellBtn.Location = new Point(568, 114);
            NewCellBtn.Name = "NewCellBtn";
            NewCellBtn.Size = new Size(120, 23);
            NewCellBtn.TabIndex = 1;
            NewCellBtn.Text = "Create new Cell";
            NewCellBtn.UseVisualStyleBackColor = true;
            NewCellBtn.Click += NewCellBtn_Click;
            // 
            // CellsFLP
            // 
            CellsFLP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            CellsFLP.AutoScroll = true;
            CellsFLP.Location = new Point(451, 151);
            CellsFLP.Name = "CellsFLP";
            CellsFLP.Size = new Size(237, 258);
            CellsFLP.TabIndex = 5;
            // 
            // UnlimitedSpeedCB
            // 
            UnlimitedSpeedCB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UnlimitedSpeedCB.AutoSize = true;
            UnlimitedSpeedCB.Location = new Point(449, 118);
            UnlimitedSpeedCB.Name = "UnlimitedSpeedCB";
            UnlimitedSpeedCB.Size = new Size(113, 19);
            UnlimitedSpeedCB.TabIndex = 6;
            UnlimitedSpeedCB.Text = "Unlimited Speed";
            UnlimitedSpeedCB.UseVisualStyleBackColor = true;
            UnlimitedSpeedCB.CheckedChanged += UnlimitedSpeedCB_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileTSMI, EditTSMI });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileTSMI
            // 
            FileTSMI.DropDownItems.AddRange(new ToolStripItem[] { NewTSMI, SaveAllTSMI, LoadTSMI });
            FileTSMI.Name = "FileTSMI";
            FileTSMI.Size = new Size(37, 20);
            FileTSMI.Text = "File";
            // 
            // NewTSMI
            // 
            NewTSMI.Name = "NewTSMI";
            NewTSMI.Size = new Size(180, 22);
            NewTSMI.Text = "New";
            NewTSMI.Click += NewTSMI_Click;
            // 
            // SaveAllTSMI
            // 
            SaveAllTSMI.Name = "SaveAllTSMI";
            SaveAllTSMI.Size = new Size(180, 22);
            SaveAllTSMI.Text = "Save All";
            SaveAllTSMI.Click += SaveAllTSMI_Click;
            // 
            // LoadTSMI
            // 
            LoadTSMI.Name = "LoadTSMI";
            LoadTSMI.Size = new Size(180, 22);
            LoadTSMI.Text = "Load";
            LoadTSMI.Click += LoadTSMI_Click;
            // 
            // EditTSMI
            // 
            EditTSMI.DropDownItems.AddRange(new ToolStripItem[] { ClearGridTSMI, SettingsTSMI });
            EditTSMI.Name = "EditTSMI";
            EditTSMI.Size = new Size(39, 20);
            EditTSMI.Text = "Edit";
            // 
            // ClearGridTSMI
            // 
            ClearGridTSMI.Name = "ClearGridTSMI";
            ClearGridTSMI.Size = new Size(126, 22);
            ClearGridTSMI.Text = "Clear Grid";
            ClearGridTSMI.Click += ClearGridTSMI_Click;
            // 
            // SettingsTSMI
            // 
            SettingsTSMI.Name = "SettingsTSMI";
            SettingsTSMI.Size = new Size(126, 22);
            SettingsTSMI.Text = "Settings";
            // 
            // BrushSizeNUD
            // 
            BrushSizeNUD.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrushSizeNUD.Location = new Point(568, 85);
            BrushSizeNUD.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            BrushSizeNUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            BrushSizeNUD.Name = "BrushSizeNUD";
            BrushSizeNUD.Size = new Size(120, 23);
            BrushSizeNUD.TabIndex = 3;
            BrushSizeNUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            BrushSizeNUD.ValueChanged += SpeedNUD_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(499, 87);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Brush Size:";
            // 
            // GenerationLabel
            // 
            GenerationLabel.AutoSize = true;
            GenerationLabel.Location = new Point(12, 29);
            GenerationLabel.Name = "GenerationLabel";
            GenerationLabel.Size = new Size(77, 15);
            GenerationLabel.TabIndex = 8;
            GenerationLabel.Text = "Generation: 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(GenerationLabel);
            Controls.Add(UnlimitedSpeedCB);
            Controls.Add(CellsFLP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BrushSizeNUD);
            Controls.Add(SpeedNUD);
            Controls.Add(StepsPerFrameNUD);
            Controls.Add(StepBtn);
            Controls.Add(RandomizeBtn);
            Controls.Add(NewCellBtn);
            Controls.Add(PauseResumeBtn);
            Controls.Add(GridPBWIM);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Colored Cellular Automaton";
            ((System.ComponentModel.ISupportInitialize)GridPBWIM).EndInit();
            ((System.ComponentModel.ISupportInitialize)StepsPerFrameNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpeedNUD).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BrushSizeNUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBoxWithInterpolationMode GridPBWIM;
        private System.Windows.Forms.Timer SimTimer;
        private Button PauseResumeBtn;
        private Button StepBtn;
        private NumericUpDown StepsPerFrameNUD;
        private NumericUpDown SpeedNUD;
        private Label label1;
        private Label label2;
        private Button RandomizeBtn;
        private Button NewCellBtn;
        private FlowLayoutPanel CellsFLP;
        private CheckBox UnlimitedSpeedCB;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileTSMI;
        private ToolStripMenuItem EditTSMI;
        private ToolStripMenuItem NewTSMI;
        private ToolStripMenuItem SaveAllTSMI;
        private ToolStripMenuItem LoadTSMI;
        private ToolStripMenuItem ClearGridTSMI;
        private NumericUpDown BrushSizeNUD;
        private Label label3;
        private ToolStripMenuItem SettingsTSMI;
        private Label GenerationLabel;
    }
}