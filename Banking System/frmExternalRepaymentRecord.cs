using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Security.Cryptography;

namespace Banking_System
{
    public partial class frmExternalRepaymentRecord : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmExternalRepaymentRecord()
        {
            InitializeComponent();
        }

        private void frmRepaymentRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(RepaymentID)[Repayment ID],RTRIM(ExternalLoanRepayment.LoanID)[Loan ID], RTRIM(ExternalLoanRepayment.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(AmmountPaid)[Paid Ammount],RTRIM(Balance)[Balance],RTRIM(RepayMonths)[ Months Paid for], RTRIM(CashierName)[ Cashier Name]from MemberRegistration,ExternalLoanRepayment where ExternalLoanRepayment.MemberID=MemberRegistration.MemberID order by ExternalLoanRepayment.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoanRepayment");
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalLoanRepayment"].DefaultView;
                dataGridViewX1.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
            dataGridViewX1.DataSource = null;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(RepaymentID)[Repayment ID],RTRIM(ExternalLoanRepayment.LoanID)[Loan ID], RTRIM(ExternalLoanRepayment.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(AmmountPaid)[Paid Ammount],RTRIM(Balance)[Balance],RTRIM(RepayMonths)[ Months Paid for], RTRIM(CashierName)[ Cashier Name]from MemberRegistration,ExternalLoanRepayment where ExternalLoanRepayment.MemberID=MemberRegistration.MemberID and Repaymentdate between @date1 and @date2 order by ExternalLoanRepayment.ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " RePaymentdate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " rePaymentdate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoanRepayment");
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalLoanRepayment"].DefaultView;
                dataGridViewX1.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRepaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }
    }
}
