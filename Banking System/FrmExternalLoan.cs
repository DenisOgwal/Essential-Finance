using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmExternalLoan : DevComponents.DotNetBar.Office2007RibbonForm
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
        SqlDataAdapter adp;
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
        public FrmExternalLoan()
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
            string ct = "select ID from ExternalLoans Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(ID) from ExternalLoans", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
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
            con.Close();
            string years = yearss.Substring(2, 2);
            LoanID.Text = "EL" + years + monthss + days + convertedid;
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
        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
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
                    PaymentMode.Items.Add(drow[1].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmExternalLoan frm = new FrmExternalLoan();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ExternalLoans='Yes'";
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
        Double begginingbalance = 0.00;
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
                int dividedperiod = (Convert.ToInt32(ServicingPeriod.Text) % PaymentInterval.Value);
                if (dividedperiod == 0)
                { }
                else
                {
                    string realinterval = null;
                    if (RepaymentInterval.Text.Trim() == "Monthly")
                    {
                        realinterval = "Months";
                    }
                    else if (RepaymentInterval.Text.Trim() == "Daily")
                    {
                        realinterval = "Days";
                    }
                    else if (RepaymentInterval.Text.Trim() == "Weekly")
                    {
                        realinterval = "Weeks";
                    }
                    MessageBox.Show("Repayments Can not be Subdivided in Intervals of " + PaymentInterval.Value + " " + realinterval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PaymentInterval.Focus();
                    return;
                }
                auto();
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
                
                double accountexcess = 0.00;
                if (AmortisationMethod.Text.Trim() == "Flat Rate")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value); i++)
                    {
                        if (RepaymentInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddMonths(i * PaymentInterval.Value)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(i * (PaymentInterval.Value))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)) * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        principal = val1;
                        double repaymentammounts = 0.00;
                        interest = Convert.ToDouble(PaymentInterval.Value) * ((Convert.ToDouble(Interest.Text) / (100)) * val1);
                        if (i == (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                        {
                            repaymentammounts = val1 + interest;
                            begginingbalance = 0;
                            int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                            if (result > 500)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else if (result < 500 && result > 0)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else
                            {
                                repaymentammount = repaymentammounts;
                            }
                        }
                        else
                        {
                            repaymentammounts = interest;
                            int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                            if (result > 500)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else if (result < 500 && result > 0)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else
                            {
                                repaymentammount = repaymentammounts;
                            }
                            begginingbalance = val1;
                        }
                        accountexcess = repaymentammount - repaymentammounts;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "insert into ExternalRepaymentSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,Lender,AccountExcess) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "Lender"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Float, 20, "AccountExcess"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = repaymentmonths;
                        cmd.Parameters["@d3"].Value = repaymentdate;
                        cmd.Parameters["@d4"].Value = repaymentammount;
                        cmd.Parameters["@d5"].Value = principal;
                        cmd.Parameters["@d6"].Value = interest;
                        cmd.Parameters["@d7"].Value = repaymentammount;
                        cmd.Parameters["@d8"].Value = begginingbalance;
                        cmd.Parameters["@d9"].Value = Lender.Text;
                        cmd.Parameters["@d10"].Value = accountexcess;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (AmortisationMethod.Text.Trim() == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text)))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    double val1 = 0;
                    double.TryParse(Amount.Value.ToString(), out val1);
                    double r = Convert.ToDouble(Interest.Text) / 100;
                    int n = Convert.ToInt32(ServicingPeriod.Text);
                    double firstint = Math.Pow((1 + r), n);
                    double secondint = Math.Pow((1 + r), n);
                    double emi = (val1 * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n)) - 1);
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text)); i++)
                    {
                        if (RepaymentInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddMonths((i))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(((i) * 7))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double repaymentammounts = 0.00;
                        if (repaymentmonths == "Installment 1")
                        {
                            if (Interest.Text == "0")
                            {
                                interest = 0.00;
                            }
                            else
                            {
                                interest = val1 * (Convert.ToDouble(Interest.Text) / 100);
                            }
                            repaymentammounts = 0;
                            principal = emi - interest;
                            repaymentammounts = emi;
                            begginingbalance = val1 - principal;
                            int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                            if (result > 500)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else if (result < 500 && result > 0)
                            {
                                repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                            }
                            else
                            {
                                repaymentammount = repaymentammounts;
                            }
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select BeginningBalance from ExternalRepaymentSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Double totals6 = Convert.ToDouble(rdr[0]);
                                if (Interest.Text == "0")
                                {
                                    interest = 0.00;
                                }
                                else
                                {
                                    interest = totals6 * (Convert.ToDouble(Interest.Text) / 100);
                                }
                                repaymentammounts = 0;
                                principal = emi - interest;
                                repaymentammounts = emi;
                                begginingbalance = totals6 - principal;
                                con.Close();
                                int result = Convert.ToInt32(Convert.ToInt32(repaymentammounts) % 1000);
                                if (result > 500)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 1000 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else if (result < 500 && result > 0)
                                {
                                    repaymentammount = Convert.ToInt32(repaymentammounts) + 500 - Convert.ToInt32(repaymentammounts) % 1000;
                                }
                                else
                                {
                                    repaymentammount = repaymentammounts;
                                }
                            }
                            con.Close();

                        }
                        accountexcess = repaymentammount - repaymentammounts;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "insert into ExternalRepaymentSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,Lender,AccountExcess) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "Lender"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Float, 50, "AccountExcess"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = repaymentmonths;
                        cmd.Parameters["@d3"].Value = repaymentdate;
                        cmd.Parameters["@d4"].Value = repaymentammount;
                        cmd.Parameters["@d5"].Value = principal;
                        cmd.Parameters["@d6"].Value = interest;
                        cmd.Parameters["@d7"].Value = repaymentammount;
                        cmd.Parameters["@d8"].Value = begginingbalance;
                        cmd.Parameters["@d9"].Value = Lender.Text;
                        cmd.Parameters["@d10"].Value = accountexcess;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                ExternalLoansAmortisation rpt = new ExternalLoansAmortisation();
                //The DataSet you created.
                FrmExternalLoanRe frm2 = new FrmExternalLoanRe();
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from ExternalRepaymentSchedule where LoanID='"+LoanID.Text+"' order by ID ASC ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ExternalRepaymentSchedule");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                frm2.crystalReportViewer1.ReportSource = rpt;
                myConnection.Close();
                frm2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult dialog = MessageBox.Show("Do you want to Save this", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                SqlDataReader rdr = null;
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + PaymentMode.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount + Convert.ToInt32(Amount.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + ApplicationDate.Text + "' where AccountNames='" + PaymentMode.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    int RowsAffected = 0;

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete  from  ExternalLoanRepayment where LoanID=@DELETE1;";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq2 = "delete  from  ExternalLoans where LoansID=@DELETE1;";
                    cmd = new SqlCommand(cq2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoandID"));
                    cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                    RowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq1 = "delete  from  ExternalRepaymentSchedule where LoanID=@DELETE1;";
                    cmd = new SqlCommand(cq1);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                    RowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Reset();

                    }
                    else
                    {
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Reset();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
                this.Hide();
            FrmExternalLoan frm = new FrmExternalLoan();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalPaymentSchedule frm = new frmExternalPaymentSchedule();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
    }
}
