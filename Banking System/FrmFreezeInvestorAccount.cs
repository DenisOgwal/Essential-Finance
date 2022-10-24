using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmFreezeInvestorAccount : DevComponents.DotNetBar.Office2007RibbonForm
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
        public FrmFreezeInvestorAccount()
        {
            InitializeComponent();
        }

        private void FrmFreezeAccount_Load(object sender, EventArgs e)
        {

        }

        private void accountnumber_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
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
            FrmFreezeInvestorAccount frm = new FrmFreezeInvestorAccount();
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
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
            if (installment.Text == "" && savingsid.Text == "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestorAccount SET Freezed=@d2 WHERE AccountNumber=@d1";
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
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE AccountNo=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                    cmd.Parameters["@d2"].Value = "Yes";
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
                    string cb = "UPDATE InvestorSavings SET Freezed=@d2 WHERE AccountNo=@d1";
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
                    FrmFreezeInvestorAccount frm = new FrmFreezeInvestorAccount();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (installment.Text == "" && savingsid.Text != "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = "Yes";
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
                    string cb = "UPDATE InvestorSavings SET Freezed=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = "Yes";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Freezed", "Freeze", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmFreezeInvestorAccount frm = new FrmFreezeInvestorAccount();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (installment.Text != "" && savingsid.Text != "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE SavingsID=@d1 and Installment='"+installment.Text+"'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = "Yes";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
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
            if (installment.Text == "" && savingsid.Text == "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestorAccount SET Freezed=@d2 WHERE AccountNumber=@d1";
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
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE AccountNo=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNo"));
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
                    string cb = "UPDATE InvestorSavings SET Freezed=@d2 WHERE AccountNo=@d1";
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
                    FrmFreezeInvestorAccount frm = new FrmFreezeInvestorAccount();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (installment.Text == "" && savingsid.Text != "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
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
                    string cb = "UPDATE InvestorSavings SET Freezed=@d2 WHERE SavingsID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = "No";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Freezed", "Freeze", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmFreezeInvestorAccount frm = new FrmFreezeInvestorAccount();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (installment.Text != "" && savingsid.Text != "")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE InvestmentAppreciation SET Freezed=@d2 WHERE SavingsID=@d1 and Installment='" + installment.Text + "'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Freezed"));
                    cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                    cmd.Parameters["@d2"].Value = "No";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void accountname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select SavingsID from InvestorSavings where  AccountNo= '" + accountnumber.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr2 = cmd.ExecuteReader();
                savingsid.Items.Clear();
                while (rdr2.Read())
                {
                    savingsid.Items.Add(rdr2["SavingsID"].ToString());
                }
                con.Close();
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
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select InvestmentPlan,Accountbalance from InvestorSavings where  SavingsID= '" + savingsid.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr2 = cmd.ExecuteReader();
                investmentplan.Text="";
                if (rdr2.Read())
                {
                    investmentplan.Text=rdr2["InvestmentPlan"].ToString();
                    accountbalance.Text= rdr2["Accountbalance"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SqlDataReader rdr3 = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select Distinct Installment from InvestmentAppreciation where  SavingsID= '" + savingsid.Text + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr3 = cmd.ExecuteReader();
                installment.Text = "";
                installment.Items.Clear();
                while (rdr3.Read())
                {
                    installment.Items.Add(rdr3[0].ToString());
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
