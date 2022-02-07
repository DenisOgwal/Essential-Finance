using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
namespace Banking_System
{
    public partial class frmRights : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString(); 
        public frmRights()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            date.Text = DateTime.Today.ToString();
            Staffid.Text = "";
            Staffname.Text = "";
            authorisedid.Text = "";
            category.Text = "";
        }
        private void usertypescomplete()
        {
            try
            {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserTypes ";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.Items.Add(rdr["UserType"]);
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
        private void Rights_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(StaffID) FROM Employee", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Staffid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Staffid.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            usertypescomplete();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Staffid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Staffname from Employee WHERE StaffID = '" + Staffid.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Staffname.Text = (rdr.GetString(0).Trim());
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
            try
            {
                Staffid.Text = Staffid.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Rights WHERE StaffID = '" + Staffid.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    authorisedid.Text = (rdr.GetString(4).Trim());
                    category.Text = (rdr.GetString(5).Trim());
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
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (Staffid.Text == "")
            {
                MessageBox.Show("Please Select Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Staffid.Focus();
                return;
            }
            if (Staffname.Text == "")
            {
                MessageBox.Show("Please enter Staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Staffname.Focus();
                return;
            }
            if (authorisedid.Text == "")
            {
                MessageBox.Show("Please enter Authorisation ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                authorisedid.Focus();
                return;
            }
            if (category.Text == "")
            {
                MessageBox.Show("Please Select Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                category.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StaffID from Rights where StaffID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@find"].Value = Staffid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Staff ID. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Staffid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                EncryptText(authorisedid.Text, "essentialfinance");
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AuthorisationID from Rights where  AuthorisationID=@find";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, " AuthorisationID"));
                cmd.Parameters["@find"].Value =result;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Authorisation ID. Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    authorisedid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Rights(AssignmentDate,StaffID,StaffName,AuthorisationID,Category) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AssignmentDate"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "StaffName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "AuthorisationID"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Category"));
                cmd.Parameters["@d1"].Value = date.Text;
                cmd.Parameters["@d2"].Value = Staffid.Text.Trim();
                cmd.Parameters["@d3"].Value = Staffname.Text.Trim();
                cmd.Parameters["@d4"].Value = result;
                cmd.Parameters["@d5"].Value = category.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Savings Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (Staffid.Text == "")
            {
                MessageBox.Show("Please enter Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Staffid.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;
               /* con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StaffID from Rights where StaffID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@find"].Value = Staffid.Text;
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
                }*/
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq1 = "delete  from  ApprovalRights where StaffID=@DELETE1;";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@DELETE1"].Value = Staffid.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  Rights where StaffID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@DELETE1"].Value = Staffid.Text;
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
                EncryptText(authorisedid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Rights set AuthorisationID=@d4 where StaffID=@d2";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AssignmentDate"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "StaffName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "AuthorisationID"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Category"));
                cmd.Parameters["@d1"].Value = date.Text;
                cmd.Parameters["@d2"].Value = Staffid.Text.Trim();
                cmd.Parameters["@d3"].Value = Staffname.Text.Trim();
                cmd.Parameters["@d4"].Value = result;
                cmd.Parameters["@d5"].Value = category.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void authorisedid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
