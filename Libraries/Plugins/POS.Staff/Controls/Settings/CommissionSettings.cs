using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Staff.Controls.Settings
{
    public partial class CommissionSettings : SharedControls.BaseSettings
    {
        public CommissionSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            csDueSoonBack.Description = Languages.LanguageStrings.AppDueSoonBackColor;
            csDueSoonFore.Description = Languages.LanguageStrings.AppDueSoonForeColor;
            csOverdueBack.Description = Languages.LanguageStrings.AppOverdueBackColor;
            csOverdueFore.Description = Languages.LanguageStrings.AppOverdueForeColor;
            csSelectedBack.Description = Languages.LanguageStrings.AppSelectedBackColor;
            csSelectedFore.Description = Languages.LanguageStrings.AppSelectedForeColor;

            lblDays.Text = Languages.LanguageStrings.Days;
            lblDueSoon.Text = Languages.LanguageStrings.AppCommissionDataDue;
        }

        public override bool SettingsSave()
        {
            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor = csDueSoonBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor = csDueSoonFore.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor = csOverdueBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor = csOverdueFore.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor = csSelectedBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor = csSelectedFore.Color.ToArgb().ToString();

            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays = (int)udDueSoon.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            csDueSoonBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor);
            csDueSoonFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor);
            csOverdueBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor);
            csOverdueFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor);
            csSelectedBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor);
            csSelectedFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor);
            udDueSoon.Value = POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays;
        }

        #endregion Overridden Methods
    }
}
