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
		int extunpaidloans = 0;
		int duepayments = 0;
		int loanssum = 0;
		int savingssum = 0;
		int cashathand = 0;
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
			totalapplicationfees.Text = "";
			TotalFines.Text = "";
			Totalexpenses.Text = "";
			Totalequipmentpurchase.Text = "";
			TotalUnpaidLoans.Text = "";
			TotalSalaries.Text = "";
			moneyavailable.Text = "";
			totaloutflows.Text = "";
			TotalDispensibleincome.Text = "";
			externalloans.Text = "";
			otherincomes.Text = "";
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
			Reset();
		}
		string TotalSalariespayable = "0";
		string Totalexpensespayable = "0";
		int principalammount = 0;
		 int staffpa = 0;
		int externalprincipalammount = 0;
		int drawingstexts = 0;
		private void buttonX2_Click(object sender, EventArgs e)
		{

			Finance2();
			try
			{
				buttonX3.Enabled = true;
				buttonX4.Enabled = true;
				buttonX5.Enabled = true;
				buttonX6.Enabled = true;

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
		public void AccrualFinance()
		{
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TransferFee from TransferCharges where Date between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(TransferFee) from TransferCharges where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					transferchargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					transferchargesi = 0;
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
					monthlychargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					monthlychargesi = 0;
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
					totalinvestmentreturnsi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentreturnsi = 0;
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
					totalannualsubscriptioni = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalannualsubscriptioni = 0;
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
					passledgeri = Convert.ToInt32(cmd.ExecuteScalar());
				}
				else
				{
					passledgeri = 0;
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
				cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					registerfeesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					registerfeesi = 0;
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
				cmd = new SqlCommand("select Ammount from Drawings where Date between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Ammount) from Drawings where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					drawingstexts = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					drawingstexts = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Drawings  sum failed  forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from ExternalLoanRepayment where Repaymentdate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from ExternalLoanRepayment where Repaymentdate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
					externalprincipalammount = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalprincipalammount = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from LoanRepayment where Repaymentdate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Repaymentdate").Value = DateTo.Value.Date;
					principalammount = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					principalammount = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AccountExcess from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalroundoffexcessi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalroundoffexcessi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					withdrawchargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					withdrawchargesi = 0;
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
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					loanrepaymentsintrest2i = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loanrepaymentsintrest2i = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Intrest Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AmountPaid from LoanApplicationPayment where PaymentDate between @date1 and @date2 ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AmountPaid) from LoanApplicationPayment where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					registrationfeesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					registrationfeesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date between @date1 and @date2  and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Cost) from Expenses where Date between @date1 and @date2 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalloanprocessingi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessingi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					totalloaninsurancei = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloaninsurancei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Insurance Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					earlysettlementchargei = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					earlysettlementchargei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					autofinesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					autofinesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Fines Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select FineFee from Fines where Date between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(FineFee) from Fines where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					manualfinesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					manualfinesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			totalfinesi = manualfinesi + autofinesi;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AccountExcess from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					roundoffexcessi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					roundoffexcessi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select BasicSalary from EmployeePayment where PaymentDate between @date1 and @date2 ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					totalsalariesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalsalariesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date between @date1 and @date2 and AppreciationAmount >0", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date between @date1 and @date2 and AppreciationAmount >0", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalinvestmentcapitali = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentcapitali = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date between @date1 and @date2  and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where Date between @date1 and @date2 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalloanprocessingexpensesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessingexpensesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					totalgranti = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalgranti = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select OtherFee from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalotherincomesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalotherincomesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Other incomes brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
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
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalloanintrest2i = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					externalloanintrest2i = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("External Loan Repayment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from Expenses where  Date between @date1 and @date2 and LoanID='N/A' and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date between @date1 and @date2 and LoanID='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalexpensesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalexpensesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					baddebtorsi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					baddebtorsi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Total Ammount sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		  
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalearlysettlementchargei = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalearlysettlementchargei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CashFinance()
		{
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					loanrepaymentsintrest2i = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loanrepaymentsintrest2i = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Intrest Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AmountPaid from LoanApplicationPayment where PaymentDate between @date1 and @date2 ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AmountPaid) from LoanApplicationPayment where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					registrationfeesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					registrationfeesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date between @date1 and @date2  and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Cost) from Expenses where Date between @date1 and @date2 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalloanprocessingi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessingi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					totalloaninsurancei = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloaninsurancei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Insurance Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					earlysettlementchargei = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					earlysettlementchargei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No' and PaymentStatus='Paid' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No' and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					autofinesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					autofinesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Fines Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select FineFee from Fines where Date between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(FineFee) from Fines where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					manualfinesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					manualfinesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			totalfinesi = manualfinesi + autofinesi;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AccountExcess from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					roundoffexcessi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					roundoffexcessi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from EmployeePayment where PaymentDate between @date1 and @date2 ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalPaid) from EmployeePayment where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					totalsalariesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalsalariesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date between @date1 and @date2 and AppreciationAmount >0 and PaidOut='Yes'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date between @date1 and @date2 and AppreciationAmount >0 and PaidOut='Yes'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalinvestmentcapitali = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentcapitali = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date between @date1 and @date2  and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where Date between @date1 and @date2 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalloanprocessingexpensesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessingexpensesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					totalgranti = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalgranti = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select OtherFee from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalotherincomesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalotherincomesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Other incomes brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
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
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalloanintrest2i = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					externalloanintrest2i = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("External Loan Repayment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from Expenses where  Date between @date1 and @date2 and LoanID='N/A' and Comment='Approved' ", con);
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
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date between @date1 and @date2 and LoanID='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalexpensesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalexpensesi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					baddebtorsi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					baddebtorsi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Total Ammount sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalearlysettlementchargei = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalearlysettlementchargei = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					withdrawchargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					withdrawchargesi = 0;
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
				cmd = new SqlCommand("select AccountExcess from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalroundoffexcessi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalroundoffexcessi = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					if ((rdr != null))
					{
						rdr.Close();
					}
					con.Close();

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					registerfeesi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					registerfeesi = 0;
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
					passledgeri = Convert.ToInt32(cmd.ExecuteScalar());
				}
				else
				{
					passledgeri = 0;
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
					totalannualsubscriptioni = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalannualsubscriptioni = 0;
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
					totalinvestmentreturnsi = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentreturnsi = 0;
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
					monthlychargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					monthlychargesi = 0;
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
				cmd = new SqlCommand("select TransferFee from TransferCharges where Date between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(TransferFee) from TransferCharges where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					transferchargesi = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					transferchargesi = 0;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Withdraw Charges Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void buttonX3_Click(object sender, EventArgs e)
		{
			FrmChooseBasis frm4 = new FrmChooseBasis();
			frm4.ShowDialog();
			label26.Text = frm4.label1.Text;
			if (label26.Text == "Accrual")
			{
				company();
				try
				{
					AccrualFinance();
					//Cursor = Cursors.WaitCursor;
					//timer1.Enabled = true;
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
					MyCommand.CommandText = "select Top(1) * from Savings where Date between @date1 and @date2";
					MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					MyCommand.CommandType = CommandType.Text;
					myDA.SelectCommand = MyCommand;
					myDA.Fill(myDS, "Savings");
					rpt.SetDataSource(myDS);
					rpt.SetParameterValue("totalrepayment", loanrepaymentsintrest2i);
					rpt.SetParameterValue("totalregistration", registrationfeesi);
					rpt.SetParameterValue("totalloanprocessingcharge", totalloanprocessingi);
					rpt.SetParameterValue("loaninsurancefees", totalloaninsurancei);
					rpt.SetParameterValue("totalfines", totalfinesi);
					rpt.SetParameterValue("earlysettlement", earlysettlementchargei);
					rpt.SetParameterValue("roundoffexcess", roundoffexcessi);
					rpt.SetParameterValue("withdrawcharges", Convert.ToInt32(withdrawchargesi));
					rpt.SetParameterValue("totalsalaries", totalsalariesi);
					rpt.SetParameterValue("investmentcapital", totalinvestmentcapitali);
					rpt.SetParameterValue("processingexpenses", totalloanprocessingexpensesi);
					rpt.SetParameterValue("totalgrant", totalgranti);
					rpt.SetParameterValue("totalotherincomes", totalotherincomesi);
					rpt.SetParameterValue("serviceintrest", Convert.ToInt32(externalloanintrest2i));
					rpt.SetParameterValue("totalexpenses", totalexpensesi);
					rpt.SetParameterValue("baddebit", baddebtorsi);
					rpt.SetParameterValue("monthlycharges", monthlychargesi);
					rpt.SetParameterValue("passbook", passledgeri);
					rpt.SetParameterValue("annualsubscription", totalannualsubscriptioni);
					rpt.SetParameterValue("registrationfees", registerfeesi);
					rpt.SetParameterValue("investmentreturns", totalinvestmentreturnsi);
					rpt.SetParameterValue("transfercharges", transferchargesi);
					rpt.SetParameterValue("externalearlysettlement", externalearlysettlementchargei);
					rpt.SetParameterValue("externalroundoffexcess", externalroundoffexcessi);
					rpt.SetParameterValue("datefrom", DateFrom.Value);
					rpt.SetParameterValue("dateto", DateTo.Value);
					rpt.SetParameterValue("comanyname", companyname);
					rpt.SetParameterValue("companyemail", companyemail);
					rpt.SetParameterValue("companycontact", companycontact);
					rpt.SetParameterValue("companyslogan", companyslogan);
					rpt.SetParameterValue("companyaddress", companyaddress);
					rpt.SetParameterValue("picpath", "logo.jpg");
					frm.crystalReportViewer1.ReportSource = rpt;
					myConnection.Close();
					frm.ShowDialog();
				}
				catch (Exception)
				{
					MessageBox.Show("Income Statement Generation Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}else if (label26.Text == "Cash")
			{
				company();

				try
				{
					CashFinance();
					//Cursor = Cursors.WaitCursor;
					//timer1.Enabled = true;
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
					MyCommand.CommandText = "select Top(1) * from Savings where Date between @date1 and @date2";
					MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					MyCommand.CommandType = CommandType.Text;
					myDA.SelectCommand = MyCommand;
					myDA.Fill(myDS, "Savings");
					rpt.SetDataSource(myDS);
					rpt.SetParameterValue("totalrepayment", loanrepaymentsintrest2i);
					rpt.SetParameterValue("totalregistration", registrationfeesi);
					rpt.SetParameterValue("totalloanprocessingcharge", totalloanprocessingi);
					rpt.SetParameterValue("loaninsurancefees", totalloaninsurancei);
					rpt.SetParameterValue("earlysettlement", earlysettlementchargei);
					rpt.SetParameterValue("totalfines", totalfinesi);
					rpt.SetParameterValue("roundoffexcess", roundoffexcessi);
					rpt.SetParameterValue("withdrawcharges", Convert.ToInt32(withdrawchargesi));
					// rpt.SetParameterValue("totalloans", totalloanprincipal);
					rpt.SetParameterValue("totalsalaries", totalsalariesi);
					rpt.SetParameterValue("investmentcapital", totalinvestmentcapitali);
					rpt.SetParameterValue("processingexpenses", totalloanprocessingexpensesi);
					rpt.SetParameterValue("monthlycharges", monthlychargesi);
					rpt.SetParameterValue("totalgrant", totalgranti);
					rpt.SetParameterValue("totalotherincomes", totalotherincomesi);
					rpt.SetParameterValue("serviceintrest", Convert.ToInt32(externalloanintrest2i));
					rpt.SetParameterValue("totalexpenses", totalexpensesi);
					rpt.SetParameterValue("baddebit", baddebtorsi);
					rpt.SetParameterValue("externalearlysettlement", externalearlysettlementchargei);
					rpt.SetParameterValue("externalroundoffexcess", externalroundoffexcessi);
					rpt.SetParameterValue("passbook", passledgeri);
					rpt.SetParameterValue("annualsubscription", totalannualsubscriptioni);
					rpt.SetParameterValue("registrationfees", registerfeesi);
					rpt.SetParameterValue("investmentreturns", totalinvestmentreturnsi);
					rpt.SetParameterValue("transfercharges", transferchargesi);
					rpt.SetParameterValue("datefrom", DateFrom.Value);
					rpt.SetParameterValue("dateto", DateTo.Value);
					rpt.SetParameterValue("comanyname", companyname);
					rpt.SetParameterValue("companyemail", companyemail);
					rpt.SetParameterValue("companycontact", companycontact);
					rpt.SetParameterValue("companyslogan", companyslogan);
					rpt.SetParameterValue("companyaddress", companyaddress);
					rpt.SetParameterValue("picpath", "logo.jpg");
					frm.crystalReportViewer1.ReportSource = rpt;
					myConnection.Close();
					frm.ShowDialog();
				}
				catch (Exception)
				{
					MessageBox.Show("Income Statement Generation Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
		}
		int passledgeri,transferchargesi, monthlychargesi, totalinvestmentreturnsi, totalannualsubscriptioni, registerfeesi, externalroundoffexcessi,loanrepaymentsintrest2i, registrationfeesi, totalloanprocessingi, totalloaninsurancei, earlysettlementchargei, totalfinesi, roundoffexcessi, manualfinesi, autofinesi, withdrawchargesi, totalsalariesi, totalinvestmentcapitali, externalearlysettlementchargei, baddebtorsi, totalexpensesi, externalloanintrest2i, totalotherincomesi, totalgranti, totalloanprocessingexpensesi = 0;
		int baddebtors, earlysettlementcharge,totalloanprocessingexpenses, totalinvestmentcapital, totalexpenses,totalfines,manualfines,autofines, totalotherincomes, totalsalaries, totalloanprincipal, totalloaninsurance, totalloanprocessing, totalgrant, registrationfees, loanrepaymentsintrest = 0; int externalloanintrest2 = 0; int externalloanintrest3 = 0; int loanrepaymentsintrest2 = 0;
  

		private void buttonX5_Click(object sender, EventArgs e)
		{
			company();
			try
			{
				Finance2();
				finance3();
				trialbalanceparameters();
				AccrualFinance();
				int cashbd = (monthlychargesf + grantsf + annualsubscriptionfeesf + transferchargesf + registerfeesf + totalinvestmentreturnsf + passledgerf + otherincomesf + loanrepaymentsintrest2f + registrationfeesf + loanprocessingf + loaninsurancef + earlysettlementchargef + finesf + roundoffexcessf + withdrawchargesf) - (totalsalariesf  + totalloanprocessingexpensesf + totalexpensesf + externalloanintrest2f + baddebtorsf + externalearlysettlementchargef + drawingsf+externalroundoffexcessf+ totalinvestmentcapitalf);
				int costs = totalsalariesi+ totalinvestmentcapitali+ totalloanprocessingexpensesi+ totalexpensesi+ externalloanintrest2i+baddebtorsi+ externalearlysettlementchargei+ externalroundoffexcessi;
				int netincomes = (monthlychargesi+ totalannualsubscriptioni + transferchargesi + registerfeesi + totalinvestmentreturnsi + passledgeri+ totalloanprocessingi +loanrepaymentsintrest2i + registrationfeesi+ totalloaninsurancei+ earlysettlementchargei+ totalfinesi+roundoffexcessi+ withdrawchargesi+ totalgranti+ totalotherincomesi) -costs;
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
				MyCommand.CommandText = "select Top(1) * from Savings where Date between @date1 and @date2  ";
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
				rpt.SetParameterValue("cashatbank4", CashAtabank4);
				rpt.SetParameterValue("cashatbank5", CashAtabank5);
				rpt.SetParameterValue("bank1", bank1);
				rpt.SetParameterValue("bank2", bank2);
				rpt.SetParameterValue("bank3", bank3);
				rpt.SetParameterValue("bank4", bank4);
				rpt.SetParameterValue("bank5", bank5);
				rpt.SetParameterValue("accountsrecievable", duepayments);
				rpt.SetParameterValue("issuedloans", Convert.ToInt32(loansum6));
				rpt.SetParameterValue("equipment", Convert.ToInt32(Totalequip));
				rpt.SetParameterValue("duepaymentsliability", duepaymentsliability);
				rpt.SetParameterValue("externalloans", Convert.ToInt32(externalloansum6));
				rpt.SetParameterValue("savings", Convert.ToInt32(savingssum));
				rpt.SetParameterValue("balanceforward", Convert.ToInt32(broughtforwards)+shares);
				rpt.SetParameterValue("investment", Convert.ToInt32(investmentsum));
				rpt.SetParameterValue("netincomes", netincomes);
				rpt.SetParameterValue("investments", investmentcapital);
				rpt.SetParameterValue("datefrom", DateFrom.Value);
				rpt.SetParameterValue("dateto", DateTo.Value);
				rpt.SetParameterValue("comanyname", companyname);
				rpt.SetParameterValue("companyemail", companyemail);
				rpt.SetParameterValue("companycontact", companycontact);
				rpt.SetParameterValue("companyslogan", companyslogan);
				rpt.SetParameterValue("companyaddress", companyaddress);
				rpt.SetParameterValue("picpath", "logo.jpg");
				frm.crystalReportViewer1.ReportSource = rpt;
				myConnection.Close();
				frm.ShowDialog();
			   
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}


		int totalsavingsreductions = 0;
		int totalsavingsincrease = 0;
		int Cashatbank = 0; int shares = 0; int investmentsum=0; int CashAtabank2 = 0; int CashAtabank3 = 0; int CashAtabank4 = 0; int CashAtabank5 = 0; string bank1 = "N/A"; string bank2 = "N/A"; string bank3 = "N/A"; string bank4 = "N/A"; string bank5 = "N/A"; int externalloanintrest = 0;int unpaidequipment = 0; int duepaymentsliability = 0; int loaninsurancedue = 0; 
	  public void trialbalanceparameters()
		{
			try
			{
				SqlConnection CN1 = new SqlConnection(cs.DBConn);
				CN1.Open();
				string SelectCommand1 = "SELECT AccountNumber,AmountAvailable,BankNo,AccountNames FROM BankAccounts order by ID ASC";
				cmd = new SqlCommand(SelectCommand1);
				cmd.Connection = CN1;
				rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					if (rdr["BankNo"].ToString().Trim() == "Cash")
					{
						cashathand = Convert.ToInt32(Convert.ToDouble(rdr["AmountAvailable"]));
					}
					//else { cashathand = 0; }

					if (rdr["BankNo"].ToString().Trim() == "Bank 1")
					{
						Cashatbank = Convert.ToInt32(rdr["AmountAvailable"]);
						bank1 = rdr["AccountNames"].ToString();
					}
					//else { Cashatbank = 0; bank1 = "N/A"; }

					if (rdr["BankNo"].ToString().Trim() == "Bank 2")
					{
						CashAtabank2 = Convert.ToInt32(rdr["AmountAvailable"]);
						bank2 = rdr["AccountNames"].ToString();
					}
					//else { CashAtabank2 = 0; bank2 = "N/A"; }

					if (rdr["BankNo"].ToString().Trim() == "Bank 3")
					{
						CashAtabank3 = Convert.ToInt32(rdr["AmountAvailable"]);
						bank3 = rdr["AccountNames"].ToString();
					}

					if (rdr["BankNo"].ToString().Trim() == "Bank 4")
					{
						CashAtabank4 = Convert.ToInt32(rdr["AmountAvailable"]);
						bank4 = rdr["AccountNames"].ToString();
					}
					if (rdr["BankNo"].ToString().Trim() == "Bank 5")
					{
						CashAtabank5 = Convert.ToInt32(rdr["AmountAvailable"]);
						bank5 = rdr["AccountNames"].ToString();
					}
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fetching Accounts Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalCost from EquipmentPurchase ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(TotalCost) from EquipmentPurchase ", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
					Totalequip = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					Totalequip = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Equipment purchase exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			int balanceexist7 = 0;
			int balanceexist8 = 0;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where BalanceExist > 0  and PaymentStatus='Pending'", con);
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
					cmd = new SqlCommand("select SUM(BalanceExist) from RepaymentSchedule where BalanceExist > 0 and PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					balanceexist7 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					balanceexist7 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Schedule loan balance failed 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where BalanceExist > 0  and PaymentStatus='Paid'", con);
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
					cmd = new SqlCommand("select SUM(BalanceExist) from RepaymentSchedule where BalanceExist > 0 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					balanceexist8 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					balanceexist8 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Schedule loan balance failed 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			balanceexist6 = balanceexist7 + balanceexist8;

			//Loan Fines
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Fines from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid' and Waivered='No'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2  and PaymentStatus='Paid' and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					paidfines6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					paidfines6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Fines from RepaymentSchedule where PaymentStatus='Pending' and Waivered='No'", con);
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
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where PaymentStatus='Pending' and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					unpaidfines6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					unpaidfines6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

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
					loanrepayments6 = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					loanrepayments6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			//Loan Fines

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					paidintrest6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					paidintrest6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where PaymentStatus='Pending'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					unpaidintrest6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					unpaidintrest6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			int loanroundoffexcess6 = 0;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where BalanceExist > 0 ", con);
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
					cmd = new SqlCommand("select SUM(AccountExcess) from RepaymentSchedule where BalanceExist > 0", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					loanroundoffexcess6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loanroundoffexcess6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Schedule loan balance failed 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		  
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and BalanceExist = 0 and Interest>0 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(AccountExcess) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and BalanceExist = 0 and Interest>0 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					loanroundoffexcess = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loanroundoffexcess = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Schedule loan balance failed 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			loansum6 = balanceexist6- (unpaidintrest6 + unpaidfines6+ loanroundoffexcess6);


			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Deposit from Savings where Approval='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Debit) from Savings where Approval='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalsavingsreductions = Convert.ToInt32(cmd.ExecuteScalar().ToString());
					con.Close();
				}
				else
				{
					totalsavingsreductions = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Savings  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Deposit from Savings where Approval='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Credit) from Savings where  Approval='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalsavingsincrease = Convert.ToInt32(cmd.ExecuteScalar().ToString());
					con.Close();
				}
				else
				{
					totalsavingsincrease = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Savings  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			savingssum = totalsavingsincrease - totalsavingsreductions;

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
					monthlycharges = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					monthlycharges = 0;
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
					withdrawcharges= Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					withdrawcharges = 0;
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
				cmd = new SqlCommand("select BasicSalary from EmployeePayment where  PaymentDate between @date1 and @date2", con);
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
					cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					TotalSalariespayable = cmd.ExecuteScalar().ToString();
					con.Close();
				}
				else
				{
					TotalSalariespayable = "0";
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Fines from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					autofines = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					autofines= 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					TotalFin = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					TotalFin = 0;
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
					Grant = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					Grant = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from Expenses where  Date between @date1 and @date2 and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date between @date1 and @date2  and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					Totalexpensespayable = cmd.ExecuteScalar().ToString();
					con.Close();
				}
				else
				{
					Totalexpensespayable = "0";
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select OtherFee from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date between @date1 and @date2 and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					otherincom = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					otherincom= 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Other Incomes Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//Drawings
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Ammount from Drawings where Date <= @date2", con);
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
					cmd = new SqlCommand("select SUM(Ammount) from Drawings where Date <= @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					devidends = Convert.ToInt32(cmd.ExecuteScalar().ToString());
				   
					con.Close();
				}
				else
				{
					devidends = 0;
				   
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Drawings Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		   
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					loanrepaymentsintrest = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
					con.Close();
				}
				else
				{
					loanrepaymentsintrest = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate >= @date1 and PaymentStatus='Written Off'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate >= @date1 and PaymentStatus='Written Off'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					badloanrepaymentsintrest = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
					con.Close();
				}
				else
				{
					badloanrepaymentsintrest = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where PaymentDate < @date2 and PaymentStatus='Pending'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where PaymentDate < @date2 and PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					loanrepaymentsintrestdue = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
					con.Close();
				}
				else
				{
					loanrepaymentsintrestdue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//Loan Application Fees
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Paid Application Fees' and Approval='Approved'", con);
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
					cmd = new SqlCommand("select SUM(Deposit) from Savings where Date between @date1 and @date2 and Transactions ='Paid Application Fees' and Approval='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalapplication = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalapplication = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Application fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		   
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					earlysettlementcharge = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					earlysettlementcharge = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from RepaymentSchedule where ActualPaymentDate between @date1 and @date2 and PaymentStatus='Written Off'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateTo.Value.Date;
					baddebtors = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					baddebtors = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Total Ammount sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			int externalbalanceexist7 = 0;
			int externalbalanceexist8 = 0;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where BalanceExist > 0  and PaymentStatus='Pending'", con);
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
					cmd = new SqlCommand("select SUM(BalanceExist) from ExternalRepaymentSchedule where BalanceExist > 0 and PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalbalanceexist7 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalbalanceexist7 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Overall Pending External Repayment Schedule loan balance failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where BalanceExist > 0  and PaymentStatus='Paid'", con);
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
					cmd = new SqlCommand("select SUM(BalanceExist) from ExternalRepaymentSchedule where BalanceExist > 0 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalbalanceexist8 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalbalanceexist8 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Pending External Loan Repayment Schedule loan balance failed 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			externalbalanceexist6 = externalbalanceexist7 + externalbalanceexist8;


			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentStatus='Pending'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalunpaidintrest6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalunpaidintrest6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Pending External Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			int Externalloanroundoffexcess6 = 0;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from EXternalRepaymentSchedule where BalanceExist > 0 ", con);
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
					cmd = new SqlCommand("select SUM(AccountExcess) from ExternalRepaymentSchedule where BalanceExist > 0", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					Externalloanroundoffexcess6 = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					Externalloanroundoffexcess6 = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Excess For External Loan Repayment Schedule loan balance failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		  
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and BalanceExist = 0  and PaymentStatus='Paid'", con);
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
					cmd = new SqlCommand("select SUM(AccountExcess) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 and BalanceExist = 0 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					Externalloanroundoffexcess = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					Externalloanroundoffexcess = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Excess For External Loan Repayment Schedule Paid Loans loan balance failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			externalloansum6 = externalbalanceexist6 - (externalunpaidintrest6 + Externalloanroundoffexcess6);
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2 ", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalloanintrest = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					externalloanintrest = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("External Loan Repayment Intrest Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select FineFee from ExternalLoanFines where Date between @date1 and @date2", con);
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
					cmd = new SqlCommand("select SUM(FineFee) from ExternalLoanFines where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					externalfines = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalfines = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("ExternalLoan Fine fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					loaninsurances = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loaninsurances= 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Insurance Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					con.Close();
				}
				else
				{
					loaninsurancedue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Insurance fees exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date between @date1 and @date2", con);
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
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					cumulativereturns = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					cumulativereturns = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment Appreciation exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date <= @date2 and PaidOut='Pending'", con);
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
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date <= @date2 and PaidOut='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					cumulativereturnsdue = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					cumulativereturnsdue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment Appreciation Due exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date < @date2 and PaidOut='Yes'", con);
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
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date < @date2 and PaidOut='Yes'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					cumulativereturnsdues = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					cumulativereturnsdues = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment Appreciation Due exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Amount from InvestorWithdraw where Issued='Yes' and WithdrawType='Whole Amount'", con);
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
					cmd = new SqlCommand("select SUM(Amount) from InvestorWithdraw where Issued='Yes' and WithdrawType='Whole Amount'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					investorpayout = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					investorpayout = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investor Payouts Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Deposit from InvestmentAppreciation where AppreciationAmount=0 and Approved='Approved' and Date between @date1 and @date2", con);
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
					cmd = new SqlCommand("select SUM(Deposit) from InvestmentAppreciation where AppreciationAmount=0 and Approved='Approved' and Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					Investorinvestment = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					Investorinvestment = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investor Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AccountBalance from InvestorSavings", con);
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
					cmd = new SqlCommand("select SUM(AccountBalance) from InvestorSavings", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					investmentsum = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar())) - cumulativereturnsdue;
					con.Close();
				}
				else
				{
					investmentsum = 0 - cumulativereturnsdue;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investor Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		   // investmentsum = Convert.ToInt32(Investorinvestment) - (Convert.ToInt32(investorpayout)- cumulativereturnsdues);
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date between @date1 and @date2  and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Cost) from Expenses where Date between @date1 and @date2 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					totalloanprocessing = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessing = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Ammount from BroughtForward", con);
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
					cmd = new SqlCommand("select SUM(Ammount) from BroughtForward", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					broughtforwards = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					broughtforwards = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Balance forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select DisposalAmount from AssetDisposal where DisposalDate between @date1 and @date2 ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DisposalDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DisposalDate").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(DisposalAmount) from AssetDisposal where DisposalDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DisposalDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DisposalDate").Value = DateTo.Value.Date;
					Disposedassets = Convert.ToInt32(cmd.ExecuteScalar().ToString());
					con.Close();
				}
				else
				{
					Disposedassets = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Asset Disposal Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from ExternalRepaymentSchedule where PaymentDate between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalearlysettlementcharge = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalearlysettlementcharge = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					annualsubscriptionfees = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					annualsubscriptionfees = 0;
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
					passledger = Convert.ToInt32(cmd.ExecuteScalar());
				}
				else
				{
					passledger = 0;
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
				cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					registerfees = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					registerfees = 0;
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
				cmd = new SqlCommand("select DepositedAmmount from ShareCapital ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(DepositedAmmount) from ShareCapital  ", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					shares = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					shares = 0;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Share capital sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//account to account transfer charges
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TransferFee from TransferCharges where Date between @date1 and @date2 ", con);
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
					cmd = new SqlCommand("select SUM(TransferFee) from TransferCharges where Date between @date1 and @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					transfercharges = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					transfercharges = 0;
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
				cmd = new SqlCommand("select Deposit from Savings where Date between @date1 and @date2 and Transactions ='Monthly Charge'  order by ID DESC", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					monthlycharges = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					monthlycharges = 0;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Monthly Charges  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		int Totalequip = 0;int passledger=0; int totalinvestmentreturns = 0; int externalearlysettlementcharge = 0; int broughtforwards = 0; int Investorinvestment = 0;int cumulativereturnsdues = 0; int investorpayout = 0; int loaninsurances = 0; int Externalloanroundoffexcess = 0; int badloanrepaymentsintrest = 0;  int registerfees = 0; int totalapplication = 0; int Grant = 0;int otherincom = 0; int withdrawcharges = 0;int TotalFin = 0; int monthlycharges = 0;int transfercharges = 0;
		private void buttonX4_Click(object sender, EventArgs e)
		{
			company();
			try
			{
				Finance2();
				finance3();
				trialbalanceparameters();
				//this.Hide();
				int cashbd = (monthlychargesf+grantsf + annualsubscriptionfeesf + transferchargesf + registerfeesf + totalinvestmentreturnsf + passledgerf+ otherincomesf + loanrepaymentsintrest2f + registrationfeesf + loanprocessingf + loaninsurancef + earlysettlementchargef + finesf + roundoffexcessf + withdrawchargesf) - (totalsalariesf + totalloanprocessingexpensesf + totalexpensesf + externalloanintrest2f + baddebtorsf + externalearlysettlementchargef + drawingsf+ externalroundoffexcessf+ totalinvestmentcapitalf);
				Cursor = Cursors.WaitCursor;
				timer1.Enabled = true;
				rpttrialbalance2 rpt = new rpttrialbalance2(); //The report you created.
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
				MyCommand.CommandText = "select Top(1) * from Savings where Date between @date1 and @date2  ";
				MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
				MyCommand.CommandType = CommandType.Text;
				myDA.SelectCommand = MyCommand;
				myDA.Fill(myDS, "Savings");
				rpt.SetDataSource(myDS);
				rpt.SetParameterValue("cashathand", cashathand);
				rpt.SetParameterValue("cashatbank1", Cashatbank);
				rpt.SetParameterValue("cashatbank2", CashAtabank2);
				rpt.SetParameterValue("cashatbank3", CashAtabank3);
				rpt.SetParameterValue("cashatbank4", CashAtabank4);
				rpt.SetParameterValue("cashatbank5", CashAtabank5);
				rpt.SetParameterValue("bank1", bank1);
				rpt.SetParameterValue("bank2", bank2);
				rpt.SetParameterValue("bank3", bank3);
				rpt.SetParameterValue("bank4", bank4);
				rpt.SetParameterValue("bank5", bank5);
				rpt.SetParameterValue("equipment", Convert.ToInt32(Convert.ToDouble(Totalequip)));
				rpt.SetParameterValue("savings", Convert.ToInt32(savingssum));
				rpt.SetParameterValue("withdrawcharges", Convert.ToInt32(withdrawcharges));
				rpt.SetParameterValue("salaries", Convert.ToInt32(TotalSalariespayable));
				rpt.SetParameterValue("grants", Convert.ToInt32(Grant));
				rpt.SetParameterValue("fine", Convert.ToInt32(Convert.ToDouble(TotalFin))+ autofines);
				rpt.SetParameterValue("loanapplicationfees", totalapplication);
				rpt.SetParameterValue("expenses", Convert.ToInt32(Totalexpensespayable));
				rpt.SetParameterValue("income", Convert.ToInt32(otherincom));
				rpt.SetParameterValue("shares", shares);
				rpt.SetParameterValue("annaualsubscription", annualsubscriptionfees);
				rpt.SetParameterValue("passbookfees", passledger);
				rpt.SetParameterValue("registrationfees", registerfees);
				rpt.SetParameterValue("accounttoaccountcharges", Convert.ToInt32(transfercharges));
				rpt.SetParameterValue("monthlycharges", Convert.ToInt32(monthlycharges));
				rpt.SetParameterValue("investmentreturns", totalinvestmentreturns);
				//rpt.SetParameterValue("dividens", Convert.ToInt32(devidends));
				rpt.SetParameterValue("issuedloans", Convert.ToInt32(loansum6));
				rpt.SetParameterValue("loanroundoffexcess", Convert.ToInt32(loanroundoffexcess));
				rpt.SetParameterValue("intrest", Convert.ToInt32(loanrepaymentsintrest) + badloanrepaymentsintrest);
				rpt.SetParameterValue("earlysettlement", earlysettlementcharge);
				rpt.SetParameterValue("baddebts", baddebtors);

				rpt.SetParameterValue("investments", investmentcapital);
				rpt.SetParameterValue("externalloanroundoffexcess", Convert.ToInt32(Externalloanroundoffexcess));
				rpt.SetParameterValue("serviceintrest", Convert.ToInt32(externalloanintrest));
				rpt.SetParameterValue("externalfines", Convert.ToInt32(externalfines));
				rpt.SetParameterValue("externalloans", externalloansum6);
				rpt.SetParameterValue("loaninsurancefees", (Convert.ToInt32(loaninsurances) + loaninsurancedue));
				rpt.SetParameterValue("disposal", Disposedassets);
				rpt.SetParameterValue("cumulativereturns", Convert.ToInt32(cumulativereturns));
				rpt.SetParameterValue("investment", Convert.ToInt32(investmentsum));
				rpt.SetParameterValue("loanprocessing", totalloanprocessing);
				rpt.SetParameterValue("externalearlysettlement", externalearlysettlementcharge);
				rpt.SetParameterValue("balanceforward", Convert.ToInt32(broughtforwards));
				rpt.SetParameterValue("balancebd", cashbd);
				rpt.SetParameterValue("duepaymentsliability", duepaymentsliability);
				rpt.SetParameterValue("duepayments", duepayments);

				rpt.SetParameterValue("dateto", DateTo.Text);
				rpt.SetParameterValue("comanyname", companyname);
				rpt.SetParameterValue("companyemail", companyemail);
				rpt.SetParameterValue("companycontact", companycontact);
				rpt.SetParameterValue("companyslogan", companyslogan);
				rpt.SetParameterValue("companyaddress", companyaddress);
				rpt.SetParameterValue("picpath", "logo.jpg");
				frm.crystalReportViewer1.ReportSource = rpt;
				myConnection.Close();
				frm.ShowDialog();
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		 
		}
		int finesdue=0; int maturedinvestments = 0;int investmentcapital = 0; int annualsubscriptionfees = 0; int Disposedassets = 0;  int loanrepaymentsintrestdue = 0; int externalfines = 0;

		private void TotalSalaries_TextChanged(object sender, EventArgs e)
		{

		}

		int cumulativereturns = 0; int cumulativereturnsdue = 0;

		public void Finance2()
		{

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date <= @date2 and PaidOut='Pending'", con);
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
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date <= @date2 and PaidOut='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					cumulativereturnsdue = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					cumulativereturnsdue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment Appreciation Due exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//Loan Fines
		   
			int unpaidloanss = 0;
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where BalanceExist>0  and PaymentDate < @date1", con);
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
					cmd = new SqlCommand("select SUM(BalanceExist) from RepaymentSchedule where BalanceExist>0  and PaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					unpaidloanss = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
					con.Close();
				}
				else
				{
					unpaidloanss = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Repayment Schedule loan balance failed 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Ammount from SupplierAccountTransactions where Date <= @date2 and Clearance='Not Cleared'", con);
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
					cmd = new SqlCommand("select SUM(Ammount) from SupplierAccountTransactions where Date <= @date2 and Clearance='Not Cleared'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
					unpaidequipment = Convert.ToInt32(cmd.ExecuteScalar().ToString());
					con.Close();
				}
				else
				{
					unpaidequipment = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Supplier Account Transactions Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select DueFees from EmployeePayment where  PaymentDate <= @date2", con);
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
					cmd = new SqlCommand("select SUM(TotalPaid) from EmployeePayment where PaymentDate <= @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					staffpa = Convert.ToInt32(cmd.ExecuteScalar().ToString());
					con.Close();
				}
				else
				{
					staffpa = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Accountbalance from InvestorSavings where  OtherMaturityDate between @date1 and @date2 and Appreciated='No'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateTo.Value.Date;
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
					cmd = new SqlCommand("select SUM(Accountbalance) from InvestorSavings where OtherMaturityDate between @date1 and @date2 and Appreciated='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateTo.Value.Date;
					maturedinvestments = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					maturedinvestments = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select BalanceExist from ExternalRepaymentSchedule where BalanceExist >0  and PaymentDate < @date2 and PaymentStatus='Pending'", con);
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
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where BalanceExist >0  and PaymentDate < @date2 and PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					extunpaidloans = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					extunpaidloans = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("External Loan Balance Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select BasicSalary from EmployeePayment where  PaymentDate <= @date2", con);
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
					cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where PaymentDate <= @date2", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					TotalSalariespayable = cmd.ExecuteScalar().ToString();
					con.Close();
				}
				else
				{
					TotalSalariespayable = "0";
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			duepaymentsliability = unpaidequipment + (Convert.ToInt32(TotalSalariespayable) - staffpa)+  cumulativereturnsdue+ extunpaidloans; //(maturedinvestments)
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Fines from RepaymentSchedule where PaymentDate <= @date2 and PaymentStatus='Pending' and Waivered='No'", con);
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
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where PaymentDate <= @date2  and PaymentStatus='Pending' and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					finesdue = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					finesdue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Application fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					con.Close();
				}
				else
				{
					loaninsurancedue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Insurance fees exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where PaymentDate < @date2 and PaymentStatus='Pending'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where PaymentDate < @date2 and PaymentStatus='Pending'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					loanrepaymentsintrestdue = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
					con.Close();
				}
				else
				{
					loanrepaymentsintrestdue = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Interest Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			duepayments =  loaninsurancedue+finesdue + loanrepaymentsintrestdue;
		}

		private void groupPanel3_Click(object sender, EventArgs e)
		{

		}

		int loaninsurancef = 0;int annualsubscriptionfeesf = 0;int transferchargesf = 0; int registerfeesf = 0; int totalinvestmentreturnsf = 0;int passledgerf = 0; int loanprocessingf = 0; int grantsf = 0; int registrationfeesf = 0; int finesf = 0; int otherincomesf = 0;
		int drawingsf = 0;int monthlychargesf = 0; int loanrepaymentsintrest2f = 0;int externalroundoffexcessf = 0; int earlysettlementchargef = 0; int roundoffexcessf = 0; int totalsalariesf = 0; int totalinvestmentcapitalf = 0; int totalloanprocessingexpensesf = 0; int externalloanintrest2f = 0; int totalexpensesf = 0; int baddebtorsf = 0; int externalearlysettlementchargef = 0; int withdrawchargesf=0; int loansf = 0;
		public void finance3()
		{
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Deposit from Savings where Date < @date1 and Transactions ='Monthly Charge'  order by ID DESC", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Deposit) from Savings where Date < @date1 and Transactions ='Monthly Charge'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					monthlychargesf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					monthlychargesf = 0;
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
				cmd = new SqlCommand("select ReturnFee from InvestmentReturns where Date < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(ReturnFee) from InvestmentReturns where Date < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					totalinvestmentreturnsf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentreturnsf = 0;
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
				cmd = new SqlCommand("select AnnualAmmount from AnnualFeesPayment where Date < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AnnualAmmount) from AnnualFeesPayment where Date < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					annualsubscriptionfeesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					annualsubscriptionfeesf = 0;
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
				cmd = new SqlCommand("select PassLedgerLoanAmmount from PassLedgerLoanFees where Date < @date1", con);
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
					passledgerf = Convert.ToInt32(cmd.ExecuteScalar());
				}
				else
				{
					passledgerf = 0;
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
				cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date < @date1", con);
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
					cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					registerfeesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					registerfeesf = 0;
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
				cmd = new SqlCommand("select TransferFee from TransferCharges where Date < @date1", con);
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
					cmd = new SqlCommand("select SUM(TransferFee) from TransferCharges where Date < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					transferchargesf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					transferchargesf = 0;
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
				cmd = new SqlCommand("select AccountExcess from ExternalRepaymentSchedule where PaymentDate < @date1 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from ExternalRepaymentSchedule where PaymentDate < @date1 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
					externalroundoffexcessf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalroundoffexcessf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from RepaymentSchedule where ActualPaymentDate < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(Interest) from RepaymentSchedule where ActualPaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					loanrepaymentsintrest2f = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					loanrepaymentsintrest2f = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Intrest Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AmountPaid from LoanApplicationPayment where PaymentDate < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AmountPaid) from LoanApplicationPayment where PaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					registrationfeesf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					registrationfeesf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					earlysettlementchargef = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					earlysettlementchargef = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AccountExcess from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Paid'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AccountExcess) from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Paid'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					roundoffexcessf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					roundoffexcessf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Round Off Excess Summ Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from EmployeePayment where PaymentDate < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where PaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					totalsalariesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalsalariesf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Employee payment exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where Date <= @date1 and AppreciationAmount >0", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where Date <= @date1 and AppreciationAmount >0", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					totalinvestmentcapitalf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalinvestmentcapitalf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Investment forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Cost from Expenses where Date < @date1 and LoanID !='N/A' and Comment='Approved'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where Date < @date1 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					totalloanprocessingexpensesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalloanprocessingexpensesf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan Processing Fees Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select Interest from ExternalRepaymentSchedule where PaymentDate < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Interest) from ExternalRepaymentSchedule where PaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					externalloanintrest2f = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar().ToString()));
					con.Close();
				}
				else
				{
					externalloanintrest2f = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("External Loan Repayment Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from Expenses where  Date < @date1 and LoanID='N/A' and Comment='Approved' ", con);
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
					cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date < @date1  and LoanID='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					totalexpensesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					totalexpensesf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Expenses forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Written Off' ", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{
					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(TotalAmmount) from RepaymentSchedule where ActualPaymentDate < @date1 and PaymentStatus='Written Off'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					baddebtorsf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					baddebtorsf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule Total Ammount sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select EarlySettlementCharge from ExternalRepaymentSchedule where PaymentDate < @date1", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
				cmd.Connection = con;
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{

					con = new SqlConnection(cs.DBConn);
					con.Open();
					cmd = new SqlCommand("select SUM(EarlySettlementCharge) from ExternalRepaymentSchedule where PaymentDate < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
					externalearlysettlementchargef = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
					con.Close();
				}
				else
				{
					externalearlysettlementchargef = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Repayment Schedule early settlement Sum Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select withdrawFee from WithdrawCharges where Date < @date1 ", con);
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
					cmd = new SqlCommand("select SUM(withdrawFee) from WithdrawCharges where Date < @date1", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					withdrawchargesf = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
				}
				else
				{
					withdrawchargesf = 0;
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
				cmd = new SqlCommand("select Ammount from Drawings", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Ammount) from Drawings", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					drawingsf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					drawingsf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Drawings  sum failed  forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		 
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select OtherFee from OtherIncomes where Date < @date1 and Comment='Approved' ", con);
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
					cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date < @date1 and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					otherincomesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					otherincomesf = 0;
				}
				con.Close();
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
				cmd = new SqlCommand("select Fines from RepaymentSchedule where  ActualPaymentDate < @date1 and Waivered='No'", con);
				cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
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
					cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where  ActualPaymentDate < @date1 and Waivered='No'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "ActualPaymentDate").Value = DateFrom.Value.Date;
					finesf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					finesf = 0;
				}
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Fine fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//Annual Subscription
			//Loan Processing
			try
			{
				con = new SqlConnection(cs.DBConn);
				con.Open();
				cmd = new SqlCommand("select TotalPaid from Expenses where Date < @date1 and LoanID !='N/A' and Comment='Approved'", con);
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
					cmd = new SqlCommand("select SUM(Cost) from Expenses where Date < @date1 and LoanID !='N/A' and Comment='Approved'", con);
					cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
					loanprocessingf = Convert.ToInt32(cmd.ExecuteScalar());
					con.Close();
				}
				else
				{
					loanprocessingf = 0;
				}
				con.Close();
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
				con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Loan insurance fees brought forward exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//External Loan
		  
		   
		}
		private void DateFrom_ValueChanged(object sender, EventArgs e)
		{ 
		   
			try{
			buttonX2.Enabled = true;
			 }
			catch (Exception)
			{
				MessageBox.Show("Button enable failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			buttonX2.Enabled = true;
		}

		private void buttonX6_Click(object sender, EventArgs e)
		{
			company();
			try
			{
				trialbalanceparameters();
				AccrualFinance();
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
				MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2";
				MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
				MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
				MyCommand.CommandType = CommandType.Text;
				myDA.SelectCommand = MyCommand;
				myDA.Fill(myDS, "Savings");
				rpt.SetDataSource(myDS);
				rpt.SetParameterValue("intrestreciepts", Convert.ToInt32(loanrepaymentsintrest2i));
				rpt.SetParameterValue("fines", Convert.ToInt32(totalfinesi));
				rpt.SetParameterValue("loaninsurancefees", Convert.ToInt32(totalloaninsurancei));
				rpt.SetParameterValue("registrationfees", Convert.ToInt32(registrationfeesi));
				rpt.SetParameterValue("otherincomes", Convert.ToInt32(totalotherincomesi));
				rpt.SetParameterValue("processingexpenses", totalloanprocessingexpensesi);
				rpt.SetParameterValue("earlysettlement", earlysettlementchargei);
				rpt.SetParameterValue("roundoffexcess", roundoffexcessi);
				rpt.SetParameterValue("withdrawcharges", Convert.ToInt32(withdrawchargesi));
				rpt.SetParameterValue("totalgrant", totalgranti);

				rpt.SetParameterValue("employeepayments", Convert.ToInt32(totalsalariesi));
				rpt.SetParameterValue("expenses", Convert.ToInt32(totalexpensesi));
				rpt.SetParameterValue("externalloanintrest", Convert.ToInt32(externalloanintrest2i));
				rpt.SetParameterValue("loanprocessing", totalloanprocessingexpensesi);
				rpt.SetParameterValue("baddebit", baddebtorsi);
				rpt.SetParameterValue("externalearlysettlement", externalearlysettlementchargei);
				rpt.SetParameterValue("externalroundoffexcess", externalroundoffexcessi);
				rpt.SetParameterValue("investmentcapital", totalinvestmentcapitali);

				rpt.SetParameterValue("equipmentpurchase", Convert.ToInt32(Convert.ToDouble(Totalequip)));
				rpt.SetParameterValue("issuedloans", Convert.ToInt32(loansum6));
				rpt.SetParameterValue("loanprincipal", Convert.ToInt32(principalammount));

				rpt.SetParameterValue("investmentdeposits", Convert.ToInt32(Investorinvestment));
				rpt.SetParameterValue("externalloans", Convert.ToInt32(externalloansum6));
				rpt.SetParameterValue("savingsdeposits", Convert.ToInt32(totalsavingsincrease));
				rpt.SetParameterValue("withdraws", Convert.ToInt32(totalsavingsreductions));
				rpt.SetParameterValue("investorwithdraw", Convert.ToInt32(investorpayout));
				rpt.SetParameterValue("externalloanrepayment", Convert.ToInt32(externalprincipalammount));
				rpt.SetParameterValue("shareholderdevidends", Convert.ToInt32(drawingstexts));
				rpt.SetParameterValue("cashbroughtforward", Convert.ToInt32(broughtforwards));
				rpt.SetParameterValue("datefrom", DateFrom.Value);
				rpt.SetParameterValue("dateto", DateTo.Value);
				rpt.SetParameterValue("comanyname", companyname);
				rpt.SetParameterValue("companyemail", companyemail);
				rpt.SetParameterValue("companycontact", companycontact);
				rpt.SetParameterValue("companyslogan", companyslogan);
				rpt.SetParameterValue("companyaddress", companyaddress);
				rpt.SetParameterValue("picpath", "logo.jpg");
				frm.crystalReportViewer1.ReportSource = rpt;
				myConnection.Close();
				frm.ShowDialog();
			}catch(Exception){
				MessageBox.Show("Cash Flow Statement Generation failed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		int loansum6 = 0; int balanceexist6 = 0; int paidintrest6 = 0; int paidfines6 = 0; int loanrepayments6 = 0; int unpaidintrest6=0; int unpaidfines6 = 0; int loanroundoffexcess = 0;
		int externalloansum6 = 0; int externalbalanceexist6 = 0; int externalunpaidintrest6 = 0;
	  
	}
}
