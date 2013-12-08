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
        public AddUser(DBConnect aDB)
        {
            mDB = aDB;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            User newUser = new User((Int32.Parse(itemSCPTextBox.Text)), (int)dropClass.SelectedIndex +1, textName.Text, textPassword.Text);
            mDB.addUser(newUser);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
