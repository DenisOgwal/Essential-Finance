using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace Banking_System
{
    public partial class frmGroupLoanMember : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmGroupLoanMember()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            membername.Text = "";
            dtpStartingDate.Text = System.DateTime.Today.ToString();
            loanid.Text = "";
            Residence.Text = "";
            Occupation.Text = "";
            Reason.Text = "";
            telno.Text = "";
            MemberID.Text = "";
            dataGridView1.DataSource = null;
            buttonX1.Enabled = true;
            loanids.Text = "";
        }
        private void Reset2()
        {
            membername.Text = "";
            dtpStartingDate.Text = System.DateTime.Today.ToString();
            Residence.Text = "";
            Occupation.Text = "";
            Reason.Text = "";
            MemberID.Text = "";
            telno.Text = "";
            buttonX1.Enabled = true;
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
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(LoanID) FROM Guarantor", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                loanids.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    loanids.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
  
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

       
       
        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            
            if (loanid.Text == "")
            {
                MessageBox.Show("Please Enter Loan ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loanid.Focus();
                return;
            }
            if (membername.Text == "")
            {
                MessageBox.Show("Please Enter Loan ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                membername.Focus();
                return;
            }
            if (MemberID.Text == "")
            {
                MessageBox.Show("Please Enter Member ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MemberID.Focus();
                return;
            }
            dataGridView1.Rows.Add(loanid.Text, membername.Text, Residence.Text, Occupation.Text, Reason.Text, MemberID.Text, dtpStartingDate.Text,telno.Text);
            Reset2();
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            
            Reset();
        }

        private void groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void dataload()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID], RTRIM(Names)[Guarantor Name],RTRIM(Residence)[Residence], RTRIM(Occupation)[Occupation],(Relationship)[Relationship],RTRIM(IDNo)[ID No.], RTRIM(Date)[Date],RTRIM(TELNo)[Tel No.] from Guarantor where LoanID='" + loanids.Text + "'  order by ID DESC", con);
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
            buttonX1.Enabled = false;
            dataload();
        }

        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Guarantor(Names,LoanID,Residence,Occupation,Relationship,IDNo,Date,TELNo) VALUES (@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 60, "Names"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "Residence"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 60, "Occupation"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Relationship"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 40, "IDNo"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "TELNo"));
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[1].Value) != null)
                        {
                            cmd.Parameters["@d2"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d3"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                            cmd.Parameters["@d5"].Value = row.Cells[3].Value;
                            cmd.Parameters["@d6"].Value = row.Cells[4].Value;
                            cmd.Parameters["@d7"].Value = row.Cells[5].Value;
                            cmd.Parameters["@d8"].Value = row.Cells[6].Value;
                            cmd.Parameters["@d9"].Value = row.Cells[7].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
               
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (buttonX1.Enabled == true)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    dataGridView1.Rows.Remove(dr);
                }
                if (buttonX1.Enabled == false)
                {

                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            int RowsAffected = 0;

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cq = "delete from Guarantor where Names=@DELETE1;";
                            cmd = new SqlCommand(cq);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 60, "Names"));
                            cmd.Parameters["@DELETE1"].Value = dr.Cells[1].Value; ;
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            loanid.Text = dr.Cells[0].Value.ToString();
            membername.Text = dr.Cells[1].Value.ToString();
            Residence.Text = dr.Cells[2].Value.ToString();
            Occupation.Text = dr.Cells[3].Value.ToString();
            Reason.Text = dr.Cells[4].Value.ToString();
            MemberID.Text = dr.Cells[5].Value.ToString();
        }
    }
}