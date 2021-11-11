using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing.Printing;
using System.Globalization;
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
                string fileName = "BS.MDF";
                string fileName2 = "BS.LDF";
                //string userName = "Denia";
                string userName = Environment.UserName;
                String filePath = @"\Users\" + userName + "\\Documents\\Dither Technologies";
                DirectoryInfo di = Directory.CreateDirectory(filePath);

                String filePath1 = @"\Users\" + userName + "\\Documents\\Dither Technologies\\SACCO";
                DirectoryInfo di1 = Directory.CreateDirectory(filePath1);

                // string sourceFile = Path.GetDirectoryName(Application.ExecutablePath);
                string sourceFile = @"\Users\" + userName + "\\Desktop\\Essential Finance\\SACCO";
                bool exists = System.IO.Directory.Exists(sourceFile);

                if (exists)
                {

                    string sourceFile1 = Path.Combine(sourceFile, fileName);
                    string destFile = Path.Combine(filePath1, fileName);
                    File.Copy(sourceFile1, destFile, true);
                    File.SetAttributes(destFile, FileAttributes.Normal);

                    string destFile2 = Path.Combine(filePath1, fileName2);
                    string sourceFile2 = Path.Combine(sourceFile, fileName2);
                    File.Copy(sourceFile2, destFile2, true);
                    File.SetAttributes(destFile2, FileAttributes.Normal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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

                    if (days == "1" || days == "2")
                    {
                        string monthlychargesetting = Properties.Settings.Default.monthlycharge;
                        if (monthlychargesetting == "No")
                        {
                            frmLogin frm = new frmLogin();
                            frm.Show();
                            timer1.Enabled = false;
                            this.Hide();
                        }
                        else if (monthlychargesetting == "Yes")
                        {
                       /* timer1.Enabled = false;
                        frmmonthlydatagrid frm1 = new frmmonthlydatagrid();
                        frm1.Show();
                        this.Hide();*/
                        }
                        else
                        {
                            frmLogin frm = new frmLogin();
                            frm.Show();
                            timer1.Enabled = false;
                            this.Hide();
                        }
                    }else if (days == "3" && monthss == "12")
                    {
                       /* timer1.Enabled = false;
                        frmyeardatagrid frm1 = new frmyeardatagrid();
                        frm1.Show();
                        this.Hide();*/
                    }
                    else
                    {
                        frmLogin frm = new frmLogin();
                        frm.Show();
                        timer1.Enabled = false;
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
