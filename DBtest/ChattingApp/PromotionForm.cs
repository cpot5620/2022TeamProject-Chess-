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
        private ChessTeam chessTeam;
        public PromotionForm(ChessTeam chessteam)
        {
            InitializeComponent();
            this.chessTeam = chessteam;
            SetButtonImage();
        }

        private void SetButtonImage()
        {
            if (chessTeam == ChessTeam.BLACK)
            {
                btnQueen.ImageList = blackPieceImgList;
                btnBishop.ImageList = blackPieceImgList;
                btnRook.ImageList = blackPieceImgList;
                btnKnight.ImageList = blackPieceImgList;
            }
            else if (chessTeam == ChessTeam.WHITE)
            {
                btnQueen.ImageList = whitePieceImgList;
                btnBishop.ImageList = whitePieceImgList;
                btnRook.ImageList = whitePieceImgList;
                btnKnight.ImageList = whitePieceImgList;

            }

            btnQueen.ImageIndex = 0;
            btnBishop.ImageIndex = 1;
            btnRook.ImageIndex = 2;
            btnKnight.ImageIndex = 3;

            btnQueen.Tag = "QUEEN";
            btnBishop.Tag = "BISHOP";
            btnRook.Tag = "ROOK";
            btnKnight.Tag = "KNIGHT";
        }

        private void btnPIeceName_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            ChessForm chessForm = (ChessForm)Owner;
            switch (btn.Tag.ToString())
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
