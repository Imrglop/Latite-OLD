﻿// Latite Client
// by Imrglop

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Latite
{
    public partial class LatiteForm : Form
    {
        [DllImport("LatiteCore.dll")]
        static extern void setEnabled(uint modId, bool enabled);
        [DllImport("LatiteCore.dll")]
        static extern void consoleMain();
        [DllImport("LatiteCore.dll")]
        static extern ulong attach();
        // extern "C" LATITE_API bool connectedToMinecraft(int type = 2);
        [DllImport("LatiteCore.dll")]
        public static extern bool connectedToMinecraft(int type = 2);
        [DllImport("LatiteCore.dll")]
        static extern void detach();
        [DllImport("LatiteCore.dll")]
        static extern void loop();
        /*
         * 
extern "C" LATITE_API void mod_zoom_setBind(char bind);
extern "C" LATITE_API void mod_zoom_setAmount(float amount);
         */
        [DllImport("LatiteCore.dll")]
        static extern void mod_zoom_setBind(char bind);
        [DllImport("LatiteCore.dll")]
        static extern void mod_zoom_setAmount(float amount);
        [DllImport("LatiteCore.dll")]
        static extern void mod_lookBehind_setBind(char bind);
        [DllImport("LatiteCore.dll")]
        static extern void setTimeChangerSetting(int setting);
        public LatiteForm()
        {
            InitializeComponent();
        }

        private Overlay OverlayForm;

        readonly string[] Commands = { "help", "info", "print <text>", "clear", "connect", "disconnect" };
        readonly string Info = "Latite Client\r\n\r\nLicense: GPLv3\r\n\r\nSource: github.com/Imrglop/Latite\r\n\r\nMade by Imrglop";
        private bool IsConsole = false;
        bool ToggleSprintBindOn = false;
        char ToggleSprintBind = 'P';

        public void Cout(string OutputString)
        {
            consoleOutput.Text += OutputString;
        }
        public void Coutln(string OutputString)
        {
            consoleOutput.Text += (OutputString + "\r\n");
        }

        private void ConnectToMc(bool show = true)
        {
            try
            {
                if (!connectedToMinecraft())
                {
                    if (!IsConsole && settingsUseConsole.Checked)
                    {
                        consoleMain();
                        IsConsole = true;
                    }
                    var Status = attach();
                    if (Status == 0)
                    {
                        connectButton.Visible = false;
                        connectedToMinecraft(1); // true
                        connectedLabel.Visible = true;
                        // have to put 1 cuz C#
                        moduleWorker.RunWorkerAsync();
                        disconnectButton.Visible = true;
                        Coutln("Connected to Minecraft!");
                        this.OverlayForm = new Overlay(this);
                        this.OverlayForm.Show();
                        if (show)
                            MessageBox.Show("Connected to Minecraft!");
                    }
                    else
                    {
                        if (show)
                        {
                            Coutln("Couldn't connect to Minecraft! Error code: " + Status.ToString());
                            var Result = MessageBox.Show("Could not connect to Minecraft! Error Code: " + Status.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                            if (Result == DialogResult.Retry)
                            {
                                ConnectToMc();
                            }
                        }
                    }
                }
            } catch (DllNotFoundException e)
            {
                var Result = MessageBox.Show("Could not connect! You may be missing LatiteCore.dll.\nPlease make sure you have Microsoft Visual C++ 2019 installed.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                Coutln("DllNotFoundException occured while attempting to import LatiteCore.dll, or any of the dependancies!\nPlease make sure you have Microsoft Visual C++ 2019 installed.");
                Coutln("Error: " + e.ToString());
                if (Result == DialogResult.Retry)
                {
                    ConnectToMc();
                }
            }
        }

        public void DisconnectFromMc()
        {
            if (connectedToMinecraft())
            {
                if (moduleWorker.IsBusy)
                {
                    moduleWorker.CancelAsync();
                }
                disconnectButton.Visible = false;
                connectButton.Visible = true;
                connectedToMinecraft(0); // false
                connectedLabel.Visible = false;
                detach();
                if (this.OverlayForm.Handle != IntPtr.Zero && this.Handle != IntPtr.Zero)
                {
                    if (!this.OverlayForm.IsDisposed) this.OverlayForm.BeginInvoke(new MethodInvoker(this.OverlayForm.Close));

                }
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectToMc();
        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DispatchCommand(consoleInput.Text);
            }
        }

        private char GetBind(string Str)
        {
            return Str.ToUpper()[0];
        }

        private void DispatchCommand(string Command)
        {
            Coutln("> " + Command);
            string[] Args = Command.Split(' ');
            if (Args.Length == 0) return;
            string Label = Args[0].ToLower();
            Args = Args.Skip(1).ToArray();
            switch(Label)
            {
                case "help":
                    Cout("Commands: ");
                    Coutln(string.Join(", ", Commands));
                    break;
                case "print":
                    Coutln(string.Join(" ", Args));
                    break;
                case "clear":
                    consoleOutput.Clear();
                    break;
                case "connect":
                    ConnectToMc();
                    break;
                case "info":
                    Coutln(Info);
                    break;
                case "disconnect":
                    DisconnectFromMc();
                    Coutln("Disconnected!");
                    break;
                default:
                    Coutln("Error: unknown command \"" + Label + "\"");
                    break;
            }
        }

        private void cinGo_Click(object sender, EventArgs e)
        {
            DispatchCommand(consoleInput.Text);
        }

        private void DRPButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/DfYUSJspcn");
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            modsControl.SelectedTab = optionsTabControl;
        }

        private void modsButton_Click(object sender, EventArgs e)
        {
            modsControl.SelectedTab = modsTabPage;
        }

        private void consoleButton_Click(object sender, EventArgs e)
        {
            modsControl.SelectedTab = consoleTab;
        }

        private void zaSlider_Scroll(object sender, EventArgs e)
        {
            var FOVAmount = (zaSlider.Value + 2) * 5;
            zaSliderLabel.Text = $"Amount ({FOVAmount})";
            mod_zoom_setAmount(FOVAmount);
            Coutln("try set amt to " + FOVAmount);
        }
        void ToggleSprint(bool Val)
        {
            this.toggleSprintCheckbox.Checked = Val;
            this.OverlayForm.ToggleSprint(Val);
            setEnabled(3, Val);
        }

        public bool FocusedOnMinecraft()
        {
            return Overlay.GetForegroundWindow() == Overlay.FindWindowA(null, "Minecraft");
        }

        private void moduleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                loop();
                if (moduleWorker.CancellationPending) break;
                if ((Overlay.GetKeyState(ToggleSprintBind) & 1) != 0 && !this.ToggleSprintBindOn)
                {
                    if (FocusedOnMinecraft()) this.ToggleSprint(true);
                    ToggleSprintBindOn = true;
                }
                else if ((Overlay.GetKeyState(ToggleSprintBind) & 1) == 0 && this.ToggleSprintBindOn)
                {
                    if (FocusedOnMinecraft()) this.ToggleSprint(false);
                    ToggleSprintBindOn = false;
                }
                Thread.Sleep(50);
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromMc();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectFromMc();
        }

        private void zoomBindBox_TextChanged(object sender, EventArgs e)
        {
            string SetStr = zoomBindBox.Text.ToUpper();
            if (SetStr.Length > 0)
                mod_zoom_setBind(SetStr[0]);
        }

        private void LatiteForm_Load(object sender, EventArgs e)
        {
            ConnectToMc(false); // silently connect on launch
        }

        private void transparentOverlayToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (connectedToMinecraft())
                this.OverlayForm.TransparentPanels(transparentOverlayToggle.Checked); ;
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("minecraft://");
        }

        private void zoomCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            setEnabled(1, zoomCheckbox.Checked);
        }

        private void lookBehindEnabled_CheckedChanged(object sender, EventArgs e)
        {
            setEnabled(2, lookBehindEnabled.Checked);
        }

        private void lookBehindBind_TextChanged(object sender, EventArgs e)
        {
            string SetStr = zoomBindBox.Text.ToUpper();
            if (SetStr.Length > 0)
                mod_lookBehind_setBind(SetStr[0]);
        }

        private void opacitySlider_Scroll(object sender, EventArgs e)
        {
            if (!connectedToMinecraft()) return;
            double val = opacitySlider.Value * 4;
            opacityDisplayLabel.Text = (opacitySlider.Value * 4) + "";
            this.OverlayForm.SetOpacity(val / 100);
        }

        private void toggleSprintCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleSprint(toggleSprintCheckbox.Checked);
        }

        private void toggleSprintBind_TextChanged(object sender, EventArgs e)
        {
            string SetStr = zoomBindBox.Text.ToUpper();
            if (SetStr.Length > 0) ToggleSprintBind = SetStr[0];
        }

        private void UpdateGUIPositions()
        {
            if (!connectedToMinecraft()) return;
            if (rbTopLeftKeystrokes.Checked)
            {
                this.OverlayForm.UpdatePanelPos(0);
            } else if (rbTopRightKeystrokes.Checked)
            {
                this.OverlayForm.UpdatePanelPos(1);
            }
        }

        private void rbTopLeftKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGUIPositions();
        }

        private void rbTopRightKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGUIPositions();
        }

        private void rbBottomRightKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGUIPositions();
        }

        private void rbBottomLeftKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGUIPositions();
        }

        private void posDisplayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (connectedToMinecraft())
                this.OverlayForm.SetGuiDisplay(0, posDisplayCheck.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int Val = timeChangerTrackBar.Value * 2500;
            setTimeChangerSetting(Val);
            if (connectedToMinecraft())
                setEnabled(4, checkBox1.Checked);
        }

        private void timeChangerTrackBar_Scroll(object sender, EventArgs e)
        {
            int Val = timeChangerTrackBar.Value * 2500;
            timeChangerTrackBarLabel.Text = Val + "";
        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Imrglop/Latite");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Imrglop/Latite/releases/latest");
        }
    }
}
