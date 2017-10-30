namespace POS.Administration.Forms.Categories
{
    partial class ProductCategoryTypeForm
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
            this.cbPrimary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbPrimary
            // 
            this.cbPrimary.AutoSize = true;
            this.cbPrimary.Location = new System.Drawing.Point(16, 69);
            this.cbPrimary.Name = "cbPrimary";
            this.cbPrimary.Size = new System.Drawing.Size(80, 17);
            this.cbPrimary.TabIndex = 2;
            this.cbPrimary.Text = "checkBox1";
            this.cbPrimary.UseVisualStyleBackColor = true;
            // 
            // ProductCategoryTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 157);
            this.Controls.Add(this.cbPrimary);
            this.Name = "ProductCategoryTypeForm";
            this.Text = "ProductCategoryTypeForm";
            this.Controls.SetChildIndex(this.cbPrimary, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPrimary;
    }
}