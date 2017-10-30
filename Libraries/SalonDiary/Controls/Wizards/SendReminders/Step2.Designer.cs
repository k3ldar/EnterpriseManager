namespace SalonDiary.Controls.Wizards.SendReminders
{
    partial class Step2
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.gridReminders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridReminders)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(7, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(159, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblAppointmentDate
            // 
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Location = new System.Drawing.Point(4, 4);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(124, 13);
            this.lblAppointmentDate.TabIndex = 1;
            this.lblAppointmentDate.Text = "Select appointment Date";
            // 
            // gridReminders
            // 
            this.gridReminders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReminders.Location = new System.Drawing.Point(7, 46);
            this.gridReminders.Name = "gridReminders";
            this.gridReminders.Size = new System.Drawing.Size(556, 307);
            this.gridReminders.TabIndex = 2;
            this.gridReminders.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.gridReminders.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.gridReminders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.gridReminders.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.gridReminders_CellToolTipTextNeeded);
            this.gridReminders.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridReminders_DataError);
            this.gridReminders.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridReminders_Scroll);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridReminders);
            this.Controls.Add(this.lblAppointmentDate);
            this.Controls.Add(this.dtpDate);
            this.Name = "Step2";
            ((System.ComponentModel.ISupportInitialize)(this.gridReminders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.DataGridView gridReminders;
    }
}
