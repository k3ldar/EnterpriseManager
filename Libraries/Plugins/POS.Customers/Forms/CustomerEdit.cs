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
 *  File: CustomerEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Accounts;
using Library.BOL.Affiliate;
using Library.BOL.Appointments;
using Library.BOL.Countries;
using Library.BOL.DeliveryAddress;
using Library.BOL.Helpdesk;
using Library.BOL.Invoices;
using Library.BOL.Orders;
using Library.BOL.Salons;
using Library.BOL.Users;
using Library.BOL.ValidationChecks;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Customers.Forms
{
    public partial class AdminMemberEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _UserEdit;

        #endregion Private Members

        #region Constructors

        public AdminMemberEdit()
        {
            InitializeComponent();

            tabUserOptions.SelectedIndexChanged += tabUserOptions_SelectedIndexChanged;
        }

        public AdminMemberEdit(User userEdit, bool ShowNotes)
            :this(userEdit)
        {
            if (ShowNotes)
                tabUserOptions.SelectedTab = tabPageNotes;
        }

        public AdminMemberEdit(User userEdit)
            : this ()
        {
            _UserEdit = userEdit;

            LoadMonths();

            permissions1.User = _UserEdit;
            permissions1.WebOnly = AppController.ActiveUser.MemberLevel < MemberLevel.StaffMember;
            LoadCountries(cmbCountry);
            LoadCountries(cmbDeliveryCountry);
            LoadUser();
            LoadSalons();
            LoadAffiliates();

            btnResetPassword.Visible = userEdit.MemberLevel == MemberLevel.StandardUser &&
                AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ResetPassword);
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabUserOptions_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCustomerEdit;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnCleanAddress.Text = LanguageStrings.AppMenuButtonCleanAddress;
            btnDeliveryAddressClean.Text = LanguageStrings.AppMenuButtonCleanAddress;
            btnDeliveryAddressSave.Text = LanguageStrings.AppMenuButtonSave;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnSendPasswordReminder.Text = LanguageStrings.AppMenuButtonSendPassword;
            btnResetPassword.Text = LanguageStrings.AppResetPassword;

            tabPageDeliveryAddresses.Text = LanguageStrings.AppCustomerDeliveryAddresses;
            tabPageGoldUser.Text = LanguageStrings.AppCustomerGoldUser;
            tabPageNotes.Text = LanguageStrings.AppNotes;
            tabPagePermissions.Text = LanguageStrings.AppPermissions;
            tabPageSalonOwner.Text = LanguageStrings.AppSalonOwner;
            tabPageUserDetails.Text = LanguageStrings.AppCustomerDetails;
            tabPageUserInvoices.Text = LanguageStrings.AppInvoices;
            tabPageUserOrders.Text = LanguageStrings.AppOrders;

            cbEmail.Text = LanguageStrings.AppCustomerReceiveEmails;
            cbPostal.Text = LanguageStrings.AppCustomerReceiveLetters;
            cbTelephone.Text = LanguageStrings.AppCustomerReceiveTelephone;
            cbVIPCustomer.Text = LanguageStrings.AppCustomerVIP;

            colHeaderDate.Text = LanguageStrings.AppDate;
            colHeaderDepartment.Text = LanguageStrings.Department;
            colHeaderInvoiceInitialPaymentType.Text = LanguageStrings.AppInitialPaymentType;
            colHeaderInvoiceInvoiceNumber.Text = LanguageStrings.AppInvoiceNumber;
            colHeaderInvoiceOrderDate.Text = LanguageStrings.AppDate;
            colHeaderInvoiceProcessStatus.Text = LanguageStrings.AppProcessStatus;
            colHeaderInvoiceStatus.Text = LanguageStrings.AppStatus;
            colHeaderLastUpdated.Text = LanguageStrings.LastUpdated;
            colHeaderLastUpdatedBy.Text = LanguageStrings.LastUpdatedBy;
            colHeaderOrderOrderNumber.Text = LanguageStrings.AppOrderNumber;
            colHeaderOrderProcessStatus.Text = LanguageStrings.AppProcessStatus;
            colHeaderOrderPurchaseDate.Text = LanguageStrings.AppPurchaseDate;
            colHeaderOrderStatus.Text = LanguageStrings.AppStatus;
            colHeaderReplies.Text = LanguageStrings.AppHelpDeskReplies;
            colHeaderStatus.Text = LanguageStrings.AppStatus;
            colHeaderTherapist.Text = LanguageStrings.AppStaffMember;
            colHeaderTicketKey.Text = LanguageStrings.AppHelpDeskKey;
            colHeaderTitle.Text = LanguageStrings.AppHelpDeskSubject;
            colHeaderTreatment.Text = LanguageStrings.AppDescription;

            lblAddressLine1.Text = LanguageStrings.AddressLine1;
            lblAddressLine2.Text = LanguageStrings.AddressLine2;
            lblAddressLine3.Text = LanguageStrings.AddressLine3;
            lblAutoGoldDiscount.Text = LanguageStrings.AppCustomerAutoGoldDiscount;
            lblAutoSalonDiscount.Text = LanguageStrings.AppCustomerAutoSalonDiscount;
            lblBirthDate.Text = LanguageStrings.AppBirthDate;
            lblBusinessName.Text = LanguageStrings.BusinessName;
            lblCity.Text = LanguageStrings.City;
            lblCountry.Text = LanguageStrings.Country;
            lblCounty.Text = LanguageStrings.County;
            lblCustomer.Text = LanguageStrings.AppCustomerName;
            lblDeliveryAddressCity.Text = LanguageStrings.City;
            lblDeliveryAddressCountry.Text = LanguageStrings.Country;
            lblDeliveryAddressCounty.Text = LanguageStrings.County;
            lblDeliveryAddressLine1.Text = LanguageStrings.AddressLine1;
            lblDeliveryAddressLine2.Text = LanguageStrings.AddressLine2;
            lblDeliveryAddressLine3.Text = LanguageStrings.AddressLine3;
            lblDeliveryAddressName.Text = LanguageStrings.Name;
            lblDeliveryAddressPostcode.Text = LanguageStrings.Postcode;
            lblEmail.Text = LanguageStrings.AppEmail;
            lblFirstName.Text = LanguageStrings.FirstName;
            lblMemberLevel.Text = LanguageStrings.AppMemberLevel;
            lblPostCode.Text = LanguageStrings.Postcode;
            lblSalonDistributionOutlets.Text = LanguageStrings.AppCustomerOutlets;
            lblSurname.Text = LanguageStrings.LastName;
            lblTelephone.Text = LanguageStrings.Telephone;

            tabPageAffiliate.Text = LanguageStrings.Affiliate;
            lblAffiliatedDescription.Text = LanguageStrings.AffiliateDescription;
            affColumnHeaderClickPrice.Text = LanguageStrings.AffiliatePricePerClick;
            affColumnHeaderID.Text = LanguageStrings.AffiliateID;
            affColumnHeaderPercentage.Text = LanguageStrings.AffiliatePercentage;
            affColumnHeaderURL.Text = LanguageStrings.AffiliateURL;
            affiliateToolStripMenuDelete.Text = LanguageStrings.Delete;
            affiliateToolStripMenuEdit.Text = LanguageStrings.Edit;
            affiliateToolStripMenuNew.Text = LanguageStrings.New;
            gbAffiliateItemSettings.Text = LanguageStrings.AffiliateLinks;
            lblAffUsage1.Text = LanguageStrings.AffiliateLink1;
            lblAffUsage2.Text = LanguageStrings.AffiliateLink2;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ApplicationController.GetUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave);

            if (!btnSave.Enabled)
            {
                if (AppController.ActiveUser.MemberLevel >= MemberLevel.StaffMember &&
                    _UserEdit.MemberLevel <= MemberLevel.GoldUser)
                {
                    btnSave.Enabled = true;
                    cmbMemberLevel.Enabled = false;
                }
            }

            btnSave.Visible = btnSave.Enabled;

            if (!btnSave.Visible)
            {
                btnCancel.Left = btnSave.Left;
                btnCancel.Text = LanguageStrings.AppMenuButtonClose;

                this.Text = LanguageStrings.AppCustomerViewDetails;
            }

            cbEmail.Enabled = btnSave.Visible;
            cbTelephone.Enabled = btnSave.Visible;
            cbPostal.Enabled = btnSave.Visible;

            txtAddLine1.Enabled = btnSave.Visible;
            txtAddLine2.Enabled = btnSave.Visible;
            txtAddLine3.Enabled = btnSave.Visible;
            txtBusinessName.Enabled = btnSave.Visible;
            txtCity.Enabled = btnSave.Visible;
            txtCounty.Enabled = btnSave.Visible;
            txtEmail.Enabled = btnSave.Visible;
            txtFirstName.Enabled = btnSave.Visible;
            txtLastName.Enabled = btnSave.Visible;
            txtPostCode.Enabled = btnSave.Visible;
            txtTelephone.Enabled = btnSave.Visible;
            cmbCountry.Enabled = btnSave.Visible;
            cmbMemberLevel.Enabled = AppController.ActiveUser.HasPermissionPOS(
                SecurityEnums.SecurityPermissionsPOS.AlterUserMemberLevel) && 
                _UserEdit.MemberLevel <= MemberLevel.Reseller;

            if (!AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerAssignPermissions) || 
                _UserEdit.MemberLevel < MemberLevel.Distributor || _UserEdit.MemberLevel >= MemberLevel.StaffMember)
                tabUserOptions.TabPages.Remove(tabPagePermissions);

            if (!AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageAffiliates))
                tabUserOptions.TabPages.Remove(tabPageAffiliate);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadMonths()
        {
            cmbBirthMonth.Items.Clear();
            DateTime months = new DateTime(2012, 1, 1);

            while (months.Year == 2012)
            {
                cmbBirthMonth.Items.Add(months.ToString(StringConstants.DATE_FORMAT_MONTH_FULL, CultureInfo.CurrentUICulture));
                months = months.AddMonths(1);
            }
        }

        private void cmbBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currMonth = cmbBirthMonth.SelectedIndex + 1;

            DateTime days = new DateTime(2012, currMonth, 1);

            cmbBirthDay.Items.Clear();

            while (days.Month == currMonth)
            {
                cmbBirthDay.Items.Add(days.Day);
                days = days.AddDays(1);
            }

            cmbBirthDay.SelectedIndex = _UserEdit.BirthDate.Day - 1;
        }

        private void LoadCountries(ComboBox combo)
        {
            Countries countries = Countries.Get();

            combo.Items.Clear();

            foreach (Country country in countries)
            {
                combo.Items.Add(country);
            }
        }

        private void LoadUser()
        {
            txtUserName.Text = _UserEdit.UserName;
            txtFirstName.Text = _UserEdit.FirstName;
            txtLastName.Text = _UserEdit.LastName;
            txtEmail.Text = _UserEdit.Email;
            txtTelephone.Text = _UserEdit.Telephone;
            cbEmail.Checked = _UserEdit.OffersEmail;
            cbPostal.Checked = _UserEdit.OffersPost;
            cbTelephone.Checked = _UserEdit.OffersTelephone;
            txtNotes.Text = _UserEdit.Notes.Replace(StringConstants.SYMBOL_RETURN, StringConstants.SYMBOL_CRLF);
            LoadUserAddress();
            cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(_UserEdit.Country);

            foreach (object obj in cmbCountry.Items)
            {
                Country country = (Country)obj;

                if (country.ID == _UserEdit.Country.ID)
                {
                    cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(obj);
                    break;
                }
            }

            if (_UserEdit.MemberLevel < MemberLevel.StaffMember)
            {
                cmbMemberLevel.SelectedIndex = (int)_UserEdit.MemberLevel;
            }
            else
            {
                cmbMemberLevel.Visible = false;
                lblMemberLevel.Visible = false;
                lblBirthDate.Visible = false;
                cmbBirthDay.Visible = false;
                cmbBirthMonth.Visible = false;
            }

            if (_UserEdit.MemberLevel != MemberLevel.GoldUser)
                tabUserOptions.TabPages.Remove(tabPageGoldUser);
            else
                spnGoldUserDiscount.Value = _UserEdit.AutoDiscount;


            lstDeliveryAddresses.Items.Clear();

            if (_UserEdit.DeliveryAddresses.Count < 1)
                _UserEdit.DeliveryAddresses.Create(_UserEdit);

            foreach (DeliveryAddress addr in _UserEdit.DeliveryAddresses)
            {
                lstDeliveryAddresses.Items.Add(addr);
            }

            if (_UserEdit.MemberLevel >= MemberLevel.Distributor)
            {
                spnSalonDiscount.Value = _UserEdit.AutoDiscount;
            }
            else
                tabUserOptions.TabPages.Remove(tabPageSalonOwner);

            LoadAppointments();

            if (_UserEdit.BirthDate.Year > 1900 | _UserEdit.BirthDate.Year == 1800)
            {
                cmbBirthDay.SelectedIndex = _UserEdit.BirthDate.Day - 1;
                cmbBirthMonth.SelectedIndex = _UserEdit.BirthDate.Month - 1;
            }

            cbVIPCustomer.Checked = _UserEdit.VIPCustomer;
        }

        private void LoadUserAddress()
        {
            txtBusinessName.Text = _UserEdit.BusinessName;
            txtAddLine1.Text = _UserEdit.AddressLine1;
            txtAddLine2.Text = _UserEdit.AddressLine2;
            txtAddLine3.Text = _UserEdit.AddressLine3;
            txtCity.Text = _UserEdit.City;
            txtCounty.Text = _UserEdit.County;
            txtPostCode.Text = _UserEdit.PostCode;
        }

        private void LoadAppointments()
        {
            lvAppointments.Items.Clear();

            foreach (Appointment appt in _UserEdit.Appointments)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = appt.AppointmentDate.ToShortDateString();
                lvItem.SubItems.Add(appt.EmployeeName);
                lvItem.SubItems.Add(appt.TreatmentName);
                lvItem.SubItems.Add(Shared.Utilities.SplitCamelCase(appt.Status.ToString()));
                lvItem.SubItems.Add(appt.ID.ToString());
                lvAppointments.Items.Add(lvItem);
            }

            lvAppointments.Sort();
        }

        private void tabPageUserOrders_Enter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstOrders.BeginUpdate();
            try
            {
                lstOrders.Items.Clear();

                foreach (Order order in _UserEdit.Orders)
                {
                    ListViewItem item = lstOrders.Items.Add(String.Format(StringConstants.ORDER_PREFIX, order.ID));
                    //Enums.PaymentMethod paytype = order.
                    item.SubItems.Add(order.ProcessStatus.ToString());
                    item.SubItems.Add(order.Status == null ? LanguageStrings.Unknown : order.Status.ToString());
                    item.SubItems.Add(order.PurchaseDateTime.ToString(StringConstants.SYMBOL_DATE_FORMAT_G));
                    item.SubItems.Add(order.ID.ToString());
                }
            }
            finally
            {
                lstOrders.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void tabPageUserInvoices_Enter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstInvoices.BeginUpdate();
            try
            {
                lstInvoices.Items.Clear();

                foreach (Invoice inv in _UserEdit.Invoices)
                {
                    ListViewItem item = lstInvoices.Items.Add(String.Format(StringConstants.PREFIX_AND_SUFFIX,
                        inv.ID, AppController.LocalSettings.InvoicePrefix));
                    PaymentStatus paytype = inv.PaymentType;
                    item.SubItems.Add(paytype.ToString());
                    item.SubItems.Add(inv.ProcessStatus.ToString());
                    item.SubItems.Add(inv.Status.ToString());
                    item.SubItems.Add(inv.PurchaseDateTime.ToString(StringConstants.SYMBOL_DATE_FORMAT_G));
                    item.SubItems.Add(inv.ID.ToString());
                }
            }
            finally
            {
                lstInvoices.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstInvoices_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstInvoices.SelectedItems)
            {
                Invoice inv = Library.BOL.Invoices.Invoices.Get(Convert.ToInt32(itm.SubItems[5].Text));

                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_INVOICE, inv));
            }
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void cmbMemberLevel_Format(object sender, ListControlConvertEventArgs e)
        {
            MemberLevel memberlevel = (MemberLevel)Convert.ToInt32(e.ListItem);
            e.Value = Shared.Utilities.SplitCamelCase(memberlevel.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Length < 6)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCustomerEmailMandatory);
                    return;
                }

                if (cmbCountry.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorSelectCountry);
                    cmbCountry.DroppedDown = true;
                    return;
                }

                if (cmbBirthDay.SelectedIndex == -1 && cmbBirthMonth.SelectedIndex == -1)
                {
                    if (!ShowQuestion(LanguageStrings.DateOfBirth, LanguageStrings.AppCustomerInvalidDoB))
                        return;
                    else
                        POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreDateOfBirth,
                            String.Format(StringConstants.VALIDATION_CHECK_CUSTOMER, _UserEdit.ID, 
                            Shared.Utilities.MaximumLength(_UserEdit.UserName, 150)));
                }

                _UserEdit.FirstName = txtFirstName.Text;
                _UserEdit.LastName = txtLastName.Text;
                _UserEdit.Email = txtEmail.Text;
                _UserEdit.Telephone = txtTelephone.Text;
                _UserEdit.BusinessName = txtBusinessName.Text;
                _UserEdit.AddressLine1 = txtAddLine1.Text;
                _UserEdit.AddressLine2 = txtAddLine2.Text;
                _UserEdit.AddressLine3 = txtAddLine3.Text;
                _UserEdit.City = txtCity.Text;
                _UserEdit.County = txtCounty.Text;
                _UserEdit.Country = (Country)cmbCountry.Items[cmbCountry.SelectedIndex];
                _UserEdit.PostCode = txtPostCode.Text;

                if (_UserEdit.MemberLevel < MemberLevel.StaffMember)
                    _UserEdit.MemberLevel = (MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

                _UserEdit.OffersTelephone = cbTelephone.Checked;
                _UserEdit.OffersPost = cbPostal.Checked;
                _UserEdit.OffersEmail = cbEmail.Checked;
                _UserEdit.Notes = txtNotes.Text;

                if (cmbMemberLevel.Visible)
                {
                    if (_UserEdit.MemberLevel == MemberLevel.GoldUser)
                    {
                        _UserEdit.AutoDiscount = (int)spnGoldUserDiscount.Value;
                    }
                    else
                    {
                        _UserEdit.AutoDiscount = (int)spnSalonDiscount.Value;
                    }
                }

                _UserEdit.VIPCustomer = cbVIPCustomer.Checked;

                if (cmbBirthDay.SelectedIndex > -1 && cmbBirthMonth.SelectedIndex > -1)
                {
                    try
                    {
                        _UserEdit.BirthDate = new DateTime(1800, cmbBirthMonth.SelectedIndex + 1, cmbBirthDay.SelectedIndex + 1);
                    }
                    catch 
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppCustomerInvalidDoB);
                        return;
                    }
                }

                _UserEdit.Save();

                if (_UserEdit.MemberLevel > MemberLevel.User4 &&
                    _UserEdit.MemberLevel < MemberLevel.StaffMember &&
                    AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerAssignPermissions))
                    permissions1.Save();

                if (this.Modal)
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    Close();
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_STORE_DUPLICATE_USER_EMAIL))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCustomerEmailAlreadyListed);
                }
                else if (err.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCustomerEditedElsewhere);
                }
                else
                    throw;
            }
        }

        private void lstOrders_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstOrders.SelectedItems)
            {
                Order order = Library.BOL.Orders.Orders.Get(Convert.ToInt32(itm.SubItems[4].Text));
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_ORDER, order));
            }
        }

        private void tabTickets_Enter(object sender, EventArgs e)
        {
            lstTickets.Items.Clear();
            SupportTickets tickets = SupportTickets.Get(_UserEdit);

            foreach (SupportTicket ticket in tickets)
            {
                ListViewItem lvi = lstTickets.Items.Add(ticket.TicketKey);
                lvi.SubItems.Add(ticket.Department.ToString());
                lvi.SubItems.Add(ticket.Subject);
                lvi.SubItems.Add(ticket.Messages.Count.ToString());
                lvi.SubItems.Add(ticket.LastUpdated.ToShortDateString());
                lvi.SubItems.Add(ticket.LastUpdatedBy);
                lvi.SubItems.Add(ticket.ID.ToString());
            }

        }

        private void lstTickets_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstTickets.SelectedItems)
            {
                SupportTicket ticket = Library.BOL.Helpdesk.SupportTickets.Get(Convert.ToInt32(itm.SubItems[6].Text));

                if (ticket != null)
                {
                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_TICKET, ticket));
                    tabTickets_Enter(sender, e);
                }
            }
        }

        private void btnCleanAddress_Click(object sender, EventArgs e)
        {
            _UserEdit.FixAddress();
            LoadUserAddress();
        }

        private void cmbDeliveryCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void lstDeliveryAddresses_Format(object sender, ListControlConvertEventArgs e)
        {
            DeliveryAddress addr = (DeliveryAddress)e.ListItem;
            e.Value = addr.Address(false).Replace(StringConstants.SYMBOL_LINE_FEED, StringConstants.SYMBOL_SPACE);
        }

        private void lstDeliveryAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeliveryAddress addr = (DeliveryAddress)lstDeliveryAddresses.SelectedItem;

            txtDeliveryName.Text = addr == null ? String.Empty : addr.Name;
            txtDeliveryAddress1.Text = addr == null ? String.Empty : addr.AddressLine1;
            txtDeliveryAddress2.Text = addr == null ? String.Empty : addr.AddressLine2;
            txtDeliveryAddress3.Text = addr == null ? String.Empty : addr.AddressLine3;
            txtDeliveryCity.Text = addr == null ? String.Empty : addr.City;
            txtDeliveryCounty.Text = addr == null ? String.Empty : addr.County;
            txtDeliveryPostCode.Text = addr == null ? String.Empty : addr.PostCode;

            if (addr == null)
                return;

            foreach (object obj in cmbDeliveryCountry.Items)
            {
                Country country = (Country)obj;

                if (country.ID == addr.Country.ID)
                {
                    cmbDeliveryCountry.SelectedIndex = cmbDeliveryCountry.Items.IndexOf(obj);
                    break;
                }
            }

            btnDeliveryAddressSave.Enabled = true;
        }

        private void btnDeliveryAddressClean_Click(object sender, EventArgs e)
        {
            if (lstDeliveryAddresses.SelectedIndex > -1)
            {
                DeliveryAddress addr = (DeliveryAddress)lstDeliveryAddresses.SelectedItem;
                lstDeliveryAddresses_SelectedIndexChanged(sender, e);
                addr.FixAddress(AppController.LocalCulture);
                btnDeliveryAddressSave.Enabled = true;
            }
        }

        private void btnDeliveryAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                Country verificationCountry = (Country)cmbDeliveryCountry.SelectedItem;


                if (verificationCountry != null)
                {
                    // verify details
                    //if (verificationCountry.AddressSettings.HasFlag(AddressOptions.AddressLine1Mandatory))
                    //    Library.

                }

                DeliveryAddress addr = (DeliveryAddress)lstDeliveryAddresses.SelectedItem;
                addr.AddressLine1 = txtDeliveryAddress1.Text;
                addr.AddressLine2 = txtDeliveryAddress2.Text;
                addr.AddressLine3 = txtDeliveryAddress3.Text;
                addr.City = txtDeliveryCity.Text;
                addr.County = txtDeliveryCounty.Text;
                addr.Country = (Country)cmbDeliveryCountry.SelectedItem;
                addr.PostCode = txtDeliveryPostCode.Text;
                addr.Save();


                lstDeliveryAddresses.Items.Remove(addr);
                lstDeliveryAddresses.Items.Add(addr);

                btnDeliveryAddressSave.Enabled = false;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_ADDRESS_IN_USE))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCustomerAddressInUse);
                }
                else
                    throw;
            }
        }

        private void cmbMemberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberLevel newLevel = (MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

            if (newLevel == _UserEdit.MemberLevel)
                return;

            _UserEdit.MemberLevel = newLevel;


            if (newLevel >= MemberLevel.Distributor)
                tabUserOptions.TabPages.Add(tabPageSalonOwner);
            else
                tabUserOptions.TabPages.Remove(tabPageSalonOwner);

            if (newLevel == MemberLevel.GoldUser)
                tabUserOptions.TabPages.Add(tabPageGoldUser);
            else
                tabUserOptions.TabPages.Remove(tabPageGoldUser);
        }

        private void LoadSalons()
        {
            foreach (Salon salon in _UserEdit.Salons)
            {
                ListViewItem lvi = lstSalons.Items.Add(salon.Name);
                lvi.SubItems.Add(salon.ContactName);
                lvi.SubItems.Add(salon.Email);
                lvi.SubItems.Add(salon.URL);

                if (salon.VIPSalon)
                    lvi.SubItems.Add(LanguageStrings.AppVIP);
                else
                    lvi.SubItems.Add(StringConstants.SYMBOL_EMPTY_STRING);

                lvi.SubItems.Add(salon.ID.ToString());
            }
        }

        private void lstSalons_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstSalons.SelectedItems)
            {
                Library.BOL.Salons.Salon salon = AppController.Administration.SalonGet(Convert.ToInt32(itm.SubItems[5].Text));
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_EDIT_SALON, salon));
            }
        }

        private void lvAppointments_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lvAppointments.SelectedItems)
            {
                Appointment appt = _UserEdit.Appointments.Find(Convert.ToInt32(itm.SubItems[4].Text));

                if (appt != null)
                {
                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_EDIT_APPOINTMENT, appt));
                }
            }
        }

        private void btnSendPasswordReminder_Click(object sender, EventArgs e)
        {
            if (_UserEdit.SendPasswordEmail())
                ShowInformation(LanguageStrings.AppCustomerLoginDetails, 
                    String.Format(LanguageStrings.AppCustomerLoginDetailsSent, _UserEdit.UserName));
            else
                ShowInformation(LanguageStrings.AppCustomerLoginDetails, LanguageStrings.AppCustomerLoginDetailsInvalidEmail);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
                Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = Shared.Utilities.GetRandomPassword(6);

            if (ShowQuestion(LanguageStrings.AppResetPassword, String.Format(LanguageStrings.AppResetPasswordConfirm, newPassword), true))
            {
                _UserEdit.Password = newPassword;
            }
        }

        #region Affiliates

        private void lvAffiliatedItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvAffiliatedItems.SelectedItems.Count == 0)
                return;

            if (AffiliateItemEdit.Show((AffiliatedItem)lvAffiliatedItems.SelectedItems[0].Tag))
            {
                AffiliatedItem selAff = (AffiliatedItem)lvAffiliatedItems.SelectedItems[0].Tag;
                ListViewItem item = lvAffiliatedItems.SelectedItems[0];
                item.Text = selAff.AffiliateID;
                item.SubItems[1].Text = selAff.Url;
                item.SubItems[2].Text = selAff.Percentage.ToString();
                item.SubItems[3].Text = selAff.PricePerClick.ToString();

            }
        }

        private void affiliateToolStripMenuNew_Click(object sender, EventArgs e)
        {
            AffiliatedItem item = new AffiliatedItem(-1, _UserEdit, AffiliatedItems.UniqueID(), String.Empty,
                0, 0, false);

            if (AffiliateItemEdit.Show(item))
                LoadAffiliates();
        }

        private void affiliateToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            if (lvAffiliatedItems.SelectedItems.Count == 0)
                return;

            AffiliatedItem selAff = (AffiliatedItem)lvAffiliatedItems.SelectedItems[0].Tag;

            if (ShowQuestion(LanguageStrings.AffiliateDelete, LanguageStrings.AffiliateDeleteDescription))
            {
                selAff.Delete();
                LoadAffiliates();
            }
        }

        private void LoadAffiliates()
        {
            lvAffiliatedItems.Items.Clear();

            AffiliatedItems items = AffiliatedItems.Get(_UserEdit);

            foreach (AffiliatedItem item in items)
            {
                ListViewItem lvItem = new ListViewItem(item.AffiliateID);
                lvItem.Tag = item;
                lvItem.SubItems.Add(item.Url);
                lvItem.SubItems.Add(item.Percentage.ToString());
                lvItem.SubItems.Add(item.PricePerClick.ToString());
                lvAffiliatedItems.Items.Add(lvItem);
            }

            gbAffiliateItemSettings.Visible = false;
        }

        private void lvAffiliatedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAffiliatedItems.SelectedItems.Count == 0)
            {
                gbAffiliateItemSettings.Visible = false;
                return;
            }

            AffiliatedItem item = (AffiliatedItem)lvAffiliatedItems.SelectedItems[0].Tag;

            if (item != null)
            {
                if (String.IsNullOrEmpty(AppController.LocalSettings.AffiliateURL))
                {
                    ShowError(LanguageStrings.AffiliateItemError, LanguageStrings.AppErrorAffiliateURLRequired);
                    gbAffiliateItemSettings.Visible = false;
                    return;
                }

                gbAffiliateItemSettings.Visible = true;

                if (String.IsNullOrEmpty(item.Url))
                {
                    lblAffUsage2.Visible = false;
                    txtAffUsage2.Visible = false;
                }
                else
                {
                    lblAffUsage2.Visible = true;
                    txtAffUsage2.Visible = true;
                    txtAffUsage2.Text = String.Format(POS.Base.Classes.StringConstants.AFFILIATE_LINK_2, AppController.LocalSettings.AffiliateURL);
                }

                txtAffUsage1.Text = String.Format(POS.Base.Classes.StringConstants.AFFILIATE_LINK_1, AppController.LocalSettings.AffiliateURL, item.AffiliateID);
            }
        }

        #endregion Affiliates

        void tabUserOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabUserOptions.SelectedTab == tabAppointments)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditAppointments;
            else if (tabUserOptions.SelectedTab == this.tabMarketing)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditMarketing;
            else if (tabUserOptions.SelectedTab == this.tabPageAffiliate)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditAffiliate;
            else if (tabUserOptions.SelectedTab == this.tabPageDeliveryAddresses)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditDeliveryAddress;
            else if (tabUserOptions.SelectedTab == this.tabPageGoldUser)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditGoldUser;
            else if (tabUserOptions.SelectedTab == this.tabPageNotes)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditNotes;
            else if (tabUserOptions.SelectedTab == this.tabPagePermissions)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditPermissions;
            else if (tabUserOptions.SelectedTab == this.tabPageSalonOwner)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditSalonOwner;
            else if (tabUserOptions.SelectedTab == this.tabPageUserDetails)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditUserDetails;
            else if (tabUserOptions.SelectedTab == this.tabPageUserInvoices)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditInvoices;
            else if (tabUserOptions.SelectedTab == this.tabPageUserOrders)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditOrders;
            else if (tabUserOptions.SelectedTab == this.tabTickets)
                HelpTopic = POS.Base.Classes.HelpTopics.CustomerEditTickets;
        }

        #endregion Private Methods
    }
}
