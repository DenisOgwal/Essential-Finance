
namespace Banking_System
{
    partial class FrmAccountBal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountBal));
            this.cmbModeOfPayment = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new DevComponents.Editors.IntegerInput();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.staffid = new System.Windows.Forms.TextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.staffname = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbModeOfPayment
            // 
            this.cmbModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModeOfPayment.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModeOfPayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbModeOfPayment.FormattingEnabled = true;
            this.cmbModeOfPayment.Location = new System.Drawing.Point(126, 24);
            this.cmbModeOfPayment.Name = "cmbModeOfPayment";
            this.cmbModeOfPayment.Size = new System.Drawing.Size(221, 30);
            this.cmbModeOfPayment.TabIndex = 80;
            this.cmbModeOfPayment.SelectedIndexChanged += new System.EventHandler(this.cmbModeOfPayment_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(26, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 22);
            this.label18.TabIndex = 81;
            this.label18.Text = "Account";
            // 
            // txtTotalPaid
            // 
            // 
            // 
            // 
            this.txtTotalPaid.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPaid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPaid.DisplayFormat = "N0";
            this.txtTotalPaid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.Location = new System.Drawing.Point(126, 72);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.Size = new System.Drawing.Size(221, 29);
            this.txtTotalPaid.TabIndex = 89;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(26, 79);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 22);
            this.label17.TabIndex = 88;
            this.label17.Text = "Balance";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(180, 199);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 61);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 90;
            this.buttonX1.Text = "&Update";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(262, 199);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(85, 61);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 91;
            this.buttonX2.Text = "Cancel";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // staffid
            // 
            this.staffid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.staffid.Location = new System.Drawing.Point(126, 118);
            this.staffid.Name = "staffid";
            this.staffid.PasswordChar = '*';
            this.staffid.Size = new System.Drawing.Size(221, 29);
            this.staffid.TabIndex = 93;
            this.staffid.TextChanged += new System.EventHandler(this.staffid_TextChanged);
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
            this.labelX2.Location = new System.Drawing.Point(25, 118);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(95, 23);
            this.labelX2.TabIndex = 92;
            this.labelX2.Text = "Approval By";
            // 
            // staffname
            // 
            this.staffname.Enabled = false;
            this.staffname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.staffname.Location = new System.Drawing.Point(125, 164);
            this.staffname.Name = "staffname";
            this.staffname.Size = new System.Drawing.Size(221, 29);
            this.staffname.TabIndex = 95;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX3.Location = new System.Drawing.Point(25, 166);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(44, 23);
            this.labelX3.TabIndex = 94;
            this.labelX3.Text = "Name";
            // 
            // FrmAccountBal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(363, 274);
            this.Controls.Add(this.staffname);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.staffid);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtTotalPaid);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbModeOfPayment);
            this.Controls.Add(this.label18);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAccountBal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Balances";
            this.Load += new System.EventHandler(this.FrmAccountBal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbModeOfPayment;
        private System.Windows.Forms.Label label18;
        private DevComponents.Editors.IntegerInput txtTotalPaid;
        private System.Windows.Forms.Label label17;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.TextBox staffid;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox staffname;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}