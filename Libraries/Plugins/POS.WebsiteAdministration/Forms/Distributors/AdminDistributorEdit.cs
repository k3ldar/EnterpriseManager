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
 *  File: AdminDistributorEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using SharedBase.BOL.Salons;
using SharedBase;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Salons
{
    public partial class AdminDistributorEdit : Base.Forms.BaseForm
    {
        #region Private Members

        private Salon _Salon;

        #endregion Private Members

        #region Constructors

        public AdminDistributorEdit()
        {
            InitializeComponent();
        }

        public AdminDistributorEdit(Salon salon)
            : this()
        {
            _Salon = salon;

            LoadSalon();
            LoadOpeningTimes();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            Text = LanguageStrings.AppDistributorsAdministration;

            btnClose.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            lblAddress.Text = LanguageStrings.AppAddress;
            lblContactName.Text = LanguageStrings.AppContactName;
            lblEmail.Text = LanguageStrings.AppEmail;
            lblFax.Text = LanguageStrings.AppFax;
            lblPicture.Text = LanguageStrings.AppPicture;
            lblPostCode.Text = LanguageStrings.Postcode;
            lblSalonName.Text = LanguageStrings.AppSalonName;
            lblTelephone.Text = LanguageStrings.AppTelephone;
            lblWebsite.Text = LanguageStrings.AppWebsite;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblType.Text = LanguageStrings.AppType;
            lblCouponCode.Text = LanguageStrings.AppCouponCode;
            lblSalonDiscount.Text = LanguageStrings.AppSalonDiscount;
            lblCustomerDiscount.Text = LanguageStrings.AppSalonCustomerDiscount;

            lblMonday.Text = LanguageStrings.Monday;
            lblTuesday.Text = LanguageStrings.Tuesday;
            lblWednesday.Text = LanguageStrings.Wednesday;
            lblThursday.Text = LanguageStrings.Thursday;
            lblFriday.Text = LanguageStrings.Friday;
            lblSaturday.Text = LanguageStrings.Saturday;
            lblSunday.Text = LanguageStrings.Sunday;

            cbShowOnWeb.Text = LanguageStrings.AppShowOnWebsite;
            cbVIPSalon.Text = LanguageStrings.AppSalonVIP;


            rbDistributor.Text = LanguageStrings.AppDistributor;
            rbSalon.Text = LanguageStrings.AppSalon;
            rbStockist.Text = LanguageStrings.AppStockist;

            tabPageGeneral.Text = LanguageStrings.AppGeneral;
            tabPageSettings.Text = LanguageStrings.AppSettings;
            tabPageType.Text = LanguageStrings.AppType;
            tabPageVIP.Text = LanguageStrings.AppVIP;
            tabPageOpeningTimes.Text = LanguageStrings.AppOpeningTimes;
        }

        protected override void SetPermissions()
        {
            btnDelete.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete);
            btnSave.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadOpeningTimes()
        {
            if (_Salon.HasOpeningTimes)
            {
                txtMonday.Text = _Salon.OpeningMonday;
                txtTuesday.Text = _Salon.OpeningTuesday;
                txtWednesday.Text = _Salon.OpeningWednesday;
                txtThursday.Text = _Salon.OpeningThursday;
                txtFriday.Text = _Salon.OpeningFriday;
                txtSaturday.Text = _Salon.OpeningSaturday;
                txtSunday.Text = _Salon.OpeningSunday;
            }
        }

        private void LoadSalon()
        {
            txtSalonName.Text = _Salon.Name;
            txtContactName.Text = _Salon.ContactName;
            txtAddress.Text = _Salon.Address.Replace(StringConstants.SYMBOL_RETURN, StringConstants.SYMBOL_CRLF);
            txtEmail.Text = _Salon.Email;
            txtFax.Text = _Salon.Fax;
            txtPicture.Text = _Salon.Image;
            txtPostcode.Text = _Salon.PostCode;
            txtTelephone.Text = _Salon.Telephone;
            txtWebsite.Text = _Salon.URL;
            cbShowOnWeb.Checked = _Salon.ShowOnWeb;
            cbVIPSalon.Checked = _Salon.VIPSalon;
            numericSortOrder.Value = _Salon.SortOrder;

            if (!cbVIPSalon.Checked)
                tabControlSalons.TabPages.Remove(tabPageVIP);

            switch (_Salon.SalonType)
            {
                case Enums.SalonType.Distributor:
                    rbDistributor.Checked = true;
                    break;
                case Enums.SalonType.Salon:
                    rbSalon.Checked = true;
                    break;
                case Enums.SalonType.StockistOnly:
                    rbStockist.Checked = true;
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowWarning(LanguageStrings.AppSalonDelete, LanguageStrings.AppSalonDeletePrompt))
            {
                _Salon.Delete();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Salon.Name = txtSalonName.Text.Trim();
            _Salon.ContactName = txtContactName.Text.Trim();
            _Salon.Address = FixAddress(txtAddress.Text);
            _Salon.Email = txtEmail.Text.Trim();
            _Salon.Fax = txtFax.Text.Trim();
            _Salon.Image = txtPicture.Text.Trim();
            _Salon.PostCode = txtPostcode.Text.Trim();
            _Salon.Telephone = txtTelephone.Text.Trim();
            _Salon.URL = txtWebsite.Text.Trim().Replace(StringConstants.SYMBOL_SPACE, 
                StringConstants.SYMBOL_EMPTY_STRING);
            _Salon.ShowOnWeb = cbShowOnWeb.Checked;
            _Salon.VIPSalon = cbVIPSalon.Checked;
            _Salon.SortOrder = (int)numericSortOrder.Value;

            if (rbStockist.Checked)
                _Salon.SalonType = Enums.SalonType.StockistOnly;
            else
            {
                if (rbDistributor.Checked)
                    _Salon.SalonType = Enums.SalonType.Distributor;
                else
                    _Salon.SalonType = Enums.SalonType.Salon;

            }

            _Salon.SetOpeningHours(txtMonday.Text, txtTuesday.Text, txtWednesday.Text, txtThursday.Text, txtFriday.Text, txtSaturday.Text, txtSunday.Text);

            _Salon.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private string FixAddress(string address)
        {
            string[] lines;

            if (address.Contains("\r"))
                lines = address.Split('\r');
            else if (address.Contains("\n"))
                lines = address.Split('\n');
            else
            {
                address = address.Replace("  ", "\r");
                lines = address.Split('\r');
            }

            string Result = String.Empty;

            foreach (string line in lines)
            {
                string s = line.Trim();

                if (!String.IsNullOrEmpty(s))
                {
                    if (String.IsNullOrEmpty(Result))
                        Result = s;
                    else
                        Result += "\r\n" + s;
                }
            }

            return (Result);
        }

        private void cbVIPSalon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVIPSalon.Checked)
                tabControlSalons.TabPages.Add(tabPageVIP);
            else
                tabControlSalons.TabPages.Remove(tabPageVIP);
        }

        private void spnCustomerDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (spnCustomerDiscount.Value >= spnSalonDiscount.Value)
            {
                ShowInformation(LanguageStrings.AppSalonVIP, LanguageStrings.AppSalonCustomerDiscountIncorrect);
                spnCustomerDiscount.Value--;
            }
        }

        private void tabPageVIP_Enter(object sender, EventArgs e)
        {
            SalonDiscount discount = _Salon.SalonDiscount;

            if (discount != null)
            {
                spnSalonDiscount.Value = discount.Discount;
                spnCustomerDiscount.Value = discount.CustomerDiscount;
                txtSalonCouponCode.Text = discount.CouponCode;
            }
        }

        private void tabControlSalons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlSalons.SelectedTab == tabPageGeneral)
                HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEditGeneral;
            else if (tabControlSalons.SelectedTab == tabPageOpeningTimes)
                HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEditOpeningTimes;
            else if (tabControlSalons.SelectedTab == tabPageSettings)
                HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEditSettings;
            else if (tabControlSalons.SelectedTab == tabPageType)
                HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEditType;
            else if (tabControlSalons.SelectedTab == tabPageVIP)
                HelpTopic = POS.Base.Classes.HelpTopics.WebSalonEditVIP;
        }

        #endregion Private Methods
    }
}
