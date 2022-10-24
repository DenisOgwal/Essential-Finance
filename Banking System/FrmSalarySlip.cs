using System;
using System.Windows.Forms;
namespace Banking_System
{
    public partial class FrmSalarySlip : DevComponents.DotNetBar.Office2007Form
    {
     
        public FrmSalarySlip()
        {
            InitializeComponent();
        }

        private void FrmSalarySlip_Load(object sender, EventArgs e)
        {

        }

        private void FrmSalarySlip_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmSalaryPayment frm = new frmSalaryPayment();
            frm.label7.Text = label1.Text;
            frm.label12.Text = label2.Text;
            frm.Show();*/
        }

    }
}
