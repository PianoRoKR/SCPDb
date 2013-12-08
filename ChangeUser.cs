using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCPDb.Classes;

namespace SCPDb
{
    public partial class ChangeUser : Form
    {
        private DBConnect mDB;
        private User mEditedUser;

        public ChangeUser(DBConnect aDB, User aUser)
        {
            mDB = aDB;
            mEditedUser = aUser;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool updated = mDB.updateUserClass(mEditedUser, (ClassType)comboBox2.SelectedIndex);

            if (updated) { this.Close(); }
            else MessageBox.Show("Update failed!");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeUser_Load(object sender, EventArgs e)
        {
            lblID.Text = mEditedUser.UserID.ToString();
            lblUserName.Text = mEditedUser.Name;
            comboBox2.Items.Clear();
            for (int i = 1; i <= (int)mDB.getAgentClass(); i++)
            {
                if (i != (int)mEditedUser.Class)
                {
                    comboBox2.Items.Add((ClassType)i);
                }
            }
            int agentID = (int)mDB.getAgentClass();
            if (agentID == 5)
            {
                comboBox2.Items.Add((ClassType)5);
            }
        }
    }
}
