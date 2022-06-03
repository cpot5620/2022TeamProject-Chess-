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
    public partial class lobby : Form
    {
        public lobby()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accessForm form = new accessForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChessForm form = new ChessForm();
            form.Show();
        }
    }
}
