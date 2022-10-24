using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class FrmSavingsRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmSavingsRecord()
        {
            InitializeComponent();
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
        }

        private void buttonX5_Click(object sender, EventArgs e)
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

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction],(Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridView1.DataSource = myDataSet.Tables["Savings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavingsSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  SavingsID Like '" + SavingsSearch.Text + "%' OR AccountNo Like '" + SavingsSearch.Text + "%' OR AccountName Like '" + SavingsSearch.Text + "%' OR CashierName Like '" + SavingsSearch.Text + "%' OR Date Like '" + SavingsSearch.Text + "%' OR Deposit Like '" + SavingsSearch.Text + "%' OR Transactions Like '" + SavingsSearch.Text + "%' OR SubmittedBy Like '" + SavingsSearch.Text + "%' OR ModeOfPayment Like '" + SavingsSearch.Text + "%' OR Accountbalance Like '" + SavingsSearch.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridView1.DataSource = myDataSet.Tables["Savings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }

        private void buttonX8_Click(object sender, EventArgs e)
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

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Savings.AccountNo)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Date)[Date],(Accountbalance)[Account Balance],RTRIM(Freezed)[Frozen] from Savings  INNER JOIN (SELECT AccountNo, Max(ID) as ID from Savings group by AccountNo) AS b ON Savings.AccountNo=b.AccountNo and Savings.ID=b.ID ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridView2.DataSource = myDataSet.Tables["Savings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            transactiontype.Text = "";
            datefrom.Text = DateTime.Today.ToString();
            dateto.Text = DateTime.Today.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
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

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  Date between @date1 and @date2 and Transactions='" + transactiontype.Text+"' order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridView3.DataSource = myDataSet.Tables["Savings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSavingsRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Distinct Transactions from Savings";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    transactiontype.Items.Add(rdr[0].ToString().Trim());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSavingsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "All")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval] from SavingsTransactions where  Date between @date1 and @date2 order by ID DESC", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker2.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "SavingsTransactions");
                    dataGridView4.DataSource = myDataSet.Tables["SavingsTransactions"].DefaultView;
                    con.Close();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval] from SavingsTransactions where  Date between @date1 and @date2 and Approval='" + comboBox1.Text + "' order by ID DESC", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker2.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "SavingsTransactions");
                    dataGridView4.DataSource = myDataSet.Tables["SavingsTransactions"].DefaultView;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text= DateTime.Today.ToString();
            comboBox1.Text = "";
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

        private void buttonX13_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            withdrawfrom.Text = DateTime.Today.ToString();
            withdrawto.Text = DateTime.Today.ToString();
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
                cmd = new SqlCommand("select RTrim(PaymentID)[Withdraw ID], RTRIM(Account)[Account No.], RTRIM(Date)[Transaction Date], RTRIM(withdrawfee)[Amount Charged] from WithdrawCharges where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = withdrawfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = withdrawto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "WithdrawCharges");
                dataGridView5.DataSource = myDataSet.Tables["WithdrawCharges"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            transferfrom.Text = DateTime.Today.ToString();
            transferto.Text = DateTime.Today.ToString();
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            if (dataGridView6.DataSource == null)
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

                rowsTotal = dataGridView6.RowCount - 1;
                colsTotal = dataGridView6.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView6.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView6.Rows[I].Cells[j].Value;
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

        private void buttonX18_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Transaction ID], RTRIM(Account)[Account No.], RTRIM(Date)[Transaction Date], RTRIM(Transferfee)[Amount Charged] from TransferCharges where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value =transferfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = transferto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "TransferCharges");
                dataGridView6.DataSource = myDataSet.Tables["TransferCharges"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            dataGridView7.DataSource = null;
            monthlyfrom.Text = DateTime.Today.ToString();
            monthlyto.Text = DateTime.Today.ToString();
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
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

                rowsTotal = dataGridView7.RowCount - 1;
                colsTotal = dataGridView7.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView7.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView7.Rows[I].Cells[j].Value;
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

        private void buttonX21_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Account)[Account No.],RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(MonthlyFee)[Amount Charged] from MonthlyCharges where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = transferfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = transferto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "MonthlyCharges");
                dataGridView7.DataSource = myDataSet.Tables["MonthlyCharges"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
