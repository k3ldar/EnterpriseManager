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
 *  File: AdminDistributorUpdate.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using Library.BOL.Salons;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Distributors
{
    public partial class AdminSalonUpdate : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Salon _salon;

        #endregion Private Members

        #region Constructors

        public AdminSalonUpdate(Salon salon, Salon salonUpdate)
        {
            InitializeComponent();

            _salon = salon;
            salonUpdateCurrent.Refresh(salon);
            salonUpdateNew.Refresh(salonUpdate);
            salonUpdateNew.ShowChanges(salon);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebSalonUpdate;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonUpdateAdministration;

            btnAccept.Text = LanguageStrings.AppMenuButtonAcceptChanges;
            btnReject.Text = LanguageStrings.AppMenuButtonRejectChanges;

            lblCurrentSalonDetails.Text = LanguageStrings.AppSalonCurrentDetails;
            lblNewSalonDetails.Text = LanguageStrings.AppSalonNewDetails;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnReject_Click(object sender, EventArgs e)
        {
            AppController.Administration.SalonOwnerUpdateDelete(_salon.UpdateOwner(), _salon);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AppController.Administration.SalonOwnerUpdateMerge(_salon.UpdateOwner(), _salon);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
