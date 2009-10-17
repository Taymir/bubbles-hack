using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BubblesHack.Solvers;
using System.IO;

namespace BubblesHack
{
    public partial class Form1 : Form
    {
        public Pointer pform;

        public int blueBubbles;
        public int redBubbles;
        public int greenBubbles;
        public int orangeBubbles;
        public int pinkBubbles;
        public int unknownBubbles;
        public int totalBubbles;

        public BubbleGrid bubbles;

        private static Form1 instance;

        public Form1()
        {
            InitializeComponent();

            bubbles = new BubbleGrid();
            pform = new Pointer(this);
        }

        public static Form1 Instance()
        {
            if (instance == null)
                instance = new Form1();

            return instance;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if( Properties.Settings.Default.MainWindowLocation.X > 0 &&
                Properties.Settings.Default.MainWindowLocation.X < Screen.PrimaryScreen.Bounds.Width &&
                Properties.Settings.Default.MainWindowLocation.Y > 0 &&
                Properties.Settings.Default.MainWindowLocation.Y < Screen.PrimaryScreen.Bounds.Height)
            this.Location = Properties.Settings.Default.MainWindowLocation;
        }

        public void fillCounts()
        {
            // Заполнение
            this.updateCounts();

            // Включение контролов
            this.groupBox1.Enabled = true;
            this.findButton.Enabled = true;
            this.autoFindButton.Enabled = true;
            this.saveButton.Enabled = true;
        }

        public void updateCounts()
        {
            this.blueCount.Text = "X " + blueBubbles.ToString();
            this.redCount.Text = "X " + redBubbles.ToString();
            this.greenCount.Text = "X " + greenBubbles.ToString();
            this.orangeCount.Text = "X " + orangeBubbles.ToString();
            this.pinkCount.Text = "X " + pinkBubbles.ToString();
            this.totalCount.Text = "Всего: " + totalBubbles.ToString();
        }

        public void eraseCounts()
        {
            // Очистка
            blueBubbles = 0;
            redBubbles = 0;
            greenBubbles = 0;
            orangeBubbles = 0;
            pinkBubbles = 0;
            unknownBubbles = 0;
            totalBubbles = 0;

            this.updateCounts();
            this.bubbles.clearBubbles();

            // Отключение контролов
            this.groupBox1.Enabled = false;
            this.findButton.Enabled = false;
            this.autoFindButton.Enabled = false;
            this.saveButton.Enabled = false;
        }



        private void pointButton_Click(object sender, EventArgs e)
        {
            pform.Show();
            pform.performValidation();
        }

        private void unpointButton_Click(object sender, EventArgs e)
        {
            pform.Hide();
            this.eraseCounts();
            pauseTimer.Enabled = false;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            ProgressForm progress = new ProgressForm(bubbles);
            progress.Show();
            progress.solve(); 
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            pform.Close();
            Properties.Settings.Default.MainWindowLocation = this.Location;

            Properties.Settings.Default.Save();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Stream stream;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        this.bubbles = BubbleGrid.loadFromFile(stream);
                        this.blueBubbles = bubbles.counter[BubbleColor.Blue];
                        this.greenBubbles = bubbles.counter[BubbleColor.Green];
                        this.redBubbles = bubbles.counter[BubbleColor.Red];
                        this.orangeBubbles = bubbles.counter[BubbleColor.Orange];
                        this.pinkBubbles = bubbles.counter[BubbleColor.Pink];
                        this.totalBubbles = this.blueBubbles + this.greenBubbles + this.redBubbles + this.orangeBubbles + this.pinkBubbles;

                        this.fillCounts();
                        pform.Hide();
                        autoFindButton.Enabled = false;
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Stream stream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = saveFileDialog1.OpenFile()) != null)
                    {
                        BubbleGrid.saveToFile(this.bubbles, stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file. Original error: " + ex.Message);
                }
            }
        }


        private Random rnd;
        private int iHandle;
        private ProgressForm progress;
        private void autoFindButton_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            
            iHandle = NativeWin32.FindWindow(null, Properties.Settings.Default.AutoFindBrowserString);
            if (iHandle == 0)
            {
                MessageBox.Show("Окно браузера не обнаружено");
                return;
            }
            pauseTimer.Interval = 100;
            pauseTimer.Enabled = true;
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            int minBubbles = Properties.Settings.Default.AutoFindMinBubbles;

            this.pauseTimer.Enabled = false;
            // Считаем очки
            if (pform.performValidation())
            {
                if (
                        blueBubbles > minBubbles ||
                        redBubbles > minBubbles ||
                        greenBubbles > minBubbles ||
                        orangeBubbles > minBubbles ||
                        pinkBubbles > minBubbles
                    )
                {
                    // Работаем с данным раскладом...
                    progress = new ProgressForm(bubbles);
                    
                    progress.maxNodes = Properties.Settings.Default.AutoFindMaxNodes;
                    progress.minThreshold = Properties.Settings.Default.AutoFindMinThreshold;
                    progress.solverType = Properties.Settings.Default.AutoFindSolverType;

                    progress.onComplete += new CompleteEventHandler(autoFindProgress_onComplete);
                    progress.Show();
                    progress.solve();
                    
                    pauseTimer.Enabled = false;
                        
                    return;
                }

                updateGame();
            }

            autoFindPause();

            this.pauseTimer.Enabled = true;
        }

        private void autoFindPause()
        {
            // Таймер ожидания
            if (rnd.Next(1000) == 99)
                // Иногда ожидаем долго...
                pauseTimer.Interval = Properties.Settings.Default.AutoFindLongPause + rnd.Next(Properties.Settings.Default.AutoFindLongPause / 2);
            else
                // Но, обычно - всего пару секунд
                pauseTimer.Interval = Properties.Settings.Default.AutoFindShortPause + rnd.Next(Properties.Settings.Default.AutoFindShortPause / 2);
        }

        private void updateGame()
        {
            Form1.Instance().pform.clickUpdate();
            //int iOtherWindow = NativeWin32.GetForegroundWindow(); // не работает
            //NativeWin32.SetForegroundWindow(iHandle);
            //NativeWin32.sendF5();
            //NativeWin32.SetForegroundWindow(iOtherWindow);
        }

        void autoFindProgress_onComplete(ProgressForm sender, int score)
        {
            if (score >= Properties.Settings.Default.AutoFindDesiredScore)
            {
                // STOP AUTOFIND
                sender.Visualize();
                System.Media.SystemSounds.Asterisk.Play();

                this.pauseTimer.Enabled = false;
            }
            else
            {
                // CONTINUE AUTOFIND
                sender.Close();

                updateGame();
                autoFindPause();
                this.pauseTimer.Enabled = true;
            }
        }

        private SettingsForm sform = new SettingsForm();
        private void settingsButton_Click(object sender, EventArgs e)
        {
            if(!sform.Visible)
                sform.Show(this);
        }
    }
}