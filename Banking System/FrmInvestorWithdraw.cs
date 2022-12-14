using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Net;
namespace Banking_System
{
    public partial class FrmInvestorWithdraw : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmInvestorWithdraw()
        {
            InitializeComponent();
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
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from InvestorWithdraw  Order By ID DESC",con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestorWithdraw ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsid.Text = "IW-"  + days +realid;
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNames) FROM InvestorAccount", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                accountnumber.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    accountnumber.Items.Add(drow[0].ToString());
                }
                CN.Close();
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
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInvestorWithdraw frm = new FrmInvestorWithdraw();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
    
        private void buttonX5_Click(object sender, EventArgs e)
        {
            auto2();
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (depositammount.Text == "")
            {
                MessageBox.Show("Please enter Deposited ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositammount.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
                return;
            }
            if (withdrawtype.Text == "")
            {
                MessageBox.Show("Please Select Withdraw Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                withdrawtype.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into InvestorWithdraw(SavingsID,AccountNo,AccountName,CashierName,Date,Amount,WithdrawID,WithdrawType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,'"+ withdrawtype.Text+ "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "WithdrawID"));

                cmd.Parameters["@d1"].Value = investmentid.Text.Trim();
                cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d3"].Value = accountname.Text;
                cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d5"].Value = date2.Text.Trim();
                cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                cmd.Parameters["@d7"].Value = savingsid.Text;
                cmd.ExecuteNonQuery();
                con.Close();
              
                MessageBox.Show("Successfully saved", "Investor Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            FrmInvestorWithdraw frm2 = new FrmInvestorWithdraw();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
       
        private void buttonX7_Click(object sender, EventArgs e)
        {
            
        }

        private void frmSavings_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }
        private void cashierid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName FROM Rights WHERE AuthorisationID = '" + cashierid.Text + "' and Category='Cashier'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cashiername.Text = rdr.GetString(0).Trim();
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

        private void accountnumber2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(AccountNames) FROM Account where AccountNumber='" + accountnumber.Text + "'";
                rdr = cmd.ExecuteReader();
                accountname.Text = "";
                if (rdr.Read())
                {
                    accountname.Text = rdr.GetString(0).Trim();
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
        private void depositammount_ValueChanged(object sender, EventArgs e)
        {
            groupPanel3.Enabled = true;
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
        private void cashierid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(cashierid.Text, "essentialfinance");
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and InvestorDeposit='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        cashiername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        cashiername.Text = "";
                    }
                }
                else
                {
                    cashiername.Text = "";
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
        private void depositammount_ValueChanged_1(object sender, EventArgs e)
        {
            try {
               
                    if (depositammount.Text == "") { }
                    else
                    {
                    if (withdrawtype.Text == "Interest Only")
                    {
                        if (depositammount.Value > interestearned.Value)
                        {
                            MessageBox.Show("you can not withdraw more than interest Earned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Hide();
                        }
                    }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        int val4 = 0;
                        int val5 = 0;
                        string ct2 = "select Accountbalance from InvestorSavings where  AccountNo= '" + accountnumber.Text + "' and SavingsID='" + investmentid.Text + "' ";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr2 = cmd.ExecuteReader();
                        if (rdr2.Read())
                        {
                            string Accbalance = rdr2["Accountbalance"].ToString();
                            val4 = Convert.ToInt32(Accbalance);
                            int.TryParse(depositammount.Value.ToString(), out val5);
                            accountbalance.Value = (val4 - val5);
                            if ((rdr2 != null))
                            {
                                rdr2.Close();
                            }
                        }
                        else
                        {
                            int val1 = 0;
                            int.TryParse(depositammount.Value.ToString(), out val1);
                            accountbalance.Value = (0 - val1);
                        }
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            auto2();
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (depositammount.Text == "")
            {
                MessageBox.Show("Please enter Deposited ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositammount.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            if (submittedby.Text == "")
            {
                MessageBox.Show("Please Enter Payer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submittedby.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Savings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,DepositDate,Debit) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "Transactions"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "Debit"));
                cmd.Parameters["@d1"].Value = savingsid.Text.Trim();
                cmd.Parameters["@d2"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d3"].Value = accountname.Text;
                cmd.Parameters["@d4"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d5"].Value = date2.Text.Trim();
                cmd.Parameters["@d6"].Value = Convert.ToInt32(depositammount.Value);
                cmd.Parameters["@d7"].Value = accountbalance.Value;
                cmd.Parameters["@d8"].Value = submittedby.Text;
                cmd.Parameters["@d9"].Value = "Withdraw";
                cmd.Parameters["@d10"].Value = cmbModeOfPayment.Text;
                cmd.Parameters["@d11"].Value = dateTimePicker1.Text;
                cmd.Parameters["@d12"].Value = "DR";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Savings Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                company();
                try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    rptReceiptWithdraw rpt = new rptReceiptWithdraw(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); //The DataSet you created.
                    Receipt frm = new Receipt();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from Expenses";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Expenses");
                    //myDA.Fill(myDS, "Rights");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", savingsid.Text);
                    rpt.SetParameterValue("accountno", accountnumber.Text);
                    rpt.SetParameterValue("membernames", accountname.Text);
                    rpt.SetParameterValue("ammount", depositammount.Value);
                    rpt.SetParameterValue("totalpaid", accountbalance.Value);
                    rpt.SetParameterValue("issuedby", cashiername.Text);
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
                    //this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                buttonX5.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            FrmInvestorWithdraw frm2 = new FrmInvestorWithdraw();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
        private void accountnumber2_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            this.accountnumber.Text = frm.clientnames.Text;
            this.accountname.Text = frm.Accountnames.Text;
            return;
        }

        private void membername2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select SavingsID from InvestorSavings where  AccountNo= '" + accountnumber.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    while (rdr2.Read())
                    {
                    investmentid.Items.Add(rdr2["SavingsID"].ToString());   
                    }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void investmentid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void withdrawtype_TextChanged(object sender, EventArgs e)
        {
            if (withdrawtype.Text == "Whole Amount")
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select Accountbalance from InvestorSavings where  SavingsID= '" +investmentid.Text + "' and OtherMaturityDate <=@date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = dateTimePicker1.Value.Date;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        accountbalance.Value = Convert.ToInt32(rdr2["Accountbalance"]);
                    }
                    else
                    {
                        MessageBox.Show("Investment has not yet Matured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                        FrmInvestorWithdraw frm = new FrmInvestorWithdraw();
                        frm.label1.Text = label1.Text;
                        frm.label2.Text = label2.Text;
                        frm.ShowDialog();
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (withdrawtype.Text == "Interest Only")
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select AppreciationAmount from InvestmentAppreciation where  SavingsID= '" + investmentid.Text + "' and Freezed='No' and Approved='Approved' and PaidOut='Pending'", con);
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select SUM(AppreciationAmount) from InvestmentAppreciation where SavingsID= '" + investmentid.Text + "' and Freezed='No' and Approved='Approved' and PaidOut='Pending'", con);
                        interestearned.Value = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Investment has not yet earned anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                        FrmInvestorWithdraw frm = new FrmInvestorWithdraw();
                        frm.label1.Text = label1.Text;
                        frm.label2.Text = label2.Text;
                        frm.ShowDialog();
                    }
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select Accountbalance from InvestorSavings where  SavingsID= '" + investmentid.Text + "' ", con);
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        accountbalance.Value = Convert.ToInt32(rdr2["Accountbalance"]);
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
}
