using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Customers.Forms;

namespace POS.Customers
{
    public class CustomerAffiliateCard : HomeCard
    {
        #region Private Members

        Forms.AffiliateData _tabFormPage;

        #endregion Private Members

        public CustomerAffiliateCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageAffiliates));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.AffiliateCommission);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.CustomerAffCommissionData);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.AffiliateData();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppAffiliateData);
        }

        public override int StatusPanelCount()
        {
            return (_tabFormPage.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tabFormPage.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tabFormPage.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (6000);
        }

        #region Private Members


        #endregion Private Members
    }
}
