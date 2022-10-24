namespace Banking_System
{
    partial class frmConfigureCompanyDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigureCompanyDetails));
            this.bussinessname = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.slogan = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.email = new System.Windows.Forms.TextBox();
            this.contacts = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bussinessname
            // 
            this.bussinessname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bussinessname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bussinessname.Location = new System.Drawing.Point(174, 3);
            this.bussinessname.Name = "bussinessname";
            this.bussinessname.Size = new System.Drawing.Size(211, 29);
            this.bussinessname.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label4.Location = new System.Drawing.Point(14, 6);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(113, 22);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Business Name";
            this.Label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // slogan
            // 
            this.slogan.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slogan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.slogan.Location = new System.Drawing.Point(174, 38);
            this.slogan.Name = "slogan";
            this.slogan.Size = new System.Drawing.Size(211, 29);
            this.slogan.TabIndex = 11;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label1.Location = new System.Drawing.Point(14, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 22);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Slogan";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.buttonX1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonX1.Location = new System.Drawing.Point(266, 178);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(119, 36);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 18;
            this.buttonX1.Text = "&Save";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.email.Location = new System.Drawing.Point(174, 73);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(211, 29);
            this.email.TabIndex = 19;
            // 
            // contacts
            // 
            this.contacts.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contacts.Location = new System.Drawing.Point(174, 108);
            this.contacts.Name = "contacts";
            this.contacts.Size = new System.Drawing.Size(211, 29);
            this.contacts.TabIndex = 20;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.address.Location = new System.Drawing.Point(174, 143);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(211, 29);
            this.address.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Contacts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(14, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.textBoxX1);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(16, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 83);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload Logo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(304, 43);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(78, 29);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "Upload";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click_2);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(11, 43);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(275, 29);
            this.textBoxX1.TabIndex = 0;
            this.textBoxX1.WatermarkText = "Click  to browse Logo Directory...";
            this.textBoxX1.Click += new System.EventHandler(this.textBoxX1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonX3);
            this.groupBox2.Controls.Add(this.textBoxX2);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(16, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 83);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload Manual";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(304, 43);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(78, 29);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 1;
            this.buttonX3.Text = "Upload";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click_1);
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Location = new System.Drawing.Point(11, 43);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(275, 29);
            this.textBoxX2.TabIndex = 0;
            this.textBoxX2.WatermarkText = "Click  to browse Manual Directory...";
            this.textBoxX2.Click += new System.EventHandler(this.textBoxX2_Click);
            // 
            // frmConfigureCompanyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 404);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.address);
            this.Controls.Add(this.contacts);
            this.Controls.Add(this.email);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.bussinessname);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.slogan);
            this.Controls.Add(this.Label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigureCompanyDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox bussinessname;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox slogan;
        internal System.Windows.Forms.Label Label1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        internal System.Windows.Forms.TextBox email;
        internal System.Windows.Forms.TextBox contacts;
        internal System.Windows.Forms.TextBox address;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
    }
}