using System;
using System.Drawing;

using Languages;

using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.PurchaseOrders.Controls;

namespace POS.PurchaseOrders
{
    public class PurchaseOrdersCard : HomeCard
    {
        #region Private Members

        private PurchaseOrderTab _purchaseOrderTab;

        #endregion Private Members

        public PurchaseOrdersCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (true);
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.PurchaseOrder);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.PurchaseOrders);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_purchaseOrderTab == null)
                _purchaseOrderTab = new PurchaseOrderTab();

            return (_purchaseOrderTab);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppPurchaseOrders);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int SortOrder()
        {
            return (350);
        }

        public override bool OwnerDrawn()
        {
            return (false);
        }

        #region Private Members


        #endregion Private Members
    }
}
