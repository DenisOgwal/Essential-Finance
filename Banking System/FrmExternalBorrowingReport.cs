using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmExternalBorrowingReport : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmExternalBorrowingReport()
        {
            InitializeComponent();
        }
        public void company()
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct6 = "select * from CompanyNames";
                cmd = new SqlCommand(ct6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyname = rdr.GetString(1).Trim();
                    companyaddress = rdr.GetString(7).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmExternalBorrowingReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void FrmExternalBorrowingReport_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct PaymentStatus FROM ExternalRepaymentSchedule";
                rdr = cmd.ExecuteReader();
                while (rdr.Read() == true)
                {
                    schedules.Items.Add(rdr[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            datefrom.Text = DateTime.Today.ToString();
            dateto.Text = DateTime.Today.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptExternalLoans rpt = new rptExternalLoans();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from ExternalLoans where Date between @date1 and @date2 order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ExternalLoans");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", datefrom.Text);
                rpt.SetParameterValue("dateto", dateto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer1.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = null;
            externalschedulefrom.Text = DateTime.Today.ToString();
            externalscheduleto.Text = DateTime.Today.ToString();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (schedules.Text == "All")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalLoanSchedule rpt = new rptExternalLoanSchedule();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = externalschedulefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = externalscheduleto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalRepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", externalschedulefrom.Text);
                    rpt.SetParameterValue("dateto", externalscheduleto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer2.ReportSource = rpt;
                    myConnection.Close();
                }
                else
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalLoanSchedule rpt = new rptExternalLoanSchedule();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='"+schedules.Text+"' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = externalschedulefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = externalscheduleto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalRepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", externalschedulefrom.Text);
                    rpt.SetParameterValue("dateto", externalscheduleto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer2.ReportSource = rpt;
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
            externalrepaymentsfrom.Text = DateTime.Today.ToString();
            externalrepaymentsto.Text = DateTime.Today.ToString();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptExternalLoanRepayment rpt = new rptExternalLoanRepayment();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from ExternalLoanRepayment where Repaymentdate between @date1 and @date2  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = externalrepaymentsfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = externalrepaymentsto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ExternalLoanRepayment");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", externalrepaymentsfrom.Text);
                rpt.SetParameterValue("dateto", externalrepaymentsto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer3.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails6 frm = new frmClientDetails6();
            frm.ShowDialog();
            loanid.Text = frm.clientnames.Text;
        }

        private void loanid_TextChanged(object sender, EventArgs e)
        {

            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptExternalLoanSchedule3 rpt = new rptExternalLoanSchedule3();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where  LoanID='"+ loanid.Text+ "' order by ID ASC ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ExternalRepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", externalschedulefrom.Text);
                rpt.SetParameterValue("dateto", externalscheduleto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer2.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loanid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
