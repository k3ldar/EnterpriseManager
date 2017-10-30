namespace POS.AutoUpdate.Controls.Wizards.AddRule
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
            this.lblSelectItems = new System.Windows.Forms.Label();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblSelectItems
            // 
            this.lblSelectItems.AutoSize = true;
            this.lblSelectItems.Location = new System.Drawing.Point(4, 4);
            this.lblSelectItems.Name = "lblSelectItems";
            this.lblSelectItems.Size = new System.Drawing.Size(35, 13);
            this.lblSelectItems.TabIndex = 0;
            this.lblSelectItems.Text = "label1";
            // 
            // clbItems
            // 
            this.clbItems.CheckOnClick = true;
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(7, 24);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(556, 319);
            this.clbItems.TabIndex = 1;
            this.clbItems.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbItems_Format);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clbItems);
            this.Controls.Add(this.lblSelectItems);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectItems;
        private System.Windows.Forms.CheckedListBox clbItems;
    }
}
