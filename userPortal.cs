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
            agentClass.Text = "Class " + mDB.getAgentClass();
            comboAss.Items.Clear();
            comboUser.Items.Clear();
            comboAss.Items.Add("Loading...");
            comboUser.Items.Add("Loading...");
            List<string> lSCPDb = mDB.getSCPDb();
            comboAss.Items.Clear();
            foreach (string lScp in lSCPDb)
            {
                comboAss.Items.Add(lScp);
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // need to add logout
            Application.Exit();
        }

        

        private void comboAss_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
