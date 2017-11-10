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
 *  File: MainScreenStockControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  01/08/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.StockControl;
using Library.BOL.Locations;
using Library.BOL.Products;
using POS.Base.Classes;
using POS.StockControl.Controls;

namespace POS.StockControl.Forms
{
    public partial class MainScreenStockControl : POS.Base.Forms.BaseForm
    {
        #region Private Members

        #endregion Private Members

        #region Constructors

        public MainScreenStockControl()
        {
            InitializeComponent();

            CheckFormPosition(this);
            mainStockControl1.Initialise();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockControl;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppStockControl, AppController.ActiveUser.UserName);

        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
