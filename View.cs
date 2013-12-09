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
    public partial class View : Form
    {
        DBConnect mDB;
        string[] mSCP;
        string mInterview;

        public View(DBConnect aDB, int aSCP)
        {
            InitializeComponent();
            mDB = aDB;
            mSCP = mDB.getSCP(aSCP);
            mInterview = mDB.getInterviewText(aSCP);
        }

        private void View_Load(object sender, EventArgs e)
        {
            lblSCPNum.Text = mSCP[0];
            lblClass.Text = ((ClassName)Convert.ToInt32(mSCP[1])).ToString();
            itemSCPTextBox.Text = mSCP[2];
            richDescription.Text = mSCP[3];
            richInterview.Text = mInterview;
        }
    }
}
