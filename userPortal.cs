using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCPDb
{
    public partial class userPortal : Form
    {
        public DBConnect mDB;

        public userPortal(DBConnect dbC)
        {
            InitializeComponent();
            mDB = dbC;
        }

        private void userPortal_Load(object sender, EventArgs e)
        {
            agentWelcome_label.Text = "Welcome Agent " + mDB.getAgentName();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // need to add logout
            Application.Exit();
        }

        
    }
}
