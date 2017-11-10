/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: NewDiscountCouponWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
