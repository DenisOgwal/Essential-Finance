using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmAccountReports : Form
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
        public FrmAccountReports()
        {
            InitializeComponent();
        }

        private void FrmAccountReports_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void FrmAccountReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            datefrom.Text = DateTime.Today.ToString();
            dateto.Text = DateTime.Today.ToString();
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
                    companyaddress = rdr.GetString(5).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                rptOpennedAccounts rpt = new rptOpennedAccounts();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Account where RegistrationDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RegistrationDate").Value = datefrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RegistrationDate").Value = dateto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Account");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = null;
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
            AccountNumber.Text = "";
        }

        private void AccountNumber_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.AccountNumber.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (AccountNumber.Text == "")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountSavings rpt = new rptAccountSavings();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and Transactions='Deposit' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", savingsfrom.Text);
                    rpt.SetParameterValue("dateto", savingsto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer2.ReportSource = rpt;
                }
                else
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountSavings rpt = new rptAccountSavings();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and AccountNo='"+AccountNumber.Text+ "' and Transactions='Deposit' order by ID ASC";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", savingsfrom.Text);
                    rpt.SetParameterValue("dateto", savingsto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer2.ReportSource = rpt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
            transactionsfrom.Text = DateTime.Today.ToString();
            transactionsto.Text = DateTime.Today.ToString();
            AccountNumber1.Text = "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (AccountNumber1.Text == "")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountTransactionsIndividual rpt = new rptAccountTransactionsIndividual();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = transactionsfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = transactionsto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", transactionsfrom.Text);
                    rpt.SetParameterValue("dateto", transactionsto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer3.ReportSource = rpt;
                }
                else
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountTransactions rpt = new rptAccountTransactions();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and AccountNo='" + AccountNumber1.Text + "' order by ID ASC";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = transactionsfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = transactionsto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", transactionsfrom.Text);
                    rpt.SetParameterValue("dateto", transactionsto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer3.ReportSource = rpt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountNumber1_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.AccountNumber1.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            crystalReportViewer4.ReportSource = null;
            loanschedulesfrom.Text = DateTime.Today.ToString();
            loanschedulesto.Text = DateTime.Today.ToString();
            AccountNumber2.Text = "";
            loanids.Text = "";
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (AccountNumber2.Text == "")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountLoanSchedule rpt = new rptAccountLoanSchedule();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = loanschedulesfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = loanschedulesto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", loanschedulesfrom.Text);
                    rpt.SetParameterValue("dateto", loanschedulesto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer4.ReportSource = rpt;
                }
                else if(AccountNumber2.Text != "" && loanids.Text=="All")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountLoanSchedule rpt = new rptAccountLoanSchedule();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and AccountNumber='" + AccountNumber2.Text + "' order by ID ASC";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = loanschedulesfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = loanschedulesto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", loanschedulesfrom.Text);
                    rpt.SetParameterValue("dateto", loanschedulesto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer4.ReportSource = rpt;
                }
                else
                {
                    try
                    {

                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        FrmLoanScheduleReport frm3 = new FrmLoanScheduleReport();
                        rptLoanRepaymentSchedule rpt = new rptLoanRepaymentSchedule();
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from RepaymentSchedule where LoanID='" + loanids.Text + "' order by ID Asc ";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "RepaymentSchedule");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        crystalReportViewer4.ReportSource = rpt;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountNumber2_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.AccountNumber2.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            crystalReportViewer5.ReportSource = null;
            issuedloansfrom.Text = DateTime.Today.ToString();
            issuedloansto.Text = DateTime.Today.ToString();
            AccountNumber3.Text = "";
        }

        private void AccountNumber3_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.AccountNumber3.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (AccountNumber3.Text == "")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountLoan rpt = new rptAccountLoan();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = issuedloansfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = issuedloansto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", issuedloansfrom.Text);
                    rpt.SetParameterValue("dateto", issuedloansto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                }
                else
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountLoan rpt = new rptAccountLoan();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and AccountNo='" + AccountNumber3.Text + "' order by ID ASC";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ApplicationDate").Value = issuedloansfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ApplicationDate").Value = issuedloansto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Loan");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", issuedloansfrom.Text);
                    rpt.SetParameterValue("dateto", issuedloansto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer5.ReportSource = rpt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountNumber2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select LoanID from Loan where AccountNo= '" + AccountNumber2.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                loanids.Items.Clear();
                loanids.Items.Add("All");
                while (rdr.Read() == true)
                {
                    loanids.Items.Add(rdr[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void crystalReportViewer6_Load(object sender, EventArgs e)
        {

        }

        private void account6_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void account6_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.account6.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            crystalReportViewer6.ReportSource = null;
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            account6.Text = "";
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptAccountExpenses rpt = new rptAccountExpenses();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Expenses where Date between @date1 and @date2 and AccountNumber='" + account6.Text + "' order by ID ASC";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = issuedloansfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = issuedloansto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Expenses");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", issuedloansfrom.Text);
                    rpt.SetParameterValue("dateto", issuedloansto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer6.ReportSource = rpt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
