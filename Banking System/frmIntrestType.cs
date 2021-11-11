using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmIntrestType : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmIntrestType()
        {
            InitializeComponent();
        }

        private void frmIntrestType_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string co2 = "SELECT IntrestTy from IntrestType";
            cmd = new SqlCommand(co2);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                string intrestty = rdr["IntrestTy"].ToString().Trim();
                if (intrestty== "ReducingBalance") {
                    radioButton2.Checked = true;
                }
                else if (intrestty == "FlatRate")
                {
                    radioButton1.Checked = true;
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string intresttypes = "null";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                intresttypes = "FlatRate";
            }
            else
            {
                radioButton2.Checked = true;
                intresttypes = "ReducingBalance";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                intresttypes = "ReducingBalance";
            }
            else
            {
                radioButton1.Checked = true;
                intresttypes = "FlatRate";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update IntrestType set IntrestTy=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "IntrestTy"));
                cmd.Parameters["@d1"].Value = intresttypes;
                cmd.ExecuteNonQuery();
                /* Properties.Settings.Default["intresttype"] = intresttypes;
                 Properties.Settings.Default.Save();*/
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}
