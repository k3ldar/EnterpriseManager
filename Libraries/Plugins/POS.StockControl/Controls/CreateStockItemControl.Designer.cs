namespace POS.StockControl.Controls
{
    partial class CreateStockItemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStockItemControl));
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.spinQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblStockAvailable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 14);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(262, 14);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Quantity:";
            // 
            // spinQuantity
            // 
            this.spinQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinQuantity.Location = new System.Drawing.Point(317, 12);
            this.spinQuantity.Name = "spinQuantity";
            this.spinQuantity.Size = new System.Drawing.Size(47, 20);
            this.spinQuantity.TabIndex = 2;
            this.spinQuantity.ValueChanged += new System.EventHandler(this.spinQuantity_ValueChanged);
            this.spinQuantity.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.spinQuantity_PreviewKeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(370, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(37, 31);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblStockAvailable
            // 
            this.lblStockAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStockAvailable.AutoSize = true;
            this.lblStockAvailable.Location = new System.Drawing.Point(428, 14);
            this.lblStockAvailable.Name = "lblStockAvailable";
            this.lblStockAvailable.Size = new System.Drawing.Size(50, 13);
            this.lblStockAvailable.TabIndex = 4;
            this.lblStockAvailable.Text = "Available";
            // 
            // CreateStockItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStockAvailable);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.spinQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblDescription);
            this.Name = "CreateStockItemControl";
            this.Size = new System.Drawing.Size(514, 42);
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown spinQuantity;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStockAvailable;
    }
}
