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
 *  File: BaseCategoryEditAddForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;

using Languages;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class BaseCategoryEditAddForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        #endregion Private Members

        #region Constructors

        public BaseCategoryEditAddForm()
        {
            InitializeComponent();
        }

        public BaseCategoryEditAddForm(CategoryType type)
            : this()
        {
            CategoryType = type;
        }

        #endregion Constructors

        #region Properties

        protected bool IsNew { get; set; }

        /// <summary>
        /// Category type
        /// </summary>
        protected CategoryType CategoryType { get; set; }

        /// <summary>
        /// description
        /// </summary>
        protected string Description
        {
            get
            {
                return (txtName.Text);
            }

            set
            {
                txtName.Text = value;
            }
        }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnOK.Text = LanguageStrings.ButtonOK;
            btnCancel.Text = LanguageStrings.ButtonCancel;

            lblName.Text = LanguageStrings.Name;
        }

        #endregion Overridden Methods

        #region Protected Methods

        protected virtual void btnOKClick(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !String.IsNullOrEmpty(txtName.Text);
        }

        #endregion Protected Methods
    }
}
