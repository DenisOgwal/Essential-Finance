using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace Banking_System
{
    public partial class frmAccessRights : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmAccessRights()
        {
            InitializeComponent();
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
        private void frmReceiptReprint_Load(object sender, EventArgs e)
        {
            this.label3.Text = AssemblyCopyright;
            dataGridViewX2.DataSource = GetData();
        }

        private void buttonX24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
       
        public DataView GetData()
        {
            dataGridViewX2.DataSource = null;
            dynamic SelectQry = "select RTRIM(Username)[User Name],RTRIM(usertype)[UserType] from User_Registration order by Username ASC ";
                DataSet SampleSource = new DataSet();
                DataView TableView = null;
                try
                {
                    SqlCommand SampleCommand = new SqlCommand();
                    dynamic SampleDataAdapter = new SqlDataAdapter();
                    SampleCommand.CommandText = SelectQry;
                    SampleCommand.Connection = Connection;
                    SampleDataAdapter.SelectCommand = SampleCommand;
                    SampleDataAdapter.Fill(SampleSource);
                    TableView = SampleSource.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return TableView;
        }
        string settings, humanresurce,account, savings, loans,investment,inflows,outflows,pendings,safetransactions,expenses,financialsummary,additions,records,reports,deletes,updates = null;
        public void Checkboxes()
        {
            if (checkBoxItem1.Checked == true)
            {
                settings = "Yes";
            }
            else
            {
                settings = "No";
            }
            if (checkBoxItem2.Checked == true)
            {
                humanresurce = "Yes";
            }
            else
            {
                humanresurce = "No";
            }
            if (checkBoxItem3.Checked == true)
            {
                account = "Yes";
            }
            else
            {
                account = "No";
            }
            if (checkBoxItem4.Checked == true)
            {
                savings = "Yes";
            }
            else
            {
                savings = "No";
            }
            if (checkBoxItem5.Checked == true)
            {
                loans = "Yes";
            }
            else
            {
                loans = "No";
            }
            if (checkBoxItem6.Checked == true)
            {
                investment = "Yes";
            }
            else
            {
                investment = "No";
            }
            if (checkBoxItem7.Checked == true)
            {
                inflows = "Yes";
            }
            else
            {
                inflows = "No";
            }
            if (checkBoxItem8.Checked == true)
            {
                outflows = "Yes";
            }
            else
            {
                outflows = "No";
            }
            if (checkBoxItem9.Checked == true)
            {
                pendings = "Yes";
            }
            else
            {
                pendings = "No";
            }
            if (checkBoxItem10.Checked == true)
            {
                safetransactions = "Yes";
            }
            else
            {
                safetransactions = "No";
            }
            if (checkBoxItem11.Checked == true)
            {
                expenses = "Yes";
            }
            else
            {
                expenses = "No";
            }
            if (checkBoxItem12.Checked == true)
            {
                financialsummary = "Yes";
            }
            else
            {
                financialsummary = "No";
            }
            if (checkBoxItem13.Checked == true)
            {
                records = "Yes";
            }
            else
            {
                records = "No";
            }
            if (checkBoxItem14.Checked == true)
            {
                reports = "Yes";
            }
            else
            {
                reports = "No";
            }
            if (checkBoxItem15.Checked == true)
            {
                additions = "Yes";
            }
            else
            {
                additions = "No";
            }
            if (checkBoxItem16.Checked == true)
            {
                deletes = "Yes";
            }
            else
            {
                deletes = "No";
            }
            if (checkBoxItem17.Checked == true)
            {
                updates = "Yes";
            }
            else
            {
                updates = "No";
            }
        }
        private void buttonX23_Click(object sender, EventArgs e)
        {
            try
            {
                if (expandablePanel2.TitleText == "Rights")
                {
                    MessageBox.Show("Please First Select User","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                Checkboxes();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserName FROM UserAccess where UserName='"+expandablePanel2.TitleText+"' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update UserAccess set Settings=@d2,Humanresource=@d3,Account=@d4,Savings=@d5,Loans=@d7,Investments=@d8,Inflows=@d9,Outflows=@d10,Pendings=@d11,SafeTransactions=@d12,Expenses=@d13,FinancialSummary=@d14 ,Records=@d15,Reports=@d16,Additions=@d17,Deletes=@d18,Updates=@d19 where UserName=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Settings"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Humanresource"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Savings"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Loans"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "Investments"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "Inflows"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Outflows"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Pendings"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SafeTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "Expenses"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "FinancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "Records"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Reports"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "Additions"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = settings;
                    cmd.Parameters["@d3"].Value = humanresurce;
                    cmd.Parameters["@d4"].Value = account;
                    cmd.Parameters["@d5"].Value = savings;
                    cmd.Parameters["@d7"].Value = loans;
                    cmd.Parameters["@d8"].Value = investment;
                    cmd.Parameters["@d9"].Value = inflows;
                    cmd.Parameters["@d10"].Value = outflows;
                    cmd.Parameters["@d11"].Value = pendings;
                    cmd.Parameters["@d12"].Value = safetransactions;
                    cmd.Parameters["@d13"].Value = expenses;
                    cmd.Parameters["@d14"].Value = financialsummary;
                    cmd.Parameters["@d15"].Value = records;
                    cmd.Parameters["@d16"].Value = reports;
                    cmd.Parameters["@d17"].Value = additions;
                    cmd.Parameters["@d18"].Value = deletes;
                    cmd.Parameters["@d19"].Value =updates;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmAccessRights frm = new frmAccessRights();
                    frm.ShowDialog();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "Insert Into UserAccess (Username,Settings,Humanresource,Account,Savings,Loans,Investments,Inflows,Outflows,Pendings,SafeTransactions,Expenses,FinancialSummary,Records,Reports,Additions,Deletes,Updates) Values(@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Settings"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Humanresource"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Savings"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Loans"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "Investments"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "Inflows"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Outflows"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Pendings"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SafeTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "Expenses"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "FinancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "Records"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Reports"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "Additions"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = settings;
                    cmd.Parameters["@d3"].Value = humanresurce;
                    cmd.Parameters["@d4"].Value = account;
                    cmd.Parameters["@d5"].Value = savings;
                    cmd.Parameters["@d7"].Value = loans;
                    cmd.Parameters["@d8"].Value = investment;
                    cmd.Parameters["@d9"].Value = inflows;
                    cmd.Parameters["@d10"].Value = outflows;
                    cmd.Parameters["@d11"].Value = pendings;
                    cmd.Parameters["@d12"].Value = safetransactions;
                    cmd.Parameters["@d13"].Value = expenses;
                    cmd.Parameters["@d14"].Value = financialsummary;
                    cmd.Parameters["@d15"].Value = records;
                    cmd.Parameters["@d16"].Value = reports;
                    cmd.Parameters["@d17"].Value = additions;
                    cmd.Parameters["@d18"].Value = deletes;
                    cmd.Parameters["@d19"].Value = updates;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Saved", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmAccessRights frm = new frmAccessRights();
                    frm.ShowDialog();
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

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX2.CurrentRow;
                string clientnames = dr.Cells[0].Value.ToString();
                expandablePanel2.TitleText = clientnames;

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + expandablePanel2.TitleText + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    settings = rdr["Settings"].ToString().Trim();
                    humanresurce = rdr["Humanresource"].ToString().Trim();
                    account = rdr["Account"].ToString().Trim();
                    savings = rdr["Savings"].ToString().Trim();
                    loans = rdr["Loans"].ToString().Trim();
                    investment = rdr["Investments"].ToString().Trim();
                    inflows = rdr["Inflows"].ToString().Trim();
                    outflows = rdr["Outflows"].ToString().Trim();
                    pendings = rdr["Pendings"].ToString().Trim();
                    safetransactions = rdr["SafeTransactions"].ToString().Trim();
                    expenses = rdr["Expenses"].ToString().Trim();
                    financialsummary = rdr["FinancialSummary"].ToString().Trim();
                    additions = rdr["Additions"].ToString().Trim();
                    records = rdr["Records"].ToString().Trim();
                    reports = rdr["Reports"].ToString().Trim();
                    deletes = rdr["Deletes"].ToString().Trim();
                    updates = rdr["Updates"].ToString().Trim();
                    if (settings == "Yes") { checkBoxItem1.Checked = true; } else { checkBoxItem1.Checked = false; }
                    if (humanresurce == "Yes") { checkBoxItem2.Checked = true; } else { checkBoxItem2.Checked = false; }
                    if (account == "Yes") { checkBoxItem3.Checked = true; } else { checkBoxItem3.Checked = false; }
                    if (savings == "Yes") { checkBoxItem4.Checked = true; } else { checkBoxItem4.Checked = false; }
                    if (loans == "Yes") { checkBoxItem5.Checked = true; } else { checkBoxItem5.Checked = false; }
                    if (investment == "Yes") { checkBoxItem6.Checked = true; } else { checkBoxItem6.Checked = false; }
                    if (inflows == "Yes") { checkBoxItem7.Checked = true; } else { checkBoxItem7.Checked = false; }
                    if (outflows == "Yes") { checkBoxItem8.Checked = true; } else { checkBoxItem8.Checked = false; }
                    if (pendings == "Yes") { checkBoxItem9.Checked = true; } else { checkBoxItem9.Checked = false; }
                    if (safetransactions == "Yes") { checkBoxItem10.Checked = true; } else { checkBoxItem10.Checked = false; }
                    if (expenses == "Yes") { checkBoxItem11.Checked = true; } else { checkBoxItem11.Checked = false; }
                    if (financialsummary == "Yes") { checkBoxItem12.Checked = true; } else { checkBoxItem12.Checked = false; }
                    if (additions == "Yes") { checkBoxItem15.Checked = true; } else { checkBoxItem15.Checked = false; }
                    if (records == "Yes") { checkBoxItem13.Checked = true; } else { checkBoxItem13.Checked = false; }
                    if (reports == "Yes") { checkBoxItem14.Checked = true; } else { checkBoxItem14.Checked = false; }
                    if (deletes == "Yes") { checkBoxItem16.Checked = true; } else { checkBoxItem16.Checked = false; }
                    if (updates == "Yes") { checkBoxItem17.Checked = true; } else { checkBoxItem17.Checked = false; }
                }
                else
                {
                    checkBoxItem1.Checked = false; 
                    checkBoxItem2.Checked = false; 
                    checkBoxItem3.Checked = false; 
                    checkBoxItem4.Checked = false; 
                    checkBoxItem5.Checked = false; 
                    checkBoxItem6.Checked = false; 
                    checkBoxItem7.Checked = false; 
                    checkBoxItem8.Checked = false; 
                    checkBoxItem9.Checked = false; 
                    checkBoxItem10.Checked = false; 
                    checkBoxItem11.Checked = false; 
                    checkBoxItem12.Checked = false; 
                    checkBoxItem15.Checked = false; 
                    checkBoxItem13.Checked = false; 
                    checkBoxItem14.Checked = false; 
                    checkBoxItem16.Checked = false; 
                    checkBoxItem17.Checked = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
