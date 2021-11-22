using System;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class FrmLoanScheduleReport : Form
    {
       
        public FrmLoanScheduleReport()
        {
            InitializeComponent();
        }

     
        private void FrmLoanAmortisationReport_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }
    }
}
