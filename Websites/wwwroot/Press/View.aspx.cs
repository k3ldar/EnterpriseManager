using System;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.News;

namespace SieraDelta.Website.Press
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
            //SieraDeltaUtils u = new SieraDeltaUtils();

            string Result = SharedUtils.PreProcessPost(Library.BOL.Websites.WebsiteSettings.RootURL, _news.Text);

            return (Result);
        }

        protected string GetNewsTitle()
        {
            string Result = _news.Title;

            return (Result);
        }

        protected string GetNewsDate()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            string Result = String.Format("<strong>{1}</strong>: {0}", SharedUtils.DateToStr(_news.DateTime, WebCulture), Languages.LanguageStrings.ReleaseDate);

            return (Result);
        }
    }
}