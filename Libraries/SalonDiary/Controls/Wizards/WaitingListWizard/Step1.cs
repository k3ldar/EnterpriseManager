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
 *  File: Step1.cs
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

using SalonDiary.Classes;
using Languages;
using SharedBase.BOL.Appointments;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.WaitingListWizard
{
    public partial class Step1 : BaseWizardPage
    {
        #region Private Members

        private WaitingListWizardOptions _options;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();
        }

        public Step1(WaitingListWizardOptions options)
            : this()
        {
            _options = options;
            btnDelete.Enabled = false;
        }

        #endregion Constructors

        #region Overridden Methods

        public override bool NextClicked()
        {
            if (!_options.IsNew)
            {
                if (lvCurrentWaitList.SelectedItems.Count == 0)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppWaitingListSelectPersonOrAdd);
                    return (false);
                }

                _options.WaitingListItem = (WaitingList)lvCurrentWaitList.SelectedItems[0].Tag;
            }

            return (true);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppSalonWaitingListSelectPerson;
            btnAdd.Text = LanguageStrings.AppMenuButtonAdd;
        }

        public override void PageShown()
        {
            lvCurrentWaitList.Items.Clear();

            foreach (WaitingList list in WaitingLists.All())
            {
                ListViewItem item = new ListViewItem();
                item.Text = list.Customer.UserName;
                item.ImageIndex = 0;
                item.Tag = list;
                lvCurrentWaitList.Items.Add(item);
            }
        }

        public override bool BeforeFinish()
        {

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _options.WaitingListItem = new WaitingList();
            _options.IsNew = true;
            this.MainWizardForm.SelectNextPage();
        }

        private void lvCurrentWaitList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCurrentWaitList.SelectedItems.Count == 0)
                return;

            _options.WaitingListItem = (WaitingList)lvCurrentWaitList.SelectedItems[0].Tag;
            _options.IsNew = false;
            MainWizardForm.SelectNextPage();
            MainWizardForm.SelectNextPage();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCurrentWaitList.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.AppDelete, LanguageStrings.AppDeleteSelectedItem))
            {
                _options.WaitingListItem = (WaitingList)lvCurrentWaitList.SelectedItems[0].Tag;
                _options.WaitingListItem.Delete();
                PageShown();
            }
        }

        private void lvCurrentWaitList_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = lvCurrentWaitList.SelectedItems.Count > 0;
        }

        #endregion Private Methods

        private void lvCurrentWaitList_MouseUp(object sender, MouseEventArgs e)
        {
            btnDelete.Enabled = lvCurrentWaitList.SelectedItems.Count > 0;
        }
    }
}
