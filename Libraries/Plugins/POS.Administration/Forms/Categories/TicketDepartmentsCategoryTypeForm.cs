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
 *  File: TicketDepartmentsCategoryTypeForm.cs
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

using Library.BOL.Helpdesk;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class TicketDepartmentsCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public TicketDepartmentsCategoryTypeForm()
            :base (CategoryType.TicketDepartmentTypes)
        {
            InitializeComponent();
        }

        public TicketDepartmentsCategoryTypeForm(ref TicketDepartment departmentType)
            : this()
        {
            DepartmentType = departmentType;
            IsNew = DepartmentType == null;

            if (!IsNew)
            {
                Description = departmentType.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private TicketDepartment DepartmentType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppTicketDepartment;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                DepartmentType = TicketDepartments.Create(Description);
            }
            else
            {
                DepartmentType.Description = Description;
                DepartmentType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref TicketDepartment ticketGroup)
        {
            bool Result = false;

            TicketDepartmentsCategoryTypeForm frm = new TicketDepartmentsCategoryTypeForm(ref ticketGroup);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                ticketGroup = frm.DepartmentType;
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