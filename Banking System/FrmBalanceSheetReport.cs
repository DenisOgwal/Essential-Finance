using System;
using System.Windows.Forms;
namespace Banking_System
{
    public partial class FrmBalanceSheetReport : DevComponents.DotNetBar.Office2007Form
    {

        public FrmBalanceSheetReport()
        {
            InitializeComponent();
        }

        private void FrmSalarySlip_Load(object sender, EventArgs e)
        {

        }

        private void FrmSalarySlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmGeneralReport frm = new frmGeneralReport();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();*/
        }

    }
}
