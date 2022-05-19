
namespace AutoTestApp
{
    partial class AddUpdateProblemForm
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
            this.gbCost = new System.Windows.Forms.GroupBox();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.tlpLow = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbByTest = new System.Windows.Forms.CheckBox();
            this.tlpMain.SuspendLayout();
            this.gbCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.tlpLow.SuspendLayout();
            this.gbName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbCost, 0, 1);
            this.tlpMain.Controls.Add(this.gbName, 0, 0);
            this.tlpMain.Controls.Add(this.tlpLow, 0, 3);
            this.tlpMain.Controls.Add(this.cbByTest, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(201, 166);
            this.tlpMain.TabIndex = 0;
            // 
            // gbCost
            // 
            this.gbCost.Controls.Add(this.nudCost);
            this.gbCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCost.Location = new System.Drawing.Point(3, 55);
            this.gbCost.Name = "gbCost";
            this.gbCost.Size = new System.Drawing.Size(195, 46);
            this.gbCost.TabIndex = 1;
            this.gbCost.TabStop = false;
            this.gbCost.Text = "Баллы за задание";
            // 
            // nudCost
            // 
            this.nudCost.DecimalPlaces = 2;
            this.nudCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCost.Location = new System.Drawing.Point(3, 19);
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(189, 23);
            this.nudCost.TabIndex = 0;
            this.nudCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tlpLow
            // 
            this.tlpLow.ColumnCount = 2;
            this.tlpLow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLow.Controls.Add(this.btnCancel, 0, 0);
            this.tlpLow.Controls.Add(this.btnOK, 0, 0);
            this.tlpLow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLow.Location = new System.Drawing.Point(0, 134);
            this.tlpLow.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLow.Name = "tlpLow";
            this.tlpLow.RowCount = 1;
            this.tlpLow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLow.Size = new System.Drawing.Size(201, 32);
            this.tlpLow.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(123, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(3, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.tbName);
            this.gbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbName.Location = new System.Drawing.Point(3, 3);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(195, 46);
            this.gbName.TabIndex = 3;
            this.gbName.TabStop = false;
            this.gbName.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(189, 23);
            this.tbName.TabIndex = 0;
            // 
            // cbByTest
            // 
            this.cbByTest.AutoSize = true;
            this.cbByTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbByTest.Location = new System.Drawing.Point(3, 107);
            this.cbByTest.Name = "cbByTest";
            this.cbByTest.Size = new System.Drawing.Size(195, 24);
            this.cbByTest.TabIndex = 4;
            this.cbByTest.Text = "Потестовая проверка";
            this.cbByTest.UseVisualStyleBackColor = true;
            // 
            // AddUpdateProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 166);
            this.Controls.Add(this.tlpMain);
            this.Name = "AddUpdateProblemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUpdateProblemForm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.gbCost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            this.tlpLow.ResumeLayout(false);
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbCost;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.TableLayoutPanel tlpLow;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox cbByTest;
    }
}