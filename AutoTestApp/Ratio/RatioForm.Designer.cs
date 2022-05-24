
namespace AutoTestApp
{
    partial class RatioForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRatio = new System.Windows.Forms.DataGridView();
            this.tlpOKCancel = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatio)).BeginInit();
            this.tlpOKCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvRatio, 0, 0);
            this.tlpMain.Controls.Add(this.tlpOKCancel, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(1049, 534);
            this.tlpMain.TabIndex = 0;
            // 
            // dgvRatio
            // 
            this.dgvRatio.AllowDrop = true;
            this.dgvRatio.AllowUserToAddRows = false;
            this.dgvRatio.AllowUserToDeleteRows = false;
            this.dgvRatio.AllowUserToResizeColumns = false;
            this.dgvRatio.AllowUserToResizeRows = false;
            this.dgvRatio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRatio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRatio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRatio.Location = new System.Drawing.Point(3, 3);
            this.dgvRatio.MultiSelect = false;
            this.dgvRatio.Name = "dgvRatio";
            this.dgvRatio.ReadOnly = true;
            this.dgvRatio.RowHeadersVisible = false;
            this.dgvRatio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvRatio.RowTemplate.Height = 25;
            this.dgvRatio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRatio.Size = new System.Drawing.Size(1043, 498);
            this.dgvRatio.TabIndex = 1;
            this.dgvRatio.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRatio_CellMouseDown);
            this.dgvRatio.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvRatio_DragDrop);
            this.dgvRatio.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvRatio_DragOver);
            // 
            // tlpOKCancel
            // 
            this.tlpOKCancel.ColumnCount = 3;
            this.tlpOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.723546F));
            this.tlpOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.81602F));
            this.tlpOKCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpOKCancel.Controls.Add(this.btnUpdate, 0, 0);
            this.tlpOKCancel.Controls.Add(this.btnOK, 0, 0);
            this.tlpOKCancel.Controls.Add(this.btnCancel, 2, 0);
            this.tlpOKCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOKCancel.Location = new System.Drawing.Point(0, 504);
            this.tlpOKCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOKCancel.Name = "tlpOKCancel";
            this.tlpOKCancel.RowCount = 1;
            this.tlpOKCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOKCancel.Size = new System.Drawing.Size(1049, 30);
            this.tlpOKCancel.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUpdate.Location = new System.Drawing.Point(105, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 24);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Соотнести";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(962, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RatioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 534);
            this.Controls.Add(this.tlpMain);
            this.Name = "RatioForm";
            this.Text = "Соотношение заданий и решений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RatioForm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatio)).EndInit();
            this.tlpOKCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpOKCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvRatio;
        private System.Windows.Forms.Button btnUpdate;
    }
}