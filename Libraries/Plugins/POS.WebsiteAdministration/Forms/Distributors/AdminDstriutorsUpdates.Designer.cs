namespace POS.WebsiteAdministration.Forms.Distributors
{
    partial class AdminSalonUpdates
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstSalons = new SharedControls.Classes.ListViewEx();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabelCount.Text = "0 Salons Found";
            // 
            // lstSalons
            // 
            this.lstSalons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSalons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lstSalons.FullRowSelect = true;
            this.lstSalons.Location = new System.Drawing.Point(1, 1);
            this.lstSalons.Name = "lstSalons";
            this.lstSalons.Size = new System.Drawing.Size(558, 236);
            this.lstSalons.TabIndex = 20;
            this.lstSalons.UseCompatibleStateImageBehavior = false;
            this.lstSalons.View = System.Windows.Forms.View.Details;
            this.lstSalons.DoubleClick += new System.EventHandler(this.lstSalons_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Salon";
            this.columnHeader6.Width = 550;
            // 
            // AdminSalonUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 262);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstSalons);
            this.Name = "AdminSalonUpdates";
            this.Text = "AdminSalonUpdates";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private SharedControls.Classes.ListViewEx lstSalons;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}