namespace POS.Orders.Controls
{
    partial class PrintSettings
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
            this.gbLabelPrinter = new System.Windows.Forms.GroupBox();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.gbLabelPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLabelPrinter
            // 
            this.gbLabelPrinter.Controls.Add(this.cmbLabelPrinter);
            this.gbLabelPrinter.Location = new System.Drawing.Point(3, 3);
            this.gbLabelPrinter.Name = "gbLabelPrinter";
            this.gbLabelPrinter.Size = new System.Drawing.Size(452, 55);
            this.gbLabelPrinter.TabIndex = 7;
            this.gbLabelPrinter.TabStop = false;
            this.gbLabelPrinter.Text = "Label Printer";
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(9, 19);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(433, 21);
            this.cmbLabelPrinter.TabIndex = 5;
            // 
            // PrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLabelPrinter);
            this.Name = "PrintSettings";
            this.gbLabelPrinter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLabelPrinter;
        private System.Windows.Forms.ComboBox cmbLabelPrinter;
    }
}
