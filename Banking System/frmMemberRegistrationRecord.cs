using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
namespace Banking_System
{
    public partial class frmMemberRegistrationRecord : DevComponents.DotNetBar.Office2007Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmMemberRegistrationRecord()
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
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Category) FROM MemberRegistration", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Category.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Category.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void AutocompleteSession()
        {
            try
            {            
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Year) FROM MemberRegistration", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                year.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    year.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutocompleteStudentName()
        {
            try
            {              
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(MemberName) FROM MemberRegistration", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                PatientName.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    PatientName.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistrationRecord_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            AutocompleteCourse();
            AutocompleteSession();
            AutocompleteStudentName();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            Category.Text = "";
            Section.Text = "";
            year.Text = "";
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
            PatientName.Text = "";
            Section.Enabled = false;
            year.Enabled = false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
           try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                            frmMemberRegistration frm = new frmMemberRegistration();
                            frm.label33.Text = label5.Text;
                            frm.label34.Text = label8.Text;
                            frm.Show();
                            frm.accountname.Text = dr.Cells[0].Value.ToString();
                            frm.accountnumber.Text = dr.Cells[1].Value.ToString();
                            frm.dateofregistration.Text = dr.Cells[2].Value.ToString();
                            frm.Gender.Text = dr.Cells[3].Value.ToString();
                            frm.DOB.Text = dr.Cells[4].Value.ToString();
                            frm.nationalitystatus.Text = dr.Cells[5].Value.ToString();
                            frm.maritalstatus.Text = dr.Cells[6].Value.ToString();
                            //frm.year.Text = dr.Cells[7].Value.ToString();
                            frm.PostalAddress.Text = dr.Cells[8].Value.ToString();
                            frm.ContactNo.Text = dr.Cells[9].Value.ToString();
                            frm.Email.Text = dr.Cells[10].Value.ToString();
                            frm.PhysicalAddress.Text = dr.Cells[11].Value.ToString();
                            frm.BankName.Text = dr.Cells[12].Value.ToString();
                            frm.nationality.Text = dr.Cells[13].Value.ToString();
                            frm.GuardianName.Text = dr.Cells[14].Value.ToString();
                            frm.GuardianAddress.Text = dr.Cells[15].Value.ToString();
                            frm.GuardianContactNo.Text = dr.Cells[16].Value.ToString();
                            frm.Relationship.Text = dr.Cells[17].Value.ToString();
                            //frm.OccupationNext.Text = dr.Cells[18].Value.ToString();
                            //frm.Chairman.Text = dr.Cells[19].Value.ToString();
                            frm.NIN.Text = dr.Cells[20].Value.ToString();
                            if (dr.Cells[21].Value != DBNull.Value)
                            {
                                byte[] data = (byte[])dr.Cells[21].Value;
                                MemoryStream ms = new MemoryStream(data);
                                frm.pictureBox1.Image = Image.FromStream(ms);
                            }
                            else { }
                            if (dr.Cells[22].Value != DBNull.Value)
                            {
                                byte[] data2 = (byte[])dr.Cells[22].Value;
                                MemoryStream ms2 = new MemoryStream(data2);
                                //frm.pictureBox2.Image = Image.FromStream(ms2);
                            }
                            else { }
                            if (dr.Cells[23].Value != DBNull.Value)
                            {
                                byte[] data3 = (byte[])dr.Cells[23].Value;
                                MemoryStream ms3 = new MemoryStream(data3);
                                //frm.pictureBox3.Image = Image.FromStream(ms3);
                            }
                            else { }
                           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                this.Hide();
                frmMemberRegistration frm = new frmMemberRegistration();
                frm.label33.Text = label5.Text;
                frm.label34.Text = label8.Text;
                frm.Show();
                frm.accountname.Text = dr.Cells[0].Value.ToString();
                frm.accountnumber.Text = dr.Cells[1].Value.ToString();
                frm.dateofregistration.Text = dr.Cells[2].Value.ToString();
                frm.Gender.Text = dr.Cells[3].Value.ToString();
                frm.DOB.Text = dr.Cells[4].Value.ToString();
                frm.nationalitystatus.Text = dr.Cells[5].Value.ToString();
                frm.maritalstatus.Text = dr.Cells[6].Value.ToString();
                //frm.year.Text = dr.Cells[7].Value.ToString();
                frm.PostalAddress.Text = dr.Cells[8].Value.ToString();
                frm.ContactNo.Text = dr.Cells[9].Value.ToString();
                frm.Email.Text = dr.Cells[10].Value.ToString();
                frm.PhysicalAddress.Text = dr.Cells[11].Value.ToString();
                frm.BankName.Text = dr.Cells[12].Value.ToString();
                frm.nationality.Text = dr.Cells[13].Value.ToString();
                frm.GuardianName.Text = dr.Cells[14].Value.ToString();
                frm.GuardianAddress.Text = dr.Cells[15].Value.ToString();
                frm.GuardianContactNo.Text = dr.Cells[16].Value.ToString();
                frm.Relationship.Text = dr.Cells[17].Value.ToString();
                //frm.OccupationNext.Text = dr.Cells[18].Value.ToString();
                //frm.Chairman.Text = dr.Cells[19].Value.ToString();
                frm.NIN.Text = dr.Cells[20].Value.ToString();
                if (dr.Cells[21].Value != DBNull.Value)
                {
                    byte[] data = (byte[])dr.Cells[21].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.pictureBox1.Image = Image.FromStream(ms);
                }
                else { }
                if (dr.Cells[22].Value != DBNull.Value)
                {
                    byte[] data2 = (byte[])dr.Cells[22].Value;
                    MemoryStream ms2 = new MemoryStream(data2);
                    //frm.pictureBox2.Image = Image.FromStream(ms2);
                }
                else { }
                if (dr.Cells[23].Value != DBNull.Value)
                {
                    byte[] data3 = (byte[])dr.Cells[23].Value;
                    MemoryStream ms3 = new MemoryStream(data3);
                    //frm.pictureBox3.Image = Image.FromStream(ms3);
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.SelectedRows[0];
                
                this.Hide();
                frmMemberRegistration frm = new frmMemberRegistration();
                frm.label33.Text = label5.Text;
                frm.label34.Text = label8.Text;
                frm.Show();
                frm.accountname.Text = dr.Cells[0].Value.ToString();
                frm.accountnumber.Text = dr.Cells[1].Value.ToString();
                frm.dateofregistration.Text = dr.Cells[2].Value.ToString();
                frm.Gender.Text = dr.Cells[3].Value.ToString();
                frm.DOB.Text = dr.Cells[4].Value.ToString();
                frm.nationalitystatus.Text = dr.Cells[5].Value.ToString();
                frm.maritalstatus.Text = dr.Cells[6].Value.ToString();
                //frm.year.Text = dr.Cells[7].Value.ToString();
                frm.PostalAddress.Text = dr.Cells[8].Value.ToString();
                frm.ContactNo.Text = dr.Cells[9].Value.ToString();
                frm.Email.Text = dr.Cells[10].Value.ToString();
                frm.PhysicalAddress.Text = dr.Cells[11].Value.ToString();
                frm.BankName.Text = dr.Cells[12].Value.ToString();
                frm.nationality.Text = dr.Cells[13].Value.ToString();
                frm.GuardianName.Text = dr.Cells[14].Value.ToString();
                frm.GuardianAddress.Text = dr.Cells[15].Value.ToString();
                frm.GuardianContactNo.Text = dr.Cells[16].Value.ToString();
                frm.Relationship.Text = dr.Cells[17].Value.ToString();
                frm.NIN.Text = dr.Cells[20].Value.ToString();
                if (dr.Cells[21].Value != DBNull.Value)
                {
                    byte[] data = (byte[])dr.Cells[21].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.pictureBox1.Image = Image.FromStream(ms);
                }
                else { }
                if (dr.Cells[22].Value != DBNull.Value)
                {
                    byte[] data2 = (byte[])dr.Cells[22].Value;
                    MemoryStream ms2 = new MemoryStream(data2);
                    //frm.pictureBox2.Image = Image.FromStream(ms2);
                }
                else { }
                if (dr.Cells[23].Value != DBNull.Value)
                {
                    byte[] data3 = (byte[])dr.Cells[23].Value;
                    MemoryStream ms3 = new MemoryStream(data3);
                   // frm.pictureBox3.Image = Image.FromStream(ms3);
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStudentRegistrationRecord2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label5.Text;
            frm.UserType.Text = label8.Text;
            frm.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Category.Text == "")
                {
                    MessageBox.Show("Please select category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Category.Focus();
                    return;
                }
                if (Section.Text == "")
                {
                    MessageBox.Show("Please select Occupation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Section.Focus();
                    return;
                }
                if (year.Text == "")
                {
                    MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    year.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(MemberName)[Member Name], RTRIM(MemberID)[Member ID.], RTRIM(AdmissionDate)[Date Of Admission], RTRIM(Gender)[Gender], RTRIM(DOB)[DOB],RTRIM(Category)[Category],RTRIM(Religion)[Religion],RTRIM(Year)[Year], RTRIM(Address)[Address], RTRIM(ContactNo)[Contact No.], RTRIM(Email)[Email], RTRIM(Residence)[Residence], RTRIM(Occupation)[Occupation],RTRIM(Nationality)[Nationality],RTRIM(NameNext)[Next of Kin Name],RTRIM(AddressNext)[Next of Kin Address],RTRIM(ContactNoNext)[Next of Kin Contact No.], RTRIM(Relationship)[Relatioship], RTRIM(OccupationNext)[Next of kin Occupation], RTRIM(Chairman)[ChairMan], RTRIM(NIN)[NIN], (Picture)[Member Image], (PictureNext)[Neft of Kin Image], (IDScan)[ID Scan] from MemberRegistration where  Category= '" + Category.Text + "'and Occupation='" + Section.Text + "'and Year='" + year.Text + "'order by AdmissionDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridView1.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Category.Text = "";
            Section.Text = "";
            year.Text = "";
            Section.Enabled = false;
            year.Enabled = false;
            Category.Focus();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
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
                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
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
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(MemberName)[Member Name], RTRIM(MemberID)[Member ID.], RTRIM(AdmissionDate)[Date Of Admission], RTRIM(Gender)[Gender], RTRIM(DOB)[DOB],RTRIM(Category)[Category],RTRIM(Religion)[Religion],RTRIM(Year)[Year], RTRIM(Address)[Address], RTRIM(ContactNo)[Contact No.], RTRIM(Email)[Email], RTRIM(Residence)[Residence], RTRIM(Occupation)[Occupation],RTRIM(Nationality)[Nationality],RTRIM(NameNext)[Next of Kin Name],RTRIM(AddressNext)[Next of Kin Address],RTRIM(ContactNoNext)[Next of Kin Contact No.], RTRIM(Relationship)[Relatioship], RTRIM(OccupationNext)[Next of kin Occupation], RTRIM(Chairman)[ChairMan], RTRIM(NIN)[NIN],(Picture)[Member Image], (PictureNext)[Neft of Kin Image], (IDScan)[ID Scan] from MemberRegistration where  AdmissionDate between @date1 and @date2 order by AdmissionDate", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AdmissionDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AdmissionDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridView2.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
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
                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
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
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            PatientName.Text = "";
            dataGridView3.DataSource = null;
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
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
                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
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
            }
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Section.Items.Clear();
            Section.Text = "";
            Section.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Occupation) from MemberRegistration where Category= '" + Category.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Section.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(MemberName)[Member Name], RTRIM(MemberID)[Member ID.], RTRIM(AdmissionDate)[Date Of Admission], RTRIM(Gender)[Gender], RTRIM(DOB)[DOB],RTRIM(Category)[Category],RTRIM(Religion)[Religion],RTRIM(Year)[Year], RTRIM(Address)[Address], RTRIM(ContactNo)[Contact No.], RTRIM(Email)[Email], RTRIM(Residence)[Residence], RTRIM(Occupation)[Occupation],RTRIM(Nationality)[Nationality],RTRIM(NameNext)[Next of Kin Name],RTRIM(AddressNext)[Next of Kin Address],RTRIM(ContactNoNext)[Next of Kin Contact No.], RTRIM(Relationship)[Relatioship], RTRIM(OccupationNext)[Next of kin Occupation], RTRIM(Chairman)[ChairMan], RTRIM(NIN)[NIN], (Picture)[Member Image], (PictureNext)[Neft of Kin Image], (IDScan)[ID Scan] from MemberRegistration where  MemberName= '" + PatientName.Text + "'order by AdmissionDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridView3.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(MemberName)[Member Name], RTRIM(MemberID)[Member ID.], RTRIM(AdmissionDate)[Date Of Admission],  RTRIM(Gender)[Gender], RTRIM(DOB)[DOB],RTRIM(Category)[Category],RTRIM(Religion)[Religion],RTRIM(Year)[Year], RTRIM(Address)[Address], RTRIM(ContactNo)[Contact No.], RTRIM(Email)[Email], RTRIM(Residence)[Residence], RTRIM(Occupation)[Occupation],RTRIM(Nationality)[Nationality],RTRIM(NameNext)[Next of Kin Name],RTRIM(AddressNext)[Next of Kin Address],RTRIM(ContactNoNext)[Next of Kin Contact No.], RTRIM(Relationship)[Relatioship], RTRIM(OccupationNext)[Next of kin Occupation], RTRIM(Chairman)[ChairMan], RTRIM(NIN)[NIN], (Picture)[Member Image], (PictureNext)[Neft of Kin Image], (IDScan)[ID Scan] from MemberRegistration where  MemberName like'%" + textBox1.Text + "%'order by AdmissionDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "MemberRegistration");
                dataGridView3.DataSource = myDataSet.Tables["MemberRegistration"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            year.Items.Clear();
            year.Text = "";
            year.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Year) from MemberRegistration where Occupation= '" + Section.Text + "' and Category= '" + Category.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    year.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
    }
}
