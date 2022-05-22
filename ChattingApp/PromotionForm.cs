using DBtest.chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingApp
{
    public partial class PromotionForm : Form
    {
        public PromotionForm()
        {
            InitializeComponent();
        }

        private void btnPIeceName_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            ChessForm chessForm = (ChessForm)Owner;
            switch (btn.Text)
            {
                case "QUEEN":
                    chessForm.promotionPiece = ChessPiece.QUEEN;
                    break;
                case "BISHOP":
                    chessForm.promotionPiece = ChessPiece.BISHOP;
                    break;
                case "ROOK":
                    chessForm.promotionPiece = ChessPiece.ROOK;
                    break;
                case "KNIGHT":
                    chessForm.promotionPiece = ChessPiece.KNIGHT;
                    break;
            }

            this.Close();
        }
    }
}
