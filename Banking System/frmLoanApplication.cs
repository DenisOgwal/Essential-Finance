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
        SqlDataAdapter adp;
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
            con.Close();
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
            string initialletters = businesstype.Text.Substring(0, 2);
            LoanID.Text = initialletters + years + monthss + days + convertedid;
        }
        private void auto2()
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
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 2;
            }
            else
            {
                realid = 1;
            }
            con.Close();
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
            string initialletters = businesstype.Text.Substring(0, 2);
            LoanID.Text = initialletters + years + monthss + days + convertedid;
        }
        private void auto3()
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
                realid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                realid = 1;
            }
            con.Close();
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
            string initialletters = businesstype.Text.Substring(0, 2);
            LoanID.Text = initialletters + years + monthss + days + convertedid;
        }

        string savingsids = null;
        private void auto4()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SR-" + days + realid;
        }
        private void auto5()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 2;
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SR-" + days + realid;
        }
        private void auto6()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select ID from SavingsTransactions  Order By ID DESC", con);
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNo) from SavingsTransactions", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = ApplicationDate.Text;
                realid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                realid = 1;
            }
            con.Close();
            string years = yearss.Substring(2, 2);
            savingsids = "SR-" + days + realid;
        }
        private void frmLoanApplication_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Loantypess) FROM LoanTypes", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                businesstype.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    businesstype.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                dataGridView1.Rows.Add(GuarantorName.Text, Residence.Text, Relationship.Text, telno.Text,MemberID.Text);
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
            MemberID.Text = "";
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
                Reset2();
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

                if (AmortisationMethod.Text == "Reducing Balance" && InterestRate.Text == "0")
                {
                    MessageBox.Show("You Can not  use 0% Interrest on Reducing Balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InterestRate.Focus();
                    return;
                }
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
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                    cmd = new SqlCommand(kt);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        auto2();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string kt3 = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                        cmd = new SqlCommand(kt3);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            auto3();
                        }
                        else
                        {
                            auto();
                        }
                        con.Close();

                    }
                    else
                    {
                        auto();
                    }
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        InsertApplication();
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
                string kt = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                cmd = new SqlCommand(kt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    auto2();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string kt3 = "select LoanID from Loan where LoanID='" + LoanID.Text + "' order by ID Desc";
                    cmd = new SqlCommand(kt3);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        auto3();
                        //MessageBox.Show("Loan ID Already Exixts, Please Repeat Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                    con.Close();
                    //MessageBox.Show("Loan ID Already Exixts, Please Repeat Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                else
                {
                    auto();
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Loan(AccountNo,AccountName,LoanID,ServicingPeriod,RepaymentInterval,Interest,Collateral,CollateralValue,RefereeName,RefereeTel,RefereeAddress,RefereeRelationship,ApplicationDate,LoanAmount,IssueType,LoanType,RegisteredBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,'"+businesstype.Text+"','"+label1.Text+"')";
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[1].Value) != null)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into Guarantor(Names,LoanID,Residence,Relationship,Date,TELNo,IDNo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 60, "Names"));
                            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "LoanID"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 60, "Residence"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 40, "Relationship"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "TELNo"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "IDNo"));

                            cmd.Parameters["@d1"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d2"].Value = LoanID.Text;
                            cmd.Parameters["@d3"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                            cmd.Parameters["@d5"].Value = ApplicationDate.Text;
                            cmd.Parameters["@d6"].Value = row.Cells[3].Value;
                            cmd.Parameters["@d7"].Value = row.Cells[4].Value;
                            cmd.ExecuteNonQuery();
                            con.Close();
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
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if ((row.Cells[1].Value) != null)
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

                            cmd.Parameters["@d1"].Value = LoanID.Text;
                            cmd.Parameters["@d2"].Value = ApplicationDate.Text;
                            cmd.Parameters["@d3"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d4"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d5"].Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                            con.Close();
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
                        principal = val1 ;
                        if (InterestRate.Text == "0")
                        {
                            interest = 0.00;
                        }
                        else
                        {
                            interest = ((Convert.ToDouble(InterestRate.Text) / (100)) * val1);
                        }
                        if (i == ServicingPeriod.Value)
                        {
                            repaymentammount = val1 + interest;
                            begginingbalance = 0;
                        }
                        else
                        {
                            repaymentammount = interest;
                            begginingbalance = val1;
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
                    double val1 = 0;
                    double.TryParse(LoanAmount.Value.ToString(), out val1);
                    double r = Convert.ToDouble(InterestRate.Text) / 100;
                    int n = ServicingPeriod.Value;
                    double firstint = Math.Pow((1 + r), n);
                    double secondint = Math.Pow((1 + r), n);
                    double emi = (val1*r* Math.Pow((1+r), n)) / ((Math.Pow((1+r), n)) - 1);
                    //MessageBox.Show("emi"+ emi);
                    //MessageBox.Show("firstint" + firstint);
                    ///MessageBox.Show("r" + r);
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
                          
                        if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                        {

                            if (InterestRate.Text == "0")
                            {
                                interest = 0.00;
                            }
                            else
                            {
                                interest = val1 * (Convert.ToDouble(InterestRate.Text) / 100);
                            }
                            principal = emi- interest;
                            repaymentammount = emi;
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
                                if (InterestRate.Text == "0")
                                {
                                    interest = 0.00;
                                }
                                else
                                {
                                    interest = totals6 * (Convert.ToDouble(InterestRate.Text) / 100);
                                }
                                principal = emi - interest;
                                repaymentammount = emi;
                                begginingbalance = totals6 - principal;
                                con.Close();
                            }
                            con.Close();

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
                DialogResult dialog = MessageBox.Show("Do you want to View Amortisation Schedule", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    FrmLoanAmortisationReport frm3 = new FrmLoanAmortisationReport();
                    frm3.label1.Text = LoanID.Text;
                    frm3.ShowDialog();
                }
                else
                {
                  
                }
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
                frmClientDetails7 frm = new frmClientDetails7();
                frm.ShowDialog();
                AccountName.Text = frm.Accountnames.Text;
                AccountNo.Text = frm.clientnames.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int paidamount = 0;
                int accountbalances = 0;
                int newaccountbalance = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Accountbalance from Savings where AccountNo= '" + AccountNo.Text + "' and Approval='Approved' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountbalances = Convert.ToInt32(rdr["Accountbalance"]);
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountPaid from LoanApplicationPayment where LoanID= '" + LoanID.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    paidamount = Convert.ToInt32(rdr[0]);
                    newaccountbalance = accountbalances + paidamount;
                    if (paidamount > 0)
                    {
                        auto4();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string kt = "select SavingsID from Savings where SavingsID='" + savingsids + "' order by ID Desc";
                        cmd = new SqlCommand(kt);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            auto5();
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string kt3 = "select SavingsID from Savings where SavingsID='" + savingsids + "' order by ID Desc";
                            cmd = new SqlCommand(kt3);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                auto6();
                            }
                            con.Close();

                        }
                        else
                        {
                            auto4();
                        }
                        con.Close();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "insert into Savings(AccountNo,SavingsID,SubmittedBy,Date,Deposit,Accountbalance,Transactions,ModeOfPayment,AccountName,CashierName,DepositDate,Credit,Approval) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Approved')";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNo"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "SavingsID"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "SubmittedBy"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "Deposit"));
                        cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 20, "Accountbalance"));
                        cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 100, "Transactions"));
                        cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                        cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 100, "AccountName"));
                        cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 60, "CashierName"));
                        cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "DepositDate"));
                        cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Credit"));
                        cmd.Parameters["@d1"].Value = AccountNo.Text;
                        cmd.Parameters["@d2"].Value = savingsids;
                        cmd.Parameters["@d3"].Value = label1.Text;
                        cmd.Parameters["@d4"].Value = ApplicationDate.Text;
                        cmd.Parameters["@d5"].Value = paidamount;
                        cmd.Parameters["@d6"].Value = newaccountbalance;
                        cmd.Parameters["@d7"].Value = "Reversed Loan Application Fees";
                        cmd.Parameters["@d8"].Value = "Transfer";
                        cmd.Parameters["@d9"].Value = AccountName.Text;
                        cmd.Parameters["@d10"].Value = label1.Text;
                        cmd.Parameters["@d11"].Value = ApplicationDate.Text;
                        cmd.Parameters["@d12"].Value = paidamount;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                con.Close();


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq2 = "delete  from LoanApplicationPayment where LoanID=@DELETE1;";
                cmd = new SqlCommand(cq2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq1 = "delete  from AmortisationSchedule where LoanID=@DELETE1;";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                cmd.Parameters["@DELETE1"].Value = LoanID.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from Loan where LoanID=@DELETE1 and FinalApproval='Pending';";
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

        private void buttonX12_Click(object sender, EventArgs e)
        {
            FrmGuarantors frm = new FrmGuarantors();
            frm.ShowDialog();
        }

        private void LoanID_TextChanged(object sender, EventArgs e)
        {
            if (businesstype.Text == "")
            {
                try
                {
                    string pat = LoanID.Text.Trim();
                    SqlConnection CN = new SqlConnection(cs.DBConn);
                    CN.Open();
                    string SelectCommand = "SELECT * FROM Loan Where LoanID='" + pat + "'";
                    cmd = new SqlCommand(SelectCommand);
                    cmd.Connection = CN;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        LoanAmount.Text = rdr["LoanAmount"].ToString();
                        ServicingPeriod.Text = rdr["ServicingPeriod"].ToString();
                        RepaymentInterval.Text = rdr["RepaymentInterval"].ToString();
                        Collateral.Text = rdr["Collateral"].ToString();
                        CollateralValue.Text = rdr["CollateralValue"].ToString();
                        InterestRate.Text = rdr["Interest"].ToString();
                        AmortisationMethod.Text = rdr["IssueType"].ToString();
                        ContactNo.Text = rdr["RefereeTel"].ToString();
                        RefName.Text = rdr["RefereeName"].ToString();
                        RefAddress.Text = rdr["RefereeAddress"].ToString();
                        RefRelationship.Text = rdr["RefereeRelationship"].ToString(); 
                    }
                    else
                    {

                    }
                    CN.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE Loan SET ServicingPeriod=@d4,RepaymentInterval=@d5,Interest=@d6,LoanAmount=@d14,IssueType=@d15,ApplicationDate=@d13,RefereeRelationShip=@d12,RefereeAddress=@d11,RefereeTel=@d10,RefereeName=@d9,CollateralValue=@d8 where LoanID=@d3";
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
                try
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete  from  AmortisationSchedule where LoanID=@DELETE1 ";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                    cmd.Parameters["@DELETE1"].Value = LoanID.Text;
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

                try
                {
                    if (AmortisationMethod.Text.ToString().Trim() == "Flat Rate")
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
                            if (RepaymentInterval.Text.ToString().Trim() == "Monthly")
                            {
                                repaymentmonths = monthscount[i] + "Months";
                                repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");
                            }
                            else if (RepaymentInterval.Text.ToString().Trim() == "Daily")
                            {
                                repaymentmonths = monthscount[i] + "Day";
                                repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");
                            }
                            else if (RepaymentInterval.Text.ToString().Trim() == "Weekly")
                            {
                                repaymentmonths = monthscount[i] + "Week";
                                repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");

                            }
                            double val1 = 0;
                            double.TryParse(LoanAmount.Value.ToString(), out val1);
                            principal = val1;
                            if (InterestRate.Text == "0")
                            {
                                interest = 0.00;
                            }
                            else
                            {
                                interest = ((Convert.ToDouble(InterestRate.Text) / (100)) * val1);
                            }
                            if (i == ServicingPeriod.Value)
                            {
                                repaymentammount = val1 + interest;
                                begginingbalance = 0;
                            }
                            else
                            {
                                repaymentammount = interest;
                                begginingbalance = val1;
                            }


                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb5 = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                            cmd = new SqlCommand(cb5);
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
                    else if (AmortisationMethod.Text.ToString().Trim() == "Reducing Balance")
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
                        double val1 = 0;
                        double.TryParse(LoanAmount.Value.ToString(), out val1);
                        double r = Convert.ToDouble(InterestRate.Text) / 100;
                        int n = ServicingPeriod.Value;
                        double firstint = Math.Pow((1 + r), n);
                        double secondint = Math.Pow((1 + r), n);
                        double emi = (val1 * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n)) - 1);
                        //MessageBox.Show("emi"+ emi);
                        //MessageBox.Show("firstint" + firstint);
                        ///MessageBox.Show("r" + r);
                        for (i = 1; i <= ServicingPeriod.Value; i++)
                        {
                            if (RepaymentInterval.Text.ToString().Trim() == "Monthly")
                            {
                                repaymentmonths = monthscount[i] + "Months";
                                repaymentdate1 = (startdate.AddMonths(i)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");
                            }
                            else if (RepaymentInterval.Text.ToString().Trim() == "Daily")
                            {
                                repaymentmonths = monthscount[i] + "Day";
                                repaymentdate1 = (startdate.AddDays(i)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");
                            }
                            else if (RepaymentInterval.Text.ToString().Trim() == "Weekly")
                            {
                                repaymentmonths = monthscount[i] + "Week";
                                repaymentdate1 = (startdate.AddDays(i * 7)).ToShortDateString();
                                DateTime dt = DateTime.Parse(repaymentdate1);
                                repaymentdate = dt.ToString("dd/MMM/yyyy");

                            }

                            if (repaymentmonths == "1Months" || repaymentmonths == "1Week" || repaymentmonths == "1Day")
                            {

                                if (InterestRate.Text == "0")
                                {
                                    interest = 0.00;
                                }
                                else
                                {
                                    interest = val1 * (Convert.ToDouble(InterestRate.Text) / 100);
                                }
                                principal = emi - interest;
                                repaymentammount = emi;
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
                                    if (InterestRate.Text == "0")
                                    {
                                        interest = 0.00;
                                    }
                                    else
                                    {
                                        interest = totals6 * (Convert.ToDouble(InterestRate.Text) / 100);
                                    }
                                    principal = emi - interest;
                                    repaymentammount = emi;
                                    begginingbalance = totals6 - principal;
                                    con.Close();
                                }
                                con.Close();

                            }
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb4 = "insert into AmortisationSchedule(LoanID,AccountNumber,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,BalanceExist,BeginningBalance,AccountName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                            cmd = new SqlCommand(cb4);
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
                    MessageBox.Show("Update Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult dialog = MessageBox.Show("Do you want to View Amortisation Schedule", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmLoanAmortisationReport frm3 = new FrmLoanAmortisationReport();
                        frm3.label1.Text = LoanID.Text;
                        frm3.ShowDialog();
                    }
                    else
                    {

                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoanProcessingApproval frm = new FrmLoanProcessingApproval();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }
    }
}
