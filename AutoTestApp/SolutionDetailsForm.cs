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
    public partial class SolutionDetailsForm : Form
    {
        Solution solution;
        public SolutionDetailsForm(Solution _solution)
        {
            InitializeComponent();
            solution = _solution;
            Text = solution.FileName;
            tbErrors.Text = (string.IsNullOrEmpty(solution.TranslationError) ? "" : 
                $"{solution.TranslationError}") + solution.Warnings;
            UpdateDgvTests();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (!string.IsNullOrEmpty(solution.TranslationError) || solution.Problem.Tests.Count == 0)
            {
                btnTestAll.Enabled = false;
            }
        }

        private void UpdateDgvTests()
        {
            dgvTests.Rows.Clear();
            var testsO = solution.Problem.Tests.OrderBy(t => t.Num).ToList();
            var idx = 1;
            foreach (var test in testsO)
            {
                var testResult = solution.TestResults.FirstOrDefault(tr => tr.Test.Id == test.Id);
                var rowIdx = dgvTests.Rows.Add($"Тест {idx++}", testResult?.ErrorText);
                dgvTests.Rows[rowIdx].Tag = test;
                SetRowStyle(rowIdx);
            }
            if (dgvTests.Rows.Count != 0)
            {
                dgvTests.Rows[0].Selected = false;
                dgvTests.Rows[0].Selected = true;
            }
        }

        private void SetRowStyle(int rowIdx)
        {
            var cell = dgvTests.Rows[rowIdx].Cells[0];
            if (!string.IsNullOrEmpty(solution.TranslationError))
            {
                cell.Style.SelectionForeColor = cell.Style.ForeColor = Color.White;
                cell.Style.SelectionBackColor = cell.Style.BackColor = Color.Black;
                return;
            }
            var test = (Test)dgvTests.Rows[rowIdx].Tag; 
            var testResult = solution.TestResults.FirstOrDefault(tr => tr.Test.Id == test.Id);
            if (testResult != null)
            {
                cell.Style.BackColor = testResult.IsCorrect ? Color.GreenYellow : Color.IndianRed;
            }
            else
            {
                cell.Style.BackColor = Color.LightGoldenrodYellow;
            }
            cell.Style.SelectionBackColor = cell.Style.BackColor;
            cell.Style.SelectionForeColor = cell.Style.ForeColor = Color.Black;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDeleteSolution_Click(object sender, EventArgs e)
        {
            using var db = new TSystemContext();
            db.Remove(solution);
            db.SaveChanges();
            solution = null;
            Close();
        }

        private void dgvTests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTests.SelectedRows.Count == 0)
            {
                tbInputTest.Text = tbOutputTest.Text = tbOutputSol.Text = "";
                return;
            }
            var test = (Test)dgvTests.SelectedRows[0].Tag;
            if (test == null) { return; }
            var testResult = solution.TestResults.FirstOrDefault(tr => tr.Test.Id == test.Id);
            tbInputTest.Text = test.InputData;
            tbOutputTest.Text = test.OutputData;
            tbOutputSol.Text = testResult?.ResultOutputData;
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            prbTest.Visible = true;
            bwMain.RunWorkerAsync();
        }

        private void bwMain_DoWork(object sender, DoWorkEventArgs e)
        {
            RunTests.Run(new() { solution }, bwMain);
        }

        private void bwMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbTest.Value = e.ProgressPercentage;
        }

        private void bwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            prbTest.Visible = false;
            UpdateDgvTests();
            tbErrors.Text = (string.IsNullOrEmpty(solution.TranslationError) ? "" :
                $"{solution.TranslationError}\r\n") + solution.Warnings;
            UpdateButtons();
        }
    }
}
