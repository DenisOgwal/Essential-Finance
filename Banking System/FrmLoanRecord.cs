using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanRecord : Form
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
        public FrmLoanRecord()
        {
            InitializeComponent();
        }

        private void FrmLoanRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID],RTRIM(ApplicationDate)[Application Date],RTRIM(ServicingPeriod)[Servicing Period],RTRIM(RepaymentInterval)[Repayment Interval] ,RTRIM(Interest)[Interest Rate],RTRIM(RefereeName)[Referee Name],RTRIM(RefereeTel)[Referee Tel],RTRIM(RefereeAddress)[Referee Address],RTRIM(RefereeRelationShip)[Referee Relationship] from Loan where LoanID='" + label1.Text+"' order by ID DESC", con);
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
    }
}
