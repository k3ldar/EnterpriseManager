namespace SalonDiary.Controls.Wizards.WaitingListWizard
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
            this.lblSelectTreatments = new System.Windows.Forms.Label();
            this.clbTreatments = new System.Windows.Forms.CheckedListBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSelectTreatments
            // 
            this.lblSelectTreatments.AutoSize = true;
            this.lblSelectTreatments.Location = new System.Drawing.Point(3, 48);
            this.lblSelectTreatments.Name = "lblSelectTreatments";
            this.lblSelectTreatments.Size = new System.Drawing.Size(132, 13);
            this.lblSelectTreatments.TabIndex = 3;
            this.lblSelectTreatments.Text = "Select Desired Treatments";
            // 
            // clbTreatments
            // 
            this.clbTreatments.CheckOnClick = true;
            this.clbTreatments.FormattingEnabled = true;
            this.clbTreatments.Location = new System.Drawing.Point(6, 64);
            this.clbTreatments.MultiColumn = true;
            this.clbTreatments.Name = "clbTreatments";
            this.clbTreatments.Size = new System.Drawing.Size(557, 289);
            this.clbTreatments.TabIndex = 4;
            this.clbTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbTreatments_Format);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(9, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(450, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(465, 19);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(98, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.clbTreatments);
            this.Controls.Add(this.lblSelectTreatments);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectTreatments;
        private System.Windows.Forms.CheckedListBox clbTreatments;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSelect;
    }
}
