namespace Banking_System
{
    partial class frmSalaryPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalaryPayment));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Duepayment = new DevComponents.Editors.IntegerInput();
            this.txtTotalPaid = new DevComponents.Editors.IntegerInput();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeduction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaymentModeDetails = new System.Windows.Forms.TextBox();
            this.cmbModeOfPayment = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.payee = new DevComponents.Editors.IntegerInput();
            this.nssf = new DevComponents.Editors.IntegerInput();
            this.txtBasicSalary = new DevComponents.Editors.IntegerInput();
            this.paye = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStaffID = new System.Windows.Forms.ComboBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txtPaymentID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.outlet = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Year = new System.Windows.Forms.DateTimePicker();
            this.months = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duepayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nssf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = global::Banking_System.Properties.Settings.Default.usercolor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("BackgroundColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(529, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(220, 551);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(818, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Duepayment);
            this.groupPanel1.Controls.Add(this.txtTotalPaid);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.txtDeduction);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtPaymentModeDetails);
            this.groupPanel1.Controls.Add(this.cmbModeOfPayment);
            this.groupPanel1.Controls.Add(this.dtpPaymentDate);
            this.groupPanel1.Controls.Add(this.label18);
            this.groupPanel1.Controls.Add(this.label17);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Location = new System.Drawing.Point(3, 300);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(514, 248);
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
            this.groupPanel1.TabIndex = 60;
            this.groupPanel1.Text = "Payment Details";
            // 
            // Duepayment
            // 
            this.Duepayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Duepayment.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Duepayment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Duepayment.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Duepayment.DisplayFormat = "N0";
            this.Duepayment.Enabled = false;
            this.Duepayment.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Duepayment.Location = new System.Drawing.Point(195, 203);
            this.Duepayment.Name = "Duepayment";
            this.Duepayment.Size = new System.Drawing.Size(294, 29);
            this.Duepayment.TabIndex = 204;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPaid.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPaid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPaid.DisplayFormat = "N0";
            this.txtTotalPaid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.Location = new System.Drawing.Point(195, 170);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.Size = new System.Drawing.Size(294, 29);
            this.txtTotalPaid.TabIndex = 203;
            this.txtTotalPaid.ValueChanged += new System.EventHandler(this.txtTotalPaid_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(30, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 22);
            this.label10.TabIndex = 81;
            this.label10.Text = "Due Payment";
            // 
            // txtDeduction
            // 
            this.txtDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeduction.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeduction.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtDeduction.Location = new System.Drawing.Point(195, 139);
            this.txtDeduction.Name = "txtDeduction";
            this.txtDeduction.Size = new System.Drawing.Size(294, 29);
            this.txtDeduction.TabIndex = 202;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(30, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 80;
            this.label3.Text = "Deduction";
            // 
            // txtPaymentModeDetails
            // 
            this.txtPaymentModeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentModeDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentModeDetails.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtPaymentModeDetails.Location = new System.Drawing.Point(195, 73);
            this.txtPaymentModeDetails.Multiline = true;
            this.txtPaymentModeDetails.Name = "txtPaymentModeDetails";
            this.txtPaymentModeDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaymentModeDetails.Size = new System.Drawing.Size(294, 60);
            this.txtPaymentModeDetails.TabIndex = 201;
            // 
            // cmbModeOfPayment
            // 
            this.cmbModeOfPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModeOfPayment.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModeOfPayment.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cmbModeOfPayment.FormattingEnabled = true;
            this.cmbModeOfPayment.Location = new System.Drawing.Point(195, 42);
            this.cmbModeOfPayment.Name = "cmbModeOfPayment";
            this.cmbModeOfPayment.Size = new System.Drawing.Size(294, 30);
            this.cmbModeOfPayment.TabIndex = 200;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPaymentDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPaymentDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(195, 12);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(294, 29);
            this.dtpPaymentDate.TabIndex = 71;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(30, 49);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 22);
            this.label18.TabIndex = 79;
            this.label18.Text = "Mode Of Payment";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(30, 177);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 22);
            this.label17.TabIndex = 78;
            this.label17.Text = "Salary Paid";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(30, 93);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 22);
            this.label16.TabIndex = 77;
            this.label16.Text = "Payment Mode Details";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(30, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 22);
            this.label15.TabIndex = 76;
            this.label15.Text = "Payment Date";
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.payee);
            this.groupPanel2.Controls.Add(this.nssf);
            this.groupPanel2.Controls.Add(this.txtBasicSalary);
            this.groupPanel2.Controls.Add(this.paye);
            this.groupPanel2.Controls.Add(this.label8);
            this.groupPanel2.Controls.Add(this.cmbStaffID);
            this.groupPanel2.Controls.Add(this.txtStaffName);
            this.groupPanel2.Controls.Add(this.Label2);
            this.groupPanel2.Controls.Add(this.Label1);
            this.groupPanel2.Controls.Add(this.label19);
            this.groupPanel2.Location = new System.Drawing.Point(3, 47);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(514, 192);
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
            this.groupPanel2.TabIndex = 61;
            this.groupPanel2.Text = "Staff Details";
            // 
            // payee
            // 
            this.payee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.payee.BackgroundStyle.Class = "DateTimeInputBackground";
            this.payee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.payee.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.payee.DisplayFormat = "N0";
            this.payee.Enabled = false;
            this.payee.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payee.Location = new System.Drawing.Point(132, 148);
            this.payee.Name = "payee";
            this.payee.Size = new System.Drawing.Size(357, 29);
            this.payee.TabIndex = 82;
            // 
            // nssf
            // 
            this.nssf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.nssf.BackgroundStyle.Class = "DateTimeInputBackground";
            this.nssf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nssf.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.nssf.DisplayFormat = "N0";
            this.nssf.Enabled = false;
            this.nssf.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nssf.Location = new System.Drawing.Point(132, 112);
            this.nssf.Name = "nssf";
            this.nssf.Size = new System.Drawing.Size(357, 29);
            this.nssf.TabIndex = 81;
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBasicSalary.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBasicSalary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBasicSalary.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBasicSalary.DisplayFormat = "N0";
            this.txtBasicSalary.Enabled = false;
            this.txtBasicSalary.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicSalary.Location = new System.Drawing.Point(132, 74);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(357, 29);
            this.txtBasicSalary.TabIndex = 80;
            // 
            // paye
            // 
            this.paye.AutoSize = true;
            this.paye.BackColor = System.Drawing.Color.Transparent;
            this.paye.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paye.ForeColor = System.Drawing.SystemColors.ControlText;
            this.paye.Location = new System.Drawing.Point(30, 146);
            this.paye.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.paye.Name = "paye";
            this.paye.Size = new System.Drawing.Size(59, 22);
            this.paye.TabIndex = 79;
            this.paye.Text = "PAYEE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(30, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 22);
            this.label8.TabIndex = 77;
            this.label8.Text = "NSSF";
            // 
            // cmbStaffID
            // 
            this.cmbStaffID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaffID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStaffID.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cmbStaffID.FormattingEnabled = true;
            this.cmbStaffID.Location = new System.Drawing.Point(132, 3);
            this.cmbStaffID.Name = "cmbStaffID";
            this.cmbStaffID.Size = new System.Drawing.Size(357, 30);
            this.cmbStaffID.TabIndex = 70;
            this.cmbStaffID.SelectedIndexChanged += new System.EventHandler(this.cmbStaffID_SelectedIndexChanged);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaffName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtStaffName.Location = new System.Drawing.Point(132, 39);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(357, 29);
            this.txtStaffName.TabIndex = 71;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(30, 39);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 22);
            this.Label2.TabIndex = 74;
            this.Label2.Text = "Staff Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(30, 9);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 22);
            this.Label1.TabIndex = 73;
            this.Label1.Text = "Staff ID";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(30, 76);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 22);
            this.label19.TabIndex = 75;
            this.label19.Text = "Basic Salary";
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.buttonX1);
            this.groupPanel3.Controls.Add(this.txtPaymentID);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Location = new System.Drawing.Point(3, 3);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(514, 38);
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
            this.groupPanel3.TabIndex = 62;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.Enabled = false;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(447, 0);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(42, 30);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 102;
            this.buttonX1.Text = ">";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPaymentID.Location = new System.Drawing.Point(132, 1);
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(281, 29);
            this.txtPaymentID.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(31, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 99;
            this.label5.Text = "Payment ID";
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.label14);
            this.groupPanel4.Controls.Add(this.label13);
            this.groupPanel4.Controls.Add(this.outlet);
            this.groupPanel4.Controls.Add(this.label11);
            this.groupPanel4.Controls.Add(this.labelX1);
            this.groupPanel4.Controls.Add(this.label7);
            this.groupPanel4.Controls.Add(this.label12);
            this.groupPanel4.Location = new System.Drawing.Point(12, 4);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(904, 44);
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
            this.groupPanel4.TabIndex = 63;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(779, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 243;
            this.label14.Text = "label14";
            this.label14.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // outlet
            // 
            this.outlet.AutoSize = true;
            this.outlet.Location = new System.Drawing.Point(664, -24);
            this.outlet.Name = "outlet";
            this.outlet.Size = new System.Drawing.Size(33, 13);
            this.outlet.TabIndex = 242;
            this.outlet.Text = "outlet";
            this.outlet.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(705, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(892, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "SALARY PAYMENT";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(638, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(678, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // groupPanel5
            // 
            this.groupPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.buttonX6);
            this.groupPanel5.Controls.Add(this.buttonX5);
            this.groupPanel5.Controls.Add(this.buttonX4);
            this.groupPanel5.Controls.Add(this.buttonX3);
            this.groupPanel5.Controls.Add(this.buttonX2);
            this.groupPanel5.Location = new System.Drawing.Point(770, 57);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(146, 554);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.Class = "";
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.Class = "";
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.Class = "";
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 64;
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX6.Location = new System.Drawing.Point(3, 433);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(134, 95);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 4;
            this.buttonX6.Text = "&Slip";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.Enabled = false;
            this.buttonX5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX5.Location = new System.Drawing.Point(3, 317);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(134, 91);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 3;
            this.buttonX5.Text = "&Update";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Enabled = false;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Location = new System.Drawing.Point(3, 205);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(134, 90);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 2;
            this.buttonX4.Text = "&Delete";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(3, 105);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(134, 86);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 1;
            this.buttonX3.Text = "&Save";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(3, 7);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(134, 78);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = "&New";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // groupPanel6
            // 
            this.groupPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.Year);
            this.groupPanel6.Controls.Add(this.months);
            this.groupPanel6.Controls.Add(this.label9);
            this.groupPanel6.Controls.Add(this.label4);
            this.groupPanel6.Location = new System.Drawing.Point(3, 245);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(514, 49);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.Class = "";
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.Class = "";
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.Class = "";
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 66;
            this.groupPanel6.Text = "Payment Period";
            // 
            // Year
            // 
            this.Year.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Year.CustomFormat = "yyyy";
            this.Year.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Year.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Year.Location = new System.Drawing.Point(381, 0);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(108, 29);
            this.Year.TabIndex = 7;
            // 
            // months
            // 
            this.months.CustomFormat = "MMM";
            this.months.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.months.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.months.Location = new System.Drawing.Point(132, 0);
            this.months.Name = "months";
            this.months.Size = new System.Drawing.Size(126, 29);
            this.months.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(324, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(31, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Months";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 557);
            this.tableLayoutPanel1.TabIndex = 68;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel1, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(520, 551);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.labelX5);
            this.ribbonClientPanel1.Controls.Add(this.label25);
            this.ribbonClientPanel1.Controls.Add(this.label28);
            this.ribbonClientPanel1.Location = new System.Drawing.Point(-8, 620);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(946, 51);
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
            this.ribbonClientPanel1.TabIndex = 69;
            this.ribbonClientPanel1.Text = "ribbonClientPanel1";
            // 
            // labelX5
            // 
            this.labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelX5.Location = new System.Drawing.Point(3, 9);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(940, 23);
            this.labelX5.TabIndex = 64;
            this.labelX5.Text = "Copyright ©  2016-2020 Dither Technologies";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(802, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 4;
            this.label25.Text = "label25";
            this.label25.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(762, 15);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "label28";
            this.label28.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.DataBindings.Add(new System.Windows.Forms.Binding("WindowState", global::Banking_System.Properties.Settings.Default, "Maximised", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printPreviewDialog1.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::Banking_System.Properties.Settings.Default, "no", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmSalaryPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(928, 673);
            this.Controls.Add(this.ribbonClientPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupPanel5);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.label6);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalaryPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Payment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalaryPayment_FormClosing);
            this.Load += new System.EventHandler(this.frmSalaryPayment_Load);
            this.Shown += new System.EventHandler(this.frmSalaryPayment_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duepayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nssf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public System.Windows.Forms.TextBox txtDeduction;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPaymentModeDetails;
        public System.Windows.Forms.ComboBox cmbModeOfPayment;
        public System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        public System.Windows.Forms.ComboBox cmbStaffID;
        public System.Windows.Forms.TextBox txtStaffName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label19;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.TextBox txtPaymentID;
        internal System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        public System.Windows.Forms.DateTimePicker Year;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.LabelX labelX5;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label28;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.Label outlet;
        private System.Windows.Forms.Label paye;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.DateTimePicker months;
        public DevComponents.Editors.IntegerInput Duepayment;
        public DevComponents.Editors.IntegerInput txtTotalPaid;
        public DevComponents.Editors.IntegerInput payee;
        public DevComponents.Editors.IntegerInput nssf;
        public DevComponents.Editors.IntegerInput txtBasicSalary;
    }
}