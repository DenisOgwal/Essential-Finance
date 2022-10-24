
namespace Banking_System
{
    partial class FrmLoanRescheduleFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoanRescheduleFee));
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.noofdays = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.chairperson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chairpersonid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(279, 119);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(103, 46);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "Cancel";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(163, 119);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(110, 46);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "Save";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // noofdays
            // 
            // 
            // 
            // 
            this.noofdays.Border.Class = "TextBoxBorder";
            this.noofdays.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.noofdays.Location = new System.Drawing.Point(139, 13);
            this.noofdays.Name = "noofdays";
            this.noofdays.Size = new System.Drawing.Size(243, 29);
            this.noofdays.TabIndex = 5;
            this.noofdays.WatermarkText = "Loan Reschedule Fee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Reschedule";
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
            this.chairperson.Location = new System.Drawing.Point(139, 84);
            this.chairperson.Name = "chairperson";
            this.chairperson.Size = new System.Drawing.Size(240, 29);
            this.chairperson.TabIndex = 10;
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
            this.chairpersonid.Location = new System.Drawing.Point(139, 48);
            this.chairpersonid.Name = "chairpersonid";
            this.chairpersonid.PasswordChar = '*';
            this.chairpersonid.Size = new System.Drawing.Size(243, 29);
            this.chairpersonid.TabIndex = 9;
            this.chairpersonid.TextChanged += new System.EventHandler(this.chairpersonid_TextChanged);
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
            this.labelX3.Location = new System.Drawing.Point(17, 84);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 23);
            this.labelX3.TabIndex = 8;
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
            this.labelX2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX2.Location = new System.Drawing.Point(17, 42);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(100, 23);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "Approval ID";
            // 
            // FrmLoanRescheduleFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Banking_System.Properties.Settings.Default.usercolor;
            this.ClientSize = new System.Drawing.Size(394, 189);
            this.Controls.Add(this.chairperson);
            this.Controls.Add(this.chairpersonid);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noofdays);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Banking_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmLoanRescheduleFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLoanRescheduleFee";
            this.Load += new System.EventHandler(this.FrmLoanRescheduleFee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX noofdays;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX chairperson;
        private DevComponents.DotNetBar.Controls.TextBoxX chairpersonid;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}