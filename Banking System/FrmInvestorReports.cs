using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmInvestorReports : Form
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
        public FrmInvestorReports()
        {
            InitializeComponent();
        }

        private void FrmInvestorReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void FrmInvestorReports_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
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
        private void buttonX1_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptInvestorAccount rpt = new rptInvestorAccount();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from InvestorAccount where RegistrationDate between @date1 and @date2 order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RegistrationDate").Value = datefrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RegistrationDate").Value = dateto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestorAccount");
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
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptInvestments rpt = new rptInvestments();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from InvestorSavings where Date between @date1 and @date2 and Transactions='Deposit' order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestorSavings");
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
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
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
                rptInvestorAccountBalance rpt = new rptInvestorAccountBalance();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select InvestorSavings.AccountNo, AccountName, Date,Accountbalance from InvestorSavings  INNER JOIN (SELECT AccountNo, Max(ID) as ID from InvestorSavings group by AccountNo) AS b ON InvestorSavings.AccountNo=b.AccountNo and InvestorSavings.ID=b.ID";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestorSavings");
                rpt.SetDataSource(myDS);
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

        private void buttonX10_Click(object sender, EventArgs e)
        {
            crystalReportViewer4.ReportSource = null;
            transactionsfrom.Text = DateTime.Today.ToString();
            transactionsto.Text = DateTime.Today.ToString();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptInvestmentsTransactions rpt = new rptInvestmentsTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from InvestmentAppreciation where Date between @date1 and @date2 and Approved='Approved'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = transactionsfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = transactionsto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestmentAppreciation");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", transactionsfrom.Text);
                rpt.SetParameterValue("dateto", transactionsto.Text);
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

        private void accountnumber_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            this.accountnumber.Text = frm.clientnames.Text;
            return;
        }
        SqlDataReader rdr = null;
        private void accountnumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountnumber.Text + "'";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                while (rdr.Read() == true)
                {
                    savingsid.Items.Add(rdr.GetString(0).Trim());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer5.ReportSource = null;
            accountnumber.Text = "";
            savingsid.Text = "";
        }
        string maturitydate, investmentplan, maturityperiod, investmentrate = null;

        private void accountnumber1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountnumber1.Text + "'";
                rdr = cmd.ExecuteReader();
                savingsid1.Items.Clear();
                while (rdr.Read() == true)
                {
                    savingsid1.Items.Add(rdr.GetString(0).Trim());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountnumber1_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            this.accountnumber1.Text = frm.clientnames.Text;
            return;
        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            crystalReportViewer7.ReportSource = null;
            Daysleft.Text = "";
            upcomingdate.Text = DateTime.Today.ToString();
        }
        int daynum = 0;
        private void buttonX27_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                daynum = Convert.ToInt32(Daysleft.Text);
                DateTime schedule = DateTime.Parse(upcomingdate.Text).Date;
                string paymentdates = (schedule.AddDays(daynum)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");

                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptInvestmentss rpt = new rptInvestmentss();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from InvestorSavings where OtherMaturityDate <= @date1 order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateTime.Parse(repaymentdates).Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestorSavings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", repaymentdates);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer7.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountno4_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            this.accountno4.Text = frm.clientnames.Text;
            return;
        }

        private void accountno4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountno4.Text + "'";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                while (rdr.Read() == true)
                {
                    accounttrans.Items.Add(rdr.GetString(0).Trim());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            company();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT OtherMaturityDate,MaturityPeriod,InterestRate,InvestmentPlan  FROM InvestorSavings where AccountNo='" + accountnumber1.Text + "' and SavingsID='" + savingsid1.Text + "' ";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                if (rdr.Read())
                {
                    maturitydate = rdr["OtherMaturityDate"].ToString();
                    investmentplan = rdr["InvestmentPlan"].ToString();
                    maturityperiod = rdr["MaturityPeriod"].ToString();
                    investmentrate = rdr["InterestRate"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //this.Hide();
                Cursor = Cursors.WaitCursor;
                //timer1.Enabled = true;
                rptLegalCertificate rpt = new rptLegalCertificate(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from InvestmentSchedule where InvestmentID='" + savingsid1.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestmentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("investmentterm", maturityperiod);
                rpt.SetParameterValue("investmentplan", investmentplan);
                rpt.SetParameterValue("maturitydate", maturitydate);
                rpt.SetParameterValue("monthlyrate", investmentrate);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer6.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            crystalReportViewer6.ReportSource = null;
            accountnumber1.Text = "";
            savingsid1.Text = "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            company();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT OtherMaturityDate,MaturityPeriod,InterestRate,InvestmentPlan  FROM InvestorSavings where AccountNo='" + accountnumber.Text + "' and SavingsID='"+savingsid.Text+"' ";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                if (rdr.Read())
                {
                    maturitydate = rdr["OtherMaturityDate"].ToString();
                    investmentplan = rdr["InvestmentPlan"].ToString();
                    maturityperiod = rdr["MaturityPeriod"].ToString();
                    investmentrate = rdr["InterestRate"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //this.Hide();
                Cursor = Cursors.WaitCursor;
                //timer1.Enabled = true;
                RptInvestmentSchedule rpt = new RptInvestmentSchedule(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from InvestmentSchedule where InvestmentID='" + savingsid.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestmentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("investmentterm", maturityperiod);
                rpt.SetParameterValue("investmentplan", investmentplan);
                rpt.SetParameterValue("maturitydate", maturitydate);
                rpt.SetParameterValue("monthlyrate", investmentrate);
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
