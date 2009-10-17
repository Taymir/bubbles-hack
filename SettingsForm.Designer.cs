namespace BubblesHack
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FindMaxNodes = new System.Windows.Forms.NumericUpDown();
            this.FindMinThreshold = new System.Windows.Forms.NumericUpDown();
            this.FindSolverType = new System.Windows.Forms.ComboBox();
            this.FindSaveTree = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AutoFindMaxNodes = new System.Windows.Forms.NumericUpDown();
            this.AutoFindMinThreshold = new System.Windows.Forms.NumericUpDown();
            this.AutoFindSolverType = new System.Windows.Forms.ComboBox();
            this.AutoFindDesiredScore = new System.Windows.Forms.NumericUpDown();
            this.AutoFindMinBubbles = new System.Windows.Forms.NumericUpDown();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindMaxNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindMinThreshold)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMaxNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindDesiredScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMinBubbles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск решения";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.FindMaxNodes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FindMinThreshold, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.FindSolverType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FindSaveTree, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество Нод:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество симуляций на ноде:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип алгоритма:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Сохранение дерева:";
            // 
            // FindMaxNodes
            // 
            this.FindMaxNodes.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FindMaxNodes.Location = new System.Drawing.Point(178, 3);
            this.FindMaxNodes.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FindMaxNodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FindMaxNodes.Name = "FindMaxNodes";
            this.FindMaxNodes.Size = new System.Drawing.Size(120, 20);
            this.FindMaxNodes.TabIndex = 4;
            this.FindMaxNodes.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // FindMinThreshold
            // 
            this.FindMinThreshold.Location = new System.Drawing.Point(178, 29);
            this.FindMinThreshold.Name = "FindMinThreshold";
            this.FindMinThreshold.Size = new System.Drawing.Size(120, 20);
            this.FindMinThreshold.TabIndex = 5;
            this.FindMinThreshold.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // FindSolverType
            // 
            this.FindSolverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FindSolverType.FormattingEnabled = true;
            this.FindSolverType.Location = new System.Drawing.Point(178, 55);
            this.FindSolverType.Name = "FindSolverType";
            this.FindSolverType.Size = new System.Drawing.Size(121, 21);
            this.FindSolverType.TabIndex = 6;
            // 
            // FindSaveTree
            // 
            this.FindSaveTree.Location = new System.Drawing.Point(178, 82);
            this.FindSaveTree.Name = "FindSaveTree";
            this.FindSaveTree.Size = new System.Drawing.Size(121, 20);
            this.FindSaveTree.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(13, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Автопоиск решения";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.AutoFindMaxNodes, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AutoFindMinThreshold, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.AutoFindSolverType, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.AutoFindDesiredScore, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.AutoFindMinBubbles, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(307, 135);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Количество Нод:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Количество симуляций на ноде:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Тип алгоритма:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Минимальный счет:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Минимум пузырей одного цвета:";
            // 
            // AutoFindMaxNodes
            // 
            this.AutoFindMaxNodes.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AutoFindMaxNodes.Location = new System.Drawing.Point(183, 3);
            this.AutoFindMaxNodes.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.AutoFindMaxNodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AutoFindMaxNodes.Name = "AutoFindMaxNodes";
            this.AutoFindMaxNodes.Size = new System.Drawing.Size(120, 20);
            this.AutoFindMaxNodes.TabIndex = 5;
            this.AutoFindMaxNodes.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // AutoFindMinThreshold
            // 
            this.AutoFindMinThreshold.Location = new System.Drawing.Point(183, 29);
            this.AutoFindMinThreshold.Name = "AutoFindMinThreshold";
            this.AutoFindMinThreshold.Size = new System.Drawing.Size(120, 20);
            this.AutoFindMinThreshold.TabIndex = 6;
            this.AutoFindMinThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AutoFindSolverType
            // 
            this.AutoFindSolverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutoFindSolverType.FormattingEnabled = true;
            this.AutoFindSolverType.Location = new System.Drawing.Point(183, 55);
            this.AutoFindSolverType.Name = "AutoFindSolverType";
            this.AutoFindSolverType.Size = new System.Drawing.Size(121, 21);
            this.AutoFindSolverType.TabIndex = 7;
            // 
            // AutoFindDesiredScore
            // 
            this.AutoFindDesiredScore.Location = new System.Drawing.Point(183, 82);
            this.AutoFindDesiredScore.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.AutoFindDesiredScore.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AutoFindDesiredScore.Name = "AutoFindDesiredScore";
            this.AutoFindDesiredScore.Size = new System.Drawing.Size(120, 20);
            this.AutoFindDesiredScore.TabIndex = 8;
            this.AutoFindDesiredScore.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // AutoFindMinBubbles
            // 
            this.AutoFindMinBubbles.Location = new System.Drawing.Point(183, 108);
            this.AutoFindMinBubbles.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AutoFindMinBubbles.Name = "AutoFindMinBubbles";
            this.AutoFindMinBubbles.Size = new System.Drawing.Size(120, 20);
            this.AutoFindMinBubbles.TabIndex = 9;
            this.AutoFindMinBubbles.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(33, 324);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(131, 32);
            this.save.TabIndex = 2;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(170, 324);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(131, 32);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(342, 367);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindMaxNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindMinThreshold)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMaxNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindDesiredScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFindMinBubbles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FindMaxNodes;
        private System.Windows.Forms.NumericUpDown FindMinThreshold;
        private System.Windows.Forms.ComboBox FindSolverType;
        private System.Windows.Forms.TextBox FindSaveTree;
        private System.Windows.Forms.NumericUpDown AutoFindMaxNodes;
        private System.Windows.Forms.NumericUpDown AutoFindMinThreshold;
        private System.Windows.Forms.ComboBox AutoFindSolverType;
        private System.Windows.Forms.NumericUpDown AutoFindDesiredScore;
        private System.Windows.Forms.NumericUpDown AutoFindMinBubbles;
    }
}