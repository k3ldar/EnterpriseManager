namespace PointOfSale.Controls.Settings.Admin
{
    partial class LogInOut
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
            this.cbAutoLogout = new System.Windows.Forms.CheckBox();
            this.lblLogoutDesc1 = new System.Windows.Forms.Label();
            this.udTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblLogoutDesc2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAutoLogout
            // 
            this.cbAutoLogout.AutoSize = true;
            this.cbAutoLogout.Location = new System.Drawing.Point(4, 4);
            this.cbAutoLogout.Name = "cbAutoLogout";
            this.cbAutoLogout.Size = new System.Drawing.Size(124, 17);
            this.cbAutoLogout.TabIndex = 0;
            this.cbAutoLogout.Text = "Automatically Logout";
            this.cbAutoLogout.UseVisualStyleBackColor = true;
            this.cbAutoLogout.CheckedChanged += new System.EventHandler(this.cbAutoLogout_CheckedChanged);
            // 
            // lblLogoutDesc1
            // 
            this.lblLogoutDesc1.AutoSize = true;
            this.lblLogoutDesc1.Location = new System.Drawing.Point(3, 39);
            this.lblLogoutDesc1.Name = "lblLogoutDesc1";
            this.lblLogoutDesc1.Size = new System.Drawing.Size(67, 13);
            this.lblLogoutDesc1.TabIndex = 1;
            this.lblLogoutDesc1.Text = "Logout after ";
            // 
            // udTimeout
            // 
            this.udTimeout.Location = new System.Drawing.Point(89, 37);
            this.udTimeout.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.udTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTimeout.Name = "udTimeout";
            this.udTimeout.Size = new System.Drawing.Size(59, 20);
            this.udTimeout.TabIndex = 2;
            this.udTimeout.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblLogoutDesc2
            // 
            this.lblLogoutDesc2.AutoSize = true;
            this.lblLogoutDesc2.Location = new System.Drawing.Point(167, 39);
            this.lblLogoutDesc2.Name = "lblLogoutDesc2";
            this.lblLogoutDesc2.Size = new System.Drawing.Size(102, 13);
            this.lblLogoutDesc2.TabIndex = 3;
            this.lblLogoutDesc2.Text = " minutes of inactivity";
            // 
            // LogInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLogoutDesc2);
            this.Controls.Add(this.udTimeout);
            this.Controls.Add(this.lblLogoutDesc1);
            this.Controls.Add(this.cbAutoLogout);
            this.Name = "LogInOut";
            ((System.ComponentModel.ISupportInitialize)(this.udTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoLogout;
        private System.Windows.Forms.Label lblLogoutDesc1;
        private System.Windows.Forms.NumericUpDown udTimeout;
        private System.Windows.Forms.Label lblLogoutDesc2;
    }
}
