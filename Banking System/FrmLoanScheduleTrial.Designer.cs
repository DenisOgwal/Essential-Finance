
namespace Banking_System
{
    partial class FrmLoanScheduleTrial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoanScheduleTrial));
            this.ApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.LoanID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PaymentInterval = new DevComponents.Editors.IntegerInput();
            this.Amount = new DevComponents.Editors.IntegerInput();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.ScheduleInterval = new System.Windows.Forms.ComboBox();
            this.AmortisationMethod = new System.Windows.Forms.ComboBox();
            this.ServicingPeriod = new DevComponents.Editors.IntegerInput();
            this.InterestRate = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicingPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.CustomFormat = "dd/MMM/yyyy";
            this.ApplicationDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ApplicationDate.Location = new System.Drawing.Point(497, 146);
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.Size = new System.Drawing.Size(206, 29);
            this.ApplicationDate.TabIndex = 133;
            // 
            // LoanID
            // 
            this.LoanID.Enabled = false;
            this.LoanID.Location = new System.Drawing.Point(172, 13);
            this.LoanID.Name = "LoanID";
            this.LoanID.Size = new System.Drawing.Size(183, 29);
            this.LoanID.TabIndex = 130;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(364, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 129;
            this.label7.Text = "Issue Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 126;
            this.label3.Text = "Loan ID";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(118, 203);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(108, 65);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "&New";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(232, 203);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(100, 65);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(475, 203);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 65);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "&Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 144;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 178);
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
            this.label6.Location = new System.Drawing.Point(16, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 145;
            this.label6.Text = "Method";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(16, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 22);
            this.label8.TabIndex = 147;
            this.label8.Text = "Interest";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(362, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 22);
            this.label12.TabIndex = 151;
            this.label12.Text = "Servicing Interval";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(364, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 22);
            this.label13.TabIndex = 153;
            this.label13.Text = "Payment Interval";
            // 
            // PaymentInterval
            // 
            // 
            // 
            // 
            this.PaymentInterval.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PaymentInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PaymentInterval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PaymentInterval.Location = new System.Drawing.Point(497, 104);
            this.PaymentInterval.Name = "PaymentInterval";
            this.PaymentInterval.Size = new System.Drawing.Size(207, 29);
            this.PaymentInterval.TabIndex = 1;
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
            this.Amount.Location = new System.Drawing.Point(172, 146);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(183, 29);
            this.Amount.TabIndex = 154;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(362, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 22);
            this.label14.TabIndex = 155;
            this.label14.Text = "Servicing Period";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(168, 178);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 22);
            this.label15.TabIndex = 157;
            this.label15.Text = "label15";
            this.label15.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(17, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(123, 22);
            this.label17.TabIndex = 159;
            this.label17.Text = "Issuable Amount";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(332, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 22);
            this.label16.TabIndex = 161;
            this.label16.Text = "label16";
            this.label16.Visible = false;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(336, 203);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(133, 65);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 162;
            this.buttonX4.Text = "&Schedule";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // ScheduleInterval
            // 
            this.ScheduleInterval.FormattingEnabled = true;
            this.ScheduleInterval.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.ScheduleInterval.Location = new System.Drawing.Point(497, 18);
            this.ScheduleInterval.Name = "ScheduleInterval";
            this.ScheduleInterval.Size = new System.Drawing.Size(208, 30);
            this.ScheduleInterval.TabIndex = 163;
            // 
            // AmortisationMethod
            // 
            this.AmortisationMethod.FormattingEnabled = true;
            this.AmortisationMethod.Items.AddRange(new object[] {
            "Reducing Balance",
            "Flat Rate"});
            this.AmortisationMethod.Location = new System.Drawing.Point(172, 57);
            this.AmortisationMethod.Name = "AmortisationMethod";
            this.AmortisationMethod.Size = new System.Drawing.Size(184, 30);
            this.AmortisationMethod.TabIndex = 164;
            // 
            // ServicingPeriod
            // 
            // 
            // 
            // 
            this.ServicingPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ServicingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ServicingPeriod.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ServicingPeriod.Location = new System.Drawing.Point(497, 62);
            this.ServicingPeriod.Name = "ServicingPeriod";
            this.ServicingPeriod.Size = new System.Drawing.Size(208, 29);
            this.ServicingPeriod.TabIndex = 165;
            // 
            // InterestRate
            // 
            // 
            // 
            // 
            this.InterestRate.Border.Class = "TextBoxBorder";
            this.InterestRate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.InterestRate.Location = new System.Drawing.Point(172, 102);
            this.InterestRate.Name = "InterestRate";
            this.InterestRate.Size = new System.Drawing.Size(183, 29);
            this.InterestRate.TabIndex = 166;
            // 
            // FrmLoanScheduleTrial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(720, 291);
            this.Controls.Add(this.InterestRate);
            this.Controls.Add(this.ServicingPeriod);
            this.Controls.Add(this.AmortisationMethod);
            this.Controls.Add(this.ScheduleInterval);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.PaymentInterval);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.ApplicationDate);
            this.Controls.Add(this.LoanID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoanScheduleTrial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan First Approval";
            this.Load += new System.EventHandler(this.FrmLoanFirstApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicingPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker ApplicationDate;
        private System.Windows.Forms.TextBox LoanID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DevComponents.Editors.IntegerInput PaymentInterval;
        private DevComponents.Editors.IntegerInput Amount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private System.Windows.Forms.ComboBox ScheduleInterval;
        private System.Windows.Forms.ComboBox AmortisationMethod;
        private DevComponents.Editors.IntegerInput ServicingPeriod;
        private DevComponents.DotNetBar.Controls.TextBoxX InterestRate;
    }
}