using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Users;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Website.Staff.Admin
{
    public partial class WebManualUpdates : BaseWebForm
    {
        private static DateTime _lastUpdated = DateTime.Now.AddDays(-1);

        protected override void OnLoad(EventArgs e)
        {
            TimeSpan span = DateTime.Now - _lastUpdated;

            if (GetFormValue("ClearCache", false))
            {
                string user = GetFormValue("User", String.Empty);

                User staff = Library.BOL.Users.User.UserGet(user);

                if (staff != null && staff.MemberLevel >= Library.MemberLevel.StaffMember)
                {
                    if (GetFormValue("Password", String.Empty) == staff.Password)
                    {
                        Shared.Classes.CacheManager.ClearAllCaches();
                        SharedWebBase.ResetWebTitleCache();
                        Response.Write("All caches cleared");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("Invalid Password");
                        Response.End();
                    }
                }

                Response.Write("Invalid Clear Cache settings.");
                Response.End();
            }

            if (span.TotalMinutes > 20)
            {
                Classes.RoutineMaintenance.RoutineMaintenance rm = new Classes.RoutineMaintenance.RoutineMaintenance();
                try
                {
                    rm.Run();
                    _lastUpdated = DateTime.Now;
                    Response.Write("Images Updated");
                }
                finally
                {
                    rm = null;
                }
            }
            else
            {
                Response.Write("Images Not Updated");
            }

            Response.End();
        }

    }
}