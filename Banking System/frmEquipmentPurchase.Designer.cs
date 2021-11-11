namespace Banking_System
{
    partial class frmEquipmentPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipmentPurchase));
            this.units = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.quantity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.manufacturer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.purchasedate = new System.Windows.Forms.DateTimePicker();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.equipmentname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.totalcost = new DevComponents.Editors.IntegerInput();
            this.costperunit = new DevComponents.Editors.IntegerInput();
            this.paymentmode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Supplier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.invoices = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.description = new System.Windows.Forms.RichTextBox();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.model = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.specifications = new System.Windows.Forms.RichTextBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.purchaseid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outlet = new System.Windows.Forms.Label();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalcost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costperunit)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // units
            // 
            this.units.DisplayMember = "Text";
            this.units.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.units.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.units.FormattingEnabled = true;
            this.units.ItemHeight = 23;
            this.units.Items.AddRange(new object[] {
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13,
            this.comboItem14,
            this.comboItem15});
            this.units.Location = new System.Drawing.Point(168, 159);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(226, 29);
            this.units.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.units.TabIndex = 14;
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "Boxes";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "Kgs";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "gms";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "Pieces";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "Bags";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Tonnes";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "Packets";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "Meters";
            // 
            // quantity
            // 
            // 
            // 
            // 
            this.quantity.Border.Class = "TextBoxBorder";
            this.quantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.quantity.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(168, 121);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(226, 29);
            this.quantity.TabIndex = 13;
            this.quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantity_KeyPress);
            // 
            // manufacturer
            // 
            // 
            // 
            // 
            this.manufacturer.Border.Class = "TextBoxBorder";
            this.manufacturer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.manufacturer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manufacturer.Location = new System.Drawing.Point(170, 51);
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.Size = new System.Drawing.Size(225, 29);
            this.manufacturer.TabIndex = 11;
            // 
            // purchasedate
            // 
            this.purchasedate.CustomFormat = "dd/MMM/yyyy";
            this.purchasedate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.purchasedate.Location = new System.Drawing.Point(526, 15);
            this.purchasedate.Name = "purchasedate";
            this.purchasedate.Size = new System.Drawing.Size(119, 29);
            this.purchasedate.TabIndex = 17;
            // 
            // labelX18
            // 
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.Class = "";
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX18.Location = new System.Drawing.Point(403, 19);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(120, 23);
            this.labelX18.TabIndex = 16;
            this.labelX18.Text = "Purchase Date";
            // 
            // equipmentname
            // 
            // 
            // 
            // 
            this.equipmentname.Border.Class = "TextBoxBorder";
            this.equipmentname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.equipmentname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentname.Location = new System.Drawing.Point(169, 15);
            this.equipmentname.Name = "equipmentname";
            this.equipmentname.Size = new System.Drawing.Size(225, 29);
            this.equipmentname.TabIndex = 10;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.Location = new System.Drawing.Point(27, 56);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(126, 23);
            this.labelX9.TabIndex = 5;
            this.labelX9.Text = "Manufacturer";
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
            this.labelX4.Location = new System.Drawing.Point(26, 15);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(137, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Equipment Name";
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.Location = new System.Drawing.Point(403, 85);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(117, 23);
            this.labelX14.TabIndex = 10;
            this.labelX14.Text = "Specifications";
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
            this.labelX12.Location = new System.Drawing.Point(26, 165);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(58, 23);
            this.labelX12.TabIndex = 8;
            this.labelX12.Text = "Units";
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
            this.labelX11.Location = new System.Drawing.Point(26, 121);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(100, 23);
            this.labelX11.TabIndex = 7;
            this.labelX11.Text = "No. of Units";
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.totalcost);
            this.groupPanel2.Controls.Add(this.costperunit);
            this.groupPanel2.Controls.Add(this.paymentmode);
            this.groupPanel2.Controls.Add(this.label14);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.Supplier);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.invoices);
            this.groupPanel2.Controls.Add(this.labelX25);
            this.groupPanel2.Controls.Add(this.labelX22);
            this.groupPanel2.Controls.Add(this.labelX21);
            this.groupPanel2.Controls.Add(this.description);
            this.groupPanel2.Controls.Add(this.labelX20);
            this.groupPanel2.Controls.Add(this.model);
            this.groupPanel2.Controls.Add(this.labelX15);
            this.groupPanel2.Controls.Add(this.specifications);
            this.groupPanel2.Controls.Add(this.units);
            this.groupPanel2.Controls.Add(this.quantity);
            this.groupPanel2.Controls.Add(this.manufacturer);
            this.groupPanel2.Controls.Add(this.purchasedate);
            this.groupPanel2.Controls.Add(this.labelX18);
            this.groupPanel2.Controls.Add(this.equipmentname);
            this.groupPanel2.Controls.Add(this.labelX14);
            this.groupPanel2.Controls.Add(this.labelX12);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Location = new System.Drawing.Point(3, 46);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(828, 328);
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
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "Equipment Details";
           
            // totalcost
            // 
            // 
            // 
            // 
            this.totalcost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.totalcost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalcost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.totalcost.DisplayFormat = "N0";
            this.totalcost.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcost.Location = new System.Drawing.Point(168, 229);
            this.totalcost.Name = "totalcost";
            this.totalcost.Size = new System.Drawing.Size(226, 29);
            this.totalcost.TabIndex = 265;
            // 
            // costperunit
            // 
            // 
            // 
            // 
            this.costperunit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.costperunit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.costperunit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.costperunit.DisplayFormat = "N0";
            this.costperunit.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costperunit.Location = new System.Drawing.Point(168, 194);
            this.costperunit.Name = "costperunit";
            this.costperunit.Size = new System.Drawing.Size(226, 29);
            this.costperunit.TabIndex = 264;
            this.costperunit.ValueChanged += new System.EventHandler(this.costperunit_ValueChanged);
            // 
            // paymentmode
            // 
            this.paymentmode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentmode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentmode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.paymentmode.FormattingEnabled = true;
            this.paymentmode.Items.AddRange(new object[] {
            "Cash",
            "Bank",
            "Mobile Money"});
            this.paymentmode.Location = new System.Drawing.Point(545, 250);
            this.paymentmode.Name = "paymentmode";
            this.paymentmode.Size = new System.Drawing.Size(274, 30);
            this.paymentmode.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(407, 253);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 22);
            this.label14.TabIndex = 250;
            this.label14.Text = "Payment Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 247;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // Supplier
            // 
            // 
            // 
            // 
            this.Supplier.Border.Class = "TextBoxBorder";
            this.Supplier.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Supplier.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier.Location = new System.Drawing.Point(169, 86);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(225, 29);
            this.Supplier.TabIndex = 12;
            this.Supplier.Click += new System.EventHandler(this.Supplier_Click);
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
            this.labelX1.Location = new System.Drawing.Point(26, 91);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(126, 23);
            this.labelX1.TabIndex = 245;
            this.labelX1.Text = "Supplier";
            // 
            // invoices
            // 
            this.invoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.invoices.Border.Class = "TextBoxBorder";
            this.invoices.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.invoices.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoices.Location = new System.Drawing.Point(741, 15);
            this.invoices.Name = "invoices";
            this.invoices.Size = new System.Drawing.Size(77, 29);
            this.invoices.TabIndex = 17;
            // 
            // labelX25
            // 
            this.labelX25.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX25.BackgroundStyle.Class = "";
            this.labelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX25.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX25.Location = new System.Drawing.Point(651, 15);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(84, 23);
            this.labelX25.TabIndex = 41;
            this.labelX25.Text = "Invoice No.";
            // 
            // labelX22
            // 
            this.labelX22.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.Class = "";
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX22.Location = new System.Drawing.Point(27, 235);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(90, 23);
            this.labelX22.TabIndex = 37;
            this.labelX22.Text = "Total Cost";
            // 
            // labelX21
            // 
            this.labelX21.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.Class = "";
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX21.Location = new System.Drawing.Point(27, 200);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(112, 23);
            this.labelX21.TabIndex = 36;
            this.labelX21.Text = "Cost Per Unit";
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(544, 174);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(274, 70);
            this.description.TabIndex = 20;
            this.description.Text = "";
            // 
            // labelX20
            // 
            this.labelX20.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.Class = "";
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX20.Location = new System.Drawing.Point(403, 180);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(117, 23);
            this.labelX20.TabIndex = 34;
            this.labelX20.Text = "Descriptions";
            
            // model
            // 
            this.model.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.model.Border.Class = "TextBoxBorder";
            this.model.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.model.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model.Location = new System.Drawing.Point(545, 50);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(274, 29);
            this.model.TabIndex = 16;
            // 
            // labelX15
            // 
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.Class = "";
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX15.Location = new System.Drawing.Point(404, 51);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(87, 23);
            this.labelX15.TabIndex = 30;
            this.labelX15.Text = "Model";
            // 
            // specifications
            // 
            this.specifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specifications.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specifications.Location = new System.Drawing.Point(544, 85);
            this.specifications.Name = "specifications";
            this.specifications.Size = new System.Drawing.Size(274, 83);
            this.specifications.TabIndex = 19;
            this.specifications.Text = "";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.purchaseid);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(828, 37);
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
            this.groupPanel1.TabIndex = 6;
            // 
            // purchaseid
            // 
            // 
            // 
            // 
            this.purchaseid.Border.Class = "TextBoxBorder";
            this.purchaseid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.purchaseid.Enabled = false;
            this.purchaseid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseid.Location = new System.Drawing.Point(291, 0);
            this.purchaseid.Name = "purchaseid";
            this.purchaseid.Size = new System.Drawing.Size(342, 29);
            this.purchaseid.TabIndex = 5;
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
            this.labelX3.Location = new System.Drawing.Point(170, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(99, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Purchase ID";
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.buttonX7);
            this.groupPanel4.Controls.Add(this.buttonX6);
            this.groupPanel4.Controls.Add(this.buttonX5);
            this.groupPanel4.Controls.Add(this.buttonX4);
            this.groupPanel4.Controls.Add(this.buttonX3);
            this.groupPanel4.Controls.Add(this.buttonX2);
            this.groupPanel4.Location = new System.Drawing.Point(858, 15);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(140, 329);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.Class = "";
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.Class = "";
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.Class = "";
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 7;
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX7.Location = new System.Drawing.Point(17, 264);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(95, 52);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 7;
            this.buttonX7.Text = "&Report";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Enabled = false;
            this.buttonX6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX6.Location = new System.Drawing.Point(17, 210);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(95, 48);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 4;
            this.buttonX6.Text = "&Get Details";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.Enabled = false;
            this.buttonX5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX5.Location = new System.Drawing.Point(17, 154);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(95, 50);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 3;
            this.buttonX5.Text = "&Update";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Enabled = false;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(17, 102);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(95, 46);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 2;
            this.buttonX4.Text = "&Delete";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(17, 54);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(95, 42);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 22;
            this.buttonX3.Text = "&Save";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(17, 3);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(95, 45);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = "&New";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1095, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1095, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel2, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.49675F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.50325F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(834, 377);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // outlet
            // 
            this.outlet.AutoSize = true;
            this.outlet.Location = new System.Drawing.Point(1052, 406);
            this.outlet.Name = "outlet";
            this.outlet.Size = new System.Drawing.Size(33, 13);
            this.outlet.TabIndex = 242;
            this.outlet.Text = "outlet";
            this.outlet.Visible = false;
            // 
            // frmEquipmentPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(1008, 395);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.outlet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupPanel4);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEquipmentPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipment Purchase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEquipmentPurchase_FormClosing);
            this.Load += new System.EventHandler(this.frmEquipmentPurchase_Load);
            this.Shown += new System.EventHandler(this.frmEquipmentPurchase_Shown);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalcost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costperunit)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        public DevComponents.DotNetBar.Controls.ComboBoxEx units;
        public DevComponents.DotNetBar.Controls.TextBoxX quantity;
        public DevComponents.DotNetBar.Controls.TextBoxX manufacturer;
        public System.Windows.Forms.DateTimePicker purchasedate;
        public DevComponents.DotNetBar.Controls.TextBoxX equipmentname;
        public System.Windows.Forms.RichTextBox description;
        public DevComponents.DotNetBar.Controls.TextBoxX model;
        public System.Windows.Forms.RichTextBox specifications;
        public DevComponents.DotNetBar.Controls.TextBoxX purchaseid;
        public DevComponents.DotNetBar.LabelX labelX3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        public DevComponents.DotNetBar.Controls.TextBoxX invoices;
        private DevComponents.DotNetBar.LabelX labelX25;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label outlet;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        public DevComponents.DotNetBar.Controls.TextBoxX Supplier;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox paymentmode;
        internal System.Windows.Forms.Label label14;
        public DevComponents.Editors.IntegerInput totalcost;
        public DevComponents.Editors.IntegerInput costperunit;
    }
}