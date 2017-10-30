namespace POS.Administration.Controls
{
    partial class ProductEditText
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
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblSentences = new System.Windows.Forms.Label();
            this.lblParagraphs = new System.Windows.Forms.Label();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbLanguageActive = new System.Windows.Forms.CheckBox();
            this.btnSaveTranslation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(74, 188);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(155, 21);
            this.cmbLanguage.TabIndex = 51;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            this.cmbLanguage.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbLanguage_Format);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(3, 191);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 50;
            this.lblLanguage.Text = "Language";
            // 
            // lblSentences
            // 
            this.lblSentences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSentences.AutoSize = true;
            this.lblSentences.Location = new System.Drawing.Point(327, 219);
            this.lblSentences.Name = "lblSentences";
            this.lblSentences.Size = new System.Drawing.Size(70, 13);
            this.lblSentences.TabIndex = 49;
            this.lblSentences.Text = "Sentences: 0";
            // 
            // lblParagraphs
            // 
            this.lblParagraphs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblParagraphs.AutoSize = true;
            this.lblParagraphs.Location = new System.Drawing.Point(226, 219);
            this.lblParagraphs.Name = "lblParagraphs";
            this.lblParagraphs.Size = new System.Drawing.Size(73, 13);
            this.lblParagraphs.TabIndex = 48;
            this.lblParagraphs.Text = "Paragraphs: 0";
            // 
            // lblWordCount
            // 
            this.lblWordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(145, 219);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(50, 13);
            this.lblWordCount.TabIndex = 47;
            this.lblWordCount.Text = "Words: 0";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 219);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(42, 13);
            this.lblSize.TabIndex = 46;
            this.lblSize.Text = "0/4000";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.MaxLength = 4000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(456, 179);
            this.txtDescription.TabIndex = 45;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // cbLanguageActive
            // 
            this.cbLanguageActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLanguageActive.AutoSize = true;
            this.cbLanguageActive.Location = new System.Drawing.Point(252, 190);
            this.cbLanguageActive.Name = "cbLanguageActive";
            this.cbLanguageActive.Size = new System.Drawing.Size(107, 17);
            this.cbLanguageActive.TabIndex = 52;
            this.cbLanguageActive.Text = "Language Active";
            this.cbLanguageActive.UseVisualStyleBackColor = true;
            // 
            // btnSaveTranslation
            // 
            this.btnSaveTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTranslation.Location = new System.Drawing.Point(365, 188);
            this.btnSaveTranslation.Name = "btnSaveTranslation";
            this.btnSaveTranslation.Size = new System.Drawing.Size(95, 23);
            this.btnSaveTranslation.TabIndex = 53;
            this.btnSaveTranslation.Text = "Save Translation";
            this.btnSaveTranslation.UseVisualStyleBackColor = true;
            this.btnSaveTranslation.Click += new System.EventHandler(this.btnSaveTranslation_Click);
            // 
            // ProductEditText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveTranslation);
            this.Controls.Add(this.cbLanguageActive);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblSentences);
            this.Controls.Add(this.lblParagraphs);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtDescription);
            this.Name = "ProductEditText";
            this.Size = new System.Drawing.Size(462, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblSentences;
        private System.Windows.Forms.Label lblParagraphs;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox cbLanguageActive;
        private System.Windows.Forms.Button btnSaveTranslation;
    }
}
