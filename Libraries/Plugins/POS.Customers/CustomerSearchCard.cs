using System;
using System.Drawing;
using Languages;
using Library.BOL.Users;
using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.Customers
{
    public class CustomerSearchCard : HomeCard
    {
        #region Private Members

        POS.Customers.Controls.CustomerSearchControl _searchControl;

        #endregion Private Members

        public CustomerSearchCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(Library.SecurityEnums.SecurityPermissionsPOS.SearchUsers));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Users);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_searchControl == null)
                _searchControl = new POS.Customers.Controls.CustomerSearchControl();

            return (_searchControl);
        }

        public override string HepString()
        {
            return (HelpTopics.CustomerSearch);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCustomerTab);
        }

        public override int StatusPanelCount()
        {
            return (_searchControl.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_searchControl.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_searchControl.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (100);
        }
    }
}
