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
    public partial class form3 : MetroFramework.Forms.MetroForm
    {
        static public string auth_user;
        string _server = "kw-chess.c7srdygxxtpt.ap-northeast-2.rds.amazonaws.com";
        int _port = 3306;
        string _database = "new_schema";
        string _id = "admin";
        string _pw = "kwchessawsqkrqudwp";
        string _connectionAddress = "";
        Boolean form4_opening = false;
        Boolean save = true;
        
        public form3()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server = {0}; Port = {1}; Database={2}; Uid = {3} ; Pwd = {4}", _server, _port, _database, _id, _pw);
            txt_win.ReadOnly = true;
            txt_lose.ReadOnly = true;
            txt_ratio.ReadOnly = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.Text == "뒤로")
            {
                this.Hide();
                Form4 form4 = new Form4();
                form4.Text = "새창1";
                form4_opening = true;
                form4.ShowDialog();
                this.Close();
            }
            if (btn_back.Text == "저장")
            {
                if (MessageBox.Show("저장하시겠습니까?", "SAVE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    save = true;
                    edit_save();
                    btn_delete.Enabled = false;
                    this.Text = "...";
                    txt_name.ReadOnly = true;
                    txt_email.ReadOnly = true;
                    txt_phone.ReadOnly = true;
                    txt_name.Enabled = false;
                    txt_email.Enabled = false;
                    txt_phone.Enabled = false;
                    user_picture.Enabled = false;
                    btn_back.Text = "뒤로";
                }
                else
                {
                    save = false;
                    btn_delete.Enabled = false;
                    this.Text = "...";
                    txt_name.ReadOnly = true;
                    txt_email.ReadOnly = true;
                    txt_phone.ReadOnly = true;
                    txt_name.Enabled = false;
                    txt_email.Enabled = false;
                    txt_phone.Enabled = false;
                    user_picture.Enabled = false;
                    btn_back.Text = "뒤로";
                }

            }
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
                        arr[8] = table["user_win"].ToString();
                        arr[9] = table["user_lose"].ToString();
      
                        if(auth_user == arr[1])
                        {
                            txt_name.AppendText(arr[3]);
                            txt_id.AppendText(arr[0]);
                            txt_email.AppendText(arr[6]);
                            txt_phone.AppendText(arr[5]);
                            txt_win.AppendText(arr[8]);
                            txt_lose.AppendText(arr[9]);
                            int win = Int16.Parse(arr[8]);
                            int lose = Int16.Parse(arr[9]);
                            int ratio = 0;
                            if (win == 0 && lose == 0)
                            {
                                ratio = 0;
                            }
                            else
                            {
                                ratio = 100 * (win / (lose + win));
                            }
                            txt_ratio.AppendText(ratio.ToString());
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
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            dialog.Filter = "( *.bmp; *.jpg; *.png; *.jpeg) | *.BMP; *.JPG; *.PNG; *.JPEG";

            if (dialog.ShowDialog() == DialogResult.OK)
                image_file = dialog.FileName;
            else if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            user_picture.Image = Bitmap.FromFile(image_file);
            user_picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if (form4_opening == false) {
                Form4 form4 = new Form4();
                form4.Text = "새창2";
                form4.ShowDialog();
            }
            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 삭제하시겠습니까?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string deleteQuery = string.Format("delete from accounts_table where name = {0};", auth_user);
                        MySqlCommand command = new MySqlCommand(deleteQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            throw new Exception("삭제 실패");
                        }
                        mysql.Close();
                        this.Hide();
                        Form4 form1 = new Form4();
                        form1.ShowDialog();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_delete.Enabled = true;
            this.Text = "Edit Profile...";
            txt_name.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_phone.ReadOnly = false;
            txt_name.Enabled = true;
            txt_email.Enabled = true;
            txt_phone.Enabled = true;
            user_picture.Enabled = true;
            btn_back.Text = "저장";
        }
        private void edit_save()
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string updateQuery = string.Format("UPDATE accounts_table SET user_name = '{0}', user_email = '{1}', user_phone = '{2}' WHERE name = '{3}';", txt_name.Text, txt_email.Text, txt_phone.Text, auth_user);
                    MySqlCommand command = new MySqlCommand(updateQuery, mysql);
                    if (command.ExecuteNonQuery() != 1)
                    {
                        throw new Exception("저장 오류");
                    }
                    mysql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_win_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
