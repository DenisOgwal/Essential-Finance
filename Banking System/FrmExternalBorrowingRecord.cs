using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class FrmExternalBorrowingRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        ConnectionString cs = new ConnectionString();
        public FrmExternalBorrowingRecord()
        {
            InitializeComponent();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            datefrom.Text = DateTime.Today.ToString();
            dateto.Text = DateTime.Today.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID],(LoanAmmount)[Loan Amount],RTRIM(Date)[Receive Date],RTRIM(Period)[Servicing Period],RTRIM(ServicingInterval)[Repayment Interval] ,RTRIM(InterestRate)[Interest Rate],RTRIM(Lender)[Lender],RTRIM(Securities)[Securities],RTRIM(OfficerName)[Officer Name],RTRIM(Method)[Method] from ExternalLoans where Date between @date1 and @date2 order by ID Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridView1.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmExternalBorrowingRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void FrmExternalBorrowingRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct PaymentStatus FROM ExternalRepaymentSchedule";
                rdr = cmd.ExecuteReader();
                while (rdr.Read()==true)
                {
                    schedules.Items.Add(rdr[0].ToString());
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
            try
            {
                if (schedules.Text == "All")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(PaymentDate)[Repayment Date], RTRIM(Months)[Installment],(AmmountPay)[Principal], (Interest)[Interest], (TotalAmmount)[Total Amount], (BalanceExist)[Balance Exist], RTRIM(PaymentStatus)[Payment Status] from ExternalRepaymentSchedule where  PaymentDate between @date1 and @date2 order by ID Asc", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = externalschedulefrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = externalscheduleto.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                    dataGridView2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                    con.Close();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(PaymentDate)[Repayment Date], RTRIM(Months)[Installment],(AmmountPay)[Principal], (Interest)[Interest], (TotalAmmount)[Total Amount], (BalanceExist)[Balance Exist], RTRIM(PaymentStatus)[Payment Status] from ExternalRepaymentSchedule where  PaymentDate between @date1 and @date2 and PaymentStatus ='" + schedules.Text + "' order by ID Asc", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = externalschedulefrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = externalscheduleto.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                    dataGridView2.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                    con.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            externalschedulefrom.Text = DateTime.Today.ToString();
            externalscheduleto.Text = DateTime.Today.ToString();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            externalrepaymentsfrom.Text = DateTime.Today.ToString();
            externalrepaymentsto.Text = DateTime.Today.ToString();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(RepaymentID)[Repayment ID],RTRIM(LoanID)[Loan ID], (AmmountPaid)[Paid Ammount],(Balance)[Balance],RTRIM(RepayMonths)[Installment], RTRIM(RepaymentDate)[Date], RTRIM(ModeOfPayment)[Payment Mode], RTRIM(PaidBy)[Paid By] from ExternalLoanRepayment where Repaymentdate between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RePaymentdate").Value = externalrepaymentsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RePaymentdate").Value = externalrepaymentsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoanRepayment");
                dataGridView3.DataSource = myDataSet.Tables["ExternalLoanRepayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            upcomingdate.Text = DateTime.Today.ToString();
            Daysleft.Text = "";
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView4.RowCount - 1;
                colsTotal = dataGridView4.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView4.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView4.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }
        int daynum = 0;
        private void buttonX12_Click(object sender, EventArgs e)
        {
            try
            {
                daynum = Convert.ToInt32(Daysleft.Text);
                DateTime schedule = DateTime.Parse(upcomingdate.Text).Date;
                string paymentdates = (schedule.AddDays(daynum)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(PaymentDate)[Repayment Date], RTRIM(Months)[Installment],(AmmountPay)[Principal], (Interest)[Interest], (TotalAmmount)[Total Amount], (BalanceExist)[Balance Exist], RTRIM(PaymentStatus)[Payment Status] from ExternalRepaymentSchedule where PaymentDate= @date1 and PaymentStatus='Pending' order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalRepaymentSchedule");
                dataGridView4.DataSource = myDataSet.Tables["ExternalRepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            externalfrom.Text = DateTime.Today.ToString();
            externalto.Text = DateTime.Today.ToString();
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            if (dataGridView5.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView5.RowCount - 1;
                colsTotal = dataGridView5.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView5.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView5.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(MemberID)[Loan ID], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By],(FineFee)[Amount Paid], RTRIM(Reason)[Reason]from ExternalLoanFines where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = externalfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = externalto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoanFines");
                dataGridView5.DataSource = myDataSet.Tables["ExternalLoanFines"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
