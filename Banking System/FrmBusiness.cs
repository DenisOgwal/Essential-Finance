using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmBusiness : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmBusiness()
        {
            InitializeComponent();
        }

        private void FrmBusiness_Load(object sender, EventArgs e)
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
                if (BusinessName.Text == "")
                {
                    MessageBox.Show("Please Fill Business Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BusinessName.Focus();
                    return;
                }
                if (Lockup.Text == "")
                {
                    MessageBox.Show("Please Fill Lockup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lockup.Focus();
                    return;
                }
                if (RegNo.Text == "")
                {
                    MessageBox.Show("Please Fill Reg No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegNo.Focus();
                    return;
                }
                if (Locations.Text == "")
                {
                    MessageBox.Show("Please Fill Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Locations.Focus();
                    return;
                }
                if (AttendantName.Text == "")
                {
                    MessageBox.Show("Please Fill Attendant Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AttendantName.Focus();
                    return;
                }
                if (Dealership.Text == "")
                {
                    MessageBox.Show("Please Fill Dealership", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dealership.Focus();
                    return;
                }
                if (MaturityDate.Text == "")
                {
                    MessageBox.Show("Please Fill Maturity Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MaturityDate.Focus();
                    return;
                }
                if (Bank.Text == "")
                {
                    MessageBox.Show("Please Fill Bank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Bank.Focus();
                    return;
                }
                if (chequeleaves.Text == "")
                {
                    MessageBox.Show("Please Fill Cheque Leaves", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chequeleaves.Focus();
                    return;
                }
                if (Description.Text == "")
                {
                    MessageBox.Show("Please Fill Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Description.Focus();
                    return;
                }
                string businesstype = null;
                if (radioButton1.Checked == true)
                {
                    businesstype = "Business";
                }
                else if (radioButton2.Checked == true)
                {
                    businesstype = "Company";
                }
                else
                {
                    MessageBox.Show("Please Select Business or Company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox1.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Business(Type,NAME,LOCKUP,REGNO,LOCATION,ATTENDANTSNAME,DEALERSHIP,DESCRIPTION,StandingOrders,MaturityDate,Bank,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "Type"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "NAME"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "LOCKUP"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "REGNO"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 100, "LOCATION"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 60, "ATTENDANTSNAME"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Text, 500, "DEALERSHIP"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Text, 500, "DESCRIPTION"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "StandingOrders"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 20, "MaturityDate"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "Bank"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Staff"));
                cmd.Parameters["@d1"].Value = businesstype;
                cmd.Parameters["@d2"].Value = BusinessName.Text;
                cmd.Parameters["@d3"].Value = Lockup.Text;
                cmd.Parameters["@d4"].Value = RegNo.Text;
                cmd.Parameters["@d5"].Value = Locations.Text;
                cmd.Parameters["@d6"].Value = AttendantName.Text;
                cmd.Parameters["@d7"].Value = Dealership.Text;
                cmd.Parameters["@d8"].Value = Description.Text;
                cmd.Parameters["@d9"].Value = chequeleaves.Text;
                cmd.Parameters["@d10"].Value = MaturityDate.Text;
                cmd.Parameters["@d11"].Value = Bank.Text;
                cmd.Parameters["@d12"].Value = LoanID.Text;
                cmd.Parameters["@d13"].Value = label2.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                label14.Text = "1";
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
