namespace POS.Base.Controls
{
    partial class SEOSettings
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblMetaDescription = new System.Windows.Forms.Label();
            this.txtMetaDescription = new System.Windows.Forms.TextBox();
            this.lblAvailableTags = new System.Windows.Forms.Label();
            this.lstAvailableTags = new System.Windows.Forms.ListBox();
            this.lstSelectedTags = new System.Windows.Forms.ListBox();
            this.lblSelectedTags = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "lblTitle";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(7, 21);
            this.txtTitle.MaxLength = 150;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(319, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblMetaDescription
            // 
            this.lblMetaDescription.AutoSize = true;
            this.lblMetaDescription.Location = new System.Drawing.Point(4, 52);
            this.lblMetaDescription.Name = "lblMetaDescription";
            this.lblMetaDescription.Size = new System.Drawing.Size(35, 13);
            this.lblMetaDescription.TabIndex = 2;
            this.lblMetaDescription.Text = "label2";
            // 
            // txtMetaDescription
            // 
            this.txtMetaDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetaDescription.Location = new System.Drawing.Point(7, 68);
            this.txtMetaDescription.MaxLength = 250;
            this.txtMetaDescription.Name = "txtMetaDescription";
            this.txtMetaDescription.Size = new System.Drawing.Size(319, 20);
            this.txtMetaDescription.TabIndex = 3;
            // 
            // lblAvailableTags
            // 
            this.lblAvailableTags.AutoSize = true;
            this.lblAvailableTags.Location = new System.Drawing.Point(4, 104);
            this.lblAvailableTags.Name = "lblAvailableTags";
            this.lblAvailableTags.Size = new System.Drawing.Size(35, 13);
            this.lblAvailableTags.TabIndex = 4;
            this.lblAvailableTags.Text = "label3";
            // 
            // lstAvailableTags
            // 
            this.lstAvailableTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableTags.FormattingEnabled = true;
            this.lstAvailableTags.Location = new System.Drawing.Point(7, 121);
            this.lstAvailableTags.MultiColumn = true;
            this.lstAvailableTags.Name = "lstAvailableTags";
            this.lstAvailableTags.Size = new System.Drawing.Size(132, 173);
            this.lstAvailableTags.TabIndex = 5;
            this.lstAvailableTags.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailableTags_Format);
            this.lstAvailableTags.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSelectedTags
            // 
            this.lstSelectedTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedTags.FormattingEnabled = true;
            this.lstSelectedTags.Location = new System.Drawing.Point(183, 121);
            this.lstSelectedTags.MultiColumn = true;
            this.lstSelectedTags.Name = "lstSelectedTags";
            this.lstSelectedTags.Size = new System.Drawing.Size(143, 173);
            this.lstSelectedTags.TabIndex = 10;
            this.lstSelectedTags.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailableTags_Format);
            this.lstSelectedTags.DoubleClick += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblSelectedTags
            // 
            this.lblSelectedTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedTags.AutoSize = true;
            this.lblSelectedTags.Location = new System.Drawing.Point(180, 104);
            this.lblSelectedTags.Name = "lblSelectedTags";
            this.lblSelectedTags.Size = new System.Drawing.Size(35, 13);
            this.lblSelectedTags.TabIndex = 9;
            this.lblSelectedTags.Text = "label3";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(146, 158);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(146, 187);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(31, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(146, 216);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(31, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "+";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // SEOSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSelectedTags);
            this.Controls.Add(this.lblSelectedTags);
            this.Controls.Add(this.lstAvailableTags);
            this.Controls.Add(this.lblAvailableTags);
            this.Controls.Add(this.txtMetaDescription);
            this.Controls.Add(this.lblMetaDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new System.Drawing.Size(329, 302);
            this.Name = "SEOSettings";
            this.Size = new System.Drawing.Size(329, 302);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblMetaDescription;
        private System.Windows.Forms.TextBox txtMetaDescription;
        private System.Windows.Forms.Label lblAvailableTags;
        private System.Windows.Forms.ListBox lstAvailableTags;
        private System.Windows.Forms.ListBox lstSelectedTags;
        private System.Windows.Forms.Label lblSelectedTags;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCreate;
    }
}
