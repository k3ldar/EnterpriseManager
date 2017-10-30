using System;
using System.Drawing;

using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Administration
{
    class DiscountCouponCard : HomeCard
    {
        #region Private Members

        Forms.DiscountCoupons.AdminDiscountCoupons _tabFormPage;

        #endregion Private Members

        public DiscountCouponCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerDiscountCoupons));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.CouponCodes);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.AdministrationDiscountCoupons);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.DiscountCoupons.AdminDiscountCoupons(AppController.Administration);
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppDiscountCoupons);
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
            return (210);
        }

        #region Private Members


        #endregion Private Members
    }
}
