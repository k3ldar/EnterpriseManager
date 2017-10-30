using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Countries;

namespace Library.BOL.CustomWebPages
{
    [Serializable]
    public sealed class CustomPage : BaseObject
    {
        #region Private Members

        private Int64 _id;

        #endregion Private Members

        #region Constructors

        public CustomPage(Int64 id, string title, string pageText, int websiteID, 
            Country country, bool isActive, CustomPagesType pageType)
        {
            _id = id;
            Title = title;
            PageText = pageText;
            WebSiteID = websiteID;
            Country = country;
            IsActive = isActive;
            PageType = pageType;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.CustomPageUpdate(this);
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Unique ID for record
        /// </summary>
        public Int64 ID 
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
        /// Page Title, static content not to be altered by user 
        /// as used when searching for page to show on website
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Formatted HTML text used to display on web page
        /// </summary>
        public string PageText { get; set; }

        /// <summary>
        /// Website ID
        /// </summary>
        public int WebSiteID { get; set; }

        /// <summary>
        /// The country for which the active page is linked to
        /// </summary>
        public Country Country { get; private set; }

        /// <summary>
        /// Determines wether the custom page is active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Custom page type
        /// </summary>
        public CustomPagesType PageType { get; set; }

        #endregion Properties
    }
}
