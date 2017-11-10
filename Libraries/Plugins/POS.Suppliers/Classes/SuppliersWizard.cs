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
 *  File: SuppliersWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Languages;
using Library.BOL.Suppliers;
using SharedControls.WizardBase;

namespace POS.Suppliers.Classes
{
    public static class SuppliersWizards
    {
        public static bool CreateNewSupplier(ref Supplier supplier)
        {
            SupplierWizard wizard = new SupplierWizard();
            wizard.Supplier = supplier;
            wizard.IsNew = true;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppSupplierCreate,
                new Controls.Wizards.Supplier.Step1(wizard), 
                new Controls.Wizards.Supplier.Step2(wizard));

            supplier = wizard.Supplier;

            return (Result);
        }

        public static bool EditSupplier(ref Supplier supplier)
        {
            SupplierWizard wizard = new SupplierWizard();
            wizard.Supplier = supplier;
            wizard.IsNew = false;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppSupplierEdit,
                new Controls.Wizards.Supplier.Step1(wizard),
                new Controls.Wizards.Supplier.Step2(wizard));

            supplier = wizard.Supplier;

            return (Result);
        }

        public static bool CreateProduct(Supplier supplier, ref SupplierProduct product)
        {
            SupplierProductWizard wizard = new SupplierProductWizard();
            wizard.IsNew = true;
            wizard.Supplier = supplier;
            wizard.Product = product;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppSupplierProductCreate,
                new Controls.Wizards.Products.Step1(wizard));

            product = wizard.Product;

            return (Result);
        }

        public static bool EditProduct(Supplier supplier, ref SupplierProduct product)
        {
            SupplierProductWizard wizard = new SupplierProductWizard();
            wizard.IsNew = false;
            wizard.Supplier = supplier;
            wizard.Product = product;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppSupplierProductEdit,
                new Controls.Wizards.Products.Step1(wizard));

            product = wizard.Product;

            return (Result);
        }
    }

    public class SupplierWizard
    {
        public bool IsNew { get; set; }
        public Supplier Supplier { get; set; }
    }

    public class SupplierProductWizard : SupplierWizard
    {
        public SupplierProduct Product { get; set; }
    }
}
