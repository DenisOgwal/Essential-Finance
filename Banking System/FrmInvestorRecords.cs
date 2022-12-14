using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Banking_System
{
    public partial class FrmInvestorRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmInvestorRecords()
        {
            InitializeComponent();
        }

        private void FrmInvestorRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void FrmInvestorRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
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
                cmd = new SqlCommand("select RTrim(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(RegistrationDate)[Registration Date], RTRIM(Gender)[Gender],RTRIM(DOB)[DOB], RTRIM(MaritalStatus)[Marital Status], RTRIM(Nationality)[Nationality], RTRIM(NationalityStatus)[Nationality Status], RTRIM(IDForm)[ID Form], RTRIM(ClientID)[Client ID], RTRIM(ContactNo)[Contact No. 1], RTRIM(ContactNo1)[Contact No. 2], RTRIM(OfficeNo)[Office No], RTRIM(Email)[Email], RTRIM(PhysicalAddress)[Physical Address], RTRIM(PostalAddress)[Postal Address], RTRIM(BankName)[Bank Name], RTRIM(BankAccountName)[Bank Account Name], RTRIM(BankAccountNumber)[Bank Account Number], RTRIM(AccountType)[Account Type], RTRIM(NOKName)[NOK Name], RTRIM(NOKContactNo)[NOK Contact No], RTRIM(NOKAddress)[NOK Address], RTRIM(CreatedBy)[Created By] from InvestorAccount where  RegistrationDate between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RegistrationDate").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RegistrationDate").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorAccount");
                dataGridView1.DataSource = myDataSet.Tables["InvestorAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(RegistrationDate)[Registration Date], RTRIM(Gender)[Gender],RTRIM(DOB)[DOB], RTRIM(MaritalStatus)[Marital Status], RTRIM(Nationality)[Nationality], RTRIM(NationalityStatus)[Nationality Status], RTRIM(IDForm)[ID Form], RTRIM(ClientID)[Client ID], RTRIM(ContactNo)[Contact No. 1], RTRIM(ContactNo1)[Contact No. 2], RTRIM(OfficeNo)[Office No], RTRIM(Email)[Email], RTRIM(PhysicalAddress)[Physical Address], RTRIM(PostalAddress)[Postal Address], RTRIM(BankName)[Bank Name], RTRIM(BankAccountName)[Bank Account Name], RTRIM(BankAccountNumber)[Bank Account Number], RTRIM(AccountType)[Account Type], RTRIM(NOKName)[NOK Name], RTRIM(NOKContactNo)[NOK Contact No], RTRIM(NOKAddress)[NOK Address], RTRIM(CreatedBy)[Created By] from InvestorAccount where  AccountNumber like '" + accountsearch.Text + "%' OR AccountNames like '" + accountsearch.Text + "%' OR RegistrationDate like '" + accountsearch.Text + "%' OR Gender like '" + accountsearch.Text + "%' OR Nationality like '" + accountsearch.Text + "%' OR NationalityStatus like '" + accountsearch.Text + "%' OR PhysicalAddress like '" + accountsearch.Text + "%' OR Email like '" + accountsearch.Text + "%' OR ContactNo like '" + accountsearch.Text + "%' OR OfficeNo like '" + accountsearch.Text + "%' OR BankName like '" + accountsearch.Text + "%' OR BankAccountName like '" + accountsearch.Text + "%' order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RegistrationDate").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RegistrationDate").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorAccount");
                dataGridView1.DataSource = myDataSet.Tables["InvestorAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
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

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                int days = 30;
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(SavingsID)[Savings ID], RTRIM(Date)[Plan Start Date],(Deposit)[Amount], RTRIM(InvestmentPlan)[Investment Plan], RTRIM(DepositInterval)[Deposit Interval], RTRIM(DepositedInstallmentNo)[No. of Deposit], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(InterestRate)[Interest Rate], RTRIM(MaturityPeriod)[Maturity Period], RTRIM(MaturityDate)[Agreeed Maturity Date], RTRIM(OtherMaturityDate)[Actual Maturity Date], RTRIM(ModeOfPayment)[Payment Mode], RTRIM(Appreciated)[Appreciated] from InvestorSavings where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView2.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
                con.Close();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string installdate = row.Cells[14].Value.ToString();

                        DateTime startdate = DateTime.Parse(installdate);
                        string checkdate4 = DateTime.Today.ToShortDateString();
                        DateTime dtc4 = DateTime.Parse(checkdate4);
                        string converteddatesc4 = dtc4.ToString("dd/MMM/yyyy");
                        int daysnumber = Convert.ToInt32(startdate.Subtract(dtc4).TotalDays);

                        if (daysnumber <= days)
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                        }
                    }
                }
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
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(SavingsID)[Savings ID], RTRIM(Date)[Plan Start Date],(Deposit)[Amount],RTRIM(InvestmentPlan)[Investment Plan] ,RTRIM(DepositInterval)[Interval], RTRIM(DepositedInstallmentNo)[No. of Deposit], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(InterestRate)[Interest Rate], RTRIM(MaturityPeriod)[Maturity Period], RTRIM(MaturityDate)[Maturity Date], RTRIM(ModeOfPayment)[Payment Mode], RTRIM(Appreciated)[Appreciated] from InvestorSavings where  SavingsID Like '" + SavingsSearch.Text + "%' OR AccountNo Like '" + SavingsSearch.Text + "%' OR AccountName Like '" + SavingsSearch.Text + "%' OR CashierName Like '" + SavingsSearch.Text + "%' OR Date Like '" + SavingsSearch.Text + "%' OR Transactions Like '" + SavingsSearch.Text + "%' OR SubmittedBy Like '" + SavingsSearch.Text + "%' OR ModeOfPayment Like '" + SavingsSearch.Text + "%' OR MaturityDate Like '" + SavingsSearch.Text + "%' OR InvestmentPlan Like '" + SavingsSearch.Text + "%'  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView2.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            textBoxX1.Text = "";
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
                cmd = new SqlCommand("select RTRIM(InvestorSavings.AccountNo)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(SavingsID)[Savings ID], RTRIM(Date)[Date],(Accountbalance)[Account Balance] from InvestorSavings ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView3.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(InvestorSavings.AccountNo)[Account Number],  RTRIM(AccountName)[Account Name], RTRIM(SavingsID)[Savings ID], RTRIM(Date)[Date],(Accountbalance)[Account Balance] from InvestorSavings   where SavingsID like '" + textBoxX1.Text + "%'  ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView3.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
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
            searchtransactions.Text = "";
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

        private void searchtransactions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount],(AppreciationAmount)[Appreciation Amount],RTRIM(AppreciationNo)[Appreciation No.], (Accountbalance)[Account Balance], RTRIM(CashierName)[Staff Name], RTRIM(InterestRate)[Interest Rate], RTRIM(Appreciated)[Appreciated],RTRIM(Approved)[Approved],RTRIM(ApprovedBy)[ApprovedBy],(Debit)[Debit],(Credit)[Credit],RTRIM(PaidOut)[PaidOut] from InvestmentAppreciation where  AccountNo Like '" + searchtransactions.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestmentAppreciation");
                dataGridView4.DataSource = myDataSet.Tables["InvestmentAppreciation"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            Daysleft.Text = "";
            upcomingdate.Text= DateTime.Today.ToString();
        }

        private void buttonX26_Click(object sender, EventArgs e)
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
        int daynum = 0;
        private void buttonX27_Click(object sender, EventArgs e)
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
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(SavingsID)[Investment ID], RTRIM(Date)[Plan Start Date],(Deposit)[Amount], RTRIM(InvestmentPlan)[Investment Plan], RTRIM(DepositInterval)[Deposit Interval], RTRIM(DepositedInstallmentNo)[No. of Deposit], (Accountbalance)[Account Balance], RTRIM(InterestRate)[Interest Rate], RTRIM(MaturityPeriod)[Maturity Period], RTRIM(MaturityDate)[Agreeed Maturity Date], RTRIM(OtherMaturityDate)[Actual Maturity Date], RTRIM(Appreciated)[Appreciated] from InvestorSavings where  OtherMaturityDate between @date2 and @date1  order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateTime.Parse(repaymentdates).Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "OtherMaturityDate").Value = DateTime.Parse(upcomingdate.Text).Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView5.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
