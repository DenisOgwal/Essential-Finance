using System;
using System.IO;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class frmLoadLocalDB : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmLoadLocalDB()
        {
            InitializeComponent();
        }

        private void frmLoadLocalDB_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "Lending.mdf";
                string fileName2 = "Lending.ldf";
                //string userName = "Denia";
                string userName = Environment.UserName;
                String filePath = @"\Users\" + userName + "\\Documents\\Dither Technologies";
                DirectoryInfo di = Directory.CreateDirectory(filePath);

                String filePath1 = @"\Users\" + userName + "\\Documents\\Dither Technologies\\Lending";
                DirectoryInfo di1 = Directory.CreateDirectory(filePath1);

                bool exists = System.IO.Directory.Exists(filePath1);

                if (exists)
                {

                    string sourceFile1 = textBoxX1.Text;
                    string destFile = Path.Combine(filePath1, fileName);
                    File.Copy(sourceFile1, destFile, true);
                    File.SetAttributes(destFile, FileAttributes.Normal);

                    string destFile2 = Path.Combine(filePath1, fileName2);
                    string sourceFile2 = Path.Combine(label1.Text, fileName2);
                    File.Copy(sourceFile2, destFile2, true);
                    File.SetAttributes(destFile2, FileAttributes.Normal);
                    MessageBox.Show("Succesfully Loaded Database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxX1_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("Lending|Lending.mdf");
                _with1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxX1.Text = openFileDialog1.FileName;
                    label1.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
