namespace POS.Images.Controls
{
    partial class ImagesTab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagesTab));
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.tvImages = new SharedControls.Controls.TreeViewEx();
            this.imageListFolders = new System.Windows.Forms.ImageList(this.components);
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.flowImage = new System.Windows.Forms.FlowLayoutPanel();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.flowImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDragDrop = new System.Windows.Forms.Panel();
            this.pnlSaveImages = new System.Windows.Forms.Panel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblNewFileName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.selectImageFiles = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuImages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.flowPicture = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlRoot.SuspendLayout();
            this.pnlSaveImages.SuspendLayout();
            this.contextMenuImages.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.flowPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter.IsSplitterFixed = true;
            this.splitter.Location = new System.Drawing.Point(3, 3);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.tvImages);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.pnlImage);
            this.splitter.Panel2.Controls.Add(this.pnlRoot);
            this.splitter.Size = new System.Drawing.Size(902, 321);
            this.splitter.SplitterDistance = 268;
            this.splitter.TabIndex = 1;
            // 
            // tvImages
            // 
            this.tvImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvImages.HideSelection = false;
            this.tvImages.ImageIndex = 0;
            this.tvImages.ImageList = this.imageListFolders;
            this.tvImages.Location = new System.Drawing.Point(3, 3);
            this.tvImages.Name = "tvImages";
            this.tvImages.SelectedImageIndex = 0;
            this.tvImages.Size = new System.Drawing.Size(262, 315);
            this.tvImages.TabIndex = 0;
            this.tvImages.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvImages_AfterCollapse);
            this.tvImages.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvImages_AfterExpand);
            this.tvImages.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvImages_BeforeSelect);
            this.tvImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvImages_AfterSelect);
            // 
            // imageListFolders
            // 
            this.imageListFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFolders.ImageStream")));
            this.imageListFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFolders.Images.SetKeyName(0, "folder_Closed_16xLG.png");
            this.imageListFolders.Images.SetKeyName(1, "folder_Open_16xLG.png");
            this.imageListFolders.Images.SetKeyName(2, "resource_16xLG.png");
            this.imageListFolders.Images.SetKeyName(3, "globe_16xLG.png");
            // 
            // pnlRoot
            // 
            this.pnlRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRoot.Controls.Add(this.flowImage);
            this.pnlRoot.Controls.Add(this.lstMessages);
            this.pnlRoot.Controls.Add(this.flowImages);
            this.pnlRoot.Controls.Add(this.pnlDragDrop);
            this.pnlRoot.Controls.Add(this.pnlSaveImages);
            this.pnlRoot.Location = new System.Drawing.Point(3, 3);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(624, 309);
            this.pnlRoot.TabIndex = 5;
            // 
            // flowImage
            // 
            this.flowImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowImage.AutoScroll = true;
            this.flowImage.Location = new System.Drawing.Point(360, 110);
            this.flowImage.Name = "flowImage";
            this.flowImage.Size = new System.Drawing.Size(261, 48);
            this.flowImage.TabIndex = 4;
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(4, 224);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(617, 82);
            this.lstMessages.TabIndex = 1;
            // 
            // flowImages
            // 
            this.flowImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowImages.AutoScroll = true;
            this.flowImages.Location = new System.Drawing.Point(4, 109);
            this.flowImages.Name = "flowImages";
            this.flowImages.Size = new System.Drawing.Size(350, 109);
            this.flowImages.TabIndex = 2;
            // 
            // pnlDragDrop
            // 
            this.pnlDragDrop.AllowDrop = true;
            this.pnlDragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDragDrop.Location = new System.Drawing.Point(4, 4);
            this.pnlDragDrop.Name = "pnlDragDrop";
            this.pnlDragDrop.Size = new System.Drawing.Size(617, 100);
            this.pnlDragDrop.TabIndex = 0;
            this.pnlDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDragDrop_DragDrop);
            this.pnlDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDragDrop_DragEnter);
            this.pnlDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDragDrop_Paint);
            this.pnlDragDrop.DoubleClick += new System.EventHandler(this.pnlDragDrop_DoubleClick);
            // 
            // pnlSaveImages
            // 
            this.pnlSaveImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSaveImages.Controls.Add(this.txtFileName);
            this.pnlSaveImages.Controls.Add(this.lblNewFileName);
            this.pnlSaveImages.Controls.Add(this.btnSave);
            this.pnlSaveImages.Location = new System.Drawing.Point(360, 164);
            this.pnlSaveImages.Name = "pnlSaveImages";
            this.pnlSaveImages.Size = new System.Drawing.Size(261, 54);
            this.pnlSaveImages.TabIndex = 3;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(6, 31);
            this.txtFileName.MaxLength = 150;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(150, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // lblNewFileName
            // 
            this.lblNewFileName.AutoSize = true;
            this.lblNewFileName.Location = new System.Drawing.Point(3, 8);
            this.lblNewFileName.Name = "lblNewFileName";
            this.lblNewFileName.Size = new System.Drawing.Size(35, 13);
            this.lblNewFileName.TabIndex = 1;
            this.lblNewFileName.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(162, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // selectImageFiles
            // 
            this.selectImageFiles.Multiselect = true;
            // 
            // contextMenuImages
            // 
            this.contextMenuImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearAllToolStripMenuItem});
            this.contextMenuImages.Name = "contextMenuImages";
            this.contextMenuImages.Size = new System.Drawing.Size(119, 54);
            this.contextMenuImages.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuImages_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // pnlImage
            // 
            this.pnlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImage.Controls.Add(this.flowPicture);
            this.pnlImage.Location = new System.Drawing.Point(3, 10);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(624, 302);
            this.pnlImage.TabIndex = 6;
            // 
            // flowPicture
            // 
            this.flowPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPicture.AutoScroll = true;
            this.flowPicture.Controls.Add(this.pictureImage);
            this.flowPicture.Location = new System.Drawing.Point(8, 4);
            this.flowPicture.Name = "flowPicture";
            this.flowPicture.Size = new System.Drawing.Size(610, 295);
            this.flowPicture.TabIndex = 0;
            // 
            // pictureImage
            // 
            this.pictureImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureImage.Location = new System.Drawing.Point(3, 3);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(100, 50);
            this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureImage.TabIndex = 0;
            this.pictureImage.TabStop = false;
            // 
            // ImagesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Name = "ImagesTab";
            this.Size = new System.Drawing.Size(908, 327);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.pnlRoot.ResumeLayout(false);
            this.pnlSaveImages.ResumeLayout(false);
            this.pnlSaveImages.PerformLayout();
            this.contextMenuImages.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.flowPicture.ResumeLayout(false);
            this.flowPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitter;
        private SharedControls.Controls.TreeViewEx tvImages;
        private System.Windows.Forms.ImageList imageListFolders;
        private System.Windows.Forms.Panel pnlDragDrop;
        private System.Windows.Forms.OpenFileDialog selectImageFiles;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.FlowLayoutPanel flowImages;
        private System.Windows.Forms.ContextMenuStrip contextMenuImages;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowImage;
        private System.Windows.Forms.Panel pnlSaveImages;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblNewFileName;
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.FlowLayoutPanel flowPicture;
        private System.Windows.Forms.PictureBox pictureImage;
    }
}
