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
 *  File: Step2.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.DatabaseUpdates;
using POS.AutoUpdate.Classes;

namespace POS.AutoUpdate.Controls.Wizards.AddRule
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectItems.Text = LanguageStrings.AppAutoRuleSelectItems;
        }

        public override bool NextClicked()
        {
            if (clbItems.CheckedItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppAutoRuleSelectItemsToUpdateError);
                return (false);
            }

            _settings.ItemsAffected.Clear();

            foreach (AutoUpdateItem item in clbItems.CheckedItems)
                _settings.ItemsAffected.Add(item);

            return (base.NextClicked());
        }

        public override void PageShown()
        {
            LoadRuleItems();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadRuleItems()
        {
            clbItems.Items.Clear();
            AutoUpdateItems items = _settings.Rule.GetItems();

            foreach (AutoUpdateItem item in items)
            {
                int idx = clbItems.Items.Add(item);

                if (_settings.ItemsAffected.IndexOf(item) > -1)
                    clbItems.SetItemChecked(idx, true);
            }
        }

        private void clbItems_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((AutoUpdateItem)e.ListItem).Description;
        }

        #endregion Private Methods
    }
}
