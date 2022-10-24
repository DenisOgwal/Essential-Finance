﻿using System;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmMonthlyChargeSetting : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMonthlyChargeSetting()
        {
            InitializeComponent();
        }

        private void frmMonthlyChargeSetting_Load(object sender, EventArgs e)
        {
            string autolo = Properties.Settings.Default.monthlycharge;
            if (autolo == "Yes")
            {
                radioButton1.Checked = true;
                
            }
            else
            {
                radioButton2.Checked = true;
            }
        }
        string monthlychargeset = null;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                monthlychargeset = "Yes";
            }
            else
            {
                radioButton2.Checked = true;
                monthlychargeset = "No";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                monthlychargeset = "No";
            }
            else
            {
                radioButton1.Checked = true;
                monthlychargeset = "Yes";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["monthlycharge"] = monthlychargeset;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
