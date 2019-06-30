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
 *  File: SpecialDate.cs
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

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class SpecialDate : BaseObject
    {
        #region Private Members

        private int _id;
        private string _description;
        private DateTime _dateStart;
        private DateTime _dateEnd;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of special date</param>
        /// <param name="description">Description of special date</param>
        /// <param name="date">Date of special date</param>
        public SpecialDate(int id, string description, DateTime dateStart, DateTime dateEnd)
        {
            _id = id;
            _description = description;
            _dateStart = dateStart;
            _dateEnd = dateEnd.AddHours(23).AddMinutes(59);
            //_dateEnd = _dateEnd.AddDays(1);
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// ID of special date
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Description of special date
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
        }

        /// <summary>
        /// Start date of special date
        /// </summary>
        public DateTime DateStart
        {
            get
            {
                return _dateStart;
            }
        }

        /// <summary>
        /// End date of special date
        /// </summary>
        public DateTime DateEnd
        {
            get
            {
                return _dateEnd;
            }
        }

        #endregion Properties


        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("SpecialDate: {0}; Description: {1}", ID, Description);
        }

        #endregion Overridden Methods

    }
}
