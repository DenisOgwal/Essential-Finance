using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmLoanApplication : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        int[] monthscount = new int[100];
        double principal = 0.00;
        double interest = 0.00;
        double repaymentammount = 0;
        string repaymentmonths = null;
        string repaymentdate = null;
        public frmLoanApplication()
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
            string ct = "select ID from Loan Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(ID) from Loan", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string convertedid = "";
            if (realid < 10)
            {
                convertedid = "00" + realid;
            }
            else if (realid < 100)
            {
                convertedid = "0" + realid;
            }
            else
            {
                convertedid = "" + realid;
            }
            string years = yearss.Substring(2, 2);
            LoanID.Text = "LA" + years + monthss + days + convertedid;
        }
        private void frmLoanApplication_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoanApplication frm = new frmLoanApplication();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuarantorName.Text == "")
                {
                    MessageBox.Show("Please Enter Guarantor Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GuarantorName.Focus();
                    return;
                }
                if (Residence.Text == "")
                {
                    MessageBox.Show("Please Enter Residence Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Residence.Focus();
                    return;
                }
                if (Relationship.Text == "")
                {
                    MessageBox.Show("Please Enter Relationship Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Relationship.Focus();
                    return;
                }
                dataGridView1.Rows.Add(GuarantorName.Text, Residence.Text, Relationship.Text, telno.Text);
                Reset();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void Reset()
        {
            GuarantorName.Text = "";
            Residence.Text = "";
            Relationship.Text = "";
            telno.Text = "";
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset2()
        {
            Institution.Text = "";
            Outstanding.Text = "";
            Duration.Text = "";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Reset2();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Institution.Text == "")
                {
                    MessageBox.Show("Please Enter Institution Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Institution.Focus();
                    return;
                }
                if (Outstanding.Text == "")
                {
                    MessageBox.Show("Please Enter Outstanding Amount", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Outstanding.Focus();
                    return;
                }
                if (Duration.Text == "")
                {
                    MessageBox.Show("Please Enter Outstanding Duration", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Duration.Focus();
                    return;
                }
                dataGridView2.Rows.Add(Institution.Text, Outstanding.Value, Duration.Text);
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanApplicationPayment frm = new FrmLoanApplicationPayment();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountNo.Text == "")
                {
                    MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccountNo.Focus();
                    return;
                }
                if (AccountName.Text == "")
                {
                    MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccountName.Focus();
                    return;
                }
                if (LoanAmount.Text == "")
                {
                    MessageBox.Show("Please Fill Loan Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoanAmount.Focus();
                    return;
                }
                if (ServicingPeriod.Text == "")
                {
                    MessageBox.Show("Please Fill Servicing Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ServicingPeriod.Focus();
                    return;
                }
                if (RepaymentInterval.Text == "")
                {
                    MessageBox.Show("Please Select Repayment Interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RepaymentInterval.Focus();
                    return;
                }
                if (Collateral.Text == "")
                {
                    MessageBox.Show("Please Select Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Collateral.Focus();
                    return;
                }
                if (CollateralValue.Text == "")
                {
                    MessageBox.Show("Please Fill Collateral Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CollateralValue.Focus();
                    return;
                }
                if (InterestRate.Text == "")
                {
                    MessageBox.Show("Please Fill Interest Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InterestRate.Focus();
                    return;
                }
                if (RefName.Text == "")
                {
                    MessageBox.Show("Please Fill Referee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefName.Focus();
                    return;
                }
                if (RefAddress.Text == "")
                {
                    MessageBox.Show("Please Fill Refree Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefAddress.Focus();
                    return;
                }
                if (ContactNo.Text == "")
                {
                    MessageBox.Show("Please Fill Contact No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ContactNo.Focus();
                    return;
                }
                if (RefRelationship.Text == "")
                {
                    MessageBox.Show("Please Fill Referee Relationship", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefRelationship.Focus();
                    return;
                }
                if (AmortisationMethod.Text == "")
                {
                    MessageBox.Show("Please Select Ammortisation Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AmortisationMethod.Focus();
                    return;
                }
                auto();
                string collateralsuccess = "";
                if (Collateral.Text == "Asset")
                {
                    FrmAssets frm = new FrmAssets();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label10.Text;
                    if (collateralsuccess == "1")
                    {
                        MessageBox.Show("Successful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (Collateral.Text == "Land Title")
                {
                    FrmLandTitle frm = new FrmLandTitle();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label15.Text;
                    if (collateralsuccess == "1")
                    {
                        InsertApplication();
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Collateral.Text == "Kibanja Property")
                {
                    FrmKibanjaProperty frm = new FrmKibanjaProperty();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label15.Text;
                    if (collateralsuccess == "1")
                    {
                        InsertApplication();
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Collateral.Text == "Vehicle / Motor cycle / Bicycle")
                {
                    FrmRide frm = new FrmRide();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label9.Text;
                    if (collateralsuccess == "1")
                    {
                        InsertApplication();
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Collateral.Text == "Business / company")
                {
                    FrmBusiness frm = new FrmBusiness();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label14.Text;
                    if (collateralsuccess == "1")
                    {
                        InsertApplication();
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Collateral.Text == "Salary")
                {

                    FrmSalaryEarners frm = new FrmSalaryEarners();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    frm.LoanID.Text = LoanID.Text;
                    frm.ShowDialog();
                    collateralsuccess = frm.label13.Text;
                    if (collateralsuccess == "1")
                    {
                        InsertApplication();
                    }
                    else
                    {
                        MessageBox.Show("Try Again and Save Collateral", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Correct Correct Collateral Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Collateral.Focus();
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        Double begginingbalance=0.00;
        public void InsertApplication()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Loan(AccountNo,AccountName,LoanID,ServicingPeriod,RepaymentInterval,Interest,Collateral,CollateralValue,RefereeName,RefereeTel,RefereeAddress,RefereeRelationship,ApplicationDate,LoanAmount,IssueType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "AccountName"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "ServicingPeriod"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "RepaymentInterval"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 30, "Interest"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "Collateral"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "CollateralValue"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "RefereeName"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "RefereeTel"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "RefereeAddress"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 30, "RefereeRelationship"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 20, "ApplicationDate"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "LoanAmount"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "IssueType"));
                cmd.Parameters["@d1"].Value = AccountNo.Text;
                cmd.Parameters["@d2"].Value = AccountName.Text;
                cmd.Parameters["@d3"].Value = LoanID.Text;
                cmd.Parameters["@d4"].Value = ServicingPeriod.Text;
                cmd.Parameters["@d5"].Value = RepaymentInterval.Text;
                cmd.Parameters["@d6"].Value = InterestRate.Text;
                cmd.Parameters["@d7"].Value = Collateral.Text;
                cmd.Parameters["@d8"].Value = CollateralValue.Value;
                cmd.Parameters["@d9"].Value = RefName.Text;
                cmd.Parameters["@d10"].Value = ContactNo.Text;
                cmd.Parameters["@d11"].Value = RefAddress.Text;
                cmd.Parameters["@d12"].Value = RefRelationship.Text;
                cmd.Parameters["@d13"].Value = ApplicationDate.Text;
                cmd.Parameters["@d14"].Value = LoanAmount.Value;
                cmd.Parameters["@d15"].Value = AmortisationMethod.Text;
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
                string cb = "insert into Guarantor(Names,LoanID,Residence,Relationship,Date,TELNo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 60, "Names"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 60, "Residence"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "Relationship"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 30, "TELNo"));
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[1].Value) != null)
                        {
                            cmd.Parameters["@d1"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d2"].Value = LoanID.Text;
                            cmd.Parameters["@d3"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                            cmd.Parameters["@d5"].Value = ApplicationDate.Text;
                            cmd.Parameters["@d6"].Value = row.Cells[3].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
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
                string cb = "insert into OutstandingLiabilities(LoanID,Date,Institution,OutstandingAmount,Duration) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Institution"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "OutstandingAmount"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Duration"));
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[1].Value) != null)
                        {
                            cmd.Parameters["@d1"].Value = LoanID.Text;
                            cmd.Parameters["@d2"].Value = ApplicationDate.Text;
                            cmd.Parameters["@d3"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d5"].Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (AmortisationMethod.Text== "Flat Rate")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= ServicingPeriod.Value)
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= ServicingPeriod.Value; i++)
                    {
                        if (RepaymentInterval.Text == "Monthly")
                        {
                            repaymentmonths = monthscount[i] + "Months";
                            repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text == "Daily")
                        {
                            repaymentmonths = monthscount[i] + "Day";
                            repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text == "Weekly")
                        {
                            repaymentmonths = monthscount[i] + "Week";
                            repaymentdate1 = (startdate.AddDays(i*7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                        double val1 = 0;
                        double.TryParse(LoanAmount.Value.ToString(), out val1);
                        principal = val1 / ServicingPeriod.Value;
                        interest = ((Convert.ToDouble(InterestRate.Value) / (100)) * val1);
                        repaymentammount = principal + interest;
                        begginingbalance = val1;

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNo.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (AmortisationMethod.Text == "Reducing Balance")
                {
                    int K = 1;
                    int i = 1;
                    while (K <= ServicingPeriod.Value)
                    {
                        monthscount[K] = K;
                        K++;
                    }
                    string repaymentdate1 = null;
                    DateTime startdate = DateTime.Parse(ApplicationDate.Text).Date;
                    for (i = 1; i <= ServicingPeriod.Value; i++)
                    {
                        if (RepaymentInterval.Text == "Monthly")
                        {
                            repaymentmonths = monthscount[i] + "Months";
                            repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text == "Daily")
                        {
                            repaymentmonths = monthscount[i] + "Day";
                            repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");
                        }
                        else if (RepaymentInterval.Text == "Weekly")
                        {
                            repaymentmonths = monthscount[i] + "Week";
                            repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                            DateTime dt = DateTime.Parse(repaymentdate1);
                            repaymentdate = dt.ToString("dd/MMM/yyyy");

                        }
                            double val1 = 0;
                            double.TryParse(LoanAmount.Value.ToString(), out val1);
                            double emi = val1 / ServicingPeriod.Value;

                        if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                        {
                            interest = val1 * (Convert.ToDouble(InterestRate.Value) / 100);
                            principal = emi;
                            repaymentammount = emi + interest;
                            begginingbalance = val1 - principal;
                        }
                        else
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt = "select BeginningBalance from AmortisationSchedule where LoanID='" + LoanID.Text + "' order by ID Desc";
                            cmd = new SqlCommand(kt);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                Double totals6 = Convert.ToDouble(rdr[0]);
                                interest = totals6 * (Convert.ToDouble(InterestRate.Value) / 100);
                                principal = emi;
                                repaymentammount = emi + interest;
                                begginingbalance = totals6 - principal;
                                con.Close();
                            }

                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Months"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "AmmountPay"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Float, 20, "Interest"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters["@d1"].Value = LoanID.Text;
                        cmd.Parameters["@d2"].Value = AccountNo.Text;
                        cmd.Parameters["@d3"].Value = repaymentmonths;
                        cmd.Parameters["@d4"].Value = repaymentdate;
                        cmd.Parameters["@d5"].Value = repaymentammount;
                        cmd.Parameters["@d6"].Value = principal;
                        cmd.Parameters["@d7"].Value = interest;
                        cmd.Parameters["@d8"].Value = repaymentammount;
                        cmd.Parameters["@d9"].Value = begginingbalance;
                        cmd.Parameters["@d10"].Value = AccountName.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully Submitted Application","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                frmLoanApplication frm = new frmLoanApplication();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails frm = new frmClientDetails();
                frm.ShowDialog();
                this.AccountNo.Text = frm.clientnames.Text;
                this.AccountName.Text = frm.Accountnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoanID_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails4 frm = new frmClientDetails4();
                frm.ShowDialog();
                this.AccountNo.Text = frm.clientnames.Text;
                this.AccountName.Text = frm.Accountnames.Text;
                this.LoanID.Text = frm.LoanID.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void Reset3()
        {
            this.Hide();
            frmLoanApplication frm = new frmLoanApplication();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from Loan where LoanID=@DELETE1 and FirstApproval='Pending';";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset3();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset3();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq1 = "delete  from AmortisationSchedule where LoanID=@DELETE1;";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                cmd.ExecuteNonQuery();
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

        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanFirstApproval frm = new FrmLoanFirstApproval();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanFinalApproval frm = new FrmLoanFinalApproval();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
    }
}
