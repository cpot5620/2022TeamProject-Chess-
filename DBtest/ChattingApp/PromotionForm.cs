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
    public partial class PromotionForm : MetroFramework.Forms.MetroForm
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

            //ChessForm chessForm = (ChessForm)Owner;
            switch (btn.Tag.ToString())
            {
                case "QUEEN":
                    ChessForm.promotionPiece = ChessPiece.QUEEN;
                    break;
                case "BISHOP":
                    ChessForm.promotionPiece = ChessPiece.BISHOP;
                    break;
                case "ROOK":
                    ChessForm.promotionPiece = ChessPiece.ROOK;
                    break;
                case "KNIGHT":
                    ChessForm.promotionPiece = ChessPiece.KNIGHT;
                    break;
            }

            this.Close();
        }
    }
}
