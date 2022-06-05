using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChattingApp;
using DBtest.chess;
namespace DBtest
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            this.Text = "올드창";
            this.Hide();
            form3 form3 = new form3();
            form3.ShowDialog();
            this.Close();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            accessForm form = new accessForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChessForm form = new ChessForm();
            form.Show();
        }

        private void btn_shop_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }
    }
}
