
namespace AutoTestApp
{
    partial class UpdateParticipantForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnDelSolution = new System.Windows.Forms.Button();
            this.btnUpdateSolution = new System.Windows.Forms.Button();
            this.dgvSolutions = new System.Windows.Forms.DataGridView();
            this.dgvcProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.tlpOKCancel = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain.SuspendLayout();
            this.gbName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolutions)).BeginInit();
            this.tlpOKCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbName, 0, 0);
            this.tlpMain.Controls.Add(this.btnDelSolution, 0, 4);
            this.tlpMain.Controls.Add(this.btnUpdateSolution, 0, 3);
            this.tlpMain.Controls.Add(this.dgvSolutions, 0, 1);
            this.tlpMain.Controls.Add(this.btnAddProblem, 0, 2);
            this.tlpMain.Controls.Add(this.tlpOKCancel, 0, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(273, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.tbName);
            this.gbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbName.Location = new System.Drawing.Point(3, 3);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(267, 46);
            this.gbName.TabIndex = 0;
            this.gbName.TabStop = false;
            this.gbName.Text = "Имя";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(261, 23);
            this.tbName.TabIndex = 0;
            // 
            // btnDelSolution
            // 
            this.btnDelSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelSolution.Location = new System.Drawing.Point(3, 393);
            this.btnDelSolution.Name = "btnDelSolution";
            this.btnDelSolution.Size = new System.Drawing.Size(267, 24);
            this.btnDelSolution.TabIndex = 3;
            this.btnDelSolution.Text = "Удалить решение";
            this.btnDelSolution.UseVisualStyleBackColor = true;
            this.btnDelSolution.Click += new System.EventHandler(this.btnDelSolution_Click);
            // 
            // btnUpdateSolution
            // 
            this.btnUpdateSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateSolution.Location = new System.Drawing.Point(3, 363);
            this.btnUpdateSolution.Name = "btnUpdateSolution";
            this.btnUpdateSolution.Size = new System.Drawing.Size(267, 24);
            this.btnUpdateSolution.TabIndex = 4;
            this.btnUpdateSolution.Text = "Изменить решение...";
            this.btnUpdateSolution.UseVisualStyleBackColor = true;
            this.btnUpdateSolution.Click += new System.EventHandler(this.btnUpdateSolution_Click);
            // 
            // dgvSolutions
            // 
            this.dgvSolutions.AllowDrop = true;
            this.dgvSolutions.AllowUserToAddRows = false;
            this.dgvSolutions.AllowUserToDeleteRows = false;
            this.dgvSolutions.AllowUserToResizeColumns = false;
            this.dgvSolutions.AllowUserToResizeRows = false;
            this.dgvSolutions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolutions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcProblem,
            this.dgvcSolution});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSolutions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolutions.Location = new System.Drawing.Point(3, 55);
            this.dgvSolutions.MultiSelect = false;
            this.dgvSolutions.Name = "dgvSolutions";
            this.dgvSolutions.ReadOnly = true;
            this.dgvSolutions.RowHeadersVisible = false;
            this.dgvSolutions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSolutions.RowTemplate.Height = 25;
            this.dgvSolutions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolutions.Size = new System.Drawing.Size(267, 272);
            this.dgvSolutions.TabIndex = 1;
            this.dgvSolutions.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSolutions_CellMouseDown);
            this.dgvSolutions.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolutions_CellMouseEnter);
            this.dgvSolutions.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolutions_CellMouseLeave);
            this.dgvSolutions.SelectionChanged += new System.EventHandler(this.dgvSolutions_SelectionChanged);
            this.dgvSolutions.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvSolutions_DragDrop);
            this.dgvSolutions.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvSolutions_DragOver);
            // 
            // dgvcProblem
            // 
            this.dgvcProblem.HeaderText = "Задание";
            this.dgvcProblem.Name = "dgvcProblem";
            this.dgvcProblem.ReadOnly = true;
            this.dgvcProblem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcSolution
            // 
            this.dgvcSolution.HeaderText = "Решение";
            this.dgvcSolution.Name = "dgvcSolution";
            this.dgvcSolution.ReadOnly = true;
            this.dgvcSolution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProblem.Location = new System.Drawing.Point(3, 333);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(267, 24);
            this.btnAddProblem.TabIndex = 2;
            this.btnAddProblem.Text = "Добавить задание";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // tlpOKCancel
            // 
            this.tlpOKCancel.ColumnCount = 2;
            this.tlpOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOKCancel.Controls.Add(this.btnOK, 0, 0);
            this.tlpOKCancel.Controls.Add(this.btnCancel, 1, 0);
            this.tlpOKCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOKCancel.Location = new System.Drawing.Point(0, 420);
            this.tlpOKCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOKCancel.Name = "tlpOKCancel";
            this.tlpOKCancel.RowCount = 1;
            this.tlpOKCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOKCancel.Size = new System.Drawing.Size(273, 30);
            this.tlpOKCancel.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(186, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Scratch files|*.sb3";
            // 
            // UpdateParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "UpdateParticipantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateParticipantForm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolutions)).EndInit();
            this.tlpOKCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridView dgvSolutions;
        private System.Windows.Forms.Button btnAddProblem;
        private System.Windows.Forms.Button btnDelSolution;
        private System.Windows.Forms.Button btnUpdateSolution;
        private System.Windows.Forms.TableLayoutPanel tlpOKCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSolution;
        private System.Windows.Forms.OpenFileDialog ofdMain;
    }
}