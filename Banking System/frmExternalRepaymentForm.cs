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
    public partial class frmExternalRepaymentForm : DevComponents.DotNetBar.Office2007RibbonForm
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

        public frmExternalRepaymentForm()
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
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(Months)[Installment],RTRIM(BalanceExist)[Amount Payable] from ExternalRepaymentSchedule WHERE PaymentDate>=@date1 and BalanceExist>0 order by ID Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridView1.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
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
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM MemberRegistration where MemberID='" + Lender.Text + "'";
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
                    messages = ammountpaid.Text + " Has been paid for clearing " + repaymonths.Text + " of Loan " + loanid.Text + " and a balance of " + balance.Text + " is left for this installment";
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
            repaymentid.Text = "EPD-" + years + monthss + days + GetUniqueKey(5);
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
                    string kt = "select Interest,AmmountPay from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and Months='" + repaymonths.Text + "' order by ID Desc";
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
                    string cb = "insert into ExternalLoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,LoanID,PaidBy,Repaymentdate,Interest,TotalAmmount,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "PaidBy"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "Interest"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                    cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = repaymonths.Text.Trim();
                    cmd.Parameters["@d5"].Value = loanid.Text.Trim();
                    cmd.Parameters["@d6"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d7"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d8"].Value = label3.Text;
                    cmd.Parameters["@d9"].Value = label4.Text;
                    cmd.Parameters["@d10"].Value =cmbModeOfPayment.Text;
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
                    string cb = "update ExternalRepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and Months=@d5";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                    cmd.Parameters["@d1"].Value = paymentstatus;
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.Parameters["@d5"].Value = repaymonths.Text;
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
            frmExternalRepaymentForm frm2 = new frmExternalRepaymentForm();
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
            if (repaymonths.Text == "")
            {
                MessageBox.Show("Please enter Months Paid for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repaymonths.Focus();
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
                string cq = "delete  from  ExternalLoanRepayment where RepaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters["@DELETE1"].Value = repaymentid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset();
                   
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset();
                    
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                int val6 = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ht = "select TotalAmmount from ExternalRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' order by ID Desc";
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
                    string cb = "update ExternalRepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and Months=@d5";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                    cmd.Parameters["@d1"].Value = "Pending";
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = val6;
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.Parameters["@d5"].Value = repaymonths.Text;
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
            this.Hide();
            frmExternalRepaymentForm frm = new frmExternalRepaymentForm();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void ammountpaid_ValueChanged(object sender, EventArgs e)
        {
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            if (repaymonths.Text == "")
            {
                MessageBox.Show("Please enter Months Paid for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repaymonths.Focus();
                return;
            }
            try
            {
                int val4 = 0;
                int val5 = 0;
                int val6 = 0;
                int val7 = 0;
                balance.Text = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ht = "select TotalAmmount,Interest from ExternalRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' ";
                cmd = new SqlCommand(ht);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    double totals = Convert.ToDouble(rdr[0]);
                    double intrests = Convert.ToDouble(rdr[1]);
                    val6 = Convert.ToInt32(totals);
                    val7 = Convert.ToInt32(intrests);
                    con.Close();
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ID,AmmountPaid,TotalAmmount from ExternalLoanRepayment where  LoanID= '" + loanid.Text + "' and RepayMonths='" + repaymonths.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   
                        double ammounts = Convert.ToDouble(rdr["AmmountPaid"]);
                        val4 = Convert.ToInt32(ammounts);
                        int.TryParse(ammountpaid.Value.ToString(), out val5);
                        int I = (val6 - (val4 + val5));
                        balance.Value = I;
                        label3.Text = "0";
                        label4.Text = ammountpaid.Value.ToString();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                }
                else
                {
                    int val1 = 0;
                    int val2 = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ft = "select TotalAmmount,AmmountPay,Interest from ExternalRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "'";
                    cmd = new SqlCommand(ft);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double totals1 = Convert.ToDouble(rdr[0]);
                        double principalammount = Convert.ToDouble(rdr[1]);
                        double interestammount = Convert.ToDouble(rdr[2]);
                        val1 = Convert.ToInt32(totals1);
                        int.TryParse(ammountpaid.Value.ToString(), out val2);
                        int I = (val1 - val2);
                        balance.Value = I;
                        double actualprincipalpay = (val2 - interestammount);
                        label3.Text = (Convert.ToInt32(rdr[2])).ToString();
                        label4.Text = Convert.ToInt32(actualprincipalpay).ToString();
                        con.Close();
                    }
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
                string cb = "update ExternalLoanRepayment set AmmountPaid=@d2,Balance=@d3,RepayMonths=@d4, PaidBy=@d8,Repaymentdate=@d9 where LoanID=@d6 and RepayMonths=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));;
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "PaidBy"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));

                cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = repaymonths.Text.Trim();
                cmd.Parameters["@d6"].Value = loanid.Text.Trim();
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
                string cb = "update ExternalRepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and Months=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@d1"].Value = paymentstatus;
                cmd.Parameters["@d2"].Value = loanid.Text;
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = dateTimePicker1.Text;
                cmd.Parameters["@d5"].Value = repaymonths.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmExternalRepaymentForm frm = new frmExternalRepaymentForm();
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
            frmExternalRepaymentForm frm = new frmExternalRepaymentForm();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ManagingDirector='Yes'";
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

        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails6 frm = new frmClientDetails6();
            frm.ShowDialog();
            this.loanid.Text = frm.clientnames.Text;
            this.Lender.Text = frm.Accountnames.Text;
            return;
        }

        private void loanid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Lender from ExternalLoans where LoansID= '" + loanid.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                Lender.Text = "";
                if (rdr.Read())
                {
                    Lender.Text = rdr[0].ToString().Trim();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Months from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and BalanceExist>0 order by ID ASC ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                repaymonths.Items.Clear();
                while (rdr.Read()==true)
                {
                    repaymonths.Items.Add(rdr[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                loanid.Text = dr.Cells[0].Value.ToString();
                repaymonths.Text = dr.Cells[1].Value.ToString();
                balance.Text = dr.Cells[2].Value.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
