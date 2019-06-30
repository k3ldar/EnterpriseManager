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
 *  File: TreatmentGroup.cs
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

namespace SharedBase.BOL.Treatments
{
    [Serializable]
    public sealed class TreatmentGroup : BaseObject
    {
        #region Private Members

        private int _ID;
        private string _Description;
        private int _SortOrder;
        private Treatments _Treatments;
        private string _TagLine;

        #endregion Private Members

        #region Constructors / Destructors

        public TreatmentGroup(int ID, string Description, int SortOrder, string TagLine)
        {
            _ID = ID;
            _Description = Description;
            _SortOrder = SortOrder;
            _TagLine = TagLine;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return _SortOrder;
            }

            set
            {
                _SortOrder = value;
            }
        }

        public Treatments Treatments
        {
            get
            {
                if (_Treatments == null)
                    _Treatments = DAL.FirebirdDB.TreatmentsGet(1, 10000, this);

                return _Treatments;
            }
        }

        public string TagLine
        {
            get
            {
                return _TagLine;
            }

            set
            {
                _TagLine = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public void Delete(User user)
        {
            Utils.LibUtils.CanDelete(user);
            DAL.FirebirdDB.AdminTreatmentGroupDelete(this);
        }

        public void Save(User user)
        {
            Utils.LibUtils.CanUpdate(user);
            DAL.FirebirdDB.AdminTreatmentGroupUpdate(this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("TreatmentGroup: {0}; Description: {1}", ID, _Description);
        }

        #endregion Overridden Methods

    }
}
