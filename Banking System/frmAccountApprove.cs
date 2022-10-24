using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
namespace Banking_System
{
    public partial class frmAccountApprove : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd2 = null;
        public frmAccountApprove()
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
            if (accountnumber.Text=="Pending..")
            {
            accountnumber.Text = yearss+monthss+days+GetUniqueKey(6);
            }
        }
       
        private void memberids()
        {
            
        }
        public void dataload() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Account)[Account Number], RTRIM(Account.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Account.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(StaffID)[StaffName],RTRIM(AccountType)[Account Type] from Account order by Account.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridViewX1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {
            memberids();
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAccountApprove frm = new frmAccountApprove();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        string numberphone2 = null;
        string messages2 = null;
        public void sendmessage2()
        {
            string numbers2 = null;
            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(ContactNo) FROM MemberRegistration where MemberID='" + memberid.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        numberphone2 = rdr.GetString(0).Trim();
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    string usernamess= Properties.Settings.Default.smsusername;
                    string passwordss = Properties.Settings.Default.smspassword;
                    numbers2 = "+256" + numberphone2;
                    messages2 = "Dear " + membername.Text + " Your Account has been created and your account number is " + accountnumber.Text;

                    WebClient client = new WebClient();
                    string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username="+usernamess+"&password="+passwordss+"&senderid=Geniussms&message=" + messages2 + "&numbers=" + numbers2;
                    client.OpenRead(baseURL);
                    MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your internet connection, The message was not sent.");
            }
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            auto();
            if (memberid.Text == "")
            {
                MessageBox.Show("Please enter Member ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                memberid.Focus();
                return;
            }
            if (membername.Text == "")
            {
                MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                membername.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
            if (managerid.Text == "")
            {
                MessageBox.Show("Please enter manager ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managerid.Focus();
                return;
            }
            if (managername.Text == "")
            {
                MessageBox.Show("Please enter Manager Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managername.Focus();
                return;
            }
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Account set ManagerID=@d2,ManagerName=@d3,Account=@d4 where MemberID=@d1 and AccountType='"+Accounttype.Text+"' ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "MemberID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ManagerID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "ManagerName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Account"));
                cmd.Parameters["@d1"].Value = memberid.Text.Trim();
                cmd.Parameters["@d2"].Value = managerid.Text.Trim();
                cmd.Parameters["@d3"].Value = managername.Text.Trim();
                cmd.Parameters["@d4"].Value = accountnumber.Text.Trim();       
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Created", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string smsallow = Properties.Settings.Default.smsallow;
                if (smsallow == "Yes")
                {
                    sendmessage2();
                }
                con.Close();
                this.Hide();
                frmAccountApprove frm = new frmAccountApprove();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Savings ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (managername.Text == "")
            {
                MessageBox.Show("Please enter Manager Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managername.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  Account where Account=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "accountnumber"));
                cmd.Parameters["@DELETE1"].Value = accountnumber.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataload();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
                try
                {
                   /* con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(MemberID) FROM Account where MemberID='" + memberid.Text + "' and Account !=''";
                    rdr = cmd.ExecuteReader(); 
                    if (rdr.Read())
                    {
                        MessageBox.Show("Can Not Update Account Details When Account Already assigned", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        memberid.Text = "";
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    if (memberid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        memberid.Focus();
                        return;
                    }
                    if (membername.Text == "")
                    {
                        MessageBox.Show("Please enter Member name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        membername.Focus();
                        return;
                    }
                    if (year.Text == "")
                    {
                        MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        year.Focus();
                        return;
                    }
                    if (Accounttype.Text == "")
                    {
                        MessageBox.Show("Please Seclect Account Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Accounttype.Focus();
                        return;
                    }
                   
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update Account set Year=@d2,Months=@d3,Date=@d4,AccountType=@d6,MemberName=@d7 where MemberID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "MemberID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "AccountType"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "MemberName"));
                    cmd.Parameters["@d1"].Value = memberid.Text.Trim();
                    cmd.Parameters["@d2"].Value = year.Text.Trim();
                    cmd.Parameters["@d3"].Value = months.Text.Trim();
                    cmd.Parameters["@d4"].Value = date.Text.Trim();
                    cmd.Parameters["@d6"].Value = Accounttype.Text.Trim();
                    cmd.Parameters["@d7"].Value = membername.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataload();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void frmSavings_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void memberid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                membername.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(MemberName) FROM MemberRegistration where MemberID='" + memberid.Text + "'";
                rdr = cmd.ExecuteReader();
                membername.Text = "";
                if (rdr.Read())
                {
                    membername.Text = rdr.GetString(0).Trim();
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

      
        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                accountnumber.Text = dr.Cells[0].Value.ToString();
                memberid.Text = dr.Cells[1].Value.ToString();
                membername.Text = dr.Cells[2].Value.ToString();
                Accounttype.Text = dr.Cells[7].Value.ToString();
                buttonX4.Enabled = true;
                buttonX3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();

                cmd = new SqlCommand("select RTRIM(Account)[Account Number], RTRIM(Account.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Account.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date], RTRIM(AccountType)[Account Type],RTRIM(ManagerName)[Manager Name] from MemberRegistration where  Date between @date1 and @date2 order by Account.ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridViewX1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
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
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ApproveAccount='Yes'";
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
        private void buttonX8_Click(object sender, EventArgs e)
        {
            dataload();
        }
        private void buttonX9_Click(object sender, EventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.DataSource = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Account)[Account Number], RTRIM(Account.MemberID)[Member ID], RTRIM(MemberName)[Member Name], RTRIM(Account.Year)[Year],RTRIM(Months)[Months], RTRIM(Date)[Date], RTRIM(AccountType)[Account Type],RTRIM(ManagerName)[Manager Name] from Account where Account !='Pending..' and Account like '" + textBoxX1.Text + "%' OR MemberName like '" + textBoxX1.Text + "%' OR Date like '" + textBoxX1.Text + "%' OR AccountType like '" + textBoxX1.Text + "%' OR MemberID like '" + textBoxX1.Text + "%' order by Account.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridViewX1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void memberid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MemberName from MemberRegistration WHERE MemberID = '" + memberid.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    membername.Text = (rdr.GetString(0).Trim());
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
    }
}
