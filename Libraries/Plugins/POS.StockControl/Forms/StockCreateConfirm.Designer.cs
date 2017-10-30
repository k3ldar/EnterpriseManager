namespace POS.StockControl.Forms
{
    partial class StockCreateConfirm
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
            this.lblStockCreate = new System.Windows.Forms.Label();
            this.lblStockRemove = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvRemoveItems = new SharedControls.Classes.ListViewEx();
            this.chStockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStockQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblStockCreate
            // 
            this.lblStockCreate.AutoSize = true;
            this.lblStockCreate.Location = new System.Drawing.Point(13, 13);
            this.lblStockCreate.Name = "lblStockCreate";
            this.lblStockCreate.Size = new System.Drawing.Size(35, 13);
            this.lblStockCreate.TabIndex = 0;
            this.lblStockCreate.Text = "label1";
            // 
            // lblStockRemove
            // 
            this.lblStockRemove.AutoSize = true;
            this.lblStockRemove.Location = new System.Drawing.Point(13, 66);
            this.lblStockRemove.Name = "lblStockRemove";
            this.lblStockRemove.Size = new System.Drawing.Size(35, 13);
            this.lblStockRemove.TabIndex = 1;
            this.lblStockRemove.Text = "label2";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(475, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Yes";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lvRemoveItems
            // 
            this.lvRemoveItems.AllowColumnReorder = true;
            this.lvRemoveItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chStockName,
            this.chStockQuantity});
            this.lvRemoveItems.Location = new System.Drawing.Point(16, 83);
            this.lvRemoveItems.Name = "lvRemoveItems";
            this.lvRemoveItems.OwnerDraw = true;
            this.lvRemoveItems.SaveName = "";
            this.lvRemoveItems.ShowToolTip = false;
            this.lvRemoveItems.Size = new System.Drawing.Size(534, 137);
            this.lvRemoveItems.TabIndex = 2;
            this.lvRemoveItems.UseCompatibleStateImageBehavior = false;
            this.lvRemoveItems.View = System.Windows.Forms.View.Details;
            // 
            // chStockName
            // 
            this.chStockName.Width = 350;
            // 
            // chStockQuantity
            // 
            this.chStockQuantity.Width = 141;
            // 
            // StockCreateConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 261);
            this.Controls.Add(this.lvRemoveItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblStockRemove);
            this.Controls.Add(this.lblStockCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockCreateConfirm";
            this.ShowIcon = false;
            this.Text = "StockCreateConfirm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockCreate;
        private System.Windows.Forms.Label lblStockRemove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private SharedControls.Classes.ListViewEx lvRemoveItems;
        private System.Windows.Forms.ColumnHeader chStockName;
        private System.Windows.Forms.ColumnHeader chStockQuantity;
    }
}