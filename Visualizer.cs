using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubblesHack
{
    public partial class Visualizer : Form
    {
        private const int bubbleSize = 28;

        private BubbleGrid origGrid;
        private BubbleGrid currGrid;
        private Move[] movesHistory;
        private int moveCount;

        public Visualizer(BubbleGrid orig, List<Move> history) //@TMP
        {
            InitializeComponent();

            this.origGrid = orig;
            this.currGrid = orig.Clone();
            this.movesHistory = history.ToArray();
            this.moveCount = 0;

            this.renderBubbles(origGrid);

            this.prev.Enabled = false;
        }

        public Visualizer(BubbleGrid orig, Move[] history)
        {
            InitializeComponent();

            this.origGrid = orig;
            this.currGrid = orig.Clone();
            this.movesHistory = history;
            this.moveCount = 0;

            this.renderBubbles(origGrid);

            this.prev.Enabled = false;
        }

        private void Visualizer_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new Size(BubbleGrid.totalCols * 28, BubbleGrid.totalRows * 28);
            //this.pictureBox1.BackColor = Color.FromArgb(68, 149, 255);
        }

        public void renderBubbles(BubbleGrid grid)
        {
            this.pictureBox1.Image = new Bitmap(BubbleGrid.totalCols * bubbleSize, BubbleGrid.totalRows * bubbleSize);
            Graphics g = Graphics.FromImage(this.pictureBox1.Image);
            for (int row = 0; row < BubbleGrid.totalRows; row++)
            {
                for (int col = 0; col < BubbleGrid.totalCols; col++)
                {
                    
                    switch (grid.getBubble(row, col))
                    {
                        case BubbleColor.Blue:
                            g.DrawImage(Form1.bluePicBox_Image, new Rectangle(col * bubbleSize, row * bubbleSize, bubbleSize, bubbleSize));
                            break;
                        case BubbleColor.Green:
                            g.DrawImage(Form1.greenPicBox_Image, new Rectangle(col * bubbleSize, row * bubbleSize, bubbleSize, bubbleSize));
                            break;
                        case BubbleColor.Orange:
                            g.DrawImage(Form1.orangePicBox_Image, new Rectangle(col * bubbleSize, row * bubbleSize, bubbleSize, bubbleSize));
                            break;
                        case BubbleColor.Pink:
                            g.DrawImage(Form1.pinkPicBox_Image, new Rectangle(col * bubbleSize, row * bubbleSize, bubbleSize, bubbleSize));
                            break;
                        case BubbleColor.Red:
                            g.DrawImage(Form1.redPicBox_Image, new Rectangle(col * bubbleSize, row * bubbleSize, bubbleSize, bubbleSize));
                            break;
                    }
                    
                }
            }
            if(moveCount < movesHistory.Length)
                renderMove(g, movesHistory[moveCount]);

            this.score.Text = grid.getScore().ToString();
            this.step.Text = this.moveCount.ToString() + " / " + this.movesHistory.Length;
        }

        public void renderMove(Graphics g, Move move)
        {
            Point[] points = this.currGrid.findAdjacentBubbles(move.row, move.col);

            foreach (Point p in points)
                g.DrawEllipse(new Pen(Brushes.Black, 3), p.X * bubbleSize, p.Y * bubbleSize, bubbleSize, bubbleSize);
        }

        private void next_Click(object sender, EventArgs e)
        {
            currGrid.clickAt(movesHistory[moveCount++]);

            renderBubbles(currGrid);

            if (moveCount >= movesHistory.Length)
                next.Enabled = false;
            prev.Enabled = true;
        }

        private void first_Click(object sender, EventArgs e)
        {
            this.currGrid = this.origGrid.Clone();
            this.moveCount = 0;

            renderBubbles(currGrid);

            next.Enabled = true;
            prev.Enabled = false;
        }

        private void last_Click(object sender, EventArgs e)
        {
            while (moveCount < movesHistory.Length)
                currGrid.clickAt(movesHistory[moveCount++]);

            renderBubbles(currGrid);

            next.Enabled = false;
            prev.Enabled = true;
        }

        private void prev_Click(object sender, EventArgs e)
        {
            int prevCount = this.moveCount - 1;
            this.currGrid = this.origGrid.Clone();
            this.moveCount = 0;

            while (moveCount < prevCount)
                currGrid.clickAt(movesHistory[moveCount++]);

            renderBubbles(currGrid);

            if (moveCount == 0)
                prev.Enabled = false;
            next.Enabled = true;


        }

        private void savePathButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.Stream stream;
                if ((stream = openFileDialog1.OpenFile()) != null)
                {
                    this.saveHistory(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save file. Original error: " + ex.Message);
            }
        }

        private void saveHistory(System.IO.Stream stream)
        {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);

                foreach (Move m in this.movesHistory)
                    writer.WriteLine(m.row.ToString() + "\t" + m.col.ToString());

                writer.Flush();
                writer.Close();

        }

        private Timer clickTimer;
        private void clickPathButton_Click(object sender, EventArgs e)
        {
            first_Click(this, null);

            clickTimer = new Timer();
            clickTimer.Tick += new EventHandler(clickTimer_Tick);
            clickTimer.Interval = 1500;
            clickTimer.Enabled = true;
        }

        void clickTimer_Tick(object sender, EventArgs e)
        {
            int row = movesHistory[moveCount].row;
            int col = movesHistory[moveCount].col;

            Form1.Instance().pform.clickAt(row, col);
            next_Click(null, null);

            if (moveCount >= movesHistory.Length)
            {
                System.Media.SystemSounds.Asterisk.Play();
                clickTimer.Enabled = false;
            }
        }
    }
}
