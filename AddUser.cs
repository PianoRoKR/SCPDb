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
    public partial class AddUser : Form
    {
        private DBConnect mDB;
        private User mUser;
        private bool mEdit;
        public AddUser(DBConnect aDB, User aUser, bool aEdit)
        {
            mDB = aDB;
            mEdit = aEdit;
            if (!mEdit)
                mUser = null;
            else
                mUser = aUser;
            this.Text = mEdit ? "Edit User" : "Add User";
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mEdit)
            {
            }
            else
            {
                User newUser = new User((Int32.Parse(itemSCPTextBox.Text)), (int)dropClass.SelectedIndex + 1, textName.Text, textPassword.Text);
                if (!mDB.addUser(newUser))
                    MessageBox.Show("Failed to add user!");
                else
                {
                    ((userPortal)this.Owner).UpdateData();
                    this.Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (mUser != null)
            {
                itemSCPTextBox.Text = mUser.UserID.ToString();
                textName.Text = mUser.Name;
                dropClass.SelectedIndex = (int)mUser.Class - 1;
                textPassword.Text = "";
                itemSCPTextBox.ReadOnly = true;
            }
            else
            {
                itemSCPTextBox.Text = mDB.getNextUserID().ToString();
                dropClass.SelectedIndex = 0;
                itemSCPTextBox.ReadOnly = true;
            }
        }
    }
}
