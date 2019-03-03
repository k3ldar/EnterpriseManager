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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SalonUser.cs
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

using POS.Base.Classes;
using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Salons;
using SharedBase.BOL.Users;

namespace POS.WebsiteAdministration.Controls
{
    public partial class SalonUser : SharedControls.BaseControl
    {
        public event EventHandler OnDelete;

        private User _CurrentUser;
        private User _SalonUser;
        private Salon _Salon;

        public SalonUser(User user, Salon salon, User salonUser)
        {
            _CurrentUser = user;
            _Salon = salon;
            InitializeComponent();
            lblSalonName.Text = salon.Name;
            lblUserName.Text = salonUser.UserName;
            _SalonUser = salonUser;
            btnDelete.Enabled = user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnDelete.Text = Languages.LanguageStrings.AppDelete;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AppController.Administration.SalonOwnerDelete(_SalonUser, _Salon);
            DoSalonUserDeleted();
        }

        private void DoSalonUserDeleted()
        {
            if (OnDelete != null)
                OnDelete(this, new EventArgs());
        }
    }
}
