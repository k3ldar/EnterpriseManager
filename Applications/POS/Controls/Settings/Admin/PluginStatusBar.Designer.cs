namespace PointOfSale.Controls.Settings.Admin
{
    partial class PluginStatusBar
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
            this.flowPanelAvailable = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAvailableStatusBar = new System.Windows.Forms.Label();
            this.flowPanelSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSelectedStatusBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowPanelAvailable
            // 
            this.flowPanelAvailable.AllowDrop = true;
            this.flowPanelAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelAvailable.AutoScroll = true;
            this.flowPanelAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelAvailable.Location = new System.Drawing.Point(4, 23);
            this.flowPanelAvailable.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.flowPanelAvailable.Name = "flowPanelAvailable";
            this.flowPanelAvailable.Size = new System.Drawing.Size(453, 177);
            this.flowPanelAvailable.TabIndex = 0;
            this.flowPanelAvailable.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowPanelSelected_DragDrop);
            this.flowPanelAvailable.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowPanelSelected_DragEnter);
            // 
            // lblAvailableStatusBar
            // 
            this.lblAvailableStatusBar.AutoSize = true;
            this.lblAvailableStatusBar.Location = new System.Drawing.Point(4, 4);
            this.lblAvailableStatusBar.Name = "lblAvailableStatusBar";
            this.lblAvailableStatusBar.Size = new System.Drawing.Size(35, 13);
            this.lblAvailableStatusBar.TabIndex = 1;
            this.lblAvailableStatusBar.Text = "label1";
            // 
            // flowPanelSelected
            // 
            this.flowPanelSelected.AllowDrop = true;
            this.flowPanelSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelSelected.Location = new System.Drawing.Point(0, 251);
            this.flowPanelSelected.Name = "flowPanelSelected";
            this.flowPanelSelected.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowPanelSelected.Size = new System.Drawing.Size(453, 86);
            this.flowPanelSelected.TabIndex = 2;
            this.flowPanelSelected.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowPanelSelected_DragDrop);
            this.flowPanelSelected.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowPanelSelected_DragEnter);
            // 
            // lblSelectedStatusBar
            // 
            this.lblSelectedStatusBar.AutoSize = true;
            this.lblSelectedStatusBar.Location = new System.Drawing.Point(3, 232);
            this.lblSelectedStatusBar.Name = "lblSelectedStatusBar";
            this.lblSelectedStatusBar.Size = new System.Drawing.Size(35, 13);
            this.lblSelectedStatusBar.TabIndex = 3;
            this.lblSelectedStatusBar.Text = "label1";
            // 
            // PluginStatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedStatusBar);
            this.Controls.Add(this.flowPanelSelected);
            this.Controls.Add(this.lblAvailableStatusBar);
            this.Controls.Add(this.flowPanelAvailable);
            this.Name = "PluginStatusBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelAvailable;
        private System.Windows.Forms.Label lblAvailableStatusBar;
        private System.Windows.Forms.FlowLayoutPanel flowPanelSelected;
        private System.Windows.Forms.Label lblSelectedStatusBar;
    }
}
