using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace Banking_System
{
    public partial class frmSplashScreen : Form
    {
        DataTable dtable = new DataTable();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string day;
        public string month;
        public string year;
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        public frmSplashScreen()
        {
            InitializeComponent();
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
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            this.labelX4.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelX1.Text = AssemblyCopyright;
            try
            {
               string sourceFile = Path.GetDirectoryName(Application.ExecutablePath);
               String filePath = @"\EssentialFinanceFIles";
               DirectoryInfo di = Directory.CreateDirectory(filePath);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try { 
            progressBar1.Visible =true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                label3.Text = "Reading modules..";
            }
            else if (this.progressBar1.Value == 20)
            {
                label3.Text = "Turning on modules.";
            }
            else if (this.progressBar1.Value == 40)
            {
                label3.Text = "Starting modules..";
            }
            else if (this.progressBar1.Value == 60)
            {
                label3.Text = "Loading modules..";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Text = "Done Loading modules..";
            }
            else if (this.progressBar1.Value == 100)
            {
               
                try
                {

                        string autoloansoption = Properties.Settings.Default.autoloanfines;
                        string autosavingstoloanoption = Properties.Settings.Default.autotransfer;
                        if (autoloansoption == "Automatic")
                        {
                            timer1.Enabled = false;
                            FrmAutoLoanFinesWork frm = new FrmAutoLoanFinesWork();
                            frm.Show();
                            this.Hide();
                        }
                       else if (autosavingstoloanoption == "Automatic")
                        {
                            timer1.Enabled = false;
                            FrmAutoSavingsToLoansWork frm = new FrmAutoSavingsToLoansWork();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            timer1.Enabled = false;
                            FrmInvestorDebit frm = new FrmInvestorDebit();
                            frm.Show();
                            this.Hide();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
               
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
