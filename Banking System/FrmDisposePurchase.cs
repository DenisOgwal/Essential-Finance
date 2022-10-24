using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Banking_System
{
    public partial class FrmDisposePurchase : Form
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        ConnectionString cs = new ConnectionString();
        public FrmDisposePurchase()
        {
            InitializeComponent();
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        private void cashierid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(cashierid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and ManagingDirector='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        cashiername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        cashiername.Text = "";
                    }
                }
                else
                {
                    cashiername.Text = "";
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDisposePurchase frm = new FrmDisposePurchase();
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (DisposeAsset.Text == "")
            {
                MessageBox.Show("Please enter equipment name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisposeAsset.Focus();
                return;
            }
            if (DisposePurchaseID.Text == "")
            {
                MessageBox.Show("Please Slect ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisposePurchaseID.Focus();
                return;
            }
            if (DisposeValue.Text == "")
            {
                MessageBox.Show("Please enter Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisposeValue.Focus();
                return;
            }
            if (cashiername.Text == "")
            {
                MessageBox.Show("Please enter Approval Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashiername.Focus();
                return;
            }
            if (quantity.Text == "")
            {
                MessageBox.Show("Please enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into AssetDisposal(Asset,PurchaseID,DisposalAmount,DisposalDate,DisposedBy,ApprovedBy,Quantity) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "Asset"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "PurchaseID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "DisposalAmount"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "DisposalDate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "DisposedBy"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Quantity"));
                cmd.Parameters["@d1"].Value = DisposeAsset.Text;
                cmd.Parameters["@d2"].Value = DisposePurchaseID.Text.Trim();
                cmd.Parameters["@d3"].Value = DisposeValue.Value;
                cmd.Parameters["@d4"].Value = registrationdate.Text;
                cmd.Parameters["@d5"].Value = DisposedBy.Text;
                cmd.Parameters["@d6"].Value = cashiername.Text;
                cmd.Parameters["@d7"].Value = quantity.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                int totaldisposepurcost = Convert.ToInt32(Convert.ToDouble(label7.Text)) * Convert.ToInt32(Convert.ToDouble(quantity.Value));
                int totalEquipmentcost = Convert.ToInt32(Convert.ToDouble(label8.Text));
                int totals = totalEquipmentcost - totaldisposepurcost;
                int qty= Convert.ToInt32(Convert.ToDouble(label9.Text))- Convert.ToInt32(Convert.ToDouble(quantity.Value));
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE EquipmentPurchase SET Disposed='Yes' WHERE PurchaseID='"+DisposePurchaseID.Text+"' ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "Asset"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "PurchaseID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "DisposalAmount"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "DisposalDate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "DisposedBy"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "ApprovedBy"));
                cmd.Parameters["@d1"].Value = DisposeAsset.Text;
                cmd.Parameters["@d2"].Value = DisposePurchaseID.Text.Trim();
                cmd.Parameters["@d3"].Value = DisposeValue.Value;
                cmd.Parameters["@d4"].Value = registrationdate.Text;
                cmd.Parameters["@d5"].Value = DisposedBy.Text;
                cmd.Parameters["@d6"].Value = cashiername.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataReader rdr = null;
                int totalaamount = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select AmountAvailable from BankAccounts where AccountNames= '" + cmbModeOfPayment.Text + "' ";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                    int newtotalammount = totalaamount + Convert.ToInt32(DisposeValue.Value);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + registrationdate.Text + "' where AccountNames='" + cmbModeOfPayment.Text + "'";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmDisposePurchase frm = new FrmDisposePurchase();
                frm.ShowDialog();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Equipmentname) FROM EquipmentPurchase", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                DisposeAsset.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    DisposeAsset.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmDisposePurchase_Load(object sender, EventArgs e)
        {
            AutocompleteStaffName();
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
                    cmbModeOfPayment.Items.Add(drow[1].ToString());
                }
                CN.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisposeAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(PurchaseID) FROM EquipmentPurchase where Equipmentname='"+DisposeAsset.Text+"'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                DisposePurchaseID.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    DisposePurchaseID.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisposePurchaseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                string ct = "SELECT UnitCost,TotalCost,Quantity FROM EquipmentPurchase where Equipmentname='" + DisposeAsset.Text.Trim() + "' and PurchaseID='"+DisposePurchaseID.Text.Trim()+"' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label7.Text = rdr["UnitCost"].ToString().Trim();
                    label8.Text = rdr["TotalCost"].ToString().Trim();
                    label9.Text = rdr["Quantity"].ToString().Trim();
                }
                else
                {
                   label7.Text = "";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
