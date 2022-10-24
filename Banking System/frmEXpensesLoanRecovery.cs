using System;
using System.ComponentModel;
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
    public partial class frmEXpensesLoanRecovery : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        SqlDataAdapter adp;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmEXpensesLoanRecovery()
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
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            expenseid.Text = "EX-" + years + monthss + days + GetUniqueKey(5);
        }
        public void dataload() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID], RTRIM(CashierID)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],RTRIM(Cost)[Cost],RTRIM(TotalPaid)[Total Paid], RTRIM(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address], RTRIM(Paid)[Payment], RTRIM(ExpenseType)[Expense Type], RTRIM(ModeOfPayment)[Mode Of Payment], RTRIM(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(LoanID)[Loan ID] from Expenses where LoanID !='N/A' and ExpenseType='Loan Recovery' order by Expenses.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                dataGridViewX1.DataSource = myDataSet.Tables["Expenses"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Expense) FROM ExpensesType", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                expensetype.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    expensetype.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEXpenses_Load(object sender, EventArgs e)
        {
           
            dataload();
            AutocompleteStaffName();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
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
        private void Reset()
        {
            cashierid.Text = "";
            cashiername.Text = "";
            expenseid.Text = "";
            year.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
            expensedate.Text = DateTime.Today.ToString();
            description.Text = "";
            cost.Text = null;
            names.Text = "";
            address.Text = "";
            tel.Text = null;
            email.Text = "";
            managerid.Text = "";
            managername.Text = "";
            comment.Text = "";
            service.Text = "";
            buttonX5.Enabled = true;
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEXpensesLoanProcess frm = new frmEXpensesLoanProcess();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            if (email.Text == "" || email.Text == "N/A" || email.Text == "n/a")
            {
            }else{
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(email.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    email.SelectAll();
                    e.Cancel = true;
                }
            }
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
        string savingsids = null;
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from Savings  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = expensedate.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from Savings ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = expensedate.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SRE-" + years + monthss + days + realid;
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (expensetype.Text == "")
            {
                MessageBox.Show("Please enter Expense Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expensetype.Focus();
                return;
            }
           
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please enter cashier Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               cashiername.Focus();
                return;
            }
            if (cashierid.Text == "")
            {
                MessageBox.Show("Please enter cashier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashierid.Focus();
                return;
            }
            if (cost.Text == "")
            {
                MessageBox.Show("Please enter Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
         
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Duepayment from Expenses where ExpenseID='"+expenseid.Text+"'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update Expenses set Duepayment=@d9 where ExpenseID=@d1";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashierid.Text.Trim();
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,LoanID,AccountNumber,AccountNames,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashiername.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(clientcost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.Parameters["@d18"].Value = LoanID.Text;
                    cmd.Parameters["@d19"].Value = accountno.Text;
                    cmd.Parameters["@d20"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    auto();
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,LoanID,AccountNumber,AccountNames,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashiername.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(clientcost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.Parameters["@d18"].Value = LoanID.Text;
                    cmd.Parameters["@d19"].Value = accountno.Text;
                    cmd.Parameters["@d20"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                buttonX5.Enabled = false;
                dataload();
                dataGridViewX1.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
          
        }

        private void managername_TextChanged(object sender, EventArgs e)
        {
            comment.Enabled = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  Expenses where ExpenseID=@DELETE1 and Comment !='Approved'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters["@DELETE1"].Value = expenseid.Text;
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ExpenseID from Expenses where ExpenseID=@find and Comment='Approved'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters["@find"].Value = expenseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to Update..Once Approved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Expenses set Year=@d3,Months=@d4,Date=@d5,Expense=@d6,Cost=@d7,TotalPaid=@d8,Duepayment=@d9,Description=@d10,Payee=@d11,Telephone=@d12,Email=@d13,Address=@d14 where ExpenseID=@d1 and Comment!='Approved'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value = cashierid.Text.Trim();
                cmd.Parameters["@d3"].Value = year.Text.Trim();
                cmd.Parameters["@d4"].Value = months.Text.Trim();
                cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                cmd.Parameters["@d6"].Value = service.Text.Trim();
                cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                cmd.Parameters["@d9"].Value = 0;
                cmd.Parameters["@d10"].Value = description.Text;
                cmd.Parameters["@d11"].Value = names.Text.Trim();
                cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                cmd.Parameters["@d13"].Value = email.Text;
                cmd.Parameters["@d14"].Value = address.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
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
            string numbers = null;
            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM Account where AccountNumber='" + accountno.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        numberphone = rdr.GetString(0);
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    string smsheader = Properties.Settings.Default.Smscode;
                    string inquiryphone = Properties.Settings.Default.phoneinquiry;
                    string usernamess = Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                    numbers = "+256" + numberphone;
                    // messages = "A Loan Application Fees Payment of " + AmountPayable.Text + " Has been made from your account No. " + AccountNumber.Text + ", Accout Name " + AccountName.Text + "  and your account balance is " + accountbalance.Text;
                    messages = smsheader + ": Your Account has been Debited UGX. " + clientcost.Text + " Reason:" + service.Text + " Expense. For Any Inquiries Call: " + inquiryphone;

                    WebClient client = new WebClient();
                    string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username=" + usernamess + "&password=" + passwordss + "&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                    client.OpenRead(baseURL);
                    //MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Internet Connection, The message was not sent");
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            if (managername.Text == "")
            {
                MessageBox.Show("Please enter manager Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managername.Focus();
                return;
            }
            if (comment.Text == "")
            {
                MessageBox.Show("Please enter comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comment.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Expenses set Comment=@d2,ManagerID=@d3,ManagerName=@d4 where ExpenseID=@d1 and Months=@d6 and Year=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "Comment"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "ManagerID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "ManagerName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value = comment.Text.Trim();
                cmd.Parameters["@d3"].Value = managerid.Text.Trim();
                cmd.Parameters["@d4"].Value = managername.Text.Trim();
                cmd.Parameters["@d5"].Value = year.Text.Trim();
                cmd.Parameters["@d6"].Value = months.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                if (comment.Text == "Approved")
                {
                    SqlDataReader rdr = null;
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
                        int newtotalammount = totalaamount - Convert.ToInt32(cost.Value);
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + expensedate.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    int newaccountbal = 0;
                    int accountbal = 0;
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct6 = "select Accountbalance from Savings where AccountNo= '" + accountno.Text + "' and Approval='Approved' order by ID DESC";
                        cmd = new SqlCommand(ct6);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            accountbal = Convert.ToInt32(rdr["Accountbalance"]);

                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            //return;
                        }
                        else
                        {
                            accountbal = 0;

                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    newaccountbal = accountbal - clientcost.Value;
                    auto2();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb6 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,DepositDate,Debit,Approval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Approved')";
                    cmd = new SqlCommand(cb6);
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
                    cmd.Parameters["@d1"].Value = accountno.Text;
                    cmd.Parameters["@d2"].Value = savingsids;
                    cmd.Parameters["@d3"].Value = cashiername.Text;
                    cmd.Parameters["@d4"].Value = expensedate.Text;
                    cmd.Parameters["@d5"].Value = clientcost.Value;
                    cmd.Parameters["@d6"].Value = newaccountbal;
                    cmd.Parameters["@d7"].Value = "Paid for " + service.Text;
                    cmd.Parameters["@d8"].Value = "Transfer";
                    cmd.Parameters["@d9"].Value = accountnames.Text;
                    cmd.Parameters["@d10"].Value = cashiername.Text;
                    cmd.Parameters["@d11"].Value = expensedate.Text;
                    cmd.Parameters["@d12"].Value = clientcost.Value;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string smsallow = Properties.Settings.Default.smsallow;
                    if (smsallow == "Yes")
                    {
                        sendmessage();
                    }
                }
                MessageBox.Show("Successful", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Reset();
               
                dataload();
                dataGridViewX1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                comment.Text = dr.Cells[0].Value.ToString();
                expenseid.Text = dr.Cells[1].Value.ToString();
                cashiername.Text = dr.Cells[2].Value.ToString();
                expensedate.Text = dr.Cells[5].Value.ToString();
                service.Text = dr.Cells[6].Value.ToString();
                cost.Text = dr.Cells[8].Value.ToString();
                description.Text = dr.Cells[10].Value.ToString();
                names.Text = dr.Cells[11].Value.ToString();
                tel.Text = dr.Cells[12].Value.ToString();
                email.Text = dr.Cells[13].Value.ToString();
                address.Text = dr.Cells[14].Value.ToString();
                expensetype.Text = dr.Cells[16].Value.ToString();
                cmbModeOfPayment.Text = dr.Cells[17].Value.ToString();
                accountno.Text = dr.Cells[18].Value.ToString();
                accountnames.Text = dr.Cells[19].Value.ToString();
                LoanID.Text = dr.Cells[20].Value.ToString();
                clientcost.Text = dr.Cells[7].Value.ToString();
                cost.Enabled = false;
                clientcost.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ExpensesApplication='Yes'";
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
                    con.Close();
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

        private void frmEXpenses_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExpensesRecord frm = new frmExpensesRecord();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void managerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(managerid.Text, "essentialfinance");
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ExpensesApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        managername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        managername.Text = "";
                    }
                    con.Close();
                }
                else
                {
                    managername.Text = "";
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
        string printoptionss = Properties.Settings.Default.PrintOptions;

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (expensetype.Text == "")
            {
                MessageBox.Show("Please enter Expense Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expensetype.Focus();
                return;
            }

            if (cashiername.Text == "")
            {
                MessageBox.Show("Please enter cashier Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (cashierid.Text == "")
            {
                MessageBox.Show("Please enter cashier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashierid.Focus();
                return;
            }
            if (cost.Text == "")
            {
                MessageBox.Show("Please enter Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost.Focus();
                return;
            }
           
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
          
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Duepayment from Expenses where ExpenseID='" + expenseid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update Expenses set Duepayment=@d9 where ExpenseID=@d1";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashierid.Text.Trim();
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,LoanID,AccountNumber,AccountNames,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashiername.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(clientcost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.Parameters["@d18"].Value = LoanID.Text;
                    cmd.Parameters["@d19"].Value = accountno.Text;
                    cmd.Parameters["@d20"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    auto();
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,LoanID,AccountNumber,AccountNames,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = cashiername.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(clientcost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.Parameters["@d18"].Value = LoanID.Text;
                    cmd.Parameters["@d19"].Value = accountno.Text;
                    cmd.Parameters["@d20"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                company();
                try
                {
                    
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    rptReceiptExpenses rpt = new rptReceiptExpenses(); //The report you created.
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
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", expenseid.Text);
                    rpt.SetParameterValue("paidto", names.Text);
                    rpt.SetParameterValue("paidfor", service.Text);
                    rpt.SetParameterValue("ammount", cost.Value);
                    rpt.SetParameterValue("totalpaid", Convert.ToInt32(cost.Value));
                    rpt.SetParameterValue("duepayment", 0);
                    rpt.SetParameterValue("issuedby", cashiername.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    myConnection.Close();
                    if (printoptionss == "autoprint")
                    {
                        string BarPrinter = Properties.Settings.Default.frontendprinter;
                        rpt.PrintOptions.PrinterName = BarPrinter;
                        rpt.PrintToPrinter(1, true, 1, 1);
                    }
                    else
                    {
                        frm.ShowDialog();
                    }
                    frm.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                buttonX5.Enabled = false;
                dataload();
                dataGridViewX1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
           
        }

        private void LoanID_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            LoanID.Text = frm.LoanID.Text;
        }

        private void LoanID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AccountNo,AccountName from Loan where LoanID= '" + LoanID.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountno.Text = rdr["AccountNo"].ToString();
                    accountnames.Text = rdr["AccountName"].ToString();

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
