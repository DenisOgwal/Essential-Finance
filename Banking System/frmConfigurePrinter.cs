using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
namespace Banking_System
{
    public partial class frmConfigurePrinter : DevComponents.DotNetBar.Office2007Form
    {
       
       // SqlConnection con = null;
        //SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        //SqlDataReader rdr = null;
        public frmConfigurePrinter()
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
                //int RowsAffected = 0;
                if ((firstprinter.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter First Printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    firstprinter.Focus();
                    return;
                }
                if ((secondprinter.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter Second Printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    secondprinter.Focus();
                    return;
                }
                Properties.Settings.Default["barcodeprinter"] = firstprinter.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default["frontendprinter"] = secondprinter.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Successfully Added", "Printers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /* con = new SqlConnection(cs.DBConn);
                 con.Open();
                 string co = "SELECT * from Printers";
                 cmd = new SqlCommand(co);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     string co1 = "Update Printers set BarPrinter = '" + firstprinter.Text + "', KitchenPrinter='" + secondprinter.Text + "'";
                     cmd = new SqlCommand(co1);
                     cmd.Connection = con;
                     RowsAffected = cmd.ExecuteNonQuery();
                     if ((RowsAffected > 0))
                     {
                         MessageBox.Show("Successfully Updated", "Printers", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     }
                 }
                 else
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     string co2 = "Insert INTO Printers (BarPrinter, KitchenPrinter) Values('" + firstprinter.Text + "','" + secondprinter.Text + "')";
                     cmd = new SqlCommand(co2);
                     cmd.Connection = con;
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("Successfully Added", "Printers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 if ((con.State == ConnectionState.Open))
                 {
                     con.Close();
                 }
                 con.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            string printoptionss = Properties.Settings.Default.PrintOptions;
            if(printoptionss== "autoprint")
            {
                radioButton2.Checked = true;
            }
            else if(printoptionss == "showdialog")
            {
                radioButton1.Checked = true;
            }
            string receiptsiz = Properties.Settings.Default.receipttype;
            if (receiptsiz == "A4")
            {
                radioButton3.Checked = true;
            }
            else if (receiptsiz == "POS")
            {
                radioButton4.Checked = true;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdPrint.PrinterSettings.PrinterName = firstprinter.Text.Trim();
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
            pdPrint.PrinterSettings.PrinterName = secondprinter.Text.Trim();
            pdPrint.Print();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            string receiptlogos = null;
            if (radioButton3.Checked == true)
            {
                receiptlogos = "A4";
            }
            else if (radioButton4.Checked == true)
            {
                receiptlogos = "POS";
            }
            Properties.Settings.Default["receipttype"] = receiptlogos;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            string receiptlogos = null;
            if (radioButton3.Checked == true)
            {
                receiptlogos = "A4";
            }
            else if (radioButton4.Checked == true)
            {
                receiptlogos = "POS";
            }
            Properties.Settings.Default["receipttype"] = receiptlogos;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            string PrintOptions = null;
            if (radioButton1.Checked == true)
            {
                PrintOptions = "showdialog";
            }
            else if (radioButton2.Checked == true)
            {
                PrintOptions = "autoprint";
            }
            Properties.Settings.Default["PrintOptions"] = PrintOptions;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            string PrintOptions = null;
            if (radioButton1.Checked == true)
            {
                PrintOptions = "showdialog";
            }
            else if (radioButton2.Checked == true)
            {
                PrintOptions = "autoprint";
            }
            Properties.Settings.Default["PrintOptions"] = PrintOptions;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
