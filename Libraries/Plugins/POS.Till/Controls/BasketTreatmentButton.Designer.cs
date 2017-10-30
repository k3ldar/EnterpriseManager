namespace POS.Till.Controls
{
    partial class BasketTreatmentButton
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
            this.btnAddTreatment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTreatment.BackColor = System.Drawing.Color.White;
            this.btnAddTreatment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddTreatment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTreatment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddTreatment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddTreatment.Location = new System.Drawing.Point(0, 0);
            this.btnAddTreatment.Name = "btnAddProduct";
            this.btnAddTreatment.Size = new System.Drawing.Size(129, 84);
            this.btnAddTreatment.TabIndex = 1;
            this.btnAddTreatment.Text = "Treatment Name";
            this.btnAddTreatment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddTreatment.UseVisualStyleBackColor = false;
            this.btnAddTreatment.Click += new System.EventHandler(this.btnAddTreatment_Click);
            // 
            // BasketTreatmentButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddTreatment);
            this.Name = "BasketTreatmentButton";
            this.Size = new System.Drawing.Size(129, 84);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddTreatment;
    }
}
