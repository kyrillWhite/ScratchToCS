
namespace AutoTestApp
{
    partial class ProblemsTestsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpProblemsCRUD = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteProblem = new System.Windows.Forms.Button();
            this.btnUpdateProblem = new System.Windows.Forms.Button();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.dgvProblems = new System.Windows.Forms.DataGridView();
            this.dgvcProblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTestCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpProblemOKCancel = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTests = new System.Windows.Forms.Panel();
            this.tlpTestCRUD = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.dgvcTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpTestIO = new System.Windows.Forms.TableLayoutPanel();
            this.gbTestInput = new System.Windows.Forms.GroupBox();
            this.tbInputData = new System.Windows.Forms.TextBox();
            this.gbTestOutput = new System.Windows.Forms.GroupBox();
            this.tbOutputData = new System.Windows.Forms.TextBox();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnDeleteTest = new System.Windows.Forms.Button();
            this.tlpSelectFiles = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSelectFilesButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddSevTests = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.gbDivider = new System.Windows.Forms.GroupBox();
            this.tbDivider = new System.Windows.Forms.TextBox();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.tlpProblemsCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).BeginInit();
            this.tlpProblemOKCancel.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlTests.SuspendLayout();
            this.tlpTestCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.tlpTestIO.SuspendLayout();
            this.gbTestInput.SuspendLayout();
            this.gbTestOutput.SuspendLayout();
            this.tlpSelectFiles.SuspendLayout();
            this.tlpSelectFilesButton.SuspendLayout();
            this.gbDivider.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpProblemsCRUD
            // 
            this.tlpProblemsCRUD.ColumnCount = 1;
            this.tlpProblemsCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProblemsCRUD.Controls.Add(this.btnDeleteProblem, 0, 3);
            this.tlpProblemsCRUD.Controls.Add(this.btnUpdateProblem, 0, 2);
            this.tlpProblemsCRUD.Controls.Add(this.btnAddProblem, 0, 1);
            this.tlpProblemsCRUD.Controls.Add(this.dgvProblems, 0, 0);
            this.tlpProblemsCRUD.Controls.Add(this.tlpProblemOKCancel, 0, 4);
            this.tlpProblemsCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProblemsCRUD.Location = new System.Drawing.Point(1, 1);
            this.tlpProblemsCRUD.Margin = new System.Windows.Forms.Padding(0);
            this.tlpProblemsCRUD.Name = "tlpProblemsCRUD";
            this.tlpProblemsCRUD.RowCount = 5;
            this.tlpProblemsCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProblemsCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProblemsCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProblemsCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProblemsCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProblemsCRUD.Size = new System.Drawing.Size(286, 448);
            this.tlpProblemsCRUD.TabIndex = 2;
            // 
            // btnDeleteProblem
            // 
            this.btnDeleteProblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProblem.Location = new System.Drawing.Point(3, 391);
            this.btnDeleteProblem.Name = "btnDeleteProblem";
            this.btnDeleteProblem.Size = new System.Drawing.Size(280, 24);
            this.btnDeleteProblem.TabIndex = 6;
            this.btnDeleteProblem.Text = "Удалить";
            this.btnDeleteProblem.UseVisualStyleBackColor = true;
            this.btnDeleteProblem.Click += new System.EventHandler(this.btnDeleteProblem_Click);
            // 
            // btnUpdateProblem
            // 
            this.btnUpdateProblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateProblem.Location = new System.Drawing.Point(3, 361);
            this.btnUpdateProblem.Name = "btnUpdateProblem";
            this.btnUpdateProblem.Size = new System.Drawing.Size(280, 24);
            this.btnUpdateProblem.TabIndex = 5;
            this.btnUpdateProblem.Text = "Изменить";
            this.btnUpdateProblem.UseVisualStyleBackColor = true;
            this.btnUpdateProblem.Click += new System.EventHandler(this.btnUpdateProblem_Click);
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProblem.Location = new System.Drawing.Point(3, 331);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(280, 24);
            this.btnAddProblem.TabIndex = 4;
            this.btnAddProblem.Text = "Добавить";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // dgvProblems
            // 
            this.dgvProblems.AllowDrop = true;
            this.dgvProblems.AllowUserToAddRows = false;
            this.dgvProblems.AllowUserToDeleteRows = false;
            this.dgvProblems.AllowUserToResizeColumns = false;
            this.dgvProblems.AllowUserToResizeRows = false;
            this.dgvProblems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProblems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcProblems,
            this.dgvcCost,
            this.dgvcTestCount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProblems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProblems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProblems.Location = new System.Drawing.Point(3, 3);
            this.dgvProblems.MultiSelect = false;
            this.dgvProblems.Name = "dgvProblems";
            this.dgvProblems.ReadOnly = true;
            this.dgvProblems.RowHeadersVisible = false;
            this.dgvProblems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvProblems.RowTemplate.Height = 25;
            this.dgvProblems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProblems.Size = new System.Drawing.Size(280, 322);
            this.dgvProblems.TabIndex = 2;
            this.dgvProblems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProblems_CellMouseDown);
            this.dgvProblems.SelectionChanged += new System.EventHandler(this.dgvProblems_SelectionChanged);
            this.dgvProblems.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvProblems_DragDrop);
            this.dgvProblems.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvProblems_DragOver);
            // 
            // dgvcProblems
            // 
            this.dgvcProblems.HeaderText = "Задание";
            this.dgvcProblems.Name = "dgvcProblems";
            this.dgvcProblems.ReadOnly = true;
            this.dgvcProblems.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcCost
            // 
            this.dgvcCost.HeaderText = "Баллы";
            this.dgvcCost.Name = "dgvcCost";
            this.dgvcCost.ReadOnly = true;
            this.dgvcCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcTestCount
            // 
            this.dgvcTestCount.HeaderText = "Тесты";
            this.dgvcTestCount.Name = "dgvcTestCount";
            this.dgvcTestCount.ReadOnly = true;
            this.dgvcTestCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlpProblemOKCancel
            // 
            this.tlpProblemOKCancel.ColumnCount = 2;
            this.tlpProblemOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProblemOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProblemOKCancel.Controls.Add(this.btnCancel, 0, 0);
            this.tlpProblemOKCancel.Controls.Add(this.btnOK, 0, 0);
            this.tlpProblemOKCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProblemOKCancel.Location = new System.Drawing.Point(0, 418);
            this.tlpProblemOKCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpProblemOKCancel.Name = "tlpProblemOKCancel";
            this.tlpProblemOKCancel.RowCount = 1;
            this.tlpProblemOKCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProblemOKCancel.Size = new System.Drawing.Size(286, 30);
            this.tlpProblemOKCancel.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(199, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.tlpProblemsCRUD, 0, 0);
            this.tlpMain.Controls.Add(this.pnlTests, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(597, 450);
            this.tlpMain.TabIndex = 3;
            // 
            // pnlTests
            // 
            this.pnlTests.Controls.Add(this.tlpTestCRUD);
            this.pnlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTests.Location = new System.Drawing.Point(309, 1);
            this.pnlTests.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTests.Name = "pnlTests";
            this.pnlTests.Size = new System.Drawing.Size(287, 448);
            this.pnlTests.TabIndex = 4;
            // 
            // tlpTestCRUD
            // 
            this.tlpTestCRUD.ColumnCount = 1;
            this.tlpTestCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTestCRUD.Controls.Add(this.dgvTests, 0, 0);
            this.tlpTestCRUD.Controls.Add(this.tlpTestIO, 0, 1);
            this.tlpTestCRUD.Controls.Add(this.btnAddTest, 0, 2);
            this.tlpTestCRUD.Controls.Add(this.btnDeleteTest, 0, 4);
            this.tlpTestCRUD.Controls.Add(this.tlpSelectFiles, 0, 3);
            this.tlpTestCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTestCRUD.Location = new System.Drawing.Point(0, 0);
            this.tlpTestCRUD.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTestCRUD.Name = "tlpTestCRUD";
            this.tlpTestCRUD.RowCount = 5;
            this.tlpTestCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTestCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTestCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTestCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTestCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTestCRUD.Size = new System.Drawing.Size(287, 448);
            this.tlpTestCRUD.TabIndex = 3;
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
            this.dgvcTest});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTests.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTests.Location = new System.Drawing.Point(3, 3);
            this.dgvTests.MultiSelect = false;
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.ReadOnly = true;
            this.dgvTests.RowHeadersVisible = false;
            this.dgvTests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTests.RowTemplate.Height = 25;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(281, 158);
            this.dgvTests.TabIndex = 3;
            this.dgvTests.SelectionChanged += new System.EventHandler(this.dgvTests_SelectionChanged);
            // 
            // dgvcTest
            // 
            this.dgvcTest.HeaderText = "Тест";
            this.dgvcTest.Name = "dgvcTest";
            this.dgvcTest.ReadOnly = true;
            this.dgvcTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlpTestIO
            // 
            this.tlpTestIO.ColumnCount = 2;
            this.tlpTestIO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTestIO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTestIO.Controls.Add(this.gbTestInput, 0, 0);
            this.tlpTestIO.Controls.Add(this.gbTestOutput, 1, 0);
            this.tlpTestIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTestIO.Location = new System.Drawing.Point(3, 167);
            this.tlpTestIO.Name = "tlpTestIO";
            this.tlpTestIO.RowCount = 1;
            this.tlpTestIO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTestIO.Size = new System.Drawing.Size(281, 158);
            this.tlpTestIO.TabIndex = 0;
            // 
            // gbTestInput
            // 
            this.gbTestInput.Controls.Add(this.tbInputData);
            this.gbTestInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTestInput.Location = new System.Drawing.Point(3, 3);
            this.gbTestInput.Name = "gbTestInput";
            this.gbTestInput.Size = new System.Drawing.Size(134, 152);
            this.gbTestInput.TabIndex = 1;
            this.gbTestInput.TabStop = false;
            this.gbTestInput.Text = "Входные данные";
            // 
            // tbInputData
            // 
            this.tbInputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInputData.Location = new System.Drawing.Point(3, 19);
            this.tbInputData.Multiline = true;
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInputData.Size = new System.Drawing.Size(128, 130);
            this.tbInputData.TabIndex = 0;
            this.tbInputData.TextChanged += new System.EventHandler(this.tbInputData_TextChanged);
            this.tbInputData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInputData_KeyDown);
            // 
            // gbTestOutput
            // 
            this.gbTestOutput.Controls.Add(this.tbOutputData);
            this.gbTestOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTestOutput.Location = new System.Drawing.Point(143, 3);
            this.gbTestOutput.Name = "gbTestOutput";
            this.gbTestOutput.Size = new System.Drawing.Size(135, 152);
            this.gbTestOutput.TabIndex = 2;
            this.gbTestOutput.TabStop = false;
            this.gbTestOutput.Text = "Выходные данные";
            // 
            // tbOutputData
            // 
            this.tbOutputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutputData.Location = new System.Drawing.Point(3, 19);
            this.tbOutputData.Multiline = true;
            this.tbOutputData.Name = "tbOutputData";
            this.tbOutputData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutputData.Size = new System.Drawing.Size(129, 130);
            this.tbOutputData.TabIndex = 0;
            this.tbOutputData.TextChanged += new System.EventHandler(this.tbOutputData_TextChanged);
            this.tbOutputData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOutputData_KeyDown);
            // 
            // btnAddTest
            // 
            this.btnAddTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTest.Location = new System.Drawing.Point(3, 331);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(281, 24);
            this.btnAddTest.TabIndex = 4;
            this.btnAddTest.Text = "Добавить";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnDeleteTest
            // 
            this.btnDeleteTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteTest.Location = new System.Drawing.Point(3, 421);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(281, 24);
            this.btnDeleteTest.TabIndex = 6;
            this.btnDeleteTest.Text = "Удалить";
            this.btnDeleteTest.UseVisualStyleBackColor = true;
            this.btnDeleteTest.Click += new System.EventHandler(this.btnDeleteTest_Click);
            // 
            // tlpSelectFiles
            // 
            this.tlpSelectFiles.ColumnCount = 2;
            this.tlpSelectFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSelectFiles.Controls.Add(this.tlpSelectFilesButton, 0, 0);
            this.tlpSelectFiles.Controls.Add(this.gbDivider, 1, 0);
            this.tlpSelectFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectFiles.Location = new System.Drawing.Point(0, 358);
            this.tlpSelectFiles.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectFiles.Name = "tlpSelectFiles";
            this.tlpSelectFiles.RowCount = 1;
            this.tlpSelectFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSelectFiles.Size = new System.Drawing.Size(287, 60);
            this.tlpSelectFiles.TabIndex = 8;
            // 
            // tlpSelectFilesButton
            // 
            this.tlpSelectFilesButton.ColumnCount = 1;
            this.tlpSelectFilesButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSelectFilesButton.Controls.Add(this.btnAddSevTests, 0, 0);
            this.tlpSelectFilesButton.Controls.Add(this.btnSelectFolder, 0, 1);
            this.tlpSelectFilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectFilesButton.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectFilesButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectFilesButton.Name = "tlpSelectFilesButton";
            this.tlpSelectFilesButton.RowCount = 2;
            this.tlpSelectFilesButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSelectFilesButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSelectFilesButton.Size = new System.Drawing.Size(187, 60);
            this.tlpSelectFilesButton.TabIndex = 8;
            // 
            // btnAddSevTests
            // 
            this.btnAddSevTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSevTests.Location = new System.Drawing.Point(3, 3);
            this.btnAddSevTests.Name = "btnAddSevTests";
            this.btnAddSevTests.Size = new System.Drawing.Size(181, 24);
            this.btnAddSevTests.TabIndex = 5;
            this.btnAddSevTests.Text = "Выбрать файлы...";
            this.ttMain.SetToolTip(this.btnAddSevTests, "Выбрать *.txt файлы, каждый из которых содержит входные и выходные данные.\r\nДанны" +
        "е должны быть разделены указанным символом.");
            this.btnAddSevTests.UseVisualStyleBackColor = true;
            this.btnAddSevTests.Click += new System.EventHandler(this.btnAddSevTests_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectFolder.Location = new System.Drawing.Point(3, 33);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(181, 24);
            this.btnSelectFolder.TabIndex = 7;
            this.btnSelectFolder.Text = "Выбрать папку с файлами...";
            this.ttMain.SetToolTip(this.btnSelectFolder, "Выбрать папку с *.txt файлами, каждый из которых содержит входные и выходные данн" +
        "ые.\r\nДанные должны быть разделены указанным символом.");
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // gbDivider
            // 
            this.gbDivider.Controls.Add(this.tbDivider);
            this.gbDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDivider.Location = new System.Drawing.Point(190, 3);
            this.gbDivider.Name = "gbDivider";
            this.gbDivider.Padding = new System.Windows.Forms.Padding(0);
            this.gbDivider.Size = new System.Drawing.Size(94, 54);
            this.gbDivider.TabIndex = 9;
            this.gbDivider.TabStop = false;
            this.gbDivider.Text = "Разделитель";
            // 
            // tbDivider
            // 
            this.tbDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbDivider.Location = new System.Drawing.Point(0, 20);
            this.tbDivider.MaxLength = 1;
            this.tbDivider.Name = "tbDivider";
            this.tbDivider.Size = new System.Drawing.Size(94, 23);
            this.tbDivider.TabIndex = 0;
            this.tbDivider.Text = "$";
            this.tbDivider.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttMain.SetToolTip(this.tbDivider, "Символ-разделитель между входными и выходными данными.");
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Текстовые документы|*txt";
            this.ofdMain.Multiselect = true;
            // 
            // ProblemsTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "ProblemsTestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Задания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateProblemForm_FormClosing);
            this.tlpProblemsCRUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).EndInit();
            this.tlpProblemOKCancel.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnlTests.ResumeLayout(false);
            this.tlpTestCRUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.tlpTestIO.ResumeLayout(false);
            this.gbTestInput.ResumeLayout(false);
            this.gbTestInput.PerformLayout();
            this.gbTestOutput.ResumeLayout(false);
            this.gbTestOutput.PerformLayout();
            this.tlpSelectFiles.ResumeLayout(false);
            this.tlpSelectFilesButton.ResumeLayout(false);
            this.gbDivider.ResumeLayout(false);
            this.gbDivider.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpProblemsCRUD;
        private System.Windows.Forms.DataGridView dgvProblems;
        private System.Windows.Forms.TableLayoutPanel tlpProblemOKCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteProblem;
        private System.Windows.Forms.Button btnUpdateProblem;
        private System.Windows.Forms.Button btnAddProblem;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTestCRUD;
        private System.Windows.Forms.TableLayoutPanel tlpTestIO;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTest;
        private System.Windows.Forms.GroupBox gbTestInput;
        private System.Windows.Forms.GroupBox gbTestOutput;
        private System.Windows.Forms.TextBox tbInputData;
        private System.Windows.Forms.TextBox tbOutputData;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnAddSevTests;
        private System.Windows.Forms.Button btnDeleteTest;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TableLayoutPanel tlpSelectFiles;
        private System.Windows.Forms.TableLayoutPanel tlpSelectFilesButton;
        private System.Windows.Forms.GroupBox gbDivider;
        private System.Windows.Forms.TextBox tbDivider;
        private System.Windows.Forms.Panel pnlTests;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProblems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTestCount;
    }
}