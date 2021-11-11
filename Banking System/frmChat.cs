using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System
{
    public partial class frmChat : DevComponents.DotNetBar.Office2007Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();  
        public frmChat()
        {
            InitializeComponent();
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Username) from User_Registration where Category ='Staff' and Username !='"+label5.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    username.Items.Add(rdr[0]);
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void username_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select  RTRIM(Status) from User_Registration where Username ='"+username.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label3.Text=rdr.GetString(0);
                   
                }
                con.Close();
                label3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            recievedmessages.Items.Clear();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Sender,Message from Chat where Sender ='" + username.Text + "' and Date=@date1 and Username='"+label5.Text+"'Order by Chatid Desc",con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 20, "Date").Value = chatdate.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    recievedmessages.Items.Add(rdr[0]+": "+rdr[1]);              
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("Please Select username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Focus();
                return;
            }
            if (sendmessage.Text == "")
            {
                MessageBox.Show("Please type some message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sendmessage.Focus();
                return;
            }
            try{
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "insert into Chat(Username,Message,Date,Sender) VALUES (@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "Message"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Sender"));
                cmd.Parameters["@d1"].Value = username.Text.Trim();
                cmd.Parameters["@d2"].Value = sendmessage.Text;
                cmd.Parameters["@d3"].Value = chatdate.Text;
                cmd.Parameters["@d4"].Value = label5.Text;
                cmd.ExecuteReader();
                con.Close();
                recievedmessages.Items.Add(label5.Text+":  "+sendmessage.Text);
                sendmessage.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Status) from User_Registration where Username ='" + username.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {                    
                    label3.Text = rdr.GetString(0);
                    return;
                }
                con.Close();
                label3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            recievedmessages.Items.Clear();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Sender,Message from Chat where Sender ='" + username.Text + "' and Date=@date1 and Username='" + label5.Text + "'Order by Chatid Desc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 20, "Date").Value = chatdate.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    recievedmessages.Items.Add(rdr[0] + ": " + rdr[1]);
                    if ((rdr == null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chatdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Status) from User_Registration where Username ='" + username.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label3.Text = rdr.GetString(0);
                    if ((rdr == null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                label3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            recievedmessages.Items.Clear();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Sender,Message from Chat where Sender ='" + username.Text + "' and Date=@date1 and Username='" + label5.Text + "'Order by Chatid Desc", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 20, "Date").Value = chatdate.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    recievedmessages.Items.Add(rdr[0] + ": " + rdr[1]);
                    if ((rdr == null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
