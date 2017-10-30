namespace POS.Staff.Controls.Wizards.Commission.PoolPayCommission
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
            this.rbSplitJoinDate = new System.Windows.Forms.RadioButton();
            this.rbSplitPermanentDate = new System.Windows.Forms.RadioButton();
            this.rbSplitJointly = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbSplitJoinDate
            // 
            this.rbSplitJoinDate.AutoSize = true;
            this.rbSplitJoinDate.Location = new System.Drawing.Point(4, 28);
            this.rbSplitJoinDate.Name = "rbSplitJoinDate";
            this.rbSplitJoinDate.Size = new System.Drawing.Size(85, 17);
            this.rbSplitJoinDate.TabIndex = 1;
            this.rbSplitJoinDate.Text = "radioButton1";
            this.rbSplitJoinDate.UseVisualStyleBackColor = true;
            // 
            // rbSplitPermanentDate
            // 
            this.rbSplitPermanentDate.AutoSize = true;
            this.rbSplitPermanentDate.Checked = true;
            this.rbSplitPermanentDate.Location = new System.Drawing.Point(4, 51);
            this.rbSplitPermanentDate.Name = "rbSplitPermanentDate";
            this.rbSplitPermanentDate.Size = new System.Drawing.Size(85, 17);
            this.rbSplitPermanentDate.TabIndex = 2;
            this.rbSplitPermanentDate.TabStop = true;
            this.rbSplitPermanentDate.Text = "radioButton2";
            this.rbSplitPermanentDate.UseVisualStyleBackColor = true;
            // 
            // rbSplitJointly
            // 
            this.rbSplitJointly.AutoSize = true;
            this.rbSplitJointly.Location = new System.Drawing.Point(4, 5);
            this.rbSplitJointly.Name = "rbSplitJointly";
            this.rbSplitJointly.Size = new System.Drawing.Size(85, 17);
            this.rbSplitJointly.TabIndex = 0;
            this.rbSplitJointly.Text = "radioButton1";
            this.rbSplitJointly.UseVisualStyleBackColor = true;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbSplitJointly);
            this.Controls.Add(this.rbSplitPermanentDate);
            this.Controls.Add(this.rbSplitJoinDate);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSplitJoinDate;
        private System.Windows.Forms.RadioButton rbSplitPermanentDate;
        private System.Windows.Forms.RadioButton rbSplitJointly;

    }
}
