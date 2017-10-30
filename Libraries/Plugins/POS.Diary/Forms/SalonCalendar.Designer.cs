namespace POS.Diary.Forms
{
    partial class SalonCalendar
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
            this.salonCalendarControl1 = new POS.Diary.Controls.SalonCalendarControl();
            this.SuspendLayout();
            // 
            // salonCalendarControl1
            // 
            this.salonCalendarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.salonCalendarControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.salonCalendarControl1.HintControl = null;
            this.salonCalendarControl1.Location = new System.Drawing.Point(3, 3);
            this.salonCalendarControl1.Name = "salonCalendarControl1";
            this.salonCalendarControl1.Size = new System.Drawing.Size(853, 405);
            this.salonCalendarControl1.TabIndex = 0;
            this.salonCalendarControl1.PayNow += new SalonDiary.Controls.PayNowEventHandler(this.salonDiary1_PayNow);
            // 
            // SalonCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 411);
            this.Controls.Add(this.salonCalendarControl1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "SalonCalendar";
            this.SaveState = true;
            this.Text = "Salon Diary";
            this.Activated += new System.EventHandler(this.SalonCalendar_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SalonCalendar_FormClosed);
            this.ResumeLayout(false);

        }


        #endregion

        private Controls.SalonCalendarControl salonCalendarControl1;
    }
}