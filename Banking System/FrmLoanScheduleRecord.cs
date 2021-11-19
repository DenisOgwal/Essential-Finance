using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanScheduleRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmLoanScheduleRecord()
        {
            InitializeComponent();
        }

        private void FrmLoanScheduleRecord_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Months)[Installment],RTRIM(LoanID)[Loan ID],RTRIM(AmmountPay)[Principal],RTRIM(Interest)[Interest],RTRIM(TotalAmmount)[Amount Payable],RTRIM(BalanceExist)[Balance Exist],RTRIM(PaymentStatus)[Payment Status] from RepaymentSchedule where LoanID='" + label1.Text + "'  order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridView1.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
