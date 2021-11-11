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
    public partial class frmEmployeeDetailsReport : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter adp;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public frmEmployeeDetailsReport()
        {
            InitializeComponent();
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(StaffName) FROM Employee", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbEmployeeName.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbEmployeeName.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEmployeeDetailsReport_Load(object sender, EventArgs e)
        {
            AutocompleteStaffName();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer2.ReportSource = null;
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
                AEmployeeDataset myDS = new AEmployeeDataset();
                rptEmployee rpt = new rptEmployee();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Employee";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Employee");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = null;
            cmbEmployeeName.Text = "";
        }

        private void cmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;

                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AEmployeeDataset myDS = new AEmployeeDataset();
                rptEmployeeIndividual rpt = new rptEmployeeIndividual();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from Employee where StaffName='"+cmbEmployeeName.Text+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Employee");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEmployeeDetailsReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }
    }
}
