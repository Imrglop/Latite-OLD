
namespace Latite
{
    partial class LatiteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LatiteForm));
            this.LatiteLabel1 = new System.Windows.Forms.Label();
            this.consoleButton = new System.Windows.Forms.Button();
            this.modsControl = new System.Windows.Forms.TabControl();
            this.modsTabPage = new System.Windows.Forms.TabPage();
            this.toggleSprintLabel = new System.Windows.Forms.Label();
            this.lookBehindDesc = new System.Windows.Forms.Label();
            this.lookBehindLabel = new System.Windows.Forms.Label();
            this.toggleSprintSettingsPanel = new System.Windows.Forms.Panel();
            this.toggleSprintCheckbox = new System.Windows.Forms.CheckBox();
            this.toggleSprintBind = new System.Windows.Forms.TextBox();
            this.toggleSprintBindLabel = new System.Windows.Forms.Label();
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.zoomBindBox = new System.Windows.Forms.TextBox();
            this.zoomKeybindLabel = new System.Windows.Forms.Label();
            this.zoomAmountR1 = new System.Windows.Forms.Label();
            this.zoomAmountL1 = new System.Windows.Forms.Label();
            this.zaSliderLabel = new System.Windows.Forms.Label();
            this.zaSlider = new System.Windows.Forms.TrackBar();
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.lookBehindPanel = new System.Windows.Forms.Panel();
            this.lookBehindBind = new System.Windows.Forms.TextBox();
            this.lookBehindBindLabel = new System.Windows.Forms.Label();
            this.lookBehindEnabled = new System.Windows.Forms.CheckBox();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.optionsTabControl = new System.Windows.Forms.TabPage();
            this.opacityDisplayLabel = new System.Windows.Forms.Label();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.transparentOverlayToggle = new System.Windows.Forms.CheckBox();
            this.settingsUseConsole = new System.Windows.Forms.CheckBox();
            this.consoleTab = new System.Windows.Forms.TabPage();
            this.cinGo = new System.Windows.Forms.Button();
            this.consoleInput = new System.Windows.Forms.TextBox();
            this.consoleOutput = new System.Windows.Forms.RichTextBox();
            this.modsButton = new System.Windows.Forms.Button();
            this.DRPButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.moduleWorker = new System.ComponentModel.BackgroundWorker();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LatiteIcon1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.launchButton = new System.Windows.Forms.Button();
            this.modsControl.SuspendLayout();
            this.modsTabPage.SuspendLayout();
            this.toggleSprintSettingsPanel.SuspendLayout();
            this.zoomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zaSlider)).BeginInit();
            this.lookBehindPanel.SuspendLayout();
            this.optionsTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.consoleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatiteIcon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LatiteLabel1
            // 
            this.LatiteLabel1.AutoSize = true;
            this.LatiteLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.LatiteLabel1.Location = new System.Drawing.Point(262, 36);
            this.LatiteLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LatiteLabel1.Name = "LatiteLabel1";
            this.LatiteLabel1.Size = new System.Drawing.Size(153, 26);
            this.LatiteLabel1.TabIndex = 1;
            this.LatiteLabel1.Text = "Latite PVP Client";
            // 
            // consoleButton
            // 
            this.consoleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.consoleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.consoleButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.consoleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.consoleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.consoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consoleButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleButton.ForeColor = System.Drawing.Color.White;
            this.consoleButton.Location = new System.Drawing.Point(12, 505);
            this.consoleButton.Name = "consoleButton";
            this.consoleButton.Size = new System.Drawing.Size(90, 39);
            this.consoleButton.TabIndex = 4;
            this.consoleButton.Text = "Console";
            this.consoleButton.UseVisualStyleBackColor = false;
            this.consoleButton.Click += new System.EventHandler(this.consoleButton_Click);
            // 
            // modsControl
            // 
            this.modsControl.Controls.Add(this.modsTabPage);
            this.modsControl.Controls.Add(this.optionsTabControl);
            this.modsControl.Controls.Add(this.consoleTab);
            this.modsControl.Location = new System.Drawing.Point(109, 92);
            this.modsControl.Name = "modsControl";
            this.modsControl.SelectedIndex = 0;
            this.modsControl.Size = new System.Drawing.Size(595, 463);
            this.modsControl.TabIndex = 7;
            // 
            // modsTabPage
            // 
            this.modsTabPage.AutoScroll = true;
            this.modsTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.modsTabPage.Controls.Add(this.toggleSprintLabel);
            this.modsTabPage.Controls.Add(this.lookBehindDesc);
            this.modsTabPage.Controls.Add(this.lookBehindLabel);
            this.modsTabPage.Controls.Add(this.toggleSprintSettingsPanel);
            this.modsTabPage.Controls.Add(this.zoomPanel);
            this.modsTabPage.Controls.Add(this.lookBehindPanel);
            this.modsTabPage.Controls.Add(this.zoomLabel);
            this.modsTabPage.Location = new System.Drawing.Point(4, 35);
            this.modsTabPage.Name = "modsTabPage";
            this.modsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modsTabPage.Size = new System.Drawing.Size(587, 424);
            this.modsTabPage.TabIndex = 0;
            this.modsTabPage.Text = "Mods";
            // 
            // toggleSprintLabel
            // 
            this.toggleSprintLabel.AutoSize = true;
            this.toggleSprintLabel.Location = new System.Drawing.Point(23, 374);
            this.toggleSprintLabel.Name = "toggleSprintLabel";
            this.toggleSprintLabel.Size = new System.Drawing.Size(122, 26);
            this.toggleSprintLabel.TabIndex = 10;
            this.toggleSprintLabel.Text = "Toggle Sprint";
            // 
            // lookBehindDesc
            // 
            this.lookBehindDesc.AutoSize = true;
            this.lookBehindDesc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookBehindDesc.Location = new System.Drawing.Point(141, 221);
            this.lookBehindDesc.Name = "lookBehindDesc";
            this.lookBehindDesc.Size = new System.Drawing.Size(172, 18);
            this.lookBehindDesc.TabIndex = 9;
            this.lookBehindDesc.Text = "Rear view by holding a key";
            // 
            // lookBehindLabel
            // 
            this.lookBehindLabel.AutoSize = true;
            this.lookBehindLabel.Location = new System.Drawing.Point(23, 215);
            this.lookBehindLabel.Name = "lookBehindLabel";
            this.lookBehindLabel.Size = new System.Drawing.Size(112, 26);
            this.lookBehindLabel.TabIndex = 7;
            this.lookBehindLabel.Text = "LookBehind";
            // 
            // toggleSprintSettingsPanel
            // 
            this.toggleSprintSettingsPanel.Controls.Add(this.toggleSprintCheckbox);
            this.toggleSprintSettingsPanel.Controls.Add(this.toggleSprintBind);
            this.toggleSprintSettingsPanel.Controls.Add(this.toggleSprintBindLabel);
            this.toggleSprintSettingsPanel.Location = new System.Drawing.Point(28, 407);
            this.toggleSprintSettingsPanel.Name = "toggleSprintSettingsPanel";
            this.toggleSprintSettingsPanel.Size = new System.Drawing.Size(200, 169);
            this.toggleSprintSettingsPanel.TabIndex = 11;
            // 
            // toggleSprintCheckbox
            // 
            this.toggleSprintCheckbox.AutoSize = true;
            this.toggleSprintCheckbox.Checked = true;
            this.toggleSprintCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleSprintCheckbox.ForeColor = System.Drawing.Color.White;
            this.toggleSprintCheckbox.Location = new System.Drawing.Point(18, 9);
            this.toggleSprintCheckbox.Name = "toggleSprintCheckbox";
            this.toggleSprintCheckbox.Size = new System.Drawing.Size(99, 30);
            this.toggleSprintCheckbox.TabIndex = 7;
            this.toggleSprintCheckbox.Text = "Enabled";
            this.toggleSprintCheckbox.UseVisualStyleBackColor = true;
            this.toggleSprintCheckbox.CheckedChanged += new System.EventHandler(this.toggleSprintCheckbox_CheckedChanged);
            // 
            // toggleSprintBind
            // 
            this.toggleSprintBind.Location = new System.Drawing.Point(73, 56);
            this.toggleSprintBind.Name = "toggleSprintBind";
            this.toggleSprintBind.Size = new System.Drawing.Size(24, 33);
            this.toggleSprintBind.TabIndex = 6;
            this.toggleSprintBind.Text = "P";
            this.toggleSprintBind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toggleSprintBind.TextChanged += new System.EventHandler(this.toggleSprintBind_TextChanged);
            // 
            // toggleSprintBindLabel
            // 
            this.toggleSprintBindLabel.AutoSize = true;
            this.toggleSprintBindLabel.Location = new System.Drawing.Point(17, 59);
            this.toggleSprintBindLabel.Name = "toggleSprintBindLabel";
            this.toggleSprintBindLabel.Size = new System.Drawing.Size(50, 26);
            this.toggleSprintBindLabel.TabIndex = 5;
            this.toggleSprintBindLabel.Text = "Bind";
            // 
            // zoomPanel
            // 
            this.zoomPanel.Controls.Add(this.zoomBindBox);
            this.zoomPanel.Controls.Add(this.zoomKeybindLabel);
            this.zoomPanel.Controls.Add(this.zoomAmountR1);
            this.zoomPanel.Controls.Add(this.zoomAmountL1);
            this.zoomPanel.Controls.Add(this.zaSliderLabel);
            this.zoomPanel.Controls.Add(this.zaSlider);
            this.zoomPanel.Controls.Add(this.zoomCheckbox);
            this.zoomPanel.Location = new System.Drawing.Point(28, 33);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(200, 169);
            this.zoomPanel.TabIndex = 2;
            // 
            // zoomBindBox
            // 
            this.zoomBindBox.Location = new System.Drawing.Point(73, 133);
            this.zoomBindBox.Name = "zoomBindBox";
            this.zoomBindBox.Size = new System.Drawing.Size(24, 33);
            this.zoomBindBox.TabIndex = 6;
            this.zoomBindBox.Text = "C";
            this.zoomBindBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomBindBox.TextChanged += new System.EventHandler(this.zoomBindBox_TextChanged);
            // 
            // zoomKeybindLabel
            // 
            this.zoomKeybindLabel.AutoSize = true;
            this.zoomKeybindLabel.Location = new System.Drawing.Point(17, 136);
            this.zoomKeybindLabel.Name = "zoomKeybindLabel";
            this.zoomKeybindLabel.Size = new System.Drawing.Size(50, 26);
            this.zoomKeybindLabel.TabIndex = 5;
            this.zoomKeybindLabel.Text = "Bind";
            // 
            // zoomAmountR1
            // 
            this.zoomAmountR1.AutoSize = true;
            this.zoomAmountR1.Location = new System.Drawing.Point(118, 106);
            this.zoomAmountR1.Name = "zoomAmountR1";
            this.zoomAmountR1.Size = new System.Drawing.Size(44, 26);
            this.zoomAmountR1.TabIndex = 4;
            this.zoomAmountR1.Text = "+60";
            // 
            // zoomAmountL1
            // 
            this.zoomAmountL1.AutoSize = true;
            this.zoomAmountL1.Location = new System.Drawing.Point(12, 106);
            this.zoomAmountL1.Name = "zoomAmountL1";
            this.zoomAmountL1.Size = new System.Drawing.Size(44, 26);
            this.zoomAmountL1.TabIndex = 3;
            this.zoomAmountL1.Text = "+10";
            // 
            // zaSliderLabel
            // 
            this.zaSliderLabel.AutoSize = true;
            this.zaSliderLabel.Location = new System.Drawing.Point(22, 45);
            this.zaSliderLabel.Name = "zaSliderLabel";
            this.zaSliderLabel.Size = new System.Drawing.Size(120, 26);
            this.zaSliderLabel.TabIndex = 2;
            this.zaSliderLabel.Text = "Amount (45)";
            // 
            // zaSlider
            // 
            this.zaSlider.Location = new System.Drawing.Point(12, 74);
            this.zaSlider.Name = "zaSlider";
            this.zaSlider.Size = new System.Drawing.Size(150, 45);
            this.zaSlider.TabIndex = 1;
            this.zaSlider.TickFrequency = 2;
            this.zaSlider.Value = 7;
            this.zaSlider.Scroll += new System.EventHandler(this.zaSlider_Scroll);
            // 
            // zoomCheckbox
            // 
            this.zoomCheckbox.AutoSize = true;
            this.zoomCheckbox.Checked = true;
            this.zoomCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomCheckbox.ForeColor = System.Drawing.Color.White;
            this.zoomCheckbox.Location = new System.Drawing.Point(17, 12);
            this.zoomCheckbox.Name = "zoomCheckbox";
            this.zoomCheckbox.Size = new System.Drawing.Size(99, 30);
            this.zoomCheckbox.TabIndex = 0;
            this.zoomCheckbox.Text = "Enabled";
            this.zoomCheckbox.UseVisualStyleBackColor = true;
            this.zoomCheckbox.CheckedChanged += new System.EventHandler(this.zoomCheckbox_CheckedChanged);
            // 
            // lookBehindPanel
            // 
            this.lookBehindPanel.Controls.Add(this.lookBehindBind);
            this.lookBehindPanel.Controls.Add(this.lookBehindBindLabel);
            this.lookBehindPanel.Controls.Add(this.lookBehindEnabled);
            this.lookBehindPanel.Location = new System.Drawing.Point(28, 248);
            this.lookBehindPanel.Name = "lookBehindPanel";
            this.lookBehindPanel.Size = new System.Drawing.Size(200, 106);
            this.lookBehindPanel.TabIndex = 8;
            // 
            // lookBehindBind
            // 
            this.lookBehindBind.Location = new System.Drawing.Point(73, 56);
            this.lookBehindBind.Name = "lookBehindBind";
            this.lookBehindBind.Size = new System.Drawing.Size(24, 33);
            this.lookBehindBind.TabIndex = 6;
            this.lookBehindBind.Text = "G";
            this.lookBehindBind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lookBehindBind.TextChanged += new System.EventHandler(this.lookBehindBind_TextChanged);
            // 
            // lookBehindBindLabel
            // 
            this.lookBehindBindLabel.AutoSize = true;
            this.lookBehindBindLabel.Location = new System.Drawing.Point(17, 59);
            this.lookBehindBindLabel.Name = "lookBehindBindLabel";
            this.lookBehindBindLabel.Size = new System.Drawing.Size(50, 26);
            this.lookBehindBindLabel.TabIndex = 5;
            this.lookBehindBindLabel.Text = "Bind";
            // 
            // lookBehindEnabled
            // 
            this.lookBehindEnabled.AutoSize = true;
            this.lookBehindEnabled.Checked = true;
            this.lookBehindEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lookBehindEnabled.ForeColor = System.Drawing.Color.White;
            this.lookBehindEnabled.Location = new System.Drawing.Point(17, 12);
            this.lookBehindEnabled.Name = "lookBehindEnabled";
            this.lookBehindEnabled.Size = new System.Drawing.Size(99, 30);
            this.lookBehindEnabled.TabIndex = 0;
            this.lookBehindEnabled.Text = "Enabled";
            this.lookBehindEnabled.UseVisualStyleBackColor = true;
            this.lookBehindEnabled.CheckedChanged += new System.EventHandler(this.lookBehindEnabled_CheckedChanged);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(23, 0);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(61, 26);
            this.zoomLabel.TabIndex = 1;
            this.zoomLabel.Text = "Zoom";
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.optionsTabControl.Controls.Add(this.opacityDisplayLabel);
            this.optionsTabControl.Controls.Add(this.opacityLabel);
            this.optionsTabControl.Controls.Add(this.opacitySlider);
            this.optionsTabControl.Controls.Add(this.transparentOverlayToggle);
            this.optionsTabControl.Controls.Add(this.settingsUseConsole);
            this.optionsTabControl.Location = new System.Drawing.Point(4, 22);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTabControl.Size = new System.Drawing.Size(587, 437);
            this.optionsTabControl.TabIndex = 1;
            this.optionsTabControl.Text = "Options";
            // 
            // opacityDisplayLabel
            // 
            this.opacityDisplayLabel.AutoSize = true;
            this.opacityDisplayLabel.Location = new System.Drawing.Point(231, 139);
            this.opacityDisplayLabel.Name = "opacityDisplayLabel";
            this.opacityDisplayLabel.Size = new System.Drawing.Size(34, 26);
            this.opacityDisplayLabel.TabIndex = 4;
            this.opacityDisplayLabel.Text = "80";
            // 
            // opacityLabel
            // 
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.Location = new System.Drawing.Point(88, 107);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(78, 26);
            this.opacityLabel.TabIndex = 3;
            this.opacityLabel.Text = "Opacity";
            // 
            // opacitySlider
            // 
            this.opacitySlider.Location = new System.Drawing.Point(23, 139);
            this.opacitySlider.Maximum = 25;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(202, 45);
            this.opacitySlider.TabIndex = 2;
            this.opacitySlider.Value = 20;
            this.opacitySlider.Scroll += new System.EventHandler(this.opacitySlider_Scroll);
            // 
            // transparentOverlayToggle
            // 
            this.transparentOverlayToggle.AutoSize = true;
            this.transparentOverlayToggle.Location = new System.Drawing.Point(23, 57);
            this.transparentOverlayToggle.Name = "transparentOverlayToggle";
            this.transparentOverlayToggle.Size = new System.Drawing.Size(202, 30);
            this.transparentOverlayToggle.TabIndex = 1;
            this.transparentOverlayToggle.Text = "Transparent Overlay";
            this.transparentOverlayToggle.UseVisualStyleBackColor = true;
            this.transparentOverlayToggle.CheckedChanged += new System.EventHandler(this.transparentOverlayToggle_CheckedChanged);
            // 
            // settingsUseConsole
            // 
            this.settingsUseConsole.AutoSize = true;
            this.settingsUseConsole.Location = new System.Drawing.Point(23, 21);
            this.settingsUseConsole.Name = "settingsUseConsole";
            this.settingsUseConsole.Size = new System.Drawing.Size(165, 30);
            this.settingsUseConsole.TabIndex = 0;
            this.settingsUseConsole.Text = "Pop Up Console";
            this.settingsUseConsole.UseVisualStyleBackColor = true;
            // 
            // consoleTab
            // 
            this.consoleTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.consoleTab.Controls.Add(this.cinGo);
            this.consoleTab.Controls.Add(this.consoleInput);
            this.consoleTab.Controls.Add(this.consoleOutput);
            this.consoleTab.Location = new System.Drawing.Point(4, 22);
            this.consoleTab.Name = "consoleTab";
            this.consoleTab.Padding = new System.Windows.Forms.Padding(3);
            this.consoleTab.Size = new System.Drawing.Size(587, 437);
            this.consoleTab.TabIndex = 2;
            this.consoleTab.Text = "Console";
            // 
            // cinGo
            // 
            this.cinGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cinGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cinGo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.cinGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.cinGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cinGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cinGo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinGo.ForeColor = System.Drawing.Color.White;
            this.cinGo.Location = new System.Drawing.Point(535, 378);
            this.cinGo.Name = "cinGo";
            this.cinGo.Size = new System.Drawing.Size(43, 33);
            this.cinGo.TabIndex = 12;
            this.cinGo.Text = "✅";
            this.cinGo.UseVisualStyleBackColor = false;
            this.cinGo.Click += new System.EventHandler(this.cinGo_Click);
            // 
            // consoleInput
            // 
            this.consoleInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.consoleInput.ForeColor = System.Drawing.Color.White;
            this.consoleInput.Location = new System.Drawing.Point(7, 378);
            this.consoleInput.Name = "consoleInput";
            this.consoleInput.Size = new System.Drawing.Size(522, 33);
            this.consoleInput.TabIndex = 1;
            this.consoleInput.Text = "Try \"help\"";
            this.consoleInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            // 
            // consoleOutput
            // 
            this.consoleOutput.BackColor = System.Drawing.Color.Black;
            this.consoleOutput.ForeColor = System.Drawing.Color.White;
            this.consoleOutput.Location = new System.Drawing.Point(6, 6);
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.Size = new System.Drawing.Size(575, 366);
            this.consoleOutput.TabIndex = 0;
            this.consoleOutput.Text = "";
            // 
            // modsButton
            // 
            this.modsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.modsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.modsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.modsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modsButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.ForeColor = System.Drawing.Color.White;
            this.modsButton.Location = new System.Drawing.Point(12, 184);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(90, 76);
            this.modsButton.TabIndex = 1;
            this.modsButton.Text = "Mods";
            this.modsButton.UseVisualStyleBackColor = false;
            this.modsButton.Click += new System.EventHandler(this.modsButton_Click);
            // 
            // DRPButton
            // 
            this.DRPButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DRPButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DRPButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.DRPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.DRPButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.DRPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DRPButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DRPButton.ForeColor = System.Drawing.Color.White;
            this.DRPButton.Location = new System.Drawing.Point(12, 466);
            this.DRPButton.Name = "DRPButton";
            this.DRPButton.Size = new System.Drawing.Size(90, 33);
            this.DRPButton.TabIndex = 3;
            this.DRPButton.Text = "Discord";
            this.DRPButton.UseVisualStyleBackColor = false;
            this.DRPButton.Click += new System.EventHandler(this.DRPButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.optionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.optionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.ForeColor = System.Drawing.Color.White;
            this.optionsButton.Location = new System.Drawing.Point(12, 266);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(90, 76);
            this.optionsButton.TabIndex = 2;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.connectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.connectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.Color.White;
            this.connectButton.Location = new System.Drawing.Point(12, 102);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(90, 76);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectedLabel
            // 
            this.connectedLabel.AutoSize = true;
            this.connectedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.connectedLabel.Location = new System.Drawing.Point(4, 127);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(103, 26);
            this.connectedLabel.TabIndex = 11;
            this.connectedLabel.Text = "Connected";
            this.connectedLabel.Visible = false;
            // 
            // moduleWorker
            // 
            this.moduleWorker.WorkerSupportsCancellation = true;
            this.moduleWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.moduleWorker_DoWork);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.disconnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disconnectButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.disconnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.disconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectButton.ForeColor = System.Drawing.Color.White;
            this.disconnectButton.Location = new System.Drawing.Point(13, 388);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(90, 33);
            this.disconnectButton.TabIndex = 12;
            this.disconnectButton.Text = "Detach";
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 463);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // LatiteIcon1
            // 
            this.LatiteIcon1.Image = global::Latite.Properties.Resources.LatiteClient_Small1;
            this.LatiteIcon1.Location = new System.Drawing.Point(25, 15);
            this.LatiteIcon1.Margin = new System.Windows.Forms.Padding(6);
            this.LatiteIcon1.Name = "LatiteIcon1";
            this.LatiteIcon1.Size = new System.Drawing.Size(64, 64);
            this.LatiteIcon1.TabIndex = 2;
            this.LatiteIcon1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 93);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.launchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.launchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.launchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchButton.ForeColor = System.Drawing.Color.White;
            this.launchButton.Location = new System.Drawing.Point(13, 427);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(90, 33);
            this.launchButton.TabIndex = 13;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // LatiteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(704, 556);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectedLabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.DRPButton);
            this.Controls.Add(this.modsButton);
            this.Controls.Add(this.modsControl);
            this.Controls.Add(this.consoleButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LatiteIcon1);
            this.Controls.Add(this.LatiteLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LatiteForm";
            this.Text = "Latite Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.LatiteForm_Load);
            this.modsControl.ResumeLayout(false);
            this.modsTabPage.ResumeLayout(false);
            this.modsTabPage.PerformLayout();
            this.toggleSprintSettingsPanel.ResumeLayout(false);
            this.toggleSprintSettingsPanel.PerformLayout();
            this.zoomPanel.ResumeLayout(false);
            this.zoomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zaSlider)).EndInit();
            this.lookBehindPanel.ResumeLayout(false);
            this.lookBehindPanel.PerformLayout();
            this.optionsTabControl.ResumeLayout(false);
            this.optionsTabControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            this.consoleTab.ResumeLayout(false);
            this.consoleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatiteIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LatiteLabel1;
        private System.Windows.Forms.PictureBox LatiteIcon1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button consoleButton;
        private System.Windows.Forms.TabControl modsControl;
        private System.Windows.Forms.TabPage modsTabPage;
        private System.Windows.Forms.TabPage optionsTabControl;
        private System.Windows.Forms.Button modsButton;
        private System.Windows.Forms.Button DRPButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.TabPage consoleTab;
        private System.Windows.Forms.RichTextBox consoleOutput;
        private System.Windows.Forms.TextBox consoleInput;
        private System.Windows.Forms.Button cinGo;
        private System.Windows.Forms.CheckBox settingsUseConsole;
        private System.Windows.Forms.CheckBox zoomCheckbox;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Panel zoomPanel;
        private System.Windows.Forms.TrackBar zaSlider;
        private System.Windows.Forms.Label zaSliderLabel;
        private System.Windows.Forms.Label zoomAmountL1;
        private System.Windows.Forms.Label zoomAmountR1;
        private System.Windows.Forms.Label zoomKeybindLabel;
        private System.Windows.Forms.TextBox zoomBindBox;
        private System.ComponentModel.BackgroundWorker moduleWorker;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.CheckBox transparentOverlayToggle;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Label lookBehindDesc;
        private System.Windows.Forms.Label lookBehindLabel;
        private System.Windows.Forms.Panel lookBehindPanel;
        private System.Windows.Forms.TextBox lookBehindBind;
        private System.Windows.Forms.Label lookBehindBindLabel;
        private System.Windows.Forms.CheckBox lookBehindEnabled;
        private System.Windows.Forms.TrackBar opacitySlider;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Label opacityDisplayLabel;
        private System.Windows.Forms.Label toggleSprintLabel;
        private System.Windows.Forms.Panel toggleSprintSettingsPanel;
        private System.Windows.Forms.TextBox toggleSprintBind;
        private System.Windows.Forms.Label toggleSprintBindLabel;
        private System.Windows.Forms.CheckBox toggleSprintCheckbox;
    }
}

