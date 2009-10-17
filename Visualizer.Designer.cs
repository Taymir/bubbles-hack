namespace BubblesHack
{
    partial class Visualizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.prev = new System.Windows.Forms.Button();
            this.last = new System.Windows.Forms.Button();
            this.first = new System.Windows.Forms.Button();
            this.step = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clickPathButton = new System.Windows.Forms.Button();
            this.savePathButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 308);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // next
            // 
            this.next.Image = ((System.Drawing.Image)(resources.GetObject("next.Image")));
            this.next.Location = new System.Drawing.Point(266, 380);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(52, 36);
            this.next.TabIndex = 3;
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(216, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Счет:";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score.Location = new System.Drawing.Point(263, 322);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(17, 18);
            this.score.TabIndex = 3;
            this.score.Text = "0";
            // 
            // prev
            // 
            this.prev.Image = ((System.Drawing.Image)(resources.GetObject("prev.Image")));
            this.prev.Location = new System.Drawing.Point(208, 380);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(52, 36);
            this.prev.TabIndex = 2;
            this.prev.UseVisualStyleBackColor = true;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // last
            // 
            this.last.Image = ((System.Drawing.Image)(resources.GetObject("last.Image")));
            this.last.Location = new System.Drawing.Point(324, 380);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(52, 36);
            this.last.TabIndex = 4;
            this.last.UseVisualStyleBackColor = true;
            this.last.Click += new System.EventHandler(this.last_Click);
            // 
            // first
            // 
            this.first.Image = ((System.Drawing.Image)(resources.GetObject("first.Image")));
            this.first.Location = new System.Drawing.Point(150, 380);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(52, 36);
            this.first.TabIndex = 1;
            this.first.UseVisualStyleBackColor = true;
            this.first.Click += new System.EventHandler(this.first_Click);
            // 
            // step
            // 
            this.step.AutoSize = true;
            this.step.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.step.Location = new System.Drawing.Point(263, 340);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(17, 18);
            this.step.TabIndex = 8;
            this.step.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(216, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Шаг:";
            // 
            // clickPathButton
            // 
            this.clickPathButton.Location = new System.Drawing.Point(382, 380);
            this.clickPathButton.Name = "clickPathButton";
            this.clickPathButton.Size = new System.Drawing.Size(93, 35);
            this.clickPathButton.TabIndex = 9;
            this.clickPathButton.Text = "Прокликать";
            this.clickPathButton.UseVisualStyleBackColor = true;
            this.clickPathButton.Click += new System.EventHandler(this.clickPathButton_Click);
            // 
            // savePathButton
            // 
            this.savePathButton.Location = new System.Drawing.Point(51, 381);
            this.savePathButton.Name = "savePathButton";
            this.savePathButton.Size = new System.Drawing.Size(93, 35);
            this.savePathButton.TabIndex = 10;
            this.savePathButton.Text = "Сохранить";
            this.savePathButton.UseVisualStyleBackColor = true;
            this.savePathButton.Click += new System.EventHandler(this.savePathButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 436);
            this.Controls.Add(this.savePathButton);
            this.Controls.Add(this.clickPathButton);
            this.Controls.Add(this.step);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.first);
            this.Controls.Add(this.last);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Visualizer";
            this.Text = "Visualizer";
            this.Load += new System.EventHandler(this.Visualizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button last;
        private System.Windows.Forms.Button first;
        private System.Windows.Forms.Label step;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clickPathButton;
        private System.Windows.Forms.Button savePathButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}