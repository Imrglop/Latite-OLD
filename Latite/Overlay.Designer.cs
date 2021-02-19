
namespace Latite
{
    partial class Overlay
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.secondRunner = new System.ComponentModel.BackgroundWorker();
            this.motionLabel = new System.Windows.Forms.Label();
            this.motionYLabel = new System.Windows.Forms.Label();
            this.posPanel = new System.Windows.Forms.Panel();
            this.zPosLabel = new System.Windows.Forms.Label();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.motionTopLabel = new System.Windows.Forms.Label();
            this.toggleSprintLabel = new System.Windows.Forms.Label();
            this.settingsCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.keystrokesTabPage = new System.Windows.Forms.TabPage();
            this.keystrokesCheckBox = new System.Windows.Forms.CheckBox();
            this.keystrokesSettingsPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.keystrokesBlueTrackbar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.keystrokesGreenTrackbar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.keystrokesRedTrackbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.posDisplayCheckbox = new System.Windows.Forms.CheckBox();
            this.blockCoordsTabPage = new System.Windows.Forms.TabPage();
            this.chatBlockCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.blockCoordsCheckbox = new System.Windows.Forms.CheckBox();
            this.blockDisplayText = new System.Windows.Forms.Label();
            this.keyStrokes_W = new System.Windows.Forms.Panel();
            this.keystrokeLabel = new System.Windows.Forms.Label();
            this.keyStrokes_S = new System.Windows.Forms.Panel();
            this.kLabel2 = new System.Windows.Forms.Label();
            this.keyStrokes_A = new System.Windows.Forms.Panel();
            this.kLabel3 = new System.Windows.Forms.Label();
            this.keyStrokes_D = new System.Windows.Forms.Panel();
            this.kLabel4 = new System.Windows.Forms.Label();
            this.Keystrokes_LMB = new System.Windows.Forms.Panel();
            this.LMBCounter = new System.Windows.Forms.Label();
            this.LMBLabel = new System.Windows.Forms.Label();
            this.LMB = new System.Windows.Forms.Label();
            this.Keystrokes_RMB = new System.Windows.Forms.Panel();
            this.RMBCounter = new System.Windows.Forms.Label();
            this.RMBLabel = new System.Windows.Forms.Label();
            this.spaceBarPanel = new System.Windows.Forms.Panel();
            this.spaceBarBox = new System.Windows.Forms.PictureBox();
            this.keystrokesPanel = new System.Windows.Forms.Panel();
            this.posPanel.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.keystrokesTabPage.SuspendLayout();
            this.keystrokesSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesBlueTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesGreenTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesRedTrackbar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.blockCoordsTabPage.SuspendLayout();
            this.keyStrokes_W.SuspendLayout();
            this.keyStrokes_S.SuspendLayout();
            this.keyStrokes_A.SuspendLayout();
            this.keyStrokes_D.SuspendLayout();
            this.Keystrokes_LMB.SuspendLayout();
            this.Keystrokes_RMB.SuspendLayout();
            this.spaceBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceBarBox)).BeginInit();
            this.keystrokesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // secondRunner
            // 
            this.secondRunner.WorkerSupportsCancellation = true;
            this.secondRunner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.secondRunner_DoWork);
            // 
            // motionLabel
            // 
            this.motionLabel.AutoSize = true;
            this.motionLabel.Location = new System.Drawing.Point(6, 98);
            this.motionLabel.Name = "motionLabel";
            this.motionLabel.Size = new System.Drawing.Size(81, 23);
            this.motionLabel.TabIndex = 1;
            this.motionLabel.Text = "Motion X";
            // 
            // motionYLabel
            // 
            this.motionYLabel.AutoSize = true;
            this.motionYLabel.Location = new System.Drawing.Point(6, 121);
            this.motionYLabel.Name = "motionYLabel";
            this.motionYLabel.Size = new System.Drawing.Size(80, 23);
            this.motionYLabel.TabIndex = 2;
            this.motionYLabel.Text = "Motion Y";
            // 
            // posPanel
            // 
            this.posPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.posPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.posPanel.Controls.Add(this.zPosLabel);
            this.posPanel.Controls.Add(this.yPosLabel);
            this.posPanel.Controls.Add(this.xPosLabel);
            this.posPanel.Controls.Add(this.motionTopLabel);
            this.posPanel.Controls.Add(this.motionLabel);
            this.posPanel.Controls.Add(this.motionYLabel);
            this.posPanel.Location = new System.Drawing.Point(14, 367);
            this.posPanel.Name = "posPanel";
            this.posPanel.Size = new System.Drawing.Size(155, 155);
            this.posPanel.TabIndex = 4;
            this.posPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.posPanel_MouseDown);
            this.posPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.posPanel_MouseMove);
            // 
            // zPosLabel
            // 
            this.zPosLabel.AutoSize = true;
            this.zPosLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.zPosLabel.Location = new System.Drawing.Point(6, 78);
            this.zPosLabel.Name = "zPosLabel";
            this.zPosLabel.Size = new System.Drawing.Size(28, 23);
            this.zPosLabel.TabIndex = 6;
            this.zPosLabel.Text = "??";
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.ForeColor = System.Drawing.Color.Lime;
            this.yPosLabel.Location = new System.Drawing.Point(6, 55);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(28, 23);
            this.yPosLabel.TabIndex = 5;
            this.yPosLabel.Text = "??";
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.ForeColor = System.Drawing.Color.Red;
            this.xPosLabel.Location = new System.Drawing.Point(6, 32);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(28, 23);
            this.xPosLabel.TabIndex = 4;
            this.xPosLabel.Text = "??";
            // 
            // motionTopLabel
            // 
            this.motionTopLabel.AutoSize = true;
            this.motionTopLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motionTopLabel.ForeColor = System.Drawing.Color.LightBlue;
            this.motionTopLabel.Location = new System.Drawing.Point(25, 2);
            this.motionTopLabel.Name = "motionTopLabel";
            this.motionTopLabel.Size = new System.Drawing.Size(102, 33);
            this.motionTopLabel.TabIndex = 3;
            this.motionTopLabel.Text = "Position";
            // 
            // toggleSprintLabel
            // 
            this.toggleSprintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleSprintLabel.AutoSize = true;
            this.toggleSprintLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.toggleSprintLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSprintLabel.Location = new System.Drawing.Point(16, 688);
            this.toggleSprintLabel.Name = "toggleSprintLabel";
            this.toggleSprintLabel.Size = new System.Drawing.Size(218, 33);
            this.toggleSprintLabel.TabIndex = 5;
            this.toggleSprintLabel.Text = "Toggle Sprint Label";
            this.toggleSprintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleSprintLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toggleSprintLabel_MouseDown);
            this.toggleSprintLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toggleSprintLabel_MouseMove);
            // 
            // settingsCheckBox
            // 
            this.settingsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.settingsCheckBox.AutoSize = true;
            this.settingsCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingsCheckBox.Location = new System.Drawing.Point(399, 25);
            this.settingsCheckBox.Name = "settingsCheckBox";
            this.settingsCheckBox.Size = new System.Drawing.Size(171, 27);
            this.settingsCheckBox.TabIndex = 6;
            this.settingsCheckBox.Text = "Settings and Mods";
            this.settingsCheckBox.UseVisualStyleBackColor = false;
            this.settingsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabControl.Controls.Add(this.keystrokesTabPage);
            this.settingsTabControl.Controls.Add(this.tabPage2);
            this.settingsTabControl.Controls.Add(this.blockCoordsTabPage);
            this.settingsTabControl.Location = new System.Drawing.Point(273, 58);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(529, 626);
            this.settingsTabControl.TabIndex = 2;
            // 
            // keystrokesTabPage
            // 
            this.keystrokesTabPage.AutoScroll = true;
            this.keystrokesTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.keystrokesTabPage.Controls.Add(this.keystrokesCheckBox);
            this.keystrokesTabPage.Controls.Add(this.keystrokesSettingsPanel);
            this.keystrokesTabPage.ForeColor = System.Drawing.Color.White;
            this.keystrokesTabPage.Location = new System.Drawing.Point(4, 32);
            this.keystrokesTabPage.Name = "keystrokesTabPage";
            this.keystrokesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.keystrokesTabPage.Size = new System.Drawing.Size(521, 590);
            this.keystrokesTabPage.TabIndex = 0;
            this.keystrokesTabPage.Text = "Keystrokes";
            // 
            // keystrokesCheckBox
            // 
            this.keystrokesCheckBox.AutoSize = true;
            this.keystrokesCheckBox.Checked = true;
            this.keystrokesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keystrokesCheckBox.Location = new System.Drawing.Point(6, 7);
            this.keystrokesCheckBox.Name = "keystrokesCheckBox";
            this.keystrokesCheckBox.Size = new System.Drawing.Size(90, 27);
            this.keystrokesCheckBox.TabIndex = 2;
            this.keystrokesCheckBox.Text = "Enabled";
            this.keystrokesCheckBox.UseVisualStyleBackColor = true;
            this.keystrokesCheckBox.CheckedChanged += new System.EventHandler(this.keystrokesCheckBox_CheckedChanged);
            // 
            // keystrokesSettingsPanel
            // 
            this.keystrokesSettingsPanel.Controls.Add(this.panel3);
            this.keystrokesSettingsPanel.Controls.Add(this.keystrokesBlueTrackbar);
            this.keystrokesSettingsPanel.Controls.Add(this.panel2);
            this.keystrokesSettingsPanel.Controls.Add(this.keystrokesGreenTrackbar);
            this.keystrokesSettingsPanel.Controls.Add(this.panel1);
            this.keystrokesSettingsPanel.Controls.Add(this.keystrokesRedTrackbar);
            this.keystrokesSettingsPanel.Controls.Add(this.label2);
            this.keystrokesSettingsPanel.Location = new System.Drawing.Point(6, 34);
            this.keystrokesSettingsPanel.Name = "keystrokesSettingsPanel";
            this.keystrokesSettingsPanel.Size = new System.Drawing.Size(465, 232);
            this.keystrokesSettingsPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(23, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(25, 25);
            this.panel3.TabIndex = 7;
            // 
            // keystrokesBlueTrackbar
            // 
            this.keystrokesBlueTrackbar.Location = new System.Drawing.Point(13, 179);
            this.keystrokesBlueTrackbar.Maximum = 64;
            this.keystrokesBlueTrackbar.Name = "keystrokesBlueTrackbar";
            this.keystrokesBlueTrackbar.Size = new System.Drawing.Size(214, 45);
            this.keystrokesBlueTrackbar.TabIndex = 6;
            this.keystrokesBlueTrackbar.Value = 64;
            this.keystrokesBlueTrackbar.Scroll += new System.EventHandler(this.keystrokesBlueTrackbar_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(23, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 25);
            this.panel2.TabIndex = 5;
            // 
            // keystrokesGreenTrackbar
            // 
            this.keystrokesGreenTrackbar.Location = new System.Drawing.Point(13, 117);
            this.keystrokesGreenTrackbar.Maximum = 64;
            this.keystrokesGreenTrackbar.Name = "keystrokesGreenTrackbar";
            this.keystrokesGreenTrackbar.Size = new System.Drawing.Size(214, 45);
            this.keystrokesGreenTrackbar.TabIndex = 4;
            this.keystrokesGreenTrackbar.Value = 64;
            this.keystrokesGreenTrackbar.Scroll += new System.EventHandler(this.keystrokesGreenTrackbar_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(23, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 25);
            this.panel1.TabIndex = 3;
            // 
            // keystrokesRedTrackbar
            // 
            this.keystrokesRedTrackbar.Location = new System.Drawing.Point(13, 58);
            this.keystrokesRedTrackbar.Maximum = 64;
            this.keystrokesRedTrackbar.Name = "keystrokesRedTrackbar";
            this.keystrokesRedTrackbar.Size = new System.Drawing.Size(214, 45);
            this.keystrokesRedTrackbar.TabIndex = 2;
            this.keystrokesRedTrackbar.Value = 64;
            this.keystrokesRedTrackbar.Scroll += new System.EventHandler(this.keystrokesRedTrackbar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text Color";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage2.Controls.Add(this.posDisplayCheckbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(521, 590);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Position";
            // 
            // posDisplayCheckbox
            // 
            this.posDisplayCheckbox.AutoSize = true;
            this.posDisplayCheckbox.Checked = true;
            this.posDisplayCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.posDisplayCheckbox.Location = new System.Drawing.Point(7, 10);
            this.posDisplayCheckbox.Name = "posDisplayCheckbox";
            this.posDisplayCheckbox.Size = new System.Drawing.Size(90, 27);
            this.posDisplayCheckbox.TabIndex = 0;
            this.posDisplayCheckbox.Text = "Enabled";
            this.posDisplayCheckbox.UseVisualStyleBackColor = true;
            this.posDisplayCheckbox.CheckedChanged += new System.EventHandler(this.posDisplayCheckbox_CheckedChanged);
            // 
            // blockCoordsTabPage
            // 
            this.blockCoordsTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blockCoordsTabPage.Controls.Add(this.chatBlockCheckbox);
            this.blockCoordsTabPage.Controls.Add(this.label1);
            this.blockCoordsTabPage.Controls.Add(this.blockCoordsCheckbox);
            this.blockCoordsTabPage.Location = new System.Drawing.Point(4, 32);
            this.blockCoordsTabPage.Name = "blockCoordsTabPage";
            this.blockCoordsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.blockCoordsTabPage.Size = new System.Drawing.Size(521, 590);
            this.blockCoordsTabPage.TabIndex = 2;
            this.blockCoordsTabPage.Text = "Block Coords";
            // 
            // chatBlockCheckbox
            // 
            this.chatBlockCheckbox.AutoSize = true;
            this.chatBlockCheckbox.Checked = true;
            this.chatBlockCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chatBlockCheckbox.Location = new System.Drawing.Point(7, 71);
            this.chatBlockCheckbox.Name = "chatBlockCheckbox";
            this.chatBlockCheckbox.Size = new System.Drawing.Size(185, 27);
            this.chatBlockCheckbox.TabIndex = 2;
            this.chatBlockCheckbox.Text = "Display while in chat";
            this.chatBlockCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shows the coordinates of the block you\'re looking at. ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blockCoordsCheckbox
            // 
            this.blockCoordsCheckbox.AutoSize = true;
            this.blockCoordsCheckbox.Location = new System.Drawing.Point(7, 10);
            this.blockCoordsCheckbox.Name = "blockCoordsCheckbox";
            this.blockCoordsCheckbox.Size = new System.Drawing.Size(90, 27);
            this.blockCoordsCheckbox.TabIndex = 0;
            this.blockCoordsCheckbox.Text = "Enabled";
            this.blockCoordsCheckbox.UseVisualStyleBackColor = true;
            this.blockCoordsCheckbox.CheckedChanged += new System.EventHandler(this.blockCoordsCheckbox_CheckedChanged);
            // 
            // blockDisplayText
            // 
            this.blockDisplayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blockDisplayText.AutoSize = true;
            this.blockDisplayText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.blockDisplayText.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockDisplayText.Location = new System.Drawing.Point(17, 590);
            this.blockDisplayText.Name = "blockDisplayText";
            this.blockDisplayText.Size = new System.Drawing.Size(35, 29);
            this.blockDisplayText.TabIndex = 0;
            this.blockDisplayText.Text = "??";
            this.blockDisplayText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blockDisplayText_MouseDown);
            this.blockDisplayText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blockDisplayText_MouseMove);
            // 
            // keyStrokes_W
            // 
            this.keyStrokes_W.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokes_W.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.keyStrokes_W.Controls.Add(this.keystrokeLabel);
            this.keyStrokes_W.Location = new System.Drawing.Point(94, 44);
            this.keyStrokes_W.Name = "keyStrokes_W";
            this.keyStrokes_W.Size = new System.Drawing.Size(60, 60);
            this.keyStrokes_W.TabIndex = 0;
            // 
            // keystrokeLabel
            // 
            this.keystrokeLabel.AutoSize = true;
            this.keystrokeLabel.Font = new System.Drawing.Font("Calibri", 18F);
            this.keystrokeLabel.Location = new System.Drawing.Point(13, 16);
            this.keystrokeLabel.Name = "keystrokeLabel";
            this.keystrokeLabel.Size = new System.Drawing.Size(34, 29);
            this.keystrokeLabel.TabIndex = 0;
            this.keystrokeLabel.Text = "W";
            // 
            // keyStrokes_S
            // 
            this.keyStrokes_S.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokes_S.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.keyStrokes_S.Controls.Add(this.kLabel2);
            this.keyStrokes_S.Location = new System.Drawing.Point(94, 110);
            this.keyStrokes_S.Name = "keyStrokes_S";
            this.keyStrokes_S.Size = new System.Drawing.Size(60, 60);
            this.keyStrokes_S.TabIndex = 1;
            // 
            // kLabel2
            // 
            this.kLabel2.AutoSize = true;
            this.kLabel2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kLabel2.Location = new System.Drawing.Point(18, 16);
            this.kLabel2.Name = "kLabel2";
            this.kLabel2.Size = new System.Drawing.Size(24, 29);
            this.kLabel2.TabIndex = 1;
            this.kLabel2.Text = "S";
            // 
            // keyStrokes_A
            // 
            this.keyStrokes_A.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokes_A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.keyStrokes_A.Controls.Add(this.kLabel3);
            this.keyStrokes_A.Location = new System.Drawing.Point(28, 110);
            this.keyStrokes_A.Name = "keyStrokes_A";
            this.keyStrokes_A.Size = new System.Drawing.Size(60, 60);
            this.keyStrokes_A.TabIndex = 2;
            // 
            // kLabel3
            // 
            this.kLabel3.AutoSize = true;
            this.kLabel3.Font = new System.Drawing.Font("Calibri", 18F);
            this.kLabel3.Location = new System.Drawing.Point(18, 16);
            this.kLabel3.Name = "kLabel3";
            this.kLabel3.Size = new System.Drawing.Size(27, 29);
            this.kLabel3.TabIndex = 3;
            this.kLabel3.Text = "A";
            // 
            // keyStrokes_D
            // 
            this.keyStrokes_D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokes_D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.keyStrokes_D.Controls.Add(this.kLabel4);
            this.keyStrokes_D.Location = new System.Drawing.Point(160, 110);
            this.keyStrokes_D.Name = "keyStrokes_D";
            this.keyStrokes_D.Size = new System.Drawing.Size(60, 60);
            this.keyStrokes_D.TabIndex = 3;
            // 
            // kLabel4
            // 
            this.kLabel4.AutoSize = true;
            this.kLabel4.Font = new System.Drawing.Font("Calibri", 18F);
            this.kLabel4.Location = new System.Drawing.Point(18, 16);
            this.kLabel4.Name = "kLabel4";
            this.kLabel4.Size = new System.Drawing.Size(28, 29);
            this.kLabel4.TabIndex = 2;
            this.kLabel4.Text = "D";
            // 
            // Keystrokes_LMB
            // 
            this.Keystrokes_LMB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Keystrokes_LMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.Keystrokes_LMB.Controls.Add(this.LMBCounter);
            this.Keystrokes_LMB.Controls.Add(this.LMBLabel);
            this.Keystrokes_LMB.Controls.Add(this.LMB);
            this.Keystrokes_LMB.Location = new System.Drawing.Point(28, 176);
            this.Keystrokes_LMB.Name = "Keystrokes_LMB";
            this.Keystrokes_LMB.Size = new System.Drawing.Size(91, 55);
            this.Keystrokes_LMB.TabIndex = 1;
            // 
            // LMBCounter
            // 
            this.LMBCounter.AutoSize = true;
            this.LMBCounter.Location = new System.Drawing.Point(20, 30);
            this.LMBCounter.Name = "LMBCounter";
            this.LMBCounter.Size = new System.Drawing.Size(53, 23);
            this.LMBCounter.TabIndex = 2;
            this.LMBCounter.Text = "0 CPS";
            this.LMBCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LMBLabel
            // 
            this.LMBLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMBLabel.Location = new System.Drawing.Point(19, 2);
            this.LMBLabel.Name = "LMBLabel";
            this.LMBLabel.Size = new System.Drawing.Size(68, 28);
            this.LMBLabel.TabIndex = 1;
            this.LMBLabel.Text = "LMB";
            // 
            // LMB
            // 
            this.LMB.AutoSize = true;
            this.LMB.Location = new System.Drawing.Point(16, 8);
            this.LMB.Name = "LMB";
            this.LMB.Size = new System.Drawing.Size(0, 23);
            this.LMB.TabIndex = 0;
            // 
            // Keystrokes_RMB
            // 
            this.Keystrokes_RMB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Keystrokes_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.Keystrokes_RMB.Controls.Add(this.RMBCounter);
            this.Keystrokes_RMB.Controls.Add(this.RMBLabel);
            this.Keystrokes_RMB.Location = new System.Drawing.Point(126, 176);
            this.Keystrokes_RMB.Name = "Keystrokes_RMB";
            this.Keystrokes_RMB.Size = new System.Drawing.Size(95, 55);
            this.Keystrokes_RMB.TabIndex = 2;
            // 
            // RMBCounter
            // 
            this.RMBCounter.AutoSize = true;
            this.RMBCounter.Location = new System.Drawing.Point(22, 30);
            this.RMBCounter.Name = "RMBCounter";
            this.RMBCounter.Size = new System.Drawing.Size(53, 23);
            this.RMBCounter.TabIndex = 2;
            this.RMBCounter.Text = "0 CPS";
            this.RMBCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RMBLabel
            // 
            this.RMBLabel.AutoSize = true;
            this.RMBLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RMBLabel.Location = new System.Drawing.Point(19, 2);
            this.RMBLabel.Name = "RMBLabel";
            this.RMBLabel.Size = new System.Drawing.Size(60, 29);
            this.RMBLabel.TabIndex = 2;
            this.RMBLabel.Text = "RMB";
            // 
            // spaceBarPanel
            // 
            this.spaceBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spaceBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.spaceBarPanel.Controls.Add(this.spaceBarBox);
            this.spaceBarPanel.Location = new System.Drawing.Point(28, 237);
            this.spaceBarPanel.Name = "spaceBarPanel";
            this.spaceBarPanel.Size = new System.Drawing.Size(192, 37);
            this.spaceBarPanel.TabIndex = 2;
            // 
            // spaceBarBox
            // 
            this.spaceBarBox.BackColor = System.Drawing.Color.White;
            this.spaceBarBox.Location = new System.Drawing.Point(53, 17);
            this.spaceBarBox.Name = "spaceBarBox";
            this.spaceBarBox.Size = new System.Drawing.Size(87, 3);
            this.spaceBarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spaceBarBox.TabIndex = 0;
            this.spaceBarBox.TabStop = false;
            // 
            // keystrokesPanel
            // 
            this.keystrokesPanel.BackColor = System.Drawing.Color.Transparent;
            this.keystrokesPanel.Controls.Add(this.spaceBarPanel);
            this.keystrokesPanel.Controls.Add(this.Keystrokes_RMB);
            this.keystrokesPanel.Controls.Add(this.Keystrokes_LMB);
            this.keystrokesPanel.Controls.Add(this.keyStrokes_D);
            this.keystrokesPanel.Controls.Add(this.keyStrokes_A);
            this.keystrokesPanel.Controls.Add(this.keyStrokes_S);
            this.keystrokesPanel.Controls.Add(this.keyStrokes_W);
            this.keystrokesPanel.Location = new System.Drawing.Point(14, 14);
            this.keystrokesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keystrokesPanel.Name = "keystrokesPanel";
            this.keystrokesPanel.Size = new System.Drawing.Size(251, 313);
            this.keystrokesPanel.TabIndex = 0;
            this.keystrokesPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keystrokesPanel_MouseDown);
            this.keystrokesPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.keystrokesPanel_MouseMove);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Latite.Properties.Resources.transparentimg;
            this.ClientSize = new System.Drawing.Size(1001, 730);
            this.Controls.Add(this.blockDisplayText);
            this.Controls.Add(this.settingsTabControl);
            this.Controls.Add(this.settingsCheckBox);
            this.Controls.Add(this.toggleSprintLabel);
            this.Controls.Add(this.posPanel);
            this.Controls.Add(this.keystrokesPanel);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Overlay";
            this.ShowInTaskbar = false;
            this.Text = "Overlay";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(31)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overlay_FormClosing);
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.posPanel.ResumeLayout(false);
            this.posPanel.PerformLayout();
            this.settingsTabControl.ResumeLayout(false);
            this.keystrokesTabPage.ResumeLayout(false);
            this.keystrokesTabPage.PerformLayout();
            this.keystrokesSettingsPanel.ResumeLayout(false);
            this.keystrokesSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesBlueTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesGreenTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keystrokesRedTrackbar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.blockCoordsTabPage.ResumeLayout(false);
            this.blockCoordsTabPage.PerformLayout();
            this.keyStrokes_W.ResumeLayout(false);
            this.keyStrokes_W.PerformLayout();
            this.keyStrokes_S.ResumeLayout(false);
            this.keyStrokes_S.PerformLayout();
            this.keyStrokes_A.ResumeLayout(false);
            this.keyStrokes_A.PerformLayout();
            this.keyStrokes_D.ResumeLayout(false);
            this.keyStrokes_D.PerformLayout();
            this.Keystrokes_LMB.ResumeLayout(false);
            this.Keystrokes_LMB.PerformLayout();
            this.Keystrokes_RMB.ResumeLayout(false);
            this.Keystrokes_RMB.PerformLayout();
            this.spaceBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spaceBarBox)).EndInit();
            this.keystrokesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label motionLabel;
        private System.Windows.Forms.Label motionYLabel;
        private System.Windows.Forms.Panel posPanel;
        private System.Windows.Forms.Label zPosLabel;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label motionTopLabel;
        private System.Windows.Forms.Label toggleSprintLabel;
        private System.Windows.Forms.CheckBox settingsCheckBox;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage keystrokesTabPage;
        private System.Windows.Forms.CheckBox keystrokesCheckBox;
        private System.Windows.Forms.Panel keystrokesSettingsPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar keystrokesBlueTrackbar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar keystrokesGreenTrackbar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar keystrokesRedTrackbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox posDisplayCheckbox;
        private System.Windows.Forms.TabPage blockCoordsTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox blockCoordsCheckbox;
        private System.Windows.Forms.Label blockDisplayText;
        private System.Windows.Forms.CheckBox chatBlockCheckbox;
        private System.Windows.Forms.Panel keyStrokes_W;
        private System.Windows.Forms.Label keystrokeLabel;
        private System.Windows.Forms.Panel keyStrokes_S;
        private System.Windows.Forms.Label kLabel2;
        private System.Windows.Forms.Panel keyStrokes_A;
        private System.Windows.Forms.Label kLabel3;
        private System.Windows.Forms.Panel keyStrokes_D;
        private System.Windows.Forms.Label kLabel4;
        private System.Windows.Forms.Panel Keystrokes_LMB;
        private System.Windows.Forms.Label LMBCounter;
        private System.Windows.Forms.Label LMBLabel;
        private System.Windows.Forms.Label LMB;
        private System.Windows.Forms.Panel Keystrokes_RMB;
        private System.Windows.Forms.Label RMBCounter;
        private System.Windows.Forms.Label RMBLabel;
        private System.Windows.Forms.Panel spaceBarPanel;
        private System.Windows.Forms.PictureBox spaceBarBox;
        private System.Windows.Forms.Panel keystrokesPanel;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.ComponentModel.BackgroundWorker secondRunner;
    }
}