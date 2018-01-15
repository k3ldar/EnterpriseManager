using System;
using System.Collections.Generic;

using lib = Library;
using Library.BOL.Users;
using Library.BOL.Helpdesk;

using Shared.Classes;

namespace Website.Library.Classes
{
    /// <summary>
    /// Base Web Form for Members who need to be logged in.
    /// </summary>
    public class BaseWebFormMember : BaseWebForm
	{
		public BaseWebFormMember()
		{

		}

		protected override void OnLoad(EventArgs e)
		{
			if (!UserIsLoggedOn())
				DoRedirect();

			base.OnLoad(e);
		}

        /// <summary>
        /// Returns the count of support tickets for the current user
        /// </summary>
        /// <returns>int - number of support tickets</returns>
        protected int SupportTicketCount()
        {
            return (SupportTickets.Get(GetUser()).Count);
        }

        /// <summary>
        /// Returns all account options that the user has access to
        /// </summary>
        /// <returns></returns>
        protected virtual string GetAccountOptionsHome()
        {
            string Result = String.Format("<li class=\"email\"><a href=\"/Account/Details/\">{0}</a></li>", Languages.LanguageStrings.MyMemberDetails);
            Result += String.Format("<li class=\"password\"><a href=\"/Account/Password/\">{0}</a></li>", Languages.LanguageStrings.MyPassword);
            Result += String.Format("<li class=\"billing\"><a href=\"/Account/Address/Billing/\">{0}</a></li>", Languages.LanguageStrings.MyBillingAddress);
            Result += String.Format("<li class=\"delivery\"><a href=\"/Account/Address/Delivery/\">{0}</a></li>", Languages.LanguageStrings.MyDeliveryAddresses);
            Result += String.Format("<li class=\"offers\"><a href=\"/Account/Special-Offers/\">{0}</a></li>", Languages.LanguageStrings.MySpecialOffers);

            if (BaseWebApplication.AllowLicences)
            {
                Result += String.Format("<li class=\"licences\"><a href=\"/Account/Licences/\">{0}</a></li>", Languages.LanguageStrings.MyLicences);
            }

            if (BaseWebApplication.AllowCreditCards)
            {
                Result += String.Format("<li class=\"creditcards\"><a href=\"/Account/Card/\">{0}</a></li>", Languages.LanguageStrings.MyCreditCard);
            }

            Result += String.Format("<li class=\"orders\"><a href=\"/Account/Orders/\">{0}</a></li>", Languages.LanguageStrings.MyOrders);
            Result += String.Format("<li class=\"invoices\"><a href=\"/Account/Invoices/\">{0}</a></li>", Languages.LanguageStrings.MyInvoices);
            Result += String.Format("<li class=\"tickets\"><a href=\"/Account/Help-Desk/Tickets/\">{0}</a></li>", Languages.LanguageStrings.MySupportTickets);

            if (BaseWebApplication.AllowCreditCards && BaseWebApplication.ShowAppointments)
            {
                Result += String.Format("<li class=\"appointments\"><a href=\"/Account/Appointments/\">{0}</a></li>", Languages.LanguageStrings.MyAppointments);
            }

            User user = GetUser();

            if (user != null)
            {
                //Salon owners
                if (user.MemberLevel >= lib.MemberLevel.Distributor)
                {
                    if (BaseWebApplication.ShowSalonUpdate)
                        Result += String.Format("<li class=\"salons\"><a href=\"/Account/Distributor/Outlet/\">{0}</a></li>", Languages.LanguageStrings.MySalons);

                    if (BaseWebApplication.ShowTradeDownloads)
                        Result += String.Format("<li class=\"tradeDownload\"><a href=\"/Members/TradeDownloads.aspx\">{0}</a></li>", Languages.LanguageStrings.TradeDownloads);
                }

                if (user.MemberLevel >= lib.MemberLevel.StaffMember)
                {
                    Result += String.Format("<li class=\"statistics\"><a href=\"/staff/statistics/index.aspx\">{0}</a></li>", Languages.LanguageStrings.Statistics);
                }
            }

            return (Result);
        }

        protected virtual string GetAccountOptions()
        {
            string Result = String.Format("<li {0}><a href=\"/Account/Details/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Details/") ? "class=\"current\"" : "",
                Languages.LanguageStrings.MyMemberDetails);

            Result += String.Format("<li {0}><a href=\"/Account/Password/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Password/") ? "class=\"current\"" : "",
                Languages.LanguageStrings.MyPassword);
            
            Result += String.Format("<li {0}><a href=\"/Account/Address/Billing/\">{1}</a></li>", 
                Request.Path.Contains("Account/Address/Billing/") ? "class=\"current\"" : "", 
                Languages.LanguageStrings.MyBillingAddress);
            
            Result += String.Format("<li {0}><a href=\"/Account/Address/Delivery/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Address/Delivery/") ? "class=\"current\"" : "", 
                Languages.LanguageStrings.MyDeliveryAddresses);

            Result += String.Format("<li {0}><a href=\"/Account/Special-Offers/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Special-Offers/") ? "class=\"current\"" : "",
                Languages.LanguageStrings.MySpecialOffers);

            if (BaseWebApplication.AllowLicences)
            {
                Result += String.Format("<li {0}><a href=\"/Account/Licences/\">{1}</a></li>",
                    Request.Path.Contains("/Account/Licences/") ? "class=\"current\"" : "",
                    Languages.LanguageStrings.MyLicences);
            }

            if (BaseWebApplication.AllowCreditCards)
            {
                Result += String.Format("<li {0}><a href=\"/Account/Card/\">{1}</a></li>",
                    Request.Path.Contains("/Account/Card/") ? "class=\"current\"" : "",
                    Languages.LanguageStrings.MyCreditCard);
            }

            Result += String.Format("<li {0}><a href=\"/Account/Orders/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Orders/") ? "class=\"current\"" : "", 
                Languages.LanguageStrings.MyOrders);

            Result += String.Format("<li {0}><a href=\"/Account/Invoices/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Invoices/") ? "class=\"current\"" : "", 
                Languages.LanguageStrings.MyInvoices);

            if (BaseWebApplication.AllowCreditCards && BaseWebApplication.ShowAppointments)
            {
                Result += String.Format("<li {0}><a href=\"/Account/Appointments/\">{1}</a></li>",
                    Request.Path.Contains("/Account/Appointments/") ? "class=\"current\"" : "",
                    Languages.LanguageStrings.MySalonAppointments);
            }

            Result += String.Format("<li {0}><a href=\"/Account/Help-Desk/Tickets/\">{1}</a></li>",
                Request.Path.Contains("/Account/Help-Desk/Tickets/") ? "class=\"current\"" : "",
                Languages.LanguageStrings.MySupportTickets);

            User user = GetUser();

            if (user != null)
            {
                //Salon owners
                if (user.MemberLevel >= lib.MemberLevel.Distributor)
                {
                    if (BaseWebApplication.ShowSalonUpdate)
                        Result += String.Format("<li {0}><a href=\"/Account/Distributor/Outlet/\">{1}</a></li>", 
                            Request.Path.Contains("/Account/Distributor/Outlet/") ? "class=\"current\"" : "",
                            Languages.LanguageStrings.MySalons);

                    if (BaseWebApplication.ShowTradeDownloads)
                        Result += String.Format("<li {0}><a href=\"/Members/TradeDownloads.aspx\">{1}</a></li>", 
                            Request.Path.Contains("/TradeDownloads.aspx") ? "class=\"current\"" : "",
                            Languages.LanguageStrings.TradeDownloads);
                }

                if (user.MemberLevel >= lib.MemberLevel.StaffMember)
                {
                    Result += String.Format("<li><a href=\"/Account/System/Hooks/\">{0}</a></li>",
                        Languages.LanguageStrings.SystemHooks);
                    Result += String.Format("<li><a href=\"/staff/index.aspx\">{0}</a></li>",
                        Languages.LanguageStrings.StaffHomePage);
                    //Result += "<li><a href=\"/staff/Diary.aspx\">my diary</a></li>";
                }

                //admin only
                if (user.MemberLevel >= lib.MemberLevel.AdminReadOnly)
                {
                    Result += String.Format("<li {0}><a href=\"/staff/Statistics/Index.aspx\">{1}</a></li>", 
                        Request.Path.Contains("/Statistics/Index.aspx") ? "class=\"current\"" : "",
                        Languages.LanguageStrings.Administration);
                }
            }


            Result += String.Format("<li {0}><a href=\"/Account/Logout/\">{1}</a></li>", 
                Request.Path.Contains("/Account/Logout/") ? "class=\"current\"" : "", 
                Languages.LanguageStrings.Logout);

            return (Result);
        }

        protected string GetSessionData()
        {
            string Result = String.Empty;

            string ReferringPages = String.Empty;

            List<UserSession> _sessions = UserSessionManager.Clone;


            foreach (UserSession session in _sessions)
            {
                string pages = String.Empty;
                int totalSeconds = 0;

                if (!String.IsNullOrEmpty(session.InitialReferrer))
                    ReferringPages += String.Format("{0}<br />", session.InitialReferrer);

                foreach (PageViewData page in session.Pages)
                {
                    pages += String.Format("{2} {0}s - {1}<br />", 
                        ((int)page.TotalTime.TotalSeconds).ToString(), page.URL, page.TimeStamp);

                    totalSeconds += (int)page.TotalTime.TotalSeconds;
                }

                pages += String.Format("Total Time Browsing: {0}s", totalSeconds);

                string userDetails = String.Empty;
                TimeSpan spanAge = DateTime.Now - session.Created;

                if (!String.IsNullOrEmpty(session.UserName))
                {
                    userDetails = String.Format("Session Started: {2}<br />Session Age: {3}<br />Visitor Name: {0}<br />Visitor Email: {1}<br />", 
                        session.UserName, session.UserEmail, session.Created.ToString("g"), spanAge.ToString());
                }
                else
                {
                    userDetails = String.Format("Session Started: {0}<br />Session Age: {1}<br />",
                        session.Created.ToString("g"), spanAge.ToString());
                }

                string sessionData = String.Format("<h2>Session ID: {0}</h2><p>{10}IP Address: {1}<br />Is Bot: {2}<br />Is Mobile: {3}<br />Browser Mobile: {15}<br />" +
                    "Referral Type: {4}<br />Bounced: {5}<br />Country: {6}<br />City: {7}<br />Initial Referer: {8}<br />Mobile Manufacturer: {11}" +
                    "<br />Mobile Model: {12}<br />Screen Width: {13}<br />Screen Height: {14}</p><h3>Pages Visited</h3><p>{9}</p>",
                    session.SessionID, session.IPAddress, session.IsBot ? "Yes" : "No",
                    session.IsMobileDevice ? "Yes" : "No", session.Referal.ToString(),
                    session.Bounced ? "Yes" : "No", session.CountryCode, session.CityName,
                    session.InitialReferrer, pages, userDetails, session.MobileManufacturer,
                    session.MobileModel, session.ScreenWidth, session.ScreenHeight,
                    session.IsBrowserMobile ? "Yes" : "No");
                Result += sessionData;
            }

            Result = String.Format("<h2>Referring Pages</h2><p>{0}</p>{1}", ReferringPages, Result);
            return (Result);
        }

	}
}
