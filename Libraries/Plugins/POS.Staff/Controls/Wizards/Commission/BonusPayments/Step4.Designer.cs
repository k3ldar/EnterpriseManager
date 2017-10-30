namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    partial class Step4
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridCommissionSplit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommissionSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(5, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(461, 115);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "button2";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(461, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gridCommissionSplit
            // 
            this.gridCommissionSplit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommissionSplit.Location = new System.Drawing.Point(4, 86);
            this.gridCommissionSplit.Name = "gridCommissionSplit";
            this.gridCommissionSplit.Size = new System.Drawing.Size(451, 267);
            this.gridCommissionSplit.TabIndex = 1;
            this.gridCommissionSplit.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridCommissionSplit_CellBeginEdit);
            this.gridCommissionSplit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCommissionSplit_CellEndEdit);
            this.gridCommissionSplit.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCommissionSplit_CellEnter);
            this.gridCommissionSplit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridCommissionSplit_DataError);
            // 
            // Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridCommissionSplit);
            this.Name = "Step4";
            ((System.ComponentModel.ISupportInitialize)(this.gridCommissionSplit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gridCommissionSplit;
    }
}
