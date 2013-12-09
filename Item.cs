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
    enum ClassName
    {
            Safe = 1,
            Euclid = 2,
            Keter = 3
    }

    public partial class Item : Form
    {
        DBConnect mDB;
        string[] mSCP;
        
        public Item(DBConnect aDB, int aScpNum)
        {
            InitializeComponent();
            mDB = aDB;
            mSCP = mDB.getSCP(aScpNum);
        }

        private void itemClass_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Item_Load(object sender, EventArgs e)
        {
            itemSCPNumTextBox.Text = mSCP[0];
            itemClassTextBox.Text = ((ClassName)Convert.ToInt16(mSCP[1])).ToString();
            itemSCPTextBox.Text = mSCP[2];
            itemDescriptionTextBox.Text = mSCP[3];
        }

        private void itemDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void itemDescrip_Click(object sender, EventArgs e)
        {

        }
    }
}
