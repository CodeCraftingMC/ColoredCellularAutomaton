using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ColoredCellularAutomaton
{
    public partial class MainForm : Form
    {
        static Cell EmptyCell { get { return LoadedSave.EmptyCell; } }
        static List<Cell> AvailableCells { get { return LoadedSave.AvailableCells; } }
        static int GridWidth { get { return LoadedSave.GridWidth; } }
        static int GridHeight { get { return LoadedSave.GridHeight; } }
        static Cell[,] Grid { get { return LoadedSave.Grid; } set { LoadedSave.Grid = value; } }
        static uint Generation { get { return LoadedSave.Generation; } set { LoadedSave.Generation = value; } }
        static CellularAutomatonSave LoadedSave { get { return CCAEnv.LoadedSave; } set { CCAEnv.LoadedSave = value; } }

        readonly object PaintCellsLock;

        Cell ActiveCell;

        public MainForm()
        {
            InitializeComponent();
            PaintCellsLock = new();
            NewSimulation();
        }

        void ReloadCellsFLP()
        {
            CellsFLP.SuspendLayout();

            CellsFLP.Controls.Clear();

            Panel[] cellPanels = new Panel[AvailableCells.Count];

            Parallel.For(0, cellPanels.Length, i =>
            {
                Cell cell = AvailableCells[i];
                Panel panel = new()
                {
                    Size = new(20, 20),
                    BackColor = cell.GetColor(),
                    Tag = cell
                };
                panel.Click += CellPanel_Click;
                cellPanels[i] = panel;
            });

            CellsFLP.Controls.AddRange(cellPanels);

            CellsFLP.ResumeLayout(true);
        }

        [MemberNotNull(nameof(LoadedSave), nameof(ActiveCell))]
        void NewSimulation(CellularAutomatonSave save)
        {
            LoadedSave = save;

            ActiveCell = EmptyCell;
            ReloadCellsFLP();
            Draw();

        }

        [MemberNotNull(nameof(LoadedSave), nameof(ActiveCell))]
        void NewSimulation()
        {
            NewSimulation(new(300, 300));
        }

        void Draw()
        {
            Bitmap bmp = new(GridWidth, GridHeight, PixelFormat.Format32bppArgb);
            Rectangle rect = new(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;

                Parallel.For(0, GridHeight, y =>
                {
                    for (int x = 0; x < GridWidth; x++)
                    {
                        int index = y * bmpData.Stride + x * bytesPerPixel;

                        Color pixelColor = Grid[x, y].GetColor();

                        ptr[index + 3] = pixelColor.A; // Alpha
                        ptr[index + 2] = pixelColor.R; // Red
                        ptr[index + 1] = pixelColor.G; // Green
                        ptr[index] = pixelColor.B;     // Blue
                    }
                });

            }

            bmp.UnlockBits(bmpData);

            GridPBWIM.SuspendLayout();
            GridPBWIM.Image?.Dispose();
            GridPBWIM.Image = bmp;
            GridPBWIM.ResumeLayout(true);
        }

        private void CellPanel_Click(object? sender, EventArgs e)
        {
            if (sender is not Panel p || p.Tag is not Cell c) return;
            switch (((MouseEventArgs)e).Button)
            {
                case MouseButtons.Right:
                    if (c.Equals(EmptyCell))
                    {
                        MessageBox.Show("Can't remove empty cell.", "Remove Cell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Do you want to remove this cell?", "Remove Cell",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (c.Equals(ActiveCell)) ActiveCell = EmptyCell;
                        AvailableCells.Remove(c);
                    }


                    break;
                case MouseButtons.Left:
                    ActiveCell = c;
                    break;
            }
            ReloadCellsFLP();
        }

        private void NewCellBtn_Click(object sender, EventArgs e)
        {
            CellCreatorForm cellCreator = new();
            if (cellCreator.ShowDialog() == DialogResult.OK)
            {
                if (AvailableCells.Find((c) => c.Equals(cellCreator.CreatedCell)) is null) AvailableCells.Add(cellCreator.CreatedCell);
                else _ = MessageBox.Show("This cell already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cellCreator.Dispose();

            ReloadCellsFLP();
        }

        private void PauseResumeBtn_Click(object sender, EventArgs e)
        {
            if (UnlimitedSpeedCB.Checked) return;
            if (SimTimer.Enabled) SimTimer.Stop();
            else SimTimer.Start();

            PauseResumeBtn.Text = SimTimer.Enabled ? "Pause" : "Resume";
        }

        private void StepBtn_Click(object sender, EventArgs e)
        {
            DoIteration();
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Grid[x, y] = AvailableCells[Random.Shared.Next(0, AvailableCells.Count)];
                }
            }
            Draw();
        }

        private async void SimTimer_Tick(object sender, EventArgs e)
        {
            await Task.Run(DoIteration);
        }

        bool IsWorkingOnIteration = false;
        void DoIteration()
        {
            if (IsWorkingOnIteration) return;
            IsWorkingOnIteration = true;
            List<Cell> availableCellsLastIteration = AvailableCells.ToList();
            for (int i = 0; i < StepsPerFrameNUD.Value; i++)
            {
                LoadedSave.Simulate();
            }
            Draw();
            if (!availableCellsLastIteration.SequenceEqual(AvailableCells) && !UnlimitedSpeedCB.Checked)
            {
                if (InvokeRequired) Invoke(ReloadCellsFLP);
                else ReloadCellsFLP();
            }
            GenerationLabel.Text = "Generation: " + Generation;
            IsWorkingOnIteration = false;
        }

        private void SpeedNUD_ValueChanged(object sender, EventArgs e)
        {
            SimTimer.Interval = (int)SpeedNUD.Value;
        }

        private void PaintCells(object sender, MouseEventArgs e)
        {
            int pictureBoxWidth = GridPBWIM.Width;
            int pictureBoxHeight = GridPBWIM.Height;

            float xScale = (float)GridWidth / pictureBoxWidth;
            float yScale = (float)GridHeight / pictureBoxHeight;

            float scale = Math.Max(xScale, yScale);

            int displayedImageWidth = (int)(GridWidth / scale);
            int displayedImageHeight = (int)(GridHeight / scale);

            int paddingX = (pictureBoxWidth - displayedImageWidth) / 2;
            int paddingY = (pictureBoxHeight - displayedImageHeight) / 2;

            int originalX = (int)((e.X - paddingX) * scale);
            int originalY = (int)((e.Y - paddingY) * scale);

            float halfBrushSize = (float)BrushSizeNUD.Value / 2f;

            if (e.Button == MouseButtons.Right)
            {
                if (originalX < 0 || originalX >= GridWidth ||
                originalY < 0 || originalY >= GridHeight)
                {
                    return;
                }
                Cell cell = Grid[originalX, originalY];
                List<Cell> neighbours = LoadedSave.GetNeighbours(originalX, originalY);

                int sameNeighbours = neighbours.Count(n => n.Equals(cell));
                int aliveNeighbours = neighbours.Count(n => n.IsAliveCell);
                int aliveSameNeighbours = neighbours.Count(n => n.IsAliveCell && n.Equals(cell));
                MessageBox.Show($"Same Neighbours: {sameNeighbours}\r\nSame Alive Neighbours: {aliveSameNeighbours}\r\nIsAlive: {cell.IsAliveCell}");
            }
            if (e.Button != MouseButtons.Left || !GridPBWIM.Bounds.Contains(e.Location)) return;

            for (float y = -halfBrushSize; y < halfBrushSize; y++)
            {
                for (float x = -halfBrushSize; x < halfBrushSize; x++)
                {
                    int tileX = (int)(originalX + x);
                    int tileY = (int)(originalY + y);
                    if (tileX < 0 || tileX >= GridWidth ||
                        tileY < 0 || tileY >= GridHeight)
                    {
                        continue;
                    }
                    Grid[tileX, tileY] = ActiveCell;
                }
            }
            Thread.Sleep(100);
            Draw();
        }

        private async void UnlimitedSpeedCB_CheckedChanged(object sender, EventArgs e) => await Task.Run(() =>
        {
            if (SimTimer.Enabled) SimTimer.Stop();
            if (InvokeRequired) Invoke(() => { PauseResumeBtn.Text = "SPEED"; });
            while (UnlimitedSpeedCB.Checked)
            {
                DoIteration();
            }
            if (InvokeRequired) Invoke(() => { PauseResumeBtn.Text = "Resume"; ReloadCellsFLP(); });
        });

        private void ClearGridTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear the grid?", "Clear Grid",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            LoadedSave.Clear();

            Draw();
        }

        private void NewTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to create a new simulation?", "New Simulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            NewSimulation();
        }

        private void SaveAllTSMI_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                AddExtension = true,
                CheckWriteAccess = true,
                DefaultExt = ".ccas",
                Filter = "Colored Cellular Automaton Save|*.ccas|All Files|*.*",
                OverwritePrompt = true,
                Title = "Save All"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dialog.FileName) ?? string.Empty);
                File.WriteAllBytes(dialog.FileName, LoadedSave.Serialize());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Could not save the simulation: {ex.Message}", "Save All", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTSMI_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                AddExtension = true,
                DefaultExt = ".ccas",
                Filter = "Colored Cellular Automaton Save|*.ccas|All Files|*.*",
                Multiselect = false,
                Title = "Load Simulation",
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                NewSimulation(new(File.ReadAllBytes(dialog.FileName)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load the simulation: {ex.Message}", "Load Simulation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}