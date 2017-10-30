namespace POS.Staff.Forms
{
    partial class StaffSickSelectNewAppointment
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
            this.lvAppointments = new SharedControls.Classes.ListViewEx();
            this.columnHeaderTherapist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvAppointments
            // 
            this.lvAppointments.AllowColumnReorder = true;
            this.lvAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTherapist,
            this.columnHeaderDate,
            this.columnHeaderTime});
            this.lvAppointments.FullRowSelect = true;
            this.lvAppointments.HideSelection = false;
            this.lvAppointments.Location = new System.Drawing.Point(12, 35);
            this.lvAppointments.Name = "lvAppointments";
            this.lvAppointments.OwnerDraw = true;
            this.lvAppointments.SaveName = "";
            this.lvAppointments.ShowToolTip = false;
            this.lvAppointments.Size = new System.Drawing.Size(557, 180);
            this.lvAppointments.TabIndex = 3;
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
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(494, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(13, 13);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(35, 13);
            this.lblInformation.TabIndex = 5;
            this.lblInformation.Text = "label1";
            // 
            // StaffSickSelectNewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 254);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvAppointments);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffSickSelectNewAppointment";
            this.ShowIcon = false;
            this.Text = "StaffSickSelectNewAppointment";
            this.Shown += new System.EventHandler(this.StaffSickSelectNewAppointment_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvAppointments;
        private System.Windows.Forms.ColumnHeader columnHeaderTherapist;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblInformation;
    }
}