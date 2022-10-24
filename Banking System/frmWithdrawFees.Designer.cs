namespace Banking_System
{
    partial class frmWithdrawFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWithdrawFees));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.year1 = new System.Windows.Forms.DateTimePicker();
            this.month1 = new System.Windows.Forms.DateTimePicker();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.fees = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.maximumfee = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.chairperson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chairpersonid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.minimumfee = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.date1);
            this.groupPanel1.Controls.Add(this.year1);
            this.groupPanel1.Controls.Add(this.month1);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Location = new System.Drawing.Point(13, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(420, 97);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Period Details";
            // 
            // date1
            // 
            this.date1.CustomFormat = "dd/MMM/yyyy";
            this.date1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(89, 44);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(144, 29);
            this.date1.TabIndex = 5;
            // 
            // year1
            // 
            this.year1.CustomFormat = "yyyy";
            this.year1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.year1.Location = new System.Drawing.Point(271, 15);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(118, 29);
            this.year1.TabIndex = 4;
            // 
            // month1
            // 
            this.month1.CustomFormat = "MMM";
            this.month1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.month1.Location = new System.Drawing.Point(89, 12);
            this.month1.Name = "month1";
            this.month1.Size = new System.Drawing.Size(111, 29);
            this.month1.TabIndex = 3;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX6.Location = new System.Drawing.Point(19, 44);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(54, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "Date";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX5.Location = new System.Drawing.Point(228, 16);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(37, 23);
            this.labelX5.TabIndex = 1;
            this.labelX5.Text = "Year";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX4.Location = new System.Drawing.Point(19, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(63, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Months";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.fees);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.maximumfee);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.chairperson);
            this.groupPanel2.Controls.Add(this.chairpersonid);
            this.groupPanel2.Controls.Add(this.minimumfee);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Location = new System.Drawing.Point(13, 115);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(420, 185);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Withdraw Charges Settings";
            // 
            // fees
            // 
            // 
            // 
            // 
            this.fees.Border.Class = "TextBoxBorder";
            this.fees.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fees.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fees.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fees.Location = new System.Drawing.Point(183, 66);
            this.fees.Name = "fees";
            this.fees.Size = new System.Drawing.Size(202, 29);
            this.fees.TabIndex = 10;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX8.Location = new System.Drawing.Point(19, 68);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(143, 23);
            this.labelX8.TabIndex = 9;
            this.labelX8.Text = "Fee";
            this.labelX8.Click += new System.EventHandler(this.labelX8_Click);
            // 
            // maximumfee
            // 
            // 
            // 
            // 
            this.maximumfee.Border.Class = "TextBoxBorder";
            this.maximumfee.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.maximumfee.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumfee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.maximumfee.Location = new System.Drawing.Point(183, 35);
            this.maximumfee.Name = "maximumfee";
            this.maximumfee.Size = new System.Drawing.Size(202, 29);
            this.maximumfee.TabIndex = 8;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX7.Location = new System.Drawing.Point(18, 34);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(143, 23);
            this.labelX7.TabIndex = 7;
            this.labelX7.Text = "Maximum Amount";
            // 
            // chairperson
            // 
            // 
            // 
            // 
            this.chairperson.Border.Class = "TextBoxBorder";
            this.chairperson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chairperson.Enabled = false;
            this.chairperson.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chairperson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chairperson.Location = new System.Drawing.Point(183, 136);
            this.chairperson.Name = "chairperson";
            this.chairperson.Size = new System.Drawing.Size(202, 29);
            this.chairperson.TabIndex = 6;
            // 
            // chairpersonid
            // 
            // 
            // 
            // 
            this.chairpersonid.Border.Class = "TextBoxBorder";
            this.chairpersonid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chairpersonid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chairpersonid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chairpersonid.Location = new System.Drawing.Point(183, 105);
            this.chairpersonid.Name = "chairpersonid";
            this.chairpersonid.PasswordChar = '*';
            this.chairpersonid.Size = new System.Drawing.Size(202, 29);
            this.chairpersonid.TabIndex = 5;
            this.chairpersonid.TextChanged += new System.EventHandler(this.chairpersonid_TextChanged);
            // 
            // minimumfee
            // 
            // 
            // 
            // 
            this.minimumfee.Border.Class = "TextBoxBorder";
            this.minimumfee.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.minimumfee.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumfee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.minimumfee.Location = new System.Drawing.Point(183, 3);
            this.minimumfee.Name = "minimumfee";
            this.minimumfee.Size = new System.Drawing.Size(202, 29);
            this.minimumfee.TabIndex = 3;
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
            this.labelX3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX3.Location = new System.Drawing.Point(19, 138);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(124, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Name";
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
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(19, 108);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(100, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Approval  ID";
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
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(18, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(143, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Minimum Amount";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.buttonX4);
            this.groupPanel3.Controls.Add(this.buttonX3);
            this.groupPanel3.Controls.Add(this.buttonX2);
            this.groupPanel3.Controls.Add(this.buttonX1);
            this.groupPanel3.Location = new System.Drawing.Point(12, 306);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(420, 73);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 2;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(314, 16);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 48);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 3;
            this.buttonX4.Text = "&Update";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(214, 16);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 46);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "&Delete";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(117, 16);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 47);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(19, 16);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 48);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "&New";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmWithdrawFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(445, 391);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWithdrawFees";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Withdraw fee Setting";
            this.Load += new System.EventHandler(this.frmTotalRegistrationFees_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker year1;
        private System.Windows.Forms.DateTimePicker month1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX minimumfee;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX chairperson;
        private DevComponents.DotNetBar.Controls.TextBoxX chairpersonid;
        private DevComponents.DotNetBar.Controls.TextBoxX fees;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX maximumfee;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}