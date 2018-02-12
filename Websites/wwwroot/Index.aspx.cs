using System;

using Website.Library;
using Website.Library.Classes;
using Library.BOL.Websites;
using Shared.Classes;

namespace SieraDelta.Website
{
    public partial class PageIndex : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divBanners.Visible = WebsiteSettings.HomePage.ShowHomeBanners;
            UpdateCustomTranslatedPageData(StringConstants.TRANSLATED_DATA_HOME_PAGE, divTranslated, false);
            FeaturedProducts1.Visible = WebsiteSettings.HomePage.ShowHomeFeaturedProducts;
        }

        protected string GetBannerLinks()
        {
            string Result = String.Empty;

            if (Library.DAL.DALHelper.AllowCaching)
            {
                CacheItem cached = GlobalClass.InternalCache.Get(StringConstants.CACHE_NAME_HOME_PAGE_FIXED_BANNERS);

                if (cached != null)
                {
                    return ((string)cached.Value);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                string setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER_LINK, 
                    Library.DAL.DALHelper.WebsiteID, i);
                string link = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER_DESCRIPTION, 
                    Library.DAL.DALHelper.WebsiteID, i);
                string title = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER_TITLE, 
                    Library.DAL.DALHelper.WebsiteID, i);
                string description = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER, 
                    Library.DAL.DALHelper.WebsiteID, i);
                string image = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

                if (!String.IsNullOrEmpty(image) || !String.IsNullOrEmpty(description) || !String.IsNullOrEmpty(link))
                {
                    string extra = i == 0 ? String.Empty : "margin: 0 0 0 10px;";

                    Result += String.Format("<a href=\"{1}\" class=\"bannerHome\" style=\"background: " +
                        "url('/images/HomeFixedBanners/{4}') no-repeat 0 0;{5}\" title=\"{2}\">" +
                        "<div class=\"overlay\"><h6>{3}</h6></div><span><strong>{2}</strong></span></a>",
                        i, link, title, description, image, extra);
                }
            }

            if (Library.DAL.DALHelper.AllowCaching)
                GlobalClass.InternalCache.Add(StringConstants.CACHE_NAME_HOME_PAGE_FIXED_BANNERS, 
                    new CacheItem(StringConstants.CACHE_NAME_HOME_PAGE_FIXED_BANNERS, Result));

            return (Result);
        }
    }
}