namespace POS.Administration.Forms.Products
{
    partial class AdminProductEdit
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.tabProductDetails = new System.Windows.Forms.TabControl();
            this.tabPageDetailDescription = new System.Windows.Forms.TabPage();
            this.productEditTextDescription = new POS.Administration.Controls.ProductEditText();
            this.tabPageDetailHowToUse = new System.Windows.Forms.TabPage();
            this.productEditTextHowToUse = new POS.Administration.Controls.ProductEditText();
            this.tabPageDetailIngredients = new System.Windows.Forms.TabPage();
            this.productEditTextIngredients = new POS.Administration.Controls.ProductEditText();
            this.tabPageDetailFeatures = new System.Windows.Forms.TabPage();
            this.productEditTextFeatures = new POS.Administration.Controls.ProductEditText();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblPrimaryGroup = new System.Windows.Forms.Label();
            this.imgPicture = new System.Windows.Forms.PictureBox();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.spnPopupID = new System.Windows.Forms.NumericUpDown();
            this.spnSortOrder = new System.Windows.Forms.NumericUpDown();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblPopupID = new System.Windows.Forms.Label();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.cbAllowPreOrder = new System.Windows.Forms.CheckBox();
            this.txtVideoLink = new System.Windows.Forms.TextBox();
            this.lblVideoLink = new System.Windows.Forms.Label();
            this.cbCarousel = new System.Windows.Forms.CheckBox();
            this.cbBestSeller = new System.Windows.Forms.CheckBox();
            this.cbFeatured = new System.Windows.Forms.CheckBox();
            this.cbNewProduct = new System.Windows.Forms.CheckBox();
            this.cbOutOfStock = new System.Windows.Forms.CheckBox();
            this.cbRegal = new System.Windows.Forms.CheckBox();
            this.cbSpecialOffer = new System.Windows.Forms.CheckBox();
            this.cbShowOnWeb = new System.Windows.Forms.CheckBox();
            this.tabPageProductItems = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlProductItems = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageProductGroups = new System.Windows.Forms.TabPage();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.lstProductGroups = new System.Windows.Forms.CheckedListBox();
            this.lblAssignedProductGroups = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblPrimaryProduct = new System.Windows.Forms.Label();
            this.cmbPrimaryType = new System.Windows.Forms.ComboBox();
            this.btnSpellCheck = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.tabProductDetails.SuspendLayout();
            this.tabPageDetailDescription.SuspendLayout();
            this.tabPageDetailHowToUse.SuspendLayout();
            this.tabPageDetailIngredients.SuspendLayout();
            this.tabPageDetailFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPopupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.tabPageProductItems.SuspendLayout();
            this.tabPageProductGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(382, 487);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(463, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(544, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(122, 6);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(362, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageDetails);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Controls.Add(this.tabPageProductItems);
            this.tabControlMain.Controls.Add(this.tabPageProductGroups);
            this.tabControlMain.Location = new System.Drawing.Point(16, 88);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(601, 391);
            this.tabControlMain.TabIndex = 6;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.tabProductDetails);
            this.tabPageDetails.Controls.Add(this.cmbGroup);
            this.tabPageDetails.Controls.Add(this.lblPrimaryGroup);
            this.tabPageDetails.Controls.Add(this.imgPicture);
            this.tabPageDetails.Controls.Add(this.cmbImage);
            this.tabPageDetails.Controls.Add(this.spnPopupID);
            this.tabPageDetails.Controls.Add(this.spnSortOrder);
            this.tabPageDetails.Controls.Add(this.lblImage);
            this.tabPageDetails.Controls.Add(this.lblPopupID);
            this.tabPageDetails.Controls.Add(this.lblSortOrder);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(593, 365);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // tabProductDetails
            // 
            this.tabProductDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProductDetails.Controls.Add(this.tabPageDetailDescription);
            this.tabProductDetails.Controls.Add(this.tabPageDetailHowToUse);
            this.tabProductDetails.Controls.Add(this.tabPageDetailIngredients);
            this.tabProductDetails.Controls.Add(this.tabPageDetailFeatures);
            this.tabProductDetails.Location = new System.Drawing.Point(6, 133);
            this.tabProductDetails.Name = "tabProductDetails";
            this.tabProductDetails.SelectedIndex = 0;
            this.tabProductDetails.Size = new System.Drawing.Size(581, 226);
            this.tabProductDetails.TabIndex = 8;
            // 
            // tabPageDetailDescription
            // 
            this.tabPageDetailDescription.Controls.Add(this.productEditTextDescription);
            this.tabPageDetailDescription.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetailDescription.Name = "tabPageDetailDescription";
            this.tabPageDetailDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetailDescription.Size = new System.Drawing.Size(573, 200);
            this.tabPageDetailDescription.TabIndex = 0;
            this.tabPageDetailDescription.Text = "Description";
            this.tabPageDetailDescription.UseVisualStyleBackColor = true;
            // 
            // productEditTextDescription
            // 
            this.productEditTextDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEditTextDescription.HintControl = null;
            this.productEditTextDescription.Location = new System.Drawing.Point(2, 2);
            this.productEditTextDescription.Margin = new System.Windows.Forms.Padding(2);
            this.productEditTextDescription.MaximumLength = 4000;
            this.productEditTextDescription.Name = "productEditTextDescription";
            this.productEditTextDescription.PageType = Library.CustomPagesType.WebPage;
            this.productEditTextDescription.Size = new System.Drawing.Size(569, 196);
            this.productEditTextDescription.TabIndex = 0;
            // 
            // tabPageDetailHowToUse
            // 
            this.tabPageDetailHowToUse.Controls.Add(this.productEditTextHowToUse);
            this.tabPageDetailHowToUse.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetailHowToUse.Name = "tabPageDetailHowToUse";
            this.tabPageDetailHowToUse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetailHowToUse.Size = new System.Drawing.Size(444, 200);
            this.tabPageDetailHowToUse.TabIndex = 1;
            this.tabPageDetailHowToUse.Text = "How to use";
            this.tabPageDetailHowToUse.UseVisualStyleBackColor = true;
            // 
            // productEditTextHowToUse
            // 
            this.productEditTextHowToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEditTextHowToUse.HintControl = null;
            this.productEditTextHowToUse.Location = new System.Drawing.Point(2, 2);
            this.productEditTextHowToUse.Margin = new System.Windows.Forms.Padding(2);
            this.productEditTextHowToUse.MaximumLength = 4000;
            this.productEditTextHowToUse.Name = "productEditTextHowToUse";
            this.productEditTextHowToUse.PageType = Library.CustomPagesType.WebPage;
            this.productEditTextHowToUse.Size = new System.Drawing.Size(440, 196);
            this.productEditTextHowToUse.TabIndex = 0;
            // 
            // tabPageDetailIngredients
            // 
            this.tabPageDetailIngredients.Controls.Add(this.productEditTextIngredients);
            this.tabPageDetailIngredients.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetailIngredients.Name = "tabPageDetailIngredients";
            this.tabPageDetailIngredients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetailIngredients.Size = new System.Drawing.Size(444, 200);
            this.tabPageDetailIngredients.TabIndex = 2;
            this.tabPageDetailIngredients.Text = "Ingredients";
            this.tabPageDetailIngredients.UseVisualStyleBackColor = true;
            // 
            // productEditTextIngredients
            // 
            this.productEditTextIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEditTextIngredients.HintControl = null;
            this.productEditTextIngredients.Location = new System.Drawing.Point(2, 2);
            this.productEditTextIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.productEditTextIngredients.MaximumLength = 4000;
            this.productEditTextIngredients.Name = "productEditTextIngredients";
            this.productEditTextIngredients.PageType = Library.CustomPagesType.WebPage;
            this.productEditTextIngredients.Size = new System.Drawing.Size(440, 196);
            this.productEditTextIngredients.TabIndex = 0;
            // 
            // tabPageDetailFeatures
            // 
            this.tabPageDetailFeatures.Controls.Add(this.productEditTextFeatures);
            this.tabPageDetailFeatures.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetailFeatures.Name = "tabPageDetailFeatures";
            this.tabPageDetailFeatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetailFeatures.Size = new System.Drawing.Size(444, 200);
            this.tabPageDetailFeatures.TabIndex = 3;
            this.tabPageDetailFeatures.Text = "Features";
            this.tabPageDetailFeatures.UseVisualStyleBackColor = true;
            // 
            // productEditTextFeatures
            // 
            this.productEditTextFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productEditTextFeatures.HintControl = null;
            this.productEditTextFeatures.Location = new System.Drawing.Point(2, 2);
            this.productEditTextFeatures.Margin = new System.Windows.Forms.Padding(2);
            this.productEditTextFeatures.MaximumLength = 4000;
            this.productEditTextFeatures.Name = "productEditTextFeatures";
            this.productEditTextFeatures.PageType = Library.CustomPagesType.WebPage;
            this.productEditTextFeatures.Size = new System.Drawing.Size(440, 196);
            this.productEditTextFeatures.TabIndex = 0;
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(122, 106);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(302, 21);
            this.cmbGroup.TabIndex = 7;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            this.cmbGroup.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbGroup_Format);
            // 
            // lblPrimaryGroup
            // 
            this.lblPrimaryGroup.AutoSize = true;
            this.lblPrimaryGroup.Location = new System.Drawing.Point(13, 109);
            this.lblPrimaryGroup.Name = "lblPrimaryGroup";
            this.lblPrimaryGroup.Size = new System.Drawing.Size(73, 13);
            this.lblPrimaryGroup.TabIndex = 6;
            this.lblPrimaryGroup.Text = "Primary Group";
            // 
            // imgPicture
            // 
            this.imgPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPicture.Location = new System.Drawing.Point(430, 13);
            this.imgPicture.MaximumSize = new System.Drawing.Size(148, 114);
            this.imgPicture.Name = "imgPicture";
            this.imgPicture.Size = new System.Drawing.Size(148, 114);
            this.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPicture.TabIndex = 33;
            this.imgPicture.TabStop = false;
            this.imgPicture.Click += new System.EventHandler(this.imgPicture_Click);
            // 
            // cmbImage
            // 
            this.cmbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Location = new System.Drawing.Point(122, 74);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(302, 21);
            this.cmbImage.TabIndex = 5;
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            this.cmbImage.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbImage_Format);
            // 
            // spnPopupID
            // 
            this.spnPopupID.Location = new System.Drawing.Point(122, 42);
            this.spnPopupID.Name = "spnPopupID";
            this.spnPopupID.Size = new System.Drawing.Size(120, 20);
            this.spnPopupID.TabIndex = 3;
            // 
            // spnSortOrder
            // 
            this.spnSortOrder.Location = new System.Drawing.Point(122, 12);
            this.spnSortOrder.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.spnSortOrder.Name = "spnSortOrder";
            this.spnSortOrder.Size = new System.Drawing.Size(120, 20);
            this.spnSortOrder.TabIndex = 1;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 77);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(36, 13);
            this.lblImage.TabIndex = 4;
            this.lblImage.Text = "Image";
            // 
            // lblPopupID
            // 
            this.lblPopupID.AutoSize = true;
            this.lblPopupID.Location = new System.Drawing.Point(12, 44);
            this.lblPopupID.Name = "lblPopupID";
            this.lblPopupID.Size = new System.Drawing.Size(52, 13);
            this.lblPopupID.TabIndex = 2;
            this.lblPopupID.Text = "Popup ID";
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(12, 14);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(55, 13);
            this.lblSortOrder.TabIndex = 0;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.cbAllowPreOrder);
            this.tabPageSettings.Controls.Add(this.txtVideoLink);
            this.tabPageSettings.Controls.Add(this.lblVideoLink);
            this.tabPageSettings.Controls.Add(this.cbCarousel);
            this.tabPageSettings.Controls.Add(this.cbBestSeller);
            this.tabPageSettings.Controls.Add(this.cbFeatured);
            this.tabPageSettings.Controls.Add(this.cbNewProduct);
            this.tabPageSettings.Controls.Add(this.cbOutOfStock);
            this.tabPageSettings.Controls.Add(this.cbRegal);
            this.tabPageSettings.Controls.Add(this.cbSpecialOffer);
            this.tabPageSettings.Controls.Add(this.cbShowOnWeb);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(464, 365);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // cbAllowPreOrder
            // 
            this.cbAllowPreOrder.AutoSize = true;
            this.cbAllowPreOrder.Location = new System.Drawing.Point(16, 208);
            this.cbAllowPreOrder.Name = "cbAllowPreOrder";
            this.cbAllowPreOrder.Size = new System.Drawing.Size(71, 17);
            this.cbAllowPreOrder.TabIndex = 8;
            this.cbAllowPreOrder.Text = "Pre Order";
            this.cbAllowPreOrder.UseVisualStyleBackColor = true;
            // 
            // txtVideoLink
            // 
            this.txtVideoLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoLink.Location = new System.Drawing.Point(16, 259);
            this.txtVideoLink.MaxLength = 500;
            this.txtVideoLink.Name = "txtVideoLink";
            this.txtVideoLink.Size = new System.Drawing.Size(429, 20);
            this.txtVideoLink.TabIndex = 10;
            // 
            // lblVideoLink
            // 
            this.lblVideoLink.AutoSize = true;
            this.lblVideoLink.Location = new System.Drawing.Point(13, 243);
            this.lblVideoLink.Name = "lblVideoLink";
            this.lblVideoLink.Size = new System.Drawing.Size(57, 13);
            this.lblVideoLink.TabIndex = 9;
            this.lblVideoLink.Text = "Video Link";
            // 
            // cbCarousel
            // 
            this.cbCarousel.AutoSize = true;
            this.cbCarousel.Location = new System.Drawing.Point(16, 184);
            this.cbCarousel.Name = "cbCarousel";
            this.cbCarousel.Size = new System.Drawing.Size(67, 17);
            this.cbCarousel.TabIndex = 7;
            this.cbCarousel.Text = "Carousel";
            this.cbCarousel.UseVisualStyleBackColor = true;
            // 
            // cbBestSeller
            // 
            this.cbBestSeller.AutoSize = true;
            this.cbBestSeller.Location = new System.Drawing.Point(16, 160);
            this.cbBestSeller.Name = "cbBestSeller";
            this.cbBestSeller.Size = new System.Drawing.Size(76, 17);
            this.cbBestSeller.TabIndex = 6;
            this.cbBestSeller.Text = "Best Seller";
            this.cbBestSeller.UseVisualStyleBackColor = true;
            // 
            // cbFeatured
            // 
            this.cbFeatured.AutoSize = true;
            this.cbFeatured.Location = new System.Drawing.Point(16, 136);
            this.cbFeatured.Name = "cbFeatured";
            this.cbFeatured.Size = new System.Drawing.Size(108, 17);
            this.cbFeatured.TabIndex = 5;
            this.cbFeatured.Text = "Featured Product";
            this.cbFeatured.UseVisualStyleBackColor = true;
            // 
            // cbNewProduct
            // 
            this.cbNewProduct.AutoSize = true;
            this.cbNewProduct.Location = new System.Drawing.Point(16, 112);
            this.cbNewProduct.Name = "cbNewProduct";
            this.cbNewProduct.Size = new System.Drawing.Size(88, 17);
            this.cbNewProduct.TabIndex = 4;
            this.cbNewProduct.Text = "New Product";
            this.cbNewProduct.UseVisualStyleBackColor = true;
            // 
            // cbOutOfStock
            // 
            this.cbOutOfStock.AutoSize = true;
            this.cbOutOfStock.Location = new System.Drawing.Point(16, 88);
            this.cbOutOfStock.Name = "cbOutOfStock";
            this.cbOutOfStock.Size = new System.Drawing.Size(86, 17);
            this.cbOutOfStock.TabIndex = 3;
            this.cbOutOfStock.Text = "Out of Stock";
            this.cbOutOfStock.UseVisualStyleBackColor = true;
            // 
            // cbRegal
            // 
            this.cbRegal.AutoSize = true;
            this.cbRegal.Location = new System.Drawing.Point(16, 65);
            this.cbRegal.Name = "cbRegal";
            this.cbRegal.Size = new System.Drawing.Size(54, 17);
            this.cbRegal.TabIndex = 2;
            this.cbRegal.Text = "Regal";
            this.cbRegal.UseVisualStyleBackColor = true;
            // 
            // cbSpecialOffer
            // 
            this.cbSpecialOffer.AutoSize = true;
            this.cbSpecialOffer.Location = new System.Drawing.Point(16, 42);
            this.cbSpecialOffer.Name = "cbSpecialOffer";
            this.cbSpecialOffer.Size = new System.Drawing.Size(87, 17);
            this.cbSpecialOffer.TabIndex = 1;
            this.cbSpecialOffer.Text = "Special Offer";
            this.cbSpecialOffer.UseVisualStyleBackColor = true;
            // 
            // cbShowOnWeb
            // 
            this.cbShowOnWeb.AutoSize = true;
            this.cbShowOnWeb.Location = new System.Drawing.Point(16, 19);
            this.cbShowOnWeb.Name = "cbShowOnWeb";
            this.cbShowOnWeb.Size = new System.Drawing.Size(112, 17);
            this.cbShowOnWeb.TabIndex = 0;
            this.cbShowOnWeb.Text = "Show On Website";
            this.cbShowOnWeb.UseVisualStyleBackColor = true;
            // 
            // tabPageProductItems
            // 
            this.tabPageProductItems.Controls.Add(this.btnNew);
            this.tabPageProductItems.Controls.Add(this.pnlProductItems);
            this.tabPageProductItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageProductItems.Name = "tabPageProductItems";
            this.tabPageProductItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductItems.Size = new System.Drawing.Size(464, 365);
            this.tabPageProductItems.TabIndex = 1;
            this.tabPageProductItems.Text = "Product Items";
            this.tabPageProductItems.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(7, 321);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlProductItems
            // 
            this.pnlProductItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductItems.AutoScroll = true;
            this.pnlProductItems.Location = new System.Drawing.Point(7, 7);
            this.pnlProductItems.Name = "pnlProductItems";
            this.pnlProductItems.Size = new System.Drawing.Size(445, 308);
            this.pnlProductItems.TabIndex = 0;
            this.pnlProductItems.SizeChanged += new System.EventHandler(this.pnlProductItems_SizeChanged);
            // 
            // tabPageProductGroups
            // 
            this.tabPageProductGroups.Controls.Add(this.btnRemoveAll);
            this.tabPageProductGroups.Controls.Add(this.lstProductGroups);
            this.tabPageProductGroups.Controls.Add(this.lblAssignedProductGroups);
            this.tabPageProductGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageProductGroups.Name = "tabPageProductGroups";
            this.tabPageProductGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductGroups.Size = new System.Drawing.Size(464, 365);
            this.tabPageProductGroups.TabIndex = 2;
            this.tabPageProductGroups.Text = "Product Groups";
            this.tabPageProductGroups.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.Location = new System.Drawing.Point(377, 333);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // lstProductGroups
            // 
            this.lstProductGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProductGroups.CheckOnClick = true;
            this.lstProductGroups.FormattingEnabled = true;
            this.lstProductGroups.Location = new System.Drawing.Point(9, 20);
            this.lstProductGroups.Name = "lstProductGroups";
            this.lstProductGroups.Size = new System.Drawing.Size(443, 304);
            this.lstProductGroups.TabIndex = 1;
            this.lstProductGroups.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstProductGroups_Format);
            // 
            // lblAssignedProductGroups
            // 
            this.lblAssignedProductGroups.AutoSize = true;
            this.lblAssignedProductGroups.Location = new System.Drawing.Point(6, 3);
            this.lblAssignedProductGroups.Name = "lblAssignedProductGroups";
            this.lblAssignedProductGroups.Size = new System.Drawing.Size(138, 13);
            this.lblAssignedProductGroups.TabIndex = 0;
            this.lblAssignedProductGroups.Text = "Assigned Treatment Groups";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(13, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(122, 32);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(194, 20);
            this.txtProductCode.TabIndex = 3;
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(13, 35);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(72, 13);
            this.lblProductCode.TabIndex = 2;
            this.lblProductCode.Text = "Product Code";
            // 
            // lblPrimaryProduct
            // 
            this.lblPrimaryProduct.AutoSize = true;
            this.lblPrimaryProduct.Location = new System.Drawing.Point(13, 62);
            this.lblPrimaryProduct.Name = "lblPrimaryProduct";
            this.lblPrimaryProduct.Size = new System.Drawing.Size(108, 13);
            this.lblPrimaryProduct.TabIndex = 4;
            this.lblPrimaryProduct.Text = "Primary Product Type";
            // 
            // cmbPrimaryType
            // 
            this.cmbPrimaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimaryType.FormattingEnabled = true;
            this.cmbPrimaryType.Location = new System.Drawing.Point(122, 58);
            this.cmbPrimaryType.Name = "cmbPrimaryType";
            this.cmbPrimaryType.Size = new System.Drawing.Size(194, 21);
            this.cmbPrimaryType.TabIndex = 5;
            this.cmbPrimaryType.DropDownClosed += new System.EventHandler(this.cmbPrimaryType_DropDownClosed);
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpellCheck.Location = new System.Drawing.Point(185, 487);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(75, 23);
            this.btnSpellCheck.TabIndex = 7;
            this.btnSpellCheck.Text = "Spell Check";
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(301, 487);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // AdminProductEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 522);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSpellCheck);
            this.Controls.Add(this.cmbPrimaryType);
            this.Controls.Add(this.lblPrimaryProduct);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblProductCode);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 525);
            this.Name = "AdminProductEdit";
            this.SaveState = true;
            this.Text = "Administration - Product Edit";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageDetails.PerformLayout();
            this.tabProductDetails.ResumeLayout(false);
            this.tabPageDetailDescription.ResumeLayout(false);
            this.tabPageDetailHowToUse.ResumeLayout(false);
            this.tabPageDetailIngredients.ResumeLayout(false);
            this.tabPageDetailFeatures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPopupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageProductItems.ResumeLayout(false);
            this.tabPageProductGroups.ResumeLayout(false);
            this.tabPageProductGroups.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageProductItems;
        private System.Windows.Forms.NumericUpDown spnPopupID;
        private System.Windows.Forms.NumericUpDown spnSortOrder;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblPopupID;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.PictureBox imgPicture;
        private System.Windows.Forms.FlowLayoutPanel pnlProductItems;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabPageProductGroups;
        private System.Windows.Forms.CheckedListBox lstProductGroups;
        private System.Windows.Forms.Label lblAssignedProductGroups;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.CheckBox cbCarousel;
        private System.Windows.Forms.CheckBox cbBestSeller;
        private System.Windows.Forms.CheckBox cbFeatured;
        private System.Windows.Forms.CheckBox cbNewProduct;
        private System.Windows.Forms.CheckBox cbOutOfStock;
        private System.Windows.Forms.CheckBox cbRegal;
        private System.Windows.Forms.CheckBox cbSpecialOffer;
        private System.Windows.Forms.CheckBox cbShowOnWeb;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblPrimaryGroup;
        private System.Windows.Forms.Label lblPrimaryProduct;
        private System.Windows.Forms.ComboBox cmbPrimaryType;
        private System.Windows.Forms.TabControl tabProductDetails;
        private System.Windows.Forms.TabPage tabPageDetailDescription;
        private System.Windows.Forms.TabPage tabPageDetailHowToUse;
        private System.Windows.Forms.TabPage tabPageDetailIngredients;
        private System.Windows.Forms.TabPage tabPageDetailFeatures;
        private System.Windows.Forms.TextBox txtVideoLink;
        private System.Windows.Forms.Label lblVideoLink;
        private System.Windows.Forms.CheckBox cbAllowPreOrder;
        private System.Windows.Forms.Button btnSpellCheck;
        private System.Windows.Forms.Button btnRemoveAll;
        private Controls.ProductEditText productEditTextDescription;
        private Controls.ProductEditText productEditTextHowToUse;
        private Controls.ProductEditText productEditTextFeatures;
        private Controls.ProductEditText productEditTextIngredients;
        private System.Windows.Forms.Button btnRemove;
    }
}