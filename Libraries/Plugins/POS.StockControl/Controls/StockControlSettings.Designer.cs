namespace POS.StockControl.Controls
{
    partial class StockControlSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockControlSettings));
            this.lblStockLowIndicator1 = new System.Windows.Forms.Label();
            this.spnLowStockLevel = new System.Windows.Forms.NumericUpDown();
            this.lblStockLowIndicator2 = new System.Windows.Forms.Label();
            this.csVeryLow = new SharedControls.ColorSelector();
            this.csVeryLowSelected = new SharedControls.ColorSelector();
            this.gbColors = new System.Windows.Forms.GroupBox();
            this.csLowStock = new SharedControls.ColorSelector();
            ((System.ComponentModel.ISupportInitialize)(this.spnLowStockLevel)).BeginInit();
            this.gbColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStockLowIndicator1
            // 
            this.lblStockLowIndicator1.AutoSize = true;
            this.lblStockLowIndicator1.Location = new System.Drawing.Point(3, 12);
            this.lblStockLowIndicator1.Name = "lblStockLowIndicator1";
            this.lblStockLowIndicator1.Size = new System.Drawing.Size(176, 13);
            this.lblStockLowIndicator1.TabIndex = 0;
            this.lblStockLowIndicator1.Text = "Show stock as low when the total is";
            // 
            // spnLowStockLevel
            // 
            this.spnLowStockLevel.Location = new System.Drawing.Point(225, 10);
            this.spnLowStockLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spnLowStockLevel.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spnLowStockLevel.Name = "spnLowStockLevel";
            this.spnLowStockLevel.Size = new System.Drawing.Size(64, 20);
            this.spnLowStockLevel.TabIndex = 1;
            this.spnLowStockLevel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblStockLowIndicator2
            // 
            this.lblStockLowIndicator2.AutoSize = true;
            this.lblStockLowIndicator2.Location = new System.Drawing.Point(318, 12);
            this.lblStockLowIndicator2.Name = "lblStockLowIndicator2";
            this.lblStockLowIndicator2.Size = new System.Drawing.Size(105, 13);
            this.lblStockLowIndicator2.TabIndex = 2;
            this.lblStockLowIndicator2.Text = "above minimum level";
            // 
            // csVeryLow
            // 
            this.csVeryLow.Description = "Description";
            this.csVeryLow.Location = new System.Drawing.Point(6, 19);
            this.csVeryLow.Name = "csVeryLow";
            this.csVeryLow.Size = new System.Drawing.Size(176, 50);
            this.csVeryLow.TabIndex = 1;
            // 
            // csVeryLowSelected
            // 
            this.csVeryLowSelected.Description = "Description";
            this.csVeryLowSelected.Location = new System.Drawing.Point(6, 75);
            this.csVeryLowSelected.Name = "csVeryLowSelected";
            this.csVeryLowSelected.Size = new System.Drawing.Size(176, 50);
            this.csVeryLowSelected.TabIndex = 2;
            // 
            // gbColors
            // 
            this.gbColors.Controls.Add(this.csLowStock);
            this.gbColors.Controls.Add(this.csVeryLowSelected);
            this.gbColors.Controls.Add(this.csVeryLow);
            this.gbColors.Location = new System.Drawing.Point(6, 60);
            this.gbColors.Name = "gbColors";
            this.gbColors.Size = new System.Drawing.Size(194, 196);
            this.gbColors.TabIndex = 3;
            this.gbColors.TabStop = false;
            this.gbColors.Text = "Colors";
            // 
            // csLowStock
            // 
            this.csLowStock.Description = "Description";
            this.csLowStock.Location = new System.Drawing.Point(6, 131);
            this.csLowStock.Name = "csLowStock";
            this.csLowStock.Size = new System.Drawing.Size(176, 50);
            this.csLowStock.TabIndex = 3;
            // 
            // StockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbColors);
            this.Controls.Add(this.lblStockLowIndicator2);
            this.Controls.Add(this.spnLowStockLevel);
            this.Controls.Add(this.lblStockLowIndicator1);
            this.Name = "StockControl";
            ((System.ComponentModel.ISupportInitialize)(this.spnLowStockLevel)).EndInit();
            this.gbColors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockLowIndicator1;
        private System.Windows.Forms.NumericUpDown spnLowStockLevel;
        private System.Windows.Forms.Label lblStockLowIndicator2;
        private SharedControls.ColorSelector csVeryLow;
        private SharedControls.ColorSelector csVeryLowSelected;
        private System.Windows.Forms.GroupBox gbColors;
        private SharedControls.ColorSelector csLowStock;
    }
}
