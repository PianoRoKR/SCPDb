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
    public partial class RemoveUserAss : Form
    {
        DBConnect mDB;
        int mDefaultUID = 0;
        List<User> mManagedUsers;

        public RemoveUserAss(DBConnect aDB, int aUserID, List<User> aManagedUsers)
        {
            InitializeComponent();
            mDB = aDB;
            mDefaultUID = aUserID;
            mManagedUsers = aManagedUsers;
        }
        
        private void RemoveUserAss_Load(object sender, EventArgs e)
        {
            int lIdx = mManagedUsers.FindIndex(s => s.UserID == mDefaultUID);
            comboUser.Items.AddRange(mManagedUsers.ToArray());
            comboUser.SelectedIndex = lIdx;
        }
        
        

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboItem.Items.Clear();
            List<int> lList;

            // make new list of user assigned to and remove them from list

            if ((int)mDB.getAgentClass() == 5) { lList = mDB.getAssignedSCPs((User)comboUser.SelectedItem); }
            else { lList= mDB.getUnassignableSCPs((User)comboUser.SelectedItem); }

            foreach (int lSCP in lList)
            {
                comboItem.Items.Add(lSCP);
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool deleted = mDB.deleteAssignment((User)comboUser.SelectedItem, Convert.ToInt32(comboItem.SelectedItem));
            if (deleted) { this.Close(); }
            else MessageBox.Show("ERROR: item not deleted");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
