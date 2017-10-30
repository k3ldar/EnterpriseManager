using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;
using Library.BOL.Countries;

using Shared.Classes;

namespace Library.BOL.Campaigns
{
    [Serializable]
    public sealed class Campaign : BaseObject, IComparable<Campaign>
    {
        #region Private Members

        private int _id;
        private DateTime _startDateTime;
        private DateTime _finishDateTime;
        private string _campaignName;
        private bool _sendEmail;
        private string _emailSubject;
        private bool _emailSent;
        private string _email;
        private string _sender;
        private string _message;
        private bool _sendLetter;
        private string _letter;
        private string _imageMainPage;
        private string _imageLeftMenu;
        private string _imageOffersPage;
        private string _offersPageText;
        private int _visits;
        private int _invoices;
        private decimal _sales;
        private string _title;

        private string _linkOverride;
        private int _activateProductGroup;
        private string _couponName;
        private int _coupanPercent;
        private int _freeProductCode;
        private int _mainProductCode;

        #endregion Private Members

        #region Constructors

        public Campaign(int ID, DateTime Start, DateTime Finish, string Name, bool SendEmail, bool EmailSent, string EmailSubject, string Email, string Sender, string Message,
            bool SendLetter, string Letter, string ImageMainPage, string ImageLeftMenu, string ImageOffersPage, string OffersPageText, int Visits, int Invoices, decimal Sales,
            string Title, string LinkOverride, int ActivateProductGroup, string CouponName, int CouponPercent, int FreeProductcode, int MainProductCode, bool canReplicate,
            Int64 offerProduct1, Int64 offerProduct2, Int64 offerProduct3, Int64 offerProduct4, Int64 offerProduct5, Int64 offerProduct6)
        {
            _id = ID;
            _startDateTime = Start;
            _finishDateTime = Finish;
            _campaignName = Name;
            _sendEmail = SendEmail;
            _emailSent = EmailSent;
            _emailSubject = EmailSubject;
            _email = Email;
            _sender = Sender;
            _message = Message;
            _sendLetter = SendLetter;
            _letter = Letter;
            _imageOffersPage = ImageOffersPage;
            _imageMainPage = ImageMainPage;
            _imageLeftMenu = ImageLeftMenu;
            _offersPageText = OffersPageText;
            _visits = Visits;
            _invoices = Invoices;
            _sales = Sales;
            _title = Title;

            _linkOverride = LinkOverride;
            _activateProductGroup = ActivateProductGroup;
            _couponName = CouponName;
            _coupanPercent = CouponPercent;
            _freeProductCode = FreeProductcode;
            _mainProductCode = MainProductCode;

            CanReplicate = canReplicate;

            OfferProduct1 = offerProduct1;
            OfferProduct2 = offerProduct2;
            OfferProduct3 = offerProduct3;
            OfferProduct4 = offerProduct4;
            OfferProduct5 = offerProduct5;
            OfferProduct6 = offerProduct6;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates wether the campaign can be replicated or not to other distributors
        /// </summary>
        public bool CanReplicate { get; set; }

        /// <summary>
        /// ID of campaign
        /// </summary>
        public int ID
        {
            get
            {
                return (_id);
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Start date/time of campaign
        /// </summary>
        public DateTime StartDateTime
        {
            get
            {
                return (_startDateTime);
            }

            set
            {
                _startDateTime = value;
            }
        }

        /// <summary>
        /// Title for Campaign
        /// </summary>
        public string Title
        {
            get
            {
                return (_title);
            }

            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Finish date/time of campaign
        /// </summary>
        public DateTime FinishDateTime
        {
            get
            {
                return (_finishDateTime);
            }

            set
            {
                _finishDateTime = value;
            }
        }

        /// <summary>
        /// Name of campaign
        /// </summary>
        public string CampaignName
        {
            get
            {
                return (_campaignName);
            }

            set
            {
                _campaignName = value;
            }
        }

        /// <summary>
        /// Indicates wether an email will be sent
        /// </summary>
        public bool SendEmail
        {
            get
            {
                return (_sendEmail);
            }

            set
            {
                _sendEmail = value;
            }
        }

        /// <summary>
        /// Indicates wether the email has been sent
        /// </summary>
        public bool EmailSent
        {
            get
            {
                return (_emailSent);
            }

            set
            {
                _emailSent = value;
            }
        }

        /// <summary>
        /// Email subject
        /// </summary>
        public string EmailSubject
        {
            get
            {
                return (_emailSubject);
            }

            set
            {
                _emailSubject = value;
            }
        }

        /// <summary>
        /// Email address for sender
        /// </summary>
        public string SenderEmail
        {
            get
            {
                return (_email);
            }

            set
            {
                _email = value;
            }
        }

        /// <summary>
        /// Email Sender's name
        /// </summary>
        public string SenderName
        {
            get
            {
                return (_sender);
            }

            set
            {
                _sender = value;
            }
        }

        /// <summary>
        /// Email message
        /// </summary>
        public string Message
        {
            get
            {
                return (_message);
            }

            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Indicates wether a letter will be sent
        /// </summary>
        public bool SendLetter
        {
            get
            {
                return (_sendLetter);
            }

            set
            {
                _sendLetter = value;
            }
        }

        /// <summary>
        /// Text of the letter
        /// </summary>
        public string Letter
        {
            get
            {
                return (_letter);
            }

            set
            {
                _letter = value;
            }
        }

        /// <summary>
        /// Image to be placed on main index page
        /// </summary>
        public string ImageMainPage
        {
            get
            {
                return (_imageMainPage);
            }

            set
            {
                _imageMainPage = value;
            }
        }

        /// <summary>
        /// Image to be placed on left menu for each page
        /// </summary>
        public string ImageLeftMenu
        {
            get
            {
                return (_imageLeftMenu);
            }

            set
            {
                _imageLeftMenu = value;
            }
        }

        /// <summary>
        /// Image to be placed on offers page
        /// </summary>
        public string ImageOffersPage
        {
            get
            {
                return (_imageOffersPage);
            }

            set
            {
                _imageOffersPage = value;
            }
        }

        /// <summary>
        /// Text to be displayed on offers page
        /// </summary>
        public string OffersPageText
        {
            get
            {
                return (_offersPageText);
            }

            set
            {
                _offersPageText = value;
            }
        }

        public int Visits
        {
            get
            {
                return (_visits);
            }
        }

        /// <summary>
        /// Total Invoices for Campaign
        /// </summary>
        public int Invoices
        {
            get
            {
                return (_invoices);
            }
        }

        /// <summary>
        /// Total Sales For Campaign
        /// </summary>
        public decimal Sales
        {
            get
            {
                return (_sales);
            }
        }

        /// <summary>
        /// Activates the product Group
        /// </summary>
        public int ActivateProductGroup
        {
            get
            {
                return (_activateProductGroup);
            }

            set
            {
                _activateProductGroup = value;
            }
        }

        /// <summary>
        /// Link to the page where the offer will go
        /// </summary>
        public string WebLink
        {
            get
            {
                if (String.IsNullOrEmpty(_linkOverride))
                    return ("/Offers/Offers.aspx");
                else
                    return (_linkOverride);
            }
        }

        /// <summary>
        /// Override's the link that jumps straight to the Offers Page
        /// </summary>
        public string LinkOverride
        {
            get
            {
                return (_linkOverride);
            }

            set
            {
                _linkOverride = value;
            }
        }

        /// <summary>
        /// Name of coupon associated with the campaign
        /// </summary>
        public string CouponName
        {
            get
            {
                return (_couponName);
            }

            set
            {
                _couponName = value;
            }
        }

        /// <summary>
        /// Percentage discount for the campaign
        /// </summary>
        public int CouponPercent
        {
            get
            {
                return (_coupanPercent);
            }

            set
            {
                _coupanPercent = value;
            }
        }

        /// <summary>
        /// Free product associated with coupon for campaign
        /// </summary>
        public int FreeProductCode
        {
            get
            {
                return (_freeProductCode);
            }

            set
            {
                _freeProductCode = value;
            }
        }

        /// <summary>
        /// Main Product Code associated with coupon for free product
        /// </summary>
        public int MainProductCode
        {
            get
            {
                return (_mainProductCode);
            }

            set
            {
                _mainProductCode = value;
            }
        }

        /// <summary>
        /// Offer Product 1
        /// </summary>
        public Int64 OfferProduct1 { get; set; }

        /// <summary>
        /// Offer Product 2
        /// </summary>
        public Int64 OfferProduct2 { get; set; }

        /// <summary>
        /// Offer Product 3
        /// </summary>
        public Int64 OfferProduct3 { get; set; }

        /// <summary>
        /// Offer Product 4
        /// </summary>
        public Int64 OfferProduct4 { get; set; }

        /// <summary>
        /// Offer Product 5
        /// </summary>
        public Int64 OfferProduct5 { get; set; }

        /// <summary>
        /// Offer Product 6
        /// </summary>
        public Int64 OfferProduct6 { get; set; }
        
        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Sends a test email for the campaign
        /// </summary>
        /// <param name="user">User to receive test email</param>
        /// <param name="SenderName"></param>
        /// <param name="SenderEmail"></param>
        /// <param name="Message"></param>
        /// <param name="Subject"></param>
        /// <param name="campaignName">Campaign Name</param>
        public void SendTestEmail(User user, string SenderName, string SenderEmail, string Message, 
            string Subject, string campaignName)
        {
            DAL.FirebirdDB.CampaignSendTestEmail(user, SenderName, SenderEmail, Message, Subject, campaignName);
        }

        #endregion Public Methods

        #region Overridden Methods

        /// <summary>
        /// Deletes the campaign
        /// </summary>
        public override void Delete()
        {
            DAL.FirebirdDB.CampaignDelete(this);
        }

        /// <summary>
        /// Saves the campaign
        /// </summary>
        public override void Save()
        {
            DAL.FirebirdDB.CampaignSave(this);
        }


        public override string ToString()
        {
            return (String.Format("Campaign: {0}; Description: {1}", ID, CampaignName));
        }

        #endregion Overridden Methods

        #region Static Methods

        /// <summary>
        /// Retrieves the active campaign
        /// </summary>
        /// <returns>Campaign object if there is an active campaign, otherwise null</returns>
        public static Campaigns GetActive(Country currentCountry)
        {
            string name = String.Format("Internally Cached Campaign By Country {0}",
                currentCountry == null ? "null" : currentCountry.CountryCode);

            if (DAL.DALHelper.AllowCaching)
            {
                CacheItem item = DAL.DALHelper.InternalCache.Get(name);

                if (item != null)
                    return ((Campaigns)item.Value);
            }

            Campaigns Result = DAL.FirebirdDB.CampaignGet(currentCountry);

            if (DAL.DALHelper.AllowCaching)
                DAL.DALHelper.InternalCache.Add(name, new CacheItem(name, Result));

            return (Result);
        }


        public static Campaign Get(int ID)
        {
            return (DAL.FirebirdDB.CampaignGet(ID));
        }

        public static Campaign Get(string Campaign)
        {
            if (Campaign.Length > 40)
                Campaign = Campaign.Substring(0, 39);

            return (DAL.FirebirdDB.CampaignGet(Campaign));
        }

        #endregion Static Methods

        #region Sorting

        public int CompareTo(Campaign other)
        {
            throw new NotImplementedException();
        }

        #endregion Sorting
    }
}
