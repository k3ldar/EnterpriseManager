using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.Licencing
{
    [Serializable]
    public sealed class Licence
    {
        #region Private Members

        private int _updates;
        private int _invoiceID;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="licenceType"></param>
        /// <param name="domain"></param>
        /// <param name="expires"></param>
        /// <param name="isTrial"></param>
        /// <param name="isValid"></param>
        /// <param name="updates"></param>
        public Licence(Int64 id, int licenceType, string domain, DateTime createDate, DateTime expires,
            bool isTrial, bool isValid, int updates, int invoiceID, int count)
        {
            ID = id;
            LicenceType = licenceType;
            Domain = domain;
            Expires = expires;
            IsTrial = isTrial;
            IsValid = isValid;
            _updates = updates;
            _invoiceID = invoiceID;
            Count = count;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique Licence ID
        /// </summary>
        public Int64 ID { get; private set; }
        
        public int LicenceType { get; private set; }
        
        /// <summary>
        /// Domain/IP Address linked to 
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Date/Time licence created/valid from
        /// </summary>
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// Date/Time licence expires
        /// </summary>
        public DateTime Expires { get; private set; }
        
        /// <summary>
        /// Determines wether it's a trial licence or not
        /// </summary>
        public bool IsTrial { get; private set; }
        
        /// <summary>
        /// Determines wether the licence is valid or not
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Number of updates for the licence
        /// </summary>
        public int Updates 
        {
            get
            {
                return (_updates);
            }
        }


        public string LicenceTypeText
        {
            get
            {
                string Result = String.Empty;

                switch (LicenceType)
                {
                    case 0:
                        Result = "Domain";
                        break;

                    case 1:
                        Result = "Server";
                        break;

                    case 2:
                        Result = "Firebird";
                        break;

                    case 3:
                        Result = "WebMonitor";
                        break;

                    case 4:
                        Result = "GeoIP";
                        break;

                    case 5:
                        Result = "ServiceGuard";
                        break;

                    case 6:
                        Result = "FBTaskScheduler";
                        break;

                    case 7:
                        Result = "Firebird Replication";
                        break;

                   default:
                        throw new Exception("Invalid Licence Type");
                }


                return (Result);
            }
        }

        /// <summary>
        /// Count of items allowed with licence
        /// </summary>
        public int Count { get; set; }

        #endregion Properties

        #region Public Methods

        public void Save()
        {
            DAL.FirebirdDB.LicenceSave(this);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Validates a licence with the database
        /// </summary>
        /// <param name="licenceID">Licence ID</param>
        /// <param name="domain">Domain Name</param>
        /// <param name="licenceType">Licence Type</param>
        /// <returns>True if valid, otherwise false</returns>
        public static bool LicenceValid(Int64 licenceID, string domain, int licenceType)
        {
            return (DAL.FirebirdDB.LicenceValid(licenceID, domain, licenceType));
        }


        public static int LicenceCount(User user)
        {
            return (DAL.FirebirdDB.LicenceCount(user));
        }

        #endregion Static Methods
    }
}
