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
    public partial class AssignUser : Form
    {
        DBConnect mDB;
        int mDefaultUID = 0;
        List<User> mManagedUsers;
        public AssignUser(DBConnect aDB, int aUserID, List<User> aManagedUsers)
        {
            InitializeComponent();
            mDB = aDB;
            mDefaultUID = aUserID;
            mManagedUsers = aManagedUsers;
        }

        private void AssignUser_Load(object sender, EventArgs e)
        {
            int lIdx = mManagedUsers.FindIndex(s => s.UserID == mDefaultUID);
            comboUser.Items.AddRange(mManagedUsers.ToArray());
            comboUser.SelectedIndex = lIdx;
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboItem.Items.Clear();
            List<int> lList = mDB.getAssignableSCP(((User)comboUser.SelectedItem).UserID);
            foreach (int lSCP in lList)
            {
                comboItem.Items.Add(lSCP);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
