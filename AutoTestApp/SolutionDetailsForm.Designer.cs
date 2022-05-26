
namespace AutoTestApp
{
    partial class SolutionDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpLeftSide = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.dgvcTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTestAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.prbTest = new System.Windows.Forms.ProgressBar();
            this.btnDeleteSolution = new System.Windows.Forms.Button();
            this.tlpTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.gbOutputSol = new System.Windows.Forms.GroupBox();
            this.tbOutputSol = new System.Windows.Forms.TextBox();
            this.gbTestInput = new System.Windows.Forms.GroupBox();
            this.tbInputTest = new System.Windows.Forms.TextBox();
            this.gbOutputTest = new System.Windows.Forms.GroupBox();
            this.tbOutputTest = new System.Windows.Forms.TextBox();
            this.bwMain = new System.ComponentModel.BackgroundWorker();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbWarnings = new System.Windows.Forms.GroupBox();
            this.tbErrors = new System.Windows.Forms.TextBox();
            this.tlpMain1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeftSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.tlpTextboxes.SuspendLayout();
            this.gbOutputSol.SuspendLayout();
            this.gbTestInput.SuspendLayout();
            this.gbOutputTest.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.gbWarnings.SuspendLayout();
            this.tlpMain1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLeftSide
            // 
            this.tlpLeftSide.ColumnCount = 1;
            this.tlpLeftSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftSide.Controls.Add(this.dgvTests, 0, 0);
            this.tlpLeftSide.Controls.Add(this.btnTestAll, 0, 1);
            this.tlpLeftSide.Controls.Add(this.btnExit, 0, 3);
            this.tlpLeftSide.Controls.Add(this.prbTest, 0, 2);
            this.tlpLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftSide.Location = new System.Drawing.Point(3, 3);
            this.tlpLeftSide.Name = "tlpLeftSide";
            this.tlpLeftSide.RowCount = 4;
            this.tlpLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeftSide.Size = new System.Drawing.Size(187, 363);
            this.tlpLeftSide.TabIndex = 0;
            // 
            // dgvTests
            // 
            this.dgvTests.AllowDrop = true;
            this.dgvTests.AllowUserToAddRows = false;
            this.dgvTests.AllowUserToDeleteRows = false;
            this.dgvTests.AllowUserToResizeColumns = false;
            this.dgvTests.AllowUserToResizeRows = false;
            this.dgvTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcTest,
            this.dgvcError});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTests.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTests.Location = new System.Drawing.Point(3, 3);
            this.dgvTests.MultiSelect = false;
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.ReadOnly = true;
            this.dgvTests.RowHeadersVisible = false;
            this.dgvTests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTests.RowTemplate.Height = 25;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(181, 267);
            this.dgvTests.TabIndex = 4;
            this.dgvTests.SelectionChanged += new System.EventHandler(this.dgvTests_SelectionChanged);
            // 
            // dgvcTest
            // 
            this.dgvcTest.HeaderText = "Тест";
            this.dgvcTest.Name = "dgvcTest";
            this.dgvcTest.ReadOnly = true;
            this.dgvcTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcError
            // 
            this.dgvcError.HeaderText = "Ошибка выполнения";
            this.dgvcError.Name = "dgvcError";
            this.dgvcError.ReadOnly = true;
            this.dgvcError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnTestAll
            // 
            this.btnTestAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestAll.Location = new System.Drawing.Point(3, 276);
            this.btnTestAll.Name = "btnTestAll";
            this.btnTestAll.Size = new System.Drawing.Size(181, 24);
            this.btnTestAll.TabIndex = 2;
            this.btnTestAll.Text = "Выполнить тесты";
            this.btnTestAll.UseVisualStyleBackColor = true;
            this.btnTestAll.Click += new System.EventHandler(this.btnTestAll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(3, 336);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(181, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // prbTest
            // 
            this.prbTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbTest.Location = new System.Drawing.Point(3, 306);
            this.prbTest.Name = "prbTest";
            this.prbTest.Size = new System.Drawing.Size(181, 24);
            this.prbTest.Step = 1;
            this.prbTest.TabIndex = 5;
            this.prbTest.Visible = false;
            // 
            // btnDeleteSolution
            // 
            this.btnDeleteSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteSolution.Location = new System.Drawing.Point(3, 8);
            this.btnDeleteSolution.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnDeleteSolution.MaximumSize = new System.Drawing.Size(0, 24);
            this.btnDeleteSolution.Name = "btnDeleteSolution";
            this.btnDeleteSolution.Size = new System.Drawing.Size(387, 24);
            this.btnDeleteSolution.TabIndex = 3;
            this.btnDeleteSolution.Text = "Удалить решение";
            this.btnDeleteSolution.UseVisualStyleBackColor = true;
            this.btnDeleteSolution.Click += new System.EventHandler(this.btnDeleteSolution_Click);
            // 
            // tlpTextboxes
            // 
            this.tlpTextboxes.ColumnCount = 1;
            this.tlpTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTextboxes.Controls.Add(this.gbOutputSol, 0, 2);
            this.tlpTextboxes.Controls.Add(this.gbTestInput, 0, 0);
            this.tlpTextboxes.Controls.Add(this.gbOutputTest, 0, 1);
            this.tlpTextboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTextboxes.Location = new System.Drawing.Point(193, 0);
            this.tlpTextboxes.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTextboxes.Name = "tlpTextboxes";
            this.tlpTextboxes.RowCount = 3;
            this.tlpTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTextboxes.Size = new System.Drawing.Size(194, 369);
            this.tlpTextboxes.TabIndex = 1;
            // 
            // gbOutputSol
            // 
            this.gbOutputSol.Controls.Add(this.tbOutputSol);
            this.gbOutputSol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOutputSol.Location = new System.Drawing.Point(3, 249);
            this.gbOutputSol.Name = "gbOutputSol";
            this.gbOutputSol.Size = new System.Drawing.Size(188, 117);
            this.gbOutputSol.TabIndex = 4;
            this.gbOutputSol.TabStop = false;
            this.gbOutputSol.Text = "Выход решения";
            // 
            // tbOutputSol
            // 
            this.tbOutputSol.BackColor = System.Drawing.SystemColors.Window;
            this.tbOutputSol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutputSol.Location = new System.Drawing.Point(3, 19);
            this.tbOutputSol.Multiline = true;
            this.tbOutputSol.Name = "tbOutputSol";
            this.tbOutputSol.ReadOnly = true;
            this.tbOutputSol.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputSol.Size = new System.Drawing.Size(182, 95);
            this.tbOutputSol.TabIndex = 0;
            this.tbOutputSol.WordWrap = false;
            // 
            // gbTestInput
            // 
            this.gbTestInput.Controls.Add(this.tbInputTest);
            this.gbTestInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTestInput.Location = new System.Drawing.Point(3, 3);
            this.gbTestInput.Name = "gbTestInput";
            this.gbTestInput.Size = new System.Drawing.Size(188, 117);
            this.gbTestInput.TabIndex = 2;
            this.gbTestInput.TabStop = false;
            this.gbTestInput.Text = "Вход теста";
            // 
            // tbInputTest
            // 
            this.tbInputTest.BackColor = System.Drawing.SystemColors.Window;
            this.tbInputTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInputTest.Location = new System.Drawing.Point(3, 19);
            this.tbInputTest.Multiline = true;
            this.tbInputTest.Name = "tbInputTest";
            this.tbInputTest.ReadOnly = true;
            this.tbInputTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInputTest.Size = new System.Drawing.Size(182, 95);
            this.tbInputTest.TabIndex = 0;
            this.tbInputTest.WordWrap = false;
            // 
            // gbOutputTest
            // 
            this.gbOutputTest.Controls.Add(this.tbOutputTest);
            this.gbOutputTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOutputTest.Location = new System.Drawing.Point(3, 126);
            this.gbOutputTest.Name = "gbOutputTest";
            this.gbOutputTest.Size = new System.Drawing.Size(188, 117);
            this.gbOutputTest.TabIndex = 3;
            this.gbOutputTest.TabStop = false;
            this.gbOutputTest.Text = "Выход теста";
            // 
            // tbOutputTest
            // 
            this.tbOutputTest.BackColor = System.Drawing.SystemColors.Window;
            this.tbOutputTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutputTest.Location = new System.Drawing.Point(3, 19);
            this.tbOutputTest.Multiline = true;
            this.tbOutputTest.Name = "tbOutputTest";
            this.tbOutputTest.ReadOnly = true;
            this.tbOutputTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputTest.Size = new System.Drawing.Size(182, 95);
            this.tbOutputTest.TabIndex = 0;
            this.tbOutputTest.WordWrap = false;
            // 
            // bwMain
            // 
            this.bwMain.WorkerReportsProgress = true;
            this.bwMain.WorkerSupportsCancellation = true;
            this.bwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMain_DoWork);
            this.bwMain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwMain_ProgressChanged);
            this.bwMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMain_RunWorkerCompleted);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.tlpLeftSide, 0, 0);
            this.tlpMain.Controls.Add(this.tlpTextboxes, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 133);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tlpMain.Size = new System.Drawing.Size(387, 369);
            this.tlpMain.TabIndex = 1;
            // 
            // gbWarnings
            // 
            this.gbWarnings.Controls.Add(this.tbErrors);
            this.gbWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbWarnings.Location = new System.Drawing.Point(3, 43);
            this.gbWarnings.Name = "gbWarnings";
            this.gbWarnings.Size = new System.Drawing.Size(387, 84);
            this.gbWarnings.TabIndex = 5;
            this.gbWarnings.TabStop = false;
            this.gbWarnings.Text = "Ошибки и предупреждения";
            // 
            // tbErrors
            // 
            this.tbErrors.BackColor = System.Drawing.SystemColors.Window;
            this.tbErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbErrors.Location = new System.Drawing.Point(3, 19);
            this.tbErrors.Multiline = true;
            this.tbErrors.Name = "tbErrors";
            this.tbErrors.ReadOnly = true;
            this.tbErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbErrors.Size = new System.Drawing.Size(381, 62);
            this.tbErrors.TabIndex = 0;
            // 
            // tlpMain1
            // 
            this.tlpMain1.ColumnCount = 1;
            this.tlpMain1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain1.Controls.Add(this.tlpMain, 0, 2);
            this.tlpMain1.Controls.Add(this.btnDeleteSolution, 0, 0);
            this.tlpMain1.Controls.Add(this.gbWarnings, 0, 1);
            this.tlpMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain1.Location = new System.Drawing.Point(0, 0);
            this.tlpMain1.Name = "tlpMain1";
            this.tlpMain1.RowCount = 3;
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.35484F));
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.64516F));
            this.tlpMain1.Size = new System.Drawing.Size(393, 505);
            this.tlpMain1.TabIndex = 2;
            // 
            // SolutionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 505);
            this.Controls.Add(this.tlpMain1);
            this.MinimumSize = new System.Drawing.Size(274, 342);
            this.Name = "SolutionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tlpLeftSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.tlpTextboxes.ResumeLayout(false);
            this.gbOutputSol.ResumeLayout(false);
            this.gbOutputSol.PerformLayout();
            this.gbTestInput.ResumeLayout(false);
            this.gbTestInput.PerformLayout();
            this.gbOutputTest.ResumeLayout(false);
            this.gbOutputTest.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.gbWarnings.ResumeLayout(false);
            this.gbWarnings.PerformLayout();
            this.tlpMain1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLeftSide;
        private System.Windows.Forms.Button btnDeleteSolution;
        private System.Windows.Forms.Button btnTestAll;
        private System.Windows.Forms.TableLayoutPanel tlpTextboxes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gbTestInput;
        private System.Windows.Forms.TextBox tbInputTest;
        private System.Windows.Forms.GroupBox gbOutputSol;
        private System.Windows.Forms.TextBox tbOutputSol;
        private System.Windows.Forms.GroupBox gbOutputTest;
        private System.Windows.Forms.TextBox tbOutputTest;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcError;
        private System.ComponentModel.BackgroundWorker bwMain;
        private System.Windows.Forms.ProgressBar prbTest;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbWarnings;
        private System.Windows.Forms.TextBox tbErrors;
        private System.Windows.Forms.TableLayoutPanel tlpMain1;
    }
}