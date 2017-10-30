using System;

using Library.BOL.Campaigns;

namespace POS.Marketing.Classes
{
    public class CampaignNodeType
    {
        #region Constructors

        public CampaignNodeType(NodeType nodeType)
        {
            Type = nodeType;
        }

        public CampaignNodeType(DateTime month)
            : this (NodeType.Date)
        {
            Month = month;
        }

        public CampaignNodeType(Campaign campaign)
            : this(NodeType.Campaign)
        {
            Campaign = campaign;
        }

        #endregion Constructors

        #region Properties

        public NodeType Type { get; private set; }

        public DateTime Month { get; private set; }

        public Campaign Campaign { get; private set; }

        #endregion Properties
    }
}
