using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
namespace Banking_System
{
    public partial class frmLoanUpdate : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string day;
        public string month;
        public string year;
        public frmLoanUpdate()
        {
            InitializeComponent();
        }
        public int dayss = 2;
        string repaymentdate=null;
        
        DateTime startdate = DateTime.Parse(DateTime.Today.ToShortDateString()).Date;
        public void dataload()
        {

            try
            {
                string repaymentdate1 = null;
                repaymentdate1 = (startdate.AddDays(dayss)).ToShortDateString();
                DateTime dt = DateTime.Parse(repaymentdate1);
                repaymentdate = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(LoanID)[LoanID],RTRIM(MaturityDate)[Maturity Date] from Loan where  MaturityDate <= '" + repaymentdate + "' and Issued !='Pending' and Clearance !='Cleared' ", con);
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
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select Interest from RepaymentSchedule where LoanID='" + row.Cells[0].Value.ToString().Trim() + "' and PaymentStatus='Pending'  order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb2 = "UPDATE Loan SET Clearance='Arrears' WHERE LoanID=@d1";
                                cmd = new SqlCommand(cb2);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString().Trim();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            else
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb2 = "UPDATE Loan SET Clearance='Cleared' WHERE LoanID=@d1";
                                cmd = new SqlCommand(cb2);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString().Trim();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            con.Close();

                        }
                    }
                    dataGridView1.DataSource = null;
                    if (dataGridView1.DataSource == null)
                    {
                        this.Hide();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Your Not Connected to Internet, The Loan Reminder messages were not sent");
                dataGridView1.DataSource = null;
                if (dataGridView1.DataSource == null)
                {
                    this.Hide();
                }
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void frmmonthlydatagrid_Shown(object sender, EventArgs e)
        {
            dataload();
        }

       
    }
}
