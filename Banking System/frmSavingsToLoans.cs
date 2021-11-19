using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.IO;
namespace Banking_System
{
    public partial class frmSavingsToLoans : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
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
        string Savingsids = null;
        string repaymentid = null;
        public frmSavingsToLoans()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtPaymentID.Text = "";
            cmbStaffID.Text = "";
            dtpPaymentDate.Text = DateTime.Today.ToString();
            txtPaymentModeDetails.Text = "";
            txtStaffName.Text = "";
            txtTotalPaid.Text = null;
            staffid.Text = "";
            staffname.Text = "";
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
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            txtPaymentID.Text = "STL-" + years + monthss + days + GetUniqueKey(5);
            repaymentid = "RID-" + years + monthss + days + GetUniqueKey(5);
            Savingsids = "S-" + years + monthss + days + GetUniqueKey(7);
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
        private void frmSalaryPayment_Load(object sender, EventArgs e)
        {
            this.labelX5.Text = AssemblyCopyright;
            dataGridView1.DataSource = GetData();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label7.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    //if (prices == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                    //if (pricess == "Yes") { buttonX5.Enabled = true; } else { buttonX5.Enabled = false; }
                }
                if (label7.Text == "ADMIN")
                {
                    //buttonX4.Enabled = true;
                    //buttonX5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        public DataView GetData()
        {
            dynamic SelectQry = "SELECT RTRIM(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names] from Account  order by ID DESC ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TableView;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                cmbStaffID.Text = dr.Cells[0].Value.ToString();
                txtStaffName.Text = dr.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.Hide();
            frmSavingsToLoansRecord frm = new frmSavingsToLoansRecord();
            frm.label4.Text = label7.Text;
            frm.label5.Text = label12.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavingsToLoans frm = new frmSavingsToLoans();
            frm.label7.Text = label7.Text;
            frm.label12.Text = label12.Text;
            frm.ShowDialog(); 
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
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            if (staffname.Text == "")
            {
                MessageBox.Show("Please enter staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                staffname.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter Ammount Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
                return;
            }
            if (repaymonths.Text == "")
            {
                MessageBox.Show("Please Select Repayment Months", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repaymonths.Focus();
                return;
            }
            try
            {
                 auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SavingsToLoans(PaymentID,AccountNo,AccountNames,Date,LoanID,TransferedAmmount,CashierName,Details) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferedAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Text, 2000, "Details"));
                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                cmd.Parameters["@d3"].Value = txtStaffName.Text; 
                cmd.Parameters["@d4"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d5"].Value = loanid.Text; 
                cmd.Parameters["@d6"].Value = Convert.ToInt32(txtTotalPaid.Value); 
                cmd.Parameters["@d7"].Value =staffname.Text;
                cmd.Parameters["@d8"].Value = txtPaymentModeDetails.Text;
                cmd.ExecuteReader();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Transactions"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                cmd.Parameters["@d1"].Value = cmbStaffID.Text;
                cmd.Parameters["@d2"].Value = Savingsids;
                cmd.Parameters["@d3"].Value = staffname.Text;
                cmd.Parameters["@d4"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d5"].Value = txtTotalPaid.Value;
                cmd.Parameters["@d6"].Value =totalsavings.Value;
                cmd.Parameters["@d7"].Value = "Paid Loan";
                cmd.Parameters["@d8"].Value = "Transfer";
                cmd.Parameters["@d9"].Value = txtStaffName.Text;
                cmd.Parameters["@d10"].Value = staffname.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb4 = "insert into LoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,CashierID,LoanID,MemberID,CashierName,Repaymentdate,Interest,TotalAmmount,MemberName,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb4);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "CashierID"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "Interest"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "MemberName"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters["@d1"].Value = repaymentid;
                cmd.Parameters["@d2"].Value = Convert.ToInt32(txtTotalPaid.Value);
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = repaymonths.Text.Trim();
                cmd.Parameters["@d5"].Value = staffid.Text;
                cmd.Parameters["@d6"].Value = loanid.Text.Trim();
                cmd.Parameters["@d7"].Value = cmbStaffID.Text;
                cmd.Parameters["@d8"].Value = staffname.Text;
                cmd.Parameters["@d9"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d10"].Value = 0;
                cmd.Parameters["@d11"].Value = txtTotalPaid.Value;
                cmd.Parameters["@d12"].Value = txtStaffName.Text;
                cmd.Parameters["@d13"].Value = "Transfer";
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb5 = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and Months=@d5";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@d1"].Value = "Paid";
                cmd.Parameters["@d2"].Value = loanid.Text;
                cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                cmd.Parameters["@d4"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d5"].Value = repaymonths.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                company();
               try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    rptReceiptAll rpt = new rptReceiptAll(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); //The DataSet you created.
                    Receipt frm = new Receipt();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from Savings";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Savings");
                    //myDA.Fill(myDS, "Rights");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", txtPaymentID.Text);
                    rpt.SetParameterValue("accountno", cmbStaffID.Text);
                    rpt.SetParameterValue("membernames", txtStaffName.Text);
                    rpt.SetParameterValue("ammount", (Convert.ToInt32(txtTotalPaid.Value)+Convert.ToInt32(balance.Value)));
                    rpt.SetParameterValue("totalpaid", txtTotalPaid.Value);
                    rpt.SetParameterValue("issuedby", staffname.Text);
                    rpt.SetParameterValue("Transactions", "Savings To Loans Receipt");
                    rpt.SetParameterValue("addons", 0);
                    rpt.SetParameterValue("duepayment", balance.Value);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.ShowDialog();
                    //rpt.PrintToPrinter(1, true, 1, 1);
                    //frm.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Hide();
                frmSavingsToLoans frm2 = new frmSavingsToLoans();
                frm2.label7.Text = label7.Text;
                frm2.label12.Text = label12.Text;
                frm2.ShowDialog(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
               /* this.Hide();
               Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptShareCapitalSlip rpt = new rptShareCapitalSlip(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AShareCapitalDataSet1 myDS = new AShareCapitalDataSet1(); //The DataSet you created.
                FrmShareCapitalPaymentSlip frm = new FrmShareCapitalPaymentSlip();
                frm.label1.Text = label7.Text;
                frm.label2.Text = label12.Text;
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from ShareCapital where PaymentID='" + txtPaymentID.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ShareCapital");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();*/
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and IncomesApproval='Yes'";
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void cmbStaffID_Click(object sender, EventArgs e)
        {
            frmClientDetails frm = new frmClientDetails();
            frm.ShowDialog();
            this.cmbStaffID.Text = frm.clientnames.Text;
            this.txtStaffName.Text = frm.Accountnames.Text;
            return;
        }

        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            this.cmbStaffID.Text = frm.clientnames.Text;
            this.loanid.Text = frm.LoanID.Text;
            return;
        }

        private void cmbStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Accountbalance from Savings where AccountNo= '" + cmbStaffID.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountbalance.Text = rdr["Accountbalance"].ToString();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    accountbalance.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repaymonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
            try
            {
                int val4 = 0;
                int val5 = 0;
                int val6 = 0;
                int val7 = 0;
                balance.Text = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ht = "select TotalAmmount,Interest from RepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' ";
                cmd = new SqlCommand(ht);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    double totals = Convert.ToDouble(rdr[0]);
                    double intrests = Convert.ToDouble(rdr[1]);
                    val6 = Convert.ToInt32(totals);
                    val7 = Convert.ToInt32(intrests);
                    con.Close();
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ID,AmmountPaid,TotalAmmount from LoanRepayment where  LoanID= '" + loanid.Text + "' and RepayMonths='" + repaymonths.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct1 = "select SUM(AmmountPaid) as AmmountPaid  from LoanRepayment where  LoanID= '" + loanid.Text + "' and RepayMonths='" + repaymonths.Text + "'";
                    cmd = new SqlCommand(ct1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double ammounts = Convert.ToDouble(rdr["AmmountPaid"]);
                        val4 = Convert.ToInt32(ammounts);
                        int.TryParse("0", out val5);
                        int I = (val6 - (val4 + val5));
                        balance.Value = I;
                        label14.Text = I.ToString();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        //return;
                    }
                    else
                    {
                        balance.Text = "0";
                        label14.Text = "0";
                    }
                }
                else
                {
                    int val1 = 0;
                    int val2 = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ft = "select TotalAmmount,AmmountPay,Interest from RepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "'";
                    cmd = new SqlCommand(ft);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        double totals1 = Convert.ToDouble(rdr[0]);
                        double principalammount = Convert.ToDouble(rdr[1]);
                        double interestammount = Convert.ToDouble(rdr[2]);
                        val1 = Convert.ToInt32(totals1);
                        int.TryParse("0", out val2);
                        int I = (val1 - val2);
                        balance.Text = I.ToString();
                        label14.Text = I.ToString();
                        con.Close();
                    }
                    else
                    {
                        balance.Text = "0";
                        label14.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTotalPaid_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalPaid.Text == "")
                {
                    return;
                }
                else
                {
                    balance.Text = (Convert.ToInt32(label14.Text) - Convert.ToInt32(txtTotalPaid.Value)).ToString();
                    totalsavings.Text = (Convert.ToInt32(accountbalance.Value) - Convert.ToInt32(txtTotalPaid.Value)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                repaymonths.Items.Clear();
                while (rdr.Read() == true)
                {
                    repaymonths.Items.Add(rdr[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
