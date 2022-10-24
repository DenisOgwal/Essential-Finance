using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.IO;
namespace Banking_System
{
    public partial class frmRemoteConnection : DevComponents.DotNetBar.Office2007Form
    {
        public Configuration config;
        public frmRemoteConnection()
        {
            InitializeComponent();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
                if ((txturl.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter ERL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txturl.Focus();
                    return;
                }

                try
                {
                    config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings["Mysql_DBConnectionString"].ConnectionString = txturl.Text.ToString();
                    config.ConnectionStrings.ConnectionStrings["Mysql_DBConnectionString"].ProviderName = "MySql.Data.MySqlClient";
                    config.Save(ConfigurationSaveMode.Modified);
                    MessageBox.Show("Successuly Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
           
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
          
        }
       
        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.PostAsync(txturl.Text.ToString(), new StringContent(""));
                    response.Wait();
                    string content = response.Result.StatusCode.ToString();
                    if (content == "OK")
                    {
                        MessageBox.Show("Successul Connection","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfigureConnection_Shown(object sender, EventArgs e)
        {
        }

        private void frmConfigureConnection_VisibleChanged(object sender, EventArgs e)
        {
           
        }

       

     
    }
}
