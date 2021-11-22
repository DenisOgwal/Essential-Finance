
namespace Banking_System
{
    partial class FrmLoanTopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoanTopup));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.AccountName = new System.Windows.Forms.TextBox();
            this.AccountNumber = new System.Windows.Forms.TextBox();
            this.LoanID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.Amount = new DevComponents.Editors.IntegerInput();
            this.label14 = new System.Windows.Forms.Label();
            this.TopupAmount = new DevComponents.Editors.IntegerInput();
            this.label13 = new System.Windows.Forms.Label();
            this.TotalAmount = new DevComponents.Editors.IntegerInput();
            this.label15 = new System.Windows.Forms.Label();
            this.AmortisationMethod = new System.Windows.Forms.ComboBox();
            this.RepaymentInterval = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ServicingPeriod = new DevComponents.Editors.IntegerInput();
            this.InterestRate = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopupAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicingPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestRate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("BackgroundColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.Location = new System.Drawing.Point(10, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(310, 534);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.CustomFormat = "dd/MMM/yyyy";
            this.ApplicationDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ApplicationDate.Location = new System.Drawing.Point(493, 362);
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.Size = new System.Drawing.Size(282, 29);
            this.ApplicationDate.TabIndex = 133;
            // 
            // AccountName
            // 
            this.AccountName.Enabled = false;
            this.AccountName.Location = new System.Drawing.Point(493, 83);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(282, 29);
            this.AccountName.TabIndex = 132;
            // 
            // AccountNumber
            // 
            this.AccountNumber.Enabled = false;
            this.AccountNumber.Location = new System.Drawing.Point(493, 48);
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(282, 29);
            this.AccountNumber.TabIndex = 131;
            // 
            // LoanID
            // 
            this.LoanID.Enabled = false;
            this.LoanID.Location = new System.Drawing.Point(493, 13);
            this.LoanID.Name = "LoanID";
            this.LoanID.Size = new System.Drawing.Size(282, 29);
            this.LoanID.TabIndex = 130;
            this.LoanID.TextChanged += new System.EventHandler(this.LoanID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(334, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 129;
            this.label7.Text = "Application Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(334, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 128;
            this.label5.Text = "Account Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(334, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 22);
            this.label4.TabIndex = 127;
            this.label4.Text = "Account No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(334, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 126;
            this.label3.Text = "Loan ID";
            // 
            // ApprovalName
            // 
            this.ApprovalName.Enabled = false;
            this.ApprovalName.Location = new System.Drawing.Point(493, 432);
            this.ApprovalName.Name = "ApprovalName";
            this.ApprovalName.Size = new System.Drawing.Size(282, 29);
            this.ApprovalName.TabIndex = 137;
            // 
            // ApprovalID
            // 
            this.ApprovalID.Location = new System.Drawing.Point(493, 397);
            this.ApprovalID.Name = "ApprovalID";
            this.ApprovalID.PasswordChar = '*';
            this.ApprovalID.Size = new System.Drawing.Size(282, 29);
            this.ApprovalID.TabIndex = 3;
            this.ApprovalID.TextChanged += new System.EventHandler(this.ApprovalID_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(334, 435);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 136;
            this.label10.Text = "Approval Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(334, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 22);
            this.label9.TabIndex = 135;
            this.label9.Text = "Approval ID";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(333, 467);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(108, 83);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "&New";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(447, 467);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(100, 83);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(671, 467);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 83);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "&Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 144;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 384);
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
            this.label6.Location = new System.Drawing.Point(334, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 145;
            this.label6.Text = "Method";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(334, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 22);
            this.label8.TabIndex = 147;
            this.label8.Text = "Interest";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(334, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 22);
            this.label11.TabIndex = 149;
            this.label11.Text = "Existing Balance";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(334, 296);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 22);
            this.label12.TabIndex = 151;
            this.label12.Text = "Servicing Interval";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(553, 467);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(112, 83);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 6;
            this.buttonX4.Text = "&Schedule";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
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
            this.Amount.Enabled = false;
            this.Amount.Location = new System.Drawing.Point(493, 188);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(282, 29);
            this.Amount.TabIndex = 154;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(334, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 22);
            this.label14.TabIndex = 155;
            this.label14.Text = "Servicing Period";
            // 
            // TopupAmount
            // 
            // 
            // 
            // 
            this.TopupAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TopupAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TopupAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TopupAmount.DisplayFormat = "N0";
            this.TopupAmount.Location = new System.Drawing.Point(493, 223);
            this.TopupAmount.Name = "TopupAmount";
            this.TopupAmount.Size = new System.Drawing.Size(282, 29);
            this.TopupAmount.TabIndex = 158;
            this.TopupAmount.ValueChanged += new System.EventHandler(this.TopupAmount_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(334, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 22);
            this.label13.TabIndex = 157;
            this.label13.Text = "Topup Amount";
            // 
            // TotalAmount
            // 
            // 
            // 
            // 
            this.TotalAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TotalAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TotalAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TotalAmount.DisplayFormat = "N0";
            this.TotalAmount.Enabled = false;
            this.TotalAmount.Location = new System.Drawing.Point(493, 258);
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Size = new System.Drawing.Size(282, 29);
            this.TotalAmount.TabIndex = 160;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(334, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 22);
            this.label15.TabIndex = 159;
            this.label15.Text = "Total Amount";
            // 
            // AmortisationMethod
            // 
            this.AmortisationMethod.FormattingEnabled = true;
            this.AmortisationMethod.Items.AddRange(new object[] {
            "Reducing Balance",
            "Flat Rate"});
            this.AmortisationMethod.Location = new System.Drawing.Point(493, 117);
            this.AmortisationMethod.Name = "AmortisationMethod";
            this.AmortisationMethod.Size = new System.Drawing.Size(282, 30);
            this.AmortisationMethod.TabIndex = 161;
            // 
            // RepaymentInterval
            // 
            this.RepaymentInterval.FormattingEnabled = true;
            this.RepaymentInterval.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.RepaymentInterval.Location = new System.Drawing.Point(493, 291);
            this.RepaymentInterval.Name = "RepaymentInterval";
            this.RepaymentInterval.Size = new System.Drawing.Size(282, 30);
            this.RepaymentInterval.TabIndex = 162;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(226, 419);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 22);
            this.label16.TabIndex = 163;
            this.label16.Text = "label16";
            this.label16.Visible = false;
            // 
            // ServicingPeriod
            // 
            // 
            // 
            // 
            this.ServicingPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ServicingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ServicingPeriod.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ServicingPeriod.Location = new System.Drawing.Point(493, 327);
            this.ServicingPeriod.Name = "ServicingPeriod";
            this.ServicingPeriod.Size = new System.Drawing.Size(282, 29);
            this.ServicingPeriod.TabIndex = 164;
            // 
            // InterestRate
            // 
            // 
            // 
            // 
            this.InterestRate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.InterestRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.InterestRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.InterestRate.Location = new System.Drawing.Point(493, 153);
            this.InterestRate.Name = "InterestRate";
            this.InterestRate.Size = new System.Drawing.Size(282, 29);
            this.InterestRate.TabIndex = 165;
            // 
            // FrmLoanTopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(784, 565);
            this.Controls.Add(this.InterestRate);
            this.Controls.Add(this.ServicingPeriod);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.RepaymentInterval);
            this.Controls.Add(this.AmortisationMethod);
            this.Controls.Add(this.TotalAmount);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TopupAmount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
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
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.AccountNumber);
            this.Controls.Add(this.LoanID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoanTopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan First Approval";
            this.Load += new System.EventHandler(this.FrmLoanFirstApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopupAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicingPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker ApplicationDate;
        private System.Windows.Forms.TextBox AccountName;
        private System.Windows.Forms.TextBox AccountNumber;
        private System.Windows.Forms.TextBox LoanID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.Editors.IntegerInput Amount;
        private System.Windows.Forms.Label label14;
        private DevComponents.Editors.IntegerInput TopupAmount;
        private System.Windows.Forms.Label label13;
        private DevComponents.Editors.IntegerInput TotalAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox AmortisationMethod;
        private System.Windows.Forms.ComboBox RepaymentInterval;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.IntegerInput ServicingPeriod;
        private DevComponents.Editors.IntegerInput InterestRate;
    }
}