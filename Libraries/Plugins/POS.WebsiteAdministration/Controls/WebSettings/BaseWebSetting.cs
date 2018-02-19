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
 *  File: BaseWebSetting.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Library.BOL.Websites;

#pragma warning disable IDE1005

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class BaseWebSetting : POS.Base.Controls.BaseControl
    {
        public BaseWebSetting()
        {
            InitializeComponent();
        }

        protected void RaiseOnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public virtual string HelpString()
        {
            return (String.Empty);
        }

        public void UpdateSetting(string setting, bool isGlobal, int settingIndex)
        {
            SettingName = setting.ToUpper();
            IsGlobal = isGlobal;
            SettingIndex = settingIndex;
        }

        public void WebsiteChanged(Website website)
        {
            Website = website;

            Reload();
        }

        public virtual void Reload()
        {

        }

        public virtual void Save()
        {

        }

        public virtual void Clear()
        {

        }

        public virtual bool AllowDelete()
        {
            return (false);
        }

        public virtual void AfterLoad()
        {

        }

        public Website Website { get; set; }

        public bool IsGlobal { get; private set; }

        public string SettingName { get; private set; }

        public int SettingIndex { get; set; }

        public event EventHandler Changed;
    }
}
