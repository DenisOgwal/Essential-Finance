using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmAttendanceReport : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmAttendanceReport()
        {
            InitializeComponent();
        }
        public void AutocompleSession()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(StaffID) from Employee ";
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
                    companyaddress = rdr.GetString(7).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {
                   
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
            company();
           try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                rptAttendance rpt = new rptAttendance();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select Rtrim(StaffName),Rtrim(StaffNo) from Attendance  where Status='Yes' and AttendanceDate between @date1 and @date2 group by StaffNo,StaffName ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Attendance");
                con.Open();
                cmd = new SqlCommand("select Count(StaffNo) from Attendance where Status='Yes' and AttendanceDate between @date1 and @date2 group by StaffNo", con);
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
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer1.ReportSource = rpt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
/*
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                Attendances myDS = new Attendances();
                rptAttendance rpt = new rptAttendance();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Attendance,Employee  where Attendance.StaffNo=Employee.StaffID and  Status='Yes' and AttendanceDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Attendance");
                myDA.Fill(myDS, "Employee");
                con.Open();
                cmd = new SqlCommand("select Count(StaffNo) from Attendance where  AttendanceDate between @date1 and @date2 group by StaffNo", con);
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
            }*/
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
                MessageBox.Show("Please select Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataSet myDS = new DataSet();
                rptAttendanceIndividual rpt = new rptAttendanceIndividual();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Attendance  where Status='Yes' and StaffNO='"+cmbSubjectCode.Text+"' and AttendanceDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker4.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker3.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Attendance");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                rpt.SetParameterValue("picpath", "logo.jpg");
                crystalReportViewer2.ReportSource = rpt;
                con.Close();
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
                cmd.CommandText = "SELECT StaffName FROM Employee WHERE StaffID = '" + cmbSubjectCode.Text + "'";
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
