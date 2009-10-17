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
    public partial class SettingsForm : Form
    {
        private string[] solvers = { 
                                       "FirstChoiceSolver",
                                       "RandomSolver",
                                       "TabuColourRandomSolver",
                                       "TabuDoubleColourRandomSolver",
                                       "SortColourRandomSolver"
                                   };
        public SettingsForm()
        {
            InitializeComponent();

            this.FindSolverType.Items.AddRange(solvers);

            this.AutoFindSolverType.Items.AddRange(solvers);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.loadFromSettings();
            this.Hide();
        }

        private void save_Click(object sender, EventArgs e)
        {
            this.saveTosettings();
            this.Hide();
        }

        private void loadFromSettings()
        {
            this.FindMaxNodes.Value = Properties.Settings.Default.FindMaxNodes;
            this.FindMinThreshold.Value = Properties.Settings.Default.FindMinThreshold;
            this.FindSolverType.Text = cutBubblesHackString(Properties.Settings.Default.FindSolverType);
            this.FindSaveTree.Text = Properties.Settings.Default.FindSaveTree;

            this.AutoFindMaxNodes.Value = Properties.Settings.Default.AutoFindMaxNodes;
            this.AutoFindMinThreshold.Value = Properties.Settings.Default.AutoFindMinThreshold;
            this.AutoFindSolverType.Text = cutBubblesHackString(Properties.Settings.Default.AutoFindSolverType);
            this.AutoFindDesiredScore.Value = Properties.Settings.Default.AutoFindDesiredScore;
            this.AutoFindMinBubbles.Value = Properties.Settings.Default.AutoFindMinBubbles;
        }

        private string cutBubblesHackString(string str)
        {
            return str.Remove(0, "BubblesHack.Solvers.".Length);
        }

        private string pasteBubblesHackString(string str)
        {
            return "BubblesHack.Solvers." + str;
        }

        private void saveTosettings()
        {
            Properties.Settings.Default.FindMaxNodes = (int)this.FindMaxNodes.Value;
            Properties.Settings.Default.FindMinThreshold = (int)this.FindMinThreshold.Value;
            Properties.Settings.Default.FindSolverType = pasteBubblesHackString(this.FindSolverType.Text);
            Properties.Settings.Default.FindSaveTree = this.FindSaveTree.Text;

            Properties.Settings.Default.AutoFindMaxNodes = (int)this.AutoFindMaxNodes.Value;
            Properties.Settings.Default.AutoFindMinThreshold = (int)this.AutoFindMinThreshold.Value;
            Properties.Settings.Default.AutoFindSolverType = pasteBubblesHackString(this.AutoFindSolverType.Text);
            Properties.Settings.Default.AutoFindDesiredScore = (int)this.AutoFindDesiredScore.Value;
            Properties.Settings.Default.AutoFindMinBubbles = (int)this.AutoFindMinBubbles.Value;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.loadFromSettings();
        }
    }
}
