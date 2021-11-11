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
using System.Reflection;
namespace Banking_System
{
    public partial class frmPlant : DevComponents.DotNetBar.Office2007RibbonForm
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmPlant()
        {
            InitializeComponent();
        }
        
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            purchaseid.Text = "PL-" + years + monthss + days + GetUniqueKey(5);
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
        private void FeesDetails_Load(object sender, EventArgs e)
        {
            this.label12.Text = AssemblyCopyright;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }


        private void Reset()
        {
            purchaseid.Text = "";
            product.Text = "";
            Price.Text = "";
            units.Text = "";
            description.Text = "";
           
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Plant where PlantID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PlantID"));
                cmd.Parameters["@DELETE1"].Value = purchaseid.Text;
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

                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select product from Plant where Product= '" + product.Text + "' and Price= '" + Price.Text + "'";
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
                auto();
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Plant(PlantID,product,units,PriceDate,description,Price) VALUES (@d1,@d2,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PlantID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 30, "Price"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = product.Text.Trim();
                cmd.Parameters["@d5"].Value = units.Text.Trim();
                cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d7"].Value = description.Text;
                cmd.Parameters["@d8"].Value = Price.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }

                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter  product description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Plant set Price=@d8, product=@d2,units=@d5,description=@d7,PriceDate=@d6 where PlantID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PlantID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 30, "Price"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = product.Text.Trim();
                cmd.Parameters["@d5"].Value = units.Text.Trim();
                cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d7"].Value = description.Text;
                cmd.Parameters["@d8"].Value = Price.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Plant Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void product_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

