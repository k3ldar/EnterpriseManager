namespace POS.Marketing.Controls
{
    partial class CreateEmailStep2
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
            this.txtStrapLine = new System.Windows.Forms.TextBox();
            this.lblStrapLine = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStrapLine
            // 
            this.txtStrapLine.Location = new System.Drawing.Point(3, 118);
            this.txtStrapLine.Multiline = true;
            this.txtStrapLine.Name = "txtStrapLine";
            this.txtStrapLine.Size = new System.Drawing.Size(556, 91);
            this.txtStrapLine.TabIndex = 7;
            this.txtStrapLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStrapLine_KeyDown);
            // 
            // lblStrapLine
            // 
            this.lblStrapLine.AutoSize = true;
            this.lblStrapLine.Location = new System.Drawing.Point(3, 101);
            this.lblStrapLine.Name = "lblStrapLine";
            this.lblStrapLine.Size = new System.Drawing.Size(55, 13);
            this.lblStrapLine.TabIndex = 6;
            this.lblStrapLine.Text = "Strap Line";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(3, 61);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(556, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(6, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(191, 24);
            this.lblHeader.TabIndex = 8;
            this.lblHeader.Text = "Header and Strapline";
            // 
            // CreateEmailStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtStrapLine);
            this.Controls.Add(this.lblStrapLine);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "CreateEmailStep2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStrapLine;
        private System.Windows.Forms.Label lblStrapLine;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHeader;
    }
}
