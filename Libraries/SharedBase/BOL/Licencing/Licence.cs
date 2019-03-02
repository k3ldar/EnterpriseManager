/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Licence.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Licencing
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
