namespace Banking_System
{
    partial class frmAccessRights
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessRights));
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ribbonClientPanel2 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonX23 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX24 = new DevComponents.DotNetBar.ButtonX();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem3 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem4 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem5 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem6 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem7 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem8 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem9 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem10 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem11 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem12 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem13 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem14 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem15 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem16 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem17 = new DevComponents.DotNetBar.CheckBoxItem();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.ribbonClientPanel2.SuspendLayout();
            this.expandablePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.dataGridViewX2);
            this.expandablePanel1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandablePanel1.Location = new System.Drawing.Point(17, 13);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(522, 629);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 0;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Users";
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.BackgroundColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.DataBindings.Add(new System.Windows.Forms.Binding("BackgroundColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(213)))), ((int)(((byte)(245)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.RowTemplate.Height = 40;
            this.dataGridViewX2.RowTemplate.ReadOnly = true;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(516, 597);
            this.dataGridViewX2.TabIndex = 2;
            this.dataGridViewX2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellClick);
            // 
            // ribbonClientPanel2
            // 
            this.ribbonClientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonClientPanel2.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.ribbonClientPanel2.Controls.Add(this.label1);
            this.ribbonClientPanel2.Controls.Add(this.label5);
            this.ribbonClientPanel2.Controls.Add(this.label3);
            this.ribbonClientPanel2.Location = new System.Drawing.Point(5, 648);
            this.ribbonClientPanel2.Name = "ribbonClientPanel2";
            this.ribbonClientPanel2.Size = new System.Drawing.Size(795, 79);
            // 
            // 
            // 
            this.ribbonClientPanel2.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseDown.Class = "";
            this.ribbonClientPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseOver.Class = "";
            this.ribbonClientPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel2.TabIndex = 65;
            this.ribbonClientPanel2.Text = "ribbonClientPanel2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(694, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(232, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Copyright ©  2016-2020 Dither Technologies";
            // 
            // buttonX23
            // 
            this.buttonX23.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX23.Location = new System.Drawing.Point(24, 581);
            this.buttonX23.Name = "buttonX23";
            this.buttonX23.Size = new System.Drawing.Size(87, 45);
            this.buttonX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX23.TabIndex = 21;
            this.buttonX23.Text = "Save";
            this.buttonX23.Click += new System.EventHandler(this.buttonX23_Click);
            // 
            // buttonX24
            // 
            this.buttonX24.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX24.Location = new System.Drawing.Point(117, 582);
            this.buttonX24.Name = "buttonX24";
            this.buttonX24.Size = new System.Drawing.Size(87, 45);
            this.buttonX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX24.TabIndex = 22;
            this.buttonX24.Text = "Close";
            this.buttonX24.Click += new System.EventHandler(this.buttonX24_Click);
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.itemPanel1);
            this.expandablePanel2.Controls.Add(this.buttonX24);
            this.expandablePanel2.Controls.Add(this.buttonX23);
            this.expandablePanel2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandablePanel2.Location = new System.Drawing.Point(556, 13);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(229, 629);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 1;
            this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "Rights";
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.checkBoxItem1,
            this.checkBoxItem2,
            this.checkBoxItem3,
            this.checkBoxItem4,
            this.checkBoxItem5,
            this.checkBoxItem6,
            this.checkBoxItem7,
            this.checkBoxItem8,
            this.checkBoxItem9,
            this.checkBoxItem10,
            this.checkBoxItem11,
            this.checkBoxItem12,
            this.checkBoxItem13,
            this.checkBoxItem14,
            this.checkBoxItem15,
            this.checkBoxItem16,
            this.checkBoxItem17});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(3, 29);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(223, 546);
            this.itemPanel1.TabIndex = 23;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.Name = "checkBoxItem1";
            this.checkBoxItem1.Text = "Settings";
            this.checkBoxItem1.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem2
            // 
            this.checkBoxItem2.Name = "checkBoxItem2";
            this.checkBoxItem2.Text = "Human Resource";
            this.checkBoxItem2.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem3
            // 
            this.checkBoxItem3.Name = "checkBoxItem3";
            this.checkBoxItem3.Text = "Accounts Creation";
            this.checkBoxItem3.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem4
            // 
            this.checkBoxItem4.Name = "checkBoxItem4";
            this.checkBoxItem4.Text = "Savings";
            this.checkBoxItem4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem5
            // 
            this.checkBoxItem5.Name = "checkBoxItem5";
            this.checkBoxItem5.Text = "Loans";
            this.checkBoxItem5.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem6
            // 
            this.checkBoxItem6.Name = "checkBoxItem6";
            this.checkBoxItem6.Text = "Investors";
            this.checkBoxItem6.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem7
            // 
            this.checkBoxItem7.Name = "checkBoxItem7";
            this.checkBoxItem7.Text = "Inflows";
            this.checkBoxItem7.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem8
            // 
            this.checkBoxItem8.Name = "checkBoxItem8";
            this.checkBoxItem8.Text = "Outflows";
            this.checkBoxItem8.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem9
            // 
            this.checkBoxItem9.Name = "checkBoxItem9";
            this.checkBoxItem9.Text = "External Borrowing";
            this.checkBoxItem9.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem10
            // 
            this.checkBoxItem10.Name = "checkBoxItem10";
            this.checkBoxItem10.Text = "Safe Transactions";
            this.checkBoxItem10.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem11
            // 
            this.checkBoxItem11.Name = "checkBoxItem11";
            this.checkBoxItem11.Text = "Expenses";
            this.checkBoxItem11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem12
            // 
            this.checkBoxItem12.Name = "checkBoxItem12";
            this.checkBoxItem12.Text = "Financial Summary";
            this.checkBoxItem12.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem13
            // 
            this.checkBoxItem13.Name = "checkBoxItem13";
            this.checkBoxItem13.Text = "Records";
            this.checkBoxItem13.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem14
            // 
            this.checkBoxItem14.Name = "checkBoxItem14";
            this.checkBoxItem14.Text = "Reports";
            this.checkBoxItem14.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem15
            // 
            this.checkBoxItem15.Name = "checkBoxItem15";
            this.checkBoxItem15.Text = "Additions";
            this.checkBoxItem15.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem16
            // 
            this.checkBoxItem16.Name = "checkBoxItem16";
            this.checkBoxItem16.Text = "Delete";
            this.checkBoxItem16.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // checkBoxItem17
            // 
            this.checkBoxItem17.Name = "checkBoxItem17";
            this.checkBoxItem17.Text = "Update";
            this.checkBoxItem17.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // frmAccessRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(803, 733);
            this.Controls.Add(this.ribbonClientPanel2);
            this.Controls.Add(this.expandablePanel2);
            this.Controls.Add(this.expandablePanel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccessRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReceiptReprint";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmReceiptReprint_Load);
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ribbonClientPanel2.ResumeLayout(false);
            this.ribbonClientPanel2.PerformLayout();
            this.expandablePanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX23;
        private DevComponents.DotNetBar.ButtonX buttonX24;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem2;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem3;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem4;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem5;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem6;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem7;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem8;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem9;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem10;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem11;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem12;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem13;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem14;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem15;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem16;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem17;
    }
}