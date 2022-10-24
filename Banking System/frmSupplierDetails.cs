using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmSupplierDetails : DevComponents.DotNetBar.Office2007RibbonForm
    {
          DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSupplierDetails()
        {
            InitializeComponent();
        }
        public void loadpay()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(Contact)[Contact] from SupplierAccount order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmClientDetails_Load(object sender, EventArgs e)
        {
            loadpay();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (clientnames.Text == "")
            {
                MessageBox.Show("Please Enter Supplier Names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientnames.Focus();
                return;
            }
            if (clientcontact.Text == "")
            {
                MessageBox.Show("Please Enter Supplier Contacts ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientcontact.Focus();
                return;
            }
            this.Hide();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(AccountNumber)[Account Number],RTRIM(AccountName)[Account Name],RTRIM(Contact)[Contact] from SupplierAccount where AccountNumber like '" + textBoxX1.Text + "%' OR AccountName Like '"+textBoxX1.Text+"%'  order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SupplierAccount");
                dataGridView1.DataSource = myDataSet.Tables["SupplierAccount"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            DataGridViewRow dr = dataGridView1.CurrentRow;
            clientnames.Text=dr.Cells[0].Value.ToString();
            clientcontact.Text = dr.Cells[1].Value.ToString();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
