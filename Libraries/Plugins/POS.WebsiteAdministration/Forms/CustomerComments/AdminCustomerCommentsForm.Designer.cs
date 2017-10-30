namespace POS.WebsiteAdministration.Forms.CustomerComments
{
    partial class AdminCustomerCommentsForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.cbShowOnWebsite = new System.Windows.Forms.CheckBox();
            this.lvComments = new SharedControls.Classes.ListViewEx();
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderShowOnWebsite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAllComments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(344, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(347, 48);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(393, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(344, 108);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 5;
            this.lblComments.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(347, 124);
            this.txtComments.MaxLength = 3000;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComments.Size = new System.Drawing.Size(393, 383);
            this.txtComments.TabIndex = 6;
            // 
            // cbShowOnWebsite
            // 
            this.cbShowOnWebsite.AutoSize = true;
            this.cbShowOnWebsite.Location = new System.Drawing.Point(347, 83);
            this.cbShowOnWebsite.Name = "cbShowOnWebsite";
            this.cbShowOnWebsite.Size = new System.Drawing.Size(107, 17);
            this.cbShowOnWebsite.TabIndex = 4;
            this.cbShowOnWebsite.Text = "Show on website";
            this.cbShowOnWebsite.UseVisualStyleBackColor = true;
            // 
            // lvComments
            // 
            this.lvComments.AllowColumnReorder = true;
            this.lvComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvComments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderName,
            this.colHeaderShowOnWebsite});
            this.lvComments.FullRowSelect = true;
            this.lvComments.HideSelection = false;
            this.lvComments.Location = new System.Drawing.Point(6, 48);
            this.lvComments.MultiSelect = false;
            this.lvComments.Name = "lvComments";
            this.lvComments.OwnerDraw = true;
            this.lvComments.SaveName = "";
            this.lvComments.ShowToolTip = false;
            this.lvComments.Size = new System.Drawing.Size(328, 459);
            this.lvComments.TabIndex = 1;
            this.lvComments.UseCompatibleStateImageBehavior = false;
            this.lvComments.View = System.Windows.Forms.View.Details;
            this.lvComments.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvComments_ItemSelectionChanged);
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Name";
            this.colHeaderName.Width = 220;
            // 
            // colHeaderShowOnWebsite
            // 
            this.colHeaderShowOnWebsite.Text = "Show";
            this.colHeaderShowOnWebsite.Width = 120;
            // 
            // lblAllComments
            // 
            this.lblAllComments.AutoSize = true;
            this.lblAllComments.Location = new System.Drawing.Point(3, 30);
            this.lblAllComments.Name = "lblAllComments";
            this.lblAllComments.Size = new System.Drawing.Size(70, 13);
            this.lblAllComments.TabIndex = 0;
            this.lblAllComments.Text = "All Comments";
            // 
            // AdminCustomerCommentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAllComments);
            this.Controls.Add(this.lvComments);
            this.Controls.Add(this.cbShowOnWebsite);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.MinimumSize = new System.Drawing.Size(743, 510);
            this.Name = "AdminCustomerCommentsForm";
            this.Size = new System.Drawing.Size(743, 510);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblComments, 0);
            this.Controls.SetChildIndex(this.txtComments, 0);
            this.Controls.SetChildIndex(this.cbShowOnWebsite, 0);
            this.Controls.SetChildIndex(this.lvComments, 0);
            this.Controls.SetChildIndex(this.lblAllComments, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.CheckBox cbShowOnWebsite;
        private SharedControls.Classes.ListViewEx lvComments;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderShowOnWebsite;
        private System.Windows.Forms.Label lblAllComments;
    }
}