
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessForm));
            this.boardPanel = new System.Windows.Forms.Panel();
            this.turnLabel = new System.Windows.Forms.Label();
            this.tmrLabel = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.turnBox = new System.Windows.Forms.TextBox();
            this.tmrTxt = new System.Windows.Forms.Label();
            this.txt_all = new System.Windows.Forms.TextBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.teamLabel = new System.Windows.Forms.Label();
            this.teamTxt = new System.Windows.Forms.Label();
            this.whitePieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.blackPieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(33, 40);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(600, 600);
            this.boardPanel.TabIndex = 0;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.BackColor = System.Drawing.Color.Transparent;
            this.turnLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.ForeColor = System.Drawing.Color.Tan;
            this.turnLabel.Location = new System.Drawing.Point(831, 40);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(92, 27);
            this.turnLabel.TabIndex = 1;
            this.turnLabel.Text = "TURN";
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrLabel
            // 
            this.tmrLabel.AutoSize = true;
            this.tmrLabel.BackColor = System.Drawing.Color.Transparent;
            this.tmrLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmrLabel.ForeColor = System.Drawing.Color.Tan;
            this.tmrLabel.Location = new System.Drawing.Point(940, 40);
            this.tmrLabel.Name = "tmrLabel";
            this.tmrLabel.Size = new System.Drawing.Size(98, 27);
            this.tmrLabel.TabIndex = 1;
            this.tmrLabel.Text = "TIMER";
            this.tmrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.turnBox.Location = new System.Drawing.Point(818, 85);
            this.turnBox.Multiline = true;
            this.turnBox.Name = "turnBox";
            this.turnBox.ReadOnly = true;
            this.turnBox.Size = new System.Drawing.Size(105, 27);
            this.turnBox.TabIndex = 2;
            // 
            // tmrTxt
            // 
            this.tmrTxt.AutoSize = true;
            this.tmrTxt.BackColor = System.Drawing.Color.Transparent;
            this.tmrTxt.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmrTxt.ForeColor = System.Drawing.Color.Tan;
            this.tmrTxt.Location = new System.Drawing.Point(938, 85);
            this.tmrTxt.Name = "tmrTxt";
            this.tmrTxt.Size = new System.Drawing.Size(102, 27);
            this.tmrTxt.TabIndex = 3;
            this.tmrTxt.Text = "READY";
            this.tmrTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_all
            // 
            this.txt_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_all.Location = new System.Drawing.Point(704, 147);
            this.txt_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.ReadOnly = true;
            this.txt_all.Size = new System.Drawing.Size(334, 445);
            this.txt_all.TabIndex = 4;
            // 
            // txt_msg
            // 
            this.txt_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_msg.Location = new System.Drawing.Point(704, 614);
            this.txt_msg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(334, 26);
            this.txt_msg.TabIndex = 5;
            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // teamLabel
            // 
            this.teamLabel.AutoSize = true;
            this.teamLabel.BackColor = System.Drawing.Color.Transparent;
            this.teamLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamLabel.ForeColor = System.Drawing.Color.Tan;
            this.teamLabel.Location = new System.Drawing.Point(700, 40);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(90, 27);
            this.teamLabel.TabIndex = 1;
            this.teamLabel.Text = "TEAM";
            this.teamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // teamTxt
            // 
            this.teamTxt.AutoSize = true;
            this.teamTxt.BackColor = System.Drawing.Color.Transparent;
            this.teamTxt.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTxt.ForeColor = System.Drawing.Color.Tan;
            this.teamTxt.Location = new System.Drawing.Point(703, 85);
            this.teamTxt.Name = "teamTxt";
            this.teamTxt.Size = new System.Drawing.Size(86, 27);
            this.teamTxt.TabIndex = 3;
            this.teamTxt.Text = "TEAM";
            this.teamTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whitePieceImgList
            // 
            this.whitePieceImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("whitePieceImgList.ImageStream")));
            this.whitePieceImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.whitePieceImgList.Images.SetKeyName(0, "kingW.png");
            this.whitePieceImgList.Images.SetKeyName(1, "queenW.png");
            this.whitePieceImgList.Images.SetKeyName(2, "bishopW.png");
            this.whitePieceImgList.Images.SetKeyName(3, "rookW.png");
            this.whitePieceImgList.Images.SetKeyName(4, "knightW.png");
            this.whitePieceImgList.Images.SetKeyName(5, "pawnW.png");
            // 
            // blackPieceImgList
            // 
            this.blackPieceImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blackPieceImgList.ImageStream")));
            this.blackPieceImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.blackPieceImgList.Images.SetKeyName(0, "kingB.png");
            this.blackPieceImgList.Images.SetKeyName(1, "queenB.png");
            this.blackPieceImgList.Images.SetKeyName(2, "bishopB.png");
            this.blackPieceImgList.Images.SetKeyName(3, "rookB.png");
            this.blackPieceImgList.Images.SetKeyName(4, "knightB.png");
            this.blackPieceImgList.Images.SetKeyName(5, "pawnB.png");
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.teamLabel);
            this.panel1.Controls.Add(this.boardPanel);
            this.panel1.Controls.Add(this.txt_msg);
            this.panel1.Controls.Add(this.turnLabel);
            this.panel1.Controls.Add(this.txt_all);
            this.panel1.Controls.Add(this.tmrLabel);
            this.panel1.Controls.Add(this.teamTxt);
            this.panel1.Controls.Add(this.turnBox);
            this.panel1.Controls.Add(this.tmrTxt);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 665);
            this.panel1.TabIndex = 6;
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 686);
            this.Controls.Add(this.panel1);
            this.Name = "ChessForm";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChessForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label teamLabel;
        private System.Windows.Forms.Label teamTxt;
        private System.Windows.Forms.ImageList whitePieceImgList;
        private System.Windows.Forms.ImageList blackPieceImgList;
        private System.Windows.Forms.Panel panel1;
    }
}