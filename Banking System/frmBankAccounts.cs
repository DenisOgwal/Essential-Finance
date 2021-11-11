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
    public partial class frmBankAccounts : DevComponents.DotNetBar.Office2007RibbonForm
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmBankAccounts()
        {
            InitializeComponent();
        }
       
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
           // purchaseid.Text = "PRO-" + years + monthss + days + GetUniqueKey(5);
        }

      

      
        private void Reset()
        {
            bankname.Text = "";
            accountnumber.Text = "";
            bankno.Text = "";
        }

       
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from BankAccounts where AccountNumber=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "AccountNumber"));
                cmd.Parameters["@DELETE1"].Value = accountnumber.Text;
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

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void frmPurchaseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMainMenu frm = new frmMainMenu();
            this.Hide();
            Reset();
            /*frm.UserType.Text = label13.Text;
            frm.User.Text = label21.Text;
            frm.Show();*/
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void product_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {

                if (bankname.Text == "")
                {
                    MessageBox.Show("Please Enter Bank Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bankname.Focus();
                    return;
                }
                if (accountnumber.Text == "")
                {
                    MessageBox.Show("Please Enter Bank Account Number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountnumber.Focus();
                    return;
                }
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AccountNumber from BankAccounts where AccountNumber= '" + accountnumber.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into BankAccounts(AccountNumber,AccountNames,Date,BankNo) VALUES (@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "BankNo"));
                
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = bankname.Text.Trim();
                cmd.Parameters["@d3"].Value = registrationdate.Text;
                cmd.Parameters["@d4"].Value = bankno.Text;
                cmd.ExecuteNonQuery();
                Reset();
                MessageBox.Show("Successfully saved", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void product_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void frmBankAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}

