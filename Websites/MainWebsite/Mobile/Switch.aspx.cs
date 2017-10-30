﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class Switch : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool goMobile = GetFormValue("m", false);
                string returnPath = GetFormValue("l", "/Index.aspx");

                UserSession session = GetUserSession();

                if (session.MobileRedirect && goMobile)
                {
                    DoRedirect(returnPath, true);
                }

                if (session.IsMobileDevice)
                {
                    session.MobileRedirect = goMobile;
                    DoRedirect(returnPath, true);
                }
                else
                {
                    DoRedirect(returnPath, true);
                }
            }
            catch
            {
                DoRedirect("/Index.aspx");
            }
        }
    }
}