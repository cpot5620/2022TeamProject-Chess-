using ChattingApp;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBtest.chess
{
    public partial class ChessForm : Form
    {
        static public string auth_user;
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private byte[] sendBuffer = new byte[1024 * 5];
        private byte[] readBuffer = new byte[1024 * 5];
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
        private ChessTeam chessTurn; // 게임 전체 턴
        private readonly ChessTeam chessTeam; // player 의 team
        public ChessPiece promotionPiece;
        private ChessTeam winnerTeam; // 승자

        private const int LIMITTIME = 30;

        //private Player player;


        public ChessForm()
        {
            InitializeComponent();
            board.setBoard();
            setButtons();
            chessTurn = ChessTeam.WHITE;
            chessTeam = ChessTeam.WHITE;
            teamTxt.Text = "WHITE";
            //player 설정
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
            chessTeam = ChessTeam.BLACK;
            teamTxt.Text = "BLACK";
            //player 설정
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
                PORT = rand.Next(49152, 65535);
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
                        this.m_Stream.Read(readBuffer, 0, 1024 * 5);
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
                            case (int)PacketType.ChessBoard:
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    ChessBoard CB = (ChessBoard)Packet.Desserialize(this.readBuffer);
                                    board.ofPosition = CB.arr;
                                    m_ThReader = new Thread(new ThreadStart(changeTurn));
                                    m_ThReader.Start();
                                }));
                                break;
                            case (int)PacketType.Winner:
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    tmrClock.Stop();
                                    Winner CT = (Winner)Packet.Desserialize(this.readBuffer);
                                    winnerTeam = CT.chessTeam;
                                    m_ThReader = new Thread(new ThreadStart(Checkmate));
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
            }
        }
        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();

            for (int i = 0; i < 1024 * 5; i++)
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
                m_bConnect = false;
            }
            // m_ThReader.Abort();
            m_listener.Stop();
            m_thServer.Abort();
            Message("서버 종료");
            m_bStop = false;
        }

        public void Disconnect()
        {
            if (!m_bConnect)
                return;
            //m_Client.Close();
            m_bConnect = false;
            m_Stream.Close();
            m_thServer.Abort();
            //m_ThReader.Abort();
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
                        this.m_Stream.Read(readBuffer, 0, 1024 * 5);
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
                        case (int)PacketType.ChessBoard:
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ChessBoard CB = (ChessBoard)Packet.Desserialize(this.readBuffer);
                                board.ofPosition = CB.arr;
                                m_ThReader = new Thread(new ThreadStart(changeTurn));
                                m_ThReader.Start();
                            }));
                            break;
                        case (int)PacketType.Winner:
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                tmrClock.Stop();
                                Winner CT = (Winner)Packet.Desserialize(this.readBuffer);
                                winnerTeam = CT.chessTeam;
                                m_ThReader = new Thread(new ThreadStart(Checkmate));
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

        private void SetChessPieceImage(int row, int col)
        {
            Square square = board.ofPosition[row, col];
            ChessPiece piece = square.pieceName;
            ChessTeam team = square.team;
            int result = -1;

            // url로 image setting
            /*WebClient downloader = new WebClient();
            Stream imgStream = downloader.OpenRead("https://e7.pngegg.com/pngimages/669/663/png-clipart-chess-piece-pawn-white-and-black-in-chess-king-chess-game-king-thumbnail.png");
            Bitmap resizedImage = new Bitmap(Bitmap.FromStream(imgStream) as Bitmap, new Size(50, 50));
            Image imgResult = (Image)resizedImage;
            ImageList img = new ImageList();
            img.Images.Add(imgResult);*/

            switch (piece)
            {
                case ChessPiece.KING:
                    result = 0;
                    break;
                case ChessPiece.QUEEN:
                    result = 1;
                    break;
                case ChessPiece.BISHOP:
                    result = 2;
                    break;
                case ChessPiece.ROOK:
                    result = 3;
                    break;
                case ChessPiece.KNIGHT:
                    result = 4;
                    break;
                case ChessPiece.PAWN:
                    result = 5;
                    break;
            }

            if (team == ChessTeam.BLACK)
                boardButtons[row, col].ImageList = blackPieceImgList; // set button's imageList
            else if (team == ChessTeam.WHITE)
                boardButtons[row, col].ImageList = whitePieceImgList; // set button's imageList

            boardButtons[row, col].ImageIndex = result;
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
                    boardButtons[row, col].Font = new Font(boardButtons[row, col].Font.FontFamily, 12);

                    boardPanel.Controls.Add(boardButtons[row, col]);
                    boardButtons[row, col].Location = new Point(col * btnLength, row * btnLength);

                    SetChessPieceImage(row, col);

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
                }
            }

        }

        private void Board_Button_Click(object sender, EventArgs e) // By click buttons, make event
        {
            if (tmrTxt.Text == "READY") // 게임 시작 전이면 동작 X
                return;

            if (chessTurn != chessTeam) // 자신의 턴이 아니면 동작 X
                return;

            Button clickedButton = (Button)sender;
            Point clickedButtonPoint = (Point)clickedButton.Tag;

            int row = clickedButtonPoint.X;
            int col = clickedButtonPoint.Y;

            Square curSquare = board.ofPosition[row, col];
            bool isMove = false;
            bool isKing = false;

            if (curSquare.pieceName != ChessPiece.NONE)
            {
                if (readyToMove == false) // click chess piece -> mark expected move
                {
                    if (chessTurn != curSquare.team || readyToMove) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    board.markExpectedMovement(curSquare);
                    readyToMove = true;
                }
                else if (curSquare.IsExpected) // click enemy's chess piece -> move piece(atatck)
                {
                    if (chessTurn != preSquare.team || !readyToMove) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    ChessPiece tempExpectedChessPiece = curSquare.whoseExpected;
                    board.unmarkExpectedMovement(preSquare);

                    // unmark로 해제된 expected 복원
                    curSquare.whoseExpected = tempExpectedChessPiece;
                    curSquare.IsExpected = true;

                    isKing = (curSquare.pieceName == ChessPiece.KING); // attack piece가 king인지 확인

                    isMove = board.moveChessPiece(preSquare, curSquare);
                    readyToMove = false;

                }
                else // click chess piece again -> unmark expected move
                {
                    if (chessTurn != curSquare.team || !readyToMove) // 상대방의 turn일 때 처리 X
                    {
                        return;
                    }

                    if (readyToMove && curSquare != preSquare)
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
                    if (chessTurn != preSquare.team || !readyToMove) // 상대방의 turn일 때 처리 X
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
                    return;
                }
            }
            promotionPawn(curSquare);
            changeChessForm();
            preSquare = curSquare;

            if (isKing) // Checkmate
            {
                tmrClock.Stop();
                Winner winner = new Winner();
                winner.type = (int)PacketType.Winner;
                winner.chessTeam = chessTurn;
                Packet.Serialize(winner).CopyTo(this.sendBuffer, 0);
                this.Send();

                winnerTeam = chessTurn;
                Checkmate();
                return;
            }

            if (isMove)
            {
                board.setExpectedClear();

                // 이동 시 board 정보 보내기
                ChessBoard CB = new ChessBoard();
                CB.type = (int)PacketType.ChessBoard;
                CB.arr = (Square[,])board.ofPosition.Clone();
                Packet.Serialize(CB).CopyTo(this.sendBuffer, 0);
                this.Send();

                changeTurn(); // 이동 시 turn 변경
            }
        }

        private void promotionPawn(Square square)
        {
            if (square.IsPieceOn && square.pieceName == ChessPiece.PAWN)
            {
                if ((square.team == ChessTeam.WHITE && square.rowNumber == 0) || (square.team == ChessTeam.BLACK && square.rowNumber == 7))
                {
                    PromotionForm promotionForm = new PromotionForm(this.chessTurn);
                    promotionForm.Owner = this;
                    if (promotionForm.ShowDialog() == DialogResult.Cancel)
                    {
                        square.pieceName = promotionPiece;
                    }
                }
            }
        }


        private void changeChessForm() // change ChessForm 
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board.ofPosition[row, col].IsExpected)
                    {
                        boardButtons[row, col].ForeColor = Color.Red;
                        boardButtons[row, col].Text = "●";
                    }
                    else
                    {
                        SetChessPieceImage(row, col);
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
            this.Invoke(new MethodInvoker(delegate () // reset timer
            {
                tmrClock.Stop();
                tmrTxt.Text = LIMITTIME.ToString();
                changeChessForm();
                tmrClock.Start();
            }));
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            if (tmrTxt.Text == "READY")
            {
                if (m_bConnect)
                {
                    tmrTxt.Text = LIMITTIME.ToString();
                }
            }
            else
            {
                // 시간 지남에 따라 시간 줄어듬
                int nextCount = Int32.Parse(tmrTxt.Text) - 1;

                if (nextCount == -1) // 시간 끝나면 show message & turn 강제 변경 
                {
                    tmrClock.Stop();
                    if (chessTurn == chessTeam)
                    {
                        var result = MessageBox.Show("Time Out.\nChange Turn", "TIME OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        board.setExpectedClear();
                        readyToMove = false;

                        ChessBoard CB = new ChessBoard();
                        CB.type = (int)PacketType.ChessBoard;
                        CB.arr = (Square[,])board.ofPosition.Clone();
                        Packet.Serialize(CB).CopyTo(this.sendBuffer, 0);
                        if (result == DialogResult.OK)
                        {
                            this.Send();
                        }
                        changeTurn();
                    }
                }
                else // text 변경
                {
                    tmrTxt.Text = nextCount.ToString();
                }
            }
        }

        private void Checkmate()
        {
            var result = MessageBox.Show("CHECKMATE!!\nWinner is " + winnerTeam.ToString(), "CHECKMATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
            int _port = 3306;
            string _database = "new_schema";
            string _id = "admin";
            string _pw = "kwchessawsqkrqudwp";
            string _connectionAddress = "";
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
            if (chessTeam == winnerTeam)
            {
                // player에 승 기록
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open(); 
                        string updateQuery = string.Format("UPDATE accounts_table SET user_win = user_win + 1 WHERE name = {0};", auth_user);
                        MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("삭제 실패");
                        }
                        mysql.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // player에 패 기록
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string updateQuery = string.Format("Update accounts_table SET user_lose = user_lose + 1 WHERE name = {0};",auth_user);
                        MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("삭제 실패");
                        }
                        mysql.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (result == DialogResult.OK)
            {
                board.setBoard();
                changeChessForm();
                tmrTxt.Text = "READY";

            }
        }



        private void ChessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chessTeam == ChessTeam.WHITE)
                ServerStop();
            else
                Disconnect();
        }
    }
}