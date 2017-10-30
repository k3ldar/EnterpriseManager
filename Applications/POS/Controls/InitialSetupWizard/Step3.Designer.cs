namespace PointOfSale.Controls.InitialSetupWizard
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
            this.pnlDragDrop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.selectImageFiles = new System.Windows.Forms.OpenFileDialog();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDragDrop
            // 
            this.pnlDragDrop.AllowDrop = true;
            this.pnlDragDrop.Location = new System.Drawing.Point(3, 27);
            this.pnlDragDrop.Name = "pnlDragDrop";
            this.pnlDragDrop.Size = new System.Drawing.Size(560, 77);
            this.pnlDragDrop.TabIndex = 0;
            this.pnlDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDragDrop_DragDrop);
            this.pnlDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDragDrop_DragEnter);
            this.pnlDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDragDrop_Paint);
            this.pnlDragDrop.DoubleClick += new System.EventHandler(this.pnlDragDrop_DoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(89, 24);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Welcome";
            // 
            // selectImageFiles
            // 
            this.selectImageFiles.Multiselect = true;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(3, 111);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(560, 242);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 3;
            this.pictureLogo.TabStop = false;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pnlDragDrop);
            this.Name = "Step3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDragDrop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.OpenFileDialog selectImageFiles;
        private System.Windows.Forms.PictureBox pictureLogo;
    }
}
