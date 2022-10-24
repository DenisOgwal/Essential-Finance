using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class FrmOutflowsRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmOutflowsRecords()
        {
            InitializeComponent();
        }

        private void FrmOutflowsRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void FrmOutflowsRecords_FormClosing(object sender, FormClosingEventArgs e)
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            purchasesfrom.Text = DateTime.Today.ToString();
            purchasesto.Text = DateTime.Today.ToString();
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

        private void buttonX7_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dividendsfrom.Text = DateTime.Today.ToString();
            dividendsto.Text = DateTime.Today.ToString();
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID],  RTRIM(CashierID)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],(Cost)[Cost],(TotalPaid)[Total Paid], (Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address],RTRIM(ExpenseType)[Expense Type],RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[AccountNumber],RTRIM(AccountNames)[Account Names] from Expenses where Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                dataGridView1.DataSource = myDataSet.Tables["Expenses"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID],  RTRIM(CashierID)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],(Cost)[Cost],(TotalPaid)[Total Paid],(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address],RTRIM(ExpenseType)[Expense Type],RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[AccountNumber],RTRIM(AccountNames)[Account Names] from Expenses where ExpenseID Like '" + accountsearch.Text+ "%' OR Date Like '" + accountsearch.Text + "%' OR Expense Like '" + accountsearch.Text + "%' OR ExpenseType Like '" + accountsearch.Text + "%' OR Payee Like '" + accountsearch.Text + "%' OR Description Like '" + accountsearch.Text + "%' OR LoanID Like '" + accountsearch.Text + "%' OR Telephone Like '" + accountsearch.Text + "%' OR AccountNumber Like '" + accountsearch.Text + "%' OR AccountNames Like '" + accountsearch.Text + "%' OR LoanID Like '" + accountsearch.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                dataGridView1.DataSource = myDataSet.Tables["Expenses"].DefaultView;
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(PurchaseID)[Purchase ID], RTRIM(Equipmentname)[Equipment Name], RTRIM(Quantity)[Quantity], RTRIM(Units)[Units], (UnitCost)[Unit Cost], (TotalCost)[Total Cost], RTRIM(InvoiceNo)[Invoice No.], RTRIM(NoPerUnit)[No. Per Unit], RTRIM(SmallUnit)[Minor Units], RTRIM(Specifications)[Specifications], RTRIM(Warnings)[Warnings],RTRIM(PurchaseDate)[Date],RTRIM(Section)[Section],RTRIM(Model)[Model],RTRIM(MfgDate)[Manufacture Date],RTRIM(ExpDate)[Expiry Date], RTRIM(Country)[Origin], RTRIM(BatchNo)[Batch No],RTRIM(Manufacturer)[Manufacturer],RTRIM(Supplier)[Supplier], RTRIM(Description)[Description] from EquipmentPurchase where  PurchaseDate between @date1 and @date2 order by ID Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = purchasesfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = purchasesto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EquipmentPurchase");
                dataGridView2.DataSource = myDataSet.Tables["EquipmentPurchase"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void purchasessearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(PurchaseID)[Purchase ID], RTRIM(Equipmentname)[Equipment Name], RTRIM(Quantity)[Quantity], RTRIM(Units)[Units], (UnitCost)[Unit Cost], (TotalCost)[Total Cost], RTRIM(InvoiceNo)[Invoice No.], RTRIM(NoPerUnit)[No. Per Unit], RTRIM(SmallUnit)[Minor Units], RTRIM(Specifications)[Specifications], RTRIM(Warnings)[Warnings],RTRIM(PurchaseDate)[Date],RTRIM(Section)[Section],RTRIM(Model)[Model],RTRIM(MfgDate)[Manufacture Date],RTRIM(ExpDate)[Expiry Date], RTRIM(Country)[Origin], RTRIM(BatchNo)[Batch No],RTRIM(Manufacturer)[Manufacturer],RTRIM(Supplier)[Supplier], RTRIM(Description)[Description] from EquipmentPurchase where  PurchaseDate like '" + purchasessearch.Text + "%' OR EquipmentName like '" + purchasessearch.Text + "%' OR PurchaseID like '" + purchasessearch.Text + "%' OR Units like '" + purchasessearch.Text + "%' OR InvoiceNo like '" + purchasessearch.Text + "%' OR SmallUnit like '" + purchasessearch.Text + "%' OR Country like '" + purchasessearch.Text + "%' OR Manufacturer like '" + purchasessearch.Text + "%' OR Model like '" + purchasessearch.Text + "%' OR MfgDate like '" + purchasessearch.Text + "%' OR ExpDate like '" + purchasessearch.Text + "%' OR Supplier like '" + purchasessearch.Text + "%' OR BatchNo like '" + purchasessearch.Text + "%' order by Equipmentname Asc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EquipmentPurchase");
                dataGridView2.DataSource = myDataSet.Tables["EquipmentPurchase"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(TransactionID)[Transaction ID], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Transaction Date],RTRIM(AuthorisedBy)[Chairman Authorisation], (Ammount)[Ammount], RTRIM(TransactionDetails)[Transaction Details]from Drawings where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value =dividendsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dividendsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Drawings");
                dataGridView3.DataSource = myDataSet.Tables["Drawings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dividendssearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(TransactionID)[Transaction ID], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Transaction Date],RTRIM(AuthorisedBy)[Chairman Authorisation], (Ammount)[Ammount], RTRIM(TransactionDetails)[Transaction Details] from Drawings where  Date Like '"+ dividendssearch.Text+ "%' OR TransactionID Like '" + dividendssearch.Text + "%' OR TransactionType Like '" + dividendssearch.Text + "%' OR TransactionDetails Like '" + dividendssearch.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Drawings");
                dataGridView3.DataSource = myDataSet.Tables["Drawings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
