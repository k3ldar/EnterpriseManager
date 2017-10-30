namespace POS.StockControl.Forms
{
    partial class MainScreenStockControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreenStockControl));
            this.mainStockControl1 = new POS.StockControl.Controls.MainStockControl();
            this.SuspendLayout();
            // 
            // mainStockControl1
            // 
            this.mainStockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainStockControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainStockControl1.HintControl = null;
            this.mainStockControl1.Location = new System.Drawing.Point(0, 0);
            this.mainStockControl1.MinimumSize = new System.Drawing.Size(824, 263);
            this.mainStockControl1.Name = "mainStockControl1";
            this.mainStockControl1.Size = new System.Drawing.Size(824, 268);
            this.mainStockControl1.TabIndex = 0;
            // 
            // MainScreenStockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 272);
            this.Controls.Add(this.mainStockControl1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(824, 263);
            this.Name = "MainScreenStockControl";
            this.SaveState = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stock Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreenStockControl_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private POS.StockControl.Controls.MainStockControl mainStockControl1;
    }
}