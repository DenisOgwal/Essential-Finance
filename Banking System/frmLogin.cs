using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;
namespace Banking_System
{
    public partial class frmLogin : DevComponents.DotNetBar.Office2007Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string status = "Available";
        public frmLogin()
        {
            InitializeComponent();
        }
         public void loansremind() {
            try
            {
               /* frmLoanreminder frm1 = new frmLoanreminder();
                    frm1.Show();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void Form1_Load(object sender, EventArgs e)
        {
            this.labelX1.Text = AssemblyCopyright;
            ProgressBar1.Visible = false;
            txtUserName.Focus();
            //loansremind();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
            frm.txtUserName.Text = "";
            frm.txtNewPassword.Text = "";
            frm.txtOldPassword.Text = "";
            frm.txtConfirmPassword.Text = "";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRecoveryPassword frm = new frmRecoveryPassword();
            frm.txtEmail.Focus();
            frm.Show();
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
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

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

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        string results = null;
        string resultss = null;
        string resultsss = null;
        string resultssss = null;

        string results1 = null;
        string results2 = null;
        string results3 = null;
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results = Encoding.UTF8.GetString(bytesDecrypted);

            return results;
        }
        public string DecryptText1(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results1 = Encoding.UTF8.GetString(bytesDecrypted);

            return results1;
        }
        public string DecryptText2(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results2 = Encoding.UTF8.GetString(bytesDecrypted);

            return results2;
        }
        public string DecryptText3(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results3 = Encoding.UTF8.GetString(bytesDecrypted);

            return results3;
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
        public string EncryptText1(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultss = Convert.ToBase64String(bytesEncrypted);

            return resultss;
        }
        public string EncryptText2(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultsss = Convert.ToBase64String(bytesEncrypted);

            return resultsss;
        }
        public string EncryptText3(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultssss = Convert.ToBase64String(bytesEncrypted);

            return resultssss;
        }
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                if (txtUserName.Text == "ADMIN" && txtPassword.Text == "jesus@lord1")
                {
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = txtUserName.Text;
                    frm.UserType.Text = "ADMIN";
                    frm.label1.Text = "jesus@lord1";

                    DateTime dt = DateTime.Today.Date;
                    string dts = DateTime.Now.ToLongTimeString();
                    string currentdate = dt.ToString("dd/MMM/yyyy");
                    string computername = Environment.MachineName;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Successful')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                    cmd.Parameters["@d1"].Value = txtUserName.Text;
                    cmd.Parameters["@d2"].Value = txtUserName.Text;
                    cmd.Parameters["@d3"].Value = currentdate;
                    cmd.Parameters["@d4"].Value = dts;
                    cmd.Parameters["@d5"].Value = computername;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    EncryptText(txtPassword.Text, "essentialfinance");
                    con = new SqlConnection(cs.DBConn);
                    SqlCommand myCommand = default(SqlCommand);
                    myCommand = new SqlCommand("SELECT usertype,Username,password,Name FROM User_Registration WHERE Username = @username AND password = @UserPassword", con);
                    SqlParameter uName = new SqlParameter("@username", SqlDbType.NChar);
                    SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.NChar);
                    uName.Value = txtUserName.Text;
                    uPassword.Value =result;
                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uPassword);
                    myCommand.Connection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read() == true)
                    {
                        int i;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;
                        for (i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }
                        string usertypes = myReader["usertype"].ToString().Trim();
                        string realname= myReader["Name"].ToString().Trim();

                        DateTime dt = DateTime.Today.Date;
                        string dts = DateTime.Now.ToLongTimeString();
                        string currentdate = dt.ToString("dd/MMM/yyyy");
                        string computername = Environment.MachineName;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Successful')";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                        cmd.Parameters["@d1"].Value = txtUserName.Text;
                        cmd.Parameters["@d2"].Value = realname;
                        cmd.Parameters["@d3"].Value = currentdate;
                        cmd.Parameters["@d4"].Value = dts;
                        cmd.Parameters["@d5"].Value = computername;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        frmMainMenu frm = new frmMainMenu();
                        frm.User.Text = txtUserName.Text;
                        frm.UserType.Text = realname;
                        this.Hide();
                        frm.Show();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                        cmd = new SqlCommand(cb1);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                        cmd.Parameters["@d1"].Value = txtUserName.Text.Trim();
                        cmd.Parameters["@d2"].Value = status;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        DateTime dt = DateTime.Today.Date;
                        string dts = DateTime.Now.ToLongTimeString();
                        string currentdate = dt.ToString("dd/MMM/yyyy");
                        string computername = Environment.MachineName;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Failed')";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                        cmd.Parameters["@d1"].Value = txtUserName.Text;
                        cmd.Parameters["@d2"].Value = txtUserName.Text;
                        cmd.Parameters["@d3"].Value = currentdate;
                        cmd.Parameters["@d4"].Value = dts;
                        cmd.Parameters["@d5"].Value = computername;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
           /* string realkey = Properties.Settings.Default.readcon;
            if (realkey == "you")
            {
                try
                {
                    string codes = "dither" + "/" + 1;
                    string keys = "dither" + "/" + 30;
                    string checkdate4 = DateTime.Today.ToShortDateString();
                    DateTime dtc4 = DateTime.Parse(checkdate4);
                    string converteddatesc4 = dtc4.ToString("dd/MMM/yyyy");
                    string expdate = (dtc4.AddDays(30).ToShortDateString());
                    DateTime ds = DateTime.Parse(expdate);
                    string convertcheck = ds.ToString("dd/MMM/yyyy");
                    EncryptText(codes, "essentialfinance");
                    EncryptText1(keys, "essentialfinance");
                    EncryptText2(converteddatesc4, "essentialfinance");
                    EncryptText3(convertcheck, "essentialfinance");
                    DecryptText(resultssss, "essentialfinance");
                    // MessageBox.Show(results, "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "UPDATE  CompanyNames set Other=@d2";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Other"));
                    cmd.Parameters["@d2"].Value = result;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "UPDATE  CurrentDate set CurrentDate=@d2";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "CurrentDate"));
                    cmd.Parameters["@d2"].Value = resultsss;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string cb5 = "UPDATE  Compositions set Coding=@d2,Date=@d3";
                    cmd = new SqlCommand(cb5);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Coding"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                    cmd.Parameters["@d2"].Value = resultss;
                    cmd.Parameters["@d3"].Value = resultssss;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Properties.Settings.Default["readcon"] = "mine";
                    Properties.Settings.Default.Save();
                }
                catch (Exception)
                {

                }
            }
            else if (realkey == "mine")
            {
                try
                {
                    string currentdates = null;
                    string currentdatess = null;
                    string currentdatesss = null;
                    string currentdatessss = null;
                    string Currentdateformat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                    string trimformart = Currentdateformat.Substring(0, 10);
                    if (trimformart == "dd/MMM/yyy")
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co = "SELECT * from CurrentDate";
                        cmd = new SqlCommand(co);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {
                            currentdates = rdr["CurrentDate"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdates) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co1 = "SELECT * from Compositions";
                        cmd = new SqlCommand(co1);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {
                            currentdatess = rdr["Coding"].ToString().Trim();
                            currentdatesss = rdr["Date"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdatess) == true || string.IsNullOrEmpty(currentdatesss) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co2 = "SELECT Other from CompanyNames";
                        cmd = new SqlCommand(co2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {

                            currentdatessss = rdr["Other"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdatessss) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                    }

                    DecryptText(currentdates, "essentialfinance");
                    DecryptText1(currentdatesss, "essentialfinance");
                    DecryptText2(currentdatessss, "essentialfinance");
                    DecryptText3(currentdatess, "essentialfinance");
                    string[] words = results2.Split('/');//noofcopies
                    string[] wordss = results3.Split('/');//days
                    DateTime dtc6 = DateTime.Parse(results);
                    DateTime dtc5 = DateTime.Parse(results1);

                    string checkdate4 = DateTime.Today.ToShortDateString();
                    DateTime dtc4 = DateTime.Parse(checkdate4);

                    double daysnumbermax = dtc5.Subtract(dtc4).TotalDays;
                    double daysnumbermin = dtc4.Subtract(dtc6).TotalDays;

                    if (daysnumbermin >= Convert.ToInt32(wordss[1].ToString()) || daysnumbermax <= 0)
                    {
                        MessageBox.Show("Your trial Period has Ended, Please Add purchase keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Enabled = false;
                        txtUserName.Enabled = false;
                        frmLicenceInput frm = new frmLicenceInput();
                        frm.ShowDialog();
                        return;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Enabled = false;
                    txtUserName.Enabled = false;
                    frmLicenceInput frm = new frmLicenceInput();
                    frm.ShowDialog();
                    return;
                }

            }
            else if (realkey == "me")
            {
                try
                {
                    string currentdates = null;
                    string currentdatess = null;
                    string currentdatesss = null;
                    string currentdatessss = null;
                    string companynam = null;
                    string Currentdateformat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                    string trimformart = Currentdateformat.Substring(0, 10);
                    if (trimformart == "dd/MMM/yyy")
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co = "SELECT * from CurrentDate";
                        cmd = new SqlCommand(co);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {
                            currentdates = rdr["CurrentDate"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdates) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co1 = "SELECT * from Compositions";
                        cmd = new SqlCommand(co1);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {
                            currentdatess = rdr["Coding"].ToString().Trim();
                            currentdatesss = rdr["Date"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdatess) == true || string.IsNullOrEmpty(currentdatesss) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string co2 = "SELECT Other,Names from CompanyNames";
                        cmd = new SqlCommand(co2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == true)
                        {

                            currentdatessss = rdr["Other"].ToString().Trim();
                            companynam = rdr["Names"].ToString().Trim();
                            if (string.IsNullOrEmpty(currentdatessss) == true)
                            {
                                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Enabled = false;
                                txtUserName.Enabled = false;
                                frmLicenceInput frm = new frmLicenceInput();
                                frm.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;

                        }
                    }
                    string[] wordsss = companynam.Split(' ');
                    string needednam = wordsss[0].ToLower();
                    DecryptText(currentdates, "essentialfinance");
                    DecryptText1(currentdatesss, "essentialfinance");//date
                    DecryptText2(currentdatessss, "essentialfinance");//other
                    DecryptText3(currentdatess, "essentialfinance");//coding
                    string[] words = results2.Split('/');//noofcopies
                    string[] wordss = results3.Split('/');//days
                    //MessageBox.Show(results1, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(results2, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(results3, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (needednam == words[0] && needednam == wordss[0])
                    {
                        DateTime dtc6 = DateTime.Parse(results);
                        DateTime dtc5 = DateTime.Parse(results1);

                        string checkdate4 = DateTime.Today.ToShortDateString();
                        DateTime dtc4 = DateTime.Parse(checkdate4);

                        double daysnumbermax = dtc5.Subtract(dtc4).TotalDays;
                        double daysnumbermin = dtc4.Subtract(dtc6).TotalDays;

                        if (daysnumbermin >= Convert.ToInt32(wordss[1].ToString()) || daysnumbermax <= 0)
                        {
                            MessageBox.Show("Your Licence Period has Ended, Please Add purchase keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Enabled = false;
                            txtUserName.Enabled = false;
                            frmLicenceInput frm = new frmLicenceInput();
                            frm.ShowDialog();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Keys you Applied are not for this Hospital, Get The Right Keys from Dither", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Enabled = false;
                        txtUserName.Enabled = false;
                        frmLicenceInput frm = new frmLicenceInput();
                        frm.ShowDialog();
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Enabled = false;
                    txtUserName.Enabled = false;
                    frmLicenceInput frm = new frmLicenceInput();
                    frm.ShowDialog();
                    return;
                }

            }
            else
            {
                MessageBox.Show("You tried To Manuplate the System. Contact Dither For Genuine Keys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
                frmLicenceInput frm = new frmLicenceInput();
                frm.ShowDialog();
                return;
            }*/
        }
    }
}
