using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace Banking_System
{
    public partial class frmAttendance : DevComponents.DotNetBar.Office2007Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmAttendance()
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
        private void Student_Attendance_Load(object sender, EventArgs e)
        {
            this.labelX18.Text = AssemblyCopyright;
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label3.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX5.Enabled = true; } else { buttonX5.Enabled = false; }
                    if (pricess == "Yes") { buttonX6.Enabled = true; } else { buttonX6.Enabled = false; }
                }
                if (label3.Text == "ADMIN")
                {
                    buttonX5.Enabled = true;
                    buttonX6.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        
        private void frmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label3.Text;
            frm.UserType.Text = label4.Text;
            frm.Show();
        }
        private void Reset()
        {
            txtStaffName.Text = "";
            dateTimePicker1.Text = System.DateTime.Today.ToString();
            listView1.Items.Clear();
            staffid.Text = "";
            staffname.Text = "";
        }

           private void delete_records()
        {
            if (checkBoxX2.Checked)
            {
                try
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete from Attendance where AttendanceDate = '" + dateTimePicker1.Text + "' ";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
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
            else
            {
                try
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete from IndividualAttendance where Attendancedate = '" + rollcalldate.Text + "' ";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
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
        }

           private void buttonX1_Click(object sender, EventArgs e)
           {
               try
               {
                   var _with1 = listView1;
                   _with1.Clear();
                   _with1.Columns.Add("Staff ID", 120, HorizontalAlignment.Left);
                   _with1.Columns.Add("Staff Name", 250, HorizontalAlignment.Left);
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = new SqlCommand("select StaffID,StaffName from Employee order by StaffName,StaffID", con);
                   rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       var item = new ListViewItem();
                       item.Text = rdr[0].ToString().Trim();
                       item.SubItems.Add(rdr[1].ToString().Trim());
                       listView1.Items.Add(item);
                   }
                   con.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void buttonX2_Click(object sender, EventArgs e)
           {

               if (txtStaffName.Text == "")
               {
                   MessageBox.Show("Please Enter staff Authorisation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtStaffName.Focus();
                   return;
               }
               try
               {
                   var _with1 = listView1;
                   _with1.Clear();
                   _with1.Columns.Add("Staff ID.", 120, HorizontalAlignment.Left);
                   _with1.Columns.Add("Staff Name", 250, HorizontalAlignment.Center);
                   _with1.Columns.Add("Attendance Date", 250, HorizontalAlignment.Center);
                   _with1.Columns.Add("Time", 100, HorizontalAlignment.Center);
                   _with1.Columns.Add("Status", 50, HorizontalAlignment.Center);
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = new SqlCommand("select StaffNo,StaffName,Status,AttendanceDate,Time from Attendance order by AttendanceID ASC", con);
                   rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       var item = new ListViewItem();
                       item.Text = rdr[0].ToString().Trim();
                       item.SubItems.Add(rdr[1].ToString().Trim());
                       item.SubItems.Add(rdr[3].ToString().Trim());
                       item.SubItems.Add(rdr[4].ToString().Trim());
                       item.SubItems.Add(rdr[2].ToString().Trim());
                      
                       listView1.Items.Add(item);
                       for (int i = listView1.Items.Count - 1; i >= 0; i--)
                       {
                           if (listView1.Items[i].SubItems[2].Text == "Yes")
                           {
                               listView1.Items[i].Checked = true;
                           }
                           else
                           {
                               listView1.Items[i].Checked = false;
                           }
                       }
                   }

               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void buttonX3_Click(object sender, EventArgs e)
           {
               Reset(); 
           }
           public void company()
           {
               try
               {
                   SqlDataReader rdr = null;
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string ct6 = "select * from CompanyNames";
                   cmd = new SqlCommand(ct6);
                   cmd.Connection = con;
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       companyname = rdr.GetString(1).Trim();
                       companyaddress = rdr.GetString(5).Trim();
                       companyslogan = rdr.GetString(2).Trim();
                       companycontact = rdr.GetString(4).Trim();
                       companyemail = rdr.GetString(3).Trim();
                   }
                   else
                   {
                       
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
           private void buttonX4_Click(object sender, EventArgs e)
           {
               if (checkBoxX2.Checked)
               {
                   if (txtStaffName.Text == "")
                   {
                       MessageBox.Show("Please Enter staff Authorisation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       txtStaffName.Focus();
                       return;
                   }
                   try
                   {
                       for (int i = listView1.Items.Count - 1; i >= 0; i--)
                       {
                           con = new SqlConnection(cs.DBConn);
                           if (listView1.Items[i].Checked == true)
                           {
                               txtStatus.Text = "Yes";
                           }
                           else
                           {
                               txtStatus.Text = "No";
                           }
                           string cd = "insert into Attendance(StaffName,attendancedate,StaffNo,Status,Time) VALUES (@d8,@d9,@d10,@d11,@d12)";
                           cmd = new SqlCommand(cd);
                           cmd.Connection = con;
                           cmd.Parameters.AddWithValue("d8", listView1.Items[i].SubItems[1].Text);
                           cmd.Parameters.AddWithValue("d9", dateTimePicker1.Text);
                           cmd.Parameters.AddWithValue("d10", listView1.Items[i].SubItems[0].Text);
                           cmd.Parameters.AddWithValue("d11", txtStatus.Text);
                           cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "Time"));
                           cmd.Parameters["@d12"].Value = time.Text;
                           con.Open();
                           cmd.ExecuteNonQuery();
                           con.Close();
                       }
                       MessageBox.Show("Successfully saved", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               else
               {
                   if (checkBoxX4.Checked)
                   {
                       try
                       {
                           if (staffid.Text == "")
                           {
                               MessageBox.Show("Please Input staff id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               staffid.Focus();
                               return;
                           }
                           if (staffname.Text == "")
                           {
                               MessageBox.Show("Please Correct Input staff id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               staffid.Focus();
                               return;
                           }
                            con = new SqlConnection(cs.DBConn);
                           
                           string cd = "insert into SignInOut(StaffName,attendancedate,StaffNo,SignIn,SignOut) VALUES (@d8,@d9,@d10,@d11,@d12)";
                           cmd = new SqlCommand(cd);
                           cmd.Connection = con;
                           cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "Staffname"));
                           cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "attendancedate"));
                           cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 15, "StaffNo"));
                           cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "SignIn"));
                           cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SignOut"));
                           cmd.Parameters["@d8"].Value = staffname.Text;
                           cmd.Parameters["@d9"].Value = rollcalldate.Text;
                           cmd.Parameters["@d10"].Value = staffid.Text;
                           cmd.Parameters["@d11"].Value = time.Text;
                           cmd.Parameters["@d12"].Value = "Pending";
                           con.Open();
                           cmd.ExecuteNonQuery();
                           con.Close();
                           MessageBox.Show("Successfully saved", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                   }
                   else if (checkBoxX3.Checked)
                   {
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string ct = "select StaffName,ID from SignInOut where  StaffNo='" + staffid.Text + "' and SignOut='Pending' order by ID Desc";
                   cmd = new SqlCommand(ct);
                   cmd.Connection = con;
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       int ids = rdr.GetInt32(1);
                       //MessageBox.Show(ids.ToString(), "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       try { 
                       con = new SqlConnection(cs.DBConn);
                       con.Open();
                       string cd = "UPDATE SignInOut SET SignOut=@d12 where StaffName=@d8 and StaffNo=@d10 and ID='"+ids+"'";
                       cmd = new SqlCommand(cd);
                       cmd.Connection = con;
                       cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "Staffname"));
                       cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "attendancedate"));
                       cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 15, "StaffNo"));
                       cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "SignIn"));
                       cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "SignOut"));
                       cmd.Parameters["@d8"].Value = staffname.Text;
                       cmd.Parameters["@d9"].Value = rollcalldate.Text;
                       cmd.Parameters["@d10"].Value = staffid.Text;
                       cmd.Parameters["@d11"].Value = time.Text;
                       cmd.Parameters["@d12"].Value = time.Text;
                       cmd.ExecuteNonQuery();
                       con.Close();
                       MessageBox.Show("Successfully saved", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                   }
                   }
               }

               
           }

           private void buttonX5_Click(object sender, EventArgs e)
           {
               if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
               {
                   delete_records();
               }
           }

           private void buttonX6_Click(object sender, EventArgs e)
           {
               if (checkBoxX2.Checked)
               {
                   try
                   {
                       for (int i = listView1.Items.Count - 1; i >= 0; i--)
                       {
                           con = new SqlConnection(cs.DBConn);
                           if (listView1.Items[i].Checked == true)
                           {
                               txtStatus.Text = "Yes";
                           }
                           else
                           {
                               txtStatus.Text = "No";
                           }
                           
                  
                           string cd = "update Attendance set Status=@d11 where  attendancedate=@d9 and StaffNo=@d10";
                           cmd = new SqlCommand(cd);
                           cmd.Connection = con;
                           cmd.Parameters.AddWithValue("d8", listView1.Items[i].SubItems[0].Text);
                           cmd.Parameters.AddWithValue("d9", dateTimePicker1.Text);
                           cmd.Parameters.AddWithValue("d10", listView1.Items[i].SubItems[0].Text);
                           cmd.Parameters.AddWithValue("d11", txtStatus.Text);
                           con.Open();
                           cmd.ExecuteNonQuery();
                           con.Close();
                       }
                       MessageBox.Show("Successfully updated", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               else
               {
                   try
                   {
                   
                           string cd = "update IndividualAttendance set Status=@d11 where StaffName=@d8 and attendancedate=@d9 and StaffNo=@d10";
                           cmd = new SqlCommand(cd);
                           cmd.Connection = con;
                           cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "StaffName"));
                           cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "AttendanceDate"));
                           cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 15, "StaffNo"));
                           cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Status"));
                           cmd.Parameters["@d8"].Value = staffname.Text;
                           cmd.Parameters["@d9"].Value = rollcalldate.Text;
                           cmd.Parameters["@d10"].Value = staffid.Text;
                           cmd.Parameters["@d11"].Value = "Yes";
                           cmd.ExecuteNonQuery();
                           con.Close();          
                       MessageBox.Show("Successfully updated", "Staff Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
           }

           private void buttonX7_Click(object sender, EventArgs e)
           {
               this.Hide();
               frmAttendanceRecord frm = new frmAttendanceRecord();
               frm.label3.Text = label3.Text;
               frm.label4.Text = label4.Text;
               frm.Show();
           }

           private void buttonX8_Click(object sender, EventArgs e)
           {
               this.Hide();
               frmAttendanceReport frm = new frmAttendanceReport();
               frm.dateTimePicker1.Text = DateTime.Today.ToString();
               frm.dateTimePicker2.Text = DateTime.Today.ToString();
               frm.crystalReportViewer1.ReportSource = null;
               frm.dateTimePicker4.Text = DateTime.Today.ToString();
               frm.dateTimePicker3.Text = DateTime.Today.ToString();
               frm.crystalReportViewer2.ReportSource = null;
               frm.label3.Text = label3.Text;
               frm.label4.Text = label4.Text;
               frm.Show();
           }

           private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
           {
               if (checkBoxX1.Checked)
               {
                   listView1.Enabled = false;
                   groupPanel1.Enabled = false;
                   checkBoxX2.Checked = false;
                   groupPanel3.Enabled = true;
               }
           }

           private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
           {
               if (checkBoxX2.Checked)
               {
                   listView1.Enabled = true;
                   groupPanel1.Enabled = true;
                   checkBoxX1.Checked = false;
                   groupPanel3.Enabled = false;
               }
           }

           private void staffid_TextChanged(object sender, EventArgs e)
           {
               try
               {
                   staffname.Text = "";
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = con.CreateCommand();
                   cmd.CommandText = "SELECT StaffName FROM Employee WHERE StaffID = '" + staffid.Text + "'";
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       staffname.Text = rdr.GetString(0).Trim();
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

           private void managerid_TextChanged(object sender, EventArgs e)
           {
               txtStaffName.Clear();
               txtStaffName.Text = "";
               txtStaffName.Enabled = true;
               try
               {
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string ct = "select distinct RTRIM(StaffName) from Rights where AuthorisationID = '" + managerid.Text + "' and Category='Manager'";
                   cmd = new SqlCommand(ct);
                   cmd.Connection = con;
                   rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       txtStaffName.Text = rdr.GetString(0).Trim();
                   }
                   con.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void textBoxX1_TextChanged(object sender, EventArgs e)
           {
               try
               {
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string ct = "select distinct RTRIM(StaffName),RTRIM(StaffID) from Rights where AuthorisationID = '" + authorisationid.Text + "'";
                   cmd = new SqlCommand(ct);
                   cmd.Connection = con;
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       //staffname.Text = rdr.GetString(0).Trim();
                       staffid.Text = rdr.GetString(1).Trim();
                   }
                   con.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
           {
               if (checkBoxX4.Checked)
               {
                   checkBoxX3.Checked = false;
               }
           }

           private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
           {
               if (checkBoxX3.Checked)
               {
                   checkBoxX4.Checked = false;
               }
           }
    }
}
