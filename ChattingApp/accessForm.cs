using DBtest.chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingApp
{
    public partial class accessForm : Form
    {
        public accessForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChessForm Form = new ChessForm(txtPort.Text);
            Form.Show();
            Form.Connect();
            this.Close();
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
        {
            //문자 예외처리 추가예정
            if (e.KeyCode == Keys.Enter)
            {
                ChessForm Form = new ChessForm(txtPort.Text);
                Form.Show();
                this.Close();
            }
        }
    }
}
