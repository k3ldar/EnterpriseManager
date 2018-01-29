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
 *  File: NewTagName.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  29/01/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using POS.Base.Classes;

using Languages;

namespace POS.Base.Forms
{
    public partial class NewTagName : BaseForm
    {
        #region Constructors

        public NewTagName()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Public Statc Methods

        public static bool CreateTag(out string tag)
        {
            tag = String.Empty;

            NewTagName newTagName = new NewTagName();
            try
            {
                if (newTagName.ShowDialog() == DialogResult.OK)
                {
                    tag = newTagName.txtTagName.Text;
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            finally
            {
                newTagName.Dispose();
                newTagName = null;
            }
        }

        #endregion Public Static Methods

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.TagCreate;
            lblTagName.Text = LanguageStrings.TagName;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTagName.Text.Contains(StringConstants.SYMBOL_SPACE))
            {
                ShowError(LanguageStrings.TagError, LanguageStrings.TagNameSpaceError);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Private Methods
    }
}
