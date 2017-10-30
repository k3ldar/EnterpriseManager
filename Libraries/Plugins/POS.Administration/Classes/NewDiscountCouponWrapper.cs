using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library.BOL.Coupons;
using SharedControls.WizardBase;

namespace POS.Administration.Classes
{
    public static class NewDiscountCouponWrapper
    {
        public static bool ShowNewDiscountWizard(Coupon coupon)
        {
            CouponSettings settings = new CouponSettings(coupon);

            return (WizardForm.ShowWizard(coupon.ID == -1 ? LanguageStrings.AppCouponNewCode : LanguageStrings.AppCouponEditCode,
                new Controls.Wizards.Coupons.Step1(settings),
                new Controls.Wizards.Coupons.Step2(settings),
                new Controls.Wizards.Coupons.Step3(settings),
                new Controls.Wizards.Coupons.Step4(settings),
                new Controls.Wizards.Coupons.Step5(settings),
                new Controls.Wizards.Coupons.Summary(settings)
                ));
        }
    }

    public sealed class CouponSettings
    {
        public CouponSettings(Coupon coupon)
        {
            Coupon = coupon;
        }

        /// <summary>
        /// Coupon being edited/created
        /// </summary>
        public Coupon Coupon { get; private set; }
    }
}
