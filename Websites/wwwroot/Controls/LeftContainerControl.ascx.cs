using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shared.Classes;

using Website.Library;
using Website.Library.Classes;

namespace SieraDelta.Website.Controls
{
    public partial class LeftContainerControl : BaseControlClass
    {
        #region Private Members

        private bool _showCampaign = true;

        #endregion Private Members

        #region Protected Members

        protected void Page_Load(object sender, EventArgs e)
        {
            string subHeader = SubHeader;
            if (subHeader == "sub header")
                subHeader = String.Empty;

            if (!GetUserSession().MobileRedirect || String.IsNullOrEmpty(subHeader))
            {
                adivClose.Visible = false;
                divMobileShowColumn.Visible = false;
            }
        }

        protected string GetCampaignText()
        {
            if (GetUserSession().MobileRedirect)
                return (String.Empty);

            if (_showCampaign)
                return (GetPromotionalOffer());
            else
                return (String.Empty);
        }

        protected string GetPrefixPageBanners()
        {
            if (Library.DAL.DALHelper.AllowCaching)
            {
                CacheItem cacheItem = GlobalClass.InternalCache.Get(StringConstants.CACHE_NAME_PAGE_BANNERS_PREFIX);

                if (cacheItem != null)
                    return ((string)cacheItem.Value);
            }

            string Result = String.Empty;

            if (!String.IsNullOrEmpty(BaseWebApplication.PageBanner1))
            {
                if (String.IsNullOrEmpty(BaseWebApplication.PageBanner1Link))
                    Result = String.Format("<img src=\"/Images/PageBanners/{0}\" width=\"158\" class=\"banner\" />",
                        BaseWebApplication.PageBanner1);
                else
                    Result = String.Format("<a href=\"{0}\" class=\"banner\">" +
                        "<img src=\"/Images/PageBanners/{1}\" width=\"158\" /></a>",
                        BaseWebApplication.PageBanner1Link, BaseWebApplication.PageBanner1);
            }

            if (Library.DAL.DALHelper.AllowCaching)
            {
                GlobalClass.InternalCache.Add(StringConstants.CACHE_NAME_PAGE_BANNERS_PREFIX, 
                    new CacheItem(StringConstants.CACHE_NAME_PAGE_BANNERS_PREFIX, Result));
            }

            return (Result);
        }

        protected string GetSuffixPageBanners()
        {
            if (GetUserSession().MobileRedirect)
                return (String.Empty);

            if (Library.DAL.DALHelper.AllowCaching)
            {
                CacheItem cacheItem = GlobalClass.InternalCache.Get(StringConstants.CACHE_NAME_PAGE_BANNERS_SUFFIX);

                if (cacheItem != null)
                    return ((string)cacheItem.Value);
            }

            string Result = String.Empty;

            if (!String.IsNullOrEmpty(BaseWebApplication.PageBanner2))
            {
                if (String.IsNullOrEmpty(BaseWebApplication.PageBanner2Link))
                    Result += String.Format("<img src=\"/Images/PageBanners/{0}\" width=\"158\" />",
                        BaseWebApplication.PageBanner2);
                else
                    Result += String.Format("<a href=\"{0}\" target=\"_blank\" class=\"banner\">" +
                        "<img src=\"/Images/PageBanners/{1}\" width=\"158\" /></a>",
                        BaseWebApplication.PageBanner2Link, BaseWebApplication.PageBanner2);
            }

            if (!String.IsNullOrEmpty(BaseWebApplication.PageBanner3))
            {
                if (String.IsNullOrEmpty(BaseWebApplication.PageBanner3Link))
                    Result += String.Format("<img src=\"/Images/PageBanners/{0}\" class=\"banner\" width=\"158\" />",
                        BaseWebApplication.PageBanner3);
                else
                    Result += String.Format("<a href=\"{0}\" class=\"banner\">" +
                        "<img src=\"/Images/PageBanners/{1}\" width=\"158\" /></a>",
                        BaseWebApplication.PageBanner3Link, BaseWebApplication.PageBanner3);
            }

            if (Library.DAL.DALHelper.AllowCaching)
            {
                GlobalClass.InternalCache.Add(StringConstants.CACHE_NAME_PAGE_BANNERS_SUFFIX, 
                    new CacheItem(StringConstants.CACHE_NAME_PAGE_BANNERS_SUFFIX, Result));
            }

            return (Result);
        }

        #endregion Protected Methods

        #region Properties

        /// <summary>
        /// Determines wether campaign data is shown
        /// </summary>
        protected bool ShowCampaign
        {
            get
            {
                return (_showCampaign);
            }

            set
            {
                _showCampaign = value;
            }
        }

        public string SubHeader
        {
            set
            {
                subHeader.InnerHtml = value;
            }

            get
            {
                return (subHeader.InnerHtml);
            }
        }

        public string SubOptions
        {
            set
            {
                subOptions.InnerHtml = value;
            }

            get
            {
                return (subOptions.InnerHtml);
            }
        }

        public string SubOptionsPlain
        {
            get
            {
                return (subOptionsOther.InnerHtml);
            }

            set
            {
                subOptions.Visible = false;
                subOptionsOther.Visible = !String.IsNullOrEmpty(value);
                subOptionsOther.InnerHtml = value;
            }
        }

        public bool SubOptionsShow
        {
            set
            {
                subHeader.Visible = value;
                subOptions.Visible = value;
            }

            get
            {
                return (subHeader.Visible);
            }
        }

        #endregion Properties
    }
}