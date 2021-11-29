using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmAssets : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmAssets()
        {
            InitializeComponent();
        }

        private void FrmAssets_Load(object sender, EventArgs e)
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
                if (ItemName.Text == "")
                {
                    MessageBox.Show("Please Fill Item Name","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    ItemName.Focus();
                    return;
                }
                if (SerialNo.Text == "")
                {
                    MessageBox.Show("Please Fill Serial No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SerialNo.Focus();
                    return;
                }
                if (ModelYear.Text == "")
                {
                    MessageBox.Show("Please Fill Model Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ModelYear.Focus();
                    return;
                }
                if (Color.Text == "")
                {
                    MessageBox.Show("Please Fill Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Color.Focus();
                    return;
                }
                if (Model.Text == "")
                {
                    MessageBox.Show("Please Fill Model", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Model.Focus();
                    return;
                }

                string PropertyDeposited = null;
                if (radioButton1.Checked == true)
                {
                    PropertyDeposited = "No";
                }
                else if (radioButton2.Checked == true)
                {
                    PropertyDeposited = "Yes";
                }
                else
                {
                    MessageBox.Show("Please Select Either of Radio Buttons", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox1.Focus();
                    return;
                }
                    con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Asset(ITEMNAME,SERIALNUMBER,MODELYEAR,COLOR,MODEL,DESCRIPTION,PropertyDeposited,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "ITEMNAME"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "SERIALNUMBER"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "MODELYEAR"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "COLOR"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "MODEL"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 500, "DESCRIPTION"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "PropertyDeposited"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "Staff"));
          
                cmd.Parameters["@d1"].Value =ItemName.Text;
                cmd.Parameters["@d2"].Value =SerialNo.Text;
                cmd.Parameters["@d3"].Value =ModelYear.Text;
                cmd.Parameters["@d4"].Value =Color.Text;
                cmd.Parameters["@d5"].Value =Model.Text;
                cmd.Parameters["@d6"].Value =Description.Text;
                cmd.Parameters["@d7"].Value = PropertyDeposited;
                cmd.Parameters["@d8"].Value = LoanID.Text;
                cmd.Parameters["@d9"].Value = label2.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                label10.Text = "1";
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
