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
    public partial class frmAttendanceRecordMember : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmAttendanceRecordMember()
        {
            InitializeComponent();
        }

        private void frmAttendanceRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label3.Text;
            frm.UserType.Text = label4.Text;
            frm.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            listView1.Items.Clear();
            label19.Visible = false;
            label20.Visible = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                label19.Visible = false;
                label20.Visible = false;
                var _with1 = listView1;
                _with1.Clear();
                _with1.Columns.Add("Member ID.", 120, HorizontalAlignment.Left);
                _with1.Columns.Add("Member Name", 250, HorizontalAlignment.Center);
                _with1.Columns.Add("Total Attendance", 120, HorizontalAlignment.Center);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(MemberID)[Member ID],RTRIM(MemberName)[Member Name],count(Status)[Total Attendance] from MemberAttendance where status= 'Yes' and MemberAttendance.AttendanceDate between @date1 and @date2 group by MemberID,MemberName", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = rdr[0].ToString();
                    item.SubItems.Add(rdr[1].ToString());
                    item.SubItems.Add(rdr[2].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Count(MemberID) from MemberAttendance where  AttendanceDate between @date1 and @date2 group by MemberID ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label19.Text = rdr.GetInt32(0).ToString();
                    label19.Visible = true;
                    label20.Visible = true;
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

        private void tabPage1_Click(object sender, EventArgs e)
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
        private void frmAttendanceRecordMember_Load(object sender, EventArgs e)
        {
            this.labelX1.Text = AssemblyCopyright;
        }
    }
}
