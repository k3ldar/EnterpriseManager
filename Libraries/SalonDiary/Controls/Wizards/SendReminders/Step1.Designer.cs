namespace SalonDiary.Controls.Wizards.SendReminders
{
    partial class Step1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Step1));
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnSpellCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(152, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Format the message to be sent";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(7, 33);
            this.txtMessage.MaxLength = 280;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(329, 117);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "Hi {NAME}, this is a friendly reminder that you have an appointment at our salon " +
    "in Shifnal, {DAY} at {TIME} with {THERAPIST}.\r\n\r\nPlease call 01952 461888 if you" +
    " need to reschedule.";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(7, 182);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(175, 117);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(7, 157);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(85, 13);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "x of x characters";
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Location = new System.Drawing.Point(343, 33);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(75, 23);
            this.btnSpellCheck.TabIndex = 4;
            this.btnSpellCheck.Text = "Spell Check";
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Visible = false;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSpellCheck);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblHeader);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnSpellCheck;
    }
}
