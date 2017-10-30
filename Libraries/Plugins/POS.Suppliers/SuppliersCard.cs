using System;
using System.Drawing;

using Languages;

using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Suppliers
{
    public class SuppliersCard : HomeCard
    {
        #region Private Members

        private SuppliersListTab _supplierTab;

        #endregion Private Members

        public SuppliersCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(Library.SecurityEnums.SecurityPermissionsAccounts.ViewSuppliers));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Suppliers);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Suppliers);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_supplierTab == null)
                _supplierTab = new SuppliersListTab();

            return (_supplierTab);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppSuppliers);
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
