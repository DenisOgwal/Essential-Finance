using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Banking_System
{
    public partial class FrmAccountRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmAccountRecords()
        {
            InitializeComponent();
        }

        private void FrmAccountRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
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
                cmd = new SqlCommand("select RTrim(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(RegistrationDate)[Registration Date], RTRIM(Gender)[Gender],RTRIM(DOB)[DOB], RTRIM(MaritalStatus)[Marital Status], RTRIM(Nationality)[Nationality], RTRIM(NationalityStatus)[Nationality Status], RTRIM(IDForm)[ID Form], RTRIM(ClientID)[Client ID], RTRIM(ContactNo)[Contact No. 1], RTRIM(ContactNo1)[Contact No. 2], RTRIM(OfficeNo)[Office No], RTRIM(Email)[Email], RTRIM(PhysicalAddress)[Physical Address], RTRIM(PostalAddress)[Postal Address], RTRIM(BankName)[Bank Name], RTRIM(BankAccountName)[Bank Account Name], RTRIM(BankAccountNumber)[Bank Account Number], RTRIM(Designation)[Designation], RTRIM(EmployerName)[Employer], RTRIM(CreatedBy)[Created By] from Account where  RegistrationDate between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "RegistrationDate").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "RegistrationDate").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridView1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAccountRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void accountsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(RegistrationDate)[Registration Date], RTRIM(Gender)[Gender],RTRIM(DOB)[DOB], RTRIM(MaritalStatus)[Marital Status], RTRIM(Nationality)[Nationality], RTRIM(NationalityStatus)[Nationality Status], RTRIM(IDForm)[ID Form], RTRIM(ClientID)[Client ID], RTRIM(ContactNo)[Contact No. 1], RTRIM(ContactNo1)[Contact No. 2], RTRIM(OfficeNo)[Office No], RTRIM(Email)[Email], RTRIM(PhysicalAddress)[Physical Address], RTRIM(PostalAddress)[Postal Address], RTRIM(BankName)[Bank Name], RTRIM(BankAccountName)[Bank Account Name], RTRIM(BankAccountNumber)[Bank Account Number], RTRIM(Designation)[Designation], RTRIM(EmployerName)[Employer], RTRIM(CreatedBy)[Created By] from Account where AccountNumber like '"+accountsearch.Text+ "%' OR AccountNames like '" + accountsearch.Text + "%' OR RegistrationDate like '" + accountsearch.Text + "%' OR Designation like '" + accountsearch.Text + "%' OR Gender like '" + accountsearch.Text + "%' OR Nationality like '" + accountsearch.Text + "%' OR NationalityStatus like '" + accountsearch.Text + "%' OR PhysicalAddress like '" + accountsearch.Text + "%' OR Email like '" + accountsearch.Text + "%' OR ContactNo like '" + accountsearch.Text + "%' OR OfficeNo like '" + accountsearch.Text + "%' OR BankName like '" + accountsearch.Text + "%' OR BankAccountName like '" + accountsearch.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridView1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            savingsfrom.Text = DateTime.Today.ToString();
            savingsto.Text = DateTime.Today.ToString();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.DataSource == null)
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

                rowsTotal = dataGridViewX1.RowCount - 1;
                colsTotal = dataGridViewX1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridViewX1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridViewX1.Rows[I].Cells[j].Value;
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
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = savingsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = savingsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridViewX1.DataSource = myDataSet.Tables["Savings"].DefaultView;
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
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode], (Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  SavingsID Like '" + SavingsSearch.Text+ "%' OR AccountNo Like '" + SavingsSearch.Text + "%' OR AccountName Like '" + SavingsSearch.Text + "%' OR CashierName Like '" + SavingsSearch.Text + "%' OR Date Like '" + SavingsSearch.Text + "%' OR Deposit Like '" + SavingsSearch.Text + "%' OR Transactions Like '" + SavingsSearch.Text + "%' OR SubmittedBy Like '" + SavingsSearch.Text + "%' OR ModeOfPayment Like '" + SavingsSearch.Text + "%' OR Accountbalance Like '" + SavingsSearch.Text + "%' OR Approval Like '" + SavingsSearch.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridViewX1.DataSource = myDataSet.Tables["Savings"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(Savings.AccountNo)[Account Number],  RTRIM(AccountName)[Account Name], RTRIM(Date)[Date],(Accountbalance)[Account Balance] from Savings  INNER JOIN (SELECT AccountNo, Max(ID) as ID from Savings group by AccountNo) AS b ON Savings.AccountNo=b.AccountNo and Savings.ID=b.ID and Savings.AccountNo like '" + textBoxX1.Text + "%'  ", con);
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
                cmd = new SqlCommand("select RTRIM(Savings.AccountNo)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Date)[Date],(Accountbalance)[Account Balance] from Savings  INNER JOIN (SELECT AccountNo, Max(ID) as ID from Savings group by AccountNo) AS b ON Savings.AccountNo=b.AccountNo and Savings.ID=b.ID", con);
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

        private void buttonX10_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            searchtransactions.Text = "";
        }

        private void searchtransactions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNo)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(Date)[Transaction Date], RTRIM(DepositDate)[DepositDate], RTRIM(SavingsID)[Savings ID],(Deposit)[Amount], RTRIM(Transactions)[Transaction], (Accountbalance)[Account Balance], RTRIM(SubmittedBy)[Submitted By], RTRIM(CashierName)[Staff Name], RTRIM(ModeOfPayment)[Payment Mode],(Debit)[Debit], (Credit)[Credit], RTRIM(Approval)[Approval], RTRIM(ApprovedBy)[Approved By] from Savings where  AccountNo Like '" + searchtransactions.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridView4.DataSource = myDataSet.Tables["Savings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            loanschedulesearch.Text = "";
        }

        private void buttonX13_Click(object sender, EventArgs e)
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

        private void loanschedulesearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(AccountNumber)[Account Number], RTRIM(AccountName)[Account Names], RTRIM(LoanID)[Loan ID], RTRIM(PaymentDate)[Repayment Date], RTRIM(Months)[Installment],(AmmountPay)[Principal], (Interest)[Interest], (TotalAmmount)[Total Amount], (BalanceExist)[Balance Exist], RTRIM(PaymentStatus)[Payment Status], (Fines)[Fines], RTRIM(Waivered)[Waivered] from RepaymentSchedule where  AccountNumber Like '" + loanschedulesearch.Text + "%' order by ID Asc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridView5.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {

            dataGridView6.DataSource = null;
            issuedloanssearch.Text = "";
        }

        private void buttonX15_Click(object sender, EventArgs e)
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

        private void issuedloanssearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account No.],RTRIM(AccountName)[Account Name],RTRIM(LoanID)[Loan ID],(LoanAmount)[Loan Amount],RTRIM(ApplicationDate)[Application Date],RTRIM(ServicingPeriod)[Servicing Period],RTRIM(RepaymentInterval)[Repayment Interval] ,RTRIM(Interest)[Interest Rate],RTRIM(RefereeName)[Referee Name],RTRIM(RefereeTel)[Referee Tel],RTRIM(RefereeAddress)[Referee Address],RTRIM(RefereeRelationShip)[Referee Relationship],RTRIM(FirstApproval)[1st Approval],(ApprovalComment)[Approval Comment],RTRIM(FinalApproval)[Final Approval],(FinalApprovalComment)[Final Approval Comment],RTRIM(FinalApprovalDate)[Final Approval Date],RTRIM(FinalApprovedBy)[Approved By],RTRIM(LoanType)[LoanType],RTRIM(IssueType)[Issue Method],RTRIM(Issued)[Issued] from Loan where  AccountNo Like '" + issuedloanssearch.Text + "%' order by ID Asc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Loan");
                dataGridView6.DataSource = myDataSet.Tables["Loan"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
