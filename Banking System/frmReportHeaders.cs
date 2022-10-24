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
    public partial class frmReportHeaders : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmReportHeaders()
        {
            InitializeComponent();
        }

        private void frmDiscountType_Load(object sender, EventArgs e)
        {
            string receiptlo = Properties.Settings.Default.receiptlogo;
            string reportlo = Properties.Settings.Default.reportlogo;
            if (receiptlo == "yes")
            {
                radioButton1.Checked = true;
            }else if(receiptlo == "no")
            {
                radioButton2.Checked = true;
            }
            if (reportlo == "yes")
            {
                radioButton4.Checked = true;
            }
            else if (receiptlo == "no")
            {
                radioButton3.Checked = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string receiptlogos = null;
            if (radioButton1.Checked == true)
            {
                receiptlogos = "yes";
            }
            else if (radioButton2.Checked == true)
            {
                receiptlogos = "no";
            }
            Properties.Settings.Default["receiptlogo"] = receiptlogos;
            Properties.Settings.Default.Save();

            string reportlogos = null;
            if (radioButton4.Checked == true)
            {
                reportlogos = "yes";
            }
            else if (radioButton3.Checked == true)
            {
                reportlogos = "no";
            }
            Properties.Settings.Default["reportlogo"] = reportlogos;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
