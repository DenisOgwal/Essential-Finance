using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http;
namespace Banking_System
{
    public partial class frmSynchronize : Form
    {
        ConnectionString cs = new ConnectionString();
        mysqlconnection mycs = new mysqlconnection();
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        public frmSynchronize()
        {
            InitializeComponent();
        }

        private void enablecheckbox()
        {
            checkBox1.Enabled = true; checkBox2.Enabled = true; 
            checkBox3.Enabled = true; checkBox6.Enabled = true; 
            checkBox8.Enabled = true; 
            checkBox9.Enabled = true;  buttonX1.Enabled = true;

        }
        private void disablecheckbox()
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false; checkBox8.Enabled = false; 
            checkBox3.Enabled = false; checkBox9.Enabled = false; 
            checkBox6.Enabled = false; buttonX1.Enabled = false;
        }
        private void frmSynchronize_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowssa = 0;
            DataTable dtsa = new DataTable();
            string rowcountsa = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(LoanID) FROM Loan WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountsa = cmd.ExecuteScalar().ToString();
            countrowssa = Convert.ToInt32(rowcountsa);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Loan WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsa.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsa.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string loanid = drsa["LoanID"].ToString().Trim();
                        string accountno = drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string servicingperiod = drsa["ServicingPeriod"].ToString().Trim();
                        string repaymentinterval = drsa["RepaymentInterval"].ToString().Trim();
                        string loanamount = drsa["LoanAmount"].ToString().Trim();
                        string interest = drsa["Interest"].ToString().Trim();
                        string collateral = drsa["Collateral"].ToString().Trim();
                        string collateralvalue = drsa["CollateralValue"].ToString().Trim();
                        string refereename = drsa["RefereeName"].ToString().Trim();
                        string refereetel = drsa["RefereeTel"].ToString().Trim();
                        string refereeaddress = drsa["RefereeAddress"].ToString().Trim();
                        string refereerelationship = drsa["RefereeRelationship"].ToString().Trim();
                        string applicationdate = drsa["ApplicationDate"].ToString().Trim();
                        string registeredby= drsa["RegisteredBy"].ToString().Trim();
                        string issuetype = drsa["IssueType"].ToString().Trim();
                        string loantype = drsa["LoanType"].ToString().Trim();
                        string issueno = drsa["IssueNo"].ToString().Trim();
                        string intervals = drsa["Intervals"].ToString().Trim();
                        string clearance = drsa["Clearance"].ToString().Trim();
                        string maturitydate = drsa["MaturityDate"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/loans.php?loanid=" + loanid + "& accountno=" + accountno + "&accountname=" + accountname + "&servicingperiod=" + servicingperiod + "&branch=" + branch + "&repaymentinterval=" + repaymentinterval + "&loanamount=" + loanamount + "&interest=" + interest + "&collateral=" + collateral + "&collateralvalue=" + collateralvalue + "&refrereename=" + refereename + "&refereetel=" + refereetel + "&refereeaddress=" + refereeaddress + "&refereerelationship=" + refereerelationship + "&applicationdate=" + applicationdate + "&registeredby=" + registeredby + "&issuetype=" + issuetype + "&loantype=" + loantype + "&issueno=" + issueno + "&intervals=" + intervals + "&clearance=" + clearance + "&maturitydate=" + maturitydate + "&ids=" + ids, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();   
                    }
                }
                rdr.Dispose();
                dtsa.Clear();

                int countrowseq = 0;
                DataTable dteq = new DataTable();
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery4sa1 = "SELECT * FROM RepaymentSchedule WHERE UploadStatus='Pending'";
                    cmd = new SqlCommand(inquery4sa1, con);
                    rdr = cmd.ExecuteReader();
                    dteq.Load(rdr);
                    rdr.Close();
                    con.Close();

                    foreach (DataRow drsa in dteq.Rows)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            string loanid = drsa["LoanID"].ToString().Trim();
                            string accountno = drsa["AccountNumber"].ToString().Trim();
                            string accountname = drsa["AccountName"].ToString().Trim();
                            string ammountpay = drsa["AmmountPay"].ToString().Trim();
                            string interest = drsa["Interest"].ToString().Trim();
                            string totalammount = drsa["TotalAmmount"].ToString().Trim();
                            string paymentdate = drsa["PaymentDate"].ToString().Trim();
                            string months = drsa["Months"].ToString().Trim();
                            string balanceexist = drsa["BalanceExist"].ToString().Trim();
                            string beginningbalance = drsa["BeginningBalance"].ToString().Trim();
                            string paymentstatus = drsa["PaymentStatus"].ToString().Trim();
                            string fines = drsa["Fines"].ToString().Trim();
                            string waivered = drsa["Waivered"].ToString().Trim();
                            string actualpaymentdate = drsa["ActualPaymentDate"].ToString().Trim();
                            string ids = drsa["ID"].ToString().Trim();
                            string branch = drsa["InsBranch"].ToString().Trim();
                            string mycon = mycs.MysqlDBConn;
                            var response = httpClient.PostAsync(mycon + "/repaymentschedule.php?ids=" + ids + "&fines=" + fines + "&waivered=" + waivered + "&actualpaymentdate=" + actualpaymentdate + "&loanid=" + loanid + "&accountno=" +accountno + "& accountname=" + accountname + "&ammountpay=" + ammountpay + "&interest=" + interest + "&totalammount=" + totalammount + "&paymentdate=" + paymentdate + "&paymentstatus=" + paymentstatus + "&months=" + months + "&fines=" + fines + "&balanceexist=" + balanceexist + "&beginningbalance=" + beginningbalance + "&branch=" + branch, new StringContent(""));
                            response.Wait();
                            string content = response.Result.StatusCode.ToString();
                        }
                    }
                    rdr.Dispose();
                    dteq.Clear();
                  
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
            MessageBox.Show("Successfuly Uploaded " + rowcountsa + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Loan SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE RepaymentSchedule SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowsbf = 0;
            DataTable dtbf = new DataTable();
            string rowcountbf = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM Savings WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountbf = cmd.ExecuteScalar().ToString();
            countrowsbf = Convert.ToInt32(rowcountbf);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Savings WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtbf.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtbf.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string savingsid = drsa["SavingsID"].ToString().Trim();
                        string accountno= drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string cashiername = drsa["CashierName"].ToString().Trim();
                        string date= drsa["Date"].ToString().Trim();
                        string deposit = drsa["Deposit"].ToString().Trim();
                        string transaction = drsa["Transactions"].ToString().Trim();
                        string accountbalance = drsa["Accountbalance"].ToString().Trim();
                        string modeofpayment = drsa["ModeOfPayment"].ToString().Trim();
                        string depositdate = drsa["DepositDate"].ToString().Trim();
                        string debit = drsa["Debit"].ToString().Trim();
                        string credit = drsa["Credit"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/savings.php?savingsid=" + savingsid + "&accountno=" + accountno + "&accountname=" + accountname + "&cashiername=" + cashiername + "&date=" + date + "&deposit=" + deposit + "&transaction=" + transaction + "&accountbalance=" + accountbalance + "&modeofpayment=" + modeofpayment + "&depositdate=" + depositdate + "&debit=" + debit + "&ids=" + ids + "&credit=" + credit + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtbf.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowsbf + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Savings SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowssp = 0;
            DataTable dtsp = new DataTable();
            DataTable dtsp1 = new DataTable();
            DataTable dtsp2 = new DataTable();
            string rowcountsp = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM InvestmentAppreciation WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountsp = cmd.ExecuteScalar().ToString();
            countrowssp = Convert.ToInt32(rowcountsp);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa2 = "SELECT * FROM InvestmentSchedule WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa2, con);
                rdr = cmd.ExecuteReader();
                dtsp2.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa2 in dtsp2.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa2["ID"].ToString().Trim();
                        string investmentid = drsa2["InvestmentID"].ToString().Trim();
                        string accountno = drsa2["AccountNumber"].ToString().Trim();
                        string accountname = drsa2["AccountName"].ToString().Trim();
                        string ammountpay = drsa2["AmmountPay"].ToString().Trim();
                        string interestearned = drsa2["InterestEarned"].ToString().Trim();
                        string cumulation = drsa2["Cumulation"].ToString().Trim();
                        string paymentdate = drsa2["PaymentDate"].ToString().Trim();
                        string months = drsa2["Months"].ToString().Trim();
                        string accrualmonths = drsa2["AccrualMonths"].ToString().Trim();
                        string paymentstatus = drsa2["PaymentStatus"].ToString().Trim();
                        string branch = drsa2["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investorschedule.php?ids=" + ids + "&investmentid=" + investmentid + "&accountno=" + accountno + "&accountname=" + accountname + "&ammountpay=" + ammountpay + "&interestearned=" + interestearned + "&cumulation=" + cumulation + "&paymentdate=" + paymentdate + "&months=" + months + "&accrualmonths=" + accrualmonths + "&paymentstatus=" + paymentstatus + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa1 = "SELECT * FROM InvestorSavings WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa1, con);
                rdr = cmd.ExecuteReader();
                dtsp1.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa1 in dtsp1.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa1["ID"].ToString().Trim();
                        string savingsid = drsa1["SavingsID"].ToString().Trim();
                        string cashiername = drsa1["CashierName"].ToString().Trim();
                        string accountno = drsa1["AccountNo"].ToString().Trim();
                        string accountname = drsa1["AccountName"].ToString().Trim();
                        string date = drsa1["Date"].ToString().Trim();
                        string deposit = drsa1["Deposit"].ToString().Trim();
                        string transactions = drsa1["Transactions"].ToString().Trim();
                        string accountbalance = drsa1["Accountbalance"].ToString().Trim();
                        string submittedby = drsa1["SubmittedBy"].ToString().Trim();
                        string modeofpayment = drsa1["ModeOfPayment"].ToString().Trim();
                        string interestrate = drsa1["InterestRate"].ToString().Trim();
                        string maturityperiod = drsa1["MaturityPeriod"].ToString().Trim();
                        string otherMaturitydate = drsa1["OtherMaturityDate"].ToString().Trim();
                        string appreciated = drsa1["Appreciated"].ToString().Trim();
                        string investmentplan = drsa1["InvestmentPlan"].ToString().Trim();
                        string depositinterval = drsa1["DepositInterval"].ToString().Trim();
                        string branch = drsa1["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investorsavings.php?interestrate=" + interestrate + "&ids=" + ids + "&savingsid=" + savingsid + "&cashiername=" + cashiername + "&accountno=" + accountno + "&accountname=" + accountname + "&date=" + date + "&deposit=" + deposit + "&transactions=" + transactions + "&accountbalance=" + accountbalance + "&submittedby=" + submittedby + "&modeofpayment=" + modeofpayment + "&maturityperiod=" + maturityperiod + "&othermaturitydate=" + otherMaturitydate + "&appreciated=" + appreciated + "&investmentplan=" + investmentplan + "&depositinterval=" + depositinterval + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM InvestmentAppreciation WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsp.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsp.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa["ID"].ToString().Trim();
                        string savingsid = drsa["SavingsID"].ToString().Trim();
                        string depositid = drsa["DepositID"].ToString().Trim();
                        string accountno = drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string date = drsa["Date"].ToString().Trim();
                        string deposit = drsa["Deposit"].ToString().Trim();
                        string appreciationamount= drsa["AppreciationAmount"].ToString().Trim();
                        string accountbalance = drsa["Accountbalance"].ToString().Trim();
                        string nextappreciationdate = drsa["NextAppreciationDate"].ToString().Trim();
                        string paidout = drsa["PaidOut"].ToString().Trim();
                        string interestrate = drsa["InterestRate"].ToString().Trim();
                        string interval =drsa["Interval"].ToString().Trim();
                        int debit = 0; int credit = 0;
                        if (drsa["Debit"] == DBNull.Value){debit = 0;}
                        else{debit = Convert.ToInt32(drsa["Debit"]);}
                        if (drsa["Credit"] == DBNull.Value) {credit = 0; }
                        else {credit = Convert.ToInt32(drsa["Credit"]); }

                        string appreciated = drsa["Appreciated"].ToString().Trim();
                        string paymentmode = drsa["PaymentMode"].ToString().Trim();
                        string installment = drsa["Installment"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investmentappreciation.php?ids=" + ids + "&savingsid=" + savingsid + "&depositid=" + depositid + "&accountno=" + accountno + "&accountname=" + accountname + "&date=" + date + "&deposit=" + deposit + "&appreciationamount=" + appreciationamount + "&accountbalance=" + accountbalance + "&nextappreciationdate=" + nextappreciationdate + "&paidout=" + paidout + "&interestrate=" + interestrate + "&interval=" + interval + "&debit=" + debit + "&credit=" + credit + "&appreciated=" + appreciated + "&paymentmode=" + paymentmode + "&installment=" + installment + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowssp + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestmentAppreciation SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestmentSchedule SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestorAccount SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker6.RunWorkerAsync();
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowspr = 0;
            DataTable dtpr = new DataTable();
            string rowcountpr = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM LoanRepayment WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountpr = cmd.ExecuteScalar().ToString();
            countrowspr = Convert.ToInt32(rowcountpr);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM LoanRepayment WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtpr.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpr.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string repaymentid = drsa["RepaymentID"].ToString().Trim();
                        string ammountpaid = drsa["AmmountPaid"].ToString().Trim();
                        string totalammount = drsa["TotalAmmount"].ToString().Trim();
                        string balance = drsa["Balance"].ToString().Trim();
                        string repaymonths = drsa["RepayMonths"].ToString().Trim();
                        string cashierid = drsa["CashierID"].ToString().Trim();
                        string cashiername = drsa["CashierName"].ToString().Trim();
                        string loanid= drsa["LoanID"].ToString().Trim();
                        string memberid = drsa["MemberID"].ToString().Trim();
                        string membername = drsa["MemberName"].ToString().Trim();
                        string repaymentdate = drsa["Repaymentdate"].ToString().Trim();
                        string year = drsa["Year"].ToString().Trim();
                        string months = drsa["Months"].ToString().Trim();
                        string interest = drsa["Interest"].ToString().Trim();
                        string modeofpayment = drsa["ModeOfPayment"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/loanrepayment.php?repaymentid=" + repaymentid + "&ammountpaid=" + ammountpaid + "&totalammount=" + totalammount + "&balance=" + balance + "&repaymonths=" + repaymonths + "&cashierid=" + cashierid + "&cashiername=" + cashiername + "&loanid=" + loanid + "&memberid=" + memberid + "&membername=" + membername + "&repaymentdate=" + repaymentdate + "&year=" + year + "&months=" + months + "&interest=" + interest + "&modeofpayment=" + modeofpayment + "&branch=" + branch+ "&ids="+ids, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpr.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowspr + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE LoanRepayment SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker7.RunWorkerAsync();
        }

        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowssb = 0;
            DataTable dtsb = new DataTable();
            string rowcountsb = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM Fines WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountsb = cmd.ExecuteScalar().ToString();
            countrowssb = Convert.ToInt32(rowcountsb);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Fines WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsb.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsb.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string paymentid = drsa["PaymentID"].ToString().Trim();
                        string memberid = drsa["MemberID"].ToString().Trim();
                        string year = drsa["Year"].ToString().Trim();
                        string months = drsa["Months"].ToString().Trim();
                        string date = drsa["Date"].ToString().Trim();
                        string finefee = drsa["FineFee"].ToString().Trim();
                        string cashiername = drsa["CashierName"].ToString().Trim();
                        string reason = drsa["Reason"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/fines.php?paymentid=" + paymentid + "&memberid=" + memberid + "&year=" + year + "&months=" + months + "&date=" + date + "&finefee=" + finefee + "&cashiername=" + cashiername + "&reason=" + reason + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsb.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowssb + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Fines SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker8.RunWorkerAsync();
        }

        private void backgroundWorker8_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowspp = 0;
            DataTable dtpp = new DataTable();
            string rowcountpp = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM InvestorAccount WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountpp = cmd.ExecuteScalar().ToString();
            countrowspp = Convert.ToInt32(rowcountpp);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM InvestorAccount WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtpp.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpp.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string accountno = drsa["AccountNumber"].ToString().Trim();
                        string accountnames = drsa["AccountNames"].ToString().Trim();
                        string registrationdate = drsa["RegistrationDate"].ToString().Trim();
                        string gender = drsa["Gender"].ToString().Trim();
                        string dob = drsa["DOB"].ToString().Trim();
                        string maritalstatus = drsa["MaritalStatus"].ToString().Trim();
                        string nationality = drsa["Nationality"].ToString().Trim();
                        string nationalitystatus = drsa["NationalityStatus"].ToString().Trim();
                        string idform = drsa["IDForm"].ToString().Trim();
                        string clientid = drsa["ClientID"].ToString().Trim();
                        string contactno = drsa["ContactNo"].ToString().Trim();
                        string contactno1 = drsa["ContactNo1"].ToString().Trim();
                        string officeno = drsa["OfficeNo"].ToString().Trim();
                        string email = drsa["Email"].ToString().Trim();
                        string physicaladdress = drsa["PhysicalAddress"].ToString().Trim();
                        string postaladdress = drsa["PostalAddress"].ToString().Trim();
                        string bankname = drsa["BankName"].ToString().Trim();
                        string bankaccountname = drsa["BankAccountName"].ToString().Trim();
                        string bankaccountnumber = drsa["BankAccountNumber"].ToString().Trim();
                        string nokname = drsa["NOKName"].ToString().Trim();
                        string nokcontactno = drsa["NOKContactNo"].ToString().Trim();
                        string nokaddreess = drsa["NOKAddress"].ToString().Trim();
                        string nokrelationship = drsa["NOKRelationship"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investoraccountregistration.php?ids=" + ids + "&accountno=" + accountno + "&accountnames=" + accountnames + "&registrationdate=" + registrationdate + "&maritalstatus=" + maritalstatus + "&nationality=" + nationality + "&nationalitystatus=" + nationalitystatus + "&gender=" + gender + "&dob=" + dob + "&idform=" + idform + "&clientid=" + clientid + "&contactno=" + contactno + "&contactno1=" + contactno1 + "&officeno=" + officeno + "&email=" + email + "&physicaladdress=" + physicaladdress + "&postaladdress=" + postaladdress + "&bankname=" + bankname + "&bankaccountname=" + bankaccountname + "&bankaccountnumber=" + bankaccountnumber + "&nokname=" + nokname + "&nokcontactno=" + nokcontactno + "&nokaddreess=" + nokaddreess + "&nokrelationship=" + nokrelationship + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpp.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowspp + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestorAccount SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker8_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker9.RunWorkerAsync();
        }

        private void backgroundWorker9_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowspp = 0;
            DataTable dtpp = new DataTable();
            string rowcountpp = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM Account WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountpp = cmd.ExecuteScalar().ToString();
            countrowspp = Convert.ToInt32(rowcountpp);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Account WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtpp.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpp.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string accountno = drsa["AccountNumber"].ToString().Trim();
                        string accountnames = drsa["AccountNames"].ToString().Trim();
                        string registrationdate = drsa["RegistrationDate"].ToString().Trim();
                        string gender = drsa["Gender"].ToString().Trim();
                        string dob = drsa["DOB"].ToString().Trim();
                        string maritalstatus = drsa["MaritalStatus"].ToString().Trim();
                        string nationality = drsa["Nationality"].ToString().Trim();
                        string nationalitystatus = drsa["NationalityStatus"].ToString().Trim();
                        string idform = drsa["IDForm"].ToString().Trim();
                        string clientid = drsa["ClientID"].ToString().Trim();
                        string contactno = drsa["ContactNo"].ToString().Trim();
                        string contactno1 = drsa["ContactNo1"].ToString().Trim();
                        string officeno = drsa["OfficeNo"].ToString().Trim();
                        string email = drsa["Email"].ToString().Trim();
                        string physicaladdress = drsa["PhysicalAddress"].ToString().Trim();
                        string postaladdress = drsa["PostalAddress"].ToString().Trim();
                        string bankname = drsa["BankName"].ToString().Trim();
                        string bankaccountname = drsa["BankAccountName"].ToString().Trim();
                        string bankaccountnumber = drsa["BankAccountNumber"].ToString().Trim();
                        string nokname = drsa["NOKName"].ToString().Trim();
                        string nokcontactno = drsa["NOKContactNo"].ToString().Trim();
                        string nokaddreess = drsa["NOKAddress"].ToString().Trim();
                        string nokrelationship = drsa["NOKRelationship"].ToString().Trim();
                        string designation = drsa["Designation"].ToString().Trim();
                        string employerName = drsa["EmployerName"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/accountregistration.php?ids=" + ids + "&accountno=" + accountno + "&accountnames=" + accountnames + "&registrationdate=" + registrationdate + "&maritalstatus=" + maritalstatus + "&nationality=" + nationality + "&nationalitystatus=" + nationalitystatus + "&gender=" + gender + "&dob=" + dob + "&idform=" + idform + "&clientid=" + clientid + "&contactno=" + contactno + "&contactno1=" + contactno1 + "&officeno=" + officeno + "&email=" + email + "&physicaladdress=" + physicaladdress + "&postaladdress=" + postaladdress + "&bankname=" + bankname + "&bankaccountname=" + bankaccountname + "&bankaccountnumber=" + bankaccountnumber + "&nokname=" + nokname + "&nokcontactno=" + nokcontactno + "&nokaddreess=" + nokaddreess + "&nokrelationship=" + nokrelationship + "&designation=" + designation + "&employerName=" + employerName + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpp.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowspp + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Account SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker9_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker10.RunWorkerAsync();
        }

        private void backgroundWorker10_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowssa = 0;
            DataTable dtsa = new DataTable();
            string rowcountsa = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(ID) FROM Sales WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountsa = cmd.ExecuteScalar().ToString();
            countrowssa = Convert.ToInt32(rowcountsa);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Sales WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsa.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsa.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string id = drsa["ID"].ToString().Trim();
                        string salesid = drsa["SalesID"].ToString().Trim();
                        string staffname = drsa["StaffName"].ToString().Trim();
                        string product = drsa["Product"].ToString().Trim();
                        string salesdate = drsa["SalesDate"].ToString().Trim();
                        string quantity = drsa["Quantity"].ToString().Trim();
                        string units = drsa["Units"].ToString().Trim();
                        string origin = drsa["Origin"].ToString().Trim();
                        string size = drsa["Size"].ToString().Trim();
                        string barcode = drsa["BarCode"].ToString().Trim();
                        string totalcost = drsa["TotalCost"].ToString().Trim();
                        string discount = drsa["Discount"].ToString().Trim();
                        string discountedcost = drsa["DiscountedCost"].ToString().Trim();
                        string balance = drsa["balance"].ToString().Trim();
                        string minorunits = drsa["MinorUnits"].ToString().Trim();
                        string purchaseprice = drsa["PurchasePrice"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/sales.php?id=" + id + "&salesid=" + salesid + "&staffname=" + staffname + "&product=" + product + "&salesdate=" + salesdate + "&quantity=" + quantity + "&units=" + units + "&origin=" + origin + "&size=" + size + "&barcode=" + barcode + "&totalcost=" + totalcost + "&discount=" + discount + "&discountedcost=" + discountedcost + "&balance=" + balance + "&minorunits=" + minorunits + "&purchaseprice=" + purchaseprice + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsa.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowssa + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Sales SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker10_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker11.RunWorkerAsync();
        }

        private void backgroundWorker11_DoWork(object sender, DoWorkEventArgs e)
        {
            int countrowssf = 0;
            DataTable dtsf = new DataTable();
            string rowcountsf = null;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String inquery3sa = "SELECT COUNT(SalesID) FROM SalesFinal WHERE UploadStatus='Pending'";
            cmd = new SqlCommand(inquery3sa, con);
            rowcountsf = cmd.ExecuteScalar().ToString();
            countrowssf = Convert.ToInt32(rowcountsf);
            con.Close();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM SalesFinal WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsf.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsf.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string salesid = drsa["SalesID"].ToString().Trim();
                        string employeename = drsa["employeename"].ToString().Trim();
                        string salesdate = drsa["salesdate"].ToString().Trim();
                        string paymentnote = drsa["paymentnote"].ToString().Trim();
                        string rbalance = drsa["Rbalance"].ToString().Trim();
                        string totalcost = drsa["TotalCost"].ToString().Trim();
                        string discount = drsa["Discount"].ToString().Trim();
                        string discountedcost = drsa["DiscountedTotal"].ToString().Trim();
                        string duepayment = drsa["Duepayment"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/salesfinal.php?salesid=" + salesid + "&employeename=" + employeename + "&salesdate=" + salesdate + "&rbalance=" + rbalance + "&totalcost=" + totalcost + "&discount=" + discount + "&discountedcost=" + discountedcost + "&duepayment=" + duepayment+ "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsf.Clear();
                MessageBox.Show("Successfuly Uploaded " + countrowssf + " Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE SalesFinal SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox1.Visible = false;
        }

        private void backgroundWorker11_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            disablecheckbox();
            Application.DoEvents();
            backgroundWorker12.RunWorkerAsync();
        }

        private void backgroundWorker12_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtsa = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Loan WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtsa.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsa.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string loanid = drsa["LoanID"].ToString().Trim();
                        string accountno = drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string servicingperiod = drsa["ServicingPeriod"].ToString().Trim();
                        string repaymentinterval = drsa["RepaymentInterval"].ToString().Trim();
                        string loanamount = drsa["LoanAmount"].ToString().Trim();
                        string interest = drsa["Interest"].ToString().Trim();
                        string collateral = drsa["Collateral"].ToString().Trim();
                        string collateralvalue = drsa["CollateralValue"].ToString().Trim();
                        string refereename = drsa["RefereeName"].ToString().Trim();
                        string refereetel = drsa["RefereeTel"].ToString().Trim();
                        string refereeaddress = drsa["RefereeAddress"].ToString().Trim();
                        string refereerelationship = drsa["RefereeRelationship"].ToString().Trim();
                        string applicationdate = drsa["ApplicationDate"].ToString().Trim();
                        string registeredby = drsa["RegisteredBy"].ToString().Trim();
                        string issuetype = drsa["IssueType"].ToString().Trim();
                        string loantype = drsa["LoanType"].ToString().Trim();
                        string issueno = drsa["IssueNo"].ToString().Trim();
                        string intervals = drsa["Intervals"].ToString().Trim();
                        string clearance = drsa["Clearance"].ToString().Trim();
                        string maturitydate = drsa["MaturityDate"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/loans.php?loanid=" + loanid + "& accountno=" + accountno + "&accountname=" + accountname + "&servicingperiod=" + servicingperiod + "&branch=" + branch + "&repaymentinterval=" + repaymentinterval + "&loanamount=" + loanamount + "&interest=" + interest + "&collateral=" + collateral + "&collateralvalue=" + collateralvalue + "&refrereename=" + refereename + "&refereetel=" + refereetel + "&refereeaddress=" + refereeaddress + "&refereerelationship=" + refereerelationship + "&applicationdate=" + applicationdate + "&registeredby=" + registeredby + "&issuetype=" + issuetype + "&loantype=" + loantype + "&issueno=" + issueno + "&intervals=" + intervals + "&clearance=" + clearance + "&maturitydate=" + maturitydate + "&ids=" + ids, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsa.Clear();

                DataTable dteq = new DataTable();
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery4sa1 = "SELECT * FROM RepaymentSchedule WHERE UploadStatus='Pending'";
                    cmd = new SqlCommand(inquery4sa1, con);
                    rdr = cmd.ExecuteReader();
                    dteq.Load(rdr);
                    rdr.Close();
                    con.Close();

                    foreach (DataRow drsa in dteq.Rows)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            string loanid = drsa["LoanID"].ToString().Trim();
                            string accountno = drsa["AccountNumber"].ToString().Trim();
                            string accountname = drsa["AccountName"].ToString().Trim();
                            string ammountpay = drsa["AmmountPay"].ToString().Trim();
                            string interest = drsa["Interest"].ToString().Trim();
                            string totalammount = drsa["TotalAmmount"].ToString().Trim();
                            string paymentdate = drsa["PaymentDate"].ToString().Trim();
                            string months = drsa["Months"].ToString().Trim();
                            string balanceexist = drsa["BalanceExist"].ToString().Trim();
                            string beginningbalance = drsa["BeginningBalance"].ToString().Trim();
                            string paymentstatus = drsa["PaymentStatus"].ToString().Trim();
                            string fines = drsa["Fines"].ToString().Trim();
                            string waivered = drsa["Waivered"].ToString().Trim();
                            string actualpaymentdate = drsa["ActualPaymentDate"].ToString().Trim();
                            string ids = drsa["ID"].ToString().Trim();
                            string branch = drsa["InsBranch"].ToString().Trim();
                            string mycon = mycs.MysqlDBConn;
                            var response = httpClient.PostAsync(mycon + "/repaymentschedule.php?ids=" + ids + "&fines=" + fines + "&waivered=" + waivered + "&actualpaymentdate=" + actualpaymentdate + "&loanid=" + loanid + "&accountno=" + accountno + "& accountname=" + accountname + "&ammountpay=" + ammountpay + "&interest=" + interest + "&totalammount=" + totalammount + "&paymentdate=" + paymentdate + "&paymentstatus=" + paymentstatus + "&months=" + months + "&fines=" + fines + "&balanceexist=" + balanceexist + "&beginningbalance=" + beginningbalance + "&branch=" + branch, new StringContent(""));
                            response.Wait();
                            string content = response.Result.StatusCode.ToString();
                        }
                    }
                    rdr.Dispose();
                    dteq.Clear();

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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Loan SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE RepaymentSchedule SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            DataTable dtbf = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Savings WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtbf.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtbf.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string savingsid = drsa["SavingsID"].ToString().Trim();
                        string accountno = drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string cashiername = drsa["CashierName"].ToString().Trim();
                        string date = drsa["Date"].ToString().Trim();
                        string deposit = drsa["Deposit"].ToString().Trim();
                        string transaction = drsa["Transactions"].ToString().Trim();
                        string accountbalance = drsa["Accountbalance"].ToString().Trim();
                        string modeofpayment = drsa["ModeOfPayment"].ToString().Trim();
                        string depositdate = drsa["DepositDate"].ToString().Trim();
                        string debit = drsa["Debit"].ToString().Trim();
                        string credit = drsa["Credit"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/savings.php?savingsid=" + savingsid + "&accountno=" + accountno + "&accountname=" + accountname + "&cashiername=" + cashiername + "&date=" + date + "&deposit=" + deposit + "&transaction=" + transaction + "&accountbalance=" + accountbalance + "&modeofpayment=" + modeofpayment + "&depositdate=" + depositdate + "&debit=" + debit + "&ids=" + ids + "&credit=" + credit + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtbf.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Savings SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            DataTable dtsp = new DataTable();
            DataTable dtsp1 = new DataTable();
            DataTable dtsp2 = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa2 = "SELECT * FROM InvestmentSchedule WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa2, con);
                rdr = cmd.ExecuteReader();
                dtsp2.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa2 in dtsp2.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa2["ID"].ToString().Trim();
                        string investmentid = drsa2["InvestmentID"].ToString().Trim();
                        string accountno = drsa2["AccountNumber"].ToString().Trim();
                        string accountname = drsa2["AccountName"].ToString().Trim();
                        string ammountpay = drsa2["AmmountPay"].ToString().Trim();
                        string interestearned = drsa2["InterestEarned"].ToString().Trim();
                        string cumulation = drsa2["Cumulation"].ToString().Trim();
                        string paymentdate = drsa2["PaymentDate"].ToString().Trim();
                        string months = drsa2["Months"].ToString().Trim();
                        string accrualmonths = drsa2["AccrualMonths"].ToString().Trim();
                        string paymentstatus = drsa2["PaymentStatus"].ToString().Trim();
                        string branch = drsa2["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investorschedule.php?ids=" + ids + "&investmentid=" + investmentid + "&accountno=" + accountno + "&accountname=" + accountname + "&ammountpay=" + ammountpay + "&interestearned=" + interestearned + "&cumulation=" + cumulation + "&paymentdate=" + paymentdate + "&months=" + months + "&accrualmonths=" + accrualmonths + "&paymentstatus=" + paymentstatus + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa1 = "SELECT * FROM InvestorSavings WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa1, con);
                rdr = cmd.ExecuteReader();
                dtsp1.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa1 in dtsp1.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa1["ID"].ToString().Trim();
                        string savingsid = drsa1["SavingsID"].ToString().Trim();
                        string cashiername = drsa1["CashierName"].ToString().Trim();
                        string accountno = drsa1["AccountNo"].ToString().Trim();
                        string accountname = drsa1["AccountName"].ToString().Trim();
                        string date = drsa1["Date"].ToString().Trim();
                        string deposit = drsa1["Deposit"].ToString().Trim();
                        string transactions = drsa1["Transactions"].ToString().Trim();
                        string accountbalance = drsa1["Accountbalance"].ToString().Trim();
                        string submittedby = drsa1["SubmittedBy"].ToString().Trim();
                        string modeofpayment = drsa1["ModeOfPayment"].ToString().Trim();
                        string interestrate = drsa1["InterestRate"].ToString().Trim();
                        string maturityperiod = drsa1["MaturityPeriod"].ToString().Trim();
                        string otherMaturitydate = drsa1["OtherMaturityDate"].ToString().Trim();
                        string appreciated = drsa1["Appreciated"].ToString().Trim();
                        string investmentplan = drsa1["InvestmentPlan"].ToString().Trim();
                        string depositinterval = drsa1["DepositInterval"].ToString().Trim();
                        string branch = drsa1["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investorsavings.php?interestrate=" + interestrate + "&ids=" + ids + "&savingsid=" + savingsid + "&cashiername=" + cashiername + "&accountno=" + accountno + "&accountname=" + accountname + "&date=" + date + "&deposit=" + deposit + "&transactions=" + transactions + "&accountbalance=" + accountbalance + "&submittedby=" + submittedby + "&modeofpayment=" + modeofpayment + "&maturityperiod=" + maturityperiod + "&othermaturitydate=" + otherMaturitydate + "&appreciated=" + appreciated + "&investmentplan=" + investmentplan + "&depositinterval=" + depositinterval + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa6 = "SELECT * FROM InvestmentAppreciation WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa6, con);
                rdr = cmd.ExecuteReader();
                dtsp.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtsp.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string ids = drsa["ID"].ToString().Trim();
                        string savingsid = drsa["SavingsID"].ToString().Trim();
                        string depositid = drsa["DepositID"].ToString().Trim();
                        string accountno = drsa["AccountNo"].ToString().Trim();
                        string accountname = drsa["AccountName"].ToString().Trim();
                        string date = drsa["Date"].ToString().Trim();
                        string deposit = drsa["Deposit"].ToString().Trim();
                        string appreciationamount = drsa["AppreciationAmount"].ToString().Trim();
                        string accountbalance = drsa["Accountbalance"].ToString().Trim();
                        string nextappreciationdate = drsa["NextAppreciationDate"].ToString().Trim();
                        string paidout = drsa["PaidOut"].ToString().Trim();
                        string interestrate = drsa["InterestRate"].ToString().Trim();
                        string interval = drsa["Interval"].ToString().Trim();
                        int debit = 0; int credit = 0;
                        if (drsa["Debit"] == DBNull.Value) { debit = 0; }
                        else { debit = Convert.ToInt32(drsa["Debit"]); }
                        if (drsa["Credit"] == DBNull.Value) { credit = 0; }
                        else { credit = Convert.ToInt32(drsa["Credit"]); }

                        string appreciated = drsa["Appreciated"].ToString().Trim();
                        string paymentmode = drsa["PaymentMode"].ToString().Trim();
                        string installment = drsa["Installment"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investmentappreciation.php?ids=" + ids + "&savingsid=" + savingsid + "&depositid=" + depositid + "&accountno=" + accountno + "&accountname=" + accountname + "&date=" + date + "&deposit=" + deposit + "&appreciationamount=" + appreciationamount + "&accountbalance=" + accountbalance + "&nextappreciationdate=" + nextappreciationdate + "&paidout=" + paidout + "&interestrate=" + interestrate + "&interval=" + interval + "&debit=" + debit + "&credit=" + credit + "&appreciated=" + appreciated + "&paymentmode=" + paymentmode + "&installment=" + installment + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtsp.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestmentAppreciation SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestmentSchedule SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestorSavings SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataTable dtpp6 = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa6 = "SELECT * FROM InvestorAccount WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa6, con);
                rdr = cmd.ExecuteReader();
                dtpp6.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpp6.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string accountno = drsa["AccountNumber"].ToString().Trim();
                        string accountnames = drsa["AccountNames"].ToString().Trim();
                        string registrationdate = drsa["RegistrationDate"].ToString().Trim();
                        string gender = drsa["Gender"].ToString().Trim();
                        string dob = drsa["DOB"].ToString().Trim();
                        string maritalstatus = drsa["MaritalStatus"].ToString().Trim();
                        string nationality = drsa["Nationality"].ToString().Trim();
                        string nationalitystatus = drsa["NationalityStatus"].ToString().Trim();
                        string idform = drsa["IDForm"].ToString().Trim();
                        string clientid = drsa["ClientID"].ToString().Trim();
                        string contactno = drsa["ContactNo"].ToString().Trim();
                        string contactno1 = drsa["ContactNo1"].ToString().Trim();
                        string officeno = drsa["OfficeNo"].ToString().Trim();
                        string email = drsa["Email"].ToString().Trim();
                        string physicaladdress = drsa["PhysicalAddress"].ToString().Trim();
                        string postaladdress = drsa["PostalAddress"].ToString().Trim();
                        string bankname = drsa["BankName"].ToString().Trim();
                        string bankaccountname = drsa["BankAccountName"].ToString().Trim();
                        string bankaccountnumber = drsa["BankAccountNumber"].ToString().Trim();
                        string nokname = drsa["NOKName"].ToString().Trim();
                        string nokcontactno = drsa["NOKContactNo"].ToString().Trim();
                        string nokaddreess = drsa["NOKAddress"].ToString().Trim();
                        string nokrelationship = drsa["NOKRelationship"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/investoraccountregistration.php?ids=" + ids + "&accountno=" + accountno + "&accountnames=" + accountnames + "&registrationdate=" + registrationdate + "&maritalstatus=" + maritalstatus + "&nationality=" + nationality + "&nationalitystatus=" + nationalitystatus + "&gender=" + gender + "&dob=" + dob + "&idform=" + idform + "&clientid=" + clientid + "&contactno=" + contactno + "&contactno1=" + contactno1 + "&officeno=" + officeno + "&email=" + email + "&physicaladdress=" + physicaladdress + "&postaladdress=" + postaladdress + "&bankname=" + bankname + "&bankaccountname=" + bankaccountname + "&bankaccountnumber=" + bankaccountnumber + "&nokname=" + nokname + "&nokcontactno=" + nokcontactno + "&nokaddreess=" + nokaddreess + "&nokrelationship=" + nokrelationship + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpp6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE InvestorAccount SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            DataTable dtpr = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM LoanRepayment WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtpr.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpr.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string repaymentid = drsa["RepaymentID"].ToString().Trim();
                        string ammountpaid = drsa["AmmountPaid"].ToString().Trim();
                        string totalammount = drsa["TotalAmmount"].ToString().Trim();
                        string balance = drsa["Balance"].ToString().Trim();
                        string repaymonths = drsa["RepayMonths"].ToString().Trim();
                        string cashierid = drsa["CashierID"].ToString().Trim();
                        string cashiername = drsa["CashierName"].ToString().Trim();
                        string loanid = drsa["LoanID"].ToString().Trim();
                        string memberid = drsa["MemberID"].ToString().Trim();
                        string membername = drsa["MemberName"].ToString().Trim();
                        string repaymentdate = drsa["Repaymentdate"].ToString().Trim();
                        string year = drsa["Year"].ToString().Trim();
                        string months = drsa["Months"].ToString().Trim();
                        string interest = drsa["Interest"].ToString().Trim();
                        string modeofpayment = drsa["ModeOfPayment"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/loanrepayment.php?repaymentid=" + repaymentid + "&ammountpaid=" + ammountpaid + "&totalammount=" + totalammount + "&balance=" + balance + "&repaymonths=" + repaymonths + "&cashierid=" + cashierid + "&cashiername=" + cashiername + "&loanid=" + loanid + "&memberid=" + memberid + "&membername=" + membername + "&repaymentdate=" + repaymentdate + "&year=" + year + "&months=" + months + "&interest=" + interest + "&modeofpayment=" + modeofpayment + "&branch=" + branch + "&ids=" + ids, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpr.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE LoanRepayment SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataTable dtpp3 = new DataTable();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery4sa = "SELECT * FROM Account WHERE UploadStatus='Pending'";
                cmd = new SqlCommand(inquery4sa, con);
                rdr = cmd.ExecuteReader();
                dtpp3.Load(rdr);
                rdr.Close();
                con.Close();

                foreach (DataRow drsa in dtpp3.Rows)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string accountno = drsa["AccountNumber"].ToString().Trim();
                        string accountnames = drsa["AccountNames"].ToString().Trim();
                        string registrationdate = drsa["RegistrationDate"].ToString().Trim();
                        string gender = drsa["Gender"].ToString().Trim();
                        string dob = drsa["DOB"].ToString().Trim();
                        string maritalstatus = drsa["MaritalStatus"].ToString().Trim();
                        string nationality = drsa["Nationality"].ToString().Trim();
                        string nationalitystatus = drsa["NationalityStatus"].ToString().Trim();
                        string idform = drsa["IDForm"].ToString().Trim();
                        string clientid = drsa["ClientID"].ToString().Trim();
                        string contactno = drsa["ContactNo"].ToString().Trim();
                        string contactno1 = drsa["ContactNo1"].ToString().Trim();
                        string officeno = drsa["OfficeNo"].ToString().Trim();
                        string email = drsa["Email"].ToString().Trim();
                        string physicaladdress = drsa["PhysicalAddress"].ToString().Trim();
                        string postaladdress = drsa["PostalAddress"].ToString().Trim();
                        string bankname = drsa["BankName"].ToString().Trim();
                        string bankaccountname = drsa["BankAccountName"].ToString().Trim();
                        string bankaccountnumber = drsa["BankAccountNumber"].ToString().Trim();
                        string nokname = drsa["NOKName"].ToString().Trim();
                        string nokcontactno = drsa["NOKContactNo"].ToString().Trim();
                        string nokaddreess = drsa["NOKAddress"].ToString().Trim();
                        string nokrelationship = drsa["NOKRelationship"].ToString().Trim();
                        string designation = drsa["Designation"].ToString().Trim();
                        string employerName = drsa["EmployerName"].ToString().Trim();
                        string branch = drsa["InsBranch"].ToString().Trim();
                        string ids = drsa["ID"].ToString().Trim();
                        string mycon = mycs.MysqlDBConn;
                        var response = httpClient.PostAsync(mycon + "/accountregistration.php?ids=" + ids + "&accountno=" + accountno + "&accountnames=" + accountnames + "&registrationdate=" + registrationdate + "&maritalstatus=" + maritalstatus + "&nationality=" + nationality + "&nationalitystatus=" + nationalitystatus + "&gender=" + gender + "&dob=" + dob + "&idform=" + idform + "&clientid=" + clientid + "&contactno=" + contactno + "&contactno1=" + contactno1 + "&officeno=" + officeno + "&email=" + email + "&physicaladdress=" + physicaladdress + "&postaladdress=" + postaladdress + "&bankname=" + bankname + "&bankaccountname=" + bankaccountname + "&bankaccountnumber=" + bankaccountnumber + "&nokname=" + nokname + "&nokcontactno=" + nokcontactno + "&nokaddreess=" + nokaddreess + "&nokrelationship=" + nokrelationship + "&designation=" + designation + "&employerName=" + employerName + "&branch=" + branch, new StringContent(""));
                        response.Wait();
                        string content = response.Result.StatusCode.ToString();
                    }
                }
                rdr.Dispose();
                dtpp3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery5sa = "UPDATE Account SET UploadStatus='Uploaded' where UploadStatus='Pending'";
                cmd = new SqlCommand(inquery5sa, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Successfuly Uploaded Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker12_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            enablecheckbox();
        }

        private void frmSynchronize_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }
    }
}
