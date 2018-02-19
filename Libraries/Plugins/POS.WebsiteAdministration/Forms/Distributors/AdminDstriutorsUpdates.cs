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
 *  File: AdminDstriutorsUpdates.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using POS.Base.Classes;
using Library.BOL.Salons;
using Library.BOL.Users;

namespace POS.WebsiteAdministration.Forms.Distributors
{
    public partial class AdminSalonUpdates : POS.Base.Controls.BaseTabControl
    {
        private User _User;

        public AdminSalonUpdates(User user)
        {
            _User = user;
            InitializeComponent();

            LoadSalonUpdates();
        }

        protected override void SetPermissions()
        {

        }

        public void LoadSalonUpdates()
        {
            lstSalons.Items.Clear();
            Library.BOL.Salons.Salons salons = AppController.Administration.SalonUpdatesGet(1, 1000);

            foreach (Salon salon in salons)
            {
                ListViewItem lvi = lstSalons.Items.Add(salon.Name);
                lvi.SubItems.Add(salon.ID.ToString());
            }
        }

        private void lstSalons_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstSalons.SelectedItems)
            {
                Library.BOL.Salons.Salon salon = AppController.Administration.SalonGet(Convert.ToInt32(itm.SubItems[1].Text));

                //is it a distributor
                if (salon == null)
                    salon = AppController.Administration.DistributorGet(Convert.ToInt32(itm.SubItems[1].Text));

                Salon salonUpdate = AppController.Administration.SalonOwnerUpdateGet(null, salon);//salon.UpdateOwner(), salon);

                if (salon != null)
                {
                    AdminSalonUpdate salonUpdateForm = new AdminSalonUpdate(salon, salonUpdate);
                    try
                    {
                        salonUpdateForm.ShowDialog(this);
                        LoadSalonUpdates();
                    }
                    finally
                    {
                        salonUpdateForm.Dispose();
                        salonUpdateForm = null;
                    }
                }
            }
        }


    }
}
