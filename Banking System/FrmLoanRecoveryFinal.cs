using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanRecoveryFinal : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        SqlCommand cmd2 = null;
        public FrmLoanRecoveryFinal()
        {
            InitializeComponent();
        }

        private void FrmLoanFirstApproval_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account No.],RTRIM(AccountNames)[Account Name],RTRIM(LoanID)[Loan ID] from Recovery where  Approval='Approved' and RecoveryModeBy='Pending' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Recovery");
                dataGridView1.DataSource = myDataSet.Tables["Recovery"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                AccountNumber.Text = dr.Cells[0].Value.ToString();
                AccountName.Text = dr.Cells[1].Value.ToString();
                LoanID.Text = dr.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanRecovery frm = new FrmLoanRecovery();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        private void ApprovalID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(ApprovalID.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and WriteOff2='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr = cmd2.ExecuteReader();
                    if (rdr.Read())
                    {
                        ApprovalName.Text = rdr["UserName"].ToString().Trim();
                    }
                    else
                    {
                        ApprovalName.Text = "";
                    }
                }
                else
                {
                    ApprovalName.Text = "";
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
        int TotalPrincipal = 0;
        int totalbalanceexist = 0;
        int pendingpayment = 0;
        string interrestmethod = null;
        int intrestearned = 0;
        int realloanfine = 0;
        int Actualbalance = 0;
        int actualinterest = 0;
        int totalbalanceexist1 = 0;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (AccountNumber.Text == "")
            {
                MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountNumber.Focus();
                return;
            }
            if (AccountName.Text == "")
            {
                MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountName.Focus();
                return;
            }
            if (ApprovalName.Text == "")
            {
                MessageBox.Show("Please Enter Correct Approval ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ApprovalID.Focus();
                return;
            }
            if (approvals.Text == "")
            {
                MessageBox.Show("Please Select Approvals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvals.Focus();
                return;
            }
            if (approvals.Text == "Approved")
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE Recovery SET RecoveryModeDate=@d2,RecoveryModeBy=@d3 Where LoanID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "RecoveryModeDate"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "RecoveryModeBy")); ;
                    cmd.Parameters["@d1"].Value = LoanID.Text;
                    cmd.Parameters["@d2"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d3"].Value = ApprovalName.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate > @date1 and PaymentStatus='Paid'", con);
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentDate > @date1 and PaymentStatus='Paid'";
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            totalbalanceexist1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        SqlDataReader rdr2 = null;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select Fines from RepaymentSchedule where Waivered='No' and PaymentStatus='Pending' and LoanID='" + LoanID.Text + "'", con);
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                        cmd.Connection = con;
                        rdr2 = cmd.ExecuteReader();
                        if (rdr2.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select SUM(Fines) from RepaymentSchedule where Waivered='No' and PaymentStatus='Pending' and LoanID='" + LoanID.Text + "'", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            realloanfine = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()));
                        }
                        else
                        {
                            realloanfine = 0;
                        }
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        SqlDataReader rdr3 = null;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "select IssueType from Loan where LoanID= '" + LoanID.Text + "'";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr3 = cmd.ExecuteReader();
                        if (rdr3.Read())
                        {
                            interrestmethod = rdr3[0].ToString().Trim();
                        }
                        con.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (interrestmethod == "Reducing Balance")
                    {
                        try
                        {
                            SqlDataReader rdr4 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and BalanceExist > 0", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            cmd.Connection = con;
                            rdr4 = cmd.ExecuteReader();
                            if (rdr4.Read())
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and BalanceExist > 0";
                                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                                totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                                con.Close();
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        try
                        {
                            SqlDataReader rdr17 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            cmd.Connection = con;
                            rdr17 = cmd.ExecuteReader();
                            if (rdr17.Read())
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "SELECT SUM(Interest) FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'";
                                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                                intrestearned = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));  
                                con.Close();    
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "SELECT SUM(AmmountPay) as principalsum FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'";
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            TotalPrincipal = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                            con.Close();   
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        int TotalIntrests = 0;
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "SELECT TOP (1) Interest FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            TotalIntrests = Convert.ToInt32(cmd.ExecuteScalar());
                            //label3.Text = TotalIntrests.ToString();
                           
                                con.Close();
                           
                        }
                        catch (Exception)
                        {
                            ///MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        int realintrest = 0;
                        int totalrealintrest = 0;
                        try
                        {
                            SqlDataReader rdr5 = null;
                            int ids = 0;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select ID from RepaymentSchedule where PaymentDate >= @date1 and LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            cmd.Connection = con;
                            rdr5 = cmd.ExecuteReader();
                            if (rdr5.Read())
                            {
                                ids = Convert.ToInt32(rdr5[0]);
                                SqlDataReader rdr6 = null;
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct2 = "select PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC ";
                                cmd = new SqlCommand(ct2);
                                cmd.Connection = con;
                                rdr6 = cmd.ExecuteReader();
                                if (rdr6.Read())
                                {
                                    string paymentdate = rdr6[0].ToString();
                                    string loantype = rdr6[1].ToString().Trim();
                                    if (loantype == "Daily")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr6[2]));
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(-1).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 0)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Weekly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr6[2])) / 7;
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(-7).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Monthly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr6[2])) / 30;
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddMonths(-1).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }

                                    }
                                    else
                                    {
                                        // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    SqlDataReader rdr7 = null;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending'  order by ID ASC ";
                                    cmd = new SqlCommand(ct6);
                                    cmd.Connection = con;
                                    rdr7 = cmd.ExecuteReader();
                                    if (rdr7.Read())
                                    {
                                        string paymentdate = rdr7[0].ToString();
                                        string loantype = rdr7[1].ToString().Trim();
                                        if (loantype == "Daily")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr7[2]));
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(0).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 0)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Weekly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr7[2])) / 7;
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(0).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Monthly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr7[2])) / 30;
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddMonths(0).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }

                                        }
                                        else
                                        {
                                            // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    con.Close();
                                }
                                con.Close();
                            }
                            else
                            {
                                SqlDataReader rdr8 = null;
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct6 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending'  order by ID ASC ";
                                cmd = new SqlCommand(ct6);
                                cmd.Connection = con;
                                rdr8 = cmd.ExecuteReader();
                                if (rdr8.Read())
                                {
                                    string paymentdate = rdr8[0].ToString();
                                    string loantype = rdr8[1].ToString().Trim();
                                    if (loantype == "Daily")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr8[2]));
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(-1).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 0)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Weekly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr8[2])) / 7;
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddDays(-7).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }
                                    }
                                    else if (loantype == "Monthly")
                                    {
                                        realintrest = Convert.ToInt32(Convert.ToDouble(rdr8[2])) / 30;
                                        DateTime startdate = DateTime.Parse(paymentdate).Date;
                                        string realdate = startdate.AddMonths(-1).ToShortDateString();
                                        DateTime dt = DateTime.Parse(realdate);
                                        DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                        int daysbetween = currentdate.Subtract(dt).Days;
                                        if (daysbetween > 1)
                                        {
                                            totalrealintrest = realintrest * daysbetween;
                                        }
                                        else
                                        {
                                            totalrealintrest = 0;
                                        }

                                    }
                                    else
                                    {
                                        // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                con.Close();
                            }

                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        int duebal = totalbalanceexist;
                        int duebals = 0;

                        int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                        if (result > 500)
                        {
                            duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                        }
                        else if (result < 500 && result > 0)
                        {
                            duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                        }
                        else
                        {
                            duebals = duebal;
                        }
                        Actualbalance = (duebals);
                        actualinterest = intrestearned ;
                    }
                    else if (interrestmethod == "Flat Rate")
                    {
                       
                        try
                        {
                            SqlDataReader rdr9 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and BalanceExist > 0", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            cmd.Connection = con;
                            rdr9 = cmd.ExecuteReader();
                            if (rdr9.Read())
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "SELECT SUM(BalanceExist) as principalsum2 FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and BalanceExist > 0";
                                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                                totalbalanceexist = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                               
                                    con.Close();
                                
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        try
                        {
                            SqlDataReader rdr10 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select TotalAmmount from RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'", con);
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                            cmd.Connection = con;
                            rdr10 = cmd.ExecuteReader();
                            if (rdr10.Read())
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "SELECT SUM(Interest) FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending'";
                                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                                intrestearned = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.ExecuteScalar())));
                                
                                    con.Close();
                                
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        SqlDataReader rdr11 = null;
                        int ids = 0;
                        int principals = 0;
                        int totalrealintrest = 0;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select ID from RepaymentSchedule where PaymentDate > @date1 and LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC", con);
                        cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = ApplicationDate.Value.Date;
                        cmd.Connection = con;
                        rdr11 = cmd.ExecuteReader();
                        if (rdr11.Read())
                        {
                            // twhen this is not the last installment
                            ids = Convert.ToInt32(rdr11[0]);
                            //MessageBox.Show(ids.ToString());
                            SqlDataReader rdr12 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            //cmd = con.CreateCommand();
                            string ct2 = "SELECT  Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr12 = cmd.ExecuteReader();
                            if (rdr12.Read())
                            {
                                int realintrest = 0;
                               
                                int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr12[0]));
                                principals = Convert.ToInt32(Convert.ToDouble(rdr12[1]));
                                try
                                {
                                    SqlDataReader rdr13 = null;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string ct4 = "select PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' and ID=" + ids + " order by ID ASC";
                                    cmd = new SqlCommand(ct4);
                                    cmd.Connection = con;
                                    rdr13= cmd.ExecuteReader();
                                    if (rdr13.Read())
                                    {
                                        string paymentdate = rdr13[0].ToString();
                                        string loantype = rdr13[1].ToString().Trim();
                                        if (loantype == "Daily")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr13[2]));
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(-1).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 0)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Weekly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr13[2])) / 7;
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(-7).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Monthly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr13[2])) / 30;
                                            // MessageBox.Show(realintrest.ToString());
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddMonths(-1).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                            //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {

                                    }

                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                con.Close();
                            }
                            else
                            {
                                SqlDataReader rdr14 = null;
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                //cmd = con.CreateCommand();
                                string ct6 = "SELECT  TOP (1) Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                                cmd = new SqlCommand(ct6);
                                cmd.Connection = con;
                                rdr14 = cmd.ExecuteReader();
                                if (rdr14.Read())
                                {
                                    int realintrest = 0;
                                    int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr14[0]));
                                    principals = Convert.ToInt32(Convert.ToDouble(rdr14[1]));
                                    try
                                    {
                                        SqlDataReader rdr15 = null;
                                        con = new SqlConnection(cs.DBConn);
                                        con.Open();
                                        string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID ASC";
                                        cmd = new SqlCommand(ct4);
                                        cmd.Connection = con;
                                        rdr15 = cmd.ExecuteReader();
                                        if (rdr15.Read())
                                        {
                                            string paymentdate = rdr15[0].ToString();
                                            //MessageBox.Show(rdr[0].ToString());
                                            string loantype = rdr15[1].ToString().Trim();
                                            if (loantype == "Daily")
                                            {
                                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr15[2]));
                                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                                string realdate = startdate.AddDays(0).ToShortDateString();
                                                DateTime dt = DateTime.Parse(realdate);
                                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                                int daysbetween = currentdate.Subtract(dt).Days;
                                                if (daysbetween > 0)
                                                {
                                                    totalrealintrest = realintrest * daysbetween;
                                                }
                                                else
                                                {
                                                    totalrealintrest = 0;
                                                }
                                            }
                                            else if (loantype == "Weekly")
                                            {
                                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr15[2])) / 7;
                                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                                string realdate = startdate.AddDays(0).ToShortDateString();
                                                DateTime dt = DateTime.Parse(realdate);
                                                string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                                int daysbetween = currentdate.Subtract(dt).Days;
                                                if (daysbetween > 1)
                                                {
                                                    totalrealintrest = realintrest * daysbetween;
                                                }
                                                else
                                                {
                                                    totalrealintrest = 0;
                                                }
                                            }
                                            else if (loantype == "Monthly")
                                            {
                                                realintrest = Convert.ToInt32(Convert.ToDouble(rdr15[2])) / 30;
                                                //MessageBox.Show(realintrest.ToString());
                                                DateTime startdate = DateTime.Parse(paymentdate).Date;
                                                string realdate = startdate.AddMonths(0).ToShortDateString();
                                                DateTime dt = DateTime.Parse(realdate);
                                                DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                                int daysbetween = currentdate.Subtract(dt).Days;
                                                if (daysbetween > 1)
                                                {
                                                    totalrealintrest = realintrest * daysbetween;
                                                }
                                                else
                                                {
                                                    totalrealintrest = 0;
                                                }
                                                //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                  
                                    con.Close();
                                }
                               
                            }
                           
                        }
                        else
                        {
                            SqlDataReader rdr16 = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            //cmd = con.CreateCommand();
                            string ct2 = "SELECT  TOP (1) Interest,AmmountPay FROM RepaymentSchedule where LoanID='" + LoanID.Text + "' and PaymentStatus='Pending' order by ID DESC";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr16 = cmd.ExecuteReader();
                            if (rdr16.Read())
                            {
                                int realintrest = 0;
                                int TotalIntrests = Convert.ToInt32(Convert.ToDouble(rdr16[0]));
                             
                                try
                                {
                                    SqlDataReader rdr = null;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string ct4 = "select TOP (1) PaymentDate,LoanType,Interest from RepaymentSchedule where LoanID= '" + LoanID.Text + "' and PaymentStatus='Pending' order by ID DESC";
                                    cmd = new SqlCommand(ct4);
                                    cmd.Connection = con;
                                    rdr = cmd.ExecuteReader();
                                    if (rdr.Read())
                                    {
                                        string paymentdate = rdr[0].ToString();
                                        string loantype = rdr[1].ToString().Trim();
                                        if (loantype == "Daily")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2]));
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(-1).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 0)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Weekly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 7;
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddDays(-7).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            string repaymentdate = dt.ToString("dd/MMM/yyyy");
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                        }
                                        else if (loantype == "Monthly")
                                        {
                                            realintrest = Convert.ToInt32(Convert.ToDouble(rdr[2])) / 30;
                                            DateTime startdate = DateTime.Parse(paymentdate).Date;
                                            string realdate = startdate.AddMonths(-1).ToShortDateString();
                                            DateTime dt = DateTime.Parse(realdate);
                                            DateTime currentdate = DateTime.Parse(ApplicationDate.Text).Date;
                                            int daysbetween = currentdate.Subtract(dt).Days;
                                            if (daysbetween > 1)
                                            {
                                                totalrealintrest = realintrest * daysbetween;
                                            }
                                            else
                                            {
                                                totalrealintrest = 0;
                                            }
                                            //MessageBox.Show(totalrealintrest.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            // MessageBox.Show(daysbetween.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            // MessageBox.Show(loantype, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                              
                            }
                           
                        }
                        int duebal =  totalbalanceexist;
                        int duebals = 0;
                        //label7.Text = (intrestearned + totalrealintrest).ToString();

                        int result = Convert.ToInt32(Convert.ToInt32(duebal) % 1000);
                        if (result > 500)
                        {
                            duebals = Convert.ToInt32(duebal) + 1000 - Convert.ToInt32(duebal) % 1000;
                        }
                        else if (result < 500 && result > 0)
                        {
                            duebals = Convert.ToInt32(duebal) + 500 - Convert.ToInt32(duebal) % 1000;
                        }
                        else
                        {
                            duebals = duebal;
                        }
                        Actualbalance = (duebals);
                        actualinterest = intrestearned;
                        con.Close();
                        // con.Close();
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb5 = "update RepaymentSchedule set BalanceExist=0,UploadStatus='Pending', PaymentStatus ='Recovery' where LoanID=@d2  and PaymentStatus ='Pending'";
                    cmd = new SqlCommand(cb5);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@d1"].Value = "Recovery";
                    cmd.Parameters["@d2"].Value = LoanID.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                        string Paymentdatess = null;
                        DateTime startdates = DateTime.Parse(ApplicationDate.Text).Date;
                        string repaymentdate1 = startdates.ToShortDateString();
                        DateTime dtss = DateTime.Parse(repaymentdate1);
                        Paymentdatess = dtss.ToString("dd/MMM/yyyy");
                    string lonty = null;
                    int issuedammount = 0;
                    double rates = 0.00;
                    string interestty = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct9 = "select LoanType,IssuedAmmount,Rates,IntrestType from RepaymentSchedule where LoanID= '" + LoanID.Text + "' order by ID DESC";
                    cmd = new SqlCommand(ct9);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        lonty = rdr["LoanType"].ToString();
                        issuedammount= Convert.ToInt32(rdr["IssuedAmmount"]);
                        rates = Convert.ToDouble(rdr["Rates"]);
                        interestty = rdr["IntrestType"].ToString();
                    }

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb4 = "insert into RepaymentSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName,IntrestType,Rates,IssuedAmmount,LoanType,ActualPaymentDate,Waivered,NoAccrued,Fines) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d4,'Recovery',60,"+ realloanfine + ")";
                        cmd = new SqlCommand(cb4);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "IntrestType"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Float, 20, "Rates"));
                        cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 20, "IssuedAmmount,"));
                        cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "LoanType"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNumber.Text;
                        cmd.Parameters["@d3"].Value = "Recovery";
                        cmd.Parameters["@d4"].Value = Paymentdatess;
                        cmd.Parameters["@d5"].Value = Actualbalance- realloanfine;
                        cmd.Parameters["@d6"].Value = (Actualbalance - (actualinterest+realloanfine));
                        cmd.Parameters["@d7"].Value = actualinterest;
                        cmd.Parameters["@d8"].Value = Actualbalance;
                        cmd.Parameters["@d9"].Value = 0;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.Parameters["@d11"].Value = interestty;
                        cmd.Parameters["@d12"].Value = rates;
                        cmd.Parameters["@d13"].Value = issuedammount;
                        cmd.Parameters["@d14"].Value = lonty;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    
                    MessageBox.Show("Successfuly Put to Recovery state", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmLoanRecoveryFinal frm = new FrmLoanRecoveryFinal();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.ShowDialog();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE Recovery SET RecoveryModeDate=@d2,RecoveryModeBy=@d3 Where LoanID=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "LoanID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "RecoveryModeDate"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "RecoveryModeBy")); ;
                    cmd.Parameters["@d1"].Value = LoanID.Text;
                    cmd.Parameters["@d2"].Value = ApplicationDate.Text;
                    cmd.Parameters["@d3"].Value = ApprovalName.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Records_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
            FrmLoanScheduleRecord frm = new FrmLoanScheduleRecord();
            frm.label1.Text = LoanID.Text;
            frm.ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (LoanID.Text == "")
            {
                MessageBox.Show("Please Fill Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoanID.Focus();
                return;
            }
            this.Hide();
            frmEXpensesLoanRecovery frm = new frmEXpensesLoanRecovery();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.LoanID.Text = LoanID.Text;
            frm.expensetype.Text = "Loan Recovery";
            frm.ShowDialog();
           
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanRecoveryFinal frm = new FrmLoanRecoveryFinal();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanRecoveryApproval frm = new FrmLoanRecoveryApproval();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
    }
}
