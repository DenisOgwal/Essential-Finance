using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class FrmTransactionsReports : Form
    {
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        DataSet ds = new DataSet();
        ConnectionString cs = new ConnectionString();
        DataTable dtable = new DataTable();
        public FrmTransactionsReports()
        {
            InitializeComponent();
        }

        private void FrmTransactionsReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void FrmTransactionsReports_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber),RTRIM(AccountNames) FROM BankAccounts", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    salarytransactions.Items.Add(drow[1].ToString());
                    expensestransactions.Items.Add(drow[1].ToString());
                    supplierdtransactions.Items.Add(drow[1].ToString());
                    drawingstransactions.Items.Add(drow[1].ToString());
                    Borrowedloantransaction.Items.Add(drow[1].ToString());
                    granttransaction.Items.Add(drow[1].ToString());
                    investmenttransactions.Items.Add(drow[1].ToString());
                    otherincomestransactions.Items.Add(drow[1].ToString());
                    savingstransactions.Items.Add(drow[1].ToString());
                    moneytrandfertransaction.Items.Add(drow[1].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX32_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                if (moneyflow.Text == "To")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptMoneyTransfer rpt = new rptMoneyTransfer();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from CashBankTransactions where Dates between @date1 and @date2 and TransactionFlow='" + moneytrandfertransaction.Text + "' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Dates").Value = moneytransferfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Dates").Value = moneytransferto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "CashBankTransactions");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("flow", moneyflow.Text);
                    rpt.SetParameterValue("transactiontype", moneytrandfertransaction.Text);
                    rpt.SetParameterValue("datefrom", moneytransferfrom.Text);
                    rpt.SetParameterValue("dateto", moneytransferto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer16.ReportSource = rpt;
                    myConnection.Close();
                }else if (moneyflow.Text == "From")
                {
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet();
                    rptMoneyTransfer rpt = new rptMoneyTransfer();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from CashBankTransactions where Dates between @date1 and @date2 and TransactionFlowFrom='" + moneytrandfertransaction.Text + "' order by ID ASC ";
                    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Dates").Value = moneytransferfrom.Value.Date;
                    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Dates").Value = moneytransferto.Value.Date;
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "CashBankTransactions");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("flow", moneyflow.Text);
                    rpt.SetParameterValue("transactiontype", moneytrandfertransaction.Text);
                    rpt.SetParameterValue("datefrom", moneytransferfrom.Text);
                    rpt.SetParameterValue("dateto", moneytransferto.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    crystalReportViewer16.ReportSource = rpt;
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            salaryfrom.Text = DateTime.Today.ToString();
            salaryto.Text = DateTime.Today.ToString();
            salarytransactions.Text = "";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = null;
            expensesfrom.Text = DateTime.Today.ToString();
            expensesto.Text = DateTime.Today.ToString();
            expensestransactions.Text = "";
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            crystalReportViewer6.ReportSource = null;
            suppliersfrom.Text = DateTime.Today.ToString();
            suppliersto.Text = DateTime.Today.ToString();
            supplierdtransactions.Text = "";
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            crystalReportViewer7.ReportSource = null;
            drawingsfrom.Text = DateTime.Today.ToString();
            drawingsto.Text = DateTime.Today.ToString();
            drawingstransactions.Text = "";
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            crystalReportViewer8.ReportSource = null;
            borrowedloanfrom.Text = DateTime.Today.ToString();
            borrowedloanto.Text = DateTime.Today.ToString();
            Borrowedloantransaction.Text = "";
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            crystalReportViewer9.ReportSource = null;
            grantfrom.Text = DateTime.Today.ToString();
            grantto.Text = DateTime.Today.ToString();
            granttransaction.Text = "";
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            crystalReportViewer10.ReportSource = null;
            investmentfrom.Text = DateTime.Today.ToString();
            investmentto.Text = DateTime.Today.ToString();
            investmenttransactions.Text = "";
        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            crystalReportViewer13.ReportSource = null;
            otherincomesfrom.Text = DateTime.Today.ToString();
            otherincomesto.Text = DateTime.Today.ToString();
            otherincomestransactions.Text = "";
        }

        private void buttonX27_Click(object sender, EventArgs e)
        {
            crystalReportViewer14.ReportSource = null;
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
            savingstransactions.Text = "";
        }

        private void buttonX31_Click(object sender, EventArgs e)
        {
            crystalReportViewer16.ReportSource = null;
            moneytransferfrom.Text = DateTime.Today.ToString();
            moneytransferto.Text = DateTime.Today.ToString();
            moneytrandfertransaction.Text = "";
        }
        public void company()
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct6 = "select * from CompanyNames";
                cmd = new SqlCommand(ct6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyname = rdr.GetString(1).Trim();
                    companyaddress = rdr.GetString(7).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptEmployeePayTransactions rpt = new rptEmployeePayTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select *  from EmployeePayment where PaymentDate between @date1 and @date2 and ModeOfPayment='"+salarytransactions.Text+"'  order by EmployeePayment.ID DESC";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = salaryfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = salaryto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "EmployeePayment");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("datefrom", salaryfrom.Text);
                rpt.SetParameterValue("dateto", salaryto.Text);
                rpt.SetParameterValue("transactiontype", salarytransactions.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer1.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptexpensesbydateTransactions rpt = new rptexpensesbydateTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Expenses where Date between @date1 and @date2 and ModeOfPayment='"+expensestransactions.Text+"' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = expensesfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = expensesto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Expenses");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", expensestransactions.Text);
                rpt.SetParameterValue("datefrom", expensesfrom.Text);
                rpt.SetParameterValue("dateto", expensesto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer2.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptSupplierTransactions rpt = new rptSupplierTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from SupplierAccountBalance where Date between @date1 and @date2 and PaymentMode='" + supplierdtransactions.Text + "' and TransactionType='Deposit' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = suppliersfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = suppliersto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SupplierAccountBalance");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", supplierdtransactions.Text);
                rpt.SetParameterValue("datefrom", suppliersfrom.Text);
                rpt.SetParameterValue("dateto", suppliersto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer6.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptDevidendsTransactions rpt = new rptDevidendsTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Drawings where Date between @date1 and @date2 and TransactionType='"+drawingstransactions.Text+"' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = drawingsfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = drawingsto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Drawings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", drawingstransactions.Text);
                rpt.SetParameterValue("datefrom", drawingsfrom.Text);
                rpt.SetParameterValue("dateto", drawingsto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer7.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptExternalLoansTransactions rpt = new rptExternalLoansTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from ExternalLoans where Date between @date1 and @date2 and ModeOfPayment='"+Borrowedloantransaction.Text+"' order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = borrowedloanfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = borrowedloanto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ExternalLoans");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", Borrowedloantransaction.Text);
                rpt.SetParameterValue("datefrom", borrowedloanfrom.Text);
                rpt.SetParameterValue("dateto", borrowedloanto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer8.ReportSource = rpt;
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptGrantsTransactions rpt = new rptGrantsTransactions();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from GrantFees where Date between @date1 and @date2 and ModeOfPayment='"+granttransaction.Text+"' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value =grantfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = grantto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "GrantFees");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", granttransaction.Text);
                rpt.SetParameterValue("datefrom", grantfrom.Text);
                rpt.SetParameterValue("dateto", grantto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer9.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                RptInvestmentTransact rpt = new RptInvestmentTransact();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from InvestmentAppreciation where Date between @date1 and @date2 and Approved='Approved' and PaymentMode='"+investmenttransactions.Text+"'  order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = investmentfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = investmentto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "InvestmentAppreciation");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", investmenttransactions.Text);
                rpt.SetParameterValue("datefrom", investmentfrom.Text);
                rpt.SetParameterValue("dateto", investmentto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer10.ReportSource = rpt;
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX26_Click(object sender, EventArgs e)
        {
            company();
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptOtherIncomes2 rpt = new rptOtherIncomes2();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from OtherIncomes where Date between @date1 and @date2 and ModeOfPayment='"+otherincomestransactions.Text+"' ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = otherincomesfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = otherincomesto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "OtherIncomes");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", otherincomestransactions.Text);
                rpt.SetParameterValue("datefrom", otherincomesfrom.Text);
                rpt.SetParameterValue("dateto", otherincomesto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer13.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX28_Click(object sender, EventArgs e)
        {
            company();
            try
            {

                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptSavings2 rpt = new rptSavings2();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Savings where Date between @date1 and @date2 and ModeOfPayment='"+savingstransactions.Text+"' order by ID ASC ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Savings");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("transactiontype", savingstransactions.Text);
                rpt.SetParameterValue("datefrom", savingsfrom.Text);
                rpt.SetParameterValue("dateto", savingsto.Text);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer14.ReportSource = rpt;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
