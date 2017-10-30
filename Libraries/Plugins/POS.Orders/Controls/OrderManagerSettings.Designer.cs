namespace POS.Orders.Controls
{
    partial class OrderManagerSettings
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
            this.gbTextAlignment = new System.Windows.Forms.GroupBox();
            this.rbOrderByAlignRight = new System.Windows.Forms.RadioButton();
            this.rbOrderByAlignCenter = new System.Windows.Forms.RadioButton();
            this.rbOrderByAlignLeft = new System.Windows.Forms.RadioButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtInvoicePreparedBy = new System.Windows.Forms.TextBox();
            this.cbLinkToStock = new System.Windows.Forms.CheckBox();
            this.cbBypassLabel = new System.Windows.Forms.CheckBox();
            this.gbTextAlignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTextAlignment
            // 
            this.gbTextAlignment.Controls.Add(this.rbOrderByAlignRight);
            this.gbTextAlignment.Controls.Add(this.rbOrderByAlignCenter);
            this.gbTextAlignment.Controls.Add(this.rbOrderByAlignLeft);
            this.gbTextAlignment.Location = new System.Drawing.Point(6, 66);
            this.gbTextAlignment.Name = "gbTextAlignment";
            this.gbTextAlignment.Size = new System.Drawing.Size(451, 42);
            this.gbTextAlignment.TabIndex = 2;
            this.gbTextAlignment.TabStop = false;
            this.gbTextAlignment.Text = "Text Alignment";
            // 
            // rbOrderByAlignRight
            // 
            this.rbOrderByAlignRight.AutoSize = true;
            this.rbOrderByAlignRight.Location = new System.Drawing.Point(395, 20);
            this.rbOrderByAlignRight.Name = "rbOrderByAlignRight";
            this.rbOrderByAlignRight.Size = new System.Drawing.Size(50, 17);
            this.rbOrderByAlignRight.TabIndex = 2;
            this.rbOrderByAlignRight.TabStop = true;
            this.rbOrderByAlignRight.Text = "Right";
            this.rbOrderByAlignRight.UseVisualStyleBackColor = true;
            // 
            // rbOrderByAlignCenter
            // 
            this.rbOrderByAlignCenter.AutoSize = true;
            this.rbOrderByAlignCenter.Location = new System.Drawing.Point(196, 20);
            this.rbOrderByAlignCenter.Name = "rbOrderByAlignCenter";
            this.rbOrderByAlignCenter.Size = new System.Drawing.Size(56, 17);
            this.rbOrderByAlignCenter.TabIndex = 1;
            this.rbOrderByAlignCenter.TabStop = true;
            this.rbOrderByAlignCenter.Text = "Center";
            this.rbOrderByAlignCenter.UseVisualStyleBackColor = true;
            // 
            // rbOrderByAlignLeft
            // 
            this.rbOrderByAlignLeft.AutoSize = true;
            this.rbOrderByAlignLeft.Location = new System.Drawing.Point(7, 20);
            this.rbOrderByAlignLeft.Name = "rbOrderByAlignLeft";
            this.rbOrderByAlignLeft.Size = new System.Drawing.Size(43, 17);
            this.rbOrderByAlignLeft.TabIndex = 0;
            this.rbOrderByAlignLeft.TabStop = true;
            this.rbOrderByAlignLeft.Text = "Left";
            this.rbOrderByAlignLeft.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(386, 26);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "You can add text to the footer of an invoice printed via the order manager, enter" +
    " \r\nthe text below, leave blank if nothing is to be added";
            // 
            // txtInvoicePreparedBy
            // 
            this.txtInvoicePreparedBy.Location = new System.Drawing.Point(6, 40);
            this.txtInvoicePreparedBy.Name = "txtInvoicePreparedBy";
            this.txtInvoicePreparedBy.Size = new System.Drawing.Size(451, 20);
            this.txtInvoicePreparedBy.TabIndex = 1;
            // 
            // cbLinkToStock
            // 
            this.cbLinkToStock.AutoSize = true;
            this.cbLinkToStock.Location = new System.Drawing.Point(6, 157);
            this.cbLinkToStock.Name = "cbLinkToStock";
            this.cbLinkToStock.Size = new System.Drawing.Size(233, 17);
            this.cbLinkToStock.TabIndex = 3;
            this.cbLinkToStock.Text = "Do not allow dispatch of items with no stock";
            this.cbLinkToStock.UseVisualStyleBackColor = true;
            // 
            // cbBypassLabel
            // 
            this.cbBypassLabel.AutoSize = true;
            this.cbBypassLabel.Location = new System.Drawing.Point(6, 199);
            this.cbBypassLabel.Name = "cbBypassLabel";
            this.cbBypassLabel.Size = new System.Drawing.Size(123, 17);
            this.cbBypassLabel.TabIndex = 4;
            this.cbBypassLabel.Text = "Bypass Label Check";
            this.cbBypassLabel.UseVisualStyleBackColor = true;
            // 
            // OrderManagerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbBypassLabel);
            this.Controls.Add(this.cbLinkToStock);
            this.Controls.Add(this.gbTextAlignment);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtInvoicePreparedBy);
            this.Name = "OrderManagerSettings";
            this.gbTextAlignment.ResumeLayout(false);
            this.gbTextAlignment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTextAlignment;
        private System.Windows.Forms.RadioButton rbOrderByAlignRight;
        private System.Windows.Forms.RadioButton rbOrderByAlignCenter;
        private System.Windows.Forms.RadioButton rbOrderByAlignLeft;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtInvoicePreparedBy;
        private System.Windows.Forms.CheckBox cbLinkToStock;
        private System.Windows.Forms.CheckBox cbBypassLabel;
    }
}
