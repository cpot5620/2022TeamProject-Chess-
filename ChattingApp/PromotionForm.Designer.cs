
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
            this.btnQueen = new System.Windows.Forms.Button();
            this.btnBishop = new System.Windows.Forms.Button();
            this.btnRook = new System.Windows.Forms.Button();
            this.btnKnight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQueen
            // 
            this.btnQueen.Location = new System.Drawing.Point(22, 98);
            this.btnQueen.Name = "btnQueen";
            this.btnQueen.Size = new System.Drawing.Size(112, 102);
            this.btnQueen.TabIndex = 0;
            this.btnQueen.Text = "QUEEN";
            this.btnQueen.UseVisualStyleBackColor = true;
            this.btnQueen.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnBishop
            // 
            this.btnBishop.Location = new System.Drawing.Point(168, 98);
            this.btnBishop.Name = "btnBishop";
            this.btnBishop.Size = new System.Drawing.Size(112, 102);
            this.btnBishop.TabIndex = 0;
            this.btnBishop.Text = "BISHOP";
            this.btnBishop.UseVisualStyleBackColor = true;
            this.btnBishop.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnRook
            // 
            this.btnRook.Location = new System.Drawing.Point(321, 98);
            this.btnRook.Name = "btnRook";
            this.btnRook.Size = new System.Drawing.Size(112, 102);
            this.btnRook.TabIndex = 0;
            this.btnRook.Text = "ROOK";
            this.btnRook.UseVisualStyleBackColor = true;
            this.btnRook.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // btnKnight
            // 
            this.btnKnight.Location = new System.Drawing.Point(471, 98);
            this.btnKnight.Name = "btnKnight";
            this.btnKnight.Size = new System.Drawing.Size(112, 102);
            this.btnKnight.TabIndex = 0;
            this.btnKnight.Text = "KNIGHT";
            this.btnKnight.UseVisualStyleBackColor = true;
            this.btnKnight.Click += new System.EventHandler(this.btnPIeceName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(152, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "폰이 상대방의 최종열에 도달했습니다!\r\n폰을 아래의 기물들로 바꿀수 있습니다. \r\n원하는 기물을 선택하세요.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKnight);
            this.Controls.Add(this.btnRook);
            this.Controls.Add(this.btnBishop);
            this.Controls.Add(this.btnQueen);
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
    }
}