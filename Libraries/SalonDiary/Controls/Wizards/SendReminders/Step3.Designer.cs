namespace SalonDiary.Controls.Wizards.SendReminders
{
    partial class Step3
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSendMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(35, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "label1";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(7, 98);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(4, 143);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(75, 13);
            this.lblSendMessage.TabIndex = 2;
            this.lblSendMessage.Text = "SendMessage";
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSendMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblHeader);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSendMessage;
    }
}
