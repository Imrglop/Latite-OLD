/*
 * 
 * Latite - A minecraft: Windows 10 Edition PVP mod.
 * Copyright (c) 2021 Imrglop
 * 
*/

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

        // Config
        /*
         * LATITE_API void settingsConfigSet(cstring k, cstring v);
	        LATITE_API cstring settingsConfigGet(cstring k);
         */

        [DllImport("LatiteCore.dll")]
        static extern void settingsConfigSet(string k, string v);

        /*[DllImport("LatiteCore.dll")]
        static extern void settingsConfigGet(string k, out StringBuilder lpLpWString);*/

        public LatiteForm()
        {
            InitializeComponent();
        }

        private Overlay OverlayForm;

        readonly string[] Commands = { "help", "info", "print <text>", "clear", "connect", "disconnect" };
        readonly string Info = "Latite Client\r\n\r\nLicense: GPLv3\r\n\r\nSource: github.com/Imrglop/Latite\r\n\r\nMade by Imrglop";
        private bool IsConsole = false;
        bool ToggleSprintBindOn = false;
        char ToggleSprintBind = (char)0xA2; // Left CTRL

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
                var Result = MessageBox.Show("Could not connect! You may be missing LatiteCore.dll.\nPlease also make sure you have Microsoft Visual C++ 2019 installed.\nPress retry to download VC redist 2019 and that could fix the issue.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                Coutln("DllNotFoundException occured while attempting to import LatiteCore.dll, or any of the dependancies!\nPlease make sure you have Microsoft Visual C++ 2019 installed.");
                Coutln("Error: " + e.ToString());
                if (Result == DialogResult.Retry)
                {
                    System.Diagnostics.Process.Start("https://aka.ms/vs/16/release/vc_redist.x64.exe");
                }
                if (show == false)
                {
                    Close();
                    Environment.Exit(1);
                }
            } catch (Exception e)
            {
                var Result = MessageBox.Show("Couldn't import DLL LatiteCore.dll! An unexpected error occured. Details:\n\n" + e.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                Coutln("Error: " + e.ToString());
                if (Result == DialogResult.Retry)
                {
                    ConnectToMc();
                } else
                {
                    this.Close();
                    Environment.Exit(1); // EXIT_FAILURE
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
                    try
                    {
                        if (!this.OverlayForm.IsDisposed) this.OverlayForm.BeginInvoke(new MethodInvoker(this.OverlayForm.Close));
                    }
                    catch (Exception) { };
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
        void ToggleSprint(int _Val)
        {
            bool Val = _Val == 1;
            if (_Val < 2)
            {
                //this.toggleSprintCheckbox.Checked = Val;
                setEnabled(3, Val);
            }
            this.OverlayForm.ToggleSprint(_Val);
        }

        public bool FocusedOnMinecraft()
        {
            return Overlay.GetForegroundWindow() == Overlay.FindWindowA(null, "Minecraft");
        }

        private void moduleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (moduleWorker.CancellationPending) break;
                loop();
                if (toggleSprintCheckbox.Checked)
                {   
                    if ((Overlay.GetKeyState((int)ToggleSprintBind) & 1) != 0 && !this.ToggleSprintBindOn)
                    {
                        if (FocusedOnMinecraft()) this.ToggleSprint(1);
                        ToggleSprintBindOn = true;
                    }
                    else if ((Overlay.GetKeyState((int)ToggleSprintBind) & 1) == 0 && this.ToggleSprintBindOn)
                    {
                        if (FocusedOnMinecraft()) this.ToggleSprint(0);
                        ToggleSprintBindOn = false;
                    }
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
            //this.ToggleSprint(toggleSprintCheckbox.Checked ? 1:0);
        }

        public char StringToBind(string s)
        {
            string SetStr = s.ToUpper();
            if (SetStr.ToLower() == "lctrl") return (char)0xA2;
            else if (SetStr.ToLower() == "lshift") return (char)0xA0;
            else if (SetStr.ToLower() == "enter" || SetStr.ToLower() == "return") return '\r';
            else if (SetStr.ToLower() == "shift") return (char)0x10;
            else if (SetStr.ToLower() == "ctrl") return (char)0x11;
            if (SetStr.Length > 0) return SetStr[0];
            return '\0';
        }

        private void toggleSprintBind_TextChanged(object sender, EventArgs e)
        {
            ToggleSprintBind = StringToBind(toggleSprintBind.Text);
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

        bool ToggleEditing = true;

        private void toggleEditingButton_Click(object sender, EventArgs e)
        {
            this.OverlayForm.SetDraggableItems(ToggleEditing);
            this.toggleEditingButton.FlatAppearance.BorderColor = (ToggleEditing ? Color.Aqua : Color.Gray);
            ToggleEditing = !ToggleEditing;
        }
    }
}
