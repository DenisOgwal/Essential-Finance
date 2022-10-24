using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.IO;
namespace Banking_System
{
    public partial class frmLoanFines : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmLoanFines()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            this.Hide();
            frmLoanFines frm = new frmLoanFines();
            frm.label7.Text = label7.Text;
            frm.label12.Text = label12.Text;
            frm.ShowDialog();
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
        private void frmSalaryPayment_Load(object sender, EventArgs e)
        {
            this.labelX5.Text = AssemblyCopyright;
            PopulateStaffID();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void txtDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Reset(); 
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
                    companyaddress = rdr.GetString(5).Trim();
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
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (cmbStaffID.Text == "")
            {
                MessageBox.Show("Please select Member id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStaffID.Focus();
                return;
            }
            if (staffname.Text == "")
            {
                MessageBox.Show("Please enter Staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                staffname.Focus();
                return;
            }
            if (loanid.Text == "")
            {
                MessageBox.Show("Please Select Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            if (installment.Text == "")
            {
                MessageBox.Show("Please Select Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                installment.Focus();
                return;
            }
            try
            {
                int fines = finefee.Value + Convert.ToInt32(Convert.ToDouble(label9.Text));
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update RepaymentSchedule set Fines="+ fines + ",BalanceExist=@d3 where LoanID=@d2 and Months=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@d2"].Value = loanid.Text;
                cmd.Parameters["@d3"].Value = (Convert.ToInt32(label4.Text)+finefee.Value);
                cmd.Parameters["@d5"].Value = installment.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved", "Fine Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX2.Enabled = true;
                con.Close();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
           
        }

        private void PopulateStaffID()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber) FROM Account", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbStaffID.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbStaffID.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AccountNames from Account WHERE AccountNumber = '" + cmbStaffID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtStaffName.Text = (rdr.GetString(0).Trim());
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
        private void staffid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(staffid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and AddFines='Yes'";
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

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (cmbStaffID.Text == "")
            {
                MessageBox.Show("Please select Member id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStaffID.Focus();
                return;
            }
            if (staffname.Text == "")
            {
                MessageBox.Show("Please enter Staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                staffname.Focus();
                return;
            }
            if (loanid.Text == "")
            {
                MessageBox.Show("Please Select Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            if (installment.Text == "")
            {
                MessageBox.Show("Please Select Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                installment.Focus();
                return;
            }
            try
            {
                int realbalance = Convert.ToInt32(Convert.ToDouble(label4.Text)) - Convert.ToInt32(Convert.ToDouble(finefee.Value));
                int totalammount = Convert.ToInt32(Convert.ToDouble(label5.Text));
                int fines =  Convert.ToInt32(Convert.ToDouble(label9.Text))- finefee.Value;
                if (totalammount> realbalance)
                {
                    MessageBox.Show("You can not waiver more than added fines", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update RepaymentSchedule set Waivered='Yes',Fines="+fines+",BalanceExist=@d3 where LoanID=@d2 and Months=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@d2"].Value = loanid.Text;
                cmd.Parameters["@d3"].Value = (Convert.ToInt32(label4.Text) - finefee.Value);
                cmd.Parameters["@d5"].Value = installment.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "Fine Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX2.Enabled = true;
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbStaffID_Click(object sender, EventArgs e)
        {
            frmClientDetails3 frm = new frmClientDetails3();
            frm.ShowDialog();
            this.cmbStaffID.Text = frm.clientnames.Text;
            this.txtStaffName.Text = frm.Accountnames.Text;
            return;
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {

        }

        private void loanid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Months from RepaymentSchedule where LoanID= '" + loanid.Text + "' and BalanceExist>0 and PaymentStatus !='Rescheduled' and PaymentStatus !='Toppedup'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                installment.Items.Clear();
                while (rdr.Read() == true)
                {
                    installment.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select LoanID from Loan where AccountNo= '" + cmbStaffID.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                loanid.Items.Clear();
                while (rdr.Read() == true)
                {
                    loanid.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void installment_TextChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ht = "select Fines,BalanceExist,TotalAmmount from RepaymentSchedule where  LoanID= '" + loanid.Text.Trim() + "' and Months='" + installment.Text.Trim() + "'  ";
            cmd = new SqlCommand(ht);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                finefee.Value = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                label4.Text =(Convert.ToInt32(Convert.ToDouble(rdr[1]))).ToString();
                label5.Text= (Convert.ToInt32(Convert.ToDouble(rdr[2]))).ToString();
                label9.Text = (Convert.ToInt32(Convert.ToDouble(rdr[0]))).ToString();
                con.Close();
            }
            else
            {
                finefee.Value = 0;
                label4.Text = "0";
                label9.Text = "0";
                label5.Text = "0";
            }
            con.Close();
        }

        private void installment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
