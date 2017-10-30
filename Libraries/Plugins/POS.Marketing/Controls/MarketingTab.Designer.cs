namespace POS.Marketing.Controls
{
    partial class MarketingTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketingTab));
            this.tvCampaigns = new System.Windows.Forms.TreeView();
            this.tvTreeImages = new System.Windows.Forms.ImageList(this.components);
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCampaigns = new System.Windows.Forms.TabPage();
            this.lvCampaigns = new SharedControls.Classes.ListViewEx();
            this.colCampaignName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignTotalVisits = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignTotalSales = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignInvoices = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.browserMap = new System.Windows.Forms.WebBrowser();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.lvCampaignDetails = new SharedControls.Classes.ListViewEx();
            this.colCampaignDetailsCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignDetailsCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignDetailsVisits = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignDetailsCurrency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCampaignDetailsSales = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageHomeImage = new System.Windows.Forms.TabPage();
            this.flowLayoutHomeImage = new System.Windows.Forms.FlowLayoutPanel();
            this.picHomeImage = new System.Windows.Forms.PictureBox();
            this.tabPageOfferImage = new System.Windows.Forms.TabPage();
            this.flowLayoutOfferImage = new System.Windows.Forms.FlowLayoutPanel();
            this.picOfferImage = new System.Windows.Forms.PictureBox();
            this.tabPagePageImage = new System.Windows.Forms.TabPage();
            this.flowLayoutPageImage = new System.Windows.Forms.FlowLayoutPanel();
            this.picPageImage = new System.Windows.Forms.PictureBox();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.txtOfferPageText = new System.Windows.Forms.TextBox();
            this.lblOfferPageText = new System.Windows.Forms.Label();
            this.txtTrackingCode = new System.Windows.Forms.TextBox();
            this.lblTrackingCode = new System.Windows.Forms.Label();
            this.txtCampaignTitle = new System.Windows.Forms.TextBox();
            this.lblCampaignTitle = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.textBlockMap = new SharedControls.Controls.TextBlock();
            this.lblCampaignName = new System.Windows.Forms.Label();
            this.cmbPageImages = new System.Windows.Forms.ComboBox();
            this.cmbOffersPageImage = new System.Windows.Forms.ComboBox();
            this.cmbHomeImages = new System.Windows.Forms.ComboBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageCampaigns.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.tabPageHomeImage.SuspendLayout();
            this.flowLayoutHomeImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeImage)).BeginInit();
            this.tabPageOfferImage.SuspendLayout();
            this.flowLayoutOfferImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOfferImage)).BeginInit();
            this.tabPagePageImage.SuspendLayout();
            this.flowLayoutPageImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPageImage)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCampaigns
            // 
            this.tvCampaigns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvCampaigns.ImageIndex = 0;
            this.tvCampaigns.ImageList = this.tvTreeImages;
            this.tvCampaigns.Location = new System.Drawing.Point(3, 28);
            this.tvCampaigns.Name = "tvCampaigns";
            this.tvCampaigns.SelectedImageIndex = 0;
            this.tvCampaigns.Size = new System.Drawing.Size(348, 269);
            this.tvCampaigns.TabIndex = 0;
            this.tvCampaigns.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCampaigns_BeforeSelect);
            this.tvCampaigns.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCampaigns_AfterSelect);
            // 
            // tvTreeImages
            // 
            this.tvTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvTreeImages.ImageStream")));
            this.tvTreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.tvTreeImages.Images.SetKeyName(0, "action_create_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(1, "animation_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(2, "calendar_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(3, "certificate_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(4, "class_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(5, "compass_16xLG.png");
            this.tvTreeImages.Images.SetKeyName(6, "Diagram_16XLG.png");
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageCampaigns);
            this.tabControlMain.Controls.Add(this.tabPageMap);
            this.tabControlMain.Controls.Add(this.tabPageDetails);
            this.tabControlMain.Controls.Add(this.tabPageHomeImage);
            this.tabControlMain.Controls.Add(this.tabPageOfferImage);
            this.tabControlMain.Controls.Add(this.tabPagePageImage);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Location = new System.Drawing.Point(357, 28);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(544, 269);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageCampaigns
            // 
            this.tabPageCampaigns.Controls.Add(this.lvCampaigns);
            this.tabPageCampaigns.Location = new System.Drawing.Point(4, 22);
            this.tabPageCampaigns.Name = "tabPageCampaigns";
            this.tabPageCampaigns.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCampaigns.Size = new System.Drawing.Size(536, 243);
            this.tabPageCampaigns.TabIndex = 0;
            this.tabPageCampaigns.Text = "tabPageCampaigns";
            this.tabPageCampaigns.UseVisualStyleBackColor = true;
            // 
            // lvCampaigns
            // 
            this.lvCampaigns.AllowColumnReorder = true;
            this.lvCampaigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCampaigns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCampaignName,
            this.colCampaignTotalVisits,
            this.colCampaignTotalSales,
            this.colCampaignInvoices});
            this.lvCampaigns.FullRowSelect = true;
            this.lvCampaigns.HideSelection = false;
            this.lvCampaigns.Location = new System.Drawing.Point(7, 7);
            this.lvCampaigns.Name = "lvCampaigns";
            this.lvCampaigns.OwnerDraw = true;
            this.lvCampaigns.SaveName = "";
            this.lvCampaigns.ShowToolTip = false;
            this.lvCampaigns.Size = new System.Drawing.Size(523, 230);
            this.lvCampaigns.TabIndex = 0;
            this.lvCampaigns.UseCompatibleStateImageBehavior = false;
            this.lvCampaigns.View = System.Windows.Forms.View.Details;
            this.lvCampaigns.DoubleClick += new System.EventHandler(this.lvCampaigns_DoubleClick);
            // 
            // colCampaignName
            // 
            this.colCampaignName.Width = 276;
            // 
            // colCampaignTotalVisits
            // 
            this.colCampaignTotalVisits.Width = 100;
            // 
            // colCampaignTotalSales
            // 
            this.colCampaignTotalSales.Width = 100;
            // 
            // colCampaignInvoices
            // 
            this.colCampaignInvoices.Width = 100;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.browserMap);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(536, 243);
            this.tabPageMap.TabIndex = 1;
            this.tabPageMap.Text = "tabPageMap";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // browserMap
            // 
            this.browserMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserMap.Location = new System.Drawing.Point(7, 7);
            this.browserMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserMap.Name = "browserMap";
            this.browserMap.Size = new System.Drawing.Size(523, 230);
            this.browserMap.TabIndex = 0;
            this.browserMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browserMap_DocumentCompleted);
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.lvCampaignDetails);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(536, 243);
            this.tabPageDetails.TabIndex = 2;
            this.tabPageDetails.Text = "tabPage1";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // lvCampaignDetails
            // 
            this.lvCampaignDetails.AllowColumnReorder = true;
            this.lvCampaignDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCampaignDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCampaignDetailsCountry,
            this.colCampaignDetailsCity,
            this.colCampaignDetailsVisits,
            this.colCampaignDetailsCurrency,
            this.colCampaignDetailsSales});
            this.lvCampaignDetails.Location = new System.Drawing.Point(6, 6);
            this.lvCampaignDetails.Name = "lvCampaignDetails";
            this.lvCampaignDetails.OwnerDraw = true;
            this.lvCampaignDetails.SaveName = "";
            this.lvCampaignDetails.ShowToolTip = false;
            this.lvCampaignDetails.Size = new System.Drawing.Size(524, 234);
            this.lvCampaignDetails.TabIndex = 0;
            this.lvCampaignDetails.UseCompatibleStateImageBehavior = false;
            this.lvCampaignDetails.View = System.Windows.Forms.View.Details;
            // 
            // colCampaignDetailsCountry
            // 
            this.colCampaignDetailsCountry.Width = 200;
            // 
            // colCampaignDetailsCity
            // 
            this.colCampaignDetailsCity.Width = 200;
            // 
            // colCampaignDetailsVisits
            // 
            this.colCampaignDetailsVisits.Width = 80;
            // 
            // colCampaignDetailsCurrency
            // 
            this.colCampaignDetailsCurrency.Width = 80;
            // 
            // colCampaignDetailsSales
            // 
            this.colCampaignDetailsSales.Width = 80;
            // 
            // tabPageHomeImage
            // 
            this.tabPageHomeImage.Controls.Add(this.cmbHomeImages);
            this.tabPageHomeImage.Controls.Add(this.flowLayoutHomeImage);
            this.tabPageHomeImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageHomeImage.Name = "tabPageHomeImage";
            this.tabPageHomeImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHomeImage.Size = new System.Drawing.Size(536, 243);
            this.tabPageHomeImage.TabIndex = 3;
            this.tabPageHomeImage.Text = "tabPage2";
            this.tabPageHomeImage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutHomeImage
            // 
            this.flowLayoutHomeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutHomeImage.AutoScroll = true;
            this.flowLayoutHomeImage.Controls.Add(this.picHomeImage);
            this.flowLayoutHomeImage.Location = new System.Drawing.Point(6, 34);
            this.flowLayoutHomeImage.Name = "flowLayoutHomeImage";
            this.flowLayoutHomeImage.Size = new System.Drawing.Size(524, 203);
            this.flowLayoutHomeImage.TabIndex = 0;
            // 
            // picHomeImage
            // 
            this.picHomeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHomeImage.Location = new System.Drawing.Point(3, 3);
            this.picHomeImage.Name = "picHomeImage";
            this.picHomeImage.Size = new System.Drawing.Size(100, 50);
            this.picHomeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHomeImage.TabIndex = 0;
            this.picHomeImage.TabStop = false;
            // 
            // tabPageOfferImage
            // 
            this.tabPageOfferImage.Controls.Add(this.cmbOffersPageImage);
            this.tabPageOfferImage.Controls.Add(this.flowLayoutOfferImage);
            this.tabPageOfferImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageOfferImage.Name = "tabPageOfferImage";
            this.tabPageOfferImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOfferImage.Size = new System.Drawing.Size(536, 243);
            this.tabPageOfferImage.TabIndex = 4;
            this.tabPageOfferImage.Text = "tabPage3";
            this.tabPageOfferImage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutOfferImage
            // 
            this.flowLayoutOfferImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutOfferImage.AutoScroll = true;
            this.flowLayoutOfferImage.Controls.Add(this.picOfferImage);
            this.flowLayoutOfferImage.Location = new System.Drawing.Point(6, 34);
            this.flowLayoutOfferImage.Name = "flowLayoutOfferImage";
            this.flowLayoutOfferImage.Size = new System.Drawing.Size(524, 203);
            this.flowLayoutOfferImage.TabIndex = 1;
            // 
            // picOfferImage
            // 
            this.picOfferImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOfferImage.Location = new System.Drawing.Point(3, 3);
            this.picOfferImage.Name = "picOfferImage";
            this.picOfferImage.Size = new System.Drawing.Size(100, 50);
            this.picOfferImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOfferImage.TabIndex = 0;
            this.picOfferImage.TabStop = false;
            // 
            // tabPagePageImage
            // 
            this.tabPagePageImage.Controls.Add(this.cmbPageImages);
            this.tabPagePageImage.Controls.Add(this.flowLayoutPageImage);
            this.tabPagePageImage.Location = new System.Drawing.Point(4, 22);
            this.tabPagePageImage.Name = "tabPagePageImage";
            this.tabPagePageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePageImage.Size = new System.Drawing.Size(536, 243);
            this.tabPagePageImage.TabIndex = 5;
            this.tabPagePageImage.Text = "tabPage1";
            this.tabPagePageImage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPageImage
            // 
            this.flowLayoutPageImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPageImage.AutoScroll = true;
            this.flowLayoutPageImage.Controls.Add(this.picPageImage);
            this.flowLayoutPageImage.Location = new System.Drawing.Point(6, 34);
            this.flowLayoutPageImage.Name = "flowLayoutPageImage";
            this.flowLayoutPageImage.Size = new System.Drawing.Size(524, 203);
            this.flowLayoutPageImage.TabIndex = 1;
            // 
            // picPageImage
            // 
            this.picPageImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPageImage.Location = new System.Drawing.Point(3, 3);
            this.picPageImage.Name = "picPageImage";
            this.picPageImage.Size = new System.Drawing.Size(100, 50);
            this.picPageImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPageImage.TabIndex = 0;
            this.picPageImage.TabStop = false;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.txtOfferPageText);
            this.tabPageSettings.Controls.Add(this.lblOfferPageText);
            this.tabPageSettings.Controls.Add(this.txtTrackingCode);
            this.tabPageSettings.Controls.Add(this.lblTrackingCode);
            this.tabPageSettings.Controls.Add(this.txtCampaignTitle);
            this.tabPageSettings.Controls.Add(this.lblCampaignTitle);
            this.tabPageSettings.Controls.Add(this.dtpEndTime);
            this.tabPageSettings.Controls.Add(this.lblEndDate);
            this.tabPageSettings.Controls.Add(this.dtpStartDate);
            this.tabPageSettings.Controls.Add(this.lblStartDate);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(536, 243);
            this.tabPageSettings.TabIndex = 6;
            this.tabPageSettings.Text = "tabPageSettings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // txtOfferPageText
            // 
            this.txtOfferPageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOfferPageText.Location = new System.Drawing.Point(10, 128);
            this.txtOfferPageText.Multiline = true;
            this.txtOfferPageText.Name = "txtOfferPageText";
            this.txtOfferPageText.Size = new System.Drawing.Size(518, 109);
            this.txtOfferPageText.TabIndex = 9;
            this.txtOfferPageText.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // lblOfferPageText
            // 
            this.lblOfferPageText.AutoSize = true;
            this.lblOfferPageText.Location = new System.Drawing.Point(10, 111);
            this.lblOfferPageText.Name = "lblOfferPageText";
            this.lblOfferPageText.Size = new System.Drawing.Size(35, 13);
            this.lblOfferPageText.TabIndex = 8;
            this.lblOfferPageText.Text = "label3";
            // 
            // txtTrackingCode
            // 
            this.txtTrackingCode.Location = new System.Drawing.Point(10, 75);
            this.txtTrackingCode.Name = "txtTrackingCode";
            this.txtTrackingCode.Size = new System.Drawing.Size(291, 20);
            this.txtTrackingCode.TabIndex = 3;
            this.txtTrackingCode.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // lblTrackingCode
            // 
            this.lblTrackingCode.AutoSize = true;
            this.lblTrackingCode.Location = new System.Drawing.Point(7, 58);
            this.lblTrackingCode.Name = "lblTrackingCode";
            this.lblTrackingCode.Size = new System.Drawing.Size(35, 13);
            this.lblTrackingCode.TabIndex = 2;
            this.lblTrackingCode.Text = "label4";
            // 
            // txtCampaignTitle
            // 
            this.txtCampaignTitle.Location = new System.Drawing.Point(10, 24);
            this.txtCampaignTitle.Name = "txtCampaignTitle";
            this.txtCampaignTitle.Size = new System.Drawing.Size(291, 20);
            this.txtCampaignTitle.TabIndex = 1;
            this.txtCampaignTitle.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // lblCampaignTitle
            // 
            this.lblCampaignTitle.AutoSize = true;
            this.lblCampaignTitle.Location = new System.Drawing.Point(7, 7);
            this.lblCampaignTitle.Name = "lblCampaignTitle";
            this.lblCampaignTitle.Size = new System.Drawing.Size(35, 13);
            this.lblCampaignTitle.TabIndex = 0;
            this.lblCampaignTitle.Text = "label3";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(328, 75);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEndTime.TabIndex = 7;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(328, 58);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(35, 13);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "label2";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(328, 24);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 5;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(325, 8);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(35, 13);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "label1";
            // 
            // textBlockMap
            // 
            this.textBlockMap.StringBlock = resources.GetString("textBlockMap.StringBlock");
            // 
            // lblCampaignName
            // 
            this.lblCampaignName.AutoSize = true;
            this.lblCampaignName.Location = new System.Drawing.Point(7, 58);
            this.lblCampaignName.Name = "lblCampaignName";
            this.lblCampaignName.Size = new System.Drawing.Size(35, 13);
            this.lblCampaignName.TabIndex = 2;
            this.lblCampaignName.Text = "label4";
            // 
            // cmbPageImages
            // 
            this.cmbPageImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPageImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageImages.FormattingEnabled = true;
            this.cmbPageImages.Location = new System.Drawing.Point(9, 7);
            this.cmbPageImages.Name = "cmbPageImages";
            this.cmbPageImages.Size = new System.Drawing.Size(521, 21);
            this.cmbPageImages.TabIndex = 2;
            this.cmbPageImages.SelectedIndexChanged += new System.EventHandler(this.cmbPageImages_SelectedIndexChanged);
            // 
            // cmbOffersPageImage
            // 
            this.cmbOffersPageImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOffersPageImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffersPageImage.FormattingEnabled = true;
            this.cmbOffersPageImage.Location = new System.Drawing.Point(7, 7);
            this.cmbOffersPageImage.Name = "cmbOffersPageImage";
            this.cmbOffersPageImage.Size = new System.Drawing.Size(523, 21);
            this.cmbOffersPageImage.TabIndex = 2;
            this.cmbOffersPageImage.SelectedIndexChanged += new System.EventHandler(this.cmbOffersPageImage_SelectedIndexChanged);
            // 
            // cmbHomeImages
            // 
            this.cmbHomeImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHomeImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHomeImages.FormattingEnabled = true;
            this.cmbHomeImages.Location = new System.Drawing.Point(7, 7);
            this.cmbHomeImages.Name = "cmbHomeImages";
            this.cmbHomeImages.Size = new System.Drawing.Size(523, 21);
            this.cmbHomeImages.TabIndex = 1;
            this.cmbHomeImages.SelectedIndexChanged += new System.EventHandler(this.cmbHomeImages_SelectedIndexChanged);
            // 
            // MarketingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.tvCampaigns);
            this.Name = "MarketingTab";
            this.Size = new System.Drawing.Size(904, 300);
            this.Controls.SetChildIndex(this.tvCampaigns, 0);
            this.Controls.SetChildIndex(this.tabControlMain, 0);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCampaigns.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageHomeImage.ResumeLayout(false);
            this.flowLayoutHomeImage.ResumeLayout(false);
            this.flowLayoutHomeImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeImage)).EndInit();
            this.tabPageOfferImage.ResumeLayout(false);
            this.flowLayoutOfferImage.ResumeLayout(false);
            this.flowLayoutOfferImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOfferImage)).EndInit();
            this.tabPagePageImage.ResumeLayout(false);
            this.flowLayoutPageImage.ResumeLayout(false);
            this.flowLayoutPageImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPageImage)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvCampaigns;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCampaigns;
        private System.Windows.Forms.TabPage tabPageMap;
        private SharedControls.Classes.ListViewEx lvCampaigns;
        private System.Windows.Forms.ColumnHeader colCampaignName;
        private System.Windows.Forms.ColumnHeader colCampaignTotalVisits;
        private System.Windows.Forms.ColumnHeader colCampaignTotalSales;
        private System.Windows.Forms.ColumnHeader colCampaignInvoices;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageHomeImage;
        private System.Windows.Forms.TabPage tabPageOfferImage;
        private System.Windows.Forms.TabPage tabPagePageImage;
        private System.Windows.Forms.WebBrowser browserMap;
        private SharedControls.Controls.TextBlock textBlockMap;
        private SharedControls.Classes.ListViewEx lvCampaignDetails;
        private System.Windows.Forms.ColumnHeader colCampaignDetailsCountry;
        private System.Windows.Forms.ColumnHeader colCampaignDetailsVisits;
        private System.Windows.Forms.ColumnHeader colCampaignDetailsCurrency;
        private System.Windows.Forms.ColumnHeader colCampaignDetailsSales;
        private System.Windows.Forms.ColumnHeader colCampaignDetailsCity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutHomeImage;
        private System.Windows.Forms.PictureBox picHomeImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOfferImage;
        private System.Windows.Forms.PictureBox picOfferImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPageImage;
        private System.Windows.Forms.PictureBox picPageImage;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox txtOfferPageText;
        private System.Windows.Forms.Label lblOfferPageText;
        private System.Windows.Forms.TextBox txtTrackingCode;
        private System.Windows.Forms.Label lblTrackingCode;
        private System.Windows.Forms.TextBox txtCampaignTitle;
        private System.Windows.Forms.Label lblCampaignTitle;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ImageList tvTreeImages;
        private System.Windows.Forms.Label lblCampaignName;
        private System.Windows.Forms.ComboBox cmbPageImages;
        private System.Windows.Forms.ComboBox cmbOffersPageImage;
        private System.Windows.Forms.ComboBox cmbHomeImages;
    }
}
