using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;

namespace Website.Library.Classes.Web
{
    public class MyCustomController : ControllerBase
    {
        protected override void Execute(RequestContext requestContext)
        {
            // Disable requestion validation (security) across the whole site
            ValidateRequest = false;
            base.Execute(requestContext);
        }

        protected override void ExecuteCore()
        {
            string controllername = ControllerContext.RouteData.Values["controller"].ToString();
            string actionName = ControllerContext.RouteData.Values["action"].ToString();
            this.ControllerContext.HttpContext.Response.Write(
                 string.Format("Controller name - {0}", controllername));
            this.ControllerContext.HttpContext.Response.Write(
                 string.Format("Action name - {0}", actionName));
        }
    }
}
