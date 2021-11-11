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
    public partial class frmAttendanceMember : DevComponents.DotNetBar.Office2007Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmAttendanceMember()
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
        private void frmAttendanceMember_Load(object sender, EventArgs e)
        {
            this.labelX1.Text = AssemblyCopyright;
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
            textBox1.Text = "";
            txtStaffName.Text = "";
        }

        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from MemberAttendance where AttendanceDate = '" + dateTimePicker1.Text + "' ";
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

           private void buttonX1_Click(object sender, EventArgs e)
           {
               try
               {
                   listView1.Items.Clear();
                   var _with1 = listView1;
                   _with1.Clear();
                   _with1.Columns.Add("Member ID", 120, HorizontalAlignment.Left);
                   _with1.Columns.Add("Member Name", 250, HorizontalAlignment.Left);
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = new SqlCommand("select MemberID,MemberName from MemberRegistration order by MemberName,MemberID", con);
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
                   MessageBox.Show("Please enter staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtStaffName.Focus();
                   return;
               }
               try
               {
                   listView1.Items.Clear();
                   var _with1 = listView1;
                   _with1.Clear();
                   _with1.Columns.Add("Member ID.", 120, HorizontalAlignment.Left);
                   _with1.Columns.Add("Member Name", 250, HorizontalAlignment.Center);
                   _with1.Columns.Add("Attendance Date", 200, HorizontalAlignment.Center);
                   _with1.Columns.Add("Attendance Time", 200, HorizontalAlignment.Center);
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = new SqlCommand("select MemberID,MemberName,Status,AttendanceDate,Time from MemberAttendance order by MemberName,MemberID", con);
                   rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       var item = new ListViewItem();
                       item.Text = rdr[0].ToString().Trim();
                       item.SubItems.Add(rdr[1].ToString().Trim());
                       item.SubItems.Add(rdr[3].ToString().Trim());
                       item.SubItems.Add(rdr[4].ToString().Trim());
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

           private void buttonX4_Click(object sender, EventArgs e)
           {
               if (txtStaffName.Text == "")
               {
                   MessageBox.Show("Please enter staff name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                       string cd = "insert into MemberAttendance(MemberName,attendanceDate,MemberID,Status,Time) VALUES (@d8,@d9,@d10,@d11,@d12)";
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
                   MessageBox.Show("Successfully saved", "Member Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
               }
           }

           private void buttonX6_Click(object sender, EventArgs e)
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
                       string cd = "update MemberAttendance set Status=@d11,MemberName=@d8 where attendanceDate=@d9 and MemberID=@d10";
                       cmd = new SqlCommand(cd);
                       cmd.Connection = con;
                       cmd.Parameters.AddWithValue("d8", listView1.Items[i].SubItems[1].Text);
                       cmd.Parameters.AddWithValue("d9", dateTimePicker1.Text);
                       cmd.Parameters.AddWithValue("d10", listView1.Items[i].SubItems[0].Text);
                       cmd.Parameters.AddWithValue("d11", txtStatus.Text);
                       con.Open();
                       cmd.ExecuteNonQuery();
                       con.Close();
                   }
                   MessageBox.Show("Successfully updated", "Member Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);

               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void buttonX7_Click(object sender, EventArgs e)
           {
               this.Hide();
               frmAttendanceRecordMember frm = new frmAttendanceRecordMember();
               frm.label3.Text = label3.Text;
               frm.label4.Text = label4.Text;
               frm.Show();
           }

           private void buttonX8_Click(object sender, EventArgs e)
           {
               this.Hide();
               frmAttendanceReportMember frm = new frmAttendanceReportMember();
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

           private void textBox1_TextChanged(object sender, EventArgs e)
           {
               try
               {
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   cmd = con.CreateCommand();
                   cmd.CommandText = "SELECT StaffName FROM Rights WHERE AuthorisationID = '" + textBox1.Text + "'";
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       txtStaffName.Text = rdr.GetString(0).Trim();
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
    }
}
