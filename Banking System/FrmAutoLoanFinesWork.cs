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
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Months)[Repayment Installment], (TotalAmmount)[Amount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status],RTRIM(Rates)[Rate],RTRIM(IntrestType)[Intrest Type],RTRIM(Accrued)[Accrued] from RepaymentSchedule where PaymentStatus='Pending' and PaymentDate < @date1 order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(dateTimePicker1.Text).Date;
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

                            if (row.Cells[11].Value.ToString().Trim() == "Flat Rate" && row.Cells[12].Value.ToString().Trim() == "No")
                            {
                                float creditperiod = 1;
                                string repaymentmonths = row.Cells[3].Value.ToString();
                                double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                double realammount = Convert.ToDouble(row.Cells[4].Value);
                                double principal = realammount / creditperiod;
                                double interest = ((intrestrate / (100)) * principal);
                                double repaymentammount = principal + interest;

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "UPDATE RepaymentSchedule SET TotalAmmount=@d5,AmmountPay=@d6,Interest=@d7,BalanceExist=@d9,BeginningBalance=@d11,Accrued='Yes' where LoanID=@d1 and Months=@d3";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString();
                                cmd.Parameters["@d3"].Value = repaymentmonths;
                                cmd.Parameters["@d5"].Value = repaymentammount;
                                cmd.Parameters["@d6"].Value = principal;
                                cmd.Parameters["@d7"].Value = interest;
                                cmd.Parameters["@d9"].Value = repaymentammount;
                                cmd.Parameters["@d11"].Value = repaymentammount;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            else if (row.Cells[11].Value.ToString().Trim() == "Reducing Balance" && row.Cells[12].Value.ToString().Trim() == "No")
                            {
                                float creditperiod = 1;
                                string repaymentmonths = row.Cells[3].Value.ToString();
                                double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                double realammount = Convert.ToDouble(row.Cells[4].Value);
                                double principal = realammount / creditperiod;
                                double interest = ((intrestrate / (100)) * principal);
                                double repaymentammount = principal + interest;
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "UPDATE RepaymentSchedule SET TotalAmmount=@d5,AmmountPay=@d6,Interest=@d7,BalanceExist=@d9 where LoanID=@d1 and Months=@d3";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString();
                                cmd.Parameters["@d3"].Value = repaymentmonths;
                                cmd.Parameters["@d5"].Value = repaymentammount;
                                cmd.Parameters["@d6"].Value = principal;
                                cmd.Parameters["@d7"].Value = interest;
                                cmd.Parameters["@d9"].Value = repaymentammount;
                                cmd.ExecuteNonQuery();
                                con.Close();

                            }
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
