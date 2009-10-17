namespace BubblesHack
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pointButton = new System.Windows.Forms.Button();
            this.unpointButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalCount = new System.Windows.Forms.Label();
            this.pinkCount = new System.Windows.Forms.Label();
            this.orangeCount = new System.Windows.Forms.Label();
            this.greenCount = new System.Windows.Forms.Label();
            this.redCount = new System.Windows.Forms.Label();
            this.blueCount = new System.Windows.Forms.Label();
            this.pinkPicBox = new System.Windows.Forms.PictureBox();
            this.orangePicBox = new System.Windows.Forms.PictureBox();
            this.greenPicBox = new System.Windows.Forms.PictureBox();
            this.redPicBox = new System.Windows.Forms.PictureBox();
            this.bluePicBox = new System.Windows.Forms.PictureBox();
            this.findButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.autoFindButton = new System.Windows.Forms.Button();
            this.pauseTimer = new System.Windows.Forms.Timer(this.components);
            this.settingsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pinkPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pointButton
            // 
            this.pointButton.Image = ((System.Drawing.Image)(resources.GetObject("pointButton.Image")));
            this.pointButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pointButton.Location = new System.Drawing.Point(12, 12);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(77, 93);
            this.pointButton.TabIndex = 0;
            this.pointButton.Text = "Указать на пузыри";
            this.pointButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // unpointButton
            // 
            this.unpointButton.Image = ((System.Drawing.Image)(resources.GetObject("unpointButton.Image")));
            this.unpointButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.unpointButton.Location = new System.Drawing.Point(95, 12);
            this.unpointButton.Name = "unpointButton";
            this.unpointButton.Size = new System.Drawing.Size(77, 93);
            this.unpointButton.TabIndex = 1;
            this.unpointButton.Text = "Снять указание";
            this.unpointButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.unpointButton.UseVisualStyleBackColor = true;
            this.unpointButton.Click += new System.EventHandler(this.unpointButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalCount);
            this.groupBox1.Controls.Add(this.pinkCount);
            this.groupBox1.Controls.Add(this.orangeCount);
            this.groupBox1.Controls.Add(this.greenCount);
            this.groupBox1.Controls.Add(this.redCount);
            this.groupBox1.Controls.Add(this.blueCount);
            this.groupBox1.Controls.Add(this.pinkPicBox);
            this.groupBox1.Controls.Add(this.orangePicBox);
            this.groupBox1.Controls.Add(this.greenPicBox);
            this.groupBox1.Controls.Add(this.redPicBox);
            this.groupBox1.Controls.Add(this.bluePicBox);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Статус";
            // 
            // totalCount
            // 
            this.totalCount.AutoSize = true;
            this.totalCount.Location = new System.Drawing.Point(6, 168);
            this.totalCount.Name = "totalCount";
            this.totalCount.Size = new System.Drawing.Size(49, 13);
            this.totalCount.TabIndex = 10;
            this.totalCount.Text = "Всего: 0";
            // 
            // pinkCount
            // 
            this.pinkCount.AutoSize = true;
            this.pinkCount.Location = new System.Drawing.Point(48, 143);
            this.pinkCount.Name = "pinkCount";
            this.pinkCount.Size = new System.Drawing.Size(23, 13);
            this.pinkCount.TabIndex = 9;
            this.pinkCount.Text = "X 0";
            // 
            // orangeCount
            // 
            this.orangeCount.AutoSize = true;
            this.orangeCount.Location = new System.Drawing.Point(48, 114);
            this.orangeCount.Name = "orangeCount";
            this.orangeCount.Size = new System.Drawing.Size(23, 13);
            this.orangeCount.TabIndex = 8;
            this.orangeCount.Text = "X 0";
            // 
            // greenCount
            // 
            this.greenCount.AutoSize = true;
            this.greenCount.Location = new System.Drawing.Point(48, 86);
            this.greenCount.Name = "greenCount";
            this.greenCount.Size = new System.Drawing.Size(23, 13);
            this.greenCount.TabIndex = 7;
            this.greenCount.Text = "X 0";
            // 
            // redCount
            // 
            this.redCount.AutoSize = true;
            this.redCount.Location = new System.Drawing.Point(48, 55);
            this.redCount.Name = "redCount";
            this.redCount.Size = new System.Drawing.Size(23, 13);
            this.redCount.TabIndex = 6;
            this.redCount.Text = "X 0";
            // 
            // blueCount
            // 
            this.blueCount.AutoSize = true;
            this.blueCount.Location = new System.Drawing.Point(48, 27);
            this.blueCount.Name = "blueCount";
            this.blueCount.Size = new System.Drawing.Size(23, 13);
            this.blueCount.TabIndex = 5;
            this.blueCount.Text = "X 0";
            // 
            // pinkPicBox
            // 
            this.pinkPicBox.Image = ((System.Drawing.Image)(resources.GetObject("pinkPicBox.Image")));
            this.pinkPicBox.Location = new System.Drawing.Point(6, 135);
            this.pinkPicBox.Name = "pinkPicBox";
            this.pinkPicBox.Size = new System.Drawing.Size(32, 30);
            this.pinkPicBox.TabIndex = 4;
            this.pinkPicBox.TabStop = false;
            // 
            // orangePicBox
            // 
            this.orangePicBox.Image = ((System.Drawing.Image)(resources.GetObject("orangePicBox.Image")));
            this.orangePicBox.Location = new System.Drawing.Point(6, 106);
            this.orangePicBox.Name = "orangePicBox";
            this.orangePicBox.Size = new System.Drawing.Size(32, 30);
            this.orangePicBox.TabIndex = 3;
            this.orangePicBox.TabStop = false;
            // 
            // greenPicBox
            // 
            this.greenPicBox.Image = ((System.Drawing.Image)(resources.GetObject("greenPicBox.Image")));
            this.greenPicBox.Location = new System.Drawing.Point(6, 77);
            this.greenPicBox.Name = "greenPicBox";
            this.greenPicBox.Size = new System.Drawing.Size(32, 30);
            this.greenPicBox.TabIndex = 2;
            this.greenPicBox.TabStop = false;
            // 
            // redPicBox
            // 
            this.redPicBox.Image = ((System.Drawing.Image)(resources.GetObject("redPicBox.Image")));
            this.redPicBox.Location = new System.Drawing.Point(6, 48);
            this.redPicBox.Name = "redPicBox";
            this.redPicBox.Size = new System.Drawing.Size(32, 30);
            this.redPicBox.TabIndex = 1;
            this.redPicBox.TabStop = false;
            // 
            // bluePicBox
            // 
            this.bluePicBox.Image = ((System.Drawing.Image)(resources.GetObject("bluePicBox.Image")));
            this.bluePicBox.Location = new System.Drawing.Point(6, 19);
            this.bluePicBox.Name = "bluePicBox";
            this.bluePicBox.Size = new System.Drawing.Size(32, 30);
            this.bluePicBox.TabIndex = 0;
            this.bluePicBox.TabStop = false;
            // 
            // findButton
            // 
            this.findButton.Enabled = false;
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findButton.Location = new System.Drawing.Point(12, 398);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(159, 41);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Поиск решения...";
            this.findButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 111);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(77, 43);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Загрузить из файла";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(95, 111);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 42);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить в файл";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // autoFindButton
            // 
            this.autoFindButton.Enabled = false;
            this.autoFindButton.Image = ((System.Drawing.Image)(resources.GetObject("autoFindButton.Image")));
            this.autoFindButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.autoFindButton.Location = new System.Drawing.Point(12, 445);
            this.autoFindButton.Name = "autoFindButton";
            this.autoFindButton.Size = new System.Drawing.Size(159, 39);
            this.autoFindButton.TabIndex = 6;
            this.autoFindButton.Text = "Автопоиск решения...";
            this.autoFindButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.autoFindButton.UseVisualStyleBackColor = true;
            this.autoFindButton.Click += new System.EventHandler(this.autoFindButton_Click);
            // 
            // pauseTimer
            // 
            this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(12, 159);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(160, 34);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.Text = "Настройки...";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 495);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.autoFindButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.unpointButton);
            this.Controls.Add(this.pointButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BubblesHack";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pinkPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.Button unpointButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox bluePicBox;
        private System.Windows.Forms.PictureBox orangePicBox;
        private System.Windows.Forms.PictureBox greenPicBox;
        private System.Windows.Forms.PictureBox redPicBox;
        private System.Windows.Forms.PictureBox pinkPicBox;
        private System.Windows.Forms.Label pinkCount;
        private System.Windows.Forms.Label orangeCount;
        private System.Windows.Forms.Label greenCount;
        private System.Windows.Forms.Label redCount;
        private System.Windows.Forms.Label blueCount;
        private System.Windows.Forms.Label totalCount;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button autoFindButton;
        private System.Windows.Forms.Timer pauseTimer;
        private System.Windows.Forms.Button settingsButton;
    }
}

