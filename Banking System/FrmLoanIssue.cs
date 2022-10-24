using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace Banking_System
{
    public partial class FrmLoanIssue : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        int[] monthscount = new int[100];
        string repaymentmonths = null;
        string repaymentdate = null;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmLoanIssue()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID],RTRIM(RefereeRelationship)[Issue Type] from Loan where FinalApproval='Approved' and FirstApproval='Approved' and Issued='Pending' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Loan");
                dataGridView1.DataSource = myDataSet.Tables["Loan"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* try
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
                    //cmbModeOfPayment.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string compulsoryinsurance = Properties.Settings.Default.compulsoryinsurance;
                if (compulsoryinsurance == "Yes")
                {
                    DataGridViewRow dr = dataGridView1.CurrentRow;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT LoanID FROM LoanInsuranceFees WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        AccountNumber.Text = dr.Cells[0].Value.ToString();
                        AccountName.Text = dr.Cells[1].Value.ToString();
                        LoanID.Text = dr.Cells[2].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Client has not yet paid Insurance Fees for this Loan Application, Please Clear to continue", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT LoanAmount,Interest,RepaymentInterval,ServicingPeriod,IssueType,CollateralValue,RefereeRelationship,RefereeName,Intervals FROM Loan WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "' and Issued='Pending'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label15.Text = "";
                    AccountNumber.Text = dr.Cells[0].Value.ToString();
                    AccountName.Text = dr.Cells[1].Value.ToString();
                    LoanID.Text = dr.Cells[2].Value.ToString();
                    AmortisationMethod.Text = rdr["IssueType"].ToString();
                    Amount.Text = rdr["LoanAmount"].ToString();
                    ScheduleInterval.Text = rdr["RepaymentInterval"].ToString();
                    Interest.Text = rdr["Interest"].ToString();
                    ServicingPeriod.Text = rdr["ServicingPeriod"].ToString();
                    label16.Text= rdr["RefereeName"].ToString();
                    label15.Text = rdr["RefereeRelationship"].ToString().Trim();
                    PaymentInterval.Value = Convert.ToInt32(rdr["Intervals"].ToString());
                    if (label15.Text=="Topup" ||label15.Text == "Reschedule")
                    {
                        IssuableAmount.Text = (Convert.ToInt32(rdr["LoanAmount"])- Convert.ToInt32(rdr["CollateralValue"])).ToString();
                    }
                    else
                    {
                        IssuableAmount.Text = rdr["LoanAmount"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Loan Already Issued","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanIssue frm = new FrmLoanIssue();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        private void ApprovalID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(ApprovalID.Text, "essentialfinance");
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoanIssue='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        ApprovalName.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        ApprovalName.Text = "";
                    }
                }
                else
                {
                    ApprovalName.Text = "";
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

        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        string savingsids = null;
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SL-" + days + realid;
        }
        private void auto3()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 2;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SL-" + days + realid;
        }
        private void auto4()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SL-" + days + realid;
        }
        Double begginingbalance = 0.00;
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
                    int accountbal = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNumber.Text + "' and Approval='Approved' order by ID DESC";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountbal = Convert.ToInt32(rdr["Accountbalance"]);

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        //return;
                    }
                    else
                    {
                        accountbal = 0;

                    }
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM Account where AccountNumber='" + AccountNumber.Text + "'";
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
                    int finalbal = accountbal + IssuableAmount.Value;
                    string usernamess = Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                    numbers = "+256" + numberphone;
                    //messages = "A Deposit of " + IssuableAmount.Text + " Has been made to your account No. " + AccountNumber.Text + ", Accout Name " + AccountName.Text + "  and your account balance is " + finalbal;
                    messages = smsheader + ": Your Account has been Credit UGX. " + IssuableAmount.Text + " Reason:Loan Issue. For Any Inquiries Call: " + inquiryphone;

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
        public void sendmessage2()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select TELNo from Guarantor where LoanID='" + LoanID.Text + "' order by ID ASC", con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {

                string numbers = rdr["TELNo"].ToString(); 
                try
                {
                    using (var client2 = new WebClient())
                    using (client2.OpenRead("http://client3.google.com/generate_204"))
                    {
                        string smsheader = Properties.Settings.Default.Smscode;
                        string inquiryphone = Properties.Settings.Default.phoneinquiry;
                        string usernamess = Properties.Settings.Default.smsusername;
                        string passwordss = Properties.Settings.Default.smspassword;
                        numbers = "+256" + numbers;
                        messages = "We here by Inform you that client "+ AccountName.Text+ " has been issued a loan facility of UGX."+IssuableAmount.Text+" with "+ ScheduleInterval.Text+ " repayment schedule. For Any Inquiries Call: " + inquiryphone;
                       
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
            con.Close();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (AccountNumber.Text == "")
            {
                MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountNumber.Focus();
                return;
            }
            if (AccountName.Text == "")
            {
                MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountName.Focus();
                return;
            }
            if (ApprovalName.Text == "")
            {
                MessageBox.Show("Please Enter Correct Approval ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ApprovalID.Focus();
                return;
            }
            if (PaymentInterval.Text == "")
            {
                MessageBox.Show("Please Enter Payment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentInterval.Focus();
                return;
            }
            try
            {
                int dividedperiod = (Convert.ToInt32(ServicingPeriod.Text) % PaymentInterval.Value);
                if (dividedperiod == 0)
                { }
                else
                {
                    string realinterval = null;
                    if (ScheduleInterval.Text.Trim() == "Monthly")
                    {
                        realinterval = "Months";
                    }
                    else if (ScheduleInterval.Text.Trim() == "Daily")
                    {
                        realinterval = "Days";
                    }
                    else if (ScheduleInterval.Text.Trim() == "Weekly")
                    {
                        realinterval = "Weeks";
                    }
                    MessageBox.Show("Repayments Can not be Subdivided in Intervals of " + PaymentInterval.Value + " " + realinterval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PaymentInterval.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (label15.Text.ToString().Trim() == "Topup")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update RepaymentSchedule set PaymentStatus=@d1,ActualPaymentDate='"+ ApplicationDate.Text+ "',BalanceExist=0,UploadStatus='Pending' where LoanID=@d2 and BalanceExist > 0 and PaymentStatus !='Rescheduled'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@d1"].Value = "ToppedUp";
                    cmd.Parameters["@d2"].Value = label16.Text.Trim();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            int loaninstallmentcount = 0;
            try
            {
                if (label15.Text.ToString().Trim() == "Reschedule")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update RepaymentSchedule set PaymentStatus=@d1,ActualPaymentDate='" + ApplicationDate.Text + "',BalanceExist=0,UploadStatus='Pending' where LoanID=@d2 and BalanceExist > 0 and PaymentStatus !='ToppedUp'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@d1"].Value = "Rescheduled";
                    cmd.Parameters["@d2"].Value = label16.Text.Trim();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select COUNT(TotalAmmount) from RepaymentSchedule where  LoanID='" + LoanID.Text + "'", con);
                    loaninstallmentcount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int accountbal = 0;
            int newaccountbal = 0;
            if (label15.Text == "Reschedule")
            {
            }
            else
            {
                string loanids = AccountNumber.Text.Trim();
                string trimed = loanids.Substring(0, 2);
                if (trimed == "10")
                {
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNumber.Text + "' and Approval='Approved' order by ID DESC";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            accountbal = Convert.ToInt32(rdr["Accountbalance"]);

                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            //return;
                        }
                        else
                        {
                            accountbal = 0;

                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    newaccountbal = accountbal + IssuableAmount.Value;
                    auto2();
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string kt = "select SavingsID from Savings where SavingsID='" + savingsids + "' order by ID Desc";
                        cmd = new SqlCommand(kt);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            auto3();
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt3 = "select SavingsID from Savings where SavingsID='" + savingsids + "' order by ID Desc";
                            cmd = new SqlCommand(kt3);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                auto4();
                            }
                            con.Close();

                        }
                        else
                        {
                            auto2();
                        }
                        con.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,DepositDate,Credit,Approval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Approved')";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Transactions"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                    cmd.Parameters["@d1"].Value = AccountNumber.Text;
                    cmd.Parameters["@d2"].Value = savingsids;
                    cmd.Parameters["@d3"].Value = ApprovalName.Text;
                    cmd.Parameters["@d4"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d5"].Value = IssuableAmount.Value;
                    cmd.Parameters["@d6"].Value = newaccountbal;
                    cmd.Parameters["@d7"].Value = "Received Loan";
                    cmd.Parameters["@d8"].Value = "Transfer";
                    cmd.Parameters["@d9"].Value = AccountName.Text;
                    cmd.Parameters["@d10"].Value = ApprovalName.Text;
                    cmd.Parameters["@d11"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d12"].Value = IssuableAmount.Value;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            string loanidss = AccountNumber.Text.Trim();
            string trimeds = loanidss.Substring(0, 2);
            if (trimeds == "10")
            {
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    sendmessage();
                }
            }
            /*SqlDataReader rdr2 = null;
            int totalaamount = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + cmbModeOfPayment.Text + "' ";
            cmd = new SqlCommand(ct2);
            cmd.Connection = con;
            rdr2= cmd.ExecuteReader();
            if (rdr2.Read())
            {
                totalaamount = Convert.ToInt32(rdr2["AmountAvailable"]);
                int newtotalammount = totalaamount - Convert.ToInt32(IssuableAmount.Value);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + ApplicationDate.Text + "' where AccountNumber='" + cmbModeOfPayment.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }*/
            try
            {
                int dividedperiod = (Convert.ToInt32(ServicingPeriod.Text) % PaymentInterval.Value);
                if (dividedperiod == 0)
                { }
                else {
                    string realinterval = null;
                    if (ScheduleInterval.Text.Trim() == "Monthly")
                    {
                        realinterval = "Months";
                    }
                    else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            realinterval = "Days";
                        }
                    else if (ScheduleInterval.Text.Trim() == "Weekly")
                    {
                        realinterval = "Weeks";
                    }
                    MessageBox.Show("Repayments Can not be Subdivided in Intervals of " + PaymentInterval.Value+" "+ realinterval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PaymentInterval.Focus();
                    return;
                }
                if (AmortisationMethod.Text.Trim() == "Flat Rate")
                {
                    double principal = 0.00;
                    double interest = 0.00;
                    double repaymentammount = 0;
                    int K = 1;
                    int i = 1;
                    double accountexcess = 0.00;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null; int noappreciated = 0; 
                    int days = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text)/PaymentInterval.Value); i++)
                    {
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment "+ monthscount[i];
                            repaymentdate1 = (startdate.AddMonths(i*PaymentInterval.Value)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            DateTime repaymentdate4= DateTime.Parse((dt.AddMonths(1)).ToShortDateString());
                            noappreciated = Convert.ToInt32(repaymentdate4.Subtract(dt).TotalDays) - days;
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(i * (PaymentInterval.Value))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            noappreciated = 1;
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)) * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            DateTime repaymentdate4 = DateTime.Parse((dt.AddDays(7)).ToShortDateString());
                            noappreciated = Convert.ToInt32(repaymentdate4.Subtract(dt).TotalDays) - days;
                        }
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        principal = val1;
                        double repaymentammounts = 0.00;
                        interest = Convert.ToDouble(PaymentInterval.Value)*((Convert.ToDouble(Interest.Text) / (100)) * val1);
                        //int result = Convert.ToInt32(interests % 1000 > 500 ? interest + 1000 - interest % 1000 : interest - interest % 1000);
                        if (i == (Convert.ToInt32(ServicingPeriod.Text)/ PaymentInterval.Value))
                        {
                            repaymentammounts = val1 + interest;
                            begginingbalance = 0;
                            int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                            if (result > 500)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else if (result < 500 && result >0)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else
                            {
                                repaymentammount = repaymentammounts;
                            }
                           
                        }
                        else
                        {
                            repaymentammounts = interest;
                            begginingbalance = val1;
                            int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                            if (result > 500)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else if (result < 500 && result > 0)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else
                            {
                                repaymentammount = repaymentammounts;
                            }
                        }
                        accountexcess = repaymentammount - repaymentammounts;

                          con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName,IntrestType,Rates,IssuedAmmount,LoanType,ActualPaymentDate,AccountExcess,NoAccrued) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Float, 20, "Rates"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 20, "IssuedAmmount,"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "LoanType"));
                        cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "ActualPaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Float, 20, "AccountExcess"));
                        cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 10, "NoAccrued"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNumber.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.Parameters["@d11"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d12"].Value = Interest.Text;
                        cmd.Parameters["@d13"].Value = Amount.Value;
                        cmd.Parameters["@d14"].Value = ScheduleInterval.Text;
                        cmd.Parameters["@d15"].Value = repaymentdate;
                        cmd.Parameters["@d16"].Value = accountexcess;
                        cmd.Parameters["@d17"].Value = noappreciated;
                        cmd.ExecuteNonQuery();
                        con.Close();
                       
                    }
                }
                else if (AmortisationMethod.Text.Trim() == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    int ids = 0;
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    int days = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                    int noappreciated = 0;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value); i++)
                    {
                        double principal = 0.00;
                        double interest = 0.00;
                        double repaymentammount = 0;
                        double accountexcess = 0.00;
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddMonths((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            DateTime repaymentdate4 = DateTime.Parse((dt.AddMonths(1)).ToShortDateString());
                            noappreciated = Convert.ToInt32(repaymentdate4.Subtract(dt).TotalDays) - days;
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            noappreciated = 1;
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(((i * (PaymentInterval.Value)) * 7))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                            DateTime repaymentdate4 = DateTime.Parse((dt.AddDays(7)).ToShortDateString());
                            noappreciated = Convert.ToInt32(repaymentdate4.Subtract(dt).TotalDays) - days;
                        }
                        double repaymentammounts = 0.00;
                        if (repaymentmonths == "Installment 1")
                        {
                            //interest = val1 * (Convert.ToDouble(Interest.Text) / 100);
                            //principal = emi - interest;
                            //repaymentammount = emi;
                            //begginingbalance = val1 - principal;
                          
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TOP ("+PaymentInterval.Value+") AmmountPay,Interest,TotalAmmount,BeginningBalance,ID from AmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID ASC" , con);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read()==true)
                            {
                                repaymentammounts = 0;
                                interest += Convert.ToDouble(rdr[1]);
                                principal += Convert.ToDouble(rdr[0]);
                                repaymentammounts += Convert.ToDouble(rdr[2]);
                                begginingbalance = Convert.ToDouble(rdr[3]);
                                ids = Convert.ToInt32(rdr[4]);
                                int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                                if (result > 500)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else if (result < 500 && result > 0)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else
                                {
                                    repaymentammount = repaymentammounts;
                                }
                                //con.Close();
                            }
                           
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TOP (" + PaymentInterval.Value + ") AmmountPay,Interest,TotalAmmount,BeginningBalance,ID from AmortisationSchedule where LoanID='" + LoanID.Text + "' and ID > "+ids+" order by ID ASC", con);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read() == true)
                            {
                                repaymentammounts = 0;
                                interest += Convert.ToDouble(rdr[1]);
                                principal += Convert.ToDouble(rdr[0]);
                                repaymentammounts += Convert.ToDouble(rdr[2]);
                                begginingbalance = Convert.ToDouble(rdr[3]);
                                ids = Convert.ToInt32(rdr[4]);

                                int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                                if (result > 500)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else if (result < 500 && result > 0)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else
                                {
                                    repaymentammount = repaymentammounts;
                                }
                                //con.Close();
                            }
                            con.Close();

                        }
                        accountexcess = repaymentammount - repaymentammounts;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName,IntrestType,Rates,IssuedAmmount,LoanType,ActualPaymentDate,AccountExcess,NoAccrued) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d4,@d15,@d16)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Float, 20, "Rates"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 20, "IssuedAmmount,"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "LoanType"));
                        cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Float, 20, "AccountExcess"));
                        cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Int, 10, "NoAccrued"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNumber.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.Parameters["@d11"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d12"].Value = Interest.Text;
                        cmd.Parameters["@d13"].Value = Amount.Value;
                        cmd.Parameters["@d14"].Value = ScheduleInterval.Text;
                        cmd.Parameters["@d15"].Value = accountexcess;
                        cmd.Parameters["@d16"].Value = noappreciated;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string clearancedate = null;
                if (ScheduleInterval.Text.Trim() == "Monthly")
                {
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    string repaymentdate11 = (startdate.AddMonths(Convert.ToInt32(ServicingPeriod.Text))).ToShortDateString();
                    DateTime dt = DateTime.Parse(repaymentdate11);
                    clearancedate = dt.ToString("dd/MMM/yyyy");
                }
                else if (ScheduleInterval.Text.Trim() == "Daily")
                {
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    string repaymentdate11 = (startdate.AddDays(Convert.ToInt32(ServicingPeriod.Text))).ToShortDateString();
                    DateTime dt = DateTime.Parse(repaymentdate11);
                    clearancedate = dt.ToString("dd/MMM/yyyy");
                }
                else if (ScheduleInterval.Text.Trim() == "Weekly")
                {
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    string repaymentdate11 = (startdate.AddDays(Convert.ToInt32(ServicingPeriod.Text)*7)).ToShortDateString();
                    DateTime dt = DateTime.Parse(repaymentdate11);
                    clearancedate = dt.ToString("dd/MMM/yyyy");

                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Loan SET Issued=@d2, MaturityDate='"+ clearancedate + "',UploadStatus='Pending' WHERE LoanID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Issued"));
                cmd.Parameters["@d1"].Value = LoanID.Text;
                cmd.Parameters["@d2"].Value = "Yes";
                cmd.ExecuteNonQuery();
                con.Close();

                if (label15.Text == "Reschedule" || label15.Text == "Topup")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDATE Loan SET IssueNo=@d2,Clearance='Cleared',UploadStatus='Pending' WHERE LoanID=@d1";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "IssueNo"));
                    cmd.Parameters["@d1"].Value = label16.Text;
                    cmd.Parameters["@d2"].Value = label15.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                try
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete  from  AmortisationSchedule where LoanID=@DELETE1 ";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                    RowsAffected = cmd.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string smsallows = Properties.Settings.Default.smsallow;
                if (smsallows == "Yes")
                {
                    sendmessage();
                }
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                company();
                company2();
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
                    MyCommand.CommandText = "select  * from RepaymentSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "RepaymentSchedule");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("accountnumber", accountnumber);
                    rpt.SetParameterValue("accountnumber1", accountnumber1);
                    rpt.SetParameterValue("bank1", bank1);
                    rpt.SetParameterValue("bank2", bank2);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm3.crystalReportViewer1.ReportSource = rpt;
                    myConnection.Close();
                    frm3.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Hide();
                FrmLoanIssue frm = new FrmLoanIssue();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        string accountnumber = "N/A"; string accountnumber1 = "N/A"; string bank1 = "N/A"; string bank2 = "N/A";

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

        public void company2()
        {
            try
            {
                SqlConnection CN1 = new SqlConnection(cs.DBConn);
                CN1.Open();
                string SelectCommand1 = "SELECT AccountNumber,BankNo,AccountNames FROM BankAccounts order by ID ASC";
                cmd = new SqlCommand(SelectCommand1);
                cmd.Connection = CN1;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["BankNo"].ToString().Trim() == "Bank 1")
                    {
                        accountnumber = rdr["AccountNumber"].ToString().Trim();
                        bank1 = rdr["AccountNames"].ToString().Trim();
                    }

                    if (rdr["BankNo"].ToString().Trim() == "Bank 2")
                    {
                        accountnumber1 = rdr["AccountNumber"].ToString().Trim();
                        bank2 = rdr["AccountNames"].ToString().Trim();
                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
            if (AccountNumber.Text == "")
            {
                MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountNumber.Focus();
                return;
            }
            if (AccountName.Text == "")
            {
                MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountName.Focus();
                return;
            }
            FrmLoanAmortisationReport frm = new FrmLoanAmortisationReport();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }
    }
}
