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
        string settings, humanresource,savingsaccount,savingsdeposit,investoraccountcreation,loanapplication,loanrecovery,loanwriteoff,Normalsettlement,earlysettlement,loanreschedule,loantopup,accountsrecord,savingsrecord,loansrecord,deletes,updates,externalborrowingrecords,investorrecords,inflowsrecords,outflowsrecords,HRrecords = null;
        string fines,grants, otherincomes,expenses,purchases,devidends,supplierbalances, savingswithdraw,creditapproval,debitapproval,addcollateral,addinsuranceprocessing,issueloan,loanschedule,savingsforloans,externalloan,externalloanschedule,externalloanfines,externalloanrepayments,investorwithdrawapplication,investorcreditapproval,investordebitfirstapproval = null;
        string investordebitsecondapproval, investorwithdrawissue, accountreports, savingsreports, loansreports, externalborrowingreports, investorreports, hrreports, transactionreports, financialsummsries, addmenu, moneytransfer, bankaccountscreate = null;
        public void Checkboxes()
        {
            if (checkBoxItem1.Checked == true) { settings = "Yes"; } else { settings = "No"; }
            if (checkBoxItem2.Checked == true) { humanresource = "Yes"; } else { humanresource = "No"; }
            if (checkBoxItem3.Checked == true) { savingsaccount = "Yes"; } else { savingsaccount = "No"; }
            if (checkBoxItem4.Checked == true) { savingsdeposit = "Yes"; } else { savingsdeposit = "No"; }
            if (checkBoxItem5.Checked == true) { investoraccountcreation = "Yes"; } else { investoraccountcreation = "No"; }
            if (checkBoxItem6.Checked == true) { loanapplication = "Yes"; } else { loanapplication = "No"; }
            if (checkBoxItem7.Checked == true) { loanrecovery = "Yes"; } else { loanrecovery = "No"; }
            if (checkBoxItem8.Checked == true) { loanwriteoff = "Yes"; } else { loanwriteoff = "No"; }
            if (checkBoxItem9.Checked == true) { Normalsettlement = "Yes"; } else { Normalsettlement = "No"; }
            if (checkBoxItem10.Checked == true) { earlysettlement = "Yes"; } else { earlysettlement = "No"; }
            if (checkBoxItem11.Checked == true) { loanreschedule = "Yes"; } else { loanreschedule = "No"; }
            if (checkBoxItem12.Checked == true) { loantopup = "Yes"; } else { loantopup = "No"; }
            if (checkBoxItem13.Checked == true) { accountsrecord = "Yes"; } else { accountsrecord = "No"; }
            if (checkBoxItem14.Checked == true) { savingsrecord = "Yes"; } else { savingsrecord = "No"; }
            if (checkBoxItem15.Checked == true) { loansrecord = "Yes"; } else { loansrecord = "No"; }
            if (checkBoxItem16.Checked == true) { deletes = "Yes"; } else { deletes = "No"; }
            if (checkBoxItem17.Checked == true) { updates = "Yes"; } else { updates = "No"; }
            if (checkBoxItem18.Checked == true) { externalborrowingrecords = "Yes"; } else { externalborrowingrecords = "No"; }
            if (checkBoxItem19.Checked == true) { investorrecords = "Yes"; } else { investorrecords = "No"; }
            if (checkBoxItem20.Checked == true) { inflowsrecords = "Yes"; } else { inflowsrecords = "No"; }
            if (checkBoxItem21.Checked == true) { outflowsrecords = "Yes"; } else { outflowsrecords = "No"; }
            if (checkBoxItem22.Checked == true) { HRrecords = "Yes"; } else { HRrecords = "No"; }
            if (checkBoxItem23.Checked == true) { fines = "Yes"; } else { fines = "No"; }
            if (checkBoxItem24.Checked == true) { grants = "Yes"; } else { grants = "No"; }
            if (checkBoxItem25.Checked == true) { otherincomes = "Yes"; } else { otherincomes = "No"; }
            if (checkBoxItem26.Checked == true) { expenses = "Yes"; } else { expenses = "No"; }
            if (checkBoxItem27.Checked == true) { purchases = "Yes"; } else {purchases = "No"; }
            if (checkBoxItem28.Checked == true) { devidends = "Yes"; } else { devidends = "No"; }
            if (checkBoxItem29.Checked == true) { supplierbalances = "Yes"; } else { supplierbalances = "No"; }
            if (checkBoxItem30.Checked == true) { savingswithdraw = "Yes"; } else { savingswithdraw= "No"; }
            if (checkBoxItem31.Checked == true) { creditapproval = "Yes"; } else { creditapproval = "No"; }
            if (checkBoxItem32.Checked == true) { debitapproval = "Yes"; } else { debitapproval = "No"; }
            if (checkBoxItem33.Checked == true) { addcollateral = "Yes"; } else { addcollateral= "No"; }
            if (checkBoxItem34.Checked == true) { addinsuranceprocessing= "Yes"; } else { addinsuranceprocessing = "No"; }
            if (checkBoxItem35.Checked == true) { issueloan = "Yes"; } else { issueloan = "No"; }
            if (checkBoxItem36.Checked == true) { loanreschedule = "Yes"; } else { loanschedule = "No"; }
            if (checkBoxItem37.Checked == true) { savingsforloans = "Yes"; } else { savingsforloans = "No"; }
            if (checkBoxItem38.Checked == true) { externalloan = "Yes"; } else { externalloan = "No"; }
            if (checkBoxItem39.Checked == true) { externalloanfines = "Yes"; } else { externalloanfines = "No"; }
            if (checkBoxItem40.Checked == true) { externalloanschedule = "Yes"; } else { externalloanschedule = "No"; }
            if (checkBoxItem41.Checked == true) { externalloanrepayments = "Yes"; } else { externalloanrepayments = "No"; }
            if (checkBoxItem42.Checked == true) { investorwithdrawapplication = "Yes"; } else { investorwithdrawapplication = "No"; }
            if (checkBoxItem43.Checked == true) { investorcreditapproval = "Yes"; } else { investorcreditapproval = "No"; }
            if (checkBoxItem44.Checked == true) { investordebitfirstapproval = "Yes"; } else { investordebitfirstapproval = "No"; }
            if (checkBoxItem45.Checked == true) { investordebitsecondapproval = "Yes"; } else { investordebitsecondapproval = "No"; }
            if (checkBoxItem46.Checked == true) { investorwithdrawissue = "Yes"; } else {investorwithdrawissue = "No"; }
            if (checkBoxItem47.Checked == true) { accountreports = "Yes"; } else { accountreports = "No"; }
            if (checkBoxItem48.Checked == true) { savingsreports = "Yes"; } else { savingsreports = "No"; }
            if (checkBoxItem49.Checked == true) { loansreports = "Yes"; } else { loansreports = "No"; }
            if (checkBoxItem50.Checked == true) { externalborrowingreports = "Yes"; } else { externalborrowingreports = "No"; }
            if (checkBoxItem51.Checked == true) { investorreports = "Yes"; } else { investorreports = "No"; }
            if (checkBoxItem52.Checked == true) { hrreports = "Yes"; } else { hrreports = "No"; }
            if (checkBoxItem53.Checked == true) { transactionreports = "Yes"; } else { transactionreports = "No"; }
            if (checkBoxItem54.Checked == true) { financialsummsries = "Yes"; } else { financialsummsries = "No"; }
            if (checkBoxItem55.Checked == true) { addmenu = "Yes"; } else { addmenu = "No"; }
            if (checkBoxItem56.Checked == true) { moneytransfer = "Yes"; } else { moneytransfer = "No"; }
            if (checkBoxItem57.Checked == true) { bankaccountscreate = "Yes"; } else { bankaccountscreate = "No"; }
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
                    string cb = "update UserAccess set BankAccounts=@d58,MoneyTransfer=@d57,AddMenu=@d56,FinancialSummaries=@d55,TransactionReports=@d54,HRReports=@d53,InvestorReports=@d52,ExternalBorrowingReports=@d51,LoanReports=@d50,SavingsReports=@d49,AccountReports=@d48,InvestorWithdraw=@d47, InvestorDebitSecond=@d46,InvestorDebitFirst=@d45,InvestorCreditApproval=@d44,InvestorWithdrawApplication=@d43,ExternalLoanRepayments=@d42,ExternalLoanSchedule=@d41,ExternalLoanFines=@d40,ExternalLoan=@d39,SavingsForLoans=@d38,LoanSchedule=@d37,IssueLoan=@d36, AddInsurance=@d35,AddCollateral=@d34,DebitApproval=@d33,CreditApproval=@d32,SavingsWithdraw=@d31,SupplierBalances=@d30,Dividends=@d29,Purchases=@d28,Expenses=@d27,OtherIncomes=@d26,Grants=@d25,Fines=@d24,HRRecords=@d23,OutflowRecords=@d22,InflowRecords=@d21,InvestorRecords=@d20,ExternalRecords=@d19,Updates=@d18,Deletes=@d17,LoanRecords=@d16,SavingsRecord=@d15,AccountsRecord=@d14,LoanTopup=@d13,LoanReschedule=@d12,EarlySettlement=@d11,NormalSettlement=@d10,LoanWriteoff=@d9,LoanRecovery=@d8, Loans=@d7,InvestorAccount=@d6,Settings=@d2,Humanresource=@d3,Account=@d4,Savings=@d5 where UserName=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Settings"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Humanresource"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Savings"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "InvestorAccount"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Loans"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "LoanRecovery"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "LoanWriteoff"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "NormalSettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "EarlySettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "LoanReschedule"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "LoanTopup"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "AccountsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "SavingsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "LoanRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "ExternalRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "InvestorRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "InflowRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "OutflowRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "HRRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "Fines"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "Grants"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "OtherIncomes"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "Expenses"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 10, "Purchases"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "Dividends"));
                    cmd.Parameters.Add(new SqlParameter("@d30", System.Data.SqlDbType.NChar, 10, "SupplierBalances"));
                    cmd.Parameters.Add(new SqlParameter("@d31", System.Data.SqlDbType.NChar, 10, "SavingsWithdraw"));
                    cmd.Parameters.Add(new SqlParameter("@d32", System.Data.SqlDbType.NChar, 10, "CreditApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 10, "DebitApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d34", System.Data.SqlDbType.NChar, 10, "AddCollateral"));
                    cmd.Parameters.Add(new SqlParameter("@d35", System.Data.SqlDbType.NChar, 10, "AddInsurance"));
                    cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 10, "IssueLoan"));
                    cmd.Parameters.Add(new SqlParameter("@d37", System.Data.SqlDbType.NChar, 10, "LoanSchedule"));
                    cmd.Parameters.Add(new SqlParameter("@d38", System.Data.SqlDbType.NChar, 10, "SavingsForLoans"));
                    cmd.Parameters.Add(new SqlParameter("@d39", System.Data.SqlDbType.NChar, 10, "ExternalLoan"));
                    cmd.Parameters.Add(new SqlParameter("@d40", System.Data.SqlDbType.NChar, 10, "ExternalLoanFines"));
                    cmd.Parameters.Add(new SqlParameter("@d41", System.Data.SqlDbType.NChar, 10, "ExternalLoanSchedule"));
                    cmd.Parameters.Add(new SqlParameter("@d42", System.Data.SqlDbType.NChar, 10, "ExternalLoanRepayments"));
                    cmd.Parameters.Add(new SqlParameter("@d43", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d44", System.Data.SqlDbType.NChar, 10, "InvestorCreditApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d45", System.Data.SqlDbType.NChar, 10, "InvestorDebitFirst"));
                    cmd.Parameters.Add(new SqlParameter("@d46", System.Data.SqlDbType.NChar, 10, "InvestorDebitSecond"));
                    cmd.Parameters.Add(new SqlParameter("@d47", System.Data.SqlDbType.NChar, 10, "InvestorWithdraw"));
                    cmd.Parameters.Add(new SqlParameter("@d48", System.Data.SqlDbType.NChar, 10, "AccountReports"));
                    cmd.Parameters.Add(new SqlParameter("@d49", System.Data.SqlDbType.NChar, 10, "SavingsReports"));
                    cmd.Parameters.Add(new SqlParameter("@d50", System.Data.SqlDbType.NChar, 10, "LoanReports"));
                    cmd.Parameters.Add(new SqlParameter("@d51", System.Data.SqlDbType.NChar, 10, "ExternalBorrowingReports"));
                    cmd.Parameters.Add(new SqlParameter("@d52", System.Data.SqlDbType.NChar, 10, "InvestorReports"));
                    cmd.Parameters.Add(new SqlParameter("@d53", System.Data.SqlDbType.NChar, 10, "HRReports"));
                    cmd.Parameters.Add(new SqlParameter("@d54", System.Data.SqlDbType.NChar, 10, "TransactionReports"));
                    cmd.Parameters.Add(new SqlParameter("@d55", System.Data.SqlDbType.NChar, 10, "FinancialSummaries"));
                    cmd.Parameters.Add(new SqlParameter("@d56", System.Data.SqlDbType.NChar, 10, "AddMenu"));
                    cmd.Parameters.Add(new SqlParameter("@d57", System.Data.SqlDbType.NChar, 10, "MoneyTransfer"));
                    cmd.Parameters.Add(new SqlParameter("@d58", System.Data.SqlDbType.NChar, 10, "BankAccounts"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = settings;
                    cmd.Parameters["@d3"].Value = humanresource;
                    cmd.Parameters["@d4"].Value = savingsaccount;
                    cmd.Parameters["@d5"].Value = savingsdeposit;
                    cmd.Parameters["@d6"].Value = investoraccountcreation;
                    cmd.Parameters["@d7"].Value = loanapplication;
                    cmd.Parameters["@d8"].Value = loanrecovery;
                    cmd.Parameters["@d9"].Value = loanwriteoff;
                    cmd.Parameters["@d10"].Value = Normalsettlement;
                    cmd.Parameters["@d11"].Value = earlysettlement;
                    cmd.Parameters["@d12"].Value = loanreschedule;
                    cmd.Parameters["@d13"].Value = loantopup;
                    cmd.Parameters["@d14"].Value = accountsrecord;
                    cmd.Parameters["@d15"].Value =savingsrecord;
                    cmd.Parameters["@d16"].Value = loansrecord;
                    cmd.Parameters["@d17"].Value = deletes;
                    cmd.Parameters["@d18"].Value =updates;
                    cmd.Parameters["@d19"].Value =externalborrowingrecords;
                    cmd.Parameters["@d20"].Value = investorrecords;
                    cmd.Parameters["@d21"].Value = inflowsrecords;
                    cmd.Parameters["@d22"].Value = outflowsrecords;
                    cmd.Parameters["@d23"].Value = HRrecords;
                    cmd.Parameters["@d24"].Value = fines;
                    cmd.Parameters["@d25"].Value = grants;
                    cmd.Parameters["@d26"].Value = otherincomes;
                    cmd.Parameters["@d27"].Value = expenses;
                    cmd.Parameters["@d28"].Value = purchases;
                    cmd.Parameters["@d29"].Value = devidends;
                    cmd.Parameters["@d30"].Value = supplierbalances;
                    cmd.Parameters["@d31"].Value = savingswithdraw;
                    cmd.Parameters["@d32"].Value = creditapproval;
                    cmd.Parameters["@d33"].Value = debitapproval;
                    cmd.Parameters["@d34"].Value = addcollateral;
                    cmd.Parameters["@d35"].Value = addinsuranceprocessing;
                    cmd.Parameters["@d36"].Value = issueloan;
                    cmd.Parameters["@d37"].Value = loanschedule;
                    cmd.Parameters["@d38"].Value = savingsforloans;
                    cmd.Parameters["@d39"].Value = externalloan;
                    cmd.Parameters["@d40"].Value = externalloanfines;
                    cmd.Parameters["@d41"].Value = externalloanschedule;
                    cmd.Parameters["@d42"].Value = externalloanrepayments;
                    cmd.Parameters["@d43"].Value = investorwithdrawapplication;
                    cmd.Parameters["@d44"].Value = investorcreditapproval;
                    cmd.Parameters["@d45"].Value = investordebitfirstapproval;
                    cmd.Parameters["@d46"].Value = investordebitsecondapproval;
                    cmd.Parameters["@d47"].Value = investorwithdrawissue;
                    cmd.Parameters["@d48"].Value =accountreports;
                    cmd.Parameters["@d49"].Value = savingsreports;
                    cmd.Parameters["@d50"].Value = loansreports;
                    cmd.Parameters["@d51"].Value = externalborrowingreports;
                    cmd.Parameters["@d52"].Value = investorreports;
                    cmd.Parameters["@d53"].Value = hrreports;
                    cmd.Parameters["@d54"].Value = transactionreports;
                    cmd.Parameters["@d55"].Value = financialsummsries;
                    cmd.Parameters["@d56"].Value = addmenu;
                    cmd.Parameters["@d57"].Value = moneytransfer;
                    cmd.Parameters["@d58"].Value = bankaccountscreate;
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
                    string cb = "Insert Into UserAccess (Username,Settings,Humanresource,Account,Savings,InvestorAccount,Loans,LoanRecovery,LoanWriteoff,NormalSettlement,EarlySettlement,LoanReschedule,LoanTopup,AccountsRecord,SavingsRecord,LoanRecords,Deletes,Updates,ExternalRecords,InvestorRecords,InflowRecords,OutflowRecords,HRRecords,Fines,Grants,OtherIncomes,Expenses,Purchases,Dividends,SupplierBalances,SavingsWithdraw,CreditApproval,DebitApproval,AddCollateral,AddInsurance,IssueLoan,LoanSchedule,SavingsForLoans,ExternalLoan,ExternalLoanFines,ExternalLoanSchedule,ExternalLoanRepayments,InvestorWithdrawApplication,InvestorCreditApproval,InvestorDebitFirst,InvestorDebitSecond,InvestorWithdraw,AccountReports,SavingsReports,LoanReports,ExternalBorrowingReports,InvestorReports,HRReports,TransactionReports,FinancialSummaries,AddMenu,MoneyTransfer,BankAccounts) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39,@d40,@d41,@d42,@d43,@d44,@d45,@d46,@d47,@d48,@d49,@d50,@d51,@d52,@d53,@d54,@d55,@d56,@d57,@d58)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Settings"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Humanresource"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Account"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Savings"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "InvestorAccount"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Loans"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "LoanRecovery"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "LoanWriteoff"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "NormalSettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "EarlySettlement"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "LoanReschedule"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "LoanTopup"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "AccountsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "SavingsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "LoanRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "ExternalRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "InvestorRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "InflowRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "OutflowRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "HRRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "Fines"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "Grants"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "OtherIncomes"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "Expenses"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 10, "Purchases"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "Dividends"));
                    cmd.Parameters.Add(new SqlParameter("@d30", System.Data.SqlDbType.NChar, 10, "SupplierBalances"));
                    cmd.Parameters.Add(new SqlParameter("@d31", System.Data.SqlDbType.NChar, 10, "SavingsWithdraw"));
                    cmd.Parameters.Add(new SqlParameter("@d32", System.Data.SqlDbType.NChar, 10, "CreditApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 10, "DebitApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d34", System.Data.SqlDbType.NChar, 10, "AddCollateral"));
                    cmd.Parameters.Add(new SqlParameter("@d35", System.Data.SqlDbType.NChar, 10, "AddInsurance"));
                    cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 10, "IssueLoan"));
                    cmd.Parameters.Add(new SqlParameter("@d37", System.Data.SqlDbType.NChar, 10, "LoanSchedule"));
                    cmd.Parameters.Add(new SqlParameter("@d38", System.Data.SqlDbType.NChar, 10, "SavingsForLoans"));
                    cmd.Parameters.Add(new SqlParameter("@d39", System.Data.SqlDbType.NChar, 10, "ExternalLoan"));
                    cmd.Parameters.Add(new SqlParameter("@d40", System.Data.SqlDbType.NChar, 10, "ExternalLoanFines"));
                    cmd.Parameters.Add(new SqlParameter("@d41", System.Data.SqlDbType.NChar, 10, "ExternalLoanSchedule"));
                    cmd.Parameters.Add(new SqlParameter("@d42", System.Data.SqlDbType.NChar, 10, "ExternalLoanRepayments"));
                    cmd.Parameters.Add(new SqlParameter("@d43", System.Data.SqlDbType.NChar, 10, "InvestorWithdrawApplication"));
                    cmd.Parameters.Add(new SqlParameter("@d44", System.Data.SqlDbType.NChar, 10, "InvestorCreditApproval"));
                    cmd.Parameters.Add(new SqlParameter("@d45", System.Data.SqlDbType.NChar, 10, "InvestorDebitFirst"));
                    cmd.Parameters.Add(new SqlParameter("@d46", System.Data.SqlDbType.NChar, 10, "InvestorDebitSecond"));
                    cmd.Parameters.Add(new SqlParameter("@d47", System.Data.SqlDbType.NChar, 10, "InvestorWithdraw"));
                    cmd.Parameters.Add(new SqlParameter("@d48", System.Data.SqlDbType.NChar, 10, "AccountReports"));
                    cmd.Parameters.Add(new SqlParameter("@d49", System.Data.SqlDbType.NChar, 10, "SavingsReports"));
                    cmd.Parameters.Add(new SqlParameter("@d50", System.Data.SqlDbType.NChar, 10, "LoanReports"));
                    cmd.Parameters.Add(new SqlParameter("@d51", System.Data.SqlDbType.NChar, 10, "ExternalBorrowingReports"));
                    cmd.Parameters.Add(new SqlParameter("@d52", System.Data.SqlDbType.NChar, 10, "InvestorReports"));
                    cmd.Parameters.Add(new SqlParameter("@d53", System.Data.SqlDbType.NChar, 10, "HRReports"));
                    cmd.Parameters.Add(new SqlParameter("@d54", System.Data.SqlDbType.NChar, 10, "TransactionReports"));
                    cmd.Parameters.Add(new SqlParameter("@d55", System.Data.SqlDbType.NChar, 10, "FinancialSummaries"));
                    cmd.Parameters.Add(new SqlParameter("@d56", System.Data.SqlDbType.NChar, 10, "AddMenu"));
                    cmd.Parameters.Add(new SqlParameter("@d57", System.Data.SqlDbType.NChar, 10, "MoneyTransfer"));
                    cmd.Parameters.Add(new SqlParameter("@d58", System.Data.SqlDbType.NChar, 10, "BankAccounts"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = settings;
                    cmd.Parameters["@d3"].Value = humanresource;
                    cmd.Parameters["@d4"].Value = savingsaccount;
                    cmd.Parameters["@d5"].Value = savingsdeposit;
                    cmd.Parameters["@d6"].Value = investoraccountcreation;
                    cmd.Parameters["@d7"].Value = loanapplication;
                    cmd.Parameters["@d8"].Value = loanrecovery;
                    cmd.Parameters["@d9"].Value = loanwriteoff;
                    cmd.Parameters["@d10"].Value = Normalsettlement;
                    cmd.Parameters["@d11"].Value = earlysettlement;
                    cmd.Parameters["@d12"].Value = loanreschedule;
                    cmd.Parameters["@d13"].Value = loantopup;
                    cmd.Parameters["@d14"].Value = accountsrecord;
                    cmd.Parameters["@d15"].Value = savingsrecord;
                    cmd.Parameters["@d16"].Value = loansrecord;
                    cmd.Parameters["@d17"].Value = deletes;
                    cmd.Parameters["@d18"].Value = updates;
                    cmd.Parameters["@d19"].Value = externalborrowingrecords;
                    cmd.Parameters["@d20"].Value = investorrecords;
                    cmd.Parameters["@d21"].Value = inflowsrecords;
                    cmd.Parameters["@d22"].Value = outflowsrecords;
                    cmd.Parameters["@d23"].Value = HRrecords;
                    cmd.Parameters["@d24"].Value = fines;
                    cmd.Parameters["@d25"].Value = grants;
                    cmd.Parameters["@d26"].Value = otherincomes;
                    cmd.Parameters["@d27"].Value = expenses;
                    cmd.Parameters["@d28"].Value = purchases;
                    cmd.Parameters["@d29"].Value = devidends;
                    cmd.Parameters["@d30"].Value = supplierbalances;
                    cmd.Parameters["@d31"].Value = savingswithdraw;
                    cmd.Parameters["@d32"].Value = creditapproval;
                    cmd.Parameters["@d33"].Value = debitapproval;
                    cmd.Parameters["@d34"].Value = addcollateral;
                    cmd.Parameters["@d35"].Value = addinsuranceprocessing;
                    cmd.Parameters["@d36"].Value = issueloan;
                    cmd.Parameters["@d37"].Value = loanschedule;
                    cmd.Parameters["@d38"].Value = savingsforloans;
                    cmd.Parameters["@d39"].Value = externalloan;
                    cmd.Parameters["@d40"].Value = externalloanfines;
                    cmd.Parameters["@d41"].Value = externalloanschedule;
                    cmd.Parameters["@d42"].Value = externalloanrepayments;
                    cmd.Parameters["@d43"].Value = investorwithdrawapplication;
                    cmd.Parameters["@d44"].Value = investorcreditapproval;
                    cmd.Parameters["@d45"].Value = investordebitfirstapproval;
                    cmd.Parameters["@d46"].Value = investordebitsecondapproval;
                    cmd.Parameters["@d47"].Value = investorwithdrawissue;
                    cmd.Parameters["@d48"].Value = accountreports;
                    cmd.Parameters["@d49"].Value = savingsreports;
                    cmd.Parameters["@d50"].Value = loansreports;
                    cmd.Parameters["@d51"].Value = externalborrowingreports;
                    cmd.Parameters["@d52"].Value = investorreports;
                    cmd.Parameters["@d53"].Value = hrreports;
                    cmd.Parameters["@d54"].Value = transactionreports;
                    cmd.Parameters["@d55"].Value = financialsummsries;
                    cmd.Parameters["@d56"].Value = addmenu;
                    cmd.Parameters["@d57"].Value = moneytransfer;
                    cmd.Parameters["@d58"].Value = bankaccountscreate;
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
                   humanresource = rdr["Humanresource"].ToString().Trim();
                    savingsaccount= rdr["Account"].ToString().Trim();
                    savingsdeposit = rdr["Savings"].ToString().Trim();
                    investoraccountcreation = rdr["InvestorAccount"].ToString().Trim();
                    loanapplication = rdr["Loans"].ToString().Trim();
                    loanrecovery = rdr["LoanRecovery"].ToString().Trim();
                    loanwriteoff= rdr["LoanWriteoff"].ToString().Trim();
                    Normalsettlement = rdr["NormalSettlement"].ToString().Trim();
                    earlysettlement = rdr["EarlySettlement"].ToString().Trim();
                    loanreschedule = rdr["LoanReschedule"].ToString().Trim();
                   loantopup = rdr["LoanTopup"].ToString().Trim();
                    accountsrecord = rdr["AccountsRecord"].ToString().Trim();
                    savingsrecord = rdr["SavingsRecord"].ToString().Trim();
                    loansrecord = rdr["LoanRecords"].ToString().Trim();
                    deletes = rdr["Deletes"].ToString().Trim();
                    updates = rdr["Updates"].ToString().Trim();
                    externalborrowingrecords = rdr["ExternalRecords"].ToString().Trim();
                    investorrecords = rdr["InvestorRecords"].ToString().Trim();
                    inflowsrecords = rdr["InflowRecords"].ToString().Trim();
                    outflowsrecords = rdr["OutflowRecords"].ToString().Trim();
                    HRrecords = rdr["HRRecords"].ToString().Trim();
                    fines = rdr["Fines"].ToString().Trim();
                    grants = rdr["Grants"].ToString().Trim();
                    otherincomes = rdr["OtherIncomes"].ToString().Trim();
                    expenses = rdr["Expenses"].ToString().Trim();
                    purchases = rdr["Purchases"].ToString().Trim();
                    devidends = rdr["Dividends"].ToString().Trim();
                    supplierbalances = rdr["SupplierBalances"].ToString().Trim();
                    savingswithdraw = rdr["SavingsWithdraw"].ToString().Trim();
                    creditapproval = rdr["CreditApproval"].ToString().Trim();
                    debitapproval = rdr["DebitApproval"].ToString().Trim();
                    addcollateral= rdr["AddCollateral"].ToString().Trim();
                    addinsuranceprocessing= rdr["AddInsurance"].ToString().Trim();
                    issueloan= rdr["IssueLoan"].ToString().Trim();
                    loanschedule = rdr["LoanSchedule"].ToString().Trim();
                    savingsforloans = rdr["SavingsForLoans"].ToString().Trim();
                    externalloan = rdr["ExternalLoan"].ToString().Trim();
                    externalloanfines = rdr["ExternalLoanFines"].ToString().Trim();
                    externalloanschedule = rdr["ExternalLoanSchedule"].ToString().Trim();
                    externalloanrepayments = rdr["ExternalLoanRepayments"].ToString().Trim();
                    investorwithdrawapplication = rdr["InvestorWithdrawApplication"].ToString().Trim();
                    investorcreditapproval = rdr["InvestorCreditApproval"].ToString().Trim();
                    investordebitfirstapproval= rdr["InvestorDebitFirst"].ToString().Trim();
                    investordebitsecondapproval= rdr["InvestorDebitSecond"].ToString().Trim();
                   investorwithdrawissue = rdr["InvestorWithdraw"].ToString().Trim();
                    accountreports= rdr["AccountReports"].ToString().Trim();
                    savingsreports = rdr["SavingsReports"].ToString().Trim();
                    loansreports = rdr["LoanReports"].ToString().Trim();
                    externalborrowingreports = rdr["ExternalBorrowingReports"].ToString().Trim();
                    investorreports = rdr["InvestorReports"].ToString().Trim();
                    hrreports = rdr["HRReports"].ToString().Trim();
                    transactionreports = rdr["TransactionReports"].ToString().Trim();
                    financialsummsries = rdr["FinancialSummaries"].ToString().Trim();
                    addmenu = rdr["AddMenu"].ToString().Trim();
                    moneytransfer = rdr["MoneyTransfer"].ToString().Trim();
                    bankaccountscreate = rdr["BankAccounts"].ToString().Trim();

                    if (settings == "Yes") { checkBoxItem1.Checked = true; } else { checkBoxItem1.Checked = false; }
                    if (humanresource == "Yes") { checkBoxItem2.Checked = true; } else { checkBoxItem2.Checked = false; }
                    if (savingsaccount == "Yes") { checkBoxItem3.Checked = true; } else { checkBoxItem3.Checked = false; }
                    if (savingsdeposit== "Yes") { checkBoxItem4.Checked = true; } else { checkBoxItem4.Checked = false; }
                    if (investoraccountcreation == "Yes") { checkBoxItem5.Checked = true; } else { checkBoxItem5.Checked = false; }
                    if (loanapplication == "Yes") { checkBoxItem6.Checked = true; } else { checkBoxItem6.Checked = false; }
                    if (loanrecovery == "Yes") { checkBoxItem7.Checked = true; } else { checkBoxItem7.Checked = false; }
                    if (loanwriteoff == "Yes") { checkBoxItem8.Checked = true; } else { checkBoxItem8.Checked = false; }
                    if (Normalsettlement == "Yes") { checkBoxItem9.Checked = true; } else { checkBoxItem9.Checked = false; }
                    if (earlysettlement == "Yes") { checkBoxItem10.Checked = true; } else { checkBoxItem10.Checked = false; }
                    if (loanreschedule == "Yes") { checkBoxItem11.Checked = true; } else { checkBoxItem11.Checked = false; }
                    if (loantopup == "Yes") { checkBoxItem12.Checked = true; } else { checkBoxItem12.Checked = false; }
                    if (accountsrecord == "Yes") { checkBoxItem13.Checked = true; } else { checkBoxItem13.Checked = false; }
                    if (savingsrecord == "Yes") { checkBoxItem14.Checked = true; } else { checkBoxItem14.Checked = false; }
                    if (loansrecord == "Yes") { checkBoxItem15.Checked = true; } else { checkBoxItem15.Checked = false; }
                    if (deletes == "Yes") { checkBoxItem16.Checked = true; } else { checkBoxItem16.Checked = false; }
                    if (updates == "Yes") { checkBoxItem17.Checked = true; } else { checkBoxItem17.Checked = false; }
                    if (externalborrowingrecords == "Yes") { checkBoxItem18.Checked = true; } else { checkBoxItem18.Checked = false; }
                    if (investorrecords == "Yes") { checkBoxItem19.Checked = true; } else { checkBoxItem19.Checked = false; }
                    if (inflowsrecords == "Yes") { checkBoxItem20.Checked = true; } else { checkBoxItem20.Checked = false; }
                    if (outflowsrecords == "Yes") { checkBoxItem21.Checked = true; } else { checkBoxItem21.Checked = false; }
                    if (HRrecords== "Yes") { checkBoxItem22.Checked = true; } else { checkBoxItem22.Checked = false; }
                    if (fines == "Yes") { checkBoxItem23.Checked = true; } else { checkBoxItem23.Checked = false; }
                    if (grants == "Yes") { checkBoxItem24.Checked = true; } else { checkBoxItem24.Checked = false; }
                    if (otherincomes == "Yes") { checkBoxItem25.Checked = true; } else { checkBoxItem25.Checked = false; }
                    if (expenses == "Yes") { checkBoxItem26.Checked = true; } else { checkBoxItem26.Checked = false; }
                    if (purchases == "Yes") { checkBoxItem27.Checked = true; } else { checkBoxItem27.Checked = false; }
                    if (devidends == "Yes") { checkBoxItem28.Checked = true; } else { checkBoxItem28.Checked = false; }
                    if (supplierbalances== "Yes") { checkBoxItem29.Checked = true; } else { checkBoxItem29.Checked = false; }
                    if (savingswithdraw == "Yes") { checkBoxItem30.Checked = true; } else { checkBoxItem30.Checked = false; }
                    if (creditapproval == "Yes") { checkBoxItem31.Checked = true; } else { checkBoxItem31.Checked = false; }
                    if (debitapproval == "Yes") { checkBoxItem32.Checked = true; } else { checkBoxItem32.Checked = false; }
                    if (addcollateral == "Yes") { checkBoxItem33.Checked = true; } else { checkBoxItem33.Checked = false; }
                    if (addinsuranceprocessing == "Yes") { checkBoxItem34.Checked = true; } else { checkBoxItem34.Checked = false; }
                    if ( issueloan== "Yes") { checkBoxItem35.Checked = true; } else { checkBoxItem35.Checked = false; }
                    if (loanschedule == "Yes") { checkBoxItem36.Checked = true; } else { checkBoxItem36.Checked = false; }
                    if (savingsforloans == "Yes") { checkBoxItem37.Checked = true; } else { checkBoxItem37.Checked = false; }
                    if (externalloan == "Yes") { checkBoxItem38.Checked = true; } else { checkBoxItem38.Checked = false; }
                    if (externalloanfines == "Yes") { checkBoxItem39.Checked = true; } else { checkBoxItem39.Checked = false; }
                    if (externalloanschedule == "Yes") { checkBoxItem40.Checked = true; } else { checkBoxItem40.Checked = false; }
                    if (externalloanrepayments == "Yes") { checkBoxItem41.Checked = true; } else { checkBoxItem41.Checked = false; }
                    if (investorwithdrawapplication == "Yes") { checkBoxItem42.Checked = true; } else { checkBoxItem42.Checked = false; }
                    if (investorcreditapproval == "Yes") { checkBoxItem43.Checked = true; } else { checkBoxItem43.Checked = false; }
                    if (investordebitfirstapproval == "Yes") { checkBoxItem44.Checked = true; } else { checkBoxItem44.Checked = false; }
                    if (investordebitsecondapproval == "Yes") { checkBoxItem45.Checked = true; } else { checkBoxItem45.Checked = false; }
                    if (investorwithdrawissue == "Yes") { checkBoxItem46.Checked = true; } else { checkBoxItem46.Checked = false; }
                    if (accountreports == "Yes") { checkBoxItem47.Checked = true; } else { checkBoxItem47.Checked = false; }
                    if (savingsreports== "Yes") { checkBoxItem48.Checked = true; } else { checkBoxItem48.Checked = false; }
                    if (loansreports == "Yes") { checkBoxItem49.Checked = true; } else { checkBoxItem49.Checked = false; }
                    if (externalborrowingreports == "Yes") { checkBoxItem50.Checked = true; } else { checkBoxItem50.Checked = false; }
                    if (investorreports == "Yes") { checkBoxItem51.Checked = true; } else { checkBoxItem51.Checked = false; }
                    if (hrreports == "Yes") { checkBoxItem52.Checked = true; } else { checkBoxItem52.Checked = false; }
                    if (transactionreports == "Yes") { checkBoxItem53.Checked = true; } else { checkBoxItem53.Checked = false; }
                    if (financialsummsries == "Yes") { checkBoxItem54.Checked = true; } else { checkBoxItem54.Checked = false; }
                    if (addmenu == "Yes") { checkBoxItem55.Checked = true; } else { checkBoxItem55.Checked = false; }
                    if (moneytransfer == "Yes") { checkBoxItem56.Checked = true; } else { checkBoxItem56.Checked = false; }
                    if (bankaccountscreate== "Yes") { checkBoxItem57.Checked = true; } else { checkBoxItem57.Checked = false; }
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
                    checkBoxItem29.Checked = false;
                    checkBoxItem30.Checked = false;
                    checkBoxItem31.Checked = false;
                    checkBoxItem32.Checked = false;
                    checkBoxItem33.Checked = false;
                    checkBoxItem34.Checked = false;
                    checkBoxItem35.Checked = false;
                    checkBoxItem36.Checked = false;
                    checkBoxItem37.Checked = false;
                    checkBoxItem38.Checked = false;
                    checkBoxItem39.Checked = false;
                    checkBoxItem40.Checked = false;
                    checkBoxItem41.Checked = false;
                    checkBoxItem42.Checked = false;
                    checkBoxItem43.Checked = false;
                    checkBoxItem44.Checked = false;
                    checkBoxItem45.Checked = false;
                    checkBoxItem46.Checked = false;
                    checkBoxItem47.Checked = false;
                    checkBoxItem48.Checked = false;
                    checkBoxItem49.Checked = false;
                    checkBoxItem50.Checked = false;
                    checkBoxItem51.Checked = false;
                    checkBoxItem52.Checked = false;
                    checkBoxItem53.Checked = false;
                    checkBoxItem54.Checked = false;
                    checkBoxItem55.Checked = false;
                    checkBoxItem56.Checked = false;
                    checkBoxItem57.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
