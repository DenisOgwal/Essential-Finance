using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class FrmInflowsRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmInflowsRecords()
        {
            InitializeComponent();
        }

        private void FrmInflowsRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void FrmInflowsRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(MemberID)[Account No.], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], RTRIM(FineFee)[Ammount Paid], RTRIM(Reason)[Reason]from Fines where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Fines");
                dataGridView1.DataSource = myDataSet.Tables["Fines"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void accountsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(MemberID)[Account Number], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], (FineFee)[Ammount Paid], RTRIM(Reason)[Reason] from Fines where MemberID like '" + accountsearch.Text + "%' OR Reason like '" + accountsearch.Text + "%' OR PaymentID like '" + accountsearch.Text + "%' Or FineFee like '" + accountsearch.Text + "%' order by ID Desc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Fines");
                dataGridView1.DataSource = myDataSet.Tables["Fines"].DefaultView;
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
            grantsfrom.Text = DateTime.Today.ToString();
            grantsto.Text = DateTime.Today.ToString();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(GrantedBy)[Granted By], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], (GrantFee)[Granted Fee], RTRIM(Reason)[Reason] from GrantFees where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = grantsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = grantsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Grantfees");
                dataGridView2.DataSource = myDataSet.Tables["GrantFees"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grantsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(GrantedBy)[Granted By], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], (GrantFee)[Granted Fee], RTRIM(Reason)[Reason] from GrantFees where  Date like '"+ grantsearch.Text+ "%' OR GrantedBy like '" + grantsearch.Text + "%' OR PaymentID like '" + grantsearch.Text + "%' OR GrantFee like '" + grantsearch.Text + "%' OR Reason like '" + grantsearch.Text + "%' order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = grantsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = grantsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Grantfees");
                dataGridView2.DataSource = myDataSet.Tables["GrantFees"].DefaultView;
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
            othersfrom.Text = DateTime.Today.ToString();
            othersto.Text = DateTime.Today.ToString();
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
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(PaymentID)[Income ID], RTRIM(CashierName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Income)[Paid For],(OtherFee)[Total Paid],RTRIM(Reason)[Reason], RTRIM(PaidBy)[Paid By],RTRIM(Telephone)[Telephone No. ], RTRIM(Address)[ Address] from OtherIncomes where Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value =othersfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = othersto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherIncomes");
                dataGridView3.DataSource = myDataSet.Tables["OtherIncomes"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void otherssearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(PaymentID)[Income ID], RTRIM(CashierName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Income)[Paid For],RTRIM(OtherFee)[Total Paid],RTRIM(Reason)[Reason], RTRIM(PaidBy)[Paid By],RTRIM(Telephone)[Telephone No. ], RTRIM(Address)[ Address] from OtherIncomes where Date like '"+otherssearch.Text+ "%' OR PaymentID like '" + otherssearch.Text + "%' OR PaidBy like '" + otherssearch.Text + "%' OR Telephone like '" + otherssearch.Text + "%' OR Comment like '" + otherssearch.Text + "%' OR Reason like '" + otherssearch.Text + "%' OR Months like '" + otherssearch.Text + "%' OR OtherFee like '" + otherssearch.Text + "%' order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = othersfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = othersto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherIncomes");
                dataGridView3.DataSource = myDataSet.Tables["OtherIncomes"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
