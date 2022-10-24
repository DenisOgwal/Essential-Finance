using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;

namespace Banking_System
{
    public partial class frmCashierSafe : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        ConnectionString cs = new ConnectionString();
        int accountbalances = 0;
        public frmCashierSafe()
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
        int savings = 0; int fines = 0; int grantfees = 0; int sharecapital = 0; int registration = 0; int loanprocessingfees = 0; int annualfeespayment = 0;
        int expenses = 0; int issuedloans = 0; int withdraws = 0;
        int loaninsurance = 0; int loanrepayment = 0; int otherincomes = 0; int passledgerform = 0;

        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            transferid.Text = "CST-" + years + monthss + days + GetUniqueKey(5);
        }
        private void cashiers()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(StaffID) FROM Employee", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                staffid.Items.Clear();
                memberid2.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    staffid.Items.Add(drow[0].ToString());
                    memberid2.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cashiers2()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(TransferID) FROM CashierFunds", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                memberid1.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    memberid1.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dataload() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmWithdraw_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
             cashiers();
             cashiers2();
             dataload();
             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 string ct2 = "select CashInBox from CashierFunds where  Latest='Yes'";
                 cmd = new SqlCommand(ct2);
                 cmd.Connection = con;
                 rdr2 = cmd.ExecuteReader();
                 if (rdr2.Read())
                 {
                     safebalance.Text = rdr2["CashInBox"].ToString();
                     label3.Text = rdr2["CashInBox"].ToString();
                     if ((rdr2 != null))
                     {
                         rdr2.Close();
                     }
                 }
                 else {
                     safebalance.Text = "0";
                     label3.Text = "0";
                 }
                con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
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
        public void Reset(){
            transferid.Text = "";
            //safebalance.Text = null;
            staffid.Text = "";
            staffname.Text = "";
            transactionammount.Text = null;
            managerid.Text = "";
            managername.Text = "";
            cashinflow.Text = null;
            cashinflow.Text = null;
    }
        private void frmWithdraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Reset();
            this.Hide();
            frmCashierSafe frm = new frmCashierSafe();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            auto();
            if (staffname.Text == "")
            {
                MessageBox.Show("Please Select Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                staffid.Focus();
                return;
            }
            if (transactionammount.Text == "")
            {
                MessageBox.Show("Please enter Transaction Ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactionammount.Focus();
                return;
            }
            if (transactionammount.Text == "")
            {
                MessageBox.Show("Please enter Transaction ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactionammount.Focus();
                return;
            }
            if (managername.Text == "")
            {
                MessageBox.Show("Please enter Manager Authentication ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managerid.Focus();
                return;
            }
            
            try
            {
                if (radioButton1.Checked)
                {
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select TransferID from CashierFunds where  TransferTo=@find and Date='" + date2.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                    cmd.Parameters["@find"].Value = staffname.Text;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        int val4 = 0;
                        int val5 = 0;
                        string ct2 = "select TotalTransfered from CashierFunds where  TransferTo='"+staffname.Text+"' and Date='" + date2.Text + "'";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr2 = cmd.ExecuteReader();
                        if (rdr2.Read())
                        {
                            string Accbalance = rdr2["TotalTransfered"].ToString();
                            val4 = Convert.ToInt32(Accbalance);
                            int.TryParse(transactionammount.Text, out val5);
                            accountbalances = (val4 +val5);
                            if ((rdr2 != null))
                            {
                                rdr2.Close();
                            }
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update CashierFunds  Set TotalTransfered=@d6,CashInBox=@d10,Latest='Yes' where TransferTo='" + staffname.Text + "' and Date='" + date2.Text + "'";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "CashierOutFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CashierInFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "CashierReturn"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "CashInBox"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = accountbalances;
                        cmd.Parameters["@d7"].Value = 0;
                        cmd.Parameters["@d8"].Value = 0;
                        cmd.Parameters["@d9"].Value = 0;
                        cmd.Parameters["@d10"].Value = safebalance.Text;
                        cmd.Parameters["@d11"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "insert into CashierFundsInstallments(TransferID,TransferTo,Year,Months,Date,TotalTransfered,ManagerName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = transactionammount.Text;
                        cmd.Parameters["@d7"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb5 = "Update CashierFunds  Set Latest='No' where TransferTo !='" + staffname.Text + "'";
                        cmd = new SqlCommand(cb5);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;         
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into CashierFunds(TransferID,TransferTo,Year,Months,Date,TotalTransfered,CashierOutFlow,CashierInFlow,CashierReturn,CashInBox,ManagerName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "CashierOutFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CashierInFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "CashierReturn"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "CashInBox"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = transactionammount.Text;
                        cmd.Parameters["@d7"].Value = 0;
                        cmd.Parameters["@d8"].Value = 0;
                        cmd.Parameters["@d9"].Value = 0;
                        cmd.Parameters["@d10"].Value = safebalance.Text;
                        cmd.Parameters["@d11"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();



                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb3 = "insert into CashierFundsInstallments(TransferID,TransferTo,Year,Months,Date,TotalTransfered,ManagerName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                        cmd = new SqlCommand(cb3);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = transactionammount.Text;
                        cmd.Parameters["@d7"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb5 = "Update CashierFunds  Set Latest='No' where TransferID !='" + transferid.Text + "'";
                        cmd = new SqlCommand(cb5);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                   
                }
                    
                else if (radioButton2.Checked)
                {
                   
                    cashinflow.Text = (savings + fines + grantfees + sharecapital + registration + loanprocessingfees + annualfeespayment + loaninsurance + loanrepayment + otherincomes + passledgerform).ToString();
                    cashoutflow.Text = (expenses + issuedloans + withdraws).ToString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                   
                    int AmmoutnIssued = 0;
                    string ct2 = "select TotalTransfered from CashierFunds where  TransferTo='" + staffname.Text + "' and Date='" + date2.Text + "'";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        string Accbalance = rdr2["TotalTransfered"].ToString();
                        AmmoutnIssued = Convert.ToInt32(Accbalance);

                        int cashreturn = (Convert.ToInt32(cashinflow.Text) + AmmoutnIssued) - Convert.ToInt32(cashoutflow.Text);
                        int returndifference = Convert.ToInt32(transactionammount.Text) - cashreturn;
                        if (returndifference < 0)
                        {
                            MessageBox.Show("The Ammount to be returned is " + cashreturn.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update CashierFunds  Set CashierReturn=@d9,CashierInFlow=@d8,CashInBox=@d10,CashierOutFlow=@d7 where TransferTo='" + staffname.Text + "' and Date='" + date2.Text + "'";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "CashierOutFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CashierInFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "CashierReturn"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "CashInBox"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = accountbalances;
                        cmd.Parameters["@d7"].Value = cashoutflow.Text;
                        cmd.Parameters["@d8"].Value = cashinflow.Text;
                        cmd.Parameters["@d9"].Value = transactionammount.Text;
                        cmd.Parameters["@d10"].Value = safebalance.Text;
                        cmd.Parameters["@d11"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into CashierFunds(TransferID,TransferTo,Year,Months,Date,TotalTransfered,CashierOutFlow,CashierInFlow,CashierReturn,CashInBox,ManagerName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "TransferTo"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "TotalTransfered"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "CashierOutFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "CashierInFlow"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "CashierReturn"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 20, "CashInBox"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "ManagerName"));

                        cmd.Parameters["@d1"].Value = transferid.Text;
                        cmd.Parameters["@d2"].Value = staffname.Text;
                        cmd.Parameters["@d3"].Value = year.Text;
                        cmd.Parameters["@d4"].Value = months2.Text;
                        cmd.Parameters["@d5"].Value = date2.Text;
                        cmd.Parameters["@d6"].Value = transactionammount.Text;
                        cmd.Parameters["@d7"].Value = 0;
                        cmd.Parameters["@d8"].Value = 0;
                        cmd.Parameters["@d9"].Value = 0;
                        cmd.Parameters["@d10"].Value = safebalance.Text;
                        cmd.Parameters["@d11"].Value = managername.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmCashierSafe frm = new frmCashierSafe();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
             if (transferid.Text == "")
            {
                MessageBox.Show("Please enter Savings ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transferid.Focus();
                return;
            }
            try
            {
                if (label2.Text == "Manager")
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete  from  CashierFunds where TransferID=@DELETE1;";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                    cmd.Parameters["@DELETE1"].Value = transferid.Text;
                    cmd.ExecuteNonQuery();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq1 = "delete  from  CashierFundsInstallments where TransferID=@DELETE1;";
                    cmd = new SqlCommand(cq1);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "TransferID"));
                    cmd.Parameters["@DELETE1"].Value = transferid.Text;
                    RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataload();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int ammounts = 0;
        int balances = 0;
        private void withdrawammount_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (transactionammount.Text == "") {
                
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        int.TryParse(transactionammount.Text, out ammounts);
                        int.TryParse(label3.Text,out balances);
                        int latestbalance = (balances - ammounts);
                        safebalance.Text = latestbalance.ToString();
                    }
                    else if (radioButton2.Checked)
                    {
                        int.TryParse(transactionammount.Text, out ammounts);
                        int.TryParse(label3.Text, out balances);
                        int latestbalance = (balances+ammounts);
                        safebalance.Text = latestbalance.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (radioButton1.Checked)
            {
                
                    int val7 = 0;
                    int.TryParse(safebalance.Text, out val7);
                    int realvalue = val7;
                    if (realvalue < 0)
                    {
                        MessageBox.Show("You cant give out more than you have in safe " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                        frmCashierSafe frm = new frmCashierSafe();
                        frm.label1.Text = label1.Text;
                        frm.label2.Text = label2.Text;
                        frm.Show();

                    }
                    if (transactionammount.Text == "")
                    {
                        transactionammount.Focus();
                        return;
                    }
            }
            
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds where Date between @date1 and @date2 order by ID DESC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = Datefrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = Dateto.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void memberid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                membername1.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(TransferTo) FROM CashierFunds where TransferID='" + memberid1.Text + "'";
                rdr = cmd.ExecuteReader();
                membername1.Text = "";
                if (rdr.Read())
                {
                    membername1.Text = rdr.GetString(0).Trim();
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds where TransferID='" + memberid1.Text + "'  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            memberid1.Text = "";
            membername1.Text = "";
            Datefrom.Text = DateTime.Today.ToString();
            Dateto.Text = DateTime.Today.ToString();
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void memberid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                membername2.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct RTRIM(StaffName) FROM Employee where StaffID='" + memberid2.Text + "'";
                rdr = cmd.ExecuteReader();
                membername2.Text = "";
                if (rdr.Read())
                {
                    membername2.Text = rdr.GetString(0).Trim();
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
            try
            {
                transactionid.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(TransferID) FROM CashierFunds where TransferTo='" + membername2.Text + "'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                transactionid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    transactionid.Items.Add(drow[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds where TransferTo='" + membername2.Text + "'  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds where TransferTo='" + membername2.Text + "'  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            memberid2.Text = "";
            membername2.Text = "";
            transactionid.Text = "";
            try
            {
               
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(TransferID)[Transaction ID], RTRIM(TransferTo)[Issued To], RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(TotalTransfered)[Total Transfered],RTRIM(CashierOutFlow)[Cash Outflow],RTRIM(CashierInFlow)[Cash In Flow],RTRIM(CashierReturn)[Money Returned],RTRIM(CashInBox)[CashInBox],RTRIM(ReceiverApproval)[Approval] from CashierFunds where TransferID='" +transactionid.Text + "'  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashierFunds");
                dataGridViewX1.DataSource = myDataSet.Tables["CashierFunds"].DefaultView;
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
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result + "'";
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

        private void staffid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked) {
                try
                {
                    staffname.Text = "";
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT distinct RTRIM(StaffName) FROM Employee where StaffID='" + staffid.Text + "'";
                    rdr = cmd.ExecuteReader();
                    staffname.Text = "";
                    if (rdr.Read())
                    {
                        staffname.Text = rdr.GetString(0).Trim();
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
            else
            {
                MessageBox.Show("First check whether your Issueing or Returning", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            if (radioButton2.Checked){
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select Deposit from Savings where Date ='" + date2.Text + "'and Transactions ='Withdraw ' and CashierName='" + staffname.Text + "'", con);
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
                            cmd = new SqlCommand("select SUM(Deposit) from Savings where Date='" + date2.Text + "' and Transactions ='Withdraw ' and CashierName='" + staffname.Text + "'", con);
                            withdraws = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            withdraws = 0;
                        }
                    con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select TotalPaid from Expenses where  Date='" + date2.Text + "' and CashierID='" + staffname.Text + "' ", con);
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
                            cmd = new SqlCommand("select SUM(TotalPaid) from Expenses where  Date='" + date2.Text + "' and CashierID='" + staffname.Text + "'", con);
                            expenses = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            expenses = 0;
                        }
                    con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                  
                   
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select AmmountPaid from LoanRepayment where Repaymentdate='" + date2.Text + "'and CashierName='" + staffname.Text + "'", con);
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
                            cmd = new SqlCommand("select SUM(AmmountPaid) from Loanrepayment where Repaymentdate='" + date2.Text + "'and CashierName='" + staffname.Text + "'", con);
                            loanrepayment = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            loanrepayment = 0;
                        }
                    con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select OtherFee from OtherIncomes where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "' ", con);
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
                            cmd = new SqlCommand("select SUM(OtherFee) from OtherIncomes where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "'", con);
                            otherincomes = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            otherincomes = 0;
                        }
                    con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                 
                    //savings
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select Deposit from Savings where Date='" + date2.Text + "'and Transactions ='Deposit' and CashierName='" + staffname.Text + "' order by ID DESC", con);
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
                            cmd = new SqlCommand("select SUM(Deposit) from Savings where Date='" + date2.Text + "'and Transactions ='Deposit' and CashierName='" + staffname.Text + "'", con);
                            savings = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            savings = 0;
                        }
                    con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Savings  sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                   try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select DepositedAmmount from ShareCapital where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "' ", con);
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
                            cmd = new SqlCommand("select SUM(DepositedAmmount) from ShareCapital where Date='" + date2.Text + "' and  DepositedAmmount !='' and CashierName='" + staffname.Text + "'", con);
                            sharecapital = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            sharecapital = 0;
                        }
                    con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Share capital sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select RegistrationAmmount from RegistrationFees where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "'", con);
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
                            cmd = new SqlCommand("select SUM(RegistrationAmmount) from RegistrationFees where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "'", con);
                            registration = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            registration = 0;
                        }
                    con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Registration fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select GrantFee from GrantFees where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "' ", con);
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
                            cmd = new SqlCommand("select SUM(GrantFee) from GrantFees where Date='" + date2.Text + "' and CashierName='" + staffname.Text + "'", con);
                            grantfees = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        }
                        else
                        {
                            grantfees = 0;
                        }
                    con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Grant fees sum failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cashinflow.Text = (savings + fines + grantfees + sharecapital + registration + loanprocessingfees + annualfeespayment + loaninsurance + loanrepayment + otherincomes + passledgerform).ToString();
                    cashoutflow.Text = (expenses + issuedloans + withdraws).ToString();
                
            
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
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

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            DataGridViewRow dr = dataGridViewX1.CurrentRow;
            frmCashierSafeApproval frm = new frmCashierSafeApproval();
            transferid.Text = dr.Cells[0].Value.ToString();
            frm.transferid.Text = dr.Cells[0].Value.ToString();
            frm.label1.Text= dr.Cells[1].Value.ToString();
            frm.ShowDialog();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
