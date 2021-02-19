using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Latite
{
    // overlay for minecraft needed for Latite
    public partial class Overlay : Form
    {
        bool[] KeysPressed = new bool[7];
        int lcps, rcps = 0;
        private int OldStyle = 0;

        LatiteForm latiteForm;
        DragUtils dragUtils;
        public bool LoadedGuiPositions = false;

        public static IntPtr hWnd = User32.FindWindowA(null, "Minecraft"); // find minecraft 

        private void secondRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (secondRunner.CancellationPending) break;
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
            if (LatiteCore.getCurrentGui() != 0) return;
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
            dragUtils.StartDrag(e, this.LoadedGuiPositions);
        }

        private void keystrokesPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsEditing) return;
            dragUtils.DragProc(keystrokesPanel, e);
        }

        public void SaveData()
        {
            // save data
            Data.Keystrokes.Enabled = keystrokesCheckBox.Checked;
            Data.PosDisplay.Enabled = posDisplayCheckbox.Checked;
            Data.BlockPosDisplay.Enabled = blockCoordsCheckbox.Checked;

            if (LoadedGuiPositions)
            {
                Data.Keystrokes.Position[0] = keystrokesPanel.Location.X;
                Data.Keystrokes.Position[1] = keystrokesPanel.Location.Y;
                Data.Keystrokes.Anchor = (int)keystrokesPanel.Anchor;
                Data.PosDisplay.Position[0] = posPanel.Location.X;
                Data.PosDisplay.Position[1] = posPanel.Location.Y;
                Data.PosDisplay.Anchor = (int)posPanel.Anchor;
                Data.BlockPosDisplay.Position[0] = blockDisplayText.Location.X;
                Data.BlockPosDisplay.Position[1] = blockDisplayText.Location.Y;
                Data.BlockPosDisplay.Anchor = (int)blockDisplayText.Anchor;
                Data.ToggleSprint.Position[0] = toggleSprintLabel.Left;
                Data.ToggleSprint.Position[1] = toggleSprintLabel.Location.Y;
                Data.ToggleSprint.Anchor = (int)toggleSprintLabel.Anchor;
            }

            Data.Save();
        }

        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void SetGuiDisplay(uint gui, bool display, int anchor = -1, int[] position = null)
        {
            Control control = null;
            switch(gui)
            {
                case 0:
                    control = keystrokesPanel;
                    break;
                case 1:
                    control = posPanel;
                    break;
                case 2:
                    control = blockDisplayText;
                    break;
                case 3:
                    control = toggleSprintLabel;
                    break;
            }
            if (control != null)
            {
                control.Visible = display;
                control.Anchor = (anchor != -1) ? (AnchorStyles)anchor : control.Anchor;
                if (position != null)
                {
                    control.Location = new Point(position[0], position[1]);
                }
            }
        }

        string OldSprintText = "";
        // Key Held
        int kh = 0x8000;
        public char EditingBind = (char)0xA1;

        private void posPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragUtils.StartDrag(e, this.LoadedGuiPositions);
        }

        private void posPanel_MouseMove(object sender, MouseEventArgs e)
        {
            dragUtils.DragProc(posPanel, e);
        }

        private void toggleSprintLabel_MouseDown(object sender, MouseEventArgs e)
        {
            dragUtils.StartDrag(e, this.LoadedGuiPositions);
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
                IsEditing = true;
                User32.SetWindowLong(this.Handle, -20, OldStyle);
                OldSprintText = toggleSprintLabel.Text;
                settingsCheckBox.Visible = true;
                settingsCheckBox.Checked = false;
                toggleSprintLabel.Text = "[Sprinting (Editing)]";
            } else
            {
                IsEditing = false;
                settingsTabControl.Visible = false;
                settingsCheckBox.Visible = false;
                User32.SetWindowLong(this.Handle, -20, OldStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
                toggleSprintLabel.Text = OldSprintText;
            }
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
                Data.Keystrokes.RGB[i] = (byte)ColorSet[i];
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
            dragUtils.StartDrag(e, this.LoadedGuiPositions);
        }

        private void blockDisplayText_MouseMove(object sender, MouseEventArgs e)
        {
            dragUtils.DragProc(blockDisplayText, e);
        }

        private void keystrokesBlueTrackbar_Scroll(object sender, EventArgs e)
        {
            UpdateTextColorK();
        }

        public void LoadGuiPos()
        {
            this.keystrokesPanel.Anchor = AnchorStyles.None;
            keystrokesPanel.Location = new Point(Data.Keystrokes.Position[0],
                    Data.Keystrokes.Position[1]);
            this.keystrokesPanel.Anchor = (AnchorStyles)Data.Keystrokes.Anchor;

            this.posPanel.Anchor = AnchorStyles.None;
            this.posPanel.Location = new Point(Data.PosDisplay.Position[0], Data.PosDisplay.Position[1]);
            this.posPanel.Anchor = (AnchorStyles)Data.PosDisplay.Anchor;
            
            this.blockDisplayText.Anchor = AnchorStyles.None;
            this.blockDisplayText.Location = new Point(Data.BlockPosDisplay.Position[0], Data.BlockPosDisplay.Position[1]);
            this.blockDisplayText.Anchor = (AnchorStyles)Data.BlockPosDisplay.Anchor;

            this.toggleSprintLabel.Anchor = AnchorStyles.None;
            this.toggleSprintLabel.Location = new Point(Data.ToggleSprint.Position[0], Data.ToggleSprint.Position[1]);
            this.toggleSprintLabel.Anchor = (AnchorStyles)Data.ToggleSprint.Anchor;

            LoadedGuiPositions = true;
        }

        public void OnDataInit()
        {
            // restore saved settings
            this.keystrokesCheckBox.Checked = Data.Keystrokes.Enabled;

            keystrokesRedTrackbar.Value = Data.Keystrokes.RGB[0] / 4;
            keystrokesGreenTrackbar.Value = Data.Keystrokes.RGB[1] / 4;
            keystrokesBlueTrackbar.Value = Data.Keystrokes.RGB[2] / 4;
            UpdateTextColorK();

            this.blockCoordsCheckbox.Checked = Data.BlockPosDisplay.Enabled;
            this.blockDisplayText.Visible = Data.BlockPosDisplay.Enabled;
        }

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
            this.OldStyle = User32.GetWindowLong(this.Handle, -20);
            User32.SetWindowLong(this.Handle, -20, OldStyle | 0x8000 /*WS_EX_LAYERED*/ | 0x20 /* WS_EX_TRANSPARENT*/);
            // run constant running loop asynch so it matches mc window without freezing
            backgroundWorker1.RunWorkerAsync();
            secondRunner.RunWorkerAsync();

            this.toggleSprintLabel.Text = "";
            settingsCheckBox.Visible = false;
            settingsTabControl.Visible = false;
        }

        private void ProcKeystroke(Panel panel, int Key)
        {
            int[] NotPressedColor = { 50, 60, 70 };
            int[] PressedColor = { NotPressedColor[0] + 10, NotPressedColor[1] + 10, NotPressedColor[2] + 10 };

            if (KeysPressed[Key]) panel.BackColor = Color.FromArgb(PressedColor[0], PressedColor[1], PressedColor[2]);
            else panel.BackColor = Color.FromArgb(NotPressedColor[0], NotPressedColor[1], NotPressedColor[2]);
        }

        private void UpdateKeystrokes()
        {
            ProcKeystroke(keyStrokes_W, 0);
            ProcKeystroke(keyStrokes_A, 1);
            ProcKeystroke(keyStrokes_S, 2);
            ProcKeystroke(keyStrokes_D, 3);

            ProcKeystroke(Keystrokes_LMB, 4);
            ProcKeystroke(Keystrokes_RMB, 5);

            ProcKeystroke(spaceBarPanel, 6);
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
                if (chatBlockCheckbox.Checked)
                {
                    if (!val && LatiteCore.getCurrentGui() == 4) return;
                }
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
            IntPtr ptr = LatiteCore.LocalPlayer.GetLookAtBlock();
            int[] coords = new int[3];
            Marshal.Copy(ptr, coords, 0, 3);
            return coords;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10); // Cooldown
                if (!IsEditing && LatiteCore.getCurrentGui() != 0) SetGuisVisible(false);
                if (IsEditing || LatiteCore.getCurrentGui() == 0) SetGuisVisible(true);

                if (this.latiteForm.FocusedOnMinecraft() || User32.GetForegroundWindow() == this.Handle)
                {

                    if ((LatiteCore.getCurrentGui() != 4) && (User32.GetAsyncKeyState(EditingBind) & 1) != 0) // rshift
                    {
                        this.latiteForm.toggleEditing();
                        User32.SetForegroundWindow(this.Handle);
                    }
                }
                if (LatiteCore.connectedToMinecraft())
                {
                    xPosLabel.Text = Math.Round(LatiteCore.LocalPlayer.GetXPos(), 2) + "";
                    yPosLabel.Text = Math.Round(LatiteCore.LocalPlayer.GetYPos(), 2) + "";
                    zPosLabel.Text = Math.Round(LatiteCore.LocalPlayer.GetZPos(), 2) + "";
                    motionLabel.Text = Math.Round(LatiteCore.LocalPlayer.GetMotion(), 3) + "";
                    motionYLabel.Text = Math.Round(LatiteCore.LocalPlayer.GetYMotion(), 3) + "";
                }

                if (User32.GetForegroundWindow() != hWnd)
                {
                    IntPtr hWnd = User32.FindWindowA(null, "Minecraft");
                    if (hWnd == (IntPtr)0)
                    {
                        this.latiteForm.DisconnectFromMc();
                    }
                    this.TopMost = false;
                } else
                {
                    this.TopMost = true;
                }
                KeysPressed[0] = ((User32.GetKeyState((int)'W') & kh) == kh);
                KeysPressed[1] = ((User32.GetKeyState((int)'A') & kh) == kh);
                KeysPressed[2] = ((User32.GetKeyState((int)'S') & kh) == kh);
                KeysPressed[3] = ((User32.GetKeyState((int)'D') & kh) == kh);
                
                KeysPressed[6] = ((User32.GetKeyState(0x20) & kh) == kh); // Space Bar

                if ((User32.GetKeyState(0x01) & kh) == kh) {
                    if (!KeysPressed[4]) { lcps++; };
                    KeysPressed[4] = true; // LMB
                }
                else KeysPressed[4] = false;

                if ((User32.GetKeyState(0x02) & kh) == kh)
                {
                    if (!KeysPressed[5]) rcps++;
                    KeysPressed[5] = true; // RMB
                }
                else KeysPressed[5] = false;
                UpdateKeystrokes();
                User32.GetWindowRect(hWnd, out User32.rect);
                this.Size = new Size(User32.rect.right - User32.rect.left,
                    User32.rect.bottom - User32.rect.top);

                // Set the position of the form
                this.Left = User32.rect.left;
                this.Top = User32.rect.top;

                if (this.blockDisplayText.Visible)
                {
                    this.blockDisplayText.Text = string.Join(", ", GetBlockCoords());
                }
            }
        }
    }
}
