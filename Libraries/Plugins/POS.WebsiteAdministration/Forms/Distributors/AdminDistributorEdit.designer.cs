namespace POS.WebsiteAdministration.Forms.Salons
{
    partial class AdminDistributorEdit
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
            this.tabControlSalons = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtPicture = new System.Windows.Forms.TextBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.lblContactName = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.numericSortOrder = new System.Windows.Forms.NumericUpDown();
            this.cbShowOnWeb = new System.Windows.Forms.CheckBox();
            this.cbVIPSalon = new System.Windows.Forms.CheckBox();
            this.tabPageVIP = new System.Windows.Forms.TabPage();
            this.txtSalonCouponCode = new System.Windows.Forms.TextBox();
            this.spnCustomerDiscount = new System.Windows.Forms.NumericUpDown();
            this.spnSalonDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblCouponCode = new System.Windows.Forms.Label();
            this.lblCustomerDiscount = new System.Windows.Forms.Label();
            this.lblSalonDiscount = new System.Windows.Forms.Label();
            this.tabPageType = new System.Windows.Forms.TabPage();
            this.lblType = new System.Windows.Forms.Label();
            this.rbDistributor = new System.Windows.Forms.RadioButton();
            this.rbStockist = new System.Windows.Forms.RadioButton();
            this.rbSalon = new System.Windows.Forms.RadioButton();
            this.tabPageOpeningTimes = new System.Windows.Forms.TabPage();
            this.txtSunday = new System.Windows.Forms.TextBox();
            this.lblSunday = new System.Windows.Forms.Label();
            this.txtSaturday = new System.Windows.Forms.TextBox();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.txtFriday = new System.Windows.Forms.TextBox();
            this.lblFriday = new System.Windows.Forms.Label();
            this.txtThursday = new System.Windows.Forms.TextBox();
            this.lblThursday = new System.Windows.Forms.Label();
            this.txtWednesday = new System.Windows.Forms.TextBox();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.txtTuesday = new System.Windows.Forms.TextBox();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.txtMonday = new System.Windows.Forms.TextBox();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblOpeningTimesDescription = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSalonName = new System.Windows.Forms.TextBox();
            this.lblSalonName = new System.Windows.Forms.Label();
            this.tabControlSalons.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSortOrder)).BeginInit();
            this.tabPageVIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCustomerDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSalonDiscount)).BeginInit();
            this.tabPageType.SuspendLayout();
            this.tabPageOpeningTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSalons
            // 
            this.tabControlSalons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSalons.Controls.Add(this.tabPageGeneral);
            this.tabControlSalons.Controls.Add(this.tabPageSettings);
            this.tabControlSalons.Controls.Add(this.tabPageVIP);
            this.tabControlSalons.Controls.Add(this.tabPageType);
            this.tabControlSalons.Controls.Add(this.tabPageOpeningTimes);
            this.tabControlSalons.Location = new System.Drawing.Point(12, 39);
            this.tabControlSalons.Name = "tabControlSalons";
            this.tabControlSalons.SelectedIndex = 0;
            this.tabControlSalons.Size = new System.Drawing.Size(501, 395);
            this.tabControlSalons.TabIndex = 25;
            this.tabControlSalons.SelectedIndexChanged += new System.EventHandler(this.tabControlSalons_SelectedIndexChanged);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.txtPostcode);
            this.tabPageGeneral.Controls.Add(this.lblWebsite);
            this.tabPageGeneral.Controls.Add(this.txtWebsite);
            this.tabPageGeneral.Controls.Add(this.lblPostCode);
            this.tabPageGeneral.Controls.Add(this.txtAddress);
            this.tabPageGeneral.Controls.Add(this.lblAddress);
            this.tabPageGeneral.Controls.Add(this.txtEmail);
            this.tabPageGeneral.Controls.Add(this.lblEmail);
            this.tabPageGeneral.Controls.Add(this.txtFax);
            this.tabPageGeneral.Controls.Add(this.lblFax);
            this.tabPageGeneral.Controls.Add(this.txtTelephone);
            this.tabPageGeneral.Controls.Add(this.lblTelephone);
            this.tabPageGeneral.Controls.Add(this.txtPicture);
            this.tabPageGeneral.Controls.Add(this.lblPicture);
            this.tabPageGeneral.Controls.Add(this.txtContactName);
            this.tabPageGeneral.Controls.Add(this.lblContactName);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(493, 369);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // txtPostcode
            // 
            this.txtPostcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostcode.Location = new System.Drawing.Point(96, 309);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(391, 20);
            this.txtPostcode.TabIndex = 37;
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 145);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(46, 13);
            this.lblWebsite.TabIndex = 36;
            this.lblWebsite.Text = "Website";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.Location = new System.Drawing.Point(96, 142);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(391, 20);
            this.txtWebsite.TabIndex = 35;
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(6, 312);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(52, 13);
            this.lblPostCode.TabIndex = 34;
            this.lblPostCode.Text = "Postcode";
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsReturn = true;
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(96, 168);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(391, 135);
            this.txtAddress.TabIndex = 33;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 171);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 32;
            this.lblAddress.Text = "Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(96, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(391, 20);
            this.txtEmail.TabIndex = 31;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 119);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email";
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(96, 90);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(391, 20);
            this.txtFax.TabIndex = 29;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(6, 93);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 28;
            this.lblFax.Text = "Fax";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelephone.Location = new System.Drawing.Point(96, 64);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(391, 20);
            this.txtTelephone.TabIndex = 27;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(6, 67);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(58, 13);
            this.lblTelephone.TabIndex = 26;
            this.lblTelephone.Text = "Telephone";
            // 
            // txtPicture
            // 
            this.txtPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPicture.Location = new System.Drawing.Point(96, 38);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.Size = new System.Drawing.Size(391, 20);
            this.txtPicture.TabIndex = 25;
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(6, 41);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(40, 13);
            this.lblPicture.TabIndex = 24;
            this.lblPicture.Text = "Picture";
            // 
            // txtContactName
            // 
            this.txtContactName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactName.Location = new System.Drawing.Point(96, 12);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(391, 20);
            this.txtContactName.TabIndex = 23;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(6, 15);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(75, 13);
            this.lblContactName.TabIndex = 22;
            this.lblContactName.Text = "Contact Name";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.lblSortOrder);
            this.tabPageSettings.Controls.Add(this.numericSortOrder);
            this.tabPageSettings.Controls.Add(this.cbShowOnWeb);
            this.tabPageSettings.Controls.Add(this.cbVIPSalon);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(493, 369);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(6, 62);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(55, 13);
            this.lblSortOrder.TabIndex = 45;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // numericSortOrder
            // 
            this.numericSortOrder.Location = new System.Drawing.Point(122, 60);
            this.numericSortOrder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericSortOrder.Name = "numericSortOrder";
            this.numericSortOrder.Size = new System.Drawing.Size(120, 20);
            this.numericSortOrder.TabIndex = 44;
            // 
            // cbShowOnWeb
            // 
            this.cbShowOnWeb.AutoSize = true;
            this.cbShowOnWeb.Location = new System.Drawing.Point(9, 18);
            this.cbShowOnWeb.Name = "cbShowOnWeb";
            this.cbShowOnWeb.Size = new System.Drawing.Size(112, 17);
            this.cbShowOnWeb.TabIndex = 43;
            this.cbShowOnWeb.Text = "Show On Website";
            this.cbShowOnWeb.UseVisualStyleBackColor = true;
            // 
            // cbVIPSalon
            // 
            this.cbVIPSalon.AutoSize = true;
            this.cbVIPSalon.Location = new System.Drawing.Point(9, 99);
            this.cbVIPSalon.Name = "cbVIPSalon";
            this.cbVIPSalon.Size = new System.Drawing.Size(73, 17);
            this.cbVIPSalon.TabIndex = 42;
            this.cbVIPSalon.Text = "VIP Salon";
            this.cbVIPSalon.UseVisualStyleBackColor = true;
            this.cbVIPSalon.CheckedChanged += new System.EventHandler(this.cbVIPSalon_CheckedChanged);
            // 
            // tabPageVIP
            // 
            this.tabPageVIP.Controls.Add(this.txtSalonCouponCode);
            this.tabPageVIP.Controls.Add(this.spnCustomerDiscount);
            this.tabPageVIP.Controls.Add(this.spnSalonDiscount);
            this.tabPageVIP.Controls.Add(this.lblCouponCode);
            this.tabPageVIP.Controls.Add(this.lblCustomerDiscount);
            this.tabPageVIP.Controls.Add(this.lblSalonDiscount);
            this.tabPageVIP.Location = new System.Drawing.Point(4, 22);
            this.tabPageVIP.Name = "tabPageVIP";
            this.tabPageVIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVIP.Size = new System.Drawing.Size(493, 369);
            this.tabPageVIP.TabIndex = 2;
            this.tabPageVIP.Text = "VIP";
            this.tabPageVIP.UseVisualStyleBackColor = true;
            this.tabPageVIP.Enter += new System.EventHandler(this.tabPageVIP_Enter);
            // 
            // txtSalonCouponCode
            // 
            this.txtSalonCouponCode.Location = new System.Drawing.Point(154, 69);
            this.txtSalonCouponCode.Name = "txtSalonCouponCode";
            this.txtSalonCouponCode.Size = new System.Drawing.Size(228, 20);
            this.txtSalonCouponCode.TabIndex = 5;
            // 
            // spnCustomerDiscount
            // 
            this.spnCustomerDiscount.Location = new System.Drawing.Point(154, 42);
            this.spnCustomerDiscount.Name = "spnCustomerDiscount";
            this.spnCustomerDiscount.Size = new System.Drawing.Size(120, 20);
            this.spnCustomerDiscount.TabIndex = 4;
            this.spnCustomerDiscount.ValueChanged += new System.EventHandler(this.spnCustomerDiscount_ValueChanged);
            // 
            // spnSalonDiscount
            // 
            this.spnSalonDiscount.Location = new System.Drawing.Point(154, 16);
            this.spnSalonDiscount.Name = "spnSalonDiscount";
            this.spnSalonDiscount.Size = new System.Drawing.Size(120, 20);
            this.spnSalonDiscount.TabIndex = 3;
            // 
            // lblCouponCode
            // 
            this.lblCouponCode.AutoSize = true;
            this.lblCouponCode.Location = new System.Drawing.Point(10, 72);
            this.lblCouponCode.Name = "lblCouponCode";
            this.lblCouponCode.Size = new System.Drawing.Size(72, 13);
            this.lblCouponCode.TabIndex = 2;
            this.lblCouponCode.Text = "Coupon Code";
            // 
            // lblCustomerDiscount
            // 
            this.lblCustomerDiscount.AutoSize = true;
            this.lblCustomerDiscount.Location = new System.Drawing.Point(10, 44);
            this.lblCustomerDiscount.Name = "lblCustomerDiscount";
            this.lblCustomerDiscount.Size = new System.Drawing.Size(96, 13);
            this.lblCustomerDiscount.TabIndex = 1;
            this.lblCustomerDiscount.Text = "Customer Discount";
            // 
            // lblSalonDiscount
            // 
            this.lblSalonDiscount.AutoSize = true;
            this.lblSalonDiscount.Location = new System.Drawing.Point(10, 18);
            this.lblSalonDiscount.Name = "lblSalonDiscount";
            this.lblSalonDiscount.Size = new System.Drawing.Size(79, 13);
            this.lblSalonDiscount.TabIndex = 0;
            this.lblSalonDiscount.Text = "Salon Discount";
            // 
            // tabPageType
            // 
            this.tabPageType.Controls.Add(this.lblType);
            this.tabPageType.Controls.Add(this.rbDistributor);
            this.tabPageType.Controls.Add(this.rbStockist);
            this.tabPageType.Controls.Add(this.rbSalon);
            this.tabPageType.Location = new System.Drawing.Point(4, 22);
            this.tabPageType.Name = "tabPageType";
            this.tabPageType.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageType.Size = new System.Drawing.Size(493, 369);
            this.tabPageType.TabIndex = 3;
            this.tabPageType.Text = "Type";
            this.tabPageType.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 24);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(111, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Please select the type";
            // 
            // rbDistributor
            // 
            this.rbDistributor.AutoSize = true;
            this.rbDistributor.Location = new System.Drawing.Point(7, 66);
            this.rbDistributor.Name = "rbDistributor";
            this.rbDistributor.Size = new System.Drawing.Size(72, 17);
            this.rbDistributor.TabIndex = 2;
            this.rbDistributor.TabStop = true;
            this.rbDistributor.Text = "Distributor";
            this.rbDistributor.UseVisualStyleBackColor = true;
            // 
            // rbStockist
            // 
            this.rbStockist.AutoSize = true;
            this.rbStockist.Location = new System.Drawing.Point(6, 89);
            this.rbStockist.Name = "rbStockist";
            this.rbStockist.Size = new System.Drawing.Size(87, 17);
            this.rbStockist.TabIndex = 1;
            this.rbStockist.TabStop = true;
            this.rbStockist.Text = "Stockist Only";
            this.rbStockist.UseVisualStyleBackColor = true;
            // 
            // rbSalon
            // 
            this.rbSalon.AutoSize = true;
            this.rbSalon.Location = new System.Drawing.Point(7, 43);
            this.rbSalon.Name = "rbSalon";
            this.rbSalon.Size = new System.Drawing.Size(52, 17);
            this.rbSalon.TabIndex = 0;
            this.rbSalon.TabStop = true;
            this.rbSalon.Text = "Salon";
            this.rbSalon.UseVisualStyleBackColor = true;
            // 
            // tabPageOpeningTimes
            // 
            this.tabPageOpeningTimes.Controls.Add(this.txtSunday);
            this.tabPageOpeningTimes.Controls.Add(this.lblSunday);
            this.tabPageOpeningTimes.Controls.Add(this.txtSaturday);
            this.tabPageOpeningTimes.Controls.Add(this.lblSaturday);
            this.tabPageOpeningTimes.Controls.Add(this.txtFriday);
            this.tabPageOpeningTimes.Controls.Add(this.lblFriday);
            this.tabPageOpeningTimes.Controls.Add(this.txtThursday);
            this.tabPageOpeningTimes.Controls.Add(this.lblThursday);
            this.tabPageOpeningTimes.Controls.Add(this.txtWednesday);
            this.tabPageOpeningTimes.Controls.Add(this.lblWednesday);
            this.tabPageOpeningTimes.Controls.Add(this.txtTuesday);
            this.tabPageOpeningTimes.Controls.Add(this.lblTuesday);
            this.tabPageOpeningTimes.Controls.Add(this.txtMonday);
            this.tabPageOpeningTimes.Controls.Add(this.lblMonday);
            this.tabPageOpeningTimes.Controls.Add(this.lblOpeningTimesDescription);
            this.tabPageOpeningTimes.Location = new System.Drawing.Point(4, 22);
            this.tabPageOpeningTimes.Name = "tabPageOpeningTimes";
            this.tabPageOpeningTimes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOpeningTimes.Size = new System.Drawing.Size(493, 369);
            this.tabPageOpeningTimes.TabIndex = 4;
            this.tabPageOpeningTimes.Text = "Opening Times";
            this.tabPageOpeningTimes.UseVisualStyleBackColor = true;
            // 
            // txtSunday
            // 
            this.txtSunday.Location = new System.Drawing.Point(108, 234);
            this.txtSunday.MaxLength = 25;
            this.txtSunday.Name = "txtSunday";
            this.txtSunday.Size = new System.Drawing.Size(170, 20);
            this.txtSunday.TabIndex = 14;
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Location = new System.Drawing.Point(10, 237);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(43, 13);
            this.lblSunday.TabIndex = 13;
            this.lblSunday.Text = "Sunday";
            // 
            // txtSaturday
            // 
            this.txtSaturday.Location = new System.Drawing.Point(108, 201);
            this.txtSaturday.MaxLength = 25;
            this.txtSaturday.Name = "txtSaturday";
            this.txtSaturday.Size = new System.Drawing.Size(170, 20);
            this.txtSaturday.TabIndex = 12;
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Location = new System.Drawing.Point(10, 204);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(49, 13);
            this.lblSaturday.TabIndex = 11;
            this.lblSaturday.Text = "Saturday";
            // 
            // txtFriday
            // 
            this.txtFriday.Location = new System.Drawing.Point(108, 171);
            this.txtFriday.MaxLength = 25;
            this.txtFriday.Name = "txtFriday";
            this.txtFriday.Size = new System.Drawing.Size(170, 20);
            this.txtFriday.TabIndex = 10;
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Location = new System.Drawing.Point(10, 174);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(35, 13);
            this.lblFriday.TabIndex = 9;
            this.lblFriday.Text = "Friday";
            // 
            // txtThursday
            // 
            this.txtThursday.Location = new System.Drawing.Point(108, 139);
            this.txtThursday.MaxLength = 25;
            this.txtThursday.Name = "txtThursday";
            this.txtThursday.Size = new System.Drawing.Size(170, 20);
            this.txtThursday.TabIndex = 8;
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Location = new System.Drawing.Point(10, 142);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(51, 13);
            this.lblThursday.TabIndex = 7;
            this.lblThursday.Text = "Thursday";
            // 
            // txtWednesday
            // 
            this.txtWednesday.Location = new System.Drawing.Point(108, 103);
            this.txtWednesday.MaxLength = 25;
            this.txtWednesday.Name = "txtWednesday";
            this.txtWednesday.Size = new System.Drawing.Size(170, 20);
            this.txtWednesday.TabIndex = 6;
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Location = new System.Drawing.Point(10, 106);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(64, 13);
            this.lblWednesday.TabIndex = 5;
            this.lblWednesday.Text = "Wednesday";
            // 
            // txtTuesday
            // 
            this.txtTuesday.Location = new System.Drawing.Point(108, 71);
            this.txtTuesday.MaxLength = 25;
            this.txtTuesday.Name = "txtTuesday";
            this.txtTuesday.Size = new System.Drawing.Size(170, 20);
            this.txtTuesday.TabIndex = 4;
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Location = new System.Drawing.Point(10, 74);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(48, 13);
            this.lblTuesday.TabIndex = 3;
            this.lblTuesday.Text = "Tuesday";
            // 
            // txtMonday
            // 
            this.txtMonday.Location = new System.Drawing.Point(108, 38);
            this.txtMonday.MaxLength = 25;
            this.txtMonday.Name = "txtMonday";
            this.txtMonday.Size = new System.Drawing.Size(170, 20);
            this.txtMonday.TabIndex = 2;
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Location = new System.Drawing.Point(10, 41);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(45, 13);
            this.lblMonday.TabIndex = 1;
            this.lblMonday.Text = "Monday";
            // 
            // lblOpeningTimesDescription
            // 
            this.lblOpeningTimesDescription.AutoSize = true;
            this.lblOpeningTimesDescription.Location = new System.Drawing.Point(7, 7);
            this.lblOpeningTimesDescription.Name = "lblOpeningTimesDescription";
            this.lblOpeningTimesDescription.Size = new System.Drawing.Size(213, 13);
            this.lblOpeningTimesDescription.TabIndex = 0;
            this.lblOpeningTimesDescription.Text = "Please enter the opening times for the salon";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(276, 440);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(357, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnClose.Location = new System.Drawing.Point(438, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtSalonName
            // 
            this.txtSalonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalonName.Location = new System.Drawing.Point(112, 10);
            this.txtSalonName.Name = "txtSalonName";
            this.txtSalonName.Size = new System.Drawing.Size(401, 20);
            this.txtSalonName.TabIndex = 1;
            // 
            // lblSalonName
            // 
            this.lblSalonName.AutoSize = true;
            this.lblSalonName.Location = new System.Drawing.Point(13, 13);
            this.lblSalonName.Name = "lblSalonName";
            this.lblSalonName.Size = new System.Drawing.Size(65, 13);
            this.lblSalonName.TabIndex = 0;
            this.lblSalonName.Text = "Salon Name";
            // 
            // AdminSalonsEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(525, 470);
            this.Controls.Add(this.tabControlSalons);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSalonName);
            this.Controls.Add(this.lblSalonName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 509);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 509);
            this.Name = "AdminSalonsEdit";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Administration - Salon Edit";
            this.tabControlSalons.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSortOrder)).EndInit();
            this.tabPageVIP.ResumeLayout(false);
            this.tabPageVIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCustomerDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSalonDiscount)).EndInit();
            this.tabPageType.ResumeLayout(false);
            this.tabPageType.PerformLayout();
            this.tabPageOpeningTimes.ResumeLayout(false);
            this.tabPageOpeningTimes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalonName;
        private System.Windows.Forms.TextBox txtSalonName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControlSalons;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtPicture;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.NumericUpDown numericSortOrder;
        private System.Windows.Forms.CheckBox cbShowOnWeb;
        private System.Windows.Forms.CheckBox cbVIPSalon;
        private System.Windows.Forms.TabPage tabPageVIP;
        private System.Windows.Forms.Label lblSalonDiscount;
        private System.Windows.Forms.NumericUpDown spnCustomerDiscount;
        private System.Windows.Forms.NumericUpDown spnSalonDiscount;
        private System.Windows.Forms.Label lblCouponCode;
        private System.Windows.Forms.Label lblCustomerDiscount;
        private System.Windows.Forms.TextBox txtSalonCouponCode;
        private System.Windows.Forms.TabPage tabPageType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbDistributor;
        private System.Windows.Forms.RadioButton rbStockist;
        private System.Windows.Forms.RadioButton rbSalon;
        private System.Windows.Forms.TabPage tabPageOpeningTimes;
        private System.Windows.Forms.Label lblOpeningTimesDescription;
        private System.Windows.Forms.TextBox txtSunday;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.TextBox txtSaturday;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.TextBox txtFriday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.TextBox txtThursday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.TextBox txtWednesday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.TextBox txtTuesday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.TextBox txtMonday;
        private System.Windows.Forms.Label lblMonday;
    }
}