using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Banking_System
{
    public partial class frmAttendanceReportMember : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmAttendanceReportMember()
        {
            InitializeComponent();
        }
        public void AutocompleSession()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(MemberID) from MemberAttendance ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSubjectCode.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAttendanceReport_Load(object sender, EventArgs e)
        {
             AutocompleSession();
             crystalReportViewer2.ReportSource = null;
             crystalReportViewer1.ReportSource = null;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            crystalReportViewer1.ReportSource = null;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptAttendanceMember rpt = new rptAttendanceMember();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from MemberAttendance  where Status='Yes' and AttendanceDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "MemberAttendance");
                con.Open();
                cmd = new SqlCommand("select Count(MemberID) from MemberAttendance where Status='Yes' and AttendanceDate between @date1 and @date2 group by MemberID", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label1.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            cmbSubjectCode.Text = "";
            cmbSubjectCode.Enabled = true;
            txtSubjectName.Text = "";
            txtSubjectName.ReadOnly = true;
            dateTimePicker4.Text = DateTime.Today.ToString();
            dateTimePicker3.Text = DateTime.Today.ToString();
            crystalReportViewer2.ReportSource = null;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (cmbSubjectCode.Text == "")
            {
                MessageBox.Show("Please select Member ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubjectCode.Focus();
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;

                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AAttendancememberDataSet myDS = new AAttendancememberDataSet();
                rptAttendanceIndividualMember rpt = new rptAttendanceIndividualMember();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from MemberAttendance where Status='Yes'  and MemberID='" + cmbSubjectCode.Text + "' and AttendanceDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker4.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker3.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "MemberAttendance");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAttendanceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label3.Text;
            frm.UserType.Text = label4.Text;
            frm.Show();
        }

        private void cmbSubjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MemberName FROM MemberAttendance WHERE MemberID = '" + cmbSubjectCode.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubjectName.Text = rdr.GetString(0).Trim();
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
