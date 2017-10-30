namespace POS.Till.Forms
{
    partial class MarkAsPaidForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkAsPaidForm));
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.lblAdditionalInformation = new System.Windows.Forms.Label();
            this.txtAdditionalInformation = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cashTill1 = new Controls.CashTill();
            this.splitPayment1 = new Controls.SplitPaymentControl();
            this.SuspendLayout();
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(13, 33);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(284, 21);
            this.cmbPaymentType.TabIndex = 0;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
            this.cmbPaymentType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPaymentType_Format);
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Location = new System.Drawing.Point(13, 14);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(75, 13);
            this.lblPaymentType.TabIndex = 1;
            this.lblPaymentType.Text = "Payment Type";
            // 
            // lblAdditionalInformation
            // 
            this.lblAdditionalInformation.AutoSize = true;
            this.lblAdditionalInformation.Location = new System.Drawing.Point(13, 70);
            this.lblAdditionalInformation.Name = "lblAdditionalInformation";
            this.lblAdditionalInformation.Size = new System.Drawing.Size(108, 13);
            this.lblAdditionalInformation.TabIndex = 2;
            this.lblAdditionalInformation.Text = "Additional Information";
            // 
            // txtAdditionalInformation
            // 
            this.txtAdditionalInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalInformation.Location = new System.Drawing.Point(14, 86);
            this.txtAdditionalInformation.MaxLength = 125;
            this.txtAdditionalInformation.Multiline = true;
            this.txtAdditionalInformation.Name = "txtAdditionalInformation";
            this.txtAdditionalInformation.Size = new System.Drawing.Size(280, 263);
            this.txtAdditionalInformation.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(222, 355);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(141, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cashTill1
            // 
            this.cashTill1.HintControl = null;
            this.cashTill1.Location = new System.Drawing.Point(13, 70);
            this.cashTill1.Name = "cashTill1";
            this.cashTill1.Size = new System.Drawing.Size(285, 261);
            this.cashTill1.TabIndex = 6;
            // 
            // splitPayment1
            // 
            this.splitPayment1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPayment1.HintControl = null;
            this.splitPayment1.Location = new System.Drawing.Point(14, 70);
            this.splitPayment1.Name = "splitPayment1";
            this.splitPayment1.Size = new System.Drawing.Size(284, 280);
            this.splitPayment1.TabIndex = 7;
            // 
            // MarkAsPaidForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 390);
            this.Controls.Add(this.splitPayment1);
            this.Controls.Add(this.cashTill1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAdditionalInformation);
            this.Controls.Add(this.lblAdditionalInformation);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.cmbPaymentType);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 428);
            this.Name = "MarkAsPaidForm";
            this.SaveState = true;
            this.Text = "Payment Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.Label lblAdditionalInformation;
        private System.Windows.Forms.TextBox txtAdditionalInformation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Controls.CashTill cashTill1;
        private Controls.SplitPaymentControl splitPayment1;
    }
}