using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class frmDrawingsRecord : DevComponents.DotNetBar.Office2007Form
    {

        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmDrawingsRecord()
        {
            InitializeComponent();
        }
        private void frmSalaryPaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label4.Text;
            frm.UserType.Text = label5.Text;
            frm.Show();*/
        }
        private void frmRegistrationFeePaymentRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void DGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmDrawings frm = new frmDrawings();
                frm.ShowDialog();
                frm.txtPaymentID.Text = dr.Cells[0].Value.ToString();
               
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
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
        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(TransactionID)[Transaction ID],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Payment Date],RTRIM(AuthorisedBy)[Issued By], RTRIM(Ammount)[Drawings Fee], RTRIM(TransactionDetails)[Details] from Drawings where  Date between @date1 and @date2 order by Date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Drawings");
                dataGridView1.DataSource = myDataSet.Tables["Drawings"].DefaultView;
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
       
    }
}
