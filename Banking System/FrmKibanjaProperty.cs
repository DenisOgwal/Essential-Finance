using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Banking_System
{
    public partial class FrmKibanjaProperty : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmKibanjaProperty()
        {
            InitializeComponent();
        }

        private void FrmKibanjaProperty_Load(object sender, EventArgs e)
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
                if (District.Text == "")
                {
                    MessageBox.Show("Please Fill District", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    District.Focus();
                    return;
                }
                if (County.Text == "")
                {
                    MessageBox.Show("Please Fill County.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    County.Focus();
                    return;
                }
                if (Subcounty.Text == "")
                {
                    MessageBox.Show("Please Fill Subcounty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Subcounty.Focus();
                    return;
                }
                if (Village.Text == "")
                {
                    MessageBox.Show("Please Fill Village", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Village.Focus();
                    return;
                }
                if (KibanjaSize.Text == "")
                {
                    MessageBox.Show("Please Fill Size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    KibanjaSize.Focus();
                    return;
                }
                if (CurrentOwner.Text == "")
                {
                    MessageBox.Show("Please Fill Current Owner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CurrentOwner.Focus();
                    return;
                }
                if (PreviousOwner.Text == "")
                {
                    MessageBox.Show("Please Fill Previous Owner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PreviousOwner.Focus();
                    return;
                }
                if (LC1Chairman.Text == "")
                {
                    MessageBox.Show("Please Fill LC 1 Chairman", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LC1Chairman.Focus();
                    return;
                }
                if (Developments.Text == "")
                {
                    MessageBox.Show("Please Fill Developments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Developments.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into KibanjaProperty(DISTRICT,COUNTY,SUBCOUNTY,VILLAGE,SIZE,CURRENTOWNER,PREVIOUSOWNER,LC1CHAIRMAN,Developments,Occupants,Description,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "DISTRICT"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "COUNTY"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "SUBCOUNTY"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "VILLAGE"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 100, "SIZE"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 50, "CURRENTOWNER"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "PREVIOUSOWNER"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 100, "LC1CHAIRMAN"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 500, "Developments"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Text, 500, "Occupants"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Text, 500, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Staff"));
                cmd.Parameters["@d1"].Value = District.Text;
                cmd.Parameters["@d2"].Value = County.Text;
                cmd.Parameters["@d3"].Value = Subcounty.Text;
                cmd.Parameters["@d4"].Value = Village.Text;
                cmd.Parameters["@d5"].Value = KibanjaSize.Text;
                cmd.Parameters["@d6"].Value = CurrentOwner.Text;
                cmd.Parameters["@d7"].Value = PreviousOwner.Text;
                cmd.Parameters["@d8"].Value = LC1Chairman.Text;
                cmd.Parameters["@d9"].Value = Developments.Text;
                cmd.Parameters["@d10"].Value = Occupants.Text;
                cmd.Parameters["@d11"].Value = Description.Text;
                cmd.Parameters["@d12"].Value = LoanID.Text;
                cmd.Parameters["@d13"].Value = label2.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                label15.Text = "1";
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
