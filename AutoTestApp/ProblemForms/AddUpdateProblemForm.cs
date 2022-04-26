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
    public partial class AddUpdateProblemForm : Form
    {
        Problem problem;
        bool isAdd;
        bool dataChanged;
        bool closedByButtons = false;
        public AddUpdateProblemForm(Problem _problem, bool _isAdd)
        {
            InitializeComponent();
            problem = _problem;
            isAdd = _isAdd;
            Text = (isAdd ? "Добавление" : "Изменение") + " задания";
            tbName.Text = isAdd ? $"Задание {_problem.Num + 1}" : _problem.Name;
            nudCost.Value = isAdd ? 1 : (decimal)_problem.Cost;
            btnOK.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text != problem.Name || nudCost.Value != (decimal)problem.Cost)
            {
                dataChanged = true;
            }
            if (dataChanged && SaveProblem())
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

        private bool SaveProblem()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Не указано название задания", "Некорректные данные",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Text = problem.Name;
                tbName.Focus();
                return false;
            }
            problem.Name = tbName.Text;
            problem.Cost = (float)Decimal.Round(nudCost.Value, 2);
            return true;
        }

        private void AddUpdateProblemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAdd) { return; }
            if (tbName.Text != problem.Name || nudCost.Value != (decimal)problem.Cost)
            {
                dataChanged = true;
            }
            if (e.CloseReason == CloseReason.UserClosing && dataChanged && !closedByButtons)
            {
                var dialogResult = MessageBox.Show("Сохранить изменения?", "Изменения",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!SaveProblem())
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
    }
}
