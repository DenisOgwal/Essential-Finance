
namespace Banking_System
{
    partial class FrmDisposePurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisposePurchase));
            this.DisposeAsset = new System.Windows.Forms.ComboBox();
            this.DisposePurchaseID = new System.Windows.Forms.ComboBox();
            this.DisposeValue = new DevComponents.Editors.IntegerInput();
            this.DisposedBy = new System.Windows.Forms.TextBox();
            this.registrationdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cashiername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.cashierid = new System.Windows.Forms.TextBox();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.quantity = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbModeOfPayment = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DisposeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // DisposeAsset
            // 
            this.DisposeAsset.FormattingEnabled = true;
            this.DisposeAsset.Location = new System.Drawing.Point(24, 34);
            this.DisposeAsset.Name = "DisposeAsset";
            this.DisposeAsset.Size = new System.Drawing.Size(312, 30);
            this.DisposeAsset.TabIndex = 0;
            this.DisposeAsset.SelectedIndexChanged += new System.EventHandler(this.DisposeAsset_SelectedIndexChanged);
            // 
            // DisposePurchaseID
            // 
            this.DisposePurchaseID.FormattingEnabled = true;
            this.DisposePurchaseID.Location = new System.Drawing.Point(364, 34);
            this.DisposePurchaseID.Name = "DisposePurchaseID";
            this.DisposePurchaseID.Size = new System.Drawing.Size(282, 30);
            this.DisposePurchaseID.TabIndex = 1;
            this.DisposePurchaseID.SelectedIndexChanged += new System.EventHandler(this.DisposePurchaseID_SelectedIndexChanged);
            // 
            // DisposeValue
            // 
            // 
            // 
            // 
            this.DisposeValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DisposeValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisposeValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DisposeValue.DisplayFormat = "N0";
            this.DisposeValue.Location = new System.Drawing.Point(24, 99);
            this.DisposeValue.Name = "DisposeValue";
            this.DisposeValue.Size = new System.Drawing.Size(312, 29);
            this.DisposeValue.TabIndex = 2;
            // 
            // DisposedBy
            // 
            this.DisposedBy.Location = new System.Drawing.Point(364, 159);
            this.DisposedBy.Name = "DisposedBy";
            this.DisposedBy.Size = new System.Drawing.Size(282, 29);
            this.DisposedBy.TabIndex = 3;
            // 
            // registrationdate
            // 
            this.registrationdate.CustomFormat = "dd/MMM/yyyy";
            this.registrationdate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationdate.Location = new System.Drawing.Point(24, 157);
            this.registrationdate.Name = "registrationdate";
            this.registrationdate.Size = new System.Drawing.Size(312, 29);
            this.registrationdate.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 22);
            this.label1.TabIndex = 100;
            this.label1.Text = "Asset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(360, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 101;
            this.label2.Text = "Purchase ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 22);
            this.label3.TabIndex = 102;
            this.label3.Text = "Total Dispose Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(360, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 103;
            this.label4.Text = "Disposed By";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(24, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 22);
            this.label5.TabIndex = 104;
            this.label5.Text = "Dispose Date";
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
            this.cashiername.Location = new System.Drawing.Point(364, 298);
            this.cashiername.Name = "cashiername";
            this.cashiername.Size = new System.Drawing.Size(282, 29);
            this.cashiername.TabIndex = 109;
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
            this.labelX12.Location = new System.Drawing.Point(364, 269);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(188, 23);
            this.labelX12.TabIndex = 108;
            this.labelX12.Text = "Managing Dir. Name";
            // 
            // cashierid
            // 
            this.cashierid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashierid.Location = new System.Drawing.Point(24, 298);
            this.cashierid.Name = "cashierid";
            this.cashierid.PasswordChar = '*';
            this.cashierid.Size = new System.Drawing.Size(312, 29);
            this.cashierid.TabIndex = 107;
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
            this.labelX11.Location = new System.Drawing.Point(24, 269);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(148, 23);
            this.labelX11.TabIndex = 106;
            this.labelX11.Text = "Approval ID";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(133, 333);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(121, 58);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 110;
            this.buttonX1.Text = "&New";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(261, 333);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(125, 58);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 111;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(393, 333);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(114, 58);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 112;
            this.buttonX3.Text = "&Cancel";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(364, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 114;
            this.label6.Text = "Quantity";
            // 
            // quantity
            // 
            // 
            // 
            // 
            this.quantity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.quantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.quantity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.quantity.DisplayFormat = "N0";
            this.quantity.Location = new System.Drawing.Point(364, 99);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(282, 29);
            this.quantity.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 22);
            this.label7.TabIndex = 115;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(562, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 22);
            this.label8.TabIndex = 116;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(610, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 22);
            this.label9.TabIndex = 117;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // cmbModeOfPayment
            // 
            this.cmbModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModeOfPayment.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModeOfPayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbModeOfPayment.FormattingEnabled = true;
            this.cmbModeOfPayment.Location = new System.Drawing.Point(24, 223);
            this.cmbModeOfPayment.Name = "cmbModeOfPayment";
            this.cmbModeOfPayment.Size = new System.Drawing.Size(312, 30);
            this.cmbModeOfPayment.TabIndex = 118;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(24, 198);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 22);
            this.label18.TabIndex = 119;
            this.label18.Text = "Mode Of Payment";
            // 
            // FrmDisposePurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(673, 403);
            this.Controls.Add(this.cmbModeOfPayment);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.cashiername);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.cashierid);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registrationdate);
            this.Controls.Add(this.DisposedBy);
            this.Controls.Add(this.DisposeValue);
            this.Controls.Add(this.DisposePurchaseID);
            this.Controls.Add(this.DisposeAsset);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmDisposePurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispose Purchase";
            this.Load += new System.EventHandler(this.FrmDisposePurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisposeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DisposeAsset;
        private System.Windows.Forms.ComboBox DisposePurchaseID;
        private DevComponents.Editors.IntegerInput DisposeValue;
        private System.Windows.Forms.TextBox DisposedBy;
        public System.Windows.Forms.DateTimePicker registrationdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX cashiername;
        private DevComponents.DotNetBar.LabelX labelX12;
        private System.Windows.Forms.TextBox cashierid;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.IntegerInput quantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cmbModeOfPayment;
        private System.Windows.Forms.Label label18;
    }
}