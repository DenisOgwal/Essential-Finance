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
            else if (currentselect == "ribbonTabItem4")
            {
                ribbonTabItem4.Select();
            }
            else if (currentselect == "ribbonTabItem2")
            {
                ribbonTabItem2.Select();
            }
            else if (currentselect == "ribbonTabItem3")
            {
                ribbonTabItem3.Select();
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
                    ribbonTabItem3.Visible = true;//Humman Resource
                    ribbonTabItem4.Visible = true;//Account
                    ribbonTabItem2.Visible = true;//Loans
                    ribbonTabItem6.Visible = true;//Investments
                    ribbonTabItem5.Visible = true;//Inflows
                    ribbonTabItem7.Visible = true;//Outflows
                    ribbonTabItem8.Visible = true;//Pendings
                    administration.Enabled = true;//account openning
                    schedule.Enabled = true;//savings transaction
                    invetory.Enabled = true;//Loans Transactions
                    records.Enabled = true;//safetransactions
                    reports.Enabled = true;//expensestransactions
                    accounts.Enabled = true;//Financial Summary
                    //buttonItem16.Visible = true;
                    buttonItem17.Visible = true;
                    buttonItem18.Visible = true;
                    buttonItem2.Visible = true;
                    buttonItem73.Visible = true;//
                    buttonItem75.Visible = true;//
                    buttonItem76.Visible = true;//
                    buttonItem84.Visible = true;//
                    buttonItem86.Visible = true;//
                }
                else
                {

                    try
                    {
                        SqlDataReader rdr = null;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select Settings,Humanresource,Account,Savings,Loans,Investments,Inflows,Outflows,Pendings,SafeTransactions,Expenses,FinancialSummary,Additions,Records,Reports from UserAccess where UserName='" + User.Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string settings = rdr["Settings"].ToString().Trim();
                            string Humanresource = rdr["Humanresource"].ToString().Trim();
                            string Account = rdr["Account"].ToString().Trim();
                            string savings = rdr["Savings"].ToString().Trim();
                            string loans = rdr["Loans"].ToString().Trim();
                            string investments = rdr["Investments"].ToString().Trim();
                            string inflows = rdr["Inflows"].ToString().Trim();
                            string outflows = rdr["Outflows"].ToString().Trim();
                            string pendings = rdr["Pendings"].ToString().Trim();
                            string safetransactions = rdr["SafeTransactions"].ToString().Trim();
                            string financialsummary = rdr["FinancialSummary"].ToString().Trim();
                            string additions = rdr["Additions"].ToString().Trim();
                            string Records = rdr["Records"].ToString().Trim();
                            string Reports = rdr["Reports"].ToString().Trim();
                            string expenses = rdr["Expenses"].ToString().Trim();
                            if (settings == "Yes")
                            {
                                //Settings.Select();
                                Settings.Visible = true;//settings
                            }
                            if (Humanresource == "Yes")
                            {
                                //ribbonTabItem3.Select();
                                ribbonTabItem3.Visible = true;//Human Resource
                            }
                            if (Account == "Yes")
                            {
                                //ribbonTabItem6.Select();
                                ribbonTabItem4.Enabled = true;
                                ribbonTabItem6.Visible = true;//accounts
                                buttonItem85.Visible = true;//accounts report
                                accounts.Enabled = true;//accounts
                            }
                            if (savings == "Yes")
                            {
                                buttonItem75.Visible = true;//savingss report
                                schedule.Enabled = true;//main button
                            }
                            if (loans == "Yes")
                            {
                                //ribbonTabItem2.Select();
                                ribbonTabItem2.Visible = true;//loan
                                buttonItem76.Visible = true;//Loans report
                                invetory.Enabled = true;//main button
                            }

                            if (investments == "Yes")
                            {
                                //ribbonTabItem6.Select();
                                ribbonTabItem6.Visible = true;//returns
                               
                            }

                            if (inflows == "Yes")
                            {
                                //ribbonTabItem5.Select();
                                ribbonTabItem5.Visible = true;//other inflows
                               
                            }
                            if (outflows == "Yes")
                            {
                                //ribbonTabItem7.Select();
                                ribbonTabItem7.Visible = true;//other inflows
                                buttonItem84.Visible = true;//expenses Reports
                                reports.Enabled = true;
                            }
                            if (pendings == "Yes")
                            {
                                // ribbonTabItem8.Select();
                                ribbonTabItem8.Visible = true;//Pendings
                            }
                            if (safetransactions == "Yes")
                            {
                                records.Enabled = true;
                            }
                            if (financialsummary == "Yes")
                            {
                                accounts.Enabled = true;
                            }
                            if (additions == "Yes")
                            {
                                buttonItem2.Visible = true;//expenses records
                            }
                            if (Records == "Yes")
                            {
                              
                            }
                            if (Reports == "Yes")
                            {
                                buttonItem73.Visible = true;//
                                buttonItem75.Visible = true;//
                                buttonItem76.Visible = true;//
                                buttonItem84.Visible = true;//
                                buttonItem86.Visible = true;//
                            }
                            if (expenses == "Yes")
                            {
                                reports.Enabled = true;
                            }
                        }
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        con.Close();
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

        private void recordreglink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmMemberRegistrationRecord frm = new frmMemberRegistrationRecord();
            frm.label5.Text = User.Text;
            frm.label8.Text = UserType.Text;
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

        private void recordreffflink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmSavingsRecord frm = new frmSavingsRecord();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
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

        private void reportreglink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmMemberRegistratioReport frm = new frmMemberRegistratioReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
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

        private void reportpatlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmSavingsReport frm = new frmSavingsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
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

        private void clinicRep_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavingsReport frm = new frmSavingsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
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
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmEquipmentPurchaseReport frm = new frmEquipmentPurchaseReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
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

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavingsReport frm = new frmSavingsReport();
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

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEquipmentPurchaseReport frm = new frmEquipmentPurchaseReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMemberRegistratioReport frm = new frmMemberRegistratioReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
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

        private void externalloanapprovals_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalLoans frm = new frmExternalLoans();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
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
        private void buttonItem68_Click(object sender, EventArgs e)
        {
            frmFormPassBookLedger frm = new frmFormPassBookLedger();
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
        private void buttonItem94_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalLoans frm = new frmExternalLoans();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
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

        private void buttonItem100_Click(object sender, EventArgs e)
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

        private void buttonItem70_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalLoans frm = new frmExternalLoans();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem72_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalPaymentSchedule frm = new frmExternalPaymentSchedule();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

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
        private void buttonItem73_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMemberRegistratioReport frm = new frmMemberRegistratioReport();
            frm.label1.Text = User.Text;
            frm.label3.Text = UserType.Text;
            frm.Show();
        }

        private void buttonItem75_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSavingsReport frm = new frmSavingsReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();

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

        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}