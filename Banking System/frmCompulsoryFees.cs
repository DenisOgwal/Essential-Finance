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
    public partial class frmCompulsoryFees : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmCompulsoryFees()
        {
            InitializeComponent();
        }

        private void frmCompulsoryFees_Load(object sender, EventArgs e)
        {
            string autolo = Properties.Settings.Default.compulsoryprocessing;
            string autolo2 = Properties.Settings.Default.compulsoryinsurance;
            if (autolo == "Yes")
            {
                checkBox1.Checked = true;
            }
            if (autolo2 == "Yes")
            {
                checkBox2.Checked = true;
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default["compulsoryprocessing"] = "Yes";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default["compulsoryprocessing"] = "No";
                    Properties.Settings.Default.Save();
                }

                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default["compulsoryinsurance"] = "Yes";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default["compulsoryinsurance"] = "No";
                    Properties.Settings.Default.Save();
                }
                MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void checkBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
