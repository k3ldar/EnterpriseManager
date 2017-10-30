namespace POS.Administration.Forms.Products
{
    partial class InvalidProductSKU
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
            this.lvSKUData = new SharedControls.Classes.ListViewEx();
            this.columnHeaderSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPrompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvSKUData
            // 
            this.lvSKUData.AllowColumnReorder = true;
            this.lvSKUData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSKU,
            this.columnHeaderCount});
            this.lvSKUData.Location = new System.Drawing.Point(13, 52);
            this.lvSKUData.Name = "lvSKUData";
            this.lvSKUData.OwnerDraw = true;
            this.lvSKUData.SaveName = "InvalidSKUData";
            this.lvSKUData.ShowToolTip = false;
            this.lvSKUData.Size = new System.Drawing.Size(303, 197);
            this.lvSKUData.TabIndex = 0;
            this.lvSKUData.UseCompatibleStateImageBehavior = false;
            this.lvSKUData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSKU
            // 
            this.columnHeaderSKU.Width = 139;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Width = 128;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(13, 13);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(39, 13);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "prompt";
            // 
            // InvalidProductSKU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 261);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.lvSKUData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvalidProductSKU";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "InvalidProductSKU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvSKUData;
        private System.Windows.Forms.ColumnHeader columnHeaderSKU;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
        private System.Windows.Forms.Label lblPrompt;
    }
}