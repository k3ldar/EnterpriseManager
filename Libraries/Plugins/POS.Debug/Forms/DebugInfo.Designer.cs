namespace POS.Debug.Forms
{
    partial class DebugInfo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLoadModules = new System.Windows.Forms.Button();
            this.lstModules = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRefreshThreads = new System.Windows.Forms.Button();
            this.lstThreads = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRefreshCache = new System.Windows.Forms.Button();
            this.lstCache = new System.Windows.Forms.ListBox();
            this.tabPageDebugTrace = new System.Windows.Forms.TabPage();
            this.lstTrace = new System.Windows.Forms.ListBox();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.colEventDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventParam1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventParam2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventParam3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventParam4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPageDebugTrace.SuspendLayout();
            this.tabPageEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPageDebugTrace);
            this.tabControl1.Controls.Add(this.tabPageEvents);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 348);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLoadModules);
            this.tabPage1.Controls.Add(this.lstModules);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Modules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLoadModules
            // 
            this.btnLoadModules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadModules.Location = new System.Drawing.Point(471, 293);
            this.btnLoadModules.Name = "btnLoadModules";
            this.btnLoadModules.Size = new System.Drawing.Size(75, 23);
            this.btnLoadModules.TabIndex = 1;
            this.btnLoadModules.Text = "Refresh";
            this.btnLoadModules.UseVisualStyleBackColor = true;
            this.btnLoadModules.Click += new System.EventHandler(this.btnLoadModules_Click);
            // 
            // lstModules
            // 
            this.lstModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstModules.FormattingEnabled = true;
            this.lstModules.Location = new System.Drawing.Point(6, 6);
            this.lstModules.Name = "lstModules";
            this.lstModules.Size = new System.Drawing.Size(540, 277);
            this.lstModules.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRefreshThreads);
            this.tabPage2.Controls.Add(this.lstThreads);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Threads";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefreshThreads
            // 
            this.btnRefreshThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshThreads.Location = new System.Drawing.Point(471, 293);
            this.btnRefreshThreads.Name = "btnRefreshThreads";
            this.btnRefreshThreads.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshThreads.TabIndex = 1;
            this.btnRefreshThreads.Text = "Refresh";
            this.btnRefreshThreads.UseVisualStyleBackColor = true;
            this.btnRefreshThreads.Click += new System.EventHandler(this.btnRefreshThreads_Click);
            // 
            // lstThreads
            // 
            this.lstThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstThreads.FormattingEnabled = true;
            this.lstThreads.Location = new System.Drawing.Point(7, 7);
            this.lstThreads.Name = "lstThreads";
            this.lstThreads.Size = new System.Drawing.Size(539, 277);
            this.lstThreads.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRefreshCache);
            this.tabPage3.Controls.Add(this.lstCache);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(552, 322);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Memory Cache";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCache
            // 
            this.btnRefreshCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCache.Location = new System.Drawing.Point(471, 290);
            this.btnRefreshCache.Name = "btnRefreshCache";
            this.btnRefreshCache.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshCache.TabIndex = 1;
            this.btnRefreshCache.Text = "button1";
            this.btnRefreshCache.UseVisualStyleBackColor = true;
            this.btnRefreshCache.Click += new System.EventHandler(this.btnRefreshCache_Click);
            // 
            // lstCache
            // 
            this.lstCache.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCache.FormattingEnabled = true;
            this.lstCache.Location = new System.Drawing.Point(7, 7);
            this.lstCache.Name = "lstCache";
            this.lstCache.Size = new System.Drawing.Size(539, 277);
            this.lstCache.TabIndex = 0;
            // 
            // tabPageDebugTrace
            // 
            this.tabPageDebugTrace.Controls.Add(this.lstTrace);
            this.tabPageDebugTrace.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebugTrace.Name = "tabPageDebugTrace";
            this.tabPageDebugTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebugTrace.Size = new System.Drawing.Size(552, 322);
            this.tabPageDebugTrace.TabIndex = 3;
            this.tabPageDebugTrace.Text = "Trace";
            this.tabPageDebugTrace.UseVisualStyleBackColor = true;
            // 
            // lstTrace
            // 
            this.lstTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTrace.FormattingEnabled = true;
            this.lstTrace.Location = new System.Drawing.Point(7, 7);
            this.lstTrace.Name = "lstTrace";
            this.lstTrace.Size = new System.Drawing.Size(539, 264);
            this.lstTrace.TabIndex = 0;
            // 
            // Events
            // 
            this.tabPageEvents.Controls.Add(this.lvEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(4, 22);
            this.tabPageEvents.Name = "Events";
            this.tabPageEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEvents.Size = new System.Drawing.Size(552, 322);
            this.tabPageEvents.TabIndex = 4;
            this.tabPageEvents.Text = "tabPage4";
            this.tabPageEvents.UseVisualStyleBackColor = true;
            // 
            // lvEvents
            // 
            this.lvEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEventDateTime,
            this.colEventName,
            this.colEventParam1,
            this.colEventParam2,
            this.colEventParam3,
            this.colEventParam4,
            this.colEventResult});
            this.lvEvents.Location = new System.Drawing.Point(7, 7);
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(539, 309);
            this.lvEvents.TabIndex = 0;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.Details;
            // 
            // colEventDateTime
            // 
            this.colEventDateTime.Width = 237;
            // 
            // colEventName
            // 
            this.colEventName.Width = 168;
            // 
            // colEventParam1
            // 
            this.colEventParam1.Width = 158;
            // 
            // colEventParam2
            // 
            this.colEventParam2.Width = 138;
            // 
            // colEventParam3
            // 
            this.colEventParam3.Width = 156;
            // 
            // colEventParam4
            // 
            this.colEventParam4.Width = 157;
            // 
            // colEventResult
            // 
            this.colEventResult.Width = 158;
            // 
            // DebugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DebugInfo";
            this.Size = new System.Drawing.Size(585, 373);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPageDebugTrace.ResumeLayout(false);
            this.tabPageEvents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnLoadModules;
        private System.Windows.Forms.ListBox lstModules;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRefreshThreads;
        private System.Windows.Forms.ListBox lstThreads;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnRefreshCache;
        private System.Windows.Forms.ListBox lstCache;
        private System.Windows.Forms.TabPage tabPageDebugTrace;
        private System.Windows.Forms.ListBox lstTrace;
        private System.Windows.Forms.TabPage tabPageEvents;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.ColumnHeader colEventDateTime;
        private System.Windows.Forms.ColumnHeader colEventName;
        private System.Windows.Forms.ColumnHeader colEventParam1;
        private System.Windows.Forms.ColumnHeader colEventParam2;
        private System.Windows.Forms.ColumnHeader colEventParam3;
        private System.Windows.Forms.ColumnHeader colEventParam4;
        private System.Windows.Forms.ColumnHeader colEventResult;
    }
}