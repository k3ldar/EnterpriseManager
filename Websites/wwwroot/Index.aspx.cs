using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.Campaigns;
using Shared.Classes;

namespace SieraDelta.Website
{
    public partial class PageIndex : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divBanners.Visible = Global.ShowHomeBanners;
            UpdateCustomTranslatedPageData("Home Page", divTranslated, false);
        }
        public const string WEB_SETTING_HOME_FIXED_BANNER_SHOW = "{0}.SETTINGS.HOMEBANNERS";
        public const string WEB_SETTING_HOME_FIXED_BANNER = "{0}.FIXEDBANNER{1}";
        public const string WEB_SETTING_HOME_FIXED_BANNER_LINK = "{0}.FIXEDBANNER{1}LINK";
        public const string WEB_SETTING_HOME_FIXED_BANNER_TITLE = "{0}.FIXEDBANNER{1}TITLE";
        public const string WEB_SETTING_HOME_FIXED_BANNER_DESCRIPTION = "{0}.FIXEDBANNER{1}NAME";

        protected string GetBannerLinks()
        {
            string name = "Page Fixed Banner Cache";

            string Result = String.Empty;

            if (Library.DAL.DALHelper.AllowCaching)
            {
                CacheItem cached = GlobalClass.InternalCache.Get(name);

                if (cached != null)
                {
                    return ((string)cached.Value);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                string setting = String.Format(WEB_SETTING_HOME_FIXED_BANNER_LINK, Library.DAL.DALHelper.WebsiteID, i);
                string link = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(WEB_SETTING_HOME_FIXED_BANNER_DESCRIPTION, Library.DAL.DALHelper.WebsiteID, i);
                string title = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(WEB_SETTING_HOME_FIXED_BANNER_TITLE, Library.DAL.DALHelper.WebsiteID, i);
                string description = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(WEB_SETTING_HOME_FIXED_BANNER, Library.DAL.DALHelper.WebsiteID, i);
                string image = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                if (!String.IsNullOrEmpty(image) || !String.IsNullOrEmpty(description) || !String.IsNullOrEmpty(link))
                {
                    Result += String.Format("<a href=\"/Images/HomeFixedBanners{1}\" class=\"banner{0}\" title=\"{2}\">" +
                        "<div class=\"overlay\"><h6>{3}</h6></div><span><strong>{2}</strong></span></a>",
                        i, link, title, description);
                }
            }

            if (Library.DAL.DALHelper.AllowCaching)
                GlobalClass.InternalCache.Add(name, new CacheItem(name, Result));

            return (Result);
        }
    }
}