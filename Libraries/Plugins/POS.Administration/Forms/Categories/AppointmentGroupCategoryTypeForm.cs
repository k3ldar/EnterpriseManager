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
 *  File: AppointmentGroupCategoryTypeForm.cs
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

using SharedBase.BOL.Appointments;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class AppointmentGroupCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public AppointmentGroupCategoryTypeForm()
            :base (CategoryType.AppointmentGroupTypes)
        {
            InitializeComponent();
        }

        public AppointmentGroupCategoryTypeForm(ref AppointmentGroup group)
            : this()
        {
            Group = group;
            IsNew = Group == null;

            if (!IsNew)
            {
                Description = group.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private AppointmentGroup Group { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppAppointmentGroup;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                Group = AppointmentGroups.Create(Description);
            }
            else
            {
                Group.Description = Description;
                Group.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref AppointmentGroup group)
        {
            bool Result = false;

            AppointmentGroupCategoryTypeForm frm = new AppointmentGroupCategoryTypeForm(ref group);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                group = frm.Group;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods
    }
}

