using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
namespace Banking_System
{
    public partial class frmConfigureCompanyDetails : DevComponents.DotNetBar.Office2007Form
    {
       
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        public frmConfigureCompanyDetails()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                if ((bussinessname.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter First Printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bussinessname.Focus();
                    return;
                }
                if ((slogan.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter Second Printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slogan.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string co = "SELECT * from CompanyNames";
                cmd = new SqlCommand(co);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string co1 = "Update CompanyNames set Names = '" + bussinessname.Text + "', Slogan='" + slogan.Text + "',Email='"+email.Text+"',Contacts='"+contacts.Text+"',Address='"+address.Text+"'";
                    cmd = new SqlCommand(co1);
                    cmd.Connection = con;
                    RowsAffected = cmd.ExecuteNonQuery();
                    if ((RowsAffected > 0))
                    {
                        MessageBox.Show("Successfully Updated", "Business Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string co2 = "Insert INTO CompanyNames (Names,Slogan,Email,Contacts,Address,Logo) Values('" + bussinessname.Text + "','" + slogan.Text + "','" + email.Text + "','" + contacts.Text + "','" + address.Text + "','logo.jpg')";
                    cmd = new SqlCommand(co2);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added", "Business Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string co = "SELECT * from CompanyNames";
                cmd = new SqlCommand(co);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    bussinessname.Text = rdr["Names"].ToString().Trim();
                    slogan.Text = rdr["Slogan"].ToString();
                    email.Text = rdr["Email"].ToString();
                    contacts.Text = rdr["Contacts"].ToString();
                    address.Text = rdr["Address"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdPrint.PrinterSettings.PrinterName = bussinessname.Text.Trim();
            pdPrint.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = 10;
            float y = 5;

            float width = 260.0F; // max width I found through trial and error
            float height = 0F;

            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("Arial", 8, FontStyle.Regular);
            Font drawFontArial10italic = new Font("Arial", 10, FontStyle.Italic);
            Font drawFontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;

            // Draw string to screen.
            string text = "Printer Test Successfully";
            e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

            text = "Powered by: +256 787045644  Site:www.essentialsystems.atwebpages.com";
            e.Graphics.DrawString(text, drawFontArial6Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, drawFontArial6Regular).Height;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdPrint.PrinterSettings.PrinterName = slogan.Text.Trim();
            pdPrint.Print();
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            try
            {
                string sourceFile = textBoxX1.Text;
                string destfileFile = @"\EssentialFinanceFIles";
                bool exists = System.IO.Directory.Exists(destfileFile);

                if (exists)
                {
                    string destFile = Path.Combine(destfileFile, "logo.jpg");
                    File.Copy(sourceFile, destFile, true);
                    File.SetAttributes(destFile, FileAttributes.Normal);
                    MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxX1_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
                _with1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxX1.Text = openFileDialog1.FileName;
                    label10.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
