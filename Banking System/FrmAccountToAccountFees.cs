using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
namespace Banking_System
{
    public partial class FrmAccountToAccountFees : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlCommand cmd2 = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr2 = null;
        public FrmAccountToAccountFees()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            minimumfee.Text = "";
            maximumfee.Text = "";
            chairperson.Text = "";
            chairpersonid.Text = "";
            fees.Text = "";
        }
        private void frmTotalRegistrationFees_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (chairperson.Text == "")
            {
                MessageBox.Show("Please enter Approval Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chairperson.Focus();
                return;
            }
            if (chairpersonid.Text == "")
            {
                MessageBox.Show("Please Enter Approval ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chairpersonid.Focus();
                return;
            }
            if (minimumfee.Text == "")
            {
                MessageBox.Show("Please enter fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                minimumfee.Focus();
                return;
            }
            try
            {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into TransferFees(Months,Year,SettingDate,TransferFee,ChairPerson,TransferFeeMIN,TransferFeeMAX) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "SettingDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 20, "TransferFee"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 40, "ChairPerson"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferFeeMIN"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "TransferFeeMAX"));
                cmd.Parameters["@d1"].Value = month1.Text;
                cmd.Parameters["@d2"].Value = year1.Text.Trim();
                cmd.Parameters["@d3"].Value = date1.Text.Trim();
                cmd.Parameters["@d4"].Value = fees.Text;
                cmd.Parameters["@d5"].Value = chairperson.Text.Trim();
                cmd.Parameters["@d6"].Value = minimumfee.Text;
                cmd.Parameters["@d7"].Value = maximumfee.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  TransferFees where Months=@DELETE1 and Year=@delete2 and SettingDate=@date3;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@DELETE1"].Value = month1.Text;
                cmd.Parameters.Add(new SqlParameter("@delete2", System.Data.SqlDbType.NChar, 15, "Year"));
                cmd.Parameters["@DELETE1"].Value = year1.Text;
                cmd.Parameters.Add(new SqlParameter("@delete3", System.Data.SqlDbType.NChar, 15, "SettingDate"));
                cmd.Parameters["@DELETE1"].Value = date1.Text;
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update TransferFees set TransferFee=@d4,TransferFeeMIN=@d6,TransferFeeMAX=@d7 where Year=@d2 and Months=@d1 and SettingDate=@d3";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "SettingDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 20, "TransferFee"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 40, "ChairPerson"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferFeeMIN"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "TransferFeeMAX"));
                cmd.Parameters["@d1"].Value = month1.Text;
                cmd.Parameters["@d2"].Value = year1.Text.Trim();
                cmd.Parameters["@d3"].Value = date1.Text.Trim();
                cmd.Parameters["@d4"].Value = fees.Text;
                cmd.Parameters["@d5"].Value = chairperson.Text.Trim();
                cmd.Parameters["@d6"].Value = minimumfee.Text;
                cmd.Parameters["@d7"].Value = maximumfee.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void chairpersonid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(chairpersonid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffid = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open(); 
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffid+ "' and SettingsApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                    chairperson.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        chairperson.Text = "";
                    }
                }
                else
                {
                    chairperson.Text = "";
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

        private void labelX8_Click(object sender, EventArgs e)
        {

        }
    }
}
