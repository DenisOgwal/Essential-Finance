using System;
using System.Windows.Forms;
using System.Reflection;
namespace Banking_System
{
    public partial class frmContact : DevComponents.DotNetBar.Office2007Form
    {
        public frmContact()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             try{
                 string webAddress = "https://www.facebook.com/ditherug";

            System.Diagnostics.Process.Start(webAddress);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string webAddress = "https://twitter.com/DitherTechnolo1";

                System.Diagnostics.Process.Start(webAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private void frmContact_Load(object sender, EventArgs e)
        {
            this.label7.Text = AssemblyCopyright;
        }

     
    }
}
