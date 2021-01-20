// Latite Client
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

namespace Latite
{
    public partial class LatiteForm : Form
    {
        [DllImport("LatiteCore.dll")]
        static extern void consoleMain();
        [DllImport("LatiteCore.dll")]
        static extern ulong attach();
        // extern "C" LATITE_API bool connectedToMinecraft(int type = 2);
        [DllImport("LatiteCore.dll")]
        static extern bool connectedToMinecraft(int type = 2);
        public LatiteForm()
        {
            InitializeComponent();
        }

        string[] Commands = { "help", "info", "print <text>", "clear", "connect" };
        string Info = "Latite Client\r\n\r\nLicense: GPLv3\r\n\r\nSource: github.com/Imrglop/Latite\r\n\r\nMade by Imrglop";
        bool IsConsole = false;

        public void Cout(string OutputString)
        {
            consoleOutput.Text += OutputString;
        }
        public void Coutln(string OutputString)
        {
            consoleOutput.Text += (OutputString + "\r\n");
        }

        private void ConnectToMc()
        {
            if (!connectedToMinecraft())
            {
                var Status = attach();
                if (Status == 0)
                {
                    MessageBox.Show("Connected to Minecraft!");
                    if (settingsUseConsole.Checked)
                    {
                        consoleMain();
                        IsConsole = true;
                    }
                    connectButton.Visible = false;
                    connectedToMinecraft(1); // true
                    connectedLabel.Visible = true;
                    // have to put 1 cuz C#
                }
                else
                {
                    MessageBox.Show("Could not connect to Minecraft! Error Code: " + Status.ToString());
                    Coutln("Couldn't connect to Minecraft! Error code: " + Status.ToString());
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
            MessageBox.Show("This feature is coming soon");
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
    }
}
