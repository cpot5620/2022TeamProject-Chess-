using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBtest.chess
{
    public class Square
    {
        public int rowNumber { get; set; }
        public int colNumber { get; set; }
        public bool IsPieceOn { get; set; }
        public bool IsExpected { get; set; }
        public ChessPiece pieceName { get; set; }
        public ChessPiece whoseExpected { get; set; }

        public ChessTeam team { get; set; }


        public Square(int i, int j)
        {
            rowNumber = i;
            colNumber = j;
        }

        public void clear() //make square having no piece
        {
            this.IsExpected = false;
            this.IsPieceOn = false;
            this.pieceName = ChessPiece.NONE;
            this.whoseExpected = ChessPiece.NONE;
            this.team = ChessTeam.NONE;
        }
    }
}
