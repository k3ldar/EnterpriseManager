namespace POS.Staff.Forms
{
    partial class AdminStaffEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminStaffEdit));
            this.ilTreeNode = new System.Windows.Forms.ImageList(this.components);
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            this.pumTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelLeaveRemaining = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelAnniversary = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelSpare = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddStaff = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveStaff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tssbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tvStaffMembers = new SharedControls.Controls.TreeViewEx();
            this.tabStaff = new System.Windows.Forms.TabControl();
            this.tabPageUserDetails = new System.Windows.Forms.TabPage();
            this.cmbMemberLevel = new System.Windows.Forms.ComboBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddLine3 = new System.Windows.Forms.TextBox();
            this.txtAddLine2 = new System.Windows.Forms.TextBox();
            this.txtAddLine1 = new System.Windows.Forms.TextBox();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMemberLevel = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddressLine3 = new System.Windows.Forms.Label();
            this.lblAddressLine2 = new System.Windows.Forms.Label();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.lblBusinessName = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tabPageContactDetails = new System.Windows.Forms.TabPage();
            this.txtContactOther = new System.Windows.Forms.TextBox();
            this.lblContactOther = new System.Windows.Forms.Label();
            this.txtContactWork = new System.Windows.Forms.TextBox();
            this.lblContactWork = new System.Windows.Forms.Label();
            this.txtContactMobile = new System.Windows.Forms.TextBox();
            this.lblContactMobile = new System.Windows.Forms.Label();
            this.txtContactHome = new System.Windows.Forms.TextBox();
            this.lblContactHome = new System.Windows.Forms.Label();
            this.tabPageEmploymentDetails = new System.Windows.Forms.TabPage();
            this.cmbEmploymentType = new System.Windows.Forms.ComboBox();
            this.lblEmploymentType = new System.Windows.Forms.Label();
            this.dtpDateProbationEnds = new System.Windows.Forms.DateTimePicker();
            this.lblDateProbationEnds = new System.Windows.Forms.Label();
            this.dtpDatePermanent = new System.Windows.Forms.DateTimePicker();
            this.lblDatePermanent = new System.Windows.Forms.Label();
            this.dtpDateJoined = new System.Windows.Forms.DateTimePicker();
            this.lblDateJoined = new System.Windows.Forms.Label();
            this.udWeeklyHours = new System.Windows.Forms.NumericUpDown();
            this.lblWeeklyHours = new System.Windows.Forms.Label();
            this.cmbPayPeriod = new System.Windows.Forms.ComboBox();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.txtPayrollNumber = new System.Windows.Forms.TextBox();
            this.lblPayrollNumber = new System.Windows.Forms.Label();
            this.cbPartTime = new System.Windows.Forms.CheckBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.tabPagePersonal = new System.Windows.Forms.TabPage();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.tabPageLeave = new System.Windows.Forms.TabPage();
            this.leaveRequests1 = new POS.Staff.Controls.LeaveRequests();
            this.rbLeaveHours = new System.Windows.Forms.RadioButton();
            this.rbLeaveDays = new System.Windows.Forms.RadioButton();
            this.cbLeaveCarriesOver = new System.Windows.Forms.CheckBox();
            this.cbLeaveAccrues = new System.Windows.Forms.CheckBox();
            this.udLeaveEntitlement = new System.Windows.Forms.NumericUpDown();
            this.lblLeaveEntitlement = new System.Windows.Forms.Label();
            this.tabPageSickness = new System.Windows.Forms.TabPage();
            this.lvSicknessRecords = new SharedControls.Classes.ListViewEx();
            this.chSicknessNotified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSicknessReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSicknessStarted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSicknessFinished = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSicknessTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSicknessSelfCertified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pumSickness = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pumSicknessNew = new System.Windows.Forms.ToolStripMenuItem();
            this.pumSicknessView = new System.Windows.Forms.ToolStripMenuItem();
            this.pumSicknessCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.pumSicknessReturnToWork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.pumSicknessStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageEmergencyContact = new System.Windows.Forms.TabPage();
            this.txtEmergencyTel2 = new System.Windows.Forms.TextBox();
            this.lblEmergencContact2 = new System.Windows.Forms.Label();
            this.txtEmergencyRelation = new System.Windows.Forms.TextBox();
            this.lblEmergencRelation = new System.Windows.Forms.Label();
            this.txtEmergencyTel1 = new System.Windows.Forms.TextBox();
            this.lblEmergencContact1 = new System.Windows.Forms.Label();
            this.txtEmergencyContactName = new System.Windows.Forms.TextBox();
            this.lblEmergencyName = new System.Windows.Forms.Label();
            this.tabPageLicenceDetails = new System.Windows.Forms.TabPage();
            this.txtDLNotes = new System.Windows.Forms.TextBox();
            this.lblDLNotes = new System.Windows.Forms.Label();
            this.dtpDLExpires = new System.Windows.Forms.DateTimePicker();
            this.lblDLExpires = new System.Windows.Forms.Label();
            this.txtDLNumber = new System.Windows.Forms.TextBox();
            this.lblDLNumber = new System.Windows.Forms.Label();
            this.tabPageDiary = new System.Windows.Forms.TabPage();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.gbLunch = new System.Windows.Forms.GroupBox();
            this.cmbLunchDuration = new System.Windows.Forms.ComboBox();
            this.lblLunchDuration = new System.Windows.Forms.Label();
            this.cmbLunchStart = new System.Windows.Forms.ComboBox();
            this.lblLunchStart = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cbPublicDiary = new System.Windows.Forms.CheckBox();
            this.cbBookCurrentDay = new System.Windows.Forms.CheckBox();
            this.gbWorkingHours = new System.Windows.Forms.GroupBox();
            this.cmbFinishTime = new System.Windows.Forms.ComboBox();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.lblWorkingFinishTime = new System.Windows.Forms.Label();
            this.lblWorkingStartTime = new System.Windows.Forms.Label();
            this.gbWorkingDays = new System.Windows.Forms.GroupBox();
            this.cbSunday = new System.Windows.Forms.CheckBox();
            this.cbSaturday = new System.Windows.Forms.CheckBox();
            this.cbFriday = new System.Windows.Forms.CheckBox();
            this.cbThursday = new System.Windows.Forms.CheckBox();
            this.cbWednesday = new System.Windows.Forms.CheckBox();
            this.cbTuesday = new System.Windows.Forms.CheckBox();
            this.cbMonday = new System.Windows.Forms.CheckBox();
            this.tabPageWorkingHours = new System.Windows.Forms.TabPage();
            this.lvWorkingHours = new SharedControls.Classes.ListViewEx();
            this.colWorkingHoursStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkingHoursDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkingHoursRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkingHoursRepeatFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkingHoursTreatments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnWorkingHoursDelete = new System.Windows.Forms.Button();
            this.btnWorkingHoursUpdate = new System.Windows.Forms.Button();
            this.btnWorkingHoursCreate = new System.Windows.Forms.Button();
            this.grpWorkingHours = new System.Windows.Forms.GroupBox();
            this.cbAllowTreatments = new System.Windows.Forms.CheckBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.lblEvery = new System.Windows.Forms.Label();
            this.cmbWorkingHoursRepeatOption = new System.Windows.Forms.ComboBox();
            this.lblRepeatFrequency = new System.Windows.Forms.Label();
            this.lblRepeatOption = new System.Windows.Forms.Label();
            this.cmbWorkingHoursFinish = new System.Windows.Forms.ComboBox();
            this.cmbWorkingHoursStart = new System.Windows.Forms.ComboBox();
            this.lblStartHour = new System.Windows.Forms.Label();
            this.lblFinishHour = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtWorkingHoursDate = new System.Windows.Forms.DateTimePicker();
            this.lblCurrentWorkingRules = new System.Windows.Forms.Label();
            this.tabPageTreatments = new System.Windows.Forms.TabPage();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAssignedPermissions = new System.Windows.Forms.Label();
            this.lbTherapistTreatments = new System.Windows.Forms.ListBox();
            this.lblAvailableTreatments = new System.Windows.Forms.Label();
            this.lbAvailableTreatments = new System.Windows.Forms.ListBox();
            this.tabPagePermissions = new System.Windows.Forms.TabPage();
            this.permissions1 = new POS.Base.Controls.Permissions();
            this.tabPageCommission = new System.Windows.Forms.TabPage();
            this.lblCommissionDetails = new System.Windows.Forms.Label();
            this.lvCommissionPayments = new SharedControls.Classes.ListViewEx();
            this.chCommissionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommissionAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommissionAuthorising = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommissionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.lvClients = new SharedControls.Classes.ListViewEx();
            this.chClientsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientsTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientsCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientsState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientsAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.udCommissionManager = new System.Windows.Forms.NumericUpDown();
            this.lblCommisionManagerRate = new System.Windows.Forms.Label();
            this.udCommissionStaff = new System.Windows.Forms.NumericUpDown();
            this.lblCommisionStaffRate = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabStaff.SuspendLayout();
            this.tabPageUserDetails.SuspendLayout();
            this.tabPageContactDetails.SuspendLayout();
            this.tabPageEmploymentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udWeeklyHours)).BeginInit();
            this.tabPagePersonal.SuspendLayout();
            this.tabPageLeave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLeaveEntitlement)).BeginInit();
            this.tabPageSickness.SuspendLayout();
            this.pumSickness.SuspendLayout();
            this.tabPageEmergencyContact.SuspendLayout();
            this.tabPageLicenceDetails.SuspendLayout();
            this.tabPageDiary.SuspendLayout();
            this.gbGroup.SuspendLayout();
            this.gbLunch.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.gbWorkingHours.SuspendLayout();
            this.gbWorkingDays.SuspendLayout();
            this.tabPageWorkingHours.SuspendLayout();
            this.grpWorkingHours.SuspendLayout();
            this.tabPageTreatments.SuspendLayout();
            this.tabPagePermissions.SuspendLayout();
            this.tabPageCommission.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeNode
            // 
            this.ilTreeNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeNode.ImageStream")));
            this.ilTreeNode.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeNode.Images.SetKeyName(0, "UseCaseDiagramFile_usecasediagram_13447.ico");
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolbar.Images.SetKeyName(0, "action_add_16xLG.png");
            // 
            // pumTreeView
            // 
            this.pumTreeView.Name = "pumTreeView";
            this.pumTreeView.Size = new System.Drawing.Size(61, 4);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeaveRemaining,
            this.statusLabelAnniversary,
            this.statusLabelSpare});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(853, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // statusLabelLeaveRemaining
            // 
            this.statusLabelLeaveRemaining.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabelLeaveRemaining.Name = "statusLabelLeaveRemaining";
            this.statusLabelLeaveRemaining.Size = new System.Drawing.Size(122, 19);
            this.statusLabelLeaveRemaining.Text = "toolStripStatusLabel1";
            // 
            // statusLabelAnniversary
            // 
            this.statusLabelAnniversary.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabelAnniversary.Name = "statusLabelAnniversary";
            this.statusLabelAnniversary.Size = new System.Drawing.Size(122, 19);
            this.statusLabelAnniversary.Text = "toolStripStatusLabel1";
            // 
            // statusLabelSpare
            // 
            this.statusLabelSpare.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabelSpare.Name = "statusLabelSpare";
            this.statusLabelSpare.Size = new System.Drawing.Size(4, 19);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddStaff,
            this.tsbRemoveStaff,
            this.toolStripSeparator1,
            this.tsbSave,
            this.tssbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(853, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbAddStaff
            // 
            this.tsbAddStaff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddStaff.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddStaff.Image")));
            this.tsbAddStaff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddStaff.Name = "tsbAddStaff";
            this.tsbAddStaff.Size = new System.Drawing.Size(23, 22);
            this.tsbAddStaff.Click += new System.EventHandler(this.tsbAddStaff_Click);
            // 
            // tsbRemoveStaff
            // 
            this.tsbRemoveStaff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveStaff.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveStaff.Image")));
            this.tsbRemoveStaff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveStaff.Name = "tsbRemoveStaff";
            this.tsbRemoveStaff.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveStaff.Text = "tsbRemoveStaff";
            this.tsbRemoveStaff.Click += new System.EventHandler(this.tsbRemoveStaff_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "toolStripButton3";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tssbRefresh
            // 
            this.tssbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tssbRefresh.Image")));
            this.tssbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbRefresh.Name = "tssbRefresh";
            this.tssbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tssbRefresh.Text = "tsbRefresh";
            this.tssbRefresh.Click += new System.EventHandler(this.tssbRefresh_Click);
            // 
            // tvStaffMembers
            // 
            this.tvStaffMembers.AllowDrop = true;
            this.tvStaffMembers.AllowNoNodeSelected = true;
            this.tvStaffMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStaffMembers.ContextMenuStrip = this.pumTreeView;
            this.tvStaffMembers.HideSelection = false;
            this.tvStaffMembers.ImageIndex = 0;
            this.tvStaffMembers.ImageList = this.ilTreeNode;
            this.tvStaffMembers.Location = new System.Drawing.Point(13, 28);
            this.tvStaffMembers.Name = "tvStaffMembers";
            this.tvStaffMembers.RightClickSelect = true;
            this.tvStaffMembers.SelectedImageIndex = 0;
            this.tvStaffMembers.SelectedNodeBold = true;
            this.tvStaffMembers.Size = new System.Drawing.Size(240, 533);
            this.tvStaffMembers.TabIndex = 1;
            this.tvStaffMembers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvStaffMembers_ItemDrag);
            this.tvStaffMembers.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvStaffMembers_BeforeSelect);
            this.tvStaffMembers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStaffMembers_AfterSelect);
            this.tvStaffMembers.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvStaffMembers_DragDrop);
            this.tvStaffMembers.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvStaffMembers_DragEnter);
            // 
            // tabStaff
            // 
            this.tabStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabStaff.Controls.Add(this.tabPageUserDetails);
            this.tabStaff.Controls.Add(this.tabPageContactDetails);
            this.tabStaff.Controls.Add(this.tabPageEmploymentDetails);
            this.tabStaff.Controls.Add(this.tabPagePersonal);
            this.tabStaff.Controls.Add(this.tabPageLeave);
            this.tabStaff.Controls.Add(this.tabPageSickness);
            this.tabStaff.Controls.Add(this.tabPageEmergencyContact);
            this.tabStaff.Controls.Add(this.tabPageLicenceDetails);
            this.tabStaff.Controls.Add(this.tabPageDiary);
            this.tabStaff.Controls.Add(this.tabPageWorkingHours);
            this.tabStaff.Controls.Add(this.tabPageTreatments);
            this.tabStaff.Controls.Add(this.tabPagePermissions);
            this.tabStaff.Controls.Add(this.tabPageCommission);
            this.tabStaff.Controls.Add(this.tabPageClients);
            this.tabStaff.Location = new System.Drawing.Point(259, 28);
            this.tabStaff.Multiline = true;
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.SelectedIndex = 0;
            this.tabStaff.Size = new System.Drawing.Size(566, 533);
            this.tabStaff.TabIndex = 2;
            this.tabStaff.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabStaff.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageUserDetails
            // 
            this.tabPageUserDetails.Controls.Add(this.cmbMemberLevel);
            this.tabPageUserDetails.Controls.Add(this.txtPostCode);
            this.tabPageUserDetails.Controls.Add(this.txtCounty);
            this.tabPageUserDetails.Controls.Add(this.txtCity);
            this.tabPageUserDetails.Controls.Add(this.txtAddLine3);
            this.tabPageUserDetails.Controls.Add(this.txtAddLine2);
            this.tabPageUserDetails.Controls.Add(this.txtAddLine1);
            this.tabPageUserDetails.Controls.Add(this.txtBusinessName);
            this.tabPageUserDetails.Controls.Add(this.txtTelephone);
            this.tabPageUserDetails.Controls.Add(this.txtEmail);
            this.tabPageUserDetails.Controls.Add(this.txtLastName);
            this.tabPageUserDetails.Controls.Add(this.txtFirstName);
            this.tabPageUserDetails.Controls.Add(this.lblMemberLevel);
            this.tabPageUserDetails.Controls.Add(this.lblCountry);
            this.tabPageUserDetails.Controls.Add(this.cmbCountry);
            this.tabPageUserDetails.Controls.Add(this.lblPostCode);
            this.tabPageUserDetails.Controls.Add(this.lblCounty);
            this.tabPageUserDetails.Controls.Add(this.lblCity);
            this.tabPageUserDetails.Controls.Add(this.lblAddressLine3);
            this.tabPageUserDetails.Controls.Add(this.lblAddressLine2);
            this.tabPageUserDetails.Controls.Add(this.lblAddressLine1);
            this.tabPageUserDetails.Controls.Add(this.lblBusinessName);
            this.tabPageUserDetails.Controls.Add(this.lblTelephone);
            this.tabPageUserDetails.Controls.Add(this.lblEmail);
            this.tabPageUserDetails.Controls.Add(this.lblLastName);
            this.tabPageUserDetails.Controls.Add(this.lblFirstName);
            this.tabPageUserDetails.Location = new System.Drawing.Point(4, 40);
            this.tabPageUserDetails.Name = "tabPageUserDetails";
            this.tabPageUserDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserDetails.Size = new System.Drawing.Size(558, 466);
            this.tabPageUserDetails.TabIndex = 0;
            this.tabPageUserDetails.Text = "Details";
            this.tabPageUserDetails.UseVisualStyleBackColor = true;
            // 
            // cmbMemberLevel
            // 
            this.cmbMemberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberLevel.FormattingEnabled = true;
            this.cmbMemberLevel.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbMemberLevel.Location = new System.Drawing.Point(133, 325);
            this.cmbMemberLevel.Name = "cmbMemberLevel";
            this.cmbMemberLevel.Size = new System.Drawing.Size(262, 21);
            this.cmbMemberLevel.TabIndex = 26;
            this.cmbMemberLevel.SelectedIndexChanged += new System.EventHandler(this.cmbMemberLevel_SelectedIndexChanged);
            this.cmbMemberLevel.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbMemberLevel_Format);
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(133, 272);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(126, 20);
            this.txtPostCode.TabIndex = 25;
            this.txtPostCode.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(133, 246);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(262, 20);
            this.txtCounty.TabIndex = 24;
            this.txtCounty.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(133, 220);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(262, 20);
            this.txtCity.TabIndex = 23;
            this.txtCity.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtAddLine3
            // 
            this.txtAddLine3.Location = new System.Drawing.Point(133, 194);
            this.txtAddLine3.Name = "txtAddLine3";
            this.txtAddLine3.Size = new System.Drawing.Size(262, 20);
            this.txtAddLine3.TabIndex = 22;
            this.txtAddLine3.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtAddLine2
            // 
            this.txtAddLine2.Location = new System.Drawing.Point(133, 168);
            this.txtAddLine2.Name = "txtAddLine2";
            this.txtAddLine2.Size = new System.Drawing.Size(262, 20);
            this.txtAddLine2.TabIndex = 21;
            this.txtAddLine2.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtAddLine1
            // 
            this.txtAddLine1.Location = new System.Drawing.Point(133, 142);
            this.txtAddLine1.Name = "txtAddLine1";
            this.txtAddLine1.Size = new System.Drawing.Size(262, 20);
            this.txtAddLine1.TabIndex = 20;
            this.txtAddLine1.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(133, 116);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(262, 20);
            this.txtBusinessName.TabIndex = 19;
            this.txtBusinessName.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(133, 90);
            this.txtTelephone.MaxLength = 25;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(262, 20);
            this.txtTelephone.TabIndex = 18;
            this.txtTelephone.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(133, 64);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(262, 20);
            this.txtEmail.TabIndex = 17;
            this.txtEmail.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(133, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(262, 20);
            this.txtLastName.TabIndex = 16;
            this.txtLastName.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(133, 9);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(262, 20);
            this.txtFirstName.TabIndex = 15;
            this.txtFirstName.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // lblMemberLevel
            // 
            this.lblMemberLevel.AutoSize = true;
            this.lblMemberLevel.Location = new System.Drawing.Point(9, 328);
            this.lblMemberLevel.Name = "lblMemberLevel";
            this.lblMemberLevel.Size = new System.Drawing.Size(74, 13);
            this.lblMemberLevel.TabIndex = 14;
            this.lblMemberLevel.Text = "Member Level";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(9, 301);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 13;
            this.lblCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(133, 298);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(185, 21);
            this.cmbCountry.TabIndex = 12;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            this.cmbCountry.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCountry_Format);
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(9, 275);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(52, 13);
            this.lblPostCode.TabIndex = 11;
            this.lblPostCode.Text = "Postcode";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Location = new System.Drawing.Point(9, 249);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(40, 13);
            this.lblCounty.TabIndex = 10;
            this.lblCounty.Text = "County";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(9, 223);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "City";
            // 
            // lblAddressLine3
            // 
            this.lblAddressLine3.AutoSize = true;
            this.lblAddressLine3.Location = new System.Drawing.Point(9, 197);
            this.lblAddressLine3.Name = "lblAddressLine3";
            this.lblAddressLine3.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine3.TabIndex = 8;
            this.lblAddressLine3.Text = "Address Line 3";
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.AutoSize = true;
            this.lblAddressLine2.Location = new System.Drawing.Point(9, 171);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine2.TabIndex = 7;
            this.lblAddressLine2.Text = "Address Line 2";
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(9, 145);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine1.TabIndex = 6;
            this.lblAddressLine1.Text = "Address Line 1";
            // 
            // lblBusinessName
            // 
            this.lblBusinessName.AutoSize = true;
            this.lblBusinessName.Location = new System.Drawing.Point(9, 119);
            this.lblBusinessName.Name = "lblBusinessName";
            this.lblBusinessName.Size = new System.Drawing.Size(80, 13);
            this.lblBusinessName.TabIndex = 5;
            this.lblBusinessName.Text = "Business Name";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(9, 93);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(58, 13);
            this.lblTelephone.TabIndex = 4;
            this.lblTelephone.Text = "Telephone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 67);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(9, 41);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 12);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // tabPageContactDetails
            // 
            this.tabPageContactDetails.Controls.Add(this.txtContactOther);
            this.tabPageContactDetails.Controls.Add(this.lblContactOther);
            this.tabPageContactDetails.Controls.Add(this.txtContactWork);
            this.tabPageContactDetails.Controls.Add(this.lblContactWork);
            this.tabPageContactDetails.Controls.Add(this.txtContactMobile);
            this.tabPageContactDetails.Controls.Add(this.lblContactMobile);
            this.tabPageContactDetails.Controls.Add(this.txtContactHome);
            this.tabPageContactDetails.Controls.Add(this.lblContactHome);
            this.tabPageContactDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageContactDetails.Name = "tabPageContactDetails";
            this.tabPageContactDetails.Size = new System.Drawing.Size(558, 484);
            this.tabPageContactDetails.TabIndex = 9;
            this.tabPageContactDetails.Text = "Contact Details";
            this.tabPageContactDetails.UseVisualStyleBackColor = true;
            // 
            // txtContactOther
            // 
            this.txtContactOther.Location = new System.Drawing.Point(16, 189);
            this.txtContactOther.MaxLength = 80;
            this.txtContactOther.Name = "txtContactOther";
            this.txtContactOther.Size = new System.Drawing.Size(243, 20);
            this.txtContactOther.TabIndex = 7;
            this.txtContactOther.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblContactOther
            // 
            this.lblContactOther.AutoSize = true;
            this.lblContactOther.Location = new System.Drawing.Point(16, 172);
            this.lblContactOther.Name = "lblContactOther";
            this.lblContactOther.Size = new System.Drawing.Size(33, 13);
            this.lblContactOther.TabIndex = 6;
            this.lblContactOther.Text = "Other";
            // 
            // txtContactWork
            // 
            this.txtContactWork.Location = new System.Drawing.Point(16, 136);
            this.txtContactWork.MaxLength = 80;
            this.txtContactWork.Name = "txtContactWork";
            this.txtContactWork.Size = new System.Drawing.Size(243, 20);
            this.txtContactWork.TabIndex = 5;
            this.txtContactWork.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblContactWork
            // 
            this.lblContactWork.AutoSize = true;
            this.lblContactWork.Location = new System.Drawing.Point(16, 119);
            this.lblContactWork.Name = "lblContactWork";
            this.lblContactWork.Size = new System.Drawing.Size(33, 13);
            this.lblContactWork.TabIndex = 4;
            this.lblContactWork.Text = "Work";
            // 
            // txtContactMobile
            // 
            this.txtContactMobile.Location = new System.Drawing.Point(16, 83);
            this.txtContactMobile.MaxLength = 80;
            this.txtContactMobile.Name = "txtContactMobile";
            this.txtContactMobile.Size = new System.Drawing.Size(243, 20);
            this.txtContactMobile.TabIndex = 3;
            this.txtContactMobile.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblContactMobile
            // 
            this.lblContactMobile.AutoSize = true;
            this.lblContactMobile.Location = new System.Drawing.Point(16, 66);
            this.lblContactMobile.Name = "lblContactMobile";
            this.lblContactMobile.Size = new System.Drawing.Size(38, 13);
            this.lblContactMobile.TabIndex = 2;
            this.lblContactMobile.Text = "Mobile";
            // 
            // txtContactHome
            // 
            this.txtContactHome.Location = new System.Drawing.Point(16, 30);
            this.txtContactHome.MaxLength = 80;
            this.txtContactHome.Name = "txtContactHome";
            this.txtContactHome.Size = new System.Drawing.Size(243, 20);
            this.txtContactHome.TabIndex = 1;
            this.txtContactHome.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblContactHome
            // 
            this.lblContactHome.AutoSize = true;
            this.lblContactHome.Location = new System.Drawing.Point(16, 13);
            this.lblContactHome.Name = "lblContactHome";
            this.lblContactHome.Size = new System.Drawing.Size(35, 13);
            this.lblContactHome.TabIndex = 0;
            this.lblContactHome.Text = "Home";
            // 
            // tabPageEmploymentDetails
            // 
            this.tabPageEmploymentDetails.Controls.Add(this.cmbEmploymentType);
            this.tabPageEmploymentDetails.Controls.Add(this.lblEmploymentType);
            this.tabPageEmploymentDetails.Controls.Add(this.dtpDateProbationEnds);
            this.tabPageEmploymentDetails.Controls.Add(this.lblDateProbationEnds);
            this.tabPageEmploymentDetails.Controls.Add(this.dtpDatePermanent);
            this.tabPageEmploymentDetails.Controls.Add(this.lblDatePermanent);
            this.tabPageEmploymentDetails.Controls.Add(this.dtpDateJoined);
            this.tabPageEmploymentDetails.Controls.Add(this.lblDateJoined);
            this.tabPageEmploymentDetails.Controls.Add(this.udWeeklyHours);
            this.tabPageEmploymentDetails.Controls.Add(this.lblWeeklyHours);
            this.tabPageEmploymentDetails.Controls.Add(this.cmbPayPeriod);
            this.tabPageEmploymentDetails.Controls.Add(this.lblPayPeriod);
            this.tabPageEmploymentDetails.Controls.Add(this.txtPayrollNumber);
            this.tabPageEmploymentDetails.Controls.Add(this.lblPayrollNumber);
            this.tabPageEmploymentDetails.Controls.Add(this.cbPartTime);
            this.tabPageEmploymentDetails.Controls.Add(this.txtLocation);
            this.tabPageEmploymentDetails.Controls.Add(this.lblLocation);
            this.tabPageEmploymentDetails.Controls.Add(this.txtJobTitle);
            this.tabPageEmploymentDetails.Controls.Add(this.lblJobTitle);
            this.tabPageEmploymentDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmploymentDetails.Name = "tabPageEmploymentDetails";
            this.tabPageEmploymentDetails.Size = new System.Drawing.Size(558, 484);
            this.tabPageEmploymentDetails.TabIndex = 11;
            this.tabPageEmploymentDetails.Text = "Employment Details";
            this.tabPageEmploymentDetails.UseVisualStyleBackColor = true;
            // 
            // cmbEmploymentType
            // 
            this.cmbEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentType.FormattingEnabled = true;
            this.cmbEmploymentType.Location = new System.Drawing.Point(20, 334);
            this.cmbEmploymentType.Name = "cmbEmploymentType";
            this.cmbEmploymentType.Size = new System.Drawing.Size(214, 21);
            this.cmbEmploymentType.TabIndex = 12;
            this.cmbEmploymentType.SelectedIndexChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblEmploymentType
            // 
            this.lblEmploymentType.AutoSize = true;
            this.lblEmploymentType.Location = new System.Drawing.Point(20, 318);
            this.lblEmploymentType.Name = "lblEmploymentType";
            this.lblEmploymentType.Size = new System.Drawing.Size(91, 13);
            this.lblEmploymentType.TabIndex = 11;
            this.lblEmploymentType.Text = "Employment Type";
            // 
            // dtpDateProbationEnds
            // 
            this.dtpDateProbationEnds.Location = new System.Drawing.Point(309, 338);
            this.dtpDateProbationEnds.Name = "dtpDateProbationEnds";
            this.dtpDateProbationEnds.Size = new System.Drawing.Size(200, 20);
            this.dtpDateProbationEnds.TabIndex = 18;
            this.dtpDateProbationEnds.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDateProbationEnds
            // 
            this.lblDateProbationEnds.AutoSize = true;
            this.lblDateProbationEnds.Location = new System.Drawing.Point(309, 322);
            this.lblDateProbationEnds.Name = "lblDateProbationEnds";
            this.lblDateProbationEnds.Size = new System.Drawing.Size(105, 13);
            this.lblDateProbationEnds.TabIndex = 17;
            this.lblDateProbationEnds.Text = "Date Probation Ends";
            // 
            // dtpDatePermanent
            // 
            this.dtpDatePermanent.Location = new System.Drawing.Point(309, 284);
            this.dtpDatePermanent.Name = "dtpDatePermanent";
            this.dtpDatePermanent.Size = new System.Drawing.Size(200, 20);
            this.dtpDatePermanent.TabIndex = 16;
            this.dtpDatePermanent.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDatePermanent
            // 
            this.lblDatePermanent.AutoSize = true;
            this.lblDatePermanent.Location = new System.Drawing.Point(309, 267);
            this.lblDatePermanent.Name = "lblDatePermanent";
            this.lblDatePermanent.Size = new System.Drawing.Size(84, 13);
            this.lblDatePermanent.TabIndex = 15;
            this.lblDatePermanent.Text = "Date Permanent";
            // 
            // dtpDateJoined
            // 
            this.dtpDateJoined.Location = new System.Drawing.Point(309, 230);
            this.dtpDateJoined.Name = "dtpDateJoined";
            this.dtpDateJoined.Size = new System.Drawing.Size(200, 20);
            this.dtpDateJoined.TabIndex = 14;
            this.dtpDateJoined.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDateJoined
            // 
            this.lblDateJoined.AutoSize = true;
            this.lblDateJoined.Location = new System.Drawing.Point(309, 213);
            this.lblDateJoined.Name = "lblDateJoined";
            this.lblDateJoined.Size = new System.Drawing.Size(64, 13);
            this.lblDateJoined.TabIndex = 13;
            this.lblDateJoined.Text = "Date Joined";
            // 
            // udWeeklyHours
            // 
            this.udWeeklyHours.DecimalPlaces = 1;
            this.udWeeklyHours.Location = new System.Drawing.Point(20, 174);
            this.udWeeklyHours.Name = "udWeeklyHours";
            this.udWeeklyHours.Size = new System.Drawing.Size(80, 20);
            this.udWeeklyHours.TabIndex = 6;
            this.udWeeklyHours.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblWeeklyHours
            // 
            this.lblWeeklyHours.AutoSize = true;
            this.lblWeeklyHours.Location = new System.Drawing.Point(20, 158);
            this.lblWeeklyHours.Name = "lblWeeklyHours";
            this.lblWeeklyHours.Size = new System.Drawing.Size(74, 13);
            this.lblWeeklyHours.TabIndex = 5;
            this.lblWeeklyHours.Text = "Weekly Hours";
            // 
            // cmbPayPeriod
            // 
            this.cmbPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayPeriod.FormattingEnabled = true;
            this.cmbPayPeriod.Location = new System.Drawing.Point(20, 284);
            this.cmbPayPeriod.Name = "cmbPayPeriod";
            this.cmbPayPeriod.Size = new System.Drawing.Size(214, 21);
            this.cmbPayPeriod.TabIndex = 10;
            this.cmbPayPeriod.SelectedIndexChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.AutoSize = true;
            this.lblPayPeriod.Location = new System.Drawing.Point(20, 267);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(58, 13);
            this.lblPayPeriod.TabIndex = 9;
            this.lblPayPeriod.Text = "Pay Period";
            // 
            // txtPayrollNumber
            // 
            this.txtPayrollNumber.Location = new System.Drawing.Point(20, 230);
            this.txtPayrollNumber.Name = "txtPayrollNumber";
            this.txtPayrollNumber.Size = new System.Drawing.Size(214, 20);
            this.txtPayrollNumber.TabIndex = 8;
            this.txtPayrollNumber.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblPayrollNumber
            // 
            this.lblPayrollNumber.AutoSize = true;
            this.lblPayrollNumber.Location = new System.Drawing.Point(20, 213);
            this.lblPayrollNumber.Name = "lblPayrollNumber";
            this.lblPayrollNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPayrollNumber.TabIndex = 7;
            this.lblPayrollNumber.Text = "Payroll Number";
            // 
            // cbPartTime
            // 
            this.cbPartTime.AutoSize = true;
            this.cbPartTime.Location = new System.Drawing.Point(20, 126);
            this.cbPartTime.Name = "cbPartTime";
            this.cbPartTime.Size = new System.Drawing.Size(71, 17);
            this.cbPartTime.TabIndex = 4;
            this.cbPartTime.Text = "Part Time";
            this.cbPartTime.UseVisualStyleBackColor = true;
            this.cbPartTime.CheckedChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(20, 87);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(353, 20);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 70);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(20, 34);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(353, 20);
            this.txtJobTitle.TabIndex = 1;
            this.txtJobTitle.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Location = new System.Drawing.Point(20, 17);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(47, 13);
            this.lblJobTitle.TabIndex = 0;
            this.lblJobTitle.Text = "Job Title";
            // 
            // tabPagePersonal
            // 
            this.tabPagePersonal.Controls.Add(this.dtpDateOfBirth);
            this.tabPagePersonal.Controls.Add(this.lblDateOfBirth);
            this.tabPagePersonal.Controls.Add(this.cmbMaritalStatus);
            this.tabPagePersonal.Controls.Add(this.lblMaritalStatus);
            this.tabPagePersonal.Controls.Add(this.cmbGender);
            this.tabPagePersonal.Controls.Add(this.lblGender);
            this.tabPagePersonal.Controls.Add(this.cmbNationality);
            this.tabPagePersonal.Controls.Add(this.lblNationality);
            this.tabPagePersonal.Location = new System.Drawing.Point(4, 22);
            this.tabPagePersonal.Name = "tabPagePersonal";
            this.tabPagePersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersonal.Size = new System.Drawing.Size(558, 484);
            this.tabPagePersonal.TabIndex = 13;
            this.tabPagePersonal.Text = "Personal";
            this.tabPagePersonal.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(16, 194);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(206, 20);
            this.dtpDateOfBirth.TabIndex = 7;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(16, 177);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.lblDateOfBirth.TabIndex = 6;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(16, 142);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(206, 21);
            this.cmbMaritalStatus.TabIndex = 5;
            this.cmbMaritalStatus.SelectedIndexChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(16, 125);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(71, 13);
            this.lblMaritalStatus.TabIndex = 4;
            this.lblMaritalStatus.Text = "Marital Status";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(16, 88);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(206, 21);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(16, 71);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender";
            // 
            // cmbNationality
            // 
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(16, 33);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(206, 21);
            this.cmbNationality.TabIndex = 1;
            this.cmbNationality.SelectedIndexChanged += new System.EventHandler(this.StaffRecordChanged);
            this.cmbNationality.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCountry_Format);
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(16, 16);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(56, 13);
            this.lblNationality.TabIndex = 0;
            this.lblNationality.Text = "Nationality";
            // 
            // tabPageLeave
            // 
            this.tabPageLeave.Controls.Add(this.leaveRequests1);
            this.tabPageLeave.Controls.Add(this.rbLeaveHours);
            this.tabPageLeave.Controls.Add(this.rbLeaveDays);
            this.tabPageLeave.Controls.Add(this.cbLeaveCarriesOver);
            this.tabPageLeave.Controls.Add(this.cbLeaveAccrues);
            this.tabPageLeave.Controls.Add(this.udLeaveEntitlement);
            this.tabPageLeave.Controls.Add(this.lblLeaveEntitlement);
            this.tabPageLeave.Location = new System.Drawing.Point(4, 22);
            this.tabPageLeave.Name = "tabPageLeave";
            this.tabPageLeave.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeave.Size = new System.Drawing.Size(558, 484);
            this.tabPageLeave.TabIndex = 7;
            this.tabPageLeave.Text = "Holidays";
            this.tabPageLeave.UseVisualStyleBackColor = true;
            // 
            // leaveRequests1
            // 
            this.leaveRequests1.AllStaff = false;
            this.leaveRequests1.AutoRefresh = true;
            this.leaveRequests1.HideApproved = false;
            this.leaveRequests1.HideAuthorised = false;
            this.leaveRequests1.HideCancelled = false;
            this.leaveRequests1.HideDenied = false;
            this.leaveRequests1.HideRequested = false;
            this.leaveRequests1.HintControl = null;
            this.leaveRequests1.Location = new System.Drawing.Point(8, 50);
            this.leaveRequests1.MinimumSize = new System.Drawing.Size(347, 240);
            this.leaveRequests1.Name = "leaveRequests1";
            this.leaveRequests1.ShowCheckBoxes = false;
            this.leaveRequests1.Size = new System.Drawing.Size(542, 365);
            this.leaveRequests1.StaffMember = null;
            this.leaveRequests1.TabIndex = 6;
            // 
            // rbLeaveHours
            // 
            this.rbLeaveHours.AutoSize = true;
            this.rbLeaveHours.Location = new System.Drawing.Point(226, 23);
            this.rbLeaveHours.Name = "rbLeaveHours";
            this.rbLeaveHours.Size = new System.Drawing.Size(53, 17);
            this.rbLeaveHours.TabIndex = 3;
            this.rbLeaveHours.TabStop = true;
            this.rbLeaveHours.Text = "Hours";
            this.rbLeaveHours.UseVisualStyleBackColor = true;
            this.rbLeaveHours.CheckedChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // rbLeaveDays
            // 
            this.rbLeaveDays.AutoSize = true;
            this.rbLeaveDays.Location = new System.Drawing.Point(148, 23);
            this.rbLeaveDays.Name = "rbLeaveDays";
            this.rbLeaveDays.Size = new System.Drawing.Size(49, 17);
            this.rbLeaveDays.TabIndex = 2;
            this.rbLeaveDays.TabStop = true;
            this.rbLeaveDays.Text = "Days";
            this.rbLeaveDays.UseVisualStyleBackColor = true;
            this.rbLeaveDays.CheckedChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // cbLeaveCarriesOver
            // 
            this.cbLeaveCarriesOver.AutoSize = true;
            this.cbLeaveCarriesOver.Location = new System.Drawing.Point(324, 24);
            this.cbLeaveCarriesOver.Name = "cbLeaveCarriesOver";
            this.cbLeaveCarriesOver.Size = new System.Drawing.Size(84, 17);
            this.cbLeaveCarriesOver.TabIndex = 4;
            this.cbLeaveCarriesOver.Text = "Carries Over";
            this.cbLeaveCarriesOver.UseVisualStyleBackColor = true;
            this.cbLeaveCarriesOver.CheckedChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // cbLeaveAccrues
            // 
            this.cbLeaveAccrues.AutoSize = true;
            this.cbLeaveAccrues.Location = new System.Drawing.Point(468, 24);
            this.cbLeaveAccrues.Name = "cbLeaveAccrues";
            this.cbLeaveAccrues.Size = new System.Drawing.Size(65, 17);
            this.cbLeaveAccrues.TabIndex = 5;
            this.cbLeaveAccrues.Text = "Accrues";
            this.cbLeaveAccrues.UseVisualStyleBackColor = true;
            this.cbLeaveAccrues.CheckedChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // udLeaveEntitlement
            // 
            this.udLeaveEntitlement.DecimalPlaces = 1;
            this.udLeaveEntitlement.Location = new System.Drawing.Point(10, 24);
            this.udLeaveEntitlement.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLeaveEntitlement.Name = "udLeaveEntitlement";
            this.udLeaveEntitlement.Size = new System.Drawing.Size(120, 20);
            this.udLeaveEntitlement.TabIndex = 1;
            this.udLeaveEntitlement.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblLeaveEntitlement
            // 
            this.lblLeaveEntitlement.AutoSize = true;
            this.lblLeaveEntitlement.Location = new System.Drawing.Point(7, 7);
            this.lblLeaveEntitlement.Name = "lblLeaveEntitlement";
            this.lblLeaveEntitlement.Size = new System.Drawing.Size(91, 13);
            this.lblLeaveEntitlement.TabIndex = 0;
            this.lblLeaveEntitlement.Text = "Leave entitlement";
            // 
            // tabPageSickness
            // 
            this.tabPageSickness.Controls.Add(this.lvSicknessRecords);
            this.tabPageSickness.Location = new System.Drawing.Point(4, 22);
            this.tabPageSickness.Name = "tabPageSickness";
            this.tabPageSickness.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSickness.Size = new System.Drawing.Size(558, 484);
            this.tabPageSickness.TabIndex = 8;
            this.tabPageSickness.Text = "Sickness";
            this.tabPageSickness.UseVisualStyleBackColor = true;
            // 
            // lvSicknessRecords
            // 
            this.lvSicknessRecords.AllowColumnReorder = true;
            this.lvSicknessRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSicknessRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSicknessNotified,
            this.chSicknessReason,
            this.chSicknessStarted,
            this.chSicknessFinished,
            this.chSicknessTotal,
            this.chSicknessSelfCertified});
            this.lvSicknessRecords.ContextMenuStrip = this.pumSickness;
            this.lvSicknessRecords.FullRowSelect = true;
            this.lvSicknessRecords.HideSelection = false;
            this.lvSicknessRecords.Location = new System.Drawing.Point(6, 6);
            this.lvSicknessRecords.MinimumSize = new System.Drawing.Size(546, 300);
            this.lvSicknessRecords.MultiSelect = false;
            this.lvSicknessRecords.Name = "lvSicknessRecords";
            this.lvSicknessRecords.OwnerDraw = true;
            this.lvSicknessRecords.SaveName = "SicknessRecords";
            this.lvSicknessRecords.ShowToolTip = false;
            this.lvSicknessRecords.Size = new System.Drawing.Size(546, 366);
            this.lvSicknessRecords.TabIndex = 0;
            this.lvSicknessRecords.UseCompatibleStateImageBehavior = false;
            this.lvSicknessRecords.View = System.Windows.Forms.View.Details;
            this.lvSicknessRecords.DoubleClick += new System.EventHandler(this.lvSicknessRecords_DoubleClick);
            // 
            // chSicknessNotified
            // 
            this.chSicknessNotified.Text = "Notified";
            this.chSicknessNotified.Width = 153;
            // 
            // chSicknessReason
            // 
            this.chSicknessReason.Width = 152;
            // 
            // chSicknessStarted
            // 
            this.chSicknessStarted.Text = "Date Started";
            this.chSicknessStarted.Width = 153;
            // 
            // chSicknessFinished
            // 
            this.chSicknessFinished.Text = "Finished";
            this.chSicknessFinished.Width = 149;
            // 
            // pumSickness
            // 
            this.pumSickness.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pumSicknessNew,
            this.pumSicknessView,
            this.pumSicknessCancel,
            this.pumSicknessReturnToWork,
            this.toolStripMenuItem1,
            this.pumSicknessStatistics});
            this.pumSickness.Name = "pumSickness";
            this.pumSickness.Size = new System.Drawing.Size(155, 120);
            this.pumSickness.Opening += new System.ComponentModel.CancelEventHandler(this.pumSickness_Opening);
            // 
            // pumSicknessNew
            // 
            this.pumSicknessNew.Name = "pumSicknessNew";
            this.pumSicknessNew.Size = new System.Drawing.Size(154, 22);
            this.pumSicknessNew.Text = "New";
            this.pumSicknessNew.Click += new System.EventHandler(this.pumSicknessNew_Click);
            // 
            // pumSicknessView
            // 
            this.pumSicknessView.Name = "pumSicknessView";
            this.pumSicknessView.Size = new System.Drawing.Size(154, 22);
            this.pumSicknessView.Text = "View";
            this.pumSicknessView.Click += new System.EventHandler(this.pumSicknessView_Click);
            // 
            // pumSicknessCancel
            // 
            this.pumSicknessCancel.Name = "pumSicknessCancel";
            this.pumSicknessCancel.Size = new System.Drawing.Size(154, 22);
            this.pumSicknessCancel.Text = "Cancel";
            this.pumSicknessCancel.Click += new System.EventHandler(this.pumSicknessCancel_Click);
            // 
            // pumSicknessReturnToWork
            // 
            this.pumSicknessReturnToWork.Name = "pumSicknessReturnToWork";
            this.pumSicknessReturnToWork.Size = new System.Drawing.Size(154, 22);
            this.pumSicknessReturnToWork.Text = "Return to Work";
            this.pumSicknessReturnToWork.Click += new System.EventHandler(this.pumSicknessReturnToWork_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // pumSicknessStatistics
            // 
            this.pumSicknessStatistics.Name = "pumSicknessStatistics";
            this.pumSicknessStatistics.Size = new System.Drawing.Size(154, 22);
            this.pumSicknessStatistics.Text = "Statistics";
            this.pumSicknessStatistics.Click += new System.EventHandler(this.pumSicknessStatistics_Click);
            // 
            // tabPageEmergencyContact
            // 
            this.tabPageEmergencyContact.Controls.Add(this.txtEmergencyTel2);
            this.tabPageEmergencyContact.Controls.Add(this.lblEmergencContact2);
            this.tabPageEmergencyContact.Controls.Add(this.txtEmergencyRelation);
            this.tabPageEmergencyContact.Controls.Add(this.lblEmergencRelation);
            this.tabPageEmergencyContact.Controls.Add(this.txtEmergencyTel1);
            this.tabPageEmergencyContact.Controls.Add(this.lblEmergencContact1);
            this.tabPageEmergencyContact.Controls.Add(this.txtEmergencyContactName);
            this.tabPageEmergencyContact.Controls.Add(this.lblEmergencyName);
            this.tabPageEmergencyContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmergencyContact.Name = "tabPageEmergencyContact";
            this.tabPageEmergencyContact.Size = new System.Drawing.Size(558, 484);
            this.tabPageEmergencyContact.TabIndex = 10;
            this.tabPageEmergencyContact.Text = "Emergency Contact";
            this.tabPageEmergencyContact.UseVisualStyleBackColor = true;
            // 
            // txtEmergencyTel2
            // 
            this.txtEmergencyTel2.Location = new System.Drawing.Point(16, 126);
            this.txtEmergencyTel2.MaxLength = 40;
            this.txtEmergencyTel2.Name = "txtEmergencyTel2";
            this.txtEmergencyTel2.Size = new System.Drawing.Size(422, 20);
            this.txtEmergencyTel2.TabIndex = 5;
            this.txtEmergencyTel2.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblEmergencContact2
            // 
            this.lblEmergencContact2.AutoSize = true;
            this.lblEmergencContact2.Location = new System.Drawing.Point(13, 110);
            this.lblEmergencContact2.Name = "lblEmergencContact2";
            this.lblEmergencContact2.Size = new System.Drawing.Size(163, 13);
            this.lblEmergencContact2.TabIndex = 4;
            this.lblEmergencContact2.Text = "Emergency Contact Telephone 2";
            // 
            // txtEmergencyRelation
            // 
            this.txtEmergencyRelation.Location = new System.Drawing.Point(16, 176);
            this.txtEmergencyRelation.MaxLength = 100;
            this.txtEmergencyRelation.Name = "txtEmergencyRelation";
            this.txtEmergencyRelation.Size = new System.Drawing.Size(422, 20);
            this.txtEmergencyRelation.TabIndex = 7;
            this.txtEmergencyRelation.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblEmergencRelation
            // 
            this.lblEmergencRelation.AutoSize = true;
            this.lblEmergencRelation.Location = new System.Drawing.Point(13, 160);
            this.lblEmergencRelation.Name = "lblEmergencRelation";
            this.lblEmergencRelation.Size = new System.Drawing.Size(161, 13);
            this.lblEmergencRelation.TabIndex = 6;
            this.lblEmergencRelation.Text = "Emergency Contact Relationship";
            // 
            // txtEmergencyTel1
            // 
            this.txtEmergencyTel1.Location = new System.Drawing.Point(16, 77);
            this.txtEmergencyTel1.MaxLength = 40;
            this.txtEmergencyTel1.Name = "txtEmergencyTel1";
            this.txtEmergencyTel1.Size = new System.Drawing.Size(422, 20);
            this.txtEmergencyTel1.TabIndex = 3;
            this.txtEmergencyTel1.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblEmergencContact1
            // 
            this.lblEmergencContact1.AutoSize = true;
            this.lblEmergencContact1.Location = new System.Drawing.Point(13, 61);
            this.lblEmergencContact1.Name = "lblEmergencContact1";
            this.lblEmergencContact1.Size = new System.Drawing.Size(163, 13);
            this.lblEmergencContact1.TabIndex = 2;
            this.lblEmergencContact1.Text = "Emergency Contact Telephone 2";
            // 
            // txtEmergencyContactName
            // 
            this.txtEmergencyContactName.Location = new System.Drawing.Point(16, 28);
            this.txtEmergencyContactName.MaxLength = 100;
            this.txtEmergencyContactName.Name = "txtEmergencyContactName";
            this.txtEmergencyContactName.Size = new System.Drawing.Size(422, 20);
            this.txtEmergencyContactName.TabIndex = 1;
            this.txtEmergencyContactName.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblEmergencyName
            // 
            this.lblEmergencyName.AutoSize = true;
            this.lblEmergencyName.Location = new System.Drawing.Point(13, 12);
            this.lblEmergencyName.Name = "lblEmergencyName";
            this.lblEmergencyName.Size = new System.Drawing.Size(100, 13);
            this.lblEmergencyName.TabIndex = 0;
            this.lblEmergencyName.Text = "Emergency Contact";
            // 
            // tabPageLicenceDetails
            // 
            this.tabPageLicenceDetails.Controls.Add(this.txtDLNotes);
            this.tabPageLicenceDetails.Controls.Add(this.lblDLNotes);
            this.tabPageLicenceDetails.Controls.Add(this.dtpDLExpires);
            this.tabPageLicenceDetails.Controls.Add(this.lblDLExpires);
            this.tabPageLicenceDetails.Controls.Add(this.txtDLNumber);
            this.tabPageLicenceDetails.Controls.Add(this.lblDLNumber);
            this.tabPageLicenceDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageLicenceDetails.Name = "tabPageLicenceDetails";
            this.tabPageLicenceDetails.Size = new System.Drawing.Size(558, 484);
            this.tabPageLicenceDetails.TabIndex = 12;
            this.tabPageLicenceDetails.Text = "Licence";
            this.tabPageLicenceDetails.UseVisualStyleBackColor = true;
            // 
            // txtDLNotes
            // 
            this.txtDLNotes.Location = new System.Drawing.Point(13, 143);
            this.txtDLNotes.MaxLength = 200;
            this.txtDLNotes.Multiline = true;
            this.txtDLNotes.Name = "txtDLNotes";
            this.txtDLNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDLNotes.Size = new System.Drawing.Size(531, 234);
            this.txtDLNotes.TabIndex = 5;
            this.txtDLNotes.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDLNotes
            // 
            this.lblDLNotes.AutoSize = true;
            this.lblDLNotes.Location = new System.Drawing.Point(10, 127);
            this.lblDLNotes.Name = "lblDLNotes";
            this.lblDLNotes.Size = new System.Drawing.Size(35, 13);
            this.lblDLNotes.TabIndex = 4;
            this.lblDLNotes.Text = "Notes";
            // 
            // dtpDLExpires
            // 
            this.dtpDLExpires.Location = new System.Drawing.Point(13, 88);
            this.dtpDLExpires.Name = "dtpDLExpires";
            this.dtpDLExpires.Size = new System.Drawing.Size(200, 20);
            this.dtpDLExpires.TabIndex = 3;
            this.dtpDLExpires.ValueChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDLExpires
            // 
            this.lblDLExpires.AutoSize = true;
            this.lblDLExpires.Location = new System.Drawing.Point(10, 72);
            this.lblDLExpires.Name = "lblDLExpires";
            this.lblDLExpires.Size = new System.Drawing.Size(41, 13);
            this.lblDLExpires.TabIndex = 2;
            this.lblDLExpires.Text = "Expires";
            // 
            // txtDLNumber
            // 
            this.txtDLNumber.Location = new System.Drawing.Point(13, 32);
            this.txtDLNumber.MaxLength = 60;
            this.txtDLNumber.Name = "txtDLNumber";
            this.txtDLNumber.Size = new System.Drawing.Size(531, 20);
            this.txtDLNumber.TabIndex = 1;
            this.txtDLNumber.TextChanged += new System.EventHandler(this.StaffRecordChanged);
            // 
            // lblDLNumber
            // 
            this.lblDLNumber.AutoSize = true;
            this.lblDLNumber.Location = new System.Drawing.Point(10, 16);
            this.lblDLNumber.Name = "lblDLNumber";
            this.lblDLNumber.Size = new System.Drawing.Size(121, 13);
            this.lblDLNumber.TabIndex = 0;
            this.lblDLNumber.Text = "Driving Licence Number";
            // 
            // tabPageDiary
            // 
            this.tabPageDiary.Controls.Add(this.gbGroup);
            this.tabPageDiary.Controls.Add(this.lblEmployeeName);
            this.tabPageDiary.Controls.Add(this.txtEmployeeName);
            this.tabPageDiary.Controls.Add(this.gbLunch);
            this.tabPageDiary.Controls.Add(this.gbOptions);
            this.tabPageDiary.Controls.Add(this.gbWorkingHours);
            this.tabPageDiary.Controls.Add(this.gbWorkingDays);
            this.tabPageDiary.Location = new System.Drawing.Point(4, 40);
            this.tabPageDiary.Name = "tabPageDiary";
            this.tabPageDiary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiary.Size = new System.Drawing.Size(558, 466);
            this.tabPageDiary.TabIndex = 3;
            this.tabPageDiary.Text = "Diary";
            this.tabPageDiary.UseVisualStyleBackColor = true;
            // 
            // gbGroup
            // 
            this.gbGroup.Controls.Add(this.cmbGroup);
            this.gbGroup.Location = new System.Drawing.Point(259, 230);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Size = new System.Drawing.Size(185, 54);
            this.gbGroup.TabIndex = 8;
            this.gbGroup.TabStop = false;
            this.gbGroup.Text = "Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(13, 25);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(158, 21);
            this.cmbGroup.TabIndex = 0;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            this.cmbGroup.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbGroup_Format);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(16, 20);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 6;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(112, 17);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(332, 20);
            this.txtEmployeeName.TabIndex = 5;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // gbLunch
            // 
            this.gbLunch.Controls.Add(this.cmbLunchDuration);
            this.gbLunch.Controls.Add(this.lblLunchDuration);
            this.gbLunch.Controls.Add(this.cmbLunchStart);
            this.gbLunch.Controls.Add(this.lblLunchStart);
            this.gbLunch.Location = new System.Drawing.Point(16, 290);
            this.gbLunch.Name = "gbLunch";
            this.gbLunch.Size = new System.Drawing.Size(428, 74);
            this.gbLunch.TabIndex = 4;
            this.gbLunch.TabStop = false;
            this.gbLunch.Text = "Lunch";
            // 
            // cmbLunchDuration
            // 
            this.cmbLunchDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLunchDuration.FormattingEnabled = true;
            this.cmbLunchDuration.Location = new System.Drawing.Point(253, 37);
            this.cmbLunchDuration.Name = "cmbLunchDuration";
            this.cmbLunchDuration.Size = new System.Drawing.Size(161, 21);
            this.cmbLunchDuration.TabIndex = 3;
            this.cmbLunchDuration.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // lblLunchDuration
            // 
            this.lblLunchDuration.AutoSize = true;
            this.lblLunchDuration.Location = new System.Drawing.Point(250, 20);
            this.lblLunchDuration.Name = "lblLunchDuration";
            this.lblLunchDuration.Size = new System.Drawing.Size(80, 13);
            this.lblLunchDuration.TabIndex = 2;
            this.lblLunchDuration.Text = "Lunch Duration";
            // 
            // cmbLunchStart
            // 
            this.cmbLunchStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLunchStart.FormattingEnabled = true;
            this.cmbLunchStart.Location = new System.Drawing.Point(6, 37);
            this.cmbLunchStart.Name = "cmbLunchStart";
            this.cmbLunchStart.Size = new System.Drawing.Size(217, 21);
            this.cmbLunchStart.TabIndex = 1;
            this.cmbLunchStart.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // lblLunchStart
            // 
            this.lblLunchStart.AutoSize = true;
            this.lblLunchStart.Location = new System.Drawing.Point(9, 20);
            this.lblLunchStart.Name = "lblLunchStart";
            this.lblLunchStart.Size = new System.Drawing.Size(62, 13);
            this.lblLunchStart.TabIndex = 0;
            this.lblLunchStart.Text = "Lunch Start";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cbPublicDiary);
            this.gbOptions.Controls.Add(this.cbBookCurrentDay);
            this.gbOptions.Location = new System.Drawing.Point(259, 146);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(185, 78);
            this.gbOptions.TabIndex = 3;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // cbPublicDiary
            // 
            this.cbPublicDiary.AutoSize = true;
            this.cbPublicDiary.Location = new System.Drawing.Point(19, 53);
            this.cbPublicDiary.Name = "cbPublicDiary";
            this.cbPublicDiary.Size = new System.Drawing.Size(82, 17);
            this.cbPublicDiary.TabIndex = 1;
            this.cbPublicDiary.Text = "Public Diary";
            this.cbPublicDiary.UseVisualStyleBackColor = true;
            this.cbPublicDiary.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbBookCurrentDay
            // 
            this.cbBookCurrentDay.AutoSize = true;
            this.cbBookCurrentDay.Location = new System.Drawing.Point(19, 29);
            this.cbBookCurrentDay.Name = "cbBookCurrentDay";
            this.cbBookCurrentDay.Size = new System.Drawing.Size(110, 17);
            this.cbBookCurrentDay.TabIndex = 0;
            this.cbBookCurrentDay.Text = "Book Current Day";
            this.cbBookCurrentDay.UseVisualStyleBackColor = true;
            this.cbBookCurrentDay.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // gbWorkingHours
            // 
            this.gbWorkingHours.Controls.Add(this.cmbFinishTime);
            this.gbWorkingHours.Controls.Add(this.cmbStartTime);
            this.gbWorkingHours.Controls.Add(this.lblWorkingFinishTime);
            this.gbWorkingHours.Controls.Add(this.lblWorkingStartTime);
            this.gbWorkingHours.Location = new System.Drawing.Point(16, 146);
            this.gbWorkingHours.Name = "gbWorkingHours";
            this.gbWorkingHours.Size = new System.Drawing.Size(229, 138);
            this.gbWorkingHours.TabIndex = 2;
            this.gbWorkingHours.TabStop = false;
            this.gbWorkingHours.Text = "Working Hours";
            // 
            // cmbFinishTime
            // 
            this.cmbFinishTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinishTime.FormattingEnabled = true;
            this.cmbFinishTime.Location = new System.Drawing.Point(6, 98);
            this.cmbFinishTime.Name = "cmbFinishTime";
            this.cmbFinishTime.Size = new System.Drawing.Size(217, 21);
            this.cmbFinishTime.TabIndex = 3;
            this.cmbFinishTime.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(6, 46);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(217, 21);
            this.cmbStartTime.TabIndex = 2;
            this.cmbStartTime.SelectedIndexChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // lblWorkingFinishTime
            // 
            this.lblWorkingFinishTime.AutoSize = true;
            this.lblWorkingFinishTime.Location = new System.Drawing.Point(6, 79);
            this.lblWorkingFinishTime.Name = "lblWorkingFinishTime";
            this.lblWorkingFinishTime.Size = new System.Drawing.Size(60, 13);
            this.lblWorkingFinishTime.TabIndex = 1;
            this.lblWorkingFinishTime.Text = "Finish Time";
            // 
            // lblWorkingStartTime
            // 
            this.lblWorkingStartTime.AutoSize = true;
            this.lblWorkingStartTime.Location = new System.Drawing.Point(6, 29);
            this.lblWorkingStartTime.Name = "lblWorkingStartTime";
            this.lblWorkingStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblWorkingStartTime.TabIndex = 0;
            this.lblWorkingStartTime.Text = "Start Time";
            // 
            // gbWorkingDays
            // 
            this.gbWorkingDays.Controls.Add(this.cbSunday);
            this.gbWorkingDays.Controls.Add(this.cbSaturday);
            this.gbWorkingDays.Controls.Add(this.cbFriday);
            this.gbWorkingDays.Controls.Add(this.cbThursday);
            this.gbWorkingDays.Controls.Add(this.cbWednesday);
            this.gbWorkingDays.Controls.Add(this.cbTuesday);
            this.gbWorkingDays.Controls.Add(this.cbMonday);
            this.gbWorkingDays.Location = new System.Drawing.Point(16, 46);
            this.gbWorkingDays.Name = "gbWorkingDays";
            this.gbWorkingDays.Size = new System.Drawing.Size(428, 94);
            this.gbWorkingDays.TabIndex = 1;
            this.gbWorkingDays.TabStop = false;
            this.gbWorkingDays.Text = "Working Days";
            // 
            // cbSunday
            // 
            this.cbSunday.AutoSize = true;
            this.cbSunday.Location = new System.Drawing.Point(207, 62);
            this.cbSunday.Name = "cbSunday";
            this.cbSunday.Size = new System.Drawing.Size(62, 17);
            this.cbSunday.TabIndex = 14;
            this.cbSunday.Text = "Sunday";
            this.cbSunday.UseVisualStyleBackColor = true;
            this.cbSunday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbSaturday
            // 
            this.cbSaturday.AutoSize = true;
            this.cbSaturday.Location = new System.Drawing.Point(110, 62);
            this.cbSaturday.Name = "cbSaturday";
            this.cbSaturday.Size = new System.Drawing.Size(68, 17);
            this.cbSaturday.TabIndex = 13;
            this.cbSaturday.Text = "Saturday";
            this.cbSaturday.UseVisualStyleBackColor = true;
            this.cbSaturday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbFriday
            // 
            this.cbFriday.AutoSize = true;
            this.cbFriday.Location = new System.Drawing.Point(15, 62);
            this.cbFriday.Name = "cbFriday";
            this.cbFriday.Size = new System.Drawing.Size(54, 17);
            this.cbFriday.TabIndex = 12;
            this.cbFriday.Text = "Friday";
            this.cbFriday.UseVisualStyleBackColor = true;
            this.cbFriday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbThursday
            // 
            this.cbThursday.AutoSize = true;
            this.cbThursday.Location = new System.Drawing.Point(331, 29);
            this.cbThursday.Name = "cbThursday";
            this.cbThursday.Size = new System.Drawing.Size(70, 17);
            this.cbThursday.TabIndex = 11;
            this.cbThursday.Text = "Thursday";
            this.cbThursday.UseVisualStyleBackColor = true;
            this.cbThursday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbWednesday
            // 
            this.cbWednesday.AutoSize = true;
            this.cbWednesday.Location = new System.Drawing.Point(207, 29);
            this.cbWednesday.Name = "cbWednesday";
            this.cbWednesday.Size = new System.Drawing.Size(83, 17);
            this.cbWednesday.TabIndex = 10;
            this.cbWednesday.Text = "Wednesday";
            this.cbWednesday.UseVisualStyleBackColor = true;
            this.cbWednesday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbTuesday
            // 
            this.cbTuesday.AutoSize = true;
            this.cbTuesday.Location = new System.Drawing.Point(110, 29);
            this.cbTuesday.Name = "cbTuesday";
            this.cbTuesday.Size = new System.Drawing.Size(67, 17);
            this.cbTuesday.TabIndex = 9;
            this.cbTuesday.Text = "Tuesday";
            this.cbTuesday.UseVisualStyleBackColor = true;
            this.cbTuesday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // cbMonday
            // 
            this.cbMonday.AutoSize = true;
            this.cbMonday.Location = new System.Drawing.Point(15, 29);
            this.cbMonday.Name = "cbMonday";
            this.cbMonday.Size = new System.Drawing.Size(64, 17);
            this.cbMonday.TabIndex = 8;
            this.cbMonday.Text = "Monday";
            this.cbMonday.UseVisualStyleBackColor = true;
            this.cbMonday.CheckedChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // tabPageWorkingHours
            // 
            this.tabPageWorkingHours.Controls.Add(this.lvWorkingHours);
            this.tabPageWorkingHours.Controls.Add(this.btnWorkingHoursDelete);
            this.tabPageWorkingHours.Controls.Add(this.btnWorkingHoursUpdate);
            this.tabPageWorkingHours.Controls.Add(this.btnWorkingHoursCreate);
            this.tabPageWorkingHours.Controls.Add(this.grpWorkingHours);
            this.tabPageWorkingHours.Controls.Add(this.lblCurrentWorkingRules);
            this.tabPageWorkingHours.Location = new System.Drawing.Point(4, 40);
            this.tabPageWorkingHours.Name = "tabPageWorkingHours";
            this.tabPageWorkingHours.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkingHours.Size = new System.Drawing.Size(558, 466);
            this.tabPageWorkingHours.TabIndex = 5;
            this.tabPageWorkingHours.Text = "Working Hours";
            this.tabPageWorkingHours.UseVisualStyleBackColor = true;
            // 
            // lvWorkingHours
            // 
            this.lvWorkingHours.AllowColumnReorder = true;
            this.lvWorkingHours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWorkingHours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colWorkingHoursStart,
            this.colWorkingHoursDay,
            this.colWorkingHoursRepeat,
            this.colWorkingHoursRepeatFrequency,
            this.colWorkingHoursTreatments});
            this.lvWorkingHours.FullRowSelect = true;
            this.lvWorkingHours.HideSelection = false;
            this.lvWorkingHours.Location = new System.Drawing.Point(8, 25);
            this.lvWorkingHours.MinimumSize = new System.Drawing.Size(544, 161);
            this.lvWorkingHours.Name = "lvWorkingHours";
            this.lvWorkingHours.OwnerDraw = true;
            this.lvWorkingHours.SaveName = "EmployeeWorkingRules";
            this.lvWorkingHours.ShowToolTip = false;
            this.lvWorkingHours.Size = new System.Drawing.Size(544, 209);
            this.lvWorkingHours.TabIndex = 20;
            this.lvWorkingHours.UseCompatibleStateImageBehavior = false;
            this.lvWorkingHours.View = System.Windows.Forms.View.Details;
            this.lvWorkingHours.SelectedIndexChanged += new System.EventHandler(this.lvWorkingHours_SelectedIndexChanged);
            // 
            // colWorkingHoursStart
            // 
            this.colWorkingHoursStart.Text = "Start Date";
            this.colWorkingHoursStart.Width = 112;
            // 
            // colWorkingHoursDay
            // 
            this.colWorkingHoursDay.Text = "Day";
            // 
            // colWorkingHoursRepeat
            // 
            this.colWorkingHoursRepeat.Text = "Repeat";
            this.colWorkingHoursRepeat.Width = 98;
            // 
            // colWorkingHoursRepeatFrequency
            // 
            this.colWorkingHoursRepeatFrequency.Text = "Repeat Frequency";
            this.colWorkingHoursRepeatFrequency.Width = 113;
            // 
            // colWorkingHoursTreatments
            // 
            this.colWorkingHoursTreatments.Text = "Allow Treatments";
            this.colWorkingHoursTreatments.Width = 98;
            // 
            // btnWorkingHoursDelete
            // 
            this.btnWorkingHoursDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWorkingHoursDelete.Location = new System.Drawing.Point(444, -69);
            this.btnWorkingHoursDelete.Name = "btnWorkingHoursDelete";
            this.btnWorkingHoursDelete.Size = new System.Drawing.Size(108, 23);
            this.btnWorkingHoursDelete.TabIndex = 19;
            this.btnWorkingHoursDelete.Text = "Delete";
            this.btnWorkingHoursDelete.UseVisualStyleBackColor = true;
            this.btnWorkingHoursDelete.Click += new System.EventHandler(this.btnWorkingHoursDelete_Click);
            // 
            // btnWorkingHoursUpdate
            // 
            this.btnWorkingHoursUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWorkingHoursUpdate.Location = new System.Drawing.Point(444, -98);
            this.btnWorkingHoursUpdate.Name = "btnWorkingHoursUpdate";
            this.btnWorkingHoursUpdate.Size = new System.Drawing.Size(108, 23);
            this.btnWorkingHoursUpdate.TabIndex = 18;
            this.btnWorkingHoursUpdate.Text = "Update";
            this.btnWorkingHoursUpdate.UseVisualStyleBackColor = true;
            this.btnWorkingHoursUpdate.Click += new System.EventHandler(this.btnWorkingHoursUpdate_Click);
            // 
            // btnWorkingHoursCreate
            // 
            this.btnWorkingHoursCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWorkingHoursCreate.Location = new System.Drawing.Point(444, -128);
            this.btnWorkingHoursCreate.Name = "btnWorkingHoursCreate";
            this.btnWorkingHoursCreate.Size = new System.Drawing.Size(108, 23);
            this.btnWorkingHoursCreate.TabIndex = 17;
            this.btnWorkingHoursCreate.Text = "New";
            this.btnWorkingHoursCreate.UseVisualStyleBackColor = true;
            this.btnWorkingHoursCreate.Click += new System.EventHandler(this.btnWorkingHoursCreate_Click);
            // 
            // grpWorkingHours
            // 
            this.grpWorkingHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpWorkingHours.Controls.Add(this.cbAllowTreatments);
            this.grpWorkingHours.Controls.Add(this.lblFrequency);
            this.grpWorkingHours.Controls.Add(this.txtFrequency);
            this.grpWorkingHours.Controls.Add(this.lblEvery);
            this.grpWorkingHours.Controls.Add(this.cmbWorkingHoursRepeatOption);
            this.grpWorkingHours.Controls.Add(this.lblRepeatFrequency);
            this.grpWorkingHours.Controls.Add(this.lblRepeatOption);
            this.grpWorkingHours.Controls.Add(this.cmbWorkingHoursFinish);
            this.grpWorkingHours.Controls.Add(this.cmbWorkingHoursStart);
            this.grpWorkingHours.Controls.Add(this.lblStartHour);
            this.grpWorkingHours.Controls.Add(this.lblFinishHour);
            this.grpWorkingHours.Controls.Add(this.lblStartDate);
            this.grpWorkingHours.Controls.Add(this.dtWorkingHoursDate);
            this.grpWorkingHours.Location = new System.Drawing.Point(8, 258);
            this.grpWorkingHours.Name = "grpWorkingHours";
            this.grpWorkingHours.Size = new System.Drawing.Size(430, 172);
            this.grpWorkingHours.TabIndex = 16;
            this.grpWorkingHours.TabStop = false;
            this.grpWorkingHours.Text = "Edit Working Hours";
            // 
            // cbAllowTreatments
            // 
            this.cbAllowTreatments.AutoSize = true;
            this.cbAllowTreatments.Location = new System.Drawing.Point(229, 142);
            this.cbAllowTreatments.Name = "cbAllowTreatments";
            this.cbAllowTreatments.Size = new System.Drawing.Size(107, 17);
            this.cbAllowTreatments.TabIndex = 20;
            this.cbAllowTreatments.Text = "Allow Treatments";
            this.cbAllowTreatments.UseVisualStyleBackColor = true;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(353, 97);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(41, 13);
            this.lblFrequency.TabIndex = 19;
            this.lblFrequency.Text = "Weeks";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(295, 94);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(41, 20);
            this.txtFrequency.TabIndex = 18;
            // 
            // lblEvery
            // 
            this.lblEvery.AutoSize = true;
            this.lblEvery.Location = new System.Drawing.Point(226, 97);
            this.lblEvery.Name = "lblEvery";
            this.lblEvery.Size = new System.Drawing.Size(34, 13);
            this.lblEvery.TabIndex = 17;
            this.lblEvery.Text = "Every";
            // 
            // cmbWorkingHoursRepeatOption
            // 
            this.cmbWorkingHoursRepeatOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingHoursRepeatOption.FormattingEnabled = true;
            this.cmbWorkingHoursRepeatOption.Location = new System.Drawing.Point(229, 41);
            this.cmbWorkingHoursRepeatOption.Name = "cmbWorkingHoursRepeatOption";
            this.cmbWorkingHoursRepeatOption.Size = new System.Drawing.Size(121, 21);
            this.cmbWorkingHoursRepeatOption.TabIndex = 16;
            // 
            // lblRepeatFrequency
            // 
            this.lblRepeatFrequency.AutoSize = true;
            this.lblRepeatFrequency.Location = new System.Drawing.Point(226, 77);
            this.lblRepeatFrequency.Name = "lblRepeatFrequency";
            this.lblRepeatFrequency.Size = new System.Drawing.Size(95, 13);
            this.lblRepeatFrequency.TabIndex = 15;
            this.lblRepeatFrequency.Text = "Repeat Frequency";
            // 
            // lblRepeatOption
            // 
            this.lblRepeatOption.AutoSize = true;
            this.lblRepeatOption.Location = new System.Drawing.Point(226, 25);
            this.lblRepeatOption.Name = "lblRepeatOption";
            this.lblRepeatOption.Size = new System.Drawing.Size(76, 13);
            this.lblRepeatOption.TabIndex = 14;
            this.lblRepeatOption.Text = "Repeat Option";
            // 
            // cmbWorkingHoursFinish
            // 
            this.cmbWorkingHoursFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingHoursFinish.FormattingEnabled = true;
            this.cmbWorkingHoursFinish.Location = new System.Drawing.Point(6, 142);
            this.cmbWorkingHoursFinish.Name = "cmbWorkingHoursFinish";
            this.cmbWorkingHoursFinish.Size = new System.Drawing.Size(196, 21);
            this.cmbWorkingHoursFinish.TabIndex = 11;
            // 
            // cmbWorkingHoursStart
            // 
            this.cmbWorkingHoursStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingHoursStart.FormattingEnabled = true;
            this.cmbWorkingHoursStart.Location = new System.Drawing.Point(6, 94);
            this.cmbWorkingHoursStart.Name = "cmbWorkingHoursStart";
            this.cmbWorkingHoursStart.Size = new System.Drawing.Size(199, 21);
            this.cmbWorkingHoursStart.TabIndex = 10;
            // 
            // lblStartHour
            // 
            this.lblStartHour.AutoSize = true;
            this.lblStartHour.Location = new System.Drawing.Point(6, 77);
            this.lblStartHour.Name = "lblStartHour";
            this.lblStartHour.Size = new System.Drawing.Size(55, 13);
            this.lblStartHour.TabIndex = 9;
            this.lblStartHour.Text = "Start Hour";
            // 
            // lblFinishHour
            // 
            this.lblFinishHour.AutoSize = true;
            this.lblFinishHour.Location = new System.Drawing.Point(6, 126);
            this.lblFinishHour.Name = "lblFinishHour";
            this.lblFinishHour.Size = new System.Drawing.Size(60, 13);
            this.lblFinishHour.TabIndex = 8;
            this.lblFinishHour.Text = "Finish Hour";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(6, 25);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtWorkingHoursDate
            // 
            this.dtWorkingHoursDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWorkingHoursDate.Location = new System.Drawing.Point(6, 42);
            this.dtWorkingHoursDate.Name = "dtWorkingHoursDate";
            this.dtWorkingHoursDate.Size = new System.Drawing.Size(200, 20);
            this.dtWorkingHoursDate.TabIndex = 6;
            // 
            // lblCurrentWorkingRules
            // 
            this.lblCurrentWorkingRules.AutoSize = true;
            this.lblCurrentWorkingRules.Location = new System.Drawing.Point(8, 9);
            this.lblCurrentWorkingRules.Name = "lblCurrentWorkingRules";
            this.lblCurrentWorkingRules.Size = new System.Drawing.Size(114, 13);
            this.lblCurrentWorkingRules.TabIndex = 15;
            this.lblCurrentWorkingRules.Text = "Current Working Rules";
            // 
            // tabPageTreatments
            // 
            this.tabPageTreatments.Controls.Add(this.btnRemove);
            this.tabPageTreatments.Controls.Add(this.btnAdd);
            this.tabPageTreatments.Controls.Add(this.lblAssignedPermissions);
            this.tabPageTreatments.Controls.Add(this.lbTherapistTreatments);
            this.tabPageTreatments.Controls.Add(this.lblAvailableTreatments);
            this.tabPageTreatments.Controls.Add(this.lbAvailableTreatments);
            this.tabPageTreatments.Location = new System.Drawing.Point(4, 40);
            this.tabPageTreatments.Name = "tabPageTreatments";
            this.tabPageTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreatments.Size = new System.Drawing.Size(558, 466);
            this.tabPageTreatments.TabIndex = 4;
            this.tabPageTreatments.Text = "Treatments";
            this.tabPageTreatments.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(235, 140);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "<< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(235, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAssignedPermissions
            // 
            this.lblAssignedPermissions.AutoSize = true;
            this.lblAssignedPermissions.Location = new System.Drawing.Point(317, 12);
            this.lblAssignedPermissions.Name = "lblAssignedPermissions";
            this.lblAssignedPermissions.Size = new System.Drawing.Size(106, 13);
            this.lblAssignedPermissions.TabIndex = 4;
            this.lblAssignedPermissions.Text = "Assigned Treatments";
            // 
            // lbTherapistTreatments
            // 
            this.lbTherapistTreatments.FormattingEnabled = true;
            this.lbTherapistTreatments.Location = new System.Drawing.Point(320, 32);
            this.lbTherapistTreatments.Name = "lbTherapistTreatments";
            this.lbTherapistTreatments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTherapistTreatments.Size = new System.Drawing.Size(220, 329);
            this.lbTherapistTreatments.TabIndex = 3;
            this.lbTherapistTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTreatments_Format);
            this.lbTherapistTreatments.DoubleClick += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblAvailableTreatments
            // 
            this.lblAvailableTreatments.AutoSize = true;
            this.lblAvailableTreatments.Location = new System.Drawing.Point(6, 12);
            this.lblAvailableTreatments.Name = "lblAvailableTreatments";
            this.lblAvailableTreatments.Size = new System.Drawing.Size(106, 13);
            this.lblAvailableTreatments.TabIndex = 2;
            this.lblAvailableTreatments.Text = "Available Treatments";
            // 
            // lbAvailableTreatments
            // 
            this.lbAvailableTreatments.FormattingEnabled = true;
            this.lbAvailableTreatments.Location = new System.Drawing.Point(6, 32);
            this.lbAvailableTreatments.Name = "lbAvailableTreatments";
            this.lbAvailableTreatments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbAvailableTreatments.Size = new System.Drawing.Size(220, 329);
            this.lbAvailableTreatments.TabIndex = 1;
            this.lbAvailableTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTreatments_Format);
            this.lbAvailableTreatments.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabPagePermissions
            // 
            this.tabPagePermissions.Controls.Add(this.permissions1);
            this.tabPagePermissions.Location = new System.Drawing.Point(4, 40);
            this.tabPagePermissions.Name = "tabPagePermissions";
            this.tabPagePermissions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePermissions.Size = new System.Drawing.Size(558, 466);
            this.tabPagePermissions.TabIndex = 6;
            this.tabPagePermissions.Text = "Permissions";
            this.tabPagePermissions.UseVisualStyleBackColor = true;
            // 
            // permissions1
            // 
            this.permissions1.HintControl = null;
            this.permissions1.Location = new System.Drawing.Point(3, 3);
            this.permissions1.Name = "permissions1";
            this.permissions1.Size = new System.Drawing.Size(537, 361);
            this.permissions1.TabIndex = 0;
            this.permissions1.OnPermissionsChanged += new System.EventHandler(this.StaffDetailsChanged);
            // 
            // tabPageCommission
            // 
            this.tabPageCommission.Controls.Add(this.lblCommissionDetails);
            this.tabPageCommission.Controls.Add(this.lvCommissionPayments);
            this.tabPageCommission.Location = new System.Drawing.Point(4, 40);
            this.tabPageCommission.Name = "tabPageCommission";
            this.tabPageCommission.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommission.Size = new System.Drawing.Size(558, 466);
            this.tabPageCommission.TabIndex = 14;
            this.tabPageCommission.Text = "Commission";
            this.tabPageCommission.UseVisualStyleBackColor = true;
            this.tabPageCommission.Enter += new System.EventHandler(this.tabPageCommission_Enter);
            // 
            // lblCommissionDetails
            // 
            this.lblCommissionDetails.AutoSize = true;
            this.lblCommissionDetails.Location = new System.Drawing.Point(6, 392);
            this.lblCommissionDetails.Name = "lblCommissionDetails";
            this.lblCommissionDetails.Size = new System.Drawing.Size(35, 13);
            this.lblCommissionDetails.TabIndex = 1;
            this.lblCommissionDetails.Text = "label1";
            // 
            // lvCommissionPayments
            // 
            this.lvCommissionPayments.AllowColumnReorder = true;
            this.lvCommissionPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCommissionPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCommissionDate,
            this.chCommissionAmount,
            this.chCommissionAuthorising,
            this.chCommissionType});
            this.lvCommissionPayments.Location = new System.Drawing.Point(6, 6);
            this.lvCommissionPayments.MinimumSize = new System.Drawing.Size(546, 334);
            this.lvCommissionPayments.Name = "lvCommissionPayments";
            this.lvCommissionPayments.OwnerDraw = true;
            this.lvCommissionPayments.SaveName = "StaffDetailsCommission";
            this.lvCommissionPayments.ShowToolTip = false;
            this.lvCommissionPayments.Size = new System.Drawing.Size(546, 382);
            this.lvCommissionPayments.TabIndex = 0;
            this.lvCommissionPayments.UseCompatibleStateImageBehavior = false;
            this.lvCommissionPayments.View = System.Windows.Forms.View.Details;
            // 
            // chCommissionDate
            // 
            this.chCommissionDate.Text = "Date";
            this.chCommissionDate.Width = 118;
            // 
            // chCommissionAmount
            // 
            this.chCommissionAmount.Text = "Amount";
            this.chCommissionAmount.Width = 103;
            // 
            // chCommissionAuthorising
            // 
            this.chCommissionAuthorising.Text = "Authorising";
            this.chCommissionAuthorising.Width = 175;
            // 
            // chCommissionType
            // 
            this.chCommissionType.Text = "Type";
            this.chCommissionType.Width = 128;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.lvClients);
            this.tabPageClients.Controls.Add(this.udCommissionManager);
            this.tabPageClients.Controls.Add(this.lblCommisionManagerRate);
            this.tabPageClients.Controls.Add(this.udCommissionStaff);
            this.tabPageClients.Controls.Add(this.lblCommisionStaffRate);
            this.tabPageClients.Location = new System.Drawing.Point(4, 40);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(558, 489);
            this.tabPageClients.TabIndex = 15;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // lvClients
            // 
            this.lvClients.AllowColumnReorder = true;
            this.lvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chClientsName,
            this.chClientsTelephone,
            this.chClientsCompany,
            this.chClientsState,
            this.chClientsAddress});
            this.lvClients.Location = new System.Drawing.Point(7, 65);
            this.lvClients.Name = "lvClients";
            this.lvClients.OwnerDraw = true;
            this.lvClients.SaveName = "";
            this.lvClients.ShowToolTip = false;
            this.lvClients.Size = new System.Drawing.Size(545, 370);
            this.lvClients.TabIndex = 8;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // chClientsName
            // 
            this.chClientsName.Width = 129;
            // 
            // chClientsTelephone
            // 
            this.chClientsTelephone.Width = 116;
            // 
            // chClientsCompany
            // 
            this.chClientsCompany.DisplayIndex = 3;
            this.chClientsCompany.Width = 147;
            // 
            // chClientsState
            // 
            this.chClientsState.DisplayIndex = 4;
            // 
            // chClientsAddress
            // 
            this.chClientsAddress.DisplayIndex = 2;
            this.chClientsAddress.Width = 134;
            // 
            // udCommissionManager
            // 
            this.udCommissionManager.DecimalPlaces = 2;
            this.udCommissionManager.Location = new System.Drawing.Point(227, 20);
            this.udCommissionManager.Name = "udCommissionManager";
            this.udCommissionManager.Size = new System.Drawing.Size(87, 20);
            this.udCommissionManager.TabIndex = 7;
            this.udCommissionManager.ValueChanged += new System.EventHandler(this.udCommissionStaff_ValueChanged);
            // 
            // lblCommisionManagerRate
            // 
            this.lblCommisionManagerRate.AutoSize = true;
            this.lblCommisionManagerRate.Location = new System.Drawing.Point(224, 3);
            this.lblCommisionManagerRate.Name = "lblCommisionManagerRate";
            this.lblCommisionManagerRate.Size = new System.Drawing.Size(35, 13);
            this.lblCommisionManagerRate.TabIndex = 6;
            this.lblCommisionManagerRate.Text = "label2";
            // 
            // udCommissionStaff
            // 
            this.udCommissionStaff.DecimalPlaces = 2;
            this.udCommissionStaff.Location = new System.Drawing.Point(9, 19);
            this.udCommissionStaff.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.udCommissionStaff.Name = "udCommissionStaff";
            this.udCommissionStaff.Size = new System.Drawing.Size(87, 20);
            this.udCommissionStaff.TabIndex = 5;
            this.udCommissionStaff.ValueChanged += new System.EventHandler(this.udCommissionStaff_ValueChanged);
            // 
            // lblCommisionStaffRate
            // 
            this.lblCommisionStaffRate.AutoSize = true;
            this.lblCommisionStaffRate.Location = new System.Drawing.Point(6, 3);
            this.lblCommisionStaffRate.Name = "lblCommisionStaffRate";
            this.lblCommisionStaffRate.Size = new System.Drawing.Size(35, 13);
            this.lblCommisionStaffRate.TabIndex = 4;
            this.lblCommisionStaffRate.Text = "label1";
            // 
            // AdminStaffEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tvStaffMembers);
            this.Controls.Add(this.tabStaff);
            this.MinimumSize = new System.Drawing.Size(853, 570);
            this.Name = "AdminStaffEdit";
            this.Size = new System.Drawing.Size(853, 570);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabStaff.ResumeLayout(false);
            this.tabPageUserDetails.ResumeLayout(false);
            this.tabPageUserDetails.PerformLayout();
            this.tabPageContactDetails.ResumeLayout(false);
            this.tabPageContactDetails.PerformLayout();
            this.tabPageEmploymentDetails.ResumeLayout(false);
            this.tabPageEmploymentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udWeeklyHours)).EndInit();
            this.tabPagePersonal.ResumeLayout(false);
            this.tabPagePersonal.PerformLayout();
            this.tabPageLeave.ResumeLayout(false);
            this.tabPageLeave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLeaveEntitlement)).EndInit();
            this.tabPageSickness.ResumeLayout(false);
            this.pumSickness.ResumeLayout(false);
            this.tabPageEmergencyContact.ResumeLayout(false);
            this.tabPageEmergencyContact.PerformLayout();
            this.tabPageLicenceDetails.ResumeLayout(false);
            this.tabPageLicenceDetails.PerformLayout();
            this.tabPageDiary.ResumeLayout(false);
            this.tabPageDiary.PerformLayout();
            this.gbGroup.ResumeLayout(false);
            this.gbLunch.ResumeLayout(false);
            this.gbLunch.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.gbWorkingHours.ResumeLayout(false);
            this.gbWorkingHours.PerformLayout();
            this.gbWorkingDays.ResumeLayout(false);
            this.gbWorkingDays.PerformLayout();
            this.tabPageWorkingHours.ResumeLayout(false);
            this.tabPageWorkingHours.PerformLayout();
            this.grpWorkingHours.ResumeLayout(false);
            this.grpWorkingHours.PerformLayout();
            this.tabPageTreatments.ResumeLayout(false);
            this.tabPageTreatments.PerformLayout();
            this.tabPagePermissions.ResumeLayout(false);
            this.tabPageCommission.ResumeLayout(false);
            this.tabPageCommission.PerformLayout();
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabStaff;
        private System.Windows.Forms.TabPage tabPageUserDetails;
        private System.Windows.Forms.ComboBox cmbMemberLevel;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddLine3;
        private System.Windows.Forms.TextBox txtAddLine2;
        private System.Windows.Forms.TextBox txtAddLine1;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMemberLevel;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddressLine3;
        private System.Windows.Forms.Label lblAddressLine2;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.Label lblBusinessName;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TabPage tabPageDiary;
        private System.Windows.Forms.TabPage tabPageTreatments;
        private System.Windows.Forms.GroupBox gbWorkingDays;
        private System.Windows.Forms.CheckBox cbSunday;
        private System.Windows.Forms.CheckBox cbSaturday;
        private System.Windows.Forms.CheckBox cbFriday;
        private System.Windows.Forms.CheckBox cbThursday;
        private System.Windows.Forms.CheckBox cbWednesday;
        private System.Windows.Forms.CheckBox cbTuesday;
        private System.Windows.Forms.CheckBox cbMonday;
        private System.Windows.Forms.GroupBox gbWorkingHours;
        private System.Windows.Forms.ComboBox cmbFinishTime;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.Label lblWorkingFinishTime;
        private System.Windows.Forms.Label lblWorkingStartTime;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAssignedPermissions;
        private System.Windows.Forms.ListBox lbTherapistTreatments;
        private System.Windows.Forms.Label lblAvailableTreatments;
        private System.Windows.Forms.ListBox lbAvailableTreatments;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cbBookCurrentDay;
        private System.Windows.Forms.CheckBox cbPublicDiary;
        private System.Windows.Forms.GroupBox gbLunch;
        private System.Windows.Forms.ComboBox cmbLunchDuration;
        private System.Windows.Forms.Label lblLunchDuration;
        private System.Windows.Forms.ComboBox cmbLunchStart;
        private System.Windows.Forms.Label lblLunchStart;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TabPage tabPageWorkingHours;
        private System.Windows.Forms.Label lblCurrentWorkingRules;
        private System.Windows.Forms.GroupBox grpWorkingHours;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label lblEvery;
        private System.Windows.Forms.ComboBox cmbWorkingHoursRepeatOption;
        private System.Windows.Forms.Label lblRepeatFrequency;
        private System.Windows.Forms.Label lblRepeatOption;
        private System.Windows.Forms.ComboBox cmbWorkingHoursFinish;
        private System.Windows.Forms.ComboBox cmbWorkingHoursStart;
        private System.Windows.Forms.Label lblStartHour;
        private System.Windows.Forms.Label lblFinishHour;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtWorkingHoursDate;
        private System.Windows.Forms.Button btnWorkingHoursDelete;
        private System.Windows.Forms.Button btnWorkingHoursUpdate;
        private System.Windows.Forms.Button btnWorkingHoursCreate;
        private System.Windows.Forms.CheckBox cbAllowTreatments;
        private System.Windows.Forms.TabPage tabPagePermissions;
        private POS.Base.Controls.Permissions permissions1;
        private System.Windows.Forms.GroupBox gbGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private SharedControls.Controls.TreeViewEx tvStaffMembers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddStaff;
        private System.Windows.Forms.ImageList ilTreeNode;
        private System.Windows.Forms.TabPage tabPageLeave;
        private System.Windows.Forms.ContextMenuStrip pumTreeView;
        private System.Windows.Forms.ImageList ilToolbar;
        private System.Windows.Forms.ToolStripButton tsbRemoveStaff;
        private System.Windows.Forms.TabPage tabPageSickness;
        private System.Windows.Forms.TabPage tabPageContactDetails;
        private System.Windows.Forms.TabPage tabPageEmploymentDetails;
        private System.Windows.Forms.TabPage tabPageEmergencyContact;
        private System.Windows.Forms.TabPage tabPageLicenceDetails;
        private System.Windows.Forms.TextBox txtEmergencyTel2;
        private System.Windows.Forms.Label lblEmergencContact2;
        private System.Windows.Forms.TextBox txtEmergencyRelation;
        private System.Windows.Forms.Label lblEmergencRelation;
        private System.Windows.Forms.TextBox txtEmergencyTel1;
        private System.Windows.Forms.Label lblEmergencContact1;
        private System.Windows.Forms.TextBox txtEmergencyContactName;
        private System.Windows.Forms.Label lblEmergencyName;
        private System.Windows.Forms.TextBox txtDLNotes;
        private System.Windows.Forms.Label lblDLNotes;
        private System.Windows.Forms.DateTimePicker dtpDLExpires;
        private System.Windows.Forms.Label lblDLExpires;
        private System.Windows.Forms.TextBox txtDLNumber;
        private System.Windows.Forms.Label lblDLNumber;
        private System.Windows.Forms.TextBox txtContactOther;
        private System.Windows.Forms.Label lblContactOther;
        private System.Windows.Forms.TextBox txtContactWork;
        private System.Windows.Forms.Label lblContactWork;
        private System.Windows.Forms.TextBox txtContactMobile;
        private System.Windows.Forms.Label lblContactMobile;
        private System.Windows.Forms.TextBox txtContactHome;
        private System.Windows.Forms.Label lblContactHome;
        private System.Windows.Forms.NumericUpDown udWeeklyHours;
        private System.Windows.Forms.Label lblWeeklyHours;
        private System.Windows.Forms.ComboBox cmbPayPeriod;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.TextBox txtPayrollNumber;
        private System.Windows.Forms.Label lblPayrollNumber;
        private System.Windows.Forms.CheckBox cbPartTime;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.TabPage tabPagePersonal;
        private System.Windows.Forms.DateTimePicker dtpDateProbationEnds;
        private System.Windows.Forms.Label lblDateProbationEnds;
        private System.Windows.Forms.DateTimePicker dtpDatePermanent;
        private System.Windows.Forms.Label lblDatePermanent;
        private System.Windows.Forms.DateTimePicker dtpDateJoined;
        private System.Windows.Forms.Label lblDateJoined;
        private System.Windows.Forms.Label lblEmploymentType;
        private System.Windows.Forms.ComboBox cmbEmploymentType;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.ComboBox cmbMaritalStatus;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.RadioButton rbLeaveHours;
        private System.Windows.Forms.RadioButton rbLeaveDays;
        private System.Windows.Forms.CheckBox cbLeaveCarriesOver;
        private System.Windows.Forms.CheckBox cbLeaveAccrues;
        private System.Windows.Forms.NumericUpDown udLeaveEntitlement;
        private System.Windows.Forms.Label lblLeaveEntitlement;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLeaveRemaining;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelAnniversary;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSpare;
        private System.Windows.Forms.ToolStripButton tssbRefresh;
        private Controls.LeaveRequests leaveRequests1;
        private System.Windows.Forms.TabPage tabPageCommission;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.NumericUpDown udCommissionManager;
        private System.Windows.Forms.Label lblCommisionManagerRate;
        private System.Windows.Forms.NumericUpDown udCommissionStaff;
        private System.Windows.Forms.Label lblCommisionStaffRate;
        private SharedControls.Classes.ListViewEx lvClients;
        private System.Windows.Forms.ColumnHeader chClientsName;
        private System.Windows.Forms.ColumnHeader chClientsTelephone;
        private System.Windows.Forms.ColumnHeader chClientsAddress;
        private System.Windows.Forms.ColumnHeader chClientsCompany;
        private System.Windows.Forms.ColumnHeader chClientsState;
        private SharedControls.Classes.ListViewEx lvCommissionPayments;
        private System.Windows.Forms.ColumnHeader chCommissionAmount;
        private System.Windows.Forms.ColumnHeader chCommissionAuthorising;
        private System.Windows.Forms.ColumnHeader chCommissionType;
        private System.Windows.Forms.ColumnHeader chCommissionDate;
        private System.Windows.Forms.Label lblCommissionDetails;
        private SharedControls.Classes.ListViewEx lvWorkingHours;
        private System.Windows.Forms.ColumnHeader colWorkingHoursStart;
        private System.Windows.Forms.ColumnHeader colWorkingHoursDay;
        private System.Windows.Forms.ColumnHeader colWorkingHoursRepeat;
        private System.Windows.Forms.ColumnHeader colWorkingHoursRepeatFrequency;
        private System.Windows.Forms.ColumnHeader colWorkingHoursTreatments;
        private SharedControls.Classes.ListViewEx lvSicknessRecords;
        private System.Windows.Forms.ColumnHeader chSicknessStarted;
        private System.Windows.Forms.ColumnHeader chSicknessFinished;
        private System.Windows.Forms.ColumnHeader chSicknessNotified;
        private System.Windows.Forms.ColumnHeader chSicknessReason;
        private System.Windows.Forms.ContextMenuStrip pumSickness;
        private System.Windows.Forms.ToolStripMenuItem pumSicknessNew;
        private System.Windows.Forms.ToolStripMenuItem pumSicknessView;
        private System.Windows.Forms.ToolStripMenuItem pumSicknessReturnToWork;
        private System.Windows.Forms.ColumnHeader chSicknessTotal;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pumSicknessStatistics;
        private System.Windows.Forms.ToolStripMenuItem pumSicknessCancel;
        private System.Windows.Forms.ColumnHeader chSicknessSelfCertified;
    }
}