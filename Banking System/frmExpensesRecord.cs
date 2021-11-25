using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Banking_System
{
    public partial class frmExpensesRecord : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataAdapter adp;
        public frmExpensesRecord()
        {
            InitializeComponent();
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Expense) FROM ExpensesType", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                expensetype.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    expensetype.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmExpensesRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            AutocompleteStaffName();
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                this.Hide();
                frmEXpenses frm = new frmEXpenses();
                frm.Show();
                frm.comment.Text = dr.Cells[0].Value.ToString();
                frm.expenseid.Text = dr.Cells[1].Value.ToString();
                frm.cashierid.Text = dr.Cells[2].Value.ToString();
                frm.cashiername.Text = dr.Cells[3].Value.ToString();
                //frm.year.Text = dr.Cells[4].Value.ToString();
                //frm.months.Text = dr.Cells[5].Value.ToString();
                frm.expensedate.Text = dr.Cells[6].Value.ToString();
                frm.service.Text = dr.Cells[7].Value.ToString();
                frm.cost.Text = dr.Cells[8].Value.ToString();
                frm.totalpaid.Text = dr.Cells[9].Value.ToString();
                frm.duepayment.Text = dr.Cells[10].Value.ToString();
                frm.description.Text = dr.Cells[11].Value.ToString();
                frm.names.Text = dr.Cells[12].Value.ToString();
                frm.tel.Text = dr.Cells[13].Value.ToString();
                frm.email.Text = dr.Cells[14].Value.ToString();
                frm.address.Text = dr.Cells[15].Value.ToString();
                if (label2.Text == "Manager")
                {
                    frm.buttonX4.Enabled = true;
                    frm.buttonX3.Enabled = true;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                }
                else
                {
                    frm.buttonX4.Enabled = false;
                    frm.buttonX3.Enabled = false;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID], RTRIM(StaffName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],RTRIM(Cost)[Cost],RTRIM(TotalPaid)[Total Paid], RTRIM(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address], RTRIM(ExpenseType)[Expense Type] from Expenses,Rights where Expenses.CashierID=Rights.StaffName and Year='" + year.Text + "' and Months='" + months.Text + "' order by Expenses.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                myDA.Fill(myDataSet, "Rights");
                dataGridViewX1.DataSource = myDataSet.Tables["Expenses"].DefaultView;
                dataGridViewX1.DataSource = myDataSet.Tables["Rights"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            year.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
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
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX2.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID],  RTRIM(StaffName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],RTRIM(Cost)[Cost],RTRIM(TotalPaid)[Total Paid], RTRIM(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address],RTRIM(ExpenseType)[Expense Type] from Expenses,Rights where Expenses.CashierID=Rights.StaffName and Date between @date1 and @date2 order by Expenses.ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                myDA.Fill(myDataSet, "Rights");
                dataGridViewX2.DataSource = myDataSet.Tables["Expenses"].DefaultView;
                dataGridViewX2.DataSource = myDataSet.Tables["Rights"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            dataGridViewX2.DataSource = null;
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
                rowsTotal = dataGridViewX2.RowCount - 1;
                colsTotal = dataGridViewX2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridViewX2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridViewX2.Rows[I].Cells[j].Value;
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

        private void dataGridViewX2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX2.SelectedRows[0];
                this.Hide();
                frmEXpenses frm = new frmEXpenses();
                frm.Show();
                frm.comment.Text = dr.Cells[0].Value.ToString();
                frm.expenseid.Text = dr.Cells[1].Value.ToString();
                frm.cashierid.Text = dr.Cells[2].Value.ToString();
                frm.cashiername.Text = dr.Cells[3].Value.ToString();
                //frm.year.Text = dr.Cells[4].Value.ToString();
                //frm.months.Text = dr.Cells[5].Value.ToString();
                frm.expensedate.Text = dr.Cells[6].Value.ToString();
                frm.service.Text = dr.Cells[7].Value.ToString();
                frm.cost.Text = dr.Cells[8].Value.ToString();
                frm.totalpaid.Text = dr.Cells[9].Value.ToString();
                frm.duepayment.Text = dr.Cells[10].Value.ToString();
                frm.description.Text = dr.Cells[11].Value.ToString();
                frm.names.Text = dr.Cells[12].Value.ToString();
                frm.tel.Text = dr.Cells[13].Value.ToString();
                frm.email.Text = dr.Cells[14].Value.ToString();
                frm.address.Text = dr.Cells[15].Value.ToString();
                if (label2.Text == "Manager")
                {
                    frm.buttonX4.Enabled = true;
                    frm.buttonX3.Enabled = true;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                }
                else
                {
                    frm.buttonX4.Enabled = false;
                    frm.buttonX3.Enabled = false;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmExpensesRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm= new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX3.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID], RTRIM(StaffName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],RTRIM(Cost)[Cost],RTRIM(TotalPaid)[Total Paid], RTRIM(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address], RTRIM(ExpenseType)[Expense Type] from Expenses,Rights where Expenses.CashierID=Rights.StaffName and ExpenseType='"+expensetype.Text+"' order by Expenses.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                myDA.Fill(myDataSet, "Rights");
                dataGridViewX3.DataSource = myDataSet.Tables["Expenses"].DefaultView;
                dataGridViewX3.DataSource = myDataSet.Tables["Rights"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            expensetype.Text = "";
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (dataGridViewX3.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
                rowsTotal = dataGridViewX3.RowCount - 1;
                colsTotal = dataGridViewX3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridViewX3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridViewX3.Rows[I].Cells[j].Value;
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
    }
}
