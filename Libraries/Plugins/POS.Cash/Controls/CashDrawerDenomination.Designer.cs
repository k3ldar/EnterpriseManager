namespace POS.CashManager.Classes
{
    partial class CashDrawerDenomination
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
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new SharedControls.TextBoxEx();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(3, 7);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(40, 13);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "£Value";
            // 
            // txtValue
            // 
            this.txtValue.AllowBackSpace = true;
            this.txtValue.AllowCopy = true;
            this.txtValue.AllowCut = true;
            this.txtValue.AllowedCharacters = "0123456789";
            this.txtValue.AllowPaste = true;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(60, 4);
            this.txtValue.MaxLength = 5;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(72, 20);
            this.txtValue.TabIndex = 1;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // CashDrawerDenomination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Name = "CashDrawerDenomination";
            this.Size = new System.Drawing.Size(135, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private SharedControls.TextBoxEx txtValue;
    }
}
