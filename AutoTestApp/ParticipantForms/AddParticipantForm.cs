using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTestApp
{
    enum VisiblePart
    {
        SelectAddWithoutSolution,
        SelectAddWithSolution,
        SelectAddSeveral,
        ParticipantCorrecting,
    }

    public partial class AddParticipantForm : Form
    {
        private int currentParticCounts = 0;
        private string[] addOneParticFiles;
        private string[] addSevParticFolders;
        bool isBtnCancelUnpack = true;
        bool dataAdded = false;
        int prevProblemsCount = 0;

        public AddParticipantForm()
        {
            InitializeComponent();
            using var db = new TSystemContext();
            currentParticCounts = db.Participants.Count() + 1;
            rbAddWOSolution.Checked = true;
            rbOneFolder.Checked = true;
        }

        private void UpdateVisiblePart(VisiblePart visiblePart)
        {
            pnlDataWO.Visible = visiblePart == VisiblePart.SelectAddWithoutSolution;
            pnlDataW.Visible = visiblePart == VisiblePart.SelectAddWithSolution;
            pnlDataSev.Visible = visiblePart == VisiblePart.SelectAddSeveral;
        }

        private void SetChooseAddTypePage()
        {
            pnlSelectAddTypePage.Visible = true;
            pnlUnpackProgress.Visible = false;
        }

        private void SetUnpackPage()
        {
            isBtnCancelUnpack = true;
            pnlSelectAddTypePage.Visible = false;
            btnCloseUnpack.Visible = false;
            btnCancelUnpack.Text = "Отмена";
            prbUnpack.Value = 0;
            lbProgressProcents.Text = "0%";
            tbUnpackedFiles.Text = "";
            pnlUnpackProgress.Visible = true;
        }

        private void rbAddWOSolution_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisiblePart(VisiblePart.SelectAddWithoutSolution);
            tbNameWO.Text = $"Участник {currentParticCounts}";
            btnNextFPage.Text = "ОК";
        }

        private void rbAddWSolution_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisiblePart(VisiblePart.SelectAddWithSolution);
            tbNameW.Text = $"Участник {currentParticCounts}";
            btnNextFPage.Text = "Далее";
        }

        private void rbAddSevWSolution_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisiblePart(VisiblePart.SelectAddSeveral);
            btnNextFPage.Text = "Далее";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rbAddWOSolution.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbNameWO.Text))
                {
                    MessageBox.Show("Не указано имя участника", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNameWO.Focus();
                    return;
                }

                using var db = new TSystemContext();
                db.Participants.Add(new Participant { Name = tbNameWO.Text });
                db.SaveChanges();

                dataAdded = true;
                Close();
            }
            else if (rbAddWSolution.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbNameW.Text))
                {
                    MessageBox.Show("Не указано имя участника", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNameW.Focus();
                    return;
                }
                if (addOneParticFiles == null)
                {
                    MessageBox.Show(rbSevFiles.Checked ? "Выберите файлы" : "Выберете директорию", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNameW.Focus();
                    return;
                }
                SetUnpackPage();
                bwUnpacker.RunWorkerAsync();
            }
            else
            {
                if (addSevParticFolders == null)
                {
                    MessageBox.Show("Выберите директорию", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNameW.Focus();
                    return;
                }
                if (addSevParticFolders.Length == 0)
                {
                    MessageBox.Show("Выбранное местоположение не содержит ни одной директории", "Некорректные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNameW.Focus();
                    return;
                }

                SetUnpackPage();
                bwUnpacker.RunWorkerAsync();
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (rbOneFolder.Checked && fbdMain.ShowDialog() == DialogResult.OK)
            {
                tbNameW.Text = Path.GetFileName(fbdMain.SelectedPath);
                addOneParticFiles = Directory.GetFiles(fbdMain.SelectedPath, "*.sb3");
            }
            else if (rbSevFiles.Checked && ofdMain.ShowDialog() == DialogResult.OK)
            {
                addOneParticFiles = ofdMain.FileNames;
            }
            else
            {
                return;
            }
            lbAddW.Text = string.Join(", ", addOneParticFiles.Select(s => Path.GetFileName(s)));
        }

        private void btnSelectFolders_Click(object sender, EventArgs e)
        {
            if (fbdMain.ShowDialog() == DialogResult.OK)
            {
                lbAddSev.Text = Path.GetFileName(fbdMain.SelectedPath);
                addSevParticFolders = Directory.GetDirectories(fbdMain.SelectedPath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbSevFiles_Click(object sender, EventArgs e)
        {
            rbSevFiles.Checked = true;
        }

        private void pbOneFolder_Click(object sender, EventArgs e)
        {
            rbOneFolder.Checked = true;
        }

        private void bwUnpacker_DoWork(object sender, DoWorkEventArgs e)
        {
            var unpacker = sender as BackgroundWorker;
            var foldersContent = rbAddWSolution.Checked ? // (Имя, Файлы)
                    new List<(string, string[])> { (tbNameW.Text, addOneParticFiles) } :
                    addSevParticFolders.Select(f => (Path.GetFileName(f), Directory.GetFiles(f, "*.sb3"))).ToList();
            var completed = 0;
            var allFilesCount = foldersContent.Sum(fc => fc.Item2.Length);
            List<Participant> participants = new();

            var maxSolCount = rbAddWSolution.Checked ?
                addOneParticFiles.Length :
                addSevParticFolders.Max(f => Directory.GetFiles(f, "*.sb3").Length);
            List<Problem> newProblems = new();
            List<Problem> prevProblems;
            List<Problem> allProblems;
            using (var db = new TSystemContext())
            {
                prevProblems = db.Problems.ToList();
                for (var i = db.Problems.Count(); i < maxSolCount; i++)
                {
                    newProblems.Add(new Problem { Cost = 1, Name = $"Задание {i + 1}", Num = i });
                }
                allProblems = prevProblems.Concat(newProblems).ToList();
                prevProblemsCount = prevProblems.Count;
            }

            Parallel.ForEach(foldersContent, (partFolder, stateJ, j) =>
            {
                var (partName, solFiles) = partFolder;
                var participant = new Participant { Name = partName };
                var jLoopBreak = false;
                Parallel.ForEach(solFiles, (solFile, stateI, i) =>
                {
                    unpacker.ReportProgress(completed * 100 / allFilesCount, solFile);
                    var thisProblem = allProblems.First(p => p.Num == i);
                    var solution = new Solution
                    {
                        FileName = Path.GetFileName(solFile),
                        Problem = thisProblem,
                        Participant = participant,
                        SolutionFile = ScratchToCS.Transpiler.ScratchToJson(solFile),
                        TestPassed = -1,
                    };
                    Interlocked.Increment(ref completed);
                    participant.Solutions.Add(solution);
                    thisProblem.Solutions.Add(solution);
                    if (unpacker.CancellationPending)
                    {
                        jLoopBreak = true;
                        stateI.Break();
                    }
                });
                if (jLoopBreak)
                {
                    stateJ.Break();
                }
                participants.Add(participant);
            });
            if (unpacker.CancellationPending)
            {
                unpacker.ReportProgress(completed * 100 / allFilesCount, "Распаковка прервана");
                e.Cancel = true;
            }
            else
            {
                using (var db = new TSystemContext())
                {
                    db.Problems.AddRange(newProblems);
                    db.Problems.AttachRange(prevProblems);
                    db.Participants.AddRange(participants);
                    db.SaveChanges();
                }
                unpacker.ReportProgress(100, "Готово");
                dataAdded = true;
            }
        }

        private void bwUnpacker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbUnpack.Value = e.ProgressPercentage;
            lbProgressProcents.Text = $"{e.ProgressPercentage}%";
            var filePath = (string)e.UserState;
            tbUnpackedFiles.AppendText(Path.Combine(
                Path.GetFileName(Path.GetDirectoryName(filePath)),
                Path.GetFileName(filePath)) + Environment.NewLine);
        }

        private void btnCancelUnpack_Click(object sender, EventArgs e)
        {
            if (isBtnCancelUnpack)
            {
                bwUnpacker.CancelAsync();
                btnCancelUnpack.Text = "Назад";
                btnCloseUnpack.Visible = true;
                isBtnCancelUnpack = false;
            }
            else
            {
                SetChooseAddTypePage();
            }
        }

        private void btnCloseUnpack_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void AddParticipantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataAdded)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private string DeclensionByNum(int num)
        {
            if (num >= 10 && num <= 20)
            {
                return "й";
            }
            var lastDigit = num % 10;
            if (lastDigit == 1)
            {
                return "е";
            }
            if (lastDigit >= 2 && lastDigit <= 4)
            {
                return "я";
            }
            return "й";
        }

        private void bwUnpacker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                btnCancelUnpack.Visible = false;
                btnCloseUnpack.Visible = true;
                if (rbAddWSolution.Checked)
                {
                    var solCount = addOneParticFiles.Length;
                    var createdProbCount = solCount - prevProblemsCount;
                    lbUnpackRes.Text =
                    $"Было обнаружено {solCount} решени{DeclensionByNum(solCount)}. " +
                    (createdProbCount <= 0 ? "Создание новых заданий не потребовалось. " : 
                        $"В результате чего дополнительно было создано {createdProbCount} задани{DeclensionByNum(createdProbCount)}.\n") +
                    "Рекомендуется соотнести задания с решениями в меню изменения данных участника из-за различных форматов именования файлов.";
                }
                else
                {
                    var maxSolCount = addSevParticFolders.Max(f => Directory.GetFiles(f, "*.sb3").Length);
                    var createdProbCount = maxSolCount - prevProblemsCount; lbUnpackRes.Text =
                     $"Добавленное количестсво участников - {addSevParticFolders.Length}.\n" +
                     $"Максимальное количество решений - {maxSolCount}. " +
                     (createdProbCount <= 0 ? "Создание новых заданий не потребовалось. " :
                         $"В результате чего дополнительно было создано {createdProbCount} задани{DeclensionByNum(createdProbCount)}.\n") +
                     "Рекомендуется соотнести задания с решениями в меню изменения данных участников из-за различных форматов именования файлов.";
                }
            }
        }
    }
}