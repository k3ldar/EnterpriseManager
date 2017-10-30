namespace SalonDiary.Controls
{
    partial class NewAppointments
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
            this.components = new System.ComponentModel.Container();
            Calendar.DrawTool drawTool2 = new Calendar.DrawTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAppointments));
            this.dayView2 = new Calendar.DayView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confirmAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNewAppointments = new System.Windows.Forms.Label();
            this.lstNewAppointments = new SharedControls.Classes.ListViewEx();
            this.colEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageAppointmentOverlays = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayView2
            // 
            drawTool2.DayView = this.dayView2;
            this.dayView2.ActiveTool = drawTool2;
            this.dayView2.AllowInplaceEditing = false;
            this.dayView2.AllowNew = false;
            this.dayView2.AlwaysShowAppointmentText = true;
            this.dayView2.AmPmDisplay = false;
            this.dayView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayView2.ContextMenuAllDay = null;
            this.dayView2.ContextMenuDiary = this.contextMenuStrip1;
            this.dayView2.ContextMenuHeader = null;
            this.dayView2.DrawAllAppointmentBorders = false;
            this.dayView2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dayView2.Location = new System.Drawing.Point(344, 16);
            this.dayView2.Name = "dayView2";
            this.dayView2.RightMouseSelect = true;
            this.dayView2.SelectedAppointment = null;
            this.dayView2.SelectionEnd = new System.DateTime(((long)(0)));
            this.dayView2.SelectionStart = new System.DateTime(((long)(0)));
            this.dayView2.ShowMinutes = true;
            this.dayView2.Size = new System.Drawing.Size(190, 414);
            this.dayView2.StartDate = new System.DateTime(((long)(0)));
            this.dayView2.TabIndex = 5;
            this.dayView2.Text = "dayView2";
            this.dayView2.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView2_ResolveAppointments);
            this.dayView2.AppointmentMoved += new System.EventHandler<Calendar.AppointmentEventArgs>(this.dayView2_AppointmentMoved);
            this.dayView2.AfterDrawAppointment += new Calendar.AfterDrawAppointmentEventHandler(this.dayView2_AfterDrawAppointment);
            this.dayView2.Click += new System.EventHandler(this.dayView2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmAppointmentToolStripMenuItem,
            this.cancelAppointmentToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editAppointmentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.viewClientToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 104);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // confirmAppointmentToolStripMenuItem
            // 
            this.confirmAppointmentToolStripMenuItem.Name = "confirmAppointmentToolStripMenuItem";
            this.confirmAppointmentToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.confirmAppointmentToolStripMenuItem.Text = "&Confirm Appointment";
            this.confirmAppointmentToolStripMenuItem.Click += new System.EventHandler(this.confirmAppointmentToolStripMenuItem_Click);
            // 
            // cancelAppointmentToolStripMenuItem
            // 
            this.cancelAppointmentToolStripMenuItem.Name = "cancelAppointmentToolStripMenuItem";
            this.cancelAppointmentToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cancelAppointmentToolStripMenuItem.Text = "C&ancel Appointment";
            this.cancelAppointmentToolStripMenuItem.Click += new System.EventHandler(this.cancelAppointmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // editAppointmentToolStripMenuItem
            // 
            this.editAppointmentToolStripMenuItem.Name = "editAppointmentToolStripMenuItem";
            this.editAppointmentToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editAppointmentToolStripMenuItem.Text = "&Edit Appointment";
            this.editAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editAppointmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(189, 6);
            // 
            // viewClientToolStripMenuItem
            // 
            this.viewClientToolStripMenuItem.Name = "viewClientToolStripMenuItem";
            this.viewClientToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewClientToolStripMenuItem.Text = "&View Client";
            this.viewClientToolStripMenuItem.Click += new System.EventHandler(this.viewClientToolStripMenuItem_Click);
            // 
            // lblNewAppointments
            // 
            this.lblNewAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewAppointments.AutoSize = true;
            this.lblNewAppointments.Location = new System.Drawing.Point(0, 0);
            this.lblNewAppointments.Name = "lblNewAppointments";
            this.lblNewAppointments.Size = new System.Drawing.Size(96, 13);
            this.lblNewAppointments.TabIndex = 7;
            this.lblNewAppointments.Text = "New Appointments";
            // 
            // lstNewAppointments
            // 
            this.lstNewAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNewAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployee,
            this.colDate});
            this.lstNewAppointments.FullRowSelect = true;
            this.lstNewAppointments.Location = new System.Drawing.Point(0, 16);
            this.lstNewAppointments.MultiSelect = false;
            this.lstNewAppointments.Name = "lstNewAppointments";
            this.lstNewAppointments.Size = new System.Drawing.Size(338, 414);
            this.lstNewAppointments.TabIndex = 6;
            this.lstNewAppointments.UseCompatibleStateImageBehavior = false;
            this.lstNewAppointments.View = System.Windows.Forms.View.Details;
            this.lstNewAppointments.SelectedIndexChanged += new System.EventHandler(this.lstNewAppointments_SelectedIndexChanged);
            // 
            // colEmployee
            // 
            this.colEmployee.Text = "Employee";
            this.colEmployee.Width = 196;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 137;
            // 
            // imageAppointmentOverlays
            // 
            this.imageAppointmentOverlays.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageAppointmentOverlays.ImageStream")));
            this.imageAppointmentOverlays.TransparentColor = System.Drawing.Color.White;
            this.imageAppointmentOverlays.Images.SetKeyName(0, "notes.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(1, "warning.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(2, "meeting.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(3, "meeting_internal.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(4, "annual_leave.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(5, "training.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(6, "notes_appt.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(7, "locked.bmp");
            // 
            // NewAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNewAppointments);
            this.Controls.Add(this.lstNewAppointments);
            this.Controls.Add(this.dayView2);
            this.Name = "NewAppointments";
            this.Size = new System.Drawing.Size(537, 433);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Calendar.DayView dayView2;
        private System.Windows.Forms.Label lblNewAppointments;
        private SharedControls.Classes.ListViewEx lstNewAppointments;
        private System.Windows.Forms.ColumnHeader colEmployee;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ImageList imageAppointmentOverlays;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem confirmAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem viewClientToolStripMenuItem;
    }
}
