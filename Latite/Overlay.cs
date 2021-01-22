using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latite
{
    // overlay for minecraft needed for Latite
    public partial class Overlay : Form
    {
        bool W_Pressed, A_Pressed, S_Pressed, D_Pressed, LMB_Pressed, RMB_Pressed;
        int lcps, rcps = 0;

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        // winuser.h
        [DllImport("user32.dll")]
        // LPCSTR lpClassName, LPCSTR lpWindowName
        public static extern IntPtr FindWindowA(string IpClassName, string IpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        // needed for size of minecraft window, pos, etc.
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT IpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow(); // get the window on the foreground

        public static IntPtr hWnd = FindWindowA(null, "Minecraft"); // find minecraft 
        public static RECT rect;

        public struct RECT
        {
            public int left, top, right, bottom;
        }

        private void secondRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                // CPS counter
                // todo not proper cps counter
                LMBCounter.Text = (lcps).ToString();
                RMBCounter.Text = (rcps).ToString();
                lcps = 0;
                rcps = 0;
            }
        }

        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (hWnd != (IntPtr)0)
            {

            } else
            {
                MessageBox.Show("Please open Minecraft first for the keystrokes and other things to work");
            }
            // cause transparency
            BackColor = Color.Brown;
            TransparencyKey = Color.Brown;

            // remove borders / minimize etc
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true; // appear ontop of other apps, needed for mc

            // able to click on mc
            var CurrentStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, CurrentStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
            // run constant running loop asynch so it matches mc window without freezing
            backgroundWorker1.RunWorkerAsync();
            secondRunner.RunWorkerAsync();
        }

        private void UpdateKeystrokes()
        {
            
            int[] NotPressedColor = { 60, 70, 80 };
            int[] PressedColor = { 70, 80, 90 };
            if (W_Pressed)
            {
                var Col = keyStrokes_W.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            } else
            {
                var Col = keyStrokes_W.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            }

            if (A_Pressed)
            {
                var Col = keyStrokes_A.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            }
            else
            {
                var Col = keyStrokes_A.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            }

            if (S_Pressed)
            {
                var Col = keyStrokes_S.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            }
            else
            {
                var Col = keyStrokes_S.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            }

            if (D_Pressed)
            {
                var Col = keyStrokes_D.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            }
            else
            {
                var Col = keyStrokes_D.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            }

            if (LMB_Pressed) Keystrokes_LMB.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            else Keystrokes_LMB.BackColor = Color.FromArgb(NotPressedColor[0], PressedColor[1], PressedColor[2]);

            if (RMB_Pressed) Keystrokes_RMB.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            else Keystrokes_RMB.BackColor = Color.FromArgb(NotPressedColor[0], PressedColor[1], PressedColor[2]);
            //MessageBox.Show("Updated kEystrokes");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10); // Cooldown
                if (GetForegroundWindow() != hWnd)
                {
                    IntPtr hWnd = FindWindowA(null, "Minecraft");
                    this.TopMost = false;
                } else
                {
                    this.TopMost = true;
                }
                if ((GetKeyState(0x57) & 0x8000) == 32768)
                {
                    W_Pressed = true;
                } else
                {
                    W_Pressed = false;
                }
                if ((GetKeyState((int)'A') & 0x8000) == 32768) A_Pressed = true;
                else A_Pressed = false;
                if ((GetKeyState((int)'S') & 0x8000) == 32768) S_Pressed = true;
                else S_Pressed = false;
                if ((GetKeyState((int)'D') & 0x8000) == 32768) D_Pressed = true;
                else D_Pressed = false;

                if ((GetKeyState(0x01) & 0x8000) == 32768) {
                    if (!LMB_Pressed) { lcps++; };
                    LMB_Pressed = true;
                }
                else LMB_Pressed = false;
                if ((GetKeyState(0x02) & 0x8000) == 32768) {
                    if (!RMB_Pressed) rcps++;
                    RMB_Pressed = true;
                }
                else RMB_Pressed = false;
                UpdateKeystrokes();

                GetWindowRect(hWnd, out rect);
                this.Size = new Size(rect.right - rect.left,
                    rect.bottom - rect.top);

                // Set the position of the form
                this.Left = rect.left;
                this.Top = rect.top;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
