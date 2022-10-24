using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class frmmonthlydatagrid : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string daysss;
        public string monthsss;
        public string yearsss;
        string monthlychargeid = null;
        public frmmonthlydatagrid()
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
            monthlychargeid = "MMC-" + years + monthss + days;
        }
        public void dataload()
        {
            try
            {
                monthsss = DateTime.Today.Month.ToString();
                string formatmonths = DateTime.Now.ToString("MMM");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TOP (100) RTRIM(AccountNumber)[Account Number], RTRIM(AccountNames)[Account Names], RTRIM(ID)[Record ID] from Account where MonthlyDate !='" + formatmonths+ "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Account");
                dataGridView1.DataSource = myDataSet.Tables["Account"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }
        private void frmrecordsselection_Load(object sender, EventArgs e)
        {
            //dataload();
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            yearsss = DateTime.Today.Year.ToString();
            daysss = DateTime.Today.Day.ToString();
            monthsss = DateTime.Today.Month.ToString();
            string formatmonths = DateTime.Now.ToString("MMM");
            string formatday = null;
            if (daysss == "1")
            {
                formatday = "01";
            }
            else if (daysss == "2")
            {
                formatday = "02";
            }
            else if (daysss == "3")
            {
                formatday = "03";
            }
            else if (daysss == "4")
            {
                formatday = "04";
            }
            else if (daysss == "5")
            {
                formatday = "05";
            }
            else if (daysss == "6")
            {
                formatday = "06";
            }
            else if (daysss == "7")
            {
                formatday = "07";
            }
            else if (daysss == "8")
            {
                formatday = "08";
            }
            else if (daysss == "9")
            {
                formatday = "09";
            }
            else
            {
                formatday = daysss;
            }
            int monthlyfee = 0;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MonthlyFee FROM MonthlyFee order by ID Desc";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    monthlyfee = rdr.GetInt32(0);
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
                //accbalance.Text=null;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[0].Value) != null)
                        {


                            auto();
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            int val4 = 0;
                            int val5 = 0;
                            string ct2 = "select Accountbalance from Savings where  AccountNo= '" + row.Cells[0].Value + "' order by ID Desc";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr2 = cmd.ExecuteReader();
                            if (rdr2.Read())
                            {
                                string Accbalance = rdr2["Accountbalance"].ToString();
                                val4 = Convert.ToInt32(Accbalance);
                                val5 = val4 - monthlyfee;
                                con.Close();

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,Debit,DepositDate,Approval,ApprovedBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d5,'" + dateTimePicker1.Text + "','Approved','Auto')";
                                cmd = new SqlCommand(cb2);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "Transactions"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                                cmd.Parameters["@d1"].Value = row.Cells[0].Value;
                                cmd.Parameters["@d2"].Value = monthlychargeid + row.Cells[2].Value;
                                cmd.Parameters["@d3"].Value = "Auto";
                                cmd.Parameters["@d4"].Value = formatday + "/" + formatmonths + "/" + yearsss;
                                cmd.Parameters["@d5"].Value = monthlyfee; 
                                cmd.Parameters["@d6"].Value = val5;
                                cmd.Parameters["@d7"].Value = "Monthly Charge";
                                cmd.Parameters["@d8"].Value = "Transfer";
                                cmd.Parameters["@d9"].Value = row.Cells[2].Value.ToString().Trim();
                                cmd.Parameters["@d10"].Value = "Auto";
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb4 = "insert into MonthlyCharges(Account,AccountName,Date,MonthlyFee) VALUES (@d2,@d3,@d4,@d5)";
                                cmd = new SqlCommand(cb4);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Account"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "AccountName"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 10, "MonthlyFee"));
                                cmd.Parameters["@d2"].Value = row.Cells[0].Value;
                                cmd.Parameters["@d3"].Value = row.Cells[1].Value.ToString().Trim();
                                cmd.Parameters["@d4"].Value = formatday + "/" + formatmonths + "/" + yearsss;
                                cmd.Parameters["@d5"].Value = monthlyfee;
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb10 = "UPDATE Account SET MonthlyDate=@d1 where AccountNumber='" + row.Cells[0].Value+"' ";
                                cmd = new SqlCommand(cb10);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "MonthlyDate"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Charged"));

                                cmd.Parameters["@d1"].Value = formatmonths;
                                cmd.Parameters["@d2"].Value = "Yes";
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                    }

                }
                dataGridView1.DataSource = null;
                if (dataGridView1.DataSource == null)
                {
                    this.Hide();
                    FrmInvestorDebit frm = new FrmInvestorDebit();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void frmmonthlydatagrid_Shown(object sender, EventArgs e)
        {
            dataload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
