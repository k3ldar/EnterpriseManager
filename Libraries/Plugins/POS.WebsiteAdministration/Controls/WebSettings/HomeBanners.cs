using System.Globalization;

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class HomeBanners : BaseWebSetting
    {
        public HomeBanners()
        {
            InitializeComponent();
        }

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDescription.Text = Languages.LanguageStrings.AppWebSettingHomeBanners;
        }

        public override string HelpString()
        {
            return (POS.Base.Classes.HelpTopics.WebsiteSettingBanners);
        }
    }
}
