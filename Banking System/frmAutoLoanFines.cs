using System;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmAutoLoanFines : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmAutoLoanFines()
        {
            InitializeComponent();
        }

        private void frmCompulsoryFees_Load(object sender, EventArgs e)
        {
            string autolo = Properties.Settings.Default.autoloanfines;
           if(autolo== "Automatic")
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
                    if (noofdays.Text=="") {
                        MessageBox.Show("Please Add No. of Days");
                        return;
                    }
                    Properties.Settings.Default["autoloanfines"] = "Automatic";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default["autoloandays"]=Convert.ToInt32(noofdays.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default["autoloanfines"] = "Manual";
                    Properties.Settings.Default.Save();
                }

                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default["autoloanfines"] = "Manual";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    if (noofdays.Text == "")
                    {
                        MessageBox.Show("Please Add No. of Days");
                        return;
                    }
                    Properties.Settings.Default["autoloanfines"] = "Automatic";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default["autoloandays"] = Convert.ToInt32(noofdays.Text);
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
