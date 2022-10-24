using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class frmSupplierAccounts: DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        public String paymentids;


        public frmSupplierAccounts()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            btnSave.Enabled = true;
            Delete.Enabled = true;
            dtp.Text = DateTime.Today.ToString();
            accountnumber.Text = "";
            accountname.Text = "";
            location.Text = "";
            contact.Text = "";
            description.Text = "";
           
           
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            this.Hide();
            frmSupplierAccounts frm = new frmSupplierAccounts();
            frm.label4.Text = label4.Text;
            frm.ShowDialog();
        }
        public void loadpay() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(Contact)[Contact],RTRIM(Location)[Location],(Description)[Description] ,RTRIM(AuthorisedBy)[CreatedBy],RTRIM(DateCreated)[Date Created] from SupplierAccount order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmOtherTransaction_Load(object sender, EventArgs e)
        {
            loadpay();
            auto();
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            accountnumber.Text = "SAC-" + years + monthss + days + GetUniqueKey(4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please Click generate button for account number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please Enter Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (contact.Text == "")
            {
                MessageBox.Show("Please Enter Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contact.Focus();
                return;
            }
            if (location.Text == "")
            {
                MessageBox.Show("Please Enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                location.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AccountNumber from SupplierAccount where  AccountNumber= '" + accountnumber.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Account Number Already Exist Try Generating Another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SupplierAccount(AccountNumber,AccountName,Contact,Location,Description,AuthorisedBy,DateCreated) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 60, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Contact"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "Location"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Text, 2000, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "DateCreated"));

                cmd.Parameters["@d1"].Value = accountnumber.Text;
                cmd.Parameters["@d2"].Value = accountname.Text;
                cmd.Parameters["@d3"].Value = contact.Text;
                cmd.Parameters["@d4"].Value = location.Text;
                cmd.Parameters["@d5"].Value = description.Text;
                cmd.Parameters["@d6"].Value = label4.Text;
                cmd.Parameters["@d7"].Value = dtp.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Registered Account", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                loadpay();
                this.Hide();
                frmSupplierAccounts frm = new frmSupplierAccounts();
                frm.label4.Text = label4.Text;
                frm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please Click generate button for account number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please Enter Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (contact.Text == "")
            {
                MessageBox.Show("Please Enter Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contact.Focus();
                return;
            }
            if (location.Text == "")
            {
                MessageBox.Show("Please Enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                location.Focus();
                return;
            }
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update SupplierAccount SET AccountName=@d2,Contact=@d3,Location=@d4,Description=@d5,AuthorisedBy=@d6,DateCreated=@d7 WHERE AccountNumber=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 60, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Contact"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "Location"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Text, 2000, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "DateCreated"));

                cmd.Parameters["@d1"].Value = accountnumber.Text;
                cmd.Parameters["@d2"].Value = accountname.Text;
                cmd.Parameters["@d3"].Value = contact.Text;
                cmd.Parameters["@d4"].Value = location.Text;
                cmd.Parameters["@d5"].Value = description.Text;
                cmd.Parameters["@d6"].Value = label4.Text;
                cmd.Parameters["@d7"].Value = dtp.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated Account", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                loadpay();
                this.Hide();
                frmSupplierAccounts frm = new frmSupplierAccounts();
                frm.label4.Text = label4.Text;
                frm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {
            try
            {
                if (accountnumber.Text == "")
                {
                    MessageBox.Show("Please enter Account first ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountnumber.Focus();
                    return;
                }
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from SupplierAccount where AccountNumber=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters["@DELETE1"].Value = accountnumber.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadpay();
                    Reset();
                   
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadpay();
                    Reset();
                   
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
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void txtamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
      
        private void accountantid_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                accountnumber.Text = dr.Cells[0].Value.ToString();
                accountname.Text = dr.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                this.Hide();
                frmSupplierAccounts frm = new frmSupplierAccounts();
                frm.label4.Text = label4.Text;
                frm.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(Contact)[Contact],RTRIM(Location)[Location],(Description)[Description] ,RTRIM(AuthorisedBy)[CreatedBy],RTRIM(DateCreated)[Date Created] from SupplierAccount WHERE AccountNumber like '"+accountnumbersearch.Text+"%' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
        }
    }