using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Banking_System
{
    public partial class frmEquipmentRecord : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmEquipmentRecord()
        {
            InitializeComponent();
        }

        private void frmExpensesRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
           
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
               /* DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                this.Hide();
                frmEXpenses frm = new frmEXpenses();
                frm.Show();
                frm.expenseid.Text = dr.Cells[1].Value.ToString();
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
               
                    frm.buttonX4.Enabled = true;
                    frm.buttonX3.Enabled = true;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX2.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(PurchaseID)[Purchase ID], RTRIM(Equipmentname)[Equipment Name], RTRIM(Quantity)[Quantity], RTRIM(Units)[Units], RTRIM(UnitCost)[Unit Cost], RTRIM(TotalCost)[Total Cost], RTRIM(InvoiceNo)[Invoice No.], RTRIM(NoPerUnit)[No. Per Unit], RTRIM(SmallUnit)[Minor Units], RTRIM(Specifications)[Specifications], RTRIM(Warnings)[Warnings],RTRIM(PurchaseDate)[Date],RTRIM(Section)[Section],RTRIM(Model)[Model],RTRIM(MfgDate)[Manufacture Date],RTRIM(ExpDate)[Expiry Date], RTRIM(Country)[Origin], RTRIM(BatchNo)[Batch No],RTRIM(Manufacturer)[Manufacturer],RTRIM(Supplier)[Supplier], RTRIM(Description)[Description] from EquipmentPurchase where  PurchaseDate between @date1 and @date2 order by Equipmentname Asc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EquipmentPurchase");
                dataGridViewX2.DataSource = myDataSet.Tables["EquipmentPurchase"].DefaultView;
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
               /* DataGridViewRow dr = dataGridViewX2.SelectedRows[0];
                this.Hide();
                frmEXpenses frm = new frmEXpenses();
                frm.Show();
                frm.expenseid.Text = dr.Cells[1].Value.ToString();
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
                    frm.buttonX4.Enabled = true;
                    frm.buttonX3.Enabled = true;
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;*/

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
            frm.outlet.Text = outlet.Text;
            frm.Show();*/
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

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX3.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(PurchaseID)[Purchase ID], RTRIM(Equipmentname)[Equipment Name], RTRIM(Quantity)[Quantity], RTRIM(Units)[Units], RTRIM(UnitCost)[Unit Cost], RTRIM(TotalCost)[Total Cost], RTRIM(InvoiceNo)[Invoice No.], RTRIM(NoPerUnit)[No. Per Unit], RTRIM(SmallUnit)[Minor Units], RTRIM(Specifications)[Specifications], RTRIM(Warnings)[Warnings],RTRIM(PurchaseDate)[Date],RTRIM(Section)[Section],RTRIM(Model)[Model],RTRIM(MfgDate)[Manufacture Date],RTRIM(ExpDate)[Expiry Date], RTRIM(Country)[Origin], RTRIM(BatchNo)[Batch No],RTRIM(Manufacturer)[Manufacturer],RTRIM(Supplier)[Supplier], RTRIM(Description)[Description] from EquipmentPurchase where  PurchaseDate like '" + textBoxX1.Text + "%' OR EquipmentName like '" + textBoxX1.Text + "%' OR PurchaseID like '" + textBoxX1.Text + "%' OR Units like '" + textBoxX1.Text + "%' OR InvoiceNo like '" + textBoxX1.Text + "%' OR SmallUnit like '" + textBoxX1.Text + "%' OR Country like '" + textBoxX1.Text + "%' OR Manufacturer like '" + textBoxX1.Text + "%' OR Model like '" + textBoxX1.Text + "%' OR MfgDate like '" + textBoxX1.Text + "%' OR ExpDate like '" + textBoxX1.Text + "%' OR Supplier like '" + textBoxX1.Text + "%' OR BatchNo like '" + textBoxX1.Text + "%' order by Equipmentname Asc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EquipmentPurchase");
                dataGridViewX3.DataSource = myDataSet.Tables["EquipmentPurchase"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
            
        }
    }
}
