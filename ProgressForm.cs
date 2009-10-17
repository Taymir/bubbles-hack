using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BubblesHack.Solvers;

namespace BubblesHack
{
    public delegate void CompleteEventHandler(ProgressForm sender, int score);

    public partial class ProgressForm : Form
    {
        private BubbleGrid bubbles;
        private MCTSSolver solver;

        public event CompleteEventHandler onComplete;

        public int maxNodes
        {
            set
            {
                solver.maxNodes = value;
            }

            get
            {
                return solver.maxNodes;
            }
        }
        public int minThreshold
        {
            set
            {
                solver.minThreshold = value;
            }

            get
            {
                return solver.minThreshold;
            }
        }
        public string solverType
        {
            set
            {
                solver.solverType = value;
            }

            get
            {
                return solver.solverType;
            }
        }

        public ProgressForm(BubbleGrid bubbles)
        {
            InitializeComponent();

            this.bubbles = bubbles.Clone();

            solver = new MCTSSolver(bubbles);

            solver.maxNodes = Properties.Settings.Default.FindMaxNodes;
            solver.minThreshold = Properties.Settings.Default.FindMinThreshold;
            solver.solverType = Properties.Settings.Default.FindSolverType;

            solver.onProgress += new ProgressEventHandler(this.progressUpdate);
        }

        public void progressUpdate(int progress, int score, int seconds, int nods, double avgScore)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new BubblesHack.Solvers.ProgressEventHandler(progressUpdate),
                    new object[] { progress, score, seconds, nods, avgScore });
            }
            else
            {
                this.progressBar1.Value = progress;
                this.score.Text = score.ToString();
                this.time.Text = seconds.ToString();
                this.nods.Text = nods.ToString();
                this.avgScore.Text = Math.Round(avgScore, 2).ToString();
                Process currentProc = Process.GetCurrentProcess();
                this.memory.Text = ((int)(currentProc.WorkingSet64 / 1048576)).ToString();

                if (progress == 100)
                    this.ok.Enabled = true;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void solve()
        {
            this.backgroundWorker1.RunWorkerAsync();
        }

        public void Visualize()
        {
            Visualizer vis = new Visualizer(bubbles, solver.bestHistory);
            vis.Show();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (onComplete == null)
            {
                Visualize();

                if (Properties.Settings.Default.FindSaveTree != "")
                    solver.dumpToFile(Properties.Settings.Default.FindSaveTree);
            }
            else
            {
                onComplete(this, solver.bestScore);
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            solver.solve();
        }
    }
}
