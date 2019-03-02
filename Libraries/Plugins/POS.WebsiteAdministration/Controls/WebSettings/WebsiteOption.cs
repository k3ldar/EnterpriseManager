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
 *  File: WebsiteOption.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  16/02/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class WebsiteOption : UserControl
    {
        #region Private Members

        private string _settingCode;
        private bool _isCulture;
        private bool _isNumber;
        private bool _isDateTime;
        private int _minValueInt;
        private int _maxValueInt;
        private double _minValueDbl;
        private double _maxValueDbl;
        private decimal _minValueDec;
        private decimal _maxValueDec;
        private int _defaultValueInt;
        private double _defaultValueDbl;
        private decimal _defaultValueDec;
        private DateTime _defaultDateValue;
        private bool _isGlobal;
        private int _websiteID;

        #endregion Private Members

        #region Constructors

        public WebsiteOption()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods


        #endregion Overridden Methods

        #region Public Methods

        public void Save()
        {
            if (cbSetting.Visible)
            {
                SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingSet(_settingCode, 
                    cbSetting.Checked.ToString(), _websiteID, _isGlobal);
            }
            else
            {
                if (_isCulture)
                {
                    // try and create a test culture
                    try
                    {
                        txtValue.Text = cmbValue.Text;
                        CultureInfo test = new CultureInfo(txtValue.Text);
                    }
                    catch
                    {
                        txtValue.Text = SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingGet(
                            _settingCode, 
                            SharedBase.BOL.Websites.WebsiteSettings.Languages.WebsiteCulture.Name,
                            _websiteID, _isGlobal);
                    }
                }
                else if (_isNumber)
                {
                    switch (SettingValueType)
                    {
                        case SettingType.Integer:
                            if (_minValueInt != 0 && _maxValueInt != 0)
                            {
                                int value = Shared.Utilities.StrToInt(txtValue.Text, _defaultValueInt);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueInt, _maxValueInt).ToString();
                            }

                            break;
                        case SettingType.Decimal:
                            if (_minValueDec != 0 && _maxValueDec != 0)
                            {
                                decimal value = Shared.Utilities.StrToDecimal(txtValue.Text, _defaultValueDec);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueDec, _maxValueDec).ToString();
                            }

                            break;
                        case SettingType.Double:
                            if (_minValueDbl != 0 && _maxValueDbl != 0)
                            {
                                double value = Shared.Utilities.StrToDblDef(txtValue.Text, _defaultValueDbl);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueDbl, _maxValueDbl).ToString();
                            }

                            break;
                    }
                }
                else if (_isDateTime)
                {

                }

                SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingSet(_settingCode, 
                    txtValue.Text, _websiteID, _isGlobal);
            }
        }

        public void UpdateSetting(string name, DateTime value, string description, string settingCode, 
            int websiteID, bool isGlobal)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _isNumber = false;
            _isCulture = false;
            _isDateTime = true;
            _defaultDateValue = value;
            string dateFormatted = Shared.Utilities.FormatDate(value, "en-GB");
            UpdateSetting(name, dateFormatted, description, settingCode, websiteID, 200, false, false, 1, isGlobal);
            SettingValueType = SettingType.DateTime;
        }

        public void UpdateSetting(string name, int value, string description, string settingCode,
            int defaultValue, int minValue, int maxValue, int websiteID, bool isGlobal)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _isNumber = true;
            _minValueInt = minValue;
            _maxValueInt = maxValue;
            _defaultValueInt = defaultValue;

            UpdateSetting(name, value.ToString(), description, settingCode, websiteID, 100, false, false, 1, isGlobal);
            SettingValueType = SettingType.Integer;
            cbSetting.Visible = false;
            cmbValue.Visible = false;
        }

        public void UpdateSetting(string name, decimal value, string description, string settingCode,
            decimal defaultValue, decimal minValue, decimal maxValue, int websiteID, bool isGlobal)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _isNumber = true;
            _minValueDec = minValue;
            _maxValueDec = maxValue;
            _defaultValueDec = defaultValue;

            UpdateSetting(name, value.ToString(), description, settingCode, websiteID, 100, false, false, 1, isGlobal);
            SettingValueType = SettingType.Decimal;
            cbSetting.Visible = false;
            cmbValue.Visible = false;
        }

        public void UpdateSetting(string name, double value, string description, string settingCode,
            double defaultValue, double minValue, double maxValue, int websiteID, bool isGlobal)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _isNumber = true;
            _minValueDbl = minValue;
            _maxValueDbl = maxValue;
            _defaultValueDbl = defaultValue;

            UpdateSetting(name, value.ToString(), description, settingCode, websiteID, 100, false, false, 1, isGlobal);
            SettingValueType = SettingType.Double;
            cbSetting.Visible = false;
            cmbValue.Visible = false;
        }

        public void UpdateSetting(string name, string value, string description, string settingCode,
            int websiteID,
            int width = 250, bool isPassword = false, bool isCulture = false, int numberOfLines = 1,
            bool isGlobal = false)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _isCulture = isCulture;
            _settingCode = settingCode;
            lblDescription.Text = description;
            lblName.Text = name;
            SettingValueType = SettingType.String;

            string savedValue = SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingGet(settingCode, value, websiteID, isGlobal);

            txtValue.Text = value;

            if (value != savedValue)
            {
                txtValue.Text = savedValue;
            }

            txtValue.Width = width;
            cbSetting.Visible = false;
            cmbValue.Visible = _isCulture;
            txtValue.Visible = !_isCulture;

            if (isCulture)
            {
                LoadCultures();
                cmbValue.Left = 6;
            }
            else
            {
                if (isPassword)
                {
                    txtValue.PasswordChar = '*';
                }
                else if (numberOfLines == 1)
                {
                    txtValue.Multiline = false;
                    txtValue.Height = 20;
                }
                else
                {
                    txtValue.Multiline = true;
                    txtValue.Height = 20 * numberOfLines;
                    Height += 20 * numberOfLines;
                }
            }
        }

        public void UpdateSetting(string name, bool value, string description, string settingCode, 
            int websiteID, int width = 250, bool isGlobal = false)
        {
            _websiteID = websiteID;
            _isGlobal = isGlobal;
            _settingCode = settingCode;
            lblDescription.Text = description;
            lblName.Text = name;
            cbSetting.Checked = value;
            txtValue.Visible = false;
            cmbValue.Visible = false;
            SettingValueType = SettingType.Bool;
            Height = 47;
            cbSetting.Left = 6;
            cbSetting.Top = 28;
            lblDescription.Left = 20;

            bool savedValue = SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingGet(settingCode, value, _websiteID, isGlobal);

            if (value != savedValue)
            {
                cbSetting.Checked = savedValue;
            }

            cbSetting.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbSetting.Visible)
            {
                SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingSet(_settingCode, 
                    cbSetting.Checked.ToString(), _websiteID, _isGlobal);
            }
            else
            {
                if (_isCulture)
                {
                    // try and create a test culture
                    try
                    {
                        CultureInfo test = new CultureInfo(txtValue.Text);
                    }
                    catch
                    {
                        txtValue.Text = SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingGet(_settingCode,
                            SharedBase.BOL.Websites.WebsiteSettings.Languages.WebsiteCulture.Name, _websiteID, _isGlobal);
                    }
                }
                else if (_isNumber)
                {
                    switch (SettingValueType)
                    {
                        case SettingType.Integer:
                            if (_minValueInt != 0 && _maxValueInt != 0)
                            {
                                int value = Shared.Utilities.StrToInt(txtValue.Text, _defaultValueInt);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueInt, _maxValueInt).ToString();
                            }

                            break;
                        case SettingType.Double:
                            if (_minValueDbl != 0 && _maxValueDbl != 0)
                            {
                                if (String.IsNullOrEmpty(txtValue.Text))
                                    txtValue.Text = _defaultValueDbl.ToString();

                                double value = Shared.Utilities.StrToDbl(txtValue.Text);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueDbl, _maxValueDbl).ToString();
                            }

                            break;
                        case SettingType.Decimal:
                            if (_minValueDec != 0 && _maxValueDec != 0)
                            {
                                decimal value = Shared.Utilities.StrToDecimal(txtValue.Text, _defaultValueDec);
                                txtValue.Text = Shared.Utilities.CheckMinMax(value, _minValueDec, _maxValueDec).ToString();
                            }

                            break;
                    }
                }
                else if (_isDateTime)
                {

                }

                SharedBase.BOL.Websites.WebsiteSettings.ConfigSettingSet(_settingCode, txtValue.Text, _websiteID, _isGlobal);
            }
        }

        #endregion Public Methods

        #region Private Enum

        private enum SettingType
        {
            String,
            Integer,
            Decimal,
            Double,
            DateTime,
            Bool,
        }

        #endregion Private Enum

        #region Properties

        private SettingType SettingValueType { get; set; }

        internal SettingPage SettingParent { get; set; }

        #endregion Properties

        #region Private Members

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (SettingParent != null)
                SettingParent.SettingUpdated();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            if (cbSetting.Visible)
                cbSetting.Checked = !cbSetting.Checked;
        }

        private void LoadCultures()
        {
            cmbValue.Items.Clear();

            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                int idx = cmbValue.Items.Add(culture);

                if (culture.Name == txtValue.Text)
                    cmbValue.SelectedIndex = idx;
            }
        }

        #endregion Private Members
    }
}
