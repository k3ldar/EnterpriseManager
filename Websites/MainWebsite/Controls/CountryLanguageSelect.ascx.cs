using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Website.Library;
using Website.Library.Classes;
using Library;
using Library.DAL;
using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class CountryLanguageSelect : BaseControlClass
    {
        #region Private Members

        private bool _languageSelector = true;

        private bool _currencySelector = true;

        #endregion Private Members

        #region Properties

        /// <summary>
        /// Determines wether the language selector is shown
        /// </summary>
        public bool ShowLanguageSelector
        {
            get
            {
                return (_languageSelector);
            }

            set
            {
                if (!_currencySelector && !value)
                    Visible = false;

                _languageSelector = value;
            }
        }

        /// <summary>
        /// Determines wether the language selector is shown
        /// </summary>
        public bool ShowCurrencySelector
        {
            get
            {
                return (_currencySelector);
            }

            set
            {
                if (!_languageSelector && !value)
                    Visible = false;

                _currencySelector = value;
            }
        }

        public bool ShowFlags { get; set; }

        #endregion Properties

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                divCurrency.Visible = _currencySelector;
                divLanguage.Visible = _languageSelector;

                LoadLanguages();
                LoadCurrencies();
            }

            btnSave.Text = Languages.LanguageStrings.Save;
            btnCancel.Text = Languages.LanguageStrings.Cancel;
        }


        private void LoadLanguages()
        {
            // has it been cached
            CacheItem cachedResult = GlobalClass.InternalCache.Get(Consts.CACHE_NAME_SELECTABLE_LANGUAGE);

            if (cachedResult == null)
            {
                cachedResult = new CacheItem(Consts.CACHE_NAME_SELECTABLE_LANGUAGE, Countries.GetLocalized());
                GlobalClass.InternalCache.Add(Consts.CACHE_NAME_SELECTABLE_LANGUAGE, cachedResult);
            }

            Countries localizedCountries = (Countries)cachedResult.Value;

            string currentCountry = SharedWebBase.WebCountry(Session, Request).CountryCode;




            ddlLanguage.Items.Clear();

            foreach (Country country in localizedCountries)
            {
                ListItem newItem = new ListItem(country.LocalizedLanguage, country.CountryCode);
                ddlLanguage.Items.Add(newItem);

                if (country.CountryCode == currentCountry)
                    ddlLanguage.SelectedIndex = ddlLanguage.Items.Count - 1;
            }
        }

        private void LoadCurrencies()
        {
            CacheItem cachedResult = GlobalClass.InternalCache.Get(Consts.CACHE_NAME_SELECTABLE_CURRENCY);

            if (cachedResult == null)
            {
                cachedResult = new CacheItem(Consts.CACHE_NAME_SELECTABLE_CURRENCY, Currencies.Get());
                GlobalClass.InternalCache.Add(Consts.CACHE_NAME_SELECTABLE_CURRENCY, cachedResult);
            }

            ddlCurrency.Items.Clear();
            string currentCurrency = SharedWebBase.WebsiteCurrency(Session, Request).CurrencyCode;

            Currencies currencies = (Currencies)cachedResult.Value;

            foreach (Currency currency in currencies)
            {
                if (currency.IsActive)
                {
                    ListItem newItem = new ListItem(String.Format("{0} {1}", currency.CurrencyCode, currency.CurrencySymbol), currency.CurrencyCode);
                    ddlCurrency.Items.Add(newItem);

                    if (currency.CurrencyCode == currentCurrency)
                        ddlCurrency.SelectedIndex = ddlCurrency.Items.Count - 1;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string currency = ddlCurrency.SelectedItem.Value;

            Currency newCurrency = Currencies.Get(currency);
            //SharedWebBase.SetCurrency(Session, newCurrency, true);

            string language = ddlLanguage.SelectedItem.Value;

            Country newCountry = Countries.Get(language);

            if (ShowLanguageSelector)
            {
                // create cookies to remember the users choices
                SharedWebBase.CookieSetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_LANGUAGE, Global.DistributorWebsite),
                    newCountry.CountryCode, DateTime.Now.AddYears(1));
            }

            if (ShowCurrencySelector)
            {
                // create cookies to remember the users choices
                SharedWebBase.CookieSetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_CURRENCY, Global.DistributorWebsite),
                    newCurrency.CurrencyCode, DateTime.Now.AddYears(1));
            }

            LocalizedLanguages.SetLanguage(Session, Request, Response, newCountry, newCurrency, true);
        }

        protected string GetLanguageCurrency()
        {
            string Result = String.Empty;

            Currency currency = SharedWebBase.WebsiteCurrency(Session, Request);
            Country country = SharedWebBase.WebCountry(Session, Request);

            string countryName = ShowLanguageSelector ? country.LocalizedLanguage : String.Empty;
            string currencyDetails = ShowCurrencySelector ? String.Format("{0} {1}", currency.CurrencyCode, currency.CurrencySymbol) : "&nbsp;";

            if (ShowFlags)
                Result = String.Format("<ul><li {0}><span>{1}</span></li></ul>",
                    ShowLanguageSelector ? String.Format("style=\"background:transparent url('/images/flags/24/{0}.png') no-repeat;\"", country.CountryCode) : String.Empty,
                    currencyDetails);
            else
                Result = String.Format("<ul><li><span>{0} {1}</span></li></ul>",
                    countryName, currencyDetails);

            return (Result);
        }

    }
}