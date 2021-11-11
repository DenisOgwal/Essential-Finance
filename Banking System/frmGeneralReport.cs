using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmGeneralReport : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
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
        int devidends = 0;
        int unpaidloans = 0;
        int extunpaidloans = 0;
        int duepayments = 0;
        int extintrep = 0;
        int loanssum = 0;
        int savingssum = 0;
        int netincome = 0;
        int externalloanssum = 0;
        int cashathand = 0;
        int loanrep = 0;
        int investments = 0;
        int totalsharereal = 0;
        string externalloanrepaymentInterest = "0";
        public frmGeneralReport()
        {
            InitializeComponent();
        }

        private void frmGeneralReport_Load(object sender, EventArgs e)
        {
            /*Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;*/
        }

        private void frmGeneralReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        public void Reset()
        {
           
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
            loanrepayments.Text = "";
            Totalsavings.Text = "";
            TotalShareCapital.Text = "";
            Totalregistrationfees.Text = "";
            TotalFines.Text = "";
            Totalexpenses.Text = "";
            Totalequipmentpurchase.Text = "";
            TotalUnpaidLoans.Text = "";
            TotalSalaries.Text = "";
           // netincome.Text = "";
            moneyavailable.Text = "";
            totaloutflows.Text = "";
            TotalDispensibleincome.Text = "";
            withdrawcharges.Text = "";
            externalloans.Text = "";
            otherincomes.Text = "";
            loanprocessing.Text = "";
            Annualsubscription.Text = "";
            withdraws.Text = "";
            externalloanrepayment.Text = "";
            Grants.Text = "";
            broughtforward.Text = "";
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
            Reset();
        }
        string TotalSalariespayable = "0";
        string Totalexpensespayable = "0";
        string Totalloanspayable = "0";
        int totalintrests = 0; string passbook = "0"; string ledger = "0"; string loanform = "0"; string principalammount = "0";
         int staffpa = 0; int expdue = 0;
        private void buttonX2_Click(object sender, EventArgs e)
        {

            Finance2();
            //Loan repayment
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AmmountPaid from LoanRepayment where Repaymentdate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPaid) from Loanrepayment where Repaymentdate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                    loanrepayments.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    loanrepayments.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from IssuedLoans where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from IssuedLoans where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    TotalUnpaidLoans.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    TotalUnpaidLoans.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from LoanRepayment where Repaymentdate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Interest) from Loanrepayment where Repaymentdate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                    totalintrests = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    totalintrests = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Loans paid principal
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from LoanRepayment where Repaymentdate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalAmmount) from Loanrepayment where Repaymentdate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                    principalammount = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    principalammount = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select LoanAmmount from ExternalLoans where RecievedDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RecievedDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RecievedDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(LoanAmmount) from ExternalLoans where RecievedDate between @date1 and @date2 and Recieved='Recieved'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RecievedDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RecievedDate").Value = DateTo.Value.Date;
                    externalloans.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    externalloans.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("External Loans Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Passbook,Loan,Ledger
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    passledger.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    passledger.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //end incomes

            //Expenses
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from Expenses where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Totalexpenses.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalexpenses.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Expenses Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //salaries
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Totalpaid from EmployeePayment where PaymentDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Totalpaid) from EmployeePayment where PaymentDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    TotalSalaries.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    TotalSalaries.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Payment exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                buttonX3.Enabled = true;
                buttonX4.Enabled = true;
                buttonX5.Enabled = true;
                buttonX6.Enabled = true;
                int totalexpense = Convert.ToInt32(Totalexpenses.Text);
                int totalequipment = Convert.ToInt32(Totalequipmentpurchase.Text);
                int totalloans = Convert.ToInt32(TotalUnpaidLoans.Text);
                int totalsalaries = Convert.ToInt32(TotalSalaries.Text);
                int totalwithdraws = Convert.ToInt32(withdraws.Text);
                int totalexternalloanrepayment = Convert.ToInt32(externalloanrepayment.Text);
                int TotalOutflows = 0;

                TotalOutflows = totalexpense + totalequipment + totalloans + totalsalaries + totalwithdraws + totalexternalloanrepayment + devidends + Convert.ToInt32(investmentcapital.Text);
                totaloutflows.Text = TotalOutflows.ToString();

                //incomes
                int totalrepayments = Convert.ToInt32(loanrepayments.Text);
                int totalsavings = Convert.ToInt32(Totalsavings.Text);
                int totalshares = Convert.ToInt32(TotalShareCapital.Text);
                int totalregistration = Convert.ToInt32(Totalregistrationfees.Text);
                int totalfine = Convert.ToInt32(TotalFines.Text);
                int grantfee = Convert.ToInt32(Grants.Text);
                int totalexternalloans = Convert.ToInt32(externalloans.Text);
                int totalotherincomes = Convert.ToInt32(otherincomes.Text);
                int totalloanprocessing = Convert.ToInt32(loanprocessing.Text);
                int totalannualsubscription = Convert.ToInt32(Annualsubscription.Text);
                int loaninsurancefees = Convert.ToInt32(loaninsurance.Text);
                int passbookledgerform = Convert.ToInt32(passledger.Text);

                TotalDispensibleincome.Text = (loaninsurancefees + passbookledgerform + totalannualsubscription + totalloanprocessing + totalotherincomes + totalexternalloans + totalrepayments + totalsavings + totalshares + totalregistration + totalfine + grantfee + Convert.ToInt32(investment.Text)).ToString();
                cashathand = (Convert.ToInt32(TotalDispensibleincome.Text) + Convert.ToInt32(broughtforward.Text)) - Convert.ToInt32(totaloutflows.Text);
                moneyavailable.Text = cashathand.ToString();

                int TotalDispensibleincomes = (loaninsurancefees + passbookledgerform + totalannualsubscription + totalloanprocessing + totalotherincomes + totalrepayments + totalregistration + totalfine + grantfee + Convert.ToInt32(withdrawcharges.Text) + Convert.ToInt32(monthlycharges.Text) + Convert.ToInt32(investment.Text)) + loanrep;
                int TotalOutflow = Convert.ToInt32(investmentcapital.Text) + Convert.ToInt32(TotalSalaries.Text) + staffpa + Convert.ToInt32(Totalexpenses.Text) + expdue + totalexternalloanrepayment + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Totalloanspayable)));
                netincome = TotalDispensibleincomes - TotalOutflow;
                buttonX3.Enabled = true;
                buttonX4.Enabled = true;
                buttonX5.Enabled = true;
                buttonX6.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            company();
            if (TotalDispensibleincome.Text == "")
            {
                MessageBox.Show("Please first set parameters and click view details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonX2.Focus();
                return;
            }
            try
            {
                finance();
                Finance2();
                //this.Hide();
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptSummaryReport rpt = new rptSummaryReport(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
                FrmIncomeStatementReport frm = new FrmIncomeStatementReport();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and Deposit !='' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("totalrepayment", loanrepaymentsintrest);
                rpt.SetParameterValue("totalregistration", registrationfees);
                rpt.SetParameterValue("totalgrant", totalgrant);
                rpt.SetParameterValue("totalloanprocessingcharge", totalloanprocessing);
                rpt.SetParameterValue("totalannualsubscription", totalannualsubscription);
                rpt.SetParameterValue("totalwithdrawcharge", totalwithdrawcharges);
                rpt.SetParameterValue("loaninsurancefees", totalloaninsurance);
                rpt.SetParameterValue("ledgerfees", totalledgerfees);
                rpt.SetParameterValue("loanformfees", totalloanformfees);
                rpt.SetParameterValue("passbookfees", totalpassbookfees);
                rpt.SetParameterValue("monthlycharges", totalmonthlycharges);
                rpt.SetParameterValue("totalloans", totalloanprincipal);
                rpt.SetParameterValue("totalsalaries", totalsalaries);
                rpt.SetParameterValue("totalotherincomes", totalotherincomes);
                rpt.SetParameterValue("totalfines", totalfines);
                rpt.SetParameterValue("serviceintrest", Convert.ToInt32(externalloanintrest));
                rpt.SetParameterValue("totalexpenses", totalexpenses);
                rpt.SetParameterValue("investmentcapital", totalinvestmentcapital);
                rpt.SetParameterValue("investmentreturns", totalinvestmentreturns);
                rpt.SetParameterValue("From", DateFrom.Value);
                rpt.SetParameterValue("To", DateTo.Value);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int totalinvestmentreturns, totalinvestmentcapital, totalexpenses,totalfines, totalotherincomes, totalsalaries, totalloanprincipal, totalmonthlycharges, totalpassbookfees, totalloanformfees, totalledgerfees, totalloaninsurance, totalwithdrawcharges, totalannualsubscription, totalloanprocessing, totalgrant, registrationfees, loanrepaymentsintrest = 0;
        public void finance()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    loanrepaymentsintrest = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    loanrepaymentsintrest = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    registrationfees = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    registrationfees = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registration fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select GrantFee from GrantFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(GrantFee) from GrantFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalgrant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalgrant = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from LoanProcessingFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from LoanProcessingFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalloanprocessing = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalloanprocessing = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AnnualAmmount from AnnualFeesPayment where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AnnualAmmount) from AnnualFeesPayment where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalannualsubscription = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalannualsubscription = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Annual Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select withdrawFee from WithdrawCharges where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(withdrawFee) from WithdrawCharges where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalwithdrawcharges = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalwithdrawcharges = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Withdraw Charges Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select InsuranceAmmount from LoanInsuranceFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(InsuranceAmmount) from LoanInsuranceFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalloaninsurance = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalloaninsurance = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan Insurance Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Ledger' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Ledger'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalledgerfees = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalledgerfees = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Loan Form ' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Loan Form'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalloanformfees = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalloanformfees = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Passbook' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Passbook'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalpassbookfees = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalpassbookfees = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Monthly Charge'  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where Date between @date1 and @date2  and Transactions ='Monthly Charge'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalmonthlycharges = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalmonthlycharges = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Monthly Charges  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPay) from RepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    totalloanprincipal = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalloanprincipal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Totalpaid from EmployeePayment where PaymentDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Totalpaid) from EmployeePayment where PaymentDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    totalsalaries = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalsalaries = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Employee payment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select OtherFee from OtherIncomes where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalotherincomes = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalotherincomes = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Other incomes brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Finefee from Fines where  Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(FineFee) from Fines where  Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalfines = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalfines = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fine fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from Expenses where  Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalexpenses = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalexpenses = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Price from Investment where PriceDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PriceDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Price) from Investment where PriceDate between @date1 and @date2 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PriceDate").Value = DateTo.Value.Date;
                    totalinvestmentcapital = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalinvestmentcapital = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Investment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select ReturnFee from InvestmentReturns where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(ReturnFee) from InvestmentReturns where Date  between @date1 and @date2 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalinvestmentreturns = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    totalinvestmentreturns = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Return fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            company();
            if (broughtforward.Text == "")
            {
                MessageBox.Show("Please first set parameters and click view details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonX2.Focus();
                return;
            }
            try
            {
                //int currentyear = DateTime.Today.Year;
                //DateFrom.Text = "01/Jan/" + currentyear;
                finance3();
                Finance2();
                //this.Hide();
                int costs = Convert.ToInt32(externalloanintrest) + Convert.ToInt32(Totalexpensespayable)+ Convert.ToInt32(TotalSalariespayable)+ Convert.ToInt32(devidendstext.Text);
                int cashbd = (broughtforwardf + savingsf + externaloansf + loaninsurancef + loanprocessingf + annualsubscriptionf + grantsf + sharesf + registrationfeesf + finesf + otherincomesf + ledgerloanf + investmentreturnsf + loanrepaymentsf) - (salariesf + loansf + equipmentf + expensesf + externaloanrepaymentf + investmentf + withdrawf + drawingsf);
                int netincomes = (Convert.ToInt32(loanrepaymentsintrest)+Convert.ToInt32(withdrawcharges.Text)+Convert.ToInt32(monthlycharges.Text)+Convert.ToInt32(passbook)+Convert.ToInt32(loanform)+Convert.ToInt32(ledger)+Convert.ToInt32(otherincomes.Text)+Convert.ToInt32(TotalFines.Text)+(Convert.ToInt32(Totalregistrationfees.Text) + registrationdue)+Convert.ToInt32(Grants.Text)+(Convert.ToInt32(Annualsubscription.Text) + annauldue)+(Convert.ToInt32(loaninsurance.Text) + loaninsurancedue)+ (Convert.ToInt32(loanprocessing.Text) + loanprosdue))-costs;
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptBalanceSheet rpt = new rptBalanceSheet(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
                FrmBalanceSheetReport frm = new FrmBalanceSheetReport();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and Deposit !='' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("balancebd", cashbd);
                rpt.SetParameterValue("cash", cashathand);
                rpt.SetParameterValue("cashatbank1", Cashatbank);
                rpt.SetParameterValue("cashatbank2", CashAtabank2);
                rpt.SetParameterValue("cashatbank3", CashAtabank3);
                rpt.SetParameterValue("bank1", bank1);
                rpt.SetParameterValue("bank2", bank2);
                rpt.SetParameterValue("bank3", bank3);
                rpt.SetParameterValue("accountsrecievable", duepayments);
                rpt.SetParameterValue("issuedloans", Convert.ToInt32(loanssum.ToString()));
                rpt.SetParameterValue("equipment", Convert.ToInt32(Totalequipmentpurchase.Text));
                rpt.SetParameterValue("duepaymentsliability", duepaymentsliability);
                rpt.SetParameterValue("externalloans", Convert.ToInt32(externalloanssum));
                rpt.SetParameterValue("savings", Convert.ToInt32(savingssum));
                rpt.SetParameterValue("balanceforward", Convert.ToInt32(broughtforward.Text));
                rpt.SetParameterValue("investment", Convert.ToInt32(investments));
                rpt.SetParameterValue("sharecapital", Convert.ToInt32(TotalShareCapital.Text));
                rpt.SetParameterValue("netincomes", netincomes);
                rpt.SetParameterValue("datefrom", DateFrom.Value);
                rpt.SetParameterValue("dateto", DateTo.Value);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        int Cashatbank = 0; int CashAtabank2 = 0; int CashAtabank3 = 0; string bank1 = "N/A"; string bank2 = "N/A"; string bank3 = "N/A"; int externalloanintrest = 0;int exppa = 0; int unpaidequipment = 0; int duepaymentsliability = 0; int registrationdue = 0; int loaninsurancedue = 0; int loanprosdue = 0; int annauldue=0;
        private void buttonX4_Click(object sender, EventArgs e)
        {
            company();
            if (broughtforward.Text == "")
            {
                MessageBox.Show("Please first set parameters and click view details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonX2.Focus();
                return;
            }
            try
            {
               
                Finance2();
                finance3();
                //this.Hide();
                int cashbd = (broughtforwardf + savingsf + externaloansf + loaninsurancef + loanprocessingf + annualsubscriptionf + grantsf + sharesf + registrationfeesf + finesf + otherincomesf + ledgerloanf + investmentreturnsf + loanrepaymentsf) - (salariesf + loansf + equipmentf + expensesf + externaloanrepaymentf + investmentf + withdrawf + drawingsf);
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rpttrialbalance1 rpt = new rpttrialbalance1(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();//The DataSet you created.
                FrmTrialBalanceReport frm = new FrmTrialBalanceReport();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and Deposit !='' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("balancebd", cashbd);
                rpt.SetParameterValue("cashathand", cashathand);
                rpt.SetParameterValue("cashatbank1", Cashatbank);
                rpt.SetParameterValue("cashatbank2", CashAtabank2);
                rpt.SetParameterValue("cashatbank3", CashAtabank3);
                rpt.SetParameterValue("bank1", bank1);
                rpt.SetParameterValue("bank2", bank2);
                rpt.SetParameterValue("bank3", bank3);
                rpt.SetParameterValue("savings", Convert.ToInt32(savingssum.ToString()));
                rpt.SetParameterValue("externalloans", Convert.ToInt32(externalloanssum.ToString()));
                rpt.SetParameterValue("loaninsurancefees", (Convert.ToInt32(loaninsurance.Text)+ loaninsurancedue));
                rpt.SetParameterValue("loanprocessing", (Convert.ToInt32(loanprocessing.Text)+loanprosdue));
                rpt.SetParameterValue("annualsubscription", (Convert.ToInt32(Annualsubscription.Text)+ annauldue));
                rpt.SetParameterValue("grants", Convert.ToInt32(Grants.Text));
                rpt.SetParameterValue("sharecapital", Convert.ToInt32(TotalShareCapital.Text));
                rpt.SetParameterValue("registrationfees", (Convert.ToInt32(Totalregistrationfees.Text)+ registrationdue));
                rpt.SetParameterValue("fine", Convert.ToInt32(TotalFines.Text));
                rpt.SetParameterValue("income", Convert.ToInt32(otherincomes.Text));
                rpt.SetParameterValue("ledgerfees", Convert.ToInt32(ledger));
                rpt.SetParameterValue("loanformfees", Convert.ToInt32(loanform));
                rpt.SetParameterValue("passbookfees", Convert.ToInt32(passbook));
                rpt.SetParameterValue("monthlycharges", Convert.ToInt32(monthlycharges.Text));
                rpt.SetParameterValue("withdrawcharges", Convert.ToInt32(withdrawcharges.Text));
                rpt.SetParameterValue("intrest", Convert.ToInt32(loanrepaymentsintrest));
                rpt.SetParameterValue("investment", Convert.ToInt32(investments));
                rpt.SetParameterValue("expenses", Convert.ToInt32(Totalexpensespayable));
                rpt.SetParameterValue("issuedloans", Convert.ToInt32(loanssum.ToString()));
                rpt.SetParameterValue("equipment", Convert.ToInt32(Totalequipmentpurchase.Text));
                rpt.SetParameterValue("salaries", Convert.ToInt32(TotalSalariespayable));
                rpt.SetParameterValue("dividens", Convert.ToInt32(devidendstext.Text));
                rpt.SetParameterValue("serviceintrest", Convert.ToInt32(externalloanintrest));
                rpt.SetParameterValue("duepaymentsliability", duepaymentsliability);
                rpt.SetParameterValue("duepayments", duepayments);
                rpt.SetParameterValue("balanceforward", Convert.ToInt32(broughtforward.Text));
                rpt.SetParameterValue("dateto", DateTo.Value);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         
        }
        public void Finance2()
        {
            try
            {
                SqlConnection CN1 = new SqlConnection(cs.DBConn);
                CN1.Open();
                string SelectCommand1 = "SELECT AccountNumber,AmountAvailable,BankNo FROM BankAccounts order by ID ASC";
                cmd = new SqlCommand(SelectCommand1);
                cmd.Connection = CN1;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["BankNo"].ToString().Trim() == "Cash")
                    {
                        cashathand = Convert.ToInt32(rdr["AmountAvailable"]);
                    }
                    else { cashathand = 0; }

                    if (rdr["BankNo"].ToString().Trim() == "Bank 1")
                    {
                        Cashatbank = Convert.ToInt32(rdr["AmountAvailable"]);
                        bank1 = rdr["AccountNumber"].ToString();
                    }
                    //else { Cashatbank = 0; bank1 = "N/A"; }

                    if (rdr["BankNo"].ToString().Trim() == "Bank 2")
                    {
                        CashAtabank2 = Convert.ToInt32(rdr["AmountAvailable"]);
                        bank2 = rdr["AccountNumber"].ToString();
                    }
                    //else { CashAtabank2 = 0; bank2 = "N/A"; }

                    if (rdr["BankNo"].ToString().Trim() == "Bank 3")
                    {
                        CashAtabank3 = Convert.ToInt32(rdr["AmountAvailable"]);
                        bank3 = rdr["AccountNumber"].ToString();
                    }
                    //else { CashAtabank3 = 0; bank3 = "N/A"; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Deposit'  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where Date between @date1 and @date2  and Transactions ='Deposit'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Totalsavings.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalsavings.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Savings  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //withdraws
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Withdraw'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where Date between @date1 and @date2 and Transactions ='Withdraw'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    withdraws.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    withdraws.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Savings Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Monthly Charges
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Monthly Charge'  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where Date between @date1 and @date2  and Transactions ='Monthly Charge'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    monthlycharges.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    monthlycharges.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Monthly Charges  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //withdraw charges
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select withdrawFee from WithdrawCharges where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(withdrawFee) from WithdrawCharges where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    withdrawcharges.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    withdrawcharges.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Withdraw Charges Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            savingssum = Convert.ToInt32(Totalsavings.Text) - (Convert.ToInt32(withdraws.Text) + Convert.ToInt32(monthlycharges.Text) + Convert.ToInt32(withdrawcharges.Text));
            //external loan repayment
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where  PaymentDate > @date1 and PaymentStatus='Pending'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPay) from ExternalRepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Pending'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    extintrep = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    extintrep = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" External repayment Schedule Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select BalanceExist from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(BalanceExist) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    externalloanrepayment.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    externalloanrepayment.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("External Loan Repayment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            externalloanssum = Convert.ToInt32(extintrep) + Convert.ToInt32(externalloanrepayment.Text);

           // external loan service intrest
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    externalloanintrest = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    externalloanintrest = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("External Loan Repayment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Loan Insurance Fees
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select InsuranceAmmount from LoanInsuranceFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(InsuranceAmmount) from LoanInsuranceFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loaninsurance.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    loaninsurance.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan Insurance Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //loan processing
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from LoanProcessingFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from LoanProcessingFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loanprocessing.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    loanprocessing.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Annual Subscription
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AnnualAmmount from AnnualFeesPayment where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AnnualAmmount) from AnnualFeesPayment where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Annualsubscription.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Annualsubscription.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Annual Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //total grants
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select GrantFee from GrantFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(GrantFee) from GrantFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Grants.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Grants.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Share capital
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select DepositedAmmount from ShareCapital where Date between @date1 and @date2 and ModeOfPayment ='Transfer' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(DepositedAmmount) from ShareCapital where Date between @date1 and @date2 and ModeOfPayment ='Transfer'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    totalsharereal = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    totalsharereal = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Share capital sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select DepositedAmmount from ShareCapital where Date between @date1 and @date2 and ModeOfPayment !='Transfer' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(DepositedAmmount) from ShareCapital where Date between @date1 and @date2 and ModeOfPayment !='Transfer'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    TotalShareCapital.Text = (Convert.ToInt32(cmd.ExecuteScalar().ToString()) - totalsharereal).ToString();
                }
                else
                {
                    TotalShareCapital.Text = (0 - totalsharereal).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Share capital sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //registration fees
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Totalregistrationfees.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalregistrationfees.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registration fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //total fines
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Finefee from Fines where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(FineFee) from Fines where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    TotalFines.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    TotalFines.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fine fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Other Incomes
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select OtherFee from OtherIncomes where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    otherincomes.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    otherincomes.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Other Incomes Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ledger
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Ledger' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Ledger'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    ledger = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    ledger = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Passbook
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Passbook' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Passbook'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    passbook = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    passbook = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //loan form
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Loan Form ' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date between @date1 and @date2 and Item='Loan Form'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loanform = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    loanform = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pass Book Exceptions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //investment
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select ReturnFee from InvestmentReturns where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(ReturnFee) from InvestmentReturns where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    investment.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    investment.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Return fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Price from Investment where PriceDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PriceDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Price) from Investment where PriceDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PriceDate").Value = DateTo.Value.Date;
                    investmentcapital.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    investmentcapital.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("investment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            investments = Convert.ToInt32(investment.Text) - Convert.ToInt32(investmentcapital.Text);
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from RepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    loanrepaymentsintrest = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                    con.Close();
                }
                else
                {
                    loanrepaymentsintrest = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Expenses
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from Expenses where Date between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Cost) from Expenses where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    Totalexpensespayable = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalexpensespayable = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Expenses Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //totalloans
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where PaymentDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalAmmount) from RepaymentSchedule where PaymentDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    Totalloanspayable = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalloanspayable = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where PaymentStatus='Pending'  and PaymentDate > @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPay) from RepaymentSchedule where PaymentStatus='Pending'  and PaymentDate > @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    unpaidloans = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                }
                else
                {
                    unpaidloans = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(BalanceExist) from RepaymentSchedule where PaymentDate > @date1 and PaymentStatus='Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    loanrep = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                }
                else
                {
                    loanrep = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loanssum = Convert.ToInt32(unpaidloans) + Convert.ToInt32(loanrep);
            //equipment purchase
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalCost from EquipmentPurchase where PurchaseDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PurchaseDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalCost) from EquipmentPurchase where PurchaseDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PurchaseDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                    Totalequipmentpurchase.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Totalequipmentpurchase.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Equipment purchase exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Basic Salary
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Totalpaid from EmployeePayment where PaymentDate between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where PaymentDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    TotalSalariespayable = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    TotalSalariespayable = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Drawings
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from Drawings where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from Drawings where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    devidends = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    devidendstext.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    devidends = 0;
                    devidendstext.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Drawings Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select DueFees from EmployeePayment where  PaymentDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from EmployeePayment where PaymentDate between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    staffpa = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    staffpa = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Employee payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Duepayment from Expenses where  Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    exppa = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    exppa = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Expenses exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where PaymentStatus='Pending'  and PaymentDate > @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalAmmount) from ExternalRepaymentSchedule where PaymentStatus='Pending'  and PaymentDate > @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                    extunpaidloans = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    extunpaidloans = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from SupplierAccountTransactions where Date > @date1 and Clearance='Not Cleared'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from SupplierAccountTransactions where Date > @date1 and Clearance='Not Cleared'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    unpaidequipment = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    unpaidequipment = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            duepaymentsliability = unpaidequipment + (Convert.ToInt32(Totalexpensespayable) - exppa) + (Convert.ToInt32(TotalSalariespayable) - staffpa);
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Duepayment from AnnualFeesPayment where  Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Duepayment) from AnnualFeesPayment where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    annauldue = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    annauldue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Annual fees Payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Duepayment from LoanProcessingFees where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Duepayment) from LoanProcessingFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loanprosdue = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    loanprosdue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan processing fees exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Duepayment from LoanInsuranceFees where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Duepayment) from LoanInsuranceFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loaninsurancedue = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    loaninsurancedue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan processing fees exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Duepayment from RegistrationFees where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Duepayment) from RegistrationFees where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    registrationdue = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    registrationdue = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan processing fees exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            duepayments =  registrationdue + loaninsurancedue + loanprosdue + annauldue;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from BroughtForward where Date between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from BroughtForward where Date between @date1 and @date2", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    broughtforward.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    broughtforward.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Balance forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int broughtforwardf = 0; int savingsf = 0; int externaloansf = 0; int loaninsurancef = 0;int loanprocessingf = 0; int annualsubscriptionf = 0; int grantsf = 0;
        int sharesf = 0; int registrationfeesf = 0; int finesf = 0; int otherincomesf = 0; int ledgerloanf = 0; int investmentreturnsf = 0; int loanrepaymentsf = 0;
        int drawingsf = 0; int withdrawf=0; int investmentf = 0; int externaloanrepaymentf = 0; int expensesf = 0; int equipmentf = 0; int loansf = 0; int salariesf = 0;
        public void finance3()
        {
            //Drawings
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from Drawings where Date < @date1   order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from Drawings where  Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    drawingsf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    drawingsf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Drawings  sum failed  forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //withdraws
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date < @date1 and Transactions ='Withdraw'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where Date < @date1 and Transactions ='Withdraw'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    withdrawf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    withdrawf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Savings forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Price from Investment where PriceDate < @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Price) from Investment where PriceDate < @date1 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PriceDate").Value = DateFrom.Value.Date;
                    investmentf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    investmentf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Investment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Monthly Charges

            //External Loans
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AmmountPaid from ExternalLoanRepayment where Repaymentdate < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPaid) from ExternalLoanrepayment where Repaymentdate < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    externaloanrepaymentf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    externaloanrepaymentf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("External loan repayment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Expenses
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from Expenses where  Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    expensesf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    expensesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Equipment Purchase
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from SupplierAccountTransactions where Date < @date1 and Clearance='Cleared'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from SupplierAccountTransactions where Date < @date1 and Clearance='Cleared'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    equipmentf = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    equipmentf = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Issued Loans
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from IssuedLoans where  Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from IssuedLoans where  Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    loansf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    loansf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Issued loans forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //salaries
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Totalpaid from EmployeePayment where PaymentDate  < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Totalpaid) from EmployeePayment where PaymentDate < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateFrom.Value.Date;
                    salariesf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    salariesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Employee payment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //loan repayments
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AmmountPaid from LoanRepayment where Repaymentdate  < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AmmountPaid) from Loanrepayment where Repaymentdate < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    loanrepaymentsf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    loanrepaymentsf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan Repayment Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //investment returns
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select ReturnFee from InvestmentReturns where Date < @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(ReturnFee) from InvestmentReturns where Date < @date1 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    investmentreturnsf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    investmentreturnsf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Return fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //passbook, loan form, ledger
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(PassLedgerLoanAmmount) from PassLedgerLoanFees where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    ledgerloanf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    ledgerloanf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("passledgerfees ammount brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Other incomes
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select OtherFee from OtherIncomes where Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    otherincomesf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    otherincomesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Other incomes brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //total fines
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Finefee from Fines where  Date < @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(FineFee) from Fines where  Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    finesf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    finesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fine fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //registration fees
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where  Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where  Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    registrationfeesf= Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    registrationfeesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registration fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //share capital
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select DepositedAmmount from ShareCapital where  Date < @date1 and ModeOfPayment !='Transfer' ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(DepositedAmmount) from ShareCapital where  Date < @date1 and DepositedAmmount !='' and ModeOfPayment !='Transfer'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    sharesf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    sharesf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Share capital sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /// Grant Fees
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select GrantFee from GrantFees where  Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(GrantFee) from GrantFees where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    grantsf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    grantsf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Annual Subscription
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select AnnualAmmount from AnnualFeesPayment where Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(AnnualAmmount) from AnnualFeesPayment where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    annualsubscriptionf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    annualsubscriptionf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Annual fees payment broughtforward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Loan Processing
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RegistrationAmmount from LoanProcessingFees where Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(RegistrationAmmount) from LoanProcessingFees where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    loanprocessingf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    loanprocessingf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan processing fees brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Loan Insurance
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select InsuranceAmmount from LoanInsuranceFees where Date < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(InsuranceAmmount) from LoanInsuranceFees where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    loaninsurancef = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    loaninsurancef = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Loan insurance fees brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //External Loan
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select LoanAmmount from ExternalLoans where RecievedDate  < @date1 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RecievedDate").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(LoanAmmount) from ExternalLoans where RecievedDate < @date1 and Recieved='Recieved'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RecievedDate").Value = DateFrom.Value.Date;
                    externaloansf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    externaloansf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("External loans broughtforward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Ammount from BroughtForward where Date< @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Ammount) from BroughtForward where Date< @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    broughtforwardf= Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    broughtforwardf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Balance forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Savings 
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Deposit from Savings where Date < @date1 and Transactions ='Deposit' order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Deposit) from Savings where  Date < @date1  and Transactions ='Deposit'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                    savingsf = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                else
                {
                    savingsf = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Savings  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateFrom_ValueChanged(object sender, EventArgs e)
        { 
            // Withdraw Charges
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select withdrawFee from WithdrawCharges where Date < @date1  ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(withdrawFee) from WithdrawCharges where Date < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                    label9.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    label9.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
          
           
           
            //Interest
            string interests = "0";
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Interest from LoanRepayment where Repaymentdate < @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Interest) from Loanrepayment where Repaymentdate < @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
                    interests = Convert.ToInt32(cmd.ExecuteScalar().ToString()).ToString();
                    con.Close();
                }
                else
                {
                     interests= "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" loan repayment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try{
            //broughtforward.Text = ((Convert.ToInt32(label3.Text) + Convert.ToInt32(label24.Text) + Convert.ToInt32(label4.Text) + Convert.ToInt32(label5.Text) + Convert.ToInt32(label6.Text) + Convert.ToInt32(label7.Text) + Convert.ToInt32(label8.Text) + Convert.ToInt32(label9.Text) + Convert.ToInt32(label10.Text) + Convert.ToInt32(label11.Text) + Convert.ToInt32(label12.Text) + Convert.ToInt32(label13.Text) + Convert.ToInt32(label14.Text) + Convert.ToInt32(label15.Text) + Convert.ToInt32(label16.Text)) - (+ Convert.ToInt32(label25.Text)+Convert.ToInt32(label17.Text) + Convert.ToInt32(label18.Text) + Convert.ToInt32(label19.Text) + Convert.ToInt32(label20.Text) + Convert.ToInt32(label21.Text) + Convert.ToInt32(label22.Text) + Convert.ToInt32(label23.Text))).ToString();
            buttonX2.Enabled = true;
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonX2.Enabled = true;
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            if (broughtforward.Text == "")
            {
                MessageBox.Show("Please first set parameters and click view details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonX2.Focus();
                return;
            }
            try
            {
                //this.Hide();
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptCashFlowStatement rpt = new rptCashFlowStatement(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
                FrmCashflow frm = new FrmCashflow();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and Deposit !='' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("intrestreciepts", Convert.ToInt32(totalintrests));
                rpt.SetParameterValue("fines", Convert.ToInt32(TotalFines.Text));
                rpt.SetParameterValue("savingsdeposits", Convert.ToInt32(Totalsavings.Text));
                rpt.SetParameterValue("annualfeespayment", Annualsubscription.Text);
                rpt.SetParameterValue("loaninsurancefees", Convert.ToInt32(loaninsurance.Text));
                rpt.SetParameterValue("ledgerloan", Convert.ToInt32(passledger.Text));
                rpt.SetParameterValue("loanprocessing", Convert.ToInt32(loanprocessing.Text));
                rpt.SetParameterValue("monthlycharges", monthlycharges.Text);
                rpt.SetParameterValue("registrationfees", Convert.ToInt32(Totalregistrationfees.Text));
                rpt.SetParameterValue("otherincomes", Convert.ToInt32(otherincomes.Text));
                rpt.SetParameterValue("withdraws", Convert.ToInt32(withdraws.Text));
                rpt.SetParameterValue("employeepayments", Convert.ToInt32(TotalSalaries.Text));
                rpt.SetParameterValue("expenses", Convert.ToInt32(Totalexpenses.Text));
                rpt.SetParameterValue("externalloanintrest", Convert.ToInt32(externalloanrepaymentInterest));
                rpt.SetParameterValue("invetmentdevidends", Convert.ToInt32(investment.Text));
                rpt.SetParameterValue("loanprincipal", Convert.ToInt32(principalammount));
                rpt.SetParameterValue("equipmentpurchase", Convert.ToInt32(Totalequipmentpurchase.Text));
                rpt.SetParameterValue("investmentcapital", Convert.ToInt32(investmentcapital.Text));
                rpt.SetParameterValue("issuedloans", Convert.ToInt32(TotalUnpaidLoans.Text));
                rpt.SetParameterValue("externalloans", Convert.ToInt32(externalloans.Text));
                rpt.SetParameterValue("sharecapital", Convert.ToInt32(TotalShareCapital.Text));
                rpt.SetParameterValue("externalloanrepayment", Convert.ToInt32(externalloanrepayment.Text));
                rpt.SetParameterValue("shareholderdevidends", Convert.ToInt32(devidendstext.Text));
                rpt.SetParameterValue("cashbroughtforward", Convert.ToInt32(broughtforward.Text));
                rpt.SetParameterValue("datefrom", DateFrom.Value);
                rpt.SetParameterValue("dateto", DateTo.Value);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }catch(Exception Ex){
                MessageBox.Show(Ex.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void labelX18_Click(object sender, EventArgs e)
        {

        }

        private void TotalDispensibleincome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
