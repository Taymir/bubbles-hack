using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BubblesHack
{
    class NativeWin32
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int FindWindow(
            string lpClassName, // class name 
            string lpWindowName // window name 
        );

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            int hWnd, // handle to destination window 
            uint Msg, // message 
            int wParam, // first message parameter 
            int lParam // second message parameter 
        );

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(
            int hWnd // handle to window
            );

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_APPWINDOW = 0x40000;
              
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST  = 1;
        public const int GW_HWNDNEXT  = 2;
        public const int GW_HWNDPREV  = 3;
        public const int GW_OWNER     = 4;
        public const int GW_CHILD     = 5;

        public delegate int EnumWindowsProcDelegate(int hWnd, int lParam);

        [DllImport("user32")]
        public static extern int EnumWindows(EnumWindowsProcDelegate lpEnumFunc, int lParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern int GetWindowLongPtr(int hwnd, int nIndex);

        [DllImport("user32")]
        public static extern int GetParent(int hwnd);

        [DllImport("user32")]
        public static extern int GetWindow(int hwnd, int wCmd);

        [DllImport("user32")]
        public static extern int IsWindowVisible(int hwnd);

        [DllImport("user32")]
        public static extern int GetDesktopWindow();

        public const int VK_A = 0x41;
        public const int VK_F5 = 0x74;



        public static void sendF5()
        {
            KEYBDINPUT k = new KEYBDINPUT();
            k.wVk = VK_A;


            INPUT i = new INPUT();
            i.type = INPUT_KEYBOARD;
            i.ki = k;

            INPUT[] inputs = new INPUT[] { i };
            int isize = Marshal.SizeOf(i);

            SendInput(1, inputs, isize);
        }

        public static void click()
        {
            MOUSEINPUT m = new MOUSEINPUT();
            m.dx = 0;
            m.dy = 0;
            m.mouseData = 0;
            m.time = 0;
            m.dwFlags = MOUSEEVENTF_LEFTDOWN;

            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi = m;

            INPUT[] inputs = new INPUT[] { i };
            int isize = Marshal.SizeOf(i);

            SendInput(1, inputs, isize);

            System.Threading.Thread.Sleep(100);

            /*MOUSEINPUT*/ m = new MOUSEINPUT();
            m.dx = 0;
            m.dy = 0;
            m.mouseData = 0;
            m.time = 0;
            m.dwFlags = MOUSEEVENTF_LEFTUP;

            /*INPUT*/ i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi = m;

            /*INPUT[]*/ inputs = new INPUT[] { i };
            /*int*/ isize = Marshal.SizeOf(i);

            SendInput(1, inputs, isize);

        }



        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int
        cbSize);
        [StructLayout(LayoutKind.Explicit)]
        struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            uint uMsg;
            ushort wParamL;
            ushort wParamH;
        }
        const uint XBUTTON1 = 0x0001;
        const uint XBUTTON2 = 0x0002;

        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const int INPUT_MOUSE = 0;
        const int INPUT_KEYBOARD = 1;
        const int INPUT_HARDWARE = 2;
    }
}
