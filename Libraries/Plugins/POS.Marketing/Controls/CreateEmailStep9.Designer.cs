namespace POS.Marketing.Controls
{
    partial class CreateEmailStep9
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
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtSubText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(11, 46);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(75, 23);
            this.btnSelectColor.TabIndex = 4;
            this.btnSelectColor.Text = "Select Color";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(11, 3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(209, 24);
            this.lblHeader.TabIndex = 7;
            this.lblHeader.Text = "Sub Text Color and Text";
            // 
            // txtSubText
            // 
            this.txtSubText.Location = new System.Drawing.Point(11, 76);
            this.txtSubText.Multiline = true;
            this.txtSubText.Name = "txtSubText";
            this.txtSubText.Size = new System.Drawing.Size(540, 267);
            this.txtSubText.TabIndex = 8;
            // 
            // CreateEmailStep3A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSubText);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.lblHeader);
            this.Name = "CreateEmailStep3A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtSubText;
    }
}
