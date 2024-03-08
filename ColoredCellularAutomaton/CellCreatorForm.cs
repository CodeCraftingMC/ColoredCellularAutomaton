using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColoredCellularAutomaton
{
    public partial class CellCreatorForm : Form
    {
        public Cell CreatedCell { get; set; }
        public CellCreatorForm()
        {
            CreatedCell = new()
            {
                IsAliveCell = true,
            };
            InitializeComponent();
        }

        private void SBCondition_ValueChanged(object sender, EventArgs e)
        {
            CreatedCell.SurviveConditions[0] = S0CB.Checked;
            CreatedCell.SurviveConditions[1] = S1CB.Checked;
            CreatedCell.SurviveConditions[2] = S2CB.Checked;
            CreatedCell.SurviveConditions[3] = S3CB.Checked;
            CreatedCell.SurviveConditions[4] = S4CB.Checked;
            CreatedCell.SurviveConditions[5] = S5CB.Checked;
            CreatedCell.SurviveConditions[6] = S6CB.Checked;
            CreatedCell.SurviveConditions[7] = S7CB.Checked;
            CreatedCell.SurviveConditions[8] = S8CB.Checked;

            CreatedCell.BirthConditions[0] = B0CB.Checked;
            CreatedCell.BirthConditions[1] = B1CB.Checked;
            CreatedCell.BirthConditions[2] = B2CB.Checked;
            CreatedCell.BirthConditions[3] = B3CB.Checked;
            CreatedCell.BirthConditions[4] = B4CB.Checked;
            CreatedCell.BirthConditions[5] = B5CB.Checked;
            CreatedCell.BirthConditions[6] = B6CB.Checked;
            CreatedCell.BirthConditions[7] = B7CB.Checked;
            CreatedCell.BirthConditions[8] = B8CB.Checked;

            CellPreviewPB.SuspendLayout();
            CellPreviewPB.Image?.Dispose();
            Bitmap newBmp = new(1, 1);
            newBmp.SetPixel(0, 0, CreatedCell.GetColor());
            CellPreviewPB.Image = newBmp;
            CellPreviewPB.ResumeLayout(true);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
