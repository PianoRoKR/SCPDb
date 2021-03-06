﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCPDb.Classes;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace SCPDb
{
    public partial class userPortal : Form
    {
        public DBConnect mDB;
        public frmLogin mParent;
        private List<User> mUserList;
        private bool mVisible;

        public void UpdateData()
        {
            agentWelcome_label.Text = "Welcome "  + (this.mDB.getAgentClass() != ClassType.O5 ? "Agent " : "Overseer ") + mDB.getAgentName();
            agentClass.Text = "Class " + mDB.getAgentClass().ToString();
            viewSCP_listBox.Items.Clear();
            usersManaged_listBox.Items.Clear();
            assignSCP_listBox.Items.Add("Loading...");
            viewSCP_listBox.Items.Add("Loading...");
            usersManaged_listBox.Items.Add("Loading...");
            mUserList = mDB.getUsersManaged();

            List<int> lSCPDb = mDB.getSCPDb();
            viewSCP_listBox.Items.Clear();
            foreach (int lScp in lSCPDb)
            {
                viewSCP_listBox.Items.Add(lScp);
            }

            List<int> lAssignedSCPDb = mDB.getAssignedSCPs(mDB.activeAgent);
            assignSCP_listBox.Items.Clear();
            if ((int)mDB.getAgentClass() == 5)
            {
                foreach (int lScp in lSCPDb)
                {
                    assignSCP_listBox.Items.Add(lScp);
                }
            }
            else
            {
                foreach (int lScp in lAssignedSCPDb)
                {
                    assignSCP_listBox.Items.Add(lScp);
                }
            }

            usersManaged_listBox.Items.Clear();
            foreach (User lUser in mUserList)
            {
                usersManaged_listBox.Items.Add(lUser);
            }

            if (this.mDB.getAgentClass() == ClassType.O5 && mVisible)
            {
                addUsers_listBox.Items.Clear();
                addUsers_listBox.Items.AddRange(mDB.getUsers().ToArray());
            }
        }

        public userPortal(DBConnect dbC, frmLogin parent)
        {
            InitializeComponent();
            mDB = dbC;
            mParent = parent;
            mVisible = false;
        }

        private void userPortal_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // need to add logout
            mDB.ExecuteLogout(mDB.getAgentID());
            this.Close();
        }

        private void buttonUserChangeClass_Click(object sender, EventArgs e)
        {
            if (usersManaged_listBox.SelectedItem == null)
                return;
            User lUser = (User)usersManaged_listBox.SelectedItem;
            ChangeUser lForm = new ChangeUser(mDB, lUser);
            lForm.Owner = this;
            lForm.ShowDialog();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "userAccess")
            {
                accessUserAdvanced();
                textBox1.Text = "";
            }
        }       

        private void accessUserAdvanced()
        {
            if (this.mDB.getAgentClass() == ClassType.O5)
            {
                lblSuper.Visible = true;
                addUsers_listBox.Visible = true;
                buttonUserAdd.Visible = true;
                buttonUserDelete.Visible = true;
                buttonUserEdit.Visible = true;
                addUsers_listBox.Items.Clear();
                addUsers_listBox.Items.AddRange(mDB.getUsers().ToArray());
            }
            else
            {
                lblO5.Visible = true;
                lblSuper.Visible = false;
                addUsers_listBox.Visible = false;
                buttonUserAdd.Visible = false;
                buttonUserDelete.Visible = false;
                buttonUserEdit.Visible = false;
            }
            mVisible = true;
        }

        private void userPortal_FormClosing(object sender, FormClosingEventArgs e)
        {
            mParent.Show();
        }

        private void buttonUserAssign_Click(object sender, EventArgs e)
        {
            if(usersManaged_listBox.SelectedItem == null)
                usersManaged_listBox.SelectedIndex = 0;
            AssignUser lForm = new AssignUser(mDB, ((User)usersManaged_listBox.SelectedItem).UserID, mUserList);
            lForm.Owner = this;
            lForm.ShowDialog();
        }

        private void buttonSCPAdd_Click(object sender, EventArgs e)
        {
            if (assignSCP_listBox.SelectedItem == null)
                MessageBox.Show("Please Select an SCP item to add an Adendum.");
            else
            {
                Adendum ad = new Adendum(mDB, (int)assignSCP_listBox.SelectedItem);
                ad.ShowDialog();
            }


        }

        private void buttonSCPEdit_Click(object sender, EventArgs e)
        {
            if (assignSCP_listBox.SelectedItem == null)
                MessageBox.Show("Please Select an SCP item to Edit.");
            else
            {
                Item item = new Item(mDB, (int)assignSCP_listBox.SelectedItem);
                item.ShowDialog();
            }
        }

        private void buttonSCPView_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (assignSCP_listBox.SelectedItem == null)
                    MessageBox.Show("Please Select an SCP item to View.");
                else
                {
                    View view = new View(mDB, (int)assignSCP_listBox.SelectedItem);
                    view.ShowDialog();
                }
            }
            else
            {
                if (viewSCP_listBox.SelectedItem == null)
                    MessageBox.Show("Please Select an SCP item to View.");
                else
                {
                    View view = new View(mDB, (int)viewSCP_listBox.SelectedItem);
                    view.ShowDialog();
                }
            }
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            AddUser add = new AddUser(mDB, null, false);
            add.Owner = this;
            add.ShowDialog();
        }

        private void buttonUserEdit_Click(object sender, EventArgs e)
        {
            if (addUsers_listBox.SelectedItem == null)
                return;
            AddUser add = new AddUser(mDB, (User)addUsers_listBox.SelectedItem, true);
            add.Owner = this;
            add.ShowDialog();
        }

        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Are you sure you want to delete person X","Delete User", MessageBoxButtons.OKCancel);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (usersManaged_listBox.SelectedItem == null)
                usersManaged_listBox.SelectedIndex = 0;
            RemoveUserAss lForm = new RemoveUserAss(mDB, ((User)usersManaged_listBox.SelectedItem).UserID, mUserList);
            lForm.ShowDialog();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            int lUID = mDB.SelectUID(mDB.getSessionID());
            
            if(lUID != mDB.getAgentID())
            {
                MessageBox.Show("Invalid session! Please login.");
                mParent.Show();
                this.Close();
                return;
            }
            AddUser lForm = new AddUser(mDB, mDB.activeAgent, true);
            lForm.Owner = this;
            lForm.ShowDialog();
        }

        

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                buttonSCPAdd.Visible = true;
                buttonSCPEdit.Visible = true;
            }
            else
            {
                buttonSCPAdd.Visible = false;
                buttonSCPEdit.Visible = false;
            }
        }

        

        


    }
}
