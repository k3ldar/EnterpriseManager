namespace PointOfSale.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerStats = new System.Windows.Forms.Timer(this.components);
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.contextMenuStripPluginSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pluginSettingsEditMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelBackup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarAutoLogout = new System.Windows.Forms.ToolStripProgressBar();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomeSettingsAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomeSettingsUserSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHomeSwapUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomeRevertUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomeLockUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHomeChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHomeClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministrationToolsSep = new System.Windows.Forms.ToolStripSeparator();
            this.menuAdministrationTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpHintsTips = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuPopupNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPopupNotifyIconOpenTill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopupNotifyIconOpenStockControl = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopupNotifyIconOpenOrderManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopupNotifyIconOpenDiary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPopupNotifyIconExit = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toastNotification1 = new SharedControls.ToastNotification(this.components);
            this.homeTabContainer = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.homeButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStripMain.SuspendLayout();
            this.contextMenuStripPluginSettings.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.menuPopupNotifyIcon.SuspendLayout();
            this.homeTabContainer.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStats
            // 
            this.timerStats.Enabled = true;
            this.timerStats.Interval = 1000;
            this.timerStats.Tick += new System.EventHandler(this.timerStats_Tick);
            // 
            // statusStripMain
            // 
            this.statusStripMain.ContextMenuStrip = this.contextMenuStripPluginSettings;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelBackup,
            this.toolStripStatusLabelUser,
            this.toolStripProgressBarAutoLogout});
            this.statusStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripMain.Location = new System.Drawing.Point(0, 201);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.ShowItemToolTips = true;
            this.statusStripMain.Size = new System.Drawing.Size(772, 24);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 5;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // contextMenuStripPluginSettings
            // 
            this.contextMenuStripPluginSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginSettingsEditMenuStrip});
            this.contextMenuStripPluginSettings.Name = "contextMenuStripPluginSettings";
            this.contextMenuStripPluginSettings.Size = new System.Drawing.Size(95, 26);
            this.contextMenuStripPluginSettings.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPluginSettings_Opening);
            // 
            // pluginSettingsEditMenuStrip
            // 
            this.pluginSettingsEditMenuStrip.Name = "pluginSettingsEditMenuStrip";
            this.pluginSettingsEditMenuStrip.Size = new System.Drawing.Size(94, 22);
            this.pluginSettingsEditMenuStrip.Text = "Edit";
            this.pluginSettingsEditMenuStrip.Click += new System.EventHandler(this.pluginSettingsEditMenuStrip_Click);
            // 
            // toolStripStatusLabelBackup
            // 
            this.toolStripStatusLabelBackup.Name = "toolStripStatusLabelBackup";
            this.toolStripStatusLabelBackup.Size = new System.Drawing.Size(97, 19);
            this.toolStripStatusLabelBackup.Text = "Database Backup";
            this.toolStripStatusLabelBackup.Visible = false;
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.DoubleClickEnabled = true;
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(83, 19);
            this.toolStripStatusLabelUser.Tag = "Fixed";
            this.toolStripStatusLabelUser.Text = "Not Logged In";
            this.toolStripStatusLabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBarAutoLogout
            // 
            this.toolStripProgressBarAutoLogout.AutoSize = false;
            this.toolStripProgressBarAutoLogout.AutoToolTip = true;
            this.toolStripProgressBarAutoLogout.Name = "toolStripProgressBarAutoLogout";
            this.toolStripProgressBarAutoLogout.Size = new System.Drawing.Size(50, 18);
            this.toolStripProgressBarAutoLogout.Tag = "Fixed";
            this.toolStripProgressBarAutoLogout.ToolTipText = "Seconds Until Logout";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHome,
            this.menuAccounts,
            this.menuTools,
            this.menuReports,
            this.menuAdministration,
            this.menuLanguage,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(772, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuHome
            // 
            this.menuHome.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHomeSettings,
            this.menuFileSep1,
            this.menuHomeSwapUser,
            this.menuHomeRevertUser,
            this.menuHomeLockUser,
            this.menuFileSep2,
            this.menuHomeChangePassword,
            this.menuFileSep3,
            this.menuHomeClose});
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(37, 20);
            this.menuHome.Text = "&File";
            this.menuHome.DropDownOpening += new System.EventHandler(this.menuHome_DropDownOpening);
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // menuHomeSettings
            // 
            this.menuHomeSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHomeSettingsAdministration,
            this.menuHomeSettingsUserSettings});
            this.menuHomeSettings.Name = "menuHomeSettings";
            this.menuHomeSettings.Size = new System.Drawing.Size(168, 22);
            this.menuHomeSettings.Text = "&Settings";
            // 
            // menuHomeSettingsAdministration
            // 
            this.menuHomeSettingsAdministration.Name = "menuHomeSettingsAdministration";
            this.menuHomeSettingsAdministration.Size = new System.Drawing.Size(153, 22);
            this.menuHomeSettingsAdministration.Text = "&Administration";
            this.menuHomeSettingsAdministration.Click += new System.EventHandler(this.menuHomeSettingsAdministration_Click);
            // 
            // menuHomeSettingsUserSettings
            // 
            this.menuHomeSettingsUserSettings.Name = "menuHomeSettingsUserSettings";
            this.menuHomeSettingsUserSettings.Size = new System.Drawing.Size(153, 22);
            this.menuHomeSettingsUserSettings.Text = "&User Settings";
            this.menuHomeSettingsUserSettings.Click += new System.EventHandler(this.menuHomeSettingsUser_Click);
            // 
            // menuFileSep1
            // 
            this.menuFileSep1.Name = "menuFileSep1";
            this.menuFileSep1.Size = new System.Drawing.Size(165, 6);
            // 
            // menuHomeSwapUser
            // 
            this.menuHomeSwapUser.Name = "menuHomeSwapUser";
            this.menuHomeSwapUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuHomeSwapUser.Size = new System.Drawing.Size(168, 22);
            this.menuHomeSwapUser.Text = "S&wap User";
            this.menuHomeSwapUser.Click += new System.EventHandler(this.menuHomeUserSwap_Click);
            // 
            // menuHomeRevertUser
            // 
            this.menuHomeRevertUser.Name = "menuHomeRevertUser";
            this.menuHomeRevertUser.Size = new System.Drawing.Size(168, 22);
            this.menuHomeRevertUser.Text = "&Revert User";
            this.menuHomeRevertUser.Click += new System.EventHandler(this.menuHomeUserRevert_Click);
            // 
            // menuHomeLockUser
            // 
            this.menuHomeLockUser.Name = "menuHomeLockUser";
            this.menuHomeLockUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menuHomeLockUser.Size = new System.Drawing.Size(168, 22);
            this.menuHomeLockUser.Text = "&Lock User";
            this.menuHomeLockUser.Click += new System.EventHandler(this.menuHomeUserLock_Click);
            // 
            // menuFileSep2
            // 
            this.menuFileSep2.Name = "menuFileSep2";
            this.menuFileSep2.Size = new System.Drawing.Size(165, 6);
            // 
            // menuHomeChangePassword
            // 
            this.menuHomeChangePassword.Name = "menuHomeChangePassword";
            this.menuHomeChangePassword.Size = new System.Drawing.Size(168, 22);
            this.menuHomeChangePassword.Text = "Change &Password";
            this.menuHomeChangePassword.Click += new System.EventHandler(this.menuHomeChangePassword_Click);
            // 
            // menuFileSep3
            // 
            this.menuFileSep3.Name = "menuFileSep3";
            this.menuFileSep3.Size = new System.Drawing.Size(165, 6);
            // 
            // menuHomeClose
            // 
            this.menuHomeClose.Name = "menuHomeClose";
            this.menuHomeClose.Size = new System.Drawing.Size(168, 22);
            this.menuHomeClose.Text = "&Close";
            this.menuHomeClose.Click += new System.EventHandler(this.menuHomeClose_Click);
            // 
            // menuAccounts
            // 
            this.menuAccounts.Name = "menuAccounts";
            this.menuAccounts.Size = new System.Drawing.Size(69, 20);
            this.menuAccounts.Text = "&Accounts";
            this.menuAccounts.DropDownOpening += new System.EventHandler(this.menuAccounts_DropDownOpening);
            // 
            // menuTools
            // 
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "&Tools";
            this.menuTools.DropDownOpening += new System.EventHandler(this.menuTools_DropDownOpening);
            // 
            // menuReports
            // 
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(59, 20);
            this.menuReports.Text = "&Reports";
            this.menuReports.DropDownOpening += new System.EventHandler(this.menuReports_DropDownOpening);
            // 
            // menuAdministration
            // 
            this.menuAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdministrationToolsSep,
            this.menuAdministrationTools});
            this.menuAdministration.Name = "menuAdministration";
            this.menuAdministration.Size = new System.Drawing.Size(98, 20);
            this.menuAdministration.Text = "Administra&tion";
            this.menuAdministration.DropDownOpening += new System.EventHandler(this.menuAdministration_DropDownOpening);
            // 
            // menuAdministrationToolsSep
            // 
            this.menuAdministrationToolsSep.MergeIndex = 149;
            this.menuAdministrationToolsSep.Name = "menuAdministrationToolsSep";
            this.menuAdministrationToolsSep.Size = new System.Drawing.Size(99, 6);
            // 
            // menuAdministrationTools
            // 
            this.menuAdministrationTools.MergeIndex = 150;
            this.menuAdministrationTools.Name = "menuAdministrationTools";
            this.menuAdministrationTools.Size = new System.Drawing.Size(102, 22);
            this.menuAdministrationTools.Text = "Tools";
            this.menuAdministrationTools.DropDownOpening += new System.EventHandler(this.menuAdministrationTools_DropDownOpening);
            // 
            // menuLanguage
            // 
            this.menuLanguage.Name = "menuLanguage";
            this.menuLanguage.Size = new System.Drawing.Size(71, 20);
            this.menuLanguage.Text = "&Language";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpHelp,
            this.menuHelpHintsTips,
            this.menuHelpSep1,
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            this.menuHelp.DropDownOpening += new System.EventHandler(this.menuHelp_DropDownOpening);
            // 
            // menuHelpHelp
            // 
            this.menuHelpHelp.Name = "menuHelpHelp";
            this.menuHelpHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuHelpHelp.Size = new System.Drawing.Size(130, 22);
            this.menuHelpHelp.Text = "&Help";
            this.menuHelpHelp.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // menuHelpHintsTips
            // 
            this.menuHelpHintsTips.Name = "menuHelpHintsTips";
            this.menuHelpHintsTips.Size = new System.Drawing.Size(130, 22);
            this.menuHelpHintsTips.Text = "Hints & &Tips";
            this.menuHelpHintsTips.Click += new System.EventHandler(this.hintsTipsToolStripMenuItem_Click);
            // 
            // menuHelpSep1
            // 
            this.menuHelpSep1.Name = "menuHelpSep1";
            this.menuHelpSep1.Size = new System.Drawing.Size(127, 6);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(130, 22);
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.trayIcon.BalloonTipText = "POS is not connected to the replication engine!";
            this.trayIcon.BalloonTipTitle = "Shifoo Small Business Manager";
            this.trayIcon.ContextMenuStrip = this.menuPopupNotifyIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "POS is not connected to the replication engine!";
            // 
            // menuPopupNotifyIcon
            // 
            this.menuPopupNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPopupNotifyIconOpenTill,
            this.menuPopupNotifyIconOpenStockControl,
            this.menuPopupNotifyIconOpenOrderManager,
            this.menuPopupNotifyIconOpenDiary,
            this.toolStripMenuItem9,
            this.menuPopupNotifyIconExit});
            this.menuPopupNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.menuPopupNotifyIcon.Size = new System.Drawing.Size(187, 120);
            // 
            // menuPopupNotifyIconOpenTill
            // 
            this.menuPopupNotifyIconOpenTill.Name = "menuPopupNotifyIconOpenTill";
            this.menuPopupNotifyIconOpenTill.Size = new System.Drawing.Size(186, 22);
            this.menuPopupNotifyIconOpenTill.Text = "Open &Till";
            // 
            // menuPopupNotifyIconOpenStockControl
            // 
            this.menuPopupNotifyIconOpenStockControl.Name = "menuPopupNotifyIconOpenStockControl";
            this.menuPopupNotifyIconOpenStockControl.Size = new System.Drawing.Size(186, 22);
            this.menuPopupNotifyIconOpenStockControl.Text = "Open &Stock Control";
            // 
            // menuPopupNotifyIconOpenOrderManager
            // 
            this.menuPopupNotifyIconOpenOrderManager.Name = "menuPopupNotifyIconOpenOrderManager";
            this.menuPopupNotifyIconOpenOrderManager.Size = new System.Drawing.Size(186, 22);
            this.menuPopupNotifyIconOpenOrderManager.Text = "Open &Order Manager";
            // 
            // menuPopupNotifyIconOpenDiary
            // 
            this.menuPopupNotifyIconOpenDiary.Name = "menuPopupNotifyIconOpenDiary";
            this.menuPopupNotifyIconOpenDiary.Size = new System.Drawing.Size(186, 22);
            this.menuPopupNotifyIconOpenDiary.Text = "Open &Diary";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(183, 6);
            // 
            // menuPopupNotifyIconExit
            // 
            this.menuPopupNotifyIconExit.Name = "menuPopupNotifyIconExit";
            this.menuPopupNotifyIconExit.Size = new System.Drawing.Size(186, 22);
            this.menuPopupNotifyIconExit.Text = "&Exit";
            this.menuPopupNotifyIconExit.Click += new System.EventHandler(this.menuHomeClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Connected.bmp");
            this.imageList1.Images.SetKeyName(1, "Disconnected(1).ico");
            this.imageList1.Images.SetKeyName(2, "Replicating.bmp");
            // 
            // toastNotification1
            // 
            this.toastNotification1.ClickForInformation = true;
            this.toastNotification1.OnClicked += new Shared.ToastNotificationHandler(this.toastNotification1_OnClicked);
            this.toastNotification1.OnTimeOut += new Shared.ToastNotificationHandler(this.toastNotification1_OnTimeOut);
            this.toastNotification1.OnCancelled += new Shared.ToastNotificationHandler(this.toastNotification1_OnCancelled);
            this.toastNotification1.OnFocus += new Shared.ToastNotificationHandler(this.toastNotification1_OnFocus);
            // 
            // homeTabContainer
            // 
            this.homeTabContainer.AllowDrop = true;
            this.homeTabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeTabContainer.Controls.Add(this.tabPageMain);
            this.homeTabContainer.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.homeTabContainer.HotTrack = true;
            this.homeTabContainer.Location = new System.Drawing.Point(6, 31);
            this.homeTabContainer.Name = "homeTabContainer";
            this.homeTabContainer.SelectedIndex = 0;
            this.homeTabContainer.Size = new System.Drawing.Size(760, 163);
            this.homeTabContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.homeTabContainer.TabIndex = 9;
            this.homeTabContainer.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.homeTabContainer_DrawItem);
            this.homeTabContainer.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.homeTabContainer_Selecting);
            this.homeTabContainer.SizeChanged += new System.EventHandler(this.homeTabContainer_SizeChanged);
            this.homeTabContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.homeTabContainer_DragDrop);
            this.homeTabContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.homeTabContainer_DragOver);
            this.homeTabContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.homeTabContainer_MouseDown);
            this.homeTabContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.homeTabContainer_MouseMove);
            this.homeTabContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.homeTabContainer_MouseUp);
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.homeButtonPanel);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(752, 137);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Home";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // homeButtonPanel
            // 
            this.homeButtonPanel.AllowDrop = true;
            this.homeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeButtonPanel.AutoScroll = true;
            this.homeButtonPanel.Location = new System.Drawing.Point(6, 6);
            this.homeButtonPanel.Name = "homeButtonPanel";
            this.homeButtonPanel.Size = new System.Drawing.Size(740, 121);
            this.homeButtonPanel.TabIndex = 0;
            this.homeButtonPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.homeButtonPanel_DragDrop);
            this.homeButtonPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.homeButtonPanel_DragEnter);
            this.homeButtonPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.homeButtonPanel_DragOver);
            this.homeButtonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.homeButtonPanel_MouseDown);
            this.homeButtonPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.homeButtonPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(772, 225);
            this.Controls.Add(this.homeTabContainer);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuMain);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(788, 264);
            this.MinimumSize = new System.Drawing.Size(788, 264);
            this.Name = "MainForm";
            this.SaveState = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sale";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.contextMenuStripPluginSettings.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.menuPopupNotifyIcon.ResumeLayout(false);
            this.homeTabContainer.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuAccounts;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuHomeClose;
        private System.Windows.Forms.ToolStripMenuItem menuHomeSettings;
        private System.Windows.Forms.ToolStripMenuItem menuHomeSettingsAdministration;
        private System.Windows.Forms.ToolStripSeparator menuFileSep3;
        private System.Windows.Forms.Timer timerStats;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuAdministration;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip menuPopupNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuPopupNotifyIconOpenTill;
        private System.Windows.Forms.ToolStripMenuItem menuPopupNotifyIconOpenStockControl;
        private System.Windows.Forms.ToolStripMenuItem menuPopupNotifyIconOpenOrderManager;
        private System.Windows.Forms.ToolStripMenuItem menuPopupNotifyIconOpenDiary;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem menuPopupNotifyIconExit;
        private System.Windows.Forms.ToolStripSeparator menuFileSep1;
        private System.Windows.Forms.ToolStripMenuItem menuHomeSwapUser;
        private System.Windows.Forms.ToolStripMenuItem menuHomeRevertUser;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarAutoLogout;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem menuHelpHelp;
        private System.Windows.Forms.ToolStripSeparator menuHelpSep1;
        private System.Windows.Forms.ToolStripMenuItem menuHomeLockUser;
        private System.Windows.Forms.ToolStripMenuItem menuHelpHintsTips;
        private System.Windows.Forms.ToolStripMenuItem menuHomeSettingsUserSettings;
        private System.Windows.Forms.ToolStripSeparator menuFileSep2;
        private System.Windows.Forms.ToolStripMenuItem menuHomeChangePassword;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBackup;
        private System.Windows.Forms.ToolStripMenuItem menuLanguage;
        internal System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPluginSettings;
        private System.Windows.Forms.ToolStripMenuItem pluginSettingsEditMenuStrip;
        private System.Windows.Forms.ToolStripSeparator menuAdministrationToolsSep;
        private System.Windows.Forms.ToolStripMenuItem menuAdministrationTools;
        private SharedControls.ToastNotification toastNotification1;
        private System.Windows.Forms.TabControl homeTabContainer;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.FlowLayoutPanel homeButtonPanel;
    }
}