
namespace DBtest.chess
{
    partial class ChessForm
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
            this.components = new System.ComponentModel.Container();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.turnLabel = new System.Windows.Forms.Label();
            this.tmrLabel = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.turnBox = new System.Windows.Forms.TextBox();
            this.tmrTxt = new System.Windows.Forms.Label();
            this.txt_all = new System.Windows.Forms.TextBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(32, 55);
            this.boardPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(686, 750);
            this.boardPanel.TabIndex = 0;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.turnLabel.Location = new System.Drawing.Point(806, 54);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(88, 27);
            this.turnLabel.TabIndex = 1;
            this.turnLabel.Text = "TURN";
            // 
            // tmrLabel
            // 
            this.tmrLabel.AutoSize = true;
            this.tmrLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrLabel.Location = new System.Drawing.Point(985, 54);
            this.tmrLabel.Name = "tmrLabel";
            this.tmrLabel.Size = new System.Drawing.Size(97, 27);
            this.tmrLabel.TabIndex = 1;
            this.tmrLabel.Text = "TIMER";
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // turnBox
            // 
            this.turnBox.BackColor = System.Drawing.Color.White;
            this.turnBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.turnBox.Location = new System.Drawing.Point(786, 97);
            this.turnBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.turnBox.Multiline = true;
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(120, 51);
            this.turnBox.TabIndex = 2;
            // 
            // tmrTxt
            // 
            this.tmrTxt.AutoSize = true;
            this.tmrTxt.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrTxt.Location = new System.Drawing.Point(1008, 109);
            this.tmrTxt.Name = "tmrTxt";
            this.tmrTxt.Size = new System.Drawing.Size(28, 27);
            this.tmrTxt.TabIndex = 3;
            this.tmrTxt.Text = "0";
            // 
            // txt_all
            // 
            this.txt_all.Location = new System.Drawing.Point(756, 198);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.ReadOnly = true;
            this.txt_all.Size = new System.Drawing.Size(365, 450);
            this.txt_all.TabIndex = 4;
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(756, 682);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(365, 25);
            this.txt_msg.TabIndex = 5;
            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // toolBar1
            // 
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1145, 42);
            this.toolBar1.TabIndex = 6;
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 862);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.txt_all);
            this.Controls.Add(this.tmrTxt);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.tmrLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.boardPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChessForm";
            this.Text = "5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChessForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label tmrLabel;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.TextBox turnBox;
        private System.Windows.Forms.Label tmrTxt;
        private System.Windows.Forms.TextBox txt_all;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.ToolBar toolBar1;
    }
}