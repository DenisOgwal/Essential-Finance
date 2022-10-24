using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class frmLoanInsuranceFeePaymentRecord : DevComponents.DotNetBar.Office2007Form
    {

        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmLoanInsuranceFeePaymentRecord()
        {
            InitializeComponent();
        }

        private void cmbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(MemberID)[Member ID], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], RTRIM(InsuranceAmmount)[Ammount Paid], RTRIM(Duepayment)[Due Payment] from LoanInsuranceFees where PaymentID= '" + cmbStaffName.Text + "' order by ID Desc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "LoanInsuranceFees");
                DGV.DataSource = myDataSet.Tables["LoanInsuranceFees"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;
            dataGridView1.DataSource = null;
            cmbStaffName.Text = "";
            DateFrom.Text= DateTime.Today.ToString();
            DateTo.Text=DateTime.Today.ToString();
        }

        private void frmSalaryPaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
            frm.label7.Text = label4.Text;
            frm.label12.Text = label5.Text;
            frm.ShowDialog();*/
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(PaymentID) FROM LoanInsuranceFees", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbStaffName.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbStaffName.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmRegistrationFeePaymentRecord_Load(object sender, EventArgs e)
        {
            AutocompleteStaffName();
        }

        private void DGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DGV.SelectedRows[0];
               
                frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                frm.txtPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.cmbStaffID.Text = dr.Cells[1].Value.ToString();
                frm.txtTotalPaid.Text = dr.Cells[6].Value.ToString();
                frm.staffname.Text = dr.Cells[5].Value.ToString();
                frm.Duepayment.Text = dr.Cells[7].Value.ToString();
                if (label5.Text == "ADMIN")
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;
                    frm.buttonX4.Enabled = true;
                    frm.buttonX5.Enabled = true;
                }
                else
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;

                }
                frm.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];

                frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
                frm.txtPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.cmbStaffID.Text = dr.Cells[1].Value.ToString();
                frm.txtTotalPaid.Text = dr.Cells[6].Value.ToString();
                frm.staffname.Text = dr.Cells[5].Value.ToString();
                frm.Duepayment.Text = dr.Cells[7].Value.ToString();

                if (label5.Text == "ADMIN")
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;
                    frm.buttonX4.Enabled = true;
                    frm.buttonX5.Enabled = true;
                }
                else
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;
                   
                }
                frm.ShowDialog();
                this.Hide();
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void DGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DGV.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DGV.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            DGV.DataSource = null;
            cmbStaffName.Text = "";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (DGV.DataSource == null)
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

                rowsTotal = DGV.RowCount - 1;
                colsTotal = DGV.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DGV.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DGV.Rows[I].Cells[j].Value;
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
                cmd = new SqlCommand("select RTrim(PaymentID)[Payment ID], RTRIM(MemberID)[Member ID], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(CashierName)[Recieved By], RTRIM(InsuranceAmmount)[Ammount Paid], RTRIM(Duepayment)[Due Payment] from LoanInsuranceFees where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "LoanInsuranceFees");
                dataGridView1.DataSource = myDataSet.Tables["LoanInsuranceFees"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
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
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
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

        private void DGV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = DGV.SelectedRows[0];

                frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
                frm.txtPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.cmbStaffID.Text = dr.Cells[1].Value.ToString();
                frm.label7.Text = label4.Text;
                frm.label12.Text = label5.Text;
                frm.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
                frm.txtPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.cmbStaffID.Text = dr.Cells[1].Value.ToString();

                if (label5.Text == "ADMIN")
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;
                    frm.buttonX4.Enabled = true;
                    frm.buttonX5.Enabled = true;
                }
                else
                {
                    frm.label7.Text = label4.Text;
                    frm.label12.Text = label5.Text;

                }
                frm.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
