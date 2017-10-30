namespace POS.Suppliers.Controls.Wizards.Supplier
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
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblPrimaryContact = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.lblContactTel = new System.Windows.Forms.Label();
            this.txtContactTel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(4, 4);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(35, 13);
            this.lblWebsite.TabIndex = 0;
            this.lblWebsite.Text = "label1";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(7, 21);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(380, 20);
            this.txtWebsite.TabIndex = 1;
            // 
            // lblPrimaryContact
            // 
            this.lblPrimaryContact.AutoSize = true;
            this.lblPrimaryContact.Location = new System.Drawing.Point(4, 51);
            this.lblPrimaryContact.Name = "lblPrimaryContact";
            this.lblPrimaryContact.Size = new System.Drawing.Size(35, 13);
            this.lblPrimaryContact.TabIndex = 2;
            this.lblPrimaryContact.Text = "label2";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(7, 67);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(380, 20);
            this.txtContactName.TabIndex = 3;
            this.txtContactName.TextChanged += new System.EventHandler(this.txtContactName_TextChanged);
            // 
            // lblContactTel
            // 
            this.lblContactTel.AutoSize = true;
            this.lblContactTel.Location = new System.Drawing.Point(4, 99);
            this.lblContactTel.Name = "lblContactTel";
            this.lblContactTel.Size = new System.Drawing.Size(35, 13);
            this.lblContactTel.TabIndex = 4;
            this.lblContactTel.Text = "label3";
            // 
            // txtContactTel
            // 
            this.txtContactTel.Location = new System.Drawing.Point(7, 115);
            this.txtContactTel.Name = "txtContactTel";
            this.txtContactTel.Size = new System.Drawing.Size(380, 20);
            this.txtContactTel.TabIndex = 5;
            this.txtContactTel.TextChanged += new System.EventHandler(this.txtContactName_TextChanged);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtContactTel);
            this.Controls.Add(this.lblContactTel);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.lblPrimaryContact);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.lblWebsite);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblPrimaryContact;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label lblContactTel;
        private System.Windows.Forms.TextBox txtContactTel;
    }
}
