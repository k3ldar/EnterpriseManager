namespace SieraDelta.POS.Orders.Forms
{
    partial class SavedBasketOrdersForm
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
            this.lblSavedOrders = new System.Windows.Forms.Label();
            this.lstSavedOrders = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSavedOrders
            // 
            this.lblSavedOrders.AutoSize = true;
            this.lblSavedOrders.Location = new System.Drawing.Point(13, 13);
            this.lblSavedOrders.Name = "lblSavedOrders";
            this.lblSavedOrders.Size = new System.Drawing.Size(72, 13);
            this.lblSavedOrders.TabIndex = 0;
            this.lblSavedOrders.Text = "Saved Orders";
            // 
            // lstSavedOrders
            // 
            this.lstSavedOrders.FormattingEnabled = true;
            this.lstSavedOrders.Location = new System.Drawing.Point(16, 30);
            this.lstSavedOrders.Name = "lstSavedOrders";
            this.lstSavedOrders.Size = new System.Drawing.Size(631, 186);
            this.lstSavedOrders.TabIndex = 1;
            this.lstSavedOrders.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstSavedOrders_Format);
            this.lstSavedOrders.DoubleClick += new System.EventHandler(this.lstSavedOrders_DoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Location = new System.Drawing.Point(544, 226);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(106, 23);
            this.btnOpenSelected.TabIndex = 3;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);
            // 
            // SavedBasketOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(659, 261);
            this.Controls.Add(this.btnOpenSelected);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstSavedOrders);
            this.Controls.Add(this.lblSavedOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavedBasketOrdersForm";
            this.SaveState = true;
            this.Text = "SavedBasketOrdersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSavedOrders;
        private System.Windows.Forms.ListBox lstSavedOrders;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenSelected;
    }
}