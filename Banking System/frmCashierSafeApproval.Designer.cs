namespace Banking_System
{
    partial class frmCashierSafeApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashierSafeApproval));
            this.cashierid = new System.Windows.Forms.TextBox();
            this.cashiername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.transferid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cashierid
            // 
            this.cashierid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashierid.Location = new System.Drawing.Point(134, 75);
            this.cashierid.Name = "cashierid";
            this.cashierid.PasswordChar = '*';
            this.cashierid.Size = new System.Drawing.Size(149, 29);
            this.cashierid.TabIndex = 29;
            this.cashierid.TextChanged += new System.EventHandler(this.cashierid_TextChanged);
            // 
            // cashiername
            // 
            this.cashiername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.cashiername.Border.Class = "TextBoxBorder";
            this.cashiername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cashiername.Enabled = false;
            this.cashiername.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashiername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashiername.Location = new System.Drawing.Point(134, 120);
            this.cashiername.Name = "cashiername";
            this.cashiername.Size = new System.Drawing.Size(149, 29);
            this.cashiername.TabIndex = 28;
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
            this.labelX12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX12.Location = new System.Drawing.Point(17, 126);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(111, 23);
            this.labelX12.TabIndex = 27;
            this.labelX12.Text = "Cashier Name";
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
            this.labelX11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX11.Location = new System.Drawing.Point(16, 79);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(99, 23);
            this.labelX11.TabIndex = 26;
            this.labelX11.Text = "Approval ID";
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX13.Location = new System.Drawing.Point(16, 38);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(115, 23);
            this.labelX13.TabIndex = 31;
            this.labelX13.Text = "Transaction ID";
            // 
            // transferid
            // 
            this.transferid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.transferid.Border.Class = "TextBoxBorder";
            this.transferid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.transferid.Enabled = false;
            this.transferid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.transferid.Location = new System.Drawing.Point(134, 32);
            this.transferid.Name = "transferid";
            this.transferid.Size = new System.Drawing.Size(149, 29);
            this.transferid.TabIndex = 30;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX1.Location = new System.Drawing.Point(83, 165);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(95, 41);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 32;
            this.buttonX1.Text = "Approve";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX2.Location = new System.Drawing.Point(185, 165);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(98, 41);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 33;
            this.buttonX2.Text = "Cancel";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // frmCashierSafeApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(300, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX13);
            this.Controls.Add(this.transferid);
            this.Controls.Add(this.cashierid);
            this.Controls.Add(this.cashiername);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.labelX11);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashierSafeApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCashierSafeApproval";
            this.Load += new System.EventHandler(this.frmCashierSafeApproval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cashierid;
        private DevComponents.DotNetBar.Controls.TextBoxX cashiername;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        public DevComponents.DotNetBar.Controls.TextBoxX transferid;
        public System.Windows.Forms.Label label1;
    }
}