namespace POS.Invoices.Controls.Wizards.RecurringPayments
{
    partial class Step1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNextRun = new System.Windows.Forms.Label();
            this.dtpNextRun = new System.Windows.Forms.DateTimePicker();
            this.lblFrequencyType = new System.Windows.Forms.Label();
            this.cmbFrequencyType = new System.Windows.Forms.ComboBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.udFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.udDiscount = new System.Windows.Forms.NumericUpDown();
            this.cbSendEmailInvoice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(7, 4);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(35, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "label1";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(7, 21);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(384, 20);
            this.txtCustomer.TabIndex = 1;
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Location = new System.Drawing.Point(410, 19);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(94, 23);
            this.btnSelectUser.TabIndex = 2;
            this.btnSelectUser.Text = "button1";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 56);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "label1";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(7, 73);
            this.txtDescription.MaxLength = 90;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(384, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // lblNextRun
            // 
            this.lblNextRun.AutoSize = true;
            this.lblNextRun.Location = new System.Drawing.Point(7, 110);
            this.lblNextRun.Name = "lblNextRun";
            this.lblNextRun.Size = new System.Drawing.Size(35, 13);
            this.lblNextRun.TabIndex = 5;
            this.lblNextRun.Text = "label2";
            // 
            // dtpNextRun
            // 
            this.dtpNextRun.Location = new System.Drawing.Point(7, 127);
            this.dtpNextRun.Name = "dtpNextRun";
            this.dtpNextRun.Size = new System.Drawing.Size(200, 20);
            this.dtpNextRun.TabIndex = 6;
            // 
            // lblFrequencyType
            // 
            this.lblFrequencyType.AutoSize = true;
            this.lblFrequencyType.Location = new System.Drawing.Point(7, 164);
            this.lblFrequencyType.Name = "lblFrequencyType";
            this.lblFrequencyType.Size = new System.Drawing.Size(35, 13);
            this.lblFrequencyType.TabIndex = 7;
            this.lblFrequencyType.Text = "label3";
            // 
            // cmbFrequencyType
            // 
            this.cmbFrequencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyType.FormattingEnabled = true;
            this.cmbFrequencyType.Location = new System.Drawing.Point(7, 180);
            this.cmbFrequencyType.Name = "cmbFrequencyType";
            this.cmbFrequencyType.Size = new System.Drawing.Size(177, 21);
            this.cmbFrequencyType.TabIndex = 8;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(76, 215);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(35, 13);
            this.lblFrequency.TabIndex = 9;
            this.lblFrequency.Text = "label4";
            // 
            // udFrequency
            // 
            this.udFrequency.Location = new System.Drawing.Point(79, 232);
            this.udFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFrequency.Name = "udFrequency";
            this.udFrequency.Size = new System.Drawing.Size(105, 20);
            this.udFrequency.TabIndex = 10;
            this.udFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(7, 269);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(35, 13);
            this.lblDiscount.TabIndex = 11;
            this.lblDiscount.Text = "label5";
            // 
            // udDiscount
            // 
            this.udDiscount.DecimalPlaces = 2;
            this.udDiscount.Location = new System.Drawing.Point(7, 286);
            this.udDiscount.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.udDiscount.Name = "udDiscount";
            this.udDiscount.Size = new System.Drawing.Size(74, 20);
            this.udDiscount.TabIndex = 12;
            // 
            // cbSendEmailInvoice
            // 
            this.cbSendEmailInvoice.AutoSize = true;
            this.cbSendEmailInvoice.Location = new System.Drawing.Point(7, 325);
            this.cbSendEmailInvoice.Name = "cbSendEmailInvoice";
            this.cbSendEmailInvoice.Size = new System.Drawing.Size(80, 17);
            this.cbSendEmailInvoice.TabIndex = 13;
            this.cbSendEmailInvoice.Text = "checkBox1";
            this.cbSendEmailInvoice.UseVisualStyleBackColor = true;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSendEmailInvoice);
            this.Controls.Add(this.udDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.udFrequency);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.cmbFrequencyType);
            this.Controls.Add(this.lblFrequencyType);
            this.Controls.Add(this.dtpNextRun);
            this.Controls.Add(this.lblNextRun);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSelectUser);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.udFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNextRun;
        private System.Windows.Forms.DateTimePicker dtpNextRun;
        private System.Windows.Forms.Label lblFrequencyType;
        private System.Windows.Forms.ComboBox cmbFrequencyType;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.NumericUpDown udFrequency;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown udDiscount;
        private System.Windows.Forms.CheckBox cbSendEmailInvoice;
    }
}
