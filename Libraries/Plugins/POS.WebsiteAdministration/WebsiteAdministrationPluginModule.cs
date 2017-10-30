using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using POS.WebsiteAdministration.Forms.Salons;

using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Products;
using Library.BOL.Salons;
using Library.BOL.Statistics;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    public class WebsiteAdministrationPluginModule : BasePlugin
    {
        #region Private Members

        private WebsitesCard _websitesCard;
        private CountriesCard _countriesCard;
        private CustomerCommentsCard _customerCommentsCard;
        private OnlineTreatmentsCard _onlineTreatmentsCard;
        private OnlineTreatmentGroupsCard _onlineTreatmentGroupsCard;
        private WebSiteVideosCard _websiteVideoCard;
        private CelebritiesCard _celebritiesCard;
        private HintsAndTipsCard _hintsAndTipsCard;
        private DistributorsCard _distributorsCard;
        private MissingLinksCard _missingLinksCard;
        private UpdateDistributorDetailsCard _updateDistributorDetailsCard;


        private ToolStripMenuItem menuAdminWebsite;
        private ToolStripSeparator menuAdminWebsiteSeperator;

        private ToolStripMenuItem menuAdminWebsiteCountries;
        private ToolStripSeparator menuAdminWebsiteCountriesSeperator;

        private ToolStripMenuItem menuAdminWebsiteTreatments;
        private ToolStripMenuItem menuAdminWebsiteTreatmentsTreatGroups;
        private ToolStripMenuItem menuAdminWebsiteTreatmentsTreats;

        private ToolStripSeparator menuAdminWebsiteTreatmentsSeperator;

        private ToolStripMenuItem menuAdminWebsiteDistributors;
        private ToolStripSeparator menuAdminWebsiteDistributorsSeperator;
        private ToolStripMenuItem menuAdminWebsiteDistributorsView;
        private ToolStripMenuItem menuAdminWebsiteSalonsSalonToOwners;
        private ToolStripSeparator menuAdminWebsiteDistributorsDistSeperator;
        private ToolStripMenuItem menuAdminWebsiteDistributorsUpdates;

        private ToolStripMenuItem menuAdminWebsiteMissingLinks;
        private ToolStripMenuItem menuAdminWebsiteCelebrities;
        private ToolStripMenuItem menuAdminWebsiteTipsTricks;
        private ToolStripMenuItem menuAdminWebsiteVideos;
        private ToolStripSeparator menuAdminWebsiteVideoSeperator;
        private ToolStripMenuItem menuAdminWebsiteCustomerComments;

        #endregion Private Members

        #region Internal Static Members

        internal static int WebsiteCount = 0;

        #endregion Internal Static Members

        #region Constructors

        public WebsiteAdministrationPluginModule(Form parent)
            : base(parent)
        {
            RaiseAlerts = true;
            AlertFrequency = new TimeSpan(0, 20, 0);
        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginWebsiteAdministration);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override bool BeforeLoad()
        {
            Library.BOL.Websites.Websites allSites = Library.BOL.Websites.Websites.All();
            WebsiteCount = allSites.Count;

            return (true);
        }

        public override void AfterLoad()
        {

        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuAdminWebsiteCelebrities.Text = LanguageStrings.AppMenuCelebrities;
            menuAdminWebsiteTipsTricks.Text = LanguageStrings.AppMenuTipsTricks;
            menuAdminWebsiteVideos.Text = LanguageStrings.AppMenuVideos;
            menuAdminWebsite.Text = LanguageStrings.AppMenuWebsite;
            menuAdminWebsiteCountries.Text = LanguageStrings.AppMenuCountries;
            menuAdminWebsiteMissingLinks.Text = LanguageStrings.AppMenuMissingLinks;
            menuAdminWebsiteSalonsSalonToOwners.Text = LanguageStrings.AppMenuSalonToOwners;
            menuAdminWebsiteDistributorsUpdates.Text = LanguageStrings.AppMenuDistributorUpdates;
            menuAdminWebsiteTreatments.Text = LanguageStrings.AppMenuTreatments;
            menuAdminWebsiteTreatmentsTreatGroups.Text = LanguageStrings.AppMenuTreatmentGroups;
            menuAdminWebsiteTreatmentsTreats.Text = LanguageStrings.AppMenuSalonTreatments;
            menuAdminWebsiteDistributors.Text = LanguageStrings.AppMenuDistributors;
            menuAdminWebsiteCustomerComments.Text = LanguageStrings.AppMenuCustomerComments;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppWebsiteOptions,
                Languages.LanguageStrings.AppWebsiteOptionsDescription,
                null, new Controls.WebsiteSettings()); //Website plugin
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            return (true);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Accounts:
                    CreateAccountsMenu(parentMenu);
                    break;
                case PluginMenuType.Administration:
                    CreateAdminMenuItems(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {
            if (menuType == PluginMenuType.Administration)
            {
                menuAdminWebsite.Visible = AppController.LocalSettings.ShowWebsiteMenuItem;
                menuAdminWebsiteSeperator.Visible = AppController.LocalSettings.ShowWebsiteMenuItem;
            }
        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_countriesCard == null)
                _countriesCard = new CountriesCard(this);

            if (_customerCommentsCard == null)
                _customerCommentsCard = new CustomerCommentsCard(this);

            if (_onlineTreatmentsCard == null)
                _onlineTreatmentsCard = new OnlineTreatmentsCard(this);

            if (_onlineTreatmentGroupsCard == null)
                _onlineTreatmentGroupsCard = new OnlineTreatmentGroupsCard(this);

            if (_websiteVideoCard == null)
                _websiteVideoCard = new WebSiteVideosCard(this);

            if (_celebritiesCard == null)
                _celebritiesCard = new CelebritiesCard(this);

            if (_hintsAndTipsCard == null)
                _hintsAndTipsCard = new HintsAndTipsCard(this);

            if (_distributorsCard == null)
                _distributorsCard = new DistributorsCard(this);

            if (_missingLinksCard == null)
                _missingLinksCard = new MissingLinksCard(this);

            if (_updateDistributorDetailsCard == null)
                _updateDistributorDetailsCard = new UpdateDistributorDetailsCard(this);

            if (_websitesCard == null)
                _websitesCard = new WebsitesCard(this);

            Result.Add(_missingLinksCard);
            Result.Add(_customerCommentsCard);
            Result.Add(_distributorsCard);
            Result.Add(_updateDistributorDetailsCard);
            Result.Add(_onlineTreatmentsCard);
            Result.Add(_onlineTreatmentGroupsCard);
            Result.Add(_websiteVideoCard);
            Result.Add(_celebritiesCard);
            Result.Add(_hintsAndTipsCard);
            Result.Add(_countriesCard);
            Result.Add(_websitesCard);

            return (Result);
        }

        #region Tray Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            Result.Add(new SalonUpdateTrayNotification(this));
            Result.Add(new WebsiteCommentsTrayNotification(this));

            return (Result);
        }

        #endregion Tray Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_EDIT_SALON:
                    EditSalonDetails((Salon)e.EventValue);
                    break;

                case StringConstants.PLUGIN_EVENT_WEBSITE_MODULE:
                    e.AllowContinue = false;
                    e.Result = true;
                    break;

                case StringConstants.PLUGIN_EVENT_WEBSITE_COUNT:
                    e.AllowContinue = false;
                    e.Result = WebsiteCount;
                    break;

                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);

            names.Add(StringConstants.PLUGIN_EVENT_EDIT_SALON);
            names.Add(StringConstants.PLUGIN_EVENT_WEBSITE_MODULE);
            names.Add(StringConstants.PLUGIN_EVENT_WEBSITE_COUNT);
        }

        #endregion Notification Events

        public override void Alert()
        {
            if (AppController.LocalSettings.FeaturedProductCheck)
            {
                SimpleStatistics stats = Products.FeaturedProducts();

                if (stats.Count == 0)
                {
                    AddToastNotification(LanguageStrings.AppProductsFeaturedProductMissing, null, null);
                }
                else if (stats.Count > 1)
                {
                    AddToastNotification(LanguageStrings.AppProductsFeaturedMultiple, MultipleFeaturedProducts, stats);
                }
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void MultipleFeaturedProducts(object stats)
        {
            SimpleStatistics simpleStats = (SimpleStatistics)stats;

            string products = String.Empty;
            bool first = true;

            foreach (SimpleStatistic stat in simpleStats)
            {
                if (first)
                {
                    first = false;
                    products = stat.Description;
                }
                else
                {
                    products += StringConstants.SYMBOL_CRLF + stat.Description;
                }
            }

            MessageBox.Show(String.Format(LanguageStrings.AppProductsFeaturedMultipleDescription, products), LanguageStrings.AppProductsFeaturedMultiple, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditSalonDetails(Salon salon)
        {
            AdminDistributorEdit salonedit = new AdminDistributorEdit(salon);
            try
            {
                salonedit.ShowDialog(ParentForm);
            }
            finally
            {
                salonedit.Dispose();
                salonedit = null;
            }
        }

        private void CreateAccountsMenu(ToolStripMenuItem parent)
        {

        }

        private void CreateAdminMenuItems(ToolStripMenuItem parent)
        {
            menuAdminWebsite = new ToolStripMenuItem(LanguageStrings.AppMenuWebsite);
            parent.DropDownItems.Insert(0, menuAdminWebsite);

            menuAdminWebsiteSeperator = new ToolStripSeparator();
            parent.DropDownItems.Insert(1, menuAdminWebsiteSeperator);

            menuAdminWebsiteCountries = new ToolStripMenuItem(LanguageStrings.AppMenuCountries);
            menuAdminWebsiteCountries.Click += menuAdminWebsiteCountries_Click;
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteCountries);

            menuAdminWebsiteCountriesSeperator = new ToolStripSeparator();
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteCountriesSeperator);

            menuAdminWebsiteTreatments = new ToolStripMenuItem(LanguageStrings.AppMenuTreatments);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteTreatments);

            menuAdminWebsiteTreatmentsSeperator = new ToolStripSeparator();
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteTreatmentsSeperator);

            menuAdminWebsiteTreatmentsTreatGroups = new ToolStripMenuItem(LanguageStrings.AppMenuTreatmentGroups);
            menuAdminWebsiteTreatmentsTreatGroups.Click += menuAdminWebsiteTreatmentsTreatGroups_Click;
            menuAdminWebsiteTreatments.DropDownItems.Add(menuAdminWebsiteTreatmentsTreatGroups);

            menuAdminWebsiteTreatmentsTreats = new ToolStripMenuItem(LanguageStrings.AppMenuTreatments);
            menuAdminWebsiteTreatmentsTreats.Click += menuAdminWebsiteTreatmentsTreats_Click;
            menuAdminWebsiteTreatments.DropDownItems.Add(menuAdminWebsiteTreatmentsTreats);

            menuAdminWebsiteDistributors = new ToolStripMenuItem(LanguageStrings.AppMenuDistributors);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteDistributors);

            menuAdminWebsiteDistributorsSeperator = new ToolStripSeparator();
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteDistributorsSeperator);

            menuAdminWebsiteDistributorsView = new ToolStripMenuItem(LanguageStrings.AppMenuDistributors);
            menuAdminWebsiteDistributorsView.Click += menuAdminWebsiteDistributorsView_Click;
            menuAdminWebsiteDistributors.DropDownItems.Add(menuAdminWebsiteDistributorsView);

            menuAdminWebsiteDistributorsDistSeperator = new ToolStripSeparator();
            menuAdminWebsiteDistributors.DropDownItems.Add(menuAdminWebsiteDistributorsDistSeperator);

            menuAdminWebsiteSalonsSalonToOwners = new ToolStripMenuItem(LanguageStrings.AppMenuSalonToOwners);
            menuAdminWebsiteSalonsSalonToOwners.Click += menuAdminWebsiteSalonsSalonToOwners_Click;
            menuAdminWebsiteDistributors.DropDownItems.Add(menuAdminWebsiteSalonsSalonToOwners);

            menuAdminWebsiteDistributorsUpdates = new ToolStripMenuItem(LanguageStrings.AppMenuDistributorUpdates);
            menuAdminWebsiteDistributorsUpdates.Click += menuAdminWebsiteSalonsSalonUpdates_Click;
            menuAdminWebsiteDistributors.DropDownItems.Add(menuAdminWebsiteDistributorsUpdates);

            menuAdminWebsiteMissingLinks = new ToolStripMenuItem(LanguageStrings.AppMenuMissingLinks);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteMissingLinks);
            menuAdminWebsiteMissingLinks.Click += menuAdminWebsiteMissingLinks_Click;

            menuAdminWebsiteCelebrities = new ToolStripMenuItem(LanguageStrings.AppMenuMissingLinks);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteCelebrities);
            menuAdminWebsiteCelebrities.Click += menuAdminWebsiteCelebrities_Click;

            menuAdminWebsiteTipsTricks = new ToolStripMenuItem(LanguageStrings.AppMenuTipsTricks);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteTipsTricks);
            menuAdminWebsiteTipsTricks.Click += menuAdminWebsiteTipsTricks_Click;

            menuAdminWebsiteVideos = new ToolStripMenuItem(LanguageStrings.AppMenuVideos);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteVideos);
            menuAdminWebsiteVideos.Click += menuAdminWebsiteVideos_Click;

            menuAdminWebsiteVideoSeperator = new ToolStripSeparator();
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteVideoSeperator);

            menuAdminWebsiteCustomerComments = new ToolStripMenuItem(LanguageStrings.AppMenuCustomerComments);
            menuAdminWebsite.DropDownItems.Add(menuAdminWebsiteCustomerComments);
            menuAdminWebsiteCustomerComments.Click += menuAdminWebsiteCustomerComments_Click;
        }

        void menuAdminWebsiteTipsTricks_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTipsTricks))
            {
                _hintsAndTipsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionTipsTricks), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteCustomerComments_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.ManageCustomerComments))
            {
                _customerCommentsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionCustomerComments), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteVideos_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.ManageVideos))
            {
                _websiteVideoCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionVideos), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteCelebrities_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.ManageCelebrities))
            {
                _celebritiesCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionCelebrities), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteMissingLinks_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerMissingLinks))
            {
                _missingLinksCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionMissingLinks), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteSalonsSalonUpdates_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerSalonUpdates))
            {
                _updateDistributorDetailsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionAdministerSalonUpdates), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteSalonsSalonToOwners_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerSalonsView))
            {
                AdminSalonToUser salonToUser = new AdminSalonToUser();
                try
                {
                    salonToUser.ShowDialog(ParentForm);
                }
                finally
                {
                    salonToUser.Dispose();
                    salonToUser = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionAdministerSalon), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteDistributorsView_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerDistributors))
            {
                _distributorsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionViewDistributors), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteTreatmentsTreats_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTreatments))
            {
                _onlineTreatmentsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionTreatments), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteTreatmentsTreatGroups_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTreatmentGroups))
            {
                _onlineTreatmentGroupsCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionTreatmentGroups), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdminWebsiteCountries_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerCountries))
            {
                _countriesCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                     LanguageStrings.AppAdministerCountries), LanguageStrings.AppErrorPermisions,
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Private Methods
    }
}
