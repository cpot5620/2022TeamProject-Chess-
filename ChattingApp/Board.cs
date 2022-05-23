using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBtest.chess
{
    class Board
    {
        public Square[,] ofPosition = new Square[8, 8];
        public static bool firstMeetEnemy;

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ofPosition[i, j] = new Square(i, j);
                }
            }
        }

        public bool moveChessPiece(Square src, Square dest) // src 에서 dest 로 ChessPiece 이동
        {
            if (dest.IsExpected == false) // move to unmakred square
            {
                return false;
            }
            
            if (dest.IsPieceOn == true) // move to marked square where exitsts piece
            {
                if(src.team == dest.team) // mine -> do noting 
                {
                    return false;
                }
                else // enemy -> attack
                {
                    dest.pieceName = src.pieceName;
                    dest.team = src.team;
                    dest.IsPieceOn = true;
                    dest.IsExpected = false;
                    dest.whoseExpected = ChessPiece.NONE;
                    src.clear();
                    return true;
                }
            }
            
            if(dest.whoseExpected == src.pieceName) // move to marked square
            {
                dest.pieceName = src.pieceName;
                dest.team = src.team;
                dest.IsPieceOn = true;
                dest.IsExpected = false;
                dest.whoseExpected = ChessPiece.NONE;
                src.clear();
                return true;
            }
            return false;
        }

        public bool isSafe(int row, int col) // row와 col의 index exception 처리
        {
            if(row>=0 && row<8 && col>=0 && col<8)
            {
                return true;
            }
            return false;
        }

        public bool isBlocked(int row, int col, ChessTeam team) // 다른 piece로 막히는 case 처리
        {
            if(ofPosition[row, col].IsPieceOn)
            {
                if (ofPosition[row, col].team != team && firstMeetEnemy == false) // 처음만난 enemy piece는 not block
                {
                    firstMeetEnemy = true;
                    return false;
                }
                return true;
            }
            else
            {
                if (firstMeetEnemy) // enemy piece를 만났다면 block
                    return true;
                return false;
            }
        }

        public void markExpected(int[,,] ableMove, int curRowNumber, int curColNumber, ChessPiece curChessPiece, ChessTeam curTeam) // piece의 movement를 사용해 예상 경로 mark
        {
            for (int i = 0; i < ableMove.GetLength(0); i++) // 방향
            {
                firstMeetEnemy = false;
                for (int j = 0; j < ableMove.GetLength(1); j++) // 거리
                {
                    int rowNumber = curRowNumber + ableMove[i, j, 0];
                    int colNumber = curColNumber + ableMove[i, j, 1];

                    if (isSafe(rowNumber, colNumber)) 
                    {
                        if (isBlocked(rowNumber, colNumber, curTeam)) // knight 제외 장애물 있으면 해당 방향 not expected
                        {
                            break;
                        }
                        ofPosition[rowNumber, colNumber].IsExpected = true;
                        ofPosition[rowNumber, colNumber].whoseExpected = curChessPiece;
                    }
                }
            }
            firstMeetEnemy = false;
        }

        public void unmarkExpected(int[,,] ableMove, int curRowNumber, int curColNumber, ChessTeam curTeam) // piece의 movement를 사용해 예상 경로 unmark
        {

            for (int i = 0; i < ableMove.GetLength(0); i++)
            {
                firstMeetEnemy = false;
                for (int j = 0; j < ableMove.GetLength(1); j++)
                {
                    int rowNumber = curRowNumber + ableMove[i, j, 0];
                    int colNumber = curColNumber + ableMove[i, j, 1];

                    if (isSafe(rowNumber, colNumber))
                    {
                        if (isBlocked(rowNumber, colNumber, curTeam))
                        {
                            break;
                        }
                        ofPosition[rowNumber, colNumber].IsExpected = false;
                        ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.NONE;
                    }
                }
            }
            firstMeetEnemy = false;
        }

        public void markExpectedPawn(int curRowNumber, int curColNumber, ChessTeam curTeam) // pawn의 예상 경로 mark (다른 piece 처럼 일반화 불가)
        {
            switch (curTeam)
            {
                case ChessTeam.WHITE:

                    // 기본 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleMoveWhite[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleMoveWhite[i, 1];

                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == false)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = true;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.PAWN;
                        }

                        if ((curRowNumber != 6) || (ofPosition[rowNumber, colNumber].IsPieceOn == true))
                            break;
                    }
                    // 공격 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleAttackMoveWhite[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleAttackMoveWhite[i, 1];
                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == true && ofPosition[rowNumber, colNumber].team != curTeam)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = true;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.PAWN;
                        }
                    }

                    break;
                case ChessTeam.BLACK:
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleMoveBlack[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleMoveBlack[i, 1];

                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == false)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = true;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.PAWN;
                        }

                        if ((curRowNumber != 1) || (ofPosition[rowNumber, colNumber].IsPieceOn == true))
                            break;
                    }
                    // 공격 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleAttackMoveBlack[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleAttackMoveBlack[i, 1];
                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == true && ofPosition[rowNumber, colNumber].team != curTeam)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = true;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.PAWN;
                        }
                    }
                    break;
            }
        }

        public void unmarkExpectedPawn(int curRowNumber, int curColNumber, ChessTeam curTeam) // pawn의 예상 경로 unmark
        {
            switch (curTeam)
            {
                case ChessTeam.WHITE:
                    // 기본 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleMoveWhite[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleMoveWhite[i, 1];

                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == false)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = false;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.NONE;
                        }

                        if ((curRowNumber != 6) || (ofPosition[rowNumber, colNumber].IsPieceOn == true))
                            break;
                    }
                    // 공격 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleAttackMoveWhite[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleAttackMoveWhite[i, 1];
                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == true && ofPosition[rowNumber, colNumber].team != curTeam)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = false;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.NONE;
                        }
                    }

                    break;
                case ChessTeam.BLACK:
                    // 기본 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleMoveBlack[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleMoveBlack[i, 1];

                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == false)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = false;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.NONE;
                        }

                        if ((curRowNumber != 1) || (ofPosition[rowNumber, colNumber].IsPieceOn == true))
                            break;
                    }
                    // 공격 이동
                    for (int i = 0; i < 2; i++)
                    {
                        int rowNumber = curRowNumber + ChessMovement.pawnAbleAttackMoveBlack[i, 0];
                        int colNumber = curColNumber + ChessMovement.pawnAbleAttackMoveBlack[i, 1];
                        if (isSafe(rowNumber, colNumber) && ofPosition[rowNumber, colNumber].IsPieceOn == true && ofPosition[rowNumber, colNumber].team != curTeam)
                        {
                            ofPosition[rowNumber, colNumber].IsExpected = false;
                            ofPosition[rowNumber, colNumber].whoseExpected = ChessPiece.NONE;
                        }
                    }

                    break;
            }
        }

        public void markExpectedMovement(Square curSquare) // 현재 piece의 예상 경로 mark
        {
            int curRowNumber = curSquare.rowNumber;
            int curColNumber = curSquare.colNumber;
            ChessPiece curPieceName = curSquare.pieceName;
            ChessTeam curTeam = curSquare.team;
            switch (curSquare.pieceName)
            {
                case ChessPiece.KING:
                    markExpected(ChessMovement.kingAbleMove, curRowNumber, curColNumber, curPieceName, curTeam);
                    break;

                case ChessPiece.QUEEN:
                    markExpected(ChessMovement.queenAbleMove, curRowNumber, curColNumber, curPieceName, curTeam);
                    break;

                case ChessPiece.ROOK:
                    markExpected(ChessMovement.rookAbleMove, curRowNumber, curColNumber, curPieceName, curTeam);
                    break;

                case ChessPiece.BISHOP:
                    markExpected(ChessMovement.bishopAbleMove, curRowNumber, curColNumber, curPieceName, curTeam);
                    break;

                case ChessPiece.KNIGHT:
                    markExpected(ChessMovement.knightAbleMove, curRowNumber, curColNumber, curPieceName, curTeam);
                    break;

                case ChessPiece.PAWN:
                    markExpectedPawn(curRowNumber, curColNumber, curTeam);
                    break;
            }
        }


        public void unmarkExpectedMovement(Square curSquare) // 현재 piece의 예상 경로 unmark
        {
            int curRowNumber = curSquare.rowNumber;
            int curColNumber = curSquare.colNumber;
            ChessTeam curTeam = curSquare.team;
            switch (curSquare.pieceName)
            {
                case ChessPiece.KING:
                    unmarkExpected(ChessMovement.kingAbleMove, curRowNumber, curColNumber, curTeam);
                    break;

                case ChessPiece.QUEEN:
                    unmarkExpected(ChessMovement.queenAbleMove, curRowNumber, curColNumber, curTeam);
                    break;

                case ChessPiece.ROOK:
                    unmarkExpected(ChessMovement.rookAbleMove, curRowNumber, curColNumber, curTeam);
                    break;

                case ChessPiece.BISHOP:
                    unmarkExpected(ChessMovement.bishopAbleMove, curRowNumber, curColNumber, curTeam);
                    break;

                case ChessPiece.KNIGHT:
                    unmarkExpected(ChessMovement.knightAbleMove, curRowNumber, curColNumber, curTeam);
                    break;

                case ChessPiece.PAWN:
                    unmarkExpectedPawn(curRowNumber, curColNumber, curTeam);
                    break;
            }
        }

        public void setBoard() // Board 초기 설정
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    ofPosition[row, col].IsExpected = false;
                    ofPosition[row, col].IsPieceOn = false;
                    ofPosition[row, col].pieceName = ChessPiece.NONE;
                    ofPosition[row, col].whoseExpected = ChessPiece.NONE;
                    ofPosition[row, col].team = ChessTeam.NONE;
                }
            }
            setWhite();
            setBlack();
        }

        public void setWhite() // White Piece 초기 설정
        {
            ofPosition[6, 0].IsPieceOn = true;
            ofPosition[6, 0].pieceName = ChessPiece.PAWN;
            ofPosition[6, 0].team = ChessTeam.WHITE;
            ofPosition[6, 1].IsPieceOn = true;
            ofPosition[6, 1].pieceName = ChessPiece.PAWN;
            ofPosition[6, 1].team = ChessTeam.WHITE;
            ofPosition[6, 2].IsPieceOn = true;
            ofPosition[6, 2].pieceName = ChessPiece.PAWN;
            ofPosition[6, 2].team = ChessTeam.WHITE;
            ofPosition[6, 3].IsPieceOn = true;
            ofPosition[6, 3].pieceName = ChessPiece.PAWN;
            ofPosition[6, 3].team = ChessTeam.WHITE;
            ofPosition[6, 4].IsPieceOn = true;
            ofPosition[6, 4].pieceName = ChessPiece.PAWN;
            ofPosition[6, 4].team = ChessTeam.WHITE;
            ofPosition[6, 5].IsPieceOn = true;
            ofPosition[6, 5].pieceName = ChessPiece.PAWN;
            ofPosition[6, 5].team = ChessTeam.WHITE;
            ofPosition[6, 6].IsPieceOn = true;
            ofPosition[6, 6].pieceName = ChessPiece.PAWN;
            ofPosition[6, 6].team = ChessTeam.WHITE;
            ofPosition[6, 7].IsPieceOn = true;
            ofPosition[6, 7].pieceName = ChessPiece.PAWN;
            ofPosition[6, 7].team = ChessTeam.WHITE;


            ofPosition[7, 0].IsPieceOn = true;
            ofPosition[7, 0].pieceName = ChessPiece.ROOK;
            ofPosition[7, 0].team = ChessTeam.WHITE;
            ofPosition[7, 1].IsPieceOn = true;
            ofPosition[7, 1].pieceName = ChessPiece.KNIGHT;
            ofPosition[7, 1].team = ChessTeam.WHITE;
            ofPosition[7, 2].IsPieceOn = true;
            ofPosition[7, 2].pieceName = ChessPiece.BISHOP;
            ofPosition[7, 2].team = ChessTeam.WHITE;
            ofPosition[7, 3].IsPieceOn = true;
            ofPosition[7, 3].pieceName = ChessPiece.QUEEN;
            ofPosition[7, 3].team = ChessTeam.WHITE;
            ofPosition[7, 4].IsPieceOn = true;
            ofPosition[7, 4].pieceName = ChessPiece.KING;
            ofPosition[7, 4].team = ChessTeam.WHITE;
            ofPosition[7, 5].IsPieceOn = true;
            ofPosition[7, 5].pieceName = ChessPiece.BISHOP;
            ofPosition[7, 5].team = ChessTeam.WHITE;

            ofPosition[7, 6].IsPieceOn = true;
            ofPosition[7, 6].pieceName = ChessPiece.KNIGHT;
            ofPosition[7, 6].team = ChessTeam.WHITE;
            ofPosition[7, 7].IsPieceOn = true;
            ofPosition[7, 7].pieceName = ChessPiece.ROOK;
            ofPosition[7, 7].team = ChessTeam.WHITE;
        }

        public void setBlack() // Black Piece 초기 설정
        {
            ofPosition[0, 0].IsPieceOn = true;
            ofPosition[0, 0].pieceName = ChessPiece.ROOK;
            ofPosition[0, 0].team = ChessTeam.BLACK;
            ofPosition[0, 1].IsPieceOn = true;
            ofPosition[0, 1].pieceName = ChessPiece.KNIGHT;
            ofPosition[0, 1].team = ChessTeam.BLACK;
            ofPosition[0, 2].IsPieceOn = true;
            ofPosition[0, 2].pieceName = ChessPiece.BISHOP;
            ofPosition[0, 2].team = ChessTeam.BLACK;
            ofPosition[0, 3].IsPieceOn = true;
            ofPosition[0, 3].pieceName = ChessPiece.QUEEN;
            ofPosition[0, 3].team = ChessTeam.BLACK;
            ofPosition[0, 4].IsPieceOn = true;
            ofPosition[0, 4].pieceName = ChessPiece.KING;
            ofPosition[0, 4].team = ChessTeam.BLACK;
            ofPosition[0, 5].IsPieceOn = true;
            ofPosition[0, 5].pieceName = ChessPiece.BISHOP;
            ofPosition[0, 5].team = ChessTeam.BLACK;
            ofPosition[0, 6].IsPieceOn = true;
            ofPosition[0, 6].pieceName = ChessPiece.KNIGHT;
            ofPosition[0, 6].team = ChessTeam.BLACK;
            ofPosition[0, 7].IsPieceOn = true;
            ofPosition[0, 7].pieceName = ChessPiece.ROOK;
            ofPosition[0, 7].team = ChessTeam.BLACK;


            ofPosition[1, 0].IsPieceOn = true;
            ofPosition[1, 0].pieceName = ChessPiece.PAWN;
            ofPosition[1, 0].team = ChessTeam.BLACK;
            ofPosition[1, 1].IsPieceOn = true;
            ofPosition[1, 1].pieceName = ChessPiece.PAWN;
            ofPosition[1, 1].team = ChessTeam.BLACK;
            ofPosition[1, 2].IsPieceOn = true;
            ofPosition[1, 2].pieceName = ChessPiece.PAWN;
            ofPosition[1, 2].team = ChessTeam.BLACK;
            ofPosition[1, 3].IsPieceOn = true;
            ofPosition[1, 3].pieceName = ChessPiece.PAWN;
            ofPosition[1, 3].team = ChessTeam.BLACK;
            ofPosition[1, 4].IsPieceOn = true;
            ofPosition[1, 4].pieceName = ChessPiece.PAWN;
            ofPosition[1, 4].team = ChessTeam.BLACK;
            ofPosition[1, 5].IsPieceOn = true;
            ofPosition[1, 5].pieceName = ChessPiece.PAWN;
            ofPosition[1, 5].team = ChessTeam.BLACK;
            ofPosition[1, 6].IsPieceOn = true;
            ofPosition[1, 6].pieceName = ChessPiece.PAWN;
            ofPosition[1, 6].team = ChessTeam.BLACK;
            ofPosition[1, 7].IsPieceOn = true;
            ofPosition[1, 7].pieceName = ChessPiece.PAWN;
            ofPosition[1, 7].team = ChessTeam.BLACK;

        }

        public void setExpectedClear() // Board의 모든 expected mark 초기화
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    ofPosition[row, col].IsExpected = false;
                    ofPosition[row, col].whoseExpected = ChessPiece.NONE;
                }
            }
        }
    }
}
