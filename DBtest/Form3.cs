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
    public partial class form3 : Form
    {
        static public string auth_user;
        string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
        int _port = 3306;
        string _database = "new_schema";
        string _id = "admin";
        string _pw = "kwchessawsqkrqudwp";
        string _connectionAddress = "";
        public form3()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            user_picture.ImageLocation = string.Format("https://item.kakaocdn.net/do/bf8d88a106e383adbb6c08cedd093f9bf43ad912ad8dd55b04db6a64cddaf76d");
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string selectQuery = string.Format("select * from accounts_table");
                    MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = command.ExecuteReader();
                    while(table.Read())
                    {
                        string[] arr = new string[8];
                        arr[0] = table["id"].ToString();
                        arr[1] = table["name"].ToString();
                        arr[2] = table["password"].ToString();
                        arr[3] = table["user_name"].ToString();
                        arr[4] = table["user_birth"].ToString();
                        arr[5] = table["user_phone"].ToString();
                        arr[6] = table["user_email"].ToString();
                        arr[7] = table["user_image"].ToString();

                        if(auth_user == arr[1])
                        {
                            txt_name.AppendText(arr[3]);
                            txt_id.AppendText(arr[0]);
                            txt_email.AppendText(arr[6]);
                            txt_phone.AppendText(arr[5]);
                            if (arr[7] =="0")
                            {
                                using (MySqlConnection mysql2 = new MySqlConnection(_connectionAddress))
                                {
                                    mysql2.Open();
                                    string basic_image = string.Format("https://drive.google.com/uc?export=view&id=1MBfrTdAAfJdHkmawtm2nPgTeek13Z0_v");
                                    string updateQuery = string.Format("UPDATE accounts_table SET user_image = '{0}' WHERE name = '{1}';", basic_image, arr[1]);
                                    Console.WriteLine("start");
                                    MySqlCommand command2 = new MySqlCommand(updateQuery, mysql2);
                                    if (command2.ExecuteNonQuery() != 1)
                                    {
                                        throw new Exception("업데이트 오류");
                                    }
                                    Console.WriteLine("finish");
                                    mysql2.Close();
                                }
                                user_picture.ImageLocation = String.Format("https://drive.google.com/uc?export=view&id=1MBfrTdAAfJdHkmawtm2nPgTeek13Z0_v");
                            }
                            else
                            {
                                user_picture.ImageLocation = String.Format(arr[7]);
                            }
                        }
                    }
                    mysql.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void user_picture_Click(object sender, EventArgs e)
        {

        }

        private void form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }
    }
}
