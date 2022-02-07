using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmLoanType : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmLoanType()
        {
            InitializeComponent();
        }

        private void frmIntrestType_Load(object sender, EventArgs e)
        {
            string autolo = Properties.Settings.Default.loantype;
            if (autolo == "Daily")
            {
                radioButton1.Checked = true;
            }
            else if (autolo == "Monthly")
            {
                radioButton2.Checked = true;
            }
            else if (autolo == "Yearly")
            {
                radioButton3.Checked = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string loantypes = "null";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                loantypes = "Daily";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                loantypes = "Monthly";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["loantype"] = loantypes;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                loantypes = "Yearly";
            }
        }
    }
}
