using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanGurarantorsRecord : Form
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
        public FrmLoanGurarantorsRecord()
        {
            InitializeComponent();
        }

        private void FrmLoanRecord_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Names)[Guarantor Names],RTRIM(Residence)[Guarantor Residence],RTRIM(Relationship)[Guarantor Relationship],RTRIM(TELNo)[ Guarantor TEL] from Guarantor where LoanID='" + label1.Text+"' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Guarantor");
                dataGridView1.DataSource = myDataSet.Tables["Guarantor"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
