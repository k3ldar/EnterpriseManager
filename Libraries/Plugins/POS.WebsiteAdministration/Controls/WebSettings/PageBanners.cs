using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class PageBanners : BaseWebSetting
    {
        public PageBanners()
        {
            InitializeComponent();
        }

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDescription.Text = Languages.LanguageStrings.AppWebSettingPageBanners;
        }

        public override string HelpString()
        {
            return (POS.Base.Classes.HelpTopics.WebsiteSettingPageBanners);
        }
    }
}
