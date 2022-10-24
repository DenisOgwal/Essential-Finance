
namespace Banking_System
{
    partial class FrmFreezeAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFreezeAccount));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.accountname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.accountnumber = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX26 = new DevComponents.DotNetBar.LabelX();
            this.accountbalance = new DevComponents.Editors.IntegerInput();
            this.cashierid = new System.Windows.Forms.TextBox();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.cashiername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.amountfreezed = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.accountbalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountfreezed)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(12, 304);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(112, 71);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "&New";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(131, 304);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(103, 71);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "&Freeze";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(356, 304);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(106, 71);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "&Cancel";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // accountname
            // 
            // 
            // 
            // 
            this.accountname.Border.Class = "TextBoxBorder";
            this.accountname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.accountname.Enabled = false;
            this.accountname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.accountname.Location = new System.Drawing.Point(172, 72);
            this.accountname.Name = "accountname";
            this.accountname.Size = new System.Drawing.Size(290, 29);
            this.accountname.TabIndex = 10;
            this.accountname.Click += new System.EventHandler(this.accountname_Click);
            this.accountname.TextChanged += new System.EventHandler(this.accountname_TextChanged);
            // 
            // accountnumber
            // 
            this.accountnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.accountnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.accountnumber.DisplayMember = "Text";
            this.accountnumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.accountnumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.accountnumber.FormattingEnabled = true;
            this.accountnumber.ItemHeight = 23;
            this.accountnumber.Location = new System.Drawing.Point(172, 32);
            this.accountnumber.Name = "accountnumber";
            this.accountnumber.Size = new System.Drawing.Size(290, 29);
            this.accountnumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.accountnumber.TabIndex = 9;
            this.accountnumber.Click += new System.EventHandler(this.accountnumber_Click);
            // 
            // labelX19
            // 
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.Class = "";
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX19.Location = new System.Drawing.Point(18, 31);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(129, 23);
            this.labelX19.TabIndex = 12;
            this.labelX19.Text = "Account Number";
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.Class = "";
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX17.Location = new System.Drawing.Point(18, 72);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(111, 23);
            this.labelX17.TabIndex = 11;
            this.labelX17.Text = "Account Name";
            // 
            // labelX26
            // 
            this.labelX26.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX26.BackgroundStyle.Class = "";
            this.labelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX26.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX26.Location = new System.Drawing.Point(18, 152);
            this.labelX26.Name = "labelX26";
            this.labelX26.Size = new System.Drawing.Size(132, 23);
            this.labelX26.TabIndex = 32;
            this.labelX26.Text = "Account Balance";
            // 
            // accountbalance
            // 
            // 
            // 
            // 
            this.accountbalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.accountbalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.accountbalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.accountbalance.DisplayFormat = "N0";
            this.accountbalance.Enabled = false;
            this.accountbalance.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountbalance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.accountbalance.Location = new System.Drawing.Point(172, 146);
            this.accountbalance.Name = "accountbalance";
            this.accountbalance.Size = new System.Drawing.Size(290, 29);
            this.accountbalance.TabIndex = 31;
            // 
            // cashierid
            // 
            this.cashierid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashierid.Location = new System.Drawing.Point(172, 225);
            this.cashierid.Name = "cashierid";
            this.cashierid.PasswordChar = '*';
            this.cashierid.Size = new System.Drawing.Size(290, 29);
            this.cashierid.TabIndex = 34;
            this.cashierid.TextChanged += new System.EventHandler(this.cashierid_TextChanged);
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX11.Location = new System.Drawing.Point(17, 227);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(148, 23);
            this.labelX11.TabIndex = 33;
            this.labelX11.Text = "Approval ID";
            // 
            // cashiername
            // 
            // 
            // 
            // 
            this.cashiername.Border.Class = "TextBoxBorder";
            this.cashiername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cashiername.Enabled = false;
            this.cashiername.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashiername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashiername.Location = new System.Drawing.Point(172, 269);
            this.cashiername.Name = "cashiername";
            this.cashiername.Size = new System.Drawing.Size(290, 29);
            this.cashiername.TabIndex = 36;
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX12.Location = new System.Drawing.Point(17, 275);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(107, 23);
            this.labelX12.TabIndex = 35;
            this.labelX12.Text = "Name";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(241, 304);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(109, 69);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 37;
            this.buttonX4.Text = "&Unfreeze";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX1.Location = new System.Drawing.Point(18, 117);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(132, 23);
            this.labelX1.TabIndex = 39;
            this.labelX1.Text = "Amount";
            // 
            // amountfreezed
            // 
            // 
            // 
            // 
            this.amountfreezed.BackgroundStyle.Class = "DateTimeInputBackground";
            this.amountfreezed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.amountfreezed.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.amountfreezed.DisplayFormat = "N0";
            this.amountfreezed.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountfreezed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.amountfreezed.Location = new System.Drawing.Point(172, 111);
            this.amountfreezed.Name = "amountfreezed";
            this.amountfreezed.Size = new System.Drawing.Size(290, 29);
            this.amountfreezed.TabIndex = 38;
            this.amountfreezed.ValueChanged += new System.EventHandler(this.integerInput1_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX2.Location = new System.Drawing.Point(18, 185);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(148, 23);
            this.labelX2.TabIndex = 84;
            this.labelX2.Text = "Date";
            // 
            // date2
            // 
            this.date2.CustomFormat = "dd/MMM/yyyy";
            this.date2.Enabled = false;
            this.date2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(172, 181);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(290, 29);
            this.date2.TabIndex = 83;
            // 
            // FrmFreezeAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(479, 391);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.amountfreezed);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.cashiername);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.cashierid);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.labelX26);
            this.Controls.Add(this.accountbalance);
            this.Controls.Add(this.accountname);
            this.Controls.Add(this.accountnumber);
            this.Controls.Add(this.labelX19);
            this.Controls.Add(this.labelX17);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmFreezeAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Freeze Account";
            this.Load += new System.EventHandler(this.FrmFreezeAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountbalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountfreezed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX accountname;
        private DevComponents.DotNetBar.Controls.ComboBoxEx accountnumber;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX26;
        private DevComponents.Editors.IntegerInput accountbalance;
        private System.Windows.Forms.TextBox cashierid;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX cashiername;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput amountfreezed;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DateTimePicker date2;
    }
}