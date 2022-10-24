using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using AForge.Video.DirectShow;
using AForge.Video;
namespace Banking_System
{
    public partial class frmEmployeeDetails : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
       // SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        private VideoCaptureDevice videosource;
        private FilterInfoCollection capturedevice;
        public frmEmployeeDetails()
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
            txtStaffID.Text = "TER-" + GetUniqueKey(6);
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
              /*  con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StaffID from Attendance where StaffID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@find"].Value = txtStaffID.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cm = "select StaffID from EmployeePayment where StaffID=@find";
                cmd = new SqlCommand(cm);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@find"].Value = txtStaffID.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }*/
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Employee where StaffID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters["@DELETE1"].Value = txtStaffID.Text;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear();
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

        private void EmployeeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label21.Text;
            frm.UserType.Text = label23.Text;
            frm.Show();*/
            try
            {
                videosource.Stop();
            }
            catch (Exception)
            {

            }
        }

        private void clear()
        {
            txtBasicSalary.Text = null;
            txtDesignation.Text = "";
            txtEmail.Text = "";
            cmbGender.Text = "";
            txtFamilyBenefitFund.Text = null;
            txtFatherName.Text = "";
            txtGrpInsurance.Text = null;
            txtIncomeTax.Text = null;
            txtLIC.Text = null;
            txtLoans.Text = null;
            txtMobileNo.Text = "";
            txtOtherDeductions.Text = null;
            txtPAddress.Text = "";
            txtPhoneNo.Text = "";
            txtQualifications.Text = "";
            txtStaffName.Text = "";
            txtTAddress.Text = "";
            txtYOP.Text = "";
            DOB.Text = "";
            txtStaffID.Text = "";
            dtpDateOfJoining.Text = System.DateTime.Today.ToString();
            //pictureBox1.Image = Properties.Resources.photo;
        }
  
        private void txtStaffName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void txtYOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtBasicSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtLIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtIncomeTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtGrpInsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        private void txtFamilyBenefitFund_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtLoans_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtOtherDeductions_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
   
        private void buttonX1_Click(object sender, EventArgs e)
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                videosource.Stop();
            }
            catch (Exception)
            {

            }
            this.Hide();
            this.clear();
            frmEmployeeRecord1 frm = new frmEmployeeRecord1();
            frm.dataGridView1.DataSource = null;
            frm.cmbEmployeeName.Text = "";
            frm.txtEmployeeName.Text = "";
            frm.dataGridView2.DataSource = null;
            frm.label1.Text = label21.Text;
            frm.label2.Text = label23.Text;
            frm.outlet.Text = outlet.Text;
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                videosource.Stop();
            }
            catch (Exception)
            {

            }
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.label21.Text = label21.Text;
            frm.label23.Text = label23.Text;
            frm.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text == "")
                {
                    MessageBox.Show("Please enter staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffName.Focus();
                    return;
                }
                if (cmbGender.Text == "")
                {
                    MessageBox.Show("Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbGender.Focus();
                    return;
                }
                if (DOB.Text == "")
                {
                    MessageBox.Show("Please enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DOB.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtPAddress.Text == "")
                {
                    MessageBox.Show("Please enter permanent address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPAddress.Focus();
                    return;
                }
                if (txtTAddress.Text == "")
                {
                    MessageBox.Show("Please enter temporary address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTAddress.Focus();
                    return;
                }
                if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter phone no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtMobileNo.Text == "")
                {
                    MessageBox.Show("Please enter mobile no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo.Focus();
                    return;
                }

               
                if (txtQualifications.Text == "")
                {
                    MessageBox.Show("Please enter qualifications", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQualifications.Focus();
                    return;
                }
                if (txtYOP.Text == "")
                {
                    MessageBox.Show("Please enter year of experience", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYOP.Focus();
                    return;
                }
                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                if (txtBasicSalary.Text == "")
                {
                    MessageBox.Show("Please enter basic salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Focus();
                    return;
                }
                if (department.Text == "")
                {
                    MessageBox.Show("Please Select Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    department.Focus();
                    return;
                }
                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please Enter Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffID.Focus();
                    return;
                }
                if (accountnames.Text == "")
                {
                    MessageBox.Show("Please Enter Staff Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountnames.Focus();
                    return;
                }
                if (accbank.Text == "")
                {
                    MessageBox.Show("Please Enter Staff Account Bank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accbank.Focus();
                    return;
                }
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please browse & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               // auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Employee(Staffid,staffname,gender,fathername,permanentaddress,temporaryaddress,phoneno,mobileno,dateofjoining,qualification,yearofexperience,designation,email,Basicsalary,lic,groupinsurance,familybenefitfund,loans,otherdeductions,IncomeTax,picture,DOB,Nokphone,AccNo,Department,AccountNames,AccountBank) values(@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d25,@d26,@d27,@d28,@d29)";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "Staffid"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Staffname"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "gender"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "fathername"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 100, "permanentaddress"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "temporaryaddress"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "Phoneno"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "mobileno"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "dateofjoining"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 70, "qualiication"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "yearofexperience"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.VarChar, 100, "designation"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 30, "email"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 10, "basicsalary"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Int, 10, "lic"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 10, "groupinsurance"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.Int, 10, "familybenefitfund"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.Int, 10, "loans"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.Int, 10, "otherdeductions"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.Int, 10, "incometax"));
                cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 20, "DOB"));
                cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 15, "Nokphone"));
                cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 30, "AccNo"));
                cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 100, "Department"));
                cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 50, "AccountBank"));
                cmd.Parameters["@d1"].Value = txtStaffID.Text;
                cmd.Parameters["@d2"].Value = txtStaffName.Text;
                cmd.Parameters["@d4"].Value = cmbGender.Text;
                cmd.Parameters["@d5"].Value = txtFatherName.Text;
                cmd.Parameters["@d6"].Value = txtPAddress.Text;
                cmd.Parameters["@d7"].Value = txtTAddress.Text;
                cmd.Parameters["@d8"].Value = txtPhoneNo.Text;
                cmd.Parameters["@d9"].Value = txtMobileNo.Text;
                cmd.Parameters["@d10"].Value = dtpDateOfJoining.Text;
                cmd.Parameters["@d11"].Value = txtQualifications.Text;
                cmd.Parameters["@d12"].Value = Convert.ToInt16(txtYOP.Text);
                cmd.Parameters["@d13"].Value = txtDesignation.Text;
                cmd.Parameters["@d14"].Value = txtEmail.Text;
                cmd.Parameters["@d15"].Value = Convert.ToInt32(txtBasicSalary.Value);
                cmd.Parameters["@d25"].Value = nokphone.Text;
                cmd.Parameters["@d26"].Value = accno.Text;
                cmd.Parameters["@d27"].Value = department.Text;
                cmd.Parameters["@d28"].Value = accountnames.Text;
                cmd.Parameters["@d29"].Value = accbank.Text;
                if (txtLIC.Text == "")
                {
                    cmd.Parameters["@d16"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(txtLIC.Value);
                }
                if (txtGrpInsurance.Text == "")
                {
                    cmd.Parameters["@d17"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d17"].Value = Convert.ToInt32(txtGrpInsurance.Value);
                }
                if (txtFamilyBenefitFund.Text == "")
                {
                    cmd.Parameters["@d18"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d18"].Value = Convert.ToInt32(txtFamilyBenefitFund.Value);
                }
                if (txtLoans.Text == "")
                {
                    cmd.Parameters["@d19"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d19"].Value = Convert.ToInt32(txtLoans.Value);
                }
                if (txtOtherDeductions.Text == "")
                {
                    cmd.Parameters["@d20"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d20"].Value = Convert.ToInt32(txtOtherDeductions.Value);
                }
                if (txtIncomeTax.Text == "")
                {
                    cmd.Parameters["@d21"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d21"].Value = Convert.ToInt32(txtIncomeTax.Value);
                }
                cmd.Parameters["@d23"].Value = DOB.Text;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d22", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                try
                {
                    videosource.Stop();
                }
                catch (Exception)
                {

                }
                this.Hide();
                frmEmployeeDetails frm = new frmEmployeeDetails();
                frm.label21.Text = label21.Text;
                frm.label23.Text = label23.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                this.Hide();
                frmEmployeeDetails frm = new frmEmployeeDetails();
                frm.label21.Text = label21.Text;
                frm.label23.Text = label23.Text;
                frm.ShowDialog();
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Employee set AccountNames=@d28,AccountBank=@d29,Nokphone=@d25,Department=@d27,staffname=@d2,gender=@d4,fathername=@d5,permanentaddress=@d6,temporaryaddress=@d7,phoneno=@d8,mobileno=@d9,dateofjoining=@d10,qualification=@d11,yearofexperience=@d12,designation=@d13,email=@d14,Basicsalary=@d15,lic=@d16,groupinsurance=@d17,familybenefitfund=@d18,loans=@d19,otherdeductions=@d20,IncomeTax=@d21,picture=@d22,DOB=@d23 where staffid=@d1";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "Staffid"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Staffname"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "gender"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "fathername"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 100, "permanentaddress"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "temporaryaddress"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "Phoneno"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "mobileno"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "dateofjoining"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 70, "qualiication"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "yearofexperience"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.VarChar, 100, "designation"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 30, "email"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 10, "basicsalary"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Int, 10, "lic"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 10, "groupinsurance"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.Int, 10, "familybenefitfund"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.Int, 10, "loans"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.Int, 10, "otherdeductions"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.Int, 10, "incometax"));
                cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 20, "DOB"));
                cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 15, "Nokphone"));
                cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 30, "AccNo"));
                cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 100, "Department"));
                cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 50, "AccountNames"));
                cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 50, "AccountBank"));
                cmd.Parameters["@d1"].Value = txtStaffID.Text;
                cmd.Parameters["@d2"].Value = txtStaffName.Text;
                cmd.Parameters["@d4"].Value = cmbGender.Text;
                cmd.Parameters["@d5"].Value = txtFatherName.Text;
                cmd.Parameters["@d6"].Value = txtPAddress.Text;
                cmd.Parameters["@d7"].Value = txtTAddress.Text;
                cmd.Parameters["@d8"].Value = txtPhoneNo.Text;
                cmd.Parameters["@d9"].Value = txtMobileNo.Text;
                cmd.Parameters["@d10"].Value = dtpDateOfJoining.Text;
                cmd.Parameters["@d11"].Value = txtQualifications.Text;
                cmd.Parameters["@d12"].Value = Convert.ToInt16(txtYOP.Text);
                cmd.Parameters["@d13"].Value = txtDesignation.Text;
                cmd.Parameters["@d14"].Value = txtEmail.Text;
                cmd.Parameters["@d15"].Value = Convert.ToInt32(txtBasicSalary.Value);
                cmd.Parameters["@d25"].Value = nokphone.Text;
                cmd.Parameters["@d26"].Value = accno.Text;
                cmd.Parameters["@d27"].Value = department.Text;
                cmd.Parameters["@d28"].Value = accountnames.Text;
                cmd.Parameters["@d29"].Value = accbank.Text;
                if (txtLIC.Text == "")
                {
                    cmd.Parameters["@d16"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(txtLIC.Value);

                }
                if (txtGrpInsurance.Text == "")
                {
                    cmd.Parameters["@d17"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d17"].Value = Convert.ToInt32(txtGrpInsurance.Value);
                }
                if (txtFamilyBenefitFund.Text == "")
                {
                    cmd.Parameters["@d18"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d18"].Value = Convert.ToInt32(txtFamilyBenefitFund.Value);
                }
                if (txtLoans.Text == "")
                {
                    cmd.Parameters["@d19"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d19"].Value = Convert.ToInt32(txtLoans.Text);
                }
                if (txtOtherDeductions.Text == "")
                {
                    cmd.Parameters["@d20"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d20"].Value = Convert.ToInt32(txtOtherDeductions.Value);
                }
                if (txtIncomeTax.Text == "")
                {
                    cmd.Parameters["@d21"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d21"].Value = Convert.ToInt32(txtIncomeTax.Value);
                }
                cmd.Parameters["@d23"].Value = DOB.Text;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d22", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                con.Close();
                try
                {
                    videosource.Stop();
                }
                catch (Exception)
                {

                }
                this.Hide();
                frmEmployeeDetails frm = new frmEmployeeDetails();
                frm.label21.Text = label21.Text;
                frm.label23.Text = label23.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

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
        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {
            /*Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;*/
            this.labelX18.Text = AssemblyCopyright;
            /* try
             {
                 SqlDataAdapter adp;
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 adp = new SqlDataAdapter();
                 adp.SelectCommand = new SqlCommand("select Section from Sections", con);
                 ds = new DataSet("ds");
                 adp.Fill(ds);
                 dtable = ds.Tables[0];
                 txtDepartment.Items.Clear();
                 foreach (DataRow drow in dtable.Rows)
                 {
                     txtDepartment.Items.Add(drow[0].ToString());
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
                string pricesss = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label21.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["deletes"].ToString().Trim();
                    pricess = rdr["updates"].ToString().Trim();
                    pricesss = rdr["HRRecords"].ToString().Trim();
                    if (prices == "Yes") { buttonX5.Enabled = true; } else { buttonX5.Enabled = false; }
                    if (pricess == "Yes") { buttonX6.Enabled = true; } else { buttonX6.Enabled = false; }
                    if (pricesss == "Yes") { buttonX2.Enabled = true; } else { buttonX2.Enabled = false; }
                }
                if (label21.Text == "ADMIN")
                {
                    buttonX5.Enabled = true;
                    buttonX6.Enabled = true;
                    buttonX2.Enabled = true;
                }
                con.Close();
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
                    comboBox3.Items.Add(Device.Name);

                }
                comboBox3.SelectedIndex = 0;
                videosource = new VideoCaptureDevice();
            }
            catch (Exception)
            {

                //return;
            }
        }
        private void txtBasicSalary_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBasicSalary.Text == null || txtBasicSalary.Text == "")
                {

                }
                else
                {
                    double I=0.15 * Convert.ToInt32(txtBasicSalary.Value);
                    int i2=Convert.ToInt32(I);
                    txtLIC.Value = i2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (txtBasicSalary.Text == null || txtBasicSalary.Text == "")
                {

                }
                else
                {
                    int basicsal= Convert.ToInt32(txtBasicSalary.Value);
                    if (basicsal <= 235000)
                    {
                        double I = 0.15 * Convert.ToInt32(txtBasicSalary.Value);
                        int i2 = Convert.ToInt32(I);
                        txtIncomeTax.Value = 0;
                    }
                    else if (basicsal > 235000 && basicsal <=310000)
                    {
                        double I = 0.10 * Convert.ToInt32(txtBasicSalary.Value);
                        int i2 = Convert.ToInt32(I);
                        txtIncomeTax.Value = i2;
                    }
                    else if (basicsal > 310000 && basicsal <= 410000)
                    {
                        double I = 0.20 * Convert.ToInt32(txtBasicSalary.Value);
                        int i2 = Convert.ToInt32(I);
                        txtIncomeTax.Value = i2;
                    }
                }

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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                videosource = new VideoCaptureDevice(capturedevice[comboBox3.SelectedIndex].MonikerString);
                videosource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                videosource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}