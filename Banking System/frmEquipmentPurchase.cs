using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Banking_System
{
    public partial class frmEquipmentPurchase : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlDataAdapter adp = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmEquipmentPurchase()
        {
            InitializeComponent();
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
        private void auto()
        {
            purchaseid.Text = "EPD-" + GetUniqueKey(5);
        }
        public void Reset()
        {
            
            equipmentname.Text = "";
            model.Text = "";
            //totalcost.Text = "";
            manufacturer.Text = "";
            quantity.Text = "";
            units.Text = "";
            specifications.Text = "";
            //costperunit.Text = "";
            //totalcost.Text = "";
            invoices.Text = "";
            purchaseid.Text = "";
        }
        private void frmEquipmentPurchase_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.outlet.Text = outlet.Text;
            frm.Show();*/
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            frmEquipmentRecord frm = new frmEquipmentRecord();
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Reference from Others where Reference=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "Reference"));
                cmd.Parameters["@find"].Value = purchaseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from EquipmentPurchase where PurchaseID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PurchaseID"));
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

        private void buttonX3_Click(object sender, EventArgs e)
        {
           
            if (equipmentname.Text == "")
            {
                MessageBox.Show("Please enter equipment name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                equipmentname.Focus();
                return;
            }
            if (manufacturer.Text == "")
            {
                MessageBox.Show("Please enter manufaturer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                manufacturer.Focus();
                return;
            }
            if (quantity.Text == "")
            {
                MessageBox.Show("Please enter quanity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Focus();
                return;
            }
            if (units.Text == "")
            {
                MessageBox.Show("Please select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                units.Focus();
                return;
            }
            if (costperunit.Text == "")
            {
                MessageBox.Show("Please enter Unit Costs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                costperunit.Focus();
                return;
            }
            if (invoices.Text == "")
            {
                MessageBox.Show("Please enter Invoice no else n/a", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                invoices.Focus();
                return;
            }
            auto();
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select PurchaseID from EquipmentPurchase where PurchaseID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "PurchaseID"));
                cmd.Parameters["@find"].Value = purchaseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Purchase ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    purchaseid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into EquipmentPurchase(PurchaseID,StaffID,Equipmentname,PurchaseDate,Manufacturer,Quantity,Units,Specifications,UnitCost,TotalCost,Description,Model,InvoiceNo,ModeOfPayment,Supplier) VALUES (@d1,@d2,@d3,@d4,@d9,@d11,@d12,@d15,@d17,@d18,@d20,@d21,@d22,'" + paymentmode.Text + "','"+label3.Text+"')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PurchaseID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "EquipmentnameName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PurchaseDate"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 40, "Manufacturer"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 15, "Quantity"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.VarChar, 20, "Units"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 200, "Specifications"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 15, "UnitCost"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.Int, 15, "TotalCost"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 30, "Model"));
                cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 20, "InvoiceNo"));
                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = label1.Text;
                cmd.Parameters["@d3"].Value = equipmentname.Text.Trim();
                cmd.Parameters["@d4"].Value = purchasedate.Text.Trim();
                cmd.Parameters["@d9"].Value = manufacturer.Text.Trim();
                cmd.Parameters["@d11"].Value = quantity.Text.Trim();
                cmd.Parameters["@d12"].Value = units.Text.Trim();
                cmd.Parameters["@d15"].Value = specifications.Text.Trim();
                cmd.Parameters["@d17"].Value = costperunit.Value;
                cmd.Parameters["@d18"].Value = totalcost.Value;
                cmd.Parameters["@d20"].Value = description.Text.Trim();
                cmd.Parameters["@d21"].Value = model.Text.Trim();
                cmd.Parameters["@d22"].Value = invoices.Text.Trim();  
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into SupplierAccountTransactions(AccountNumber,TransactionID,Reason,Ammount,Date) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Reason"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "Ammount"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters["@d1"].Value = Supplier.Text;
                cmd.Parameters["@d2"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d3"].Value = equipmentname.Text+" Purchase on " + DateTime.Now;
                cmd.Parameters["@d4"].Value = totalcost.Value;
                cmd.Parameters["@d5"].Value = purchasedate.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                /*
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= '" + paymentmode.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount - Convert.ToInt32(totalcost.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb4 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + purchasedate.Text + "' where AccountNumber='" + paymentmode.Text + "'";
                    cmd = new SqlCommand(cb4);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }*/
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
           
            if (equipmentname.Text == "")
            {
                MessageBox.Show("Please enter equipment name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                equipmentname.Focus();
                return;
            }
            if (manufacturer.Text == "")
            {
                MessageBox.Show("Please enter manufaturer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                manufacturer.Focus();
                return;
            }
            if (quantity.Text == "")
            {
                MessageBox.Show("Please enter quanity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Focus();
                return;
            }
            if (units.Text == "")
            {
                MessageBox.Show("Please select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                units.Focus();
                return;
            }
            if (costperunit.Text == "")
            {
                MessageBox.Show("Please enter Unit Costs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                costperunit.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update DrugPurchase set StaffID=@d2,EquipmentnameName=@d3,PurchaseDate=@d4,Manufacturer=@d9,Quantity=@d11,Units=@d12,Specifications=@d15,UnitCost=@d17,TotalCost=@d18,Description=@d20,Model=@d21 where PurchaseID='" + purchaseid.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PurchaseID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 40, "EquipmentnameName"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "PurchaseDate"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 40, "Manufacturer"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 15, "Quantity"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.VarChar, 20, "Units"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 200, "Specifications"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 15, "UnitCost"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.Int, 15, "TotalCost"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 30, "Model"));
                cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 20, "InvoiceNo"));
                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = label1.Text;
                cmd.Parameters["@d3"].Value = equipmentname.Text.Trim();
                cmd.Parameters["@d4"].Value = purchasedate.Text.Trim();
                cmd.Parameters["@d9"].Value = manufacturer.Text.Trim();
                cmd.Parameters["@d11"].Value = quantity.Text.Trim();
                cmd.Parameters["@d12"].Value = units.Text.Trim();
                cmd.Parameters["@d15"].Value = specifications.Text.Trim();
                cmd.Parameters["@d17"].Value = costperunit.Value;
                cmd.Parameters["@d18"].Value = totalcost.Value;
                cmd.Parameters["@d20"].Value = description.Text.Trim();
                cmd.Parameters["@d21"].Value = model.Text.Trim();
                cmd.Parameters["@d22"].Value = invoices.Text.Trim();  
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void noperunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void costperunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void totalcost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        private void frmEquipmentPurchase_Load(object sender, EventArgs e)
        {
            /*Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;*/
            try
            {
                string prices = null;
                string pricess = null;
                string pricesss = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["deletes"].ToString().Trim();
                    pricess = rdr["updates"].ToString().Trim();
                    pricesss = rdr["Records"].ToString().Trim();
                    if (prices == "Yes") { buttonX4.Enabled = true; }
                    if (pricess == "Yes") { buttonX5.Enabled = true; }
                    if (pricesss == "Yes") { buttonX6.Enabled = true; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX4.Enabled = true;
                    buttonX5.Enabled = true;
                    buttonX6.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            frmEquipmentReport frm = new frmEquipmentReport();
            frm.ShowDialog();
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            frmSupplierDetails frm = new frmSupplierDetails();
            frm.ShowDialog();
            this.Supplier.Text = frm.clientnames.Text;
            this.label3.Text = frm.clientcontact.Text;
            return;
        }

        private void frmEquipmentPurchase_Shown(object sender, EventArgs e)
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
                    paymentmode.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void costperunit_ValueChanged(object sender, EventArgs e)
        {
            if (quantity.Text == "" && purchaseid.Text == "")
            {
                MessageBox.Show("Please First enter quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Focus();
                return;
            }
            int val1 = 0;
            int val2 = 0;
            int.TryParse(quantity.Text, out val1);
            int.TryParse(costperunit.Value.ToString(), out val2);
            int I = (val2 * val1);
            totalcost.Text = I.ToString();
        }
    }
}
