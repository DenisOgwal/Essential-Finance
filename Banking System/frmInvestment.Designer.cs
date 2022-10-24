namespace Banking_System
{
    partial class frmInvestment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvestment));
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Price = new DevComponents.Editors.IntegerInput();
            this.cmbModeOfPayment = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.units = new System.Windows.Forms.TextBox();
            this.product = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Purchasedate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.purchaseid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.staffname = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.staffid = new System.Windows.Forms.TextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(769, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 57;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(825, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 61;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.Size = new System.Drawing.Size(921, 62);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 63;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = global::Banking_System.Properties.Settings.Default.usercolor;
            this.styleManager1.ManagerStyle = global::Banking_System.Properties.Settings.Default.userstyle;
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.label12);
            this.ribbonClientPanel1.Location = new System.Drawing.Point(5, 334);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(921, 53);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.Class = "";
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.Class = "";
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 64;
            this.ribbonClientPanel1.Text = "ribbonClientPanel1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(335, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 18);
            this.label12.TabIndex = 60;
            this.label12.Text = "Copyright ©  2016-2020 Dither  Technologies";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.staffname);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.staffid);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.Price);
            this.groupPanel1.Controls.Add(this.cmbModeOfPayment);
            this.groupPanel1.Controls.Add(this.label18);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.units);
            this.groupPanel1.Controls.Add(this.product);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.description);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.Purchasedate);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.purchaseid);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Location = new System.Drawing.Point(19, 69);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(724, 255);
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
            this.groupPanel1.TabIndex = 65;
            this.groupPanel1.Text = "Investment Details";
            
            // Price
            // 
            // 
            // 
            // 
            this.Price.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Price.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Price.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Price.DisplayFormat = "N0";
            this.Price.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(524, 82);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(175, 29);
            this.Price.TabIndex = 111;
            // 
            // cmbModeOfPayment
            // 
            this.cmbModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModeOfPayment.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModeOfPayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbModeOfPayment.FormattingEnabled = true;
            this.cmbModeOfPayment.Location = new System.Drawing.Point(524, 123);
            this.cmbModeOfPayment.Name = "cmbModeOfPayment";
            this.cmbModeOfPayment.Size = new System.Drawing.Size(175, 30);
            this.cmbModeOfPayment.TabIndex = 109;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(381, 126);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 22);
            this.label18.TabIndex = 110;
            this.label18.Text = "Mode Of Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 108;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // units
            // 
            this.units.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.units.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.units.Location = new System.Drawing.Point(524, 47);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(175, 29);
            this.units.TabIndex = 107;
            // 
            // product
            // 
            this.product.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.product.Location = new System.Drawing.Point(175, 13);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(200, 29);
            this.product.TabIndex = 106;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(380, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 22);
            this.label11.TabIndex = 104;
            this.label11.Text = "Value";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.description.Location = new System.Drawing.Point(175, 82);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(200, 71);
            this.description.TabIndex = 100;
            this.description.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 22);
            this.label3.TabIndex = 99;
            this.label3.Text = "Investment Description";
            // 
            // Purchasedate
            // 
            this.Purchasedate.CustomFormat = "dd/MMM/yyyy";
            this.Purchasedate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchasedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Purchasedate.Location = new System.Drawing.Point(175, 47);
            this.Purchasedate.Name = "Purchasedate";
            this.Purchasedate.Size = new System.Drawing.Size(200, 29);
            this.Purchasedate.TabIndex = 98;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(381, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 22);
            this.label15.TabIndex = 94;
            this.label15.Text = "Units";
            // 
            // purchaseid
            // 
            this.purchaseid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.purchaseid.Location = new System.Drawing.Point(524, 12);
            this.purchaseid.Name = "purchaseid";
            this.purchaseid.ReadOnly = true;
            this.purchaseid.Size = new System.Drawing.Size(175, 29);
            this.purchaseid.TabIndex = 93;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(381, 13);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 22);
            this.label10.TabIndex = 92;
            this.label10.Text = "Registration ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(22, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 18);
            this.label7.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(4, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 89;
            this.label6.Text = "Value Date";
            
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 22);
            this.label1.TabIndex = 87;
            this.label1.Text = "Investment Name";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.buttonX4);
            this.groupPanel2.Controls.Add(this.buttonX3);
            this.groupPanel2.Controls.Add(this.buttonX2);
            this.groupPanel2.Controls.Add(this.buttonX1);
            this.groupPanel2.Location = new System.Drawing.Point(749, 80);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(167, 244);
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
            this.groupPanel2.TabIndex = 66;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Enabled = false;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX4.Location = new System.Drawing.Point(35, 185);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(93, 50);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 3;
            this.buttonX4.Text = "&Update";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Enabled = false;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX3.Location = new System.Drawing.Point(35, 129);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(93, 51);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "&Delete";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX2.Location = new System.Drawing.Point(35, 72);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(93, 51);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "&Save";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX1.Location = new System.Drawing.Point(35, 14);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(93, 52);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "&New";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // staffname
            // 
            this.staffname.Enabled = false;
            this.staffname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.staffname.Location = new System.Drawing.Point(524, 164);
            this.staffname.Name = "staffname";
            this.staffname.Size = new System.Drawing.Size(175, 29);
            this.staffname.TabIndex = 115;
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
            this.labelX3.Location = new System.Drawing.Point(385, 166);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(44, 23);
            this.labelX3.TabIndex = 114;
            this.labelX3.Text = "Name";
            // 
            // staffid
            // 
            this.staffid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.staffid.Location = new System.Drawing.Point(175, 162);
            this.staffid.Name = "staffid";
            this.staffid.PasswordChar = '*';
            this.staffid.Size = new System.Drawing.Size(200, 29);
            this.staffid.TabIndex = 113;
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
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(7, 166);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(104, 23);
            this.labelX2.TabIndex = 112;
            this.labelX2.Text = "Registered By";
            // 
            // frmInvestment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 403);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.ribbonClientPanel1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmInvestment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Set Investment Details";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseDetails_FormClosing);
            this.Load += new System.EventHandler(this.FeesDetails_Load);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker Purchasedate;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox purchaseid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.TextBox product;
        private System.Windows.Forms.TextBox units;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbModeOfPayment;
        private System.Windows.Forms.Label label18;
        private DevComponents.Editors.IntegerInput Price;
        private System.Windows.Forms.TextBox staffname;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.TextBox staffid;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}