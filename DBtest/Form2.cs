using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DBtest
{
    public partial class Form2 : Form
    {
        string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
        int _port = 3306;
        string _database = "new_schema";
        string _id = "admin";
        string _pw = "kwchessawsqkrqudwp";
        string _connectionAddress = "";
        public Form2()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    if (!CheckIdvalid(txt_id.Text))
                    {
                        MessageBox.Show("아이디를 생성할 수 없습니다.(이미 존재하는 아이디)");
                        return;
                    }
                    if (txt_pwd1.Text != txt_pwd2.Text)
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다. 확인 후 다시 입력바랍니다");
                        return;
                    }
                    if (!CheckPWvalid(txt_pwd1.Text))
                    {
                        MessageBox.Show("비밀번호는 반드시 영문, 숫자, 특수문자를 포합해야합니다");
                        return;
                    }
                    string insertQuery = string.Format("INSERT INTO accounts_table(name, password, user_name, user_birth, user_phone, user_email) VALUES('{0}','{1}','{2}','{3}','{4}','{5}');",
                        txt_id.Text, txt_pwd1.Text, txt_name.Text, txt_birth.Text, txt_phone.Text, txt_email.Text);

                    MySqlCommand command = new MySqlCommand(insertQuery, mysql);
                    if (command.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("회원가입 오류 발생 서비스 센터 문의바랍니다.");
                    }
                    else
                    {
                        this.Hide();
                        Form1 form1 = new Form1();
                        form1.ShowDialog();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btn_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private bool CheckPWvalid(string text)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Za-z])(?=.*?\d)(?=.*?[~`!@#$%\^&*()-+=.]).{4,32}$");
            Match match = regex.Match(text);
            return match.Success;
            throw new NotImplementedException();
        }

        private bool CheckIdvalid(string text)
        {
            using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
            {
                mysql.Open();
                string selectQuery = string.Format("SELECT * FROM accounts_table");

                Boolean success = false;
                MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                MySqlDataReader table = command.ExecuteReader();

                if (table.HasRows)
                {
                    while (table.Read())
                    {
                        string[] arr = new string[3];
                        arr[0] = table["id"].ToString();
                        arr[1] = table["name"].ToString();
                        arr[2] = table["password"].ToString();
                        if (text == arr[1])
                        {
                            success = false;
                            break;
                        }
                        else
                        {
                            success = true;
                        }
                    }
                }
                else
                {
                    success = true;
                }
                return success;
            }
        }

        private void Form2_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
