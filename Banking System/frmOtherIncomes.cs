using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
namespace Banking_System
{
    public partial class frmOtherIncomes : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmOtherIncomes()
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

            expenseid.Text = "OI-" + years + monthss + days + GetUniqueKey(5);
        }
        public void dataload() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(PaymentID)[Income ID], RTRIM(CashierName)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Income)[Paid For],RTRIM(OtherFee)[Total Paid],RTRIM(Reason)[Description], RTRIM(PaidBy)[Names of Payer],RTRIM(Telephone)[Telephone No. ] from OtherIncomes,Rights where OtherIncomes.CashierName=Rights.StaffName  order by OtherIncomes.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherIncomes");
                myDA.Fill(myDataSet, "Rights");
                dataGridViewX1.DataSource = myDataSet.Tables["OtherIncomes"].DefaultView;
                dataGridViewX1.DataSource = myDataSet.Tables["Rights"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }
        private void frmEXpenses_Load(object sender, EventArgs e)
        {
           /* Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;*/
            dataload();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    cmbModeOfPayment.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            cashierid.Text = "";
            cashiername.Text = "";
            expenseid.Text = "";
            year.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
            expensedate.Text = DateTime.Today.ToString();
            description.Text = "";
           
            totalpaid.Text = null;
           
            names.Text = "";
            address.Text = "";
            tel.Text = null;
            managerid.Text = "";
            managername.Text = "";
            comment.Text = "";
            service.Text = "";
            buttonX5.Enabled = true;
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherIncomes frm = new frmOtherIncomes();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            auto();
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please enter cashier Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               cashiername.Focus();
                return;
            }
            if (totalpaid.Text == "")
            {
                MessageBox.Show("Please enter total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                totalpaid.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select PaymentID from OtherIncomes where PaymentID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "PaymentID"));
                cmd.Parameters["@find"].Value = expenseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Payment ID. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    expenseid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into OtherIncomes(PaymentID,Year,Months,Date,OtherFee,CashierName,Income,PaidBy,Telephone,Address,Reason,Comment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 15, "OtherFee"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 40, "Income"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "PaidBy"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Telephone"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "Address"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "Reason"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 30, "Comment"));
                
                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = months.Text.Trim();
                cmd.Parameters["@d4"].Value = expensedate.Text.Trim();
                cmd.Parameters["@d5"].Value = Convert.ToInt32(totalpaid.Value);
                cmd.Parameters["@d6"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d7"].Value = service.Text;
                cmd.Parameters["@d8"].Value = names.Text.Trim();
                cmd.Parameters["@d9"].Value = tel.Text;
                cmd.Parameters["@d10"].Value = address.Text;
                cmd.Parameters["@d11"].Value = description.Text;
                cmd.Parameters["@d12"].Value = "Pending Approval";
                cmd.ExecuteNonQuery();

                SqlDataReader rdr3 = null;
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr3 = cmd.ExecuteReader();
                if (rdr3.Read())
                {
                    totalaamount = Convert.ToInt32(rdr3["AmountAvailable"]);
                    int newtotalammount = totalaamount + Convert.ToInt32(totalpaid.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + expensedate.Text + "' where AccountNumber='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                buttonX5.Enabled = false;
                dataload();
                con.Close();
                this.Hide();
                frmOtherIncomes frm = new frmOtherIncomes();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void managername_TextChanged(object sender, EventArgs e)
        {
            comment.Enabled = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;
               /* con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select PaymentID from OtherIncomes where PaymentID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters["@find"].Value = expenseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }*/
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  OtherIncomes where PaymentID=@DELETE1 and Comment !='Approved'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters["@DELETE1"].Value = expenseid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select PaymentID from OtherIncomes where PaymentID=@find and Comment='Approved'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters["@find"].Value = expenseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to Update..Once Approved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update OtherIncomes set Year=@d2,Months=@d3,Date=@d4,OtherFee=@d5,CashierName=@d6,Income=@d7,PaidBy=@d8,Telephone=@d9,Address=@d10,Reason=@d11 where PaymentID=@d1 and Comment!='Approved'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 15, "OtherFee"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "CashierName"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 40, "Income"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "PaidBy"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Telephone"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "Address"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "Reason"));
               

                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = months.Text.Trim();
                cmd.Parameters["@d4"].Value = expensedate.Text.Trim();
                cmd.Parameters["@d5"].Value = Convert.ToInt32(totalpaid.Value);
                cmd.Parameters["@d6"].Value = cashiername.Text.Trim();
                cmd.Parameters["@d7"].Value = service.Text;
                cmd.Parameters["@d8"].Value = names.Text.Trim();
                cmd.Parameters["@d9"].Value = tel.Text;
                cmd.Parameters["@d10"].Value = address.Text;
                cmd.Parameters["@d11"].Value = description.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            if (managername.Text == "")
            {
                MessageBox.Show("Please enter manager Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managername.Focus();
                return;
            }
            if (comment.Text == "")
            {
                MessageBox.Show("Please enter comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comment.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update OtherIncomes set Comment=@d2,ManagerID=@d3,ManagerName=@d4 where PaymentID=@d1 and Months=@d6 and Year=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "Comment"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "ManagerID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "ManagerName"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value = comment.Text.Trim();
                cmd.Parameters["@d3"].Value = managerid.Text.Trim();
                cmd.Parameters["@d4"].Value = managername.Text.Trim();
                cmd.Parameters["@d5"].Value = year.Text.Trim();
                cmd.Parameters["@d6"].Value = months.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataload();
                //Reset();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
               // this.Hide();
                //frmOtherIncomes frm = new frmOtherIncomes();
                //frm.Show();
                comment.Text = dr.Cells[0].Value.ToString();
                expenseid.Text = dr.Cells[1].Value.ToString();
                cashiername.Text = dr.Cells[2].Value.ToString();
              
                expensedate.Text = dr.Cells[5].Value.ToString();
                service.Text = dr.Cells[6].Value.ToString();
                totalpaid.Text = dr.Cells[7].Value.ToString();
                description.Text = dr.Cells[8].Value.ToString();
                names.Text = dr.Cells[9].Value.ToString();
                tel.Text = dr.Cells[10].Value.ToString(); 
                if (label2.Text == "Manager")
                {
                    buttonX4.Enabled = true;
                    buttonX3.Enabled = true;
                    label1.Text = label1.Text;
                    label2.Text = label2.Text;
                }
                else
                {
                    buttonX4.Enabled = false;
                    buttonX3.Enabled = false;
                    label1.Text = label1.Text;
                    label2.Text = label2.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        private void cashierid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(cashierid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and IncomesApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        cashiername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        cashiername.Text = "";
                    }
                }
                else
                {
                    cashiername.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void frmEXpenses_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherIncomesRecord frm = new frmOtherIncomesRecord();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void managerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(managerid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ExpensesApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        managername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        managername.Text = "";
                    }
                }
                else
                {
                    managername.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptOtherIncomesSlip rpt = new rptOtherIncomesSlip(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AExpensesDataSet myDS = new AExpensesDataSet(); //The DataSet you created.
                FrmOtherIncomesSlip frm = new FrmOtherIncomesSlip();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from Expenses,Rights where Expenses.CashierID=Rights.AuthorisationID and ExpenseID='" + expenseid.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Expenses");
                myDA.Fill(myDS, "Rights");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                company();
                float x = 10;
                float y = 5;

                float width = 260.0F; // max width I found through trial and error
                float height = 0F;

                Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
                Font drawFontArial10italic = new Font("Arial", 10, FontStyle.Italic);
                Font drawFontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
                Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Set format of string.
                StringFormat drawFormatCenter = new StringFormat();
                drawFormatCenter.Alignment = StringAlignment.Center;
                StringFormat drawFormatLeft = new StringFormat();
                drawFormatLeft.Alignment = StringAlignment.Near;
                StringFormat drawFormatRight = new StringFormat();
                drawFormatRight.Alignment = StringAlignment.Far;

                // Draw string to screen.
                string text = companyname;
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyslogan;
                e.Graphics.DrawString(text, drawFontArial10italic, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10italic).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyaddress;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companyemail;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = companycontact;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Payment ID: " + expenseid.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Date: " + DateTime.Now.ToString();
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Paid For: "+service.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "Paid By: " + names.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Total Paid: UGX." + string.Format("{0:n0}",Convert.ToInt32(totalpaid.Value));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Recieved By: " + cashiername.Text;
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = "-----------------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "THANK YOU, COME AGAIN";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Powered by: www.essentialsystems.atwebpages.com +256787045644";
                e.Graphics.DrawString(text, drawFontArial6Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial6Regular).Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
