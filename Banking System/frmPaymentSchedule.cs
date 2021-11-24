using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Banking_System
{
    public partial class frmPaymentSchedule : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmPaymentSchedule()
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
        private void frmPaymentSchedule_Load(object sender, EventArgs e)
        {

            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {

                int days = 2;
                string autoloansoption = Properties.Settings.Default.autoloanfines;
                if (autoloansoption == "Automatic")
                {
                    days = Properties.Settings.Default.autoloandays;
                }
                DateTime schedule = DateTime.Parse(dateTimePicker1.Text).Date;
                string paymentdates = (schedule.AddDays(-days)).ToShortDateString();
                DateTime dt = DateTime.Parse(paymentdates);
                string repaymentdates = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Months)[Repayment Installment], (TotalAmmount)[Amount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status],RTRIM(Rates)[Rate],RTRIM(IntrestType)[Intrest Type],RTRIM(Accrued)[Accrued] from RepaymentSchedule where PaymentStatus='Pending' and PaymentDate < @date1 order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTime.Parse(repaymentdates).Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
                //dataGridViewX2.DefaultCellStyle.Format = "#.##0";
                //dataGridViewX2.Columns["Amount Payable"]. = "D";
                // dataGridViewX2.Columns["Amount Payable"].DefaultCellStyle.Format = "C";
                //dataGridViewX2.Columns["Principal"].DefaultCellStyle.Format = "N";

                //dataGridViewX2.Columns["Amount Payable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridViewX2.Columns["Principal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (autoloansoption == "Automatic")
                {
                    foreach (DataGridViewRow row in dataGridViewX2.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if ((row.Cells[0].Value) != null)
                            {

                                if (row.Cells[11].Value.ToString().Trim() == "Flat Rate" && row.Cells[12].Value.ToString().Trim() == "No")
                                {
                                    float creditperiod = 1;
                                    string repaymentmonths = row.Cells[3].Value.ToString();
                                    double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                    double realammount = Convert.ToDouble(row.Cells[4].Value);
                                    double principal = realammount / creditperiod;
                                    double interest = ((intrestrate / (100)) * principal);
                                    double repaymentammount = principal + interest;

                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "UPDATE RepaymentSchedule SET TotalAmmount=@d5,AmmountPay=@d6,Interest=@d7,BalanceExist=@d9,BeginningBalance=@d11,Accrued='Yes' where LoanID=@d1 and Months=@d3";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                                    cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString();
                                    cmd.Parameters["@d3"].Value = repaymentmonths;
                                    cmd.Parameters["@d5"].Value = repaymentammount;
                                    cmd.Parameters["@d6"].Value = principal;
                                    cmd.Parameters["@d7"].Value = interest;
                                    cmd.Parameters["@d9"].Value = repaymentammount;
                                    cmd.Parameters["@d11"].Value = repaymentammount;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                else if (row.Cells[11].Value.ToString().Trim() == "Reducing Balance" && row.Cells[12].Value.ToString().Trim() == "No")
                                {
                                    float creditperiod = 1;
                                    string repaymentmonths = row.Cells[3].Value.ToString();
                                    double intrestrate = Convert.ToDouble(row.Cells[10].Value);
                                    double realammount = Convert.ToDouble(row.Cells[4].Value);
                                    double principal = realammount / creditperiod;
                                    double interest = ((intrestrate / (100)) * principal);
                                    double repaymentammount = principal + interest;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "UPDATE RepaymentSchedule SET TotalAmmount=@d5,AmmountPay=@d6,Interest=@d7,BalanceExist=@d9 where LoanID=@d1 and Months=@d3";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                    cmd.Parameters["@d1"].Value = row.Cells[0].Value.ToString();
                                    cmd.Parameters["@d3"].Value = repaymentmonths;
                                    cmd.Parameters["@d5"].Value = repaymentammount;
                                    cmd.Parameters["@d6"].Value = principal;
                                    cmd.Parameters["@d7"].Value = interest;
                                    cmd.Parameters["@d9"].Value = repaymentammount;
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //dataGridViewX2.Columns("My Column").DefaultCellStyle.Format = "D"
        }

        private void frmPaymentSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPaymentSchedule frm = new frmPaymentSchedule();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmRepaymentForm frm = new frmRepaymentForm();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        public void loaddata()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Months)[Repayment Months], (TotalAmmount)[Ammount Payable],(AmmountPay)[Principal], (Interest)[Interest],(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from RepaymentSchedule where LoanID='" + loanid.Text + "' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridViewX1.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void memberid_TextChanged(object sender, EventArgs e)
        {
            //membername.Text = "";
            loaddata();
        }

        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Months)[Repayment Installment], RTRIM(TotalAmmount)[Ammount Payable],RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest],RTRIM(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from RepaymentSchedule where PaymentDate between @date1 and @date2 order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoanID)[Loan ID],RTRIM(AccountNumber)[Account Number], RTRIM(AccountName)[Account Name], RTRIM(Months)[Repayment Months], RTRIM(TotalAmmount)[Ammount Payable],RTRIM(AmmountPay)[Principal], RTRIM(Interest)[Interest],RTRIM(BalanceExist)[Balance Pending],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentStatus)[Payment Status] from RepaymentSchedule where PaymentDate between @date1 and @date2 order by ID ASC", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "RepaymentSchedule");
                dataGridViewX2.DataSource = myDataSet.Tables["RepaymentSchedule"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loanid_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            this.loanid.Text = frm.LoanID.Text;
            this.memberid.Text = frm.clientnames.Text;
            this.membername.Text = frm.Accountnames.Text;
            return;
        }

        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void dataGridViewX2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (label1.Text == "Admin" || label1.Text == "ADMIN")
                {
                    switch (dataGridViewX2.Columns[e.ColumnIndex].Index)
                    {
                        case 4:
                            DataGridViewRow dr = dataGridViewX2.CurrentRow;
                            DataGridViewCell dc = dataGridViewX2.CurrentCell;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();

                            string cb = "UPDATE RepaymentSchedule SET TotalAmmount=@d5,BalanceExist=@d9,BeginningBalance=@d11 where LoanID=@d1 and Months=@d3";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                            cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                            cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                            cmd.Parameters["@d1"].Value = dr.Cells[0].Value;
                            cmd.Parameters["@d3"].Value = dr.Cells[3].Value;
                            cmd.Parameters["@d5"].Value = dc.Value;
                            cmd.Parameters["@d9"].Value = dc.Value;
                            cmd.Parameters["@d11"].Value = dc.Value;
                            cmd.ExecuteNonQuery();
                            break;
                        case 5:
                            DataGridViewRow dr1 = dataGridViewX2.CurrentRow;
                            DataGridViewCell dc1 = dataGridViewX2.CurrentCell;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();

                            string cb1 = "UPDATE RepaymentSchedule SET AmmountPay=@d6 where LoanID=@d1 and Months=@d3";
                            cmd = new SqlCommand(cb1);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                            cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                            cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                            cmd.Parameters["@d1"].Value = dr1.Cells[0].Value;
                            cmd.Parameters["@d3"].Value = dr1.Cells[3].Value;
                            cmd.Parameters["@d5"].Value = dc1.Value;
                            cmd.Parameters["@d6"].Value = dc1.Value;
                            cmd.Parameters["@d7"].Value = dr1.Cells[6].Value;
                            cmd.Parameters["@d9"].Value = dc1.Value;
                            cmd.Parameters["@d11"].Value = dc1.Value;
                            cmd.ExecuteNonQuery();
                            break;

                        case 6:
                            DataGridViewRow dr2 = dataGridViewX2.CurrentRow;
                            DataGridViewCell dc2 = dataGridViewX2.CurrentCell;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();

                            string cb2 = "UPDATE RepaymentSchedule SET Interest=@d7 where LoanID=@d1 and Months=@d3";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                            cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                            cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                            cmd.Parameters["@d1"].Value = dr2.Cells[0].Value;
                            cmd.Parameters["@d3"].Value = dr2.Cells[3].Value;
                            cmd.Parameters["@d5"].Value = dc2.Value;
                            cmd.Parameters["@d6"].Value = dc2.Value;
                            cmd.Parameters["@d7"].Value = dc2.Value;
                            cmd.Parameters["@d9"].Value = dc2.Value;
                            cmd.Parameters["@d11"].Value = dc2.Value;
                            cmd.ExecuteNonQuery();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
