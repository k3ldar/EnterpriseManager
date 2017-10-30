namespace POS.Customers.Forms
{
    partial class AffiliateItemEdit
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
            this.lblAffiliateID = new System.Windows.Forms.Label();
            this.txtAffiliateID = new System.Windows.Forms.TextBox();
            this.lblAffiliateURL = new System.Windows.Forms.Label();
            this.txtAffiliateURL = new System.Windows.Forms.TextBox();
            this.lblPricePerClick = new System.Windows.Forms.Label();
            this.udPricePerClick = new System.Windows.Forms.NumericUpDown();
            this.lblPercentCommission = new System.Windows.Forms.Label();
            this.udPercentage = new System.Windows.Forms.NumericUpDown();
            this.cbActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udPricePerClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(313, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(232, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAffiliateID
            // 
            this.lblAffiliateID.AutoSize = true;
            this.lblAffiliateID.Location = new System.Drawing.Point(12, 13);
            this.lblAffiliateID.Name = "lblAffiliateID";
            this.lblAffiliateID.Size = new System.Drawing.Size(35, 13);
            this.lblAffiliateID.TabIndex = 0;
            this.lblAffiliateID.Text = "label1";
            // 
            // txtAffiliateID
            // 
            this.txtAffiliateID.Location = new System.Drawing.Point(118, 10);
            this.txtAffiliateID.MaxLength = 40;
            this.txtAffiliateID.Name = "txtAffiliateID";
            this.txtAffiliateID.Size = new System.Drawing.Size(266, 20);
            this.txtAffiliateID.TabIndex = 1;
            // 
            // lblAffiliateURL
            // 
            this.lblAffiliateURL.AutoSize = true;
            this.lblAffiliateURL.Location = new System.Drawing.Point(12, 48);
            this.lblAffiliateURL.Name = "lblAffiliateURL";
            this.lblAffiliateURL.Size = new System.Drawing.Size(35, 13);
            this.lblAffiliateURL.TabIndex = 2;
            this.lblAffiliateURL.Text = "label2";
            // 
            // txtAffiliateURL
            // 
            this.txtAffiliateURL.Location = new System.Drawing.Point(118, 45);
            this.txtAffiliateURL.Name = "txtAffiliateURL";
            this.txtAffiliateURL.Size = new System.Drawing.Size(266, 20);
            this.txtAffiliateURL.TabIndex = 3;
            // 
            // lblPricePerClick
            // 
            this.lblPricePerClick.AutoSize = true;
            this.lblPricePerClick.Location = new System.Drawing.Point(12, 83);
            this.lblPricePerClick.Name = "lblPricePerClick";
            this.lblPricePerClick.Size = new System.Drawing.Size(35, 13);
            this.lblPricePerClick.TabIndex = 4;
            this.lblPricePerClick.Text = "label3";
            // 
            // udPricePerClick
            // 
            this.udPricePerClick.DecimalPlaces = 4;
            this.udPricePerClick.Location = new System.Drawing.Point(118, 81);
            this.udPricePerClick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udPricePerClick.Name = "udPricePerClick";
            this.udPricePerClick.Size = new System.Drawing.Size(120, 20);
            this.udPricePerClick.TabIndex = 5;
            // 
            // lblPercentCommission
            // 
            this.lblPercentCommission.AutoSize = true;
            this.lblPercentCommission.Location = new System.Drawing.Point(12, 123);
            this.lblPercentCommission.Name = "lblPercentCommission";
            this.lblPercentCommission.Size = new System.Drawing.Size(35, 13);
            this.lblPercentCommission.TabIndex = 6;
            this.lblPercentCommission.Text = "label4";
            // 
            // udPercentage
            // 
            this.udPercentage.DecimalPlaces = 4;
            this.udPercentage.Location = new System.Drawing.Point(118, 121);
            this.udPercentage.Name = "udPercentage";
            this.udPercentage.Size = new System.Drawing.Size(120, 20);
            this.udPercentage.TabIndex = 7;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(15, 161);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(80, 17);
            this.cbActive.TabIndex = 8;
            this.cbActive.Text = "checkBox1";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // AffiliateItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 235);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.udPercentage);
            this.Controls.Add(this.lblPercentCommission);
            this.Controls.Add(this.udPricePerClick);
            this.Controls.Add(this.lblPricePerClick);
            this.Controls.Add(this.txtAffiliateURL);
            this.Controls.Add(this.lblAffiliateURL);
            this.Controls.Add(this.txtAffiliateID);
            this.Controls.Add(this.lblAffiliateID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AffiliateItemEdit";
            this.Text = "Affiliate Item";
            ((System.ComponentModel.ISupportInitialize)(this.udPricePerClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAffiliateID;
        private System.Windows.Forms.TextBox txtAffiliateID;
        private System.Windows.Forms.Label lblAffiliateURL;
        private System.Windows.Forms.TextBox txtAffiliateURL;
        private System.Windows.Forms.Label lblPricePerClick;
        private System.Windows.Forms.NumericUpDown udPricePerClick;
        private System.Windows.Forms.Label lblPercentCommission;
        private System.Windows.Forms.NumericUpDown udPercentage;
        private System.Windows.Forms.CheckBox cbActive;
    }
}