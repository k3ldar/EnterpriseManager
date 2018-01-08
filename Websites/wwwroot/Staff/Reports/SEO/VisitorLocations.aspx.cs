using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.BOL.Statistics;
using Shared.Classes;

namespace SieraDelta.Website.Reports
{
    public partial class VisitorLocations : BaseWebFormStaff
    {
        private decimal _age = 0.014m;
        private List<UserSession> _sessions;

        protected void Page_Load(object sender, EventArgs e)
        {
            _sessions = UserSessionManager.Clone;
            _age = GetFormValue("age", 0.014m);
        }

        protected string GetLocations()
        {
            string Result = String.Empty;

            foreach (UserSession session in UserSessionManager.Clone)
            {
                string image = GetImageName(session);

                Result += String.Format("['{0}\\rUser: {3}\\rConverted: {4}\\rMobile: {5}\\rReferrer: {6}\\rCountry: {9}\\rCity: {10}\\rTotal Pages: {11}\\rTotal Time: {12} (s)', {1}, {2}, {7}, {8}, {13}, '{14}'],",
                    session.IPAddress,
                    session.Latitude,
                    session.Longitude,
                    String.IsNullOrEmpty(session.UserName) ? "Unknown" : session.UserName,
                    session.CurrentSale > 0.00m ? "Yes" : "No",
                    session.IsMobileDevice ? "Yes" : "No",
                    session.Referal.ToString(),
                    session.IsBot ? 1 : 2, // 7 bot
                    session.CurrentSale > 0.00m ? 1 : 2, // 8 sale
                    session.CountryCode,
                    session.CityName,
                    session.Pages.Count,
                    session.TotalTime,
                    session.Bounced ? 1 : 2,
                    image // name of image
                    );
            }

            if (Result.EndsWith(","))
                Result = Result.Substring(0, Result.Length - 1);

            return (Result);
        }

        private string GetImageName(UserSession session)
        {
            if (session.IsBot)
                return ("orange");

            if (session.Bounced)
                return ("yellow");

            if (session.CurrentSale > 0.00m)
            {
                if (session.IsMobileDevice)
                    return ("grn-pushpin");
                else
                    return ("blue-pushpin");
            }

            if (!String.IsNullOrEmpty(session.UserEmail))
            {
                if (session.IsMobileDevice)
                    return ("green-dot");
                else
                    return ("green");
            }

            return ("blue");
        }
    }
}