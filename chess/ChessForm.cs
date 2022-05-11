using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBtest.chess
{
    public partial class ChessForm : Form
    {
        static Board board = new Board();
        public Button[,] boardButtons = new Button[8, 8];
        private bool readyToMove = false; // when marking expected, true
        private Square preSquare;

        public ChessForm()
        {
            InitializeComponent();
            board.setBoard(); 
            setButtons();
        }

        private void setButtons() // make buttons in panel
        {
            int btnLength = boardPanel.Width / 8;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardButtons[row, col] = new Button();
                    boardButtons[row, col].Height = btnLength;
                    boardButtons[row, col].Width = btnLength;

                    boardPanel.Controls.Add(boardButtons[row, col]);
                    boardButtons[row, col].Location = new Point(col * btnLength, row * btnLength);
                    if (board.ofPosition[row, col].pieceName != ChessPiece.NONE)
                    {
                        boardButtons[row, col].Text = board.ofPosition[row, col].pieceName.ToString();
                    }
                    else
                    {
                        boardButtons[row, col].Text = "";
                    }
                    boardButtons[row, col].Tag = new Point(row, col);
                    boardButtons[row, col].Click += Board_Button_Click;

                    // Set BackColor
                    if (row % 2 == col % 2)
                    {
                        boardButtons[row, col].BackColor = Color.Wheat;
                    }
                    else
                    {
                        boardButtons[row, col].BackColor = Color.BurlyWood;
                    }

                    // Set ForeColor
                    if (board.ofPosition[row, col].team == ChessTeam.WHITE)
                    {
                        boardButtons[row, col].ForeColor = Color.White;
                    }
                    else if(board.ofPosition[row, col].team == ChessTeam.BLACK)
                    {
                        boardButtons[row, col].ForeColor = Color.Black;
                    }
                    else
                    {
                        boardButtons[row, col].ForeColor = Color.Red;
                    }
                }
            }

        }

        private void Board_Button_Click(object sender, EventArgs e) // By click buttons, make event
        {
            Button clickedButton = (Button)sender;
            Point clickedButtonPoint = (Point)clickedButton.Tag;

            int row = clickedButtonPoint.X;
            int col = clickedButtonPoint.Y;

            Square curSquare = board.ofPosition[row, col];

            if (curSquare.pieceName != ChessPiece.NONE)
            {
                if (readyToMove == false) // click chess piece -> mark expected move
                {
                    board.markExpectedMovement(curSquare);
                    readyToMove = true;
                }
                else if (curSquare.IsExpected) // click enemy's chess piece -> move piece(atatck)
                {
                    ChessPiece tempExpectedChessPiece = curSquare.whoseExpected;
                    board.unmarkExpectedMovement(preSquare);

                    // unmark로 해제된 expected 복원
                    curSquare.whoseExpected = tempExpectedChessPiece;
                    curSquare.IsExpected = true;

                    board.moveChessPiece(preSquare, curSquare);
                    readyToMove = false;
                } 
                else // click chess piece again -> unmark expected move
                {
                    board.unmarkExpectedMovement(curSquare);
                    readyToMove = false;
                }

            }
            else 
            {
                if(curSquare.IsExpected) // click expected piece -> move piece
                {
                    ChessPiece tempExpectedChessPiece = curSquare.whoseExpected;
                    board.unmarkExpectedMovement(preSquare);

                    // unmark로 해제된 expected 복원
                    curSquare.whoseExpected = tempExpectedChessPiece;
                    curSquare.IsExpected = true; 

                    board.moveChessPiece(preSquare, curSquare);
                    readyToMove = false;
                }
                else // click normal square -> do nothing
                {
                    MessageBox.Show("It's just a board");
                }
            }
            changeChessForm();
            preSquare = curSquare;
        }

        private void changeChessForm() // change ChessForm 
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Change ForeColor
                    if (board.ofPosition[row, col].team == ChessTeam.WHITE)
                    {
                        boardButtons[row, col].ForeColor = Color.White;
                    }
                    else if (board.ofPosition[row, col].team == ChessTeam.BLACK)
                    {
                        boardButtons[row, col].ForeColor = Color.Black;
                    }
                    else
                    {
                        boardButtons[row, col].ForeColor = Color.Red;
                    }


                    // Change Text
                    if (board.ofPosition[row, col].IsExpected)
                    {
                        boardButtons[row, col].Text = "go?";
                    }
                    else if (board.ofPosition[row, col].IsPieceOn)
                    {
                        boardButtons[row, col].Text = board.ofPosition[row, col].pieceName.ToString();
                    }
                    else
                    {
                        boardButtons[row, col].Text = "";
                    }
                }
            }
        }


    }
}
