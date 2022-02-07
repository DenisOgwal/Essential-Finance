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
            cmd = new SqlCommand("select ID from InvestmentAppreciation where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestmentAppreciation where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dateTimePicker1.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string years = yearss.Substring(2, 2);
            savingsid = years + monthss + days + realid;
        }
       
        public void dataload()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(SavingsID)[Savings ID],RTRIM(AccountNo)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Deposit)[Deposit], RTRIM(InterestRate)[Interest Rate] ,RTRIM(AppreciationNo)[Appreciation No.],RTRIM(NextAppreciationDate)[Appreciation Date.],RTRIM(Interval)[Interval], RTRIM(ID)[Record ID] from InvestmentAppreciation where Appreciated='No' and PaidOut='Pending' and NextAppreciationDate <=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "NextAppreciationDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestmentAppreciation");
                dataGridView1.DataSource = myDataSet.Tables["InvestmentAppreciation"].DefaultView;
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
                          
                            string ct2 = "select Accountbalance,ID from InvestorSavings where  AccountNo= '" + row.Cells[1].Value + "' and SavingsID='" + row.Cells[0].Value + "' order by ID Desc";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr2 = cmd.ExecuteReader();
                            if (rdr2.Read())
                            {
                                string ids = rdr2["ID"].ToString();
                                string Accbalance = rdr2["Accountbalance"].ToString();
                                val4 = Convert.ToInt32(Accbalance);
                                double intrests = 0.00;
                                if (row.Cells[3].Value.ToString().Trim() == "One Off") {
                                    intrests = (Convert.ToDouble(row.Cells[4].Value) / 100) / 12;
                                }
                                else
                                {
                                    intrests = Convert.ToDouble(row.Cells[4].Value) / 100;
                                }
                                val5 = Convert.ToInt32(row.Cells[3].Value) * (intrests);
                                val6 = val4 + Convert.ToInt32(val5);

                                string nextappreciation = null;
                                DateTime startdates = DateTime.Parse(dateTimePicker1.Text).Date;
                                nextappreciation = (startdates.AddMonths(1)).ToShortDateString();
                                DateTime dts = DateTime.Parse(nextappreciation);
                                string nextConvertedappreciationDate = dts.ToString("dd/MMM/yyyy");

                                int newappreciationno = Convert.ToInt32(row.Cells[5].Value) - 1;

                                string nextappreciationss = null;
                                DateTime startdatesss = DateTime.Parse(dateTimePicker1.Text).Date;
                                nextappreciationss = (startdatesss.AddMonths(newappreciationno)).ToShortDateString();
                                DateTime dtsss = DateTime.Parse(nextappreciationss);
                                string nextConvertedappreciationDatess = dtsss.ToString("dd/MMM/yyyy");
                                if (newappreciationno < 0)
                                {
                                }
                                else
                                {
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "insert into InvestmentAppreciation(SavingsID,DepositID,AccountNo,AccountName,Date,Deposit,Accountbalance,InterestRate,NextAppreciationDate,AppreciationNo,AppreciationAmount,Interval,Approved,ApprovedBy,Credit) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,'" + row.Cells[7].Value + "','Approved','Auto','CR')";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "DepositID"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "AccountName"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "Deposit"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Accountbalance"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 12, "InterestRate"));
                                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "NextAppreciationDate"));
                                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 5, "AppreciationNo"));
                                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "AppreciationAmount"));

                                    cmd.Parameters["@d1"].Value = row.Cells[0].Value;
                                    cmd.Parameters["@d2"].Value = savingsid;
                                    cmd.Parameters["@d3"].Value = row.Cells[1].Value;
                                    cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                                    cmd.Parameters["@d5"].Value = dateTimePicker1.Text.Trim();
                                    cmd.Parameters["@d6"].Value = row.Cells[3].Value;
                                    cmd.Parameters["@d7"].Value = val6;
                                    cmd.Parameters["@d8"].Value = row.Cells[4].Value;
                                    cmd.Parameters["@d9"].Value = nextConvertedappreciationDate;
                                    cmd.Parameters["@d10"].Value = newappreciationno;
                                    cmd.Parameters["@d11"].Value = val5;
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb10 = "UPDATE InvestmentAppreciation SET Appreciated=@d1 where ID='" + row.Cells[8].Value + "' ";
                                    cmd = new SqlCommand(cb10);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Appreciated"));
                                    cmd.Parameters["@d1"].Value = "Yes";
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb11 = "UPDATE InvestorSavings SET AccountBalance=@d1,OtherMaturityDate=@d2 where SavingsID='" + row.Cells[0].Value + "' ";
                                    cmd = new SqlCommand(cb11);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.Int, 10, "AccountBalance"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "OtherMaturityDate"));
                                    cmd.Parameters["@d1"].Value = val6;
                                    cmd.Parameters["@d2"].Value = nextappreciationss;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }

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
