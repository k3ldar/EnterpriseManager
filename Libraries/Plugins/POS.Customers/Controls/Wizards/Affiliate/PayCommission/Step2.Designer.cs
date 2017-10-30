namespace POS.Customers.Controls.Wizards.Affiliate.PayCommission
{
    partial class Step2
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
            this.gridCommissionSplit = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommissionSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCommissionSplit
            // 
            this.gridCommissionSplit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommissionSplit.Location = new System.Drawing.Point(3, 31);
            this.gridCommissionSplit.Name = "gridCommissionSplit";
            this.gridCommissionSplit.Size = new System.Drawing.Size(451, 322);
            this.gridCommissionSplit.TabIndex = 1;
            this.gridCommissionSplit.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridCommissionSplit_CellBeginEdit);
            this.gridCommissionSplit.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridCommissionSplit_CellFormatting);
            this.gridCommissionSplit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridCommissionSplit_DataError);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(460, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(460, 60);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "button2";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridCommissionSplit);
            this.Name = "Step2";
            ((System.ComponentModel.ISupportInitialize)(this.gridCommissionSplit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCommissionSplit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblDescription;

    }
}
