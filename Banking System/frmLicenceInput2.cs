using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Banking_System
{
    public partial class frmLicenceInput2 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmLicenceInput2()
        {
            InitializeComponent();
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        private void frmLicenceInput_Load(object sender, EventArgs e)
        {

        }
        string results = null;
        string resultsss = null;
        string resultssss = null;
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results = Encoding.UTF8.GetString(bytesDecrypted);

            return results;
        }
        public string EncryptText2(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultsss = Convert.ToBase64String(bytesEncrypted);

            return resultsss;
        }
        public string EncryptText3(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultssss = Convert.ToBase64String(bytesEncrypted);

            return resultssss;
        }
        private async void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string copiesapplied = null;
                string companyname = null;
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string co2 = "SELECT Names,Others from CompanyNames";
                    cmd = new SqlCommand(co2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        string companynames = rdr[0].ToString();
                        copiesapplied = rdr[1].ToString();
                        string[] words = companynames.Split(' ');
                        companyname = words[0].ToLower();
                    }
                    con.Close();
                    DecryptText(licencekey.Text, "essentialfinance");
                    string[] wordsss = results.Split('/');
                   
                    string checkdate4 = DateTime.Today.ToShortDateString();
                    DateTime dtc4 = DateTime.Parse(checkdate4);
                    string converteddatesc4 = dtc4.ToString("dd/MMM/yyyy");
                    string expdate = (dtc4.AddDays(Convert.ToInt32(wordsss[1])).ToShortDateString());
                    DateTime ds = DateTime.Parse(expdate);
                    string convertcheck = ds.ToString("dd/MMM/yyyy");

                    var postData = new List<KeyValuePair<string, string>>();
                    postData.Add(new KeyValuePair<string, string>("companyname", companyname));
                    postData.Add(new KeyValuePair<string, string>("licencecode", licencecode.Text));
                    postData.Add(new KeyValuePair<string, string>("licencekey", licencekey.Text));
                    postData.Add(new KeyValuePair<string, string>("Dates", converteddatesc4));
                    var content = new FormUrlEncodedContent(postData);
                    HttpClient client = new HttpClient();
                    Uri uri = new Uri(string.Format("http://localhost:8080/DitherAPI/FinanceLicence.php", string.Empty));
                    client.BaseAddress = new Uri("http://localhost:8080/DitherAPI/FinanceLicence.php");
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = null;
                    response = await client.PostAsync("http://localhost:8080/DitherAPI/FinanceLicence.php", content);

                    if (response.IsSuccessStatusCode)
                    {
                       string result = await response.Content.ReadAsStringAsync();
                        
                       // MessageBox.Show(result);
                        //MessageBox.Show(companyname);
                        if (result== companyname)
                        {
                            string currentdatess = null;
                            string currentdatesss = null;
                            string currentdatessss = null;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string co1 = "SELECT * from Compositions";
                            cmd = new SqlCommand(co1);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read() == true)
                            {
                                currentdatess = rdr["Coding"].ToString().Trim();
                                currentdatesss = rdr["Date"].ToString().Trim();
                            }
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string co6 = "SELECT Other from CompanyNames";
                            cmd = new SqlCommand(co6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read() == true)
                            {

                                currentdatessss = rdr["Other"].ToString().Trim();
                                
                            }
                            con.Close();
                            if (licencecode.Text == currentdatessss && licencekey.Text == currentdatess)
                            {
                                Properties.Settings.Default["readcon"] = "me";
                                Properties.Settings.Default.Save();
                                MessageBox.Show("Activation Successful, Thank you", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Hide();
                            }
                            else
                            {
                                EncryptText2(converteddatesc4, "essentialfinance");
                                EncryptText3(convertcheck, "essentialfinance");

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb3 = "UPDATE  CompanyNames set Other=@d2";
                                cmd = new SqlCommand(cb3);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Other"));
                                cmd.Parameters["@d2"].Value = licencecode.Text;
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb4 = "UPDATE  CurrentDate set CurrentDate=@d2";
                                cmd = new SqlCommand(cb4);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "CurrentDate"));
                                cmd.Parameters["@d2"].Value = resultsss;
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con.Open();
                                string cb5 = "UPDATE  Compositions set Coding=@d2,Date=@d3";
                                cmd = new SqlCommand(cb5);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Coding"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                                cmd.Parameters["@d2"].Value = licencekey.Text;
                                cmd.Parameters["@d3"].Value = resultssss;
                                cmd.ExecuteNonQuery();
                                con.Close();
                                Properties.Settings.Default["readcon"] = "me";
                                Properties.Settings.Default.Save();
                                MessageBox.Show("Activation Successful, Thank you", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Key and Code you applied do not match the Company Names, Please Contact Dither for Genuine Credentials","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your internet connection, You Can not Activate this software without Internet connection");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
