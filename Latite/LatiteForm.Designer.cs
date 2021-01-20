
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
            this.LatiteIcon1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.consoleButton = new System.Windows.Forms.Button();
            this.modsControl = new System.Windows.Forms.TabControl();
            this.modsTabPage = new System.Windows.Forms.TabPage();
            this.optionsTabControl = new System.Windows.Forms.TabPage();
            this.modsButton = new System.Windows.Forms.Button();
            this.DRPButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.consoleTab = new System.Windows.Forms.TabPage();
            this.consoleOutput = new System.Windows.Forms.RichTextBox();
            this.consoleInput = new System.Windows.Forms.TextBox();
            this.cinGo = new System.Windows.Forms.Button();
            this.settingsUseConsole = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LatiteIcon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.modsControl.SuspendLayout();
            this.optionsTabControl.SuspendLayout();
            this.consoleTab.SuspendLayout();
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 463);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
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
            this.consoleButton.TabIndex = 6;
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
            this.modsTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.modsTabPage.Location = new System.Drawing.Point(4, 35);
            this.modsTabPage.Name = "modsTabPage";
            this.modsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modsTabPage.Size = new System.Drawing.Size(587, 424);
            this.modsTabPage.TabIndex = 0;
            this.modsTabPage.Text = "Mods";
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.optionsTabControl.Controls.Add(this.settingsUseConsole);
            this.optionsTabControl.Location = new System.Drawing.Point(4, 35);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTabControl.Size = new System.Drawing.Size(587, 424);
            this.optionsTabControl.TabIndex = 1;
            this.optionsTabControl.Text = "Options";
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
            this.modsButton.TabIndex = 8;
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
            this.DRPButton.TabIndex = 9;
            this.DRPButton.Text = "DRP";
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
            this.optionsButton.TabIndex = 10;
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
            this.connectButton.TabIndex = 5;
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
            // consoleTab
            // 
            this.consoleTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.consoleTab.Controls.Add(this.cinGo);
            this.consoleTab.Controls.Add(this.consoleInput);
            this.consoleTab.Controls.Add(this.consoleOutput);
            this.consoleTab.Location = new System.Drawing.Point(4, 35);
            this.consoleTab.Name = "consoleTab";
            this.consoleTab.Padding = new System.Windows.Forms.Padding(3);
            this.consoleTab.Size = new System.Drawing.Size(587, 424);
            this.consoleTab.TabIndex = 2;
            this.consoleTab.Text = "Console";
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
            // LatiteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(704, 556);
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
            ((System.ComponentModel.ISupportInitialize)(this.LatiteIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.modsControl.ResumeLayout(false);
            this.optionsTabControl.ResumeLayout(false);
            this.optionsTabControl.PerformLayout();
            this.consoleTab.ResumeLayout(false);
            this.consoleTab.PerformLayout();
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
    }
}

