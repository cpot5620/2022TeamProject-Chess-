using DBtest.chess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBtest
{
    public partial class Form1 : Form
    {
        string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
        int _port = 3306;
        string _database = "new_schema";
        string _id = "admin";
        string _pw = "kwchessawsqkrqudwp";
        string _connectionAddress = "";
        public Form1()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    Boolean check = mysql.Ping();
                    if (check != true)
                    {
                        throw new Exception("DB연결안됨.");
                    }
                    string selectQuery = string.Format("SELECT * FROM accounts_table");

                    Boolean success = false;
                    MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = command.ExecuteReader();


                    while (table.Read())
                    {
                        string[] arr = new string[3];
                        arr[0] = table["id"].ToString();
                        arr[1] = table["name"].ToString();
                        arr[2] = table["password"].ToString();
                        Console.WriteLine(arr[1]);
                        if (txtName.Text == arr[1] && txtNum.Text == arr[2])
                        {
                            success = true;
                            break;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                    //DB에 값이 없을 경우 false로 해야겟지?
                    if (success == true)
                    {
                        MessageBox.Show("로그인 성공!");
                        form3.auth_user = txtName.Text;
                        /*
                         * 외래키정보입력
                         */
                        Form5.auth_user =
                        ChessForm.auth_user = txtName.Text;
                        this.Hide();
                        Form4 form4 = new Form4();
                        form4.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("로그인 실패!");
                    }

                    txtName.Text = "";
                    txtNum.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
    }
}
