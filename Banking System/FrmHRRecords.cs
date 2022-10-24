using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class FrmHRRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmHRRecords()
        {
            InitializeComponent();
        }

        private void FrmHRRecords_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void FrmHRRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void buttonX8_Click(object sender, EventArgs e)
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

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(StaffID)[Staff ID], RTRIM(StaffName)[Staff Name], RTRIM(Department)[Department], RTRIM(Gender)[Gender],RTRIM(DOB)[DOB], RTRIM(FatherName)[Father's Name], RTRIM(PermanentAddress)[Permanent Address],RTRIM(TemporaryAddress)[Temporary Address], RTRIM(PhoneNo)[Phone No.], RTRIM(MobileNo)[Mobile No.],RTRIM(DateOfJoining)[Date Of Joining],RTRIM(Qualification)[Qualifications],RTRIM(YearOfExperience)[Year Of  Experience], RTRIM(Designation)[Designation], RTRIM(Email)[Email], (BasicSalary)[Basic Salary], (LIC)[LIC], (IncomeTax)[IncomeTax], (GroupInsurance)[Group Insurance], (FamilyBenefitFund)[Family Benefit Fund],(Loans)[Loans], (OtherDeductions)[Other Deductions], (Picture)[Picture],(ContractPeriodExpiry)[Contract Expiry Date], (AccNo)[Account Number], (AccountNames)[Account Names], (AccountBank)[Bank] from employee order by Staffname", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Employee");
                dataGridView1.DataSource = myDataSet.Tables["Employee"].DefaultView;
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(StaffID)[Staff ID], RTRIM(StaffName)[Staff Name], (EmployeePayment.BasicSalary)[Basic Salary], RTRIM(PaymentDate)[Payment Date],RTRIM(ModeOfPayment)[Payment Mode], RTRIM(PaymentModeDetails)[Payment Mode Details], (Deduction)[Deduction],(TotalPaid)[Total Paid],(DueFees)[Due Fees],RTRIM(Months)[Months],RTRIM(Year)[Year] from EmployeePayment where  PaymentDate between @date1 and @date2 order by PaymentDate", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " PaymentDate").Value = savingsfrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = savingsto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EmployeePayment");
                dataGridView2.DataSource = myDataSet.Tables["EmployeePayment"].DefaultView;
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
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(StaffID)[Staff ID], RTRIM(StaffName)[Staff Name], (EmployeePayment.BasicSalary)[Basic Salary], RTRIM(PaymentDate)[Payment Date],RTRIM(ModeOfPayment)[Payment Mode], RTRIM(PaymentModeDetails)[Payment Mode Details], (Deduction)[Deduction],(TotalPaid)[Total Paid],RTRIM(DueFees)[Due Fees],RTRIM(Months)[Months],RTRIM(Year)[Year] from EmployeePayment where  PaymentDate Like '"+SavingsSearch.Text + "%' OR StaffID Like '" + SavingsSearch.Text + "%' OR StaffName Like '" + SavingsSearch.Text + "%' OR Months Like '" + SavingsSearch.Text + "%' OR Year Like '" + SavingsSearch.Text + "%' BasicSalary Like '" + SavingsSearch.Text + "%' order by ID Desc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EmployeePayment");
                dataGridView2.DataSource = myDataSet.Tables["EmployeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
