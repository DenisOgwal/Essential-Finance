using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmChooseBasis :DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FrmChooseBasis()
        {
            InitializeComponent();
        }

        private void FrmChooseBasis_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            label1.Text = "Accrual";
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            label1.Text = "Cash";
            this.Hide();
        }
    }
}
