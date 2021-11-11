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
    public partial class frmEquipmentPurchaseReport : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter adp;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public frmEquipmentPurchaseReport()
        {
            InitializeComponent();
        }
        private void AutocompleteCourse()
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
                Equipmentname.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Equipmentname.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEquipmentPurchaseReport_Load(object sender, EventArgs e)
        {
            AutocompleteCourse();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer2.ReportSource = null;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Equipmentname.Text == "")
            {
                MessageBox.Show("Please Select Equipment Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Equipmentname.Focus();
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
                AEquipmentPurchaseDataset myDS = new AEquipmentPurchaseDataset();
                rptEquipmentPurchase rpt = new rptEquipmentPurchase();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from EquipmentPurchase,Rights  where EquipmentPurchase.StaffID=Rights.AuthorisationID and Equipmentname='" + Equipmentname.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "EquipmentPurchase");
                myDA.Fill(myDS, "Rights");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                AEquipmentPurchaseDataset myDS = new AEquipmentPurchaseDataset();
                rptEquipmentPurchaseAll rpt = new rptEquipmentPurchaseAll();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from EquipmentPurchase where  PurchaseDate between @date1 and @date2 ";
                MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
                MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "EquipmentPurchase");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            Equipmentname.Text = "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource =null;
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
        }

        private void frmEquipmentPurchaseReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label3.Text;
            frm.Show();
        }
    }
}
