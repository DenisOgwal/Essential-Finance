using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using AForge.Video;
using AForge.Video.DirectShow;
namespace Banking_System
{
    public partial class frmInvestorAccount : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        private VideoCaptureDevice videosource;
        private FilterInfoCollection capturedevice;
        public frmInvestorAccount()
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
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            int realid = 0;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select ID from InvestorAccount Order By ID DESC";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select COUNT(AccountNumber) from InvestorAccount", con);
                realid = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                realid = 1;
            }
            string convertedid = "";
            if (realid < 10)
            {
                convertedid = "00" + realid;
            }
            else if (realid < 100)
            {
                convertedid = "0" + realid;
            }
            else
            {
                convertedid = "" + realid;
            }
            string years = yearss.Substring(2, 2);
            accountnumber.Text = "20" + years + monthss + days + convertedid;
        }
        public void Reset()
        {
            this.Hide();
            frmInvestorAccount frm = new frmInvestorAccount();
            frm.label33.Text = label33.Text;
            frm.label34.Text = label34.Text;
            frm.ShowDialog();
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            var _with1 = openFileDialog1;
            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;
            //Clear the file name
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInvestorAccount frm = new frmInvestorAccount();
            frm.label33.Text = label33.Text;
            frm.label34.Text = label34.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            auto();
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (Gender.Text == "")
            {
                MessageBox.Show("Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Gender.Focus();
                return;
            }
            if (nationalitystatus.Text == "")
            {
                MessageBox.Show("Please select Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nationalitystatus.Focus();
                return;
            }
            if (DOB.Text == "")
            {
                MessageBox.Show("Please enter dob", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DOB.Focus();
                return;
            }
            if (maritalstatus.Text == "")
            {
                MessageBox.Show("Please select religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maritalstatus.Focus();
                return;
            }
            if (nationality.Text == "")
            {
                MessageBox.Show("Please enter nationality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nationality.Focus();
                return;
            }
            if (idform.Text == "")
            {
                MessageBox.Show("Please Select ID Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idform.Focus();
                return;
            }
            if (NIN.Text == "")
            {
                MessageBox.Show("Please enter national Identity number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NIN.Focus();
                return;
            }
            if (ContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactNo.Focus();
                return;
            }
            if (ContactNo2.Text == "")
            {
                MessageBox.Show("Please enter contact no. 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactNo2.Focus();
                return;
            }
            if (OfficeNo.Text == "")
            {
                MessageBox.Show("Please enter office no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OfficeNo.Focus();
                return;
            }
            if (Email.Text == "")
            {
                MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Email.Focus();
                return;
            }
            if (PostalAddress.Text == "")
            {
                MessageBox.Show("Please select address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PostalAddress.Focus();
                return;
            }
            if (PhysicalAddress.Text == "")
            {
                MessageBox.Show("Please enter Residence.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhysicalAddress.Focus();
                return;
            }
            if (BankName.Text == "")
            {
                MessageBox.Show("Please enter Bank Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankName.Focus();
                return;
            }
            if (BankAccountName.Text == "")
            {
                MessageBox.Show("Please enter Bank Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankAccountName.Focus();
                return;
            }
            if (BankAccountNumber.Text == "")
            {
                MessageBox.Show("Please enter Bank Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankAccountNumber.Focus();
                return;
            }
            if (GuardianName.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianName.Focus();
                return;
            }
            if (GuardianContactNo.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianContactNo.Focus();
                return;
            }
            if (GuardianAddress.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianAddress.Focus();
                return;
            }
            if (Relationship.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Relationship", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Relationship.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into InvestorAccount(AccountNumber,AccountNames,RegistrationDate,Gender,DOB,MaritalStatus,Nationality,NationalityStatus,IDForm,ClientID,ContactNo,ContactNo1,OfficeNo,Email,PhysicalAddress,PostalAddress,BankName,BankAccountName,BankAccountNumber,NOKName,NOKContactNo,NOKAddress,NOKRelationship,CreatedBy,AccountPicture,Signature,AccountType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d33,@d34,@d35,@d36)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "RegistrationDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "DOB"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "MaritalStatus"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "Nationality"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "NationalityStatus"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "IDForm"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ClientID"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "ContactNo1"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "OfficeNo"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 100, "PhysicalAddress"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 100, "PostalAddress"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 100, "BankName"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 100, "BankAccountName"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 20, "BankAccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "NOKName"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "NOKContactNo"));
                cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 100, "NOKAddress"));
                cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 30, "NOKRelationship"));
                cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 50, "CreatedBy"));
                cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 30, "AccountType"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = accountname.Text.Trim();
                cmd.Parameters["@d3"].Value = dateofregistration.Text.Trim();
                cmd.Parameters["@d4"].Value = Gender.Text;
                cmd.Parameters["@d5"].Value = DOB.Text;
                cmd.Parameters["@d6"].Value = maritalstatus.Text;
                cmd.Parameters["@d7"].Value = nationality.Text;
                cmd.Parameters["@d8"].Value = nationalitystatus.Text;
                cmd.Parameters["@d9"].Value = idform.Text;
                cmd.Parameters["@d10"].Value = NIN.Text;
                cmd.Parameters["@d11"].Value = ContactNo.Text;
                cmd.Parameters["@d12"].Value = ContactNo2.Text;
                cmd.Parameters["@d13"].Value = OfficeNo.Text;
                cmd.Parameters["@d14"].Value = Email.Text;
                cmd.Parameters["@d15"].Value = PhysicalAddress.Text;
                cmd.Parameters["@d16"].Value = PostalAddress.Text;
                cmd.Parameters["@d17"].Value = BankName.Text;
                cmd.Parameters["@d18"].Value = BankAccountName.Text;
                cmd.Parameters["@d19"].Value = BankAccountNumber.Text;
                cmd.Parameters["@d20"].Value = GuardianName.Text;
                cmd.Parameters["@d21"].Value = GuardianContactNo.Text;
                cmd.Parameters["@d22"].Value = GuardianAddress.Text;
                cmd.Parameters["@d23"].Value = Relationship.Text;
                cmd.Parameters["@d33"].Value = label33.Text;
                cmd.Parameters["@d36"].Value = "N/A";
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d34", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                MemoryStream ms3 = new MemoryStream();
                Bitmap bmpImage3 = new Bitmap(pictureBox4.Image);
                bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data3 = ms3.GetBuffer();
                SqlParameter p3 = new SqlParameter("@d35", SqlDbType.Image);
                p3.Value = data3;
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonX2.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmInvestorAccount frm = new frmInvestorAccount();
            frm.label33.Text = label33.Text;
            frm.label34.Text = label34.Text;
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (accountnumber.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountnumber.Focus();
                return;
            }
            if (accountname.Text == "")
            {
                MessageBox.Show("Please enter Member Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountname.Focus();
                return;
            }
            if (Gender.Text == "")
            {
                MessageBox.Show("Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Gender.Focus();
                return;
            }
            if (nationalitystatus.Text == "")
            {
                MessageBox.Show("Please select Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nationalitystatus.Focus();
                return;
            }
            if (DOB.Text == "")
            {
                MessageBox.Show("Please enter dob", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DOB.Focus();
                return;
            }
            if (maritalstatus.Text == "")
            {
                MessageBox.Show("Please select religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maritalstatus.Focus();
                return;
            }
            if (nationality.Text == "")
            {
                MessageBox.Show("Please enter nationality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nationality.Focus();
                return;
            }
            if (idform.Text == "")
            {
                MessageBox.Show("Please Select ID Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idform.Focus();
                return;
            }
            if (NIN.Text == "")
            {
                MessageBox.Show("Please enter national Identity number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NIN.Focus();
                return;
            }
            if (ContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactNo.Focus();
                return;
            }
            if (ContactNo2.Text == "")
            {
                MessageBox.Show("Please enter contact no. 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactNo2.Focus();
                return;
            }
            if (OfficeNo.Text == "")
            {
                MessageBox.Show("Please enter office no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OfficeNo.Focus();
                return;
            }
            if (Email.Text == "")
            {
                MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Email.Focus();
                return;
            }
            if (PostalAddress.Text == "")
            {
                MessageBox.Show("Please select address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PostalAddress.Focus();
                return;
            }
            if (PhysicalAddress.Text == "")
            {
                MessageBox.Show("Please enter Residence.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhysicalAddress.Focus();
                return;
            }
            if (BankName.Text == "")
            {
                MessageBox.Show("Please enter Bank Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankName.Focus();
                return;
            }
            if (BankAccountName.Text == "")
            {
                MessageBox.Show("Please enter Bank Account Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankAccountName.Focus();
                return;
            }
            if (BankAccountNumber.Text == "")
            {
                MessageBox.Show("Please enter Bank Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BankAccountNumber.Focus();
                return;
            }
            if (GuardianName.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianName.Focus();
                return;
            }
            if (GuardianContactNo.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianContactNo.Focus();
                return;
            }
            if (GuardianAddress.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianAddress.Focus();
                return;
            }
            if (Relationship.Text == "")
            {
                MessageBox.Show("Please enter Next Of Kin Relationship", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Relationship.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update InvestorAccount set AccountType=@d36,Signature=@d35,AccountPicture=@d34,CreatedBy=@d33,NOKRelationship=@d23,NOKAddress=@d22,NOKContactNo=@d21,NOKName=@d20,BankAccountNumber=@d19,BankAccountName=@d18,BankName=@d17,PostalAddress=@d16,PhysicalAddress=@d15,Email=@d14,OfficeNo=@d13,ContactNo1=@d12,ContactNo=@d11,ClientID=@d10,IDForm=@d9,NationalityStatus=@d8,Nationality=@d7,MaritalStatus=@d6,DOB=@d5,Gender=@d4,AccountNames=@d2 where AccountNumber=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "RegistrationDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "DOB"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "MaritalStatus"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 50, "Nationality"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "NationalityStatus"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "IDForm"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "ClientID"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "ContactNo1"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "OfficeNo"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 100, "PhysicalAddress"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 100, "PostalAddress"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 100, "BankName"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 100, "BankAccountName"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 20, "BankAccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 50, "NOKName"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "NOKContactNo"));
                cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 100, "NOKAddress"));
                cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 30, "NOKRelationship"));
                cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 50, "CreatedBy"));
                cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 30, "AccountType"));
                cmd.Parameters["@d1"].Value = accountnumber.Text.Trim();
                cmd.Parameters["@d2"].Value = accountname.Text.Trim();
                cmd.Parameters["@d3"].Value = dateofregistration.Text.Trim();
                cmd.Parameters["@d4"].Value = Gender.Text;
                cmd.Parameters["@d5"].Value = DOB.Text;
                cmd.Parameters["@d6"].Value = maritalstatus.Text;
                cmd.Parameters["@d7"].Value = nationality.Text;
                cmd.Parameters["@d8"].Value = nationalitystatus.Text;
                cmd.Parameters["@d9"].Value = idform.Text;
                cmd.Parameters["@d10"].Value = NIN.Text;
                cmd.Parameters["@d11"].Value = ContactNo.Text;
                cmd.Parameters["@d12"].Value = ContactNo2.Text;
                cmd.Parameters["@d13"].Value = OfficeNo.Text;
                cmd.Parameters["@d14"].Value = Email.Text;
                cmd.Parameters["@d15"].Value = PhysicalAddress.Text;
                cmd.Parameters["@d16"].Value = PostalAddress.Text;
                cmd.Parameters["@d17"].Value = BankName.Text;
                cmd.Parameters["@d18"].Value = BankAccountName.Text;
                cmd.Parameters["@d19"].Value = BankAccountNumber.Text;
                cmd.Parameters["@d20"].Value = GuardianName.Text;
                cmd.Parameters["@d21"].Value = GuardianContactNo.Text;
                cmd.Parameters["@d22"].Value = GuardianAddress.Text;
                cmd.Parameters["@d23"].Value = Relationship.Text;
                cmd.Parameters["@d33"].Value = label33.Text;
                cmd.Parameters["@d36"].Value = "N/A";
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d34", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                MemoryStream ms3 = new MemoryStream();
                Bitmap bmpImage3 = new Bitmap(pictureBox4.Image);
                bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data3 = ms3.GetBuffer();
                SqlParameter p3 = new SqlParameter("@d35", SqlDbType.Image);
                p3.Value = data3;
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated", "Account Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmInvestorAccount frm = new frmInvestorAccount();
                frm.label33.Text = label33.Text;
                frm.label34.Text = label34.Text;
                frm.ShowDialog();
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
                string cq = "delete  from  InvestorAccount where AccountNumber=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
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
        private void frmPatientRegistration_Load(object sender, EventArgs e)
        {
            /*try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AccountName FROM InvestorAccountTypes";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountType.Items.Add(rdr[0].ToString().Trim());
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label33.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label33.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                capturedevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videosource = new VideoCaptureDevice();
                foreach (FilterInfo Device in capturedevice)
                {
                    comboBox1.Items.Add(Device.Name);

                }
                comboBox1.SelectedIndex = 0;
                videosource = new VideoCaptureDevice();
            }
            catch (Exception)
            {

                //return;
            }
        }
        private void frmPatientRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            videosource.Stop();
            this.Hide();
            /*frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label8.Text;
            frm.Show();*/
        }
        private void Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (Email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(Email.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Email.SelectAll();
                    e.Cancel = true;
                }
            }
        }
        private void buttonX9_Click_1(object sender, EventArgs e)
        {
            var _with1 = openFileDialog1;
            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;
            //Clear the file name
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                videosource = new VideoCaptureDevice(capturedevice[comboBox1.SelectedIndex].MonikerString);
                videosource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                videosource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                pictureBox1.Image = (Bitmap)e.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = (Bitmap)pictureBox1.Image.Clone();
                videosource.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void accountnumber_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientDetails2 frm = new frmClientDetails2();
                frm.ShowDialog();
                this.accountnumber.Text = frm.clientnames.Text;
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountnumber_TextChanged(object sender, EventArgs e)
        {
            if (accountnumber.Text == "") { }
            else
            {
                try
                {
                    string pat = accountnumber.Text.Trim();
                    SqlConnection CN = new SqlConnection(cs.DBConn);
                    CN.Open();
                    string SelectCommand = "SELECT * FROM InvestorAccount Where AccountNumber='" + pat + "'";
                    cmd = new SqlCommand(SelectCommand);
                    cmd.Connection = CN;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountname.Text = rdr["AccountNames"].ToString();
                        Gender.Text = rdr["Gender"].ToString();
                        DOB.Text = rdr["DOB"].ToString();
                        maritalstatus.Text = rdr["MaritalStatus"].ToString();
                        nationality.Text = rdr["Nationality"].ToString();
                        nationalitystatus.Text = rdr["NationalityStatus"].ToString();
                        idform.Text = rdr["IDForm"].ToString();
                        NIN.Text = rdr["ClientID"].ToString();
                        ContactNo.Text = rdr["ContactNo"].ToString();
                        ContactNo2.Text = rdr["ContactNo1"].ToString();
                        OfficeNo.Text = rdr["OfficeNo"].ToString();
                        Email.Text = rdr["Email"].ToString();
                        PhysicalAddress.Text = rdr["PhysicalAddress"].ToString();
                        PostalAddress.Text = rdr["PostalAddress"].ToString();
                        BankName.Text = rdr["BankName"].ToString();
                        BankAccountName.Text = rdr["BankAccountName"].ToString();
                        BankAccountNumber.Text = rdr["BankAccountNumber"].ToString();
                        GuardianName.Text = rdr["NOKName"].ToString();
                        GuardianContactNo.Text = rdr["NOKContactNo"].ToString();
                        GuardianAddress.Text = rdr["NOKAddress"].ToString();
                        Relationship.Text = rdr["NOKRelationship"].ToString();
                        //AccountType.Text = rdr["AccountType"].ToString();
                        byte[] data = (byte[])rdr["AccountPicture"];
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);

                        byte[] data1 = (byte[])rdr["Signature"];
                        MemoryStream ms1 = new MemoryStream(data1);
                        pictureBox4.Image = Image.FromStream(ms1);

                    }
                    else
                    {

                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
