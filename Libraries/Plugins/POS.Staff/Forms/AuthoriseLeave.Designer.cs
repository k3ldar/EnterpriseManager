namespace POS.Staff.Forms
{
    partial class AuthoriseLeave
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
            this.lblApprovePrompt = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAuthorise = new System.Windows.Forms.Button();
            this.requestsAuthorise = new POS.Staff.Controls.LeaveRequests();
            this.SuspendLayout();
            // 
            // lblApprovePrompt
            // 
            this.lblApprovePrompt.AutoSize = true;
            this.lblApprovePrompt.Location = new System.Drawing.Point(12, 10);
            this.lblApprovePrompt.Name = "lblApprovePrompt";
            this.lblApprovePrompt.Size = new System.Drawing.Size(35, 13);
            this.lblApprovePrompt.TabIndex = 7;
            this.lblApprovePrompt.Text = "label1";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(500, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAuthorise
            // 
            this.btnAuthorise.Location = new System.Drawing.Point(392, 295);
            this.btnAuthorise.Name = "btnAuthorise";
            this.btnAuthorise.Size = new System.Drawing.Size(102, 23);
            this.btnAuthorise.TabIndex = 5;
            this.btnAuthorise.Text = "Approve";
            this.btnAuthorise.UseVisualStyleBackColor = true;
            this.btnAuthorise.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // requestsAuthorise
            // 
            this.requestsAuthorise.AllStaff = false;
            this.requestsAuthorise.HideApproved = false;
            this.requestsAuthorise.HideAuthorised = true;
            this.requestsAuthorise.HideCancelled = true;
            this.requestsAuthorise.HideDenied = true;
            this.requestsAuthorise.HideRequested = true;
            this.requestsAuthorise.HintControl = null;
            this.requestsAuthorise.Location = new System.Drawing.Point(12, 38);
            this.requestsAuthorise.MinimumSize = new System.Drawing.Size(347, 240);
            this.requestsAuthorise.Name = "requestsAuthorise";
            this.requestsAuthorise.ShowCheckBoxes = true;
            this.requestsAuthorise.Size = new System.Drawing.Size(563, 251);
            this.requestsAuthorise.StaffMember = null;
            this.requestsAuthorise.TabIndex = 4;
            // 
            // AuthoriseLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 328);
            this.Controls.Add(this.lblApprovePrompt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAuthorise);
            this.Controls.Add(this.requestsAuthorise);
            this.Name = "AuthoriseLeave";
            this.Text = "AuthoriseLeave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApprovePrompt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAuthorise;
        private Controls.LeaveRequests requestsAuthorise;
    }
}