namespace POS.Staff.Controls.Wizards.Commission.PoolPayCommission
{
    partial class Step1
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
            this.lblSelectPool = new System.Windows.Forms.Label();
            this.cmbPools = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSelectPool
            // 
            this.lblSelectPool.AutoSize = true;
            this.lblSelectPool.Location = new System.Drawing.Point(4, 4);
            this.lblSelectPool.Name = "lblSelectPool";
            this.lblSelectPool.Size = new System.Drawing.Size(35, 13);
            this.lblSelectPool.TabIndex = 0;
            this.lblSelectPool.Text = "label1";
            // 
            // cmbPools
            // 
            this.cmbPools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPools.FormattingEnabled = true;
            this.cmbPools.Location = new System.Drawing.Point(7, 21);
            this.cmbPools.Name = "cmbPools";
            this.cmbPools.Size = new System.Drawing.Size(239, 21);
            this.cmbPools.TabIndex = 1;
            this.cmbPools.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPools_Format);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPools);
            this.Controls.Add(this.lblSelectPool);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectPool;
        private System.Windows.Forms.ComboBox cmbPools;
    }
}
