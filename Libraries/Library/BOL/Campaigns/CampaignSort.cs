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
