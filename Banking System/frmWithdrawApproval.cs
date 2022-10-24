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
    public partial class frmWithdrawApproval : DevComponents.DotNetBar.Office2007Form
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
        public frmWithdrawApproval()
        {
            InitializeComponent();
        }
        
        private void frmSavings_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(SavingsID)[With ID],RTRIM(ModeOfPayment)[Mode Of Payment] from SavingsTransactions where Approval='Not Approved' and Debit='DR' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SavingsTransactions");
                dataGridView1.DataSource = myDataSet.Tables["SavingsTransactions"].DefaultView;
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
            frmWithdrawApproval frm = new frmWithdrawApproval();
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
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM Account where AccountNumber='" + accountnumber.Text + "'";
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
                    messages = smsheader+": Your Account has been Debited UGX. " + depositammount.Text + " Reason:Cash withdraw. For Any Inquiries Call: "+ inquiryphone;

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
        string withdrawids = null;
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            withdrawids = "WID-" + years + monthss + days + GetUniqueKey(5);
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
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
                return;
            }
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approvals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }
           
            try
            {
                if (approvals.Text == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
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
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value +withdrawcharge.Value;
                    cmd.Parameters["@d8"].Value = submittedby.Text;
                    cmd.Parameters["@d9"].Value = "Withdraw";
                    cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d13"].Value = approvals.Text;
                    cmd.Parameters["@d14"].Value = cashiername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX5.Enabled = false;
                    con.Close();
                    if (withdrawcharge.Value > 0)
                    {
                        auto();

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb6 = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                        cmd = new SqlCommand(cb6);
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
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                        cmd.Parameters["@d1"].Value = withdrawids;
                        cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                        cmd.Parameters["@d3"].Value = accountname.Text;
                        cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                        cmd.Parameters["@d5"].Value = date2.Text.Trim();
                        cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value);
                        cmd.Parameters["@d7"].Value = accountbalance.Value;
                        cmd.Parameters["@d8"].Value = submittedby.Text;
                        if (label4.Text == "Transfer")
                        {
                            cmd.Parameters["@d9"].Value = "Account Transfer Charge";
                        }
                        else
                        {
                            cmd.Parameters["@d9"].Value = "Withdraw Charge";
                        }
                        cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                        cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                        cmd.Parameters["@d12"].Value = Convert.ToInt32(withdrawcharge.Value);
                        cmd.Parameters["@d13"].Value = approvals.Text;
                        cmd.Parameters["@d14"].Value = cashiername.Text;
                        cmd.ExecuteNonQuery();
                        buttonX5.Enabled = false;
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
                if (label4.Text == "Transfer")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "insert into TransferCharges (PaymentID,Account,Year,Months,Date,TransferFee) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferFee"));
                    cmd.Parameters["@d1"].Value = savingsid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = DateTime.Today.Year;
                    cmd.Parameters["@d4"].Value = DateTime.Today.Month;
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value.ToString());
                    cmd.ExecuteReader();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string savetrim = savingsid.Text.Trim();
                    int stringlenth = savetrim.Length;
                    string trimedsaveid = savetrim.Substring(1, stringlenth - 1);
                    string newids = "S" + trimedsaveid;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb8 = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb8);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = newids;
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    auto();
                    string accountnumber1 = null;
                    string accountnames1 = null;
                    int accountbalancess =0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT AccountNo,AccountName from SavingsTransactions WHERE SavingsID = '" +newids+ "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountnumber1 = (rdr.GetString(0).Trim());
                        accountnames1 = (rdr.GetString(1).Trim());
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT Accountbalance from Savings WHERE SavingsID = '" + newids + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountbalancess = Convert.ToInt32(rdr.GetString(0));
                    }
                    else { accountbalancess = 0; }
                    int newaccountbalancess = accountbalancess + depositammount.Value;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb6 = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Credit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                    cmd = new SqlCommand(cb6);
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
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Credit"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = newids;
                    cmd.Parameters["@d2"].Value = accountnumber1.Trim();
                    cmd.Parameters["@d3"].Value = accountnames1.Trim();
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = newaccountbalancess;
                    cmd.Parameters["@d8"].Value = submittedby.Text;
                    if (label4.Text == "Transfer")
                    {
                        cmd.Parameters["@d9"].Value = "Account Transfer Deposit";
                    }
                    cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d13"].Value = approvals.Text;
                    cmd.Parameters["@d14"].Value = cashiername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX5.Enabled = false;
                    con.Close();

                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "insert into WithdrawCharges (PaymentID,Account,Year,Months,Date,withdrawFee) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "withdrawFee"));
                    cmd.Parameters["@d1"].Value = savingsid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = DateTime.Today.Year;
                    cmd.Parameters["@d4"].Value = DateTime.Today.Month;
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value.ToString());
                    cmd.ExecuteReader();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlDataReader rdr = null;
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
                        int newtotalammount = totalaamount - Convert.ToInt32(depositammount.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                }
                MessageBox.Show("Successfully saved", "Withdraw Approval Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    sendmessage();
                }
                buttonX5.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmWithdrawApproval frm2 = new frmWithdrawApproval();
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
                cmd.CommandText = "SELECT distinct RTRIM(AccountNames) FROM Account where AccountNumber='" + accountnumber.Text + "'";
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and AccountantRights='Yes'";
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
                    con.Close();
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
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
                return;
            }
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approvals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }
            try
            {
                if (approvals.Text == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
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
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value + withdrawcharge.Value;
                    cmd.Parameters["@d8"].Value = submittedby.Text;
                    cmd.Parameters["@d9"].Value = "Withdraw";
                    cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d13"].Value = approvals.Text;
                    cmd.Parameters["@d14"].Value = cashiername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX5.Enabled = false;
                    con.Close();
                    if (withdrawcharge.Value > 0)
                    {
                        auto();

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb6 = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                        cmd = new SqlCommand(cb6);
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
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                        cmd.Parameters["@d1"].Value = withdrawids;
                        cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                        cmd.Parameters["@d3"].Value = accountname.Text;
                        cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                        cmd.Parameters["@d5"].Value = date2.Text.Trim();
                        cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value);
                        cmd.Parameters["@d7"].Value = accountbalance.Value;
                        cmd.Parameters["@d8"].Value = submittedby.Text;
                        if (label4.Text == "Transfer")
                        {
                            cmd.Parameters["@d9"].Value = "Account Transfer Charge";
                        }
                        else
                        {
                            cmd.Parameters["@d9"].Value = "Withdraw Charge";
                        }
                        cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                        cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                        cmd.Parameters["@d12"].Value = Convert.ToInt32(withdrawcharge.Value);
                        cmd.Parameters["@d13"].Value = approvals.Text;
                        cmd.Parameters["@d14"].Value = cashiername.Text;
                        cmd.ExecuteNonQuery();
                        buttonX5.Enabled = false;
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
                if (label4.Text == "Transfer")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "insert into TransferCharges (PaymentID,Account,Year,Months,Date,TransferFee) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferFee"));
                    cmd.Parameters["@d1"].Value = savingsid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = DateTime.Today.Year;
                    cmd.Parameters["@d4"].Value = DateTime.Today.Month;
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value.ToString());
                    cmd.ExecuteReader();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string savetrim = savingsid.Text.Trim();
                    int stringlenth = savetrim.Length;
                    string trimedsaveid = savetrim.Substring(1, stringlenth - 1);
                    string newids = "S" + trimedsaveid;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb8 = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb8);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = newids;
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    auto();
                    string accountnumber1 = null;
                    string accountnames1 = null;
                    int accountbalancess = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT AccountNo,AccountName from SavingsTransactions WHERE SavingsID = '" + newids + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountnumber1 = (rdr.GetString(0).Trim());
                        accountnames1 = (rdr.GetString(1).Trim());
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT Accountbalance from Savings WHERE SavingsID = '" + newids + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountbalancess = Convert.ToInt32(rdr.GetString(0));
                    }
                    else { accountbalancess = 0; }
                    int newaccountbalancess = accountbalancess + depositammount.Value;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb6 = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Credit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                    cmd = new SqlCommand(cb6);
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
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Credit"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = newids;
                    cmd.Parameters["@d2"].Value = accountnumber1.Trim();
                    cmd.Parameters["@d3"].Value = accountnames1.Trim();
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d7"].Value = newaccountbalancess;
                    cmd.Parameters["@d8"].Value = submittedby.Text;
                    if (label4.Text == "Transfer")
                    {
                        cmd.Parameters["@d9"].Value = "Account Transfer Deposit";
                    }
                    cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(depositammount.Value);
                    cmd.Parameters["@d13"].Value = approvals.Text;
                    cmd.Parameters["@d14"].Value = cashiername.Text;
                    cmd.ExecuteNonQuery();
                    buttonX5.Enabled = false;
                    con.Close();

                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "insert into WithdrawCharges (PaymentID,Account,Year,Months,Date,withdrawFee) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "withdrawFee"));
                    cmd.Parameters["@d1"].Value = savingsid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = DateTime.Today.Year;
                    cmd.Parameters["@d4"].Value = DateTime.Today.Month;
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(withdrawcharge.Value.ToString());
                    cmd.ExecuteReader();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE SavingsTransactions SET Approval=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Approval"));

                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = approvals.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlDataReader rdr = null;
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
                        int newtotalammount = totalaamount - Convert.ToInt32(depositammount.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                }
                MessageBox.Show("Successfully saved", "Withdraw Approval Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    sendmessage();
                }
                buttonX5.Enabled = false;
                buttonX2.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            company();
            try
            {
                //this.Hide();
                Cursor = Cursors.WaitCursor;
                //timer1.Enabled = true;
                rptReceiptWithdraws rpt = new rptReceiptWithdraws(); //The report you created.
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
            this.Hide();
            frmWithdrawApproval frm2 = new frmWithdrawApproval();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
        string printoptionss = Properties.Settings.Default.PrintOptions;
        private void accountnumber2_Click(object sender, EventArgs e)
        {
            frmClientDetails frm = new frmClientDetails();
            frm.ShowDialog();
            this.accountnumber.Text = frm.clientnames.Text;
            this.accountname.Text = frm.Accountnames.Text;
            return;
        }

        private void membername2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                label4.Text = dr.Cells[3].Value.ToString();
                accountnumber.Text = dr.Cells[0].Value.ToString();
                accountname.Text = dr.Cells[1].Value.ToString();
                savingsid.Text = dr.Cells[2].Value.ToString();
                label4.Text= dr.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void savingsid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (savingsid.Text == "") { }
                else
                {
                    SqlDataReader rdr = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select * from SavingsTransactions where  SavingsID= '" + savingsid.Text + "'";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        submittedby.Text = rdr["SubmittedBy"].ToString();
                        dateTimePicker1.Text = rdr["DepositDate"].ToString();
                        cmbModeOfPayment.Text = rdr["ModeOfPayment"].ToString();
                        depositammount.Text = rdr["Deposit"].ToString();
                        cashier.Text = rdr["CashierName"].ToString();
                        //accountbalance.Text = rdr["Accountbalance"].ToString();

                        /*if ((rdr2 != null))
                        {
                            rdr2.Close();
                        }*/
                    }
                    else
                    {
                        MessageBox.Show("Wrong Transaction","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
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
                if (depositammount.Text == "" || depositammount.Text == null)
                {

                }
                else
                {
                    if (label4.Text.Trim() == "Transfer")
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct4 = "select TransferFee from TransferFees where TransferFeeMin <= '" + depositammount.Value + "' and TransferFeemax >= '" + depositammount.Value + "' order by ID Desc";
                        cmd = new SqlCommand(ct4);
                        cmd.Connection = con;
                        rdr2 = cmd.ExecuteReader();
                        if (rdr2.Read())
                        {
                            withdrawcharge.Text = rdr2["TransferFee"].ToString();
                            if ((rdr2 != null))
                            {
                                rdr2.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Transfer Charges not Set, contact chairman to set it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Hide();
                            return;
                        }
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct4 = "select WithdrawFee from WithdrawFees where WithdrawFeeMin <= '" + depositammount.Value + "' and WithdrawFeemax >= '" + depositammount.Value + "' order by ID Desc";
                        cmd = new SqlCommand(ct4);
                        cmd.Connection = con;
                        rdr2 = cmd.ExecuteReader();
                        if (rdr2.Read())
                        {
                            withdrawcharge.Text = rdr2["WithdrawFee"].ToString();
                            if ((rdr2 != null))
                            {
                                rdr2.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Withdraw Charges not Set, contact chairman to set it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Hide();
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (depositammount.Text == "") { }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    int val4 = 0;
                    int val5 = 0;
                    int val7 = 0;
                    string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        string Accbalance = rdr["Accountbalance"].ToString();
                        val4 = Convert.ToInt32(Accbalance);
                        int.TryParse(depositammount.Value.ToString(), out val5);
                        int.TryParse(withdrawcharge.Value.ToString(), out val7);
                        accountbalance.Value = (val4 - (val5 + val7));
                       
                    }
                    else
                    {
                        MessageBox.Show("Withdraw not acceptable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        /*int val1 = 0;
                        int.TryParse(depositammount.Value.ToString(), out val1);
                        accountbalance.Value = val1;*/
                    }
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
