namespace POS.AutoUpdate.Controls.Wizards.AddRule
{
    partial class Step1
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
            this.lblSelectRule = new System.Windows.Forms.Label();
            this.cmbRules = new System.Windows.Forms.ComboBox();
            this.lblRuleDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelectRule
            // 
            this.lblSelectRule.AutoSize = true;
            this.lblSelectRule.Location = new System.Drawing.Point(4, 4);
            this.lblSelectRule.Name = "lblSelectRule";
            this.lblSelectRule.Size = new System.Drawing.Size(35, 13);
            this.lblSelectRule.TabIndex = 0;
            this.lblSelectRule.Text = "label1";
            // 
            // cmbRules
            // 
            this.cmbRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRules.FormattingEnabled = true;
            this.cmbRules.Location = new System.Drawing.Point(7, 21);
            this.cmbRules.Name = "cmbRules";
            this.cmbRules.Size = new System.Drawing.Size(427, 21);
            this.cmbRules.TabIndex = 1;
            this.cmbRules.SelectedIndexChanged += new System.EventHandler(this.cmbRules_SelectedIndexChanged);
            this.cmbRules.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbRules_Format);
            // 
            // lblRuleDescription
            // 
            this.lblRuleDescription.AutoSize = true;
            this.lblRuleDescription.Location = new System.Drawing.Point(7, 61);
            this.lblRuleDescription.Name = "lblRuleDescription";
            this.lblRuleDescription.Size = new System.Drawing.Size(35, 13);
            this.lblRuleDescription.TabIndex = 2;
            this.lblRuleDescription.Text = "label2";
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRuleDescription);
            this.Controls.Add(this.cmbRules);
            this.Controls.Add(this.lblSelectRule);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectRule;
        private System.Windows.Forms.ComboBox cmbRules;
        private System.Windows.Forms.Label lblRuleDescription;
    }
}
