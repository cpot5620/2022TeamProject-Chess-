﻿using System;
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
    public partial class Form4 : Form
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
    }
}
