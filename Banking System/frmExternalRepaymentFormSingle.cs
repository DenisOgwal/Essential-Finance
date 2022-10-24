using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;
using System.IO;
namespace Banking_System
{
    public partial class frmExternalRepaymentFormSingle : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        SqlDataAdapter adp;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;

        public frmExternalRepaymentFormSingle()
        {
            InitializeComponent();
        }

        private void frmRepaymentForm_Load(object sender, EventArgs e)
        {
           // loanids();
            
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(Months)[Installment],RTRIM(BalanceExist)[Amount Payable] from ExternalRepaymentSchedule WHERE PaymentDate <=@date1 and BalanceExist>0 order by ID Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridView1.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
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
        string numberphone = null;
        string messages = null;
        public void sendmessage()
        {

            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM MemberRegistration where MemberID='" + Lender.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        numberphone = rdr.GetString(0).Trim();
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    string usernamess = Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                   
                    string numbers = "+256" + numberphone;
                    messages = ammountpaid.Text + " Has been paid for clearing Whole of your Loan " + loanid.Text + " and a balance of " + balance.Text + " is left for this installment";
                    WebClient client = new WebClient();
                    string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username="+usernamess+"&password="+passwordss+"&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                    client.OpenRead(baseURL);
                    MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Internet Connection, The message was not sent");
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
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            repaymentid.Text = "EPD-" + years + monthss + days + GetUniqueKey(5);
        }
        string paymentstatus = "Paid";
        //int TotalInterest = 0;
        //int totalaamount = 0;
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
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (ammountpaid.Text == "")
            {
                MessageBox.Show("Please enter ammount paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ammountpaid.Focus();
                return;
            }
            if (balance.Text == "")
            {
                MessageBox.Show("Please enter balance ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                balance.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please Enter Cashier name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please Select Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            auto();
            try
            {

                try
                {
                    
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into ExternalLoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,LoanID,PaidBy,Repaymentdate,Interest,TotalAmmount,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "PaidBy"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "Interest"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters["@d1"].Value = repaymentid.Text.Trim();
                    cmd.Parameters["@d2"].Value = Convert.ToInt32(ammountpaid.Value);
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(balance.Value);
                    cmd.Parameters["@d4"].Value = "All";
                    cmd.Parameters["@d5"].Value = loanid.Text.Trim();
                    cmd.Parameters["@d6"].Value = cashiername.Text.Trim();
                    cmd.Parameters["@d7"].Value = dateTimePicker1.Text;
                    cmd.Parameters["@d8"].Value =Convert.ToInt32(Convert.ToDouble(label3.Text));
                    cmd.Parameters["@d9"].Value =0;
                    cmd.Parameters["@d10"].Value =cmbModeOfPayment.Text;
                    //cmd.ExecuteNonQuery();
                    buttonX2.Enabled = false;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string updateid = "";
                try
                {
                    SqlDataReader rdr = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select TOP(1) Interest,AmmountPay,ID from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID Asc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        updateid = rdr[2].ToString();
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update ExternalRepaymentSchedule set Interest=0,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and PaymentStatus='Pending' ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Float, 15, "BalanceExist"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters["@d1"].Value = paymentstatus;
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.Parameters["@d3"].Value = 0;
                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text.Trim();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb6 = "update ExternalRepaymentSchedule set PaymentStatus=@d1 where LoanID=@d2";
                    cmd = new SqlCommand(cb6);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@d1"].Value = paymentstatus;
                    cmd.Parameters["@d2"].Value = loanid.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    double realintrest = Convert.ToDouble(label3.Text);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb5 = "update ExternalRepaymentSchedule set Interest=@d3,EarlySettlementCharge=@d4 where ID=@d2";
                    cmd = new SqlCommand(cb5);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "ID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Float, 15, "Interest"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 15, "EarlySettlementCharge"));
                    cmd.Parameters["@d2"].Value = updateid;
                    cmd.Parameters["@d3"].Value = realintrest;
                    cmd.Parameters["@d4"].Value = earlysettlement.Value;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    int totalaamount = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                        int newtotalammount = totalaamount - Convert.ToInt32(ammountpaid.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dateTimePicker1.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                    MessageBox.Show("Successfully Saved", "Repayment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     /*string smsallow = Properties.Settings.Default.smsallow;
                     if (smsallow == "Yes")
                     {
                         sendmessage();
                     }*/
                  
                    buttonX2.Enabled = true;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmExternalRepaymentFormSingle frm2 = new frmExternalRepaymentFormSingle();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
           
        }

        private void ammountpaid_ValueChanged(object sender, EventArgs e)
        {
            try {
                balance.Value = (Convert.ToInt32(Convert.ToDouble(label5.Text))+earlysettlement.Value) - ammountpaid.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalRepaymentFormSingle frm = new frmExternalRepaymentFormSingle();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
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
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ExternalRepayments='Yes'";
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

        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails6 frm = new frmClientDetails6();
            frm.ShowDialog();
            this.loanid.Text = frm.clientnames.Text;
            this.Lender.Text = frm.Accountnames.Text;
            return;
        }
        string interrestmethod = null;
        int pendingpayment = 0;
        int TotalPrincipal = 0;
        int totalbalanceexist = 0;
        int intrestearned = 0;
        int realloanfine = 0;

        private void loanid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Method from ExternalLoans where LoansID= '" + loanid.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    interrestmethod = rdr[0].ToString().Trim();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Lender from ExternalLoans where LoansID= '" + loanid.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                Lender.Text = "";
                if (rdr.Read())
                {
                    Lender.Text = rdr[0].ToString().Trim();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
            if (interrestmethod == "Reducing Balance")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentDate <= @date1 and BalanceExist > 0", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentDate <= @date1 and BalanceExist > 0";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                        totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(Interest) FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                        intrestearned = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and PaymentDate > @date1";
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    TotalPrincipal = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                int TotalIntrests = 0;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT TOP (1) Interest FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID ASC";
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                    label3.Text = TotalIntrests.ToString();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    ///MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int realintrest = 0;
                int totalrealintrest = 0;
                try
                {
                    int ids = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select ID from ExternalRepaymentSchedule where PaymentDate <= @date1 and LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' order by ID Desc", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ids = Convert.ToInt32(rdr[0]) + 1;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "select PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC ";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string paymentdate = rdr[0].ToString();
                            string loantype = rdr[1].ToString().Trim();
                            if (loantype == "Daily")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddDays(-1).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 0)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }
                            }
                            else if (loantype == "Weekly")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddDays(-7).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }
                            }
                            else if (loantype == "Monthly")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddMonths(-1).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }

                            }
                            else
                            {
                                // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending'  order by ID Desc ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                string paymentdate = rdr[0].ToString();
                                string loantype = rdr[1].ToString().Trim();
                                if (loantype == "Daily")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(0).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 0)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Weekly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(0).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Monthly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddMonths(0).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }

                                }
                                else
                                {
                                    // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            con.Close();
                        }
                        con.Close();
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending'  order by ID Desc ";
                        cmd = new SqlCommand(ct6);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string paymentdate = rdr[0].ToString();
                            string loantype = rdr[1].ToString().Trim();
                            if (loantype == "Daily")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddDays(-1).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 0)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }
                            }
                            else if (loantype == "Weekly")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddDays(-7).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }
                            }
                            else if (loantype == "Monthly")
                            {
                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                string realdate = startdate.AddMonths(-1).ToShortDateString();
                                DateTime dt = DateTime.Parse(realdate);
                                DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = realintrest * daysbetween;
                                }
                                else
                                {
                                    totalrealintrest = 0;
                                }

                            }
                            else
                            {
                                // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        con.Close();
                    }

                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int duebal = totalrealintrest + TotalPrincipal + totalbalanceexist + realloanfine;
                int duebals = 0;

                int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                if (result > 500)
                {
                    duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                }
                else if (result < 500 && result > 0)
                {
                    duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                }
                else
                {
                    duebals = duebal;
                }
                balance.Value = (duebals);
                label4.Text = balance.Value.ToString();
                label3.Text = (totalrealintrest + intrestearned).ToString();
                label5.Text = balance.Value.ToString();
                label6.Text = (pendingpayment + totalbalanceexist).ToString();
                label7.Text = (totalrealintrest + intrestearned).ToString();
            }
            else if (interrestmethod == "Flat Rate")
            {
                SqlDataReader rdr = null;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentDate <= @date1 and BalanceExist > 0", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentDate <= @date1 and BalanceExist > 0";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                        totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(Interest) FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                        intrestearned = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int ids = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select ID from ExternalRepaymentSchedule where PaymentDate <= @date1 and LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' order by ID Desc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    // twhen this is not the last installment
                    ids = Convert.ToInt32(rdr[0]) + 1;
                    //MessageBox.Show(ids.ToString());
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    //cmd = con.CreateCommand();
                    string ct2 = "SELECT  Interest,AmmountPay FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID DESC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int realintrest = 0;
                        int totalrealintrest = 0;
                        int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                        int principals = Convert.ToInt32(Convert.ToDouble(rdr[1]));
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct4 = "select PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID DESC ";
                            cmd = new SqlCommand(ct4);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                string paymentdate = rdr[0].ToString();
                                string loantype = rdr[1].ToString().Trim();
                                if (loantype == "Daily")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(-1).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 0)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Weekly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(-7).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Monthly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                    // MessageBox.Show(realintrest.ToString());
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddMonths(-1).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                    //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {

                            }

                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        int duebal = principals + totalrealintrest + realloanfine + totalbalanceexist;
                        int duebals = 0;
                        label7.Text = (intrestearned + totalrealintrest).ToString();

                        int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                        if (result > 500)
                        {
                            duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                        }
                        else if (result < 500 && result > 0)
                        {
                            duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                        }
                        else
                        {
                            duebals = duebal;
                        }
                        balance.Value = (duebals);
                        label4.Text = balance.Value.ToString();
                        label5.Text = balance.Value.ToString();
                        label6.Text = balance.Value.ToString();
                        label3.Text = (intrestearned + totalrealintrest).ToString();
                        label7.Text = (intrestearned + totalrealintrest).ToString();
                        con.Close();
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        //cmd = con.CreateCommand();
                        string ct6 = "SELECT  TOP (1) Interest,AmmountPay FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID DESC";
                        cmd = new SqlCommand(ct6);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            int realintrest = 0;
                            int totalrealintrest = 0;
                            int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                            int principals = Convert.ToInt32(Convert.ToDouble(rdr[1]));
                            try
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' order by ID DESC ";
                                cmd = new SqlCommand(ct4);
                                cmd.Connection = con;
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    string paymentdate = rdr[0].ToString();
                                    //MessageBox.Show(rdr[0].ToString());
                                    string loantype = rdr[1].ToString().Trim();
                                    if (loantype == "Daily")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(0).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 0)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Weekly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(0).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Monthly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                        //MessageBox.Show(realintrest.ToString());
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddMonths(0).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                        //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            int duebal = totalrealintrest + realloanfine + totalbalanceexist;
                            int duebals = 0;
                            label7.Text = (intrestearned + totalrealintrest).ToString();

                            int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                            if (result > 500)
                            {
                                duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                            }
                            else if (result < 500 && result > 0)
                            {
                                duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                            }
                            else
                            {
                                duebals = duebal;
                            }
                            balance.Value = (duebals);
                            label4.Text = balance.Value.ToString();
                            label5.Text = balance.Value.ToString();
                            label6.Text = balance.Value.ToString();
                            label3.Text = (intrestearned + totalrealintrest).ToString();
                            label7.Text = (intrestearned + totalrealintrest).ToString();
                            con.Close();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    //cmd = con.CreateCommand();
                    string ct2 = "SELECT  TOP (1) Interest,AmmountPay FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID DESC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int realintrest = 0;
                        int totalrealintrest = 0;
                        int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                        int principals = Convert.ToInt32(Convert.ToDouble(rdr[1]));
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from ExternalRepaymentSchedule where LoanID= '" + loanid.Text + "' and PaymentStatus='Pending' order by ID DESC";
                            cmd = new SqlCommand(ct4);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                string paymentdate = rdr[0].ToString();
                                string loantype = rdr[1].ToString().Trim();
                                if (loantype == "Daily")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(-1).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 0)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Weekly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddDays(-7).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                }
                                else if (loantype == "Monthly")
                                {
                                    realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                    DateTime startdate = DateTime.Parse(paymentdate).Date;
                                    string realdate = startdate.AddMonths(-1).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    DateTime currentdate = DateTime.Parse(dateTimePicker1.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = realintrest * daysbetween;
                                    }
                                    else
                                    {
                                        totalrealintrest = 0;
                                    }
                                    //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    // MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        int duebal = principals + totalrealintrest + realloanfine + totalbalanceexist;
                        int duebals = 0;
                        label7.Text = (intrestearned + totalrealintrest).ToString();

                        int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                        if (result > 500)
                        {
                            duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                        }
                        else if (result < 500 && result > 0)
                        {
                            duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                        }
                        else
                        {
                            duebals = duebal;
                        }
                        balance.Value = (duebals);
                        label4.Text = balance.Value.ToString();
                        label5.Text = balance.Value.ToString();
                        label6.Text = balance.Value.ToString();
                        label3.Text = (intrestearned + totalrealintrest).ToString();
                        label7.Text = (intrestearned + totalrealintrest).ToString();
                        con.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                loanid.Text = dr.Cells[0].Value.ToString();
                balance.Text = dr.Cells[2].Value.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBoxEx1.Text == "Interest Only")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Interest from ExternalLoanRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    balance.Value = Convert.ToInt32(Convert.ToDouble(rdr["Interest"]));
                }
                con.Close();
            }else if(comboBoxEx1.Text == "Principal Only")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AmmountPay from ExternalLoanRepaymentSchedule where  LoanID= '" + loanid.Text + "' and Months='" + repaymonths.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    balance.Value = Convert.ToInt32(Convert.ToDouble(rdr["AmmountPay"]));
                }
                con.Close();
            }
            else if (comboBoxEx1.Text == "Early Settlement")
            {*/
                int TotalPrincipal = 0;
                int pendingpayment = 0;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM ExternalExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending'";
                    TotalPrincipal = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum FROM ExternalExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending'";
                    pendingpayment = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int TotalIntrests = 0;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT TOP (1) Interest FROM ExternalRepaymentSchedule where LoanID='" + loanid.Text + "' and PaymentStatus='Pending' order by ID ASC";
                    TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                    label3.Text = TotalIntrests.ToString();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    ///MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                balance.Value = (TotalIntrests + TotalPrincipal );
            //}
        }

        private void loanid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void earlysettlement_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (earlysettlement.Text == "")
                {

                }
                else
                {
                    int realbalance = Convert.ToInt32(label5.Text);
                    balance.Value = realbalance + earlysettlement.Value;
                }
            }
            catch (Exception)
            {
                ///MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
