using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Banking_System
{
    public partial class FrmInvestmentScheduleTrial : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public FrmInvestmentScheduleTrial()
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
        private void auto2()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from InvestorSavings where Date=@date1 Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from InvestorSavings where Date=@date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = date2.Value.Date;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string years = yearss.Substring(2, 2);
            if (investmentplan.Text == "Silver Extra")
            {
                savingsid.Text = "SE-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Premium")
            {
                savingsid.Text = "P-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Premium Extra")
            {
                savingsid.Text = "PE-" + years + monthss + days + realid;
            }
            else if (investmentplan.Text == "Silver")
            {
                savingsid.Text = "S-" + years + monthss + days + realid;
            }
            con.Close();
        }
        private void frmSavings_Load(object sender, EventArgs e)
        {

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
                    companyaddress = rdr.GetString(7).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {

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
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  InvestmentScheduleTrial  ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            FrmInvestmentScheduleTrial frm = new FrmInvestmentScheduleTrial();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
       
        private void buttonX5_Click(object sender, EventArgs e)
        {
  
            if (depositammount.Text == "")
            {
                MessageBox.Show("Please enter Deposited ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositammount.Focus();
                return;
            }
            if (IntrestRate.Text == "")
            {
                MessageBox.Show("Please Enter Interest Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IntrestRate.Focus();
                return;
            }
            if (MaturityPeriod.Text == "")
            {
                MessageBox.Show("Please Enter Investment Maturity Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaturityPeriod.Focus();
                return;
            }
            if (depositinterval.Text == "")
            {
                MessageBox.Show("Please Select Deposit Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depositinterval.Focus();
                return;
            }
            auto2();
            try
            {
                string investmentid = savingsid.Text;
                int ammountpay = depositammount.Value;
                double Intrestearned = ((Convert.ToDouble(IntrestRate.Text) / 100) / 12) * depositammount.Value;
                if (depositinterval.Text.ToString().Trim() == "One Off")
                {
                    double cumulation = Intrestearned * MaturityPeriod.Value;
                    string installmentno = "Installment 1";
                    string appreciationDatess = null;
                    DateTime startdatess = DateTime.Parse(date2.Text).Date;
                    appreciationDatess = (startdatess.AddMonths(MaturityPeriod.Value)).ToShortDateString();
                    DateTime dtss = DateTime.Parse(appreciationDatess);
                    string maturitydates = dtss.ToString("dd/MMM/yyyy");

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cbs = "insert into InvestmentScheduleTrial(InvestmentID,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                    cmd = new SqlCommand(cbs);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Cumulation"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                    cmd.Parameters["@d1"].Value = savingsid.Text;
                    cmd.Parameters["@d2"].Value = installmentno;
                    cmd.Parameters["@d3"].Value = maturitydates;
                    cmd.Parameters["@d4"].Value = ammountpay;
                    cmd.Parameters["@d5"].Value = Intrestearned;
                    cmd.Parameters["@d6"].Value = cumulation;
                    cmd.Parameters["@d7"].Value = MaturityPeriod.Value;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    for (int i = 1; i <= (Convert.ToInt32(MaturityPeriod.Text)); i++)
                    {
                        string installmentno = null;
                        double cumulation = 0.00;
                        string maturitydates = null;
                        int leftmonths = 0;
                        if (i == 1)
                        {
                            cumulation = Intrestearned * MaturityPeriod.Value;
                            installmentno = "Installment 1";
                            string appreciationDatess = null;
                            leftmonths = MaturityPeriod.Value;
                            DateTime startdatess = DateTime.Parse(date2.Text).Date;
                            appreciationDatess = (startdatess.AddMonths(0)).ToShortDateString();
                            DateTime dtss = DateTime.Parse(appreciationDatess);
                            maturitydates = dtss.ToString("dd/MMM/yyyy");
                        }
                        else
                        {
                            leftmonths = MaturityPeriod.Value - (i - 1);
                            cumulation = Intrestearned * leftmonths;
                            installmentno = "Installment " + i;
                            string appreciationDatess = null;
                            DateTime startdatess = DateTime.Parse(date2.Text).Date;
                            appreciationDatess = (startdatess.AddMonths(i - 1)).ToShortDateString();
                            DateTime dtss = DateTime.Parse(appreciationDatess);
                            maturitydates = dtss.ToString("dd/MMM/yyyy");
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cbs = "insert into InvestmentScheduleTrial(InvestmentID,Months,PaymentDate,AmmountPay,InterestEarned,Cumulation,AccrualMonths) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                        cmd = new SqlCommand(cbs);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "InvestmentID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "InterestEarned"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Cumulation"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 20, "AccrualMonths"));
                        cmd.Parameters["@d1"].Value = savingsid.Text;
                        cmd.Parameters["@d2"].Value = installmentno;
                        cmd.Parameters["@d3"].Value = maturitydates;
                        cmd.Parameters["@d4"].Value = ammountpay;
                        cmd.Parameters["@d5"].Value = Intrestearned;
                        cmd.Parameters["@d6"].Value = cumulation;
                        cmd.Parameters["@d7"].Value = leftmonths;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                company();
                try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    //timer1.Enabled = true;
                    RptInvestmentScheduleTrial rpt = new RptInvestmentScheduleTrial(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); //The DataSet you created.
                    FrmInvestmentTrial frm = new FrmInvestmentTrial();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from InvestmentScheduleTrial where InvestmentID='" + savingsid.Text + "'";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "InvestmentScheduleTrial");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    myConnection.Close();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  InvestmentScheduleTrial  ";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            FrmInvestmentScheduleTrial frm2 = new FrmInvestmentScheduleTrial();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {

        }

        private void frmSavings_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* this.Hide();
             frmMainMenu frm = new frmMainMenu();
             frm.User.Text = label1.Text;
             frm.UserType.Text = label2.Text;
             frm.Show();*/
        }
        
        private void depositammount_ValueChanged(object sender, EventArgs e)
        {
            groupPanel3.Enabled = true;
        }
      
        private void depositammount_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (depositammount.Text == "") { }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    int val4 = 0;
                    int val5 = 0;
                    string ct2 = "select Accountbalance from InvestorSavings where SavingsID= '" + savingsid.Text + "' order by ID Desc";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {
                        string Accbalance = rdr2["Accountbalance"].ToString();
                        val4 = Convert.ToInt32(Accbalance);
                        int.TryParse(depositammount.Value.ToString(), out val5);
                        accountbalance.Value = (val4 + val5);
                        if ((rdr2 != null))
                        {
                            rdr2.Close();
                        }
                    }
                    else
                    {
                        int val1 = 0;
                        int.TryParse(depositammount.Value.ToString(), out val1);
                        accountbalance.Value = val1;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        private void MaturityPeriod_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (MaturityPeriod.Text == " ")
                {
                    return;
                }
                else
                {
                    DateTime target = DateTime.Parse(date2.Text.ToString()).Date;
                    target = target.AddMonths(MaturityPeriod.Value);
                    maturitydate.Text = target.ToString("dd/MMM/yyyy");
                }
            }
            catch (Exception)
            {
                MaturityPeriod.Text = "";
            }
        }

        private void savingsid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select * from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    depositammount.Value = Convert.ToInt32(rdr["Deposit"]);
                    investmentplan.Text = rdr["InvestmentPlan"].ToString();
                    IntrestRate.Text = rdr["InterestRate"].ToString();
                    //accountbalance.Text = rdr["AccountBalance"].ToString();
                    MaturityPeriod.Text = rdr["MaturityPeriod"].ToString();
                    depositinterval.Text= rdr["DepositInterval"].ToString();
                    maturitydate.Text = rdr["OtherMaturityDate"].ToString();
                  
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void Depositid_TextChanged(object sender, EventArgs e)
        {

        }

        private void savingsid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select * from InvestorSavings where SavingsID='" + savingsid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    depositammount.Value = Convert.ToInt32(rdr["Deposit"]);
                    investmentplan.Text = rdr["InvestmentPlan"].ToString();
                    IntrestRate.Text = rdr["InterestRate"].ToString();
                    //accountbalance.Text = rdr["AccountBalance"].ToString();
                    MaturityPeriod.Text = rdr["MaturityPeriod"].ToString();
                    depositinterval.Text = rdr["DepositInterval"].ToString();
                    maturitydate.Text = rdr["OtherMaturityDate"].ToString();
                   
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
