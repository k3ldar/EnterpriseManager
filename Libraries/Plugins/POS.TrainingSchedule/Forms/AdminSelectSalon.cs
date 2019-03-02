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
 *  File: AdminSelectSalon.cs
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase.Utils;
using SharedBase.BOL.Salons;

namespace POS.TrainingSchedule.Forms
{
    public partial class AdminSelectSalon : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public AdminSelectSalon()
        {
            InitializeComponent();

            LoadSalons();
        }

        #endregion Constructors

        #region Properties

        public Salon SelectedSalon
        {
            get
            {
                return ((Salon)lstSalons.SelectedItem);
            }

            set
            {
                lstSalons.SelectedIndex = -1;

                foreach (Salon salon in lstSalons.Items)
                {
                    if (salon.ID == value.ID)
                    {
                        lstSalons.SelectedIndex = lstSalons.Items.IndexOf(salon);
                        return;
                    }
                }
            }
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TrainingScheduleSelectSalon;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonSelect;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSalons()
        {
            SharedBase.BOL.Salons.Salons salons = SharedBase.BOL.Salons.Salons.Get(1, 10000);

            foreach (Salon salon in salons)
            {
                lstSalons.Items.Add(salon);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstSalons.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppSalonSelectError);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lstSalons_Format(object sender, ListControlConvertEventArgs e)
        {
            Salon salon = (Salon)e.ListItem;
            e.Value = salon.Name;
        }

        private void lstSalons_DoubleClick(object sender, EventArgs e)
        {
            if (lstSalons.SelectedIndex > -1)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
