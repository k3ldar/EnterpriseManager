namespace POS.Orders.Forms
{
    partial class InvoiceDispatched
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
            this.btnDispatchOrder = new System.Windows.Forms.Button();
            this.txtTrackingReference = new System.Windows.Forms.TextBox();
            this.lblShippingReference = new System.Windows.Forms.Label();
            this.btnInternal = new System.Windows.Forms.Button();
            this.btnInternational = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDispatchOrder
            // 
            this.btnDispatchOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDispatchOrder.Location = new System.Drawing.Point(296, 98);
            this.btnDispatchOrder.Name = "btnDispatchOrder";
            this.btnDispatchOrder.Size = new System.Drawing.Size(99, 23);
            this.btnDispatchOrder.TabIndex = 5;
            this.btnDispatchOrder.Text = "Dispatch Order";
            this.btnDispatchOrder.UseVisualStyleBackColor = true;
            this.btnDispatchOrder.Click += new System.EventHandler(this.btnDispatchOrder_Click);
            // 
            // txtTrackingReference
            // 
            this.txtTrackingReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrackingReference.Location = new System.Drawing.Point(13, 34);
            this.txtTrackingReference.Name = "txtTrackingReference";
            this.txtTrackingReference.Size = new System.Drawing.Size(382, 20);
            this.txtTrackingReference.TabIndex = 1;
            // 
            // lblShippingReference
            // 
            this.lblShippingReference.AutoSize = true;
            this.lblShippingReference.Location = new System.Drawing.Point(13, 15);
            this.lblShippingReference.Name = "lblShippingReference";
            this.lblShippingReference.Size = new System.Drawing.Size(102, 13);
            this.lblShippingReference.TabIndex = 0;
            this.lblShippingReference.Text = "Tracking Reference";
            // 
            // btnInternal
            // 
            this.btnInternal.Location = new System.Drawing.Point(320, 60);
            this.btnInternal.Name = "btnInternal";
            this.btnInternal.Size = new System.Drawing.Size(75, 23);
            this.btnInternal.TabIndex = 3;
            this.btnInternal.Text = "UK";
            this.btnInternal.UseVisualStyleBackColor = true;
            this.btnInternal.Visible = false;
            this.btnInternal.Click += new System.EventHandler(this.btnInternal_Click);
            // 
            // btnInternational
            // 
            this.btnInternational.Location = new System.Drawing.Point(239, 60);
            this.btnInternational.Name = "btnInternational";
            this.btnInternational.Size = new System.Drawing.Size(75, 23);
            this.btnInternational.TabIndex = 2;
            this.btnInternational.Text = "International";
            this.btnInternational.UseVisualStyleBackColor = true;
            this.btnInternational.Visible = false;
            this.btnInternational.Click += new System.EventHandler(this.btnInternational_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 2);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(215, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // InvoiceDispatched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 133);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInternational);
            this.Controls.Add(this.btnInternal);
            this.Controls.Add(this.lblShippingReference);
            this.Controls.Add(this.txtTrackingReference);
            this.Controls.Add(this.btnDispatchOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceDispatched";
            this.SaveState = true;
            this.Text = "Dispatch Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDispatchOrder;
        private System.Windows.Forms.TextBox txtTrackingReference;
        private System.Windows.Forms.Label lblShippingReference;
        private System.Windows.Forms.Button btnInternal;
        private System.Windows.Forms.Button btnInternational;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
    }
}