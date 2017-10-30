namespace POS.Administration.Forms.Products
{
    partial class AdminPriceCalculator
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNetCost = new System.Windows.Forms.Label();
            this.lblVATRate = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtNetAmount = new SharedControls.TextBoxEx();
            this.txtVATAmount = new SharedControls.TextBoxEx();
            this.txtCost = new SharedControls.TextBoxEx();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(151, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(70, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNetCost
            // 
            this.lblNetCost.AutoSize = true;
            this.lblNetCost.Location = new System.Drawing.Point(12, 13);
            this.lblNetCost.Name = "lblNetCost";
            this.lblNetCost.Size = new System.Drawing.Size(35, 13);
            this.lblNetCost.TabIndex = 2;
            this.lblNetCost.Text = "label1";
            // 
            // lblVATRate
            // 
            this.lblVATRate.AutoSize = true;
            this.lblVATRate.Location = new System.Drawing.Point(12, 47);
            this.lblVATRate.Name = "lblVATRate";
            this.lblVATRate.Size = new System.Drawing.Size(35, 13);
            this.lblVATRate.TabIndex = 3;
            this.lblVATRate.Text = "label1";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(12, 82);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(35, 13);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "label1";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.AllowBackSpace = true;
            this.txtNetAmount.AllowCopy = true;
            this.txtNetAmount.AllowCut = true;
            this.txtNetAmount.AllowedCharacters = "0123456789.";
            this.txtNetAmount.AllowPaste = true;
            this.txtNetAmount.Location = new System.Drawing.Point(123, 10);
            this.txtNetAmount.MaxLength = 20;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtNetAmount.TabIndex = 5;
            this.txtNetAmount.TextChanged += new System.EventHandler(this.txtNetAmount_TextChanged);
            // 
            // txtVATAmount
            // 
            this.txtVATAmount.AllowBackSpace = true;
            this.txtVATAmount.AllowCopy = true;
            this.txtVATAmount.AllowCut = true;
            this.txtVATAmount.AllowedCharacters = "0123456789.";
            this.txtVATAmount.AllowPaste = true;
            this.txtVATAmount.Location = new System.Drawing.Point(123, 44);
            this.txtVATAmount.MaxLength = 20;
            this.txtVATAmount.Name = "txtVATAmount";
            this.txtVATAmount.Size = new System.Drawing.Size(100, 20);
            this.txtVATAmount.TabIndex = 6;
            this.txtVATAmount.TextChanged += new System.EventHandler(this.txtVATAmount_TextChanged);
            // 
            // txtCost
            // 
            this.txtCost.AllowBackSpace = true;
            this.txtCost.AllowCopy = true;
            this.txtCost.AllowCut = true;
            this.txtCost.AllowedCharacters = "0123456789.";
            this.txtCost.AllowPaste = true;
            this.txtCost.Location = new System.Drawing.Point(123, 79);
            this.txtCost.MaxLength = 20;
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 20);
            this.txtCost.TabIndex = 7;
            this.txtCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            // 
            // FormCostItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 153);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtVATAmount);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblVATRate);
            this.Controls.Add(this.lblNetCost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCostItem";
            this.ShowIcon = false;
            this.Text = "FormCostItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNetCost;
        private System.Windows.Forms.Label lblVATRate;
        private System.Windows.Forms.Label lblCost;
        private SharedControls.TextBoxEx txtNetAmount;
        private SharedControls.TextBoxEx txtVATAmount;
        private SharedControls.TextBoxEx txtCost;
    }
}