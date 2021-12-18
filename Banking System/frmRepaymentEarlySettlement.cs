using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;
using System.IO;
namespace Banking_System
{
    public partial class frmRepaymentEarlySettlement : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;

        public frmRepaymentEarlySettlement()
        {
            InitializeComponent();
        }

        private void frmRepaymentForm_Load(object sender, EventArgs e)
        {
           // loanids();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
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
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(Months)[Installment],RTRIM(BalanceExist)[Amount Payable] from RepaymentSchedule WHERE PaymentDate > @date1 and BalanceExist > 0 and PaymentStatus = 'Pending' order by ID Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridView1.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string numberphone = null;
        string messages = null;
        public void sendmessage()
        {

            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM Account where AccountNumber='" + memberid.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        numberphone = rdr.GetString(0).Trim();
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
                   
                    string numbers = "+256" + numberphone;
                    messages = ammountpaid.Text + " Has been paid for clearing All your of Loan " + loanid.Text + " and a balance of " + balance.Text + " is left for this installment";
                    WebClient client = new WebClient();
                    string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username="+usernamess+"&password="+passwordss+"&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                    client.OpenRead(baseURL);
                    MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Internet Connection, The message was not sent");
            }
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
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            repaymentid.Text = "RID-" + years + monthss + days + GetUniqueKey(5);
        }
        string paymentstatus = "Paid";
        int TotalInterest = 0;
        int totalaamount = 0;
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
        private void buttonX2_Click(object sender, EventArgs e)
        {

            if (membername.Text == "")
            {
                MessageBox.Show("Please enter Member Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                membername.Focus();
                return;
            }
            if (ammountpaid.Text == "")
            {
                MessageBox.Show("Please enter ammount paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ammountpaid.Focus();
                return;
            }
            if (balance.Text == "")
            {
                MessageBox.Show("Please enter balance ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                balance.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            auto();
            try
            {

                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select Interest,AmmountPay from RepaymentSchedule where LoanID='" + loanid.Text + "' and Months='All' order by ID Desc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double totals6 = Convert.ToDouble(rdr[0]);
                        double totals7 = Convert.ToDouble(rdr[1]);
                        int.TryParse(totals6.ToString(), out TotalInterest);
                        int.TryParse(totals7.ToString(), out totalaamount);
                        con.Close();
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into LoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,CashierID,LoanID,MemberID,CashierName,Repaymentdate,Interest,TotalAmmount,MemberName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d12,@d13,@d14)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "MemberID"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 20, "Interest"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "MemberName"));

                    cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                    cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = "All";
                    cmd.Parameters["@d5"].Value = cashierid.Text.Trim();
                    cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                    cmd.Parameters["@d7"].Value = memberid.Text.Trim();
                    cmd.Parameters["@d8"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d9"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = label3.Text;
                    cmd.Parameters["@d13"].Value = label4.Text;
                    cmd.Parameters["@d14"].Value = membername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX2.Enabled = false;
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
                    string cb = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters["@d1"].Value = paymentstatus;
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = null;
                    int totalaamount = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + cmbModeOfPayment.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                        int newtotalammount = totalaamount + Convert.ToInt32(ammountpaid.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNumber='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Successfully Saved", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     string smsallow = Properties.Settings.Default.smsallow;
                     if (smsallow == "Yes")
                     {
                         sendmessage();
                     }
                  
                    buttonX2.Enabled = true;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmRepaymentEarlySettlement frm2 = new frmRepaymentEarlySettlement();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            if (repaymentid.Text == "")
            {
                MessageBox.Show("Please enter repayment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repaymentid.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  LoanRepayment where RepaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters["@DELETE1"].Value = repaymentid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset();
                    this.Hide();
                    frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset();
                    this.Hide();
                    frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.ShowDialog();
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                int val6 = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ht = "select TotalAmmount from RepaymentSchedule where  LoanID= '" + loanid.Text + "' order by ID Desc";
                cmd = new SqlCommand(ht);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    double totals = Convert.ToDouble(rdr[0]);
                    val6 = Convert.ToInt32(totals);
                    con.Close();
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters["@d1"].Value = "Pending";
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = val6;
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated Payment Schedule", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonX2.Enabled = true;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ammountpaid_ValueChanged(object sender, EventArgs e)
        {
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            try
            {
                if (ammountpaid.Text == null || ammountpaid.Text == "")
                {

                }
                else
                {
                    balance.Value = (Convert.ToInt32(label4.Text) - Convert.ToInt32(ammountpaid.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update LoanRepayment set AmmountPaid=@d2,Balance=@d3,RepayMonths=@d4, CashierID=@d5, CashierName=@d8,Repaymentdate=@d9 where LoanID=@d6 and RepayMonths=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "CashierID"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));

                cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = "All";
                cmd.Parameters["@d5"].Value = cashierid.Text.Trim();
                cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                cmd.Parameters["@d7"].Value = memberid.Text.Trim();
                cmd.Parameters["@d8"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d9"].Value = dateTimePicker1.Text;
                cmd.ExecuteNonQuery();
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
                string cb = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                cmd.Parameters["@d1"].Value = paymentstatus;
                cmd.Parameters["@d2"].Value = loanid.Text;
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = dateTimePicker1.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
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
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and IncomesApproval='Yes'";
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

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (membername.Text == "")
            {
                MessageBox.Show("Please enter Member Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                membername.Focus();
                return;
            }
            if (ammountpaid.Text == "")
            {
                MessageBox.Show("Please enter ammount paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ammountpaid.Focus();
                return;
            }
            if (balance.Text == "")
            {
                MessageBox.Show("Please enter balance ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                balance.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }

            auto();
            try
            {

                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select Interest,AmmountPay from RepaymentSchedule where LoanID='" + loanid.Text + "' and Months='All' order by ID Desc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double totals6 = Convert.ToDouble(rdr[0]);
                        double totals7 = Convert.ToDouble(rdr[1]);
                        int.TryParse(totals6.ToString(), out TotalInterest);
                        int.TryParse(totals7.ToString(), out totalaamount);
                        con.Close();
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into LoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,CashierID,LoanID,MemberID,CashierName,Repaymentdate,Interest,TotalAmmount,MemberName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d12,@d13,@d14)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "MemberID"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 20, "Interest"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "MemberName"));

                    cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                    cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = "All";
                    cmd.Parameters["@d5"].Value = cashierid.Text.Trim();
                    cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                    cmd.Parameters["@d7"].Value = memberid.Text.Trim();
                    cmd.Parameters["@d8"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d9"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = label3.Text;
                    cmd.Parameters["@d13"].Value = label4.Text;
                    cmd.Parameters["@d14"].Value = membername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX2.Enabled = false;
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
                    string cb = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters["@d1"].Value = paymentstatus;
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = null;
                    int totalaamount = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + cmbModeOfPayment.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                        int newtotalammount = totalaamount + Convert.ToInt32(ammountpaid.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNumber='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Successfully Saved", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     string smsallow = Properties.Settings.Default.smsallow;
                     if (smsallow == "Yes")
                     {
                         sendmessage();
                     }
                    company();

                    try
                    {

                        //this.Hide();
                        Cursor = Cursors.WaitCursor;
                        //timer1.Enabled = true;
                        rptReceiptLoanRepayment rpt = new rptReceiptLoanRepayment(); //The report you created.
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();  //The DataSet you created.
                        Receipt frm = new Receipt();
                        myConnection = new SqlConnection(cs.DBConn);
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select * from Expenses";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "Expenses");
                        //myDA.Fill(myDS, "Rights");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("paymentid", repaymentid.Text);
                        rpt.SetParameterValue("membernames", membername.Text);
                        rpt.SetParameterValue("ammount", ammountpaid.Value);
                        rpt.SetParameterValue("months", "All");
                        rpt.SetParameterValue("loanid", loanid.Text);
                        rpt.SetParameterValue("loanbalance", balance.Value);
                        rpt.SetParameterValue("issuedby", cashiername.Text);
                        rpt.SetParameterValue("payableammount", label4.Text);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        frm.crystalReportViewer1.ReportSource = rpt;
                        frm.ShowDialog();
                        //BarPrinter = Properties.Settings.Default.frontendprinter;
                        //rpt.PrintOptions.PrinterName = BarPrinter;
                        //rpt.PrintToPrinter(1, true, 1, 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    buttonX2.Enabled = true;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmRepaymentEarlySettlement frm2 = new frmRepaymentEarlySettlement();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }

        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            this.loanid.Text = frm.LoanID.Text;
            this.memberid.Text = frm.clientnames.Text;
            this.membername.Text = frm.Accountnames.Text;
            return;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                memberid.Text = dr.Cells[1].Value.ToString();
                membername.Text = dr.Cells[2].Value.ToString();
                balance.Text = dr.Cells[4].Value.ToString();
                loanid.Text = dr.Cells[0].Value.ToString();
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int TotalPrincipal = 0;
        int totalbalanceexist = 0;
        private void loanid_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM RepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending'";
                TotalPrincipal = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Paid'";
                totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int TotalIntrests = 0;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP (1) Interest FROM RepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID ASC";
                TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                label3.Text = TotalIntrests.ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                ///MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            balance.Value = (TotalIntrests + TotalPrincipal + totalbalanceexist);
            label4.Text = balance.Value.ToString();
            label5.Text = balance.Value.ToString();
        }
        private void EarlySettlement_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double settlementpercentage = Convert.ToDouble(EarlySettlement.Value) / 100;
                double SettlementFee = settlementpercentage * Convert.ToDouble(label5.Text);
                balance.Value = Convert.ToInt32(SettlementFee)+ Convert.ToInt32(label5.Text);
                label4.Text = balance.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
