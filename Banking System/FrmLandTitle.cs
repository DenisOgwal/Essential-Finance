using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLandTitle : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmLandTitle()
        {
            InitializeComponent();
        }

        private void FrmLandTitle_Load(object sender, EventArgs e)
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
                if (Plot.Text == "")
                {
                    MessageBox.Show("Please Fill Plot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Plot.Focus();
                    return;
                }
                if (Block.Text == "")
                {
                    MessageBox.Show("Please Fill Block", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Block.Focus();
                    return;
                }
                if (County.Text == "")
                {
                    MessageBox.Show("Please Fill County", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    County.Focus();
                    return;
                }
                if (Volume.Text == "")
                {
                    MessageBox.Show("Please Fill Volume", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Volume.Focus();
                    return;
                }
                if (Folio.Text == "")
                {
                    MessageBox.Show("Please Fill Folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Folio.Focus();
                    return;
                }
                if (LandAt.Text == "")
                {
                    MessageBox.Show("Please Fill Land At", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LandAt.Focus();
                    return;
                }
                if (LandSize.Text == "")
                {
                    MessageBox.Show("Please Fill Size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LandSize.Focus();
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
                string cb = "insert into LandTitle(DISTRICT,PLOT,BLOCK,COUNTY,VOLUME,FOLIO,LANDAT,SIZE,Developments,Occupants,Description,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "DISTRICT"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "PLOT"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "BLOCK"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 100, "COUNTY"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "VOLUME"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 50, "FOLIO"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "LANDAT"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "SIZE"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Text, 500, "Developments"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Text, 500, "Occupants"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Text, 500, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Staff"));
                cmd.Parameters["@d1"].Value = District.Text;
                cmd.Parameters["@d2"].Value = Plot.Text;
                cmd.Parameters["@d3"].Value = Block.Text;
                cmd.Parameters["@d4"].Value = County.Text;
                cmd.Parameters["@d5"].Value = Volume.Text;
                cmd.Parameters["@d6"].Value = Folio.Text;
                cmd.Parameters["@d7"].Value = LandAt.Text;
                cmd.Parameters["@d8"].Value = LandSize.Text;
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
