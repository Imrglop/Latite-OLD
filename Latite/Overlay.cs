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

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public static IntPtr hWnd = FindWindowA(null, "Minecraft"); // find minecraft 
        public static RECT rect;
        [DllImport("LatiteCore.dll")]
        public static extern IntPtr LPGetLookAtBlock();


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

        readonly string ToggleSprintTextOn = "[Sprinting (Toggled)]";
        public void ToggleSprint(int val)
        {
            if (LatiteForm.getCurrentGui() != 0) return;
            if (val == 1)
            {
                toggleSprintLabel.Text = ToggleSprintTextOn;
            }
            else if (val == 0)
            {
                toggleSprintLabel.Text = "";
            } 
            else if (val == 2)
            {
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
                    keystrokesPanel.Visible = display;
                    break;
                case 1:
                    posPanel.Visible = display;
                    break;
                case 2:
                    blockDisplayText.Visible = display;
                    break;
            }
        }

        string OldSprintText = "";
        // Key Held
        int kh = 0x8000;
        public char EditingBind = (char)0xA1;

        private void posPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragUtils.StartDrag(e);
        }

        private void posPanel_MouseMove(object sender, MouseEventArgs e)
        {
            dragUtils.DragProc(posPanel, e);
        }

        private void toggleSprintLabel_MouseDown(object sender, MouseEventArgs e)
        {
            dragUtils.StartDrag(e);
        }

        private void toggleSprintLabel_MouseMove(object sender, MouseEventArgs e)
        {
            dragUtils.DragProc(toggleSprintLabel, e);
        }

        public bool IsEditing = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            settingsTabControl.Visible = settingsCheckBox.Checked;
        }

        private void keystrokesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetGuiDisplay(0, keystrokesCheckBox.Checked);
        }

        private void posDisplayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetGuiDisplay(1, posDisplayCheckbox.Checked);
        }

        public void SetDraggableItems(bool Draggable)
        {
            if (Draggable)
            {
                SetWindowLong(this.Handle, -20, OldStyle);
                OldSprintText = toggleSprintLabel.Text;
                settingsCheckBox.Visible = true;
                settingsCheckBox.Checked = false;
                toggleSprintLabel.Text = "[Sprinting (Editing)]";
            } else
            {
                settingsTabControl.Visible = false;
                settingsCheckBox.Visible = false;
                SetWindowLong(this.Handle, -20, OldStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
                toggleSprintLabel.Text = OldSprintText;
            }
            IsEditing = !IsEditing;
        }
        private void UpdateTextColorK()
        {
            int[] ColorSet = { keystrokesRedTrackbar.Value * 4, keystrokesGreenTrackbar.Value * 4, keystrokesBlueTrackbar.Value * 4 };
            for (int i = 0; i < ColorSet.Length; i++)
            {
                if (ColorSet[i] > 0xFF)
                {
                    ColorSet[i] = 0xFF;
                }
            }
            foreach (Control parentControl in keystrokesPanel.Controls)
            {
                if (parentControl is Panel)
                {
                    foreach (Control control in parentControl.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;
                            label.ForeColor = Color.FromArgb(ColorSet[0], ColorSet[1], ColorSet[2]);
                        } else if (control is PictureBox)
                        {
                            PictureBox picture = (PictureBox)control;
                            picture.BackColor = Color.FromArgb(ColorSet[0], ColorSet[1], ColorSet[2]);
                        }
                    }
                }
            }
        }
        private void keystrokesRedTrackbar_Scroll(object sender, EventArgs e)
        {
            UpdateTextColorK();
        }

        private void keystrokesGreenTrackbar_Scroll(object sender, EventArgs e)
        {
            UpdateTextColorK();
        }

        private void blockCoordsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetGuiDisplay(2, blockCoordsCheckbox.Checked);
        }

        private void blockDisplayText_MouseDown(object sender, MouseEventArgs e)
        {
            dragUtils.StartDrag(e);
        }

        private void blockDisplayText_MouseMove(object sender, MouseEventArgs e)
        {
            dragUtils.DragProc(blockDisplayText, e);
        }

        private void keystrokesBlueTrackbar_Scroll(object sender, EventArgs e)
        {
            UpdateTextColorK();
        }

        private void copyBlockButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join(" ", GetBlockCoords()));
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
            settingsCheckBox.Visible = false;
            settingsTabControl.Visible = false;
            blockDisplayText.Visible = false;
        }

        private void UpdateKeystrokes()
        {
            
            int[] NotPressedColor = { 50, 60, 70 };
            int[] PressedColor = { NotPressedColor[0] + 10, NotPressedColor[1] + 10, NotPressedColor[2] + 10 };
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

        public void SetGuisVisible(bool val)
        {
            if (keystrokesCheckBox.Checked)
            {
                SetGuiDisplay(0, val);
            }
            if (posDisplayCheckbox.Checked)
            {
                SetGuiDisplay(1, val);
            }
            if (blockCoordsCheckbox.Checked)
            {
                if (!val && LatiteForm.getCurrentGui() == 4) return;
                SetGuiDisplay(2, val);
            }
            if (!val && !IsEditing)
            {
                OldSprintText = toggleSprintLabel.Text;
                toggleSprintLabel.Text = "";
            }
            else if (!IsEditing)
            {
                toggleSprintLabel.Text = (latiteForm.IsToggleSprint) ? this.ToggleSprintTextOn : "";
            }
        }
        public int[] GetBlockCoords()
        {
            IntPtr ptr = LPGetLookAtBlock();
            int[] coords = new int[3];
            Marshal.Copy(ptr, coords, 0, 3);
            return coords;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10); // Cooldown
                if (!IsEditing && LatiteForm.getCurrentGui() != 0) SetGuisVisible(false);
                if (IsEditing || LatiteForm.getCurrentGui() == 0) SetGuisVisible(true);

                if (this.latiteForm.FocusedOnMinecraft() || GetForegroundWindow() == this.Handle)
                {

                    if ((GetAsyncKeyState(EditingBind) & 1) != 0) // rshift
                    {
                        this.latiteForm.toggleEditing();
                        SetForegroundWindow(this.Handle);
                    }
                }
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

                if (this.blockDisplayText.Visible)
                {
                    this.blockDisplayText.Text = string.Join(", ", GetBlockCoords());
                }
            }
        }

    }
}
