namespace POS.TrainingSchedule.Forms
{
    partial class EditTrainingAppointment
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
            this.lblTrainerDesc = new System.Windows.Forms.Label();
            this.lblAttendees = new System.Windows.Forms.Label();
            this.flowLayoutPanelAttendees = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbTrainer = new System.Windows.Forms.ComboBox();
            this.lblCourseDesc = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.btnAddCompany = new System.Windows.Forms.Button();
            this.lblTotalAttendees = new System.Windows.Forms.Label();
            this.lblPlacesAvailable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTrainerDesc
            // 
            this.lblTrainerDesc.AutoSize = true;
            this.lblTrainerDesc.Location = new System.Drawing.Point(16, 13);
            this.lblTrainerDesc.Name = "lblTrainerDesc";
            this.lblTrainerDesc.Size = new System.Drawing.Size(40, 13);
            this.lblTrainerDesc.TabIndex = 0;
            this.lblTrainerDesc.Text = "Trainer";
            // 
            // lblAttendees
            // 
            this.lblAttendees.AutoSize = true;
            this.lblAttendees.Location = new System.Drawing.Point(16, 71);
            this.lblAttendees.Name = "lblAttendees";
            this.lblAttendees.Size = new System.Drawing.Size(55, 13);
            this.lblAttendees.TabIndex = 1;
            this.lblAttendees.Text = "Attendees";
            // 
            // flowLayoutPanelAttendees
            // 
            this.flowLayoutPanelAttendees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAttendees.AutoScroll = true;
            this.flowLayoutPanelAttendees.Location = new System.Drawing.Point(16, 87);
            this.flowLayoutPanelAttendees.Name = "flowLayoutPanelAttendees";
            this.flowLayoutPanelAttendees.Size = new System.Drawing.Size(469, 216);
            this.flowLayoutPanelAttendees.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(410, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(329, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbTrainer
            // 
            this.cmbTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrainer.FormattingEnabled = true;
            this.cmbTrainer.Location = new System.Drawing.Point(117, 10);
            this.cmbTrainer.Name = "cmbTrainer";
            this.cmbTrainer.Size = new System.Drawing.Size(270, 21);
            this.cmbTrainer.TabIndex = 7;
            this.cmbTrainer.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTrainer_Format);
            // 
            // lblCourseDesc
            // 
            this.lblCourseDesc.AutoSize = true;
            this.lblCourseDesc.Location = new System.Drawing.Point(16, 40);
            this.lblCourseDesc.Name = "lblCourseDesc";
            this.lblCourseDesc.Size = new System.Drawing.Size(40, 13);
            this.lblCourseDesc.TabIndex = 8;
            this.lblCourseDesc.Text = "Course";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(117, 37);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(270, 21);
            this.cmbCourse.TabIndex = 9;
            this.cmbCourse.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCourse_Format);
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCompany.Location = new System.Drawing.Point(343, 310);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(142, 23);
            this.btnAddCompany.TabIndex = 10;
            this.btnAddCompany.Text = "Add Salon";
            this.btnAddCompany.UseVisualStyleBackColor = true;
            this.btnAddCompany.Click += new System.EventHandler(this.btnAddCompany_Click);
            // 
            // lblTotalAttendees
            // 
            this.lblTotalAttendees.AutoSize = true;
            this.lblTotalAttendees.Location = new System.Drawing.Point(16, 310);
            this.lblTotalAttendees.Name = "lblTotalAttendees";
            this.lblTotalAttendees.Size = new System.Drawing.Size(82, 13);
            this.lblTotalAttendees.TabIndex = 11;
            this.lblTotalAttendees.Text = "Total Attendees";
            // 
            // lblPlacesAvailable
            // 
            this.lblPlacesAvailable.AutoSize = true;
            this.lblPlacesAvailable.Location = new System.Drawing.Point(16, 336);
            this.lblPlacesAvailable.Name = "lblPlacesAvailable";
            this.lblPlacesAvailable.Size = new System.Drawing.Size(85, 13);
            this.lblPlacesAvailable.TabIndex = 12;
            this.lblPlacesAvailable.Text = "Places Available";
            // 
            // EditTrainingAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(497, 433);
            this.Controls.Add(this.lblPlacesAvailable);
            this.Controls.Add(this.lblTotalAttendees);
            this.Controls.Add(this.btnAddCompany);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.lblCourseDesc);
            this.Controls.Add(this.cmbTrainer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.flowLayoutPanelAttendees);
            this.Controls.Add(this.lblAttendees);
            this.Controls.Add(this.lblTrainerDesc);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTrainingAppointment";
            this.SaveState = true;
            this.Text = "Training Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrainerDesc;
        private System.Windows.Forms.Label lblAttendees;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAttendees;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbTrainer;
        private System.Windows.Forms.Label lblCourseDesc;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Button btnAddCompany;
        private System.Windows.Forms.Label lblTotalAttendees;
        private System.Windows.Forms.Label lblPlacesAvailable;
    }
}