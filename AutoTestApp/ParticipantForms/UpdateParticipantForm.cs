using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTestApp
{
    public partial class UpdateParticipantForm : Form
    {
        Participant participant;
        List<Solution> removedSolutions = new(); 
        List<Problem> newProblems = new(); 
        bool dataChanged = false;
        bool closedByButtons = false;
        int dragEnd = -1;

        public UpdateParticipantForm(Participant _participant)
        {
            InitializeComponent();
            participant = _participant;
            UpdateDgvSolutions();
            UpdateUpdDelBtnEnable();
            tbName.Text = participant.Name;
            Text = $"{participant.Name} - Изменение данных участника";
        }
        private void UpdateUpdDelBtnEnable()
        {
            btnUpdateSolution.Enabled = btnDelSolution.Enabled = dgvSolutions.SelectedRows.Count > 0;
        }

        private void SetSolutionToRow(int rowIdx, Solution solution)
        {
            var cellSolution = dgvSolutions.Rows[rowIdx].Cells["dgvcSolution"];
            cellSolution.Value = solution.FileName;
            cellSolution.Style.BackColor = dgvSolutions.DefaultCellStyle.BackColor;
            cellSolution.Style.ForeColor = dgvSolutions.DefaultCellStyle.ForeColor;
            cellSolution.Tag = solution;
        }

        private void RemoveSolutionFromRow(int rowIdx)
        {
            var cellSolution = dgvSolutions.Rows[rowIdx].Cells["dgvcSolution"];
            cellSolution.Value = "Выбрать...";
            cellSolution.Style.ForeColor = Color.White;
            cellSolution.Style.BackColor = Color.Black;
            cellSolution.Tag = null;
        }

        private void UpdateDgvSolutions() 
        {
            participant.Solutions.Clear();
            dgvSolutions.Rows.Clear();
            using (var db = new TSystemContext())
            {
                var oProblems = db.Problems.OrderBy(p => p.Num).ToList();
                foreach (var problem in oProblems)
                {
                    var solution = db.Solutions.FirstOrDefault(s => s.ProblemId == problem.Id &&
                        s.ParticipantId == participant.Id);
                    var newRowIdx = dgvSolutions.Rows.Add();
                    dgvSolutions.Rows[newRowIdx].Tag = problem;
                    var cellProblem = dgvSolutions.Rows[newRowIdx].Cells["dgvcProblem"];
                    var cellSolution = dgvSolutions.Rows[newRowIdx].Cells["dgvcSolution"];
                    cellProblem.Value = problem.Name;
                    if (solution == null)
                    {
                        RemoveSolutionFromRow(newRowIdx);
                    }
                    else
                    {
                        participant.Solutions.Add(solution);
                        SetSolutionToRow(newRowIdx, solution);
                    }
                }
            }
        }

        private void dgvSolutions_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0) { return; }
            var cell = dgvSolutions.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell != null && cell.Tag == null)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void dgvSolutions_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0) { return; }
            var cell = dgvSolutions.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell != null && cell.Tag == null)
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddSolution(Problem problem, int rowIdx, bool update = false)
        {
            var solution = (Solution)dgvSolutions.Rows[rowIdx].Cells[1].Tag;
            if ((solution == null || update) && ofdMain.ShowDialog() == DialogResult.OK)
            {
                var solFile = Path.GetFileName(ofdMain.FileName);

                solution ??= new Solution();

                solution.FileName = solFile;
                solution.Problem = problem;
                solution.Participant = participant;
                solution.SolutionFile = ScratchToCS.Transpiler.ScratchToJson(ofdMain.FileName);
                solution.TestPassed = -1;

                SetSolutionToRow(rowIdx, solution);
                dataChanged = true;
                participant.Solutions.Add(solution);
            }
        }
        private void dgvSolutions_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0) { return; }
            var problem = (Problem)(dgvSolutions.Rows[e.RowIndex].Tag);
            if (dgvSolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
            {
                dgvSolutions.DoDragDrop(e.RowIndex, DragDropEffects.Move);
            }
            else
            {
                AddSolution(problem, e.RowIndex);
                Cursor = Cursors.Default;
            }
        }

        private void dgvSolutions_DragOver(object sender, DragEventArgs e)
        {
            var point = dgvSolutions.PointToClient(new Point(e.X, e.Y));
            var targetRowIdnx = dgvSolutions.HitTest(point.X, point.Y).RowIndex;
            if (targetRowIdnx != -1)
            {
                dgvSolutions.Rows[targetRowIdnx].Selected = true;
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgvSolutions_DragDrop(object sender, DragEventArgs e)
        {
            var point = dgvSolutions.PointToClient(new Point(e.X, e.Y));
            var prevRowIndex = (int)e.Data.GetData(typeof(int));
            var newRowIndex = dgvSolutions.HitTest(point.X, point.Y).RowIndex;
            if (newRowIndex != -1 && prevRowIndex != newRowIndex)
            {
                SwapSolutions(prevRowIndex, newRowIndex);
                dragEnd = newRowIndex;
            }
        }

        private void SwapSolutions(int solRow1Idx, int solRow2Idx)
        {
            using var db = new TSystemContext();
            var problem1 = (Problem)(dgvSolutions.Rows[solRow1Idx].Tag);
            var problem2 = (Problem)(dgvSolutions.Rows[solRow2Idx].Tag);
            var solution1 = (Solution)(dgvSolutions.Rows[solRow1Idx].Cells[1].Tag);
            var solution2 = (Solution)(dgvSolutions.Rows[solRow2Idx].Cells[1].Tag);

            if (solution1 != null)
            {
                solution1.Problem = problem2;
                solution1.ProblemId = problem2.Id;
                problem1.Solutions.Remove(solution1);
                problem2.Solutions.Add(solution1);
            }
            if (solution2 != null)
            {
                solution2.Problem = problem1;
                solution2.ProblemId = problem1.Id;
                problem2.Solutions.Remove(solution2);
                problem1.Solutions.Add(solution2);
            }
            SwapCells(dgvSolutions.Rows[solRow1Idx].Cells[1], dgvSolutions.Rows[solRow2Idx].Cells[1]);
            dataChanged = true;
        }

        private void SwapCells(DataGridViewCell cell1, DataGridViewCell cell2)
        {
            var tempStyle = cell1.Style;
            var tempValue = cell1.Value;
            var tempTag = cell1.Tag;

            cell1.Style = cell2.Style;
            cell1.Value = cell2.Value;
            cell1.Tag = cell2.Tag;

            cell2.Style = tempStyle;
            cell2.Value = tempValue;
            cell2.Tag = tempTag;
        }

        private bool SaveParticipant()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Не указано имя участника", "Некорректные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Text = participant.Name;
                tbName.Focus();
                return false;
            }
            else
            {
                participant.Name = tbName.Text;
            }
            using var db = new TSystemContext();
            db.Solutions.RemoveRange(removedSolutions);
            db.SaveChanges();
            db.Problems.AddRange(newProblems);
            db.SaveChanges();
            db.Participants.Attach(participant);
            db.Entry(participant).Property("Name").IsModified = true;
            participant.Solutions.Where(s => db.Solutions.Contains(s)).ToList().ForEach(s =>
            {
                db.Solutions.Attach(s);
                db.Entry(s).Property("FileName").IsModified = true;
                db.Entry(s).Property("SolutionFile").IsModified = true;
                db.Entry(s).Property("TestPassed").IsModified = true;
                db.Entry(s).Reference("Problem").IsModified = true;
            });

            db.SaveChanges();
            DialogResult = DialogResult.OK;
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text != participant.Name)
            {
                dataChanged = true;
            }
            if (dataChanged && SaveParticipant())
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

        private void UpdateParticipantForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tbName.Text != participant.Name)
            {
                dataChanged = true;
            }
            if (e.CloseReason == CloseReason.UserClosing && dataChanged && !closedByButtons)
            {
                var dialogResult = MessageBox.Show("Сохранить изменения?", "Изменения",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!SaveParticipant())
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

        private void dgvSolutions_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUpdDelBtnEnable();
            if (dragEnd != -1)
            {
                dgvSolutions.Rows[dragEnd].Selected = true;
                dragEnd = -1;
            }
        }

        private void btnDelSolution_Click(object sender, EventArgs e)
        {
            if (dgvSolutions.SelectedRows[0].Cells[1].Tag == null) { return; }
            using var db = new TSystemContext();
            var delSolution = (Solution)dgvSolutions.SelectedRows[0].Cells[1].Tag;
            if (db.Solutions.Find(delSolution.Id) != null)
            {
                removedSolutions.Add(delSolution);
            }
            participant.Solutions.Remove(delSolution);
            RemoveSolutionFromRow(dgvSolutions.SelectedRows[0].Index);
            dataChanged = true;
        }

        private void btnUpdateSolution_Click(object sender, EventArgs e)
        {
            var selectedRowIdx = dgvSolutions.SelectedRows[0].Index;
            var problem = (Problem)(dgvSolutions.SelectedRows[0].Tag);
            AddSolution(problem, selectedRowIdx, true);
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            var problem = new Problem { Cost = 0, Name = "", Num = dgvSolutions.Rows.Count, ByTest = false };
            var addUpdateProblemForm = new AddUpdateProblemForm(problem, true);
            if (addUpdateProblemForm.ShowDialog() == DialogResult.OK)
            {
                var rowIdx = dgvSolutions.Rows.Add(problem.Name, "");
                dgvSolutions.Rows[rowIdx].Tag = problem;
                newProblems.Add(problem);
                RemoveSolutionFromRow(rowIdx);
                dataChanged = true;
                UpdateUpdDelBtnEnable();
            }
        }
    }
}
