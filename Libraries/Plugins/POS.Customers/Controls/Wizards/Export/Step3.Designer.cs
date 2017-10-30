namespace POS.Customers.Controls.Wizards.Export
{
    partial class Step3
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
            this.lblMemberLevel = new System.Windows.Forms.Label();
            this.cmbMemberLevel = new System.Windows.Forms.ComboBox();
            this.rbLevelEqualBelow = new System.Windows.Forms.RadioButton();
            this.rbLevelEqual = new System.Windows.Forms.RadioButton();
            this.rbLevelAbove = new System.Windows.Forms.RadioButton();
            this.rbLevelBelow = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblMemberLevel
            // 
            this.lblMemberLevel.AutoSize = true;
            this.lblMemberLevel.Location = new System.Drawing.Point(4, 4);
            this.lblMemberLevel.Name = "lblMemberLevel";
            this.lblMemberLevel.Size = new System.Drawing.Size(217, 13);
            this.lblMemberLevel.TabIndex = 0;
            this.lblMemberLevel.Text = "Select the member level for records to export";
            // 
            // cmbMemberLevel
            // 
            this.cmbMemberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberLevel.FormattingEnabled = true;
            this.cmbMemberLevel.Location = new System.Drawing.Point(7, 21);
            this.cmbMemberLevel.Name = "cmbMemberLevel";
            this.cmbMemberLevel.Size = new System.Drawing.Size(214, 21);
            this.cmbMemberLevel.TabIndex = 1;
            this.cmbMemberLevel.SelectedIndexChanged += new System.EventHandler(this.cmbMemberLevel_SelectedIndexChanged);
            // 
            // rbLevelEqualBelow
            // 
            this.rbLevelEqualBelow.AutoSize = true;
            this.rbLevelEqualBelow.Checked = true;
            this.rbLevelEqualBelow.Location = new System.Drawing.Point(7, 88);
            this.rbLevelEqualBelow.Name = "rbLevelEqualBelow";
            this.rbLevelEqualBelow.Size = new System.Drawing.Size(177, 17);
            this.rbLevelEqualBelow.TabIndex = 3;
            this.rbLevelEqualBelow.TabStop = true;
            this.rbLevelEqualBelow.Text = "Equal to or below Member Level";
            this.rbLevelEqualBelow.UseVisualStyleBackColor = true;
            // 
            // rbLevelEqual
            // 
            this.rbLevelEqual.AutoSize = true;
            this.rbLevelEqual.Location = new System.Drawing.Point(7, 112);
            this.rbLevelEqual.Name = "rbLevelEqual";
            this.rbLevelEqual.Size = new System.Drawing.Size(129, 17);
            this.rbLevelEqual.TabIndex = 4;
            this.rbLevelEqual.Text = "Equal to member level";
            this.rbLevelEqual.UseVisualStyleBackColor = true;
            // 
            // rbLevelAbove
            // 
            this.rbLevelAbove.AutoSize = true;
            this.rbLevelAbove.Location = new System.Drawing.Point(7, 136);
            this.rbLevelAbove.Name = "rbLevelAbove";
            this.rbLevelAbove.Size = new System.Drawing.Size(122, 17);
            this.rbLevelAbove.TabIndex = 5;
            this.rbLevelAbove.Text = "Above Member level";
            this.rbLevelAbove.UseVisualStyleBackColor = true;
            // 
            // rbLevelBelow
            // 
            this.rbLevelBelow.AutoSize = true;
            this.rbLevelBelow.Location = new System.Drawing.Point(7, 64);
            this.rbLevelBelow.Name = "rbLevelBelow";
            this.rbLevelBelow.Size = new System.Drawing.Size(124, 17);
            this.rbLevelBelow.TabIndex = 2;
            this.rbLevelBelow.Text = "Below Member Level";
            this.rbLevelBelow.UseVisualStyleBackColor = true;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbLevelAbove);
            this.Controls.Add(this.rbLevelEqual);
            this.Controls.Add(this.rbLevelEqualBelow);
            this.Controls.Add(this.rbLevelBelow);
            this.Controls.Add(this.cmbMemberLevel);
            this.Controls.Add(this.lblMemberLevel);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMemberLevel;
        private System.Windows.Forms.ComboBox cmbMemberLevel;
        private System.Windows.Forms.RadioButton rbLevelEqualBelow;
        private System.Windows.Forms.RadioButton rbLevelEqual;
        private System.Windows.Forms.RadioButton rbLevelAbove;
        private System.Windows.Forms.RadioButton rbLevelBelow;
    }
}
