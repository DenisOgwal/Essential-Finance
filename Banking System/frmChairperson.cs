using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;

namespace Banking_System
{
    public partial class frmChairperson : DevComponents.DotNetBar.Office2007RibbonForm
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmChairperson()
        {
            InitializeComponent();
        }
       
       
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        public DataView GetData()
        {
            dynamic SelectQry = "SELECT RTRIM(LCName)[LC1 Name],RTRIM(LCAddress)[LC1 Address],RTRIM(TelephoneNumbers)[LC1 Contacts],RTRIM(Village)[Village],RTRIM(SubCounty)[SubCounty],RTRIM(County)[County],RTRIM(District)[District] FROM Chairpersons order by ID DESC ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TableView;
        }
        private void FeesDetails_Load(object sender, EventArgs e)
        {
            //this.label12.Text = AssemblyCopyright;
            dataGridView1.DataSource = GetData();
            try
            {
                string prices = null;
                string pricess = null;
                string pricesss = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label4.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["deletes"].ToString().Trim();
                    pricess = rdr["updates"].ToString().Trim();
                    pricesss = rdr["Records"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; }
                    //if (pricesss == "Yes") { buttonX1.Enabled = true; }
                }
                if (label4.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
                    //buttonX1.Enabled = true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Chairpersons where District= '" + District.Text + "' and County= '" + county.Text + "' and Village= '" + village.Text + "' and LCName= '" + lcname.Text + "';";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 50, "Village"));
                cmd.Parameters["@DELETE1"].Value = village.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmProperty frm = new frmProperty();
                    frm.label4.Text = label4.Text;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmProperty frm = new frmProperty();
                    frm.label4.Text = label4.Text;
                    frm.ShowDialog();
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
            this.Hide();
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
            this.Hide();
            frmChairperson frm = new frmChairperson();
            frm.label4.Text = label4.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {

                if (District.Text == "")
                {
                    MessageBox.Show("Please Enter District", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    District.Focus();
                    return;
                }
                if (county.Text == "")
                {
                    MessageBox.Show("Please Enter County", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    county.Focus();
                    return;
                }
                if (subcounty.Text == "")
                {
                    MessageBox.Show("Please Enter Subcounty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    subcounty.Focus();
                    return;
                }
                if (village.Text == "")
                {
                    MessageBox.Show("Please Enter Village", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    village.Focus();
                    return;
                }
               
                if (lcname.Text == "")
                {
                    MessageBox.Show("Please enter LC Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lcname.Focus();
                    return;
                }
                if (lccontacts.Text == "")
                {
                    MessageBox.Show("Please Enter LC Contacts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lccontacts.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ID from Chairpersons where District= '" + District.Text+ "' and County= '" +county.Text + "' and Village= '" + village.Text + "' and LCName= '" + lcname.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Chairpersons(District,County,SubCounty,Village,LCName,LCAddress,TelephoneNumbers) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "District"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "County"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "SubCounty"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "Village"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "LCName"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 100, "LCAddress"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 24, "TelephoneNumbers"));
                cmd.Parameters["@d1"].Value = District.Text;
                cmd.Parameters["@d2"].Value = county.Text;
                cmd.Parameters["@d3"].Value = subcounty.Text;
                cmd.Parameters["@d4"].Value = village.Text;
                cmd.Parameters["@d5"].Value = lcname.Text;
                cmd.Parameters["@d6"].Value = lcaddress.Text;
                cmd.Parameters["@d7"].Value = lccontacts.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Hide();
                frmChairperson frm = new frmChairperson();
                frm.label4.Text = label4.Text;
                frm.ShowDialog();
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (District.Text == "")
                {
                    MessageBox.Show("Please Enter District", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    District.Focus();
                    return;
                }
                if (county.Text == "")
                {
                    MessageBox.Show("Please Enter County", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    county.Focus();
                    return;
                }
                if (subcounty.Text == "")
                {
                    MessageBox.Show("Please Enter Subcounty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    subcounty.Focus();
                    return;
                }
                if (village.Text == "")
                {
                    MessageBox.Show("Please Enter Village", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    village.Focus();
                    return;
                }
                
                if (lcname.Text == "")
                {
                    MessageBox.Show("Please enter Land Lord Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lcname.Focus();
                    return;
                }
                if (lccontacts.Text == "")
                {
                    MessageBox.Show("Please Enter Land Lord Contacts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lccontacts.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Chairpersons set LCName=@d5,LCAddress=@d6,TelephoneNumbers=@d7 where District=@d1 and County=@d2 and SubCounty=@d3 and Village=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "District"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "County"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "SubCounty"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "Village"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "LCName"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 100, "LCAddress"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 24, "TelephoneNumbers"));
                cmd.Parameters["@d1"].Value = District.Text;
                cmd.Parameters["@d2"].Value = county.Text;
                cmd.Parameters["@d3"].Value = subcounty.Text;
                cmd.Parameters["@d4"].Value = village.Text;
                cmd.Parameters["@d5"].Value = lcname.Text;
                cmd.Parameters["@d6"].Value = lcaddress.Text;
                cmd.Parameters["@d7"].Value = lccontacts.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Hide();
                frmChairperson frm = new frmChairperson();
                frm.label4.Text = label4.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                lcname.Text = dr.Cells[0].Value.ToString();
                lcaddress.Text = dr.Cells[1].Value.ToString();
                lccontacts.Text = dr.Cells[2].Value.ToString();
                village.Text = dr.Cells[3].Value.ToString();
                subcounty.Text = dr.Cells[4].Value.ToString();
                county.Text = dr.Cells[5].Value.ToString();
                District.Text = dr.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(LCName)[LC1 Name],RTRIM(LCAddress)[LC1 Address],RTRIM(TelephoneNumbers)[LC1 Contacts],RTRIM(Village)[Village],RTRIM(SubCounty)[SubCounty],RTRIM(County)[County],RTRIM(District)[District] FROM Chairpersons where District like '" + searchbox.Text + "%' OR County like '" + searchbox.Text + "%' OR SubCounty like '" + searchbox.Text + "%' OR Village like '%" + searchbox.Text + "%' OR LCName like '%" + searchbox.Text + "%' OR LCAddress like '%" + searchbox.Text + "%' OR TelephoneNumbers like '%" + searchbox.Text + "%' order by ID DESC ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Chairpersons");
                dataGridView1.DataSource = myDataSet.Tables["Chairpersons"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

