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
    public partial class frmShareToSavings : DevComponents.DotNetBar.Office2007Form
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
        string Savingsids = null;
        string sharecapitalids = null;
        public frmShareToSavings()
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
            txtBasicSalary.Text = "";
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
            txtPaymentID.Text = "STS-" + years + monthss + days + GetUniqueKey(5);
            sharecapitalids = "SC-" + years + monthss + days + GetUniqueKey(5);
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


        private void frmRegistrationFeesPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
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
            dynamic SelectQry = "SELECT RTRIM(RegistrationFees.MemberID)[Member ID], RTRIM(MemberName)[Member Name] from RegistrationFees  order by RegistrationFees.ID DESC ";
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
            frmShareToSavingsRecord frm = new frmShareToSavingsRecord();
            frm.label4.Text = label7.Text;
            frm.label5.Text = label12.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmShareToSavings frm = new frmShareToSavings();
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
            try
            {
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ShareCapital(PaymentID,MemberID,Year,Months,Date,DepositedAmmount,CashierName,CurrentTotalShares,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "DepositedAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CurrentTotalShares"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters["@d1"].Value = sharecapitalids;
                cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                cmd.Parameters["@d3"].Value = Year.Text; 
                cmd.Parameters["@d4"].Value = months.Text;
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text; 
                cmd.Parameters["@d6"].Value = Convert.ToInt32(-txtTotalPaid.Value); 
                cmd.Parameters["@d7"].Value =staffname.Text;
                cmd.Parameters["@d8"].Value = Convert.ToInt32(Duepayment.Value);
                cmd.Parameters["@d9"].Value = "Transfer";
                cmd.ExecuteReader();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb7 = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Credit,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                cmd = new SqlCommand(cb7);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "Transactions"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Credit"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "Approval"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters["@d1"].Value = Savingsids;
                cmd.Parameters["@d2"].Value = txtBasicSalary.Text;
                cmd.Parameters["@d3"].Value = txtStaffName.Text;
                cmd.Parameters["@d4"].Value = staffname.Text.Trim();
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text.Trim();
                cmd.Parameters["@d6"].Value = txtTotalPaid.Value;
                cmd.Parameters["@d7"].Value = totalsavings.Value;
                cmd.Parameters["@d8"].Value = "Transfer";
                cmd.Parameters["@d9"].Value = "Shares to Savings Transfer";
                cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                cmd.Parameters["@d11"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d12"].Value = txtTotalPaid.Value;
                cmd.Parameters["@d13"].Value = "Approved";
                cmd.Parameters["@d14"].Value = staffname.Text;
                cmd.ExecuteNonQuery();
                con.Close();
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb3 = "insert into SharesToSavings(PaymentID,MemberID,Year,Months,Date,TransferedAmmount,CashierName,AccountNumber,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "DepositedAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters["@d1"].Value = sharecapitalids;
                cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                cmd.Parameters["@d3"].Value = Year.Text;
                cmd.Parameters["@d4"].Value = months.Text;
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d6"].Value = Convert.ToInt32(txtTotalPaid.Value);
                cmd.Parameters["@d7"].Value = staffname.Text;
                cmd.Parameters["@d8"].Value = txtBasicSalary.Text;
                cmd.Parameters["@d9"].Value = "Transfer";
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                company();
               /* try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    rptReceiptAll rpt = new rptReceiptAll(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    AllPaymentsDataset myDS = new AllPaymentsDataset(); //The DataSet you created.
                    Receipt frm = new Receipt();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from AnnualFeesPayment";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "AnnualFeesPayment");
                    //myDA.Fill(myDS, "Rights");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", txtPaymentID.Text);
                    rpt.SetParameterValue("accountno", cmbStaffID.Text);
                    rpt.SetParameterValue("membernames", txtStaffName.Text);
                    rpt.SetParameterValue("ammount", txtBasicSalary.Text);
                    rpt.SetParameterValue("totalpaid", txtTotalPaid.Text);
                    rpt.SetParameterValue("issuedby", staffname.Text);
                    rpt.SetParameterValue("Transactions", "Share Capital Fees Receipt");
                    rpt.SetParameterValue("addons", 0);
                    rpt.SetParameterValue("duepayment", Duepayment.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.Show();
                    //rpt.PrintToPrinter(1, true, 1, 1);
                    //frm.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                this.Hide();
                frmShareToSavings frm2 = new frmShareToSavings();
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
                string cq = "delete  from ShareCapital where  PaymentID=@DELETE1;";
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
                string cb = "update ShareCapital set MemberID=@d2,Date=@d5,Months=@d4,Year=@d3,CashierName=@d7,DepositedAmmount=@d6,CurrentTotalShares=@d8 where PaymentID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "DepositedAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CurrentTotalShares"));
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
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(MemberID) FROM RegistrationFees", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbStaffID.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbStaffID.Items.Add(drow[0].ToString());
                }
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
                this.Hide();
               Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptShareCapitalSlip rpt = new rptShareCapitalSlip(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet(); //The DataSet you created.
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
                frm.Show();
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

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AccountNumber from Account WHERE AccountNumber = '" + cmbStaffID.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBasicSalary.Text = (rdr.GetString(0).Trim());
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

        private void txtTotalPaid_Validating(object sender, CancelEventArgs e)
        {
            /*if((int.Parse(txtTotalPaid.Text))<(int.Parse(txtBasicSalary.Text))){
                MessageBox.Show("Can Not pay less than Minimum Share Ammount", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotalPaid.Text="";
            }
            if(txtTotalPaid.Text==""){
                txtTotalPaid.Focus();
                return;
            }*/
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

        private void txtTotalPaid_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select MemberID,CurrentTotalShares from ShareCapital where MemberID= '" + cmbStaffID.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label11.Text = rdr["CurrentTotalShares"].ToString();
                    int val4 = 0;
                    int val6 = 0;
                    int.TryParse(label11.Text, out val4);
                    int.TryParse(txtTotalPaid.Value.ToString(), out val6);
                    if (val4 != 0)
                    {
                        int I = ((val4 - val6));
                        Duepayment.Value = I;
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    //return;
                }
                else
                {
                    int val3 = 0;
                    int.TryParse(txtTotalPaid.Value.ToString(), out val3);
                    int I = val3;
                    Duepayment.Value = I;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AccountNo,Accountbalance from Savings where AccountNo= '" + txtBasicSalary.Text + "' and Approval='Approved' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label14.Text = rdr["Accountbalance"].ToString();
                    int val4 = 0;
                    int val6 = 0;
                    int.TryParse(label14.Text, out val4);
                    int.TryParse(txtTotalPaid.Value.ToString(), out val6);
                    if (val4 != 0)
                    {
                        int I = ((val4 + val6));
                        totalsavings.Value = I;
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    int val3 = 0;
                    int.TryParse(txtTotalPaid.Value.ToString(), out val3);
                    int I = val3;
                    totalsavings.Value = I;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStaffID_TextChanged(object sender, EventArgs e)
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

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AccountNumber from Account WHERE AccountNumber = '" + cmbStaffID.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBasicSalary.Text = (rdr.GetString(0).Trim());
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

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
