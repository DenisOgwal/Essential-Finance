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
        public frmLoanApplication()
        {
            InitializeComponent();
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Loan(AccountNo,AccountName,LoanID,ServicingPeriod,RepaymentInterval,Interest,Collateral,CollateralValue,RefereeName,RefereeTel,RefereeAddress,RefereeRelationship,ApplicationDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
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
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 100, "RefereeAddress"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 30, "RefereeRelationship"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "ApplicationDate"));
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
        }
    }
}
