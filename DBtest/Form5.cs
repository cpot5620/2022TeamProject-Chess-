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
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        static public string auth_user;
        static public int point;
        string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
        int _port = 3306;
        string _database = "new_schema";
        string _id = "admin";
        string _pw = "kwchessawsqkrqudwp";
        string _connectionAddress = "";
        Boolean form4_opening = false;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
            shop_name_txt.Text = auth_user;
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string selectQuery = string.Format("select * from accounts_table where name = {0};",auth_user);
                    MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = command.ExecuteReader();
                    while (table.Read())
                    {
                        string[] arr = new string[10];
                        arr[0] = table["user_king"].ToString();
                        arr[1] = table["user_queen"].ToString();
                        arr[2] = table["user_bishop"].ToString();
                        arr[3] = table["user_rook"].ToString();
                        arr[4] = table["user_knight"].ToString();
                        arr[5] = table["user_pawn"].ToString();
                        arr[7] = table["name"].ToString();
                        arr[8] = table["user_point"].ToString();
                        lb_pts2.Text = arr[8];
                        point = Convert.ToInt32(arr[8]);
                    }
                    mysql.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            skin_no1.ImageLocation = string.Format("https://drive.google.com/uc?export=view&id=1p12M4V97qc_woJXehFEarR0a2CONT7FS");
            skin_no2.ImageLocation = string.Format("https://drive.google.com/uc?export=view&id=107gxtIyMJzKqO-oaZaBIcDJUW4Gw5g-x");
            skin_no3.ImageLocation = string.Format("https://drive.google.com/uc?export=view&id=1EFg_Kl8AJBzksPP-kkhoT_ittI7erwaI");
            
        }
        private void skin1_purchase_Click(object sender, EventArgs e)
        {
            if(point >= 100)
            {
                point = point - 100;
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string updateQuery = string.Format("UPDATE accounts_table SET user_image = '{0}',user_point = '{1}' WHERE name = '{2}';",skin_no1.ImageLocation, point, auth_user);
                        MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("저장 오류");
                        }
                        MessageBox.Show("구매완료!");
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
                MessageBox.Show("포인트가 부족합니다.");
            }
        }
        private void skin2_purchase_Click(object sender, EventArgs e)
        {
            if (point >= 120)
            {
                point = point - 120;
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string updateQuery = string.Format("UPDATE accounts_table SET user_image = '{0}', user_poin='{1}' WHERE name = '{2}';", skin_no2.ImageLocation,point,auth_user);
                        MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("저장 오류");
                        }
                        MessageBox.Show("구매완료!");
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
                MessageBox.Show("포인트가 부족합니다.");
            }
        }

        private void skin3_purchase_Click(object sender, EventArgs e)
        {
            if (point >= 80)
            {
                point = point - 80;
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string updateQuery = string.Format("UPDATE accounts_table SET user_image = '{0}', user_point='{1}' WHERE name = '{2}';", skin_no3.ImageLocation,point,auth_user);
                        MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("저장 오류");
                        }
                        MessageBox.Show("구매완료!");
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
                MessageBox.Show("포인트가 부족합니다.");
            }
        }

        private void skin_no1_Click(object sender, EventArgs e)
        {

        }

        private void lb_pts2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lb_name_Click(object sender, EventArgs e)
        {

        }

        private void lb_pts_Click(object sender, EventArgs e)
        {

        }

        private void skin_no3_Click(object sender, EventArgs e)
        {

        }

        private void shop_name_txt_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void skin_no2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.Text == "back")
            {
                this.Hide();
                Form4 form4 = new Form4();
                form4_opening = true;
                form4.ShowDialog();
                this.Close();
            }
        }

        private void Formclosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if (form4_opening == false)
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();
            }
            this.Close();
        }
    }
}
