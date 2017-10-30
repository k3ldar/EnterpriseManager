namespace POS.Till.Forms
{
    partial class MainScreenPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreenPOS));
            this.tillControl = new POS.Till.Controls.TillControl();
            this.SuspendLayout();
            // 
            // tillControl
            // 
            this.tillControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tillControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tillControl.HintControl = null;
            this.tillControl.Location = new System.Drawing.Point(2, 2);
            this.tillControl.MinimumSize = new System.Drawing.Size(822, 646);
            this.tillControl.Name = "tillControl";
            this.tillControl.Size = new System.Drawing.Size(855, 727);
            this.tillControl.TabIndex = 0;
            // 
            // MainScreenPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 741);
            this.Controls.Add(this.tillControl);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(822, 646);
            this.Name = "MainScreenPOS";
            this.SaveState = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shifoo Small Business Manager";
            this.Activated += new System.EventHandler(this.MainScreen_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreenPOS_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainScreenPOS_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainScreen_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TillControl tillControl;
    }
}

