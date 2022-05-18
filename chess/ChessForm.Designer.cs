
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
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(29, 31);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(600, 600);
            this.boardPanel.TabIndex = 0;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.turnLabel.Location = new System.Drawing.Point(705, 31);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(63, 21);
            this.turnLabel.TabIndex = 1;
            this.turnLabel.Text = "TURN";
            // 
            // tmrLabel
            // 
            this.tmrLabel.AutoSize = true;
            this.tmrLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrLabel.Location = new System.Drawing.Point(862, 31);
            this.tmrLabel.Name = "tmrLabel";
            this.tmrLabel.Size = new System.Drawing.Size(69, 21);
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
            this.turnBox.Location = new System.Drawing.Point(688, 66);
            this.turnBox.Multiline = true;
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(105, 41);
            this.turnBox.TabIndex = 2;
            // 
            // tmrTxt
            // 
            this.tmrTxt.AutoSize = true;
            this.tmrTxt.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrTxt.Location = new System.Drawing.Point(882, 75);
            this.tmrTxt.Name = "tmrTxt";
            this.tmrTxt.Size = new System.Drawing.Size(21, 21);
            this.tmrTxt.TabIndex = 3;
            this.tmrTxt.Text = "0";
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 690);
            this.Controls.Add(this.tmrTxt);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.tmrLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.boardPanel);
            this.Name = "ChessForm";
            this.Text = "5";
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
    }
}