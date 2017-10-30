namespace POS.Diary.Forms
{
    partial class CreditCardDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditCardDetails));
            this.lblCardType = new System.Windows.Forms.Label();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardNumber = new SharedControls.TextBoxEx();
            this.lblValidFrom = new System.Windows.Forms.Label();
            this.cmbFromMonth = new System.Windows.Forms.ComboBox();
            this.cmbFromYear = new System.Windows.Forms.ComboBox();
            this.cmbToYear = new System.Windows.Forms.ComboBox();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.lblValidTo = new System.Windows.Forms.Label();
            this.lblLast3Digits = new System.Windows.Forms.Label();
            this.txtLast3Digits = new SharedControls.TextBoxEx();
            this.cbNoCardDetails = new System.Windows.Forms.CheckBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(12, 100);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(56, 13);
            this.lblCardType.TabIndex = 0;
            this.lblCardType.Text = "Card Type";
            // 
            // cmbCardType
            // 
            this.cmbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Items.AddRange(new object[] {
            "Visa",
            "Visa Debit",
            "Master Card"});
            this.cmbCardType.Location = new System.Drawing.Point(15, 116);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(175, 21);
            this.cmbCardType.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(15, 153);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(69, 13);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.AllowBackSpace = true;
            this.txtCardNumber.AllowCopy = true;
            this.txtCardNumber.AllowCut = true;
            this.txtCardNumber.AllowedCharacters = "0123456789";
            this.txtCardNumber.AllowPaste = true;
            this.txtCardNumber.Location = new System.Drawing.Point(15, 170);
            this.txtCardNumber.MaxLength = 25;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(210, 20);
            this.txtCardNumber.TabIndex = 3;
            // 
            // lblValidFrom
            // 
            this.lblValidFrom.AutoSize = true;
            this.lblValidFrom.Location = new System.Drawing.Point(15, 202);
            this.lblValidFrom.Name = "lblValidFrom";
            this.lblValidFrom.Size = new System.Drawing.Size(56, 13);
            this.lblValidFrom.TabIndex = 6;
            this.lblValidFrom.Text = "Valid From";
            // 
            // cmbFromMonth
            // 
            this.cmbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromMonth.FormattingEnabled = true;
            this.cmbFromMonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbFromMonth.Location = new System.Drawing.Point(15, 219);
            this.cmbFromMonth.Name = "cmbFromMonth";
            this.cmbFromMonth.Size = new System.Drawing.Size(47, 21);
            this.cmbFromMonth.TabIndex = 7;
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromYear.FormattingEnabled = true;
            this.cmbFromYear.Location = new System.Drawing.Point(68, 219);
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Size = new System.Drawing.Size(81, 21);
            this.cmbFromYear.TabIndex = 8;
            // 
            // cmbToYear
            // 
            this.cmbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToYear.FormattingEnabled = true;
            this.cmbToYear.Location = new System.Drawing.Point(235, 219);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(81, 21);
            this.cmbToYear.TabIndex = 11;
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbToMonth.Location = new System.Drawing.Point(182, 219);
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.Size = new System.Drawing.Size(47, 21);
            this.cmbToMonth.TabIndex = 10;
            // 
            // lblValidTo
            // 
            this.lblValidTo.AutoSize = true;
            this.lblValidTo.Location = new System.Drawing.Point(179, 203);
            this.lblValidTo.Name = "lblValidTo";
            this.lblValidTo.Size = new System.Drawing.Size(46, 13);
            this.lblValidTo.TabIndex = 9;
            this.lblValidTo.Text = "Valid To";
            // 
            // lblLast3Digits
            // 
            this.lblLast3Digits.AutoSize = true;
            this.lblLast3Digits.Location = new System.Drawing.Point(228, 153);
            this.lblLast3Digits.Name = "lblLast3Digits";
            this.lblLast3Digits.Size = new System.Drawing.Size(65, 13);
            this.lblLast3Digits.TabIndex = 4;
            this.lblLast3Digits.Text = "Last 3 Digits";
            // 
            // txtLast3Digits
            // 
            this.txtLast3Digits.AllowBackSpace = true;
            this.txtLast3Digits.AllowCopy = true;
            this.txtLast3Digits.AllowCut = true;
            this.txtLast3Digits.AllowedCharacters = "0123456789";
            this.txtLast3Digits.AllowPaste = true;
            this.txtLast3Digits.Location = new System.Drawing.Point(231, 170);
            this.txtLast3Digits.MaxLength = 3;
            this.txtLast3Digits.Name = "txtLast3Digits";
            this.txtLast3Digits.Size = new System.Drawing.Size(85, 20);
            this.txtLast3Digits.TabIndex = 5;
            // 
            // cbNoCardDetails
            // 
            this.cbNoCardDetails.AutoSize = true;
            this.cbNoCardDetails.Location = new System.Drawing.Point(15, 263);
            this.cbNoCardDetails.Name = "cbNoCardDetails";
            this.cbNoCardDetails.Size = new System.Drawing.Size(147, 17);
            this.cbNoCardDetails.TabIndex = 12;
            this.cbNoCardDetails.Text = "Card Details Not Supplied";
            this.cbNoCardDetails.UseVisualStyleBackColor = true;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(15, 283);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(44, 13);
            this.lblReason.TabIndex = 13;
            this.lblReason.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(15, 299);
            this.txtReason.MaxLength = 100;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(301, 66);
            this.txtReason.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(241, 374);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(292, 78);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // CreditCardDetails
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 409);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cbNoCardDetails);
            this.Controls.Add(this.txtLast3Digits);
            this.Controls.Add(this.lblLast3Digits);
            this.Controls.Add(this.cmbToYear);
            this.Controls.Add(this.cmbToMonth);
            this.Controls.Add(this.lblValidTo);
            this.Controls.Add(this.cmbFromYear);
            this.Controls.Add(this.cmbFromMonth);
            this.Controls.Add(this.lblValidFrom);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.lblCardType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditCardDetails";
            this.SaveState = true;
            this.Text = "Credit Card Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Label lblValidFrom;
        private System.Windows.Forms.ComboBox cmbFromMonth;
        private System.Windows.Forms.ComboBox cmbFromYear;
        private System.Windows.Forms.ComboBox cmbToYear;
        private System.Windows.Forms.ComboBox cmbToMonth;
        private System.Windows.Forms.Label lblValidTo;
        private System.Windows.Forms.Label lblLast3Digits;
        private System.Windows.Forms.CheckBox cbNoCardDetails;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private SharedControls.TextBoxEx txtCardNumber;
        private SharedControls.TextBoxEx txtLast3Digits;
        private System.Windows.Forms.Label lblDescription;
    }
}