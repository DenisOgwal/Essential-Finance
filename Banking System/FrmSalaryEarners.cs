using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmSalaryEarners : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmSalaryEarners()
        {
            InitializeComponent();
        }

        private void FrmSalaryEarners_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Employer.Text == "")
                {
                    MessageBox.Show("Please Fill Employer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Employer.Focus();
                    return;
                }
                if (JobTitle.Text == "")
                {
                    MessageBox.Show("Please Fill Job Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    JobTitle.Focus();
                    return;
                }
                if (PayRoleNo.Text == "")
                {
                    MessageBox.Show("Please Fill Pay Role No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PayRoleNo.Focus();
                    return;
                }
                if (StaffID.Text == "")
                {
                    MessageBox.Show("Please Fill Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StaffID.Focus();
                    return;
                }
                if (SalaryBank.Text == "")
                {
                    MessageBox.Show("Please Fill Salary Bank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SalaryBank.Focus();
                    return;
                }
                if (AccountName.Text == "")
                {
                    MessageBox.Show("Please Fill Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccountName.Focus();
                    return;
                }
                if (AccountNumber.Text == "")
                {
                    MessageBox.Show("Please Fill Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccountNumber.Focus();
                    return;
                }
                if (NetSalary.Text == "")
                {
                    MessageBox.Show("Please Fill Net Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NetSalary.Focus();
                    return;
                }
                if (Description.Text == "")
                {
                    MessageBox.Show("Please Fill Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Description.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SalaryEarners(EMPLOYER,JOBTITLE,PAYROLENO,STAFFID,SALARYBANK,ACCOUNTNAME,ACCOUNTNUMBER,NETSALARY,DESCRIPTION,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "EMPLOYER"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "JOBTITLE"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "PAYROLENO"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "STAFFID"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 100, "SALARYBANK"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 100, "ACCOUNTNAME"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "ACCOUNTNUMBER"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "NETSALARY"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 500, "DESCRIPTION"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "Staff"));
                cmd.Parameters["@d1"].Value = Employer.Text;
                cmd.Parameters["@d2"].Value = JobTitle.Text;
                cmd.Parameters["@d3"].Value = PayRoleNo.Text;
                cmd.Parameters["@d4"].Value = StaffID.Text;
                cmd.Parameters["@d5"].Value = SalaryBank.Text;
                cmd.Parameters["@d6"].Value = AccountName.Text;
                cmd.Parameters["@d7"].Value = AccountNumber.Text;
                cmd.Parameters["@d8"].Value = NetSalary.Value;
                cmd.Parameters["@d9"].Value = Description.Text;
                cmd.Parameters["@d10"].Value = LoanID.Text;
                cmd.Parameters["@d11"].Value = label2.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                label13.Text = "1";
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoanID_Click(object sender, EventArgs e)
        {
            frmClientDetails4 frm = new frmClientDetails4();
            frm.ShowDialog();
            this.LoanID.Text = frm.LoanID.Text;
            return;
        }
    }
}
