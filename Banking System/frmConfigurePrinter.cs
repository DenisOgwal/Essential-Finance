using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
namespace Banking_System
{
    public partial class frmConfigurePrinter : DevComponents.DotNetBar.Office2007Form
    {
       
        ConnectionString cs = new ConnectionString();
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
                Properties.Settings.Default["barcodeprinter"] = firstprinter.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default["frontendprinter"] = secondprinter.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Successful", "Printers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try { 
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdPrint.PrinterSettings.PrinterName = firstprinter.Text.Trim();
            pdPrint.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try{
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdPrint.PrinterSettings.PrinterName = secondprinter.Text.Trim();
            pdPrint.Print();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

     
    }
}
