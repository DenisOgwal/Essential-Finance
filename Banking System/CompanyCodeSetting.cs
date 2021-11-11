using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class CompanyCodeSetting : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public CompanyCodeSetting()
        {
            InitializeComponent();
        }

        private void CompanyCodeSetting_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["companycode"] =codeset.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
