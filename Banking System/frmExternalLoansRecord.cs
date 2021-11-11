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
    public partial class frmExternalLoansRecord : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmExternalLoansRecord()
        {
            InitializeComponent();
        }

        private void frmLoansRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID], RTRIM(LoanAmmount)[Loan Ammount],RTRIM(Securities)[Securities],RTRIM(OfficerName)[Officer Name],RTRIM(Comment)[Comment],RTRIM(Year)[Application Year],RTRIM(Months)[Application Months], RTRIM(Date)[Application Date],RTRIM(ManagerName)[Manager Name],RTRIM(ReviewComment)[Manager Review Comment], RTRIM(ReviewDate)[Manager Review Date],RTRIM(ChairpersonName)[ChairPerson Name],RTRIM(Decision)[Decision], RTRIM(DecisionDate)[Decision Date],RTRIM(Description)[Description],RTRIM(Recieved)[Reciept],RTRIM(RecievedDate)[Reciept Date] from ExternalLoans order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLoansRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID], RTRIM(LoanAmmount)[Loan Ammount],RTRIM(Securities)[Securities],RTRIM(OfficerName)[Officer Name],RTRIM(Comment)[Comment],RTRIM(Year)[Application Year],RTRIM(Months)[Application Months], RTRIM(Date)[Application Date],RTRIM(ManagerName)[Manager Name],RTRIM(ReviewComment)[Manager Review Comment], RTRIM(ReviewDate)[Manager Review Date],RTRIM(ChairpersonName)[ChairPerson Name],RTRIM(Decision)[Decision], RTRIM(DecisionDate)[Decision Date],RTRIM(Description)[Description],RTRIM(Recieved)[Reciept],RTRIM(RecievedDate)[Reciept Date] from ExternalLoans where  Date between @date1 and @date2  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
        }
    }
}
