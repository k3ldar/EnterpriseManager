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
using System;

using POS.Base.Classes;
using POS.Suppliers.Classes;

using Languages;

using Library.BOL.ContactDetails;
using System.Globalization;

namespace POS.Suppliers.Controls.Wizards.Supplier
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SupplierWizard _supplier;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();
        }

        public Step2(SupplierWizard supplier)
            : this()
        {
            Supplier = supplier;
        }

        #endregion Constructors

        #region Properties

        public SupplierWizard Supplier
        {
            get
            {
                return (_supplier);
            }

            set
            {
                _supplier = value;

                if (_supplier.Supplier != null)
                {
                    txtWebsite.Text = _supplier.Supplier.Website;

                    if (_supplier.Supplier.Contacts.Count > 0)
                    {
                        Contact contact = _supplier.Supplier.Contacts[0];
                        txtContactName.Text = contact.ContactName;
                        txtContactTel.Text = contact.ContactValue;
                    }
                }
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblContactTel.Text = LanguageStrings.TelephoneNumber;
            lblPrimaryContact.Text = LanguageStrings.ContactName;
            lblWebsite.Text = LanguageStrings.Website;
        }

        public override bool CanGoFinish()
        {
            return (!String.IsNullOrEmpty(txtContactName.Text) && 
                !String.IsNullOrEmpty(txtContactTel.Text));
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.SuppliersEditStep2;
        }

        public override bool BeforeFinish()
        {
            _supplier.Supplier.Website = txtWebsite.Text;

            if (_supplier.IsNew)
            {
                _supplier.Supplier = Library.BOL.Suppliers.Suppliers.Create(
                    _supplier.Supplier.BusinessName,
                    _supplier.Supplier.Addressline1,
                    _supplier.Supplier.Addressline2,
                    _supplier.Supplier.Addressline3,
                    _supplier.Supplier.City,
                    _supplier.Supplier.County,
                    _supplier.Supplier.Postcode,
                    _supplier.Supplier.Country,
                    _supplier.Supplier.Website,
                    _supplier.Supplier.Status,
                    0, 0);
            }
            else
            {
                _supplier.Supplier.Save();
            }

            _supplier.Supplier.UpdateContact(txtContactName.Text, txtContactTel.Text);

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        #endregion Private Methods
    }
}