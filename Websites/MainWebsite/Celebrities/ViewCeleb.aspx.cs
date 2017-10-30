using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Celebrities;

namespace Heavenskincare.WebsiteTemplate.Celebrities
{
    public partial class ViewCeleb : BaseWebForm
    {
        private Celebrity _celebrity;

        protected void Page_Load(object sender, EventArgs e)
        {
            _celebrity = Library.BOL.Celebrities.Celebrities.Get(GetFormValue("ID", -1));

            if (_celebrity == null)
                DoRedirect("/Celebrities/Index.aspx", true);
        }

        protected string GetCelebDescription()
        {
            string Result = HSCUtils.PreProcessPost(_celebrity.Description);
            return (Result);
        }

        protected string GetCelebImage()
        {
            return (_celebrity.Image);
        }

        protected string GetCelebName()
        {
            return (_celebrity.Name);
        }
    }
}