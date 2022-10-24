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
    public partial class frmLoanMultipleType : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmLoanMultipleType()
        {
            InitializeComponent();
        }

        private void frmCompulsoryFees_Load(object sender, EventArgs e)
        {
            string autolo = Properties.Settings.Default.loanmultipletype;
            if (autolo == "Percentage")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
            else
            {
                checkBox1.Checked = false;
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
                    Properties.Settings.Default["loanmultipletype"] = "Percentage";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default["loanmultipletype"] = "Figure";
                    Properties.Settings.Default.Save();
                }

                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default["loanmultipletype"] = "Figure";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default["loanmultipletype"] = "Percentage";
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
            checkBox2.Checked = false;
            checkBox1.Checked = true;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox1.Checked = false;
        }
    }
}
