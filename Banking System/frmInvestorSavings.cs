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
    public partial class frmInvestorSavings : DevComponents.DotNetBar.Office2007Form
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

        string BarPrinter = null;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmInvestorSavings()
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
            cmd = new SqlCommand("select ID from InvestmentAppreciation  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestmentAppreciation ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            Depositid.Text =days + realid;
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber) FROM InvestorAccount", CN);
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
                    cmbModeOfPayment.Items.Add(drow[1].ToString());
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
            frmInvestorSavings frm = new frmInvestorSavings();
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

                    string usernamess = Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                    numbers = "+256" + numberphone;
                    messages = "A deposit of " + depositammount.Text + " Has been made on your account No. " + accountnumber.Text + ", Accout Name" + accountname.Text + "  and your account balance is " + accountbalance.Text;

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
            if (savingsid.Text == "")
            {
                auto2();
            }
            auto();
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
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
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
            if (savingsid.Text == "")
            {
                MessageBox.Show("Please Generate Investment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                savingsid.Focus();
                return;
            }
            try
            {
                string nextappreciation = null;
                DateTime startdates = DateTime.Parse(date2.Text).Date;
                nextappreciation = (startdates.AddMonths(1)).ToShortDateString();
                DateTime dts = DateTime.Parse(nextappreciation);
                string nextConvertedappreciationDate = dts.ToString("dd/MMM/yyyy");

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
                    int newdeositno = depositedno;
                    int appreciationnos = Convert.ToInt32(MaturityPeriod.Value) - newdeositno;

                    string nextappreciationss = null;
                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                    nextappreciationss = (startdatess.AddMonths(1)).ToShortDateString();
                    DateTime dtsss = DateTime.Parse(nextappreciationss);
                    string nextConvertedappreciationDatess = dtsss.ToString("dd/MMM/yyyy"); 

                   

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into InvestmentAppreciation(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,InterestRate,AppreciationNo,NextAppreciationDate,DepositID,Interval,Credit,Installment,PaymentMode) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'"+depositammount.Value+"','"+ installment.Text+ "','" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 12, "InterestRate"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 30, "AppreciationNo"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "NextAppreciationDate"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "DepositID"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "Interval"));
          
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value;
                    cmd.Parameters["@d8"].Value = IntrestRate.Text;
                    cmd.Parameters["@d9"].Value = MaturityPeriod.Value;
                    cmd.Parameters["@d10"].Value = nextConvertedappreciationDate;
                    cmd.Parameters["@d11"].Value = Depositid.Text;
                    cmd.Parameters["@d12"].Value = depositinterval.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string ConvertedappreciationDatess = null;
                    /*if (depositinterval.Text == "One Off")
                    {
                        string appreciationDatess = null;
                        DateTime startdatess = DateTime.Parse(date2.Text).Date;
                        appreciationDatess = (startdatess.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                        DateTime dtss = DateTime.Parse(appreciationDatess);
                        ConvertedappreciationDatess = dtss.ToString("dd/MMM/yyyy");*/
                    //}
                   // else
                    //{
                        string appreciationDatess = null;
                        DateTime startdatess = DateTime.Parse(date2.Text).Date;
                        appreciationDatess = (startdatess.AddMonths(1)).ToShortDateString();
                        DateTime dtss = DateTime.Parse(appreciationDatess);
                        ConvertedappreciationDatess = dtss.ToString("dd/MMM/yyyy");
                    //}
                    string appreciationDate = null;
                    DateTime startdate = DateTime.Parse(date2.Text).Date;
                    appreciationDate = (startdate.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                    DateTime dt = DateTime.Parse(appreciationDate);
                    string ConvertedappreciationDate = dt.ToString("dd/MMM/yyyy");

                    string appreciationDatesss = null;
                    DateTime startdatesss = DateTime.Parse(date2.Text).Date;
                    appreciationDatesss = (startdatesss.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                    DateTime dtsss = DateTime.Parse(appreciationDatesss);
                    string ConvertedappreciationDatesss = dtsss.ToString("dd/MMM/yyyy");
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "insert into InvestorSavings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,InterestRate,MaturityPeriod,MaturityDate,InvestmentPlan,DepositInterval,DepositedInstallmentNo,OtherMaturityDate,NextDepositDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,-1,@d16,'"+ ConvertedappreciationDatess+ "')";
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
                    cmd.Parameters["@d7"].Value = 0;
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
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb5 = "insert into InvestmentAppreciation(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,InterestRate,AppreciationNo,NextAppreciationDate,DepositID,Interval,Credit,Installment,PaymentMode) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'"+depositammount.Value+"','"+ installment.Text+ "','" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb5);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 12, "InterestRate"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 30, "AppreciationNo"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "NextAppreciationDate"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "DepositID"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "Interval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value;
                    cmd.Parameters["@d8"].Value = IntrestRate.Text;
                    cmd.Parameters["@d9"].Value = MaturityPeriod.Value;
                    cmd.Parameters["@d10"].Value = ConvertedappreciationDatess;
                    cmd.Parameters["@d11"].Value = Depositid.Text;
                    cmd.Parameters["@d12"].Value = depositinterval.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();

                MessageBox.Show("Successfully saved", "Investment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    //sendmessage();
                }
                buttonX5.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmInvestorSavings frm2 = new frmInvestorSavings();
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
            /*try
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountnumber.Text + "' and Accountbalance > 0";
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and InvestorDeposit='Yes'";
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
                    string ct2 = "select Accountbalance from InvestorSavings where  SavingsID= '" + savingsid.Text + "' order by ID Desc";
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
                    con.Close();
                }
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
            if (savingsid.Text == "")
            {
                auto2();
            }
            auto();
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
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
                return;
            }
            try
            {
                string nextappreciation = null;
                DateTime startdates = DateTime.Parse(date2.Text).Date;
                nextappreciation = (startdates.AddMonths(1)).ToShortDateString();
                DateTime dts = DateTime.Parse(nextappreciation);
                string nextConvertedappreciationDate = dts.ToString("dd/MMM/yyyy");

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
                    int newdeositno = depositedno + 1;
                    int appreciationnos = Convert.ToInt32(MaturityPeriod.Value) - newdeositno;

                    string nextappreciationss = null;
                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                    nextappreciationss = (startdatess.AddMonths(appreciationnos)).ToShortDateString();
                    DateTime dtsss = DateTime.Parse(nextappreciationss);
                    string nextConvertedappreciationDatess = dtsss.ToString("dd/MMM/yyyy");

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update InvestorSavings set OtherMaturityDate=@d4,AccountBalance =@d2,DepositedInstallmentNo=@d3 where SavingsID=@d1";
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

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into InvestmentAppreciation(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,InterestRate,AppreciationNo,NextAppreciationDate,DepositID,Interval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 12, "InterestRate"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 30, "AppreciationNo"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "NextAppreciationDate"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "DepositID"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "Interval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value;
                    cmd.Parameters["@d8"].Value = IntrestRate.Text;
                    cmd.Parameters["@d9"].Value = appreciationnos;
                    cmd.Parameters["@d10"].Value = nextConvertedappreciationDate;
                    cmd.Parameters["@d11"].Value = Depositid.Text;
                    cmd.Parameters["@d12"].Value = depositinterval.Text;
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
                    string cb = "insert into InvestorSavings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,InterestRate,MaturityPeriod,MaturityDate,InvestmentPlan,DepositInterval,DepositedInstallmentNo,OtherMaturityDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,1,@d16)";
                    cmd = new SqlCommand(cb);
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
                    cmd.Parameters["@d8"].Value = submittedby.Text;
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
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "insert into InvestmentAppreciation(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,InterestRate,AppreciationNo,NextAppreciationDate,DepositID,Interval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 12, "InterestRate"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 30, "AppreciationNo"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "NextAppreciationDate"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "DepositID"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "Interval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value;
                    cmd.Parameters["@d8"].Value = IntrestRate.Text;
                    cmd.Parameters["@d9"].Value = MaturityPeriod.Value;
                    cmd.Parameters["@d10"].Value = nextConvertedappreciationDate;
                    cmd.Parameters["@d11"].Value = Depositid.Text;
                    cmd.Parameters["@d12"].Value = depositinterval.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                MessageBox.Show("Successfully saved", "Investment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    sendmessage();
                }
                buttonX5.Enabled = false;
                con.Close();
                company();
                try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    rptReceiptSavings rpt = new rptReceiptSavings(); //The report you created.
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
                    //frm.ShowDialog();
                    BarPrinter = Properties.Settings.Default.frontendprinter;
                    rpt.PrintOptions.PrinterName = BarPrinter;
                    rpt.PrintToPrinter(1, true, 1, 1);
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                buttonX5.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            frmInvestorSavings frm2 = new frmInvestorSavings();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
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
                    depositinterval.Text= rdr["DepositInterval"].ToString();
                    maturitydate.Text = rdr["OtherMaturityDate"].ToString();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            try
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
                    installment.Text = "";
                }
                depositammount.Enabled = false;
                IntrestRate.Enabled = false;
                investmentplan.Enabled = false;
                MaturityPeriod.Enabled = false;
                depositinterval.Enabled = false;
                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountnumber_TextChanged(object sender, EventArgs e)
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(SavingsID) FROM InvestorSavings where AccountNo='" + accountnumber.Text + "' and Accountbalance > 0";
                rdr = cmd.ExecuteReader();
                savingsid.Items.Clear();
                while (rdr.Read() == true)
                {
                    savingsid.Items.Add(rdr.GetString(0).Trim());
                }
                /*if ((rdr != null))
                {
                    rdr.Close();
                }*/
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
    }
}
