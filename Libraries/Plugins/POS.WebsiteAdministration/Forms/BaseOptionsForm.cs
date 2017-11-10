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
 *  File: BaseOptionsForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SieraDelta.POS.WebsiteAdministration.Forms
{
    public partial class BaseOptionsForm : SieraDelta.POS.Forms.BaseForm
    {
        public BaseOptionsForm()
        {
            InitializeComponent();
        }

        #region Properties

        protected bool IsEditing { get; set; }

        #endregion Properties

        #region Protected Methods

        protected virtual void OnCreate()
        {

        }

        protected virtual void OnDelete()
        {

        }

        protected virtual void OnSave()
        {

        }

        protected virtual void UpdateUI(bool itemSelected)
        {
            if (itemSelected)
            {
                toolStripButtonDelete.Enabled = true;
                toolStripButtonSave.Enabled = IsEditing;
            }
            else
            {
                toolStripButtonDelete.Enabled = false;
                toolStripButtonSave.Enabled = false;
            }

            toolStripButtonCreate.Enabled = !IsEditing;
        }

        #endregion Protected Methods

        #region Private Methods

        private void toolStripButtonCreate_Click(object sender, EventArgs e)
        {
            OnCreate();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        #endregion Private Methods
    }
}
