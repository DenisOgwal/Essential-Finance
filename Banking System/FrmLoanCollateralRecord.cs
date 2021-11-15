using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanCollateralRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmLoanCollateralRecord()
        {
            InitializeComponent();
        }

        private void FrmLoanCollateralRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(DISTRICT)[District],RTRIM(PLOT)[Plot],RTRIM(BLOCK)[Block],RTRIM(COUNTY)[County],RTRIM(VOLUME)[Volume],RTRIM(FOLIO)[Folio],RTRIM(LANDAT)[Land At],RTRIM(SIZE)[Size],(Developments)[Developments],(Occupants)[Occupants],(Description)[Description] from LandTitle where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "LandTitle");
                dataGridView1.DataSource = myDataSet.Tables["LandTitle"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(DISTRICT)[District],RTRIM(COUNTY)[County],RTRIM(SUBCOUNTY)[Subcounty],RTRIM(VILLAGE)[Village],RTRIM(SIZE)[Size],RTRIM(CURRENTOWNER)[Current Owner],RTRIM(PREVIOUSOWNER)[Previous Owner],RTRIM(LC1CHAIRMAN)[LC1 Chairman],(Developments)[Developments],(Occupants)[Occupants],(Description)[Description] from KibanjaProperty where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "KibanjaProperty");
                dataGridView2.DataSource = myDataSet.Tables["KibanjaProperty"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(EMPLOYER)[EMPLOYER],RTRIM(JOBTITLE)[JOB TITLE],RTRIM(PAYROLENO)[PAY ROLE NO],RTRIM(STAFFID)[STAFF ID],RTRIM(SALARYBANK)[SALARY BANK],RTRIM(ACCOUNTNAME)[ACCOUNT NAME],RTRIM(ACCOUNTNUMBER)[ACCOUNT NUMBER],RTRIM(NETSALARY)[NETSALARY],(DESCRIPTION)[Description] from SalaryEarners where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SalaryEarners");
                dataGridView3.DataSource = myDataSet.Tables["SalaryEarners"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(RideType)[Ride Type],RTRIM(Category)[Category],RTRIM(PlateNo)[Plate No],RTRIM(ModelYear)[Model Year],RTRIM(Color)[Color],RTRIM(PropertyDeposited)[Property Deposited],(Description)[Description] from Ride where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Ride");
                dataGridView4.DataSource = myDataSet.Tables["Ride"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(ITEMNAME)[ITEM NAME],RTRIM(SERIALNUMBER)[SERIAL NUMBER],RTRIM(MODELYEAR)[MODEL YEAR],RTRIM(COLOR)[COLOR],RTRIM(MODEL)[MODEL],RTRIM(PropertyDeposited)[Property Deposited],(Description)[Description] from Asset where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Asset");
                dataGridView5.DataSource = myDataSet.Tables["Asset"].DefaultView;
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
                cmd = new SqlCommand("select RTRIM(Type)[Type],RTRIM(NAME)[Business Name],RTRIM(LOCKUP)[Lock Up],RTRIM(REGNO)[Reg No.],RTRIM(Location)[Location],RTRIM(AttendantsName)[Attendants Name],(DEALERSHIP)[Dealership],(MaturityDate)[Maturity Date],(Bank)[Bank],(StandingOrders)[Standing Orders],(DESCRIPTION)[Description] from Business where LoanID='" + label1.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Business");
                dataGridView6.DataSource = myDataSet.Tables["Business"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
