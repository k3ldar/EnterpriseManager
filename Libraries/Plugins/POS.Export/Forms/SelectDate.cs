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
 *  File: SelectDate.cs
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

namespace POS.Export.Forms
{
    public partial class frmExportSelectDate : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public frmExportSelectDate()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = Languages.LanguageStrings.AppExportSelectDate;
            lblDescription.Text = Languages.LanguageStrings.AppExportSelectDateDesc;
            btnCancel.Text = Languages.LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = Languages.LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        public DateTime DateFrom
        {
            get
            {
                return (calSelectedDate.SelectionRange.Start.Date);
            }
        }

        #endregion Properties
    }
}
