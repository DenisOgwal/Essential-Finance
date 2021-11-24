using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class FrmInvestorDebit : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string day;
        public string month;
        public string year;
        string savingsid = null;
        public FrmInvestorDebit()
        {
            InitializeComponent();
        }
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from InvestorSavings where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestorSavings where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string years = yearss.Substring(2, 2);
            savingsid = "I-" + years + monthss + days + realid;

        }
        public void dataload()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(AccountNo)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Deposit)[Deposit], RTRIM(InterestRate)[Interest Rate], RTRIM(ID)[Record ID] from InvestorSavings where Appreciated='No' and MaturityDate <=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "MaturityDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestorSavings");
                dataGridView1.DataSource = myDataSet.Tables["InvestorSavings"].DefaultView;
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
                            double val5 = 0.00;
                            int val6 = 0;
                            string ct2 = "select Accountbalance,ID from InvestorSavings where  AccountNo= '" + row.Cells[0].Value + "' order by ID Desc";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr2 = cmd.ExecuteReader();
                            if (rdr2.Read())
                            {
                                string ids = rdr2["ID"].ToString();
                                string Accbalance = rdr2["Accountbalance"].ToString();
                                val4 = Convert.ToInt32(Accbalance);
                                val5 = Convert.ToInt32(row.Cells[2].Value) * (Convert.ToDouble(row.Cells[3].Value) / 100);
                                val6 = val4 + Convert.ToInt32(val5);

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "insert into InvestorSavings(SavingsID,AccountNo,AccountName,CashierName,Date,Deposit,Accountbalance,SubmittedBy,Transactions,ModeOfPayment,InterestRate,MaturityPeriod,MaturityDate,Appreciated) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "CashierName"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "Transactions"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ModeOfPayment"));
                                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 20, "InterestRate"));
                                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 20, "MaturityPeriod"));
                                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "MaturityDate"));
                                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "Appreciated"));
                                cmd.Parameters["@d1"].Value = savingsid;
                                cmd.Parameters["@d2"].Value = row.Cells[0].Value;
                                cmd.Parameters["@d3"].Value = row.Cells[1].Value;
                                cmd.Parameters["@d4"].Value = "Auto";
                                cmd.Parameters["@d5"].Value = dateTimePicker1.Text.Trim();
                                cmd.Parameters["@d6"].Value = val5;
                                cmd.Parameters["@d7"].Value = val6;
                                cmd.Parameters["@d8"].Value = "Auto";
                                cmd.Parameters["@d9"].Value = "Appreciation";
                                cmd.Parameters["@d10"].Value = "Appreciation";
                                cmd.Parameters["@d11"].Value = 0;
                                cmd.Parameters["@d12"].Value = 0;
                                cmd.Parameters["@d13"].Value = dateTimePicker1.Text;
                                cmd.Parameters["@d14"].Value = "Yes";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb10 = "UPDATE InvestorSavings SET Appreciated=@d1 where ID='" + row.Cells[4].Value + "' ";
                                cmd = new SqlCommand(cb10);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Appreciated"));
                                cmd.Parameters["@d1"].Value = "Yes";
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
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmmonthlydatagrid_Shown(object sender, EventArgs e)
        {
            dataload();
        }


    }
}
