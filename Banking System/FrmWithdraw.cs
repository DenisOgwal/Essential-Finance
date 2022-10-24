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
    public partial class FrmWithdraw : DevComponents.DotNetBar.Office2007Form
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
        public FrmWithdraw()
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
            cmd = new SqlCommand("select ID from Savings  Order By ID DESC",con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from Savings ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsid.Text = "W-"  + days +realid;
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {
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
            FrmWithdraw frm = new FrmWithdraw();
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

                        string usernamess = Properties.Settings.Default.smsusername;
                        string passwordss = Properties.Settings.Default.smspassword;
                        numbers = "+256" + numberphone;
                        messages = " A Withdraw of " + depositammount.Text + " Has been made on your account No. " + accountnumber.Text + ", Accout Name"+accountname.Text+"  and your account balance is " + accountbalance.Text;

                        WebClient client = new WebClient();
                        string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username="+usernamess +"&password="+passwordss+"&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
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
            auto2();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SavingsTransactions(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
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
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "Debit"));
                cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d3"].Value = accountname.Text;
                cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d5"].Value = date2.Text.Trim();
                cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                cmd.Parameters["@d7"].Value = accountbalance.Value;
                cmd.Parameters["@d8"].Value = submittedby.Text;
                cmd.Parameters["@d9"].Value = "Withdraw";
                cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                cmd.Parameters["@d12"].Value = "DR";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Savings Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX5.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            FrmWithdraw frm2 = new FrmWithdraw();
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
                    string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        string Accbalance = rdr2["Accountbalance"].ToString();
                        val4 = Convert.ToInt32(Accbalance);
                        int.TryParse(depositammount.Value.ToString(), out val5);
                        accountbalance.Value = (val4 - val5);
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

        private void accountnumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(AccountNames) FROM Account where AccountNumber='" + accountnumber.Text + "' and Freezed='No'";
                rdr = cmd.ExecuteReader();
                accountname.Text = "";
                if (rdr.Read())
                {
                    accountname.Text = rdr.GetString(0).Trim();
                }
                else
                {
                    MessageBox.Show("You Can not withdraw from this Account, It has been Frozen", "Frozen Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
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
    }
}
