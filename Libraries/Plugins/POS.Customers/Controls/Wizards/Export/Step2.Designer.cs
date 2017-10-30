namespace POS.Customers.Controls.Wizards.Export
{
    partial class Step2
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
            this.cbValidEmail = new System.Windows.Forms.CheckBox();
            this.cbReceiveEmail = new System.Windows.Forms.CheckBox();
            this.cbReceivePostal = new System.Windows.Forms.CheckBox();
            this.cbReceiveTelephone = new System.Windows.Forms.CheckBox();
            this.cbExcludeInvalidPostal = new System.Windows.Forms.CheckBox();
            this.rbIgnoreBusinessName = new System.Windows.Forms.RadioButton();
            this.rbHasBusinessName = new System.Windows.Forms.RadioButton();
            this.rbNoBusinessName = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cbValidEmail
            // 
            this.cbValidEmail.AutoSize = true;
            this.cbValidEmail.Location = new System.Drawing.Point(4, 91);
            this.cbValidEmail.Name = "cbValidEmail";
            this.cbValidEmail.Size = new System.Drawing.Size(244, 17);
            this.cbValidEmail.TabIndex = 3;
            this.cbValidEmail.Text = "Include only records with a valid email address";
            this.cbValidEmail.UseVisualStyleBackColor = true;
            // 
            // cbReceiveEmail
            // 
            this.cbReceiveEmail.AutoSize = true;
            this.cbReceiveEmail.Location = new System.Drawing.Point(4, 3);
            this.cbReceiveEmail.Name = "cbReceiveEmail";
            this.cbReceiveEmail.Size = new System.Drawing.Size(215, 17);
            this.cbReceiveEmail.TabIndex = 0;
            this.cbReceiveEmail.Text = "Include all records that want email offers";
            this.cbReceiveEmail.UseVisualStyleBackColor = true;
            // 
            // cbReceivePostal
            // 
            this.cbReceivePostal.AutoSize = true;
            this.cbReceivePostal.Location = new System.Drawing.Point(4, 27);
            this.cbReceivePostal.Name = "cbReceivePostal";
            this.cbReceivePostal.Size = new System.Drawing.Size(219, 17);
            this.cbReceivePostal.TabIndex = 1;
            this.cbReceivePostal.Text = "Include all records that want postal offers";
            this.cbReceivePostal.UseVisualStyleBackColor = true;
            // 
            // cbReceiveTelephone
            // 
            this.cbReceiveTelephone.AutoSize = true;
            this.cbReceiveTelephone.Location = new System.Drawing.Point(4, 51);
            this.cbReceiveTelephone.Name = "cbReceiveTelephone";
            this.cbReceiveTelephone.Size = new System.Drawing.Size(241, 17);
            this.cbReceiveTelephone.TabIndex = 2;
            this.cbReceiveTelephone.Text = "Include all records  that want telephone offers";
            this.cbReceiveTelephone.UseVisualStyleBackColor = true;
            // 
            // cbExcludeInvalidPostal
            // 
            this.cbExcludeInvalidPostal.AutoSize = true;
            this.cbExcludeInvalidPostal.Location = new System.Drawing.Point(4, 114);
            this.cbExcludeInvalidPostal.Name = "cbExcludeInvalidPostal";
            this.cbExcludeInvalidPostal.Size = new System.Drawing.Size(228, 17);
            this.cbExcludeInvalidPostal.TabIndex = 4;
            this.cbExcludeInvalidPostal.Text = "Exclude records with invalid postal address";
            this.cbExcludeInvalidPostal.UseVisualStyleBackColor = true;
            // 
            // rbIgnoreBusinessName
            // 
            this.rbIgnoreBusinessName.AutoSize = true;
            this.rbIgnoreBusinessName.Checked = true;
            this.rbIgnoreBusinessName.Location = new System.Drawing.Point(4, 152);
            this.rbIgnoreBusinessName.Name = "rbIgnoreBusinessName";
            this.rbIgnoreBusinessName.Size = new System.Drawing.Size(131, 17);
            this.rbIgnoreBusinessName.TabIndex = 5;
            this.rbIgnoreBusinessName.TabStop = true;
            this.rbIgnoreBusinessName.Text = "Ignore Business Name";
            this.rbIgnoreBusinessName.UseVisualStyleBackColor = true;
            // 
            // rbHasBusinessName
            // 
            this.rbHasBusinessName.AutoSize = true;
            this.rbHasBusinessName.Location = new System.Drawing.Point(4, 176);
            this.rbHasBusinessName.Name = "rbHasBusinessName";
            this.rbHasBusinessName.Size = new System.Drawing.Size(159, 17);
            this.rbHasBusinessName.TabIndex = 6;
            this.rbHasBusinessName.Text = "Must Have a business name";
            this.rbHasBusinessName.UseVisualStyleBackColor = true;
            // 
            // rbNoBusinessName
            // 
            this.rbNoBusinessName.AutoSize = true;
            this.rbNoBusinessName.Location = new System.Drawing.Point(4, 200);
            this.rbNoBusinessName.Name = "rbNoBusinessName";
            this.rbNoBusinessName.Size = new System.Drawing.Size(167, 17);
            this.rbNoBusinessName.TabIndex = 7;
            this.rbNoBusinessName.Text = "Business Name must be blank";
            this.rbNoBusinessName.UseVisualStyleBackColor = true;
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbNoBusinessName);
            this.Controls.Add(this.rbHasBusinessName);
            this.Controls.Add(this.rbIgnoreBusinessName);
            this.Controls.Add(this.cbExcludeInvalidPostal);
            this.Controls.Add(this.cbReceiveTelephone);
            this.Controls.Add(this.cbReceivePostal);
            this.Controls.Add(this.cbReceiveEmail);
            this.Controls.Add(this.cbValidEmail);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbValidEmail;
        private System.Windows.Forms.CheckBox cbReceiveEmail;
        private System.Windows.Forms.CheckBox cbReceivePostal;
        private System.Windows.Forms.CheckBox cbReceiveTelephone;
        private System.Windows.Forms.CheckBox cbExcludeInvalidPostal;
        private System.Windows.Forms.RadioButton rbIgnoreBusinessName;
        private System.Windows.Forms.RadioButton rbHasBusinessName;
        private System.Windows.Forms.RadioButton rbNoBusinessName;
    }
}
