﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Products;
using Shared.Classes;

namespace SieraDelta.Website.Controls
{
    public partial class MayAlsoLike : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetScrollCount()
        {
            UserSession session = GetUserSession();

            if (session.IsMobileDevice)
                return ("1");
            else
                return ("3");
        }
    }
}