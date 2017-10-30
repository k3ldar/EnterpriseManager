namespace POS.WebsiteAdministration.Forms.Website
{
    partial class AdminVideos
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
            this.pnlItems = new System.Windows.Forms.Panel();
            this.txtVideoReference = new SharedControls.TextBoxEx();
            this.lblVideoReference = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lvItems = new SharedControls.Classes.ListViewEx();
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlItems
            // 
            this.pnlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItems.Controls.Add(this.txtVideoReference);
            this.pnlItems.Controls.Add(this.lblVideoReference);
            this.pnlItems.Controls.Add(this.txtDescription);
            this.pnlItems.Controls.Add(this.lblDescription);
            this.pnlItems.Location = new System.Drawing.Point(243, 28);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(445, 323);
            this.pnlItems.TabIndex = 9;
            // 
            // txtVideoReference
            // 
            this.txtVideoReference.AllowBackSpace = true;
            this.txtVideoReference.AllowCopy = true;
            this.txtVideoReference.AllowCut = true;
            this.txtVideoReference.AllowedCharacters = null;
            this.txtVideoReference.AllowPaste = true;
            this.txtVideoReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoReference.Location = new System.Drawing.Point(7, 171);
            this.txtVideoReference.MaxLength = 50;
            this.txtVideoReference.Name = "txtVideoReference";
            this.txtVideoReference.RaiseCustomPasteEvent = true;
            this.txtVideoReference.Size = new System.Drawing.Size(435, 20);
            this.txtVideoReference.TabIndex = 3;
            this.txtVideoReference.OnPaste += new SharedControls.CustomPasteEventHandler(this.txtVideoReference_OnPaste);
            this.txtVideoReference.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblVideoReference
            // 
            this.lblVideoReference.AutoSize = true;
            this.lblVideoReference.Location = new System.Drawing.Point(4, 155);
            this.lblVideoReference.Name = "lblVideoReference";
            this.lblVideoReference.Size = new System.Drawing.Size(87, 13);
            this.lblVideoReference.TabIndex = 2;
            this.lblVideoReference.Text = "Video Reference";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(7, 21);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(435, 120);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // lvItems
            // 
            this.lvItems.AllowColumnReorder = true;
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDescription});
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(3, 28);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.OwnerDraw = true;
            this.lvItems.SaveName = "";
            this.lvItems.ShowToolTip = false;
            this.lvItems.Size = new System.Drawing.Size(234, 323);
            this.lvItems.TabIndex = 6;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvItems_ItemSelectionChanged);
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 300;
            // 
            // AdminVideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.lvItems);
            this.Name = "AdminVideos";
            this.Size = new System.Drawing.Size(691, 354);
            this.Controls.SetChildIndex(this.lvItems, 0);
            this.Controls.SetChildIndex(this.pnlItems, 0);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlItems;
        private SharedControls.Classes.ListViewEx lvItems;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private SharedControls.TextBoxEx txtVideoReference;
        private System.Windows.Forms.Label lblVideoReference;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}