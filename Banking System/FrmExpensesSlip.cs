using System;
using System.Windows.Forms;
namespace Banking_System
{
    public partial class FrmExpensesSlip : DevComponents.DotNetBar.Office2007Form
    {
     
        public FrmExpensesSlip()
        {
            InitializeComponent();
        }

        private void FrmExpensesSlip_Load(object sender, EventArgs e)
        {

        }

        private void FrmExpensesSlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmEXpenses frm = new frmEXpenses();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }

    }
}
