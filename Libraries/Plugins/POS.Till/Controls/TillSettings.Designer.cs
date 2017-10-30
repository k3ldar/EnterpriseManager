namespace POS.Till.Controls
{
    partial class TillSettings
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
            this.gbButtonOptions = new System.Windows.Forms.GroupBox();
            this.cbShowProductImages = new System.Windows.Forms.CheckBox();
            this.rbShowButtons = new System.Windows.Forms.RadioButton();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.cbShowPriceExcludingVAT = new System.Windows.Forms.CheckBox();
            this.cbHideOutOfStockProducts = new System.Windows.Forms.CheckBox();
            this.cbHideZeroStockProducts = new System.Windows.Forms.CheckBox();
            this.cbShowSummaryStatusBar = new System.Windows.Forms.CheckBox();
            this.gbButtonOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbButtonOptions
            // 
            this.gbButtonOptions.Controls.Add(this.cbShowProductImages);
            this.gbButtonOptions.Location = new System.Drawing.Point(19, 32);
            this.gbButtonOptions.Name = "gbButtonOptions";
            this.gbButtonOptions.Size = new System.Drawing.Size(438, 100);
            this.gbButtonOptions.TabIndex = 1;
            this.gbButtonOptions.TabStop = false;
            this.gbButtonOptions.Text = "Button Options";
            // 
            // cbShowProductImages
            // 
            this.cbShowProductImages.AutoSize = true;
            this.cbShowProductImages.Location = new System.Drawing.Point(13, 21);
            this.cbShowProductImages.Name = "cbShowProductImages";
            this.cbShowProductImages.Size = new System.Drawing.Size(181, 17);
            this.cbShowProductImages.TabIndex = 0;
            this.cbShowProductImages.Text = "Show product images if available";
            this.cbShowProductImages.UseVisualStyleBackColor = true;
            // 
            // rbShowButtons
            // 
            this.rbShowButtons.AutoSize = true;
            this.rbShowButtons.Location = new System.Drawing.Point(4, 4);
            this.rbShowButtons.Name = "rbShowButtons";
            this.rbShowButtons.Size = new System.Drawing.Size(91, 17);
            this.rbShowButtons.TabIndex = 0;
            this.rbShowButtons.TabStop = true;
            this.rbShowButtons.Text = "Show Buttons";
            this.rbShowButtons.UseVisualStyleBackColor = true;
            this.rbShowButtons.CheckedChanged += new System.EventHandler(this.rbShowButtons_CheckedChanged);
            // 
            // rbList
            // 
            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(4, 165);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(76, 17);
            this.rbList.TabIndex = 2;
            this.rbList.TabStop = true;
            this.rbList.Text = "Show Lists";
            this.rbList.UseVisualStyleBackColor = true;
            this.rbList.CheckedChanged += new System.EventHandler(this.rbShowButtons_CheckedChanged);
            // 
            // cbShowPriceExcludingVAT
            // 
            this.cbShowPriceExcludingVAT.AutoSize = true;
            this.cbShowPriceExcludingVAT.Location = new System.Drawing.Point(4, 210);
            this.cbShowPriceExcludingVAT.Name = "cbShowPriceExcludingVAT";
            this.cbShowPriceExcludingVAT.Size = new System.Drawing.Size(140, 17);
            this.cbShowPriceExcludingVAT.TabIndex = 3;
            this.cbShowPriceExcludingVAT.Text = "Show price without VAT";
            this.cbShowPriceExcludingVAT.UseVisualStyleBackColor = true;
            // 
            // cbHideOutOfStockProducts
            // 
            this.cbHideOutOfStockProducts.AutoSize = true;
            this.cbHideOutOfStockProducts.Location = new System.Drawing.Point(4, 234);
            this.cbHideOutOfStockProducts.Name = "cbHideOutOfStockProducts";
            this.cbHideOutOfStockProducts.Size = new System.Drawing.Size(158, 17);
            this.cbHideOutOfStockProducts.TabIndex = 4;
            this.cbHideOutOfStockProducts.Text = "cbHideOutOfStockProducts";
            this.cbHideOutOfStockProducts.UseVisualStyleBackColor = true;
            // 
            // cbHideZeroStockProducts
            // 
            this.cbHideZeroStockProducts.AutoSize = true;
            this.cbHideZeroStockProducts.Location = new System.Drawing.Point(4, 257);
            this.cbHideZeroStockProducts.Name = "cbHideZeroStockProducts";
            this.cbHideZeroStockProducts.Size = new System.Drawing.Size(158, 17);
            this.cbHideZeroStockProducts.TabIndex = 5;
            this.cbHideZeroStockProducts.Text = "Hide products with no stock";
            this.cbHideZeroStockProducts.UseVisualStyleBackColor = true;
            // 
            // cbShowSummaryStatusBar
            // 
            this.cbShowSummaryStatusBar.AutoSize = true;
            this.cbShowSummaryStatusBar.Location = new System.Drawing.Point(4, 281);
            this.cbShowSummaryStatusBar.Name = "cbShowSummaryStatusBar";
            this.cbShowSummaryStatusBar.Size = new System.Drawing.Size(151, 17);
            this.cbShowSummaryStatusBar.TabIndex = 6;
            this.cbShowSummaryStatusBar.Text = "Show Summary Status Bar";
            this.cbShowSummaryStatusBar.UseVisualStyleBackColor = true;
            // 
            // TillSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowSummaryStatusBar);
            this.Controls.Add(this.cbHideZeroStockProducts);
            this.Controls.Add(this.cbHideOutOfStockProducts);
            this.Controls.Add(this.cbShowPriceExcludingVAT);
            this.Controls.Add(this.rbList);
            this.Controls.Add(this.rbShowButtons);
            this.Controls.Add(this.gbButtonOptions);
            this.Name = "TillSettings";
            this.gbButtonOptions.ResumeLayout(false);
            this.gbButtonOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbButtonOptions;
        private System.Windows.Forms.RadioButton rbShowButtons;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.CheckBox cbShowProductImages;
        private System.Windows.Forms.CheckBox cbShowPriceExcludingVAT;
        private System.Windows.Forms.CheckBox cbHideOutOfStockProducts;
        private System.Windows.Forms.CheckBox cbHideZeroStockProducts;
        private System.Windows.Forms.CheckBox cbShowSummaryStatusBar;
    }
}
