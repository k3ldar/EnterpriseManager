namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
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
            this.lblSelectTreatments = new System.Windows.Forms.Label();
            this.lstTreatments = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblSelectTreatments
            // 
            this.lblSelectTreatments.AutoSize = true;
            this.lblSelectTreatments.Location = new System.Drawing.Point(3, 0);
            this.lblSelectTreatments.Name = "lblSelectTreatments";
            this.lblSelectTreatments.Size = new System.Drawing.Size(93, 13);
            this.lblSelectTreatments.TabIndex = 0;
            this.lblSelectTreatments.Text = "Select Treatments";
            // 
            // lstTreatments
            // 
            this.lstTreatments.FormattingEnabled = true;
            this.lstTreatments.Location = new System.Drawing.Point(3, 20);
            this.lstTreatments.MultiColumn = true;
            this.lstTreatments.Name = "lstTreatments";
            this.lstTreatments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTreatments.Size = new System.Drawing.Size(560, 329);
            this.lstTreatments.TabIndex = 1;
            this.lstTreatments.SelectedIndexChanged += new System.EventHandler(this.lstTreatments_SelectedIndexChanged);
            this.lstTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTreatments_Format);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstTreatments);
            this.Controls.Add(this.lblSelectTreatments);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectTreatments;
        private System.Windows.Forms.ListBox lstTreatments;
    }
}
