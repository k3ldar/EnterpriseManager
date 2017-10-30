namespace POS.Administration.Controls
{
    partial class AdminProductItem
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
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(4, 6);
            this.txtSKU.MaxLength = 10;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(77, 20);
            this.txtSKU.TabIndex = 0;
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(87, 6);
            this.txtSize.MaxLength = 60;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(215, 20);
            this.txtSize.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(525, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(583, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(308, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "label1";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(460, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // AdminProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtSKU);
            this.Name = "AdminProductItem";
            this.Size = new System.Drawing.Size(642, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnRemove;
    }
}
