
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
