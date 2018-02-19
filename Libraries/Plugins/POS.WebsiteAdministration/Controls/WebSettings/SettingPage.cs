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
 *  File: SettingPage.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  14/02/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Library.Interfaces;

#pragma warning disable IDE0017

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class SettingPage : BaseWebSetting, IWebsiteOptions
    {
        #region Private Members

        private string _pageName;
        private Library.BOL.Websites.Settings _settings;

        private bool _isLoaded;
        private int _totalDescriptions = 0;

        #endregion Private Members

        #region Constructors

        public SettingPage()
        {
            InitializeComponent();
            _settings = new Library.BOL.Websites.Settings();
            _isLoaded = false;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void Save()
        {
            foreach (Control control in flowLayoutSettings.Controls)
            {
                if (control.GetType() == typeof(WebsiteOption))
                {
                    WebsiteOption setting = (WebsiteOption)control;
                    setting.Save();
                }
            }
        }

        public override void Reload()
        {
            if (!_isLoaded)
            {
                _settings.WebSiteOptions(_pageName, this);
                _isLoaded = true;
                AfterLoad();
            }
        }

        public override void AfterLoad()
        {
            flowLayoutSettings.Width = this.Width - 6;

            foreach (Control ctl in flowLayoutSettings.Controls)
                ctl.Width = flowLayoutSettings.Width - 30;

            flowLayoutSettings.Top = GetLabelHeights();
            flowLayoutSettings.Height = Height - (flowLayoutSettings.Top - 3);
        }

        #endregion Overridden Methods

        #region Public Methods

        public void SetPage(string pageName)
        {
            if (String.IsNullOrEmpty(pageName))
                throw new ArgumentNullException(nameof(pageName));

            _pageName = pageName;
            lblHeader.Text = pageName;
        }

        public void SettingUpdated()
        {
            RaiseOnChanged();
        }

        #endregion Public Methods

        #region IWebsiteOptions

        public void AddDescription(string description)
        {
#warning replace with string constants
            description = description.Replace("<p>", String.Empty).Replace("</p>", "\r\n").Replace("<br />", "\r\n");
            _totalDescriptions++;
            Label descLabel = new Label();
            descLabel.Parent = this;
            descLabel.AutoSize = true;
            descLabel.Left = 8;
            descLabel.Top = (_totalDescriptions * 20) + 4;
            descLabel.Width = this.Width - 6;
            descLabel.Height = descLabel.Height * 2;
            descLabel.MinimumSize = descLabel.Size;
            descLabel.Text = description;
        }

        public void AddHeader(string header)
        {
            lblHeader.Text = header;
        }

        public void AddOption(string name, int value, string description, string reference, int defaultValue, int minValue, int maxValue, bool isGlobal = false)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, value, decimal.MinValue,
                decimal.MaxValue, Website.ID, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        public void AddOption(string name, double value, string description, string reference, bool isGlobal = false)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, value, double.MinValue, 
                double.MaxValue, Website.ID, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        public void AddOption(string name, decimal value, string description, string reference, bool isGlobal = false)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, value, decimal.MinValue, 
                decimal.MaxValue, Website.ID, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        public void AddOption(string name, bool value, string description, string reference, bool isGlobal = false)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, Website.ID, 250, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        public void AddOption(string name, string value, string description, string reference, int width = 300, 
            bool isPassword = false, bool isCulture = false, int numberOfLines = 1, bool isGlobal = false)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, Website.ID, width, isPassword,
                isCulture, numberOfLines, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        public void AddOption(string name, DateTime value, string description, string reference, bool isGlobal)
        {
            WebsiteOption websiteOption = new WebsiteOption();
            websiteOption.UpdateSetting(name, value, description, reference, Website.ID, isGlobal);
            websiteOption.Width = flowLayoutSettings.Width - 30;
            flowLayoutSettings.Controls.Add(websiteOption);
            websiteOption.SettingParent = this;
        }

        #endregion IWebsiteOptions

        #region Private Methods

        private int GetLabelHeights()
        {
            int Result = 0;

            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    Result += control.Height + 5;
                }
            }

            return (Result);
        }

        #endregion Private Methods
    }
}
