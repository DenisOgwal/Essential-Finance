using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_System
{
    public partial class frmConnectionLoad : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        public frmConnectionLoad()
        {
            InitializeComponent();
        }

        private void frmConnectionLoad_Load(object sender, EventArgs e)
        {
            buttonX1.Focus();

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            string conntype = null;
           
                conntype = "Local";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            
            Properties.Settings.Default["usercon"] = conntype;
            Properties.Settings.Default.Save();
            frmLoadLocalDB frm = new frmLoadLocalDB();
            frm.ShowDialog();

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            string conntype = null;
            if (radioButton1.Checked == true)
            {
                conntype = "Local";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (radioButton2.Checked == true)
            {
                conntype = "Remote";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            Properties.Settings.Default["usercon"] = conntype;
            Properties.Settings.Default.Save();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                string userserver = textBox1.Text.Trim();
                string userdb = textBox2.Text.Trim();
                string serverpass = textBox3.Text.Trim();
                string servernam = textBox4.Text.Trim();
                string instancenam = instancename.Text;
                string usercon = Properties.Settings.Default.usercon;
                string connectionString = null;
                string userName = Environment.UserName;
                string filePath1 = @"C:\\Users\" + userName + "\\documents\\Dither Technologies\\Lending";
              
                if (usercon == "Local")
                {
                    connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + filePath1 + "\\Lending.mdf;Integrated Security=True;Connect Timeout=30";
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please input Server Name");
                        return;
                    }
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Please input Database Name");
                        return;
                    }
                    connectionString = "Data Source=" + userserver + "\\" + instancenam + ",1433;Initial Catalog=" + userdb + ";User ID=" + servernam + ";Password=" + serverpass+ "";
                }

                con = new SqlConnection(connectionString);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Properties.Settings.Default["conserver"] = textBox1.Text.Trim();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default["userdb"] = textBox2.Text.Trim();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default["connectionsuccess"] = "y";
                    Properties.Settings.Default.Save();

                    Properties.Settings.Default["servernam"] = servernam;
                    Properties.Settings.Default.Save();

                    Properties.Settings.Default["serverpass"] = serverpass;
                    Properties.Settings.Default.Save();

                    Properties.Settings.Default["realcon"] = connectionString;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Successfully Saved");
                    this.Hide();
                    frmConnectionLoad frm = new frmConnectionLoad();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Connection is Wrong");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed, Wrong Connection Details");
                return;
            }
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string userserver = textBox1.Text.Trim();
                string userdb = textBox2.Text.Trim();
                string serverpass = textBox3.Text.Trim();
                string servernam = textBox4.Text.Trim();
                string instancenam = instancename.Text;
                string usercon = Properties.Settings.Default.usercon;
                string connectionString = null;
                string userName = Environment.UserName;
                string filePath1 = @"C:\\Users\" + userName + "\\documents\\Dither Technologies\\Lending";
                if (usercon == "Local")
                {
                    connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + filePath1 + "\\Lending.mdf;Integrated Security=True;Connect Timeout=30";
                }
                else
                {
                    connectionString = "Data Source=" + userserver + "\\" + instancenam + ",1433;Initial Catalog=" + userdb + ";User ID=" + servernam + ";Password=" + serverpass + "";
                }
               
                con = new SqlConnection(connectionString);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection Successful");
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed, Wrong Connection Details");
                return;
            }
        }

        private void frmConnectionLoad_Shown(object sender, EventArgs e)
        {

            try
            {

                string consuc = Properties.Settings.Default.connectionsuccess;
                if (consuc == "y")
                {
                    this.Hide();
                    frmSplashScreen frm = new frmSplashScreen();
                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmConnectionLoad_Activated(object sender, EventArgs e)
        {

        }
    }
}
