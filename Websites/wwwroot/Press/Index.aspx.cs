using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.BOL.News;
using Library.Utils;

namespace SieraDelta.Website.Press
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetPressItems()
        {
            string Result = "";

            //SieraDeltaUtils u = new SieraDeltaUtils();
            bool first = true;
            NewsItems items = NewsItems.Get(GetFormValue("Page", 1), 12);

            foreach (NewsItem item in items)
            {
                if (item.URL != "")
                {
                    Result += String.Format("<li><a href=\"{0}\" target=\"_blank\"><img src=\"/Images/Press/{1}_icon.png\" alt=\"\" border=\"0\" width=\"93\" height=\"130\"/>" +
                        "<span class=\"newPress\" {4}>{5}</span><span class=\"best\" {3}>{6}</span><strong>{2}</strong></a></li>",
                        item.URL, item.Image, item.Title, SharedUtils.DateTimeToStr(item.DateTime, WebCulture), first ? " style=\"display:block;\"" : "",
                        Languages.LanguageStrings.New, Languages.LanguageStrings.BestSeller);
                }
                else
                {
                    Result += String.Format("<li><a href=\"/Press/View.aspx?ID={0}\"><img src=\"/Images/Press/{1}_icon.png\" alt=\"\" border=\"0\" width=\"93\" height=\"130\"/>" +
                        "<span class=\"newPress\" {4}>{5}</span><span class=\"best\" {3}>{6}</span><strong>{2}</strong></a></li>",
                        item.ID, item.Image, item.Title, SharedUtils.DateTimeToStr(item.DateTime, WebCulture), first ? " style=\"display:block;\"" : "", 
                        Languages.LanguageStrings.New, Languages.LanguageStrings.BestSeller);
                }

                first = false;
            }

            if (Result == "")
                Result = String.Format("<p>{0}</p>", Languages.LanguageStrings.NoNews);

            return (Result);
        }
    }
}