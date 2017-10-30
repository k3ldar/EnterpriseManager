namespace POS.WebsiteAdministration.Forms.Distributors
{
    partial class AdminSalonUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSalonUpdate));
            this.salonUpdateCurrent = new Controls.SalonUpdate();
            this.lblCurrentSalonDetails = new System.Windows.Forms.Label();
            this.lblNewSalonDetails = new System.Windows.Forms.Label();
            this.salonUpdateNew = new Controls.SalonUpdate();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // salonUpdateCurrent
            // 
            this.salonUpdateCurrent.HintControl = null;
            this.salonUpdateCurrent.Location = new System.Drawing.Point(12, 27);
            this.salonUpdateCurrent.Name = "salonUpdateCurrent";
            this.salonUpdateCurrent.Size = new System.Drawing.Size(616, 160);
            this.salonUpdateCurrent.TabIndex = 0;
            // 
            // lblCurrentSalonDetails
            // 
            this.lblCurrentSalonDetails.AutoSize = true;
            this.lblCurrentSalonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSalonDetails.Location = new System.Drawing.Point(13, 8);
            this.lblCurrentSalonDetails.Name = "lblCurrentSalonDetails";
            this.lblCurrentSalonDetails.Size = new System.Drawing.Size(127, 13);
            this.lblCurrentSalonDetails.TabIndex = 1;
            this.lblCurrentSalonDetails.Text = "Current Salon Details";
            // 
            // lblNewSalonDetails
            // 
            this.lblNewSalonDetails.AutoSize = true;
            this.lblNewSalonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewSalonDetails.Location = new System.Drawing.Point(13, 209);
            this.lblNewSalonDetails.Name = "lblNewSalonDetails";
            this.lblNewSalonDetails.Size = new System.Drawing.Size(111, 13);
            this.lblNewSalonDetails.TabIndex = 3;
            this.lblNewSalonDetails.Text = "New Salon Details";
            // 
            // salonUpdateNew
            // 
            this.salonUpdateNew.HintControl = null;
            this.salonUpdateNew.Location = new System.Drawing.Point(12, 237);
            this.salonUpdateNew.Name = "salonUpdateNew";
            this.salonUpdateNew.Size = new System.Drawing.Size(616, 160);
            this.salonUpdateNew.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(542, 416);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(97, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept Changes";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Location = new System.Drawing.Point(439, 416);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(97, 23);
            this.btnReject.TabIndex = 5;
            this.btnReject.Text = "Reject Changes";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // AdminSalonUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 451);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNewSalonDetails);
            this.Controls.Add(this.salonUpdateNew);
            this.Controls.Add(this.lblCurrentSalonDetails);
            this.Controls.Add(this.salonUpdateCurrent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdminSalonUpdate";
            this.SaveState = true;
            this.Text = "AdminSalonUpdates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SalonUpdate salonUpdateCurrent;
        private System.Windows.Forms.Label lblCurrentSalonDetails;
        private System.Windows.Forms.Label lblNewSalonDetails;
        private Controls.SalonUpdate salonUpdateNew;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;

    }
}