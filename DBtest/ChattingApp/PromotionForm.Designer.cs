
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQueen
            // 
            this.btnQueen.BackColor = System.Drawing.Color.BurlyWood;
            this.btnQueen.Location = new System.Drawing.Point(46, 114);
            this.btnQueen.Name = "btnQueen";
            this.btnQueen.Size = new System.Drawing.Size(112, 102);
            this.btnQueen.TabIndex = 0;
            this.btnQueen.UseVisualStyleBackColor = false;
            this.btnQueen.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnBishop
            // 
            this.btnBishop.BackColor = System.Drawing.Color.BurlyWood;
            this.btnBishop.Location = new System.Drawing.Point(192, 114);
            this.btnBishop.Name = "btnBishop";
            this.btnBishop.Size = new System.Drawing.Size(112, 102);
            this.btnBishop.TabIndex = 0;
            this.btnBishop.UseVisualStyleBackColor = false;
            this.btnBishop.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnRook
            // 
            this.btnRook.BackColor = System.Drawing.Color.BurlyWood;
            this.btnRook.Location = new System.Drawing.Point(345, 114);
            this.btnRook.Name = "btnRook";
            this.btnRook.Size = new System.Drawing.Size(112, 102);
            this.btnRook.TabIndex = 0;
            this.btnRook.UseVisualStyleBackColor = false;
            this.btnRook.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnKnight
            // 
            this.btnKnight.BackColor = System.Drawing.Color.BurlyWood;
            this.btnKnight.Location = new System.Drawing.Point(495, 114);
            this.btnKnight.Name = "btnKnight";
            this.btnKnight.Size = new System.Drawing.Size(112, 102);
            this.btnKnight.TabIndex = 0;
            this.btnKnight.UseVisualStyleBackColor = false;
            this.btnKnight.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(176, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "폰이 상대방의 최종열에 도달했습니다!\r\n원하는 기물로 폰을 바꾸십시오\r\n\r\n";
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
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnQueen);
            this.panel1.Controls.Add(this.btnKnight);
            this.panel1.Controls.Add(this.btnBishop);
            this.panel1.Controls.Add(this.btnRook);
            this.panel1.Location = new System.Drawing.Point(1, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 261);
            this.panel1.TabIndex = 2;
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 285);
            this.Controls.Add(this.panel1);
            this.Name = "PromotionForm";
            this.Padding = new System.Windows.Forms.Padding(14, 40, 14, 13);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQueen;
        private System.Windows.Forms.Button btnBishop;
        private System.Windows.Forms.Button btnRook;
        private System.Windows.Forms.Button btnKnight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList blackPieceImgList;
        private System.Windows.Forms.ImageList whitePieceImgList;
        private System.Windows.Forms.Panel panel1;
    }
}