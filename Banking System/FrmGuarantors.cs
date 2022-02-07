using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace Banking_System
{
    public partial class FrmGuarantors: DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public FrmGuarantors()
        {
            InitializeComponent();
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private void frmEvent_Load(object sender, EventArgs e)
        {
            this.labelX5.Text = AssemblyCopyright;
          
        }
        public void dataload()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Names)[Guarantor Name],RTRIM(Residence)[Residence],(Relationship)[Relationship],RTRIM(IDNo)[ID No.], RTRIM(Date)[Date],RTRIM(TELNo)[Tel No.] from Guarantor  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Guarantor");
                dataGridView1.DataSource = myDataSet.Tables["Guarantor"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loanids_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataload();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
              
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int RowsAffected = 0;

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cq = "delete from Guarantor where Names=@DELETE1 and LoanID='" + dr.Cells[0].Value + "';";
                        cmd = new SqlCommand(cq);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 60, "Names"));
                        cmd.Parameters["@DELETE1"].Value = dr.Cells[1].Value;
                        RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Reset();
                        }
                        else
                        {
                            MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Reset();
                        }

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dataGridView1.Rows.Remove(dr);
                }
                
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
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
                xlApp.Columns[3].Cells.NumberFormat = "@";
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

        private void serachbox_TextChanged(object sender, EventArgs e)
        {
           try {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Names)[Guarantor Name],RTRIM(Residence)[Residence],(Relationship)[Relationship],RTRIM(IDNo)[ID No.], RTRIM(Date)[Date],RTRIM(TELNo)[Tel No.] from Guarantor where  Residence Like '" + serachbox.Text + "%' OR Names Like '" + serachbox.Text + "%' OR IDNo Like '" + serachbox.Text + "%' OR LoanID Like '" + serachbox.Text + "%' OR TELNo like'" + serachbox.Text + "%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Guarantor");
                dataGridView1.DataSource = myDataSet.Tables["Guarantor"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}