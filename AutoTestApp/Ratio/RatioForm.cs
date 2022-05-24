using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTestApp
{
    public partial class RatioForm : Form
    {
        bool dataChanged;
        bool closedByButtons = false;
        List<Solution> allSolutions = new List<Solution>();
        List<Problem> allProblems = new List<Problem>();

        public RatioForm()
        {
            InitializeComponent();
            UpdateDgvRatio();
            btnOK.Select();
        }

        private void UpdateDgvRatio()
        {
            dgvRatio.Columns.Clear();
            dgvRatio.Rows.Clear();
            List<Participant> oParticipants;

            using (var db = new TSystemContext())
            {
                // Колонки
                allSolutions = db.Solutions.ToList();
                allProblems = db.Problems.ToList();
                dgvRatio.Columns.Add("dgvcParticName", "Участник");
                dgvRatio.Columns[0].Frozen = true;
                db.Problems.Include(p => p.Solutions).OrderBy(p => p.Num).ToList().ForEach(problem =>
                {
                    dgvRatio.Columns.Add($"dgvcProblem{problem.Id}", problem.Name);
                    dgvRatio.Columns[$"dgvcProblem{problem.Id}"].Tag = problem;
                });
                oParticipants = db.Participants.OrderBy(p => p.Name).ToList();
            }
            var ratio = new Ratio(allSolutions, allProblems);
            // Строки
            foreach (var participant in oParticipants)
            {
                var rowIdx = dgvRatio.Rows.Add();
                dgvRatio.Rows[rowIdx].Tag = participant;
                UpdateDgvRatioRow(rowIdx, ratio);
            }
        }
        private void UpdateDgvRatioRow(int rowIdx, Ratio ratio)
        {
            using var db = new TSystemContext();
            var participant = db.Entry((Participant)dgvRatio.Rows[rowIdx].Tag).Entity;
            var solutions = db.Solutions
                .Include(s => s.Problem)
                .Where(s => s.ParticipantId == participant.Id)
                .ToList();
            dgvRatio.Rows[rowIdx].Cells["dgvcParticName"].Value = participant.Name;
            var solidcoefs = ratio.CurrentСorrelate(solutions);

            var row = dgvRatio.Rows[rowIdx];
            // Ячейки
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ColumnIndex == 0)
                {
                    continue;
                }
                var cellProblem = db.Problems.Include(p => p.Tests).FirstOrDefault(p => p.Num == cell.ColumnIndex - 1);
                var cellSolution = db.Solutions.FirstOrDefault(s =>
                    s.ProblemId == cellProblem.Id && s.ParticipantId == participant.Id);
                var cellSolutionId = cellSolution?.Id;
                SetCellStyle(cell, cellSolution, cellSolutionId != null ? 
                    solidcoefs[cellSolution.Id] / ratio.MaxCoefficient : 0);
            }
        }

        private void SetCellStyle(DataGridViewCell cell, Solution solution, float coef)
        {
            if (solution != null)
            {
                var bestColor = Color.GreenYellow;
                var worstColor = Color.IndianRed;
                cell.Style.BackColor = Color.FromArgb(
                    (byte)(bestColor.R * coef + worstColor.R * (1 - coef)),
                    (byte)(bestColor.G * coef + worstColor.G * (1 - coef)),
                    (byte)(bestColor.B * coef + worstColor.B * (1 - coef)));
                cell.Style.ForeColor = Color.Black;
                cell.Value = solution.FileName;
                cell.Tag = solution;
            }
            else
            {
                cell.Value = "";
                cell.Style.BackColor = Color.GreenYellow;
                cell.Style.ForeColor = Color.Black;
                cell.Tag = null;
            }
            cell.Style.SelectionBackColor = cell.Style.BackColor;
            cell.Style.SelectionForeColor = cell.Style.ForeColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataChanged && Save())
            {
                DialogResult = DialogResult.OK;
            }
            closedByButtons = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closedByButtons = true;
            Close();
        }
        private bool Save()
        {
            foreach (DataGridViewColumn column in dgvRatio.Columns)
            {
                if (column.Tag != null)
                {
                    using var db = new TSystemContext();
                    var problem = (Problem)column.Tag;
                    db.Entry(problem).Collection("Solutions").IsModified = true;
                    db.Problems.Attach(problem);
                    db.SaveChanges();
                }
            }

            DialogResult = DialogResult.OK;
            return true;
        }

        private void RatioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && dataChanged && !closedByButtons)
            {
                var dialogResult = MessageBox.Show("Сохранить изменения?", "Изменения",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!Save())
                    {
                        e.Cancel = true;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvRatio_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0) { return; }
            if (dgvRatio.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
            {
                dgvRatio.Rows[e.RowIndex].Selected = true;
                dgvRatio.DoDragDrop((e.RowIndex, e.ColumnIndex), DragDropEffects.Move);
            }
        }

        private void dgvRatio_DragOver(object sender, DragEventArgs e)
        {
            var point = dgvRatio.PointToClient(new Point(e.X, e.Y));
            var targetColumnIdnx = dgvRatio.HitTest(point.X, point.Y).ColumnIndex;
            var targetRowIdnx = dgvRatio.HitTest(point.X, point.Y).RowIndex;
            var (rowIndex, prevColumnIndex) = ((int, int))e.Data.GetData(typeof((int, int)));
            if (targetColumnIdnx != 0 && targetRowIdnx == rowIndex)
            {
                dgvRatio.Rows[targetRowIdnx].Selected = true;
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgvRatio_DragDrop(object sender, DragEventArgs e)
        {
            var point = dgvRatio.PointToClient(new Point(e.X, e.Y));
            var (rowIndex, prevColumnIndex) = ((int, int))e.Data.GetData(typeof((int, int)));
            var newColumnIndex = dgvRatio.HitTest(point.X, point.Y).ColumnIndex;
            if (newColumnIndex != 0 && prevColumnIndex != newColumnIndex)
            {
                dgvRatio.Rows[rowIndex].Selected = true;
                SwapSolutions(rowIndex, prevColumnIndex, newColumnIndex);
            }
        }

        private void SwapSolutions(int rowIdx, int solCol1Idx, int solCol2Idx)
        {
            var solution1 = (Solution)(dgvRatio[solCol1Idx, rowIdx].Tag);
            var solution2 = (Solution)(dgvRatio[solCol2Idx, rowIdx].Tag);
            var problem1 = (Problem)(dgvRatio.Columns[solCol1Idx].Tag);
            var problem2 = (Problem)(dgvRatio.Columns[solCol2Idx].Tag);

            if (solution1 != null)
            {
                solution1.Problem = problem2;
                solution1.ProblemId = problem2.Id;
                problem1.Solutions.RemoveAll(s => s.Id == solution1.Id);
                problem2.Solutions.Add(solution1);
            }
            if (solution2 != null)
            {
                solution2.Problem = problem1;
                solution2.ProblemId = problem1.Id;
                problem2.Solutions.RemoveAll(s => s.Id == solution2.Id);
                problem1.Solutions.Add(solution2);
            }

            var pSolutions = new List<Solution>();
            foreach (DataGridViewCell cell in dgvRatio.Rows[rowIdx].Cells)
            {
                if (cell.Tag != null) {
                    pSolutions.Add((Solution)cell.Tag);
                }
            }
            var ratio = new Ratio(pSolutions, allProblems);
            var solidcoefs = ratio.CurrentСorrelate(pSolutions);
            var solutionId1 = solution1?.Id;
            var solutionId2 = solution2?.Id;
            SetCellStyle(dgvRatio[solCol1Idx, rowIdx], solution2, solutionId2 != null ?
                solidcoefs[solution2.Id] / ratio.MaxCoefficient : 0);
            SetCellStyle(dgvRatio[solCol2Idx, rowIdx], solution1, solutionId1 != null ?
                solidcoefs[solution1.Id] / ratio.MaxCoefficient : 0);
            dataChanged = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var ratio = new Ratio(allSolutions, allProblems);

            foreach (DataGridViewRow row in dgvRatio.Rows)
            {
                var participant = (Participant)row.Tag;
                var probsols = ratio.Сorrelate(participant.Id);
                foreach (var probsol in probsols)
                {
                    var problemId = probsol.Key;
                    var solutionId = probsol.Value.Item1;
                    var prevProblem = allProblems.First(p => p.Solutions.FirstOrDefault(s => s.Id == solutionId) != null);
                    var solution = participant.Solutions.FirstOrDefault(s => s.Id == solutionId);
                    prevProblem.Solutions.Remove(solution);
                    var thisProblem = allProblems.First(p => p.Id == problemId);
                    thisProblem.Solutions.Add(solution);
                    solution.Problem = thisProblem;
                }
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        continue;
                    }
                    Solution sol = null;
                    float coef = 0;
                    var cellProblem = (Problem)dgvRatio.Columns[cell.ColumnIndex].Tag;
                    if (cellProblem != null && probsols.ContainsKey(cellProblem.Id))
                    {
                        var (_solId, _coef) = probsols[cellProblem.Id];
                        sol = allSolutions.FirstOrDefault(s => s.Id == _solId);
                        coef = _coef / ratio.MaxCoefficient;
                    }
                    SetCellStyle(cell, sol, coef);
                }
            }
            dataChanged = true;
        }
    }
}
