using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
namespace Banking_System
{
    public partial class frmExternalPaymentSchedule : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        int ammount = 0;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmExternalPaymentSchedule()
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
        private void auto()
        {

            repaymentid.Text = "ERID-" + GetUniqueKey(5);
        }
        private void loanids()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(LoansID) FROM ExternalLoans where Recieved='Recieved'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                loanid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    loanid.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dataload1()
        {
            try
            {
                DateTime schedule = DateTime.Parse(dateTimePicker1.Text).Date;
                string paymentdates = (schedule.AddDays(1)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Months)[Repayment Months], RTRIM(TotalAmmount)[Ammount Payable],RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest],RTRIM(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status]from ExternalRePaymentSchedule where PaymentStatus='Pending' and PaymentDate = @date1 order by ExternalRepaymentSchedule.ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPaymentSchedule_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            loanids();
            dataload1();
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
                    buttonX4.Enabled = true;
                    buttonX3.Enabled = true;
                }
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPaymentSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }
        private void Reset()
        {
            ammountpaid.Text = null;
            balance.Text = null;
            repaymentid.Text = "";
            cashierid.Text = "";
            cashiername.Text = "";
            repaymonths.Text = "";
            loanid.Text = "";
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalPaymentSchedule frm = new frmExternalPaymentSchedule();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }
        string paymentstatus = "Paid";
        int TotalInterest = 0;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            auto();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string kt = "select Interest from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' order by ID Desc";
                cmd = new SqlCommand(kt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    double totals6 = Convert.ToDouble(rdr[0]);
                    TotalInterest = Convert.ToInt32(totals6);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (repaymentid.Text == "")
            {
                MessageBox.Show("Please Enter Repayment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repaymentid.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select LoanID,RepayMonths from ExternalLoanrepayment where  LoanID=@find and RepayMonths='" + repaymonths.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, " LoanID"));
                cmd.Parameters["@find"].Value = loanid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Loans ID. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loanid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                SqlDataReader rdr2 = null;
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                    totalaamount = Convert.ToInt32(rdr2["AmountAvailable"]);
                    int newtotalammount = totalaamount - Convert.ToInt32(ammountpaid.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNumber='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ExternalLoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,PaidBy,LoanID,Repaymentdate,Year,Months,Interest) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "PaidBy"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "Interest"));

                cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Text);
                cmd.Parameters["@d4"].Value = repaymonths.Text.Trim();
                cmd.Parameters["@d5"].Value = cashierid.Text.Trim();
                cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                cmd.Parameters["@d7"].Value = dateTimePicker1.Text;
                cmd.Parameters["@d8"].Value = year.Text.Trim();
                cmd.Parameters["@d9"].Value = months.Text;
                cmd.Parameters["@d10"].Value = TotalInterest;
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
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Text);
                cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                cmd.Parameters["@d5"].Value = repaymonths.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                buttonX2.Enabled = true;
                dataload2();
                dataload1();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void dataload()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Months)[Repayment Months], RTRIM(TotalAmmount)[Ammount Payable],RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest],RTRIM(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from ExternalRePaymentSchedule where PaymentDate between @date1 and @date2 order by ExternalRepaymentSchedule.ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            dataload();
        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {
            dataload();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
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
                string ct = "select RepaymentID from ExternalLoanRepayment where RepaymentID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters["@find"].Value = repaymentid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete * from  ExternalLoanRepayment where RepaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters["@DELETE1"].Value = repaymentid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
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
                balance.Text = null;
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AmmountPaid from ExternalLoanRepayment where  LoanID= '" + loanid.Text + "' and RepayMonths='" + repaymonths.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    double ammounts = Convert.ToDouble(rdr["AmmountPaid"]);
                    val4 = Convert.ToInt32(ammount);
                    int.TryParse(ammountpaid.Value.ToString(), out val5);
                    int I = (val6 - (val4 + val5));
                    balance.Text = I.ToString();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    int val1 = 0;
                    int val2 = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ft = "select TotalAmmount from ExternalRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' order by ID Desc";
                    cmd = new SqlCommand(ft);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double totals1 = Convert.ToDouble(rdr[0]);
                        val1 = Convert.ToInt32(totals1);
                        con.Close();
                        int.TryParse(ammountpaid.Value.ToString(), out val2);
                        int I = (val1 - val2);
                        balance.Text = I.ToString();
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
                string cb = "update ExternalLoanRepayment set AmmountPaid=@d2,Balance=@d3,RepayMonths=@d4, PaidBy=@d5,Repaymentdate=@d9 where LoanID=@d6 and RepayMonths=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "PaidBy"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));

                cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Text);
                cmd.Parameters["@d4"].Value = repaymonths.Text.Trim();
                cmd.Parameters["@d5"].Value = cashierid.Text.Trim();
                cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                cmd.Parameters["@d9"].Value = DateTo.Text;
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
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Text);
                cmd.Parameters["@d4"].Value = DateTo.Text;
                cmd.Parameters["@d5"].Value = repaymonths.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalRepaymentRecord frm = new frmExternalRepaymentRecord();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
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
        public void dataload2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Months)[Repayment Months], RTRIM(TotalAmmount)[Ammount Payable],RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest],RTRIM(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status]from ExternalRePaymentSchedule where  LoanID='" + loanid.Text + "' order by ExternalRepaymentSchedule.ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loanid_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataload2();
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                company();
                float x = 10;
                float y = 5;

                float width = 260.0F; // max width I found through trial and error
                float height = 0F;

                Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
                Font drawFontArial10italic = new Font("Arial", 10, FontStyle.Italic);
                Font drawFontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
                Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Set format of string.
                StringFormat drawFormatCenter = new StringFormat();
                drawFormatCenter.Alignment = StringAlignment.Center;
                StringFormat drawFormatLeft = new StringFormat();
                drawFormatLeft.Alignment = StringAlignment.Near;
                StringFormat drawFormatRight = new StringFormat();
                drawFormatRight.Alignment = StringAlignment.Far;

                // Draw string to screen.
                string text = companyname;
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyslogan;
                e.Graphics.DrawString(text, drawFontArial10italic, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10italic).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyaddress;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyemail;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companycontact;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Payment ID: " + repaymentid.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Date: " + DateTime.Now.ToString();
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;



                text = "Paid For:  Loan Repayment";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "Loan ID: " + loanid.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "Repayment Months: " + repaymonths.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;



                text = "Total Paid: UGX." + string.Format("{0:n0}", Convert.ToInt32(ammountpaid.Value));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Due Payment: UGX." + string.Format("{0:n0}", Convert.ToInt32(balance.Text));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Recieved By: " + cashiername.Text;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "THANK YOU, COME AGAIN";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Powered by: www.ditherug.tech +256787045644";
                e.Graphics.DrawString(text, drawFontArial6Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial6Regular).Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
