using System;
using System.Globalization;
using System.Web.UI.WebControls;

using Library.BOL.Websites;

#pragma warning disable IDE1006

namespace Website.Library.Controls
{
    public partial class EditSettingsText : System.Web.UI.UserControl
    {
        #region Private Members

        private string _settingCode;
        private bool _isCulture;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbSetting.Visible)
                Classes.BaseWebApplication.ConfigSettingSet(_settingCode, cbSetting.Checked.ToString());
            else
            {
                if (_isCulture)
                {
                    // try and create a test culture
                    try
                    {
                        CultureInfo test = new CultureInfo(settingText.Text);
                    }
                    catch 
                    {
                        settingText.Text = Classes.BaseWebApplication.ConfigSettingGet(_settingCode,
                            WebsiteSettings.Languages.WebsiteCulture.Name);
                    }
                }

                Classes.BaseWebApplication.ConfigSettingSet(_settingCode, settingText.Text);
            }
        }

        #endregion Protected Methods

        #region Public Methods

        public void UpdateSetting(string name, string value, string description, string settingCode,
            int width = 250, bool isPassword = false, bool isCulture = false, int numberOfLines = 1)
        {
            _isCulture = isCulture;
            _settingCode = settingCode;
            settingDescription.InnerHtml = description;
            settingName.InnerText = name;
            settingText.Text = value;
            settingText.Width = width;
            cbSetting.Visible = false;
            settingText.Visible = true;

            if (isPassword)
            {
                settingText.TextMode = TextBoxMode.Password;
            }
            else if (numberOfLines == 1)
            {
                settingText.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                settingText.TextMode = TextBoxMode.MultiLine;
                settingText.Rows = numberOfLines;
            }
        }

        public void UpdateSetting(string name, bool value, string description, string settingCode, int width = 250)
        {
            _settingCode = settingCode;
            settingDescription.InnerHtml = description;
            settingName.InnerText = name;
            cbSetting.Checked = value;
            settingText.Visible = false;
            cbSetting.Visible = true;
        }

        #endregion Public Methods
    }
}