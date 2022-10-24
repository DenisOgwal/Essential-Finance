using System;
using System.ComponentModel;
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
    public partial class frmLoanInsuranceFeesPayment : DevComponents.DotNetBar.Office2007Form
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
        public frmLoanInsuranceFeesPayment()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtPaymentID.Text = "";
            cmbStaffID.Text = "";
            cmbModeOfPayment.Text = "";
            dtpPaymentDate.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
            Year.Text = DateTime.Today.ToString();
            txtBasicSalary.Text = null;
            txtDeduction.Text = "";
            txtPaymentModeDetails.Text = "";
            txtStaffName.Text = null;
            txtTotalPaid.Text =null;
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
            txtPaymentID.Text = "LI-" + years + monthss + days + GetUniqueKey(5);
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
            /*Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;*/
            dataGridView1.DataSource = GetData();
            PopulateStaffID();
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
                    if (prices == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                    if (pricess == "Yes") { buttonX5.Enabled = true; } else { buttonX5.Enabled = false; }
                }
                if (label7.Text == "ADMIN")
                {
                    buttonX4.Enabled = true;
                    buttonX5.Enabled = true;
                }
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
                string ct2 = "select InsurancePercentage from LoanInsurance order by ID DESC";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string proseccingpercentage = rdr["InsurancePercentage"].ToString();
                    txtBasicSalary.Value = Convert.ToInt32(proseccingpercentage);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    // return;
                }
                else
                {
                    txtBasicSalary.Value = 0;
                }
                con.Close();
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
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmRegistrationFeesPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label7.Text;
            frm.UserType.Text = label12.Text;
            frm.Show();*/
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
            dynamic SelectQry = "SELECT RTRIM(LoanID)[Loan ID], RTRIM(LoanAmount)[Loan Amount],RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name] from Loan order by ID DESC "; //where Issued = 'Pending'
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
                txtStaffName.Value = Convert.ToInt32(dr.Cells[1].Value);
                AccountNumber.Text = dr.Cells[2].Value.ToString();
                AccountName.Text = dr.Cells[3].Value.ToString();
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
            frmLoanInsuranceFeePaymentRecord frm = new frmLoanInsuranceFeePaymentRecord();
            frm.label4.Text = label7.Text;
            frm.label5.Text = label12.Text;
            frm.ShowDialog();
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
                    companyaddress = rdr.GetString(7).Trim();
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
      
        string savingsids = null;
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from Savings  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpPaymentDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from Savings ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpPaymentDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SA-" + days + realid;
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
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please select mode of payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (Duepayment.Text != "0")
            {
                MessageBox.Show("Pay this fee in not more than two installments for better accounts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNumber.Text + "' and Approval='Approved' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountbalance.Text = (Convert.ToInt32(Convert.ToDouble(rdr["Accountbalance"])) - Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Value))).ToString();
                   
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    //return;
                }
                else
                {
                    accountbalance.Text = (0 - Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Text))).ToString();
                  
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select LoanID from LoanInsuranceFees where LoanID= '" + cmbStaffID.Text + "' ";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Loan Already Paid for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                auto2();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,DepositDate,Debit,Approval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Approved')";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 100, "Transactions"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                cmd.Parameters["@d1"].Value = AccountNumber.Text;
                cmd.Parameters["@d2"].Value = savingsids;
                cmd.Parameters["@d3"].Value = staffname.Text;
                cmd.Parameters["@d4"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d5"].Value = txtTotalPaid.Value;
                cmd.Parameters["@d6"].Value = accountbalance.Text;
                cmd.Parameters["@d7"].Value = "Paid Loan Insurance Fees";
                cmd.Parameters["@d8"].Value = "Transfer";
                cmd.Parameters["@d9"].Value = AccountName.Text;
                cmd.Parameters["@d10"].Value = staffname.Text;
                cmd.Parameters["@d11"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d12"].Value = txtTotalPaid.Value;
                cmd.ExecuteNonQuery();
                con.Close();
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into LoanInsuranceFees(PaymentID,LoanID,MemberID,Year,Months,Date,InsuranceAmmount,CashierName,Duepayment) VALUES (@d1,@d9,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "InsuranceAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Duepayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                cmd.Parameters["@d2"].Value = txtStaffName.Value;
                cmd.Parameters["@d3"].Value = Year.Text; 
                cmd.Parameters["@d4"].Value = months.Text;
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text; 
                cmd.Parameters["@d6"].Value = Convert.ToInt32(txtTotalPaid.Value); 
                cmd.Parameters["@d7"].Value =staffname.Text;
                cmd.Parameters["@d8"].Value = Convert.ToInt32(Duepayment.Value);
                cmd.Parameters["@d9"].Value = cmbStaffID.Text;
                cmd.ExecuteReader();
                con.Close();

                //SqlDataReader rdr = null;
                /*int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount + Convert.ToInt32(txtTotalPaid.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dtpPaymentDate.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();*/
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                frmLoanInsuranceFeesPayment frm2 = new frmLoanInsuranceFeesPayment();
                frm2.label7.Text = label7.Text;
                frm2.label12.Text = label12.Text;
                frm2.ShowDialog();
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
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from LoanInsuranceFees where  PaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters["@DELETE1"].Value = txtPaymentID.Text;
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

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update LoanInsuranceFees set MemberID=@d2,Date=@d5,Months=@d4,Year=@d3,CashierName=@d7,InsuranceAmmount=@d6,Duepayment=@d8 where PaymentID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "InsuranceAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Duepayment"));
                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                cmd.Parameters["@d3"].Value = Year.Text;
                cmd.Parameters["@d4"].Value = months.Text;
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d6"].Value = Convert.ToInt32(txtTotalPaid.Value);
                cmd.Parameters["@d7"].Value = staffname.Text;
                cmd.Parameters["@d8"].Value = Convert.ToInt32(Duepayment.Value);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStaffID()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(LoanID) FROM Loan where Issued='Pending'", CN);
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

        private void buttonX6_Click(object sender, EventArgs e)
        {
            /*try
            {
                this.Hide();
               Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptLoanProcessingFeeSlip rpt = new rptLoanProcessingFeeSlip(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                ARegistration myDS = new ARegistration(); //The DataSet you created.
                FrmLoanProcessingFeeSlip frm = new FrmLoanProcessingFeeSlip();
                frm.label1.Text = label7.Text;
                frm.label2.Text = label12.Text;
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from LoanInsuranceFees where PaymentID='" + txtPaymentID.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "LoanInsuranceFees");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

       
        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDeduction_TextChanged(object sender, EventArgs e)
        {

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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoanInsurance='Yes'";
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

        private void txtTotalPaid_Validating(object sender, CancelEventArgs e)
        {
           
            
        }

        private void cmbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string howto = Properties.Settings.Default.Loaninsurancetype;
            if (howto == "Figure")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT LoanAmount from Loan WHERE LoanID = '" + cmbStaffID.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtStaffName.Value = rdr.GetInt32(0);
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
            else if (howto == "Percentage")
            {
                try
                {
                    int val8 = 0;
                    int val7 = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct1 = "select LoanAmount from Loan where LoanID= '" + cmbStaffID.Text + "' order by ID DESC";
                    cmd = new SqlCommand(ct1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        string loanammount = rdr["LoanAmount"].ToString();

                        val7 = Convert.ToInt32(loanammount);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        // return;
                    }
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select InsurancePercentage from LoanInsurance order by ID DESC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        string proseccingpercentage = rdr["InsurancePercentage"].ToString();

                        val8 = Convert.ToInt32(proseccingpercentage);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        // return;
                    }
                    con.Close();
                    double pervalue = val8 * 0.01;
                    int payablevalue = Convert.ToInt32(pervalue * val7);
                    txtBasicSalary.Value = payablevalue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbStaffID_TextChanged(object sender, EventArgs e)
        {
            string howto = Properties.Settings.Default.Loaninsurancetype;
            if (howto == "Figure")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT LoanAmount from Loan WHERE LoanID = '" + cmbStaffID.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtStaffName.Value = rdr.GetInt32(0);
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
            else if (howto == "Percentage")
            {
                try
                {
                    int val8 = 0;
                    int val7 = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct1 = "select LoanAmount from Loan where LoanID= '" + cmbStaffID.Text + "' order by ID DESC";
                    cmd = new SqlCommand(ct1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        string loanammount = rdr["LoanAmount"].ToString();

                        val7 = Convert.ToInt32(loanammount);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        // return;
                    }
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select InsurancePercentage from LoanInsurance order by ID DESC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        string proseccingpercentage = rdr["InsurancePercentage"].ToString();

                        val8 = Convert.ToInt32(proseccingpercentage);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        // return;
                    }
                    con.Close();
                    double pervalue = val8 * 0.01;
                    int payablevalue = Convert.ToInt32(pervalue * val7);
                    txtBasicSalary.Value = payablevalue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please select mode of payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (Duepayment.Text != "0")
            {
                MessageBox.Show("Pay this fee in not more than two installments for better accounts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select LoanID from LoanInsuranceFees where LoanID= '" + cmbStaffID.Text + "' ";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Loan Already Paid for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNumber.Text + "' and Approval='Approved' order by ID DESC";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountbalance.Text = (Convert.ToInt32(Convert.ToDouble(rdr["Accountbalance"])) - Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Value))).ToString();

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        //return;
                    }
                    else
                    {
                        accountbalance.Text = (0 - Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Text))).ToString();

                    }
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
                    string ct4 = "select LoanID from LoanInsuranceFees where LoanID= '" + cmbStaffID.Text + "' ";
                    cmd = new SqlCommand(ct4);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Loan Already Paid for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    con.Close();
                    auto2();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,DepositDate,Debit,Approval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Approved')";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 100, "Transactions"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Debit"));
                    cmd.Parameters["@d1"].Value = AccountNumber.Text;
                    cmd.Parameters["@d2"].Value = savingsids;
                    cmd.Parameters["@d3"].Value = staffname.Text;
                    cmd.Parameters["@d4"].Value = dtpPaymentDate.Text;
                    cmd.Parameters["@d5"].Value = txtTotalPaid.Value;
                    cmd.Parameters["@d6"].Value = accountbalance.Text;
                    cmd.Parameters["@d7"].Value = "Paid Loan Insurance Fees";
                    cmd.Parameters["@d8"].Value = "Transfer";
                    cmd.Parameters["@d9"].Value = AccountName.Text;
                    cmd.Parameters["@d10"].Value = staffname.Text;
                    cmd.Parameters["@d11"].Value = dtpPaymentDate.Text;
                    cmd.Parameters["@d12"].Value = txtTotalPaid.Value;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into LoanInsuranceFees(PaymentID,LoanID,MemberID,Year,Months,Date,InsuranceAmmount,CashierName,Duepayment) VALUES (@d1,@d9,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "InsuranceAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Duepayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                cmd.Parameters["@d2"].Value = txtStaffName.Value;
                cmd.Parameters["@d3"].Value = Year.Text;
                cmd.Parameters["@d4"].Value = months.Text;
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d6"].Value = Convert.ToInt32(txtTotalPaid.Value);
                cmd.Parameters["@d7"].Value = staffname.Text;
                cmd.Parameters["@d8"].Value = Convert.ToInt32(Duepayment.Value);
                cmd.Parameters["@d9"].Value = cmbStaffID.Text;
                if (txtDeduction.Text == "")
                {
                    txtDeduction.Text = "0";
                }
                cmd.ExecuteReader();
                con.Close();
                /*int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount + Convert.ToInt32(txtTotalPaid.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dtpPaymentDate.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();*/
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                company();
                try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    rptReceiptAll2 rpt = new rptReceiptAll2(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); //The DataSet you created.
                    Receipt frm = new Receipt();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from LoanInsuranceFees";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "LoanInsuranceFees");
                    //myDA.Fill(myDS, "Rights");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", txtPaymentID.Text);
                    rpt.SetParameterValue("accountno", cmbStaffID.Text);
                    rpt.SetParameterValue("membernames", txtStaffName.Value);
                    rpt.SetParameterValue("ammount", txtBasicSalary.Value);
                    rpt.SetParameterValue("totalpaid", txtTotalPaid.Value);
                    rpt.SetParameterValue("issuedby", staffname.Text);
                    rpt.SetParameterValue("Transactions", "Loan Insurance Fees Receipt");
                    rpt.SetParameterValue("addons", txtDeduction.Text);
                    rpt.SetParameterValue("duepayment", Duepayment.Value);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    myConnection.Close();
                    frm.ShowDialog();
                    //BarPrinter = Properties.Settings.Default.frontendprinter;
                    //rpt.PrintOptions.PrinterName = BarPrinter;
                    //rpt.PrintToPrinter(1, true, 1, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Hide();
                frmLoanInsuranceFeesPayment frm2 = new frmLoanInsuranceFeesPayment();
                frm2.label7.Text = label7.Text;
                frm2.label12.Text = label12.Text;
                frm2.ShowDialog();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select LoanID,Duepayment from LoanInsuranceFees where LoanID= '" + cmbStaffID.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label11.Text = rdr["Duepayment"].ToString();
                    int val4 = 0;
                    int val5 = 0;
                    int val6 = 0;
                    int.TryParse(label11.Text, out val4);
                    int.TryParse(txtDeduction.Text, out val5);
                    int.TryParse(txtTotalPaid.Value.ToString(), out val6);
                    int I = ((val4 + val5) - (val6));
                    Duepayment.Value = I;

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    // return;
                }
                else
                {
                    int val1 = 0;
                    int val2 = 0;
                    int val3 = 0;
                    int.TryParse(txtBasicSalary.Value.ToString(), out val1);
                    int.TryParse(txtDeduction.Text, out val2);
                    int.TryParse(txtTotalPaid.Value.ToString(), out val3);
                    int I = ((val1 + val2) - val3);
                    Duepayment.Value = I;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalPaid_Validating_1(object sender, CancelEventArgs e)
        {
            int val10 = Convert.ToInt32(txtTotalPaid.Value);
            int val11 = Convert.ToInt32(txtBasicSalary.Value);
            if (val10 < val11)
            {
                MessageBox.Show("Can Not pay less than Loan Insurance ammount", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotalPaid.Text = null;
                return;
            }
        }

        private void AccountNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNumber.Text + "' and Approval='Approved' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountbalance.Text = (Convert.ToInt32(Convert.ToDouble(rdr["Accountbalance"]))- Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Value))).ToString();
                    txtTotalPaid.Text = (Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Value))).ToString();
                    txtTotalPaid.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    accountbalance.Text = (0 - Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Text))).ToString();
                    txtTotalPaid.Text = (Convert.ToInt32(Convert.ToDouble(txtBasicSalary.Value))).ToString();
                    txtTotalPaid.Enabled = false;
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
