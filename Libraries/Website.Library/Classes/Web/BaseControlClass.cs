using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Campaigns;
using Library.BOL.Websites;

using lib = Library;
using Library.Utils;
using Shared.Classes;

namespace Website.Library.Classes
{
    /// <summary>
    /// Summary description for BaseControlClass.
    /// </summary>
    public class BaseControlClass : System.Web.UI.UserControl
	{
		#region Private / Protected Members

        private static lib.WebsiteAdministration _Administration;
        private static lib.LibraryHelperClass _Web;
        private bool _IPIsBanned = false;
		private int _BanType = 0;

		#endregion Private / Protected Members

		#region Constructors

		public BaseControlClass()
		{

        }

		#endregion Constructors
		
		#region Overridden Functions

        protected bool TreatAsStratosphereProduct(ProductType primaryProductType)
        {
            bool Result = false;

            switch (primaryProductType.Description)
            {
                case "Stratosphere":
                case "MensHeaven":
                    Result = true;
                    break;
            }

            return (Result);
        }

		#endregion Overridden Functions

        /// <summary>
        /// Get's the current user session
        /// </summary>
        /// <returns>UserSession instance for current users session</returns>
        protected UserSession GetUserSession()
        {
            return ((UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION]);
        }

        /// <summary>
        /// Base url of website
        /// </summary>
        /// <returns></returns>
        protected string BaseURL()
        {
            return (WebsiteSettings.RootURL);
        }

        /// <summary>
        /// Gets the website currency, currently being used by the active user
        /// </summary>
        /// <returns></returns>
        protected Currency GetWebsiteCurrency()
        {
            return (SharedWebBase.WebsiteCurrency(Session, Request));
        }

        protected string GetCarouselProducts(
            bool ShowPrices = true, bool ShowNew = true, bool ShowBest = true, 
            bool Clickable = true, string FormattingOptions = "")
        {
            string Result = String.Empty;

            Result = GetCarouselProducts(Clickable);

            return (Result);
        }

        [Obsolete("do not use!!!")]
        private string GetCarouselProductsStratosphere(bool ShowPrices, bool ShowNew, bool ShowBest, bool Clickable, string FormattingOptions)
        {
            string Result = "";
            lib.BOL.Products.Products carousel = lib.BOL.Products.Products.GetCarousel();
                
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in carousel)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = LibUtils.ResizeImage(image, 200);

                if (Clickable)
                    Result += String.Format("<li>\r<a href=\"/Products/Stratosphere.aspx?ID={0}\">\r", product.ID);
                else
                    Result += "<li>\r";

                Result += String.Format("<img src=\"/Images/Products/{0}\" alt=\"I\" border=\"0\" width=\"200\" height=\"145\"/>\r", image);

                if (ShowNew && product.NewProduct)
                    Result += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r", Languages.LanguageStrings.NewProduct);
                //else
                //    Result += "<span class=\"new\">new product</span>\r";

                if (ShowBest && !product.NewProduct && product.BestSeller)
                    Result += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r", Languages.LanguageStrings.BestSeller);
                //else
                //    Result += "<span class=\"best\">best seller</span>\r";

                if (ShowPriceData && ShowPrices)
                    Result += String.Format("<div class=\"textDirection\" style=\"padding: 48px 20px 8px 20px; {3}\">{0}<strong>{2} {1}</strong></div>\r</a>\r</li>\r", 
                        product.Name,
                        SharedUtils.FormatMoney(product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry), GetWebsiteCurrency()),
                        Languages.LanguageStrings.From, FormattingOptions);
                else
                    Result += String.Format("<div class=\"textDirection\" style=\"padding: 48px 20px 8px 20px; {1} \">{0}</div>\r</a>\r</li>\r", 
                        product.Name,
                        FormattingOptions);
            }

            return (Result);
        }

        private string GetCarouselProducts(bool Clickable)
        {
            string currency = String.Format("CAROUSEL BY CURRENCY {0}", GetWebsiteCurrency().CurrencyCode);

            CacheItem item = GlobalClass.InternalCache.Get(currency);

            if (item != null)
                return ((string)item.Value);

            string Result = String.Empty;
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            // if we get this far then the carousel hasn't been built for the currency
            lib.BOL.Products.Products carousel = lib.BOL.Products.Products.GetCarousel();

            foreach (Product product in carousel)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = LibUtils.ResizeImage(image, 200);

                if (Clickable)
                    Result += String.Format("<li>\r<a href=\"/All-Products/Group/{0}/{1}/\">\r", 
                        product.PrimaryGroup.SEODescripton, product.NameSEO);
                else
                    Result += "<li>\r";

                Result += String.Format("<img src=\"/Images/Products/{0}\" " +
                    "alt=\"I\" style=\"border: 0;\" width=\"200\" height=\"145\"/>\r", image);

                if (product.NewProduct)
                    Result += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r", 
                        Languages.LanguageStrings.NewProduct);

                if (!product.NewProduct && product.BestSeller)
                    Result += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r", 
                        Languages.LanguageStrings.BestSeller);

                if (ShowPriceData)
                {
                    decimal cost = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                    if (WebsiteSettings.Tax.PricesIncludeVAT)
                    {
                        cost += SharedUtils.VATCalculate(cost, WebVATRate);
                    }

                    Result += String.Format("<br /><div class=\"textDirection\">{0}<strong>{2} {1}</strong></div>\r</a>\r</li>\r", product.Name,
                        SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        Languages.LanguageStrings.From);
                }
                else
                {
                    Result += String.Format("<br /><div class=\"textDirection\">{0}</div>\r</a>\r</li>\r", product.Name);
                }
            }

            item = new CacheItem(currency, Result);
            GlobalClass.InternalCache.Add(currency, item);

            return (Result);
        }

        protected string GetProductCategories()
        {
            string Result = "";

            User user = GetUser();
            ProductGroups groups = ProductGroups.Get(user == null ? lib.MemberLevel.StandardUser : user.MemberLevel, true);

            foreach (ProductGroup group in groups)
            {
                if (String.IsNullOrEmpty(group.URL))
                {
                    Result += String.Format("<li><a href=\"/All-Products/Group/{0}/\">{1}</a></li>\r\n", 
                        group.SEODescripton, group.Description);
                }
                else
                {
                    Result += String.Format("<li><a href=\"{0}\">{1}</a></li>\r\n", 
                        group.URL, group.Description);
                }
            }

            return (Result);
        }

        protected string BasketInfo()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ShoppingBasket basket = localData.Basket;
            decimal Cost = 0.00m;

            if (basket.HasItems())
                Cost = basket.TotalAmount;

            string Result = String.Format("{2}: {0} <strong>{1}</strong>", basket.Items.Count,
                SharedUtils.FormatMoney(Cost, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.Items);

            return (Result);
        }


        protected ShoppingBasket GetBasket()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.Basket);
        }

        /// <summary>
        /// Retrurns the active promotional offers
        /// </summary>
        /// <returns></returns>
        protected string GetPromotionalOffer()
        {
            string Result = "";

            Campaigns currentCampaigns = Campaign.GetActive(lib.BOL.Countries.Countries.Get(GetUserCountry()));

            foreach (Campaign currentCampaign in currentCampaigns)
            {
                if (currentCampaign != null)
                {
                    if (!String.IsNullOrEmpty(currentCampaign.ImageLeftMenu))
                        Result += String.Format("<a href=\"{2}{3}cmp={1}\"><img src=\"{0}\" border=\"0\" alt=\"\" /></a><br /><br /><br />",
                            currentCampaign.ImageLeftMenu, currentCampaign.CampaignName, currentCampaign.WebLink, currentCampaign.WebLink.Contains("?") ? "&" : "?");
                }
            }

            if (!Request.IsLocal && Request.IsSecureConnection)
                Result = Result.ToLower().Replace("http://", "https://");

            return (Result);
        }

        /// <summary>
        /// The telephone number used by the website
        /// </summary>
        /// <returns></returns>
        protected string GetWebsiteTelephoneNumber()
        {
            return (WebsiteSettings.ContactDetails.WebsiteTelephoneNumber);
        }

        /// <summary>
        /// Date format used by the website
        /// </summary>
        /// <returns></returns>
        protected string GetWebsiteDateFormat()
        {
            return (WebsiteSettings.WebsiteDateFormat);
        }

        protected string GetExtraBasketInformation()
        {
            //<p>Please note, due to unprecedented demand there is currently a 21 day delay in the dispatch of orders.</p>
            return (String.Empty);
        }

        protected string GetWebsiteAddress()
        {
            return (WebsiteSettings.RootURL);
        }

        protected string GetUserCountry()
        {
            string Result;
            string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                ipAddress = GetFormValue("FakeAddress", ipAddress);
#endif

            if (!UserIsLoggedOn())
            {
                Result = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
            }
            else
            {
                User user = GetUser();

                if (user == null)
                {
                    Result = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
                }
                else
                {
                    if (user.Country == null)
                        Result = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
                    else
                        Result = GetUser().Country.CountryCode;
                }
            }

            return (Result);
        }

        protected Country GetCountry()
        {
            Country Result;

            if (!UserIsLoggedOn())
            {
                string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                ipAddress = GetFormValue("FakeAddress", ipAddress);
#endif

                Result = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(ipAddress));
            }
            else
                Result = GetUser().Country;

            if (Result == null)
                Result = Countries.Get("ZZ");

            return (Result);
        }

        #region Properties

        public bool ShowPriceData
        {
            get
            {
                string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                    ipAddress = GetFormValue("FakeAddress", ipAddress);
#endif

                Country country = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(ipAddress));

                if (country != null)
                    return (country.ShowPriceData());
                else
                    return (WebsiteSettings.ShoppingCart.DefaultShowPrices);
            }
        }

        public Country WebCountry
        {
            get
            {
                return (SharedWebBase.WebCountry(Session, Request));
            }
        }

        protected decimal WebConversionRate
        {
            get
            {
                decimal Result = 1.0m;

                Currency currency = SharedWebBase.WebsiteCurrency(Session, Request);

                if (currency != null)
                {
                    Result = currency.ConversionRate;
                }

                return (Result);
            }
        }


        public lib.LibraryHelperClass Web
        {
            get
            {
                if (_Web == null)
                    _Web = new lib.LibraryHelperClass();

                return (_Web);
            }
        }

        public lib.WebsiteAdministration WebAdmin
        {
            get
            {
                if (_Administration == null)
                    _Administration = new lib.WebsiteAdministration(GetUser());

                return (_Administration);
            }
        }
        
        public double WebVATRate
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (localData.VATRate);
            }
        }

        public CultureInfo WebCulture
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (new CultureInfo(localData.Culture));
            }
        }

        public string CountryCode
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (localData.CountryCode);
            }
        }


        #endregion Properties

        #region Cookie management

		protected string CookieGetValue(string CookieName, string Default)
		{
            return (SharedWebBase.CookieGetValue(Request, Response, CookieName, Default));
		}


		#endregion Cookie management

		#region Virtual Methods

		protected virtual void Localize()
		{
		}


		#endregion Virtual Methods
		
		#region Protected Functions

        protected User GetUser()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser);
        }

        protected void ValidateDetails(string s, int MinLength, string Field)
        {
            if (s == null || s == String.Empty)
            {
                if (MinLength == 0)
                    throw (new System.Exception(String.Format("{0} is a mandatory field.", Field)));
                else
                {
                    if (s.Length < MinLength)
                    {
                        throw (new System.Exception(String.Format("{0} is a mandatory field and should " +
                            "be at least {1} characters long.", Field, MinLength)));
                    }
                }
            }
            else
            {
                if (MinLength == 0 && s.Length == 0)
                    throw (new System.Exception(String.Format("{0} is a mandatory field.", Field)));
                else
                {
                    if (s.Length < MinLength)
                    {
                        throw (new System.Exception(String.Format("{0} is a mandatory field and should " +
                            "be at least {1} characters long.", Field, MinLength)));
                    }
                }

            }
        }

        
        protected string GetLastError()
		{
			string result = "";

			if (Session["LASTERROR"] != null)
				result = (string)Session["LASTERROR"];

			return (result);
		}


		protected void SetErrorMessage()
		{
			string result = "";

			try
			{
				Exception Err = Server.GetLastError();
				string Inner;
				string Message;
				string Source;
				string StackTrace;
				string TargetSite;

				if (Err != null)
				{
					Inner = Err.InnerException.ToString();
					Message = Err.Message;
					Source = Err.Source;
					StackTrace = Err.StackTrace;
					TargetSite = Err.TargetSite.ToString();
				}
				else
				{
					Inner =  "Unknown";
					Message = "Unknown Error";
					Source =  "Unknown";
					StackTrace =  "Unknown";
					TargetSite =  "Unknown";
				}
				result = String.Format("<P>Error Message: {0}</P>" +
					"<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
					"<P>StackTrace: {3}</P><P>Target Site: {4}</P>", 
					Message, Inner, Source, StackTrace, TargetSite);
			}
			catch (Exception error)
			{
				result = String.Format("<P>Error Message: {0}</P>" +
					"<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
					"<P>StackTrace: {3}</P><P>Target Site: {4}</P>", 
					error.Message, error.InnerException.ToString(), 
					error.Source, error.StackTrace, error.TargetSite.ToString());
			}

			Session["LASTERROR"] = result;
		}


		/// <summary>
		/// IPAddressIsBanned
		/// </summary>
		/// <param name="IPAddress">User's IP Address</param>
		/// <param name="BanType">Returns BanType; 0 = Softban (not allowed to input); 1 = Hardban (not allowed access to site)</param>
		/// <returns></returns>
		protected void IPAddressIsBanned(string IPAddress)
		{
            _IPIsBanned = lib.LibraryHelperClass.IPAddressIsBanned(IPAddress, out _BanType);
		}


		protected void DoRedirect(string URL)
		{
			DoRedirect(URL, false);
		}


		protected void DoRedirect(string URL, bool EndResponse)
		{
            Response.Redirect(URL, EndResponse);
		}


		protected long GetUserID()
		{
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            if (localData.CurrentUser == null)
                return (-1);
            else
                return (localData.CurrentUser.ID);
        }


		protected bool UserIsLoggedOn()
		{
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser != null);
		}

		protected int GetUsersMemberLevel()
		{
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.MemberLevel);
        }


        /// <summary>
        /// Ensures the user has correct privileges to continue, throws exception if user level to low.
        /// </summary>
        /// <param name="MinLevel">10 = Admin; 9 = Admin Update; 8 = Admin Read Only</param>
        protected void ValidateMemberLevel(int MinLevel)
        {
            int CurrentLevel = GetUsersMemberLevel();

            if (CurrentLevel < MinLevel)
                throw new Exception(String.Format("You do not have enough privileges to continue {0}/{1}", CurrentLevel, MinLevel));
        }


		protected string GlobalRootURL()
		{
            return (WebsiteSettings.RootURL);
		}

        protected DateTime GetFormValue(string Name, DateTime Default)
        {
            DateTime Result;

            string sDate = GetFormValue(Name, Default.ToString("dd/MM/yyyy"));

            try
            {
                Result = Convert.ToDateTime(sDate);
            }
            catch
            {
                Result = Default;
            }

            return (Result);
        }


		protected string GetFormValue(string Name, string Default)
		{
			if (Request[Name] != null && Request[Name] != String.Empty)
				return (Request[Name]);
			else
				return (Default);
		}


		protected string GetFormValue(string Name)
		{
			return (GetFormValue(Name, String.Empty));
		}


		protected int GetFormValue(string Name, int Default)
		{
			string Value = String.Empty;

			if (Request[Name] != null && Request[Name] != String.Empty)
				Value = Request[Name];
			else
				Value = String.Empty;

			if (Value.IndexOf("#") > 0)
				Value = Value.Substring(0, Value.IndexOf("#"));

            int result = Shared.Utilities.StrToIntDef(Value, Default);

			return (result);
		}


		protected Int64 GetFormValue(string Name, Int64 Default)
		{
			string Value = String.Empty;

			if (Request[Name] != null && Request[Name] != String.Empty)
				Value = Request[Name];
			else
				Value = String.Empty;

			if (Value.IndexOf("#") > 0)
				Value = Value.Substring(0, Value.IndexOf("#"));

            Int64 result = Shared.Utilities.StrToIntDef(Value, Default);

			return (result);
		}


		#endregion Protected Functions

		#region Public Properties
		
		/// <summary>
		/// Gets the status of ban type
		/// </summary>
		public bool IPAddressBanned
		{
			get
			{
				return (_IPIsBanned);
			}
		}
		

		public int IPAddressBanType
		{
			get
			{
				return (_BanType);
			}
		}


		public int MemberLevel
		{
			get
			{
				return (GetUsersMemberLevel());
			}
		}


		#endregion Public Properties

		#region HTML Table wrapper functions

		protected HtmlTable CreateTable(string ClassName, int CellSpacing)
		{
			HtmlTable Result = new HtmlTable();
			Result.Attributes.Add("class", ClassName);
			Result.CellPadding = 0;
			Result.CellSpacing = CellSpacing;
			Result.Border = 0;
			Result.Width = "100%";

			return (Result);
		}


		protected HtmlTableRow CreateRow(HtmlTable Table)
		{
			return (CreateRow(Table, String.Empty, 0));
		}


		protected HtmlTableRow CreateRow(HtmlTable Table, string ClassName)
		{
			return (CreateRow(Table, ClassName, 0));
		}


		protected HtmlTableRow CreateRow(HtmlTable Table, string ClassName, int Height)
		{
			HtmlTableRow Result = new HtmlTableRow();

			if (ClassName != String.Empty)
				Result.Attributes.Add("class", ClassName);

			if (Height != 0)
				Result.Height = Height.ToString();

			Table.Rows.Add(Result);

			return (Result);
		}



		protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, string Text)
		{
			return (CreateCell(Row, ClassName, CellAlign.Left, 0, Text, false));
		}

		protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, string Text, bool IsHTML)
		{
			return (CreateCell(Row, ClassName, CellAlign.Left, 0, Text, IsHTML));
		}

		protected HtmlTableCell CreateCell(HtmlTableRow Row, string Text)
		{
			return (CreateCell(Row, String.Empty, CellAlign.Left, 0, 0, Text, false));
		}


		protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
			int Width, string Text, bool IsHTML)
		{
			return (CreateCell(Row, ClassName, Alignment, Width, 0, Text, IsHTML));
		}


		protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
			int Width, string Text)
		{
			return (CreateCell(Row, ClassName, Alignment, Width, 0, Text, false));
		}


		protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
			int Width, int Height, string Text, bool IsHTML)
		{
			HtmlTableCell Result = new HtmlTableCell();

			if (ClassName != String.Empty)
				Result.Attributes.Add("class", ClassName);

			// alignment
			Result.Align = Alignment.ToString();

			if (Width != 0)
				Result.Width = Width == -1 ? "100%" : Width.ToString();

			if (Height != 0)
				Result.Height = Height.ToString();

			if (IsHTML || Text == String.Empty)
				Result.InnerHtml = Text == String.Empty ? "&nbsp;" : Text;
			else
				Result.InnerText = Text;

			// add the cell to the row
			Row.Cells.Add(Result);

			return (Result);
		}


		#endregion HTML Table wrapper functions

		#region Public Methods

		#endregion Public Methods

		public void FixControl (System.Web.UI.Control ct)
		{
			TextBox tx;
			string sUnitW, sUnitH;
            
			if (ct is TextBox)
			{
				tx =(TextBox)ct;
				if (tx.Attributes["style"] == null)
				{
					if (tx.Height.Value != 0 && tx.Width.Value != 0)
					{
						if (tx.Width.Type == UnitType.Pixel )
							sUnitW = "px";
						else
							sUnitW = "%";
						if (tx.Height.Type == UnitType.Pixel )
							sUnitH ="px";
						else
							sUnitH ="%";
						tx.Attributes.Add ("style",
							string.Format ("WIDTH:{0}{1}; HEIGHT:{2}{3}",
							tx.Width.Value, sUnitW,
							tx.Height.Value, sUnitH));
					}
					else
					{
						if (tx.Height.Value != 0 && tx.Width == 0)
						{
							if (tx.Height.Type == UnitType.Pixel)
								sUnitH = "px";
							else
								sUnitH = "%";    
							tx.Attributes.Add ("style",
								string.Format ("HEIGHT:{0}{1}",
								tx.Height.Value,sUnitH ));
						}
						else
						{
							if(tx.Width.Value != 0 && tx.Height == 0)
							{
								if (tx.Width.Type == UnitType.Pixel)
									sUnitW ="px";
								else
									sUnitW = "%";
								tx.Attributes.Add ("style",
									string.Format ("WIDTH:{0}{1};",
									tx.Width.Value, sUnitW ));
							}
						}
					}
				}
			}
		}
		

	}
}
