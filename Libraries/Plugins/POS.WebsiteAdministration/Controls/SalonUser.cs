using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;
using Library;
using Library.Utils;
using Library.BOL.Salons;
using Library.BOL.Users;

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
