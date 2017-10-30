using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Website.Library;

using Library.BOL.Products;
using Library.Utils;
using Library.BOL.SEO;

using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class MediaLinks : BaseControlClass
    {
        #region Private Members

        string _image = null;
        string _text = null;
        string _sku = null;

        #endregion Private Members

        #region Protected Members

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetMediaLinks(bool facebook = true, bool twitter = true, bool pinIt = true, bool plusOne = true)
        {
            string Result = String.Empty;

            UserSession session = (UserSession)Session[ StringConstants.SESSION_NAME_USER_SESSION];

            if (session.MobileRedirect)
            {
                Result = String.Empty;

                if (facebook)
                {
                    string fbExtra;

                    if (String.IsNullOrEmpty(_sku))
                        fbExtra = Request.Url.ToString();
                    else
                        fbExtra = String.Format("{0}/products.aspx?SKU={1}", Request.Url.ToString(), _sku);

                    Result += String.Format("<tr><td style=\"width:290px;padding-bottom:15px;\"><div class=\"fb-like\" data-href=\"{0}\" data-height=\"10\" data-width=\"260\" data-colorscheme=\"light\" data-layout=\"standard\" data-action=\"like\" data-show-faces=\"false\" data-send=\"false\"></div></td></tr>",
                        fbExtra);
                }

                if (twitter)
                {
                    string urlExtra = String.Empty;

                    urlExtra = String.Format("?url={0}", Request.Url.ToString());

                    if (!String.IsNullOrEmpty(_text))
                        urlExtra += String.Format("&text={0}", _text);

                    Result += String.Format("<tr><td style=\"width:290px;padding-bottom:15px;\"><a href=\"https://twitter.com/share{0}\" class=\"twitter-share-button\" data-hashtags=\"{1}\">Tweet</a></td></tr>", urlExtra, BaseWebApplication.TwitterDefaultTags);
                }

                if (pinIt)
                    Result += "<tr><td style=\"width:290px;padding-bottom:15px;\"></td></tr>";

                if (plusOne)
                    Result += String.Format("<tr><td style=\"width:290px;padding-bottom:15px;\"><div class=\"g-plusone\" data-size=\"medium\" data-annotation=\"inline\" data-width=\"150\" data-href=\"{0}\"></div></td></tr>",
                        Request.Url.ToString());
            }
            else
            {
                Result = "<tr>";

                if (facebook)
                {
                    string fbExtra;

                    if (String.IsNullOrEmpty(_sku))
                        fbExtra = Request.Url.ToString();
                    else
                        fbExtra = String.Format("{0}/products.aspx?SKU={1}", Request.Url.ToString(), _sku);

                    Result += String.Format("<td><div class=\"fb-like\" data-href=\"{0}\" data-width=\"80\" data-height=\"10\" data-colorscheme=\"light\" data-layout=\"standard\" data-action=\"like\" data-show-faces=\"false\" data-send=\"false\"></div></td>",
                        fbExtra);
                }

                if (twitter)
                {
                    string urlExtra = String.Empty;

                    urlExtra = String.Format("?url={0}", Request.Url.ToString());

                    if (!String.IsNullOrEmpty(_text))
                        urlExtra += String.Format("&text={0}", _text);

                    Result += String.Format("<td><a href=\"https://twitter.com/share{0}\" class=\"twitter-share-button\" data-hashtags=\"{1}\">Tweet</a></td>", urlExtra, BaseWebApplication.TwitterDefaultTags);
                }

                if (pinIt)
                    Result += "<td style=\"padding-right: 10px;\"></td>";

                if (plusOne)
                    Result += String.Format("<td><div class=\"g-plusone\" data-size=\"medium\" data-annotation=\"inline\" data-width=\"300\" data-href=\"{0}\"></div></td>",
                        Request.Url.ToString());

                Result += "</tr>";
            }

            return (Result);
        }

        #endregion Protected Members

        #region Public Members

        /// <summary>
        /// Change the links into product links
        /// </summary>
        public Product ProductLink
        {
            set
            {
                if (value != null)
                {
                    _image = value.Image.ToLower();

                    if (!_image.Contains(".png") && !_image.Contains(".jpg"))
                        _image += "_200.jpg";

                    _image = SharedUtils.ResizeImage(_image, 200);

                    _text = value.Name;
                    _sku = value.SKU;
                }
            }
        }

        #endregion Public Members
    }
}