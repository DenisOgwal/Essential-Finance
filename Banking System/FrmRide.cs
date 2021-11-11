using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmRide : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public FrmRide()
        {
            InitializeComponent();
        }

        private void FrmRide_Load(object sender, EventArgs e)
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
                if (RideType.Text == "")
                {
                    MessageBox.Show("Please Fill Item Ride Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RideType.Focus();
                    return;
                }
                if (PlateNo.Text == "")
                {
                    MessageBox.Show("Please Fill Plate No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PlateNo.Focus();
                    return;
                }
                if (ModelNo.Text == "")
                {
                    MessageBox.Show("Please Fill Model No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ModelNo.Focus();
                    return;
                }
                if (RideColor.Text == "")
                {
                    MessageBox.Show("Please Fill Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RideColor.Focus();
                    return;
                }
                if (Description.Text == "")
                {
                    MessageBox.Show("Please Fill Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Description.Focus();
                    return;
                }

                string PropertyDeposited = null;
                if (radioButton5.Checked == true)
                {
                    PropertyDeposited = "No";
                }
                else if (radioButton4.Checked == true)
                {
                    PropertyDeposited = "Yes";
                }
                else
                {
                    MessageBox.Show("Please Select whether Property is Deposited or Not", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox2.Focus();
                    return;
                }
                string ridecategory = null;
                if (radioButton1.Checked == true)
                {
                    ridecategory = "Vahicle";
                }
                else if (radioButton2.Checked == true)
                {
                    ridecategory = "Motorcycle";
                }
                else if (radioButton3.Checked == true)
                {
                    ridecategory = "Bicycle";
                }
                else
                {
                    MessageBox.Show("Please Select Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox1.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Ride(RideType,Category,PlateNo,ModelYear,Color,Description,PropertyDeposited,LoanID,Staff) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "RideType"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Category"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "PlateNo"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "ModelYear"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Color"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Text, 500, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "PropertyDeposited"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "LoanID"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 50, "Staff"));

                cmd.Parameters["@d1"].Value = RideType.Text;
                cmd.Parameters["@d2"].Value = ridecategory;
                cmd.Parameters["@d3"].Value = PlateNo.Text;
                cmd.Parameters["@d4"].Value = ModelNo.Text;
                cmd.Parameters["@d5"].Value = RideColor.Text;
                cmd.Parameters["@d6"].Value = Description.Text;
                cmd.Parameters["@d7"].Value = PropertyDeposited;
                cmd.Parameters["@d8"].Value = LoanID.Text;
                cmd.Parameters["@d9"].Value = label2.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                label9.Text = "1";
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
