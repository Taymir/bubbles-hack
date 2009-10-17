using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BubblesHack
{
    struct RGB
    {
        public double R;
        public double G;
        public double B;
    }

    struct XYZ
    {
        public double X;
        public double Y;
        public double Z;
    }

    struct LAB
    {
        public double L;
        public double a;
        public double b;
    }

    public partial class Pointer : Form
    {
        public const int borderSize = 10;
        public const int gameWidth = 607;
        public const int gameHeight = 590;

        private const double tao = 15.00; //Предельное значение ф-ии colorDistance при котором цвета считаются равными

        private Form1 form1;

        private int relX, relY;

        public Dictionary<BubbleColor, Color> colorsMap;

        /*[DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string strDriver, string strDevice,
                                             string strOutput, IntPtr pData);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int x, int y);

        [DllImport("user32")]
        internal static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        internal static extern void ReleaseDC(IntPtr dc);*/

        public Pointer(Form1 form1)
        {
            InitializeComponent();

            this.form1 = form1;

            this.colorsMap = new Dictionary<BubbleColor, Color>(5);
            
            colorsMap.Add(BubbleColor.Blue, Color.FromArgb(3, 4, 218));
            colorsMap.Add(BubbleColor.Red, Color.FromArgb(219, 2, 2));
            colorsMap.Add(BubbleColor.Green, Color.FromArgb(4, 156, 4));
            colorsMap.Add(BubbleColor.Orange, Color.FromArgb(244, 146, 2));
            colorsMap.Add(BubbleColor.Pink, Color.FromArgb(183, 3, 183));
        }

        private void Pointer_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(borderSize + gameWidth + borderSize, borderSize + gameHeight + borderSize); // Переопределение размера

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, this.Size.Width, this.Size.Height));
            gp.AddRectangle(new Rectangle(borderSize, borderSize, gameWidth, gameHeight));
            this.Region = new Region(gp);


            this.Location = Properties.Settings.Default.PointerWindowLocation;
        }

        private void Pointer_MouseDown(object sender, MouseEventArgs e)
        {
            this.relX = e.X;
            this.relY = e.Y;
        }

        private void Pointer_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.None)
                this.dragForm(e.X, e.Y);
        }

        private void dragForm(int x, int y)
        {
            this.Left = this.Left + (x - relX);
            this.Top = this.Top + (y - relY);

            this.Refresh();
        }

        private void Pointer_MouseUp(object sender, MouseEventArgs e)
        {
            performValidation();
        }

        public void countBubbles()
        {
            form1.eraseCounts();
            Bitmap screenshot = getScreenshot();

            for (int row = 0; row < 11; ++row)
            {
                for (int col = 0; col < 19; ++col)
                {
                    BubbleColor bubble = detectBubbleColor(getPixelColor(gamePoint2ScreenPoint(col, row), screenshot));

                    switch (bubble)
                    {
                        case BubbleColor.Blue:
                            form1.blueBubbles++;
                            break;
                        case BubbleColor.Green:
                            form1.greenBubbles++;
                            break;
                        case BubbleColor.Orange:
                            form1.orangeBubbles++;
                            break;
                        case BubbleColor.Pink:
                            form1.pinkBubbles++;
                            break;
                        case BubbleColor.Red:
                            form1.redBubbles++;
                            break;
                        default:
                            form1.unknownBubbles++;
                            form1.totalBubbles--;
                            break;
                    }

                    form1.totalBubbles++;

                    form1.bubbles.setBubble(row, col, bubble);

                    #region debug
                    /*IntPtr deskDc = GetDC(IntPtr.Zero);
                    Graphics g = Graphics.FromHdc(deskDc);
                    
                    g.DrawRectangle(new Pen(this.colorsMap[col]), new Rectangle(gamePoint2ScreenPoint(i, j), new Size(8,8)));
                    g.Dispose();
                    ReleaseDC(deskDc);*/
                    #endregion

                    form1.fillCounts();
                }
            }
        }

        private static Bitmap getScreenshot()
        {
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(screenshot);
            gr.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            
            return screenshot;
        }

        public bool performValidation()
        {
            if (!validateBubbles())
            {
                this.BackColor = Color.DarkRed;
                ColorRestoreTimer.Enabled = true;
                return false;
            }
            else
            {
                this.BackColor = Color.LightGreen;
                ColorRestoreTimer.Enabled = true;
                return true;
            }
        }

        private bool validateBubbles()
        {
            this.countBubbles();

            if (form1.totalBubbles == 209 &&
                form1.blueBubbles > 10 &&
                form1.redBubbles > 10 &&
                form1.greenBubbles > 10 &&
                form1.orangeBubbles > 10 &&
                form1.pinkBubbles > 10)

                return true;

            form1.eraseCounts();
            return false;
        }


        private Point gamePoint2ScreenPoint(int col, int row)
        {
            Point p = new Point();

            p.X = 
                this.Left +    // Край формы
                borderSize +   // ширина бордера
                10 +           // от начала игрового экрана
                col * 31 +  // ширина шарика 28 + расстояние между шариками 3
                17;            // точка внутри шарика

            p.Y =
                this.Top +     // Край формы
                borderSize +   // ширина бордера
                38 +           // от начала игрового экрана
                row * 31 +     // высота шарика 27 + расстояние между шариками 4
                17;            // точка внутри шарика

            #region debug
            /*IntPtr deskDc = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(deskDc);
            g.DrawRectangle(Pens.AntiqueWhite, p.X - 2, p.Y - 2, 4, 4);
            g.Dispose();
            ReleaseDC(deskDc);*/
            #endregion

            return p;
        }

        private Color getPixelColor(int x, int y, Bitmap screenshot)
        {
            /* OLD GDI func
             * // Call the three external functions.

            IntPtr hdcScreen = CreateDC("Display", null, null, IntPtr.Zero);
            int cr = GetPixel(hdcScreen, x, y);
            DeleteDC(hdcScreen);

            // Convert a Win32 COLORREF to a .NET Color object

            Color clr = Color.FromArgb((cr & 0x000000FF),
                                 (cr & 0x0000FF00) >> 8,
                                 (cr & 0x00FF0000) >> 16);
            */
            Color clr = screenshot.GetPixel(x, y);

            return clr;
        }

        private Color getPixelColor(Point p, Bitmap screenshot)
        {
            return getPixelColor(p.X, p.Y, screenshot);
        }

        private BubbleColor detectBubbleColor(Color testColor)
        {
            BubbleColor bestColor = BubbleColor.Unknown;
            double bestTao = tao;

            foreach (KeyValuePair<BubbleColor, Color> pair in this.colorsMap)
            {
                double currentTao = colorDifference(pair.Value, testColor);
                if (currentTao < bestTao)
                {
                    bestTao = currentTao;
                    bestColor = pair.Key;
                }
            }


            return bestColor;
        }

        private double colorDifference(Color A, Color B)
        {
            // uses CIE1994 def-algorithm

            LAB labA = xyz2lab(rgb2xyz(A));
            LAB labB = xyz2lab(rgb2xyz(B));

            double dL = labA.L - labB.L;
            double Ca = Math.Sqrt(Math.Pow(labA.a, 2) + Math.Pow(labA.b, 2));
            double Cb = Math.Sqrt(Math.Pow(labB.a, 2) + Math.Pow(labB.b, 2));
            double dC = Ca - Cb;
            double da = labA.a - labB.a;
            double db = labA.b - labB.b;

            double Sc = 1 + 0.045 * Ca;
            double Sh = 1 + 0.015 * Ca;

            double dH = Math.Sqrt(Math.Pow(da, 2) + Math.Pow(db, 2) - Math.Pow(dC, 2));

            double dE = Math.Sqrt(Math.Pow(dL, 2) + Math.Pow(dC / Sc, 2) + Math.Pow(dH / Sh, 2));

            return dE;
        }

        private static LAB xyz2lab(XYZ col)
        {
            //XYZ -> Lab conversion
            col.X /= 95.047;
            col.Y /= 100;
            col.Z /= 108.883;

            if (col.X > 0.008856)
                col.X = Math.Pow(col.X, 1.0 / 3.0);
            else
                col.X = 7.787 * col.X + 16.0 / 116.0;

            if (col.Y > 0.008856)
                col.Y = Math.Pow(col.Y, 1.0 / 3.0);
            else
                col.Y = 7.787 * col.Y + 16.0 / 116.0;

            if (col.Z > 0.008856)
                col.Z = Math.Pow(col.Z, 1.0 / 3.0);
            else
                col.Z = 7.787 * col.Z + 16.0 / 116.0;


            LAB lab = new LAB();
            lab.L = 116 * col.Y - 16;
            lab.a = 500 * (col.X - col.Y);
            lab.b = 200 * (col.Y - col.Z);

            return lab;
        }

        private static XYZ rgb2xyz(Color A)
        {
            RGB col = new RGB();

            //RGB -> XYZ conversion
            col.R = (double)A.R / 255;
            col.G = (double)A.G / 255;
            col.B = (double)A.B / 255;

            if (col.R > 0.04045)
            {
                col.R = (col.R + 0.055) / 1.055;
                col.R = Math.Pow(col.R, 2.4);
            }
            else
            {
                col.R = col.R / 12.92;
            }


            if (col.G > 0.04045)
            {
                col.G = (col.G + 0.055) / 1.055;
                col.G = Math.Pow(col.G, 2.4);
            }
            else
            {
                col.G = col.G / 12.92;
            }


            if (col.B > 0.04045)
            {
                col.B = (col.B + 0.055) / 1.055;
                col.B = Math.Pow(col.B, 2.4);
            }
            else
            {
                col.B = col.B / 12.92;
            }

            col.R *= 100.0;
            col.G *= 100.0;
            col.B *= 100.0;

            XYZ xyz = new XYZ();
            xyz.X = col.R * 0.4124 + col.G * 0.3576 + col.B * 0.1805;
            xyz.Y = col.R * 0.2126 + col.G * 0.7152 + col.B * 0.0722;
            xyz.Z = col.R * 0.0193 + col.G * 0.1192 + col.B * 0.9505;

            return xyz;
        }

        private void ColorRestoreTimer_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            ((Timer)sender).Enabled = false;
        }

        private void Pointer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PointerWindowLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        public void clickAt(int row, int col)
        {
            Point p = gamePoint2ScreenPoint(col, row);

            Cursor.Position = p;
            System.Threading.Thread.Sleep(500);
            Cursor.Position = p;
            NativeWin32.click();
        }

        public void clickUpdate()
        {
            Point p = gamePoint2ScreenPoint(17, 0);
            p.X -= 25;
            p.Y -= 40;

            Cursor.Position = p;
            System.Threading.Thread.Sleep(100);
            Cursor.Position = p;
            NativeWin32.click();


            Cursor.Position = new Point(100, 1000);
        }
    }
}
