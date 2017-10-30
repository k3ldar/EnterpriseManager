namespace POS.HelpDesk.Forms
{
    partial class Ticket
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
            this.lblDescKey = new System.Windows.Forms.Label();
            this.lblDescDepartment = new System.Windows.Forms.Label();
            this.lblDescSubject = new System.Windows.Forms.Label();
            this.lblDescPriority = new System.Windows.Forms.Label();
            this.lblDescLastUpdated = new System.Windows.Forms.Label();
            this.lblDescLastReplier = new System.Windows.Forms.Label();
            this.lblDescCreatedBy = new System.Windows.Forms.Label();
            this.lblDescStatus = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLastReplier = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.pnlMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnfindUser = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnSpellCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescKey
            // 
            this.lblDescKey.AutoSize = true;
            this.lblDescKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescKey.Location = new System.Drawing.Point(13, 13);
            this.lblDescKey.Name = "lblDescKey";
            this.lblDescKey.Size = new System.Drawing.Size(32, 13);
            this.lblDescKey.TabIndex = 0;
            this.lblDescKey.Text = "Key:";
            // 
            // lblDescDepartment
            // 
            this.lblDescDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescDepartment.AutoSize = true;
            this.lblDescDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescDepartment.Location = new System.Drawing.Point(301, 13);
            this.lblDescDepartment.Name = "lblDescDepartment";
            this.lblDescDepartment.Size = new System.Drawing.Size(76, 13);
            this.lblDescDepartment.TabIndex = 10;
            this.lblDescDepartment.Text = "Department:";
            // 
            // lblDescSubject
            // 
            this.lblDescSubject.AutoSize = true;
            this.lblDescSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescSubject.Location = new System.Drawing.Point(12, 33);
            this.lblDescSubject.Name = "lblDescSubject";
            this.lblDescSubject.Size = new System.Drawing.Size(54, 13);
            this.lblDescSubject.TabIndex = 2;
            this.lblDescSubject.Text = "Subject:";
            // 
            // lblDescPriority
            // 
            this.lblDescPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescPriority.AutoSize = true;
            this.lblDescPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescPriority.Location = new System.Drawing.Point(301, 41);
            this.lblDescPriority.Name = "lblDescPriority";
            this.lblDescPriority.Size = new System.Drawing.Size(46, 13);
            this.lblDescPriority.TabIndex = 12;
            this.lblDescPriority.Text = "Priority";
            // 
            // lblDescLastUpdated
            // 
            this.lblDescLastUpdated.AutoSize = true;
            this.lblDescLastUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescLastUpdated.Location = new System.Drawing.Point(13, 97);
            this.lblDescLastUpdated.Name = "lblDescLastUpdated";
            this.lblDescLastUpdated.Size = new System.Drawing.Size(87, 13);
            this.lblDescLastUpdated.TabIndex = 8;
            this.lblDescLastUpdated.Text = "Last Updated:";
            // 
            // lblDescLastReplier
            // 
            this.lblDescLastReplier.AutoSize = true;
            this.lblDescLastReplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescLastReplier.Location = new System.Drawing.Point(12, 75);
            this.lblDescLastReplier.Name = "lblDescLastReplier";
            this.lblDescLastReplier.Size = new System.Drawing.Size(79, 13);
            this.lblDescLastReplier.TabIndex = 6;
            this.lblDescLastReplier.Text = "Last Replier:";
            // 
            // lblDescCreatedBy
            // 
            this.lblDescCreatedBy.AutoSize = true;
            this.lblDescCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCreatedBy.Location = new System.Drawing.Point(12, 53);
            this.lblDescCreatedBy.Name = "lblDescCreatedBy";
            this.lblDescCreatedBy.Size = new System.Drawing.Size(73, 13);
            this.lblDescCreatedBy.TabIndex = 4;
            this.lblDescCreatedBy.Text = "Created By:";
            // 
            // lblDescStatus
            // 
            this.lblDescStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescStatus.AutoSize = true;
            this.lblDescStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescStatus.Location = new System.Drawing.Point(301, 69);
            this.lblDescStatus.Name = "lblDescStatus";
            this.lblDescStatus.Size = new System.Drawing.Size(47, 13);
            this.lblDescStatus.TabIndex = 14;
            this.lblDescStatus.Text = "Status:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(112, 13);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(35, 13);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "label9";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(112, 33);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(41, 13);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "label10";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(112, 53);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(41, 13);
            this.lblCreatedBy.TabIndex = 5;
            this.lblCreatedBy.Text = "label11";
            // 
            // lblLastReplier
            // 
            this.lblLastReplier.AutoSize = true;
            this.lblLastReplier.Location = new System.Drawing.Point(112, 75);
            this.lblLastReplier.Name = "lblLastReplier";
            this.lblLastReplier.Size = new System.Drawing.Size(41, 13);
            this.lblLastReplier.TabIndex = 7;
            this.lblLastReplier.Text = "label12";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(112, 97);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(41, 13);
            this.lblLastUpdated.TabIndex = 9;
            this.lblLastUpdated.Text = "label13";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(402, 10);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartment.TabIndex = 11;
            this.cmbDepartment.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDepartment_Format);
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Enabled = false;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(402, 38);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbPriority.TabIndex = 13;
            this.cmbPriority.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPriority_Format);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(402, 66);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 15;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStatus_Format);
            // 
            // pnlMessages
            // 
            this.pnlMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMessages.AutoScroll = true;
            this.pnlMessages.Location = new System.Drawing.Point(12, 113);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(511, 146);
            this.pnlMessages.TabIndex = 16;
            this.pnlMessages.SizeChanged += new System.EventHandler(this.pnlMessages_SizeChanged);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 262);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(63, 13);
            this.lblCurrentUser.TabIndex = 17;
            this.lblCurrentUser.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(12, 277);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(511, 20);
            this.txtUserName.TabIndex = 18;
            // 
            // txtReply
            // 
            this.txtReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReply.Location = new System.Drawing.Point(12, 320);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(511, 84);
            this.txtReply.TabIndex = 20;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 304);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 13);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Reply";
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.Location = new System.Drawing.Point(366, 410);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(75, 23);
            this.btnReply.TabIndex = 24;
            this.btnReply.Text = "&Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(448, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnfindUser
            // 
            this.btnfindUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnfindUser.Location = new System.Drawing.Point(12, 410);
            this.btnfindUser.Name = "btnfindUser";
            this.btnfindUser.Size = new System.Drawing.Size(75, 23);
            this.btnfindUser.TabIndex = 21;
            this.btnfindUser.Text = "Find User";
            this.btnfindUser.UseVisualStyleBackColor = true;
            this.btnfindUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.Location = new System.Drawing.Point(275, 410);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(85, 23);
            this.btnPrintPreview.TabIndex = 23;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpellCheck.Location = new System.Drawing.Point(194, 410);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(75, 23);
            this.btnSpellCheck.TabIndex = 22;
            this.btnSpellCheck.Text = "spell check";
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 439);
            this.Controls.Add(this.btnSpellCheck);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnfindUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblLastReplier);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblDescLastUpdated);
            this.Controls.Add(this.lblDescLastReplier);
            this.Controls.Add(this.lblDescCreatedBy);
            this.Controls.Add(this.lblDescStatus);
            this.Controls.Add(this.lblDescPriority);
            this.Controls.Add(this.lblDescSubject);
            this.Controls.Add(this.lblDescDepartment);
            this.Controls.Add(this.lblDescKey);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 477);
            this.Name = "Ticket";
            this.SaveState = true;
            this.Text = "Support Ticket";
            this.SizeChanged += new System.EventHandler(this.Ticket_SizeChanged);
            this.Enter += new System.EventHandler(this.Ticket_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescKey;
        private System.Windows.Forms.Label lblDescDepartment;
        private System.Windows.Forms.Label lblDescSubject;
        private System.Windows.Forms.Label lblDescPriority;
        private System.Windows.Forms.Label lblDescLastUpdated;
        private System.Windows.Forms.Label lblDescLastReplier;
        private System.Windows.Forms.Label lblDescCreatedBy;
        private System.Windows.Forms.Label lblDescStatus;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblLastReplier;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.FlowLayoutPanel pnlMessages;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnfindUser;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnSpellCheck;
    }
}