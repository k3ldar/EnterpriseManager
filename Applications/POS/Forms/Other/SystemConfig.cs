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
 *  File: SystemConfig.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using POS.Base.Classes;

namespace PointOfSale.Forms.Other
{
    public partial class SystemConfig : POS.Base.Forms.BaseForm
    {
        public SystemConfig()
        {
            InitializeComponent();

            int count = ConfigurationSettings.GetConfigCount();
            cmbConfigNames.Items.Clear();

            for (int i = 0; i < count; i++)
                cmbConfigNames.Items.Add(ConfigurationSettings.GetConfigName(i));

            cmbConfigNames.SelectedIndex = 0;
        }

        private void cmbConfigNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = ConfigurationSettings.GetConfigValue((string)cmbConfigNames.SelectedItem);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConfigurationSettings.SetConfigValue((string)cmbConfigNames.SelectedItem, txtValue.Text.Trim());
        }
    }
}
