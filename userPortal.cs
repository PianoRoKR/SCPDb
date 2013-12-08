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
    public partial class userPortal : Form
    {
        public DBConnect mDB;
        public frmLogin mParent;
        private List<User> mUserList;
        public userPortal(DBConnect dbC, frmLogin parent)
        {
            InitializeComponent();
            mDB = dbC;
            mParent = parent;
        }

        private void userPortal_Load(object sender, EventArgs e)
        {
            
            agentWelcome_label.Text = "Welcome Agent " + mDB.getAgentName();
            agentClass.Text = "Class " + mDB.getAgentClass().ToString();
            assignSCP_listBox.Items.Clear();
            usersManaged_listBox.Items.Clear();
            assignSCP_listBox.Items.Add("Loading...");
            usersManaged_listBox.Items.Add("Loading...");
            mUserList = mDB.getUsersManaged();

            List<string> lSCPDb = mDB.getSCPDb();
            assignSCP_listBox.Items.Clear();
            foreach (string lScp in lSCPDb)
            {
                assignSCP_listBox.Items.Add(lScp);
            }

            ;
            usersManaged_listBox.Items.Clear();
            foreach(User lUser in mUserList)
            {
                usersManaged_listBox.Items.Add(lUser);
            }
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
            lForm.ShowDialog();
        }

        private void buttonSCPAdd_Click(object sender, EventArgs e)
        {
            if (assignSCP_listBox.SelectedItem == null)
                MessageBox.Show("Please Select an SCP item to add an Adendum.");
            else
            {
                Adendum ad = new Adendum();
                ad.ShowDialog();
            }


        }

        private void buttonSCPEdit_Click(object sender, EventArgs e)
        {
            if (assignSCP_listBox.SelectedItem == null)
                MessageBox.Show("Please Select an SCP item to Edit.");
            else
            {
                Item item = new Item();
                item.ShowDialog();
            }
        }

        private void buttonSCPView_Click(object sender, EventArgs e)
        {
            if (assignSCP_listBox.SelectedItem == null)
                MessageBox.Show("Please Select an SCP item to View.");
            else
            {
                View view = new View();
                view.ShowDialog();
            }
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            AddUser add = new AddUser();
            add.ShowDialog();
        }

        private void buttonUserEdit_Click(object sender, EventArgs e)
        {
            //NEED TO CHANGE CONSTRUCTOR TO LOAD USER SELECTED INFO
            AddUser add = new AddUser();
            add.ShowDialog();
        }

        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Are you sure you want to delete person X","Delete User", MessageBoxButtons.OKCancel);
        }
    }
}
