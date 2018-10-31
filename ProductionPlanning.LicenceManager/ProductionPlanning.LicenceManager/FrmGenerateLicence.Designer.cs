namespace ProductionPlanning.LicenceManager
{
    partial class FrmGenerateLicence
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
            this.label5 = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.nudNumberOfUsers = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLicenceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLicenceNumber = new System.Windows.Forms.TextBox();
            this.lbAvailableModules = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbModules = new System.Windows.Forms.ListBox();
            this.btnModuleAdd = new System.Windows.Forms.Button();
            this.btnModuleRemove = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerateLicence = new System.Windows.Forms.Button();
            this.llClearDate = new System.Windows.Forms.LinkLabel();
            this.llCreateCustomer = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ablaufdatum:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CustomFormat = " ";
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiryDate.Location = new System.Drawing.Point(445, 146);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(119, 20);
            this.dtpExpiryDate.TabIndex = 19;
            this.dtpExpiryDate.ValueChanged += new System.EventHandler(this.dtpExpiryDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Kunde:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(342, 103);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(243, 21);
            this.cmbCustomer.TabIndex = 17;
            this.cmbCustomer.SelectedValueChanged += new System.EventHandler(this.cmbCustomer_SelectedValueChanged);
            // 
            // nudNumberOfUsers
            // 
            this.nudNumberOfUsers.Location = new System.Drawing.Point(342, 146);
            this.nudNumberOfUsers.Name = "nudNumberOfUsers";
            this.nudNumberOfUsers.Size = new System.Drawing.Size(97, 20);
            this.nudNumberOfUsers.TabIndex = 16;
            this.nudNumberOfUsers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfUsers.ValueChanged += new System.EventHandler(this.nudNumberOfUsers_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Anzahl Benutzer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Lizenzname:";
            // 
            // txtLicenceName
            // 
            this.txtLicenceName.Location = new System.Drawing.Point(342, 64);
            this.txtLicenceName.Name = "txtLicenceName";
            this.txtLicenceName.Size = new System.Drawing.Size(276, 20);
            this.txtLicenceName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lizenznummer:";
            // 
            // txtLicenceNumber
            // 
            this.txtLicenceNumber.Enabled = false;
            this.txtLicenceNumber.Location = new System.Drawing.Point(342, 25);
            this.txtLicenceNumber.Name = "txtLicenceNumber";
            this.txtLicenceNumber.Size = new System.Drawing.Size(276, 20);
            this.txtLicenceNumber.TabIndex = 11;
            // 
            // lbAvailableModules
            // 
            this.lbAvailableModules.FormattingEnabled = true;
            this.lbAvailableModules.Location = new System.Drawing.Point(12, 29);
            this.lbAvailableModules.Name = "lbAvailableModules";
            this.lbAvailableModules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAvailableModules.Size = new System.Drawing.Size(120, 251);
            this.lbAvailableModules.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Verfügbare Module:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Module:";
            // 
            // lbModules
            // 
            this.lbModules.FormattingEnabled = true;
            this.lbModules.Location = new System.Drawing.Point(193, 29);
            this.lbModules.Name = "lbModules";
            this.lbModules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbModules.Size = new System.Drawing.Size(120, 251);
            this.lbModules.TabIndex = 23;
            // 
            // btnModuleAdd
            // 
            this.btnModuleAdd.Location = new System.Drawing.Point(138, 117);
            this.btnModuleAdd.Name = "btnModuleAdd";
            this.btnModuleAdd.Size = new System.Drawing.Size(49, 23);
            this.btnModuleAdd.TabIndex = 25;
            this.btnModuleAdd.Text = "->";
            this.btnModuleAdd.UseVisualStyleBackColor = true;
            this.btnModuleAdd.Click += new System.EventHandler(this.btnModuleAdd_Click);
            // 
            // btnModuleRemove
            // 
            this.btnModuleRemove.Location = new System.Drawing.Point(138, 146);
            this.btnModuleRemove.Name = "btnModuleRemove";
            this.btnModuleRemove.Size = new System.Drawing.Size(49, 23);
            this.btnModuleRemove.TabIndex = 26;
            this.btnModuleRemove.Text = "<-";
            this.btnModuleRemove.UseVisualStyleBackColor = true;
            this.btnModuleRemove.Click += new System.EventHandler(this.btnModuleRemove_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(342, 185);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(276, 95);
            this.txtDescription.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Beschreibung:";
            // 
            // btnGenerateLicence
            // 
            this.btnGenerateLicence.Location = new System.Drawing.Point(12, 301);
            this.btnGenerateLicence.Name = "btnGenerateLicence";
            this.btnGenerateLicence.Size = new System.Drawing.Size(606, 23);
            this.btnGenerateLicence.TabIndex = 29;
            this.btnGenerateLicence.Text = "Lizenzschlüssel generieren";
            this.btnGenerateLicence.UseVisualStyleBackColor = true;
            this.btnGenerateLicence.Click += new System.EventHandler(this.btnGenerateLicence_Click);
            // 
            // llClearDate
            // 
            this.llClearDate.AutoSize = true;
            this.llClearDate.Location = new System.Drawing.Point(570, 148);
            this.llClearDate.Name = "llClearDate";
            this.llClearDate.Size = new System.Drawing.Size(48, 13);
            this.llClearDate.TabIndex = 30;
            this.llClearDate.TabStop = true;
            this.llClearDate.Text = "Löschen";
            this.llClearDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llClearDate_LinkClicked);
            // 
            // llCreateCustomer
            // 
            this.llCreateCustomer.AutoSize = true;
            this.llCreateCustomer.Location = new System.Drawing.Point(591, 106);
            this.llCreateCustomer.Name = "llCreateCustomer";
            this.llCreateCustomer.Size = new System.Drawing.Size(27, 13);
            this.llCreateCustomer.TabIndex = 31;
            this.llCreateCustomer.TabStop = true;
            this.llCreateCustomer.Text = "Neu";
            this.llCreateCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreateCustomer_LinkClicked);
            // 
            // FrmGenerateLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 347);
            this.Controls.Add(this.llCreateCustomer);
            this.Controls.Add(this.llClearDate);
            this.Controls.Add(this.btnGenerateLicence);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnModuleRemove);
            this.Controls.Add(this.btnModuleAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbModules);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAvailableModules);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.nudNumberOfUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicenceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLicenceNumber);
            this.Name = "FrmGenerateLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lizenzschlüssel generieren";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.NumericUpDown nudNumberOfUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLicenceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenceNumber;
        private System.Windows.Forms.ListBox lbAvailableModules;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbModules;
        private System.Windows.Forms.Button btnModuleAdd;
        private System.Windows.Forms.Button btnModuleRemove;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGenerateLicence;
        private System.Windows.Forms.LinkLabel llClearDate;
        private System.Windows.Forms.LinkLabel llCreateCustomer;
    }
}