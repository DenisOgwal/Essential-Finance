using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Banking_System
{
    public partial class FrmIncomeStatementReport : DevComponents.DotNetBar.Office2007Form
    {

        public FrmIncomeStatementReport()
        {
            InitializeComponent();
        }

        private void FrmSalarySlip_Load(object sender, EventArgs e)
        {

        }

        private void FrmSalarySlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmGeneralReport frm = new frmGeneralReport();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();*/
        }

    }
}
