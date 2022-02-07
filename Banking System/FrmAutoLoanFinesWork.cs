using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class FrmAutoLoanFinesWork : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmAutoLoanFinesWork()
        {
            InitializeComponent();
        }
        public void dataload()
        {
            try
            {
                int days = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                DateTime schedule = DateTime.Parse(dateTimePicker1.Text).Date;
                string paymentdates = (schedule.AddDays(-days)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Months)[Repayment Installment], (TotalAmmount)[Amount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status],RTRIM(Rates)[Rate],RTRIM(IssuedAmmount)[Issued Ammount],RTRIM(LoanType)[Loan Type] from RepaymentSchedule where PaymentStatus='Pending' and PaymentDate < @date1 and Accrued='No' order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
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
                            string repaymentmonths = null;
                            double fines = 0.00;
                            double balanceexist = 0.00;
                            if (row.Cells[12].Value.ToString().Trim() == "Monthly")
                            {
                                repaymentmonths = row.Cells[3].Value.ToString();
                                double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                double realammount = Convert.ToDouble(row.Cells[11].Value);
                                int noofdays = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                                fines = (((intrestrate / 100) / 30) * noofdays) * realammount;
                                balanceexist = Convert.ToDouble(row.Cells[4].Value) + fines;
                            }else if(row.Cells[12].Value.ToString().Trim() == "Weekly")
                            {
                                repaymentmonths = row.Cells[3].Value.ToString();
                                double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                double realammount = Convert.ToDouble(row.Cells[11].Value);
                                int noofdays = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                                fines = (((intrestrate / 100) / 7) * noofdays) * realammount;
                                balanceexist = Convert.ToDouble(row.Cells[4].Value) + fines;
                            }
                            else if (row.Cells[12].Value.ToString().Trim() == "Daily")
                            {
                                repaymentmonths = row.Cells[3].Value.ToString();
                                double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                double realammount = Convert.ToDouble(row.Cells[11].Value);
                                int noofdays = Convert.ToInt32(Properties.Settings.Default.autoloandays);
                                fines = ((intrestrate / 100) * noofdays) * realammount;
                                balanceexist = Convert.ToDouble(row.Cells[4].Value) + fines;
                            }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "UPDATE RepaymentSchedule SET Fines=@d3,BalanceExist=@d4,Accrued='Yes' where LoanID=@d1 and Months=@d2";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Float,12, "Fines"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 12, "BalanceExist"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString();
                                cmd.Parameters["@d2"].Value = repaymentmonths;
                                cmd.Parameters["@d3"].Value =fines;
                                cmd.Parameters["@d4"].Value = balanceexist;
                                cmd.ExecuteNonQuery();
                                con.Close();                         
                        }
                    }
                }
                dataGridView1.DataSource = null;
                if (dataGridView1.DataSource == null)
                {
                    FrmAutoSavingsToLoansWork frm = new FrmAutoSavingsToLoansWork();
                    frm.Show();
                    this.Hide();
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
