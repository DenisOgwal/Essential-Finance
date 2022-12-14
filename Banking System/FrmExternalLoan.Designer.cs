
namespace Banking_System
{
    partial class FrmExternalLoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExternalLoan));
            this.ApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.Lender = new System.Windows.Forms.TextBox();
            this.LoanID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ApprovalName = new System.Windows.Forms.TextBox();
            this.ApprovalID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Interest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.PaymentInterval = new DevComponents.Editors.IntegerInput();
            this.Amount = new DevComponents.Editors.IntegerInput();
            this.ServicingPeriod = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.AmortisationMethod = new System.Windows.Forms.ComboBox();
            this.RepaymentInterval = new System.Windows.Forms.ComboBox();
            this.PaymentMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Securities = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.CustomFormat = "dd/MMM/yyyy";
            this.ApplicationDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ApplicationDate.Location = new System.Drawing.Point(506, 151);
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.Size = new System.Drawing.Size(261, 29);
            this.ApplicationDate.TabIndex = 12;
            // 
            // Lender
            // 
            this.Lender.Location = new System.Drawing.Point(142, 57);
            this.Lender.Name = "Lender";
            this.Lender.Size = new System.Drawing.Size(223, 29);
            this.Lender.TabIndex = 0;
            // 
            // LoanID
            // 
            this.LoanID.Enabled = false;
            this.LoanID.Location = new System.Drawing.Point(142, 13);
            this.LoanID.Name = "LoanID";
            this.LoanID.Size = new System.Drawing.Size(223, 29);
            this.LoanID.TabIndex = 130;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(374, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 129;
            this.label7.Text = "Issue Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(17, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 127;
            this.label4.Text = "Lender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 126;
            this.label3.Text = "Loan ID";
            // 
            // ApprovalName
            // 
            this.ApprovalName.Enabled = false;
            this.ApprovalName.Location = new System.Drawing.Point(142, 286);
            this.ApprovalName.Name = "ApprovalName";
            this.ApprovalName.Size = new System.Drawing.Size(223, 29);
            this.ApprovalName.TabIndex = 137;
            // 
            // ApprovalID
            // 
            this.ApprovalID.Location = new System.Drawing.Point(142, 240);
            this.ApprovalID.Name = "ApprovalID";
            this.ApprovalID.PasswordChar = '*';
            this.ApprovalID.Size = new System.Drawing.Size(223, 29);
            this.ApprovalID.TabIndex = 9;
            this.ApprovalID.TextChanged += new System.EventHandler(this.ApprovalID_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(16, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 136;
            this.label10.Text = "Approval Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(17, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 22);
            this.label9.TabIndex = 135;
            this.label9.Text = " Approval ID";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(56, 340);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(143, 83);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 13;
            this.buttonX3.Text = "&New";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(220, 340);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(155, 83);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 10;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(570, 340);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(164, 83);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 12;
            this.buttonX1.Text = "&Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 144;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 143;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(19, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 145;
            this.label6.Text = "Method";
            // 
            // Interest
            // 
            this.Interest.Location = new System.Drawing.Point(142, 149);
            this.Interest.Name = "Interest";
            this.Interest.Size = new System.Drawing.Size(223, 29);
            this.Interest.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(22, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 22);
            this.label8.TabIndex = 147;
            this.label8.Text = "Interest";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(22, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 22);
            this.label11.TabIndex = 149;
            this.label11.Text = "Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(371, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 22);
            this.label12.TabIndex = 151;
            this.label12.Text = "Servicing Interval";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(373, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 22);
            this.label13.TabIndex = 153;
            this.label13.Text = "Payment Interval";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(391, 340);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(156, 83);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 11;
            this.buttonX4.Text = "&Schedule";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // PaymentInterval
            // 
            // 
            // 
            // 
            this.PaymentInterval.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PaymentInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PaymentInterval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PaymentInterval.Location = new System.Drawing.Point(506, 103);
            this.PaymentInterval.Name = "PaymentInterval";
            this.PaymentInterval.Size = new System.Drawing.Size(261, 29);
            this.PaymentInterval.TabIndex = 6;
            // 
            // Amount
            // 
            // 
            // 
            // 
            this.Amount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Amount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Amount.DisplayFormat = "N0";
            this.Amount.Location = new System.Drawing.Point(142, 195);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(223, 29);
            this.Amount.TabIndex = 3;
            // 
            // ServicingPeriod
            // 
            this.ServicingPeriod.Location = new System.Drawing.Point(506, 57);
            this.ServicingPeriod.Name = "ServicingPeriod";
            this.ServicingPeriod.Size = new System.Drawing.Size(261, 29);
            this.ServicingPeriod.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(371, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 22);
            this.label14.TabIndex = 155;
            this.label14.Text = "Servicing Period";
            // 
            // AmortisationMethod
            // 
            this.AmortisationMethod.FormattingEnabled = true;
            this.AmortisationMethod.Items.AddRange(new object[] {
            "Reducing Balance",
            "Flat Rate"});
            this.AmortisationMethod.Location = new System.Drawing.Point(142, 103);
            this.AmortisationMethod.Name = "AmortisationMethod";
            this.AmortisationMethod.Size = new System.Drawing.Size(223, 30);
            this.AmortisationMethod.TabIndex = 1;
            // 
            // RepaymentInterval
            // 
            this.RepaymentInterval.FormattingEnabled = true;
            this.RepaymentInterval.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.RepaymentInterval.Location = new System.Drawing.Point(506, 13);
            this.RepaymentInterval.Name = "RepaymentInterval";
            this.RepaymentInterval.Size = new System.Drawing.Size(261, 30);
            this.RepaymentInterval.TabIndex = 4;
            // 
            // PaymentMode
            // 
            this.PaymentMode.FormattingEnabled = true;
            this.PaymentMode.Location = new System.Drawing.Point(506, 194);
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.Size = new System.Drawing.Size(261, 30);
            this.PaymentMode.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(374, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 157;
            this.label5.Text = "Payment Mode";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(371, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 44);
            this.label15.TabIndex = 158;
            this.label15.Text = "Securities\r\nPresented";
            // 
            // Securities
            // 
            this.Securities.Location = new System.Drawing.Point(506, 238);
            this.Securities.Name = "Securities";
            this.Securities.Size = new System.Drawing.Size(261, 77);
            this.Securities.TabIndex = 8;
            this.Securities.Text = "";
            // 
            // FrmExternalLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.Securities);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.PaymentMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RepaymentInterval);
            this.Controls.Add(this.AmortisationMethod);
            this.Controls.Add(this.ServicingPeriod);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.PaymentInterval);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Interest);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.ApprovalName);
            this.Controls.Add(this.ApprovalID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ApplicationDate);
            this.Controls.Add(this.Lender);
            this.Controls.Add(this.LoanID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExternalLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan First Approval";
            this.Load += new System.EventHandler(this.FrmLoanFirstApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker ApplicationDate;
        private System.Windows.Forms.TextBox Lender;
        private System.Windows.Forms.TextBox LoanID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ApprovalName;
        private System.Windows.Forms.TextBox ApprovalID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Interest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.Editors.IntegerInput PaymentInterval;
        private DevComponents.Editors.IntegerInput Amount;
        private System.Windows.Forms.TextBox ServicingPeriod;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox AmortisationMethod;
        private System.Windows.Forms.ComboBox RepaymentInterval;
        private System.Windows.Forms.ComboBox PaymentMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox Securities;
    }
}