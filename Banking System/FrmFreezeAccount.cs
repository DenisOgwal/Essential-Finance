using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmFreezeAccount : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        ConnectionString cs = new ConnectionString();
        public FrmFreezeAccount()
        {
            InitializeComponent();
        }

        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        string saveid = null;
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            saveid = "S-" + days + realid;
        }
        private void auto3()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 2;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            saveid = "S-" + days + realid;
        }
        private void auto4()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            saveid = "S-" + days + realid;
        }
        private void FrmFreezeAccount_Load(object sender, EventArgs e)
        {

        }

        private void accountnumber_Click(object sender, EventArgs e)
        {
            frmClientDetails frm = new frmClientDetails();
            frm.ShowDialog();
            this.accountnumber.Text = frm.clientnames.Text;
            this.accountname.Text = frm.Accountnames.Text;
            return;
        }

        private void accountname_Click(object sender, EventArgs e)
        {
            try
            {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                    accountbalance.Text = rdr2["Accountbalance"].ToString();
                        if ((rdr2 != null))
                        {
                            rdr2.Close();
                        }
                    }
                    else
                    {
                    accountbalance.Text = "0";
                    }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and SettingsApproval='Yes'";
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFreezeAccount frm = new FrmFreezeAccount();
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
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
            try
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select SavingsID from Savings where SavingsID='" + saveid + "' order by ID Desc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        auto3();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string kt3 = "select SavingsID from Savings where SavingsID='" + saveid + "' order by ID Desc";
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
                    string cb = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Credit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
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
                    cmd.Parameters["@d1"].Value = saveid;
                    cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d3"].Value = accountname.Text;
                    cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d5"].Value = date2.Text.Trim();
                    cmd.Parameters["@d6"].Value = Convert.ToInt32(amountfreezed.Value);
                    cmd.Parameters["@d7"].Value = accountbalance.Value;
                    cmd.Parameters["@d8"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d9"].Value = "Freezed";
                    cmd.Parameters["@d10"].Value = "Cash";
                    cmd.Parameters["@d11"].Value = date2.Text.Trim();
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(amountfreezed.Value);
                    cmd.Parameters["@d13"].Value = "Approved";
                    cmd.Parameters["@d14"].Value = cashiername.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Account SET Freezed=@d2 WHERE AccountNumber=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = "Yes";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            /*try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Savings SET Freezed=@d2 WHERE AccountNo=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = "Yes";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Freezed", "Freeze", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmFreezeAccount frm = new FrmFreezeAccount();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void buttonX4_Click(object sender, EventArgs e)
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
            try
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select SavingsID from Savings where SavingsID='" + saveid + "' order by ID Desc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        auto3();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string kt3 = "select SavingsID from Savings where SavingsID='" + saveid + "' order by ID Desc";
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
               
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        accountbalance.Text = (Convert.ToInt32(rdr2["Accountbalance"]) + amountfreezed.Value).ToString();
                        if ((rdr2 != null))
                        {
                            rdr2.Close();
                        }
                    }
                    else
                    {
                        accountbalance.Text = "0";
                        accountbalance.Text = (0 + amountfreezed.Value).ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Credit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
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
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Credit"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters["@d1"].Value = saveid;
                cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d3"].Value = accountname.Text;
                cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d5"].Value = date2.Text.Trim();
                cmd.Parameters["@d6"].Value = Convert.ToInt32(amountfreezed.Value);
                cmd.Parameters["@d7"].Value = accountbalance.Value;
                cmd.Parameters["@d8"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d9"].Value = " Un Freezed";
                cmd.Parameters["@d10"].Value = "Cash";
                cmd.Parameters["@d11"].Value = date2.Text.Trim();
                cmd.Parameters["@d12"].Value = Convert.ToInt32(amountfreezed.Value);
                cmd.Parameters["@d13"].Value = "Approved";
                cmd.Parameters["@d14"].Value = cashiername.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successful Unfreezed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Account SET Freezed=@d2 WHERE AccountNumber=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = "No";
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
                string cb = "UPDATE Savings SET Freezed=@d2 WHERE AccountNo=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = "No";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Freezed", "Freeze", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmFreezeAccount frm = new FrmFreezeAccount();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void accountname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                    accountbalance.Text = rdr2["Accountbalance"].ToString();
                    if ((rdr2 != null))
                    {
                        rdr2.Close();
                    }
                }
                else
                {
                    accountbalance.Text = "0";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void integerInput1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Accountbalance from Savings where  AccountNo= '" + accountnumber.Text + "' and Approval='Approved' order by Savings.ID Desc";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                    accountbalance.Text = (Convert.ToInt32(rdr2["Accountbalance"])-amountfreezed.Value).ToString();
                    if ((rdr2 != null))
                    {
                        rdr2.Close();
                    }
                }
                else
                {
                    accountbalance.Text = "0";
                    accountbalance.Text = (0 - amountfreezed.Value).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
