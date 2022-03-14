
namespace AutoTestApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParticipants = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddParticipant = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProblemsTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProblemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProblemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTestResults = new System.Windows.Forms.DataGridView();
            this.tlpRightMenu = new System.Windows.Forms.TableLayoutPanel();
            this.gbParticipants = new System.Windows.Forms.GroupBox();
            this.tlpParticButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPartic = new System.Windows.Forms.Button();
            this.btnUpdatePartic = new System.Windows.Forms.Button();
            this.btnDeletePartic = new System.Windows.Forms.Button();
            this.gbTesting = new System.Windows.Forms.GroupBox();
            this.tlpTesting = new System.Windows.Forms.TableLayoutPanel();
            this.btnTestSelected = new System.Windows.Forms.Button();
            this.btnTestAll = new System.Windows.Forms.Button();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.prbTest = new System.Windows.Forms.ProgressBar();
            this.lbTestingState = new System.Windows.Forms.Label();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.bwTest = new System.ComponentModel.BackgroundWorker();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.ofdSession = new System.Windows.Forms.OpenFileDialog();
            this.sfdTable = new System.Windows.Forms.SaveFileDialog();
            this.msMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).BeginInit();
            this.tlpRightMenu.SuspendLayout();
            this.gbParticipants.SuspendLayout();
            this.tlpParticButtons.SuspendLayout();
            this.gbTesting.SuspendLayout();
            this.tlpTesting.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.tsmiParticipants,
            this.tsmiProblemsTests});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(940, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreate,
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // tsmiCreate
            // 
            this.tsmiCreate.Name = "tsmiCreate";
            this.tsmiCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiCreate.Size = new System.Drawing.Size(241, 22);
            this.tsmiCreate.Text = "Создать";
            this.tsmiCreate.Click += new System.EventHandler(this.tsmiCreate_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpen.Size = new System.Drawing.Size(241, 22);
            this.tsmiOpen.Text = "Открыть...";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(241, 22);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiSaveAs.Size = new System.Drawing.Size(241, 22);
            this.tsmiSaveAs.Text = "Сохранить как...";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(241, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiParticipants
            // 
            this.tsmiParticipants.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddParticipant});
            this.tsmiParticipants.Name = "tsmiParticipants";
            this.tsmiParticipants.Size = new System.Drawing.Size(77, 20);
            this.tsmiParticipants.Text = "Участники";
            // 
            // tsmiAddParticipant
            // 
            this.tsmiAddParticipant.Name = "tsmiAddParticipant";
            this.tsmiAddParticipant.Size = new System.Drawing.Size(126, 22);
            this.tsmiAddParticipant.Text = "Добавить";
            this.tsmiAddParticipant.Click += new System.EventHandler(this.tsmiAddParticipant_Click);
            // 
            // tsmiProblemsTests
            // 
            this.tsmiProblemsTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProblemDetails,
            this.toolStripSeparator3,
            this.tsmiProblemAdd});
            this.tsmiProblemsTests.Name = "tsmiProblemsTests";
            this.tsmiProblemsTests.Size = new System.Drawing.Size(109, 20);
            this.tsmiProblemsTests.Text = "Задания и Тесты";
            // 
            // tsmiProblemDetails
            // 
            this.tsmiProblemDetails.Name = "tsmiProblemDetails";
            this.tsmiProblemDetails.Size = new System.Drawing.Size(172, 22);
            this.tsmiProblemDetails.Text = "Подробности";
            this.tsmiProblemDetails.Click += new System.EventHandler(this.tsmiProblemDetails_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiProblemAdd
            // 
            this.tsmiProblemAdd.Name = "tsmiProblemAdd";
            this.tsmiProblemAdd.Size = new System.Drawing.Size(172, 22);
            this.tsmiProblemAdd.Text = "Добавить задание";
            this.tsmiProblemAdd.Click += new System.EventHandler(this.tsmiProblemAdd_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.Controls.Add(this.dgvTestResults, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRightMenu, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(940, 570);
            this.tlpMain.TabIndex = 1;
            // 
            // dgvTestResults
            // 
            this.dgvTestResults.AllowDrop = true;
            this.dgvTestResults.AllowUserToAddRows = false;
            this.dgvTestResults.AllowUserToDeleteRows = false;
            this.dgvTestResults.AllowUserToResizeColumns = false;
            this.dgvTestResults.AllowUserToResizeRows = false;
            this.dgvTestResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTestResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestResults.Location = new System.Drawing.Point(4, 4);
            this.dgvTestResults.MultiSelect = false;
            this.dgvTestResults.Name = "dgvTestResults";
            this.dgvTestResults.ReadOnly = true;
            this.dgvTestResults.RowHeadersVisible = false;
            this.dgvTestResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTestResults.RowTemplate.Height = 25;
            this.dgvTestResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestResults.Size = new System.Drawing.Size(771, 562);
            this.dgvTestResults.TabIndex = 0;
            this.dgvTestResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTestResults_CellMouseDown);
            this.dgvTestResults.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestResults_CellMouseEnter);
            this.dgvTestResults.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestResults_CellMouseLeave);
            this.dgvTestResults.SelectionChanged += new System.EventHandler(this.dgvTestResults_SelectionChanged);
            // 
            // tlpRightMenu
            // 
            this.tlpRightMenu.ColumnCount = 1;
            this.tlpRightMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightMenu.Controls.Add(this.gbParticipants, 0, 0);
            this.tlpRightMenu.Controls.Add(this.gbTesting, 0, 1);
            this.tlpRightMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightMenu.Location = new System.Drawing.Point(779, 1);
            this.tlpRightMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRightMenu.Name = "tlpRightMenu";
            this.tlpRightMenu.RowCount = 3;
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightMenu.Size = new System.Drawing.Size(160, 568);
            this.tlpRightMenu.TabIndex = 1;
            // 
            // gbParticipants
            // 
            this.gbParticipants.Controls.Add(this.tlpParticButtons);
            this.gbParticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbParticipants.Location = new System.Drawing.Point(3, 3);
            this.gbParticipants.Name = "gbParticipants";
            this.gbParticipants.Size = new System.Drawing.Size(154, 114);
            this.gbParticipants.TabIndex = 0;
            this.gbParticipants.TabStop = false;
            this.gbParticipants.Text = "Участники";
            // 
            // tlpParticButtons
            // 
            this.tlpParticButtons.ColumnCount = 1;
            this.tlpParticButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParticButtons.Controls.Add(this.btnAddPartic, 0, 0);
            this.tlpParticButtons.Controls.Add(this.btnUpdatePartic, 0, 1);
            this.tlpParticButtons.Controls.Add(this.btnDeletePartic, 0, 2);
            this.tlpParticButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParticButtons.Location = new System.Drawing.Point(3, 19);
            this.tlpParticButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpParticButtons.Name = "tlpParticButtons";
            this.tlpParticButtons.RowCount = 3;
            this.tlpParticButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParticButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParticButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParticButtons.Size = new System.Drawing.Size(148, 92);
            this.tlpParticButtons.TabIndex = 0;
            // 
            // btnAddPartic
            // 
            this.btnAddPartic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPartic.Location = new System.Drawing.Point(3, 3);
            this.btnAddPartic.Name = "btnAddPartic";
            this.btnAddPartic.Size = new System.Drawing.Size(142, 24);
            this.btnAddPartic.TabIndex = 0;
            this.btnAddPartic.Text = "Добавить";
            this.btnAddPartic.UseVisualStyleBackColor = true;
            this.btnAddPartic.Click += new System.EventHandler(this.btnAddPartic_Click);
            // 
            // btnUpdatePartic
            // 
            this.btnUpdatePartic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdatePartic.Location = new System.Drawing.Point(3, 33);
            this.btnUpdatePartic.Name = "btnUpdatePartic";
            this.btnUpdatePartic.Size = new System.Drawing.Size(142, 24);
            this.btnUpdatePartic.TabIndex = 1;
            this.btnUpdatePartic.Text = "Изменить";
            this.btnUpdatePartic.UseVisualStyleBackColor = true;
            this.btnUpdatePartic.Click += new System.EventHandler(this.btnUpdatePartic_Click);
            // 
            // btnDeletePartic
            // 
            this.btnDeletePartic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeletePartic.Location = new System.Drawing.Point(3, 63);
            this.btnDeletePartic.Name = "btnDeletePartic";
            this.btnDeletePartic.Size = new System.Drawing.Size(142, 26);
            this.btnDeletePartic.TabIndex = 2;
            this.btnDeletePartic.Text = "Удалить";
            this.btnDeletePartic.UseVisualStyleBackColor = true;
            this.btnDeletePartic.Click += new System.EventHandler(this.btnDeletePartic_Click);
            // 
            // gbTesting
            // 
            this.gbTesting.Controls.Add(this.tlpTesting);
            this.gbTesting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTesting.Location = new System.Drawing.Point(3, 123);
            this.gbTesting.Name = "gbTesting";
            this.gbTesting.Size = new System.Drawing.Size(154, 180);
            this.gbTesting.TabIndex = 2;
            this.gbTesting.TabStop = false;
            this.gbTesting.Text = "Тестирование";
            // 
            // tlpTesting
            // 
            this.tlpTesting.ColumnCount = 1;
            this.tlpTesting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTesting.Controls.Add(this.btnTestSelected, 0, 0);
            this.tlpTesting.Controls.Add(this.btnTestAll, 0, 1);
            this.tlpTesting.Controls.Add(this.btnSaveTable, 0, 2);
            this.tlpTesting.Controls.Add(this.prbTest, 0, 4);
            this.tlpTesting.Controls.Add(this.lbTestingState, 0, 3);
            this.tlpTesting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTesting.Location = new System.Drawing.Point(3, 19);
            this.tlpTesting.Name = "tlpTesting";
            this.tlpTesting.RowCount = 5;
            this.tlpTesting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTesting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTesting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTesting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTesting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTesting.Size = new System.Drawing.Size(148, 158);
            this.tlpTesting.TabIndex = 0;
            // 
            // btnTestSelected
            // 
            this.btnTestSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestSelected.Location = new System.Drawing.Point(3, 3);
            this.btnTestSelected.Name = "btnTestSelected";
            this.btnTestSelected.Size = new System.Drawing.Size(142, 25);
            this.btnTestSelected.TabIndex = 0;
            this.btnTestSelected.Text = "Тест выбраного уч.";
            this.btnTestSelected.UseVisualStyleBackColor = true;
            this.btnTestSelected.Click += new System.EventHandler(this.btnTestSelected_Click);
            // 
            // btnTestAll
            // 
            this.btnTestAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestAll.Location = new System.Drawing.Point(3, 34);
            this.btnTestAll.Name = "btnTestAll";
            this.btnTestAll.Size = new System.Drawing.Size(142, 25);
            this.btnTestAll.TabIndex = 1;
            this.btnTestAll.Text = "Тест всех участников";
            this.btnTestAll.UseVisualStyleBackColor = true;
            this.btnTestAll.Click += new System.EventHandler(this.btnTestAll_Click);
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveTable.Location = new System.Drawing.Point(3, 65);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(142, 25);
            this.btnSaveTable.TabIndex = 2;
            this.btnSaveTable.Text = "Сохранить результаты";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // prbTest
            // 
            this.prbTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbTest.Location = new System.Drawing.Point(3, 127);
            this.prbTest.Name = "prbTest";
            this.prbTest.Size = new System.Drawing.Size(142, 28);
            this.prbTest.Step = 1;
            this.prbTest.TabIndex = 3;
            this.prbTest.Visible = false;
            // 
            // lbTestingState
            // 
            this.lbTestingState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTestingState.AutoSize = true;
            this.lbTestingState.Location = new System.Drawing.Point(3, 106);
            this.lbTestingState.Margin = new System.Windows.Forms.Padding(3);
            this.lbTestingState.Name = "lbTestingState";
            this.lbTestingState.Size = new System.Drawing.Size(0, 15);
            this.lbTestingState.TabIndex = 4;
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Scratch files|*.sb3";
            // 
            // bwTest
            // 
            this.bwTest.WorkerReportsProgress = true;
            this.bwTest.WorkerSupportsCancellation = true;
            this.bwTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTest_DoWork);
            this.bwTest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwTest_ProgressChanged);
            this.bwTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwTest_RunWorkerCompleted);
            // 
            // sfdMain
            // 
            this.sfdMain.DefaultExt = "tsb3";
            this.sfdMain.FileName = "*";
            this.sfdMain.Filter = "Тест-сессии|*.tsb3";
            // 
            // ofdSession
            // 
            this.ofdSession.Filter = "Тест-сессии|*.tsb3";
            // 
            // sfdTable
            // 
            this.sfdTable.DefaultExt = "csv";
            this.sfdTable.FileName = "*";
            this.sfdTable.Filter = "CSV|*.csv";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 594);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.Text = "UNTITLED - Система тестирования программ Scratch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).EndInit();
            this.tlpRightMenu.ResumeLayout(false);
            this.gbParticipants.ResumeLayout(false);
            this.tlpParticButtons.ResumeLayout(false);
            this.gbTesting.ResumeLayout(false);
            this.tlpTesting.ResumeLayout(false);
            this.tlpTesting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridView dgvTestResults;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiProblemsTests;
        private System.Windows.Forms.ToolStripMenuItem tsmiProblemDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiProblemAdd;
        private System.Windows.Forms.TableLayoutPanel tlpRightMenu;
        private System.Windows.Forms.GroupBox gbParticipants;
        private System.Windows.Forms.TableLayoutPanel tlpParticButtons;
        private System.Windows.Forms.Button btnAddPartic;
        private System.Windows.Forms.Button btnUpdatePartic;
        private System.Windows.Forms.Button btnDeletePartic;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiParticipants;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddParticipant;
        private System.Windows.Forms.GroupBox gbTesting;
        private System.Windows.Forms.TableLayoutPanel tlpTesting;
        private System.Windows.Forms.Button btnTestSelected;
        private System.Windows.Forms.Button btnTestAll;
        private System.Windows.Forms.Button btnSaveTable;
        private System.Windows.Forms.ProgressBar prbTest;
        private System.Windows.Forms.Label lbTestingState;
        private System.ComponentModel.BackgroundWorker bwTest;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.OpenFileDialog ofdSession;
        private System.Windows.Forms.SaveFileDialog sfdTable;
    }
}

