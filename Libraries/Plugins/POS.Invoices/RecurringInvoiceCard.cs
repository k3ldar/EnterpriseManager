using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    class RecurringInvoiceCard : HomeCard
    {
        #region Private Members

        Controls.RecurringInvocesControl _recurringInvoices;

        #endregion Private Members

        #region Constructors

        public RecurringInvoiceCard(BasePlugin parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CreateOrder));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.RecurringInvoices);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.RecurringInvoices);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_recurringInvoices == null)
            {
                _recurringInvoices = new Controls.RecurringInvocesControl();
            }

            return (_recurringInvoices);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCreateRecurringInvoice);
        }

        public override int StatusPanelCount()
        {
            return (_recurringInvoices.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_recurringInvoices.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_recurringInvoices.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (200);
        }

        #endregion Overridden Methods

        #region Private Members


        #endregion Private Members
    }
}
