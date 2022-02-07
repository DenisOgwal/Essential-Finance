using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanScheduleTrial : DevComponents.DotNetBar.Office2007RibbonForm
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
        SqlDataAdapter adp = null;
        int[] monthscount = new int[100];
        string repaymentmonths = null;
        string repaymentdate = null;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmLoanScheduleTrial()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  TrialAmortisationSchedule where LoanID=@DELETE1 ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                RowsAffected = cmd.ExecuteNonQuery();
               
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
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  TAmortisationSchedule where LoanID=@DELETE1 ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                RowsAffected = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            FrmLoanScheduleTrial frm = new FrmLoanScheduleTrial();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  TrialAmortisationSchedule where LoanID=@DELETE1 ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                RowsAffected = cmd.ExecuteNonQuery();

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
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  TAmortisationSchedule where LoanID=@DELETE1 ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                RowsAffected = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            LoanID.Text = "LA" + years + monthss + days + convertedid;
        }
        double begginingbalance = 0.00;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (AmortisationMethod.Text == "Reducing Balance" && InterestRate.Text=="0")
            {
                MessageBox.Show("You Can not use 0% Interrest on Reducing Balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterestRate.Focus();
                return;
            }
            auto();
            if (PaymentInterval.Text == "")
            {
                MessageBox.Show("Please Enter Payment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentInterval.Focus();
                return;
            }
            try
            {
                int dividedperiod = (Convert.ToInt32(ServicingPeriod.Text) % PaymentInterval.Value);
                if (dividedperiod == 0)
                { }
                else {
                    string realinterval = "N/A";
                    if (ScheduleInterval.Text.Trim() == "Monthly")
                    {
                        realinterval = "Months";
                    }
                    else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            realinterval = "Days";
                        }
                    else if (ScheduleInterval.Text.Trim() == "Weekly")
                    {
                        realinterval = "Weeks";
                    }
                    MessageBox.Show("Repayments Can not be Subdivided in Intervals of " + PaymentInterval.Value+" "+ realinterval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PaymentInterval.Focus();
                    return;
                }
                if (AmortisationMethod.Text == "Flat Rate")
                {
                    double principal = 0.00;
                    double interest = 0.00;
                    double repaymentammount = 0;
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
                         if (ScheduleInterval.Text == "Monthly")
                         {
                             repaymentmonths = monthscount[i] + "Months";
                             repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                             DateTime dt = DateTime.Parse(repaymentdate1);
                             repaymentdate = dt.ToString("dd/MMM/yyyy");
                         }
                         else if (ScheduleInterval.Text == "Daily")
                         {
                             repaymentmonths = monthscount[i] + "Day";
                             repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                             DateTime dt = DateTime.Parse(repaymentdate1);
                             repaymentdate = dt.ToString("dd/MMM/yyyy");
                         }
                         else if (ScheduleInterval.Text == "Weekly")
                         {
                             repaymentmonths = monthscount[i] + "Week";
                             repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                             DateTime dt = DateTime.Parse(repaymentdate1);
                             repaymentdate = dt.ToString("dd/MMM/yyyy");

                         }
                         double val1 = 0;
                         double.TryParse(Amount.Value.ToString(), out val1);
                         principal = val1;
                        if (InterestRate.Text == "0")
                        {
                            interest = 0.00;
                        }
                        else
                        {
                            interest = ((Convert.ToDouble(InterestRate.Text) / (100)) * val1);
                        }
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
                         string cb = "insert into TAmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                         cmd.Parameters["@d2"].Value = "N/a";
                         cmd.Parameters["@d3"].Value = repaymentmonths;
                         cmd.Parameters["@d4"].Value = repaymentdate;
                         cmd.Parameters["@d5"].Value = repaymentammount;
                         cmd.Parameters["@d6"].Value = principal;
                         cmd.Parameters["@d7"].Value = interest;
                         cmd.Parameters["@d8"].Value = repaymentammount;
                         cmd.Parameters["@d9"].Value = begginingbalance;
                         cmd.Parameters["@d10"].Value = "N/a";
                         cmd.ExecuteNonQuery();
                         con.Close();
                        
                    }
                }
                else if (AmortisationMethod.Text == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    double principal = 0.00;
                    double interest = 0.00;
                    double repaymentammount = 0;
                    while (K <= ServicingPeriod.Value)
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    double val1 = 0;
                    double.TryParse(Amount.Value.ToString(), out val1);
                    double r = Convert.ToDouble(InterestRate.Text) / 100;
                    int n = ServicingPeriod.Value;
                    double firstint = Math.Pow((1 + r), n);
                    double secondint = Math.Pow((1 + r), n);
                    double emi = (val1 * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n)) - 1);
                    for (i = 1; i <= ServicingPeriod.Value; i++)
                    {
                        if (ScheduleInterval.Text == "Monthly")
                        {
                            repaymentmonths = monthscount[i] + "Months";
                            repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text == "Daily")
                        {
                            repaymentmonths = monthscount[i] + "Day";
                            repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text == "Weekly")
                        {
                            repaymentmonths = monthscount[i] + "Week";
                            repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                        {
                            if (InterestRate.Text == "0")
                            {
                                interest = 0.00;
                            }
                            else
                            {
                                interest = val1 * (Convert.ToDouble(InterestRate.Text) / 100);
                            }
                            principal = emi - interest;
                            repaymentammount = emi;
                            begginingbalance = val1 - principal;
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select BeginningBalance from TAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Double totals6 = Convert.ToDouble(rdr[0]);
                                if (InterestRate.Text == "0")
                                {
                                    interest = 0.00;
                                }
                                else
                                {
                                    interest = totals6 * (Convert.ToDouble(InterestRate.Text) / 100);
                                }
                                principal = emi - interest;
                                repaymentammount = emi;
                                begginingbalance = totals6 - principal;
                                con.Close();
                            }

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into TAmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                        cmd.Parameters["@d2"].Value = "N/a";
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = "N/a";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                if (AmortisationMethod.Text.Trim() == "Flat Rate")
                {
                    double principal = 0.00;
                    double interest = 0.00;
                    double repaymentammount = 0;
                    int K = 1;
                    int i = 1;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text)/PaymentInterval.Value); i++)
                    {
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment "+ monthscount[i];
                            repaymentdate1 = (startdate.AddMonths(i*PaymentInterval.Value)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(i * (PaymentInterval.Value))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)) * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        principal = val1;
                        if (InterestRate.Text == "0")
                        {
                            interest = 0.00;
                        }
                        else
                        {
                            interest = Convert.ToDouble(PaymentInterval.Value) * ((Convert.ToDouble(InterestRate.Text) / (100)) * val1);
                        }
                        if (i == (Convert.ToInt32(ServicingPeriod.Text)/ PaymentInterval.Value))
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
                        string cb = "insert into TrialAmortisationSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,IntrestType,Rates) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Float, 20, "Rates"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = repaymentmonths;
                        cmd.Parameters["@d3"].Value = repaymentdate;
                        cmd.Parameters["@d4"].Value = repaymentammount;
                        cmd.Parameters["@d5"].Value = principal;
                        cmd.Parameters["@d6"].Value = interest;
                        cmd.Parameters["@d7"].Value = repaymentammount;
                        cmd.Parameters["@d8"].Value = begginingbalance;
                        cmd.Parameters["@d9"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d10"].Value = InterestRate.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                       
                    }
                }
                else if (AmortisationMethod.Text.Trim() == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value))
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    int ids = 0;
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value); i++)
                    {
                        double principal = 0.00;
                        double interest = 0.00;
                        double repaymentammount = 0;
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddMonths((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + monthscount[i];
                            repaymentdate1 = (startdate.AddDays(((i * (PaymentInterval.Value)) * 7))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        if (repaymentmonths == "Installment 1")
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TOP ("+PaymentInterval.Value+ ") AmmountPay,Interest,TotalAmmount,BeginningBalance,ID from TAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID ASC" , con);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read()==true)
                            {
                                interest += Convert.ToDouble(rdr[1]);
                                principal += Convert.ToDouble(rdr[0]);
                                repaymentammount += Convert.ToDouble(rdr[2]);
                                begginingbalance = Convert.ToDouble(rdr[3]);
                                ids = Convert.ToInt32(rdr[4]);
                                //con.Close();
                            }
                           
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TOP (" + PaymentInterval.Value + ") AmmountPay,Interest,TotalAmmount,BeginningBalance,ID from TAmortisationSchedule where LoanID='" + LoanID.Text + "' and ID > "+ids+" order by ID ASC", con);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read() == true)
                            {
                                interest += Convert.ToDouble(rdr[1]);
                                principal += Convert.ToDouble(rdr[0]);
                                repaymentammount += Convert.ToDouble(rdr[2]);
                                begginingbalance = Convert.ToDouble(rdr[3]);
                                ids = Convert.ToInt32(rdr[4]);
                                //con.Close();
                            }
                           
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into TrialAmortisationSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,IntrestType,Rates) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Float, 20, "Rates"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = repaymentmonths;
                        cmd.Parameters["@d3"].Value = repaymentdate;
                        cmd.Parameters["@d4"].Value = repaymentammount;
                        cmd.Parameters["@d5"].Value = principal;
                        cmd.Parameters["@d6"].Value = interest;
                        cmd.Parameters["@d7"].Value = repaymentammount;
                        cmd.Parameters["@d8"].Value = begginingbalance;
                        cmd.Parameters["@d9"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d10"].Value = InterestRate.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                company();
                try
                {
                    if (AmortisationMethod.Text.Trim() == "Reducing Balance")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        FrmLoanScheduleReport frm3 = new FrmLoanScheduleReport();
                        RptTrialLoanAmortisation rpt = new RptTrialLoanAmortisation();
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from TrialAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "TrialAmortisationSchedule");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        frm3.crystalReportViewer1.ReportSource = rpt;
                        frm3.ShowDialog();
                    }
                    else if (AmortisationMethod.Text.Trim() == "Flat Rate")
                        {
                            SqlConnection myConnection = default(SqlConnection);
                            SqlCommand MyCommand = new SqlCommand();
                            SqlDataAdapter myDA = new SqlDataAdapter();
                            DataSet myDS = new DataSet();
                            FrmLoanScheduleReport frm3 = new FrmLoanScheduleReport();
                            RptTrialLoanAmortisationFlat rpt = new RptTrialLoanAmortisationFlat();
                            myConnection = new SqlConnection(cs.DBConn);
                            myConnection.Open();
                            MyCommand.Connection = myConnection;
                            MyCommand.CommandText = "select  * from TrialAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                            MyCommand.CommandType = CommandType.Text;
                            myDA.SelectCommand = MyCommand;
                            myDA.Fill(myDS, "TrialAmortisationSchedule");
                            rpt.SetDataSource(myDS);
                            rpt.SetParameterValue("comanyname", companyname);
                            rpt.SetParameterValue("companyemail", companyemail);
                            rpt.SetParameterValue("companycontact", companycontact);
                            rpt.SetParameterValue("companyslogan", companyslogan);
                            rpt.SetParameterValue("companyaddress", companyaddress);
                            rpt.SetParameterValue("picpath", "logo.jpg");
                            frm3.crystalReportViewer1.ReportSource = rpt;
                            frm3.ShowDialog();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*this.Hide();
                FrmLoanScheduleTrial frm = new FrmLoanScheduleTrial();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();*/
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                company();
                try
                {
                    if (AmortisationMethod.Text.Trim() == "Reducing Balance")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        FrmLoanScheduleReport frm3 = new FrmLoanScheduleReport();
                        RptTrialLoanAmortisation rpt = new RptTrialLoanAmortisation();
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from TrialAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "TrialAmortisationSchedule");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        frm3.crystalReportViewer1.ReportSource = rpt;
                        frm3.ShowDialog();
                    }
                    else if (AmortisationMethod.Text.Trim() == "Flat Rate")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        FrmLoanScheduleReport frm3 = new FrmLoanScheduleReport();
                        RptTrialLoanAmortisationFlat rpt = new RptTrialLoanAmortisationFlat();
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from TrialAmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Asc ";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "TrialAmortisationSchedule");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        frm3.crystalReportViewer1.ReportSource = rpt;
                        frm3.ShowDialog();
                    }
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
        }
    }
}
