namespace POS.HelpDesk.Controls
{
    partial class TicketEntry
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
            this.lblReplier = new System.Windows.Forms.Label();
            this.lblReplyDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblReplier
            // 
            this.lblReplier.AutoSize = true;
            this.lblReplier.Location = new System.Drawing.Point(4, 4);
            this.lblReplier.Name = "lblReplier";
            this.lblReplier.Size = new System.Drawing.Size(35, 13);
            this.lblReplier.TabIndex = 0;
            this.lblReplier.Text = "label1";
            // 
            // lblReplyDate
            // 
            this.lblReplyDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplyDate.AutoSize = true;
            this.lblReplyDate.Location = new System.Drawing.Point(263, 4);
            this.lblReplyDate.Name = "lblReplyDate";
            this.lblReplyDate.Size = new System.Drawing.Size(35, 13);
            this.lblReplyDate.TabIndex = 1;
            this.lblReplyDate.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 2);
            this.panel1.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(7, 29);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(478, 132);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TicketEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblReplyDate);
            this.Controls.Add(this.lblReplier);
            this.Name = "TicketEntry";
            this.Size = new System.Drawing.Size(493, 164);
            this.SizeChanged += new System.EventHandler(this.TicketEntry_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReplier;
        private System.Windows.Forms.Label lblReplyDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMessage;
    }
}
