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
    public partial class frmIndividualAttendanceForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmIndividualAttendanceForm()
        {
            InitializeComponent();
        }

        private void frmIndividualAttendanceForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (checkBoxX4.Checked)
            {
                try
                {
                    if (staffid.Text == "")
                    {
                        MessageBox.Show("Please Input staff id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        staffid.Focus();
                        return;
                    }
                    if (staffname.Text == "")
                    {
                        MessageBox.Show("Please Correct Input staff id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        staffid.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cd = "insert into SignInOut(StaffName,attendancedate,StaffNo,SignIn,SignOut) VALUES (@d8,@d9,@d10,@d11,@d12)";
                    cmd = new SqlCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "Staffname"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "attendancedate"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 15, "StaffNo"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "SignIn"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SignOut"));
                    cmd.Parameters["@d8"].Value = staffname.Text;
                    cmd.Parameters["@d9"].Value = rollcalldate.Text;
                    cmd.Parameters["@d10"].Value = staffid.Text;
                    cmd.Parameters["@d11"].Value = time.Text;
                    cmd.Parameters["@d12"].Value = "Pending";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (checkBoxX3.Checked)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StaffName,ID from SignInOut where  StaffNo='" + staffid.Text + "' and SignOut='Pending' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int ids = rdr.GetInt32(1);
                    //MessageBox.Show(ids.ToString(), "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cd = "UPDATE SignInOut SET SignOut=@d12 where StaffName=@d8 and StaffNo=@d10 and ID='" + ids + "'";
                        cmd = new SqlCommand(cd);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "Staffname"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "attendancedate"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 15, "StaffNo"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "SignIn"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SignOut"));
                        cmd.Parameters["@d8"].Value = staffname.Text;
                        cmd.Parameters["@d9"].Value = rollcalldate.Text;
                        cmd.Parameters["@d10"].Value = staffid.Text;
                        cmd.Parameters["@d11"].Value = time.Text;
                        cmd.Parameters["@d12"].Value = time.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully saved", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
        private void authorisationid_TextChanged(object sender, EventArgs e)
        {
            try{
                EncryptText(authorisationid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string ct = "select distinct RTRIM(StaffName),RTRIM(StaffID) from Rights where AuthorisationID = '" +result+ "'";
                   cmd = new SqlCommand(ct);
                   cmd.Connection = con;
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       //staffname.Text = rdr.GetString(0).Trim();
                       staffid.Text = rdr.GetString(1).Trim();
                   }
                   con.Close();
            }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
        }

        private void staffid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                staffname.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName FROM Employee WHERE StaffID = '" + staffid.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    staffname.Text = rdr.GetString(0).Trim();
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
