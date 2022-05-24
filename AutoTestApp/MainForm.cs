using Microsoft.EntityFrameworkCore;
using ScratchToCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTestApp
{
    public partial class MainForm : Form
    {
        int preTestSelectedRowIdx = -1;
        bool dataChanged = false;
        string savedFilePath;

        public MainForm()
        {
            InitializeComponent();
            Transpiler.ChangeSpecValues();
            UpdateDgvTestResults();
            UpdateBtnEnable();
        }

        private void DataChange()
        {
            dataChanged = true;
            if (!string.IsNullOrEmpty(savedFilePath))
            {
                Text = $"*{Path.GetFileName(savedFilePath)} - Система тестирования программ Scratch";
            }
        }

        private void UpdateDgvTestResults()
        {
            dgvTestResults.Columns.Clear();
            dgvTestResults.Rows.Clear();
            List<Participant> oParticipants;

            using (var db = new TSystemContext())
            {
                // Колонки
                dgvTestResults.Columns.Add("dgvcParticName", "Участник");
                dgvTestResults.Columns[0].Frozen = true;
                db.Problems.OrderBy(p => p.Num).ToList().ForEach(problem =>
                {
                    dgvTestResults.Columns.Add($"dgvcProblem{problem.Id}", problem.Name);
                    dgvTestResults.Columns[$"dgvcProblem{problem.Id}"].Tag = problem;
                });
                dgvTestResults.Columns.Add("dgvcResult", "Итог");
                oParticipants = db.Participants.OrderBy(p => p.Name).ToList();
            }
            // Строки
            foreach (var participant in oParticipants)
            {
                var rowIdx = dgvTestResults.Rows.Add();
                dgvTestResults.Rows[rowIdx].Tag = participant;
                UpdateDgvTestResultsRow(rowIdx);
            }
        }
        private void UpdateDgvTestResultsRow(int rowIdx)
        {
            using var db = new TSystemContext();
            var participant = db.Entry((Participant)dgvTestResults.Rows[rowIdx].Tag).Entity;
            var solutions = db.Solutions
                .Include(s => s.Problem)
                .Include(s => s.Problem.Tests)
                .Where(s => s.ParticipantId == participant.Id)
                .ToList();
            dgvTestResults.Rows[rowIdx].Cells["dgvcParticName"].Value = participant.Name;


            var resultScore = solutions.Sum(s =>
                s.Problem.Tests.Count > 0 ?
                    (s.Problem.ByTest ? s.Problem.Cost / s.Problem.Tests.Count * s.TestPassed :
                        (s.TestPassed == s.Problem.Tests.Count ? s.Problem.Cost : 0)) : 0);
            dgvTestResults.Rows[rowIdx].Cells["dgvcResult"].Value = resultScore;
            var row = dgvTestResults.Rows[rowIdx];

            // Ячейки
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ColumnIndex == 0 || cell.ColumnIndex == dgvTestResults.Columns.Count - 1)
                {
                    continue;
                }

                var cellProblem = db.Problems.Include(p => p.Tests).FirstOrDefault(p => p.Num == cell.ColumnIndex - 1);
                var cellSolution = db.Solutions.FirstOrDefault(s =>
                    s.ProblemId == cellProblem.Id && s.ParticipantId == participant.Id);
                SetCellStyle(cell, cellSolution);
            }
        }

        private void SetCellStyle(DataGridViewCell cell, Solution solution)
        {
            if (solution != null)
            {
                if (solution.TestPassed == -1)
                {
                    cell.Style.BackColor = Color.LightGoldenrodYellow;
                    cell.Style.ForeColor = Color.Black;
                    cell.Value = $"?/{solution.Problem.Tests.Count}";
                }
                else if (solution.TestPassed < solution.Problem.Tests.Count)
                {
                    if (solution.Problem.ByTest)
                    {
                        var bestColor = Color.GreenYellow;
                        var worstColor = Color.IndianRed;
                        var percent = (float)solution.TestPassed / solution.Problem.Tests.Count;
                        cell.Style.BackColor = Color.FromArgb(
                            (byte)(bestColor.R * percent + worstColor.R * (1 - percent)),
                            (byte)(bestColor.G * percent + worstColor.G * (1 - percent)),
                            (byte)(bestColor.B * percent + worstColor.B * (1 - percent)));
                    }
                    else
                    {
                        cell.Style.BackColor = Color.IndianRed;
                    }
                    cell.Style.ForeColor = Color.Black;
                    cell.Value = $"{solution.TestPassed}/{solution.Problem.Tests.Count}";
                }
                else
                {
                    cell.Style.BackColor = Color.GreenYellow;
                    cell.Style.ForeColor = Color.Black;
                    cell.Value = $"{solution.TestPassed}/{solution.Problem.Tests.Count}";
                }
                cell.Tag = solution;
            }
            else
            {
                cell.Value = "Выбрать...";
                cell.Style.ForeColor = Color.White;
                cell.Style.BackColor = Color.Black;
                cell.Tag = null;
            }
            cell.Style.SelectionBackColor = cell.Style.BackColor;
            cell.Style.SelectionForeColor = cell.Style.ForeColor;
        }

        private void UpdateBtnEnable()
        {
            btnUpdatePartic.Enabled =
            btnDeletePartic.Enabled =
            btnTestSelected.Enabled =
            btnTestAll.Enabled =
            btnSaveTable.Enabled =
                dgvTestResults.SelectedRows.Count > 0;
        }

        private void dgvTestResults_SelectionChanged(object sender, EventArgs e)
        {
            UpdateBtnEnable();
        }

        private void btnAddPartic_Click(object sender, EventArgs e)
        {
            var addParticForm = new AddParticipantForm();
            var dialogResult = addParticForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                UpdateDgvTestResults();
                UpdateBtnEnable();
                DataChange();
            }
        }

        private void btnUpdatePartic_Click(object sender, EventArgs e)
        {
            Participant participant;
            List<int> prevProblemIds;
            List<int> newProblemIds;
            using (var db = new TSystemContext())
            {
                participant = db.Entry((Participant)dgvTestResults.SelectedRows[0].Tag).Entity;
                prevProblemIds = db.Problems.OrderBy(p => p.Id).Select(p => p.Id).ToList();
                db.SaveChanges();
            }
            var updateParticForm = new UpdateParticipantForm(participant);
            var dialogResult = updateParticForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                using var db = new TSystemContext();
                newProblemIds = db.Problems.OrderBy(p => p.Id).Select(p => p.Id).ToList();
                var solutions = db.Solutions.Include(s => s.TestResults).Where(s => s.ParticipantId == participant.Id).ToList();
                solutions.ForEach(s => s.TestPassed = -1);
                db.TestResults.RemoveRange(solutions.SelectMany(s => s.TestResults));
                db.SaveChanges();
                if (Enumerable.SequenceEqual(prevProblemIds, newProblemIds))
                {
                    UpdateDgvTestResultsRow(dgvTestResults.SelectedRows[0].Index);
                }
                else
                {
                    UpdateDgvTestResults();
                }
                UpdateBtnEnable();
                DataChange();
            }
        }

        private void btnDeletePartic_Click(object sender, EventArgs e)
        {
            using var db = new TSystemContext();
            var selectedRowIdx = dgvTestResults.SelectedCells[0].RowIndex;
            var partic = db.Entry((Participant)dgvTestResults.Rows[selectedRowIdx].Tag).Entity;
            db.Participants.Remove(partic);
            db.SaveChanges();
            dgvTestResults.Rows.RemoveAt(selectedRowIdx);
            UpdateBtnEnable();
            DataChange();
        }

        private void dgvTestResults_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0 ||
                e.ColumnIndex == dgvTestResults.Columns.Count - 1 || bwTest.IsBusy) { return; }
            Cursor = Cursors.Hand;
        }

        private void dgvTestResults_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0 ||
                e.ColumnIndex == dgvTestResults.Columns.Count - 1 || bwTest.IsBusy) { return; }
            Cursor = Cursors.Default;
        }

        private void AddSolution(int rowIdx, int columnIdx)
        {
            using var db = new TSystemContext();
            var participant = (Participant)dgvTestResults.Rows[rowIdx].Tag;
            var problem = (Problem)dgvTestResults.Columns[columnIdx].Tag;
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                var solFile = Path.GetFileName(ofdMain.FileName);

                var solution = new Solution()
                {
                    FileName = solFile,
                    Problem = problem,
                    Participant = participant,
                    SolutionFile = ScratchToCS.Transpiler.ScratchToJson(ofdMain.FileName),
                    TestPassed = -1,
                };
                db.Participants.Attach(participant);
                db.Problems.Attach(problem);
                db.Solutions.Add(solution);
                db.SaveChanges();
                UpdateDgvTestResultsRow(rowIdx);
            }
        }

        private void dgvTestResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 0 ||
                e.ColumnIndex == dgvTestResults.Columns.Count - 1 || bwTest.IsBusy) { return; }
            var cell = dgvTestResults.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag == null)
            {
                AddSolution(e.RowIndex, e.ColumnIndex);
            }
            else
            {
                using var db = new TSystemContext();
                var solution = db.Solutions
                    .Include(s => s.TestResults)
                    .Include(s => s.Problem)
                    .Include(s => s.Problem.Tests)
                    .FirstOrDefault(s => s.Id == ((Solution)cell.Tag).Id);
                var solutionDetails = new SolutionDetailsForm(solution);
                solutionDetails.ShowDialog();
                SetCellStyle(cell, db.Solutions.Contains(solution) ? solution : null);
            }
        }

        private void tsmiProblemDetails_Click(object sender, EventArgs e)
        {
            var updateProblemForm = new ProblemsTestsForm();
            var dialogResult = updateProblemForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                UpdateDgvTestResults();
                DataChange();
            }
        }

        private void tsmiProblemAdd_Click(object sender, EventArgs e)
        {
            var problem = new Problem { Cost = 0, Name = "", Num = dgvTestResults.Columns.Count - 2, ByTest = false };
            var addUpdateProblemForm = new AddUpdateProblemForm(problem, true);
            if (addUpdateProblemForm.ShowDialog() == DialogResult.OK)
            {
                var columnIdx = dgvTestResults.Columns.Count - 1;
                var dgvcSolution = dgvTestResults.Columns["dgvcResult"].Clone() as DataGridViewColumn;
                dgvcSolution.Name = $"dgvcProblem{problem.Id}";
                dgvcSolution.HeaderText = problem.Name;
                dgvcSolution.Tag = problem;
                dgvTestResults.Columns.Insert(columnIdx, dgvcSolution);
                foreach (DataGridViewRow row in dgvTestResults.Rows)
                {
                    var cell = row.Cells[columnIdx];
                    cell.Value = "Выбрать...";
                    cell.Style.SelectionBackColor = cell.Style.BackColor = Color.Black;
                    cell.Style.SelectionForeColor = cell.Style.ForeColor = Color.White;
                    cell.Tag = null;
                }
                using var db = new TSystemContext();
                db.Problems.Add(problem);
                db.SaveChanges();
                DataChange();
            }
        }

        private void tsmiAddParticipant_Click(object sender, EventArgs e)
        {
            var addParticForm = new AddParticipantForm();
            var dialogResult = addParticForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                UpdateDgvTestResults();
                UpdateBtnEnable();
                DataChange();
            }
        }

        private void tsmiRatio_Click(object sender, EventArgs e)
        {
            var ratioForm = new RatioForm();
            var dialogResult = ratioForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                UpdateDgvTestResults();
                UpdateBtnEnable();
                DataChange();
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BlockButtons()
        {
            btnAddPartic.Enabled =
            btnUpdatePartic.Enabled =
            btnDeletePartic.Enabled =
            btnTestSelected.Enabled =
            btnTestAll.Enabled =
            btnSaveTable.Enabled = 
            msMain.Enabled = false;
        }

        private void UnlockButtons()
        {
            btnAddPartic.Enabled =
            btnUpdatePartic.Enabled =
            btnDeletePartic.Enabled =
            btnTestSelected.Enabled =
            btnTestAll.Enabled =
            btnSaveTable.Enabled =
            msMain.Enabled = true;
        }

        private void btnTestSelected_Click(object sender, EventArgs e)
        {
            var participantId = ((Participant)dgvTestResults.SelectedRows[0].Tag).Id;
            List<Solution> solutions;
            using var db = new TSystemContext();
            solutions = db.Solutions
                .Include(s => s.Problem)
                .Include(s => s.Problem.Tests)
                .Include(s => s.TestResults)
                .Where(s => s.ParticipantId == participantId)
                .ToList();
            BlockButtons();
            preTestSelectedRowIdx = dgvTestResults.SelectedRows[0].Index;
            prbTest.Visible = true;
            DataChange();
            bwTest.RunWorkerAsync(solutions);
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            List<Solution> solutions;
            using var db = new TSystemContext();
            solutions = db.Solutions
                .Include(s => s.Problem)
                .Include(s => s.Problem.Tests)
                .Include(s => s.TestResults)
                .ToList();
            BlockButtons();
            preTestSelectedRowIdx = -1;
            prbTest.Visible = true;
            DataChange();
            bwTest.RunWorkerAsync(solutions);
        }

        private void bwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            var solutions = (List<Solution>)e.Argument;
            RunTests.Run(solutions, bwTest);
        }

        private void bwTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbTest.Value = e.ProgressPercentage;
            lbTestingState.Text = (string)e.UserState;
        }

        private void bwTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbTestingState.Text = "";
            prbTest.Visible = false;
            if (preTestSelectedRowIdx == -1)
            {
                UpdateDgvTestResults();
            }
            else
            {
                UpdateDgvTestResultsRow(preTestSelectedRowIdx);
            }
            UnlockButtons();
        }

        private void ClearAll()
        {
            using var db = new TSystemContext();
            db.Participants.RemoveRange(db.Participants);
            db.Problems.RemoveRange(db.Problems);
            db.Solutions.RemoveRange(db.Solutions);
            db.Tests.RemoveRange(db.Tests);
            db.TestResults.RemoveRange(db.TestResults);
            db.SaveChanges();
            UpdateDgvTestResults();
            UpdateBtnEnable();
        }

        private void ArchiveDataBase(string newFilePath)
        {
            using (var fs = new FileStream(newFilePath, FileMode.Create))
            using (var arch = new ZipArchive(fs, ZipArchiveMode.Create, true))
            {
                arch.CreateEntryFromFile("tsystem.db", "tsystem.db");
            }
        }

        private void UnarchiveDataBase(string archpath)
        {
            ZipFile.ExtractToDirectory(archpath, Directory.GetCurrentDirectory());
        }

        private void SaveAs()
        {
            var dialogResult = sfdMain.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                savedFilePath = sfdMain.FileName;
                sfdMain.FileName = Path.GetFileName(savedFilePath);
                ArchiveDataBase(savedFilePath);
                Text = $"{Path.GetFileName(savedFilePath)} - Система тестирования программ Scratch";
            }
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(savedFilePath))
            {
                SaveAs();
            }
            else
            {
                ArchiveDataBase(savedFilePath);
                Text = $"{Path.GetFileName(savedFilePath)} - Система тестирования программ Scratch";
            }
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = sfdTable.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    var columnNames = dgvTestResults.Columns
                        .Cast<DataGridViewTextBoxColumn>()
                        .Select(column => column.HeaderText);
                    sb.AppendLine(string.Join(";", columnNames));

                    foreach (DataGridViewRow row in dgvTestResults.Rows)
                    {
                        IEnumerable<string> fields = row.Cells
                            .Cast<DataGridViewTextBoxCell>()
                            .Select(cell =>
                                string.Concat("\"", cell.Value
                                    .ToString()
                                    .Replace("\"", "\"\"")
                                    .Replace("Выбрать...", "Нет решения"), "\""));
                        sb.AppendLine(string.Join(";", fields));
                    }
                    File.WriteAllText(sfdTable.FileName, sb.ToString());
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка при сохранении",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            ClearAll();
            dataChanged = false;
            savedFilePath = null;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            var dialogResult = ofdSession.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                File.Delete("tsystem.db");
                savedFilePath = ofdSession.FileName;
                sfdMain.FileName = Path.GetFileName(savedFilePath);
                Text = $"{Path.GetFileName(savedFilePath)} - Система тестирования программ Scratch";
                UnarchiveDataBase(savedFilePath);
                UpdateDgvTestResults();
                UpdateBtnEnable();
                dataChanged = false;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Save();
            dataChanged = false;
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
            dataChanged = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {
                var dialogResult = MessageBox.Show("Сохранить сессию?", "Заврешение работы",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            ClearAll();
        }
    }
}
