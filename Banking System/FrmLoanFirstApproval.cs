using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanFirstApproval : DevComponents.DotNetBar.Office2007RibbonForm
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
        public FrmLoanFirstApproval()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID] from Loan where FirstApproval='Pending' and ProcessingApproval='Approved' order by ID DESC", con);
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
                cmd.CommandText = "SELECT LoanID FROM LoanApplicationPayment WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    AccountNumber.Text = dr.Cells[0].Value.ToString();
                    AccountName.Text = dr.Cells[1].Value.ToString();
                    LoanID.Text = dr.Cells[2].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Client has not yet paid Loan Application Fees for this Loan Application, Please Clear to continue","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
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
                DataGridViewRow dr = dataGridView1.CurrentRow;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT LoanAmount FROM Loan WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Amount.Text = rdr[0].ToString();
                    label12.Text = rdr[0].ToString();
                }
                else
                {
                    MessageBox.Show("Client has not yet paid Loan Application Fees for this Loan Application, Please Clear to continue", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
            FrmLoanFirstApproval frm = new FrmLoanFirstApproval();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansManagerApproval='Yes'";
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
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approval and Enter Comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }
           /* con = new SqlConnection(cs.DBConn);
            con.Open();
            string kt = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
            cmd = new SqlCommand(kt);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Loan ID Already Exixts, Please Repeat Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            try
            {
                if (approvals.Text == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE Loan SET ApprovalDate=@d4,FirstApproval=@d5,FinalApproval='Pending',ApprovalComment=@d6,ApprovedBy=@d7,LoanAmount='" + Amount.Value + "',Intervals='" + PaymentInterval.Value + "' WHERE LoanID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "ApprovalDate"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "FirstApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 500, "ApprovalComment"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = LoanID.Text;
                    cmd.Parameters["@d2"].Value = AccountNumber.Text;
                    cmd.Parameters["@d3"].Value = AccountName.Text;
                    cmd.Parameters["@d4"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d5"].Value = approvals.Text;
                    cmd.Parameters["@d6"].Value = ApprovalComment.Text;
                    cmd.Parameters["@d7"].Value = ApprovalName.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE Loan SET ApprovalDate=@d4,FirstApproval=@d5,FinalApproval='Rejected',ApprovalComment=@d6,ApprovedBy=@d7,LoanAmount='" + Amount.Value + "',Intervals='" + PaymentInterval.Value + "' WHERE LoanID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "ApprovalDate"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "FirstApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 500, "ApprovalComment"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                    cmd.Parameters["@d1"].Value = LoanID.Text;
                    cmd.Parameters["@d2"].Value = AccountNumber.Text;
                    cmd.Parameters["@d3"].Value = AccountName.Text;
                    cmd.Parameters["@d4"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d5"].Value = approvals.Text;
                    cmd.Parameters["@d6"].Value = ApprovalComment.Text;
                    cmd.Parameters["@d7"].Value = ApprovalName.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (Amount.Value != Convert.ToInt32(label12.Text))
                {
                    try
                    {
                        int RowsAffected = 0;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cq = "delete  from  AmortisationSchedule where LoanID=@DELETE1 ";
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
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT IssueType,ServicingPeriod,RepaymentInterval,Interest, LoanAmount FROM Loan WHERE LoanID = '" + LoanID.Text.ToString().Trim() + "'";
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string AmortisationMethod = rdr["IssueType"].ToString().Trim();
                            int ServicingPeriod = Convert.ToInt32(rdr["ServicingPeriod"]);
                            string RepaymentInterval = rdr["RepaymentInterval"].ToString().Trim();
                            double InterestRate= Convert.ToDouble(rdr["Interest"].ToString());
                            if (AmortisationMethod == "Flat Rate")
                            {
                                int K = 1;
                                int i = 1;
                                while (K <= ServicingPeriod)
                                {
                                    monthscount[K] = K;
                                    K++;
                                }
                                string repaymentdate1 = null;
                                DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                                for (i = 1; i <= ServicingPeriod; i++)
                                {
                                    if (RepaymentInterval == "Monthly")
                                    {
                                        repaymentmonths = monthscount[i] + "Months";
                                        repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else if (RepaymentInterval == "Daily")
                                    {
                                        repaymentmonths = monthscount[i] + "Day";
                                        repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else if (RepaymentInterval == "Weekly")
                                    {
                                        repaymentmonths = monthscount[i] + "Week";
                                        repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");

                                    }
                                    double val1 = 0;
                                    double.TryParse(Amount.Value.ToString(), out val1);
                                    principal = val1;
                                    if (InterestRate == 0)
                                    {
                                        interest = 0.00;
                                    }
                                    else
                                    {
                                        interest = ((Convert.ToDouble(InterestRate) / (100)) * val1);
                                    }
                                    if (i == ServicingPeriod)
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
                                    string cb8 = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                                    cmd = new SqlCommand(cb8);
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
                            else if (AmortisationMethod == "Reducing Balance")
                            {
                                int K = 1;
                                int i = 1;
                                while (K <= ServicingPeriod)
                                {
                                    monthscount[K] = K;
                                    K++;
                                }

                                string repaymentdate1 = null;
                                DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                                double val1 = 0;
                                double.TryParse(Amount.Value.ToString(), out val1);
                                double r = Convert.ToDouble(InterestRate) / 100;
                                int n = ServicingPeriod;
                                double firstint = Math.Pow((1 + r), n);
                                double secondint = Math.Pow((1 + r), n);
                                double emi = (val1 * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n)) - 1);
                                //MessageBox.Show("emi"+ emi);
                                //MessageBox.Show("firstint" + firstint);
                                ///MessageBox.Show("r" + r);
                                for (i = 1; i <= ServicingPeriod; i++)
                                {
                                    if (RepaymentInterval == "Monthly")
                                    {
                                        repaymentmonths = monthscount[i] + "Months";
                                        repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else if (RepaymentInterval == "Daily")
                                    {
                                        repaymentmonths = monthscount[i] + "Day";
                                        repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else if (RepaymentInterval == "Weekly")
                                    {
                                        repaymentmonths = monthscount[i] + "Week";
                                        repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");

                                    }

                                    if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                                    {

                                        if (InterestRate == 0)
                                        {
                                            interest = 0.00;
                                        }
                                        else
                                        {
                                            interest = val1 * (Convert.ToDouble(InterestRate) / 100);
                                        }
                                        principal = emi - interest;
                                        repaymentammount = emi;
                                        begginingbalance = val1 - principal;
                                    }
                                    else
                                    {
                                        con = new SqlConnection(cs.DBConn);
                                        con.Open();
                                        string kt2 = "select BeginningBalance from AmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                                        cmd = new SqlCommand(kt2);
                                        cmd.Connection = con;
                                        rdr = cmd.ExecuteReader();
                                        if (rdr.Read())
                                        {
                                            Double totals6 = Convert.ToDouble(rdr[0]);
                                            if (InterestRate == 0)
                                            {
                                                interest = 0.00;
                                            }
                                            else
                                            {
                                                interest = totals6 * (Convert.ToDouble(InterestRate) / 100);
                                            }
                                            principal = emi - interest;
                                            repaymentammount = emi;
                                            begginingbalance = totals6 - principal;
                                            con.Close();
                                        }
                                        con.Close();

                                    }
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb9 = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                                    cmd = new SqlCommand(cb9);
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
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmLoanFirstApproval frm = new FrmLoanFirstApproval();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
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
            FrmLoanRecord frm = new FrmLoanRecord();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
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
            FrmLoanGurarantorsRecord frm = new FrmLoanGurarantorsRecord();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
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
            FrmLoanLiabilitiesRecord frm = new FrmLoanLiabilitiesRecord();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
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
            FrmLoanAmortisationReport frm = new FrmLoanAmortisationReport();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
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
            FrmLoanCollateralRecord frm = new FrmLoanCollateralRecord();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }
    }
}
