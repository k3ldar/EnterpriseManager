namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lvAppointments = new SharedControls.Classes.ListViewEx();
            this.columnHeaderTherapist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbShowInDiary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // lvAppointments
            // 
            this.lvAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTherapist,
            this.columnHeaderDate,
            this.columnHeaderTime});
            this.lvAppointments.FullRowSelect = true;
            this.lvAppointments.HideSelection = false;
            this.lvAppointments.Location = new System.Drawing.Point(6, 29);
            this.lvAppointments.Name = "lvAppointments";
            this.lvAppointments.Size = new System.Drawing.Size(557, 304);
            this.lvAppointments.TabIndex = 2;
            this.lvAppointments.UseCompatibleStateImageBehavior = false;
            this.lvAppointments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTherapist
            // 
            this.columnHeaderTherapist.Text = "Therapist";
            this.columnHeaderTherapist.Width = 260;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 120;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 120;
            // 
            // cbShowInDiary
            // 
            this.cbShowInDiary.AutoSize = true;
            this.cbShowInDiary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbShowInDiary.Checked = true;
            this.cbShowInDiary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowInDiary.Location = new System.Drawing.Point(473, 339);
            this.cbShowInDiary.Name = "cbShowInDiary";
            this.cbShowInDiary.Size = new System.Drawing.Size(80, 17);
            this.cbShowInDiary.TabIndex = 3;
            this.cbShowInDiary.Text = "checkBox1";
            this.cbShowInDiary.UseVisualStyleBackColor = true;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowInDiary);
            this.Controls.Add(this.lvAppointments);
            this.Controls.Add(this.lblStatus);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private SharedControls.Classes.ListViewEx lvAppointments;
        private System.Windows.Forms.ColumnHeader columnHeaderTherapist;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.CheckBox cbShowInDiary;

    }
}
