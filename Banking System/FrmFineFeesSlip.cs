﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Banking_System
{
    public partial class FrmFineFeesSlip : DevComponents.DotNetBar.Office2007Form
    {

        public FrmFineFeesSlip()
        {
            InitializeComponent();
        }

        private void FrmSalarySlip_Load(object sender, EventArgs e)
        {

        }

        private void FrmSalarySlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmFineFeesPayment frm = new frmFineFeesPayment();
            frm.label7.Text = label1.Text;
            frm.label12.Text = label2.Text;
            frm.Show();
        }

    }
}
