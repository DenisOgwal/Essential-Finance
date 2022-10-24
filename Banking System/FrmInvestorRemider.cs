using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
namespace Banking_System
{
    public partial class FrmInvestorRemider : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string day;
        public string month;
        public string year;
        public FrmInvestorRemider()
        {
            InitializeComponent();
        }
        string numberphone2 = null;
        string messages2 = null;
        public int dayss = 2;
        string repaymentdate=null;
        
        DateTime startdate = DateTime.Parse(DateTime.Today.ToShortDateString()).Date;
        public void dataload()
        {
            try
            {
                string repaymentdate1 = null;
                repaymentdate1 = (startdate.AddDays(dayss)).ToShortDateString();
                DateTime dt = DateTime.Parse(repaymentdate1);
                repaymentdate = dt.ToString("dd/MMM/yyyy");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Deposit)[Deposit],RTRIM(ContactNo)[Contact],RTRIM(AccountNumber)[AccountNumber] from InvestorAccount,InvestmentAppreciation where InvestorAccount.AccountNumber=InvestmentAppreciation.AccountNo and NextAppreciationDate='" + repaymentdate + "' and Interval !='One Off'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "InvestmentAppreciation");
                myDA.Fill(myDataSet, "InvestorAccount");
                dataGridView1.DataSource = myDataSet.Tables["InvestmentAppreciation"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["InvestorAccount"].DefaultView;
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
            string smsallows = Properties.Settings.Default.smsallow;
            if (smsallows == "Yes")
            {
                try
                {
                    //accbalance.Text=null;
                    using (var client3 = new WebClient())
                    using (client3.OpenRead("http://client3.google.com/generate_204"))
                    {
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your Not Connected to Internet, The Investor reminder messages were not sent");
                    dataGridView1.DataSource = null;
                    if (dataGridView1.DataSource == null)
                    {
                        this.Hide();
                        return;
                    }

                }
                try
                {
                    //accbalance.Text=null;
                    using (var client2 = new WebClient())
                    using (client2.OpenRead("http://client3.google.com/generate_204"))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                if ((row.Cells[0].Value) != null)
                                {
                                    string numbers2 = null;
                                    try
                                    {
                                        string repaymentdate1 = null;
                                        repaymentdate1 = (startdate.AddDays(dayss)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                        string sentdates = startdate.ToString("dd/MMM/yyyy");
                                        numberphone2 = row.Cells[1].Value.ToString();

                                        con = new SqlConnection(cs.DBConn);
                                        con.Open();
                                        string ct3 = "select MemberID from LoanMessageSent where  MemberID=@find and SentDate=@find2";
                                        cmd = new SqlCommand(ct3);
                                        cmd.Connection = con;
                                        cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, " MemberID"));
                                        cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NChar, 20, "SentDate"));
                                        cmd.Parameters["@find"].Value = row.Cells[3].Value;
                                        cmd.Parameters["@find2"].Value = sentdates;
                                        rdr = cmd.ExecuteReader();
                                        if (rdr.Read())
                                        {

                                        }
                                        else
                                        {
                                            string smsallow = Properties.Settings.Default.smsallow;
                                            if (smsallow == "Yes")
                                            {
                                                con = new SqlConnection(cs.DBConn);
                                                con.Open();
                                                string cb = "insert into LoanMessageSent(MemberID,SentDate) VALUES (@d1,@d2)";
                                                cmd = new SqlCommand(cb);
                                                cmd.Connection = con;
                                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "MemberID"));
                                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SentDate"));
                                                cmd.Parameters["@d1"].Value = row.Cells[3].Value;
                                                cmd.Parameters["@d2"].Value = sentdates;
                                                cmd.ExecuteNonQuery();
                                                con.Close();
                                                string smsheader = Properties.Settings.Default.Smscode;
                                                string inquiryphone = Properties.Settings.Default.phoneinquiry;
                                                string usernamess = Properties.Settings.Default.smsusername;
                                                string passwordss = Properties.Settings.Default.smspassword;
                                                numbers2 = "+256" + numberphone2;
                                                messages2 = "Please Your reminded to Deposit your monthly Investment plan Deposit of UGX. " + row.Cells[0].Value.ToString() + " Due on " + repaymentdate;
                                                messages2 = smsheader + ": We hereby remind you of your " + row.Cells[4].Value.ToString() + " loan repayment of UGX. " + row.Cells[0].Value.ToString() + " Due on " + repaymentdate + " Please endavour to make the payments through the Accouts we Provided. For Any Inquiries Call: " + inquiryphone;

                                                WebClient client = new WebClient();
                                                string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username=" + usernamess + "&password=" + passwordss + "&senderid=Geniussms&message=" + messages2 + "&numbers=" + numbers2;
                                                client.OpenRead(baseURL);
                                            }
                                        }
                                        con.Close();
                                    }
                                    catch (Exception exp)
                                    {
                                        MessageBox.Show(exp.ToString());
                                    }
                                }
                            }

                        }

                        dataGridView1.DataSource = null;
                        if (dataGridView1.DataSource == null)
                        {
                            this.Hide();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your Not Connected to Internet, The Investor reminder messages were not sent");
                    dataGridView1.DataSource = null;
                    if (dataGridView1.DataSource == null)
                    {
                        this.Hide();
                        return;
                    }

                }
            }
            else
            {
                this.Hide();
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void frmmonthlydatagrid_Shown(object sender, EventArgs e)
        {
            dataload();
        }

       
    }
}
