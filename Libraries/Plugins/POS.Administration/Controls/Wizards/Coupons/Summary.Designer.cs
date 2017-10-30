namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Summary
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblSummaryDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(3, 9);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(97, 24);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Summary";
            // 
            // lblSummaryDescription
            // 
            this.lblSummaryDescription.AutoSize = true;
            this.lblSummaryDescription.Location = new System.Drawing.Point(4, 44);
            this.lblSummaryDescription.Name = "lblSummaryDescription";
            this.lblSummaryDescription.Size = new System.Drawing.Size(35, 13);
            this.lblSummaryDescription.TabIndex = 1;
            this.lblSummaryDescription.Text = "label2";
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSummaryDescription);
            this.Controls.Add(this.lblSummary);
            this.Name = "Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblSummaryDescription;
    }
}
