namespace POS.Diary.Forms
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newAppointments1 = new SalonDiary.Controls.NewAppointments();
            this.SuspendLayout();
            // 
            // newAppointments1
            // 
            this.newAppointments1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newAppointments1.Location = new System.Drawing.Point(11, 10);
            this.newAppointments1.Name = "newAppointments1";
            this.newAppointments1.Size = new System.Drawing.Size(667, 392);
            this.newAppointments1.TabIndex = 0;
            // 
            // NewAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 411);
            this.Controls.Add(this.newAppointments1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAppointments";
            this.SaveState = true;
            this.Text = "NewAppointments";
            this.ResumeLayout(false);

        }

        #endregion

        public SalonDiary.Controls.NewAppointments newAppointments1;

    }
}