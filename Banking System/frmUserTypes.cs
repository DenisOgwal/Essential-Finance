using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
namespace Banking_System
{
    public partial class frmUserTypes : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmUserTypes()
        {
            InitializeComponent();
        }
        private void Autocomplete()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserType FROM UserTypes", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "UserTypes");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["UserType"].ToString());
            }
            txtEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEmail.AutoCompleteCustomSource = col;
            txtEmail.AutoCompleteMode = AutoCompleteMode.Suggest;

            con.Close();
        }
        private void RecoveryPassword_Load(object sender, EventArgs e)
        {
            Autocomplete();
            txtEmail.Focus();
        }

        private void RecoveryPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter your User type Name please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            try
            {
                SqlDataReader rdr = null;
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserType From UserTypes WHERE  UserType = '" + txtEmail.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("User type. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into UserTypes(UserType) VALUES (@d1)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserType"));
                cmd.Parameters["@d1"].Value = txtEmail.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "UserType Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Hide();
                frmUserTypes frm = new frmUserTypes();
                frm.Show();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                this.Hide();
                frmUserTypes frm = new frmUserTypes();
                frm.Show();
            }
        }
        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from UserTypes where UserType='" + txtEmail.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Autocomplete();
                    txtEmail.Text = "";
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Text = "";
                    //Autocomplete();
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
