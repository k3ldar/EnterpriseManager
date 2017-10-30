using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Distributors
{
    [Serializable]
    public sealed class WebsiteDistributor : BaseObject
    {
        #region Constructors

        public WebsiteDistributor (Int64 id, string countryCode, string name, string url, bool isActive, string continent, bool autoRedirect)
        {
            ID = id;
            CountryCode = countryCode;
            Name = name;
            URL = url;
            IsActive = isActive;
            Continent = continent;
            AutoRedirect = autoRedirect;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; private set; }
        
        public string CountryCode { get; private set; }
        
        public string Name { get; private set; }
        
        public string URL { get; private set; }

        public bool IsActive { get; private set; }

        public string Continent { get; private set; }

        public bool AutoRedirect { get; private set; }

        #endregion Properties
    }
}
