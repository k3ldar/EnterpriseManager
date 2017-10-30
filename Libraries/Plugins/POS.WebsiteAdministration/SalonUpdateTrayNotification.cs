using System;

using Languages;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    /// <summary>
    /// Tray notification for salon updates
    /// </summary>
    public class SalonUpdateTrayNotification : TrayNotification
    {
        #region Constructors

        public SalonUpdateTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = true;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 2;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            int countSalonUpdates = AppController.Administration.StatsSalonUpdates();
            this.Blinking = countSalonUpdates > 0;

            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppSalonUpdates;

            if (countSalonUpdates == 1)
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppSalonUpdate;

            Result = String.Format(Result, countSalonUpdates);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTraySalonUpdates);
        }

        public override void DoubleClick()
        {

        }

        public override bool CanLoad()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {

        }

        #endregion Overridden Methods
    }
}
