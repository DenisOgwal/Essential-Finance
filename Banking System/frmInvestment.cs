using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.IO;
namespace Banking_System
{
    public partial class frmInvestment : DevComponents.DotNetBar.Office2007RibbonForm
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        public frmInvestment()
        {
            InitializeComponent();
        }
        
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            purchaseid.Text = "PR-" + years + monthss + days + GetUniqueKey(5);
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
        private void FeesDetails_Load(object sender, EventArgs e)
        {
            this.label12.Text = AssemblyCopyright;
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label2.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label2.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
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
                    cmbModeOfPayment.Items.Add(drow[1].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }


        private void Reset()
        {
            purchaseid.Text = "";
            product.Text = "";
            Price.Text =null;
            units.Text = "";
            description.Text = "";
           
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Investment where PropertyID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PropertyID"));
                cmd.Parameters["@DELETE1"].Value = purchaseid.Text;
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

        private void frmPurchaseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMainMenu frm = new frmMainMenu();
            this.Hide();
            Reset();
            /*frm.UserType.Text = label13.Text;
            frm.User.Text = label21.Text;
            frm.Show();*/
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void product_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffname.Text == "")
                {
                    MessageBox.Show("Please enter  names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    staffname.Focus();
                    return;
                }
                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select product from Property where Product= '" + product.Text + "' and Price= '" + Price.Value + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                auto();
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Investment(PropertyID,product,units,PriceDate,description,Price,Staff) VALUES (@d1,@d2,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PropertyID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 30, "Price"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 60, "Staff"));
                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = product.Text.Trim();
                cmd.Parameters["@d5"].Value = units.Text.Trim();
                cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d7"].Value = description.Text;
                cmd.Parameters["@d8"].Value = Price.Value;
                cmd.Parameters["@d9"].Value = staffname.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr3 = null;
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr3 = cmd.ExecuteReader();
                if (rdr3.Read())
                {
                    totalaamount = Convert.ToInt32(rdr3["AmountAvailable"]);
                    int newtotalammount = totalaamount - Convert.ToInt32(Price.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + Purchasedate.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }

                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter  product description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Investment set Price=@d8, product=@d2,units=@d5,description=@d7,PriceDate=@d6 where PropertyID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PropertyID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 30, "Price"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = product.Text.Trim();
                cmd.Parameters["@d5"].Value = units.Text.Trim();
                cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d7"].Value = description.Text;
                cmd.Parameters["@d8"].Value = Price.Value;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Property Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and Investments='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        staffname.Text = rdr2["UserName"].ToString().Trim();
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

