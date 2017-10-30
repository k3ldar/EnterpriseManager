namespace POS.Staff.Forms
{
    partial class ApproveLeave
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
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblApprovePrompt = new System.Windows.Forms.Label();
            this.requestsApprove = new POS.Staff.Controls.LeaveRequests();
            this.SuspendLayout();
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(393, 298);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(102, 23);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(501, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblApprovePrompt
            // 
            this.lblApprovePrompt.AutoSize = true;
            this.lblApprovePrompt.Location = new System.Drawing.Point(13, 13);
            this.lblApprovePrompt.Name = "lblApprovePrompt";
            this.lblApprovePrompt.Size = new System.Drawing.Size(35, 13);
            this.lblApprovePrompt.TabIndex = 3;
            this.lblApprovePrompt.Text = "label1";
            // 
            // requestsApprove
            // 
            this.requestsApprove.AllStaff = false;
            this.requestsApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestsApprove.HideApproved = true;
            this.requestsApprove.HideAuthorised = true;
            this.requestsApprove.HideCancelled = true;
            this.requestsApprove.HideDenied = true;
            this.requestsApprove.HideRequested = false;
            this.requestsApprove.HintControl = null;
            this.requestsApprove.Location = new System.Drawing.Point(13, 41);
            this.requestsApprove.MinimumSize = new System.Drawing.Size(347, 240);
            this.requestsApprove.Name = "requestsApprove";
            this.requestsApprove.ShowCheckBoxes = true;
            this.requestsApprove.Size = new System.Drawing.Size(563, 251);
            this.requestsApprove.StaffMember = null;
            this.requestsApprove.TabIndex = 0;
            // 
            // ApproveLeave
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 333);
            this.Controls.Add(this.lblApprovePrompt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.requestsApprove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApproveLeave";
            this.Text = "ApproveLeave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LeaveRequests requestsApprove;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblApprovePrompt;
    }
}