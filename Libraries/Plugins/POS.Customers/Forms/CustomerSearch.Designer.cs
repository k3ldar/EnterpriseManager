namespace POS.Customers.Forms
{
    partial class CustomerSearch
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
            this.customerSearchControl1 = new POS.Customers.Controls.CustomerSearchControl();
            this.SuspendLayout();
            // 
            // customerSearchControl1
            // 
            this.customerSearchControl1.HintControl = null;
            this.customerSearchControl1.Location = new System.Drawing.Point(1, 0);
            this.customerSearchControl1.MinimumSize = new System.Drawing.Size(896, 317);
            this.customerSearchControl1.Name = "customerSearchControl1";
            this.customerSearchControl1.Size = new System.Drawing.Size(896, 317);
            this.customerSearchControl1.TabIndex = 0;
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 326);
            this.Controls.Add(this.customerSearchControl1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(896, 317);
            this.Name = "CustomerSearch";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Administration - Members";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomerSearchControl customerSearchControl1;
    }
}