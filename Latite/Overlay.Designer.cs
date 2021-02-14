
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
            this.keystrokesPanel = new System.Windows.Forms.Panel();
            this.spaceBarPanel = new System.Windows.Forms.Panel();
            this.spaceBarBox = new System.Windows.Forms.PictureBox();
            this.Keystrokes_RMB = new System.Windows.Forms.Panel();
            this.RMBCounter = new System.Windows.Forms.Label();
            this.RMBLabel = new System.Windows.Forms.Label();
            this.Keystrokes_LMB = new System.Windows.Forms.Panel();
            this.LMBCounter = new System.Windows.Forms.Label();
            this.LMBLabel = new System.Windows.Forms.Label();
            this.LMB = new System.Windows.Forms.Label();
            this.keyStrokes_D = new System.Windows.Forms.Panel();
            this.kLabel4 = new System.Windows.Forms.Label();
            this.keyStrokes_A = new System.Windows.Forms.Panel();
            this.kLabel3 = new System.Windows.Forms.Label();
            this.keyStrokes_S = new System.Windows.Forms.Panel();
            this.kLabel2 = new System.Windows.Forms.Label();
            this.keyStrokes_W = new System.Windows.Forms.Panel();
            this.keystrokeLabel = new System.Windows.Forms.Label();
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
            this.keystrokesPanel.SuspendLayout();
            this.spaceBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceBarBox)).BeginInit();
            this.Keystrokes_RMB.SuspendLayout();
            this.Keystrokes_LMB.SuspendLayout();
            this.keyStrokes_D.SuspendLayout();
            this.keyStrokes_A.SuspendLayout();
            this.keyStrokes_S.SuspendLayout();
            this.keyStrokes_W.SuspendLayout();
            this.posPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.keystrokesPanel.Margin = new System.Windows.Forms.Padding(5);
            this.keystrokesPanel.Name = "keystrokesPanel";
            this.keystrokesPanel.Size = new System.Drawing.Size(251, 313);
            this.keystrokesPanel.TabIndex = 0;
            this.keystrokesPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keystrokesPanel_MouseDown);
            this.keystrokesPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.keystrokesPanel_MouseMove);
            // 
            // spaceBarPanel
            // 
            this.spaceBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.spaceBarPanel.Controls.Add(this.spaceBarBox);
            this.spaceBarPanel.Location = new System.Drawing.Point(28, 176);
            this.spaceBarPanel.Name = "spaceBarPanel";
            this.spaceBarPanel.Size = new System.Drawing.Size(192, 37);
            this.spaceBarPanel.TabIndex = 2;
            // 
            // spaceBarBox
            // 
            this.spaceBarBox.BackColor = System.Drawing.Color.White;
            this.spaceBarBox.Location = new System.Drawing.Point(52, 17);
            this.spaceBarBox.Name = "spaceBarBox";
            this.spaceBarBox.Size = new System.Drawing.Size(82, 3);
            this.spaceBarBox.TabIndex = 0;
            this.spaceBarBox.TabStop = false;
            // 
            // Keystrokes_RMB
            // 
            this.Keystrokes_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.Keystrokes_RMB.Controls.Add(this.RMBCounter);
            this.Keystrokes_RMB.Controls.Add(this.RMBLabel);
            this.Keystrokes_RMB.Location = new System.Drawing.Point(129, 217);
            this.Keystrokes_RMB.Name = "Keystrokes_RMB";
            this.Keystrokes_RMB.Size = new System.Drawing.Size(91, 55);
            this.Keystrokes_RMB.TabIndex = 2;
            // 
            // RMBCounter
            // 
            this.RMBCounter.AutoSize = true;
            this.RMBCounter.Location = new System.Drawing.Point(18, 30);
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
            this.RMBLabel.Location = new System.Drawing.Point(15, 2);
            this.RMBLabel.Name = "RMBLabel";
            this.RMBLabel.Size = new System.Drawing.Size(60, 29);
            this.RMBLabel.TabIndex = 2;
            this.RMBLabel.Text = "RMB";
            // 
            // Keystrokes_LMB
            // 
            this.Keystrokes_LMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.Keystrokes_LMB.Controls.Add(this.LMBCounter);
            this.Keystrokes_LMB.Controls.Add(this.LMBLabel);
            this.Keystrokes_LMB.Controls.Add(this.LMB);
            this.Keystrokes_LMB.Location = new System.Drawing.Point(27, 217);
            this.Keystrokes_LMB.Name = "Keystrokes_LMB";
            this.Keystrokes_LMB.Size = new System.Drawing.Size(86, 55);
            this.Keystrokes_LMB.TabIndex = 1;
            // 
            // LMBCounter
            // 
            this.LMBCounter.AutoSize = true;
            this.LMBCounter.Location = new System.Drawing.Point(16, 30);
            this.LMBCounter.Name = "LMBCounter";
            this.LMBCounter.Size = new System.Drawing.Size(53, 23);
            this.LMBCounter.TabIndex = 2;
            this.LMBCounter.Text = "0 CPS";
            this.LMBCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LMBLabel
            // 
            this.LMBLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMBLabel.Location = new System.Drawing.Point(15, 2);
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
            // keyStrokes_D
            // 
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
            this.kLabel4.Location = new System.Drawing.Point(17, 17);
            this.kLabel4.Name = "kLabel4";
            this.kLabel4.Size = new System.Drawing.Size(22, 23);
            this.kLabel4.TabIndex = 2;
            this.kLabel4.Text = "D";
            // 
            // keyStrokes_A
            // 
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
            this.kLabel3.Location = new System.Drawing.Point(19, 17);
            this.kLabel3.Name = "kLabel3";
            this.kLabel3.Size = new System.Drawing.Size(21, 23);
            this.kLabel3.TabIndex = 3;
            this.kLabel3.Text = "A";
            // 
            // keyStrokes_S
            // 
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
            this.kLabel2.Location = new System.Drawing.Point(20, 17);
            this.kLabel2.Name = "kLabel2";
            this.kLabel2.Size = new System.Drawing.Size(19, 23);
            this.kLabel2.TabIndex = 1;
            this.kLabel2.Text = "S";
            // 
            // keyStrokes_W
            // 
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
            this.keystrokeLabel.Location = new System.Drawing.Point(16, 18);
            this.keystrokeLabel.Name = "keystrokeLabel";
            this.keystrokeLabel.Size = new System.Drawing.Size(27, 23);
            this.keystrokeLabel.TabIndex = 0;
            this.keystrokeLabel.Text = "W";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // secondRunner
            // 
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
            this.posPanel.Location = new System.Drawing.Point(12, 340);
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
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Latite.Properties.Resources.transparentimg;
            this.ClientSize = new System.Drawing.Size(969, 730);
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
            this.keystrokesPanel.ResumeLayout(false);
            this.spaceBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spaceBarBox)).EndInit();
            this.Keystrokes_RMB.ResumeLayout(false);
            this.Keystrokes_RMB.PerformLayout();
            this.Keystrokes_LMB.ResumeLayout(false);
            this.Keystrokes_LMB.PerformLayout();
            this.keyStrokes_D.ResumeLayout(false);
            this.keyStrokes_D.PerformLayout();
            this.keyStrokes_A.ResumeLayout(false);
            this.keyStrokes_A.PerformLayout();
            this.keyStrokes_S.ResumeLayout(false);
            this.keyStrokes_S.PerformLayout();
            this.keyStrokes_W.ResumeLayout(false);
            this.keyStrokes_W.PerformLayout();
            this.posPanel.ResumeLayout(false);
            this.posPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel keystrokesPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel keyStrokes_W;
        private System.Windows.Forms.Panel keyStrokes_S;
        private System.Windows.Forms.Panel keyStrokes_A;
        private System.Windows.Forms.Panel keyStrokes_D;
        private System.Windows.Forms.Label kLabel4;
        private System.Windows.Forms.Label kLabel3;
        private System.Windows.Forms.Label kLabel2;
        private System.Windows.Forms.Label keystrokeLabel;
        private System.Windows.Forms.Panel Keystrokes_RMB;
        private System.Windows.Forms.Panel Keystrokes_LMB;
        private System.Windows.Forms.Label LMB;
        private System.Windows.Forms.Label LMBCounter;
        private System.Windows.Forms.Label RMBLabel;
        private System.Windows.Forms.Label LMBLabel;
        private System.ComponentModel.BackgroundWorker secondRunner;
        private System.Windows.Forms.Label motionLabel;
        private System.Windows.Forms.Label motionYLabel;
        private System.Windows.Forms.Panel posPanel;
        private System.Windows.Forms.Label zPosLabel;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label motionTopLabel;
        private System.Windows.Forms.Label toggleSprintLabel;
        private System.Windows.Forms.Label RMBCounter;
        private System.Windows.Forms.Panel spaceBarPanel;
        private System.Windows.Forms.PictureBox spaceBarBox;
    }
}