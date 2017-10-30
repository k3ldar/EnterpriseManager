namespace POS.Administration.Forms.Emails
{
    partial class AdminSystemEmails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSystemEmails));
            this.lstEmails = new System.Windows.Forms.ListBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.grpKey = new SharedControls.CollapsablePanel();
            this.lblKey = new System.Windows.Forms.Label();
            this.grpEmails = new SharedControls.CollapsablePanel();
            this.cbAllowSend = new System.Windows.Forms.CheckBox();
            this.grpKey.SuspendLayout();
            this.grpEmails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEmails
            // 
            this.lstEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEmails.FormattingEnabled = true;
            this.lstEmails.Location = new System.Drawing.Point(31, 36);
            this.lstEmails.Name = "lstEmails";
            this.lstEmails.Size = new System.Drawing.Size(283, 147);
            this.lstEmails.TabIndex = 0;
            this.lstEmails.SelectedIndexChanged += new System.EventHandler(this.lstEmails_SelectedIndexChanged);
            this.lstEmails.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstEmails_Format);
            this.lstEmails.SizeChanged += new System.EventHandler(this.lstEmails_SizeChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(301, 35);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(304, 51);
            this.txtSubject.MaxLength = 180;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(531, 20);
            this.txtSubject.TabIndex = 4;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(301, 112);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(78, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Email Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(304, 128);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(531, 306);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // grpKey
            // 
            this.grpKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpKey.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.grpKey.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.grpKey.CollapseImage = ((System.Drawing.Image)(resources.GetObject("grpKey.CollapseImage")));
            this.grpKey.Controls.Add(this.lblKey);
            this.grpKey.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.grpKey.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.grpKey.ExpandImage = ((System.Drawing.Image)(resources.GetObject("grpKey.ExpandImage")));
            this.grpKey.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpKey.HeaderForeColor = System.Drawing.Color.Black;
            this.grpKey.HeaderText = "Collapsable Panel";
            this.grpKey.HeaderTextAlign = System.Drawing.StringAlignment.Near;
            this.grpKey.HintControl = null;
            this.grpKey.Location = new System.Drawing.Point(6, 217);
            this.grpKey.Name = "grpKey";
            this.grpKey.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.grpKey.Size = new System.Drawing.Size(289, 217);
            this.grpKey.TabIndex = 2;
            this.grpKey.TabStop = false;
            this.grpKey.BeforeCollapse += new System.ComponentModel.CancelEventHandler(this.grpEmails_BeforeCollapse);
            // 
            // lblKey
            // 
            this.lblKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKey.Location = new System.Drawing.Point(31, 34);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(280, 183);
            this.lblKey.TabIndex = 0;
            this.lblKey.Text = resources.GetString("lblKey.Text");
            this.lblKey.SizeChanged += new System.EventHandler(this.lblKey_SizeChanged);
            // 
            // grpEmails
            // 
            this.grpEmails.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.grpEmails.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.grpEmails.CollapseImage = ((System.Drawing.Image)(resources.GetObject("grpEmails.CollapseImage")));
            this.grpEmails.Controls.Add(this.lstEmails);
            this.grpEmails.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.grpEmails.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.grpEmails.ExpandImage = ((System.Drawing.Image)(resources.GetObject("grpEmails.ExpandImage")));
            this.grpEmails.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEmails.HeaderForeColor = System.Drawing.Color.Black;
            this.grpEmails.HeaderText = "Collapsable Panel";
            this.grpEmails.HeaderTextAlign = System.Drawing.StringAlignment.Near;
            this.grpEmails.HintControl = null;
            this.grpEmails.Location = new System.Drawing.Point(3, 28);
            this.grpEmails.Name = "grpEmails";
            this.grpEmails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.grpEmails.Size = new System.Drawing.Size(292, 195);
            this.grpEmails.TabIndex = 1;
            this.grpEmails.TabStop = false;
            this.grpEmails.BeforeCollapse += new System.ComponentModel.CancelEventHandler(this.grpEmails_BeforeCollapse);
            // 
            // cbAllowSend
            // 
            this.cbAllowSend.AutoSize = true;
            this.cbAllowSend.Location = new System.Drawing.Point(304, 81);
            this.cbAllowSend.Name = "cbAllowSend";
            this.cbAllowSend.Size = new System.Drawing.Size(80, 17);
            this.cbAllowSend.TabIndex = 5;
            this.cbAllowSend.Text = "checkBox1";
            this.cbAllowSend.UseVisualStyleBackColor = true;
            this.cbAllowSend.CheckedChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // AdminSystemEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAllowSend);
            this.Controls.Add(this.grpEmails);
            this.Controls.Add(this.grpKey);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.MinimumSize = new System.Drawing.Size(838, 443);
            this.Name = "AdminSystemEmails";
            this.Size = new System.Drawing.Size(838, 443);
            this.Controls.SetChildIndex(this.lblSubject, 0);
            this.Controls.SetChildIndex(this.txtSubject, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.txtMessage, 0);
            this.Controls.SetChildIndex(this.grpKey, 0);
            this.Controls.SetChildIndex(this.grpEmails, 0);
            this.Controls.SetChildIndex(this.cbAllowSend, 0);
            this.grpKey.ResumeLayout(false);
            this.grpEmails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEmails;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private SharedControls.CollapsablePanel grpKey;
        private System.Windows.Forms.Label lblKey;
        private SharedControls.CollapsablePanel grpEmails;
        private System.Windows.Forms.CheckBox cbAllowSend;
    }
}