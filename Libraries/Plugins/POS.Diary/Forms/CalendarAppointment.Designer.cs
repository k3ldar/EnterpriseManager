namespace POS.Diary.Forms
{
    partial class CalendarAppointment
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.cmbAppointmentType = new System.Windows.Forms.ComboBox();
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnAddTreatments = new System.Windows.Forms.Button();
            this.cmbTreatments = new System.Windows.Forms.ComboBox();
            this.lblTreatments = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.flowLayoutTreatments = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(267, 307);
            this.txtNotes.MaxLength = 239;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(375, 89);
            this.txtNotes.TabIndex = 18;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(270, 291);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 17;
            this.lblNotes.Text = "Notes";
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(12, 230);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(165, 21);
            this.cmbStartTime.TabIndex = 10;
            this.cmbStartTime.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStartTime_Format);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(12, 214);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 9;
            this.lblStartTime.Text = "Start Time";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(484, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(567, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(12, 130);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(242, 21);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStatus_Format);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 114);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // cmbDuration
            // 
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Location = new System.Drawing.Point(12, 180);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(242, 21);
            this.cmbDuration.TabIndex = 8;
            this.cmbDuration.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDuration_Format);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 164);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(47, 13);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Duration";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 269);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            // 
            // cmbAppointmentType
            // 
            this.cmbAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointmentType.FormattingEnabled = true;
            this.cmbAppointmentType.Location = new System.Drawing.Point(12, 84);
            this.cmbAppointmentType.Name = "cmbAppointmentType";
            this.cmbAppointmentType.Size = new System.Drawing.Size(242, 21);
            this.cmbAppointmentType.TabIndex = 4;
            this.cmbAppointmentType.SelectedIndexChanged += new System.EventHandler(this.cmbAppointmentType_SelectedIndexChanged);
            this.cmbAppointmentType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbAppointmentType_Format);
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.AutoSize = true;
            this.lblAppointmentType.Location = new System.Drawing.Point(12, 68);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(93, 13);
            this.lblAppointmentType.TabIndex = 3;
            this.lblAppointmentType.Text = "Appointment Type";
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(443, 24);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnFindCustomer.TabIndex = 1;
            this.btnFindCustomer.Text = "Find";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(12, 26);
            this.txtCustomer.MaxLength = 200;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(427, 20);
            this.txtCustomer.TabIndex = 2;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(390, 408);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(75, 23);
            this.btnHistory.TabIndex = 19;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnAddTreatments
            // 
            this.btnAddTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTreatments.Location = new System.Drawing.Point(532, 268);
            this.btnAddTreatments.Name = "btnAddTreatments";
            this.btnAddTreatments.Size = new System.Drawing.Size(110, 23);
            this.btnAddTreatments.TabIndex = 15;
            this.btnAddTreatments.Text = "Add &Treatments";
            this.btnAddTreatments.UseVisualStyleBackColor = true;
            this.btnAddTreatments.Click += new System.EventHandler(this.btnAddTreatments_Click);
            // 
            // cmbTreatments
            // 
            this.cmbTreatments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTreatments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTreatments.FormattingEnabled = true;
            this.cmbTreatments.Location = new System.Drawing.Point(273, 91);
            this.cmbTreatments.Name = "cmbTreatments";
            this.cmbTreatments.Size = new System.Drawing.Size(251, 21);
            this.cmbTreatments.TabIndex = 13;
            this.cmbTreatments.SelectedIndexChanged += new System.EventHandler(this.cmbTreatments_SelectedIndexChanged);
            this.cmbTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTreatments_Format);
            this.cmbTreatments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTreatments_KeyPress);
            this.cmbTreatments.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbTreatments_PreviewKeyDown);
            // 
            // lblTreatments
            // 
            this.lblTreatments.AutoSize = true;
            this.lblTreatments.Location = new System.Drawing.Point(270, 73);
            this.lblTreatments.Name = "lblTreatments";
            this.lblTreatments.Size = new System.Drawing.Size(60, 13);
            this.lblTreatments.TabIndex = 12;
            this.lblTreatments.Text = "Treatments";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Location = new System.Drawing.Point(451, 268);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 16;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // flowLayoutTreatments
            // 
            this.flowLayoutTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutTreatments.AutoScroll = true;
            this.flowLayoutTreatments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutTreatments.Location = new System.Drawing.Point(267, 118);
            this.flowLayoutTreatments.Name = "flowLayoutTreatments";
            this.flowLayoutTreatments.Size = new System.Drawing.Size(375, 133);
            this.flowLayoutTreatments.TabIndex = 14;
            this.flowLayoutTreatments.WrapContents = false;
            // 
            // CalendarAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 436);
            this.Controls.Add(this.flowLayoutTreatments);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.lblTreatments);
            this.Controls.Add(this.cmbTreatments);
            this.Controls.Add(this.btnAddTreatments);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.cmbAppointmentType);
            this.Controls.Add(this.lblAppointmentType);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(662, 475);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(662, 475);
            this.Name = "CalendarAppointment";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Calendar Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.ComboBox cmbAppointmentType;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnAddTreatments;
        private System.Windows.Forms.ComboBox cmbTreatments;
        private System.Windows.Forms.Label lblTreatments;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutTreatments;
    }
}