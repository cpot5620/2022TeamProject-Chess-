
namespace ChattingApp
{
    partial class PromotionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionForm));
            this.btnQueen = new System.Windows.Forms.Button();
            this.btnBishop = new System.Windows.Forms.Button();
            this.btnRook = new System.Windows.Forms.Button();
            this.btnKnight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.blackPieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.whitePieceImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnQueen
            // 
            this.btnQueen.BackColor = System.Drawing.Color.BurlyWood;
            this.btnQueen.Location = new System.Drawing.Point(31, 147);
            this.btnQueen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQueen.Name = "btnQueen";
            this.btnQueen.Size = new System.Drawing.Size(160, 153);
            this.btnQueen.TabIndex = 0;
            this.btnQueen.UseVisualStyleBackColor = false;
            this.btnQueen.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnBishop
            // 
            this.btnBishop.BackColor = System.Drawing.Color.BurlyWood;
            this.btnBishop.Location = new System.Drawing.Point(240, 147);
            this.btnBishop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBishop.Name = "btnBishop";
            this.btnBishop.Size = new System.Drawing.Size(160, 153);
            this.btnBishop.TabIndex = 0;
            this.btnBishop.UseVisualStyleBackColor = false;
            this.btnBishop.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnRook
            // 
            this.btnRook.BackColor = System.Drawing.Color.BurlyWood;
            this.btnRook.Location = new System.Drawing.Point(459, 147);
            this.btnRook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRook.Name = "btnRook";
            this.btnRook.Size = new System.Drawing.Size(160, 153);
            this.btnRook.TabIndex = 0;
            this.btnRook.UseVisualStyleBackColor = false;
            this.btnRook.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnKnight
            // 
            this.btnKnight.BackColor = System.Drawing.Color.BurlyWood;
            this.btnKnight.Location = new System.Drawing.Point(673, 147);
            this.btnKnight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKnight.Name = "btnKnight";
            this.btnKnight.Size = new System.Drawing.Size(160, 153);
            this.btnKnight.TabIndex = 0;
            this.btnKnight.UseVisualStyleBackColor = false;
            this.btnKnight.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(217, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "폰이 상대방의 최종열에 도달했습니다!\r\n폰을 아래의 기물들로 바꿀수 있습니다. \r\n원하는 기물을 선택하세요.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blackPieceImgList
            // 
            this.blackPieceImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blackPieceImgList.ImageStream")));
            this.blackPieceImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.blackPieceImgList.Images.SetKeyName(0, "queenB.png");
            this.blackPieceImgList.Images.SetKeyName(1, "bishopB.png");
            this.blackPieceImgList.Images.SetKeyName(2, "rookB.png");
            this.blackPieceImgList.Images.SetKeyName(3, "knightB.png");
            // 
            // whitePieceImgList
            // 
            this.whitePieceImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("whitePieceImgList.ImageStream")));
            this.whitePieceImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.whitePieceImgList.Images.SetKeyName(0, "queenW.png");
            this.whitePieceImgList.Images.SetKeyName(1, "bishopW.png");
            this.whitePieceImgList.Images.SetKeyName(2, "rookW.png");
            this.whitePieceImgList.Images.SetKeyName(3, "knightW.png");
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKnight);
            this.Controls.Add(this.btnRook);
            this.Controls.Add(this.btnBishop);
            this.Controls.Add(this.btnQueen);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PromotionForm";
            this.Text = "PromotionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQueen;
        private System.Windows.Forms.Button btnBishop;
        private System.Windows.Forms.Button btnRook;
        private System.Windows.Forms.Button btnKnight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList blackPieceImgList;
        private System.Windows.Forms.ImageList whitePieceImgList;
    }
}