namespace POS.Marketing.Controls
{
    partial class MassEmailSettings
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
            this.lblSelectOptions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelectOptions
            // 
            this.lblSelectOptions.AutoSize = true;
            this.lblSelectOptions.Location = new System.Drawing.Point(3, 13);
            this.lblSelectOptions.Name = "lblSelectOptions";
            this.lblSelectOptions.Size = new System.Drawing.Size(175, 13);
            this.lblSelectOptions.TabIndex = 0;
            this.lblSelectOptions.Text = "Please select an option from the left";
            // 
            // MassEmailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectOptions);
            this.Name = "MassEmailSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectOptions;
    }
}
