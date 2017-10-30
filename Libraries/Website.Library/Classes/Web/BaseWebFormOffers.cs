using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Library.Classes
{
    /// <summary>
    /// Base web Form For offers that expire.  Will check the expirery date, if it's passed will throw it over to the offers page.
    /// </summary>
    public class BaseWebFormOffers : BaseWebForm
    {
        #region Properties

        /// <summary>
        /// Date/Time the page expires
        /// 
        /// Once expired the page will automatically redirect to the usual offers page
        /// </summary>
        public DateTime PageExpires { get; set; }

        /// <summary>
        /// Date/Time page will be available to the public
        /// </summary>
        public DateTime PageAvailable { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (GetUsersMemberLevel() < 7)
            {
                if (!Shared.Utilities.DateWithin(PageAvailable, PageExpires, DateTime.Now))
                    DoRedirect("/Offers/Offers.aspx", true);
            }
        }

        #endregion Overridden Methods
    }
}
