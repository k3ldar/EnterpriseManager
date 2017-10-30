namespace POS.Marketing.Controls
{
    partial class CreateEmailStep8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEmailStep8));
            this.btnTestLink = new System.Windows.Forms.Button();
            this.txtWebLink = new System.Windows.Forms.TextBox();
            this.lblWebLink = new System.Windows.Forms.Label();
            this.rbCampaignManagerPage = new System.Windows.Forms.RadioButton();
            this.rbCustomWebPage = new System.Windows.Forms.RadioButton();
            this.selectProductControl1 = new Controls.SelectProductControl();
            this.selectProductControl2 = new Controls.SelectProductControl();
            this.selectProductControl3 = new Controls.SelectProductControl();
            this.selectProductControl4 = new Controls.SelectProductControl();
            this.SuspendLayout();
            // 
            // btnTestLink
            // 
            this.btnTestLink.Location = new System.Drawing.Point(488, 330);
            this.btnTestLink.Name = "btnTestLink";
            this.btnTestLink.Size = new System.Drawing.Size(75, 23);
            this.btnTestLink.TabIndex = 8;
            this.btnTestLink.Text = "Test Link";
            this.btnTestLink.UseVisualStyleBackColor = true;
            this.btnTestLink.Click += new System.EventHandler(this.btnTestLink_Click);
            // 
            // txtWebLink
            // 
            this.txtWebLink.Location = new System.Drawing.Point(84, 332);
            this.txtWebLink.Name = "txtWebLink";
            this.txtWebLink.Size = new System.Drawing.Size(398, 20);
            this.txtWebLink.TabIndex = 7;
            // 
            // lblWebLink
            // 
            this.lblWebLink.AutoSize = true;
            this.lblWebLink.Location = new System.Drawing.Point(4, 335);
            this.lblWebLink.Name = "lblWebLink";
            this.lblWebLink.Size = new System.Drawing.Size(46, 13);
            this.lblWebLink.TabIndex = 6;
            this.lblWebLink.Text = "Weblink";
            // 
            // rbCampaignManagerPage
            // 
            this.rbCampaignManagerPage.AutoSize = true;
            this.rbCampaignManagerPage.Checked = true;
            this.rbCampaignManagerPage.Location = new System.Drawing.Point(7, 13);
            this.rbCampaignManagerPage.Name = "rbCampaignManagerPage";
            this.rbCampaignManagerPage.Size = new System.Drawing.Size(163, 17);
            this.rbCampaignManagerPage.TabIndex = 9;
            this.rbCampaignManagerPage.TabStop = true;
            this.rbCampaignManagerPage.Text = "Default Campaign Web Page";
            this.rbCampaignManagerPage.UseVisualStyleBackColor = true;
            this.rbCampaignManagerPage.CheckedChanged += new System.EventHandler(this.rbCampaignManagerPage_CheckedChanged);
            // 
            // rbCustomWebPage
            // 
            this.rbCustomWebPage.AutoSize = true;
            this.rbCustomWebPage.Location = new System.Drawing.Point(212, 13);
            this.rbCustomWebPage.Name = "rbCustomWebPage";
            this.rbCustomWebPage.Size = new System.Drawing.Size(114, 17);
            this.rbCustomWebPage.TabIndex = 10;
            this.rbCustomWebPage.Text = "Custom Web Page";
            this.rbCustomWebPage.UseVisualStyleBackColor = true;
            this.rbCustomWebPage.CheckedChanged += new System.EventHandler(this.rbCampaignManagerPage_CheckedChanged);
            // 
            // selectProductControl1
            // 
            this.selectProductControl1.HintControl = null;
            this.selectProductControl1.Location = new System.Drawing.Point(0, 38);
            this.selectProductControl1.Name = "selectProductControl1";
            this.selectProductControl1.Size = new System.Drawing.Size(558, 59);
            this.selectProductControl1.TabIndex = 11;
            // 
            // selectProductControl2
            // 
            this.selectProductControl2.HintControl = null;
            this.selectProductControl2.Location = new System.Drawing.Point(0, 103);
            this.selectProductControl2.Name = "selectProductControl2";
            this.selectProductControl2.Size = new System.Drawing.Size(558, 59);
            this.selectProductControl2.TabIndex = 12;
            // 
            // selectProductControl3
            // 
            this.selectProductControl3.HintControl = null;
            this.selectProductControl3.Location = new System.Drawing.Point(0, 167);
            this.selectProductControl3.Name = "selectProductControl3";
            this.selectProductControl3.Size = new System.Drawing.Size(558, 59);
            this.selectProductControl3.TabIndex = 13;
            // 
            // selectProductControl4
            // 
            this.selectProductControl4.HintControl = null;
            this.selectProductControl4.Location = new System.Drawing.Point(0, 232);
            this.selectProductControl4.Name = "selectProductControl4";
            this.selectProductControl4.Size = new System.Drawing.Size(558, 59);
            this.selectProductControl4.TabIndex = 14;
            // 
            // CreateEmailStep4A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectProductControl4);
            this.Controls.Add(this.selectProductControl3);
            this.Controls.Add(this.selectProductControl2);
            this.Controls.Add(this.selectProductControl1);
            this.Controls.Add(this.rbCustomWebPage);
            this.Controls.Add(this.rbCampaignManagerPage);
            this.Controls.Add(this.btnTestLink);
            this.Controls.Add(this.txtWebLink);
            this.Controls.Add(this.lblWebLink);
            this.Name = "CreateEmailStep4A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestLink;
        private System.Windows.Forms.TextBox txtWebLink;
        private System.Windows.Forms.Label lblWebLink;
        private System.Windows.Forms.RadioButton rbCampaignManagerPage;
        private System.Windows.Forms.RadioButton rbCustomWebPage;
        private SelectProductControl selectProductControl1;
        private SelectProductControl selectProductControl2;
        private SelectProductControl selectProductControl3;
        private SelectProductControl selectProductControl4;
    }
}
