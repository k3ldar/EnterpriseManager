using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Celebrities;

namespace Heavenskincare.WebsiteTemplate.PageCelebrities
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetCelebrities()
        {
            string Result = "";

            Library.BOL.Celebrities.Celebrities celebs = Library.BOL.Celebrities.Celebrities.Get();

            foreach (Celebrity celeb in celebs)
            {
                Result += String.Format("<li style=\"height:185px;\"><a href=\"/Celebrities/ViewCeleb.aspx?ID={0}\"><img src=\"/Images/Celebs/{1}\" alt=\"\" border=\"0\" width=\"113\" height=\"160\"/>" +
                    "<span class=\"new\" ></span><span class=\"best\" ></span><br />{2}</a></li>\r\n",
                    celeb.ID, celeb.Image, celeb.Name);
            }

            return (Result);
        }
    }
}