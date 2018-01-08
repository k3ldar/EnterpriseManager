using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Controls
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
    }
}