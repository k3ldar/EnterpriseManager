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
 *  File: Step1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Affiliate;
using Library.BOL.Users;
using POS.Customers.Classes;

namespace POS.Customers.Controls.Wizards.Affiliate.PayCommission
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayAffiliateCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1(PayAffiliateCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
            LoadUsers();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblSelectPool.Text = LanguageStrings.AppCommissionPoolSelect;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerAffPayCommissionStep1;
        }

        public override bool NextClicked()
        {
            _settings.User = (User)cmbPools.SelectedItem;

            _settings.CommissionItems = AffiliateCommission.Get(_settings.User, DateTime.MinValue, DateTime.Now, false, true);

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadUsers()
        {
            cmbPools.Items.Clear();

            foreach (User user in AffiliatedItems.GetAffiliateUsers())
                cmbPools.Items.Add(user);

            cmbPools.SelectedIndex = 0;
        }

        private void cmbPools_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((User)e.ListItem).UserName;
        }

        #endregion Private Methods
    }
}
