using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security.Cryptography;
namespace Banking_System
{
    public partial class frmExternalLoanManual : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        public frmExternalLoanManual()
        {
            InitializeComponent();
        }

        private void frmExternalLoanManual_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalLoanManual frm = new frmExternalLoanManual();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (Lender.Text == "")
            {
                MessageBox.Show("Please Fill Lender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Lender.Focus();
                return;
            }
            if (AmortisationMethod.Text == "")
            {
                MessageBox.Show("Please Select Amortisation Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AmortisationMethod.Focus();
                return;
            }
            if (ApprovalName.Text == "")
            {
                MessageBox.Show("Please Enter Correct Approval ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ApprovalID.Focus();
                return;
            }
            if (PaymentInterval.Text == "")
            {
                MessageBox.Show("Please Enter Payment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentInterval.Focus();
                return;
            }
            if (Interest.Text == "")
            {
                MessageBox.Show("Please Enter Interest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Interest.Focus();
                return;
            }
            if (Amount.Text == "")
            {
                MessageBox.Show("Please Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Amount.Focus();
                return;
            }
            if (RepaymentInterval.Text == "")
            {
                MessageBox.Show("Please Enter Repayment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RepaymentInterval.Focus();
                return;
            }
            if (ServicingPeriod.Text == "")
            {
                MessageBox.Show("Please Enter Servicing Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ServicingPeriod.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ExternalLoans(LoansID,LoanAmmount,Securities,OfficerName,Date,Period,InterestRate,ModeOfPayment,Lender,Method,ServicingInterval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoansID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "LoanAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 200, "Securities"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "OfficerName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Period"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "InterestRate"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "Lender"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "Method"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "ServicingInterval"));
                cmd.Parameters["@d1"].Value = LoanID.Text.Trim();
                cmd.Parameters["@d2"].Value = Amount.Value;
                cmd.Parameters["@d3"].Value = Securities.Text;
                cmd.Parameters["@d4"].Value = ApprovalName.Text.Trim();
                cmd.Parameters["@d5"].Value = ApplicationDate.Text.Trim();
                cmd.Parameters["@d6"].Value = ServicingPeriod.Text;
                cmd.Parameters["@d7"].Value = Interest.Text;
                cmd.Parameters["@d8"].Value = PaymentMode.Text.Trim();
                cmd.Parameters["@d9"].Value = Lender.Text;
                cmd.Parameters["@d10"].Value = AmortisationMethod.Text;
                cmd.Parameters["@d11"].Value = RepaymentInterval.Text;
                cmd.ExecuteNonQuery();
                con.Close();


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into ExternalRepaymentSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Interest"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[0].Value) != null)
                        {
                            cmd.Parameters["@d1"].Value = LoanID.Text;
                            cmd.Parameters["@d2"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d3"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[4].Value;
                            cmd.Parameters["@d5"].Value = row.Cells[2].Value;
                            cmd.Parameters["@d6"].Value = row.Cells[3].Value;
                            cmd.Parameters["@d7"].Value = row.Cells[4].Value;
                            cmd.Parameters["@d8"].Value = row.Cells[5].Value;
                            cmd.ExecuteNonQuery();
                           
                        }
                    }
                }
                con.Close();
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
        private void ApprovalID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(ApprovalID.Text, "essentialfinance");
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
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        ApprovalName.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        ApprovalName.Text = "";
                    }
                }
                else
                {
                    ApprovalName.Text = "";
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
