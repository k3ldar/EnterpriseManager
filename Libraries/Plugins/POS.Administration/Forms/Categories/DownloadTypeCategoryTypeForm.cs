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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: DownloadTypeCategoryTypeForm.cs
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

using Library.BOL.Downloads;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class DownloadTypeCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public DownloadTypeCategoryTypeForm()
            :base (CategoryType.DownloadTypes)
        {
            InitializeComponent();
        }

        public DownloadTypeCategoryTypeForm(ref DownloadType downloadType)
            : this()
        {
            DownloadType = downloadType;
            IsNew = DownloadType == null;

            if (!IsNew)
            {
                Description = downloadType.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private DownloadType DownloadType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppDownloadType;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                DownloadType = DownloadTypes.Create(Description);
            }
            else
            {
                DownloadType.Description = Description;
                DownloadType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref DownloadType downloadType)
        {
            bool Result = false;

            DownloadTypeCategoryTypeForm frm = new DownloadTypeCategoryTypeForm(ref downloadType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                downloadType = frm.DownloadType;
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

