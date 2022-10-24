using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace Banking_System
{
    public partial class FrmAccountBal : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmAccountBal()
        {
            InitializeComponent();
        }

        private void FrmAccountBal_Load(object sender, EventArgs e)
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtTotalPaid.Value= Convert.ToInt32(rdr["AmountAvailable"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffname.Text == "")
                {
                    MessageBox.Show("Please enter  names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    staffname.Focus();
                    return;
                }
                if (txtTotalPaid.Text == "")
                {
                    MessageBox.Show("Please enter Ammount Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalPaid.Focus();
                    return;
                }
                if (cmbModeOfPayment.Text == "")
                {
                    MessageBox.Show("Please select mode of payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbModeOfPayment.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "UPDate BankAccounts Set AmountAvailable='" + txtTotalPaid.Value + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
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

        private void staffid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(staffid.Text, "essentialfinance");
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ManagingDirector='Yes'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        staffname.Text = rdr["UserName"].ToString().Trim();
                    }
                    else
                    {
                        staffname.Text = "";
                    }
                }
                else
                {
                    staffname.Text = "";
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
