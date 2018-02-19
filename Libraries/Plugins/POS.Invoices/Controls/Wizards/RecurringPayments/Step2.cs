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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Step2.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Windows.Forms;

using SharedControls.WizardBase;

using Languages;
using Library.BOL.Products;
using Library.BOL.Invoices;

using POS.Base.Classes;
using POS.Invoices.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Controls.Wizards.RecurringPayments
{
    public partial class Step2 : BaseWizardPage
    {
        #region Private Members

        private RecurringPaymentOptions _options;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();

            LoadProductItems();
        }

        public Step2(RecurringPaymentOptions options)
            : this()
        {
            _options = options;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppRecurringInvoiceSelectProducts;
            chSKU.Text = LanguageStrings.AppSKU;
            chProductType.Text = LanguageStrings.AppProductType;
            chProductName.Text = LanguageStrings.AppProductName;
            chProductSize.Text = LanguageStrings.AppProductSize;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.RecurringInvociesCreateStep2;

            if (_options.Invoice != null && _options.Invoice.Items.Count > 0)
            {
                for (int i = 0; i < lstProducts.Items.Count; i++)
                {
                    ProductCost item = (ProductCost)lstProducts.Items[i].Tag;
                    RecurringInvoiceItem invItem = _options.Invoice.Items.Get(item);

                    lstProducts.Items[i].Checked = invItem == null ? false : true;

                    if (lstProducts.Items[i].Checked)
                        lstProducts.Items[i].Text = invItem.Quantity.ToString();
                }
            }
        }

        public override bool NextClicked()
        {
            if (lstProducts.CheckedItems.Count < 1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppProductSelect);
                return (false);
            }


                _options.Invoice.Items.Clear();

            foreach (ListViewItem item in lstProducts.CheckedItems)
            {
                ProductCost costItem = (ProductCost)item.Tag;
                RecurringInvoiceItem invItem = _options.Invoice.Items.Get(costItem);

                if (invItem == null)
                {
                    _options.Invoice.Items.Add(new RecurringInvoiceItem(-1, 
                        _options.Invoice, costItem, Shared.Utilities.StrToDecimal(item.Text, 1)));
                }
                else
                {
                    decimal newQty = Shared.Utilities.StrToDecimal(item.Text, 1);

                    if (invItem.Quantity != newQty)
                        invItem.Quantity = newQty;
                }
            }

            return (base.NextClicked());
        }

        public override bool CanGoNext()
        {
            return base.CanGoNext();
        }

        public override bool BeforeFinish()
        {
            return base.BeforeFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadProductItems()
        {
            lstProducts.BeginUpdate();
            try
            {
                foreach (Product product in AppController.Administration.ProductsGet())
                {
                    foreach (ProductCost cost in product.ProductCosts)
                    {
                        ListViewItem item = new ListViewItem(StringConstants.SYMBOL_ONE);
                        item.SubItems.Add(product.PrimaryProduct.Description);
                        item.SubItems.Add(product.Name);
                        item.SubItems.Add(cost.Size);
                        item.SubItems.Add(cost.SKU);
                        item.Tag = cost;
                        lstProducts.Items.Add(item);
                    }
                }
            }
            finally
            {
                lstProducts.EndUpdate();
            }
        }

        private void lstProducts_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = false;
        }

        private void lstProducts_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            decimal newValue = Shared.Utilities.StrToDecimal(e.Label, -1);

            if (newValue <= 0)
                e.CancelEdit = true;
        }

        #endregion Private Methods
    }
}
