using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace Banking_System
{
    public partial class frmMainMenu : DevComponents.DotNetBar.Office2007RibbonForm
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string status = "UnAvailable";
        public frmMainMenu()
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
        string companyname = null;
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

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = AssemblyCopyright;
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            string realkey = Properties.Settings.Default.readcon;
            company();
            /* if (realkey == "you")
             {
                 this.Text = "Essential Finance Fake Version";
                 frmLicenceInput frm = new frmLicenceInput();
                 frm.ShowDialog();
                 Environment.Exit(-1);
             }
             if (realkey == "mine")
             {
                 this.Text = "Essential Finance [Trial Version]";
             }
             else if (realkey == "me")
             {
                 this.Text = "Essential Finance [Licensed to " + companyname + "]";
                 buttonItem42.Visible = false;
             }*/
            string currentselect = Properties.Settings.Default.currentselection;
            if (currentselect == "Settings")
            {
                Settings.Select();
            }
            else if (currentselect == "ribbonTabItem1")
            {
                ribbonTabItem1.Select();
            }
            else if (currentselect == "ribbonTabItem2")
            {
                ribbonTabItem2.Select();
            }
            else if (currentselect == "ribbonTabItem3")
            {
                ribbonTabItem3.Select();
            }
            else if (currentselect == "ribbonTabItem4")
            {
                ribbonTabItem4.Select();
            }
            
            else if (currentselect == "ribbonTabItem5")
            {
                ribbonTabItem5.Select();
            }
            else if (currentselect == "ribbonTabItem6")
            {
                ribbonTabItem6.Select();
            }
            else if (currentselect == "ribbonTabItem7")
            {
                ribbonTabItem7.Select();
            }
            else if (currentselect == "ribbonTabItem8")
            {
                ribbonTabItem8.Select();
            }
            else
            {
                ribbonTabItem2.Select();
            }
            try
            {

                Time.Text = "";
                Time.Text = DateTime.Now.ToString();
                timer1.Start();
            }
            catch (Exception)
            {

            }
            try
            {
                if (User.Text == "ADMIN" && label1.Text == "jesus@lord1")
                {
                    buttonItem16.Visible = true;
                }
                if (User.Text == "ADMIN")
                {
                    //ribbonTabItem1.Select();
                    Settings.Visible = true;//settings
                    ribbonTabItem1.Visible = true;//Loans
                    ribbonTabItem2.Visible = true;//Loans
                    ribbonTabItem3.Visible = true;//Humman Resource
                    ribbonTabItem4.Visible = true;//Account
                    ribbonTabItem5.Visible = true;//Inflows
                    ribbonTabItem6.Visible = true;//Investments
                    ribbonTabItem7.Visible = true;//Outflows
                    ribbonTabItem8.Visible = true;//Pendings

                    administration.Enabled = true;//account openning
                    schedule.Enabled = true;//savings transaction
                    records.Enabled = true;//safetransactions
                    invetory.Enabled = true;//Loans Transactions
                    reports.Enabled = true;//expensestransactions
                    accounts.Enabled = true;//Financial Summary
                    buttonX1.Enabled = true;
                    buttonX3.Enabled = true;
                    buttonX2.Enabled = true;
                    buttonX4.Enabled = true;
                    buttonX5.Enabled = true;
                    buttonX6.Enabled = true;
                    buttonX7.Enabled = true;
                    buttonX13.Enabled = true;
                    buttonX9.Enabled = true;
                    buttonX10.Enabled = true;
                    buttonX11.Enabled = true;
                    buttonX12.Enabled = true;

                    buttonItem21.Visible = true;
                    buttonItem28.Visible = true;
                    buttonItem29.Visible = true;
                    buttonItem8.Visible = true;//
                    buttonItem9.Visible = true;//
                    buttonItem10.Visible = true;//
                    buttonItem120.Visible = true;//
                    buttonItem24.Visible = true;//
                    buttonItem25.Visible = true;//
                    buttonItem62.Visible = true;//
                    Credit.Visible = true;//
                    buttonItem65.Visible = true;//
                    buttonItem91.Visible = true;//
                    buttonItem39.Visible = true;//
                    buttonItem33.Visible = true;//
                    buttonItem93.Visible = true;//
                    buttonItem32.Visible = true;//
                    buttonItem41.Visible = true;//
                    buttonItem14.Visible = true;//
                    buttonItem121.Visible = true;//
                    buttonItem50.Visible = true;//
                    buttonItem70.Visible = true;//
                    buttonItem34.Visible = true;//
                    buttonItem67.Visible = true;//
                    buttonItem72.Visible = true;//
                    buttonItem35.Visible = true;//
                    buttonItem36.Visible = true;//
                    buttonItem68.Visible = true;//
                    buttonItem38.Visible = true;//
                    buttonItem64.Visible = true;//
                    buttonItem74.Visible = true;//
                    buttonItem80.Visible = true;//
                    buttonItem42.Visible = true;//
                    buttonItem44.Visible = true;//
                    buttonItem45.Visible = true;//
                    buttonItem48.Visible = true;//
                    buttonItem49.Visible = true;//
                    buttonItem51.Visible = true;//
                    buttonItem56.Visible = true;//
                    buttonItem57.Visible = true;//
                    buttonItem58.Visible = true;//

                    buttonItem117.Visible = true;//
                    buttonItem118.Visible = true;//
                    buttonItem119.Visible = true;//
                    buttonItem2.Visible = true;//
                }
                else
                {

                    try
                    {
                        string settings, humanresource, savingsaccount, savingsdeposit, investoraccountcreation, loanapplication, loanrecovery, loanwriteoff, Normalsettlement, earlysettlement, loanreschedule, loantopup, accountsrecord, savingsrecord, loansrecord, deletes, updates, externalborrowingrecords, investorrecords, inflowsrecords, outflowsrecords, HRrecords = null;
                        string fines, grants, otherincomes, expenses, purchases, devidends, supplierbalances, savingswithdraw, creditapproval, debitapproval, addcollateral, addinsuranceprocessing, issueloan, loanschedule, savingsforloans, externalloan, externalloanschedule, externalloanfines, externalloanrepayments, investorwithdrawapplication, investorcreditapproval, investordebitfirstapproval = null;
                        string investordebitsecondapproval, investorwithdrawissue, accountreports, savingsreports, loansreports, externalborrowingreports, investorreports, hrreports, transactionreports, financialsummsries, addmenu, moneytransfer, bankaccountscreate = null;
                        SqlDataReader rdr = null;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + User.Text + "' ";

                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            settings = rdr["Settings"].ToString().Trim();
                            humanresource = rdr["Humanresource"].ToString().Trim();
                            savingsaccount = rdr["Account"].ToString().Trim();
                            savingsdeposit = rdr["Savings"].ToString().Trim();
                            investoraccountcreation = rdr["InvestorAccount"].ToString().Trim();
                            loanapplication = rdr["Loans"].ToString().Trim();
                            loanrecovery = rdr["LoanRecovery"].ToString().Trim();
                            loanwriteoff = rdr["LoanWriteoff"].ToString().Trim();
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
                            addcollateral = rdr["AddCollateral"].ToString().Trim();
                            addinsuranceprocessing = rdr["AddInsurance"].ToString().Trim();
                            issueloan = rdr["IssueLoan"].ToString().Trim();
                            loanschedule = rdr["LoanSchedule"].ToString().Trim();
                            savingsforloans = rdr["SavingsForLoans"].ToString().Trim();
                            externalloan = rdr["ExternalLoan"].ToString().Trim();
                            externalloanfines = rdr["ExternalLoanFines"].ToString().Trim();
                            externalloanschedule = rdr["ExternalLoanSchedule"].ToString().Trim();
                            externalloanrepayments = rdr["ExternalLoanRepayments"].ToString().Trim();
                            investorwithdrawapplication = rdr["InvestorWithdrawApplication"].ToString().Trim();
                            investorcreditapproval = rdr["InvestorCreditApproval"].ToString().Trim();
                            investordebitfirstapproval = rdr["InvestorDebitFirst"].ToString().Trim();
                            investordebitsecondapproval = rdr["InvestorDebitSecond"].ToString().Trim();
                            investorwithdrawissue = rdr["InvestorWithdraw"].ToString().Trim();
                            accountreports = rdr["AccountReports"].ToString().Trim();
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
                            if (settings == "Yes") { Settings.Visible = true; } else { Settings.Visible = false; }
                            if (humanresource == "Yes") {ribbonTabItem3.Visible = true; } else { ribbonTabItem3.Visible = false; }
                            if (savingsaccount == "Yes") { administration.Enabled = true; buttonItem24.Enabled = true; ribbonTabItem4.Visible = true; } else { administration.Enabled = false; buttonItem24.Enabled =false; ribbonTabItem4.Visible = false; }
                            if (savingsdeposit == "Yes") { schedule.Enabled = true; buttonItem25.Enabled = true; } else { schedule.Enabled= false; buttonItem25.Enabled = false; }
                            if (investoraccountcreation == "Yes") { records.Enabled = true; buttonItem35.Enabled = true; ribbonTabItem6.Visible = true; } else {records.Enabled = false; buttonItem35.Enabled = false; ribbonTabItem6.Visible = false; }
                            if (loanapplication == "Yes") {invetory.Enabled = true; buttonItem91.Enabled = true; ribbonTabItem2.Visible = true; } else { invetory.Enabled = false; buttonItem91.Enabled = false; ribbonTabItem2.Visible = false; }
                            if (loanrecovery == "Yes") { reports.Enabled= true; } else { reports.Enabled = false; }
                            if (loanwriteoff == "Yes") { accounts.Enabled = true; } else { accounts.Enabled = false; }
                            if (Normalsettlement == "Yes") { buttonX1.Enabled = true; } else { buttonX1.Enabled = false; }
                            if (earlysettlement == "Yes") { buttonX2.Enabled = true; } else { buttonX2.Enabled = false; }
                            if (loanreschedule == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                            if (loantopup == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                            if (accountsrecord == "Yes") { buttonX5.Enabled = true; } else { buttonX5.Enabled = false; }
                            if (savingsrecord == "Yes") {buttonX6.Enabled = true; } else { buttonX6.Enabled = false; }
                            if (loansrecord == "Yes") { buttonX7.Enabled = true; } else { buttonX7.Enabled = false; }
                            if (externalborrowingrecords == "Yes") { buttonX9.Enabled = true; } else {buttonX9.Enabled = false; }
                            if (investorrecords == "Yes") { buttonX10.Enabled = true; } else { buttonX10.Enabled = false; }
                            if (inflowsrecords == "Yes") {buttonX11.Enabled = true; } else { buttonX11.Enabled = false; }
                            if (outflowsrecords == "Yes") { buttonX12.Enabled = true; } else { buttonX12.Enabled = false; }
                            if (HRrecords == "Yes") { buttonX13.Enabled = true; } else { buttonX13.Enabled = false; }
                            if (fines == "Yes") { buttonItem21.Enabled = true; ribbonTabItem5.Visible = true; } else { buttonItem21.Enabled = false; ribbonTabItem5.Visible = false; }
                            if (grants == "Yes") { buttonItem28.Enabled = true; } else { buttonItem28.Enabled = false; }
                            if (otherincomes == "Yes") { buttonItem29.Enabled = true; } else { buttonItem29.Enabled = false; }
                            if (expenses == "Yes") { buttonItem8.Enabled = true; ribbonTabItem7.Visible = true; } else { buttonItem8.Enabled = false; ribbonTabItem7.Visible=false; }
                            if (purchases == "Yes") { buttonItem9.Enabled = true; } else { buttonItem9.Enabled = false; }
                            if (devidends == "Yes") { buttonItem10.Enabled = true; } else { buttonItem10.Enabled = false; }
                            if (supplierbalances == "Yes") { buttonItem120.Enabled = true; buttonItem119.Enabled = true; } else { buttonItem120.Enabled = false; buttonItem119.Enabled = true; }
                            if (savingswithdraw == "Yes") { buttonItem62.Enabled = true; } else { buttonItem62.Enabled = false; }
                            if (creditapproval == "Yes") { Credit.Enabled = true; } else { Credit.Enabled = false; }
                            if (debitapproval == "Yes") { buttonItem65.Enabled = true; } else { buttonItem65.Enabled = false; }
                            if (addcollateral == "Yes") { buttonItem33.Enabled = true; } else { buttonItem33.Enabled = false; }
                            if (addinsuranceprocessing == "Yes") { buttonItem93.Enabled = true; } else { buttonItem93.Enabled = false; }
                            if (issueloan == "Yes") { buttonItem41.Enabled = true; } else { buttonItem41.Enabled = false; }
                            if (loanschedule == "Yes") { buttonItem14.Enabled = true; } else { buttonItem14.Enabled = false; }
                            if (savingsforloans == "Yes") { buttonItem121.Enabled = true; } else { buttonItem121.Enabled = false; }
                            if (externalloan == "Yes") { ribbonTabItem8.Visible = true; buttonItem50.Enabled = true; buttonItem67.Enabled = true; ribbonTabItem8.Visible = true; } else { ribbonTabItem8.Visible = false; buttonItem50.Enabled = false; buttonItem67.Enabled = false; ribbonTabItem8.Visible = false; }
                            if (externalloanfines == "Yes") { buttonItem70.Enabled = true; } else { buttonItem70.Enabled= false; }
                            if (externalloanschedule == "Yes") { buttonItem34.Enabled= true; } else { buttonItem34.Enabled = false; }
                            if (externalloanrepayments == "Yes") { buttonItem72.Enabled = true; } else { buttonItem72.Enabled = false; }
                            if (investorwithdrawapplication == "Yes") { buttonItem68.Enabled = true; } else { buttonItem68.Enabled = false; }
                            if (investorcreditapproval == "Yes") { buttonItem38.Enabled = true; } else { buttonItem38.Enabled = false; }
                            if (investordebitfirstapproval == "Yes") { buttonItem64.Enabled = true; } else { buttonItem64.Enabled = false; }
                            if (investordebitsecondapproval == "Yes") { buttonItem74.Enabled = true; } else { buttonItem74.Enabled = false; }
                            if (investorwithdrawissue == "Yes") { buttonItem80.Enabled= true; } else { buttonItem80.Enabled = false; }
                            if (accountreports == "Yes") { buttonItem42.Enabled = true; } else { buttonItem42.Enabled = false; }
                            if (savingsreports == "Yes") { buttonItem44.Enabled = true; } else { buttonItem44.Enabled = false; }
                            if (loansreports == "Yes") { buttonItem45.Enabled = true; } else { buttonItem45.Enabled = false; }
                            if (externalborrowingreports == "Yes") { buttonItem47.Enabled = true; } else { buttonItem47.Enabled = false; }
                            if (investorreports == "Yes") { buttonItem48.Enabled = true; } else { buttonItem48.Enabled = false; }
                            if (hrreports == "Yes") { buttonItem56.Enabled = true; } else { buttonItem56.Enabled = false; }
                            if (transactionreports == "Yes") { buttonItem57.Enabled = true; } else { buttonItem57.Enabled = false; }
                            if (financialsummsries == "Yes") { buttonItem58.Enabled = true; } else { buttonItem58.Enabled = false; }
                            if (addmenu == "Yes") { buttonItem2.Visible = true; } else { buttonItem2.Visible = false; }
                            if (moneytransfer == "Yes") { buttonItem118.Visible = true; } else { buttonItem118.Visible = false; }
                            if (bankaccountscreate == "Yes") { buttonItem119.Visible = true; } else { buttonItem119.Visible = false; }
                        }
                        else
                        {
                            Settings.Visible = false;//settings
                            ribbonTabItem1.Visible = false;//Loans
                            ribbonTabItem2.Visible = false;//Loans
                            ribbonTabItem3.Visible = false;//Humman Resource
                            ribbonTabItem4.Visible = false;//Account
                            ribbonTabItem5.Visible = false;//Inflows
                            ribbonTabItem6.Visible = false;//Investments
                            ribbonTabItem7.Visible = false;//Outflows
                            ribbonTabItem8.Visible =false;//Pendings

                            administration.Enabled = false;//account openning
                            schedule.Enabled = false;//savings transaction
                            records.Enabled = false;//safetransactions
                            invetory.Enabled = false;//Loans Transactions
                            reports.Enabled = false;//expensestransactions
                            accounts.Enabled = false;//Financial Summary
                            buttonX1.Enabled = false;
                            buttonX3.Enabled = false;
                            buttonX2.Enabled = false;
                            buttonX4.Enabled = false;
                            buttonX5.Enabled = false;
                            buttonX6.Enabled = false;
                            buttonX7.Enabled = false;
                            buttonX13.Enabled = false;
                            buttonX9.Enabled = false;
                            buttonX10.Enabled = false;
                            buttonX11.Enabled = false;
                            buttonX12.Enabled = false;

                            buttonItem21.Visible = false;
                            buttonItem28.Visible = false;
                            buttonItem29.Visible = false;
                            buttonItem8.Visible = false;//
                            buttonItem9.Visible = false;//
                            buttonItem10.Visible = false;//
                            buttonItem120.Visible = false;//
                            buttonItem24.Visible = false;//
                            buttonItem25.Visible = false;//
                            buttonItem62.Visible = false;//
                            Credit.Visible = false;//
                            buttonItem65.Visible = false;//
                            buttonItem91.Visible = false;//
                            buttonItem39.Visible = false;//
                            buttonItem33.Visible = false;//
                            buttonItem93.Visible = false;//
                            buttonItem32.Visible = false;//
                            buttonItem41.Visible = false;//
                            buttonItem14.Visible = false;//
                            buttonItem121.Visible = false;//
                            buttonItem50.Visible = false;//
                            buttonItem70.Visible = false;//
                            buttonItem34.Visible = false;//
                            buttonItem67.Visible = false;//
                            buttonItem72.Visible = false;//
                            buttonItem35.Visible = false;//
                            buttonItem36.Visible = false;//
                            buttonItem68.Visible = false;//
                            buttonItem38.Visible = false;//
                            buttonItem64.Visible = false;//
                            buttonItem74.Visible = false;//
                            buttonItem80.Visible = false;//
                            buttonItem42.Visible = false;//
                            buttonItem44.Visible = false;//
                            buttonItem45.Visible = false;//
                            buttonItem48.Visible = false;//
                            buttonItem49.Visible = false;//
                            buttonItem51.Visible = false;//
                            buttonItem56.Visible = false;//
                            buttonItem57.Visible = false;//
                            buttonItem58.Visible = false;//

                            buttonItem117.Visible = false;//
                            buttonItem118.Visible = false;//
                            buttonItem119.Visible = false;//
                            buttonItem2.Visible = false;//
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

            }
            frmLoanreminder frm = new frmLoanreminder();
            frm.ShowDialog();
            FrmInvestorRemider frm2 = new FrmInvestorRemider();
            frm2.ShowDialog();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavings frm = new frmSavings();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.Show();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendance frm = new frmAttendance();
            frm.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmContact frm = new frmContact();
            frm.Show();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                System.Environment.Exit(1);

            }
            else
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }
        private void administration_Click(object sender, EventArgs e)
        {
            frmMemberRegistration frm = new frmMemberRegistration();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void formattlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEquipmentPurchase frm = new frmEquipmentPurchase();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }
        private void recordpaylink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmSalaryPaymentRecord frm = new frmSalaryPaymentRecord();
            frm.label4.Text = User.Text;
            frm.label5.Text = UserType.Text;
            frm.Show();
        }

        private void recordattlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmAttendanceRecord frm = new frmAttendanceRecord();
            frm.label3.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }
        private void reportattlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmAttendanceReport frm = new frmAttendanceReport();
            frm.label3.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }
        private void reportpaylink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEmployeePaymentReport frm = new frmEmployeePaymentReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
            frm.Show();
        }
        private void reporteventslink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEventsReport frm = new frmEventsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void reportschlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            //frmReports frm = new frmReports();
            //frm.Show();
        }
        private void clinicDia_Click(object sender, EventArgs e)
        {
            this.Hide();
            //frmDiagnosis frm = new frmDiagnosis();
            //frm.Show();
        }

        private void clinicMed_Click(object sender, EventArgs e)
        {
            this.Hide();
            //frmMedication frm = new frmMedication();
            //frm.Show();
        }
        private void pharmsto_Click(object sender, EventArgs e)
        {

        }
        private void pharmreg_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.Show();
        }

        private void pharmatt_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendance frm = new frmAttendance();
            frm.Show();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }

        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMemberRegistration frm = new frmMemberRegistration();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.label21.Text = User.Text;
            frm.label23.Text = UserType.Text;
            frm.Show();
        }
        private void buttonItem11_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmEvent frm = new frmEvent();
            frm.label8.Text = User.Text;
            frm.label9.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmExpensesRecord frm = new frmExpensesRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEventRecord frm = new frmEventRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEmployeeRecord frm = new frmEmployeeRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = "";
            Time.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            //frmMedicationReport frm = new frmMedicationReport();
            //frm.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmExpenseReport frm = new frmExpenseReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEmployeeDetailsReport frm = new frmEmployeeDetailsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }
        private void pharmsch_Click(object sender, EventArgs e)
        {
            this.Hide();
            //frmEmployeeDetailsReport frm = new frmEmployeeDetailsReport();
            //frm.Show();
        }

        private void humanchat_Click(object sender, EventArgs e)
        {
            frmChat frm = new frmChat();
            frm.label5.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMemberRegistration frm = new frmMemberRegistration();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEquipmentPurchase frm = new frmEquipmentPurchase();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEvent frm = new frmEvent();
            frm.label8.Text = User.Text;
            frm.label9.Text = UserType.Text;
            frm.Show();
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            frmSavings frm = new frmSavings();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void buttonItem36_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavings frm = new frmSavings();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }
        private void buttonItem21_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendanceReport frm = new frmAttendanceReport();
            frm.label3.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExpenseReport frm = new frmExpenseReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }
        private void buttonItem25_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeDetailsReport frm = new frmEmployeeDetailsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem26_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeePaymentReport frm = new frmEmployeePaymentReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
            frm.Show();
        }
        private void Incomeapprovals_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherIncomes frm = new frmOtherIncomes();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void Expenseapprovals_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEXpenses frm = new frmEXpenses();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void Event_Click(object sender, EventArgs e)
        {

            frmEventRecord frm = new frmEventRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void buttonItem53_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.ShowDialog();
        }

        private void buttonItem55_Click(object sender, EventArgs e)
        {
            frmRights frm = new frmRights();
            frm.ShowDialog();
        }
        private void buttonItem61_Click(object sender, EventArgs e)
        {
            frmSavingsInterest frm = new frmSavingsInterest();
            frm.ShowDialog();
        }
        private void buttonItem58_Click(object sender, EventArgs e)
        {
            frmMinimumAccountbalance frm = new frmMinimumAccountbalance();
            frm.ShowDialog();
        }

        private void buttonItem65_Click(object sender, EventArgs e)
        {
            frmTotalRegistrationFees frm = new frmTotalRegistrationFees();
            frm.ShowDialog();
        }
        private void buttonItem59_Click(object sender, EventArgs e)
        {
            frmLoanProcessing frm = new frmLoanProcessing();
            frm.ShowDialog();
        }

        private void buttonItem60_Click(object sender, EventArgs e)
        {
            frmLoanInsurance frm = new frmLoanInsurance();
            frm.ShowDialog();
        }
        private void buttonItem69_Click(object sender, EventArgs e)
        {
            frmExpensesType frm = new frmExpensesType();
            frm.ShowDialog();
        }

        private void buttonItem63_Click(object sender, EventArgs e)
        {
            frmIntrestType frm = new frmIntrestType();
            frm.ShowDialog();
        }

        private void buttonItem9_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmEquipmentPurchase frm = new frmEquipmentPurchase();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem10_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmDrawings frm = new frmDrawings();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frmPlant frm = new frmPlant();
            frm.Show();
        }

        private void buttonItem5_Click_1(object sender, EventArgs e)
        {
            frmProperty frm = new frmProperty();
            frm.Show();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            frmBroughtForward frm = new frmBroughtForward();
            frm.label7.Text = User.Text;
            frm.Show();
        }

        private void buttonItem21_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmFineFeesPayment frm = new frmFineFeesPayment();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem23_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendanceMember frm = new frmAttendanceMember();
            frm.label3.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }
        private void buttonItem28_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmGrant frm = new frmGrant();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem29_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmOtherIncomes frm = new frmOtherIncomes();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void buttonItem19_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Properties.Settings.Default["usercolor"] = colorDialog1.Color;
            Properties.Settings.Default.Save();
            DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem77_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2007Black;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem82_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2007Blue;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem83_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2007Silver;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem85_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem87_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2010Black;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem88_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2010Blue;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem89_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Office2010Silver;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem90_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["userstyle"] = DevComponents.DotNetBar.eStyle.Windows7Blue;
                Properties.Settings.Default.Save();
                DialogResult dialog = MessageBox.Show("Do you want to ogin now for the chages to take effect", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = User.Text;
                    frm.UserType.Text = UserType.Text;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonItem14_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalPaymentSchedule frm = new frmExternalPaymentSchedule();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem30_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.label21.Text = User.Text;
            frm.label23.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem37_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendance frm = new frmAttendance();
            frm.label3.Text = User.Text;
            frm.label4.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem95_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSalaryPayment frm = new frmSalaryPayment();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem96_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmEvent frm = new frmEvent();
            frm.label8.Text = User.Text;
            frm.label9.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem52_Click(object sender, EventArgs e)
        {
            frmUserTypes frm = new frmUserTypes();
            frm.ShowDialog();
        }

        private void buttonItem54_Click(object sender, EventArgs e)
        {
            frmAccessRights frm = new frmAccessRights();
            frm.ShowDialog();
        }

        private void buttonItem98_Click(object sender, EventArgs e)
        {
            frmApprovalRights frm = new frmApprovalRights();
            frm.ShowDialog();
        }
        private void buttonItem99_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem22_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmMemberRegistration frm = new frmMemberRegistration();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem25_Click_1(object sender, EventArgs e)
        {
            frmSavings frm = new frmSavings();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem101_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem102_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem103_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem104_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void ribbonTabItem8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem8";
            Properties.Settings.Default.Save();
        }

        private void buttonItem8_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            frmEXpenses frm = new frmEXpenses();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem105_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem106_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem49_Click_1(object sender, EventArgs e)
        {
            frmAccountApprove frm = new frmAccountApprove();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void buttonItem51_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherIncomes frm = new frmOtherIncomes();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }
        private void buttonItem72_Click(object sender, EventArgs e)
        {
            frmExternalRepaymentForm frm = new frmExternalRepaymentForm();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        private void buttonItem16_Click_1(object sender, EventArgs e)
        {
            frmConfigureCompanyDetails frm = new frmConfigureCompanyDetails();
            frm.ShowDialog();
        }

        private void buttonItem17_Click_1(object sender, EventArgs e)
        {
            frmConfigurePrinter frm = new frmConfigurePrinter();
            frm.ShowDialog();
        }
        private void buttonItem84_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExpenseReport frm = new frmExpenseReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem86_Click(object sender, EventArgs e)
        {
            frmGeneralReport frm = new frmGeneralReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
        private void buttonItem81_Click(object sender, EventArgs e)
        {
            frmEmployeePaymentReport frm = new frmEmployeePaymentReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
            frm.Show();
            this.Hide();
        }


        private void buttonItem108_Click(object sender, EventArgs e)
        {
            frmCompulsoryFees frm = new frmCompulsoryFees();
            frm.ShowDialog();
        }

        private void buttonItem109_Click(object sender, EventArgs e)
        {
            frmLoanTypesSet frm = new frmLoanTypesSet();
            frm.ShowDialog();
        }

        private void buttonItem110_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCashierSafe frm = new frmCashierSafe();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem111_Click(object sender, EventArgs e)
        {
            frmLoanProcessingType frm = new frmLoanProcessingType();
            frm.ShowDialog();
        }
        private void labelItem8_Click(object sender, EventArgs e)
        {

        }
        private void buttonItem113_Click(object sender, EventArgs e)
        {
            frmLoanInsuranceType frm = new frmLoanInsuranceType();
            frm.ShowDialog();
        }
        private void buttonItem115_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Reset Connection Details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                Properties.Settings.Default["connectionsuccess"] = "n";
                Properties.Settings.Default.Save();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.UserType.Text = UserType.Text;
                frm.User.Text = User.Text;
                frm.Show();
            }
        }

        private void buttonItem116_Click(object sender, EventArgs e)
        {
            try
            {
                frmLicenceInput2 frm = new frmLicenceInput2();
                frm.ShowDialog();
                MessageBox.Show("The System Will Exit for Licence To Take Effect, Thank you", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "Settings";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem3";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem4";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem1";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem2";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem6";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem5";
            Properties.Settings.Default.Save();
        }

        private void ribbonTabItem7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem7";
            Properties.Settings.Default.Save();
        }

        private void buttonItem117_Click(object sender, EventArgs e)
        {
            frmBankAccounts frm = new frmBankAccounts();
            frm.ShowDialog();
        }

        private void buttonItem118_Click(object sender, EventArgs e)
        {
            frmMoneyTransfer frm = new frmMoneyTransfer();
            frm.label2.Text = User.Text;
            frm.ShowDialog();
        }

        private void buttonItem119_Click(object sender, EventArgs e)
        {
            frmSupplierAccounts frm = new frmSupplierAccounts();
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void buttonItem120_Click(object sender, EventArgs e)
        {
            frmSupplierAccountBalance frm = new frmSupplierAccountBalance();
            frm.label12.Text = User.Text;
            frm.ShowDialog();
        }

        private void buttonItem114_Click_1(object sender, EventArgs e)
        {
           
        }

        private void buttonItem121_Click(object sender, EventArgs e)
        {
            frmSavingsToLoans frm = new frmSavingsToLoans();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonItem11_Click_1(object sender, EventArgs e)
        {
            frmLoanTypesSet frm = new frmLoanTypesSet();
            frm.ShowDialog();
        }
        private void buttonItem15_Click_1(object sender, EventArgs e)
        {
            frmIntrestType frm = new frmIntrestType();
            frm.ShowDialog();
        }

        private void buttonItem22_Click_2(object sender, EventArgs e)
        {
            frmCompulsoryFees frm = new frmCompulsoryFees();
            frm.ShowDialog();
        }

        private void buttonItem23_Click_2(object sender, EventArgs e)
        {
            frmSmsSettings frm = new frmSmsSettings();
            frm.ShowDialog();
        }

        private void buttonItem26_Click_3(object sender, EventArgs e)
        {
            CompanyCodeSetting frm = new CompanyCodeSetting();
            frm.ShowDialog();
        }

        private void buttonItem27_Click_3(object sender, EventArgs e)
        {
            frmAutoLoanFines frm = new frmAutoLoanFines();
            frm.ShowDialog();
        }

        private void buttonItem31_Click_2(object sender, EventArgs e)
        {
            frmAutoSavingsToLoans frm = new frmAutoSavingsToLoans();
            frm.ShowDialog();
        }

        private void buttonItem43_Click_2(object sender, EventArgs e)
        {
            frmLoanProcessingType frm = new frmLoanProcessingType();
            frm.ShowDialog();
        }

        private void buttonItem46_Click_2(object sender, EventArgs e)
        {
            frmLoanInsuranceType frm = new frmLoanInsuranceType();
            frm.ShowDialog();
        }

        private void records_Click(object sender, EventArgs e)
        {
            frmInvestorAccount frm = new frmInvestorAccount();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void invetory_Click(object sender, EventArgs e)
        {
            frmLoanApplication frm = new frmLoanApplication();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem24_Click_1(object sender, EventArgs e)
        {
            frmMemberRegistration frm = new frmMemberRegistration();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem91_Click(object sender, EventArgs e)
        {
            frmLoanApplication frm = new frmLoanApplication();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            FrmLoanApplicationPayment frm = new FrmLoanApplicationPayment();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem93_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmLoanInsuranceFeesPayment frm = new frmLoanInsuranceFeesPayment();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {
            FrmLoanIssue frm = new FrmLoanIssue();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            frmEXpensesLoanProcess frm = new frmEXpensesLoanProcess();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void buttonItem14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmPaymentSchedule frm = new frmPaymentSchedule();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmRepaymentForm frm = new frmRepaymentForm();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmRepaymentEarlySettlement frm = new frmRepaymentEarlySettlement();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            FrmLoanReschedule frm = new FrmLoanReschedule();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            FrmLoanTopup frm = new FrmLoanTopup();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void accounts_Click(object sender, EventArgs e)
        {
            FrmLoanWriteOff frm = new FrmLoanWriteOff();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void reports_Click(object sender, EventArgs e)
        {
            FrmLoanRecovery frm = new FrmLoanRecovery();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem50_Click(object sender, EventArgs e)
        {
            FrmExternalLoan frm = new FrmExternalLoan();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem34_Click_1(object sender, EventArgs e)
        {
            frmExternalPaymentSchedule frm = new frmExternalPaymentSchedule();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem70_Click(object sender, EventArgs e)
        {
            frmExternalLoanFineFeesPayment frm = new frmExternalLoanFineFeesPayment();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem38_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem35_Click_1(object sender, EventArgs e)
        {
            frmInvestorAccount frm = new frmInvestorAccount();
            frm.label33.Text = User.Text;
            frm.label34.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem36_Click_1(object sender, EventArgs e)
        {
            frmInvestorSavings frm = new frmInvestorSavings();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {
            frmInvestorAccountTypes frm = new frmInvestorAccountTypes();
            frm.ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAccountRecords frm = new FrmAccountRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSavingsRecord frm = new FrmSavingsRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanRecords frm = new FrmLoanRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmExternalBorrowingRecord frm = new FrmExternalBorrowingRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInvestorRecords frm = new FrmInvestorRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInflowsRecords frm = new FrmInflowsRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOutflowsRecords frm = new FrmOutflowsRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHRRecords frm = new FrmHRRecords();
            frm.label1.Text = User.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }
        string collateralsuccess = "";
        private void landTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLandTitle frm = new FrmLandTitle();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label15.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kibanjaPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKibanjaProperty frm = new FrmKibanjaProperty();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label15.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalaryEarners frm = new FrmSalaryEarners();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label13.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRide frm = new FrmRide();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label9.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void businessCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBusiness frm = new FrmBusiness();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label14.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void assetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssets frm = new FrmAssets();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            collateralsuccess = frm.label10.Text;
            if (collateralsuccess == "1")
            {
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonItem61_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem42_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAccountReports frm = new FrmAccountReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem44_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSavingsReport frm = new FrmSavingsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem45_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanReports frm = new FrmLoanReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem47_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmExternalBorrowingReport frm = new FrmExternalBorrowingReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem48_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInvestorReports frm = new FrmInvestorReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem49_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInflowsReports frm = new FrmInflowsReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem51_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOutflowsReports frm = new FrmOutflowsReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem56_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHumanResourceReports frm = new FrmHumanResourceReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem58_Click_1(object sender, EventArgs e)
        {
            frmGeneralReport frm = new frmGeneralReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem57_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmTransactionsReports frm = new FrmTransactionsReports();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void ribbonTabItem1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default["currentselection"] = "ribbonTabItem1";
            Properties.Settings.Default.Save();
        }

        private void buttonItem62_Click(object sender, EventArgs e)
        {
            FrmWithdraw frm = new FrmWithdraw();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem63_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem64_Click(object sender, EventArgs e)
        {
            frmSavingsApproval frm = new frmSavingsApproval();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
            
        }

        private void buttonItem65_Click_1(object sender, EventArgs e)
        {
            frmWithdrawApproval frm = new frmWithdrawApproval();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem66_Click(object sender, EventArgs e)
        {
            FrmLoanScheduleTrial frm = new FrmLoanScheduleTrial();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem67_Click(object sender, EventArgs e)
        {
            frmExternalLoanManual frm = new frmExternalLoanManual();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem68_Click(object sender, EventArgs e)
        {
            FrmInvestorWithdraw frm = new FrmInvestorWithdraw();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem71_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void buttonItem78_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmChairperson frm = new frmChairperson();
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void buttonItem79_Click(object sender, EventArgs e)
        {
            frmLogins frm = new frmLogins();
            frm.ShowDialog();
        }

        private void buttonItem38_Click_2(object sender, EventArgs e)
        {
            frmInvestorSavingsApproval frm = new frmInvestorSavingsApproval();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem64_Click_1(object sender, EventArgs e)
        {
            FrmInvestorWithdrawApproval frm = new FrmInvestorWithdrawApproval();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem74_Click(object sender, EventArgs e)
        {
            FrmInvestorWithdrawApprovalFinal frm = new FrmInvestorWithdrawApprovalFinal();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void buttonItem80_Click(object sender, EventArgs e)
        {
            FrmInvestorWithdrawIssue frm = new FrmInvestorWithdrawIssue();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }
        SqlDataReader rdr = null;
        private void frmMainMenu_Shown(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select PaymentDate from RepaymentSchedule where BalanceExist >0 and PaymentDate <= @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = registrationdate.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int pendinginvoice = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select Count(PaymentDate) from RepaymentSchedule where BalanceExist >0 and PaymentDate <= @date1 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = registrationdate.Value.Date;
                    pendinginvoice = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(2000, "Reminder", "You have " + pendinginvoice + " Loans Payable today", ToolTipIcon.Info);
                   // notifyIcon1.Click += new System.EventHandler(NotifyIcon1_Click);
                }
                else
                {

                }
                //notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(2000,"warning you","Try to start again",ToolTipIcon.Info);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select NextDepositDate from InvestorSavings where NextDepositDate <= @date1", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "NextDepositDate").Value = registrationdate.Value.Date;
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int pendinginvoice = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select Count(NextDepositDate) from InvestorSavings where  NextDepositDate <= @date1 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "NextDepositDate").Value = registrationdate.Value.Date;
                    pendinginvoice = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    notifyIcon2.Visible = true;
                    notifyIcon2.ShowBalloonTip(2000, "Reminder", pendinginvoice + " investment Deposits are Expected today", ToolTipIcon.Info);
                    // notifyIcon1.Click += new System.EventHandler(NotifyIcon1_Click);
                }
                else
                {

                }
                //notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(2000,"warning you","Try to start again",ToolTipIcon.Info);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem92_Click(object sender, EventArgs e)
        {
            frmLoanFines frm = new frmLoanFines();
            frm.label7.Text = User.Text;
            frm.label12.Text = UserType.Text;
            frm.ShowDialog();
        }
    }
}