
namespace Banking_System
{
    partial class FrmExternalBorrowingReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExternalBorrowingReport));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.loanid = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.externalscheduleto = new System.Windows.Forms.DateTimePicker();
            this.externalschedulefrom = new System.Windows.Forms.DateTimePicker();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dateto = new System.Windows.Forms.DateTimePicker();
            this.datefrom = new System.Windows.Forms.DateTimePicker();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.externalrepaymentsto = new System.Windows.Forms.DateTimePicker();
            this.externalrepaymentsfrom = new System.Windows.Forms.DateTimePicker();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.rptExternalLoans1 = new Banking_System.rptExternalLoans();
            this.rptExternalLoanSchedule1 = new Banking_System.rptExternalLoanSchedule();
            this.rptExternalLoanRepayment1 = new Banking_System.rptExternalLoanRepayment();
            this.schedules = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(876, 394);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.crystalReportViewer2);
            this.tabControlPanel2.Controls.Add(this.groupPanel2);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 32);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(876, 362);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 76);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(873, 286);
            this.crystalReportViewer2.TabIndex = 20;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.schedules);
            this.groupPanel2.Controls.Add(this.label11);
            this.groupPanel2.Controls.Add(this.loanid);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.Controls.Add(this.buttonX4);
            this.groupPanel2.Controls.Add(this.buttonX6);
            this.groupPanel2.Controls.Add(this.externalscheduleto);
            this.groupPanel2.Controls.Add(this.externalschedulefrom);
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(872, 80);
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
            this.groupPanel2.TabIndex = 19;
            // 
            // loanid
            // 
            this.loanid.DisplayMember = "Text";
            this.loanid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.loanid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loanid.FormattingEnabled = true;
            this.loanid.ItemHeight = 23;
            this.loanid.Location = new System.Drawing.Point(673, 38);
            this.loanid.Name = "loanid";
            this.loanid.Size = new System.Drawing.Size(185, 29);
            this.loanid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loanid.TabIndex = 116;
            this.loanid.SelectedIndexChanged += new System.EventHandler(this.loanid_SelectedIndexChanged);
            this.loanid.TextChanged += new System.EventHandler(this.loanid_TextChanged);
            this.loanid.Click += new System.EventHandler(this.loanid_Click);
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
            this.labelX1.Location = new System.Drawing.Point(673, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 115;
            this.labelX1.Text = "Loan ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(155, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 22);
            this.label5.TabIndex = 114;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(9, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 22);
            this.label6.TabIndex = 113;
            this.label6.Text = "From";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(566, 3);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(98, 64);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 110;
            this.buttonX4.Text = "&Reset";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX6.Location = new System.Drawing.Point(462, 3);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(98, 64);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 108;
            this.buttonX6.Text = "&View";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // externalscheduleto
            // 
            this.externalscheduleto.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.externalscheduleto.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.externalscheduleto.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.externalscheduleto.CustomFormat = "dd/MMM/yyyy";
            this.externalscheduleto.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalscheduleto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.externalscheduleto.Location = new System.Drawing.Point(159, 38);
            this.externalscheduleto.Name = "externalscheduleto";
            this.externalscheduleto.Size = new System.Drawing.Size(136, 29);
            this.externalscheduleto.TabIndex = 107;
            // 
            // externalschedulefrom
            // 
            this.externalschedulefrom.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.externalschedulefrom.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.externalschedulefrom.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.externalschedulefrom.CustomFormat = "dd/MMM/yyyy";
            this.externalschedulefrom.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalschedulefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.externalschedulefrom.Location = new System.Drawing.Point(13, 37);
            this.externalschedulefrom.Name = "externalschedulefrom";
            this.externalschedulefrom.Size = new System.Drawing.Size(136, 29);
            this.externalschedulefrom.TabIndex = 106;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Loan Schedules";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.crystalReportViewer1);
            this.tabControlPanel1.Controls.Add(this.groupPanel1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 32);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(876, 362);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 76);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(873, 283);
            this.crystalReportViewer1.TabIndex = 19;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.buttonX3);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.dateto);
            this.groupPanel1.Controls.Add(this.datefrom);
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(521, 80);
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
            this.groupPanel1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(155, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 22);
            this.label4.TabIndex = 114;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 22);
            this.label3.TabIndex = 113;
            this.label3.Text = "From";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(409, 7);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(98, 64);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 110;
            this.buttonX3.Text = "&Reset";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(305, 7);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(98, 64);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 108;
            this.buttonX1.Text = "&View";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // dateto
            // 
            this.dateto.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.dateto.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateto.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.dateto.CustomFormat = "dd/MMM/yyyy";
            this.dateto.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateto.Location = new System.Drawing.Point(159, 38);
            this.dateto.Name = "dateto";
            this.dateto.Size = new System.Drawing.Size(136, 29);
            this.dateto.TabIndex = 107;
            // 
            // datefrom
            // 
            this.datefrom.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.datefrom.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.datefrom.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.datefrom.CustomFormat = "dd/MMM/yyyy";
            this.datefrom.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefrom.Location = new System.Drawing.Point(13, 37);
            this.datefrom.Name = "datefrom";
            this.datefrom.Size = new System.Drawing.Size(136, 29);
            this.datefrom.TabIndex = 106;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "External Loans";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.crystalReportViewer3);
            this.tabControlPanel3.Controls.Add(this.groupPanel3);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 32);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(876, 362);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 75);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.Size = new System.Drawing.Size(873, 284);
            this.crystalReportViewer3.TabIndex = 22;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.label8);
            this.groupPanel3.Controls.Add(this.buttonX7);
            this.groupPanel3.Controls.Add(this.buttonX9);
            this.groupPanel3.Controls.Add(this.externalrepaymentsto);
            this.groupPanel3.Controls.Add(this.externalrepaymentsfrom);
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(520, 80);
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
            this.groupPanel3.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(155, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 22);
            this.label7.TabIndex = 114;
            this.label7.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(9, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 22);
            this.label8.TabIndex = 113;
            this.label8.Text = "From";
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX7.Location = new System.Drawing.Point(409, 7);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(98, 64);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 110;
            this.buttonX7.Text = "&Reset";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX9.Location = new System.Drawing.Point(305, 7);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(98, 64);
            this.buttonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX9.TabIndex = 108;
            this.buttonX9.Text = "&View";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // externalrepaymentsto
            // 
            this.externalrepaymentsto.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.externalrepaymentsto.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.externalrepaymentsto.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.externalrepaymentsto.CustomFormat = "dd/MMM/yyyy";
            this.externalrepaymentsto.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalrepaymentsto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.externalrepaymentsto.Location = new System.Drawing.Point(159, 38);
            this.externalrepaymentsto.Name = "externalrepaymentsto";
            this.externalrepaymentsto.Size = new System.Drawing.Size(136, 29);
            this.externalrepaymentsto.TabIndex = 107;
            // 
            // externalrepaymentsfrom
            // 
            this.externalrepaymentsfrom.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.externalrepaymentsfrom.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.externalrepaymentsfrom.CalendarTitleForeColor = System.Drawing.SystemColors.Highlight;
            this.externalrepaymentsfrom.CustomFormat = "dd/MMM/yyyy";
            this.externalrepaymentsfrom.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalrepaymentsfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.externalrepaymentsfrom.Location = new System.Drawing.Point(13, 37);
            this.externalrepaymentsfrom.Name = "externalrepaymentsfrom";
            this.externalrepaymentsfrom.Size = new System.Drawing.Size(136, 29);
            this.externalrepaymentsfrom.TabIndex = 106;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "Repayments";
            // 
            // schedules
            // 
            this.schedules.FormattingEnabled = true;
            this.schedules.Items.AddRange(new object[] {
            "All"});
            this.schedules.Location = new System.Drawing.Point(301, 37);
            this.schedules.Name = "schedules";
            this.schedules.Size = new System.Drawing.Size(155, 30);
            this.schedules.TabIndex = 118;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(300, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 22);
            this.label11.TabIndex = 117;
            this.label11.Text = "Status";
            // 
            // FrmExternalBorrowingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 392);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmExternalBorrowingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "External Borrowing Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExternalBorrowingReport_FormClosing);
            this.Load += new System.EventHandler(this.FrmExternalBorrowingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.DateTimePicker dateto;
        public System.Windows.Forms.DateTimePicker datefrom;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        public System.Windows.Forms.DateTimePicker externalscheduleto;
        public System.Windows.Forms.DateTimePicker externalschedulefrom;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX9;
        public System.Windows.Forms.DateTimePicker externalrepaymentsto;
        public System.Windows.Forms.DateTimePicker externalrepaymentsfrom;
        private rptExternalLoans rptExternalLoans1;
        private rptExternalLoanSchedule rptExternalLoanSchedule1;
        private rptExternalLoanRepayment rptExternalLoanRepayment1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx loanid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox schedules;
        private System.Windows.Forms.Label label11;
    }
}