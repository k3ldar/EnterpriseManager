using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.BOL.Countries;
using POS.Base.Classes;

namespace POS.Diary.Controls
{
    public partial class DiarySettings : SharedControls.BaseSettings
    {
        public DiarySettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbMaxDiaryAge1Month.Text = Languages.LanguageStrings.AppSettingsDiaryDiaryAge;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.DiaryUseMinimumDate = !cbMaxDiaryAge1Month.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbMaxDiaryAge1Month.Checked = !AppController.LocalSettings.DiaryUseMinimumDate;
        }

        #endregion Overridden Methods

    }
}
