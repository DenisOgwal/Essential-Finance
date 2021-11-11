using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Security.Cryptography;

namespace Banking_System
{
    public partial class frmExternalLoans : DevComponents.DotNetBar.Office2007Form
    {
        public int day = 30;
        public int month;
        public string years;
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        double principal = 0;
        int creditperiod = 0;
        double intrestrate = 0;
        double interest = 0;
        double repaymentammount = 0;
        string repaymentmonths = null;
        string repaymentdate = null;
        string paymentstatus = "Pending";
        int[] monthscount = new int[100];
        public frmExternalLoans()
        {
            InitializeComponent();
        }
        public void dataload3() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID], RTRIM(LoanAmmount)[Loan Ammount],RTRIM(Securities)[Securities],RTRIM(Comment)[Officer Comment],RTRIM(Year)[Application Year],RTRIM(Months)[Application Months], RTRIM(Date)[Application Date], RTRIM(Period)[Repayment Period] from ExternalLoans where ReviewComment='Pending...' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridViewX1.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID], RTRIM(LoanAmmount)[Loan Ammount],RTRIM(Securities)[Securities],RTRIM(Comment)[Officer Comment],RTRIM(Year)[Application Year],RTRIM(Months)[Application Months], RTRIM(Date)[Application Date],RTRIM(ManagerName)[Manager Name],RTRIM(ReviewComment)[Review Comment], RTRIM(ReviewDate)[Review Date], RTRIM(Period)[Repayment Period] from ExternalLoans where Decision !='Approved' and ReviewComment !='Pending...' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridViewX2.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(LoansID)[Loan ID], RTRIM(LoanAmmount)[Loan Ammount],RTRIM(Securities)[Securities],RTRIM(Comment)[Officer Comment],RTRIM(Year)[Application Year],RTRIM(Months)[Application Months], RTRIM(Date)[Application Date],RTRIM(ManagerName)[Manager Name],RTRIM(ReviewComment)[ReviewComment], RTRIM(ReviewDate)[Review Date], RTRIM(ChairPersonName)[Chairperson Name],RTRIM(Decision)[Decision], RTRIM(DecisionDate)[Decision Date],RTRIM(Description)[Description], RTRIM(Period)[Repayment Period] from ExternalLoans where  Decision='Approved' and Recieved !='Recieved' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ExternalLoans");
                dataGridViewX3.DataSource = myDataSet.Tables["ExternalLoans"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLoans_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            dataload3();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                buttonX5.Enabled = false;
                groupPanel3.Enabled = true;
                checkBoxX2.Checked = false;
                buttonX2.Enabled = true;
            }
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX2.Checked)
            {
                groupPanel4.Enabled = true;
                checkBoxX1.Checked = false;
                buttonX2.Enabled = true;
                buttonX5.Enabled = false;
            }
        }

      
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        private void auto()
        {

            loanid.Text = "EXID-"+ GetUniqueKey(5);
        }
        private void frmLoans_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();
        }

      
        private void Reset()
        {
         
            loanid.Text = "";
            date.Text = DateTime.Today.ToString();
            date2.Text = DateTime.Today.ToString();
            date3.Text = DateTime.Today.ToString();
            officerid.Text = "";
            officername.Text = "";
            chairpersonid.Text = "";
            chairpersonname.Text = "";
            managerid.Text = "";
            managername.Text = "";
            loanammount.Text = null;
            security.Text = "";  
            comment.Text = "";
            reviewcomment.Text = "";
            description.Text = "";
            decision.Text = "";
            period.Text = null;
            interestrate.Text ="";
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            auto();
           
                if (loanammount.Text == "")
                {
                    MessageBox.Show("Please enter Member Loan Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loanammount.Focus();
                    return;
                }
                if (period.Text == "")
                {
                    MessageBox.Show("Please enter loan period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    period.Focus();
                    return;
                }
             
                if (security.Text == "")
                {
                    MessageBox.Show("Please enter Securities", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    security.Focus();
                    return;
                }
             
             if (comment.Text == "")
                {
                    MessageBox.Show("Please enter comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comment.Focus();
                    return;
                }
              if (officername.Text == "")
                {
                    MessageBox.Show("Please enter officer name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    officername.Focus();
                    return;
                }
              if (interestrate.Text == "")
              {
                  MessageBox.Show("Please enter Inerest rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  interestrate.Focus();
                  return;
              }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select LoansID from ExternalLoans where LoansID=@find";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, " LoansID"));
                    cmd.Parameters["@find"].Value = loanid.Text;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Loans ID. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into ExternalLoans(LoansID,LoanAmmount,Securities,Comment,OfficerName,Year,Months,Date,Period,InterestRate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoansID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 15, "LoanAmmount"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 200, "Securities"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 200, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "OfficerName"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 20, "Period"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Float, 20, "InterestRate"));
                    cmd.Parameters["@d1"].Value = loanid.Text.Trim();
                    cmd.Parameters["@d2"].Value = Convert.ToInt32(loanammount.Value);
                    cmd.Parameters["@d3"].Value = security.Text.Trim();
                    cmd.Parameters["@d4"].Value = comment.Text.Trim();
                    cmd.Parameters["@d5"].Value = officername.Text.Trim();
                    cmd.Parameters["@d6"].Value = year.Text;
                     cmd.Parameters["@d7"].Value = months.Text;
                    cmd.Parameters["@d8"].Value = date.Text.Trim();
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(period.Text);
                    cmd.Parameters["@d10"].Value = interestrate.Text; 
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Savings Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonX5.Enabled = false;
                    dataload3();
                    Reset();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (loanid.Text == "")
            {
                MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loanid.Focus();
                return;
            }
           try{
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "DELETE from  ExternalLoans where LoansID=@DELETE1";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "LoansID"));
                cmd.Parameters["@DELETE1"].Value = loanid.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (loanid.Text == "")
                {
                    MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loanid.Focus();
                    return;
                }
                if (officername.Text == "")
                {
                    MessageBox.Show("Please enter Officer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    officername.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select LoansID from Loans where LoansID=@find and ReviewComment !='Pending...'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "LoansID"));
                cmd.Parameters["@find"].Value = loanid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to Update..Once Approved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update ExternalLoans set LoanAmmount=@d3,Securities=@d5,Comment=@d7,OfficerName=@d8,Year=@d9,Months=@d10,Date=@d11, Period=@d19 where LoansID=@d1 and ReviewComment='Pending...'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoansID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 15, "LoanAmmount"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 200, "Securities"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 200, "Comment"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "OfficerName"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.Int, 20, "Period"));
                cmd.Parameters["@d1"].Value = loanid.Text.Trim();
                cmd.Parameters["@d3"].Value = loanammount.Value;
                cmd.Parameters["@d5"].Value = security.Text.Trim();
                cmd.Parameters["@d7"].Value = comment.Text.Trim();
                cmd.Parameters["@d8"].Value = officername.Text.Trim();
                cmd.Parameters["@d9"].Value = year.Text;
                cmd.Parameters["@d10"].Value = months.Text;
                cmd.Parameters["@d11"].Value = date.Text.Trim();
                cmd.Parameters["@d19"].Value = Convert.ToInt32(period.Text); ;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataload3();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if(checkBoxX1.Checked){
                if (loanid.Text == "")
                {
                    MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loanid.Focus();
                    return;
                }
                if (managername.Text == "")
                {
                    MessageBox.Show("Please enter Manager Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    managername.Focus();
                    return;
                }
                if (reviewcomment.Text == "")
                {
                    MessageBox.Show("Please enter Review Comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reviewcomment.Focus();
                    return;
                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update ExternalLoans set ManagerName=@d1,ReviewComment=@d2,ReviewDate=@d3 where LoansID=@d4";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "MamagerName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 200, "ReviewComment"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "reviewDate"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "LoansID"));
                    cmd.Parameters["@d1"].Value = managername.Text.Trim();
                    cmd.Parameters["@d2"].Value = reviewcomment.Text.Trim();
                    cmd.Parameters["@d3"].Value = date2.Text.Trim();
                    cmd.Parameters["@d4"].Value = loanid.Text.Trim();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Commented", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataload3();
                    Reset();
                   
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (checkBoxX2.Checked) {
                if (checkBoxX3.Checked == false && checkBoxX4.Checked == false)
                {
                    MessageBox.Show("Please Check one of the interest Rate Types to continue ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (loanid.Text == "")
                {
                    MessageBox.Show("Please enter Loan ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loanid.Focus();
                    return;
                }
                if (decision.Text == "")
                {
                    MessageBox.Show("Please Select Decision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    decision.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please Make A description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }
                try
                {
                   
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update ExternalLoans set ChairpersonName=@d1,Decision=@d2,DecisionDate=@d3,Description=@d4 where LoansID=@d5";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "ChairpersonName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Decision"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "DecisionDate"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 15, "LoansID"));
                    cmd.Parameters["@d1"].Value = managername.Text.Trim();
                    cmd.Parameters["@d2"].Value = decision.Text.Trim();
                    cmd.Parameters["@d3"].Value = date3.Text.Trim();
                    cmd.Parameters["@d4"].Value = description.Text.Trim();
                    cmd.Parameters["@d5"].Value = loanid.Text.Trim();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Commented", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataload3();
                    
                    Reset();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void dataload() {
            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                this.Hide();
                frmExternalLoans frm = new frmExternalLoans();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.Show();
                frm.loanid.Text = dr.Cells[0].Value.ToString();
                frm.loanammount.Value = Convert.ToInt32(dr.Cells[1].Value);
                frm.security.Text = dr.Cells[2].Value.ToString();
                frm.comment.Text = dr.Cells[3].Value.ToString();
                frm.period.Text = dr.Cells[7].Value.ToString();
                frm.buttonX2.Enabled = true;
                frm.buttonX3.Enabled = true;
                frm.groupPanel3.Enabled = true;
                frm.checkBoxX1.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataload();
        }
        public void dataload1() {
            try
            {
                DataGridViewRow dr = dataGridViewX2.SelectedRows[0];
                this.Hide();
                frmExternalLoans frm = new frmExternalLoans();
                frm.label1.Text = label1.Text;
                frm.label2.Text = label2.Text;
                frm.Show();
                frm.loanid.Text = dr.Cells[0].Value.ToString();
                frm.loanammount.Text = dr.Cells[1].Value.ToString();
                frm.security.Text = dr.Cells[2].Value.ToString();
                frm.comment.Text = dr.Cells[3].Value.ToString();
                frm.managername.Text = dr.Cells[7].Value.ToString();
                frm.reviewcomment.Text = dr.Cells[8].Value.ToString();
                frm.date2.Text = dr.Cells[9].Value.ToString();
                frm.buttonX2.Enabled = true;
                frm.buttonX3.Enabled = true;
                frm.groupPanel4.Enabled = true;
                frm.checkBoxX2.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewX2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataload1();
        }
        Double begginingbalance;
        public void dataload2() {
            try
            {
                if (checkBoxX3.Checked == false && checkBoxX4.Checked == false)
                {
                    MessageBox.Show("Please Check one of the interest Rate Types to continue ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataGridViewRow dr = dataGridViewX3.SelectedRows[0];
                if (buttonX3.Enabled == true && dr.Cells[11].Value.ToString() == "Approved")
                {
                    DialogResult dialog = MessageBox.Show("Are you confirming Reciept of the loan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == System.Windows.Forms.DialogResult.Yes)
                    {
                        string recievedate = DateTime.Today.ToShortDateString();
                        DateTime dtc1 = DateTime.Parse(recievedate);
                        string convertrecievedate = dtc1.ToString("dd/MMM/yyyy");
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb4 = "update ExternalLoans set Recieved=@d1,RecievedDate=@d2 where LoansID=@d3";
                        cmd = new SqlCommand(cb4);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "Recieved"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "RecievedDate"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 15, "LoansID"));

                        cmd.Parameters["@d1"].Value = "Recieved";
                        cmd.Parameters["@d2"].Value = convertrecievedate;
                        cmd.Parameters["@d3"].Value = dr.Cells[0].Value.ToString();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        SqlDataReader rdr = null;
                        int totalaamount = 0;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "select AmountAvailable from BankAccounts where AccountNumber= 'Cash' ";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            totalaamount = Convert.ToInt32(rdr["AmountAvailable"]);
                            int newtotalammount = totalaamount + Convert.ToInt32(dr.Cells[1].Value.ToString());
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb2 = "UPDate BankAccounts Set AmountAvailable='" + newtotalammount + "', Date='" + date3.Text + "' where AccountNumber='Cash'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        try
                        {


                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select Period from ExternalLoans where LoansID='" + dr.Cells[0].Value.ToString() + "'", con);
                            creditperiod = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            con.Close();
                            try
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = new SqlCommand("select InterestRate from ExternalLoans where LoansID='" + dr.Cells[0].Value.ToString() + "' order By ID DESC", con);
                                intrestrate = Convert.ToDouble(cmd.ExecuteScalar().ToString());
                                con.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Reset();
                                return;
                            }
                            if (checkBoxX3.Checked)
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                int K = 1;
                                int i = 1;
                                while (K <= creditperiod)
                                {
                                    monthscount[K] = K;
                                    K++;
                                }
                                string repaymentdate1 = null;
                                DateTime startdate = DateTime.Parse(convertrecievedate).Date;
                                for (i = 1; i <= creditperiod; i++)
                                {
                                    repaymentmonths = monthscount[i] + "Months";
                                    if (repaymentmonths == "1Months")
                                    {
                                        repaymentdate1 = (startdate.AddDays(day)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else
                                    {
                                        DateTime repaymentdateVar = DateTime.Parse(repaymentdate1);
                                        repaymentdate1 = (repaymentdateVar.AddDays(day)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }


                                    int val1 = 0;
                                    int.TryParse(dr.Cells[1].Value.ToString(), out val1);
                                    principal = val1 / creditperiod;
                                    interest = ((intrestrate / 100) * val1);
                                    repaymentammount = principal + interest;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "insert into ExternalRepaymentSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,PaymentStatus,BalanceExist,Year,BeginningBalance) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d10,@d11)";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Months"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "AmmountPay"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Interest"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Year"));
                                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                                    cmd.Parameters["@d1"].Value = dr.Cells[0].Value.ToString();
                                    cmd.Parameters["@d2"].Value = repaymentmonths;
                                    cmd.Parameters["@d3"].Value = repaymentdate;
                                    cmd.Parameters["@d4"].Value = repaymentammount;
                                    cmd.Parameters["@d5"].Value = principal;
                                    cmd.Parameters["@d6"].Value = interest;
                                    cmd.Parameters["@d7"].Value = paymentstatus;
                                    cmd.Parameters["@d8"].Value = repaymentammount;
                                    cmd.Parameters["@d10"].Value = year.Text;
                                    cmd.Parameters["@d11"].Value = begginingbalance;
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                }
                                //MessageBox.Show("Successfully Confirmed", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (checkBoxX4.Checked)
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                int K = 1;
                                int i = 1;
                                while (K <= creditperiod)
                                {
                                    monthscount[K] = K;
                                    K++;
                                }
                                string repaymentdate1 = null;
                                DateTime startdate = DateTime.Parse(convertrecievedate).Date;
                                for (i = 1; i <= creditperiod; i++)
                                {
                                    repaymentmonths = monthscount[i] + "Months";
                                    if (repaymentmonths == "1Months")
                                    {
                                        repaymentdate1 = (startdate.AddDays(day)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }
                                    else
                                    {
                                        DateTime repaymentdateVar = DateTime.Parse(repaymentdate1);
                                        repaymentdate1 = (repaymentdateVar.AddDays(day)).ToShortDateString();
                                        DateTime dt = DateTime.Parse(repaymentdate1);
                                        repaymentdate = dt.ToString("dd/MMM/yyyy");
                                    }


                                    int val1 = 0;
                                    int.TryParse(dr.Cells[1].Value.ToString(), out val1);
                                    double emi= val1 / creditperiod;
                                    //double emi = (val1 * (intrestrate / (12 * 100)) * (Math.Pow(((1 + (intrestrate / (12 * 100)))), creditperiod))) / ((Math.Pow((1 + (intrestrate / (12 * 100))), creditperiod)) - 1);
                                    //repaymentammount = emi;
                                    if (repaymentmonths == "1Months")
                                    {
                                        interest = val1 * (intrestrate / 100);
                                        principal = emi;
                                        repaymentammount = emi + interest;
                                        begginingbalance = val1 - principal;
                                    }
                                    else
                                    {
                                        con = new SqlConnection(cs.DBConn);
                                        con.Open();
                                        string kt = "select BeginningBalance from ExternalRepaymentSchedule where LoanID='" + dr.Cells[0].Value.ToString() + "' order by ID Desc";
                                        cmd = new SqlCommand(kt);
                                        cmd.Connection = con;
                                        rdr = cmd.ExecuteReader();
                                        if (rdr.Read())
                                        {
                                            Double totals6 = Convert.ToDouble(rdr[0]);
                                            interest = totals6 * (intrestrate / 100);
                                            principal = emi;
                                            repaymentammount = emi + interest;
                                            begginingbalance = totals6 - principal;
                                            con.Close();
                                        }

                                    }
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "insert into ExternalRepaymentSchedule(LoanID,Months,PaymentDate,TotalAmmount,AmmountPay,Interest,PaymentStatus,BalanceExist,Year,BeginningBalance) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d10,@d11)";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "LoanID"));
                                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "Months"));
                                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "PaymentDate"));
                                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Float, 20, "TotalAmmount"));
                                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 20, "AmmountPay"));
                                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Float, 20, "Interest"));
                                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 15, "PaymentStatus"));
                                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Float, 20, "BalanceExist"));
                                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Year"));
                                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Float, 20, "BeginningBalance"));
                                    cmd.Parameters["@d1"].Value = dr.Cells[0].Value.ToString();
                                    cmd.Parameters["@d2"].Value = repaymentmonths;
                                    cmd.Parameters["@d3"].Value = repaymentdate;
                                    cmd.Parameters["@d4"].Value = repaymentammount;
                                    cmd.Parameters["@d5"].Value = principal;
                                    cmd.Parameters["@d6"].Value = interest;
                                    cmd.Parameters["@d7"].Value = paymentstatus;
                                    cmd.Parameters["@d8"].Value = repaymentammount;
                                    cmd.Parameters["@d10"].Value = year.Text;
                                    cmd.Parameters["@d11"].Value = begginingbalance;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        Reset();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not a Manager, can not confirm", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewX3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataload2();
            dataload3();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExternalLoansRecord frm = new frmExternalLoansRecord();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }

        private void membername_TextChanged(object sender, EventArgs e)
        {
            
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
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        private void officerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(officerid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" +result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansApplication='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        officername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        officername.Text = "";
                    }
                }
                else
                {
                    officername.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void managerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EncryptText(managerid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansManagerApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        managername.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        managername.Text = "";
                    }
                }
                else
                {
                    managername.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chairpersonid_TextChanged(object sender, EventArgs e)
        {

            try
            {
                EncryptText(chairpersonid.Text, "essentialfinance");
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StaffName,StaffID FROM Rights WHERE AuthorisationID = '" + result+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string staffids = rdr["StaffID"].ToString().Trim();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "SELECT UserName,StaffID FROM ApprovalRights WHERE StaffID='" + staffids + "' and LoansFinalApproval='Yes'";
                    cmd2 = new SqlCommand(ct);
                    cmd2.Connection = con;
                    rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read())
                    {
                        chairpersonname.Text = rdr2["UserName"].ToString().Trim();
                    }
                    else
                    {
                        chairpersonname.Text = "";
                    }
                }
                else
                {
                    chairpersonname.Text = "";
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Repayments()
        {
           
        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX3.Checked)
            {
                checkBoxX4.Checked = false;
                checkBoxX3.Checked = true;
            }
            else
            {
                checkBoxX3.Checked = false;
                checkBoxX4.Checked = true;
            }
        }

        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX4.Checked)
            {
                checkBoxX3.Checked = false;
                checkBoxX4.Checked = true;
            }
            else
            {
                checkBoxX4.Checked = false;
                checkBoxX3.Checked = true;
            }
        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

    }
}
