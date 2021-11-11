using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;


namespace Banking_System
{
    public partial class frmSavingsRecords : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSavingsRecords()
        {
            InitializeComponent();
        }

        private void frmSavingsRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                Memberid.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(MemberID) FROM Savings", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Memberid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Memberid.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                transactionid.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(SavingsID) FROM Savings", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                transactionid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    transactionid.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Datefrom.Text = DateTime.Today.ToString();
            Dateto.Text = DateTime.Today.ToString();
            dataGridViewX1.DataSource = null;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account Number], RTRIM(Savings.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Savings.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(CashierName)[StaffName],RTRIM(Deposit)[Deposit Ammount],RTRIM(Withdraw)[WithDraw Ammount],RTRIM(Accountbalance)[Account Balance],RTRIM(SavingsID)[Transaction ID],RTRIM(WithDrawer)[WithDrew By],RTRIM(Telephone)[Telephone] from Savings where  Date between @date1 and @date2 order by Savings.ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = Datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = Dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridViewX1.DataSource = myDataSet.Tables["Savings"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSavingsRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            dataGridViewX2.DataSource = null;
            transactionid.Text = "";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX2.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account Number], RTRIM(Savings.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Savings.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(CashierName)[StaffName],RTRIM(Deposit)[Deposit Ammount],RTRIM(Withdraw)[WithDraw Ammount],RTRIM(Accountbalance)[Account Balance],RTRIM(SavingsID)[Savings ID],RTRIM(WithDrawer)[WithDrew By],RTRIM(Telephone)[Telephone] from Savings where SavingsID='" + transactionid.Text + "' order by Savings.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridViewX2.DataSource = myDataSet.Tables["Savings"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            datefrom1.Text = DateTime.Today.ToString();
            dateto1.Text = DateTime.Today.ToString();
            dataGridViewX3.DataSource = null;
            transactiontype.Text = "";
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (transactiontype.Text == "Deposit")
            {
                try
                {
                    dataGridViewX3.DataSource = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTRIM(AccountNo)[Account Number], RTRIM(Savings.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Savings.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(StaffName)[StaffName],RTRIM(Deposit)[Deposit Ammount],RTRIM(Accountbalance)[Account Balance],RTRIM(SavingsID)[Transaction ID],RTRIM(WithDrawer)[Deposited By],RTRIM(Telephone)[Telephone] from Savings where Date between @date1 and @date2 and Deposit!='' order by Savings.ID DESC", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom1.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto1.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Savings");
                    dataGridViewX3.DataSource = myDataSet.Tables["Savings"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (transactiontype.Text == "Withdraw")
            {
                try
                {
                    dataGridViewX3.DataSource = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTRIM(AccountNo)[Account Number], RTRIM(Savings.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Savings.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(StaffName)[StaffName],RTRIM(Withdraw)[WithDraw Ammount],RTRIM(Accountbalance)[Account Balance],RTRIM(SavingsID)[Transaction ID],RTRIM(WithDrawer)[WithDrew By],RTRIM(Telephone)[Telephone] from Savings where Date between @date1 and @date2 and Withdraw !='' order by Savings.ID DESC", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom1.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto1.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Savings");
                    dataGridViewX3.DataSource = myDataSet.Tables["Savings"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            datefrom2.Text = DateTime.Today.ToString();
            dateto2.Text = DateTime.Today.ToString();
            dataGridViewX4.DataSource = null;
            Memberid.Text = "";
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX4.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNo)[Account Number], RTRIM(Savings.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Savings.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(CashierName)[StaffName],RTRIM(Deposit)[Deposit Ammount],RTRIM(Withdraw)[WithDraw Ammount] ,RTRIM(MonthlyCharge)[Monthly Charge],RTRIM(Accountbalance)[Account Balance],RTRIM(SavingsID)[Transaction ID],RTRIM(WithDrawer)[WithDrew By],RTRIM(Telephone)[Telephone] from Savings where Date between @date1 and @date2  and Savings.MemberID='" + Memberid.Text + "'order by Savings.ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = datefrom2.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dateto2.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Savings");
                dataGridViewX4.DataSource = myDataSet.Tables["Savings"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (dataGridViewX4.DataSource == null)
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
                rowsTotal = dataGridViewX4.RowCount - 1;
                colsTotal = dataGridViewX4.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridViewX4.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridViewX4.Rows[I].Cells[j].Value;
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

        private void buttonX11_Click(object sender, EventArgs e)
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

        private void buttonX12_Click(object sender, EventArgs e)
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
    }
}
