namespace POS.Diary.Forms
{
    partial class AppointmentChanges
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lvChanges = new SharedControls.Classes.ListViewEx();
            this.colHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTreatment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDateAltered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderAlteredBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(278, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "The following changes have occured for this appointment";
            // 
            // lvChanges
            // 
            this.lvChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderDate,
            this.colHeaderTime,
            this.colHeaderDuration,
            this.colHeaderStatus,
            this.colHeaderType,
            this.colHeaderEmployee,
            this.colHeaderTreatment,
            this.colHeaderNotes,
            this.colHeaderDateAltered,
            this.colHeaderAlteredBy});
            this.lvChanges.FullRowSelect = true;
            this.lvChanges.Location = new System.Drawing.Point(12, 25);
            this.lvChanges.MultiSelect = false;
            this.lvChanges.Name = "lvChanges";
            this.lvChanges.Size = new System.Drawing.Size(507, 183);
            this.lvChanges.TabIndex = 1;
            this.lvChanges.UseCompatibleStateImageBehavior = false;
            this.lvChanges.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderDate
            // 
            this.colHeaderDate.Text = "Date";
            this.colHeaderDate.Width = 75;
            // 
            // colHeaderTime
            // 
            this.colHeaderTime.Text = "Time";
            // 
            // colHeaderDuration
            // 
            this.colHeaderDuration.Text = "Duration";
            // 
            // colHeaderStatus
            // 
            this.colHeaderStatus.Text = "Status";
            this.colHeaderStatus.Width = 109;
            // 
            // colHeaderType
            // 
            this.colHeaderType.Text = "Type";
            this.colHeaderType.Width = 108;
            // 
            // colHeaderEmployee
            // 
            this.colHeaderEmployee.Text = "Employee";
            this.colHeaderEmployee.Width = 92;
            // 
            // colHeaderTreatment
            // 
            this.colHeaderTreatment.Text = "Treatment";
            this.colHeaderTreatment.Width = 92;
            // 
            // colHeaderNotes
            // 
            this.colHeaderNotes.Text = "Notes";
            this.colHeaderNotes.Width = 100;
            // 
            // colHeaderDateAltered
            // 
            this.colHeaderDateAltered.Text = "Date Altered";
            this.colHeaderDateAltered.Width = 85;
            // 
            // colHeaderAlteredBy
            // 
            this.colHeaderAlteredBy.Text = "Altered By";
            this.colHeaderAlteredBy.Width = 92;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(444, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // AppointmentChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 255);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvChanges);
            this.Controls.Add(this.lblDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentChanges";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Appointment Changes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private SharedControls.Classes.ListViewEx lvChanges;
        private System.Windows.Forms.ColumnHeader colHeaderDate;
        private System.Windows.Forms.ColumnHeader colHeaderTime;
        private System.Windows.Forms.ColumnHeader colHeaderDuration;
        private System.Windows.Forms.ColumnHeader colHeaderStatus;
        private System.Windows.Forms.ColumnHeader colHeaderType;
        private System.Windows.Forms.ColumnHeader colHeaderEmployee;
        private System.Windows.Forms.ColumnHeader colHeaderTreatment;
        private System.Windows.Forms.ColumnHeader colHeaderNotes;
        private System.Windows.Forms.ColumnHeader colHeaderDateAltered;
        private System.Windows.Forms.ColumnHeader colHeaderAlteredBy;
        private System.Windows.Forms.Button btnClose;
    }
}