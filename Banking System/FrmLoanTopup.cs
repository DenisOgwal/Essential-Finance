using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanTopup : DevComponents.DotNetBar.Office2007RibbonForm
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
        int[] monthscount = new int[100];
        double principal = 0.00;
        double interest = 0.00;
        double repaymentammount = 0;
        string repaymentmonths = null;
        string repaymentdate = null;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmLoanTopup()
        {
            InitializeComponent();
        }
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select ID from Loan Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(ID) from Loan", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string convertedid = "";
            if (realid < 10)
            {
                convertedid = "00" + realid;
            }
            else if (realid < 100)
            {
                convertedid = "0" + realid;
            }
            else
            {
                convertedid = "" + realid;
            }
            string years = yearss.Substring(2, 2);
            LoanID.Text = "LT" + years + monthss + days + convertedid;
        }
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select ID from Loan Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(ID) from Loan", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 2;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string convertedid = "";
            if (realid < 10)
            {
                convertedid = "00" + realid;
            }
            else if (realid < 100)
            {
                convertedid = "0" + realid;
            }
            else
            {
                convertedid = "" + realid;
            }
            string years = yearss.Substring(2, 2);
            LoanID.Text = "LT" + years + monthss + days + convertedid;
        }
        private void auto3()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select ID from Loan Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(ID) from Loan", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string convertedid = "";
            if (realid < 10)
            {
                convertedid = "00" + realid;
            }
            else if (realid < 100)
            {
                convertedid = "0" + realid;
            }
            else
            {
                convertedid = "" + realid;
            }
            string years = yearss.Substring(2, 2);
            LoanID.Text = "LT" + years + monthss + days + convertedid;
        }
        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TOP (200) RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID] from Loan where  Issued='Yes' and IssueNo ='New' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Loan");
                dataGridView1.DataSource = myDataSet.Tables["Loan"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                AccountNumber.Text = dr.Cells[0].Value.ToString();
                AccountName.Text = dr.Cells[1].Value.ToString();
                label16.Text = dr.Cells[2].Value.ToString();
                LoanID.Text = dr.Cells[2].Value.ToString();
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanTopup frm = new FrmLoanTopup();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansApplication='Yes'";
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
        double begginingbalance = 0;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (AccountNumber.Text == "")
            {
                MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountNumber.Focus();
                return;
            }
            if (AccountName.Text == "")
            {
                MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountName.Focus();
                return;
            }
            if (ApprovalName.Text == "")
            {
                MessageBox.Show("Please Enter Correct Approval ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ApprovalID.Focus();
                return;
            }
            if (ServicingPeriod.Text == "")
            {
                MessageBox.Show("Please Fill Servicing Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ServicingPeriod.Focus();
                return;
            }
            if (RepaymentInterval.Text == "")
            {
                MessageBox.Show("Please Select Repayment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RepaymentInterval.Focus();
                return;
            }
            if (InterestRate.Text == "")
            {
                MessageBox.Show("Please Fill Interest Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterestRate.Focus();
                return;
            }
            if (AmortisationMethod.Text == "")
            {
                MessageBox.Show("Please Select Ammortisation Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AmortisationMethod.Focus();
                return;
            }
            if (TopupAmount.Text == "")
            {
                MessageBox.Show("Please Add Topup Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TopupAmount.Focus();
                return;
            }
            auto();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string kt = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                cmd = new SqlCommand(kt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    auto2();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt3 = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                    cmd = new SqlCommand(kt3);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        auto3();
                    }
                    else
                    {
                        auto();
                    }
                    con.Close();
                }
                else
                {
                    auto();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Loan(AccountNo,AccountName,LoanID,ServicingPeriod,RepaymentInterval,Interest,Collateral,CollateralValue,RefereeName,RefereeTel,RefereeAddress,RefereeRelationship,ApplicationDate,LoanAmount,IssueType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "ServicingPeriod"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "RepaymentInterval"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 30, "Interest"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "Collateral"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "CollateralValue"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "RefereeName"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "RefereeTel"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "RefereeAddress"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 30, "RefereeRelationship"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "ApplicationDate"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "LoanAmount"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "IssueType"));
                cmd.Parameters["@d1"].Value = AccountNumber.Text;
                cmd.Parameters["@d2"].Value = AccountName.Text;
                cmd.Parameters["@d3"].Value = LoanID.Text;
                cmd.Parameters["@d4"].Value = ServicingPeriod.Text;
                cmd.Parameters["@d5"].Value = RepaymentInterval.Text;
                cmd.Parameters["@d6"].Value = InterestRate.Value;
                cmd.Parameters["@d7"].Value = label16.Text;
                cmd.Parameters["@d8"].Value = Amount.Value;
                cmd.Parameters["@d9"].Value = label16.Text;
                cmd.Parameters["@d10"].Value = label16.Text;
                cmd.Parameters["@d11"].Value = label16.Text;
                cmd.Parameters["@d12"].Value = "Topup";
                cmd.Parameters["@d13"].Value = ApplicationDate.Text;
                cmd.Parameters["@d14"].Value = TotalAmount.Value;
                cmd.Parameters["@d15"].Value = AmortisationMethod.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (AmortisationMethod.Text.ToString().Trim() == "Flat Rate")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= ServicingPeriod.Value)
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= ServicingPeriod.Value; i++)
                    {
                        if (RepaymentInterval.Text.ToString().Trim() == "Monthly")
                        {
                            repaymentmonths = monthscount[i] + "Months";
                            repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.ToString().Trim() == "Daily")
                        {
                            repaymentmonths = monthscount[i] + "Day";
                            repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.ToString().Trim() == "Weekly")
                        {
                            repaymentmonths = monthscount[i] + "Week";
                            repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(TotalAmount.Value.ToString(), out val1);
                        principal = val1;
                        interest = ((Convert.ToDouble(InterestRate.Value) / (100)) * val1);
                        if (i == ServicingPeriod.Value)
                        {
                            repaymentammount = val1 + interest;
                            begginingbalance = 0;
                        }
                        else
                        {
                            repaymentammount = interest;
                            begginingbalance = val1;
                        }

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNumber.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (AmortisationMethod.Text.ToString().Trim() == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= ServicingPeriod.Value)
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    double val1 = 0;
                    double.TryParse(TotalAmount.Value.ToString(), out val1);
                    double r = Convert.ToDouble(InterestRate.Value) / 100;
                    int n = ServicingPeriod.Value;
                    double firstint = Math.Pow((1 + r), n);
                    double secondint = Math.Pow((1 + r), n);
                    double emi = (val1 * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n)) - 1);
                    for (i = 1; i <= ServicingPeriod.Value; i++)
                    {
                        if (RepaymentInterval.Text.ToString().Trim() == "Monthly")
                        {
                            repaymentmonths = monthscount[i] + "Months";
                            repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.ToString().Trim() == "Daily")
                        {
                            repaymentmonths = monthscount[i] + "Day";
                            repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.ToString().Trim() == "Weekly")
                        {
                            repaymentmonths = monthscount[i] + "Week";
                            repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                        {
                            interest = val1 * (Convert.ToDouble(InterestRate.Value) / 100);
                            principal = emi - interest;
                            repaymentammount = emi;
                            begginingbalance = val1 - principal;
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select BeginningBalance from AmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Double totals6 = Convert.ToDouble(rdr[0]);
                                interest = totals6 * (Convert.ToDouble(InterestRate.Value) / 100);
                                principal = emi - interest;
                                repaymentammount = emi;
                                begginingbalance = totals6 - principal;
                                con.Close();
                            }
                            con.Close();
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNumber.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully Submitted Application", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int TotalPrincipal = 0;
        int totalbalanceexist = 0;
        int totalbalanceexist1 = 0;
        int TotalIntrests = 0;
        string interrestmethod = null;
        int realloanfine = 0;
        int intrestearned = 0;
        private void LoanID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate > @date1 and PaymentStatus='Paid'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate > @date1 and PaymentStatus='Paid'";
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    totalbalanceexist1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
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
                cmd = new SqlCommand("select Fines from RepaymentSchedule where Waivered='No' and PaymentStatus='Pending' and LoanID='" + LoanID.Text + "' and PaymentDate > @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where Waivered='No' and PaymentStatus='Pending' and LoanID='" + LoanID.Text + "' and PaymentDate > @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    realloanfine = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
                }
                else
                {
                    realloanfine = 0;
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
                string ct2 = "select IssueType from Loan where LoanID= '" + LoanID.Text + "'";
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
            if (interrestmethod == "Reducing Balance")
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate <= @date1 and BalanceExist > 0", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate <= @date1 and BalanceExist > 0";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
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
                    cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(Interest) FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
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
                    cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and PaymentDate > @date1";
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
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
                    cmd.CommandText = "SELECT TOP (1) Interest FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                    //label3.Text = TotalIntrests.ToString();
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
                    cmd = new SqlCommand("select ID from RepaymentSchedule where PaymentDate >= @date1 and LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ids = Convert.ToInt32(rdr[0]);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "select PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC ";
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                            string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending'  order by ID ASC";
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                        string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID DESC";
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 0)
                                {
                                    totalrealintrest = 0; //realintrest * daysbetween;
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = 0; //realintrest * daysbetween;
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
                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                int daysbetween = currentdate.Subtract(dt).Days;
                                if (daysbetween > 1)
                                {
                                    totalrealintrest = 0;// realintrest * daysbetween;
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
                int duebal = totalrealintrest + TotalPrincipal + totalbalanceexist +totalbalanceexist1 + realloanfine;
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
                Amount.Value = (duebals);
            }
            else if (interrestmethod == "Flat Rate")
            {
                SqlDataReader rdr = null;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate <= @date1 and BalanceExist > 0", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate <= @date1 and BalanceExist > 0";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
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
                    cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT SUM(Interest) FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and PaymentDate <= @date1";
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
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
                int totalrealintrest = 0;
                int principals = 0;
                int ids = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select ID from RepaymentSchedule where PaymentDate > @date1 and LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    // twhen this is not the last installment
                    ids = Convert.ToInt32(rdr[0]);
                    //MessageBox.Show(ids.ToString());
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    //cmd = con.CreateCommand();
                    string ct2 = "SELECT  Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int realintrest = 0;
                       
                        int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                        principals = Convert.ToInt32(Convert.ToDouble(rdr[1]));
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct4 = "select PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC";
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                        con.Close();
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        //cmd = con.CreateCommand();
                        string ct6 = "SELECT  TOP (1) Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                        cmd = new SqlCommand(ct6);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            int realintrest = 0;
                            int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                            try
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
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
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
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
                    string ct2 = "SELECT  TOP (1) Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID DESC";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int realintrest = 0;
                        int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr[0]));
                        //principals = Convert.ToInt32(Convert.ToDouble(rdr[1]));
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID DESC";
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
                                    string realdate = startdate.AddDays(0).ToShortDateString();
                                    DateTime dt = DateTime.Parse(realdate);
                                    string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 0)
                                    {
                                        totalrealintrest = 0; //realintrest * daysbetween;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = 0;//realintrest * daysbetween;
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
                                    DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                    int daysbetween = currentdate.Subtract(dt).Days;
                                    if (daysbetween > 1)
                                    {
                                        totalrealintrest = 0;//realintrest * daysbetween;
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
                       
                        con.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                int duebal = principals + totalrealintrest + realloanfine + totalbalanceexist + totalbalanceexist1;
                int duebals = 0;
                //label7.Text = (intrestearned + totalrealintrest).ToString();

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
                Amount.Value = (duebals);
            }
        }

        private void TopupAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TopupAmount.Text == "") { } else
                {
                    TotalAmount.Value = (TopupAmount.Value +Amount.Value);
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
            company();
            try
            {

                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                FrmLoanScheduleReport frm = new FrmLoanScheduleReport();
                rptLoanRepaymentSchedule rpt = new rptLoanRepaymentSchedule();
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from RepaymentSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "RepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm.crystalReportViewer1.ReportSource = rpt;
                myConnection.Close();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoanID_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            this.AccountName.Text = frm.Accountnames.Text;
            this.AccountNumber.Text = frm.clientnames.Text;
            label16.Text = frm.LoanID.Text;
            this.LoanID.Text = frm.LoanID.Text;
            return;
        }
    }
}
