using Microsoft.EntityFrameworkCore;
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
    public partial class ProblemsTestsForm : Form
    {
        List<Problem> removedProblems = new();
        List<Test> removedTests = new();
        bool closedByButtons = false;
        bool dataChanged = false;
        bool innerDataChanged = false;
        int dragEnd = -1;

        bool inputKeyDown = false;
        bool outputKeyDown = false;

        public ProblemsTestsForm()
        {
            InitializeComponent();
            UpdateDgvProblems();
            UpdateUpdDelBtnEnable();
            UpdateTestPanel();
        }

        private void DataChanged()
        {
            dataChanged = true;
            Text = "*Задания";
        }

        private void InnerDataChanged()
        {
            innerDataChanged = true;
            Text = "*Задания";
        }

        private void UpdateDgvProblems()
        {
            dgvProblems.Rows.Clear();
            using var db = new TSystemContext();
            var oProblems = db.Problems.Include(p => p.Tests).OrderBy(p => p.Num).ToList();
            foreach (var problem in oProblems)
            {
                var rowIdx = dgvProblems.Rows.Add(
                    problem.Name,
                    problem.ByTest ? (problem.Tests.Count == 0 ? "по ? за тест" :
                        $"по {problem.Cost / problem.Tests.Count} за тест") : problem.Cost,
                    problem.Tests.Count);
                dgvProblems.Rows[rowIdx].Tag = problem;
            }
        }

        private void UpdateProblemNums()
        {
            var num = 0;
            foreach (DataGridViewRow row in dgvProblems.Rows)
            {
                var problem = (Problem)row.Tag;
                problem.Num = num++;
            }
        }

        private void UpdateTestNums()
        {
            var num = 0;
            foreach (DataGridViewRow row in dgvTests.Rows)
            {
                var test = (Test)row.Tag;
                test.Num = num++;
            }
        }

        private void SaveProblems()
        {
            UpdateTestNums();
            using var db = new TSystemContext();
            var cRemovedProblems = removedProblems.Where(p => db.Problems.Contains(p)).ToList();
            var cRemovedTests = removedTests.Where(t => db.Tests.Contains(t)).ToList();
            db.Problems.RemoveRange(cRemovedProblems);
            db.SaveChanges();
            db.Tests.RemoveRange(cRemovedTests);
            db.SaveChanges();

            foreach (DataGridViewRow row in dgvProblems.Rows)
            {
                var problem = (Problem)row.Tag;
                if (db.Problems.Contains(problem))
                {
                    db.Problems.Attach(problem);
                    db.Entry(problem).Property("Num").IsModified = true;
                    db.Entry(problem).Property("Name").IsModified = true;
                    db.Entry(problem).Property("Cost").IsModified = true;
                    db.Entry(problem).Property("ByTest").IsModified = true;
                    foreach (var test in problem.Tests)
                    {
                        if (db.Tests.Contains(test))
                        {
                            db.Tests.Attach(test);
                            db.Entry(test).Property("InputData").IsModified = true;
                            db.Entry(test).Property("OutputData").IsModified = true;
                        }
                        else
                        {
                            db.Tests.Add(test);
                        }
                    }
                }
                else
                {
                    db.Problems.Add(problem);
                }
            }

            db.SaveChanges();
        }
        private void UpdateUpdDelBtnEnable()
        {
            btnUpdateProblem.Enabled = btnDeleteProblem.Enabled = dgvProblems.SelectedRows.Count > 0;
        }

        private void UpdateTestPanel()
        {
            dgvTests.Rows.Clear();
            tbInputData.Text = tbOutputData.Text = "";
            pnlTests.Enabled = dgvProblems.SelectedRows.Count > 0;
            if (!pnlTests.Enabled)
            {
                return;
            };
            var problem = (Problem)dgvProblems.SelectedRows[0].Tag;
            var testsO = problem.Tests.OrderBy(t => t.Num);
            var idx = 1;
            foreach (var test in testsO)
            {
                var rowIdx = dgvTests.Rows.Add($"Тест {idx++}");
                dgvTests.Rows[rowIdx].Tag = test;
            }
            if (dgvTests.Rows.Count != 0)
            {
                dgvTests.Rows[0].Selected = false;
                dgvTests.Rows[0].Selected = true;
            }
            TestsSelectionChanged();
        }

        private void tbInputData_KeyDown(object sender, KeyEventArgs e)
        {
            inputKeyDown = true;
        }

        private void tbOutputData_KeyDown(object sender, KeyEventArgs e)
        {
            outputKeyDown = true;
        }

        private void tbInputData_TextChanged(object sender, EventArgs e)
        {
            if (!inputKeyDown || dgvTests.SelectedRows.Count == 0)
            {
                return;
            }
            inputKeyDown = false;
            var test = (Test)dgvTests.SelectedRows[0].Tag;
            test.InputData = tbInputData.Text;
            InnerDataChanged();
        }

        private void tbOutputData_TextChanged(object sender, EventArgs e)
        {
            if (!outputKeyDown || dgvTests.SelectedRows.Count == 0)
            {
                return;
            }
            outputKeyDown = false;
            var test = (Test)dgvTests.SelectedRows[0].Tag;
            test.OutputData = tbOutputData.Text;
            InnerDataChanged();
        }

        private void TestsSelectionChanged()
        {
            if (dgvTests.SelectedRows.Count == 0)
            {
                tbInputData.Text = tbOutputData.Text = "";
                tbInputData.Enabled = false;
                tbOutputData.Enabled = false;
                btnDeleteTest.Enabled = false;
                return;
            }
            tbInputData.Enabled = true;
            tbOutputData.Enabled = true;
            btnDeleteTest.Enabled = true;
            var test = (Test)dgvTests.SelectedRows[0].Tag;
            tbInputData.Text = test?.InputData;
            tbOutputData.Text = test?.OutputData;
        }

        private void dgvTests_SelectionChanged(object sender, EventArgs e)
        {
            TestsSelectionChanged();
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            var problem = (Problem)dgvProblems.SelectedRows[0].Tag;
            var test = new Test { Problem = problem };
            problem.Tests.Add(test);
            var rowIdx = dgvTests.Rows.Add($"Тест {dgvTests.Rows.Count + 1}");
            dgvTests.Rows[rowIdx].Tag = test;
            dgvTests.Rows[rowIdx].Selected = true;
            if (problem.ByTest)
            {
                dgvProblems.SelectedRows[0].Cells[1].Value = $"по {problem.Cost / problem.Tests.Count} за тест";
            }
            dgvProblems.SelectedRows[0].Cells[2].Value = problem.Tests.Count;
            DataChanged();
        }

        private void btnAddSevTests_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDivider.Text))
            {
                MessageBox.Show("Не указан символ-разделитель", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDivider.Text = "$";
                tbDivider.Select();
                return;
            }
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                var files = ofdMain.FileNames;
                AddTestsFromFiles(files);
                DataChanged();
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDivider.Text))
            {
                MessageBox.Show("Не указан символ-разделитель", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDivider.Text = "$";
                tbDivider.Select();
                return;
            }
            if (fbdMain.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(fbdMain.SelectedPath, "*.txt");
                AddTestsFromFiles(files);
                DataChanged();
            }
        }

        private void AddTestsFromFiles(string[] files)
        {
            var badFiles = new List<string>();
            foreach(var file in files)
            {
                var text = File.ReadAllText(file);
                var data = text.Split(tbDivider.Text);
                string input = "", output = "";
                if (data.Length == 1)
                {
                    input = data[0].Trim('\r', '\n', ' ');
                }
                else if (data.Length == 2)
                {
                    input = data[0].Trim('\r', '\n', ' ');
                    output = data[1].Trim('\r', '\n', ' ');
                }
                else if (data.Length > 2)
                {
                    badFiles.Add(file);
                    continue;
                }
                var problem = (Problem)dgvProblems.SelectedRows[0].Tag;
                var test = new Test { Problem = problem, InputData = input, OutputData = output };
                problem.Tests.Add(test);
                var rowIdx = dgvTests.Rows.Add($"Тест {dgvTests.Rows.Count + 1}");
                dgvTests.Rows[rowIdx].Tag = test;
                dgvTests.Rows[rowIdx].Selected = true;
                if (problem.ByTest)
                {
                    dgvProblems.SelectedRows[0].Cells[1].Value = $"по {problem.Cost / problem.Tests.Count} за тест";
                }
                dgvProblems.SelectedRows[0].Cells[2].Value = problem.Tests.Count;
            }
            if (badFiles.Count != 0)
            {
                MessageBox.Show("При попытке разделения данных на входные и выходные " +
                    "было обнаружено несколько разделителей.\n " +
                    $"Данная ситуация встречается в файлах:\n + {string.Join("\n", badFiles)}", "Ошибка при чтении",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            var testRowIdx = dgvTests.SelectedRows[0].Index;
            var test = (Test)dgvTests.Rows[testRowIdx].Tag;
            var problem = (Problem)dgvProblems.SelectedRows[0].Tag;
            problem.Tests.Remove(test);
            removedTests.Add(test);
            UpdateTestPanel();
            if (dgvTests.Rows.Count > testRowIdx)
            {
                dgvTests.Rows[testRowIdx].Selected = true;
            }
            else if (testRowIdx != 0 && dgvTests.Rows.Count == testRowIdx)
            {
                dgvTests.Rows[testRowIdx - 1].Selected = true;
            }
            DataChanged();
            dgvProblems.SelectedRows[0].Cells[1].Value =
                problem.ByTest ? (problem.Tests.Count == 0 ? "по ? за тест" :
                    $"по {problem.Cost / problem.Tests.Count} за тест") : problem.Cost;
            dgvProblems.SelectedRows[0].Cells[2].Value = problem.Tests.Count;
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            var problem = new Problem { Cost = 0, Name = "", Num = dgvProblems.Rows.Count, ByTest = false };
            var addUpdateProblemForm = new AddUpdateProblemForm(problem, true);
            if (addUpdateProblemForm.ShowDialog() == DialogResult.OK)
            {
                var row = (DataGridViewRow)dgvProblems.RowTemplate.Clone();
                row.CreateCells(dgvProblems,
                    problem.Name,
                    problem.ByTest ? "по ? за тест" : problem.Cost,
                    0);
                row.Tag = problem;
                dgvProblems.Rows.Add(row);
                DataChanged();
                UpdateUpdDelBtnEnable();
            }
        }

        private void btnUpdateProblem_Click(object sender, EventArgs e)
        {
            var problem = (Problem)dgvProblems.SelectedRows[0].Tag;
            var addUpdateProblemForm = new AddUpdateProblemForm(problem, false);
            if (addUpdateProblemForm.ShowDialog() == DialogResult.OK)
            {
                dgvProblems.SelectedRows[0].Cells[0].Value = problem.Name;
                dgvProblems.SelectedRows[0].Cells[1].Value = 
                    problem.ByTest ? (problem.Tests.Count == 0 ? "по ? за тест" : 
                        $"по {problem.Cost / problem.Tests.Count} за тест") : problem.Cost;
                DataChanged();
            }
        }

        private void btnDeleteProblem_Click(object sender, EventArgs e)
        {
            var rowIdx = dgvProblems.SelectedRows[0].Index;
            var problem = (Problem)dgvProblems.Rows[rowIdx].Tag;
            removedProblems.Add(problem);
            dgvProblems.Rows.RemoveAt(rowIdx);
            DataChanged();
            UpdateUpdDelBtnEnable();
            UpdateProblemNums();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataChanged)
            {
                SaveProblems();
                DialogResult = DialogResult.OK;
            }
            else if (innerDataChanged)
            {
                SaveProblems();
            }
            closedByButtons = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closedByButtons = true;
            Close();
        }

        private void UpdateProblemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && (dataChanged || innerDataChanged) && !closedByButtons)
            {
                var dialogResult = MessageBox.Show("Сохранить изменения?", "Изменения",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveProblems();
                    if (dataChanged)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvProblems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUpdDelBtnEnable();
            UpdateTestPanel();
            if (dragEnd != -1)
            {
                dgvProblems.Rows[dragEnd].Selected = true;
                dragEnd = -1;
            }
        }

        private void dgvProblems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            dgvProblems.DoDragDrop(e.RowIndex, DragDropEffects.Move);
        }

        private void dgvProblems_DragOver(object sender, DragEventArgs e)
        {
            var point = dgvProblems.PointToClient(new Point(e.X, e.Y));
            var targetRowIdnx = dgvProblems.HitTest(point.X, point.Y).RowIndex;
            if (targetRowIdnx != -1)
            {
                dgvProblems.Rows[targetRowIdnx].Selected = true;
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void SwapRows(DataGridViewRow row1, DataGridViewRow row2)
        {
            var tempValue1 = row1.Cells[0].Value;
            var tempValue2 = row1.Cells[1].Value;
            var tempValue3 = row1.Cells[2].Value;
            var tempTag = row1.Tag;

            row1.Cells[0].Value = row2.Cells[0].Value;
            row1.Cells[1].Value = row2.Cells[1].Value;
            row1.Cells[2].Value = row2.Cells[2].Value;
            row1.Tag = row2.Tag;

            row2.Cells[0].Value = tempValue1;
            row2.Cells[1].Value = tempValue2;
            row2.Cells[2].Value = tempValue3;
            row2.Tag = tempTag;
        }

        private void dgvProblems_DragDrop(object sender, DragEventArgs e)
        {
            var point = dgvProblems.PointToClient(new Point(e.X, e.Y));
            var prevRowIndex = (int)e.Data.GetData(typeof(int));
            var newRowIndex = dgvProblems.HitTest(point.X, point.Y).RowIndex;
            if (newRowIndex != -1 && prevRowIndex != newRowIndex)
            {
                SwapRows(dgvProblems.Rows[prevRowIndex], dgvProblems.Rows[newRowIndex]);
                UpdateProblemNums();
                DataChanged();
                dragEnd = newRowIndex;
            }
        }
    }
}
