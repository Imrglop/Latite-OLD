/*
 * 
 * Latite - A minecraft: Windows 10 Edition PVP mod.
 * Copyright (c) 2021 Imrglop
 * 
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Latite
{
    public partial class LatiteForm : Form
    {
        public LatiteForm()
        {
            InitializeComponent();
        }

        private Overlay OverlayForm;

        readonly string[] Commands = { "help", "info", "print <text>", "clear", "connect", "disconnect" };
        readonly string Info = "Latite Client\r\n\r\nLicense: GPLv3\r\n\r\nSource: github.com/Imrglop/Latite\r\n\r\nMade by Imrglop";
        public bool ToggleSprintBindOn = false;
        char ToggleSprintBind = (char)0xA2; // Left CTRL

        public void Cout(string OutputString)
        {
            consoleOutput.Text += OutputString;
            Console.Write(OutputString);
        }
        public void Coutln(string OutputString)
        {
            consoleOutput.Text += (OutputString + "\r\n");
            Console.WriteLine(OutputString);
        }
        void DynamicUpdateData()
        {
            zaSlider_ValueChanged();
            zoomCheckbox_CheckedChanged();
            toggleSprintCheckbox_CheckedChanged();
            lookBehindBind_TextChanged();
            lookBehindEnabled_CheckedChanged();
            fullbrightCheckBox_CheckedChanged();
            timeChanger_CheckedChanged();
        }
        private void DataInit()
        {
            bool ConfigLoaded = Data.Load();
            if (ConfigLoaded)
            {
                zoomCheckbox.Checked = Data.Zoom.Enabled;

                zoomBindBox.Text = BindToString(Data.Zoom.Bind);
                zaSlider.Value = (int)Data.Zoom.Amount;

                toggleSprintCheckbox.Checked = Data.ToggleSprint.Enabled;
                toggleSprintBind.Text = BindToString(Data.ToggleSprint.Bind);
                
                fullbrightCheckBox.Checked = Data.Fullbright.Enabled;

                lookBehindBind.Text = BindToString(Data.LookBehind.Bind);
                lookBehindEnabled.Checked = Data.LookBehind.Enabled;

                //timeChangerTrackBar.Value = Data.TimeChanger.TimeOfDay;
                timeChangerCheckBox.Checked = Data.TimeChanger.Enabled;

                opacitySlider.Value = Data.Options.Opacity;

                DynamicUpdateData();
            }
            else
            {
                // First time loaded
                Coutln("First Time Using (detected)");
                Data.Save(true);
            }
        }

        private void ConnectToMc(bool show = true)
        {
            try
            {
                if (!LatiteCore.connectedToMinecraft())
                {
                    uint Status = 0;
                    try
                    {
                        Status = LatiteCore.attach();
                    } catch (Exception e)
                    {
                        var Result = MessageBox.Show("Couldn't attach to Minecraft!\n\n" + e.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                        if (Result == DialogResult.Retry)
                        {
                            ConnectToMc();
                        } else
                        {
                            Environment.Exit(1);
                        }
                    }
                    if (Status == 0)
                    {
                        connectButton.Visible = false;
                        LatiteCore.connectedToMinecraft(1); // true
                        connectedLabel.Visible = true;
                        moduleWorker.RunWorkerAsync();
                        disconnectButton.Visible = true;
                        Coutln("Connected to Minecraft!");
                        this.OverlayForm = new Overlay(this);
                        this.OverlayForm.Show();
                        DataInit();
                        this.OverlayForm.OnDataInit();
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
                var Result = MessageBox.Show("Could not connect! You may be missing LatiteCore.dll.\nPlease also make sure you have Microsoft Visual C++ 2019 installed and Silver.dll.\nPress retry to download VC redist 2019 and that could fix the issue.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                Coutln("DllNotFoundException occured while attempting to import LatiteCore.dll, or any of the dependancies!\nPlease make sure you have Microsoft Visual C++ 2019 installed.");
                Coutln("Error: " + e.ToString());
                if (Result == DialogResult.Retry)
                {
                    System.Diagnostics.Process.Start("https://aka.ms/vs/16/release/vc_redist.x64.exe");
                }
                if (show == false)
                {
                    Environment.Exit(1);
                }
            } catch (Exception e)
            {
                var Result = MessageBox.Show("An unexpected error occured. Details:\n\n" + e.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                Coutln("Error: " + e.ToString());
                if (Result == DialogResult.Retry)
                {
                    ConnectToMc();
                } else
                {
                    Environment.Exit(1); // EXIT_FAILURE
                }
            }
        }

        public void DisconnectFromMc()
        {
            if (LatiteCore.connectedToMinecraft())
            {
                if (moduleWorker.IsBusy)
                {
                    moduleWorker.CancelAsync();
                }
                disconnectButton.Visible = false;
                connectButton.Visible = true;
                LatiteCore.connectedToMinecraft(0); // false
                connectedLabel.Visible = false;
                this.OverlayForm.SaveData();
                this.OverlayForm.backgroundWorker1.CancelAsync();
                if (this.OverlayForm.IsEditing) this.toggleEditing();
                if (!this.OverlayForm.IsDisposed) this.OverlayForm.BeginInvoke(new MethodInvoker(this.OverlayForm.Close));
                LatiteCore.detach();
            }
        }

        private void connectButton_Click(object sender = null, EventArgs e = null)
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

        private void cinGo_Click(object sender = null, EventArgs e = null)
        {
            DispatchCommand(consoleInput.Text);
        }

        private void DRPButton_Click(object sender = null, EventArgs e = null)
        {
            System.Diagnostics.Process.Start("https://discord.gg/DfYUSJspcn");
        }
        #region Tabs
        private void optionsButton_Click(object sender = null, EventArgs e = null)
        {
            modsControl.SelectedTab = optionsTabControl;
        }

        private void modsButton_Click(object sender = null, EventArgs e = null)
        {
            modsControl.SelectedTab = modsTabPage;
        }

        private void consoleButton_Click(object sender = null, EventArgs e = null)
        {
            modsControl.SelectedTab = consoleTab;
        }
        #endregion Tabs
        public bool IsToggleSprint = false;

        void ToggleSprint(int _Val)
        {
            bool Val = _Val == 1;
            if (_Val < 2)
            {
                LatiteCore.setEnabled(3, Val);
                Data.ToggleSprint.Enabled = Val;
            }
            
            if (_Val == 1) IsToggleSprint = true;
            else if (_Val == 0) IsToggleSprint = false;
            this.OverlayForm.ToggleSprint(_Val);
        }

        public bool FocusedOnMinecraft()
        {
            return User32.GetForegroundWindow() == User32.FindWindowA(null, "Minecraft");
        }

        private void moduleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (moduleWorker.CancellationPending) break;
                LatiteCore.loop();
                if (toggleSprintCheckbox.Checked && LatiteCore.connectedToMinecraft())
                {   
                    if ((User32.GetKeyState((int)ToggleSprintBind) & 1) != 0 && !this.ToggleSprintBindOn)
                    {
                        if (!OverlayForm.IsEditing && FocusedOnMinecraft() && (LatiteCore.getCurrentGui() == 0)) this.ToggleSprint(1);
                        ToggleSprintBindOn = true;
                    }
                    else if ((User32.GetKeyState((int)ToggleSprintBind) & 1) == 0 && this.ToggleSprintBindOn)
                    {
                        if (!OverlayForm.IsEditing && FocusedOnMinecraft() && (LatiteCore.getCurrentGui() == 0)) this.ToggleSprint(0);
                        ToggleSprintBindOn = false;
                    }
                }
                Thread.Sleep(50);
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromMc();
            Data.Save();
        }

        private void disconnectButton_Click(object sender = null, EventArgs e = null)
        {
            DisconnectFromMc();
        }

        private void zoomBindBox_TextChanged(object sender = null, EventArgs e = null)
        {
            string SetStr = zoomBindBox.Text;
            byte Bind = (byte)StringToBind(SetStr);
            Data.Zoom.Bind = Bind;
            if (SetStr.Length > 0) LatiteCore.mod_zoom_setBind((char)Bind);
        }

        private void LatiteForm_Load(object sender = null, EventArgs e = null)
        {
            ConnectToMc(false); // silently connect on launch
        }

        private void launchButton_Click(object sender = null, EventArgs e = null)
        {
            System.Diagnostics.Process.Start("minecraft://");
        }

        private void zoomCheckbox_CheckedChanged(object sender = null, EventArgs e = null)
        {
            Data.Zoom.Enabled = zoomCheckbox.Checked;
            LatiteCore.setEnabled(1, zoomCheckbox.Checked);
        }

        private void lookBehindEnabled_CheckedChanged(object sender = null, EventArgs e = null)
        {
            Data.LookBehind.Enabled = lookBehindEnabled.Checked;
            LatiteCore.setEnabled(2, lookBehindEnabled.Checked);
        }

        private void lookBehindBind_TextChanged(object sender = null, EventArgs e = null)
        {
            string SetStr = zoomBindBox.Text.ToUpper();
            if (SetStr.Length > 0)
                LatiteCore.mod_lookBehind_setBind(SetStr[0]);
        }

        private void toggleSprintCheckbox_CheckedChanged(object sender = null, EventArgs e = null)
        {
            if (!(this.toggleSprintCheckbox.Checked))
            {
                // unchecked
                this.OverlayForm.ToggleSprint(0);
                this.ToggleSprint(0);
            }
        }

        public char StringToBind(string s)
        {
            string SetStr = s.ToUpper();
            if (SetStr.ToLower() == "lctrl") return (char)0xA2;
            else if (SetStr.ToLower() == "lshift") return (char)0xA0;
            else if (SetStr.ToLower() == "enter" || SetStr.ToLower() == "return") return '\r';
            else if (SetStr.ToLower() == "rshift") return (char)0xA1;
            else if (SetStr.ToLower() == "rctrl") return (char)0xA3;
            if (SetStr.Length > 0) return (SetStr.ToUpper())[0];
            return '\0';
        }

        public string BindToString(byte bind)
        {
            switch (bind) 
            {
                case 0xA2:
                    return "lctrl";
                case 0xA0:
                    return "lshift";
                case 0xA1:
                    return "rshift";
                case 0xA3:
                    return "rctrl";
            }
            return ((char)bind).ToString();
        }

        private void toggleSprintBind_TextChanged(object sender = null, EventArgs e = null)
        {
            ToggleSprintBind = StringToBind(toggleSprintBind.Text);
        }
        
        private void GithubButton_Click(object sender = null, EventArgs e = null)
        {
            System.Diagnostics.Process.Start("https://github.com/Imrglop/Latite");
        }

        private void updateButton_Click(object sender = null, EventArgs e = null)
        {
            System.Diagnostics.Process.Start("https://github.com/Imrglop/Latite/releases/latest");
        }

        public bool ToggleEditing = false;

        public void toggleEditing()
        {
            ToggleEditing = !ToggleEditing;
            this.OverlayForm.SetDraggableItems(ToggleEditing);
            this.toggleEditingButton.FlatAppearance.BorderColor = (ToggleEditing ? Color.Aqua : Color.Gray);
        }

        private void toggleEditingButton_Click(object sender = null, EventArgs e = null)
        {
            if (LatiteCore.connectedToMinecraft())
                this.toggleEditing();
        }

        private void shortcutToggleEditing_TextChanged(object sender = null, EventArgs e = null)
        {
            if (LatiteCore.connectedToMinecraft())
            {
                this.OverlayForm.EditingBind = StringToBind(shortcutToggleEditing.Text);
            }
        }

        private void fullbrightCheckBox_CheckedChanged(object sender = null, EventArgs e = null)
        {
            Data.Fullbright.Enabled = fullbrightCheckBox.Checked;
            LatiteCore.setEnabled(5, fullbrightCheckBox.Checked);
        }

        private void button1_Click(object sender = null, EventArgs e = null)
        {
            System.Diagnostics.Process.Start("settings.txt");
        }

        private void zaSlider_ValueChanged(object sender = null, EventArgs e = null)
        {
            var FOVAmount = (zaSlider.Value + 2) * 5;
            zaSliderLabel.Text = $"Amount ({FOVAmount})";
            Data.Zoom.Amount = (byte)zaSlider.Value;
            LatiteCore.mod_zoom_setAmount(FOVAmount);
            Coutln("try set amt to " + FOVAmount);
        }

        private void timeChangerTrackBar_ValueChanged(object sender = null, EventArgs e = null)
        {
            Data.TimeChanger.TimeOfDay = timeChangerTrackBar.Value;
            int Val = timeChangerTrackBar.Value * 2500;
            timeChangerTrackBarLabel.Text = Val + "";
        }

        private void button2_Click(object sender = null, EventArgs e = null)
        {
            if (LatiteCore.connectedToMinecraft())
            {
                this.OverlayForm.LoadGuiPos();
            } else
            {
                MessageBox.Show("Latite is not connected to Minecraft.");
            }
        }

        private void opacitySlider_ValueChanged(object sender = null, EventArgs e = null)
        {
            if (!LatiteCore.connectedToMinecraft()) return;
            Data.Options.Opacity = opacitySlider.Value;
            double val = opacitySlider.Value * 4;
            opacityDisplayLabel.Text = (opacitySlider.Value * 4) + "";
            this.OverlayForm.SetOpacity(val / 100);
        }

        private void freelookCheckbox_CheckedChanged(object sender = null, EventArgs e = null)
        {
            LatiteCore.mod_freelook_setBind(StringToBind(freelookBindBox.Text));
            LatiteCore.setEnabled(6, freelookCheckbox.Checked);
        }

        private void timeChanger_CheckedChanged(object sender = null, EventArgs e = null)
        {
            int Val = timeChangerTrackBar.Value * 2500;
            LatiteCore.setTimeChangerSetting(Val);
            Data.TimeChanger.Enabled = timeChangerCheckBox.Checked;
            Data.TimeChanger.TimeOfDay = Val;
            if (LatiteCore.connectedToMinecraft())
                LatiteCore.setEnabled(4, timeChangerCheckBox.Checked);
        }
    }
}
