using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class frmExternalPaymentSchedule : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmExternalPaymentSchedule()
        {
            InitializeComponent();
        }
        public void dataload1()
        {
            try
            {
                DateTime schedule = DateTime.Parse(DateTo.Text).Date;
                string paymentdates = (schedule.AddDays(1)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Months)[Repayment Installment], (TotalAmmount)[Amount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from ExternalRePaymentSchedule where PaymentStatus='Pending' and PaymentDate = @date1 order by ExternalRepaymentSchedule.ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPaymentSchedule_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            dataload1();
        }
    
        public void dataload()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Months)[Repayment Months], (TotalAmmount)[Amount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from ExternalRePaymentSchedule where PaymentDate between @date1 and @date2 and BalanceExist>0 order by ExternalRepaymentSchedule.ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            dataload();
        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {
            dataload();
        }
        public void dataload2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Months)[Repayment Months],(TotalAmmount)[Amount Payable],(AmmountPay)[Principal],(Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status]from ExternalRePaymentSchedule where  LoanID='" + loanid.Text + "' order by ExternalRepaymentSchedule.ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loanid_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataload2();
        }
        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails6 frm = new frmClientDetails6();
            frm.ShowDialog();
            loanid.Text = frm.clientnames.Text;
        }

        private void loanid_TextChanged(object sender, EventArgs e)
        {
            dataload2();
        }
    }
}
