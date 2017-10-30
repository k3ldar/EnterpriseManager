using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    public class InvoiceManagerCard : HomeCard
    {
        #region Private Members

        Controls.InvoiceManagerControl _invoiceManager;

        #endregion Private Members

        public InvoiceManagerCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewInvoiceManager));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Invoices);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.InvoiceManager);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_invoiceManager == null)
            {
                _invoiceManager = new Controls.InvoiceManagerControl();
            }

            return (_invoiceManager);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppInvoiceManager);
        }

        public override int StatusPanelCount()
        {
            return (_invoiceManager.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_invoiceManager.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_invoiceManager.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (160);
        }

        #region Private Members


        #endregion Private Members
    }
}
