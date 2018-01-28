using System;
using System.Web.UI;

using Website.Library.Classes;
using Library.BOL.Users;

using webLib = Website.Library;

namespace SieraDelta.Website
{
    public partial class SiteStaffMaster : BaseMasterClassWebForm
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Global.UseHTTPS && !Request.IsLocal && Request.Url.ToString().ToLower().StartsWith("http://"))
            {
                Response.Redirect(Request.Url.ToString().Replace("http://", "https://"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string BaseURL()
        {
            return (webLib.GlobalClass.RootURL);
        }

        protected string GetMenuItems()
        {
            string Result = "";

            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.CreateNewProducts))
            {
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/Products/Index.aspx\">Products</a></li>";
            }
              
            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ManageHashTags))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/TagLines/Index.aspx\">Tag Lines</a></li>";

            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ManageFAQs))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/FAQ/Index.aspx\">Frequently Asked Questions</a></li>";

            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.MetaData))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/MetaData/Index.aspx\">Meta Data</a></li>";

            //Result = "<li><a href=\"/Staff/Admin/Index.aspx\">Administration</a></li><div class=\"menu\"><div><ul>";


            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ManageCustomPages))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/CustomPages.aspx\">Custom Pages</a></li>";

            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.AlterWebsiteOptions))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/Options.aspx\">Website Options</a></li>";

            if (GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.StaticHomePageBanners))
                Result += "<li class=\"staffSubMenu\"><a href=\"/Staff/Admin/StaticBanners.aspx\">Homepage Banners</a></li>";


            if (String.IsNullOrEmpty(Result))
                Result = "Not enough Priviledges.";

            return (Result);
        }

        protected string GetUserName()
        {
            string Result = "";

            User currentUser = GetUser();

            if (currentUser != null)
                Result = currentUser.UserName;

            return (Result);
        }

    }
}
