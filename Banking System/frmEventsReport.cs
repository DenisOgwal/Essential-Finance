using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmEventsReport : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public frmEventsReport()
        {
            InitializeComponent();
        }

        private void frmEventsReport_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptEvents rpt = new rptEvents();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from Event";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Event");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEventsReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }
    }
}
