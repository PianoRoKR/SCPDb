using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCPDb
{
    public partial class frmLogin : Form
    {
        DBConnect mDBConnect;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lPassword = tbPassword.Text;
            int lUID = -1;
            if (!int.TryParse(tbUserName.Text, out lUID) || lUID == -1)
            {
                MessageBox.Show("Invalid user id!");
                tbPassword.Text = "";
                return;
            }
            if (mDBConnect.ExecuteLogin(lUID, lPassword) == true)
                MessageBox.Show("Logged in!");
            else
                MessageBox.Show("Log in failed!");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            mDBConnect = new DBConnect();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mDBConnect.CloseSSH();
        }


    }
}
