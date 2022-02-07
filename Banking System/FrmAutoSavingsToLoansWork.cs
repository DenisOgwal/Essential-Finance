using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class FrmAutoSavingsToLoansWork : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        ConnectionString cs = new ConnectionString();
        string paymentid = null;
        string savingsid = null;
        string repaymentid = null;

        public FrmAutoSavingsToLoansWork()
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
            cmd = new SqlCommand("select ID from Savings where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from Savings where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string years = yearss.Substring(2, 2);
            paymentid = "STL-" + years + monthss + days + realid;
            repaymentid = "RID-" + years + monthss + days + realid;
            savingsid = "S-" + years + monthss + days + realid;
        }
        public void dataload()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(LoanID)[Loan ID], RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Names],RTRIM(Months)[Installment],RTRIM(PaymentDate)[Payment Date],RTRIM(TotalAmmount)[TotalAmmount], RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest] , RTRIM(BalanceExist)[Balance Exist] from RepaymentSchedule where  PaymentDate <= @date1 and BalanceExist >0 ORDER BY ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridView1.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void frmrecordsselection_Load(object sender, EventArgs e)
        {
            //dataload();

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[0].Value) != null)
                        {
                           // RTrim(LoanID)[Loan ID], RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Names],RTRIM(Months)[Installment],RTRIM(PaymentDate)[Payment Date],RTRIM(TotalAmmount)[TotalAmmount], RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest] , RTRIM(BalanceExist)[Balance Exist]
                            string loanid = row.Cells[0].Value.ToString().Trim();
                            string Accountno = row.Cells[1].Value.ToString().Trim();
                            string installment = row.Cells[3].Value.ToString().Trim();
                            int totalammount = Convert.ToInt32(Convert.ToDouble(row.Cells[8].Value.ToString()));
                            int Principal = Convert.ToInt32(Convert.ToDouble(row.Cells[6].Value));
                            int interest = Convert.ToInt32(Convert.ToDouble(row.Cells[7].Value));
                            int Accountbalance = 0;
                            int NewAccountBalance = 0;

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Accountbalance from Savings where AccountNo= '" + Accountno + "' order by ID DESC";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Accountbalance = Convert.ToInt32(rdr["Accountbalance"]);
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                               
                            }
                            else
                            {
                                Accountbalance = 0;
                            }
                            //if (Accountbalance >= totalammount)
                            //{
                                NewAccountBalance = Accountbalance - totalammount;
                                try
                                {
                                    auto();
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "insert into SavingsToLoans(PaymentID,AccountNo,AccountNames,Date,LoanID,TransferedAmmount,CashierName,Details) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNo"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountNames"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TransferedAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "CashierName"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Text, 2000, "Details"));
                                    cmd.Parameters["@d1"].Value = paymentid;
                                    cmd.Parameters["@d2"].Value = Accountno;
                                    cmd.Parameters["@d3"].Value = row.Cells[2].Value.ToString().Trim();
                                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text;
                                    cmd.Parameters["@d5"].Value = loanid;
                                    cmd.Parameters["@d6"].Value = totalammount;
                                    cmd.Parameters["@d7"].Value = "Auto";
                                    cmd.Parameters["@d8"].Value = "Auto Transfer From Savings to Clear Loan";
                                    //cmd.ExecuteReader();
                                    con.Close();

                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,Debit,DepositDate,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d5,'" + dateTimePicker1.Text + "','Approved','Auto')";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Transactions"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                                    cmd.Parameters["@d1"].Value = Accountno;
                                    cmd.Parameters["@d2"].Value = savingsid;
                                    cmd.Parameters["@d3"].Value ="Auto";
                                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text;
                                    cmd.Parameters["@d5"].Value = totalammount;
                                    cmd.Parameters["@d6"].Value = NewAccountBalance;
                                    cmd.Parameters["@d7"].Value = "Paid Loan";
                                    cmd.Parameters["@d8"].Value = "Transfer";
                                    cmd.Parameters["@d9"].Value = row.Cells[2].Value.ToString().Trim();
                                    cmd.Parameters["@d10"].Value = "Auto";
                                    //cmd.ExecuteNonQuery();
                                    con.Close();
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb4 = "insert into LoanRepayment(RepaymentID,AmmountPaid,Balance,RepayMonths,CashierID,LoanID,MemberID,CashierName,Repaymentdate,Interest,TotalAmmount,MemberName,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                                    cmd = new SqlCommand(cb4);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "RepaymentID"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "AmmountPaid"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Balance"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "RepayMonths"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "CashierID"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "MemberID"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "CashierName"));
                                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "Repaymentdate"));
                                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "Interest"));
                                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 20, "TotalAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "MemberName"));
                                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                                    cmd.Parameters["@d1"].Value = repaymentid;
                                    cmd.Parameters["@d2"].Value = totalammount;
                                    cmd.Parameters["@d3"].Value = 0;
                                    cmd.Parameters["@d4"].Value = installment;
                                    cmd.Parameters["@d5"].Value = "Auto";
                                    cmd.Parameters["@d6"].Value = loanid;
                                    cmd.Parameters["@d7"].Value = Accountno;
                                    cmd.Parameters["@d8"].Value = "Auto";
                                    cmd.Parameters["@d9"].Value = dateTimePicker1.Text;
                                    cmd.Parameters["@d10"].Value = interest;
                                    cmd.Parameters["@d11"].Value = totalammount;
                                    cmd.Parameters["@d12"].Value = row.Cells[2].Value.ToString().Trim();
                                    cmd.Parameters["@d13"].Value = "Transfer";
                                    //cmd.ExecuteNonQuery();
                                    con.Close();

                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb5 = "update RepaymentSchedule set PaymentStatus=@d1,BalanceExist=@d3,PaymentDate=@d4 where LoanID=@d2 and Months=@d5";
                                    cmd = new SqlCommand(cb5);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "BalanceExist"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "Months"));
                                    cmd.Parameters["@d1"].Value = "Paid";
                                    cmd.Parameters["@d2"].Value = loanid;
                                    cmd.Parameters["@d3"].Value = 0;
                                    cmd.Parameters["@d4"].Value = dateTimePicker1.Text;
                                    cmd.Parameters["@d5"].Value = installment;
                                    //cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception Ex)
                                {
                                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            //}
                        }

                    }
                }
                dataGridView1.DataSource = null;
                if (dataGridView1.DataSource == null)
                {
                    this.Hide();
                    FrmInvestorDebit frm = new FrmInvestorDebit();
                    frm.Show();
                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void frmmonthlydatagrid_Shown(object sender, EventArgs e)
        {
            dataload();

        }
    }
}
