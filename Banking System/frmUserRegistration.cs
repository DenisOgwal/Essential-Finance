using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;

namespace Banking_System
{
    public partial class frmUserRegistration : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        string type = "Staff";

        public frmUserRegistration()
        {
            InitializeComponent();
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        this.label12.Text = AssemblyCopyright;
        Autocomplete();
        usertypescomplete();
        try
        {
            SqlConnection CN = new SqlConnection(cs.DBConn);
            CN.Open();
            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(StaffName) FROM Employee", CN);
            ds = new DataSet("ds");
            adp.Fill(ds);
            dtable = ds.Tables[0];
            txtName.Items.Clear();
            foreach (DataRow drow in dtable.Rows)
            {
                txtName.Items.Add(drow[0].ToString());
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (CN.State == ConnectionState.Open)
            {
                CN.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }
        private void Reset()
        {
            /*txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact_no.Text = "";
            txtName.Text = "";
            txtEmail_Address.Text = "";
            cmbUsertype.Text = "";*/
            this.Hide();
            frmUserRegistration frm = new frmUserRegistration();
            frm.ShowDialog();
        }
        private void usertypescomplete()
        {
            try
            {
                txtUsername.Text = txtUsername.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserTypes ";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsertype.Items.Add(rdr["UserType"]);
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
        private void Email_Address_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail_Address.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail_Address.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail_Address.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void Name_Of_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Username_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]");
            if (txtUsername.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtUsername.Text))
                {
                    MessageBox.Show("only letters,numbers and underscore is allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtUsername.Text = txtUsername.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_registration WHERE username = '" + txtUsername.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtPassword.Text = (rdr.GetString(1).Trim());
                    txtName.Text = (rdr.GetString(2).Trim());
                    txtContact_no.Text = (rdr.GetString(3).Trim());
                    txtEmail_Address.Text = (rdr.GetString(4).Trim());
                    cmbUsertype.Text = (rdr.GetString(6).Trim());
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

       private void Autocomplete()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT username FROM user_registration", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "user_registration");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Username"].ToString());
            }
            txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUsername.AutoCompleteCustomSource = col;
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;

            con.Close();
        }

        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from User_Registration where Username='" + txtUsername.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Autocomplete();
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    //Autocomplete();
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
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select username from user_registration where username=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "username"));
                cmd.Parameters["@find"].Value = txtUsername.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Username not available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!rdr.Read())
                {
                    MessageBox.Show("Username available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();

                }
                if ((rdr != null))
                {
                    rdr.Close();
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
            frmRegisteredUsersDetails frm = new frmRegisteredUsersDetails();
            frm.label1.Text = label8.Text;
            frm.label2.Text = label9.Text;
            frm.ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptText(txtPassword.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update user_registration set password=@d2,contact_no=@d3,email=@d4,name=@d5,usertype=@d7 where username=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "password"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "contact_no"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "email"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "name"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "usertype"));
                cmd.Parameters["@d1"].Value = txtUsername.Text.Trim();
                cmd.Parameters["@d2"].Value = result;
                cmd.Parameters["@d5"].Value = txtName.Text;
                cmd.Parameters["@d3"].Value = txtContact_no.Text;
                cmd.Parameters["@d4"].Value = txtEmail_Address.Text;
                cmd.Parameters["@d7"].Value = cmbUsertype.Text;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Autocomplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
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
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

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

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        string results = null;
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results = Encoding.UTF8.GetString(bytesDecrypted);

            return results;
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
        private void buttonX3_Click(object sender, EventArgs e)
        {
            /*try
            {
               
                DecryptText(result, "essentialhospital");
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(results, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (cmbUsertype.Text == "")
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtContact_no.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact_no.Focus();
                return;
            }
            if (txtEmail_Address.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail_Address.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Username from User_Registration where Username=@find";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "Username"));
                cmd.Parameters["@find"].Value = txtUsername.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                EncryptText(txtPassword.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into User_Registration(Username,Password,Contact_no,Email,Name,Date_of_joining,usertype,Category) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Password"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Contact_no"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Email"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "Name"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 30, "Date_of_joining"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 29, "usertype"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Category"));
                cmd.Parameters["@d1"].Value = txtUsername.Text.Trim();
                cmd.Parameters["@d2"].Value = result;
                cmd.Parameters["@d3"].Value = txtContact_no.Text;
                cmd.Parameters["@d4"].Value = txtEmail_Address.Text;
                cmd.Parameters["@d5"].Value = txtName.Text;
                cmd.Parameters["@d6"].Value = DateTime.Now;
                cmd.Parameters["@d7"].Value = cmbUsertype.Text;
                cmd.Parameters["@d8"].Value = type;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                //Autocomplete(); 
            }
            catch (Exception ex)
            {
           MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}