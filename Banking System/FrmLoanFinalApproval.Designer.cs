
namespace Banking_System
{
    partial class FrmLoanFinalApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoanFinalApproval));
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
            this.label11 = new System.Windows.Forms.Label();
            this.ApprovalComment = new System.Windows.Forms.RichTextBox();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.approvals = new System.Windows.Forms.ComboBox();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.Amount = new DevComponents.Editors.IntegerInput();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
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
            this.dataGridView1.Size = new System.Drawing.Size(310, 420);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.CustomFormat = "dd/MMM/yyyy";
            this.ApplicationDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ApplicationDate.Location = new System.Drawing.Point(493, 118);
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.Size = new System.Drawing.Size(229, 29);
            this.ApplicationDate.TabIndex = 133;
            // 
            // AccountName
            // 
            this.AccountName.Enabled = false;
            this.AccountName.Location = new System.Drawing.Point(493, 83);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(229, 29);
            this.AccountName.TabIndex = 132;
            // 
            // AccountNumber
            // 
            this.AccountNumber.Enabled = false;
            this.AccountNumber.Location = new System.Drawing.Point(493, 48);
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(229, 29);
            this.AccountNumber.TabIndex = 131;
            // 
            // LoanID
            // 
            this.LoanID.Enabled = false;
            this.LoanID.Location = new System.Drawing.Point(493, 13);
            this.LoanID.Name = "LoanID";
            this.LoanID.Size = new System.Drawing.Size(229, 29);
            this.LoanID.TabIndex = 130;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(334, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 129;
            this.label7.Text = "Approval Date";
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
            this.ApprovalName.Location = new System.Drawing.Point(493, 318);
            this.ApprovalName.Name = "ApprovalName";
            this.ApprovalName.Size = new System.Drawing.Size(229, 29);
            this.ApprovalName.TabIndex = 137;
            // 
            // ApprovalID
            // 
            this.ApprovalID.Location = new System.Drawing.Point(493, 283);
            this.ApprovalID.Name = "ApprovalID";
            this.ApprovalID.PasswordChar = '*';
            this.ApprovalID.Size = new System.Drawing.Size(229, 29);
            this.ApprovalID.TabIndex = 3;
            this.ApprovalID.TextChanged += new System.EventHandler(this.ApprovalID_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(334, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 136;
            this.label10.Text = "Approval Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(334, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 22);
            this.label9.TabIndex = 135;
            this.label9.Text = "Approval ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(334, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 22);
            this.label11.TabIndex = 138;
            this.label11.Text = "Approval Comment";
            // 
            // ApprovalComment
            // 
            this.ApprovalComment.Location = new System.Drawing.Point(493, 225);
            this.ApprovalComment.Name = "ApprovalComment";
            this.ApprovalComment.Size = new System.Drawing.Size(229, 52);
            this.ApprovalComment.TabIndex = 2;
            this.ApprovalComment.Text = "";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(359, 353);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(120, 83);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "&New";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(493, 353);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(112, 83);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(615, 353);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(107, 83);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "&Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 144;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 439);
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
            this.label6.Location = new System.Drawing.Point(334, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 22);
            this.label6.TabIndex = 145;
            this.label6.Text = "Approval";
            // 
            // approvals
            // 
            this.approvals.FormattingEnabled = true;
            this.approvals.Items.AddRange(new object[] {
            "Approved",
            "Rejected"});
            this.approvals.Location = new System.Drawing.Point(493, 153);
            this.approvals.Name = "approvals";
            this.approvals.Size = new System.Drawing.Size(229, 30);
            this.approvals.TabIndex = 1;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(728, 13);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(132, 81);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 146;
            this.buttonX4.Text = "View \r\nDetails";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX5.Location = new System.Drawing.Point(728, 100);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(132, 78);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 147;
            this.buttonX5.Text = "View Collateral";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX6.Location = new System.Drawing.Point(728, 184);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(132, 79);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 148;
            this.buttonX6.Text = "View Guarantors";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX7.Location = new System.Drawing.Point(728, 269);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(132, 78);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 149;
            this.buttonX7.Text = "View Liabilities";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX8.Location = new System.Drawing.Point(728, 353);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Size = new System.Drawing.Size(132, 83);
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX8.TabIndex = 150;
            this.buttonX8.Text = "Amortisation\r\nSchedule";
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
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
            this.Amount.Location = new System.Drawing.Point(493, 189);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(229, 29);
            this.Amount.TabIndex = 158;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(334, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 22);
            this.label8.TabIndex = 157;
            this.label8.Text = "Loan Amount";
            // 
            // FrmLoanFinalApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(877, 453);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonX8);
            this.Controls.Add(this.buttonX7);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.approvals);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.ApprovalComment);
            this.Controls.Add(this.label11);
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
            this.Name = "FrmLoanFinalApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan First Approval";
            this.Load += new System.EventHandler(this.FrmLoanFirstApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox ApprovalComment;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox approvals;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX8;
        private DevComponents.Editors.IntegerInput Amount;
        private System.Windows.Forms.Label label8;
    }
}