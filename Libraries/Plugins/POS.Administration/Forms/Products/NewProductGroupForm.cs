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
 *  File: NewProductGroupForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Products;
using POS.Base.Classes;

namespace POS.Administration.Forms.Products
{
    public partial class NewProductGroupForm : Base.Forms.BaseForm
    {
        #region Constructors

        public NewProductGroupForm()
        {
            InitializeComponent();

            //set NewProduct to null
            NewProductGroup = null;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = Base.Classes.HelpTopics.ProductGroupNew;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductGroupCreateNew;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Newly created product
        /// </summary>
        public ProductGroup NewProductGroup { private set; get; }

        #endregion Properties

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewProductGroup = createProductControl1.Create(AppController.Administration);

            if (NewProductGroup != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        #endregion Private Methods
    }
}