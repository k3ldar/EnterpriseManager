using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Campaigns;
using Library.BOL.SEO;

using POS.Base.Classes;
using POS.Marketing.Classes;

using SharedControls.Classes;


namespace POS.Marketing.Controls
{
    public partial class MarketingTab : Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private Campaigns _campaigns;
        private TreeNode _futureCampaigns;
        private TreeNode _nodeActive;
        private TreeNode _nodeTopVisitors;
        private TreeNode _nodeTopSpend;
        private string _tempFile;

        #endregion Private Members

        #region Constructors

        public MarketingTab()
        {
            InitializeComponent();

            _tempFile = Path.GetTempFileName();
            _campaigns = Campaigns.Get();

            LoadImages();

            CreateStandardNodes(false);
        }

        #endregion Constructors

        #region Overridden Methods
  
        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            colCampaignInvoices.Text = LanguageStrings.TotalInvoices;
            colCampaignName.Text = LanguageStrings.Name;
            colCampaignTotalSales.Text = LanguageStrings.AppCampaignTotalSales;
            colCampaignTotalVisits.Text = LanguageStrings.AppCampaignTotalVisits;

            tabPageCampaigns.Text = LanguageStrings.AppCampaigns;
            tabPageDetails.Text = LanguageStrings.AppDetails;
            tabPageHomeImage.Text = LanguageStrings.AppCampaignHomeImage;
            tabPageMap.Text = LanguageStrings.AppCampaignMap;
            tabPageOfferImage.Text = LanguageStrings.AppCampaignOfferImage;
            tabPagePageImage.Text = LanguageStrings.AppCampaignPageImage;
            tabPageSettings.Text = LanguageStrings.Settings;

            colCampaignDetailsCity.Text = LanguageStrings.City;
            colCampaignDetailsCountry.Text = LanguageStrings.Country;
            colCampaignDetailsCurrency.Text = LanguageStrings.Currency;
            colCampaignDetailsSales.Text = LanguageStrings.AppCampaignTotalSales;
            colCampaignDetailsVisits.Text = LanguageStrings.AppCampaignTotalVisits;

            dtpStartDate.CustomFormat = Shared.Utilities.DateFormat(true, true);
            dtpEndTime.CustomFormat = Shared.Utilities.DateFormat(true, true);

            lblTrackingCode.Text = LanguageStrings.AppCampaignTrackingCode;
            lblCampaignTitle.Text = LanguageStrings.AppTitle;
            lblOfferPageText.Text = LanguageStrings.AppCampaignOfferPageText;
            lblStartDate.Text = LanguageStrings.AppStartDate;
            lblEndDate.Text = LanguageStrings.AppDateEnd;
        }

        protected override void OnCreateClicked()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (Classes.MarketingEmail.Run())
                    OnRefreshClicked();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        protected override void OnDeleteClicked()
        {
            base.OnDeleteClicked();
        }

        protected override void OnSaveClicked()
        {
            CampaignNodeType nodeType = (CampaignNodeType)tvCampaigns.SelectedNode.Tag;

            if (nodeType.Type == NodeType.Campaign)
            {
                SaveCurrentCampaign(nodeType.Campaign);
            }
        }

        protected override void OnEditClicked()
        {
            base.OnEditClicked();
        }

        protected override void OnRefreshClicked()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                LoadImages();
                CreateStandardNodes(true);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void CreateStandardNodes(bool refreshData)
        {
            tvCampaigns.BeginUpdate();
            try
            {
                tvCampaigns.Nodes.Clear();

                if (_nodeActive == null)
                {
                    _nodeActive = new TreeNode(LanguageStrings.Active);
                    _nodeActive.Tag = new CampaignNodeType(NodeType.Active);
                    _nodeActive.ImageIndex = 0;
                    _nodeActive.SelectedImageIndex = 0;
                }
                else
                {
                    _nodeActive.Nodes.Clear();
                }

                tvCampaigns.Nodes.Add(_nodeActive);

                if (_futureCampaigns == null)
                {
                    _futureCampaigns = new TreeNode(LanguageStrings.AppCampaignFuture);
                    _futureCampaigns.Tag = new CampaignNodeType(NodeType.Future);
                    _futureCampaigns.ImageIndex = 1;
                    _futureCampaigns.SelectedImageIndex = 1;
                }
                else
                {
                    _futureCampaigns.Nodes.Clear();
                }

                tvCampaigns.Nodes.Add(_futureCampaigns);

                if (_nodeTopVisitors == null)
                {
                    _nodeTopVisitors = new TreeNode(LanguageStrings.AppCampaignTopVisitors);
                    _nodeTopVisitors.Tag = new CampaignNodeType(NodeType.Top);
                    _nodeTopVisitors.ImageIndex = 3;
                    _nodeTopVisitors.SelectedImageIndex = 3;
                }
                else
                {
                    _nodeTopVisitors.Nodes.Clear();
                }

                tvCampaigns.Nodes.Add(_nodeTopVisitors);

                if (_nodeTopSpend == null)
                {
                    _nodeTopSpend = new TreeNode(LanguageStrings.AppCampaignTopSpend);
                    _nodeTopSpend.Tag = new CampaignNodeType(NodeType.Top);
                    _nodeTopSpend.ImageIndex = 3;
                }
                else
                {
                    _nodeTopSpend.Nodes.Clear();
                }

                tvCampaigns.Nodes.Add(_nodeTopSpend);

                LoadCampaignData(refreshData);

                tvCampaigns.SelectedNode = tvCampaigns.Nodes[0];
                tvCampaigns.SelectedNode.EnsureVisible();

                AllowRefresh = true;
                AllowEdit = false;
                AllowDelete = false;
                AllowAddNew = true;
                UpdateUI(true);
            }
            finally
            {
                tvCampaigns.EndUpdate();
            }
        }

        private void LoadCampaignData(bool forceRefresh)
        {
            if (forceRefresh)
                _campaigns = Campaigns.Get();

            _campaigns.Sort(CampaignSortType.StartDateDescending);

            for (int i = 0; i < _campaigns.Count; i++)
            {
                if (_campaigns[i].StartDateTime <= DateTime.Now && _campaigns[i].FinishDateTime > DateTime.Now)
                {
                    TreeNode node = new TreeNode(_campaigns[i].Title);
                    node.ImageIndex = 5;
                    node.SelectedImageIndex = 5;
                    node.Tag = new CampaignNodeType(_campaigns[i]);
                    _nodeActive.Nodes.Add(node);
                }

                TreeNode campaignNode = new TreeNode(_campaigns[i].Title);
                campaignNode.ImageIndex = 5;
                campaignNode.SelectedImageIndex = 5;
                campaignNode.Tag = new CampaignNodeType(_campaigns[i]);

                if (_campaigns[i].StartDateTime > DateTime.Now)
                {
                    _futureCampaigns.Nodes.Add(campaignNode);
                }
                else
                {
                    TreeNode parentMonth = FindDateNode(new DateTime(_campaigns[i].StartDateTime.Year,
                        _campaigns[i].StartDateTime.Month, 1));
                    parentMonth.Nodes.Add(campaignNode);

                    if (_campaigns[i].StartDateTime.Year < DateTime.Now.Year)
                        parentMonth.Collapse();
                    else
                        parentMonth.Expand();
                }
            }

            _campaigns.Sort(CampaignSortType.TopVisits);

            for (int i = 0; i < _campaigns.Count; i++)
            {
                TreeNode node = new TreeNode(_campaigns[i].Title);
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
                node.Tag = new CampaignNodeType(_campaigns[i]);
                _nodeTopVisitors.Nodes.Add(node);

                if (i == 9)
                    break;
            }

            _campaigns.Sort(CampaignSortType.TopSpend);

            for (int i = 0; i < _campaigns.Count; i++)
            {
                TreeNode node = new TreeNode(_campaigns[i].Title);
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
                node.Tag = new CampaignNodeType(_campaigns[i]);
                _nodeTopSpend.Nodes.Add(node);

                if (i == 9)
                    break;
            }

            _nodeActive.Expand();
            _futureCampaigns.Expand();
            _nodeTopSpend.Expand();
            _nodeTopVisitors.Expand();
            _nodeActive.EnsureVisible();
        }

        private void SaveCurrentCampaign(Campaign campaign)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (!txtCampaignTitle.ReadOnly)
                    campaign.Title = txtCampaignTitle.Text;

                if (!txtOfferPageText.ReadOnly)
                    campaign.OffersPageText = txtOfferPageText.Text;

                if (!txtTrackingCode.ReadOnly)
                    campaign.CampaignName = txtTrackingCode.Text;

                if (dtpStartDate.Enabled)
                    campaign.StartDateTime = dtpStartDate.Value;

                if (dtpEndTime.Enabled)
                    campaign.FinishDateTime = dtpEndTime.Value;

                if (cmbHomeImages.SelectedIndex > -1)
                    campaign.ImageMainPage = (string)cmbHomeImages.SelectedItem;

                if (cmbOffersPageImage.SelectedIndex > -1)
                    campaign.ImageOffersPage = (string)cmbOffersPageImage.SelectedItem;

                if (cmbPageImages.SelectedIndex > -1)
                    campaign.ImageLeftMenu = (string)cmbPageImages.SelectedItem;

                campaign.Save();

                IsEditing = false;
                UpdateUI(true);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private TreeNode FindDateNode(DateTime month)
        {
            TreeNode Result = null;

            foreach (TreeNode node in tvCampaigns.Nodes)
            {
                CampaignNodeType type = (CampaignNodeType)node.Tag;

                if (type.Type == NodeType.Date && type.Month.CompareTo(month) == 0)
                    return (node);
            }

            Result = new TreeNode(month.ToString(StringConstants.SYMBOL_DATE_FORMAT_MONTH_YEAR));
            Result.Tag = new CampaignNodeType(month);
            Result.ImageIndex = 2;
            Result.SelectedImageIndex = Result.ImageIndex;
            tvCampaigns.Nodes.Add(Result);

            return (Result);
        }

        private void tvCampaigns_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (IsEditing)
            {
                CampaignNodeType nodeType = (CampaignNodeType)tvCampaigns.SelectedNode.Tag;

                if (nodeType.Type == NodeType.Campaign &&
                    ShowQuestion(LanguageStrings.AppCampaignSave, LanguageStrings.AppCampaignSaveDescription))
                {
                    SaveCurrentCampaign(nodeType.Campaign);
                    IsEditing = false;
                }
            }
        }

        private void tvCampaigns_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CampaignNodeType nodeType = (CampaignNodeType)e.Node.Tag;
            this.Cursor = Cursors.WaitCursor;
            //tvCampaigns.SuspendDrawing();
            tabControlMain.SuspendDrawing();
            try
            {
                tabControlMain.TabPages.Clear();

                switch (nodeType.Type)
                {
                    case NodeType.Campaign:
                        tabControlMain.TabPages.Add(tabPageSettings);

                        if (nodeType.Campaign.StartDateTime < DateTime.Now)
                        {
                            AddMapTab(nodeType.Campaign);
                        }

                        LoadCampaignData(nodeType.Campaign);

                        break;

                    case NodeType.Active:
                    case NodeType.Date:
                    case NodeType.Future:
                    case NodeType.Top:
                        tabControlMain.TabPages.Insert(0, tabPageCampaigns);
                        lvCampaigns.Items.Clear();

                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            nodeType = (CampaignNodeType)node.Tag;

                            ListViewItem item = new ListViewItem(nodeType.Campaign.Title);
                            item.SubItems.Add(nodeType.Campaign.Visits.ToString());
                            item.SubItems.Add(nodeType.Campaign.Sales.ToString());
                            item.SubItems.Add(nodeType.Campaign.Invoices.ToString());
                            item.Tag = node;
                            lvCampaigns.Items.Add(item);
                        }

                        break;
                }

                AllowRefresh = true;
                AllowEdit = false;
                AllowDelete = false;
                AllowAddNew = true;
                IsEditing = false;
                UpdateUI(true);

            }
            finally
            {
                //tvCampaigns.ResumeDrawing();
                tabControlMain.ResumeDrawing();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void LoadImages()
        {
            LoadHomeImages();
            LoadPageImages();
            LoadOfferImages();
        }

        private void LoadHomeImages()
        { 
            cmbHomeImages.Items.Clear();

            string[] files = Directory.GetFiles(AppController.POSFolder(ImageTypes.HomePageBanners), 
                StringConstants.IMAGE_SEARCH_HOME_IMAGES);

            foreach (string file in files)
            {
                cmbHomeImages.Items.Add(Path.GetFileName(file));
            }
        }

        private void LoadPageImages()
        {
            cmbPageImages.Items.Clear();

            string[] files = Directory.GetFiles(AppController.POSFolder(ImageTypes.PageBanners),
                StringConstants.IMAGE_SEARCH_PAGE_IMAGES);

            foreach (string file in files)
            {
                cmbPageImages.Items.Add(Path.GetFileName(file));
            }
        }

        private void LoadOfferImages()
        {
            cmbOffersPageImage.Items.Clear();

            string[] files = Directory.GetFiles(AppController.POSFolder(ImageTypes.OfferImages),
                StringConstants.IMAGE_SEARCH_OFFER_IMAGES);

            foreach (string file in files)
            {
                cmbOffersPageImage.Items.Add(Path.GetFileName(file));
            }
        }

        #region Campaign Tab

        private void lvCampaigns_DoubleClick(object sender, EventArgs e)
        {
            if (lvCampaigns.SelectedItems.Count == 0)
                return;

            TreeNode node = (TreeNode)lvCampaigns.SelectedItems[0].Tag;
            tvCampaigns.SelectedNode = node;
            node.EnsureVisible();
        }

        #endregion Campaign Tab

        #region Map Tab

        private void AddMapTab(Campaign campaign)
        {
            string mapLocations = GetLocations(campaign);

            if (String.IsNullOrEmpty(mapLocations))
                return;

            // create temp html file
            string contents = textBlockMap.StringBlock;
            contents = contents.Replace(StringConstants.MAP_LOCATIONS, mapLocations);
            contents = contents.Replace(StringConstants.MAP_TITLE, 
                String.Format(LanguageStrings.AppCampaignTitle, campaign.Title));

            // save map data
            Shared.Utilities.FileWrite(_tempFile, contents);
            try
            {
                browserMap.Url = new Uri(_tempFile);
            }
            finally
            {
                //File.Delete(file); 
            }

            tabControlMain.TabPages.Add(tabPageMap);
            tabControlMain.TabPages.Add(tabPageDetails);
        }

        private void LoadCampaignData(Campaign campaign)
        {
            if (campaign == null)
                return;

            dtpStartDate.Value = campaign.StartDateTime;

            try
            {
                dtpEndTime.Value = campaign.FinishDateTime;
            }
            catch (ArgumentOutOfRangeException)
            {
                if (campaign.FinishDateTime > DateTime.Now)
                    ShowError(LanguageStrings.AppCampaign, LanguageStrings.AppcampaignFinishDateWrong);

                campaign.FinishDateTime = campaign.StartDateTime.AddHours(6);
            }

            txtTrackingCode.Text = campaign.CampaignName;
            txtCampaignTitle.Text = campaign.Title;
            txtOfferPageText.Text = campaign.OffersPageText;

            dtpEndTime.Enabled = campaign.FinishDateTime > DateTime.Now;
            dtpStartDate.Enabled = campaign.StartDateTime > DateTime.Now;
            txtTrackingCode.ReadOnly = campaign.StartDateTime < DateTime.Now;
            txtCampaignTitle.ReadOnly = campaign.StartDateTime < DateTime.Now;
            txtOfferPageText.ReadOnly = campaign.FinishDateTime < DateTime.Now;

            cmbHomeImages.Enabled = campaign.FinishDateTime > DateTime.Now;
            cmbOffersPageImage.Enabled = campaign.FinishDateTime > DateTime.Now;
            cmbPageImages.Enabled = campaign.FinishDateTime > DateTime.Now;

            if (!String.IsNullOrEmpty(campaign.ImageMainPage) | campaign.FinishDateTime > DateTime.Now)
            {
                tabControlMain.TabPages.Add(tabPageHomeImage);

                if (campaign.ImageMainPage.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) || 
                    campaign.ImageMainPage.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
                {
                    picHomeImage.ImageLocation = campaign.ImageMainPage;
                }
                else if (!String.IsNullOrEmpty(campaign.ImageMainPage))
                {
                    string imageFile = AppController.POSFolder(ImageTypes.HomePageBanners) + campaign.ImageMainPage;

                    if (File.Exists(imageFile))
                        picHomeImage.ImageLocation = imageFile;

                }
            }

            cmbHomeImages.SelectedIndex = cmbHomeImages.Items.IndexOf(campaign.ImageMainPage);

            if (!String.IsNullOrEmpty(campaign.ImageOffersPage) | campaign.FinishDateTime > DateTime.Now)
            {
                tabControlMain.TabPages.Add(tabPageOfferImage);

                if (campaign.ImageOffersPage.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) ||
                    campaign.ImageOffersPage.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
                {
                    picOfferImage.ImageLocation = campaign.ImageOffersPage;
                }
                else if (!String.IsNullOrEmpty(campaign.ImageOffersPage))
                {
                    string imageFile = AppController.POSFolder(ImageTypes.OfferImages) + campaign.ImageOffersPage;

                    if (File.Exists(imageFile))
                        picHomeImage.ImageLocation = imageFile;

                }
            }

            cmbOffersPageImage.SelectedIndex = cmbOffersPageImage.Items.IndexOf(campaign.ImageOffersPage);

            if (!String.IsNullOrEmpty(campaign.ImageLeftMenu) | campaign.FinishDateTime > DateTime.Now)
            {
                tabControlMain.TabPages.Add(tabPagePageImage);

                if (campaign.ImageLeftMenu.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) ||
                    campaign.ImageLeftMenu.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
                {
                    picPageImage.ImageLocation = campaign.ImageLeftMenu;
                }
                else if (!String.IsNullOrEmpty(campaign.ImageLeftMenu))
                {
                    string imageFile = AppController.POSFolder(ImageTypes.PageBanners) + campaign.ImageLeftMenu;

                    if (File.Exists(imageFile))
                        picPageImage.ImageLocation = imageFile;

                }
            }

            cmbPageImages.SelectedIndex = cmbPageImages.Items.IndexOf(campaign.ImageLeftMenu);
        }

        private string GetLocations(Campaign campaign)
        {
            SeoReports mapData = SeoReports.SEOCampaign(campaign);
            string Result = String.Empty;

            if (mapData == null || mapData.Count == 0)
                return (String.Empty);

            foreach (SeoReport report in mapData)
            {
                string image = "green";
                //switch (_reportType)
                //{
                //    case MapReportType.City:
                Result += String.Format("['{5}: {0}\\rVisits: {1}', {2}, {3}, '{4}'],",
                    String.IsNullOrEmpty(report.City) ? report.Country : report.City.Replace("'", " "),
                    report.TotalVisits,
                    report.Latitude,
                    report.Longitude,
                    image,
                    String.IsNullOrEmpty(report.City) ? "Country" : "City");
                //    break;
                //case MapReportType.Country:
                //Result += String.Format("['Country: {0}\\rVisits: {1}', {2}, {3}, '{4}'],",
                    //report.City.Replace("'", " "),
                    //report.TotalVisits,
                    //report.Latitude,
                    //report.Longitude,
                    //image);
                //break;
                //case MapReportType.Currency:
                //Result += String.Format("['Currency: {0}\\rTotal Sales: {1}', {2}, {3}, '{4}'],",
                //    report.Currency,
                //    report.Sales,
                //    report.Latitude,
                //    report.Longitude,
                //    image);
                //    break;
                //default:
                //    throw new Exception("Invalid Report Type");
                //}
            }

            if (Result.EndsWith(","))
                Result = Result.Substring(0, Result.Length - 1);

            lvCampaignDetails.BeginUpdate();
            try
            {
                lvCampaignDetails.Items.Clear();

                foreach (SeoReport report in mapData)
                {
                    ListViewItem item = new ListViewItem(report.Country);
                    item.SubItems.Add(report.City);
                    item.SubItems.Add(report.TotalVisits.ToString());
                    item.SubItems.Add(report.Currency);
                    item.SubItems.Add(report.Sales == 0 ? String.Empty : report.Sales.ToString());

                    lvCampaignDetails.Items.Add(item);
                }
            }
            finally
            {
                lvCampaignDetails.EndUpdate();
            }

            
            return (Result);
        }

        private void browserMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            File.Delete(_tempFile);
        }

        #endregion Map Tab

        #region Page Image Tab

        private void cmbPageImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageFile = AppController.POSFolder(ImageTypes.PageBanners) + cmbPageImages.SelectedItem;

            if (File.Exists(imageFile))
                picPageImage.ImageLocation = imageFile;

            IsEditing = true;
            UpdateUI(true);
        }

        #endregion Page Image Tab

        #region Offers Image Tab

        private void cmbOffersPageImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageFile = AppController.POSFolder(ImageTypes.OfferImages) + cmbOffersPageImage.SelectedItem;

            if (File.Exists(imageFile))
                picOfferImage.ImageLocation = imageFile;

            IsEditing = true;
            UpdateUI(true);
        }

        #endregion Offers Image Tab

        #region Home Image Tab

        private void cmbHomeImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageFile = AppController.POSFolder(ImageTypes.HomePageBanners) + cmbHomeImages.SelectedItem;

            if (File.Exists(imageFile))
                picHomeImage.ImageLocation = imageFile;

            IsEditing = true;
            UpdateUI(true);
        }

        #endregion Home Image Tab

        #endregion Private Methods

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndTime.MinDate = dtpStartDate.Value.AddHours(6);
            valueChanged(sender, e);
        }

        private void valueChanged(object sender, EventArgs e)
        {
            IsEditing = true;
            UpdateUI(true);
        }
    }
}
