using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class LeftContainerControl : BaseControlClass
    {
        private bool _showCampaign = true;

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

            divSubscribers.Visible = !HideSubscription && Global.AllowMailListSubscribers;

            if (!String.IsNullOrEmpty(Global.TradeBanner))
                if (System.IO.File.Exists(String.Format("{1}Images\\Banners\\{0}", System.IO.Path.GetFileName(
                    Global.TradeBanner), Global.Path)))
                {
                    imageTrade.Src = Global.TradeBanner;
                }

            if (!String.IsNullOrEmpty(Global.BlogBanner))
                if (System.IO.File.Exists(String.Format("{1}Images\\Banners\\{0}", System.IO.Path.GetFileName(
                    Global.BlogBanner), Global.Path)))
                {
                    imageBlog.Src = Global.BlogBanner;
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


        public bool HideSubscription { get; set; }

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
    }
}