using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Banking_System
{
    public partial class frmWithdrawminimum : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmWithdrawminimum()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            interestrate.Text = "";
            chairperson.Text = "";
            chairpersonid.Text = "";
        }
        private void frmWithdrawminimum_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (chairperson.Text == "")
            {
                MessageBox.Show("Please enter Chairperson Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chairperson.Focus();
                return;
            }
            if (chairpersonid.Text == "")
            {
                MessageBox.Show("Please Select ChairPerson ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chairpersonid.Focus();
                return;
            }
            if (interestrate.Text == "")
            {
                MessageBox.Show("Please enter Interest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                interestrate.Focus();
                return;
            }
            try
            {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into MinimumWithdraw(Months,Year,SettingDate,MinimumFee,ChairPerson) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "SettingDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 20, "MinimumFee"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 40, "ChairPerson"));
                cmd.Parameters["@d1"].Value = month1.Text;
                cmd.Parameters["@d2"].Value = year1.Text.Trim();
                cmd.Parameters["@d3"].Value = date1.Text.Trim();
                cmd.Parameters["@d4"].Value = interestrate.Text;
                cmd.Parameters["@d5"].Value = chairperson.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Savings Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete * from  MinimumWithdraw where Months=@DELETE1 and Year=@delete2 and SettingDate=@date3;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "Months"));
                cmd.Parameters["@DELETE1"].Value = month1.Text;
                cmd.Parameters.Add(new SqlParameter("@delete2", System.Data.SqlDbType.NChar, 15, "Year"));
                cmd.Parameters["@DELETE1"].Value = year1.Text;
                cmd.Parameters.Add(new SqlParameter("@delete3", System.Data.SqlDbType.NChar, 15, "SettingDate"));
                cmd.Parameters["@DELETE1"].Value = date1.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update MinimumWithdraw set MinimumFee=@d4 where Year=@d2 and Months=@d1 and SettingDate=@d3";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "SettingDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 20, "MinimumFee"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ChairPerson"));
                cmd.Parameters["@d1"].Value = month1.Text;
                cmd.Parameters["@d2"].Value = year1.Text.Trim();
                cmd.Parameters["@d3"].Value = date1.Text.Trim();
                cmd.Parameters["@d4"].Value = interestrate.Text;
                cmd.Parameters["@d5"].Value = chairperson.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Interest Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chairpersonid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName FROM Rights WHERE AuthorisationID = '" + chairpersonid.Text + "' and Category='ChairPerson'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    chairperson.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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
    }
}
