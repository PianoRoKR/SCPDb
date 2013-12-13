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
    public partial class Adendum : Form
    {
        DBConnect mDB;
        string mAddNum;
        int mSCPNum;

        public Adendum(DBConnect aDB, int aSCPNum)
        {
            mDB = aDB;
            mSCPNum = aSCPNum;
            mAddNum = mDB.getNextAddendum(aSCPNum);
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Adendum_Load(object sender, EventArgs e)
        {
            labelItem.Text = labelItem.Text + " " + mSCPNum + " Adendum: " + mAddNum;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("No Text Entered");
            }
            else
            {
                if (mDB.addAddendum(mSCPNum, mAddNum, richTextBox1.Text))
                    this.Close();
                else
                    MessageBox.Show("Adendum failed to be inserted!");
            }
        }
    }
}
