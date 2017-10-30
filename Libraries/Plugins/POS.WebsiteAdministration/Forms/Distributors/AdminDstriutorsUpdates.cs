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
