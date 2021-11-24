using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class frmSupplierAccountBalance : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmSupplierAccountBalance()
        {
            InitializeComponent();
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
            paymentid.Text = "SPD-" + years + monthss + days + GetUniqueKey(5);
        }
        public void loadpay()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(SupplierAccountBalance.AccountNumber)[Account Number],RTRIM(TransactionBy)[Account Name],RTRIM(SupplierAccountBalance.Ammount)[Ammount],RTRIM(SupplierAccountBalance.TransactionType)[Transaction Type],RTRIM(SupplierAccountBalance.Balance)[AccountBalance],RTRIM(SupplierAccountBalance.TransactionBy)[Supplier],RTRIM(SupplierAccountBalance.Date)[TransactionDate],RTRIM(SupplierAccountBalance.AuthorisedBy)[Staff Concerned],(SupplierAccountBalance.Description)[Description],(SupplierAccountBalance.Reason)[Reason],(SupplierAccountBalance.TransactionID)[Transaction ID] from SupplierAccountBalance order by SupplierAccountBalance.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccountBalance");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccountBalance"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecoveryPassword_Load(object sender, EventArgs e)
        {
            loadpay();
            reason.Text = "N/A";
            //ammount.Text = "0";
            description.Text = "N/A";
            auto();
            patiendidhelp2();
        }
       
        public void patiendidhelp2()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber) FROM SupplierAccount", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                accountnumber.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    accountnumber.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecoveryPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please Select Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
          
            try
            {
                auto();
                SqlDataReader rdr = null;
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TransactionID From SupplierAccountBalance WHERE TransactionID = '" + paymentid.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Payment ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountnumber.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                if (transactiontype.Text == "By Transaction Clearance"|| transactiontype.Text == "Deposit")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update SupplierAccountTransactions Set Clearance='Cleared',PaymentID='"+paymentid.Text+"'  WHERE  TransactionID=@d1";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters["@d1"].Value = transactionid.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into SupplierAccountBalance(TransactionID,AccountNumber,Ammount,TransactionType,Balance,AuthorisedBy,Date,Description,Reason,PaymentMode,TransactionBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9,@d10,@d11,@d12)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Ammount"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "TransactionType"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 2000, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "Reason"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "PaymentMode"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "TransactionBy"));
                    cmd.Parameters["@d1"].Value = paymentid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = ammount.Value;
                    cmd.Parameters["@d4"].Value = transactiontype.Text;
                    cmd.Parameters["@d5"].Value = Accountbalance.Value;
                    cmd.Parameters["@d7"].Value = label12.Text;
                    cmd.Parameters["@d8"].Value = dtp.Text;
                    cmd.Parameters["@d9"].Value = description.Text;
                    cmd.Parameters["@d12"].Value = accountnames.Text;
                    if (transactiontype.Text == "Deposit") { 
                    cmd.Parameters["@d10"].Value = reason.Text;
                    }else{
                        cmd.Parameters["@d10"].Value = transactionid.Text;
                    }
                    cmd.Parameters["@d11"].Value = paymentmode.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (transactiontype.Text == "Deposit")
                    {
                        int totalaamount = 0;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + paymentmode.Text + "' ";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();   
                        if (rdr.Read())
                        {
                            totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                            int newtotalammount = totalaamount - Convert.ToInt32(ammount.Value);
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb4 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + dtp.Text + "' where AccountNumber='" + paymentmode.Text + "'";
                            cmd = new SqlCommand(cb4);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    loadpay();

                }
                else if (transactiontype.Text == "Clear All Bills")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update SupplierAccountTransactions Set PaymentID='" + paymentid.Text + "'  WHERE  AccountNumber=@d1 and Clearance !='Cleared'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters["@d1"].Value =accountnumber.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb7 = "Update SupplierAccountTransactions Set Clearance='Cleared'  WHERE  AccountNumber=@d1";
                    cmd = new SqlCommand(cb7);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters["@d1"].Value = accountnumber.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into SupplierAccountBalance(TransactionID,AccountNumber,Ammount,TransactionType,Balance,AuthorisedBy,Date,Description,Reason,TransactionBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9,@d10,@d12)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Ammount"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "TransactionType"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 2000, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "Reason"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "TransactionBy"));
                    cmd.Parameters["@d1"].Value = paymentid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = ammount.Value;
                    cmd.Parameters["@d4"].Value = transactiontype.Text;
                    cmd.Parameters["@d5"].Value = Accountbalance.Value;
                    cmd.Parameters["@d7"].Value = label12.Text;
                    cmd.Parameters["@d8"].Value = dtp.Text;
                    cmd.Parameters["@d9"].Value = description.Text;
                    cmd.Parameters["@d10"].Value = reason.Text;
                    cmd.Parameters["@d12"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    loadpay();
                    //printPreviewDialog1.Document = printDocument1;
                    //printPreviewDialog1.ShowDialog();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmSupplierAccountBalance frm2 = new frmSupplierAccountBalance();
            frm2.label12.Text = label12.Text;
            frm2.ShowDialog();
        }

        private void accountantid_TextChanged(object sender, EventArgs e)
        {
            
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
        public void reset() {
            accountnumber.Text = "";
            ammount.Text = null;
            Accountbalance.Text = null;
            transactiontype.Text = "";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSupplierAccountBalance frm = new frmSupplierAccountBalance();
            frm.label12.Text = label12.Text;
            frm.ShowDialog();
        }
        public void company()
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct6 = "select * from CompanyNames";
                cmd = new SqlCommand(ct6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyname = rdr.GetString(1).Trim();
                    companyaddress = rdr.GetString(5).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void accountnumbersearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(SupplierAccountBalance.AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(SupplierAccountBalance.Ammount)[Ammount],RTRIM(SupplierAccountBalance.TransactionType)[Transaction Type],RTRIM(SupplierAccountBalance.Balance)[AccountBalance],RTRIM(SupplierAccountBalance.TransactionBy)[Client],RTRIM(SupplierAccountBalance.Date)[TransactionDate],RTRIM(SupplierAccountBalance.AuthorisedBy)[Staff Concerned],(SupplierAccountBalance.Description)[Description] from SupplierAccountBalance,SupplierAccount where SupplierAccountBalance.AccountNumber=SupplierAccount.AccountNumber and SupplierAccountBalance.AccountNumber like '" + accountnumbersearch.Text + "%' order by SupplierAccountBalance.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccountBalance");
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccountBalance"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Delete this from the Account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into DeletedTransactions(SalesID,Product,Size,StaffName,Date) VALUES (@d1,@d2,@d3,@d4,@d6)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SalesID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Product"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Size"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "StaffName"));
                //cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Quantity"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "Date"));

                cmd.Parameters["@d1"].Value = paymentid.Text;
                cmd.Parameters["@d2"].Value = transactiontype.Text;
                cmd.Parameters["@d3"].Value = "Account Transaction";
                cmd.Parameters["@d4"].Value = label13.Text;
                //cmd.Parameters["@d5"].Value = ;
                cmd.Parameters["@d6"].Value = DateTime.Today.Date;
                cmd.ExecuteNonQuery();
                con.Close();
                delete_records();
                this.Hide();
                frmSupplierAccountBalance frm = new frmSupplierAccountBalance();
                frm.label12.Text = label12.Text;
                frm.ShowDialog();
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
                string cq = "delete from SupplierAccountBalance where TransactionID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                cmd.Parameters["@DELETE1"].Value = paymentid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadpay();
                    reset();

                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadpay();
                    reset();

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

        private void beneficiaryid_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountnumber.Text = "";
            patiendidhelp2();
        }

        private void ammount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Balance from SupplierAccountBalance where  AccountNumber= '" + accountnumber.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    //txtamt.Text = "0";
                    string duefeess = rdr["Balance"].ToString();
                    int val4 = 0;
                    int val6 = 0;
                    int I = 0;
                    int.TryParse(duefeess, out val4);
                    int.TryParse(ammount.Text, out val6);
                    if (transactiontype.Text == "Deposit")
                    {
                        I = (val4 + val6);
                    }
                    else
                    {
                        I = (val4 - val6);
                    }
                    Accountbalance.Text = I.ToString();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    if (transactiontype.Text == "Deposit")
                    {
                        int val1 = 0;
                        int.TryParse(ammount.Text, out val1);
                        int I = (val1);
                        Accountbalance.Text = (0 + I).ToString();
                    }
                    else
                    {
                        int val1 = 0;
                        int.TryParse(ammount.Text, out val1);
                        int I = (val1);
                        Accountbalance.Text = (0 - I).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactionid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                string SelectCommand = "SELECT Reason,Ammount FROM SupplierAccountTransactions Where TransactionID='" + transactionid.Text + "' and Clearance='Not Cleared'";
                cmd = new SqlCommand(SelectCommand);
                cmd.Connection = CN;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    reason.Text = rdr[0].ToString();
                    ammount.Text = rdr[1].ToString();
                    ammount.Enabled = false;
                }
                else
                {
                    reason.Text = "N/A";
                    ammount.Text = "0";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ammount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Balance from SupplierAccountBalance where  AccountNumber= '" + accountnumber.Text + "' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    //txtamt.Text = "0";
                    string duefeess = rdr["Balance"].ToString();
                    int val4 = 0;
                    int val6 = 0;
                    int I = 0;
                    int.TryParse(duefeess, out val4);
                    int.TryParse(ammount.Text, out val6);
                    if (transactiontype.Text == "Deposit")
                    {
                        I = (val4 + val6);
                    }
                    else
                    {
                        I = (val4 - val6);
                    }
                    Accountbalance.Text = I.ToString();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    if (transactiontype.Text == "Deposit")
                    {
                        int val1 = 0;
                        int.TryParse(ammount.Text, out val1);
                        int I = (val1);
                        Accountbalance.Text = (0 + I).ToString();
                    }
                    else
                    {
                        int val1 = 0;
                        int.TryParse(ammount.Text, out val1);
                        int I = (val1);
                        Accountbalance.Text = (0 - I).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(SupplierAccountBalance.AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(SupplierAccountBalance.Ammount)[Ammount],RTRIM(SupplierAccountBalance.TransactionType)[Transaction Type],RTRIM(SupplierAccountBalance.Balance)[AccountBalance],RTRIM(SupplierAccountBalance.TransactionBy)[Client],RTRIM(SupplierAccountBalance.Date)[TransactionDate],RTRIM(SupplierAccountBalance.AuthorisedBy)[Staff Concerned],(SupplierAccountBalance.Description)[Description] from SupplierAccountBalance,SupplierAccount where  SupplierAccountBalance.AccountNumber=SupplierAccount.AccountNumber and  AccountName like '" + textBox1.Text + "%' order by SupplierAccountBalance.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccountBalance");
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccountBalance"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactiontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transactiontype.Text == "Deposit")
            {
                transactionid.Text = "N/A";
                //reason.Text = "N/A";
                //reason.Enabled = false;
                amountdue.Enabled = true;
                amountdue.Text = "0";
                transactionid.Enabled = true;

            }
            else if (transactiontype.Text == "Clear All Bills")
            {
                ammount.Enabled = false;
                ammount.Text = billspending.Text;
                transactionid.Text = "N/A";
                transactionid.Enabled = true;
                reason.Text = "Total Peanding Balance Clearance";

            }
            else
            {
                ammount.Text = null;
                amountdue.Enabled = false;
                transactionid.Text = " ";
                transactionid.Enabled = true;
                ammount.Enabled = true;
            }
        }

        private void accountnumber_TextChanged(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {

            }
            else
            {
                try
                {
                    SqlConnection CN = new SqlConnection(cs.DBConn);
                    CN.Open();
                    adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand("SELECT TransactionID FROM SupplierAccountTransactions Where AccountNumber='" + accountnumber.Text + "' and Clearance='Not Cleared'", CN);
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
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Balance from SupplierAccountBalance where  AccountNumber= '" + accountnumber.Text + "' order by ID Desc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        //txtamt.Text = "0";
                        string duefeess = rdr["Balance"].ToString();

                        Accountbalance.Text = duefeess.ToString();
                        label17.Text= duefeess.ToString();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        //return;
                    }
                    else
                    {
                        Accountbalance.Text = "0";
                        label17.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select AccountName from SupplierAccount where  AccountNumber= '" + accountnumber.Text + "' order by ID Desc";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountnames.Text=rdr["AccountName"].ToString();
 
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        //return;
                    }
                    else
                    {
                        Accountbalance.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Ammount from SupplierAccountTransactions where  AccountNumber= '" + accountnumber.Text + "' and Clearance='Not Cleared'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        con.Close();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select SUM(Ammount) from SupplierAccountTransactions where  AccountNumber= '" + accountnumber.Text + "' and Clearance='Not Cleared'", con);
                        billspending.Text = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        billspending.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void transactiontype_TextChanged(object sender, EventArgs e)
        {

        }

        private void ammount_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please Select Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
           
            try
            {
                auto();
                SqlDataReader rdr = null;
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TransactionID From SupplierAccountBalance WHERE TransactionID = '" + paymentid.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Payment ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountnumber.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                if (transactiontype.Text == "By Transaction Clearance" || transactiontype.Text == "Deposit")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update SupplierAccountTransactions Set Clearance='Cleared',PaymentID='"+paymentid.Text+"'  WHERE  TransactionID=@d1";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters["@d1"].Value = transactionid.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into SupplierAccountBalance(TransactionID,AccountNumber,Ammount,TransactionType,Balance,AuthorisedBy,Date,Description,Reason,PaymentMode,TransactionBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9,@d10,@d11,@d12)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Ammount"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "TransactionType"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 2000, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "Reason"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "PaymentMode"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "TransactionBy"));
                    cmd.Parameters["@d1"].Value = paymentid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = ammount.Text;
                    cmd.Parameters["@d4"].Value = transactiontype.Text;
                    cmd.Parameters["@d5"].Value = Accountbalance.Text;
                    cmd.Parameters["@d7"].Value = label12.Text;
                    cmd.Parameters["@d8"].Value = dtp.Text;
                    cmd.Parameters["@d9"].Value = description.Text;
                    cmd.Parameters["@d12"].Value = accountnames.Text;
                    if (transactiontype.Text == "Deposit")
                    {
                        cmd.Parameters["@d10"].Value = reason.Text;
                    }
                    else
                    {
                        cmd.Parameters["@d10"].Value = transactionid.Text;
                    }
                    cmd.Parameters["@d11"].Value = paymentmode.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    loadpay();

                    
                  
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb8 = "Update SupplierAccountTransactions Set PaymentID='" + paymentid.Text + "'  WHERE  AccountNumber=@d1 and Clearance !='Cleared'";
                    cmd = new SqlCommand(cb8);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters["@d1"].Value = accountnumber.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb7 = "Update SupplierAccountTransactions Set Clearance='Cleared'  WHERE  AccountNumber=@d1";
                    cmd = new SqlCommand(cb7);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters["@d1"].Value = accountnumber.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb6 = "insert into SupplierAccountBalance(TransactionID,AccountNumber,Ammount,TransactionType,Balance,AuthorisedBy,Date,Description,Reason,TransactionBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9,@d10,@d12)";
                    cmd = new SqlCommand(cb6);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "Ammount"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "TransactionType"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Balance"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 60, "AuthorisedBy"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 2000, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "Reason"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 60, "TransactionBy"));
                    cmd.Parameters["@d1"].Value = paymentid.Text;
                    cmd.Parameters["@d2"].Value = accountnumber.Text;
                    cmd.Parameters["@d3"].Value = ammount.Text;
                    cmd.Parameters["@d4"].Value = transactiontype.Text;
                    cmd.Parameters["@d5"].Value = Accountbalance.Text;
                    cmd.Parameters["@d7"].Value = label12.Text;
                    cmd.Parameters["@d8"].Value = dtp.Text;
                    cmd.Parameters["@d9"].Value = description.Text;
                    cmd.Parameters["@d10"].Value = reason.Text;
                    cmd.Parameters["@d12"].Value = accountnames.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    loadpay();
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmSupplierAccountBalance frm2 = new frmSupplierAccountBalance();
            frm2.label12.Text = label12.Text;
            frm2.ShowDialog();
        }

        private void accountnames_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            paymentid.Text = dr.Cells[10].Value.ToString();
            accountnumber.Text = dr.Cells[0].Value.ToString();
            accountnumber.Text = dr.Cells[0].Value.ToString();
            accountnames.Text = dr.Cells[1].Value.ToString();
            reason.Text = "N/A";
            ammount.Text = dr.Cells[2].Value.ToString();
            amountdue.Text = "0";
            Accountbalance.Text = dr.Cells[4].Value.ToString();
            transactiontype.Text = dr.Cells[3].Value.ToString();
        }

        private void accountnumber_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupplierDetails frm = new frmSupplierDetails();
                frm.ShowDialog();
                this.accountnumber.Text = frm.clientnames.Text;
                this.accountnames.Text = frm.clientcontact.Text;
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
        private void frmSupplierAccountBalance_Shown(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber),RTRIM(AccountNames) FROM BankAccounts", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    paymentmode.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
