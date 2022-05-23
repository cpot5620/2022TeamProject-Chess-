
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
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.teamLabel = new System.Windows.Forms.Label();
            this.teamTxt = new System.Windows.Forms.Label();
            this.whitePieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.blackPieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(40, 66);
            this.boardPanel.Margin = new System.Windows.Forms.Padding(4);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(857, 900);
            this.boardPanel.TabIndex = 0;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.turnLabel.Location = new System.Drawing.Point(1127, 66);
            this.turnLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(104, 32);
            this.turnLabel.TabIndex = 1;
            this.turnLabel.Text = "TURN";
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrLabel
            // 
            this.tmrLabel.AutoSize = true;
            this.tmrLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrLabel.Location = new System.Drawing.Point(1283, 66);
            this.tmrLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tmrLabel.Name = "tmrLabel";
            this.tmrLabel.Size = new System.Drawing.Size(115, 32);
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
            this.turnBox.Location = new System.Drawing.Point(1103, 118);
            this.turnBox.Margin = new System.Windows.Forms.Padding(4);
            this.turnBox.Multiline = true;
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(150, 62);
            this.turnBox.TabIndex = 2;
            // 
            // tmrTxt
            // 
            this.tmrTxt.AutoSize = true;
            this.tmrTxt.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmrTxt.Location = new System.Drawing.Point(1280, 134);
            this.tmrTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tmrTxt.Name = "tmrTxt";
            this.tmrTxt.Size = new System.Drawing.Size(120, 32);
            this.tmrTxt.TabIndex = 3;
            this.tmrTxt.Text = "READY";
            this.tmrTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_all
            // 
            this.txt_all.Location = new System.Drawing.Point(946, 237);
            this.txt_all.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.ReadOnly = true;
            this.txt_all.Size = new System.Drawing.Size(455, 540);
            this.txt_all.TabIndex = 4;
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(946, 819);
            this.txt_msg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(455, 28);
            this.txt_msg.TabIndex = 5;
            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // toolBar1
            // 
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1431, 42);
            this.toolBar1.TabIndex = 6;
            // 
            // teamLabel
            // 
            this.teamLabel.AutoSize = true;
            this.teamLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamLabel.Location = new System.Drawing.Point(940, 66);
            this.teamLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(105, 32);
            this.teamLabel.TabIndex = 1;
            this.teamLabel.Text = "TEAM";
            this.teamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // teamTxt
            // 
            this.teamTxt.AutoSize = true;
            this.teamTxt.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamTxt.Location = new System.Drawing.Point(944, 134);
            this.teamTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.teamTxt.Name = "teamTxt";
            this.teamTxt.Size = new System.Drawing.Size(101, 32);
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
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 1035);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.txt_all);
            this.Controls.Add(this.teamTxt);
            this.Controls.Add(this.tmrTxt);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.tmrLabel);
            this.Controls.Add(this.teamLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.boardPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label teamLabel;
        private System.Windows.Forms.Label teamTxt;
        private System.Windows.Forms.ImageList whitePieceImgList;
        private System.Windows.Forms.ImageList blackPieceImgList;
    }
}