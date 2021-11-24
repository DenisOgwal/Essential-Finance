using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanReschedule : DevComponents.DotNetBar.Office2007RibbonForm
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
        public FrmLoanReschedule()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID] from Loan where  Issued='Yes' order by ID DESC", con);
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT LoanAmount,Interest,RepaymentInterval,ServicingPeriod,IssueType FROM Loan WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "' and Issued='Yes'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    AccountNumber.Text = dr.Cells[0].Value.ToString();
                    AccountName.Text = dr.Cells[1].Value.ToString();
                    LoanID.Text = dr.Cells[2].Value.ToString();
                    AmortisationMethod.Text = rdr["IssueType"].ToString();
                    ScheduleInterval.Text = rdr["RepaymentInterval"].ToString();
                    Interest.Text = rdr["Interest"].ToString();
                }
                else
                {
                    MessageBox.Show("Loan Already Issued","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanReschedule frm = new FrmLoanReschedule();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansFinalApproval='Yes'";
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
            if (PaymentInterval.Text == "")
            {
                MessageBox.Show("Please Enter Payment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentInterval.Focus();
                return;
            }
            int loaninstallmentcount = 0;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update RepaymentSchedule set PaymentStatus=@d1 where LoanID=@d2 and BalanceExist > 0 and PaymentStatus !='ToppedUp'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@d1"].Value = "Rescheduled";
                cmd.Parameters["@d2"].Value = LoanID.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(TotalAmmount) from RepaymentSchedule where  LoanID='" + LoanID.Text + "'", con);
                loaninstallmentcount = Convert.ToInt32(cmd.ExecuteScalar());
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                try
            {
                int dividedperiod = (Convert.ToInt32(ServicingPeriod.Text) % PaymentInterval.Value);
                if (dividedperiod == 0)
                { }
                else {
                    string realinterval = null;
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
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text)/PaymentInterval.Value); i++)
                    {
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment "+ (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddMonths(i*PaymentInterval.Value)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddDays(i * (PaymentInterval.Value))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)) * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        principal = val1 / (Convert.ToInt32(ServicingPeriod.Text));
                        interest = ((Convert.ToDouble(Interest.Text) / (100)) * val1);
                        double intre = 0;
                        for (int m = 0; m < PaymentInterval.Value; m++)
                        {
                            intre += (principal + interest);
                        }
                        repaymentammount = intre;
                        begginingbalance = val1;

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName,IntrestType,Rates) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Float, 20, "Rates"));
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
                        cmd.Parameters["@d11"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d12"].Value = Interest.Text;
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
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value); i++)
                    {
                        if (ScheduleInterval.Text.Trim() == "Monthly")
                        {
                            repaymentmonths = "Installment " + (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddMonths((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Daily")
                        {
                            repaymentmonths = "Installment " + (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddDays((i * (PaymentInterval.Value)))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (ScheduleInterval.Text.Trim() == "Weekly")
                        {
                            repaymentmonths = "Installment " + (monthscount[i] + loaninstallmentcount);
                            repaymentdate1 = (startdate.AddDays(((i * (PaymentInterval.Value)) * 7))).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        double emi = val1 / (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value);
                        double emi2= val1 / (Convert.ToInt32(ServicingPeriod.Text));
                        if (monthscount[i] == 1)
                        {
                            double intre = 0;
                            for (int m=0;m< PaymentInterval.Value;m++)
                            {
                                double newinterest= ((val1 - (m*emi2))) * (Convert.ToDouble(Interest.Text) / 100);
                                intre += newinterest;
                            }
                            interest = intre;
                            principal = emi;
                            repaymentammount = emi + interest;
                            begginingbalance = val1 - principal;
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select BeginningBalance from RepaymentSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Double totals6 = Convert.ToDouble(rdr[0]);
                                double intre = 0;
                                for (int m = 0; m < PaymentInterval.Value; m++)
                                {
                                    double newinterest = ((totals6 - (m * emi2))) * (Convert.ToDouble(Interest.Text) / 100);
                                    intre += newinterest;
                                }
                                interest = intre;
                                principal = emi;
                                repaymentammount = emi + interest;
                                begginingbalance = totals6 - principal;
                                con.Close();
                            }

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName,IntrestType,Rates) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Float, 20, "Rates"));
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
                        cmd.Parameters["@d11"].Value = AmortisationMethod.Text;
                        cmd.Parameters["@d12"].Value = Interest.Text;
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

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Loan SET Issued=@d2 WHERE LoanID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Issued"));
                cmd.Parameters["@d1"].Value = LoanID.Text;
                cmd.Parameters["@d2"].Value = "Yes";
                //cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmLoanIssue frm = new FrmLoanIssue();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        int TotalPrincipal = 0;
        int totalbalanceexist = 0;
        private void LoanID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'";
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
                cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Paid'";
                totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int TotalIntrests = 0;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP (1) Interest FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Amount.Value = (TotalIntrests + TotalPrincipal + totalbalanceexist);
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
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
