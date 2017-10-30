using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.News;

namespace Heavenskincare.WebsiteTemplate.Press
{
    public partial class View : BaseWebForm
    {
        private NewsItem _news;

        protected void Page_Load(object sender, EventArgs e)
        {
            _news = NewsItems.Get(GetFormValue("ID", -1));

            if (_news == null)
                DoRedirect("/Press/Index.aspx", true);
        }

        protected string GetPressImage()
        {
            string Result = _news.Image;


            return (Result);
        }

        protected string GetNewsID()
        {
            string Result = _news.ID.ToString();
            return (Result);
        }

        protected string GetNewsText()
        {
            string Result = HSCUtils.PreProcessPost(_news.Text);

            return (Result);
        }

        protected string GetNewsTitle()
        {
            string Result = _news.Title;

            return (Result);
        }

        protected string GetNewsDate()
        {
            string Result = String.Format("<strong>{1}</strong>: {0}", Shared.Utilities.DateToStr(_news.DateTime, WebCulture), Languages.LanguageStrings.ReleaseDate);

            return (Result);
        }
    }
}