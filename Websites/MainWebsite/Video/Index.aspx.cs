using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Video;

namespace Heavenskincare.WebsiteTemplate.Video
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetVideoReference()
        {
            Library.BOL.Video.Video video = Library.BOL.Video.Videos.Get(GetFormValue("ID", 1));

            string Result = "vxtMu8irCKg";

            if (video != null)
                Result = video.VideoReference;

            int widthMax = 640;
            int heightMax = 390;

            if (GetUserSession().MobileRedirect)
            {
                widthMax = 300;
                heightMax = 170;
            }
            Result = String.Format("<iframe width=\"{1}\" height=\"{2}\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\"></iframe>", Result, widthMax, heightMax);

            return (Result);
        }

        protected string GetVideoList()
        {
            string Result = "";

            Library.BOL.Video.Videos videos = Library.BOL.Video.Videos.Get();

            foreach (Library.BOL.Video.Video video in videos)
            {
                Result += String.Format("<li><a href=\"/Video/Index.aspx?ID={0}\"><img src=\"https://img.youtube.com/vi/{2}/1.jpg\" alt=\"\" border=\"0\" width=\"178\" height=\"128\"/>" + 
                    "<span class=\"new\" ></span><span class=\"best\" ></span><br />{1}</a></li>\r\n", video.ID, video.Description, video.VideoReference);
            }

            return (Result);
        }
    }
}