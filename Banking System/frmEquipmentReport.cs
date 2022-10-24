using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmEquipmentReport : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter adp;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
         string contacts1 = null;
        string contacts2 = null;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmEquipmentReport()
        {
            InitializeComponent();
        }

        private void frmExpenseReport_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            AutocompleteStaffName();
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
                expenseid.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    expenseid.Items.Add(drow[0].ToString());
                }
                CN.Close();
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
                    contacts1 = rdr.GetString(5).Trim();
                    contacts2 = rdr.GetString(6).Trim();
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
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                company();
                //Cursor = Cursors.WaitCursor;
                //timer1.Enabled = true;
                //The report you created.
                string receiptlogos = null;
                    receiptlogos = Properties.Settings.Default.reportlogo;
                    if (receiptlogos == "yes")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        rptEquipment rpt = new rptEquipment();
                        //The DataSet you created.
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from EquipmentPurchase where PurchaseDate between @date1 and @date2 ";
                        MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
                        MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "EquipmentPurchase");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("contacts1", contacts1);
                        rpt.SetParameterValue("contacts2", contacts2);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        crystalReportViewer2.ReportSource = rpt;
                    }
                    else if (receiptlogos == "no")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        rptEquipment rpt = new rptEquipment();
                       
                        //The DataSet you created.
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select  * from EquipmentPurchase where PurchaseDate between @date1 and @date2 ";
                        MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateFrom.Value.Date;
                        MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PurchaseDate").Value = DateTo.Value.Date;
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "EquipmentPurchase");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("contacts1", contacts1);
                        rpt.SetParameterValue("contacts2", contacts2);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        crystalReportViewer2.ReportSource = rpt;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            crystalReportViewer3.ReportSource = null;
            expenseid.Text = "";
        }

        private void expenseid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please Select Equipment Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                company();
                //Cursor = Cursors.WaitCursor;
                //timer1.Enabled = true;
                //The report you created.
                string receiptlogos = null;
                    receiptlogos = Properties.Settings.Default.reportlogo;
                    if (receiptlogos == "yes")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        rptEquipment2 rpt = new rptEquipment2();
                        //The DataSet you created.
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select * from EquipmentPurchase  where Equipmentname='" + expenseid.Text + "'";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "EquipmentPurchase");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("equipmentname", expenseid.Text);
                        rpt.SetParameterValue("contacts1", contacts1);
                        rpt.SetParameterValue("contacts2", contacts2);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        crystalReportViewer3.ReportSource = rpt;
                    }
                    else if (receiptlogos == "no")
                    {
                        SqlConnection myConnection = default(SqlConnection);
                        SqlCommand MyCommand = new SqlCommand();
                        SqlDataAdapter myDA = new SqlDataAdapter();
                        DataSet myDS = new DataSet();
                        rptEquipment2 rpt = new rptEquipment2();
                        //The DataSet you created.
                        myConnection = new SqlConnection(cs.DBConn);
                        myConnection.Open();
                        MyCommand.Connection = myConnection;
                        MyCommand.CommandText = "select * from EquipmentPurchase  where Equipmentname='" + expenseid.Text + "'";
                        MyCommand.CommandType = CommandType.Text;
                        myDA.SelectCommand = MyCommand;
                        myDA.Fill(myDS, "EquipmentPurchase");
                        rpt.SetDataSource(myDS);
                        rpt.SetParameterValue("equipmentname", expenseid.Text);
                        rpt.SetParameterValue("contacts1", contacts1);
                        rpt.SetParameterValue("contacts2", contacts2);
                        rpt.SetParameterValue("comanyname", companyname);
                        rpt.SetParameterValue("companyemail", companyemail);
                        rpt.SetParameterValue("companycontact", companycontact);
                        rpt.SetParameterValue("companyslogan", companyslogan);
                        rpt.SetParameterValue("companyaddress", companyaddress);
                        rpt.SetParameterValue("picpath", "logo.jpg");
                        crystalReportViewer3.ReportSource = rpt;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            DateFrom.Text = "";
            DateTo.Text = "";
            crystalReportViewer2.ReportSource = null;
        }

        private void frmExpenseReport_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void crystalReportViewer3_Load(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
