namespace POS.Diary.Forms
{
    partial class AppointmentHistoryForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lvApptHistory = new SharedControls.Classes.ListViewEx();
            this.colTimeFrame = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApptCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(490, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lvApptHistory
            // 
            this.lvApptHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimeFrame,
            this.colStatus,
            this.colApptCount});
            this.lvApptHistory.Location = new System.Drawing.Point(13, 39);
            this.lvApptHistory.Name = "lvApptHistory";
            this.lvApptHistory.Size = new System.Drawing.Size(552, 292);
            this.lvApptHistory.TabIndex = 1;
            this.lvApptHistory.UseCompatibleStateImageBehavior = false;
            this.lvApptHistory.View = System.Windows.Forms.View.Details;
            // 
            // colTimeFrame
            // 
            this.colTimeFrame.Text = "Time Frame";
            this.colTimeFrame.Width = 196;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 158;
            // 
            // colApptCount
            // 
            this.colApptCount.Text = "Count of Appointments";
            this.colApptCount.Width = 131;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(210, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "The following is the appointment history for ";
            // 
            // AppointmentHistoryForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 361);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lvApptHistory);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(587, 404);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(587, 404);
            this.Name = "AppointmentHistoryForm";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Appointment History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private SharedControls.Classes.ListViewEx lvApptHistory;
        private System.Windows.Forms.ColumnHeader colTimeFrame;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colApptCount;
        private System.Windows.Forms.Label lblDescription;
    }
}