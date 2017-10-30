namespace POS.Diary.Forms
{
    partial class SelectTreatmentsForm
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
            this.tabControlTreatments = new System.Windows.Forms.TabControl();
            this.tabPageAllTreatments = new System.Windows.Forms.TabPage();
            this.lstAllTreatments = new System.Windows.Forms.ListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tabPagePreviousTreatments = new System.Windows.Forms.TabPage();
            this.lstPreviousTreatments = new System.Windows.Forms.ListBox();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.lblSelectedTreatments = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControlTreatments.SuspendLayout();
            this.tabPageAllTreatments.SuspendLayout();
            this.tabPagePreviousTreatments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTreatments
            // 
            this.tabControlTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTreatments.Controls.Add(this.tabPageAllTreatments);
            this.tabControlTreatments.Controls.Add(this.tabPagePreviousTreatments);
            this.tabControlTreatments.Location = new System.Drawing.Point(11, 12);
            this.tabControlTreatments.Name = "tabControlTreatments";
            this.tabControlTreatments.SelectedIndex = 0;
            this.tabControlTreatments.Size = new System.Drawing.Size(388, 221);
            this.tabControlTreatments.TabIndex = 0;
            this.tabControlTreatments.SelectedIndexChanged += new System.EventHandler(this.tabControlTreatments_SelectedIndexChanged);
            // 
            // tabPageAllTreatments
            // 
            this.tabPageAllTreatments.Controls.Add(this.lstAllTreatments);
            this.tabPageAllTreatments.Controls.Add(this.txtFilter);
            this.tabPageAllTreatments.Controls.Add(this.lblFilter);
            this.tabPageAllTreatments.Location = new System.Drawing.Point(4, 22);
            this.tabPageAllTreatments.Name = "tabPageAllTreatments";
            this.tabPageAllTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllTreatments.Size = new System.Drawing.Size(380, 195);
            this.tabPageAllTreatments.TabIndex = 0;
            this.tabPageAllTreatments.Text = "All Treatments";
            this.tabPageAllTreatments.UseVisualStyleBackColor = true;
            // 
            // lstAllTreatments
            // 
            this.lstAllTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllTreatments.FormattingEnabled = true;
            this.lstAllTreatments.Location = new System.Drawing.Point(6, 39);
            this.lstAllTreatments.Name = "lstAllTreatments";
            this.lstAllTreatments.Size = new System.Drawing.Size(367, 147);
            this.lstAllTreatments.TabIndex = 1;
            this.lstAllTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAllTreatments_Format);
            this.lstAllTreatments.DoubleClick += new System.EventHandler(this.lstAllTreatments_DoubleClick);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(67, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(307, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 9);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // tabPagePreviousTreatments
            // 
            this.tabPagePreviousTreatments.Controls.Add(this.lstPreviousTreatments);
            this.tabPagePreviousTreatments.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreviousTreatments.Name = "tabPagePreviousTreatments";
            this.tabPagePreviousTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreviousTreatments.Size = new System.Drawing.Size(380, 195);
            this.tabPagePreviousTreatments.TabIndex = 1;
            this.tabPagePreviousTreatments.Text = "Previous Treatments";
            this.tabPagePreviousTreatments.UseVisualStyleBackColor = true;
            // 
            // lstPreviousTreatments
            // 
            this.lstPreviousTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPreviousTreatments.FormattingEnabled = true;
            this.lstPreviousTreatments.Location = new System.Drawing.Point(3, 3);
            this.lstPreviousTreatments.Name = "lstPreviousTreatments";
            this.lstPreviousTreatments.Size = new System.Drawing.Size(374, 186);
            this.lstPreviousTreatments.TabIndex = 0;
            this.lstPreviousTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAllTreatments_Format);
            this.lstPreviousTreatments.DoubleClick += new System.EventHandler(this.lstPreviousTreatments_DoubleClick);
            // 
            // lstSelected
            // 
            this.lstSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.Location = new System.Drawing.Point(11, 262);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(388, 82);
            this.lstSelected.TabIndex = 1;
            this.lstSelected.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAllTreatments_Format);
            this.lstSelected.DoubleClick += new System.EventHandler(this.lstSelected_DoubleClick);
            // 
            // lblSelectedTreatments
            // 
            this.lblSelectedTreatments.AutoSize = true;
            this.lblSelectedTreatments.Location = new System.Drawing.Point(12, 246);
            this.lblSelectedTreatments.Name = "lblSelectedTreatments";
            this.lblSelectedTreatments.Size = new System.Drawing.Size(105, 13);
            this.lblSelectedTreatments.TabIndex = 2;
            this.lblSelectedTreatments.Text = "Selected Treatments";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(324, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(243, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SelectTreatmentsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 389);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSelectedTreatments);
            this.Controls.Add(this.lstSelected);
            this.Controls.Add(this.tabControlTreatments);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(428, 427);
            this.Name = "SelectTreatmentsForm";
            this.SaveState = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Treatments";
            this.tabControlTreatments.ResumeLayout(false);
            this.tabPageAllTreatments.ResumeLayout(false);
            this.tabPageAllTreatments.PerformLayout();
            this.tabPagePreviousTreatments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTreatments;
        private System.Windows.Forms.TabPage tabPageAllTreatments;
        private System.Windows.Forms.TabPage tabPagePreviousTreatments;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Label lblSelectedTreatments;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstAllTreatments;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ListBox lstPreviousTreatments;
    }
}