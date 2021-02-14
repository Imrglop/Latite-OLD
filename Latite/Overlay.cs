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
        bool W_Pressed, A_Pressed, S_Pressed, D_Pressed, LMB_Pressed, RMB_Pressed, Space_Pressed;
        int lcps, rcps = 0;
        private int OldStyle = 0;

        LatiteForm latiteForm;
        DragUtils dragUtils;

        [DllImport("LatiteCore.dll")]
        static extern float LPGetYMotion();
        [DllImport("LatiteCore.dll")]
        static extern float LPGetXPos();
        [DllImport("LatiteCore.dll")]
        static extern float LPGetYPos();
        [DllImport("LatiteCore.dll")]
        static extern float LPGetZPos();

        [DllImport("LatiteCore.dll")]
        static extern float LPGetMotion();

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

        public void TransparentPanels(bool b)
        {
            if (b)
            {
                posPanel.BackColor = Color.Transparent;
            } else
            {
                posPanel.BackColor = Color.FromArgb(50, 60, 70);
            }
        }

        private void secondRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                // CPS counter
                // todo not proper cps counter
                LMBCounter.Text = lcps + " CPS";
                RMBCounter.Text = rcps + " CPS";
                lcps = 0;
                rcps = 0;
            }
        }

        public void SetOpacity(double Opacity)
        {
            this.Opacity = Opacity;
        }

        public void ToggleSprint(int val)
        {
            if (val == 1)
            {
                toggleSprintLabel.Text = "[Sprinting (Toggled)]";
            }
            else if (val == 0)
            {
                toggleSprintLabel.Text = "";
            } 
            else if (val == 2)
            {
                latiteForm.Coutln("Sprinting key held");
                toggleSprintLabel.Text = "[Sprinting (Key Held)]";
            }
        }
        public Overlay(LatiteForm latiteForm)
        {
            this.latiteForm = latiteForm;
            this.dragUtils = new DragUtils(this);
            InitializeComponent();
        }

        private void keystrokesPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsEditing) return;
            dragUtils.StartDrag(e);
        }

        private void keystrokesPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsEditing) return;
            dragUtils.DragProc(keystrokesPanel, e);
        }

        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save data
        }

        public void SetGuiDisplay(uint gui, bool display)
        {
            switch(gui)
            {
                case 0:
                    posPanel.Visible = display;
                    break;
            }
        }

        string OldSprintText = "";

        // Key Held
        int kh = 0x8000;

        public bool IsEditing = false;
        public void SetDraggableItems(bool Draggable)
        {
            if (Draggable)
            {
                SetWindowLong(this.Handle, -20, OldStyle);
                OldSprintText = toggleSprintLabel.Text;
                toggleSprintLabel.Text = "[Sprinting (Editing)]";
            } else
            {
                SetWindowLong(this.Handle, -20, OldStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
                toggleSprintLabel.Text = OldSprintText;
            }
            IsEditing = !IsEditing;
        }
        
        public static readonly Point nullpoint = new Point(0, 0);
        public static readonly AnchorStyles nullanchor = (AnchorStyles)(-1);

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.90;
            this.KeyPreview = true;

            // cause transparency
            this.BackColor = Color.FromArgb(0, 0, 31);

            // remove borders / minimize etc
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true; // appear ontop of other apps, needed for mc

            // able to click on mc
            this.OldStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, OldStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
            // run constant running loop asynch so it matches mc window without freezing
            backgroundWorker1.RunWorkerAsync();
            secondRunner.RunWorkerAsync();

            this.toggleSprintLabel.Text = "";
        }

        private void UpdateKeystrokes()
        {
            
            int[] NotPressedColor = { 50, 60, 70 };
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
            else Keystrokes_LMB.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);

            if (RMB_Pressed) Keystrokes_RMB.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            else Keystrokes_RMB.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            
            if (Space_Pressed) spaceBarPanel.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            else spaceBarPanel.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
            //MessageBox.Show("Updated kEystrokes");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(8); // Cooldown
                if (LatiteForm.connectedToMinecraft())
                {
                    xPosLabel.Text = Math.Round(LPGetXPos(), 2) + "";
                    yPosLabel.Text = Math.Round(LPGetYPos(), 2) + "";
                    zPosLabel.Text = Math.Round(LPGetZPos(), 2) + "";
                    motionLabel.Text = Math.Round(LPGetMotion(), 3) + "";
                    motionYLabel.Text = Math.Round(LPGetYMotion(), 3) + "";
                }

                if (GetForegroundWindow() != hWnd)
                {
                    IntPtr hWnd = FindWindowA(null, "Minecraft");
                    if (hWnd == (IntPtr)0)
                    {
                        this.latiteForm.DisconnectFromMc();
                    }
                    this.TopMost = false;
                } else
                {
                    this.TopMost = true;
                }
                W_Pressed = ((GetKeyState((int)'W') & kh) == kh);
                A_Pressed = ((GetKeyState((int)'A') & kh) == kh);
                S_Pressed = ((GetKeyState((int)'S') & kh) == kh);
                D_Pressed = ((GetKeyState((int)'D') & kh) == kh);
                Space_Pressed = ((GetKeyState(0x20) & kh) == kh);

                if ((GetKeyState(0x01) & kh) == kh) {
                    if (!LMB_Pressed) { lcps++; };
                    LMB_Pressed = true;
                }
                else LMB_Pressed = false;

                if ((GetKeyState(0x02) & kh) == kh)
                {
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

    }
}
