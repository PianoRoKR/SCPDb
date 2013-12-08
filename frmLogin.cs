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
using SCPDb.Classes;

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
                tbUserName.Text = "";
                tbPassword.Text = "";
                return;
            }
            if (mDBConnect.ExecuteLogin(lUID, lPassword) == true)
            {
                userPortal portal = new userPortal(mDBConnect, this);
                tbUserName.Text = "";
                tbPassword.Text = "";
                portal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Log in failed!");
                tbPassword.Text = "";
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            mDBConnect = new DBConnect();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mDBConnect.CloseSSH();
        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {
            tbUserName.Focus();
        }


    }
}
