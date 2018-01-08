using System;
using System.Threading;
using System.Web;
using System.Web.Routing;
using Website.Library.Classes;

using Website.Library;
using Shared.Classes;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

using webLib = Website.Library.Classes;

namespace SieraDelta.Website
{
    #region Class Global

    /// <summary>
    /// Summary description for Global.
    /// </summary>
    public class Global : BaseWebApplication
	{
        #region Constructors/Destructors

        /// <summary>
		/// Required designer variable.
		/// </summary>
		public Global()
		{
			InitializeComponent();
		}	
		


		#endregion Constructors/Destructors

        #region Overridden Methods

        public override void SessionClosed(Shared.Classes.UserSession session)
        {
            Library.BOL.SEO.SeoData.SEOSaveSession(session);
        }

        public override UserSession SessionRetrieve(string sessionID)
        {
            return (Library.BOL.SEO.SeoData.SeoSessionGet(sessionID));
        }

        public override void SessionSaveData(Shared.Classes.UserSession session)
        {
            Library.BOL.SEO.SeoData.SEOSaveSession(session);
        }

        public override void LoadCustomSettings()
        {
            LocalizedLanguages.Active = true;
            StaticWebSite = false;
            Global.AllowWebsiteGeoUpdate = true;
            AllowCreditCards = true;
            ShowSalonUpdate = false;
            ShowAppointments = false;
            ShowTradeDownloads = false;
            AllowLicences = true;

            GlobalClass.Address = String.Format("{0} {1} {2}",
                webLib.BaseWebApplication.AddressLine1,
                webLib.BaseWebApplication.AddressLine2,
                webLib.BaseWebApplication.AddressLine3);

            Library.DAL.DALHelper.SetCacheLimit(new TimeSpan(24, 0, 0));
            GlobalClass.InternalCache.MaximumAge = Library.DAL.DALHelper.CacheLimit;
            GlobalClass.StyleSheet = "Style.css";
            AllowMobileWebsite = true;

            Shared.Classes.ThreadManager.ThreadStart(new ReloadBannedIPAddresses(), "Banned IP Addresses", ThreadPriority.Lowest);
        }

        #endregion Overridden Methods

        #region Private Methods

        void ErrorHandling_InternalException(object sender, Library.BOLEvents.InternalErrorEventArgs e)
        {
            string msg = String.Empty;

            try
            {
                msg = String.Format("Internal Exception in Website - {5}\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}",
                    e.Method, e.Source, e.Parameters, e.CallStack, e.Message, DistributorWebsite);
#if ERROR_MANAGER
                if (!ErrorClient.GetErrorClient.SendError(
                    new ErrorManager.ErrorClient.Options("em.SieraDelta.com", 37789, "SieraDelta", "Heaven_!3B"),
                    msg))
                {
                    //Failed to send error details to server
                    Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                        msg, Global.SupportName, Global.SupportEMail);
                }
#else
                Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                    msg, Global.SupportName, Global.SupportEMail);
#endif
            }
            catch (Exception err)
            {
                msg += String.Format("\r\n\r\n{0}", err.Message);
                Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                    msg, Global.SupportName, Global.SupportEMail);
            }
        }


        #endregion Private Methods

        #region WebAppEvents

        protected void Application_Start(Object sender, EventArgs e)
		{
            ApplicationStart();

            WebChart.ChartControl.PhysicalPath = Global.Path + @"Admin\Reports\WebChartGraphs\";
            WebChart.ChartControl.VirtualPath = Global.RootURL + @"/Admin/Reports/WebChartGraphs/";

            Library.ErrorHandling.InternalException += ErrorHandling_InternalException;
        }

        protected void Session_Start(Object sender, EventArgs e)
		{
            // add a test cookie to see if cookies are enabled.
            SharedWebBase.CookieSetValue(Request, Response, "SIERADELTA_TEST_COOKIE", "CookiesEnabled", DateTime.Now, true);

            SharedWebBase.StartUserSession(Session, Request, Response);
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

            if (Global.MaintenanceMode)
            {
                if (SharedWebBase.CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_BYPASS_MAINTENANCE, BaseWebApplication.DistributorWebsite),
                    "notfound") == "notfound")
                {
                    string email = (string)Request["user"];
                    string password = (string)Request["password"];

                    Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(email, password);

                    if (user == null || user.MemberLevel < Library.MemberLevel.StaffMember)
                    {
                        Response.Redirect("/maintenance.htm", true);
                        Response.End();
                    }
                    else
                    {
                        SharedWebBase.CookieSetValue(Request, Response,
                            String.Format(StringConstants.COOKIE_BYPASS_MAINTENANCE, BaseWebApplication.DistributorWebsite),
                            "yes", DateTime.Now.AddDays(10));
                    }
                }
            }

            if (Request.Path.ToLower().IndexOf("get_aspx_ver.aspx") >= 0)
                Response.End();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			try
			{
                HttpException ex = Server.GetLastError() as HttpException;

                // if 404 error check if we can redirect the user
                if (ex != null && ex.GetHttpCode() == 404)
                {
                    //should we autoban some users depending what they are searching for?
                    if (AutoBanIPAddress(Request.Path, Request.UserHostAddress))
                    {
                        Response.Redirect(String.Format("{0}/Error/IPIsBanned.aspx", Global.RootURL), true);
                        return;
                    }

                    string file = ex.Message;
                    file = CanRedirect(file);

                    if (file != "")
                    {
                        // a file to redirect to has been found, redirect and exit the procedure
                        Response.Redirect(file, true);
                        return;
                    }
                }

                SharedWebBase.HandleException(Server.GetLastError(), ex.GetHttpCode());
			}
			catch (Exception error)
			{
				string Msg = String.Format("<P>Error Message: {0}</P>" +
					"<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
					"<P>StackTrace: {3}</P><P>Target Site: {4}</P>", 
					error.Message, error.InnerException == null ? "" : error.InnerException.ToString(), 
					error.Source, error.StackTrace, error.TargetSite.ToString());

                Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
					Msg, Global.SupportName, Global.SupportEMail);
			}
		}

		protected void Session_End(Object sender, EventArgs e)
		{
            
		}

		protected void Application_End(Object sender, EventArgs e)
		{
            //finalise web hack validation
            ApplicationEnd();
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
        }

		#endregion

		#endregion WebAppEvents
	}

	#endregion Class Global

    #region Banned IP Load Thread

    internal sealed class ReloadBannedIPAddresses : Shared.Classes.ThreadManager
    {
        #region Constructors

        internal ReloadBannedIPAddresses()
            : base(null, new TimeSpan(1, 0, 0))
        {
            ContinueIfGlobalException = true;
        }

        protected override bool Run(object parameters)
        {
            //Library.BOL.Statistics.SimpleStatistics locations = Library.BOL.Statistics.Statistics.CurrentyBanned();

            //foreach (Library.BOL.Statistics.SimpleStatistic stat in locations)
            //{
            //    Library.BOL.IPAddresses.IPCity city = Library.BOL.IPAddresses.IPCity.Get(stat.StringValue1, stat.StringValue1);
            //}

            return (true);
        }

        #endregion Constructors
    }

    #endregion Banned IP Load Thread
}

