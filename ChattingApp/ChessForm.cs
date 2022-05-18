using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBtest.chess
{
    public partial class ChessForm : Form
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        public int PORT;
        private Thread m_ThReader;

        TcpClient hClient;
        public bool m_bStop = false;
        private TcpListener m_listener;
        private Thread m_thServer;
        private Thread m_thStream;
        ChessBoard chessBoard;
        SendMessage message;
        public bool m_bConnect = false;
        TcpClient m_Client;

        static Board board = new Board();
        public Button[,] boardButtons = new Button[8, 8];
        private bool readyToMove = false; // when marking expected, true
        private Square preSquare;
        private ChessTeam chessTurn;
        private const int LIMITTIME = 60;

        public ChessForm()
        {
            InitializeComponent();
            board.setBoard();
            setButtons();
            chessTurn = ChessTeam.WHITE;
            tmrTxt.Text = LIMITTIME.ToString();
            tmrClock.Start();
            m_thServer = new Thread(new ThreadStart(ServerStart));
            m_thServer.Start();
        }

        public ChessForm(string str)
        {
            InitializeComponent();
            board.setBoard();
            setButtons();
            chessTurn = ChessTeam.WHITE;
            tmrTxt.Text = LIMITTIME.ToString();
            tmrClock.Start();

            this.PORT = Int32.Parse(str);
            m_thServer = new Thread(new ThreadStart(Connect));
            m_thServer.Start();
        }


        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txt_all.AppendText(msg + "\r\n");
                txt_all.Focus();
                txt_all.ScrollToCaret();
                txt_msg.Focus();
            }));
        }
        public void ServerStart()
        {
            try
            {
                Random rand = new Random();
                PORT = rand.Next(0, 30000);
                m_listener = new TcpListener(PORT);
                m_listener.Start();

                m_bStop = true;
                Message("방 입장 Code : " + PORT.ToString());
                Message("상대방 접속 대기중...");

                while (m_bStop)
                {
                    hClient = m_listener.AcceptTcpClient();

                    if (hClient.Connected)
                    {
                        m_bConnect = true;
                        Message("상대방 접속 완료");
                        m_Stream = hClient.GetStream();
                        break;
                    }
                }
                while (m_bStop)
                {
                    if (m_Stream.DataAvailable)
                    {
                        this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                        Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                        switch ((int)packet.type)
                        {
                            case (int)PacketType.Message:
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.message = (SendMessage)Packet.Desserialize(this.readBuffer);
                                    m_ThReader = new Thread(new ThreadStart(Receive));
                                    m_ThReader.Start();
                                }));
                                break;
                        }
                    }


                    /*
                    m_ThReader = new Thread(new ThreadStart(Receive));
                    m_ThReader.Start();*/

                }
            }
            catch
            {
                Message("연결 실패");
                return;
            }
        }
        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }
        public void ServerStop()
        {
            if (!m_bStop)
                return;
            if (m_bConnect)
            {
                m_Stream.Close();
                hClient.Close();
            }
            m_listener.Stop();
            m_thServer.Abort();
            Message("서버 종료");
            m_bStop = false;
        }

        public void Disconnect()
        {
            if (!m_bConnect)
                return;
            m_bConnect = false;
            m_Stream.Close();

            Message("상대방과 연결 중단");
        }
        public void Connect()
        {
            m_Client = new TcpClient();

            try
            {
                m_Client.Connect("127.0.0.1", PORT);
            }
            catch
            {
                m_bConnect = false;
                return;
            }
            m_bConnect = true;
            Message("서버 연결");

            m_Stream = m_Client.GetStream();
            while (m_bConnect)
            {
                if (m_Stream.DataAvailable)
                {
                    try
                    {
                        this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                    }
                    catch
                    {
                        this.m_bConnect = false;
                        this.m_Stream = null;
                    }
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                    switch ((int)packet.type)
                    {
                        case (int)PacketType.Message:
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.message = (SendMessage)Packet.Desserialize(this.readBuffer);
                                m_ThReader = new Thread(new ThreadStart(Receive));
                                m_ThReader.Start();
                            }));
                            break;
                    }
                }
            }
            // m_ThReader = new Thread(new ThreadStart(Receive));
            // m_ThReader.Start();
        }

        public void Receive()
        {
            try
            {
                string szMessage = message.msg;

                if (szMessage != null)
                    Message("상대방 >>> : " + szMessage);
            }
            catch
            {
                Message("메세지 오류 발생");
                Disconnect();
            }
        }

        public void SendMsg()
        {
            try
            {
                SendMessage msg = new SendMessage();
                msg.type = (int)PacketType.Message;
                msg.msg = txt_msg.Text;

                Packet.Serialize(msg).CopyTo(this.sendBuffer, 0);
                this.Send();

                Message(">>> : " + txt_msg.Text);
                txt_msg.Text = "";
            }
            catch
            {
                Message("데이터 전송 실패");
            }
        }

        private void txt_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendMsg();
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
                    else if (board.ofPosition[row, col].team == ChessTeam.BLACK)
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
            bool isMove = false;



            if (curSquare.pieceName != ChessPiece.NONE)
            {
                if (readyToMove == false) // click chess piece -> mark expected move
                {
                    if (chessTurn != curSquare.team) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    board.markExpectedMovement(curSquare);
                    readyToMove = true;
                }
                else if (curSquare.IsExpected) // click enemy's chess piece -> move piece(atatck)
                {
                    if (chessTurn != preSquare.team) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    ChessPiece tempExpectedChessPiece = curSquare.whoseExpected;
                    board.unmarkExpectedMovement(preSquare);

                    // unmark로 해제된 expected 복원
                    curSquare.whoseExpected = tempExpectedChessPiece;
                    curSquare.IsExpected = true;

                    bool isKing = (curSquare.pieceName == ChessPiece.KING); // attack piece가 king인지 확인

                    isMove = board.moveChessPiece(preSquare, curSquare);
                    readyToMove = false;

                    if (isKing) // Checkmate
                    {
                        changeChessForm();
                        tmrClock.Stop();
                        Checkmate();
                        return;
                    }
                }
                else // click chess piece again -> unmark expected move
                {
                    if (chessTurn != curSquare.team) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    board.unmarkExpectedMovement(curSquare);
                    readyToMove = false;
                }

            }
            else
            {
                if (curSquare.IsExpected) // click expected piece -> move piece
                {
                    if (chessTurn != preSquare.team) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    ChessPiece tempExpectedChessPiece = curSquare.whoseExpected;
                    board.unmarkExpectedMovement(preSquare);

                    // unmark로 해제된 expected 복원
                    curSquare.whoseExpected = tempExpectedChessPiece;
                    curSquare.IsExpected = true;

                    isMove = board.moveChessPiece(preSquare, curSquare);
                    readyToMove = false;
                }
                else // click normal square -> do nothing
                {
                    MessageBox.Show("It's just a board");
                }
            }
            changeChessForm();
            preSquare = curSquare;

            // 이동 시 turn 변경
            if (isMove)
                changeTurn();
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

        private void changeTurn() // change chess turn
        {
            switch (chessTurn)
            {
                case ChessTeam.WHITE:
                    chessTurn = ChessTeam.BLACK;
                    turnBox.BackColor = Color.Black;
                    break;

                case ChessTeam.BLACK:
                    chessTurn = ChessTeam.WHITE;
                    turnBox.BackColor = Color.White;
                    break;
            }

            // reset timer
            tmrClock.Stop();
            tmrTxt.Text = LIMITTIME.ToString();
            changeChessForm();
            tmrClock.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            // 시간 지남에 따라 시간 줄어듬
            int nextCount = Int32.Parse(tmrTxt.Text) - 1;

            if (nextCount == -1) // 시간 끝나면 show message & turn 강제 변경 
            {
                tmrClock.Stop();
                var result = MessageBox.Show("Time Out. Change Turn.");
                if (result == DialogResult.OK)
                {
                    board.setExpectedClear();
                    changeTurn();
                }
            }
            else // text 변경
            {
                tmrTxt.Text = nextCount.ToString();
            }
        }

        private void Checkmate()
        {
            ChessTeam winnerTeam = chessTurn;

            var result = MessageBox.Show("Checkmate!!\nWinner is " + winnerTeam.ToString() + "");
            if (result == DialogResult.OK)
            {
                board.setBoard();
                changeChessForm();
            }

            // user에 승 패 기록 
        }

        private void ChessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }
    }
}
