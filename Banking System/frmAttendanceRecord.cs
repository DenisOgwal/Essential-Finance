using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace Banking_System
{
    public partial class frmAttendanceRecord : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmAttendanceRecord()
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
            if (checkBoxX2.Checked)
            {
                try
                {
                    label19.Visible = false;
                    label20.Visible = false;
                    var _with1 = listView1;
                    _with1.Clear();
                    _with1.Columns.Add("Staff No.", 120, HorizontalAlignment.Left);
                    _with1.Columns.Add("Staff Name", 250, HorizontalAlignment.Center);
                    _with1.Columns.Add("Total Attendance", 120, HorizontalAlignment.Center);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(StaffNo)[Staff No.],Rtrim(StaffName)[Staff Name],count(Status)[Total Attendance] from Attendance where status= 'Yes' and AttendanceDate between @date1 and @date2 group by StaffNo,StaffName  order by StaffName", con);
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
                    cmd = new SqlCommand("select Count(StaffNo) from Attendance where  AttendanceDate between @date1 and @date2 group by StaffNo ", con);
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
            else
            {
                listView1.Clear();
                try
                {
                    if (staffid.Text == "")
                    {
                        MessageBox.Show("Please enter Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        staffid.Focus();
                        return;
                    }   
                    var _with1 = listView1;
                    _with1.Clear();
                    _with1.Columns.Add("Staff No.", 120, HorizontalAlignment.Left);
                    _with1.Columns.Add("Attendance Date", 250, HorizontalAlignment.Center);
                    _with1.Columns.Add("Sign In", 150, HorizontalAlignment.Center);
                    _with1.Columns.Add("Sign Out", 150, HorizontalAlignment.Center);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(StaffNo)[Staff No.],RTRIM(AttendanceDate)[Attendance Date],RTRIM(SignIn)[Sign In],RTRIM(SignOut)[Sign Out] from SignInOut where StaffNo='" + staffid.Text + "'  and AttendanceDate between @date1 and @date2 ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker1.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttendanceDate").Value = dateTimePicker2.Value.Date;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = rdr[0].ToString();
                        item.SubItems.Add(rdr[1].ToString());
                        item.SubItems.Add(rdr[2].ToString());
                        item.SubItems.Add(rdr[3].ToString());
                        listView1.Items.Add(item);
                    }
                    con.Close();
                   
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void staffid_TextChanged(object sender, EventArgs e)
        {
            try
            {
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

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                checkBoxX2.Checked = false;
            }
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX2.Checked)
            {
                checkBoxX1.Checked = false;
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {/*
            if (listView1.Items == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
                rowsTotal = listView1 - 1;
                colsTotal = listView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = listView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = listView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }*/
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

            xla.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            int i = 1;

            int j = 1;

            foreach (ListViewItem comp in listView1.Items)
            {

                ws.Cells[i, j] = comp.Text.ToString();

                //MessageBox.Show(comp.Text.ToString());

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {

                    ws.Cells[i, j] = drv.Text.ToString();

                    j++;

                }

                j = 1;

                i++;

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
        private void frmAttendanceRecord_Load(object sender, EventArgs e)
        {
            this.labelX18.Text = AssemblyCopyright;
        }
    }
}
