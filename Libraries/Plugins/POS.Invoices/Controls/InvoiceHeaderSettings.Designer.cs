namespace POS.Invoices.Controls
{
    partial class InvoiceHeaderSettings
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
            this.lblJPEGDesc = new System.Windows.Forms.Label();
            this.btnSelectInvoiceHeader = new System.Windows.Forms.Button();
            this.picInvoiceHeader = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblInvoiceAddress = new System.Windows.Forms.Label();
            this.txtInvoiceAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInvoiceHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJPEGDesc
            // 
            this.lblJPEGDesc.AutoSize = true;
            this.lblJPEGDesc.Location = new System.Drawing.Point(152, 14);
            this.lblJPEGDesc.Name = "lblJPEGDesc";
            this.lblJPEGDesc.Size = new System.Drawing.Size(141, 13);
            this.lblJPEGDesc.TabIndex = 1;
            this.lblJPEGDesc.Text = "JPEG Image 550 pixels wide";
            // 
            // btnSelectInvoiceHeader
            // 
            this.btnSelectInvoiceHeader.Location = new System.Drawing.Point(3, 9);
            this.btnSelectInvoiceHeader.Name = "btnSelectInvoiceHeader";
            this.btnSelectInvoiceHeader.Size = new System.Drawing.Size(142, 23);
            this.btnSelectInvoiceHeader.TabIndex = 0;
            this.btnSelectInvoiceHeader.Text = "Select Header";
            this.btnSelectInvoiceHeader.UseVisualStyleBackColor = true;
            this.btnSelectInvoiceHeader.Click += new System.EventHandler(this.btnSelectInvoiceHeader_Click);
            // 
            // picInvoiceHeader
            // 
            this.picInvoiceHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picInvoiceHeader.Location = new System.Drawing.Point(3, 38);
            this.picInvoiceHeader.Name = "picInvoiceHeader";
            this.picInvoiceHeader.Size = new System.Drawing.Size(440, 120);
            this.picInvoiceHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInvoiceHeader.TabIndex = 3;
            this.picInvoiceHeader.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblInvoiceAddress
            // 
            this.lblInvoiceAddress.AutoSize = true;
            this.lblInvoiceAddress.Location = new System.Drawing.Point(3, 165);
            this.lblInvoiceAddress.Name = "lblInvoiceAddress";
            this.lblInvoiceAddress.Size = new System.Drawing.Size(83, 13);
            this.lblInvoiceAddress.TabIndex = 2;
            this.lblInvoiceAddress.Text = "Invoice Address";
            // 
            // txtInvoiceAddress
            // 
            this.txtInvoiceAddress.AcceptsReturn = true;
            this.txtInvoiceAddress.Location = new System.Drawing.Point(3, 181);
            this.txtInvoiceAddress.MaxLength = 600;
            this.txtInvoiceAddress.Multiline = true;
            this.txtInvoiceAddress.Name = "txtInvoiceAddress";
            this.txtInvoiceAddress.Size = new System.Drawing.Size(453, 158);
            this.txtInvoiceAddress.TabIndex = 3;
            // 
            // InvoiceHeaderSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInvoiceAddress);
            this.Controls.Add(this.lblInvoiceAddress);
            this.Controls.Add(this.lblJPEGDesc);
            this.Controls.Add(this.btnSelectInvoiceHeader);
            this.Controls.Add(this.picInvoiceHeader);
            this.Name = "InvoiceHeaderSettings";
            ((System.ComponentModel.ISupportInitialize)(this.picInvoiceHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJPEGDesc;
        private System.Windows.Forms.Button btnSelectInvoiceHeader;
        private System.Windows.Forms.PictureBox picInvoiceHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblInvoiceAddress;
        private System.Windows.Forms.TextBox txtInvoiceAddress;
    }
}
