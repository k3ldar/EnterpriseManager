using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Website.Library.Classes;

namespace SieraDelta.Website.Services
{
    public partial class CustomWebsites : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Services;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Services"));
        }
    }
}