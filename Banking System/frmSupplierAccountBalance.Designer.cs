namespace Banking_System
{
    partial class frmSupplierAccountBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierAccountBalance));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.accountnumber = new System.Windows.Forms.ComboBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.accountnumbersearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.transactiontype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Accountbalance = new DevComponents.Editors.IntegerInput();
            this.label5 = new System.Windows.Forms.Label();
            this.paymentid = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.reason = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.transactionid = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.billspending = new DevComponents.Editors.IntegerInput();
            this.label2 = new System.Windows.Forms.Label();
            this.accountnames = new System.Windows.Forms.TextBox();
            this.ammount = new DevComponents.Editors.IntegerInput();
            this.amountdue = new DevComponents.Editors.IntegerInput();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.paymentmode = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accountbalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billspending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ammount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountdue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(129, 547);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 43);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 15;
            this.buttonX1.Text = "&Save";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Account Number";
            // 
            // accountnumber
            // 
            this.accountnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.accountnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.accountnumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnumber.FormattingEnabled = true;
            this.accountnumber.Location = new System.Drawing.Point(159, 41);
            this.accountnumber.Name = "accountnumber";
            this.accountnumber.Size = new System.Drawing.Size(216, 30);
            this.accountnumber.TabIndex = 20;
            this.accountnumber.TextChanged += new System.EventHandler(this.accountnumber_TextChanged);
            this.accountnumber.Click += new System.EventHandler(this.accountnumber_Click);
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MMM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(159, 488);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(216, 29);
            this.dtp.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(19, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 22);
            this.label6.TabIndex = 95;
            this.label6.Text = "Date";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(42, 547);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(81, 43);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 97;
            this.buttonX2.Text = "&New";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonX3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(223, 547);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(92, 43);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 98;
            this.buttonX3.Text = "&Delete";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // accountnumbersearch
            // 
            this.accountnumbersearch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnumbersearch.Location = new System.Drawing.Point(528, 6);
            this.accountnumbersearch.Name = "accountnumbersearch";
            this.accountnumbersearch.Size = new System.Drawing.Size(134, 29);
            this.accountnumbersearch.TabIndex = 101;
            this.accountnumbersearch.TextChanged += new System.EventHandler(this.accountnumbersearch_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(383, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 22);
            this.label7.TabIndex = 100;
            this.label7.Text = "Search by Acc. No.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("BackgroundColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.Location = new System.Drawing.Point(387, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(627, 567);
            this.dataGridView1.TabIndex = 99;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX4.Location = new System.Drawing.Point(898, 3);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(107, 43);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 102;
            this.buttonX4.Text = "&Export To Excel";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // transactiontype
            // 
            this.transactiontype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.transactiontype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.transactiontype.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactiontype.FormattingEnabled = true;
            this.transactiontype.Items.AddRange(new object[] {
            "Deposit",
            "By Transaction Clearance",
            "Clear All Bills"});
            this.transactiontype.Location = new System.Drawing.Point(159, 121);
            this.transactiontype.Name = "transactiontype";
            this.transactiontype.Size = new System.Drawing.Size(216, 30);
            this.transactiontype.TabIndex = 104;
            this.transactiontype.SelectedIndexChanged += new System.EventHandler(this.transactiontype_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 22);
            this.label3.TabIndex = 103;
            this.label3.Text = "Transaction Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(12, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 105;
            this.label4.Text = "Transaction Amount";
            // 
            // Accountbalance
            // 
            // 
            // 
            // 
            this.Accountbalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Accountbalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Accountbalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Accountbalance.DisplayFormat = "N0";
            this.Accountbalance.Enabled = false;
            this.Accountbalance.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accountbalance.Location = new System.Drawing.Point(159, 390);
            this.Accountbalance.Name = "Accountbalance";
            this.Accountbalance.Size = new System.Drawing.Size(216, 29);
            this.Accountbalance.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(14, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 22);
            this.label5.TabIndex = 107;
            this.label5.Text = "Account Balance";
            // 
            // paymentid
            // 
            this.paymentid.Enabled = false;
            this.paymentid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentid.Location = new System.Drawing.Point(159, 6);
            this.paymentid.Name = "paymentid";
            this.paymentid.Size = new System.Drawing.Size(216, 29);
            this.paymentid.TabIndex = 110;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Location = new System.Drawing.Point(12, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 22);
            this.label28.TabIndex = 109;
            this.label28.Text = "Payment ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(14, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 22);
            this.label8.TabIndex = 111;
            this.label8.Text = "Details";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(101, 425);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.description.Size = new System.Drawing.Size(274, 57);
            this.description.TabIndex = 112;
            // 
            // reason
            // 
            this.reason.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.reason.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.reason.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reason.FormattingEnabled = true;
            this.reason.Location = new System.Drawing.Point(159, 249);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(216, 30);
            this.reason.TabIndex = 114;
           
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(8, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 22);
            this.label9.TabIndex = 113;
            this.label9.Text = " Reason";
            // 
            // transactionid
            // 
            this.transactionid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.transactionid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.transactionid.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionid.FormattingEnabled = true;
            this.transactionid.Location = new System.Drawing.Point(159, 213);
            this.transactionid.Name = "transactionid";
            this.transactionid.Size = new System.Drawing.Size(216, 30);
            this.transactionid.TabIndex = 116;
            this.transactionid.SelectedIndexChanged += new System.EventHandler(this.transactionid_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(12, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 22);
            this.label10.TabIndex = 115;
            this.label10.Text = "Transaction ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(663, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 22);
            this.label11.TabIndex = 117;
            this.label11.Text = "By Name";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(744, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 29);
            this.textBox1.TabIndex = 118;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 469);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 119;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(12, 359);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 22);
            this.label13.TabIndex = 120;
            this.label13.Text = "Total Bills Pending";
            // 
            // billspending
            // 
            // 
            // 
            // 
            this.billspending.BackgroundStyle.Class = "DateTimeInputBackground";
            this.billspending.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.billspending.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.billspending.DisplayFormat = "N0";
            this.billspending.Enabled = false;
            this.billspending.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billspending.Location = new System.Drawing.Point(159, 352);
            this.billspending.Name = "billspending";
            this.billspending.Size = new System.Drawing.Size(216, 29);
            this.billspending.TabIndex = 121;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 122;
            this.label2.Text = "Account Name";
            // 
            // accountnames
            // 
            this.accountnames.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnames.Location = new System.Drawing.Point(159, 77);
            this.accountnames.Name = "accountnames";
            this.accountnames.Size = new System.Drawing.Size(216, 29);
            this.accountnames.TabIndex = 123;
            this.accountnames.TextChanged += new System.EventHandler(this.accountnames_TextChanged);
            // 
            // ammount
            // 
            // 
            // 
            // 
            this.ammount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ammount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ammount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ammount.DisplayFormat = "N0";
            this.ammount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammount.Location = new System.Drawing.Point(159, 285);
            this.ammount.Name = "ammount";
            this.ammount.Size = new System.Drawing.Size(216, 29);
            this.ammount.TabIndex = 106;
            this.ammount.ValueChanged += new System.EventHandler(this.ammount_ValueChanged);
            this.ammount.TextChanged += new System.EventHandler(this.ammount_TextChanged);
            // 
            // amountdue
            // 
            // 
            // 
            // 
            this.amountdue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.amountdue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.amountdue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.amountdue.DisplayFormat = "N0";
            this.amountdue.Enabled = false;
            this.amountdue.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountdue.Location = new System.Drawing.Point(159, 317);
            this.amountdue.Name = "amountdue";
            this.amountdue.Size = new System.Drawing.Size(216, 29);
            this.amountdue.TabIndex = 247;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(12, 324);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 22);
            this.label14.TabIndex = 246;
            this.label14.Text = "Amount Due";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(20, 450);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 248;
            this.label15.Text = "0";
            this.label15.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(69, 496);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 252;
            this.label17.Text = "label17";
            this.label17.Visible = false;
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
            this.paymentmode.Location = new System.Drawing.Point(159, 166);
            this.paymentmode.Name = "paymentmode";
            this.paymentmode.Size = new System.Drawing.Size(216, 30);
            this.paymentmode.TabIndex = 255;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(12, 169);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 22);
            this.label18.TabIndex = 256;
            this.label18.Text = "Payment Mode";
            // 
            // frmSupplierAccountBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 621);
            this.Controls.Add(this.paymentmode);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.amountdue);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.accountnames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.billspending);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.transactionid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paymentid);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.Accountbalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ammount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.transactiontype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.accountnumbersearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.accountnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplierAccountBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clear Suppliers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecoveryPassword_FormClosing);
            this.Load += new System.EventHandler(this.RecoveryPassword_Load);
            this.Shown += new System.EventHandler(this.frmSupplierAccountBalance_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accountbalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billspending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ammount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountdue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtp;
        internal System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        public System.Windows.Forms.TextBox accountnumbersearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox paymentid;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox accountnumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox accountnames;
        public System.Windows.Forms.ComboBox transactiontype;
        public DevComponents.Editors.IntegerInput Accountbalance;
        public System.Windows.Forms.ComboBox reason;
        public System.Windows.Forms.ComboBox transactionid;
        public DevComponents.Editors.IntegerInput billspending;
        public DevComponents.Editors.IntegerInput ammount;
        public DevComponents.Editors.IntegerInput amountdue;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox paymentmode;
        internal System.Windows.Forms.Label label18;
    }
}