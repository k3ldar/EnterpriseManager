namespace POS.Diary.Controls
{
    partial class SalonAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalonAppointment));
            this.cmbTherapist = new System.Windows.Forms.ComboBox();
            this.cmbTreatments = new System.Windows.Forms.ComboBox();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.pictureDelete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTherapist
            // 
            this.cmbTherapist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTherapist.FormattingEnabled = true;
            this.cmbTherapist.Location = new System.Drawing.Point(3, 3);
            this.cmbTherapist.Name = "cmbTherapist";
            this.cmbTherapist.Size = new System.Drawing.Size(111, 21);
            this.cmbTherapist.TabIndex = 0;
            this.cmbTherapist.SelectedIndexChanged += new System.EventHandler(this.cmbTherapist_SelectedIndexChanged);
            this.cmbTherapist.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTherapist_Format);
            // 
            // cmbTreatments
            // 
            this.cmbTreatments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTreatments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTreatments.FormattingEnabled = true;
            this.cmbTreatments.Location = new System.Drawing.Point(120, 3);
            this.cmbTreatments.Name = "cmbTreatments";
            this.cmbTreatments.Size = new System.Drawing.Size(138, 21);
            this.cmbTreatments.TabIndex = 1;
            this.cmbTreatments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTreatments_KeyPress);
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(264, 3);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(60, 21);
            this.cmbStartTime.TabIndex = 2;
            this.cmbStartTime.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStartTime_Format);
            // 
            // pictureDelete
            // 
            this.pictureDelete.Image = Properties.Resources.EmployeeNoTreatments;
            this.pictureDelete.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureDelete.InitialImage")));
            this.pictureDelete.Location = new System.Drawing.Point(330, 6);
            this.pictureDelete.Name = "pictureDelete";
            this.pictureDelete.Size = new System.Drawing.Size(16, 16);
            this.pictureDelete.TabIndex = 3;
            this.pictureDelete.TabStop = false;
            this.pictureDelete.Click += new System.EventHandler(this.pictureDelete_Click);
            // 
            // SalonAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureDelete);
            this.Controls.Add(this.cmbStartTime);
            this.Controls.Add(this.cmbTreatments);
            this.Controls.Add(this.cmbTherapist);
            this.Name = "SalonAppointment";
            this.Size = new System.Drawing.Size(350, 28);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTherapist;
        private System.Windows.Forms.ComboBox cmbTreatments;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.PictureBox pictureDelete;
    }
}
