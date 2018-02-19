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
 *  File: CampaignSort.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Collections;

namespace Library.BOL.Campaigns
{
    public class CampaignSortComparer : IComparer
    {
        #region Constructors

        public CampaignSortComparer(CampaignSortType sortType)
        {
            SortType = sortType;
        }

        #endregion Constructors

        #region Properties

        public CampaignSortType SortType { get; private set; }

        #endregion Properties

        #region Public Methods

        int IComparer.Compare(object x, object y)
        {
            if (x == null || y == null)
                return (0);

            switch (SortType)
            {
                case CampaignSortType.TopSpend:
                    return (CompareSpend((Campaign)x, (Campaign)y));
                case CampaignSortType.TopVisits:
                    return (CompareVisits((Campaign)x, (Campaign)y));
                case CampaignSortType.StartDateDescending:
                    return (CompareStartDateDescending((Campaign)x, (Campaign)y));
                case CampaignSortType.StartDateAscending:
                default:
                    return (CompareStartDate((Campaign)x, (Campaign)y));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private int CompareStartDate(Campaign x, Campaign y)
        {
            return (x.StartDateTime.CompareTo(y.StartDateTime));
        }

        private int CompareStartDateDescending(Campaign x, Campaign y)
        {
            return (y.StartDateTime.CompareTo(x.StartDateTime));
        }

        private int CompareSpend(Campaign x, Campaign y)
        {
            return (y.Sales.CompareTo(x.Sales));
        }

        private int CompareVisits(Campaign x, Campaign y)
        {
            return (y.Visits.CompareTo(x.Visits));
        }

        #endregion Private Methods
    }
}
