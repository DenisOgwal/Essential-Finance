﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanIssue : DevComponents.DotNetBar.Office2007RibbonForm
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
        public FrmLoanIssue()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID] from Loan where FinalApproval='Approved' and FirstApproval='Approved' and Issued='Pending' order by ID DESC", con);
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
                cmd.CommandText = "SELECT LoanAmount,Interest,RepaymentInterval,ServicingPeriod,IssueType,CollateralValue,RefereeRelationship,RefereeName FROM Loan WHERE LoanID = '" + dr.Cells[2].Value.ToString().Trim() + "' and Issued='Pending'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label15.Text = "";
                    AccountNumber.Text = dr.Cells[0].Value.ToString();
                    AccountName.Text = dr.Cells[1].Value.ToString();
                    LoanID.Text = dr.Cells[2].Value.ToString();
                    AmortisationMethod.Text = rdr["IssueType"].ToString();
                    Amount.Text = rdr["LoanAmount"].ToString();
                    ScheduleInterval.Text = rdr["RepaymentInterval"].ToString();
                    Interest.Text = rdr["Interest"].ToString();
                    ServicingPeriod.Text = rdr["ServicingPeriod"].ToString();
                    label16.Text= rdr["RefereeName"].ToString();
                    label15.Text = rdr["RefereeRelationship"].ToString().Trim();
                    if (label15.Text=="Topup")
                    {
                        IssuableAmount.Text = (Convert.ToInt32(rdr["LoanAmount"])- Convert.ToInt32(rdr["CollateralValue"])).ToString();
                    }
                    else
                    {
                        IssuableAmount.Text = rdr["LoanAmount"].ToString();
                    }
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
            FrmLoanIssue frm = new FrmLoanIssue();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and IncomesApproval='Yes'";
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update RepaymentSchedule set PaymentStatus=@d1 where LoanID=@d2 and BalanceExist > 0";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@d1"].Value = "ToppedUp";
                cmd.Parameters["@d2"].Value = label16.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                        double val1 = 0;
                        double.TryParse(Amount.Value.ToString(), out val1);
                        double emi = val1 / (Convert.ToInt32(ServicingPeriod.Text) / PaymentInterval.Value);
                        double emi2= val1 / (Convert.ToInt32(ServicingPeriod.Text));
                        if (repaymentmonths == "Installment 1")
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
                        string cb = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
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
                cmd.ExecuteNonQuery();
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

    }
}