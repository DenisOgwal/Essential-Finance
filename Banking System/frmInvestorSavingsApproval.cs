using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Net;
namespace Banking_System
{
    public partial class frmInvestorSavingsApproval : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmInvestorSavingsApproval()
        {
            InitializeComponent();
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from InvestorSavings where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestorSavings where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            if (investmentplan.Text == "Silver Extra")
            {
                savingsid.Text = "SE-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Premium")
            {
                savingsid.Text = "P-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Premium Extra")
            {
                savingsid.Text = "PE-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Silver")
            {
                savingsid.Text = "S-" + years + monthss + days + realid;
            }

        }
        private void auto()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from InvestmentAppreciation where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestmentAppreciation where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            Depositid.Text =years + monthss + days + realid;
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(SavingsID)[Investment ID],RTRIM(DepositID)[Deposit ID],RTRIM(Date)[Date] from InvestmentAppreciation where Approved='Not Approved' and Credit>0 order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestmentAppreciation");
                dataGridView1.DataSource = myDataSet.Tables["InvestmentAppreciation"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNames) FROM InvestorAccount", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                accountnumber.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    accountnumber.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber),RTRIM(AccountNames) FROM BankAccounts", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbModeOfPayment.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInvestorSavingsApproval frm = new frmInvestorSavingsApproval();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        string numberphone = null;
        string messages = null;
        public void sendmessage()
        {
            string numbers = null;
            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM InvestorAccount where AccountNumber='" + accountnumber.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        numberphone = rdr.GetString(0);
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    string smsheader = Properties.Settings.Default.Smscode;
                    string inquiryphone = Properties.Settings.Default.phoneinquiry;
                    string usernamess = Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                    numbers = "+256" + numberphone;
                   // messages = "A deposit of " + depositammount.Text + " Has been made on your account No. " + accountnumber.Text + ", Accout Name" + accountname.Text + "  and your account balance is " + accountbalance.Text;
                    messages = smsheader + ": Your Account has been Credited UGX. " + depositammount.Text + " Reason:Investment Deposit. For Any Inquiries Call: " + inquiryphone;

                    WebClient client = new WebClient();
                    string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username=" + usernamess + "&password=" + passwordss + "&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                    client.OpenRead(baseURL);
                    //MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Internet Connection, The message was not sent");
            }
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {

            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (depositammount.Text == "")
            {
                MessageBox.Show("Please enter Deposited ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositammount.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }

            if (IntrestRate.Text == "")
            {
                MessageBox.Show("Please Enter Interest Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IntrestRate.Focus();
                return;
            }
            if (MaturityPeriod.Text == "")
            {
                MessageBox.Show("Please Enter Investment Maturity Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaturityPeriod.Focus();
                return;
            }
            if (depositinterval.Text == "")
            {
                MessageBox.Show("Please Select Deposit Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositinterval.Focus();
                return;
            }
            if (installment.Text == "")
            {
                MessageBox.Show("Please Enter Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                installment.Focus();
                return;
            }
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }

            try
            {
                if (approvals.Text.Trim() == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Deposit,AccountBalance,DepositedInstallmentNo from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int accountbalances = Convert.ToInt32(rdr[1]);
                        int newaccountbalance = accountbalances + depositammount.Value;
                        int depositedno = Convert.ToInt32(rdr[2]);
                        int newdeositno = depositedno+1;
                        int appreciationnos = Convert.ToInt32(MaturityPeriod.Value);

                        string nextappreciationss = null;
                        DateTime startdatess = DateTime.Parse(date2.Text).Date;
                        nextappreciationss = (startdatess.AddMonths(appreciationnos)).ToShortDateString();
                        DateTime dtsss = DateTime.Parse(nextappreciationss);
                        string nextConvertedappreciationDatess = dtsss.ToString("dd/MMM/yyyy");

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "update InvestorSavings set OtherMaturityDate=@d4,AccountBalance=@d2,DepositedInstallmentNo=@d3,UploadStatus='Pending' where SavingsID=@d1";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AccountBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "DepositedInstallmentNo"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "OtherMaturityDate"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.Parameters["@d2"].Value = newaccountbalance;
                        cmd.Parameters["@d3"].Value = newdeositno;
                        cmd.Parameters["@d4"].Value = nextConvertedappreciationDatess;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string appreciationDate = null;
                        DateTime startdate = DateTime.Parse(date2.Text).Date;
                        appreciationDate = (startdate.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                        DateTime dt = DateTime.Parse(appreciationDate);
                        string ConvertedappreciationDate = dt.ToString("dd/MMM/yyyy");
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "insert into InvestorSavings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,InterestRate,MaturityPeriod,MaturityDate,InvestmentPlan,DepositInterval,DepositedInstallmentNo,OtherMaturityDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,1,@d16)";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "Transactions"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "InterestRate"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 20, "MaturityPeriod"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "MaturityDate"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 30, "InvestmentPlan"));
                        cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "DepositInterval"));
                        cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 20, "OtherMaturiyDate"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                        cmd.Parameters["@d3"].Value = accountname.Text;
                        cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                        cmd.Parameters["@d5"].Value = date2.Text.Trim();
                        cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                        cmd.Parameters["@d7"].Value = accountbalance.Value;
                        cmd.Parameters["@d8"].Value = "N/A";
                        cmd.Parameters["@d9"].Value = "Deposit";
                        cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                        cmd.Parameters["@d11"].Value = IntrestRate.Text;
                        cmd.Parameters["@d12"].Value = MaturityPeriod.Value;
                        cmd.Parameters["@d13"].Value = ConvertedappreciationDate;
                        cmd.Parameters["@d14"].Value = investmentplan.Text;
                        cmd.Parameters["@d15"].Value = depositinterval.Text;
                        cmd.Parameters["@d16"].Value = ConvertedappreciationDate;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                    int totalaamount = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                        int newtotalammount = totalaamount + Convert.ToInt32(depositammount.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + date2.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                    string smsallow = Properties.Settings.Default.smsallow;
                    if (smsallow == "Yes")
                    {
                        sendmessage();
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct8 = "select InvestmentID from InvestmentSchedule where InvestmentID= '" + savingsid.Text.Trim() + "' ";
                    cmd = new SqlCommand(ct8);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "update InvestmentSchedule set PaymentStatus='Paid',PaymentDate='" + date2.Text + "',UploadStatus='Pending'  where InvestmentID=@d1 and Months='" + installment.Text.ToString().Trim() + "' ";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string investmentid = savingsid.Text;
                        string accountnumbers = accountnumber.Text;
                        string accountnamess = accountname.Text;
                        int ammountpay = depositammount.Value;
                        double Intrestearned = ((Convert.ToDouble(IntrestRate.Text) / 100) / 12) * depositammount.Value;
                        if (depositinterval.Text.ToString().Trim() == "One Off")
                        {
                            double cumulation = Intrestearned * MaturityPeriod.Value;
                            string installmentno = "Installment 1";
                            string appreciationDatess = null;
                            DateTime startdatess = DateTime.Parse(date2.Text).Date;
                            appreciationDatess = (startdatess.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                            DateTime dtss = DateTime.Parse(appreciationDatess);
                            string maturitydates = dtss.ToString("dd/MMM/yyyy");

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cbs = "insert into InvestmentSchedule(InvestmentID,AccountNumber,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths,PaymentStatus,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                            cmd = new SqlCommand(cbs);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Cumulation"));
                            cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                            cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "PaymentStatus"));
                            cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                            cmd.Parameters["@d1"].Value = savingsid.Text;
                            cmd.Parameters["@d2"].Value = accountnumber.Text;
                            cmd.Parameters["@d3"].Value = installmentno;
                            cmd.Parameters["@d4"].Value = maturitydates;
                            cmd.Parameters["@d5"].Value = ammountpay;
                            cmd.Parameters["@d6"].Value = Intrestearned;
                            cmd.Parameters["@d7"].Value = cumulation;
                            cmd.Parameters["@d8"].Value = MaturityPeriod.Value;
                            cmd.Parameters["@d9"].Value = "Paid";
                            cmd.Parameters["@d10"].Value = accountname.Text;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            for (int i = 1; i <= (Convert.ToInt32(MaturityPeriod.Text)); i++)
                            {
                                string paymentstatus = null;
                                string installmentno = null;
                                double cumulation = 0.00;
                                string maturitydates = null;
                                int leftmonths = 0;
                                if (i == 1)
                                {
                                    cumulation = Intrestearned * MaturityPeriod.Value;
                                    installmentno = "Installment 1";
                                    string appreciationDatess = null;
                                    leftmonths = MaturityPeriod.Value;
                                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                                    appreciationDatess = (startdatess.AddMonths(0)).ToShortDateString();
                                    DateTime dtss = DateTime.Parse(appreciationDatess);
                                    maturitydates = dtss.ToString("dd/MMM/yyyy");
                                    paymentstatus = "Paid";
                                }
                                else
                                {
                                    //int noofmoths = Convert.ToInt32(rdr["AccrualMonths"]);
                                    leftmonths = MaturityPeriod.Value - (i - 1);
                                    cumulation = Intrestearned * leftmonths;
                                    installmentno = "Installment " + i;
                                    string appreciationDatess = null;
                                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                                    appreciationDatess = (startdatess.AddMonths(i - 1)).ToShortDateString();
                                    DateTime dtss = DateTime.Parse(appreciationDatess);
                                    maturitydates = dtss.ToString("dd/MMM/yyyy");
                                    paymentstatus = "Pending";
                                }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cbs = "insert into InvestmentSchedule(InvestmentID,AccountNumber,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths,PaymentStatus,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                                cmd = new SqlCommand(cbs);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Cumulation"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "PaymentStatus"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                cmd.Parameters["@d1"].Value = savingsid.Text;
                                cmd.Parameters["@d2"].Value = accountnumber.Text;
                                cmd.Parameters["@d3"].Value = installmentno;
                                cmd.Parameters["@d4"].Value = maturitydates;
                                cmd.Parameters["@d5"].Value = ammountpay;
                                cmd.Parameters["@d6"].Value = Intrestearned;
                                cmd.Parameters["@d7"].Value = cumulation;
                                cmd.Parameters["@d8"].Value = leftmonths;
                                cmd.Parameters["@d9"].Value = paymentstatus;
                                cmd.Parameters["@d10"].Value = accountname.Text;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        con.Close();
                    }
                   
                    if (installment.Text.ToString().Trim() == "Installment 1")
                    {
                        company();
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
                            FrmInvestorLegalCertificate frm = new FrmInvestorLegalCertificate();
                            myConnection = new SqlConnection(cs.DBConn);
                            MyCommand.Connection = myConnection;
                            MyCommand.CommandText = "select * from InvestmentSchedule where InvestmentID='" + savingsid.Text + "'";
                            MyCommand.CommandType = CommandType.Text;
                            myDA.SelectCommand = MyCommand;
                            myDA.Fill(myDS, "InvestmentSchedule");
                            rpt.SetDataSource(myDS);
                            rpt.SetParameterValue("investmentterm", MaturityPeriod.Text);
                            rpt.SetParameterValue("investmentplan", investmentplan.Text);
                            rpt.SetParameterValue("maturitydate", maturitydate.Text);
                            rpt.SetParameterValue("monthlyrate", IntrestRate.Text);
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                string nextappreciationsss = null;
                DateTime startdatesss = DateTime.Parse(date2.Text).Date;
                nextappreciationsss = (startdatesss.AddMonths(1)).ToShortDateString();
                DateTime dtssss = DateTime.Parse(nextappreciationsss);
                string nextConvertedappreciationDatesss = dtssss.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE InvestmentAppreciation SET Approved=@d2,NextAppreciationDate='"+ nextConvertedappreciationDatesss + "', ApprovedBy=@d3 WHERE SavingsID=@d1 and DepositID=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approved"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "DepositID"));

                cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                cmd.Parameters["@d2"].Value = approvals.Text;
                cmd.Parameters["@d3"].Value = cashiername.Text;
                cmd.Parameters["@d4"].Value = Depositid.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Investment Deposit Approval Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX5.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Hide();
            frmInvestorSavingsApproval frm2 = new frmInvestorSavingsApproval();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {

        }

        private void frmSavings_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* this.Hide();
             frmMainMenu frm = new frmMainMenu();
             frm.User.Text = label1.Text;
             frm.UserType.Text = label2.Text;
             frm.Show();*/
        }
        private void cashierid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName FROM Rights WHERE AuthorisationID = '" + cashierid.Text + "' and Category='Cashier'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cashiername.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountnumber2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(AccountNames) FROM InvestorAccount where AccountNumber='" + accountnumber.Text + "'";
                rdr = cmd.ExecuteReader();
                accountname.Text = "";
                if (rdr.Read())
                {
                    accountname.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                /*con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountnumber.Text + "'";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                while (rdr.Read() == true)
                {
                    savingsid.Items.Add(rdr.GetString(0).Trim());
                }
                /*if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void depositammount_ValueChanged(object sender, EventArgs e)
        {
            groupPanel3.Enabled = true;
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        private void cashierid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(cashierid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and InvestorSavingsApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        cashiername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        cashiername.Text = "";
                    }
                }
                else
                {
                    cashiername.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void depositammount_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (depositammount.Text == "") { }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    int val4 = 0;
                    int val5 = 0;
                    string ct2 = "select Accountbalance from InvestorSavings where SavingsID= '" + savingsid.Text + "' order by ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        string Accbalance = rdr2["Accountbalance"].ToString();
                        val4 = Convert.ToInt32(Accbalance);
                        int.TryParse(depositammount.Value.ToString(), out val5);
                        accountbalance.Value = (val4 + val5);
                        if ((rdr2 != null))
                        {
                            rdr2.Close();
                        }
                    }
                    else
                    {
                        int val1 = 0;
                        int.TryParse(depositammount.Value.ToString(), out val1);
                        accountbalance.Value = val1;
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {

            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (depositammount.Text == "")
            {
                MessageBox.Show("Please enter Deposited ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositammount.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (installment.Text == "")
            {
                MessageBox.Show("Please Enter Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                installment.Focus();
                return;
            }
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }
            try
            {
                if (approvals.Text.Trim() == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Deposit,AccountBalance,DepositedInstallmentNo from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int accountbalances = Convert.ToInt32(rdr[1]);
                        int newaccountbalance = accountbalances + depositammount.Value;
                        int depositedno = Convert.ToInt32(rdr[2]);
                        int newdeositno = depositedno+1;
                        int appreciationnos = Convert.ToInt32(MaturityPeriod.Value) - (newdeositno);

                        string nextappreciationss = null;
                        DateTime startdatess = DateTime.Parse(date2.Text).Date;
                        nextappreciationss = (startdatess.AddMonths(appreciationnos)).ToShortDateString();
                        DateTime dtsss = DateTime.Parse(nextappreciationss);
                        string nextConvertedappreciationDatess = dtsss.ToString("dd/MMM/yyyy");

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "update InvestorSavings set OtherMaturityDate=@d4,AccountBalance =@d2,DepositedInstallmentNo=@d3,UploadStatus='Pending' where SavingsID=@d1";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AccountBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "DepositedInstallmentNo"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "OtherMaturityDate"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.Parameters["@d2"].Value = newaccountbalance;
                        cmd.Parameters["@d3"].Value = newdeositno;
                        cmd.Parameters["@d4"].Value = nextConvertedappreciationDatess;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string appreciationDate = null;
                        DateTime startdate = DateTime.Parse(date2.Text).Date;
                        appreciationDate = (startdate.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                        DateTime dt = DateTime.Parse(appreciationDate);
                        string ConvertedappreciationDate = dt.ToString("dd/MMM/yyyy");
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "insert into InvestorSavings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,InterestRate,MaturityPeriod,MaturityDate,InvestmentPlan,DepositInterval,DepositedInstallmentNo,OtherMaturityDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,1,@d16)";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "Transactions"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "InterestRate"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 20, "MaturityPeriod"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "MaturityDate"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 30, "InvestmentPlan"));
                        cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "DepositInterval"));
                        cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 20, "OtherMaturiyDate"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                        cmd.Parameters["@d3"].Value = accountname.Text;
                        cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                        cmd.Parameters["@d5"].Value = date2.Text.Trim();
                        cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                        cmd.Parameters["@d7"].Value = accountbalance.Value;
                        cmd.Parameters["@d8"].Value = "N/A";
                        cmd.Parameters["@d9"].Value = "Deposit";
                        cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                        cmd.Parameters["@d11"].Value = IntrestRate.Text;
                        cmd.Parameters["@d12"].Value = MaturityPeriod.Value;
                        cmd.Parameters["@d13"].Value = ConvertedappreciationDate;
                        cmd.Parameters["@d14"].Value = investmentplan.Text;
                        cmd.Parameters["@d15"].Value = depositinterval.Text;
                        cmd.Parameters["@d16"].Value = ConvertedappreciationDate;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                    int totalaamount = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                        int newtotalammount = totalaamount + Convert.ToInt32(depositammount.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + date2.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                    string smsallow = Properties.Settings.Default.smsallow;
                    if (smsallow == "Yes")
                    {
                        sendmessage();
                    }


                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct8 = "select InvestmentID from InvestmentSchedule where InvestmentID= '" + savingsid.Text + "' ";
                    cmd = new SqlCommand(ct8);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "update InvestmentSchedule set PaymentStatus='Paid',PaymentDate='" + date2.Text + "',UploadStatus='Pending' where InvestmentID=@d1 and Months='" + installment.Text + "' ";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                        cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string investmentid = savingsid.Text;
                        string accountnumbers = accountnumber.Text;
                        string accountnamess = accountname.Text;
                        int ammountpay = depositammount.Value;
                        double Intrestearned = ((Convert.ToDouble(IntrestRate.Text) / 100) / 12) * depositammount.Value;
                        if (depositinterval.Text.ToString().Trim() == "One Off")
                        {
                            double cumulation = Intrestearned * MaturityPeriod.Value;
                            string installmentno = "Installment 1";
                            string appreciationDatess = null;
                            DateTime startdatess = DateTime.Parse(date2.Text).Date;
                            appreciationDatess = (startdatess.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                            DateTime dtss = DateTime.Parse(appreciationDatess);
                            string maturitydates = dtss.ToString("dd/MMM/yyyy");

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cbs = "insert into InvestmentSchedule(InvestmentID,AccountNumber,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths,PaymentStatus,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                            cmd = new SqlCommand(cbs);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Cumulation"));
                            cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                            cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "PaymentStatus"));
                            cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                            cmd.Parameters["@d1"].Value = savingsid.Text;
                            cmd.Parameters["@d2"].Value = accountnumber.Text;
                            cmd.Parameters["@d3"].Value = installmentno;
                            cmd.Parameters["@d4"].Value = maturitydates;
                            cmd.Parameters["@d5"].Value = ammountpay;
                            cmd.Parameters["@d6"].Value = Intrestearned;
                            cmd.Parameters["@d7"].Value = cumulation;
                            cmd.Parameters["@d8"].Value = MaturityPeriod.Value;
                            cmd.Parameters["@d9"].Value = "Paid";
                            cmd.Parameters["@d10"].Value = accountname.Text;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            for (int i = 1; i <= (Convert.ToInt32(MaturityPeriod.Text)); i++)
                            {
                                string paymentstatus = null;
                                string installmentno = null;
                                double cumulation = 0.00;
                                string maturitydates = null;
                                int leftmonths = 0;
                                if (i == 1)
                                {
                                    cumulation = Intrestearned * MaturityPeriod.Value;
                                    installmentno = "Installment 1";
                                    string appreciationDatess = null;
                                    leftmonths = MaturityPeriod.Value;
                                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                                    appreciationDatess = (startdatess.AddMonths(0)).ToShortDateString();
                                    DateTime dtss = DateTime.Parse(appreciationDatess);
                                    maturitydates = dtss.ToString("dd/MMM/yyyy");
                                    paymentstatus = "Paid";
                                }
                                else
                                {
                                    //int noofmoths = Convert.ToInt32(rdr["AccrualMonths"]);
                                    leftmonths = MaturityPeriod.Value - (i - 1);
                                    cumulation = Intrestearned * leftmonths;
                                    installmentno = "Installment " + i;
                                    string appreciationDatess = null;
                                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                                    appreciationDatess = (startdatess.AddMonths(i - 1)).ToShortDateString();
                                    DateTime dtss = DateTime.Parse(appreciationDatess);
                                    maturitydates = dtss.ToString("dd/MMM/yyyy");
                                    paymentstatus = "Pending";
                                }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cbs = "insert into InvestmentSchedule(InvestmentID,AccountNumber,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths,PaymentStatus,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                                cmd = new SqlCommand(cbs);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Cumulation"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "PaymentStatus"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                cmd.Parameters["@d1"].Value = savingsid.Text;
                                cmd.Parameters["@d2"].Value = accountnumber.Text;
                                cmd.Parameters["@d3"].Value = installmentno;
                                cmd.Parameters["@d4"].Value = maturitydates;
                                cmd.Parameters["@d5"].Value = ammountpay;
                                cmd.Parameters["@d6"].Value = Intrestearned;
                                cmd.Parameters["@d7"].Value = cumulation;
                                cmd.Parameters["@d8"].Value = leftmonths;
                                cmd.Parameters["@d9"].Value = paymentstatus;
                                cmd.Parameters["@d10"].Value = accountname.Text;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    con.Close();
                    company();
                    try
                    {
                        //this.Hide();
                        Cursor = Cursors.WaitCursor;
                        //timer1.Enabled = true;
                        rptReceiptInvestor rpt = new rptReceiptInvestor(); //The report you created.
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet(); //The DataSet you created.
                        Receipt frm = new Receipt();
                        myConnection = new SqlConnection(cs.DBConn);
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select * from Expenses";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "Expenses");
                        //myDA.Fill(myDS, "Rights");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("paymentid", savingsid.Text);
                        rpt.SetParameterValue("accountno", accountnumber.Text);
                        rpt.SetParameterValue("membernames", accountname.Text);
                        rpt.SetParameterValue("ammount", depositammount.Value);
                        rpt.SetParameterValue("totalpaid", accountbalance.Value);
                        rpt.SetParameterValue("issuedby", cashiername.Text);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        frm.crystalReportViewer1.ReportSource = rpt;
                        myConnection.Close();
                        if (printoptionss == "autoprint")
                        {
                            string BarPrinter = Properties.Settings.Default.frontendprinter;
                            rpt.PrintOptions.PrinterName = BarPrinter;
                            rpt.PrintToPrinter(1, true, 1, 1);
                        }
                        else
                        {
                            frm.ShowDialog();
                        }
                        //BarPrinter = Properties.Settings.Default.frontendprinter;
                        //rpt.PrintOptions.PrinterName = BarPrinter;
                        //rpt.PrintToPrinter(1, true, 1, 1);
                        //this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    buttonX5.Enabled = false;
                    con.Close();

                    if (installment.Text.ToString().Trim() == "Installment 1")
                    {
                        company();
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
                            FrmInvestorLegalCertificate frm = new FrmInvestorLegalCertificate();
                            myConnection = new SqlConnection(cs.DBConn);
                            MyCommand.Connection = myConnection;
                            MyCommand.CommandText = "select * from InvestmentSchedule where InvestmentID='" + savingsid.Text + "'";
                            MyCommand.CommandType = CommandType.Text;
                            myDA.SelectCommand = MyCommand;
                            myDA.Fill(myDS, "InvestmentSchedule");
                            rpt.SetDataSource(myDS);
                            rpt.SetParameterValue("investmentterm", MaturityPeriod.Text);
                            rpt.SetParameterValue("investmentplan", investmentplan.Text);
                            rpt.SetParameterValue("maturitydate", maturitydate.Text);
                            rpt.SetParameterValue("monthlyrate", IntrestRate.Text);
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                string nextappreciationsss = null;
                DateTime startdatesss = DateTime.Parse(date2.Text).Date;
                nextappreciationsss = (startdatesss.AddMonths(1)).ToShortDateString();
                DateTime dtssss = DateTime.Parse(nextappreciationsss);
                string nextConvertedappreciationDatesss = dtssss.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE InvestmentAppreciation SET Approved=@d2,NextAppreciationDate='" + nextConvertedappreciationDatesss + "', ApprovedBy=@d3 WHERE SavingsID=@d1 and DepositID=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approved"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "DepositID"));

                cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                cmd.Parameters["@d2"].Value = approvals.Text;
                cmd.Parameters["@d3"].Value = cashiername.Text;
                cmd.Parameters["@d4"].Value = Depositid.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Investment Deposit Approval Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX5.Enabled = false;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            this.Hide();
            frmInvestorSavingsApproval frm2 = new frmInvestorSavingsApproval();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
        string printoptionss = Properties.Settings.Default.PrintOptions;
        private void accountnumber2_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            this.accountnumber.Text = frm.clientnames.Text;
            this.accountname.Text = frm.Accountnames.Text;
            return;
        }

        private void membername2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AccountType FROM InvestorAccount where AccountNumber='" + accountnumber.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label3.Text = rdr[0].ToString().Trim();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaturityPeriod,MinimumAmount FROM InvestorAccountTypes where AccountName='" + label3.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    depositammount.Text = rdr[1].ToString().Trim();
                    MaturityPeriod.Text = rdr[0].ToString().Trim();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaturityPeriod_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (MaturityPeriod.Text == " ")
                {
                    return;
                }
                else
                {
                    DateTime target = DateTime.Parse(date2.Text.ToString()).Date;
                    target = target.AddMonths(MaturityPeriod.Value);
                    maturitydate.Text = target.ToString("dd/MMM/yyyy");
                }
            }
            catch (Exception)
            {
                MaturityPeriod.Text = "";
            }
        }

        private void savingsid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select * from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    depositammount.Value = Convert.ToInt32(rdr["Deposit"]);
                    investmentplan.Text = rdr["InvestmentPlan"].ToString();
                    IntrestRate.Text = rdr["InterestRate"].ToString();
                    //accountbalance.Text = rdr["AccountBalance"].ToString();
                    MaturityPeriod.Text = rdr["MaturityPeriod"].ToString();
                    depositinterval.Text= rdr["DepositInterval"].ToString();
                    maturitydate.Text = rdr["OtherMaturityDate"].ToString();
                    cmbModeOfPayment.Text = rdr["ModeOfPayment"].ToString();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            try
            {

                if (depositinterval.Text == "One Off")
                {
                    installment.Text = "Installment 1";
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Months,AccrualMonths from InvestmentSchedule where InvestmentID='" + savingsid.Text + "' and PaymentStatus='Pending' order by ID Asc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        installment.Text = rdr["Months"].ToString();
                        MaturityPeriod.Text = rdr["AccrualMonths"].ToString();
                    }
                    else
                    {
                        if (depositinterval.Text == "One Off")
                        {
                            installment.Text = "Installment 1";
                        }
                        else
                        {
                            installment.Text = "";
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                accountnumber.Text = dr.Cells[0].Value.ToString();
                accountname.Text = dr.Cells[1].Value.ToString();
                savingsid.Text = dr.Cells[2].Value.ToString();
                Depositid.Text = dr.Cells[3].Value.ToString();
                date2.Text = dr.Cells[4].Value.ToString().Trim(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Depositid_TextChanged(object sender, EventArgs e)
        {

        }

        private void savingsid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select * from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    depositammount.Value = Convert.ToInt32(rdr["Deposit"]);
                    investmentplan.Text = rdr["InvestmentPlan"].ToString();
                    IntrestRate.Text = rdr["InterestRate"].ToString();
                    //accountbalance.Text = rdr["AccountBalance"].ToString();
                    MaturityPeriod.Text = rdr["MaturityPeriod"].ToString();
                    depositinterval.Text = rdr["DepositInterval"].ToString();
                    maturitydate.Text = rdr["OtherMaturityDate"].ToString();
                    cmbModeOfPayment.Text = rdr["ModeOfPayment"].ToString();
                    cashier.Text = rdr["CashierName"].ToString();
                   
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (depositinterval.Text == "One Off")
                {
                    installment.Text = "Installment 1";
                }
                else
                {
                    SqlDataReader rdr = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Months,AccrualMonths from InvestmentSchedule where InvestmentID='" + savingsid.Text + "' and PaymentStatus='Pending' order by ID Asc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        installment.Text = rdr["Months"].ToString();
                        MaturityPeriod.Text = rdr["AccrualMonths"].ToString();
                    }
                    else
                    {
                        if (depositinterval.Text == "One Off")
                        {
                            installment.Text = "Installment 1";
                        }
                        else
                        {
                            installment.Text = "Installment 1";
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
