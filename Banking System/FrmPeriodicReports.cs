using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmPeriodicReports : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmPeriodicReports()
        {
            InitializeComponent();
        }
        string officeadmin, recoveryofficer, relationshipmanager, directoroperations, managingdirector, directoraccounts = null;
        private void FrmPeriodicReports_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            SqlDataReader rdr = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label19.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                officeadmin = rdr["OfficeAdmin"].ToString().Trim();
                recoveryofficer = rdr["RecoveryOfficer"].ToString().Trim();
                relationshipmanager = rdr["RelationshipManager"].ToString().Trim();
                directoroperations = rdr["DirectorOperations"].ToString().Trim();
                managingdirector = rdr["ManagingDirector"].ToString().Trim();
                directoraccounts = rdr["DirectorAccounts"].ToString().Trim();
                if (officeadmin == "Yes") { tabItem1.Visible = true; } else { tabItem1.Visible = false; }
                if (recoveryofficer == "Yes") { tabItem4.Visible = true; } else { tabItem4.Visible = false; }
                if (relationshipmanager == "Yes") { tabItem2.Visible = true; } else { tabItem2.Visible = false; }
                if (directoroperations == "Yes") { tabItem3.Visible = true; } else { tabItem3.Visible = false; }
                if (managingdirector == "Yes") { tabItem5.Visible = true; } else { tabItem5.Visible = false; }
                if (directoraccounts == "Yes") { tabItem1.Visible = true; tabItem2.Visible = true; tabItem3.Visible = true; tabItem4.Visible = true; tabItem5.Visible = true; }
                else
                {
                }
            }
            else
            {
                tabItem1.Visible = false; tabItem2.Visible = false; tabItem3.Visible = false; tabItem4.Visible = false; tabItem5.Visible = false;
            }
            con.Close();

            }

        private void tabControl1_Click(object sender, EventArgs e)
        {

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
        private void buttonX3_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            datefrom.Text = DateTime.Today.ToString();
            dateto.Text = DateTime.Today.ToString();
            reportoptions1.Text ="";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            company();
            if (reportoptions1.Text == "New applied Loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansNew rpt = new rptLoansNew();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FirstApproval='Pending'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
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
            }else if (reportoptions1.Text == "Approved Loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansApproved rpt = new rptLoansApproved();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FinalApproval='Approved'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
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
            else if (reportoptions1.Text == "Denied Loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansDenied rpt = new rptLoansDenied();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FinalApproval='Rejected'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
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
            else if (reportoptions1.Text == "Still under processing")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansStillProcessing rpt = new rptLoansStillProcessing();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FinalApproval='Pending'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
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
            else if (reportoptions1.Text == "Loan collections")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanCollections rpt = new rptLoanCollections();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
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
            else if (reportoptions1.Text == "Collection Report Arrear")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanCollectionsPaid rpt = new rptLoanCollectionsPaid();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentDate < @date1 and PaymentStatus='Paid' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
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
            else if (reportoptions1.Text == "Collection Report Advance")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanCollectionsPaids rpt = new rptLoanCollectionsPaids();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentDate > @date1 and PaymentStatus='Paid' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
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
            else if (reportoptions1.Text == "Expected loan collection")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanCollectionsPaidss rpt = new rptLoanCollectionsPaidss();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Pending' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
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
            else if (reportoptions1.Text == "Total loan application fees collected")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    RptLoanApplicationCollections rpt = new RptLoanApplicationCollections();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from LoanApplicationPayment where PaymentDate between @date1 and @date2 order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "LoanApplicationPayment");
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
            else if (reportoptions1.Text == "Total loan processing fees collected")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanProcessingExpenses rpt = new rptLoanProcessingExpenses();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where DepositDate between @date1 and @date2 and SavingsID like 'SE%' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DepositDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DepositDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
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
        }

        private void reportoptions1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void FrmPeriodicReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label19.Text;
            frm.UserType.Text = label20.Text;
            frm.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            company();
            if (reportoptions2.Text == "New applied Loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansNewRelationship rpt = new rptLoansNewRelationship();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FirstApproval = 'Pending' and RegisteredBy='"+label19.Text+"'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom2.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto2.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom2.Text);
                    rpt.SetParameterValue("dateto", dateto2.Text); 
                    rpt.SetParameterValue("relationshipmanager", label19.Text);
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
            else if (reportoptions2.Text == "Loans pending to next months")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansStillProcessingRelationship rpt = new rptLoansStillProcessingRelationship();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FinalApproval = 'Pending' and RegisteredBy='" + label19.Text + "'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom2.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto2.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom2.Text);
                    rpt.SetParameterValue("dateto", dateto2.Text);
                    rpt.SetParameterValue("relationshipmanager", label19.Text);
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
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = null;
            datefrom2.Text = DateTime.Today.ToString();
            dateto2.Text = DateTime.Today.ToString();
            reportoptions2.Text = "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
            datefrom3.Text = DateTime.Today.ToString();
            dateto3.Text = DateTime.Today.ToString();
            reportoptions3.Text = "";
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            if (reportoptions3.Text == "New clients under demand notice level")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanDemandNoriceLevel rpt = new rptLoanDemandNoriceLevel();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2  and BalanceExist >0 and Fines>0 and Waivered='No'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom3.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto3.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom3.Text);
                    rpt.SetParameterValue("dateto", dateto3.Text);
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
            else if (reportoptions3.Text == "Total number of clients under demand notice level")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanDemandNoticeAll rpt = new rptLoanDemandNoticeAll();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate <= @date2  and BalanceExist >0 and Fines>0 and Waivered='No'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom3.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto3.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom3.Text);
                    rpt.SetParameterValue("dateto", dateto3.Text);
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
            else if (reportoptions3.Text == "Amount pending recovery")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanDemandNoticeRecovery rpt = new rptLoanDemandNoticeRecovery();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate <= @date2  and BalanceExist >0 and Fines>0 and Waivered='No' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom3.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto3.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom3.Text);
                    rpt.SetParameterValue("dateto", dateto3.Text);
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
            else if (reportoptions3.Text == "Amount recovered at demand notice level")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanDemandNoticeRecovered rpt = new rptLoanDemandNoticeRecovered();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate <= @date2  and BalanceExist =0 and Fines>0 and Waivered='No' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom3.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto3.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom3.Text);
                    rpt.SetParameterValue("dateto", dateto3.Text);
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
            else if (reportoptions3.Text == "Number of clients rescheduled at demand notice level")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanDemandrescheduled rpt = new rptLoanDemandrescheduled();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2  and PaymentStatus='Rescheduled' and Fines>0 and Waivered='No' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom3.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto3.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom3.Text);
                    rpt.SetParameterValue("dateto", dateto3.Text);
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
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            crystalReportViewer4.ReportSource = null;
            datefrom4.Text = DateTime.Today.ToString();
            dateto4.Text = DateTime.Today.ToString();
            reportoptions4.Text = "";
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            company();
            if (reportoptions4.Text == "Total registry of all clients in recovery")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanRecoveryRegistry rpt = new rptLoanRecoveryRegistry();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where  PaymentStatus='Recovery' and BalanceExist > 0  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom4.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto4.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom4.Text);
                    rpt.SetParameterValue("dateto", dateto4.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer4.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (reportoptions4.Text == "Total amount recovered")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanRecoveryPaid rpt = new rptLoanRecoveryPaid();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and BalanceExist = 0 and Waivered='Recovery' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom4.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto4.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom4.Text);
                    rpt.SetParameterValue("dateto", dateto4.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer4.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions4.Text == "Total amount spent on recovery")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoanProcessingExpensesRecovery rpt = new rptLoanProcessingExpensesRecovery();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where DepositDate between @date1 and @date2 and SavingsID like 'SRE%' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DepositDate").Value = datefrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DepositDate").Value = dateto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom.Text);
                    rpt.SetParameterValue("dateto", dateto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer4.ReportSource = rpt;
                    myConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            crystalReportViewer5.ReportSource = null;
            datefrom5.Text = DateTime.Today.ToString();
            dateto5.Text = DateTime.Today.ToString();
            reportoptions5.Text = "";
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            company();
            if (reportoptions5.Text == "Registry of new loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansNewRegistry rpt = new rptLoansNewRegistry();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and FirstApproval='Approved'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of rescheduled loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansRescheduled rpt = new rptLoansRescheduled();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Rescheduled'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of top up loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansToppedup rpt = new rptLoansToppedup();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='ToppedUp'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of cleared loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansCleared rpt = new rptLoansCleared();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of Written off loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansWritenoff rpt = new rptLoansWritenoff();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of all currently running loans")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptLoansRunning rpt = new rptLoansRunning();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentStatus='Pending'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of new creditors")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalLoansNew rpt = new rptExternalLoansNew();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalLoans where Date between @date1 and @date2 order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalLoans");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of principal payments")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalPaidPrincipal rpt = new rptExternalPaidPrincipal();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalRepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Registry of interest payments")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalPaidIntrest rpt = new rptExternalPaidIntrest();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalLoanRepayment where Repaymentdate between @date1 and @date2  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalLoanRepayment");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reportoptions5.Text == "Current position")
            {
                try
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptExternalLoanCurrentPosition rpt = new rptExternalLoanCurrentPosition();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where  PaymentStatus='Pending' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = datefrom5.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = dateto5.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "ExternalRepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", datefrom5.Text);
                    rpt.SetParameterValue("dateto", dateto5.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
