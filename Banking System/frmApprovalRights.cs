using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace Banking_System
{
    public partial class frmApprovalRights : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmApprovalRights()
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
            dynamic SelectQry = "select RTRIM(StaffName)[StaffName],RTRIM(StaffID)[StaffID] from Rights order by StaffName ASC ";
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
        string incomesapproval, loansapproval,loansmanagerapproval,loansfinalaaproval, expensesapplication,expensesapproval,settingsapproval,managingdirector,createaccount,investorsavingsdeposit,investorsavingsapproval,investorwithdrawapproval1,investorwithdrawapproval2,writeoff1,writeoff2,accountants= null;
        string investment,loansettlement, loanissue, staffpayment, otherincomes, Dividends, loaninsurance, addfines, externalloans, externalRepayments, investorissue,loanprocessing = null;
        public void Checkboxes()
        {
            if (checkBoxItem1.Checked == true){incomesapproval = "Yes";}else{ incomesapproval = "No";}
            if (checkBoxItem2.Checked == true){loansapproval = "Yes";}else{loansapproval = "No";}
            if (checkBoxItem3.Checked == true){loansmanagerapproval = "Yes";}else{loansmanagerapproval = "No";}
            if (checkBoxItem4.Checked == true){loansfinalaaproval = "Yes";}else{loansfinalaaproval = "No";}
            if (checkBoxItem5.Checked == true){ expensesapproval = "Yes";}else{expensesapproval = "No";}
            if (checkBoxItem6.Checked == true){ expensesapplication = "Yes";}else{expensesapplication = "No";}
            if (checkBoxItem7.Checked == true){ settingsapproval = "Yes";}else{settingsapproval = "No";}
            if (checkBoxItem8.Checked == true){createaccount = "Yes";}else {createaccount = "No";}
            if (checkBoxItem9.Checked == true){managingdirector= "Yes";}else{managingdirector = "No";}
            if (checkBoxItem10.Checked == true) { investorsavingsdeposit = "Yes"; } else { investorsavingsdeposit = "No"; }
            if (checkBoxItem11.Checked == true) { investorsavingsapproval = "Yes"; } else { investorsavingsapproval = "No"; }
            if (checkBoxItem12.Checked == true) { investorwithdrawapproval1 = "Yes"; } else { investorwithdrawapproval1 = "No"; }
            if (checkBoxItem13.Checked == true) { investorwithdrawapproval2 = "Yes"; } else { investorwithdrawapproval2 = "No"; }
            if (checkBoxItem14.Checked == true) { writeoff1 = "Yes"; } else { writeoff1 = "No"; }
            if (checkBoxItem15.Checked == true) { writeoff2 = "Yes"; } else { writeoff2 = "No"; }
            if (checkBoxItem16.Checked == true) { accountants = "Yes"; } else { accountants = "No"; }

            if (checkBoxItem17.Checked == true) { loansettlement = "Yes"; } else { loansettlement = "No"; }
            if (checkBoxItem18.Checked == true) { loanissue = "Yes"; } else { loanissue = "No"; }
            if (checkBoxItem19.Checked == true) { staffpayment = "Yes"; } else { staffpayment = "No"; }
            if (checkBoxItem20.Checked == true) { otherincomes = "Yes"; } else { otherincomes = "No"; }
            if (checkBoxItem21.Checked == true) { Dividends = "Yes"; } else { Dividends = "No"; }
            if (checkBoxItem22.Checked == true) { loaninsurance = "Yes"; } else { loaninsurance = "No"; }
            if (checkBoxItem23.Checked == true) { addfines = "Yes"; } else { addfines = "No"; }
            if (checkBoxItem24.Checked == true) { externalloans = "Yes"; } else { externalloans = "No"; }
            if (checkBoxItem25.Checked == true) { externalRepayments = "Yes"; } else { externalRepayments = "No"; }
            if (checkBoxItem26.Checked == true) { investorissue = "Yes"; } else { investorissue = "No"; }
            if (checkBoxItem27.Checked == true) {loanprocessing = "Yes"; } else { loanprocessing = "No"; }
            if (checkBoxItem28.Checked == true) {investment = "Yes"; } else { investment = "No"; }

        }
        private void buttonX23_Click(object sender, EventArgs e)
        {
            try
            {
                if (expandablePanel2.TitleText == "Approval Rights")
                {
                    MessageBox.Show("Please First Select User","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                Checkboxes();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffID FROM ApprovalRights where StaffID='"+expandablePanel1.TitleText+"' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update ApprovalRights set Investments=@d29,LoanProcessing=@d28,InvestorIssue=@d27,ExternalRepayments=@d26,ExternalLoans=@d25,AddFines=@d24,LoanInsurance=@d23,Dividends=@d22,OtherIncomes=@d21,StaffPayment=@d20,LoanIssue=@d19,LoanSettlement=@d18,WriteOff2=@d17,WriteOff1=@d16,InvestorWithdrawApproval2=@d15,InvestorWithdrawApproval1=@d14,InvestorSavingsApproval=@d13,AccountantRights=@d12,InvestorDeposit=@d11,ManagingDirector=@d10,CreateAccount=@d9,SettingsApproval=@d8, ExpensesApproval=@d7,ExpensesApplication=@d6,LoansFinalApproval=@d5,LoansManagerApproval=@d4, LoansApplication=@d3, IncomesApproval=@d2  where StaffID =@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "StaffID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "IncomesApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "LoansApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "LoansManagerApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "LoansFinalApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "ExpensesApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "ExpensesApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "SettingsApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "CreateAccount"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "ManagingDirector"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "InvestorDeposit"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "AccountantRights"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "InvestorSavingsApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApproval1"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApproval2"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "WriteOff1"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "WriteOff2"));

                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "LoanSettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "LoanIssue"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "StaffPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "OtherIncomes"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "Dividends"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "LoanInsurance"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "AddFines"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "ExternalLoans"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "ExternalRepayments"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "InvestorIssue"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 10, "LoanProcessing"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "Investments"));
                    cmd.Parameters["@d1"].Value = expandablePanel1.TitleText;
                    cmd.Parameters["@d2"].Value = incomesapproval;
                    cmd.Parameters["@d3"].Value = loansapproval;
                    cmd.Parameters["@d4"].Value =loansmanagerapproval;
                    cmd.Parameters["@d5"].Value = loansfinalaaproval;
                    cmd.Parameters["@d6"].Value = expensesapplication;
                    cmd.Parameters["@d7"].Value = expensesapproval;
                    cmd.Parameters["@d8"].Value = settingsapproval;
                    cmd.Parameters["@d9"].Value = createaccount;
                    cmd.Parameters["@d10"].Value = managingdirector;
                    cmd.Parameters["@d11"].Value = investorsavingsdeposit;
                    cmd.Parameters["@d12"].Value = investorsavingsapproval;
                    cmd.Parameters["@d13"].Value = investorwithdrawapproval1;
                    cmd.Parameters["@d14"].Value = investorwithdrawapproval2;
                    cmd.Parameters["@d15"].Value = writeoff1;
                    cmd.Parameters["@d16"].Value = writeoff2;
                    cmd.Parameters["@d17"].Value = accountants;
                    cmd.Parameters["@d18"].Value = loansettlement;
                    cmd.Parameters["@d19"].Value = loanissue;
                    cmd.Parameters["@d20"].Value = staffpayment;
                    cmd.Parameters["@d21"].Value = otherincomes;
                    cmd.Parameters["@d22"].Value = Dividends;
                    cmd.Parameters["@d23"].Value = loaninsurance;
                    cmd.Parameters["@d24"].Value = addfines;
                    cmd.Parameters["@d25"].Value = externalloans;
                    cmd.Parameters["@d26"].Value =externalRepayments;
                    cmd.Parameters["@d27"].Value = investorissue;
                    cmd.Parameters["@d28"].Value = loanprocessing;
                    cmd.Parameters["@d29"].Value = investment;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully updated", "Rights Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmApprovalRights frm = new frmApprovalRights();
                    frm.ShowDialog();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "Insert Into ApprovalRights (StaffID,IncomesApproval,LoansApplication,LoansManagerApproval,LoansFinalApproval,ExpensesApplication,ExpensesApproval,SettingsApproval,CreateAccount,ManagingDirector,InvestorDeposit,AccountantRights,InvestorSavingsApproval,InvestorWithdrawApproval1,InvestorWithdrawApproval2,WriteOff1,WriteOff2,UserName,LoanSettlement,LoanIssue,StaffPayment,OtherIncomes,Dividends,LoanInsurance,AddFines,ExternalLoans,ExternalRepayments,InvestorIssue,LoanProcessing,Investments) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d28,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d29,@d30)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "StaffID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "IncomesApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "LoansApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "LoansManagerApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "LoansFinalApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "ExpensesApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "ExpensesApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "SettingsApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "CreateAccount"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "ManagingDirector"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "InvestorDeposit"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "AccountantRights"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "InvestorSavingsApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApproval1"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApproval2"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "WriteOff1"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "WriteOff2"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "LoanSettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "LoanIssue"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "StaffPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "OtherIncomes"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "Dividends"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "LoanInsurance"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "AddFines"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "ExternalLoans"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "ExternalRepayments"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "InvestorIssue"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "LoanProcessing"));
                    cmd.Parameters.Add(new SqlParameter("@d30", System.Data.SqlDbType.NChar, 10, "Investments"));
                    cmd.Parameters["@d1"].Value = expandablePanel1.TitleText;
                    cmd.Parameters["@d2"].Value = incomesapproval;
                    cmd.Parameters["@d3"].Value = loansapproval;
                    cmd.Parameters["@d4"].Value = loansmanagerapproval;
                    cmd.Parameters["@d5"].Value = loansfinalaaproval;
                    cmd.Parameters["@d6"].Value = expensesapplication;
                    cmd.Parameters["@d7"].Value = expensesapproval;
                    cmd.Parameters["@d8"].Value = settingsapproval;
                    cmd.Parameters["@d9"].Value = createaccount;
                    cmd.Parameters["@d10"].Value = managingdirector;
                    cmd.Parameters["@d11"].Value = investorsavingsdeposit;
                    cmd.Parameters["@d12"].Value = investorsavingsapproval;
                    cmd.Parameters["@d13"].Value = investorwithdrawapproval1;
                    cmd.Parameters["@d14"].Value = investorwithdrawapproval2;
                    cmd.Parameters["@d15"].Value = writeoff1;
                    cmd.Parameters["@d16"].Value = writeoff2;
                    cmd.Parameters["@d17"].Value = accountants;
                    cmd.Parameters["@d18"].Value = loansettlement;
                    cmd.Parameters["@d19"].Value = loanissue;
                    cmd.Parameters["@d20"].Value = staffpayment;
                    cmd.Parameters["@d21"].Value = otherincomes;
                    cmd.Parameters["@d22"].Value = Dividends;
                    cmd.Parameters["@d23"].Value = loaninsurance;
                    cmd.Parameters["@d24"].Value = addfines;
                    cmd.Parameters["@d25"].Value = externalloans;
                    cmd.Parameters["@d26"].Value = externalRepayments;
                    cmd.Parameters["@d27"].Value = investorissue;
                    cmd.Parameters["@d28"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d29"].Value = loanprocessing;
                    cmd.Parameters["@d30"].Value = investment;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Saved", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmApprovalRights frm = new frmApprovalRights();
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
                expandablePanel1.TitleText = dr.Cells[1].Value.ToString();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM ApprovalRights where StaffID='" + expandablePanel1.TitleText + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   incomesapproval = rdr["IncomesApproval"].ToString().Trim();
                    loansapproval = rdr["LoansApplication"].ToString().Trim();
                    loansmanagerapproval = rdr["LoansManagerApproval"].ToString().Trim();
                    loansfinalaaproval = rdr["LoansFinalApproval"].ToString().Trim();
                    expensesapplication = rdr["ExpensesApplication"].ToString().Trim();
                    expensesapproval = rdr["ExpensesApproval"].ToString().Trim();
                    settingsapproval = rdr["SettingsApproval"].ToString().Trim();
                    createaccount = rdr["CreateAccount"].ToString().Trim();
                    managingdirector = rdr["ManagingDirector"].ToString().Trim();
                    investorsavingsdeposit = rdr["InvestorDeposit"].ToString().Trim();
                    investorsavingsapproval = rdr["InvestorSavingsApproval"].ToString().Trim();
                    investorwithdrawapproval1 = rdr["InvestorWithdrawApproval1"].ToString().Trim();
                    investorwithdrawapproval2 = rdr["InvestorWithdrawApproval2"].ToString().Trim();
                    writeoff1 = rdr["WriteOff1"].ToString().Trim();
                    writeoff2 = rdr["WriteOff2"].ToString().Trim();
                    accountants = rdr["AccountantRights"].ToString().Trim();

                    loansettlement = rdr["LoanSettlement"].ToString().Trim();
                    loanissue = rdr["LoanIssue"].ToString().Trim();
                    staffpayment = rdr["StaffPayment"].ToString().Trim();
                    otherincomes = rdr["OtherIncomes"].ToString().Trim();
                    Dividends = rdr["Dividends"].ToString().Trim();
                    loaninsurance = rdr["LoanInsurance"].ToString().Trim();
                    addfines = rdr["AddFines"].ToString().Trim();
                    externalloans = rdr["ExternalLoans"].ToString().Trim();
                    externalRepayments = rdr["ExternalRepayments"].ToString().Trim();
                    investorissue = rdr["InvestorIssue"].ToString().Trim();
                    loanprocessing = rdr["LoanProcessing"].ToString().Trim();
                    investment = rdr["Investments"].ToString().Trim();
                    if (incomesapproval == "Yes") { checkBoxItem1.Checked = true; } else { checkBoxItem1.Checked = false; }
                    if (loansapproval == "Yes") { checkBoxItem2.Checked = true; } else { checkBoxItem2.Checked = false; }
                    if (loansmanagerapproval == "Yes") { checkBoxItem3.Checked = true; } else { checkBoxItem3.Checked = false; }
                    if (loansfinalaaproval == "Yes") { checkBoxItem4.Checked = true; } else { checkBoxItem4.Checked = false; }
                    if (expensesapplication == "Yes") { checkBoxItem5.Checked = true; } else { checkBoxItem5.Checked = false; }
                    if (expensesapproval == "Yes") { checkBoxItem6.Checked = true; } else { checkBoxItem6.Checked = false; }
                    if (settingsapproval == "Yes") { checkBoxItem7.Checked = true; } else { checkBoxItem7.Checked = false; }
                    if (createaccount == "Yes") { checkBoxItem8.Checked = true; } else { checkBoxItem8.Checked = false; }
                    if (managingdirector == "Yes") { checkBoxItem9.Checked = true; } else { checkBoxItem9.Checked = false; }
                    if (investorsavingsdeposit == "Yes") { checkBoxItem10.Checked = true; } else { checkBoxItem10.Checked = false; }
                    if (investorsavingsapproval == "Yes") { checkBoxItem11.Checked = true; } else { checkBoxItem11.Checked = false; }
                    if (investorwithdrawapproval1 == "Yes") { checkBoxItem12.Checked = true; } else { checkBoxItem12.Checked = false; }
                    if (investorwithdrawapproval2 == "Yes") { checkBoxItem13.Checked = true; } else { checkBoxItem13.Checked = false; }
                    if (writeoff1 == "Yes") { checkBoxItem14.Checked = true; } else { checkBoxItem14.Checked = false; }
                    if (writeoff2 == "Yes") { checkBoxItem15.Checked = true; } else { checkBoxItem15.Checked = false; }
                    if (accountants == "Yes") { checkBoxItem16.Checked = true; } else { checkBoxItem16.Checked = false; }

                    if (loansettlement == "Yes") { checkBoxItem17.Checked = true; } else { checkBoxItem17.Checked = false; }
                    if (loanissue == "Yes") { checkBoxItem18.Checked = true; } else { checkBoxItem18.Checked = false; }
                    if (staffpayment == "Yes") { checkBoxItem19.Checked = true; } else { checkBoxItem19.Checked = false; }
                    if (otherincomes == "Yes") { checkBoxItem20.Checked = true; } else { checkBoxItem20.Checked = false; }
                    if (Dividends == "Yes") { checkBoxItem21.Checked = true; } else { checkBoxItem21.Checked = false; }
                    if (loaninsurance == "Yes") { checkBoxItem22.Checked = true; } else { checkBoxItem22.Checked = false; }
                    if (addfines == "Yes") { checkBoxItem23.Checked = true; } else { checkBoxItem23.Checked = false; }
                    if (externalloans == "Yes") { checkBoxItem24.Checked = true; } else { checkBoxItem24.Checked = false; }
                    if (externalRepayments == "Yes") { checkBoxItem25.Checked = true; } else { checkBoxItem25.Checked = false; }
                    if (investorissue == "Yes") { checkBoxItem26.Checked = true; } else { checkBoxItem26.Checked = false; }
                    if (loanprocessing == "Yes") { checkBoxItem27.Checked = true; } else { checkBoxItem27.Checked = false; }
                    if (investment == "Yes") { checkBoxItem28.Checked = true; } else { checkBoxItem28.Checked = false; }
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
                    checkBoxItem13.Checked = false;
                    checkBoxItem14.Checked = false;
                    checkBoxItem15.Checked = false;
                    checkBoxItem16.Checked = false;

                    checkBoxItem17.Checked = false;
                    checkBoxItem18.Checked = false;
                    checkBoxItem19.Checked = false;
                    checkBoxItem20.Checked = false;
                    checkBoxItem21.Checked = false;
                    checkBoxItem22.Checked = false;
                    checkBoxItem23.Checked = false;
                    checkBoxItem24.Checked = false;
                    checkBoxItem25.Checked = false;
                    checkBoxItem26.Checked = false;
                    checkBoxItem27.Checked = false;
                    checkBoxItem28.Checked = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
