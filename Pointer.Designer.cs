namespace BubblesHack
{
    partial class Pointer
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
            this.ColorRestoreTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ColorRestoreTimer
            // 
            this.ColorRestoreTimer.Interval = 500;
            this.ColorRestoreTimer.Tick += new System.EventHandler(this.ColorRestoreTimer_Tick);
            // 
            // Pointer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(627, 610);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pointer";
            this.Opacity = 0.7;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pointer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Pointer_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pointer_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pointer_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pointer_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pointer_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ColorRestoreTimer;
    }
}