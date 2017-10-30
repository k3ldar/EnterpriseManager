namespace POS.WebsiteAdministration.Forms.MissingLinks
{
    partial class AdminMissingLinkEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMissingLink = new System.Windows.Forms.Label();
            this.lblRedirectLink = new System.Windows.Forms.Label();
            this.txtMissingLink = new System.Windows.Forms.TextBox();
            this.txtRedirectLink = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(438, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblMissingLink
            // 
            this.lblMissingLink.AutoSize = true;
            this.lblMissingLink.Location = new System.Drawing.Point(13, 13);
            this.lblMissingLink.Name = "lblMissingLink";
            this.lblMissingLink.Size = new System.Drawing.Size(65, 13);
            this.lblMissingLink.TabIndex = 2;
            this.lblMissingLink.Text = "Missing Link";
            // 
            // lblRedirectLink
            // 
            this.lblRedirectLink.AutoSize = true;
            this.lblRedirectLink.Location = new System.Drawing.Point(13, 62);
            this.lblRedirectLink.Name = "lblRedirectLink";
            this.lblRedirectLink.Size = new System.Drawing.Size(70, 13);
            this.lblRedirectLink.TabIndex = 3;
            this.lblRedirectLink.Text = "Redirect Link";
            // 
            // txtMissingLink
            // 
            this.txtMissingLink.Location = new System.Drawing.Point(13, 30);
            this.txtMissingLink.Name = "txtMissingLink";
            this.txtMissingLink.Size = new System.Drawing.Size(500, 20);
            this.txtMissingLink.TabIndex = 4;
            // 
            // txtRedirectLink
            // 
            this.txtRedirectLink.Location = new System.Drawing.Point(13, 78);
            this.txtRedirectLink.Name = "txtRedirectLink";
            this.txtRedirectLink.Size = new System.Drawing.Size(500, 20);
            this.txtRedirectLink.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 116);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AdminMissingLinkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 151);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtRedirectLink);
            this.Controls.Add(this.txtMissingLink);
            this.Controls.Add(this.lblRedirectLink);
            this.Controls.Add(this.lblMissingLink);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminMissingLinkEdit";
            this.SaveState = true;
            this.Text = "Administration - Edit Missing Link";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMissingLink;
        private System.Windows.Forms.Label lblRedirectLink;
        private System.Windows.Forms.TextBox txtMissingLink;
        private System.Windows.Forms.TextBox txtRedirectLink;
        private System.Windows.Forms.Button btnDelete;
    }
}