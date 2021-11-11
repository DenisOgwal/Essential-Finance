using System;
using System.Data;
using System.Windows.Forms;


namespace Banking_System
{
    public partial class Receipt : Form
    {
        DataTable dtable = new DataTable();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public Receipt()
        {
            InitializeComponent();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            try
            {/*
                Cursor = Cursors.WaitCursor;
               // timer1.Enabled = true;

                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AloansDataset myDS = new AloansDataset();
                RecieptTest rpt = new RecieptTest();
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings  ";
               // MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = Datefrom.Value.Date;
                //MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = Dateto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                //rpt.SetParameterValue("datefrom", Datefrom.Value);
                //rpt.SetParameterValue("Dateto", Dateto.Value);
                crystalReportViewer1.ReportSource = rpt;
                rpt.PrintToPrinter(1, true, 1, 2);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
