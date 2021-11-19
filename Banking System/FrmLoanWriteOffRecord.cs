using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanWriteOffRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmLoanWriteOffRecord()
        {
            InitializeComponent();
        }

        private void FrmLoanWriteOffRecord_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account Number],RTRIM(AccountNames)[Account Names],RTRIM(Reason)[Request Reason],RTRIM(RequestDate)[Request Date],RTRIM(RequestedBy)[Requested By],RTRIM(Approval)[Approval],RTRIM(ApprovalComment)[Approval Comment],RTRIM(ApprovalDate)[Approval Date],RTRIM(ApprovedBy)[Approved By] from WriteOff where LoanID='" + label1.Text + "'  order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "WriteOff");
                dataGridView1.DataSource = myDataSet.Tables["WriteOff"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
