﻿using System;
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
            if(comboBox2.SelectedIndex != -1) {
                bool updated = mDB.updateUserClass(mEditedUser, (ClassType)comboBox2.SelectedItem);

                if (updated)
                {
                    mEditedUser.Class = (ClassType)comboBox2.SelectedItem;
                    ((userPortal)this.Owner).UpdateData();
                    this.Close(); 
                }
                else MessageBox.Show("Update failed!");
            }
            else MessageBox.Show("Select new class!");
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
        }
    }
}
