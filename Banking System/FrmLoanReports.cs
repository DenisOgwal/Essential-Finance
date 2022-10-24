using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanReports : Form
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
        public FrmLoanReports()
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
        private void FrmLoanReports_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void FrmLoanReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
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
                    rptAccountLoan rpt = new rptAccountLoan();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Loan where ApplicationDate between @date1 and @date2 and Issued='Yes'  order by ID ASC ";
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

        private void buttonX9_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptPaidLoanSchedule rpt = new rptPaidLoanSchedule();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'  order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = paidfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = paidto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("datefrom", paidfrom.Text);
                    rpt.SetParameterValue("dateto", paidto.Text);
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
            crystalReportViewer2.ReportSource = null;
            paidfrom.Text = DateTime.Today.ToString();
            paidto.Text = DateTime.Today.ToString();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
            unpaidfrom.Text = DateTime.Today.ToString();
            unpaidto.Text = DateTime.Today.ToString();
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
                rptUnPaidLoanSchedule rpt = new rptUnPaidLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Pending'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = unpaidfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = unpaidto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", unpaidfrom.Text);
                rpt.SetParameterValue("dateto", unpaidto.Text);
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
            rescheduledfrom.Text = DateTime.Today.ToString();
            rescheduledto.Text = DateTime.Today.ToString();
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
                rptRescheduledLoanSchedule rpt = new rptRescheduledLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Rescheduled'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = rescheduledfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = rescheduledto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", rescheduledfrom.Text);
                rpt.SetParameterValue("dateto", rescheduledto.Text);
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

        private void buttonX13_Click(object sender, EventArgs e)
        {
            crystalReportViewer5.ReportSource = null;
            toppedupfrom.Text = DateTime.Today.ToString();
            toppedupto.Text = DateTime.Today.ToString();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptToppedupLoanSchedule rpt = new rptToppedupLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='ToppedUp'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = toppedupfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = toppedupto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", toppedupfrom.Text);
                rpt.SetParameterValue("dateto", toppedupto.Text);
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

        private void buttonX16_Click(object sender, EventArgs e)
        {
            crystalReportViewer6.ReportSource = null;
            repaymentfrom.Text = DateTime.Today.ToString();
            repaymentto.Text = DateTime.Today.ToString();
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptLoanRepayment rpt = new rptLoanRepayment();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from LoanRepayment where Repaymentdate between @date1 and @date2 order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = repaymentfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = repaymentto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "LoanRepayment");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", repaymentfrom.Text);
                rpt.SetParameterValue("dateto", repaymentto.Text);
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

        private void buttonX19_Click(object sender, EventArgs e)
        {
            crystalReportViewer7.ReportSource = null;
            writtenofffrom.Text = DateTime.Today.ToString();
            writtenoffto.Text = DateTime.Today.ToString();
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptWrittenoffLoanSchedule rpt = new rptWrittenoffLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Written Off'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = writtenofffrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = writtenoffto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", writtenofffrom.Text);
                rpt.SetParameterValue("dateto", writtenoffto.Text);
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

        private void buttonX24_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptRecoveryLoanSchedule rpt = new rptRecoveryLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Recovery'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = recoverfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = recoverto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", recoverfrom.Text);
                rpt.SetParameterValue("dateto",recoverto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer8.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX22_Click(object sender, EventArgs e)
        {
            crystalReportViewer8.ReportSource = null;
            recoverfrom.Text = DateTime.Today.ToString();
            recoverto.Text = DateTime.Today.ToString();
        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            crystalReportViewer9.ReportSource = null;
            upcomingdate.Text = DateTime.Today.ToString();
            Daysleft.Text = null;
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
                rptUnPaidLoanSchedule rpt = new rptUnPaidLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Pending'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", repaymentdates);
                rpt.SetParameterValue("dateto", repaymentdates);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer9.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer10.ReportSource = null;
            clearancestatus.Text = "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptAccountLoans rpt = new rptAccountLoans();
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Loan where Clearance='"+clearancestatus.Text+"'  and Issued !='Pending' order by ID ASC ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Loan");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("loanstatus", clearancestatus.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer10.ReportSource = rpt;
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            crystalReportViewer11.ReportSource = null;
            pastdaysset.Text = DateTime.Today.ToString();
            dayspast.Text = null;
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                daynum = Convert.ToInt32(dayspast.Text);
                DateTime schedule = DateTime.Parse(pastdaysset.Text).Date;
                string paymentdates = (schedule.AddDays(-daynum)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");

                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptUnPaidLoanSchedule2 rpt = new rptUnPaidLoanSchedule2();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where PaymentDate <= @date1 and PaymentStatus='Pending'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", pastdaysset.Text);
                rpt.SetParameterValue("dateto", dayspast.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer11.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            crystalReportViewer12.ReportSource = null;
            finesfrom.Text = DateTime.Today.ToString();
           finesto.Text = DateTime.Today.ToString();
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptFinesLoanSchedule rpt = new rptFinesLoanSchedule();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid' and Fines >0 and Waivered='No'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = finesfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = finesto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", finesfrom.Text);
                rpt.SetParameterValue("dateto", finesto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer12.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
