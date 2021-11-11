using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmMoneyTransfer : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp = null;
        public frmMoneyTransfer()
        {
            InitializeComponent();
        }
        public void loadpay()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Dates)[Date],RTRIM(TransactionFlow)[Transaction To],RTRIM(TransactionFlowFrom)[Transaction From],RTRIM(TransactionAmount)[Transaction Amount],RTRIM(TransactionBy)[Transaction By] from CashBankTransactions order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "CashBankTransactions");
                dataGridView1.DataSource = myDataSet.Tables["CashBankTransactions"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMoneyTransfer_Load(object sender, EventArgs e)
        {
            loadpay();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {

                if (amounttransfered.Text == "")
                {
                    MessageBox.Show("Please Input Ammount Transfered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    amounttransfered.Focus();
                    return;
                }
             
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into CashBankTransactions(Dates,TransactionAmount,TransactionFlow,TransactionBy,TransactionFlowFrom) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "Dates"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 10, "TransactionAmount"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "TransactionFlow"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "TransactionBy"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "TransactionFlowFrom"));
                cmd.Parameters["@d1"].Value = Purchasedate.Text;
                cmd.Parameters["@d2"].Value =amounttransfered.Value;
                cmd.Parameters["@d3"].Value = toaccount.Text;
                cmd.Parameters["@d4"].Value = label2.Text;
                cmd.Parameters["@d5"].Value = from.Text;
                cmd.ExecuteNonQuery();
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + from.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount - Convert.ToInt32(amounttransfered.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + Purchasedate.Text + "' where AccountNumber='" + from.Text + "'";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int totalaamounts = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct4 = "select AmountAvailable from BankAccounts where AccountNumber= '" + toaccount.Text + "' ";
                cmd = new SqlCommand(ct4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamounts = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamounts + Convert.ToInt32(amounttransfered.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + Purchasedate.Text + "' where AccountNumber='" +toaccount.Text + "'";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Successfully saved","Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmMoneyTransfer frm = new frmMoneyTransfer();
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void frmMoneyTransfer_Shown(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(AccountNumber),RTRIM(AccountNames) FROM BankAccounts", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    from.Items.Add(drow[0].ToString());
                    toaccount.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
