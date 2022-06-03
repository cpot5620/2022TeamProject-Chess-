using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
namespace ChattingApp
{
    public partial class chatting : Form
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        public int PORT;
        private Thread m_ThReader;

        public bool m_bStop = false;
        private TcpListener m_listener;
        private Thread m_thServer;

        public bool m_bConnect = false;
        TcpClient m_Client;

        public chatting()
        {
            InitializeComponent();
            m_thServer = new Thread(new ThreadStart(ServerStart));
            m_thServer.Start();
        }
        public chatting(string str)
        {
            InitializeComponent();
            this.PORT = Int32.Parse(str);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
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
                PORT = rand.Next(10000, 99999);
                m_listener = new TcpListener(PORT);
                m_listener.Start();

                m_bStop = true;
                Message("방 입장 Code : " + PORT.ToString());
                Message("상대방 접속 대기중...");

                while (m_bStop)
                {
                    TcpClient hClient = m_listener.AcceptTcpClient();

                    if (hClient.Connected)
                    {
                        m_bConnect = true;
                        Message("상대방 접속 완료");
                        
                        m_Stream = hClient.GetStream();
                        m_Read = new StreamReader(m_Stream);
                        m_Write = new StreamWriter(m_Stream);

                        m_ThReader = new Thread(new ThreadStart(Receive));
                        m_ThReader.Start();
                    }
                }
            }
            catch
            {
                Message("연결 실패");
                return;
            }
        }
        public void ServerStop()
        {
            if (!m_bStop)
                return;

            m_listener.Stop();
            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_ThReader.Abort();
            m_thServer.Abort();

            Message("서버 종료");
        }

        public void Disconnect()
        {
            if (!m_bConnect)
                return;
            m_bConnect = false;
            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_ThReader.Abort();

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

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);

            m_ThReader = new Thread(new ThreadStart(Receive));
            m_ThReader.Start();
        }

        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    string szMessage = m_Read.ReadLine();

                    if (szMessage != null)
                        Message("상대방 >>> : " + szMessage);
                }
            }
            catch
            {
                Message("메세지 오류 발생");
            }
            Disconnect();
        }

        public void Send()
        {
            try
            {
                m_Write.WriteLine(txt_msg.Text);
                m_Write.Flush();

                Message(">>> : " + txt_msg.Text);
                txt_msg.Text = "";
            }
            catch
            {
                Message("데이터 전송 실패");
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txt_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Send();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_thServer = new Thread(new ThreadStart(ServerStart));
            m_thServer.Start();
            btnCreate.Enabled = true;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Connect();
            btn_Connect.Enabled = true;
        }
    }
}
